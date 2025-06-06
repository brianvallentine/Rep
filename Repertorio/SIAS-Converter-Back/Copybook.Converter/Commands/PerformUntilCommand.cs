//using CobolLanguageConverter.Converter.DIVISION;
//using Copybook.Converter;
//using System;
//using System.Reflection;
//using System.Text;
//using System.Text.RegularExpressions;
//using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

//namespace CobolLanguageConverter.Converter.Commands
//{
//    public class PerformUntilCommand : ICobolCommand
//    {
//        public CurrentLineType CurrentLine { get; set; }
//        public ResultSet Result { get; set; }

//        public CobolCommandResponse Execute(string line)
//        {
//            var output = new StringBuilder();
//            var response = new CobolCommandResponse(line);
//            var markedList = new Dictionary<string, string>();

//            try
//            {
//                if (line.StartsWith("END-PERFORM"))
//                {
//                    if (Result.IsIn.Contains("PERFORM UNTIL"))
//                    {
//                        output.AppendLine($"}}");

//                        Result.IsIn.Remove("PERFORM UNTIL");
//                        response.Executed = true;
//                    }
//                }

//                if (line.StartsWith("PERFORM "))
//                {
//                    var repl = Regex.Replace(line, @"\s+OF\s+\S+\s+", " ");
//                    //var match = Regex.Match(repl, @"PERFORM\s+((?<method>[\S]+)\s+)?UNTIL*(?<conditions>\s+((OR|AND)\s+)*\S+\s+(NOT\s+)*(>=|<=|!=|=|>|<|EQUAL|EQUALS|GREATER)?\s+((?<isHighValues>HIGH-VALUES)|\S+))+[.]*");

//                    var match = Regex.Match(repl, @"PERFORM\s+((?<method>[\S]+)\s+)?UNTIL*(?<conditions>\s+((OR|AND)\s+)*\S+\s+(NOT\s+)*(>=|<=|!=|=|>|<|EQUAL|EQUALS|GREATER)?\s+((?<isHighValues>HIGH-VALUES)|\S+))*(\s+OF\s+\S+)*(?<conditions>\s+\S+)*[.]*");

//                    Match? perfVarying = null;
//                    try { perfVarying = Regex.Match(line.Replace(Environment.NewLine, " ").Trim(), @"PERFORM\s+VARYING\s+(?<varnameFrom>\S+)\s+FROM\s+(?<initialFromNum>\S+)\s+BY\s+(?<incrementFromNum>\S+)\s+UNTIL\s+(?<fullcondition>(.*)+$)", RegexOptions.Multiline, TimeSpan.FromMilliseconds(400)); } catch { }

//                    //se não for perform VARYING
//                    if (match.Success && perfVarying?.Success != true)
//                    {
//                        var method = match.Groups["method"].Value;
//                        var isHighValues = match.Groups["isHighValues"].Value == "HIGH-VALUES";
//                        //var condition = match.Groups["condition"].Value.Replace("NOT", "!").Replace("'", "\"");

//                        var conditions = match.Groups["conditions"].Captures;
//                        var condition = string.Join(" ", conditions.Select(x => x.Value).Where(x => !string.IsNullOrEmpty(x) && x.Trim() != "."));

//                        condition = Regex.Replace(condition, @"\s+", " ");
//                        condition = condition.Trim().TrimEnd('.').Trim();
//                        condition = condition.Replace("NOT LESS", ">=");
//                        condition = condition.Replace("NOT GREATER", "<=");
//                        condition = condition.Replace("NOT EQUAL", "!=");
//                        condition = condition.Replace("NOT ", "!");
//                        condition = condition.Replace("! ", "!").Replace("!EQUALS", "!=");
//                        condition = condition.Replace("!EQUAL", "!=");
//                        condition = condition.Replace("EQUALS", "==");
//                        condition = condition.Replace("GREATER", ">");
//                        condition = condition.Replace("LESS", "<");
//                        condition = condition.Replace("SPACES", "\"\"");
//                        condition = condition.Replace("SPACE", "\"\"");
//                        condition = condition.Replace("ZEROES", "0");
//                        condition = condition.Replace("ZEROS", "0");
//                        condition = condition.Replace("ZERO", "0");
//                        condition = condition.Replace("EQUAL", "==");
//                        condition = condition.Replace(" = ", " == ");
//                        condition = condition.Replace(" OR ", " || ");
//                        condition = condition.Replace(" AND ", " && ");
//                        condition = Regex.Replace(condition, @"\(\s*", "( ");
//                        condition = Regex.Replace(condition, @"\s*\)", " )");

//                        if (condition == "=")
//                            condition = "==";

//                        //no C# o while é condição inversa ao COBOL
//                        //PERFORM UNTIL A NOT = B
//                        //while(a == b)

//                        if (condition.Contains(">="))
//                            condition = condition.Replace(">=", H.Mark("<", ref markedList));

