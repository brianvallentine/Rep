//using CobolLanguageConverter.Converter.Commands.IF;
//using System.Text.RegularExpressions;

//namespace CobolLanguageConverter.Converter.Commands
//{
//    public class IF_PostProcessingConditionDefaultCommand : IIfCommand
//    {
//        public int Order { get; set; } = 5;
//        public string? CurrentLine { get; set; }

//        public string Execute(string line)
//        {
//            var ret = line;

//            ret = PostProcessingConditionDefault(ret);

//            return ret;
//        }

//        /// <summary>
//        /// Processamento padrão para trocar métodos locais do IF
//        /// </summary>
//        /// <param name="line"></param>
//        /// <returns></returns>
//        string PostProcessingConditionDefault(string line)
//        {
//            var matchs = new List<Match>();
//            var ret = line.Replace(" .", ".");
//            ret = Regex.Replace(ret.ToString(), @"SQLCODE == [0]+", "SQLCODE.IsSuccess()");

//            if (ret.ToString().Contains("!= 0"))
//            {
//                ret = Regex.Replace(ret.ToString(), @"SQLCODE != [0]+", "SQLCODE.NotIsSuccess()");

//                var str = ret.ToString();
//                var regex = Regex.Matches(str.Trim(), @"\S+.[NotIsSuccess]");
//                matchs.AddRange(regex.Where(x => x.Value.Contains("NotIsSuccess")).ToList());
//            }

//            if (ret.ToString().Contains("!= string.Empty"))
//            {
//                ret = Regex.Replace(ret.ToString(), @" != string.Empty", ".NotIsEmpty()");

//                var str = ret.ToString();
//                var regex = Regex.Matches(str.Trim(), @"\S+.[NotIsEmpty]");
//                matchs.AddRange(regex.Where(x => x.Value.Contains("NotIsEmpty")).ToList());
//            }

//            if (ret.ToString().Contains("== LOW-VALUES"))
//            {
//                ret = Regex.Replace(ret.ToString(), @"[\s]+==[\s]+LOW-VALUES", ".IsLowValues()");
//                ret = Regex.Replace(ret.ToString(), @"\.ToString\(\)\.IsLowValues", ".IsLowValues");
//            }

//            if (ret.ToString().Contains("!= LOW-VALUES"))
//            {
//                ret = Regex.Replace(ret.ToString(), @" !=[\s]+LOW-VALUES", ".NotIsLowValues()");

//                var str = ret.ToString();
//                var regex = Regex.Matches(str.Trim(), @"\S+.[NotIsLowValues]");
//                matchs.AddRange(regex.Where(x => x.Value.Contains("NotIsLowValues")).ToList());
//            }

//            if (ret.ToString().Contains(".InNot"))
//            {
//                var str = ret.ToString();
//                var regex = Regex.Matches(str.Trim(), @"\S+.[InNot]");
//                matchs.AddRange(regex.Where(x => x.Value.Contains("InNot")).ToList());
//            }

//            if (ret.ToString().Contains(".NotIsNumeric"))
//            {
//                var str = ret.ToString();
//                var regex = Regex.Matches(str.Trim(), @"\S+.[NotIsNumeric]");
//                matchs.AddRange(regex.Where(x => x.Value.Contains("NotIsNumeric")).ToList());
//            }

//            foreach (Match item in matchs)
//                ret = ret.Replace(item.Value, $"!{item.Value}");

//            ret = ret.Replace(" == string.Empty", ".IsEmpty()");
//            ret = ret.Replace("NotIsSuccess", "IsSuccess");
//            ret = ret.Replace("NotIsNumeric", "IsNumeric()");
//            ret = ret.Replace("NotIsEmpty", "IsEmpty");
//            ret = ret.Replace("NotIsLowValues", "IsLowValues");
//            ret = ret.Replace("ToString().IsLowValues", "IsLowValues");
//            ret = ret.Replace("InNot", "In");
//            ret = ret.Replace("!)", ")");
//            ret = ret.Replace("!DB.SQLCODE.IsSuccess() && 100", "!DB.SQLCODE.IsSuccess() && DB.SQLCODE != 100");
//            ret = ret.Replace("!DB.SQLCODE.IsSuccess() && +100", "!DB.SQLCODE.IsSuccess() && DB.SQLCODE != 100");
//            ret = ret.Replace("IsEmpty() || 00", "IsEmpty()");

//            return ret.ToString();
//        }
//    }
//}
