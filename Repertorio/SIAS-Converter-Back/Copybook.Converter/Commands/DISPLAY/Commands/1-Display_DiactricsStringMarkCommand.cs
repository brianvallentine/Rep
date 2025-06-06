using CobolLanguageConverter.Converter.Commands.IF;
using CobolLanguageConverter.Converter.DIVISION;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands.DISPLAY
{
    public class Display_DiactricsStringMarkCommand : IDisplayCommand
    {
        public int Order { get; set; } = 1;
        public CurrentLineType? CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public string Execute(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            ret = DiactricsStringMark(ret, ref markedList);

            return ret;
        }

        string DiactricsStringMark(string line, ref Dictionary<string, string> markedList)
        {
            markedList = new Dictionary<string, string>();
            var ret = line;

            var match = Regex.Match(line, @$"(?<before>.*)");

            if (!match.Success) return ret;

            var before = match.Groups["before"].Value.Trim();
            var beforeMarked = H.ToMarkedString(before, out markedList);

            //converto todas as referencias dentro da lina
            var allBeforeItems = beforeMarked.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            for (int i = 0; i < allBeforeItems.Length; i++)
            {
                var item = allBeforeItems[i];

                if (DisplayCommand.EquivalenceList.ContainsKey(item))
                    allBeforeItems[i] = H.Mark(DisplayCommand.EquivalenceList[item], ref markedList);
            }

            ret = ret.Replace(before, string.Join(" ", allBeforeItems));

            return ret;
        }
    }
}
