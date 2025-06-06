using CobolLanguageConverter.Converter.Commands.IF;
using CobolLanguageConverter.Converter.DIVISION;
using System.Text.RegularExpressions;

namespace CobolLanguageConverter.Converter.Commands
{
    public class IF_PreProcessCommand : IIfCommand
    {
        public int Order { get; set; } = 0;
        public CurrentLineType? CurrentLine { get; set; } //Cobol Code
        public ResultSet Result { get; set; }

        public string Execute(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            ret = PreProcessingClean(ret);

            return ret;
        }

        string PreProcessingClean(string line)
        {
            //// Regex para identificar padrões nas condições IF do COBOL
            var match = Regex.Match(line, @"IF\s+(?<conditions>(\S+|\s+)+)$", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (!match.Success) return line;

            var ret = match.Groups["conditions"].Value.Replace(" THEN", "");

            if (ret.Contains("ALPHABETIC"))
            {
                if (ret.Contains("NOT"))
                {
                    ret = ret.Replace(@"\s*NOT\s+", " ");
                    ret = Regex.Replace(ret, @"^\s*(.+?)\s+ALPHABETIC$", "!_.IsAlphabetic( $1 )");
                }
                else
                {
                    ret = Regex.Replace(ret, @"^\s*(.+?)\s+ALPHABETIC$", "_.IsAlphabetic( $1 )");

                }

            }

            if (Regex.IsMatch(match.Value.Trim(), @"^IF\s+NOT\s+"))
                ret = $"! {Regex.Replace(ret, @"\s*NOT\s+", " ")}";

            ret = Regex.Replace(ret, @"\s+(?=(?:[^']*'[^']*')*[^']*$)", " ");
            ret = Regex.Replace(ret, @"\s*\(\s*", " ( ");
            ret = Regex.Replace(ret, @"\s*\)\s*", " ) ");
            ret = Regex.Replace(ret, @"\s+THEN", "");
            ret = Regex.Replace(ret, @"\s+IN\s+", " OF ");
            ret = Regex.Replace(ret, @"\s+LOW-VALUES\s+OR\s+'0'", " LOW-VALUES");//no C# lowValues e 0 é o mesmo teste
            ret = Regex.Replace(ret, @"\s+SPACES\s+OR\s+LOW-VALUES", " LOW-VALUES");//no C# lowValues e 0 é o mesmo teste
            ret = Regex.Replace(ret, @"\s+SPACES\s+OR\s+'1212-12-12'\s+OR\s+LOW-VALUES", " LOW-VALUES");//
            ret = Regex.Replace(ret, @"\s+LOW-VALUES\s+AND\s+SPACES", " LOW-VALUES");//no C# lowValues e " "  é o mesmo teste
            ret = Regex.Replace(ret, @"\s+NEXT\s+SENTENCE\s*.*", "");
            ret = Regex.Replace(ret, @"AND\s+NOT\s+-803", "AND NOT EQUAL -803");
            ret = Regex.Replace(ret, @"\s+X\s*(?<repl>'[^']+')", " ${repl}");
            ret = Regex.Replace(ret, @"\s*\((?<uniqueVariable>\s*\S+(\s*OF\s*\S+)*\s*)\)", m => m.Groups["uniqueVariable"].Success ? $"({m.Groups["uniqueVariable"].Value.Trim()})" : m.Value);
            ret = Regex.Replace(ret, @"\((?<substringIni>\s*[A-z0-9-]+(\s*OF\s*[A-z0-9-]+)*\s*):(?<substringEnd>\s*[A-z0-9-]+(\s*OF\s*[A-z0-9-]+)*\s*)\)", m => m.Groups["substringIni"].Success && m.Groups["substringEnd"].Success ? $"({m.Groups["substringIni"].Value.Trim()}:{m.Groups["substringEnd"].Value.Trim()})" : m.Value);
            ret = Regex.Replace(ret, @"'\""'", "double_quote");
            var subStrMatch = Regex.Match(ret, @"\S+(?<replaceLocal>\s+\()\S+:\S+\)");
            if (subStrMatch.Success)
                ret = ret.Replace(subStrMatch.Value, subStrMatch.Value.Replace(subStrMatch.Groups["replaceLocal"].Value, "("));

            var subStrMatches = Regex.Matches(ret, @"\s+([-|+]\s*)*(\d+,\d+)");
            if (subStrMatches.Any(x => x.Success))
                foreach (Match item in subStrMatches)
                    ret = ret.Replace(item.Value, item.Value.Replace(",", "."));

            return ret;
        }
    }
}
