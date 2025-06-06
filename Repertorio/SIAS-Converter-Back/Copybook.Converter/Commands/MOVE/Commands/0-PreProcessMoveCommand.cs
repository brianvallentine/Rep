using CobolLanguageConverter.Converter.Commands.MOVE;
using CobolLanguageConverter.Converter.DIVISION;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class PreProcessMoveCommand : IMoveCommand
    {
        public int Order { get; set; } = 0;
        public CurrentLineType? CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public string Execute(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            ret = PreProcessingCleanMove(ret);

            return ret;
        }

        string PreProcessingCleanMove(string line)
        {
            line = line
                    .Replace(Environment.NewLine, " ")
                    .Replace("\r", " ")
                    .Replace("MOVE ", "")
                    //.Replace(, , StringComparison.InvariantCultureIgnoreCase)
                    .TrimEnd('.')
                    ;

            line = Regex.Replace(line, @"[,]*\s+TO\s+", $" {H.CommaMark} ");
            line = Regex.Replace(line, @"ALL\s+'\*'", @"ALL *");
            line = Regex.Replace(line, @"\s+IN\s+", " OF ");
            line = Regex.Replace(line, @"SQLERRMC\s+DELIMITED\s+BY\s+'\s+'\s+IN", @"");
            line = Regex.Replace(line, @"DELIMITED\s+BY\s+'\s+'\s+IN", @"");
            line = Regex.Replace(line, @"\)", @" )");
            //line = Regex.Replace(line, @"\s+OF\s+\S+", @"");
            line = Regex.Replace(line, @"\s+\)", @")");

            return line;
        }
    }
}
