using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class SetTrueCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; }
        public ResultSet Result { get; set; }
        public CobolCommandResponse Execute(string line)
        {
            var output = new StringBuilder();
            var response = new CobolCommandResponse(line);

            try
            {
                //SET CURSOR-01 TO TRUE ou SET WS-PRD TO 1
                //var match = Regex.Match(line.Trim(), @"^SET\s+(?<varName>\S+)\s+TO\s+(?<command>\S+)");
                //ajuste para reconhecer o comando SET de forma múltipla
                //Ex:SET IXF1 IXP1 IXB1 IXB2 IXB3 TO WZEROS.
                var match = Regex.Match(line.Trim(), @"^SET\s+(?<varNames>(?:\S+\s+)*\S+)\s+TO\s+(?<command>\S+)");

                if (match.Success)
                {
                    //var originalName = match.Groups["varNames"].Value;
                    foreach (var m in match.Groups["varNames"].Value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        var command = match.Groups["command"].Value;
                        var varName = H.GetReferenceName(m, Result);
                        if (varName == null)
                            throw new Exception($"Variavel SET não encontrada :>{m}");

                        var varCommand = H.GetReferenceName(command, Result);
                        if (varCommand != null)
                            command = varCommand;
                        else
                            command = command.Trim().TrimEnd('.').ToLower();

                        var isTrueFalse = command?.ToLower() == "true" || command?.ToLower() == "false";

                        output.AppendLine($"{varName}{(!isTrueFalse ? ".Value" : "")} = {command};");
                        response.Executed = true;
                    }
                }

                //SET CURSOR-01 UP BY 1
                match = Regex.Match(line.Trim(), @"^SET\s+(?<varName>\S+)\s+UP\s+BY\s+(?<command>\S+)");
                if (match.Success)
                {
                    var originalName = match.Groups["varName"].Value;
                    var command = match.Groups["command"].Value;

                    var varName = H.GetReferenceName(originalName, Result);
                    if (varName == null)
                        throw new Exception($"Variavel SET não encontrada :>{originalName}");

                    var varCommand = H.GetReferenceName(command, Result);
                    if (varCommand != null)
                        command = varCommand;
                    else
                        command = command.Trim().TrimEnd('.').ToLower();

                    output.AppendLine($"{varName}{(varCommand == null || command != null ? ".Value" : "")} += {command};");
                    response.Executed = true;
                }

                //SET DATA3-MM TO I03
                match = Regex.Match(line.Trim(), @"^SET\s+(?<varName>\S+)\s+DOWN\s+BY\s+(?<command>\S+)");
                if (match.Success)
                {
                    var originalName = match.Groups["varName"].Value;
                    var command = match.Groups["command"].Value;

                    var varName = H.GetReferenceName(originalName, Result);
                    if (varName == null)
                        throw new Exception($"Variavel SET não encontrada :>{originalName}");

                    var varCommand = H.GetReferenceName(command, Result);
                    if (varCommand != null)
                        command = varCommand;
                    else
                        command = command.Trim().TrimEnd('.').ToLower();

                    output.AppendLine($"{varName}{(varCommand == null || command != null ? ".Value" : "")} -= {command};");
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
