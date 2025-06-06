using CobolLanguageConverter.Converter.Commands.CSHARP;
using CobolLanguageConverter.Converter.Commands.IF;
using CobolLanguageConverter.Converter.Commands.MOVE;
using CobolLanguageConverter.Converter.CSHARP;
using CobolLanguageConverter.Converter.DIVISION;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class SearchCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public CobolCommandResponse Execute(string line)
        {
            var output = new StringBuilder();
            var response = new CobolCommandResponse(line);

            try
            {
                #region OLD_REFERENCE
                /*
                  {
                    var internalLine = Regex.Replace(line, @"  ", @" ");
                    var rex = Regex.Match(internalLine, @"SEARCH\s+(?<listVar>\S+)\s+WHEN\s+(?<whenArg1>\S+)\s+(?<compareSignal>\S+)\s+(?<whenArg2>\S+)\(\s*(?<index>\S+)\s*\)\s+(?<whenTrue>.+?)\s*END-SEARCH\.");
                    if (!rex.Success) return response;

                    //adicionei o Searh na lista IsIn pois se precisar fazer algum processo dentro do ProcedureProceessConvert logo a baixo,
                    //vamos conseguir identificar quando estamos dentro do Search
                    Result.IsIn.Add("SEARCH ");

                    var listVar = rex.Groups["listVar"].Value;
                    var whenArg1 = rex.Groups["whenArg1"].Value;
                    var compareSignal = rex.Groups["compareSignal"].Value;
                    var whenArg2 = rex.Groups["whenArg2"].Value;
                    var index = rex.Groups["index"].Value;
                    var whenTrue = rex.Groups["whenTrue"].Value;

                    var refListVar = H.GetReferenceName(listVar, Result);
                    var refWhenArg1 = H.GetReferenceName(whenArg1, Result);
                    var refIndex = H.GetReferenceName(index, Result);
                    var refWhenArg2 = $"{refListVar}[{refIndex}].{whenArg2.Replace("-", "_")}";
                    var refCompareSignal = compareSignal
                                                .Replace("NOT EQUALS", "!=")
                                                .Replace("NOT EQUAL", "!=")
                                                .Replace("EQUALS", "==")
                                                .Replace("EQUAL", "==")
                                                ;

                    output.AppendLine($"for (;{refIndex} < {refListVar}.Items.Count; {refIndex}.Value++) {{");

                    output.AppendLine($"if({refWhenArg1} {refCompareSignal} {refWhenArg2}){{");

                    var cSharpCommand = new CSharp_PROCEDUREProcessConverterCommand();
                    cSharpCommand.Result = Result;
                    var res = cSharpCommand.ConvertMethodBody(whenTrue.Split(Environment.NewLine).ToList());
                    output.Append(res);

                    output.AppendLine("}");
                    output.AppendLine("}");

                    Result.IsIn.Remove("SEARCH ");
                    response.Executed = true;
                }
                 */
                #endregion

                if (Regex.IsMatch(line, @"WHEN\s+") && Result.IsIn.Any(x => x.Contains("SEARCH ")))
                {
                    var lastSearch = Result.IsIn.LastOrDefault(x => x.Contains("SEARCH "));
                    var isFor = lastSearch?.Contains("for(") == true;
                    var isForAlready = lastSearch?.Contains("Already") == true;

                    var exec = H.GetIfResponseForLine(Regex.Replace(CurrentLine.Line, @"WHEN\s+", ""), CurrentLine.LineNumber, Result, true);

                    var inCheckNumber = Result.IsIn.Count(x => x.Equals("inCheckNumber"));

                    if (Result.IsIn.Any(x => x.Contains("SEARCH True Already"))) inCheckNumber ++;

                    if (isFor)
                    {
                        //se for atEnd precisa fechar o método aberto anteriormente
                        output.AppendLine("};");
                        output.AppendLine("");


                        //manobra feita para adicionar o "for" depois do método de atEnd criado
                        var forClause = lastSearch?.Split(" ").LastOrDefault();
                        output.AppendLine($"var mustSearchAtEnd{inCheckNumber} = true;");
                        output.AppendLine(forClause);

                        var idx = Result.IsIn.IndexOf(lastSearch);
                        Result.IsIn[idx] = "SEARCH True Already";
                    }
                    else if (isForAlready)
                    {
                        //se for atEnd precisa fechar o método aberto anteriormente
                        output.AppendLine("}");
                        output.AppendLine("");
                    }

                    //adicionando comando de IF
                    //var ifComm = new IfCommand();
                    //ifComm.Result = Result;
                    //ifComm.CurrentLine = CurrentLine.Replace("WHEN ", "IF ");
                    //var exec = ifComm.Execute(ifComm.CurrentLine);
                    output.AppendLine(exec.ToString());
                    if (isFor)
                        output.AppendLine($"mustSearchAtEnd{inCheckNumber} = false;");

                    if (Regex.IsMatch(CurrentLine.Line, @"NEXT\s+SENTENCE"))
                        output.AppendLine("continue;");

                    //if (isAtEnd)
                    //    output.AppendLine($"hasSearchFounded = true;");

                    //Result.IsIn.Remove(lastSearch);
                    response.Executed = true;
                }

                if (line.Trim().EndsWith(".") && Result.IsIn.Any(x => x.Contains("SEARCH ")))
                {
                    var localStrBuilder = new StringBuilder();

                    var lastSearch = Result.IsIn.LastOrDefault(x => x.Contains("SEARCH "));
                    var isAtEnd = lastSearch?.Contains("True") == true;


                    //bracket do IF
                    localStrBuilder.AppendLine("break;");
                    localStrBuilder.AppendLine("}");
                    //bracket do FOR
                    localStrBuilder.AppendLine("}");

                    localStrBuilder.AppendLine("");
                    var inCheckNumber = Result.IsIn.Count(x => x.Equals("inCheckNumber"));
                    //IF do AtEnd
                    if (isAtEnd)
                    {
                        if (Result.IsIn.Count(x => x.Equals("SEARCH True Already")) > 1 && !Result.IsIn.Any(x => x.Contains("inCheckNumber")))
                            inCheckNumber ++;

                        else if (inCheckNumber > 0 && (Result.IsIn.Count(x => x.Equals("SEARCH True Already")) > 1 && Result.IsIn.Any(x => x.Contains("inCheckNumber"))))
                            inCheckNumber--;
                        else if (inCheckNumber > 0 && (Result.IsIn.Any(x => x.Contains("moreThanOneSearch")) && Result.IsIn.Any(x => x.Contains("inCheckNumber"))))
                        {
                            Result.IsIn.Remove("moreThanOneSearch");
                            inCheckNumber--;
                        }

                        Result.IsIn.Add("inCheckNumber");

                        localStrBuilder.AppendLine($"if(mustSearchAtEnd{inCheckNumber})");
                        localStrBuilder.AppendLine($"SearchAtEnd{inCheckNumber}();");
                        if (Result.IsIn.Count(x => x.Equals("SEARCH True Already")) > 1)
                            Result.IsIn.Add("moreThanOneSearch");
                    }

                    response.AfterExecuted = localStrBuilder.ToString();

                    Result.IsIn.Remove(lastSearch);
                    response.Executed = true;
                }

                if (line.StartsWith("SEARCH "))
                {
                    var internalLine = Regex.Replace(line, @"  ", @" ");
                    var rex = Regex.Match(internalLine, @"SEARCH\s+(?<listVar>\S+)(?<isAtEnd>\s+AT\s+END)*");
                    if (!rex.Success) return response;
                    var inCheckNumber = Result.IsIn.Count(x => x.Equals("inCheckNumber"));
                    
                    if (Result.IsIn.Any(x => x.Contains("SEARCH True Already"))) inCheckNumber ++;

                    //adicionei o Searh na lista IsIn pois se precisar fazer algum processo dentro do ProcedureProceessConvert logo a baixo,
                    //vamos conseguir identificar quando estamos dentro do Search
                    var listVar = rex.Groups["listVar"].Value;
                    var isAtEnd = !string.IsNullOrWhiteSpace(rex.Groups["isAtEnd"].Value);

                    var refListVar = H.GetReferenceProperty(listVar, Result);
                    var index = refListVar?.IndexedBy;
                    var refIfVar = H.GetIfResponseForLine(listVar, 0, Result);
                    var refIndex = H.GetReferenceProperty(index, Result);
                    var isInKey = $"SEARCH ";
                    var forLine = $"for (;{refIndex.PropertyName} < {refIfVar}.Items.Count; {refIndex.PropertyName}.Value++) {{";

                    if (isAtEnd)
                    {
                        //output.AppendLine($"var hasSearchFounded = false;");
                        output.AppendLine($"void SearchAtEnd{inCheckNumber}() {{");
                        isInKey += $"{isAtEnd} " + forLine.Replace(" ", "");
                    }
                    else
                        output.AppendLine(forLine);

                    Result.IsIn.Add(isInKey);

                    response.Executed = true;
                }

                if (Regex.IsMatch(line.Trim(), @"^END-SEARCH\s*") && Result.IsIn.Any(x => x.Contains("SEARCH ")))
                    response.Executed = true;
            }
            catch (Exception ex)
            {
                var lastSearch = Result.IsIn.LastOrDefault(x => x.Contains("SEARCH "));
                Result.IsIn.Remove(lastSearch);

                response.SetError(ex);
            }

            response.SetResponse(output);
            return response;
        }
    }
}
