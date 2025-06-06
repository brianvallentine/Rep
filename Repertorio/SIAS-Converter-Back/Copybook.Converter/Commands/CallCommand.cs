using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class CallCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; }
        public ResultSet Result { get; set; }
        public CobolCommandResponse Execute(string line)
        {
            var output = new StringBuilder();
            var response = new CobolCommandResponse(line);

            try
            {
                //CALL WS-CALL USING LINKAGE-SZ02022S END-CALL
                var match = Regex.Match(line.Replace(",", " ").Replace(";", "").Replace("END-CALL.", "").Replace("END-CALL", ""), @"^CALL\s+(?<variableProgName>\S+)\s+USING\s+(?<parameterName>[\S|\s]+)");
                if (match.Success)
                {
                    var variableProgName = match.Groups["variableProgName"].Value;
                    var parameterNames = match.Groups["parameterName"].Value.Replace(Environment.NewLine, " ").Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                    var varProg = H.GetReferenceName(variableProgName, Result);
                    //var parameters = new List<string>();

                    if (string.IsNullOrWhiteSpace(varProg) && variableProgName.Contains("'"))
                        varProg = variableProgName.Replace("'", "\"");

                    var parameterRefList = new List<ReferenceModel>();
                    foreach (var parameterName in parameterNames)
                    {
                        var paramRef = H.GetReferenceProperty(parameterName, Result);
                        if (string.IsNullOrWhiteSpace(varProg) || paramRef == null)
                            throw new Exception($"Erro ao formar o CALL parametros inválidos: var={varProg} - param={paramRef}");

                        parameterRefList.Add(paramRef);
                    }

                    var parameters = ParametersResolver(parameterRefList);

                    output.AppendLine($"_.Call({varProg}, {string.Join(", ", parameters)});");

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

        private List<string> ParametersResolver(List<ReferenceModel> convertedLines)
        {
            var retList = new List<string>();

            foreach (var item in convertedLines.DistinctBy(x => x.PropertyParent))
            {
                //se o item que estou lendo dos parametros for class, posso utilizar diretamente seu tipo,
                //caso contrário devo utilizar o tipo de seu antecessor

                //existem casos excentricos, que serão adicionados aqui
                var propperAdd = item.PropertyIsClass || retList.Count > 5 ? item.PropertyName.Split(".").LastOrDefault() : item.PropertyParent;
                var variable = H.GetReferenceProperty(propperAdd, Result);
                if (variable == null)
                    variable = H.GetReferencePropertyByClass(propperAdd, Result);

                if (variable != null)
                    if (propperAdd != null && !retList.Any(x => x.Contains(propperAdd)))
                        retList.Add($"{variable.PropertyName}");
            }

            return retList;
        }
    }
}
