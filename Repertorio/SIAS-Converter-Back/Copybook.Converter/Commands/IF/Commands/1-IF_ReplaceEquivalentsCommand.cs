using CobolLanguageConverter.Converter.Commands.IF;
using CobolLanguageConverter.Converter.DIVISION;
using System.Text.RegularExpressions;

namespace CobolLanguageConverter.Converter.Commands
{
    public class IF_ReplaceEquivalentsCommand : IIfCommand
    {
        public int Order { get; set; } = 1;
        public CurrentLineType? CurrentLine { get; set; } //Cobol Code
        public ResultSet Result { get; set; }

        public string Execute(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            ret = ReplaceEquivalents(ret);

            return ret;
        }

        string ReplaceEquivalents(string line)
        {
            var EquivalenceList = new Dictionary<string, string> {
                        {@"(\s+(?<oper>EQUAL)\s*\((?<values>.+?)\))"," ${oper} ${values} " },
                        {@"\s+GREATER\s+OR\s+EQUAL\s+TO\s+"," >= " },
                        {@"\s+GREATER\s+OR\s+EQUAL\s+"," >= " },
                        {@"\s+LESS\s+OR\s+EQUAL\s+"," <= " },
                        {@"\s+AND\s+NOT\s+EQUAL\s+"," && " },
                        {@"\s+NOT\s+NUMERIC\s*"," .NotIsNumeric " },
                        {@"\s+NUMERIC\s*"," .IsNumeric " },
                        {@"\s+OR\s+EQUAL\s+"," || " },
                        {@"\s+OR\s+\=\s*"," || " },
                        {@"\s+NOT\s+="," !=" },
                        {@"\s+IS\s+NEGATIVE"," < 0 " },
                        {@"\s+="," ==" },
                        {@"\s+NOT\s+EQUAL\s+TO"," != " },
                        {@"\s+NOT\s+EQUALS\s+"," != " },
                        {@"\s+NOT\s+EQUAL\s+"," != " },
                        {@"\s+EQUAL\s+TO"," ==" },
                        {@"\s+EQUALS\s+"," == " },
                        {@"\s+AND\s+\+\s+100"," AND +100" },
                        {@"\s+EQUAL\s+"," == " },
                        {@"\s+NOT GREATER\s+"," <= " },
                        {@"\s+NOT >"," <=" },
                        {@"\s+GREATER\s+THAN\s+"," > " },
                        {@"\s+GREATER\s+"," > " },
                        {@"\s+NOT LESS\s+"," >= " },
                        {@"\s+NOT\s+"," ! " },
                        {@"\s+LESS"," <" },
                        {@"\s+ZEROS"," 00" },
                        {@"\s+ZEROES"," 00" },
                        {@"\s+ZERO"," 00" },
                        {@"(?<![\w-])ZERO(?![\w-])"," 00" },
                        {@"\s+AND\s*\("," && (" },
                        {@"\s+AND\s+"," && " },
                        {@"\s+OR\s+"," || " },
                        {@"\s+OR\("," || (" },
                        {@"\s+SPACES"," string.Empty" },
                        {@"\s+SPACE"," ' '" },
                        { @"\s+(?=(?:[^']*'[^']*')*[^']*$)", " "},
                    };

            var ret = line;

            //vamos alterar inicialmente a string crua, ja converterndo todos os equivalentes
            foreach (var item in EquivalenceList)
            {
                ret = Regex.Replace(ret, $@"(\s+IS)*{item.Key}(\s+THAN)*", $"{item.Value}");
            }

            return ret;
        }
    }
}
