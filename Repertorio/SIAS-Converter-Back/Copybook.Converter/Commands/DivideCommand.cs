using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class DivideCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; }
        public ResultSet Result { get; set; }
        public CobolCommandResponse Execute(string line)
        {
            var output = new StringBuilder();
            var response = new CobolCommandResponse(line);

            try
            {
                //DIVIDE WS-ANO-REFER BY 4 GIVING WS-RESULTADO REMAINDER WS-RESTO 
                var match = Regex.Match(line.Trim(), @"^DIVIDE\s+(?<value>\S+(\s+OF\s+\S+)*)\s+BY\s+(?<by>\S+(\s+OF\s+\S+)*)\s+GIVING\s+(?<result>\S+)(\s+REMAINDER\s+(?<remaining>\S+))*");
                if (match.Success)
                {
                    var value = match.Groups["value"].Value;
                    var by = match.Groups["by"].Value;
                    var result = match.Groups["result"].Value;
                    var remaining = match.Groups["remaining"].Value;

                    var mounting = $"{value}|{by}|{result}".Replace(",", ".");
                    if (!string.IsNullOrEmpty(remaining))
                        mounting += $"|{remaining}";

                    foreach (var parameterName in mounting.Split("|", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).OrderByDescending(x => x.Length))
                    {
                        var param = H.GetReferenceName(parameterName, Result);
                        if (string.IsNullOrWhiteSpace(param))
                            continue;

                        mounting = Regex.Replace(mounting, $"(?<symbol>(\\||^)){parameterName}", $"${{symbol}}{param}");
                    }

                    output.AppendLine($"_.Divide({mounting.Replace("|", ", ")});");
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
    }
}