//                        if (condition.Contains("<="))
//                            condition = condition.Replace("<=", H.Mark(">", ref markedList));

//                        if (condition.Contains("=="))
//                            condition = condition.Replace("==", H.Mark("!=", ref markedList));

//                        if (condition.Contains("!="))
//                            condition = condition.Replace("!=", H.Mark("==", ref markedList));

//                        if (condition.Contains(">"))
//                            condition = condition.Replace(">", H.Mark("<=", ref markedList));

//                        if (condition.Contains("<"))
//                            condition = condition.Replace("<", H.Mark(">=", ref markedList));

//                        if (condition.Contains("||"))
//                            condition = condition.Replace("||", H.Mark("&&", ref markedList));

//                        if (condition.Contains("&&"))
//                            condition = condition.Replace("&&", H.Mark("||", ref markedList));

//                        condition = H.ToUnMarkedString(condition, markedList);

//                        //if (condition.Contains("("))
//                        //    condition = condition.Replace("(", "");
//                        //if (condition.Contains(")"))
//                        //    condition = condition.Replace(")", "");

//                        //var conditionReq = match.Groups["conditionReq"].Value;
//                        //var refferVar = H.GetReferenceName(variable, Result);
//                        var refferMethod = method.Replace("-", "_");

//                        //precisa percorrer a string na procura de variaveis válidas
//                        foreach (var condItem in condition.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).OrderByDescending(x => x.Length))
//                        {
//                            var varItem = H.GetReferenceName(condItem, Result);
//                            if (varItem == null) continue;

//                            condition = condition.Replace(condItem, varItem);
//                        }

//                        var isNegatedSymbol = "";
//                        if (isHighValues)
//                        {
//                            if (condition.Contains("!="))
//                                isNegatedSymbol = "!";

//                            condition = condition
//                                .Replace("!= HIGH-VALUES", ".IsHighValues")
//                                .Replace("== HIGH-VALUES", ".IsHighValues");
//                        }

//                        output.AppendLine($"\nwhile({isNegatedSymbol}{condition.TrimEnd('.').Replace("'", "\"")}) \n{{");
//                        if (!string.IsNullOrEmpty(refferMethod))
//                        {
//                            output.AppendLine($"{refferMethod}();");
//                            output.AppendLine("}");
//                        }
//                        else
//                            Result.IsIn.Add("PERFORM UNTIL");

//                        response.Executed = true;
//                        response.SetResponse(output);
//                        return response;
//                    }
//                }

//                if (line.StartsWith("PERFORM UNTIL"))
//                {
//                    var match = Regex.Match(line, @"(PERFORM[\s]+UNTIL)?\s+(?<variable>[\S]+)?\s+(?<condition>[NOT]*\s?[=|>|<])?\s*(?<conditionReq>\S+)");

//                    if (match.Success)
//                    {
//                        Result.IsIn.Add("PERFORM UNTIL");

//                        var variable = match.Groups["variable"].Value;

//                        var condition = match.Groups["condition"].Value.Replace("NOT", "!").Replace(" ", "");
//                        condition = Regex.Replace(condition, @"\s+", " ");
//                        condition = condition.Replace("NOT ", "!");
//                        condition = condition.Replace("! ", "!").Replace("!EQUALS", "!=");
//                        condition = condition.Replace("!EQUAL", "!=");
//                        condition = condition.Replace("EQUALS", "=");
//                        condition = condition.Replace("GREATER", ">");
//                        condition = condition.Replace("LESS", "<");
//                        condition = condition.Replace("SPACES", "\"\"");
//                        condition = condition.Replace("SPACE", "\"\"");
//                        condition = condition.Replace("ZERO", "0");
//                        condition = condition.Replace("ZEROES", "0");
//                        condition = condition.Replace("EQUAL", "=");

//                        condition = Regex.Replace(condition, @"\s+=\s+", " == ");
//                        if (condition == "=")
//                            condition = "==";

//                        //no C# o while é condição inversa ao COBOL
//                        //PERFORM UNTIL A NOT = B
//                        //while(a == b)

//                        if (condition.Contains("=="))
//                            condition = condition.Replace("==", "!=");
//                        else

//                        if (condition.Contains("!="))
//                            condition = condition.Replace("!=", "==");
//                        else

//                        if (condition.Contains(">"))
//                            condition = condition.Replace(">", "<=");
//                        else

//                        if (condition.Contains("<"))
//                            condition = condition.Replace("<", ">=");

//                        var conditionReq = match.Groups["conditionReq"].Value;
//                        var reffer = H.GetReferenceName(variable, Result);

//                        output.AppendLine($"\nwhile({reffer} {condition} {conditionReq.Trim().TrimEnd('.')}) \n{{");

//                        response.Executed = true;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                response.SetError(ex);
//            }

//            response.SetResponse(output);
//            return response;
//        }
//    }
//}
