using CobolLanguageConverter.Converter.Commands.MOVE;
using CobolLanguageConverter.Converter.DIVISION;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class StringCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public CobolCommandResponse Execute(string line)
        {
            var output = new StringBuilder();
            var response = new CobolCommandResponse(line);

            try
            {
                if (Regex.IsMatch(line.Trim(), @"^STRING\s+"))
                {
                    var ret = Regex.Replace(line, @"\s+", " ");
                    ret = Regex.Replace(ret, @"SPACES", "' '");
                    ret = Regex.Replace(ret, @"\s+\(", "(");
                    ret = ret.Replace("STRING ", "MOVE ");
                    ret = ret.Replace("END-STRING", "");
                    var initialCounter = Result.IsIn.Count(x => x.Equals("STRING_SPL"));
                    var splNum = initialCounter;

                    var rexMatches = Regex.Matches(line, @"DELIMITED\s+BY\s+(?<type>(SIZE|['].*?[']))");
                    ret = Regex.Replace(ret, @"DELIMITED\s+BY\s+(?<type>(SIZE|['].*?[']))", "");
                    ret = Regex.Replace(ret, @"\s+INTO\s+", " TO ");
                    ret = Regex.Replace(ret, @"^MOVE ", "");
                    var markedList = new Dictionary<string, string>();

                    //single cote verification
                    var regexSingle = Regex.Replace(ret, @"['](?<content>.+?)[']", x => H.Mark(x.Value, ref markedList));
                    if (regexSingle.Contains("\""))
                    {
                        ret = Regex.Replace(ret, "'", "__SIMPLE_COTE");
                        ret = Regex.Replace(ret, "\"", "'");
                    }


                    output.AppendLine("#region STRING");

                    foreach (var rexMatch in rexMatches.Where(x => x.Success))
                    {
                        var type = rexMatch?.Groups["type"].Value.Trim();
                        var isSize = type == "SIZE";
                        var isLetter = !isSize;
                        var letter = isLetter ? type.Trim().Replace("'", "") : "";
                        if (isLetter && letter == string.Empty)
                            letter = " ";

                        var leftOfTo = ret.Split(" TO ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).FirstOrDefault();
                        leftOfTo = leftOfTo.Split(rexMatch.Value, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).FirstOrDefault();

                        //tratamento alterado para substituição complexa pois ocorria de substituir coisas estranhas
                        leftOfTo = Regex.Replace(leftOfTo, @"['](?<content>.+?)[']", x => $"'{x.Groups["content"].Value.Replace(" ", "__SPACE")}'");
                        if (Regex.IsMatch(leftOfTo, @"\s+FUNCTION\s+"))
                        {
                            var functionThreatment = new FunctionsMarkCommand();
                            functionThreatment.Result = Result;
                            functionThreatment.CurrentLine = CurrentLine;

                            leftOfTo = functionThreatment.Execute(leftOfTo, ref markedList);
                        }

                        var allvariables = leftOfTo.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                        var concatAtFirst = "";
                        var splitOption = isLetter ? $".Split(\"{letter}\").FirstOrDefault()" : "";

                        foreach (var item in allvariables)
                        {
                            //aqui sei que não é variavel e nem caracteres, e sim alguma função que ja foi traduzida
                            if (Regex.IsMatch(item, H.MarkRegex))
                            {
                                var addStr = H.ToUnMarkedString(item, markedList);
                                if (splNum == initialCounter)
                                {
                                    var putSplitOpt = addStr.Contains("\"") ? "" : splitOption;
                                    concatAtFirst += $"{addStr}{putSplitOpt} + ";
                                    continue;
                                }

                                output.AppendLine($"spl{splNum} += {addStr};");
                                continue;
                            }

                            //quando a ocorrencia é uma palavra "string literal"
                            if (item.Contains("'"))
                            {
                                var addStr = item.Replace("\\", "/").Replace("\"", "\\\"").Replace("'", "\"").Replace($"__SPACE", " ").Replace($"__SIMPLE_COTE", "'");
                                if (splNum == initialCounter)
                                {
                                    concatAtFirst += $"{addStr} + ";
                                    continue;
                                }

                                output.AppendLine($"spl{splNum} += {addStr};");
                                continue;
                            }

                            var varname = H.GetIfResponseForLine(item, CurrentLine.LineNumber, Result);

                            Result.IsIn.Add("STRING_SPL");
                            output.AppendLine($"var spl{++splNum} = {concatAtFirst}{varname}.GetMoveValues(){splitOption};");
                            concatAtFirst = "";
                        }

                        if (splNum == initialCounter)
                        {
                            concatAtFirst = concatAtFirst.Trim().LastOrDefault() == '+' ? concatAtFirst.Substring(0, concatAtFirst.Trim().Length - 1) : concatAtFirst;
                            Result.IsIn.Add("STRING_SPL");
                            output.AppendLine($"var spl{++splNum} = {concatAtFirst};");
                            concatAtFirst = "";
                        }

                        ret = ret.Replace($"{H.ToUnMarkedString(leftOfTo, markedList)}{rexMatch.Value}", "");
                    }

                    var resultsVar = $"results{splNum + 1}";
                    if (splNum > (initialCounter + 1))
                    {
                        output.Append($"var {resultsVar} = ");
                        for (int i = initialCounter + 1; i <= splNum; i++)
                        {
                            var signal = i == (initialCounter + 1) ? "" : "+";
                            output.Append($"{signal}spl{i}");
                        }

                        output.Append($";");

                        output.AppendLine();
                    }
                    else
                        resultsVar = $"spl{splNum}";

                    ret = $"MOVE {resultsVar} TO {ret.Split(" TO ").LastOrDefault()}";

                    var moveCommand = new MoveCommand();
                    moveCommand.Result = Result;
                    moveCommand.CurrentLine = CurrentLine;
                    var res = moveCommand.Execute(ret);

                    output.Append(res.Output);

                    output.AppendLine("#endregion");
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
    }
}
