using CobolLanguageConverter.Converter.DIVISION;
using CodeAnalyser.Helper;
using FileResolver.Helper;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace CobolLanguageConverter.Converter.CSHARP
{
    public class CSharpCommand : IConverterCommand
    {
        public int Order { get; set; } = 20;
        public ResultSet Result { get; set; }
        public static Stopwatch StopWatch { get; set; } = new Stopwatch();


        public delegate bool InternalMethodDelegate(string line, out string invokedString, out List<int> removeIndex);

        public string Execute(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = new StringBuilder();
            var allCommands = ConvertHelper.FindCommands<ICSharpCommand>(Assembly.GetExecutingAssembly()).OrderBy(x => x.Order);
            var markedList = new Dictionary<string, string>();

            foreach (var command in allCommands)
            {
                command.Result = Result;
                ret = command.Execute(ret, ref divisionAndLines);

                if (FileResolverHelper.Conf.LogTimeLine)
                {
                    Console.WriteLine($" --{GetType().Name} -> {command.GetType().Name} em {StopWatch.Elapsed.ToString()}");
                    StopWatch.Restart();
                }
            }

            return ret.ToString();
        }
    }
}