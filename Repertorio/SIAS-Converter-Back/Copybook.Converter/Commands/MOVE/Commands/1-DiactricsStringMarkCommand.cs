using CobolLanguageConverter.Converter.Commands.MOVE;
using CobolLanguageConverter.Converter.DIVISION;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class DiactricsStringMarkCommand : IMoveCommand
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

            var match = Regex.Match(line, @$"(?<before>.*)\s*{H.CommaMark}\s*(?<after>.*)");

            if (!match.Success) return ret;

            var before = match.Groups["before"].Value.Trim();
            if (before[0] == '\'')
            {
                before = before.Substring(1, before.Length - 2);
                before = before.Replace("'", "\\\"");
                before = $"'{before}'";
            }
            
            var beforeMarked = H.ToMarkedString(before, out markedList);

            //converto todas as referencias dentro da lina
            var allBeforeItems = beforeMarked.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            for (int i = 0; i < allBeforeItems.Length; i++)
            {
                var item = allBeforeItems[i];

                if (MoveCommand.EquivalenceList.ContainsKey(item))
                    allBeforeItems[i] = H.Mark(MoveCommand.EquivalenceList[item], ref markedList);

                if (allBeforeItems[i].Contains(","))
                    allBeforeItems[i] = allBeforeItems[i].Replace(",", ".");
            }

            var splitedRet = ret.Split(H.CommaMark);
            splitedRet[0] = string.Join(" ", allBeforeItems);
            ret = string.Join($" {H.CommaMark} ", splitedRet);

            return ret;
        }
    }
}
