using CobolLanguageConverter.Converter.Commands.DISPLAY;
using CobolLanguageConverter.Converter.DIVISION;
using FileResolver.Helper;
using System.Linq;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands.DISPLAY
{
    public class Display_ResolveUnMarkStringCommand : IDisplayCommand
    {
        public int Order { get; set; } = 7;
        public CurrentLineType? CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public string Execute(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            ret = ResolveUnMarkString(ret, ref markedList);

            return ret;
        }

        string ResolveUnMarkString(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;
            var beforeCounter = ret.Split(H.CommaMark)[0].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Length;
            var qf = FileResolverHelper.Conf.ProjectQualifierGeneralCommands;

            var isInterpolation = markedList.Values.Any(x => x.Contains("'"));
            var greaterCondition = beforeCounter > 2;
            ret = H.ToUnMarkedString(ret.Replace(" ", ""), markedList, isInterpolation);

            var beforeValue = ret.Replace(@"'", "\"");

            if (isInterpolation)
                if (greaterCondition)
                    ret = $"\n$\"{beforeValue.Replace(@"""", "")}\"\n.Display();";
                else
                    ret = $"{qf}.Display($\"{beforeValue.Replace(@"""", "")}\");";
            else
                ret = $"{qf}.Display({beforeValue});";

            return ret;
        }
    }
}
