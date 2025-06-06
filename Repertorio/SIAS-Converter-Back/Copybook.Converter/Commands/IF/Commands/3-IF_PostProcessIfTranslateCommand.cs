using CobolLanguageConverter.Converter.Commands.IF;
using CobolLanguageConverter.Converter.DIVISION;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class IF_PostProcessIfTranslateCommand : IIfCommand
    {
        public int Order { get; set; } = 3;
        public CurrentLineType? CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public string Execute(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            ret = PostProcessIfTranslate(ret, ref markedList);
            ret = PostProcessIfTranslateNamed(ret, ref markedList);

            return ret;
        }

        string PostProcessIfTranslate(string condition, ref Dictionary<string, string> markedList)
        {
            var ret = condition.Replace("(", "( ").Replace(")", " )");
            //while (H.HasStringMark(ret))
            //{
            ret = H.ToUnMarkedString(ret, markedList);
            ret = ret.Replace("\\", "\\\\");
            ret = ret.Replace("\"\"\"", $"\"\\\"\"");

            ret = ret.Replace(",", " , ");

            //old var splitter = Regex.Replace(ret, @"\s*-\s*", "-").Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            ret = Regex.Replace(ret, @"\s*-\s*", "-");
            var splitter = Regex.Matches(ret, @"[^\s']+|'.+?'")
                    .Cast<Match>()
                    .Select(m => m.Value)
                    .ToArray();

            for (int i = 0; i < splitter.Length; i++)
            //foreach (var item in splitter)
            {
                //old var item = splitter[i].Replace(".IsEmpty()", "");
                var item = Regex.Replace(splitter[i], @"\.IsEmpty\(\)(?=(?:[^']*'[^']*')*[^']*$)", "");

                if (item.Trim() == ":" || item.Trim() == "," || item.Trim() == "!") continue;

                var rex = Regex.Match(item, @"\S+");
                var localVar = H.GetReferenceName(rex.Value, Result);
                if (!string.IsNullOrEmpty(localVar) && item.Replace("!", "") != localVar && localVar != rex.Value)
                    splitter[i] = splitter[i].Replace(item, localVar);
            }

            ret = string.Join(" ", splitter);

            return ret.Replace("'", "\"");
        }

        string PostProcessIfTranslateNamed(string condition, ref Dictionary<string, string> markedList)
        {
            var ret = condition;

            //DB.SQLCODE != 00 && + 100
            ret = Regex.Replace(ret, @"\s*(==|!=)\s*(.IsHighValues)", ".IsHighValues");
            ret = ret.Replace("\"string.Empty\"", "string.Empty");
            ret = Regex.Replace(ret, @"\s*==\s*HIGH-VALUE", ".IsHighValues");

            //caso encontre casos que o HIGH-VALUES foi substituido e não deveria.
            ret = Regex.Replace(ret, @"(\s+|^).IsHighValues", "HIGH-VALUES");
            ret = Regex.Replace(ret, @"(^|\s+)DB\.SQLCODE\s+\!\=\s+00\s+\&\&\s+\+\s+100", "(^|\\s+)!DB.SQLCODE.IsSuccess() && DB.SQLCODE != 100");

            string pattern = @"(?<identificador>[A-Z0-9\-]+)\s*(?<operador>>=|<=|==|!=|>|<)\s*(?<data>\d{8})";

            Match match = Regex.Match(ret, pattern);
            if (match.Success)
            {
                string dataStr = match.Groups["data"].Value;
                if (DateTime.TryParseExact(dataStr, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out DateTime dataValida))
                {
                    string replacement = "${identificador}.GetMoveValues().ToInt() ${operador} ${data}";
                    ret = Regex.Replace(ret, pattern, replacement);
                }
            }
            return ret.Replace("'", "\"");
        }
    }
}
