//using CobolLanguageConverter.Converter.CobolDivisions;
//using CobolLanguageConverter.Converter.Commands.IF;
//using CobolLanguageConverter.Converter.DIVISION;
//using CodeAnalyser.Helper;
//using Copybook.Converter;
//using System.Reflection;
//using System.Text;
//using System.Text.RegularExpressions;
//using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

//namespace CobolLanguageConverter.Converter.Commands
//{
//    public class PerformVaryingCommand : ICobolCommand
//    {
//        public CurrentLineType CurrentLine { get; set; }
//        public ResultSet Result { get; set; }

//        public CobolCommandResponse Execute(string line)
//        {
//            var output = new StringBuilder();
//            var response = new CobolCommandResponse(line);


//            try
//            {
//                if (Regex.IsMatch(line.Trim(), @"^END-PERFORM"))
//                {
//                    if (Result.IsIn.Contains("PERFORM VARYING"))
//                    {
//                        output.AppendLine($"}}");

//                        Result.IsIn.Remove("PERFORM VARYING");
//                        response.Executed = true;
//                    }
//                }

//                if (Regex.IsMatch(line.Trim(), @"^PERFORM\s+"))
//                {
//                    Match? perfVarying = null;
//                    try { perfVarying = Regex.Match(line.Replace(Environment.NewLine, " ").Trim(), @"PERFORM\s+(?<method>\S+)*\s*VARYING\s+(?<varnameFrom>\S+)\s+FROM\s+(?<initialFromNum>\S+)\s+BY\s+(?<incrementFromNum>\S+)\s+UNTIL\s+(?<fullcondition>(.*)+$)", RegexOptions.Multiline, TimeSpan.FromMilliseconds(400)); } catch { }

//                    if (perfVarying?.Success != true)
//                        return response;

//                    var methodName = perfVarying.Groups["method"].Value.Replace("-", "_");
//                    var isMethod = !string.IsNullOrEmpty(methodName);
//                    var varnameFrom = perfVarying.Groups["varnameFrom"].Value;
//                    var initialFromNum = perfVarying.Groups["initialFromNum"].Value;
//                    var incrementFromNum = perfVarying.Groups["incrementFromNum"].Value;
//                    var fullcondition = perfVarying.Groups["fullcondition"].Value;

//                    var cSharpCondition = Regex.Replace(fullcondition, @"(\.+\s+)*\.+$", "");
//                    cSharpCondition = H.GetIfResponseForLine(cSharpCondition, Result)?.ToString();

//                    var fromVar = H.GetReferenceName(varnameFrom, Result);
//                    if (fromVar == null)
//                        fromVar = varnameFrom;
//                    else
//                        fromVar += ".Value";

//                    var iniFromNum = H.GetReferenceName(initialFromNum, Result);
//                    if (iniFromNum == null)
//                        iniFromNum = initialFromNum;

//                    if (isMethod)
//                    {
//                        output.AppendLine($"\n for({fromVar} = {iniFromNum}; !({cSharpCondition}); {fromVar} += {incrementFromNum}) \n{{");

//                        if (!H.IsIgnoredMethod(methodName, Result))
//                            output.AppendLine($"{methodName.Replace("-", "_")}();");
//                        else
//                            output.AppendLine($"/*Método Suprimido por falta de linha ou apenas EXIT nome: {methodName}*/\n");

//                        output.AppendLine($"}}");
//                    }
//                    else
//                    {
//                        output.AppendLine($"\n for({fromVar} = {iniFromNum}; !({cSharpCondition}); {fromVar} += {incrementFromNum}) \n{{");

//                        Result.IsIn.Add("PERFORM VARYING");
//                    }



//                    response.Executed = true;
//                }
//            }
//            catch (Exception ex)
//            {
//                response.SetError(ex);
//            }

//            response.SetResponse(output);
//            return response;
//        }

//        //private string GetMethodName(string line, bool cSharpName = true)
//        //{
//        //    // Extrair o nome do método
//        //    string methodName = Regex.Match(line, @"(\bPERFORM\s*)?(?<NomeDoMetodo>\w+(?:-\w+)*)\b").Groups["NomeDoMetodo"].Value;
//        //    if (cSharpName)
//        //        methodName = methodName.Replace("-", "_");

//        //    return methodName;
//        //}
//    }
//}
