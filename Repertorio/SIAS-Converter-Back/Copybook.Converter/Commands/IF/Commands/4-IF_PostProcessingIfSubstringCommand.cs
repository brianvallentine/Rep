//using CobolLanguageConverter.Converter.Commands.IF;
//using System.Text.RegularExpressions;

//namespace CobolLanguageConverter.Converter.Commands
//{
//    public class IF_PostProcessingIfSubstringCommand : IIfCommand
//    {
//        public int Order { get; set; } = 4;
//        public string? CurrentLine { get; set; }

//        public string Execute(string line)
//        {
//            var ret = line;

//            ret = PostProcessingIfSubstring(ret);

//            return ret;
//        }

//        /// <summary>
//        /// Busca por if que contenham substring (100:200)
//        /// </summary>
//        /// <param name="condition"></param>
//        /// <returns></returns>
//        string PostProcessingIfSubstring(string condition)
//        {
//            var ret = condition;
//            var matchR = Regex.Match(ret, @"\(\s*\d+:\d+\s*\)");
//            if (matchR.Success)
//            {
//                var match = matchR.Value;
//                match = match.Replace("(", "");
//                match = match.Replace(")", "");
//                match = match.Replace(":", ",");

//                match = $".Substring({match.Trim()})";

//                ret = ret.Replace(matchR.Value, match);
//            }

//            return ret;
//        }
//    }
//}
