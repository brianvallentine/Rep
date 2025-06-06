using CobolLanguageConverter.Converter.Commands.IF;
using CobolLanguageConverter.Converter.DIVISION;
using System.Text.RegularExpressions;

namespace CobolLanguageConverter.Converter.Commands.DISPLAY
{
    public class Display_TransformedStringNormalizeCommand : IDisplayCommand
    {
        public int Order { get; set; } = 2;
        public CurrentLineType? CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public string Execute(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            ret = ClearMoreSpacesBetween(ret);
            ret = ClearMoreSpacesInside(ret);
            ret = ClearAnotherSpacesInside(ret);

            return ret;
        }

        string ClearMoreSpacesBetween(string line) => Regex.Replace(line, @"\s+", " ");

        string ClearMoreSpacesInside(string line)
        {
            var ret = line;

            var splited = ret.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in splited)
            {
                var removedStrings = item.Replace(" ", "");
                ret = ret.Replace(item, removedStrings);
            }

            return ret;
        }
        string ClearAnotherSpacesInside(string line) => Regex.Replace(line, @"\s+\(\s*", "(");

    }
}
