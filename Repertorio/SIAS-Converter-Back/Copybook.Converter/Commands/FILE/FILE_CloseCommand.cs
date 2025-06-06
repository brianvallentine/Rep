using CobolLanguageConverter.Converter.Commands.IF;
using CobolLanguageConverter.Converter.DIVISION;
using System.Text;
using System.Text.RegularExpressions;

namespace CobolLanguageConverter.Converter.Commands
{
    public class FILE_CloseCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; } //Cobol Code
        public ResultSet Result { get; set; }
        StringBuilder output = new StringBuilder();

        public CobolCommandResponse Execute(string line)
        {
            var response = new CobolCommandResponse(line);

            try
            {
                if (line.StartsWith("CLOSE "))
                {
                    var ret = Close(line);

                    output = ret;

                    response.Executed = true;
                }
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            response.SetResponse(output);
            return response;
        }

        StringBuilder Close(string line)
        {
            var output = new StringBuilder();

            //// Regex para identificar padrões nas condições de write de arquivo do COBOL
            var match = Regex.Match(line, @"CLOSE\s+(?<varnames>((?<varname>\S+)\s*)+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (!match.Success) return new StringBuilder(line);

            var varname = match.Groups["varnames"].Value.Replace("-", "_").TrimEnd('.');
            varname = Regex.Replace(varname.Trim(), @",", " ");
            varname = Regex.Replace(varname, @"\s+", ",");
            if (string.IsNullOrEmpty(varname)) return new StringBuilder(line);

            var varnames = varname?.Split(',').ToList() ?? new List<string>();
            foreach (var item in varnames)
                output.AppendLine($"{item}.Close();");

            return output;
        }
    }
}
