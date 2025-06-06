using CobolLanguageConverter.Converter.Commands.IF;
using CobolLanguageConverter.Converter.DIVISION;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands.DISPLAY
{
    public class Display_FunctionsMarkCommand : IDisplayCommand
    {
        public int Order { get; set; } = 3;
        public CurrentLineType? CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public string Execute(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            ret = FunctionsExternalsMark(ret, ref markedList);
            ret = FunctionsInternalsMark(ret, ref markedList);

            return ret;
        }

        string FunctionsExternalsMark(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            var splited = ret.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var isInterpolation = splited.Any(x => H.HasStringMark(x));
            foreach (var item in splited)
            {
                if (!item.Contains("WHEN-COMPILED") && !item.Contains("CURRENT-DATE")) continue;
                if (!Regex.IsMatch(item, @"^WHEN-COMPILED") && !Regex.IsMatch(item, @"^CURRENT-DATE")) continue;

                var convertedValue = $"FUNCTION {item}";

                //tratando FUNCTION CURRENT_DATE(1:10)
                if (H.TryCurrentDateTransform(convertedValue, isInterpolation, out var pLine))
                    convertedValue = pLine;

                //tratando FUNCTION WHEN-COMPILED(1:10)
                if (H.TryWhenCompileTransform(convertedValue, out var wLine))
                    convertedValue = wLine;

                ret = ret.Replace(item, H.Mark(convertedValue, ref markedList));
            }


            return ret;
        }

        string FunctionsInternalsMark(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            var splited = ret.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in splited)
            {
                if (!H.HasStringMark(item)) continue;

                var considerValue = markedList[item];
                if (!considerValue.Contains("WHEN-COMPILED") && !considerValue.Contains("CURRENT-DATE")) continue;
                if (!Regex.IsMatch(item, @"^WHEN-COMPILED") && !Regex.IsMatch(item, @"^CURRENT-DATE")) continue;

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
