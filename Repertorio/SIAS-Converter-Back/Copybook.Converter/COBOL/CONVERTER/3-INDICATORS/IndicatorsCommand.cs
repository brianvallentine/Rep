using CobolLanguageConverter.Converter.DIVISION;
using CodeAnalyser.Helper;
using System.Reflection;
using System.Text;

namespace CobolLanguageConverter.Converter.INDICATORS
{
    public class IndicatorsCommand : IConverterCommand
    {
        public int Order { get; set; } = 30;
        public ResultSet Result { get; set; }

        public delegate bool InternalMethodDelegate(string line, out string invokedString, out List<int> removeIndex);

        public string Execute(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = new StringBuilder(lines);
            var allCommands = ConvertHelper.FindCommands<IIndicatorsCommand>(Assembly.GetExecutingAssembly()).OrderBy(x => x.Order);
            var markedList = new Dictionary<string, string>();
            dynamic outData = null;

            foreach (var command in allCommands)
            {
                command.Result = Result;
                ret = command.Execute(ret, ref divisionAndLines, ref outData);
            }

            return ret.ToString();
        }
    }
}