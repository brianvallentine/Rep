using CobolLanguageConverter.Converter.CSHARP;
using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using FileResolver.Helper;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands.DIVISIONS
{
    public class CSharp_CobolLineChangeCommand : ICSharpCommand
    {
        public int Order { get; set; } = 26;
        public ResultSet Result { get; set; }
        public static string ChangedKeyMarker = "__CHANGED__";
        public static string ChangedNewKeyMarker = "M-";

        public StringBuilder Execute(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = CobolLineChangeWhenDoublePointMove(csharpCode);
            ret = CobolLineChangeWhenEvaluateIsIf(ret);
            ret = CobolLineChangeWhenChangedMethodName(ret);
            ret = CobolLineChangeWhenWeirdLineAppear(ret);
            ret = CobolLineChangeWhenExecSqlAppear(ret);
            return ret;
        }

        StringBuilder CobolLineChangeWhenChangedMethodName(StringBuilder lines)
        {
            var ret = lines;

            //obtem a lista de métodos a serem alterados, pois o nome é incompativel com o C#
            //ordenado pelo tamanho para não substituir erroneamente EX: 999-999 acabar substituindo um método 9999-999
            var changedReferenceList = Result.ProcedureReference.Where(x => x.Key.Name.Contains(ChangedKeyMarker)).OrderByDescending(x => x.Key.Name.Length).ToList();

            //se tenho métodos a alterar
            if (changedReferenceList.Any())
            {
                //dos métodos que tenho a alterar preciso procurar por referencias dentro do código
                foreach (var referenceMethodToChange in changedReferenceList)
                {
                    //rodamos por todas as linhas da procedure division, para encontrar referencias dos métodos alterados
                    for (int i = 0; i < Result.ProcedureReference.Count; i++) // evitar foreach pois iremos alterar a lista dentro do for
                    {
                        //bloco da procedure division separado por método, então aqui KEY é o método e VALUES as linhas do método
                        var secLine = Result.ProcedureReference.ElementAt(i);

                        //resolvendo as linhas
                        for (int j = 0; j < secLine.Value.Count; j++)
                        {
                            var currentLine = secLine.Value[j].Line.Replace(Environment.NewLine, " ");
                            //var occurences = changedReferenceList.Where(x => Regex.IsMatch(currentLine, @$"\s+{x.Key.Replace(ChangedKeyMarker, "").Replace("_", "-")}")).ToList();
                            //var lastOccurences = changedReferenceList.Where(x => currentLine.Contains(x.Key.Replace(ChangedKeyMarker, "").Replace("_", "-"))).ToList();

                            //alterando as varias chamadas, caso haja mais de 1 aparição, irá resolver
                            var methodToContains = referenceMethodToChange.Key.Name.Replace(ChangedKeyMarker, "").Replace("_", "-");
                            if (Regex.IsMatch(currentLine, $@"\s+{methodToContains}"))
                            {
                                var header = referenceMethodToChange.Key.Name;
                                var newHeader = header.Replace(ChangedKeyMarker, ChangedNewKeyMarker).Replace("_", "-");
                                var originalMethodName = header.Replace(ChangedKeyMarker, "").Replace("_", "-");

                                currentLine = currentLine.Replace(originalMethodName, newHeader);
                                secLine.Value[j].Line = currentLine;
                            }
                            //alterando as chamadas das linhas
                        }

                        //resolvendo as keys ( nome do método na integra )
                        if (secLine.Key.Name.Contains(ChangedKeyMarker))
                        {
                            Result.ProcedureReference.Remove(secLine.Key);
                            secLine.Key.Name = secLine.Key.Name.Replace(ChangedKeyMarker, ChangedNewKeyMarker.Replace("-", "_"));
                            Result.ProcedureReference.Add(secLine.Key, secLine.Value);
                        }
                    }
                }
            }
            return ret;
        }

        StringBuilder CobolLineChangeWhenDoublePointMove(StringBuilder lines)
        {
            var ret = lines;

            for (int i = 0; i < Result.ProcedureReference.Count; i++)
            {
                var secLine = Result.ProcedureReference.ElementAt(i);

                for (int j = 0; j < secLine.Value.Count; j++)
                {
                    var currentLineRef = secLine.Value[j];
                    var currentLine = currentLineRef.Line.Replace(Environment.NewLine, " ");

                    //procura por Move's que contenham APÓS O TO mais de 1 variavel com 2 pontos
                    var rex = Regex.IsMatch(currentLine.Trim(), @"MOVE\s+.*\s+TO\s+.+?\:.+?\:", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(200));
                    if (!rex)
                        continue;

                    var splitedTo = currentLine.Trim().Split(" TO ", StringSplitOptions.RemoveEmptyEntries);
                    var moveCom = splitedTo[0];
                    splitedTo[1] = Regex.Replace(splitedTo[1], @"\s*\(\s*", @"(");
                    splitedTo[1] = Regex.Replace(splitedTo[1], @"\s*\)", @")");
                    splitedTo[1] = Regex.Replace(splitedTo[1], @"\s*:\s*", @":");
                    var splitedVars = splitedTo[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    foreach (var toValue in splitedVars)
                    {
                        secLine.Value.Insert(j + 1, new CurrentLineType($"{moveCom} TO {toValue}", currentLineRef.LineNumber));
                    }

                    secLine.Value.RemoveAt(j);
                }
            }
            return ret;
        }

        StringBuilder CobolLineChangeWhenEvaluateIsIf(StringBuilder lines)
        {
            var ret = lines;

            for (int i = 0; i < Result.ProcedureReference.Count; i++)
            {
                var secLine = Result.ProcedureReference.ElementAt(i);
                IEnumerable<CurrentLineType>? evaluateLines = null;
                var originalEvaluateVarName = "";

                for (int j = 0; j < secLine.Value.Count; j++)
                {
                    var currentLineRef = secLine.Value[j];
                    var currentLine = currentLineRef.Line.Replace(Environment.NewLine, " ");
                    if (string.IsNullOrWhiteSpace(currentLine.Trim())) continue;

                    //procura por END-EVALUATE fechando o ciclo, este geralmente é o ultimo passo
                    var rex = Regex.IsMatch(currentLine.Trim(), @"END-EVALUATE", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(200));
                    if (rex)
                    {
                        var mustPutEndIf = Result.IsIn.Contains("EVALUATE TRUE");

                        Result.IsIn.Remove("EVALUATE");
                        Result.IsIn.Remove("WHEN");
                        Result.IsIn.Remove("EVALUATE TRUE");
                        Result.IsIn.Remove("EVALUATE TRUE CASE");
                        evaluateLines = null;

                        var isInVarEvalEnd = Result.IsIn.FirstOrDefault(x => x.Contains("EVALUATE VAR-EVAL"));
                        if (isInVarEvalEnd != null)
                        {
                            Result.IsIn.Remove(isInVarEvalEnd);
                            mustPutEndIf = true;
                        }

                        if (mustPutEndIf)
                        {
                            if (FileResolverHelper.Conf.LogAllLines)
                                secLine.Value.Insert(j, new CurrentLineType($"/*- {secLine.Value[j].Line}*/", currentLineRef.LineNumber));

                            j++;
                            secLine.Value[j].Line = currentLine.Replace("END-EVALUATE", "END-IF");
                        }
                        continue;
                    }

                    //procura por EVALUATE com variaveis no WHEN, será alterado por IF's
                    rex = Regex.IsMatch(currentLine.Trim(), @"EVALUATE\s+TRUE", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(200));
                    if (rex)
                    {
                        Result.IsIn.Add("EVALUATE TRUE");
                        secLine.Value.RemoveAt(j);
                        if (FileResolverHelper.Conf.LogAllLines)
                            secLine.Value.Insert(j, new CurrentLineType($"/*- {currentLine}*/", currentLineRef.LineNumber));

                        continue;
                    }

                    //procura por EVALUATE TRUE, será alterado por IF's
                    var match = Regex.Match(currentLine.Trim(), @"EVALUATE\s+(?<varName>\S+(\s+OF\s+\S+\s*)*)", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(200));
                    if (match.Success)
                    {
                        var varName = match.Groups["varName"].Value;
                        var varRef = H.GetIfResponseForLine(varName, currentLineRef.LineNumber, Result)?.ToString();

                        //caso for uma substring REG-NOME-ARQUIVO(6:2), o evaluate precisa ser de strings
                        var mustToChangeToString = false;
                        if (varName.Contains(":") && varRef?.Contains("Substring") == true)
                            mustToChangeToString = true;

                        //vamos validar se todos evaluates contem constantes, se tiver variavel precisa virar IF
                        evaluateLines = secLine.Value
                                                .Where(x => x.LineNumber > currentLineRef.LineNumber)
                                                .TakeWhile(x => !x.Line.Contains("END-EVALUATE"))
                                                ;
                        var forLines = evaluateLines
                                                .Where(x => x.Line.Contains("WHEN "));

                        for (int k = 0; k < forLines.Count(); k++)
                        {
                            var item = forLines.ElementAt(k);
                            if (item.Line.Contains("'")) continue;

                            var lineTest = Regex.Match(item.Line, @"WHEN\s+(?<testItem>\S+(\s+OF\s+\S+)*)\s*");
                            var testItem = lineTest.Groups["testItem"].Value;

                            //no caso de ser int, vamos precisar verificar se precisa mudar pra STRING
                            if (int.TryParse(testItem, out var pTst) && !mustToChangeToString) continue;
                            if (testItem == "OTHER") continue;

                            var refTest = H.GetIfResponseForLine(lineTest.Groups["testItem"].Value, item.LineNumber, Result).ToString();

                            //no caso de ser int e precisa passar pra string, vamos precisar verificar se precisa mudar pra STRING
                            if (mustToChangeToString)
                            {
                                var newValue = lineTest.Value.Replace(lineTest.Groups["testItem"].Value, $"'{lineTest.Groups["testItem"].Value}'");
                                item.Line = newValue;
                                continue;
                            }

                            if (!string.IsNullOrEmpty(refTest))
                            {
                                originalEvaluateVarName = match.Groups["varName"].Value;
                                Result.IsIn.Add("EVALUATE VAR-EVAL " + originalEvaluateVarName);
                                secLine.Value.RemoveAt(j);

                                if (FileResolverHelper.Conf.LogAllLines)
                                    secLine.Value.Insert(j, new CurrentLineType($"/*- {currentLine}*/", currentLineRef.LineNumber));

                                break;
                            }
                        }

                        continue;
                    }

                    var isInTrueEval = Result.IsIn.Contains("EVALUATE TRUE");
                    var isInTrueCaseEval = Result.IsIn.Contains("EVALUATE TRUE CASE");
                    var isInVarEval = Result.IsIn.FirstOrDefault(x => x.Contains("EVALUATE VAR-EVAL"));

                    //caso esta seja uma linha de WHEN
                    var isWhen = Regex.IsMatch(currentLine.Trim(), @"WHEN\s+", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(200));

                    //existem momentos que, tendo uma lista de "when" aninhados para serem adicionados ao resultado final,
                    //quando não tinha condição se não fosse aninhada estava dando problema
                    /* exemplo:
                        EVALUATE PROPOVA-COD-PRODUTO                   
                            WHEN 8205 WHEN JVPROD(8205)                    
                            WHEN 8209 WHEN JVPROD(8209)                    
                            WHEN 9329 WHEN JVPROD(9329)                    
                            WHEN 9343 WHEN JVPROD(9343)                    
                              IF CLIENTES-TIPO-PESSOA NOT = 'J'            
                                 ADD 1 TO AC-REJEITADOS                    
                                 GO TO 0100-NEXT                           
                              END-IF                                       
                        END-EVALUATE                                   
                     */

                    if (!isWhen && (isInVarEval == null || isInVarEval?.IndexOf(" OR ") < 0)) continue;

                    //CASO SEJA WHEN OTHER
                    var isOther = Regex.IsMatch(currentLine.Trim(), @"WHEN\s+OTHER", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(200));

                    //verificando se temos um Evaluate do tipo variaveis que deve ser convertido para IF
                    if (isInVarEval != null)
                    {
                        //o IsIn vai conter o nome da variavel do Evaluate
                        var isInVarName = Regex.Match(isInVarEval, @"EVALUATE\s+VAR-EVAL\s+(?<varName>(.*\s*)+)").Groups["varName"].Value.Trim();
                        var localWhenList = evaluateLines?.Where(x => x.LineNumber >= currentLineRef.LineNumber).ToList();
                        var hasWhenCadence = localWhenList?.ElementAtOrDefault(1)?.Line?.Contains("WHEN ") == true;
                        var idx = Result.IsIn.IndexOf(isInVarEval);

                        //aqui quando temos um WHEN com cadencia
                        if (hasWhenCadence && isWhen)
                        {
                            var lineTest = $" OR {currentLine.Replace("WHEN ", $" ")} ";
                            if (isInVarName == originalEvaluateVarName)
                                lineTest = currentLine.Replace("WHEN ", $" EQUALS ");

                            secLine.Value[j].Line = $"/*- {secLine.Value[j].Line}*/";

                            Result.IsIn[idx] = isInVarEval += lineTest;
                            continue;
                        }

                        var lineToReplace = $"  {isInVarName}{(isWhen && !isOther ? " OR " : "")}";
                        if (isInVarName == originalEvaluateVarName && !isOther)
                            lineToReplace = $"  {isInVarName} EQUALS ";

                        if (isInTrueCaseEval)
                            if (!isOther)
                                currentLine = currentLine.Replace("WHEN ", $"ELSE IF {lineToReplace} ");
                            else
                                currentLine = "ELSE";
                        else if (isWhen && !isOther)
                        {
                            currentLine = currentLine.Replace("WHEN ", $"IF {lineToReplace} ");
                            Result.IsIn.Add("EVALUATE TRUE CASE");
                        }
                        else if (!isOther)
                        {
                            secLine.Value.Insert(j, new CurrentLineType($"IF {lineToReplace}", currentLineRef.LineNumber));
                            Result.IsIn[idx] = "EVALUATE VAR-EVAL " + originalEvaluateVarName;
                            continue;
                        }
                        else if (isOther && isWhen)
                        {
                            currentLine = $"ELSE";
                        }

                        Result.IsIn[idx] = "EVALUATE VAR-EVAL " + originalEvaluateVarName;

                        if (FileResolverHelper.Conf.LogAllLines)
                            secLine.Value.Insert(j, new CurrentLineType($"/*- {secLine.Value[j].Line}*/", currentLineRef.LineNumber));

                        j++;
                        secLine.Value[j].Line = currentLine;
                    }
                    else if (isInTrueEval)
                    {
                        if (isInTrueCaseEval)
                            if (!isOther)
                                currentLine = currentLine.Replace("WHEN ", "ELSE IF ");
                            else
                                currentLine = "ELSE";
                        else
                        {
                            currentLine = currentLine.Replace("WHEN ", "IF ");
                            Result.IsIn.Add("EVALUATE TRUE CASE");
                        }

                        if (FileResolverHelper.Conf.LogAllLines)
                            secLine.Value.Insert(j, new CurrentLineType($"/*- {secLine.Value[j].Line}*/", currentLineRef.LineNumber));

                        j++;
                        secLine.Value[j].Line = currentLine;
                    }
                }
            }
            return ret;
        }

        StringBuilder CobolLineChangeWhenWeirdLineAppear(StringBuilder lines)
        {
            var ret = lines;

            for (int i = 0; i < Result.ProcedureReference.Count; i++)
            {
                var secLine = Result.ProcedureReference.ElementAt(i);
                IEnumerable<CurrentLineType>? evaluateLines = null;
                var originalEvaluateVarName = "";

                for (int j = 0; j < secLine.Value.Count; j++)
                {
                    var currentLineRef = secLine.Value[j];
                    var currentLine = currentLineRef.Line.Replace(Environment.NewLine, " ");
                    if (string.IsNullOrWhiteSpace(currentLine.Trim())) continue;

                    //procura por END-EVALUATE fechando o ciclo, este geralmente é o ultimo passo
                    var rex = Regex.IsMatch(currentLine.Trim(), @"IF\s+SQLCODE\s+NOT\s+=\s+\(\s+0\s+AND\s+100\s+\)", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(200));
                    if (rex)
                    {
                        secLine.Value[j].Line = "IF SQLCODE NOT = 0 AND 100";
                    }

                }
            }

            return ret;
        }

        //método destinado a criar chamadas do SQL em métodos separados
        StringBuilder CobolLineChangeWhenExecSqlAppear(StringBuilder lines)
        {
            var ret = lines;

            for (int i = 0; i < Result.ProcedureReference.Count; i++)
            {
                var secLine = Result.ProcedureReference.ElementAt(i);
                var innerMethodCounter = 0;

                for (int j = 0; j < secLine.Value.Count; j++)
                {
                    var currentLineRef = secLine.Value[j];
                    var currentLine = currentLineRef.Line.Trim();
                    if (string.IsNullOrWhiteSpace(currentLine.Trim())) continue;

                    //métodos já criados
                    if (secLine.Key.NameWithoutSection.Contains("_DB_")) continue;

                    //procura por EXEC SQL
                    var rex = Regex.Match(currentLine.Trim(), @"^EXEC\s+SQL\s+(?<command>(INSERT|SELECT|UPDATE|DELETE|SET|CALL|DECLARE|FETCH|OPEN|CLOSE))", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(200));
                    var checkSequence = Regex.Match(currentLine.Trim(),@"EXEC\s+SQL\s+SET\b.*?\bNEXT\s+VALUE\s+FOR\b");
                    if (rex.Success)
                    {
                        var command = rex.Groups["command"].Value;
                        if (checkSequence.Success)
                            command = "SEQUENCE";
                        var newMethodNamePrefix = $"{secLine.Key.NameWithoutSection}_DB_{command}";
                        var counterMethods = Result.ProcedureReference.Count(x => x.Key.NameWithoutSection.Contains(newMethodNamePrefix)) + 1;
                        var newMethodName = $"{newMethodNamePrefix}_{counterMethods}";

                        var procList = Result.ProcedureReference.ToList();
                        var itemAdd = new KeyValuePair<CurrentMethodType, List<CurrentLineType>>(new CurrentMethodType(newMethodName, currentLineRef.LineNumber), new List<CurrentLineType> { new CurrentLineType(currentLineRef.Line, currentLineRef.LineNumber) });

                        var indexIns = procList.IndexOf(procList.LastOrDefault(x => x.Key.Name.Contains("_DB_") && x.Key.Name.Contains("OPEN")));
                        if (indexIns == -1 || command != "DECLARE")
                            indexIns = i + counterMethods + innerMethodCounter;
                        else indexIns += 1;

                        if (procList.Count > indexIns)
                            procList.Insert(indexIns, itemAdd);
                        else
                            procList.Add(itemAdd);

                        Result.ProcedureReference = procList.ToDictionary();

                        secLine.Value[j].Line = $"PERFORM {newMethodName}";
                        innerMethodCounter++;
                    }
                }
            }

            return ret;
        }
    }
}