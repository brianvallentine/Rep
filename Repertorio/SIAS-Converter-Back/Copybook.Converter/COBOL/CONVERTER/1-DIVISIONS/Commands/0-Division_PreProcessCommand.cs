using CobolLanguageConverter.Converter.DIVISION;
using System.Text.RegularExpressions;

namespace CobolLanguageConverter.Converter.Commands.DIVISIONS
{
    public class Division_PreProcessCommand : IDivisionCommand
    {
        public int Order { get; set; } = 0;
        public ResultSet Result { get; set; }

        public string Execute(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = PreProcessingCleanLines(lines);
            return ret;
        }


        /// <summary>
        /// Método vai trazer as linhas com comentário, a intenção aqui é remover algumas marcas e normalizar algumas coisas, e remover o lado "direito" do programa
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        string PreProcessingCleanLines(string lines)
        {
            var validLines = new List<string>();

            try
            {
                foreach (var line in lines.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
                {
                    // Skip lines with less than 7 characters
                    //if (line.Length < 7) continue;

                    // Check if the line is a comment (*) at position 7
                    //if (line[6] == '*') continue;

                    // Check if the line is a comment --
                    //if (line[6] == '-' && line[7] == '-') continue;
                    var currentLine = line;
                    var length = currentLine.Length;
                    if (length > 72)
                    {
                        length = 72;
                    }

                    currentLine = currentLine.Substring(0, length - 0);

                    if (currentLine.Trim().Contains("EJECT")) continue;
                    if (currentLine.Trim() == "SKIP1") continue;
                    if (currentLine.Trim() == "SKIP2") continue;
                    if (currentLine.Trim() == "SKIP3") continue;


                    //Haviam programas com ID DIVISION :S
                    if (Regex.IsMatch(currentLine, @"ID\s+DIVISION"))
                        currentLine = Regex.Replace(currentLine, @"ID\s+DIVISION", "IDENTIFICATION DIVISION");

                    validLines.Add(currentLine);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading the COBOL file: {ex.Message}");
            }

            var ret = string.Join(Environment.NewLine, validLines);
            return ret;
        }
    }
}
