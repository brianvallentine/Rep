using Cobol.Converter;
using CobolLanguageConverter.Converter.CSHARP;
using CobolLanguageConverter.Converter.DIVISION;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System;
using System.Text;
using System.Xml.Linq;
using IA_ConverterCommons;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;
using Copybook.Converter;
using CodeAnalyser.Helper;
using FileResolver.Helper;
using System.Reflection;
using FileResolver;
using FileResolver.Model;
using System.Linq;
using System.Diagnostics;

namespace CobolLanguageConverter.Converter.Commands.CSHARP
{
    public class CSharp_PROCEDUREProcessConverterCommand : ICSharpCommand
    {
        public int Order { get; set; } = 28;
        public ResultSet Result { get; set; }
        public List<string> ParametersToPassBy = new List<string>();
        public static Stopwatch StopWatch { get; set; } = new Stopwatch();

        public StringBuilder Execute(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = PROCEDUREProcessConverter(csharpCode);
            return ret;
        }

        StringBuilder PROCEDUREProcessConverter(StringBuilder csharpCode)
        {
            var hasExecuteParameter = false;
            var blockValue = new List<CurrentLineType>();
            CurrentMethodType? headerValue = null;

            // Adicionar métodos correspondentes aos blocos de método
            for (int i = 0; i < Result.ProcedureReference.Count; i++)
            {
                var block = Result.ProcedureReference.ElementAt(i);
                var methodName = block.Key;
                var isExecute = methodName.Name == "Execute";
                var isExecuteReturnMethod = Result.IsCursorReturnProgram;
                var parameterNames = new List<string>();

                if (methodName.Name == "USING")
                {
                    hasExecuteParameter = true;
                    blockValue = block.Value;
                    headerValue = methodName;
                    continue;
                }

                if (!isExecute)
                {
                    blockValue = block.Value;
                    headerValue = methodName;
                }

                Result.CurrentMethod = block.Key;

                //if (!isExecute && (block.Value.Count == 0 || (block.Value.Count == 1 && (block.Value?.FirstOrDefault()?.Line?.Contains("EXIT") == true || block.Value?.FirstOrDefault()?.Line?.Contains("EJECT") == true))))
                if (H.IsIgnoredMethod(Result.CurrentMethod, Result))
                {
                    csharpCode.AppendLine($"/*Método Suprimido por falta de linha ou apenas EXIT nome: {methodName.Name}*/");
                    continue;
                }

                if (isExecute)
                {
                    //if (isExecuteReturnMethod)
                    csharpCode.AppendLine($"public dynamic Result {{ get; set; }}\n");

                    csharpCode.Append($"#endregion\n");
                }

                var parametersResolved = ResolveMethodParameter(headerValue, blockValue, isExecute);
                var blockParamView = FileResolverHelper.Conf.LogAllLines ? $"/*{string.Join("\n", blockValue.Select(x => x.Line.Replace("-", "_").Trim()))}*/" : "";

                csharpCode.Append($"\n[StopWatch]");
                if (FileResolverHelper.Conf.LogAllLines)
                    csharpCode.Append($"\n /*\" {methodName.Name.Replace("_", "-")} */");

                csharpCode.Append($"\n\t{(isExecute /*&& isExecuteReturnMethod*/ ? "public dynamic" : $"{(headerValue.NameWithoutSection.Contains("_DB_") ? "public" : "private")} void")} {methodName.Name}({parametersResolved}) {(isExecute ? $"//PROCEDURE DIVISION {(blockValue.Count > 0 ? "USING " : "")}\n{blockParamView}" : "")}\n\t{{");

                if (isExecute)
                {
                    var cursorResolver = Regex.Matches(csharpCode.ToString(), @" GetQuery_\S+", RegexOptions.Multiline);

                    csharpCode.AppendLine("try {");

                    var methodRefferToAPI = new List<ReferenceModel>();

                    //inicialização de parametros
                    if (ParametersToPassBy.Count > 0)
                    {
                        foreach (var item in ParametersToPassBy)
                        {
                            var splited = item.Split(" ");
                            var @class = splited[0];
                            var parameter = Regex.Replace(splited[1], @"_P\s*$", "");
                            //var parameter = splited[1].TrimEnd('_', 'P');

                            if (parameter.Contains("FILE_NAME"))
                            {
                                //var splitedFileVar = parameter.Split("_");
                                //var fileVar = splitedFileVar[0];
                                var fileVar = parameter.Replace("IN_SORT_", "");
                                fileVar = fileVar.Replace("INPUT_", "");
                                fileVar = fileVar.Replace("OUTPUT_", "");
                                fileVar = fileVar.Replace("_FILE_NAME", "");

                                var parametropNaModel = Result.FileAssignReference.Where(x => x.Key.Contains(fileVar)).ToList().FirstOrDefault().Value;
                                    
                                methodRefferToAPI.Add(new ReferenceModel(parameter, "string", propertyNameOnModel: parametropNaModel));
                                //esta linha adiciona o comportamento na saida
                                //parameterNames.Add($"{fileVar} = {fileVar}.Value");

                                csharpCode.AppendLine($"{fileVar}.SetFile({parameter}_P);");
                                continue;
                            }

                            var paramType = H.GetReferenceProperty(parameter, Result);
                            if (paramType == null)
                            {
                                paramType = H.GetReferencePropertyByClass(parameter, Result);
                                if (paramType == null)
                                {
                                    paramType = H.GetReferencePropertyByClass(@class, Result);
                                    if (paramType == null)
                                        continue;
                                }
                            }

                            methodRefferToAPI.Add(paramType);

                            var splitedParam = paramType?.PropertyName.Split(".");
                            for (int j = splitedParam.Length - 1; j >= 0; j--)
                            {
                                var param = splitedParam[j];
                                var localParamProp = H.GetReferenceProperty(param, Result);
                                if (@class.Split(".").Last() == localParamProp.PropertyType)
                                {
                                    var putValueProperty = VarBasis.VarBasysCommomTypes.Any(x => x.Name.ToLower() == localParamProp.PropertyType.ToLower());
                                    var valueProp = putValueProperty ? ".Value" : "";
                                    csharpCode.AppendLine($"this.{localParamProp.PropertyName}{valueProp} = {parameter}_P{valueProp};");
                                    parameterNames.Add(localParamProp.PropertyName);
                                    break;
                                }
                            }
                        }
                    }

                    Result.ApiMethodsReference.Add(new MethodReferenceInfo(Result.module, Result.programName, methodRefferToAPI));

                    //inicialização dos cursores
                    if (cursorResolver.Any())
                    {
                        //foreach (Match item in cursorResolver)
                        //{
                        //    if (!item.Success) continue;

                        //    var delegateMethodName = item.Value;
                        //    var cursorName = delegateMethodName.Replace("GetQuery_", "").Replace("()", "").Replace(";", "").Trim();
                        //    var cursorProperty = H.GetReferenceProperty(cursorName, Result);

                        //    csharpCode.AppendLine($"{cursorProperty.PropertyName}.GetQueryEvent += {delegateMethodName.Replace("()", "")};");
                        //}

                        csharpCode.AppendLine($"InitializeGetQuery();");
                    }

                    // Adicionar lógica correspondente usando ConvertMethodBlock
                    if (!block.Value.Any())
                        block.Value.Add(new CurrentLineType($"FLUXCONTROL_PERFORM {Result.ProcedureReference.ElementAtOrDefault(i + 1).Key.Name}", 0));
                }
                else
                {
                    // Adicionar lógica correspondente usando ConvertMethodBlock
                    //bloco novo em 03-09-2024, pode causar "bastante" problema
                    //a ideia se resume em procurar um "GOTO" ou "PERFORM" do método seguinte dentro do método atual
                    //o Cobol funciona proceduramente caso não tenha nenhuma chamada ao bloco subsequente
                    var procedureDivisionCode = string.Join(Environment.NewLine, block.Value.Select(x => x.Line));
                    var nextMethod = Result.ProcedureReference?.Skip(i+1)?.FirstOrDefault(x=> !x.Key.NameWithoutSection.Contains("_DB_")).Key;
                    if (nextMethod is not null && !block.Key.NameWithoutSection.Contains("_DB_"))
                    {
                        var hasMethodCaller = Regex.Match(procedureDivisionCode, $@"PERFORM.*?{nextMethod.Name.Replace("_", "-")}");
                        hasMethodCaller = hasMethodCaller.Success ? hasMethodCaller : Regex.Match(procedureDivisionCode, $@"GO\s*TO.*?{nextMethod.Name.Replace("_", "-")}");

                        var isExitOnly = block.Value.All(x => x.Line.Contains("Removido na conversão: EXIT"));
                        isExitOnly |= H.IsIgnoredMethod(nextMethod, Result);
                        if (
                                //!hasMethodCaller.Success && 
                                Result.CurrentMethod.MethodType == CurrentMethodTypeEnum.SECTION &&
                                !isExitOnly &&
                                nextMethod.MethodType != CurrentMethodTypeEnum.SECTION
                        )
                        {
                            //somente colocar o IF quando não for SECTION, pois um perform em uma section precisa executar todos os paragrafos "se houver"
                            var isCurrentSection = Result.CurrentMethod.MethodType == CurrentMethodTypeEnum.SECTION;

                            if (!isCurrentSection)
                                block.Value.Add(new CurrentLineType($"IF !isPerform", 0));

                            //if (isSection)
                            //{
                            //    var sectionList = Result.ProcedureReference.Skip(i + 1).TakeWhile(x => x.Key.MethodType != CurrentMethodTypeEnum.SECTION).ToList();
                            //    foreach (var sectionAdd in sectionList)
                            //        block.Value.Add(new CurrentLineType($"PERFORM {sectionAdd.Key.Name}", 0));
                            //}
                            //else
                            block.Value.Add(new CurrentLineType($"FLUXCONTROL_PERFORM {nextMethod.Name}", 0));

                            if (!isCurrentSection)
                                block.Value.Add(new CurrentLineType($"END-IF", 0));
                        }
                    }
                }

                // Verifica se o programa possui Return Code referenciado na Working e, caso tenha, adiciona como parâmetro para ser inserido no Result final
                if (Result.WorkingStorageReference.ContainsKey("RETURN_CODE"))
                {
                    parameterNames.Add($"CodigoRetorno = RETURN_CODE.Value");
                }
                

                string methodBody = ConvertMethodBody(block.Value);
                if (!string.IsNullOrEmpty(methodBody))
                    csharpCode.AppendLine(methodBody);

                if (isExecute)
                {
                    csharpCode.AppendLine("}");
                    csharpCode.AppendLine("catch(GoBack ex) {");
                    csharpCode.AppendLine("}");
                    csharpCode.AppendLine("");
                    csharpCode.AppendLine(@"if(!IsCall) DatabaseConnection.Instance.EndTransaction();");
                    csharpCode.AppendLine(@"");

                    if (!isExecuteReturnMethod && ParametersToPassBy.Count > 0)
                        csharpCode.AppendLine(@$"Result = new {{{string.Join(",", parameterNames)}}};");

                    csharpCode.AppendLine(@"return Result;");
                }

                csharpCode.AppendLine($"}}");

                if (isExecute)
                {
                    var cursorResolver = Regex.Matches(csharpCode.ToString(), @" GetQuery_\S+", RegexOptions.Multiline);
                    if (cursorResolver.Any())
                    {
                        csharpCode.AppendLine($"\npublic void InitializeGetQuery() {{");
                        foreach (Match item in cursorResolver)
                        {
                            if (!item.Success) continue;

                            var delegateMethodName = item.Value;
                            var cursorName = delegateMethodName.Replace("GetQuery_", "").Replace("()", "").Replace(";", "").Trim();
                            var cursorProperty = H.GetReferenceProperty(cursorName, Result);

                            csharpCode.AppendLine($"{cursorProperty.PropertyName}.GetQueryEvent += {delegateMethodName.Replace("()", "")};");
                        }
                        csharpCode.AppendLine($"}}");
                    }
                }


                if (hasExecuteParameter)
                    hasExecuteParameter = false;
            }

            // Retornar o código C# convertido
            csharpCode.AppendLine($"}}");
            return csharpCode;
        }

        private string ResolveMethodParameter(CurrentMethodType header, List<CurrentLineType> lines, bool isExecuteMethod = false)
        {
            if (!isExecuteMethod) return header?.MethodType == CurrentMethodTypeEnum.PARAGRAPH && !header.NameWithoutSection.Contains("_DB_") ? "bool isPerform = false" : "";

            var allProcCode = string.Join(Environment.NewLine, Result.ProcedureReference.Select(x => string.Join(Environment.NewLine, x.Value.Select(x => x.Line))));

            var ret = "";
            if (header?.Name.Contains(" USING") == true && header?.Name.Contains(".") == true)
            {
                var item = Regex.Replace(header.Name.Trim(), @"^PERFORM\s+DIVISION\s+USING\s+", "");
                item = item.Replace(".", "");

                lines.Add(new CurrentLineType(item, 0));
            }

            //aqui vamos obter todas as referencias a variaveis da USING
            var convertedLines = new List<ReferenceModel>();
            foreach (var itemF in lines)
            {
                var item = itemF.Line.Trim();
                if (item.EndsWith("."))
                    item = item.TrimEnd().TrimEnd('.').Trim();

                if (item.StartsWith(","))
                    item = item.TrimStart(',').Trim();

                foreach (var it in item.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                {
                    var variable = H.GetReferenceProperty(it, Result);
                    if (variable != null)
                        convertedLines.Add(variable);
                }
            }

            var rexSysins = Regex.Matches(allProcCode, @"ACCEPT\s+(?<varname>\S+(\s+OF\s+\S+)*)\s+FROM\s+SYSIN");
            foreach (var item in rexSysins.Where(x => x.Success))
            {
                var varname = item.Groups["varname"].Value;
                var variable = H.GetReferenceProperty(varname, Result);
                if (variable != null)
                    convertedLines.Add(variable);
            }

            //aqui vamos para cada variavel verificar sua classe "mae" 
            //assim podemos passar objetos não valores unicos
            ParametersToPassBy = new List<string>();

            foreach (var item in convertedLines.DistinctBy(x => x.PropertyParent))
            {
                //se o item que estou lendo dos parametros for class, posso utilizar diretamente seu tipo,
                //caso contrário devo utilizar o tipo de seu antecessor
                var propperAdd = item.PropertyIsClass ? item.PropertyType : item.PropertyParent;
                var variable = H.GetReferenceProperty(propperAdd, Result);
                if (variable == null)
                    variable = H.GetReferencePropertyByClass(propperAdd, Result);

                if (variable != null)
                {
                    //if (propperAdd == "WSS")
                    //{
                    //    propperAdd = $"PARAM_{Result.programName}";
                    //}

                    //if (string.IsNullOrWhiteSpace(item.PropertyParent))
                    //    ParametersToPassBy.Add($"{(item.PropertyIsCopy || propperAdd == $"PARAM_{Result.programName}" ? item.PropertyType : $"{item.PropertyType}")} {propperAdd}");

                    if (propperAdd != null && !ParametersToPassBy.Any(x => x.Contains(propperAdd)))
                    {
                        if (variable.PropertyIsClass)
                            ParametersToPassBy.Add($"{variable.PropertyType} {propperAdd}_P");
                        else
                            ParametersToPassBy.Add($"{variable.DataType.Name} {propperAdd}_P");
                    }
                }
            }


            var fileParameters = new List<string>();
            //Parametros de arquivos de entrada
            foreach (var item in Result.FileSelectReference)
            {
                var itemName = item.Key.Replace("_STATUS", "").Replace("_RELATIVE", "").Replace("_ASSIGN", "");
                if (!fileParameters.Any(x => Regex.IsMatch(itemName, @$"{x}\d*")))
                    fileParameters.Add(itemName);
            }

            // aqui temos todos os nomes de arquivos FD
            foreach (var item in fileParameters)
            {
                var isOutputFile = false;
                var isInputFile = false;
                var isSortFile = false;
                var allLines = string.Join(Environment.NewLine, Result.ProcedureReference.Values.Select(x => string.Join(Environment.NewLine, x)));
                var varFileName = $"{item}_";

                if (Regex.IsMatch(allLines, @$"WRITE\s+{item}") || Regex.IsMatch(allLines, @$"OPEN\s+OUTPUT\s+{item}"))
                    isOutputFile = true;

                if (Regex.IsMatch(allLines, @$"READ\s+{item}"))
                    isInputFile = true;

                if (Regex.IsMatch(allLines, @$"RETURN\s+{item}"))
                    isSortFile = true;

                if (isInputFile)
                    varFileName += "INPUT_";

                if (isOutputFile)
                    varFileName += "OUTPUT_";

                if (isSortFile)
                    varFileName += "IN_SORT_";

                varFileName += "FILE_NAME_P";

                ParametersToPassBy.Add($"string {varFileName}");
            }
            //Parametros de arquivos de entrada

            if (ParametersToPassBy?.Any() == true)
                Result.ParametersReference = ParametersToPassBy.ToDictionary(x => x.Split(" ").Skip(1).FirstOrDefault(), x => x.Split(" ").FirstOrDefault());

            ret = string.Join(", ", ParametersToPassBy);

            return ret;
        }

        public string ConvertMethodBody(List<CurrentLineType> methodLines)
        {
            if (methodLines?.Any() != true)
                return "";

            var output = new StringBuilder();
            var NO_PRINT = new List<string> {
                "END-STRING",
                Environment.NewLine,
                "SECTION",
                "SECTION.",
                "EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC",
                "EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC",
                "EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC",
                "WHENEVER SQLERROR GOTO P910-DB2-ERRO END-EXEC",
                "EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC.",
                "EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC.",
                "EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC.",
                "WHENEVER SQLERROR GOTO P910-DB2-ERRO END-EXEC.",
                "EXEC SQL WHENEVER SQLERROR GOTO P910-DB2-ERRO END-EXEC",
                @"EXEC SQL WHENEVER SQLERROR GO\s*TO \S+ END-EXEC",
                @"EXEC SQL WHENEVER SQLWARNING GO\s*TO \S+ END-EXEC",
                "CONTINUE",
                ".",
            };

            foreach (var commandLine in methodLines)
            {
                var lineRef = commandLine;
                var line = commandLine.Line.Trim();
                //remover o espaco do hexadecimal X'00'
                line = Regex.Replace(line, @"X\s*'00'", "X'00'");

                var allCommands = ConvertHelper.FindCommands<ICobolCommand>(Assembly.GetExecutingAssembly());
                var hasAnySuccessCommand = false;
                var afterExecuted = "";

                if (FileResolverHelper.Conf.LogAllLines)
                {
                    var logLine = line.Trim();
                    if (logLine.StartsWith("/*-"))
                        logLine = logLine.Replace("/*-", "").Replace("*/", "");

                    output.AppendLine($"        \n/*\" {(FileResolverHelper.Conf.LogNumber ? $"-{lineRef.LineNumber}- " : "")}{logLine.Replace("/*", "/-*").Replace("*/", "*-/").Replace(Environment.NewLine, " ")} */");
                }

                var errors = new List<string>();
                var executedLine = false;
                foreach (var command in allCommands)
                {
                    var beforeExecutedValidFromAnother = Result.PassByValidLineFromAnotherProcess == true;
                    command.Result = Result;
                    command.CurrentLine = lineRef;
                    var response = command.Execute(line);

                    if (response.Success && response.Executed)
                    {
                        output.Append(response.Output);
                        hasAnySuccessCommand = true;
                        executedLine = true;
                    }

                    if (!string.IsNullOrWhiteSpace(response.Error))
                        errors.Add(response.Error);

                    if (!string.IsNullOrWhiteSpace(response.AfterExecuted))
                        afterExecuted = response.AfterExecuted;

                    if (!beforeExecutedValidFromAnother)
                        Result.PassByValidLineFromAnotherProcess = executedLine;

                    if (FileResolverHelper.Conf.LogTimeLine)
                    {
                        //00:00:00.0024767
                        if (StopWatch.Elapsed > TimeSpan.FromMilliseconds(10))
                        {
                            var contains = command.GetType().Name.PadRight(25);
                            Console.WriteLine($" ---ICSharpCommand--{GetType().Name} -> {contains}em {StopWatch.Elapsed.ToString()}");

                            //Thread.Sleep(50);
                        }

                        StopWatch.Restart();
                    }

                    executedLine = false;
                }

                //controla a adição de "brackets" ou código que deve ser colocado após toda a execução
                if (!string.IsNullOrWhiteSpace(afterExecuted))
                    output.Append(afterExecuted);

                //Para cada linha, faz o invoke dos métodos que podem estar aguardando
                for (int i = Result.WaitingFor.Count - 1; i >= 0; i--)
                {
                    var item = Result.WaitingFor.ElementAt(i);
                    var successInvoke = item.Invoke(line, out var invokedString, out var removeIndexes);
                    if (successInvoke)
                    {
                        var fstDef = Result.WaitingFor.FirstOrDefault(x => x.Method.Name.ToString() == item.Method.Name);
                        var idx = Result.WaitingFor.IndexOf(fstDef);
                        removeIndexes.Add(idx);

                        removeIndexes = removeIndexes.OrderByDescending(x => x).Distinct().ToList();
                        foreach (var index in removeIndexes)
                            Result.WaitingFor.RemoveAt(index);

                        output.AppendLine(invokedString);
                        hasAnySuccessCommand = true;
                        break;
                    }
                }

                var isMathNoPrint = false;
                foreach (var item in NO_PRINT.Where(x => x.Contains(@"\")))
                {
                    var normLine = Regex.Replace(line.Trim(), @"\s+", " ");
                    isMathNoPrint = Regex.IsMatch(normLine, item);
                    if (isMathNoPrint) break;
                }

                if ((!hasAnySuccessCommand && (!NO_PRINT.Contains(Regex.Replace(line.Trim(), @"\s+", " ")) && !isMathNoPrint)))
                {
                    if (!line.Trim().StartsWith("/*-") && !line.Trim().StartsWith("/*\"") && !line.Trim().StartsWith("/*"))
                    {
                        output.AppendLine($"        \n/* {line.Replace(Environment.NewLine, " ")} */");

                        if (FileResolverHelper.Conf.ShowErrors && errors.Any())
                            output.AppendLine($"        /*Err-{string.Join(Environment.NewLine, errors)} */");
                    }
                }
            }

            return output.ToString();
        }

    }
}
