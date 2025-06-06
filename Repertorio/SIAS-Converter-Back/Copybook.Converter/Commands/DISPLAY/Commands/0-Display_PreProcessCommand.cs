using System.Text.RegularExpressions;
using CobolLanguageConverter.Converter.DIVISION;
using Microsoft.CodeAnalysis.Differencing;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands.DISPLAY
{
    public class Display_PreProcessCommand : IDisplayCommand
    {
        public int Order { get; set; } = 0;
        public CurrentLineType? CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public string Execute(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            ret = PreProcessingCleanDisplay(ret);

            return ret;
        }

        string PreProcessingCleanDisplay(string line)
        {
            var back = line;
            line = line
                    .Replace(Environment.NewLine, " ")
                    .Replace("\r", " ")
                    .Replace("DISPLAY ", "")
                    .Replace("FUNCTION CURRENT-DATE", "CURRENT-DATE")
                    .TrimEnd('.')
                    ;
            line = Regex.Replace(line, @"UPON\s+CONSOLE", "");

            var matches = Regex.Matches(line, @"(?<!')\\?""([^""]+)""");
            foreach (Match match in matches)
            {
                
                if (!match.ToString().Contains('\''))
                {
                    string replaced = "'" + match.Groups[1].Value + "'";
                    line = line.Replace(match.Value, replaced);
                }
            }

            return line;
        }
    }
}
