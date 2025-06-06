//using CobolLanguageConverter.Converter.Commands.DIVISIONS;
//using CobolLanguageConverter.Converter.DIVISION;
//using Copybook.Converter;
//using System.Text;
//using System.Text.RegularExpressions;
//using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

//namespace CobolLanguageConverter.Converter.Commands
//{
//    public class PerformCommand : ICobolCommand
//    {
//        public CurrentLineType CurrentLine { get; set; }
//        public ResultSet Result { get; set; }

//        public CobolCommandResponse Execute(string line)
//        {
//            var output = new StringBuilder();
//            var response = new CobolCommandResponse(line);

//            try
//            {
//                var isPerfUntil = false;
//                var isPerfThru = false;
//                var isPerfVarying = false;
//                var isPerfTimes = false;

//                try { isPerfTimes = Regex.IsMatch(line.Trim(), @"^PERFORM\s*(\S+\s+)*\d+\s*TIMES", RegexOptions.None, TimeSpan.FromMilliseconds(300)); } catch { }
//                try { isPerfUntil = Regex.IsMatch(line.Trim(), @"^PERFORM\s*(THRU(\s*|.*)+)*(\S+\s+)*UNTIL", RegexOptions.None, TimeSpan.FromMilliseconds(300)); } catch { }
//                try { isPerfThru = Regex.IsMatch(line.Trim(), @"(?<before>\S+)\s+THRU\s+(?<after>\S+)", RegexOptions.None, TimeSpan.FromMilliseconds(300)); } catch { }
//                try { isPerfVarying = Regex.IsMatch(line.Trim(), @"PERFORM\s+VARYING", RegexOptions.None, TimeSpan.FromMilliseconds(300)); } catch { }

//                if (line.StartsWith("PERFORM ") && !isPerfUntil && !isPerfThru && !isPerfVarying && !isPerfTimes)
//                {
//                    var match = Regex.Match(line, @"(\DERFORM)?\s+(?<values>'[^']*'|[^'\n]+)");
//                    if (match.Success)
//                    {
//                        var threatedLine = match.Value.Replace("'", @"""").Replace("PERFORM ", "");
//                        var methodName = GetMethodName(threatedLine);
//                        if (string.IsNullOrEmpty(methodName)) throw new Exception("Erro ao definir nome do Perform.");

//                        var item = Result.ProcedureReference[methodName];
//                        if (item?.Count == 0 || (H.IsIgnoredMethod(methodName, Result)))
//                            output.AppendLine($"/*Método Suprimido por falta de linha ou apenas EXIT nome: {methodName}*/\n");
//                        else
//                            output.AppendLine($"\n{methodName}();");
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

//        private string GetMethodName(string line, bool cSharpName = true)
//        {
//            // Extrair o nome do método
//            string methodName = Regex.Match(line, @"(\bPERFORM\s*)?(?<NomeDoMetodo>\w+(?:-\w+)*)\b").Groups["NomeDoMetodo"].Value;
//            if (cSharpName)
//            {
//                if (char.IsDigit(methodName[0]))
//                    methodName = $"{CSharp_CobolLineChangeCommand.ChangedNewKeyMarker}{methodName}";

//                methodName = methodName.Replace("-", "_");
//            }

//            return methodName;
//        }
//    }
//}
