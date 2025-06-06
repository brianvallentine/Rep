using CobolLanguageConverter.Converter.Commands.IF;
using CobolLanguageConverter.Converter.DIVISION;
using System.Text;
using System.Text.RegularExpressions;
using FileResolver.Helper;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class FILE_WriteCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; } //Cobol Code
        public ResultSet Result { get; set; }
        StringBuilder output = new StringBuilder();

        public CobolCommandResponse Execute(string line)
        {
            var response = new CobolCommandResponse(line);

            try
            {
                if (Regex.IsMatch(line.Trim(), @"^WRITE\s+"))
                {
                    var ret = Write(line);

                    output.AppendLine(ret);

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

        string Write(string line)
        {
            var moveInCaseFrom = "";
            var qf = FileResolverHelper.Conf.ProjectQualifierGeneralCommands;
            var matchFrom = Regex.Match(line, @"WRITE\s+(?<varname>\S+)\s+FROM\s+(?<varname2>\S+(\s+\([^\)]+\))*)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (matchFrom.Success)
            {
                var varname1 = matchFrom.Groups["varname"].Value.Replace("-", "_").TrimEnd('.');
                var varname2 = matchFrom.Groups["varname2"].Value.Replace("-", "_").TrimEnd('.');

                var propName1 = H.GetReferenceProperty(varname1, Result, true)?.PropertyName;
                var propName2 = H.GetIfResponseForLine(varname2, 0, Result);
                // Tratamento para transformar indices corretamente DE: TAB-REG-PROPOSTA(IND-TAB) PARA: TABELA_PROPOSTA.TAB_REG_PROPOSTA[WS_WORKING.INDEXADORES.IND_TAB]
                propName2 = propName2.Replace("(", "[").Replace(")", "]");

                moveInCaseFrom = $"{qf}.Move({propName2}.GetMoveValues(), {propName1}); \r\n \r\n ";
            }
            //// Regex para identificar padrões nas condições de write de arquivo do COBOL
            var match = Regex.Match(line, @"WRITE\s+(?<varname>\S+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (!match.Success) return line;

            var varname = match.Groups["varname"].Value.Replace("-", "_").TrimEnd('.');

            var findRelativeFile = Result.FileSelectReference.FirstOrDefault(x => x.Value == varname || x.Value.Contains($".{varname}"));
            if (findRelativeFile.Key == null) throw new Exception($"variavel relativa não encontrada! VAR:> {varname}");

            var fileName = Regex.Replace(findRelativeFile.Key, @"_RELATIVE\d*", "");
            var propName = H.GetReferenceProperty(varname, Result, true)?.PropertyName;

            return $"{moveInCaseFrom}{fileName}.Write({(string.IsNullOrEmpty(propName) ? "" : $"{propName}.GetMoveValues().ToString()")});";
        }
    }
}
