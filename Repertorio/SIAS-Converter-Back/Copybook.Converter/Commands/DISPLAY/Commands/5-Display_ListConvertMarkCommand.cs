using CobolLanguageConverter.Converter.Commands.IF;
using CobolLanguageConverter.Converter.DIVISION;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands.DISPLAY
{
    public class Display_ListConvertMarkCommand : IDisplayCommand
    {
        public int Order { get; set; } = 5;
        public CurrentLineType? CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public string Execute(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            ret = ListConvertMarkVariables(ret, ref markedList);
            ret = ListConvertMarkNumbers(ret, ref markedList);

            return ret;
        }

        string ListConvertMarkVariables(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;
            var splited = ret.Replace(H.CommaMark, "").Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in splited)
            {
                if (H.HasStringMark(item)) continue;

                var rxVariables = Regex.Match(item, @"\S*\((?<variable>[\s]*\S+[\s]*)\)");
                if (rxVariables.Success)
                {
                    var outterVariable = item.Substring(0, item.IndexOf("("));
                    var outterProperty = H.GetReferenceProperty(outterVariable, Result);
                    var varProcess = outterProperty?.PropertyName.Split(".");
                    if (varProcess?.Any() != true) return line;

                    for (int i = varProcess.Length; i > 0; i--)
                    {
                        var innerVar = varProcess.Take(i).Last();
                        var refferProp = H.GetReferenceProperty(innerVar, Result);
                        if (refferProp?.PropertyType.Contains("ListBasis") == true)
                        {
                            var innerProperty = H.GetReferenceProperty(rxVariables.Groups["variable"].Value, Result);
                            if (innerProperty == null) return line;

                            ret = ret.Replace(item, H.Mark($"{refferProp.PropertyName}[{innerProperty.PropertyName}]", ref markedList));
                            break;
                        }
                    }
                }
            }

            return ret;
        }

        string ListConvertMarkNumbers(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;
            var splited = ret.Replace(H.CommaMark, "").Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in splited)
            {
                if (H.HasStringMark(item)) continue;

                var lstMath = new List<Match>();
                var rxNumbers = Regex.Match(item, @"\S*\((?<number>[\s]*\d+[\s]*)\)");
                if (rxNumbers.Success)
                {
                    var outterVariable = item.Substring(0, item.IndexOf("("));
                    var outterProperty = H.GetReferenceProperty(outterVariable, Result);
                    var varProcess = outterProperty?.PropertyName?.Split(".");
                    if (varProcess?.Any() != true) return line;

                    for (int i = varProcess.Length; i > 0; i--)
                    {
                        var innerVar = varProcess.Take(i).Last();
                        var refferProp = H.GetReferenceProperty(innerVar, Result);
                        if (refferProp?.PropertyType.Contains("ListBasis") == true)
                        {
                            var innerProperty = rxNumbers.Groups["number"].Value;
                            if (!int.TryParse(innerProperty, out var pInnerProperty)) return line;

                            ret = ret.Replace(item, H.Mark($"{refferProp.PropertyName}[{pInnerProperty}]", ref markedList));
                            break;
                        }
                    }
                }
            }

            return ret;
        }
    }
}
