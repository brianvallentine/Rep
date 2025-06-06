using CobolLanguageConverter.Converter.DIVISION;
using System.Text.RegularExpressions;

namespace CobolLanguageConverter.Converter.Commands.DIVISIONS
{
    public class Division_ExtractDivisionCommand : IDivisionCommand
    {
        public int Order { get; set; } = 1;
        public ResultSet Result { get; set; }

        public string Execute(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = ExtractDivision(lines, ref divisionAndLines);
            ret = ExtractDivisionComments(ret, ref divisionAndLines);
            ret = ThreatCommentedLines(ret, ref divisionAndLines);
            return ret;
        }

        string ExtractDivision(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var currentDivisionName = "";
            var currentDivisionCode = new List<CurrentLineType>();
            var lineNumber = 0;

            foreach (var line in lines.Split(Environment.NewLine))
            {
                lineNumber++;

                if (string.IsNullOrWhiteSpace(line)) continue;

                //adicionado parã não pegar comentário na division
                if (IsDivision(line) && line.ElementAtOrDefault(6) != '*')
                {
                    // Se encontrou uma nova division, adiciona a division anterior ao dicionário
                    if (!string.IsNullOrEmpty(currentDivisionName))
                        divisionAndLines.Add(currentDivisionName.Replace(".", ""), currentDivisionCode);

                    // Atualiza a currentDivisionName com o nome da nova division
                    currentDivisionName = Regex.Replace(line.Substring(7, line.Length - 7).Trim(), @"\s+", " ");
                    currentDivisionCode = new List<CurrentLineType>();
                }
                else
                    // Adiciona à division atual
                    currentDivisionCode.Add(new CurrentLineType(line, lineNumber));

            }

            // Adiciona a última division ao dicionário
            if (!string.IsNullOrEmpty(currentDivisionName))
                divisionAndLines.Add(currentDivisionName, currentDivisionCode);

            return lines;
        }

        string ExtractDivisionComments(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            foreach (var division in divisionAndLines.ToList())
            {
                var divisionName = division.Key;
                var divisionCommentedName = division.Key + "_Comment";
                var divisionList = new List<CurrentLineType>();
                var divisionCommentedList = new List<CurrentLineType>();

                foreach (var line in division.Value)
                {
                    var isComment = false;

                    // Check if the line is a comment (*) at position 7
                    if (line.Line.Length < 7) continue;

                    if (line.Line.ElementAtOrDefault(6) == '*') isComment = true;

                    // Check if the line is a comment --
                    if (line.Line.ElementAtOrDefault(6) == '-' && line.Line.ElementAtOrDefault(7) == '-') isComment = true;

                    var validLine = line;

                    var length = line.Line.Length;
                    if (length > 72 && !isComment)
                        length = 72;

                    if (isComment)
                        divisionCommentedList.Add(validLine);
                    else
                    {
                        validLine.Line = line.Line.Substring(7, length - 7);
                        divisionList.Add(validLine);
                    }
                }

                divisionAndLines[divisionName] = divisionList;

                if (divisionCommentedList.Any())
                    divisionAndLines.Add(divisionCommentedName, divisionCommentedList);
            }

            return lines;
        }

        string ThreatCommentedLines(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var validLines = new List<string>();

            foreach (var line in lines.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
            {
                if (line.Length < 7) continue;

                // Check if the line is a comment (*) at position 7
                if (line[6] == '*') continue;

                // Check if the line is a comment --
                if (line[6] == '-' && line[7] == '-') continue;

                var length = line.Length;
                if (length > 72)
                {
                    length = 72;
                }

                validLines.Add(line.Substring(7, length - 7));
            }

            return string.Join(Environment.NewLine, validLines);
        }

        private bool IsDivision(string line)
        {
            // Lógica para identificar uma linha de division
            var trimmedLine = line.Trim().ToUpper();

            if (line.ElementAtOrDefault(6) == '*') return false;
            if (line.Length > 7)
                trimmedLine = line.Substring(7, line.Length - 7).Trim().ToUpper();

            var divisions = new List<string>
            {
                @"^IDENTIFICATION\s+DIVISION"      ,
                @"^ENVIRONMENT\s+DIVISION"      ,
                @"^DATA\s+DIVISION"             ,
                @"^INPUT-OUTPUT\s+SECTION"             ,
                @"^LOCAL-STORAGE\s+SECTION"     ,
                @"^CONFIGURATION\s+SECTION"     ,
                @"^FILE\s+SECTION"             ,
                @"^WORKING-STORAGE\s+SECTION"   ,
                @"^LINKAGE\s+SECTION"           ,
                @"^PROCEDURE\s+DIVISION"        ,
            };

            var isDivision = false;
            foreach (var division in divisions)
            {
                try
                {
                    var isMatch = Regex.IsMatch(trimmedLine, division, RegexOptions.None, TimeSpan.FromMilliseconds(300));
                    if (isMatch)
                    {
                        isDivision = true;
                        break;
                    }
                }
                catch { }
            }

            return isDivision;
        }
    }
}
