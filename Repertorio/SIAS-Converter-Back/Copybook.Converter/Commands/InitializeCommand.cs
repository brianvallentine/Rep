using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using FileResolver.Helper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class InitializeCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public CobolCommandResponse Execute(string line)
        {
            var output = new StringBuilder();
            var response = new CobolCommandResponse(line);
            var q = FileResolverHelper.Conf.ProjectQualifierGeneralCommands;

            try
            {
                if (Regex.IsMatch(line, @"^INITIALIZE\s+"))
                {
                    var ret = line;
                    ret = ret.Replace("\r\n", " ").Replace(".", "");
                    ret = Regex.Replace(ret, @"\s*,", " ");
                    ret = Regex.Replace(ret, @"\s+\(", "(");
                    ret = Regex.Replace(ret, @"\s*\)\s*", ") ");
                    //REPLACING NUMERIC DATA BY ZEROS ALPHANUMERIC DATA BY SPACES
                    ret = Regex.Replace(ret, @"REPLACING\s+", "");
                    ret = Regex.Replace(ret, @"ALPHANUMERIC(\s+DATA)*\s+BY\s+(SPACES|SPACE)", "");
                    ret = Regex.Replace(ret, @"NUMERIC(\s+DATA)*\s+BY\s+(ZEROES|ZEROS|ZERO)", "");
                    ret = Regex.Replace(ret, @"INITIALIZE\s+", "");

                    var mathes = Regex.Matches(ret, @"(?<matchLine>\S+(\s+OF\s+\S+)*)");

                    foreach (Match item in mathes.Where(x => x.Success).DistinctBy(x => x.Value).OrderByDescending(x => x.Groups["matchLine"].Value.Length))
                    {
                        var matchLine = item.Groups["matchLine"].Value;
                        ret = ret.Replace(matchLine, H.GetIfResponseForLine(matchLine, CurrentLine.LineNumber, Result).ToString());
                    }

                    ret = Regex.Replace(ret.Trim(), @"\s+", "\n\t,");

                    ExceptionOnValidationError(ret);

                    output.AppendLine($"{q}.Initialize(\n\t{ret}\n);");

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

        private void ExceptionOnValidationError(string threatedLine)
        {
            var splited = threatedLine.Split(",");
            if (splited.Length <= 0 || splited.Any(x => string.IsNullOrWhiteSpace(x.Replace("\n", ""))))
                throw new Exception($"Não contém referência(s) válida(s) no código para a(s) variave[l|is] ..encontrada(s):> {string.Join(", ", splited)}");
        }
    }
}
