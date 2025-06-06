using CobolLanguageConverter.Converter.Commands.MOVE;
using CobolLanguageConverter.Converter.DIVISION;
using FileResolver.Helper;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class UnstringCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public CobolCommandResponse Execute(string line)
        {
            var output = new StringBuilder();
            var response = new CobolCommandResponse(line);

            try
            {
                if (line.StartsWith("UNSTRING "))
                {
                    //https://regex101.com/r/pY5uwm
                    //var rex = Regex.Match(line, @"^UNSTRING\s+(?<uniVariable>(\S+(\s+OF\s+\S+)*)\s+)DELIMITED\s+BY\s+(?<delimitedByOr>(?<isAll>ALL\s+)*(?<delimitedBy>('[^']+')|SPACE)(\s+OR\s+)*)+\s+INTO\s+(?<intoVar>[-A-Z0-9]+((\s+DELIMITER\s+IN\s+(?<inDelimiter>\S+))|(\s+COUNT\s+IN\s+(?<inCounter>\S+)))*\s*)+(\.|END-UNSTRING|$)");
                    var rex = Regex.Match(line, @"^UNSTRING\s+(?<uniVariable>(\S+(\s+OF\s+\S+)*)\s+)DELIMITED\s+BY\s+(?<delimitedByOr>(?<isAll>ALL\s+)*(?<delimitedBy>('[^']+')|SPACE)(\s+OR\s+)*)+\s+INTO\s+(?<intoVar>(?!END-UNSTRING)[-A-Z0-9]+((\s+DELIMITER\s+IN\s+(?<inDelimiter>\S+))|(\s+COUNT\s+IN\s+(?<inCounter>\S+)))*\s*)+(\.|END-UNSTRING|$)");

                    if (!rex.Success) return response;
                    var qf = FileResolverHelper.Conf.ProjectQualifierGeneralCommands;

                    var uniVariable = rex.Groups["uniVariable"].Value;
                    var delimitedList = rex.Groups["delimitedByOr"].Captures.Select(x => $"new UnstringDelimitedParameter({Regex.Replace(Regex.Replace(x.Value, @"\s*ALL\s+", ""), @"\s*OR\s+", "").Replace(" SPACES ", " ' ' ").Trim().Replace("'", "\"")}{(x.Value.Contains("ALL") ? ",true" : "")})");
                    var intoList = rex.Groups["intoVar"].Captures.Select(x => $"new UnstringIntoParameter({H.GetIfResponseForLine(Regex.Match(x.Value.Trim(), @"^\S+").Value, CurrentLine.LineNumber, Result)}{(Regex.IsMatch(x.Value, @"COUNT\s+IN") ? $",\"COUNT\",{H.GetIfResponseForLine(Regex.Match(x.Value.Trim(), @"\S+$").Value, CurrentLine.LineNumber, Result)}" : "")})");

                    var uniVar = H.GetIfResponseForLine(uniVariable, CurrentLine.LineNumber, Result).ToString();

                    output.AppendLine($"{qf}.Unstring({uniVar}, \n\t[{string.Join($"{Environment.NewLine}{new string('\t', 4)},", delimitedList)}], \n\t[{string.Join($"{Environment.NewLine}{new string('\t', 4)},", intoList)}\n]);");
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
