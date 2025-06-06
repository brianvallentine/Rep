using CodeAnalyser.Helper;
using System.Reflection;

namespace CobolLanguageConverter.Converter.DIVISION
{
    public class DivisionCommand : IConverterCommand
    {
        public int Order { get; set; } = 0;
        public ResultSet Result { get; set; }

        public string Execute(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = lines;
            var allCommands = ConvertHelper.FindCommands<IDivisionCommand>(Assembly.GetExecutingAssembly()).OrderBy(x => x.Order);
            var markedList = new Dictionary<string, string>();

            foreach (var command in allCommands)
            {
                command.Result = Result;
                ret = command.Execute(ret, ref divisionAndLines);
            }

            return ret;
        }
    }
}