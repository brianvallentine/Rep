using CobolLanguageConverter.Converter.Commands.MOVE;
using CobolLanguageConverter.Converter.DIVISION;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class VariableConvertMarkCommand : IMoveCommand
    {
        public int Order { get; set; } = 4;
        public CurrentLineType? CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public string Execute(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            ret = VariableConvertMark(ret, ref markedList);

            return ret;
        }

        string VariableConvertMark(string parLine, ref Dictionary<string, string> markedList)
        {
            var replaceMark = "___";
            var replaceMarkDotOfList = "@@@";

            //pode conter espaços dentro de uma lista matrix (VAR1 VAR2))
            var line = Regex.Replace(parLine, @"\s+\(", "(");
            line = Regex.Replace(line, @"\)\s*", ") ");
            var matrixRex = Regex.Matches(line, @"\S+\(.+?\)+(?<dotReplace>\s*\(\s*\d+\s*:\s*\d+\s*\))*");
            foreach (Match item in matrixRex.Where(x => x.Success))
            {
                line = line.Replace(item.Value, item.Value.Replace(" ", replaceMark));

                var dotReplace = item.Groups["dotReplace"].Value;
                if (!string.IsNullOrWhiteSpace(dotReplace))
                    line = line.Replace(dotReplace, dotReplace.Replace(":", replaceMarkDotOfList));
            }

            //converto todas as referencias dentro da linha
            var allItems = line.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
            allItems = H.OfNormalizeFromSpaceSplitedList(allItems);
            var afterMark = false;
            var nextAfter = 0;
            var isLength = false;

            for (int i = 0; i < allItems.Count; i++)
            {
                var item = allItems[i];

                if (afterMark)
                    nextAfter++;

                if (item == H.CommaMark)
                    afterMark = true;

                //contem a marca de string
                if (H.HasStringMark(item)) continue;
                if (item.Contains(":") && !item.Contains(replaceMark)) continue;

                if (item.Contains(replaceMark))
                    item = item.Replace(replaceMark, " ");

                if (item.Contains(replaceMarkDotOfList))
                    item = item.Replace(replaceMarkDotOfList, ":");

                if (item.Contains("LENGTH OF"))
                {
                    item = item.Replace("LENGTH OF", "");
                    isLength = true;
                }

                var beforVar = H.GetIfResponseForLine(item, CurrentLine.LineNumber, Result).ToString();
                //existem casos que beforVar será == o item, ou seja, não converteu HIGH-VALUES ou é uma variavel simples ex: WRETORNO
                if (beforVar == item)
                    beforVar = H.GetReferenceProperty(beforVar, Result)?.PropertyName;

                if (!string.IsNullOrEmpty(beforVar))
                {
                    var propName = beforVar + (!isLength ? "" : ".Value.Length");
                    var fileSelectReplace = Result.FileSelectReference.FirstOrDefault(x => x.Value == beforVar).Key;

                    if (fileSelectReplace != null && !afterMark)
                    {
                        var fileReplaceName = Regex.Match(fileSelectReplace, @"(?<varname>\S+)_RELATIVE").Groups["varname"].Value;
                        propName = fileReplaceName + (!isLength ? "?.Value" : "?.Value?.Length");
                    }

                    allItems[i] = H.Mark($"{(nextAfter > 1 ? "," : "")}{propName}", ref markedList);

                    if (isLength)
                        isLength = false;
                }
            }

            return string.Join(" ", allItems);
        }
    }
}
