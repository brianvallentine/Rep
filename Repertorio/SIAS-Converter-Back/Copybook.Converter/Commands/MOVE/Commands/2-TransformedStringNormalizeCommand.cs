using CobolLanguageConverter.Converter.Commands.MOVE;
using CobolLanguageConverter.Converter.DIVISION;
using System.Text.RegularExpressions;

namespace CobolLanguageConverter.Converter.Commands
{
    public class TransformedStringNormalizeCommand : IMoveCommand
    {
        public int Order { get; set; } = 2;
        public CurrentLineType? CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public string Execute(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            ret = ClearCommaSeparatorSide(ret);
            ret = ClearMoreSpacesBetween(ret);
            ret = ClearMoreSpacesInside(ret);
            ret = ClearAnotherSpacesInside(ret);

            return ret;
        }

        string ClearAnotherSpacesInside(string line) => Regex.Replace(line, @"\s+\(\s*", "(");
        string ClearMoreSpacesBetween(string line) => Regex.Replace(line, @"\s+", " ");
        string ClearCommaSeparatorSide(string line) => Regex.Replace(line, @",", " ");

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
    }
}
