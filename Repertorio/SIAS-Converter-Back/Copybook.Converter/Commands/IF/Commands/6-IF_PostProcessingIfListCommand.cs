//using CobolLanguageConverter.Converter.Commands.IF;
//using System.Text.RegularExpressions;
//using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

//namespace CobolLanguageConverter.Converter.Commands
//{
//    public class IF_PostProcessingIfListCommand : IIfCommand
//    {
//        public int Order { get; set; } = 6;
//        public string? CurrentLine { get; set; }

//        public string Execute(string line)
//        {
//            var ret = line;

//            ret = PostProcessingIfList(ret);

//            return ret;
//        }

//        /// <summary>
//        /// processa variaveis de LISTA no COBOL
//        /// </summary>
//        /// <param name="condition"></param>
//        /// <returns></returns>
//        string PostProcessingIfList(string condition)
//        {
//            var ret = condition
//                        .Replace(" (","(")
//                        .Replace(" )",")")
//                        .Replace(") ",")")
//                        .Replace("( ","(")
//                        ;//.Replace(" ", "");
//            var matchR = Regex.Match(ret, @"\([^""]*\)");
//            if (matchR.Success)
//            {
//                var testResult = matchR.Value.Replace(" ", "").Replace("\n", "").Trim();
//                var isInvalidString =
//                                   testResult == "()"
//                                || testResult.Contains("=")
//                                || testResult.Contains("||")
//                                || testResult.Contains("!")
//                                || testResult.Contains(",")
//                            ;

//                if (isInvalidString) return condition;
//                var match = matchR.Value;
//                var indexOf = ret.IndexOf(match);
//                if (indexOf < 0) return condition;

//                var pattern = @$"\S+{match.Replace(")", @"\)").Replace("(", @"\(").Replace(".", @"\.")}";
//                var substringVariableR = Regex.Match(ret, pattern);
//                var substringVariable = substringVariableR.Value.Replace(match, "");
//                var varProcess = substringVariable.Split(".", StringSplitOptions.RemoveEmptyEntries);
//                if (!varProcess.Any()) return condition;

//                for (int i = varProcess.Length; i > 0; i--)
//                {
//                    var refferProp = H.GetReferenceProperty(varProcess.Take(i).Last());
//                    if (refferProp.PropertyType.Contains("ListBasis"))
//                    {
//                        ret = ret.Replace(substringVariable, refferProp.PropertyName);
//                        ret = ret.Replace(match, match.Replace("(", "[").Replace(")", "]"));
//                        break;
//                    }
//                }
//            }

//            return ret;
//        }
//    }
//}
