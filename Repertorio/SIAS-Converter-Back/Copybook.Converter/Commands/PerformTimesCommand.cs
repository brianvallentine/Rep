//using CobolLanguageConverter.Converter.DIVISION;
//using Copybook.Converter;
//using System;
//using System.Reflection;
//using System.Text;
//using System.Text.RegularExpressions;
//using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

//namespace CobolLanguageConverter.Converter.Commands
//{
//    public class PerformTimesCommand : ICobolCommand
//    {
//        public CurrentLineType CurrentLine { get; set; }
//        public ResultSet Result { get; set; }

//        public CobolCommandResponse Execute(string line)
//        {
//            var output = new StringBuilder();
//            var response = new CobolCommandResponse(line);

//            try
//            {
//                if (line.StartsWith("END-PERFORM") && Result.IsIn.Contains("PERFORM_N_TIMES"))
//                {
//                    Result.IsIn.Remove("PERFORM_N_TIMES");

//                    output.AppendLine($"}}");

//                    response.Executed = true;
//                    response.SetResponse(output);

//                    return response;
//                }

//                if (line.StartsWith("PERFORM "))
//                {
//                    #region PERFORM METHOD 5 TIMES
//                    var match = Regex.Match(line, @"PERFORM\s+(?<method>\S+)\s+(?<times>\d+)\s+TIMES");

//                    //se for times
//                    if (match.Success)
//                    {
//                        var method = match.Groups["method"].Value;
//                        var times = match.Groups["times"].Value;
//                        if (!int.TryParse(times, out var pTimes))
//                            throw new Exception($"Erro ao converter inteiro do TIMES considerando -> {times}");

//                        var refferMethod = method.Replace("-", "_");
//                        output.AppendLine($"\nfor (int i = 0; i < {pTimes}; i++) \n{{");
//                        if (!string.IsNullOrEmpty(refferMethod))
//                        {
//                            output.AppendLine($"{refferMethod}();");
//                            output.AppendLine("}");
//                        }
//                        else
//                            throw new Exception($"Erro ao converter Perform, metodo não identificado -> {method}");

//                        response.Executed = true;
//                        response.SetResponse(output);

//                        return response;
//                    }
//                    #endregion


//                    #region PERFORM 5 TIMES
//                    match = Regex.Match(line, @"PERFORM\s+(?<times>\d+)\s+TIMES");

//                    //se for times
//                    if (match.Success)
//                    {
//                        var times = match.Groups["times"].Value;

//                        if (!int.TryParse(times, out var pTimes))
//                            throw new Exception($"Erro ao converter inteiro do TIMES considerando -> {times}");

//                        Result.IsIn.Add("PERFORM_N_TIMES");

//                        output.AppendLine($"\nfor (int i = 0; i < {pTimes}; i++) \n{{");

//                        response.Executed = true;
//                        response.SetResponse(output);

//                        return response;
//                    }
//                    #endregion
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
