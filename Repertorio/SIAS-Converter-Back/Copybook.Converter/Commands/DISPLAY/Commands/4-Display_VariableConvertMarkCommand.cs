using CobolLanguageConverter.Converter.Commands.IF;
using CobolLanguageConverter.Converter.DIVISION;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands.DISPLAY
{
    public class Display_VariableConvertMarkCommand : IDisplayCommand
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

        string VariableConvertMark(string line, ref Dictionary<string, string> markedList)
        {
            //converto todas as referencias dentro da linha
            var allItems = line.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)?.ToList();
            allItems = H.OfNormalizeFromSpaceSplitedList(allItems);
            var afterMark = false;
            var nextAfter = 0;

            for (int i = 0; i < allItems.Count; i++)
            {
                var item = allItems[i];

                if (afterMark)
                    nextAfter++;

                if (item == H.CommaMark)
                    afterMark = true;

                //contem a marca de string
                if (H.HasStringMark(item)) continue;

                var beforVar = H.GetReferenceProperty(item, Result);
                if (beforVar != null)
                {
                    allItems[i] = beforVar.PropertyName;
                    allItems[i] = H.Mark($"{(nextAfter > 1 ? "," : "")}{beforVar.PropertyName}", ref markedList);
                }
            }

            return string.Join(" ", allItems);
        }
    }
}
