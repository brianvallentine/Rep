using Cobol.Converter;
using CobolLanguageConverter.Converter.Commands;
using CobolLanguageConverter.Converter.CSHARP;
using CodeAnalyser.Helper;
using Copybook.Converter;
using FileResolver.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Reflection.Metadata.Ecma335.MethodBodyStreamEncoder;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.CobolDivisions
{
    //public class CobolProcedureDivisionCode
    //{
    //    //public static Dictionary<string, List<string>> ProcedureBlocks = new Dictionary<string, List<string>>();
    //    public static List<string> ParametersToPassBy = new List<string>();

    //    public string ConvertProcedureDivision(string sectionName, string cobolCode)
    //    {
    //        // Separar o código COBOL em linhas
    //        //string[] lines = cobolCode.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

    //        // Inicializar um StringBuilder para armazenar o código C# convertido
    //        var csharpCode = new StringBuilder();

    //        //var lineList = new List<string>();
    //        //var curName = sectionName.Contains(" USING") ? "USING" : "Execute";
    //        //var lastLineHeader = "";

    //        //// Processar linhas
    //        //foreach (string line in lines)
    //        //{
    //        //    //string trimmedLine = line;
    //        //    if (curName == "USING" && sectionName.Contains("."))
    //        //    {
    //        //        var threatedSectionName = Regex.Replace(sectionName, @"\s+", " ").Replace("PROCEDURE DIVISION USING ", "").Trim().TrimEnd('.');

    //        //        ProcedureBlocks.Add(curName, new List<string> { threatedSectionName });
    //        //        curName = "Execute";
    //        //        continue;
    //        //    }

    //        //    if (!string.IsNullOrEmpty(line) && line.Length > 6)
    //        //    {
    //        //        //       P010-TRATA-CPF-FIM. EXIT.
    //        //        var utilLine = line.Substring(7);
    //        //        // Verificar se é início de um bloco de método
    //        //        if (char.IsLetter(line[7]))
    //        //        {
    //        //            //existem métodos escritos na mesma linha, significa que vamos ter que dividir
    //        //            var spliter = lastLineHeader.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)?.Where(x => !x.Equals("."));
    //        //            if (lineList.Count == 0 && spliter?.Count() > 1)
    //        //            {
    //        //                lineList.Add(spliter.LastOrDefault());
    //        //            }

    //        //            ProcedureBlocks.Add(curName, lineList);
    //        //            curName = curName == "USING" ? "Execute" : GetMethodName(utilLine);
    //        //            lineList = new List<string>();
    //        //            lastLineHeader = utilLine;
    //        //            continue;
    //        //        }

    //        //        lineList.Add(utilLine);
    //        //    }
    //        //}

    //        //ProcedureBlocks.Add(curName, lineList);

    //        var hasExecuteParameter = false;
    //        var blockValue = new List<string>();
    //        var headerValue = "";
    //        // Adicionar métodos correspondentes aos blocos de método
    //        for (int i = 0; i < ProcedureBlocks.Count; i++)
    //        {
    //            var block = ProcedureBlocks.ElementAt(i);
    //            var methodName = block.Key;
    //            if (methodName == "USING")
    //            {
    //                hasExecuteParameter = true;
    //                blockValue = block.Value;
    //                headerValue = block.Key;
    //                continue;
    //            }

    //            ICSharpCommand.CurrentMethod = methodName;

    //            if (methodName != "Execute" && (block.Value.Count == 0 || (block.Value.Count == 1 && block.Value?.FirstOrDefault()?.Contains("EXIT") == true)))
    //            {
    //                csharpCode.AppendLine($"/*Método Suprimido por falta de linha ou apenas EXIT nome: {methodName}*/");
    //                continue;
    //            }

    //            csharpCode.Append($"\n[StopWatch]");
    //            csharpCode.Append($"\n\tpublic void {methodName}({ResolveMethodParameter(headerValue, blockValue, hasExecuteParameter)}) \n\t{{");

    //            if (ICSharpCommand.CurrentMethod == "Execute")
    //            {
    //                csharpCode.AppendLine("try {");

    //                //inicialização de parametros
    //                if (ParametersToPassBy.Count > 0)
    //                {
    //                    foreach (var item in ParametersToPassBy)
    //                    {
    //                        var splited = item.Split(" ");
    //                        var @class = splited[0];
    //                        var parameter = splited[1];
    //                        var paramType = H.GetReferenceProperty(parameter);
    //                        if (paramType == null)
    //                        {
    //                            paramType = H.GetReferencePropertyByClass(parameter);
    //                            if (paramType == null)
    //                            {
    //                                paramType = H.GetReferencePropertyByClass(@class);
    //                                if (paramType == null)
    //                                    continue;
    //                            }
    //                        }

    //                        var splitedParam = paramType?.PropertyName.Split(".");
    //                        for (int j = splitedParam.Length - 1; j >= 0; j--)
    //                        {
    //                            var param = splitedParam[j];
    //                            var localParamProp = H.GetReferenceProperty(param);
    //                            if (@class.Split(".").Last() == localParamProp.PropertyType)
    //                            {
    //                                csharpCode.AppendLine($"{localParamProp.PropertyName} = {parameter};");
    //                                break;
    //                            }
    //                        }
    //                    }
    //                }

    //                // Adicionar lógica correspondente usando ConvertMethodBlock
    //                if (!block.Value.Any())
    //                    block.Value.Add($"PERFORM {ProcedureBlocks.ElementAtOrDefault(i + 1).Key}");
    //            }

    //            string methodBody = ConvertMethodBody(block.Value);
    //            if (!string.IsNullOrEmpty(methodBody))
    //                csharpCode.AppendLine(methodBody);

    //            if (ICSharpCommand.CurrentMethod == "Execute")
    //            {
    //                csharpCode.AppendLine("}");
    //                csharpCode.AppendLine("catch(GoBack ex) {");
    //                csharpCode.AppendLine("}");
    //            }

    //            csharpCode.AppendLine($"}}");

    //            if (hasExecuteParameter)
    //                hasExecuteParameter = false;
    //        }

    //        ProcedureBlocks.Clear();

    //        // Retornar o código C# convertido
    //        return csharpCode.ToString();
    //    }

    //    private string ResolveMethodParameter(string header, List<string> lines, bool isExecuteMethod = false)
    //    {
    //        if (!isExecuteMethod) return "";

    //        var ret = "";
    //        if (header.Contains(" USING") && header.Contains("."))
    //        {
    //            var item = Regex.Replace(header.Trim(), @"^PERFORM\s+DIVISION\s+USING\s+", "");
    //            item = item.Replace(".", "");

    //            lines.Add(item);
    //        }

    //        //aqui vamos obter todas as referencias a variaveis da USING
    //        var convertedLines = new List<ReferenceModel>();
    //        foreach (var itemF in lines)
    //        {
    //            var item = itemF;
    //            if (item.EndsWith("."))
    //                item = item.Substring(0, item.Length - 1);

    //            var variable = H.GetReferenceProperty(item);
    //            if (variable != null)
    //                convertedLines.Add(variable);
    //        }

    //        //aqui vamos para cada variavel verificar sua classe "mae" 
    //        //assim podemos passar objetos não valores unicos
    //        ParametersToPassBy = new List<string>();
    //        foreach (var item in convertedLines.DistinctBy(x => x.PropertyParent))
    //        {
    //            //se o item que estou lendo dos parametros for class, posso utilizar diretamente seu tipo,
    //            //caso contrário devo utilizar o tipo de seu antecessor
    //            var propperAdd = item.PropertyIsClass ? item.PropertyType : item.PropertyParent;
    //            var variable = H.GetReferenceProperty("WSS");
    //            if (variable != null)
    //            {
    //                if (propperAdd == "WSS")
    //                {
    //                    propperAdd = $"PARAM_{CobolConverter.programName}";
    //                }

    //                if (propperAdd != null && !ParametersToPassBy.Contains(propperAdd))
    //                    ParametersToPassBy.Add($"{(item.PropertyIsCopy || propperAdd == $"PARAM_{CobolConverter.programName}" ? item.PropertyType : $"{variable.PropertyType}.{item.PropertyType}")} {propperAdd}");
    //            }
    //        }

    //        ret = string.Join(", ", ParametersToPassBy);

    //        return ret;
    //    }

    //    private string GetMethodName(string line, bool cSharpName = true)
    //    {
    //        // Extrair o nome do método
    //        string methodName = Regex.Match(line, @"(\bPERFORM\s*)?(?<NomeDoMetodo>\w+(?:-\w+)*)\b").Groups["NomeDoMetodo"].Value;
    //        if (cSharpName)
    //            methodName = methodName.Replace("-", "_");

    //        return methodName;
    //    }

    //    private string ConvertMethodBody(List<string> methodLines)
    //    {
    //        if (methodLines?.Any() != true)
    //            return "";

    //        var fullCommandLines = new List<string>();
    //        var output = new StringBuilder();
    //        var statements = new List<string> {
    //            "IF",
    //            "PERFORM",
    //            "EVALUATE",
    //            "MOVE",
    //            "ADD",
    //            "INITIALIZE",
    //            "SUBTRACT",
    //            "MULTIPLY",
    //            "DIVIDE",
    //            "STRING",
    //            "UNSTRING",
    //            "DISPLAY",
    //            "ACCEPT",
    //            "READ",
    //            "WHEN ",
    //            "WRITE",
    //            "REWRITE",
    //            "DELETE",
    //            "START",
    //            "GOBACK",
    //            "STOP RUN.",
    //            "STOP RUN",
    //            "CALL",
    //            "ELSE",
    //            "END-IF",
    //            "END-EVALUATE",
    //            "GO TO",
    //            "EXIT",
    //            "EXEC SQL",
    //            "END-PERFORM",
    //            " .",
    //        };

    //        var NO_PRINT = new List<string> {
    //            "END-STRING",
    //            Environment.NewLine,
    //            "\n",
    //            "",
    //            "EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC",
    //            "EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC",
    //            "EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC",
    //            "WHENEVER SQLERROR GOTO P910-DB2-ERRO END-EXEC",
    //            "EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC.",
    //            "EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC.",
    //            "EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC.",
    //            "WHENEVER SQLERROR GOTO P910-DB2-ERRO END-EXEC."
    //        };
    //        var commandBlock = new StringBuilder();

    //        #region converte as linhas em blocos de comando
    //        for (int i = 0; i < methodLines.Count; i++)
    //        {
    //            string line = methodLines[i].Trim();

    //            if (string.IsNullOrEmpty(line)) continue;

    //            // para que o WHEN não quebre o código, é preciso considerar a proxima linha, sendo assim
    //            if (line.Trim().Contains("WHEN "))
    //            {
    //                var matches = Regex.Match(line, @"WHEN\s+('[^']*'|[^\s]+)");
    //                if (matches.Success)
    //                {
    //                    if (!string.IsNullOrEmpty(commandBlock.ToString()))
    //                    {
    //                        fullCommandLines.Add(commandBlock.ToString());
    //                        commandBlock.Clear();
    //                    }
    //                    fullCommandLines.Add(matches.Value);
    //                    fullCommandLines.Add(line.Replace(matches.Value, string.Empty).Trim());
    //                    continue;
    //                }

    //                //if (!string.IsNullOrEmpty(commandBlock.ToString()))
    //                //    fullCommandLines.Add(commandBlock.ToString());

    //                //commandBlock.AppendLine(line);
    //            }

    //            //usado para marcar a string, para não confundir string com comando
    //            var marked = H.ToMarkedString(line, out var markedList).Trim();
    //            marked = Regex.Replace(marked, @"\s+", " ");

    //            if (statements.Any(x => marked.StartsWith(x, StringComparison.OrdinalIgnoreCase)))
    //            {
    //                if (!string.IsNullOrWhiteSpace(commandBlock.ToString()))
    //                {
    //                    fullCommandLines.Add(commandBlock.ToString());
    //                    commandBlock.Clear();
    //                }
    //            }

    //            commandBlock.AppendLine(line);
    //        }

    //        fullCommandLines.Add(commandBlock.ToString());
    //        #endregion

    //        foreach (var commandLine in fullCommandLines)
    //        {
    //            var line = commandLine.Trim();
    //            var allCommands = ConvertHelper.FindCommands<ICobolCommand>(Assembly.GetExecutingAssembly());
    //            var executedLine = false;

    //            if (FileResolverHelper.Conf.LogAllLines)
    //                output.AppendLine($"        \n/* {line.Replace(Environment.NewLine, " ")} */");

    //            var errors = new List<string>();
    //            foreach (var command in allCommands)
    //            {
    //                var response = command.Execute(line);

    //                if (response.Success && response.Executed)
    //                {
    //                    output.Append(response.Output);
    //                    executedLine = true;
    //                }

    //                if (!string.IsNullOrWhiteSpace(response.Error))
    //                    errors.Add(response.Error);
    //            }

    //            if ((!executedLine && !NO_PRINT.Contains(Regex.Replace(line.Trim(), @"\s+", " "))) && !FileResolverHelper.Conf.LogAllLines)
    //            {
    //                output.AppendLine($"        \n/* {line.Replace(Environment.NewLine, " ")} */");

    //                if (FileResolverHelper.Conf.ShowErrors && errors.Any())
    //                    output.AppendLine($"        /* {string.Join(Environment.NewLine, errors)} */");
    //            }
    //        }

    //        return output.ToString();
    //    }
    //}
}
