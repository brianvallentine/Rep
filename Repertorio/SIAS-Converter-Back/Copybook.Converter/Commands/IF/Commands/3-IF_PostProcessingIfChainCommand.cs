//using CobolLanguageConverter.Converter.Commands.IF;
//using System.Text.RegularExpressions;

//namespace CobolLanguageConverter.Converter.Commands
//{
//    public class IF_PostProcessingIfChainCommand : IIfCommand
//    {
//        public int Order { get; set; } = 3;
//        public string? CurrentLine { get; set; }

//        public string Execute(string line, ref Dictionary<string, string> markedList)
//        {
//            var ret = line;

//            ret = PostProcessingIfChain(ret, ref markedList);

//            return ret;
//        }

//        /// <summary>
//        /// procura a condição && "a" && "B" && "C" ou || "A" || "B" || "C"
//        /// </summary>
//        /// <param name="condition"></param>
//        /// <returns></returns>
//        string PostProcessingIfChain(string condition, ref Dictionary<string, string> markedList)
//        {
//            var ret = condition;//.Replace("LOW-VALUES", @"""0""");
//            var matchs = Regex.Matches(ret, @"(?<compares>(\W{2}\s)[""]\S+[""])");
//            if (matchs.Any(x => x.Success))
//            {
//                var acceptableList = new List<string> { " OR ", " AND ", " || ", " && " };
//                if (!acceptableList.Any(x => condition.Contains(x)))
//                    return ret;

//                var compareNot = matchs.ElementAt(0).Value.Contains("!");
//                var join = string.Join(" ", matchs);
//                var match = join.ToString();
//                match = match.Replace("==", "");
//                match = match.Replace("!=", "");
//                match = match.Replace("&&", ",");
//                match = match.Replace("||", ",");

//                if (compareNot)
//                    match = $".InNot({match})";
//                else
//                    match = $".In({match.Replace(" \"0\" , \"0\"", "\"0\"")})";

//                ret = ret.Replace(join, match);
//            }

//            return ret;
//        }

//        //string PostProcessingIfChain(string condition)
//        //{
//        //    var ret = condition;//.Replace("LOW-VALUES", @"""0""");
//        //    var matchs = Regex.Matches(ret, @"(?<compares>(\W{2}\s)[""]\S+[""])");
//        //    if (matchs.Any(x => x.Success))
//        //    {
//        //        var acceptableList = new List<string> { " OR ", " AND ", " || ", " && " };
//        //        if (!acceptableList.Any(x => condition.Contains(x)))
//        //            return ret;

//        //        var compareNot = matchs.ElementAt(0).Value.Contains("!");
//        //        var join = string.Join(" ", matchs);
//        //        var match = join.ToString();
//        //        match = match.Replace("==", "");
//        //        match = match.Replace("!=", "");
//        //        match = match.Replace("&&", ",");
//        //        match = match.Replace("||", ",");

//        //        if (compareNot)
//        //            match = $".InNot({match})";
//        //        else
//        //            match = $".In({match.Replace(" \"0\" , \"0\"", "\"0\"")})";

//        //        ret = ret.Replace(join, match);
//        //    }

//        //    return ret;
//        //}
//    }
//}
