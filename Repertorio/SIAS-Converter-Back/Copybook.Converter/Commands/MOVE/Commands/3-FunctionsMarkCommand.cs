using CobolLanguageConverter.Converter.Commands.MOVE;
using CobolLanguageConverter.Converter.DIVISION;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class FunctionsMarkCommand : IMoveCommand
    {
        public int Order { get; set; } = 3;
        public CurrentLineType? CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public string Execute(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            ret = FunctionsExternalsMark(ret, ref markedList);
            ret = FunctionsInternalsMark(ret, ref markedList);
            ret = FunctionLowerCaseMark(ret, ref markedList);
            ret = FunctionUpperCaseMark(ret, ref markedList);
            ret = FunctionKnowedSpecialVars(ret, ref markedList);

            return ret;
        }

        string FunctionKnowedSpecialVars(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            var rex = Regex.Match(ret, @"SQLERRD\s*\(\s*(?<number>\d+)\s*\)");
            if (!rex.Success) return ret;

            MatchCollection matches = Regex.Matches(ret, @"SQLERRD\s*\(\s*(?<number>\d+)\s*\)");

            int CountComma = matches.Count - 1;
            foreach (Match match in matches)
            {
                var number = match.Groups["number"].Value;
                var varName = $"SQLERRD({number})";
                if (CountComma > 0)
                    ret = ret.Replace(match.Value, H.Mark($"{H.GetReferenceProperty(varName, Result).PropertyName}", ref markedList) +" "+ H.CommaMark);
                else
                    ret = ret.Replace(match.Value, H.Mark($"{H.GetReferenceProperty(varName, Result).PropertyName}", ref markedList));
                
                CountComma--;
            }


            return ret;
        }

        public string FunctionUpperCaseMark(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            var rexTst = Regex.Match(ret, @"FUNCTION\s+UPPER-CASE");
            if (!rexTst.Success) return ret;

            var rexs = Regex.Matches(ret, @"(?<upperFunc>FUNCTION\s+UPPER-CASE\s*\((?<upperVar>[^\)]+)\))");
            foreach (var rex in rexs.Where(x => x.Success))
            {
                var upperFunc = rex.Groups["upperFunc"].Value;
                var upperVar = rex.Groups["upperVar"].Value;

                ret = ret.Replace(upperFunc, H.Mark($"{H.GetIfResponseForLine(upperVar, CurrentLine.LineNumber, Result).ToString()}.ToString().ToUpper()", ref markedList));
            }

            return ret;
        }

        public string FunctionLowerCaseMark(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            var rexTst = Regex.Match(ret, @"FUNCTION\s+LOWER-CASE");
            if (!rexTst.Success) return ret;

            var rexs = Regex.Matches(ret, @"(?<lowerFunc>FUNCTION\s+LOWER-CASE\s*\((?<lowerVar>[^\)]+)\))");
            foreach (var rex in rexs.Where(x => x.Success))
            {
                var lowerFunc = rex.Groups["lowerFunc"].Value;
                var lowerVar = rex.Groups["lowerVar"].Value;

                ret = ret.Replace(lowerFunc, H.Mark($"{H.GetIfResponseForLine(lowerVar, CurrentLine.LineNumber, Result).ToString()}.ToString().ToLower()", ref markedList));
            }

            return ret;
        }

        string FunctionsExternalsMark(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            var splited = ret.Split(new string[] { H.CommaMark, " " }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in splited)
            {
                if ((!item.Contains("WHEN-COMPILED") || item.Contains("-WHEN-COMPILED")) && (!item.Contains("CURRENT-DATE") || item.Contains("-CURRENT-DATE"))) continue;

                var convertedValue = item;

                //tratando FUNCTION CURRENT_DATE(1:10)
                if (H.TryCurrentDateTransform(item, H.HasStringMark(line), out var pLine))
                    convertedValue = pLine;

                //tratando FUNCTION WHEN-COMPILED(1:10)
                if (H.TryWhenCompileTransform(item, out var wLine))
                    convertedValue = wLine;

                //tratamento criado pois havia strings concorrentes dentro do valor
                //EX: CURRENT-DATE = WS-CURRENT-DATE, quando dava replace, deixava código quebrado
                if (ret.Contains($"-{item}"))
                    ret = ret.Replace($"-{item}", "||-ABSORVED||");

                if (ret.Contains($"{item}-"))
                    ret = ret.Replace($"{item}-", "||ABSORVED-||");

                ret = ret.Replace(item, H.Mark(convertedValue, ref markedList));
                ret = ret.Replace("FUNCTION ", " ");
                ret = ret.Replace("||-ABSORVED||", $"-{item}");
                ret = ret.Replace("||ABSORVED-||", $"{item}-");
                ret = Regex.Replace(ret, @"\s+", " ");
            }


            return ret;
        }

        string FunctionsInternalsMark(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            var splited = ret.Replace(H.CommaMark, "").Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in splited)
            {
                if (!H.HasStringMark(item)) continue;

                var considerValue = markedList[item];
                if (!considerValue.Contains("WHEN-COMPILED") && !considerValue.Contains("CURRENT-DATE")) continue;

                var convertedValue = considerValue;

                //tratando FUNCTION CURRENT_DATE(1:10)
                if (H.TryCurrentDateTransform(considerValue, true, out var pLine))
                    convertedValue = pLine;

                //tratando FUNCTION WHEN-COMPILED(1:10)
                if (H.TryWhenCompileTransform(considerValue, out var wLine))
                    convertedValue = wLine;

                markedList[item] = convertedValue;
            }


            return ret;
        }
    }
}
