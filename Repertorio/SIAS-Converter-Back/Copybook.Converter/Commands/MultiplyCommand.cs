using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class MultiplyCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; }
        public ResultSet Result { get; set; }
        public CobolCommandResponse Execute(string line)
        {
            var output = new StringBuilder();
            var response = new CobolCommandResponse(line);

            try
            {
                if (Regex.IsMatch(line, @"^\s*MULTIPLY\b", RegexOptions.IgnoreCase))
                {
                    var lineTrimmed = line.Trim();
                    var parameters = new List<string>();

                    var matchGiving = Regex.Match(lineTrimmed,
                        @"^MULTIPLY\s+(?<value>\S+(?:\s+OF\s+\S+)*)\s+BY\s+(?<by>\S+(?:\s+OF\s+\S+)*)\s+GIVING\s+(?<result>\S+)",
                        RegexOptions.IgnoreCase);

                    if (matchGiving.Success)
                    {
                        parameters.Add(matchGiving.Groups["value"].Value);
                        parameters.Add(matchGiving.Groups["by"].Value);
                        parameters.Add(matchGiving.Groups["result"].Value);
                    }
                    else
                    {
                        var match = Regex.Match(lineTrimmed,
                            @"^MULTIPLY\s+(?<value>\S+(?:\s+OF\s+\S+)*)\s+BY\s+(?<targets>.+)$",
                            RegexOptions.IgnoreCase);

                        if (match.Success)
                        {
                            parameters.Add(match.Groups["value"].Value);
                            parameters.Add(match.Groups["targets"].Value);
                        }
                    }

                    if (parameters.Count > 0)
                    {
                        var mounting = string.Join("|", parameters).Replace(",", ".");

                        foreach (var parameterName in mounting
                                                        .Split("|", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                                                        .OrderByDescending(x => x.Length))
                        {
                            var param = H.GetReferenceName(parameterName, Result);
                            if (string.IsNullOrWhiteSpace(param))
                                continue;

                            mounting = Regex.Replace(mounting, $"(?<symbol>(\\||^)){Regex.Escape(parameterName)}", $"${{symbol}}{param}");
                        }

                        output.AppendLine($"_.Multiply({mounting.Replace("|", ", ")});");
                        response.Executed = true;
                    }
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
