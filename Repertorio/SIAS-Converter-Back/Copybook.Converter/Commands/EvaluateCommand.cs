using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using FileResolver.Helper;
using IA_ConverterCommons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class EvaluateCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public CobolCommandResponse Execute(string line)
        {
            var output = new StringBuilder();
            var response = new CobolCommandResponse(line);

            try
            {
                if (line.StartsWith("END-EVALUATE"))
                {
                    var evalCode = Regex.Match(Result.IsIn.LastOrDefault(x => x.Contains("EVALUATE_")), @"_(?<eval>\d+)").Groups["eval"].Value;
                    var isFirstWhen = !Result.IsIn.Contains($"WHEN_{evalCode}");
                    var isInTrueEval = Result.IsIn.Contains($"EVALUATE TRUE_{evalCode}");
                    var isInTrueCaseEval = Result.IsIn.Contains($"EVALUATE TRUE CASE_{evalCode}");


                    Result.IsIn.Remove($"EVALUATE_{evalCode}");
                    Result.IsIn.Remove($"WHEN_{evalCode}");
                    Result.IsIn.Remove($"EVALUATE TRUE_{evalCode}");
                    Result.IsIn.Remove($"EVALUATE TRUE CASE_{evalCode}");

                    if (!isInTrueCaseEval)
                        output.AppendLine($"break;");

                    output.AppendLine($"}}\n");

                    response.Executed = true;
                }

                if (line.StartsWith("EVALUATE"))
                {
                    Result.IsIn.Add($"EVALUATE_{CurrentLine.LineNumber}");
                    Result.PassByValidLineFromAnotherProcess = false;

                    var eval = line.Replace("EVALUATE", string.Empty).Trim();
                    var reference = H.GetIfResponseForLine(eval, CurrentLine.LineNumber, Result).ToString();
                    var trimStr = "";
                    if (!string.IsNullOrEmpty(reference))
                    {
                        if (reference.Equals("DB.SQLCODE") )
                        {
                            trimStr = reference;
                            output.AppendLine($"switch({trimStr}.Value) \r\n{{");
                        }
                        else
                        {
                            if (reference.Contains("CURSOR"))
                            {
                                trimStr = TrimCheck(reference);
                                output.AppendLine($"switch({reference}{trimStr}) \r\n{{");

                            }
                            else
                            {
                                trimStr = TrimCheck(reference);
                                output.AppendLine($"switch({reference}.Value{trimStr}) \r\n{{");
                            }
                            
                        }


                        response.Executed = true;
                    }
                    else
                    {
                        if (eval.Trim() == "TRUE")
                            Result.IsIn.Add($"EVALUATE TRUE_{CurrentLine.LineNumber}");
                        else
                        {   //EVALUATE REG-NOME-ARQUIVO(6:2) 
                            //REG_SIGAT.FILLER_0.REG_NOME_ARQUIVO.Substring(6, 2).Value
                            var matchR = Regex.Match(eval, @"(?<variable>\S+)\((?<substr>\s*\S+:\d+\s*)\)");
                            if (matchR.Success)
                            {
                                var substr = matchR.Groups["substr"].Value;
                                var variable = matchR.Groups["variable"].Value;
                                substr = substr.Replace(":", ",");
                                variable = H.GetReferenceName(variable, Result);

                                var splitVar = substr.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                                if (splitVar.Length > 0)
                                {
                                    var firstValue = splitVar[0];
                                    var firstVariableName = H.GetReferenceName(firstValue, Result);
                                    if (!string.IsNullOrEmpty(firstVariableName))
                                        substr = substr.Replace(firstValue, firstVariableName);
                                }

                                var asInt = "";
                                var method = Result.CurrentMethod;
                                var TemporaryProcedureReference = new List<string>(Result.ProcedureReference[method].Select(x => x.Line));

                                for (int i = 0; i < TemporaryProcedureReference.Count; i++)
                                    TemporaryProcedureReference[i] = TemporaryProcedureReference[i].Replace("\r\n", "").Trim();

                                var indexOfCurrentLine = TemporaryProcedureReference.FindIndex(x => x == CurrentLine.Line.Trim());

                                if (indexOfCurrentLine > -1)
                                    if (int.TryParse(Result.ProcedureReference[method].ElementAtOrDefault(indexOfCurrentLine + 1).Line.Replace("WHEN", "").Trim(), out var pWhen))
                                        asInt = "int.Parse(";

                                substr = $"{variable}.Substring({substr.Trim()})";

                                trimStr = TrimCheck(eval);
                                if (!string.IsNullOrEmpty(trimStr) && !string.IsNullOrEmpty(asInt))
                                    trimStr = "";

                                output.AppendLine($"switch({asInt}{substr}.Value{trimStr})) \r\n{{");
                            }
                            else if (eval.Contains("(") && !eval.Any(char.IsDigit))
                            {
                                //EVALUATE LK-COD-ATRIBUTO-2064(WS-IND)

                                var splited = eval.Split('(', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                                var sourceVar = H.GetReferenceName(splited[0], Result);
                                var indVar = H.GetReferenceName(splited[1], Result);
                                var lastDot = sourceVar.Split(".").Last();
                                sourceVar = sourceVar.Replace($".{lastDot}", $"[{indVar}].{lastDot}");

                                trimStr = TrimCheck(eval);

                                output.AppendLine($"switch({sourceVar}.Value{trimStr}) \r\n{{");
                            }
                            else
                                output.AppendLine($"switch({eval.ToLower().Trim()}) \r\n{{");
                        }

                        response.Executed = true;
                    }
                }


                if (line.StartsWith("WHEN ") && Result.IsIn.Any(x => x.Contains("EVALUATE")))
                {
                    var evalCode = Regex.Match(Result.IsIn.LastOrDefault(x => x.Contains("EVALUATE_")), @"_(?<eval>\d+)").Groups["eval"].Value;
                    var isFirstWhen = !Result.IsIn.Contains($"WHEN_{evalCode}");
                    var isInTrueEval = Result.IsIn.Contains($"EVALUATE TRUE_{evalCode}");
                    var isInTrueCaseEval = Result.IsIn.Contains($"EVALUATE TRUE CASE_{evalCode}");
                    var thru = Regex.Match(line, @"WHEN\s+(?<start>\d+)\s+THRU\s+(?<end>\d+)", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(200));

                    var eval = line.Replace("WHEN", string.Empty).Trim();
                    eval = eval.Replace("'", "\"");

                    if (!isFirstWhen && !isInTrueCaseEval && Result.PassByValidLineFromAnotherProcess) //não colocar break caso não tiver linha abaixo
                        output.AppendLine($"break;");

                    if (eval != "OTHER")
                    {
                        if (Regex.IsMatch(eval, @"\s+NOT\s+EQUAL\s+SPACES") || Regex.IsMatch(eval, @"\s+EQUAL\s+SPACES"))
                            eval = (Regex.IsMatch(eval, @"\s+NOT\s+EQUAL\s+SPACES") ? "!" : "") + Regex.Replace(eval, @"\s+NOT\s+EQUAL\s+SPACES", " .IsEmpty()");

                        if (eval.Contains("ZEROS") || eval.Contains("ZEROES"))
                            eval = eval.Replace("ZEROS", "0").Replace("ZEROES", "0");

                        if (eval.Contains("GREATER"))
                            eval = eval.Replace("GREATER", ">");

                        if (eval.Contains("LESS"))
                            eval = eval.Replace("LESS", "<");

                        if (eval == "SPACES")
                            eval = "\"\"";

                        var rexValue = Regex.Match(eval, @"\S+").Value;
                        var variableName = H.GetIfResponseForLine(rexValue, CurrentLine.LineNumber, Result).ToString();
                        var isVarName = !rexValue.Contains("\"") && !int.TryParse(rexValue, out var pVar);

                        if (variableName != null && isVarName)
                        {
                            if (isInTrueEval)
                            {
                                //caso for Evaluate, e a variavel de comparação for APENAS ELA, é = TRUE
                                if (Regex.IsMatch(eval.Trim(), @"\S+"))
                                {
                                    if (isInTrueCaseEval)
                                        output.Append($"}}\r\n else ");

                                    var restOfLine = eval.Replace(rexValue, "").Replace(" = ", " == ");
                                    output.AppendLine($"\r\nif({rexValue.Replace(rexValue.Replace("!", ""), variableName)} {restOfLine.Trim()}) //EVALUATE\r\n{{");
                                }
                                else // neste momento sabemos que pode ser uma comparação
                                {

                                }
                                //output.AppendLine($"switch(bool.Parse({variable.PropertyName}.Value.ToString())) \r\n{{");
                                //output.AppendLine($"case true:");

                                if (!isInTrueCaseEval)
                                    Result.IsIn.Add($"EVALUATE TRUE CASE_{evalCode}");
                            }
                            else
                                output.AppendLine($"case {variableName}.Value:");
                        }
                        else if (thru.Success)
                        {
                            string startValue = thru.Groups["start"].Value;
                            string endValue = thru.Groups["end"].Value;

                            string evalThru = $">= {startValue} and <= {endValue}";
                            output.AppendLine($"case {evalThru}:");
                        }
                        else
                            output.AppendLine($"case {eval}:");


                    }
                    else
                    {
                        if (!isInTrueCaseEval)
                            output.AppendLine($"default:");
                        else
                            output.Append($"}}\r\n else \r\n {{");
                    }

                    if (isFirstWhen)
                        Result.IsIn.Add($"WHEN_{evalCode}");

                    Result.PassByValidLineFromAnotherProcess = false;
                    response.Executed = true;
                }
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            response.SetResponse(output);
            return response;
        }

        string TrimCheck(string reference)
        {
            var trimStr = "";
            var splitTrim = reference.Split(".");
            var trimVarName = splitTrim.LastOrDefault();
            if (trimVarName.Contains("Substring"))
                trimVarName = splitTrim.SkipLast(1).LastOrDefault();

            if (H.GetReferenceProperty(trimVarName, Result).PropertyType == typeof(StringBasis).Name)
                trimStr = ".Trim()";

            return trimStr;
        }
    }
}
