using CobolLanguageConverter.Converter.Commands.IF;
using CobolLanguageConverter.Converter.DIVISION;
using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class FILE_Sort_ReturnCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; } //Cobol Code
        public ResultSet Result { get; set; }
        StringBuilder output = new StringBuilder();

        public CobolCommandResponse Execute(string line)
        {
            var response = new CobolCommandResponse(line);

            try
            {
                if (line.Contains(".") && Result.IsIn.Any(x => x.Contains("RETURN_")))
                {
                    var inn = Result.IsIn.LastOrDefault(x => x.Contains("RETURN_"));
                    Result.IsIn.Remove(inn);

                    response.AfterExecuted = $@"
                        }});
                    }}
                    catch (GoToException ex)
                    {{
                        return;
                    }}";

                    response.Executed = true;
                }

                //inicio do RETURN
                if (line.StartsWith("RETURN "))
                {
                    //RETURN {FILE} AT END  Exactly
                    var match = Regex.Match(line, @"RETURN\s+(?<variable>\S+)\s+AT\s+END");
                    if (match.Success)
                    {
                        var variable = match.Groups["variable"].Value;
                        var variableRef = H.GetReferenceProperty(variable, Result);
                        var key = $"RETURN_{variable}";

                        var rexPperty = Regex.Match(variableRef.PropertyType, @"SortBasis<(?<type>\S+)>");
                        var pType = rexPperty.Groups["type"].Value;
                        var fileSort = H.GetReferencePropertyByClass(pType, Result);

                        //Add IsIn para fechar o bloco
                        if (!Result.IsIn.Contains(key))
                            Result.IsIn.Add(key);

                        output.AppendLine($@"try
                        {{
                            {variableRef.PropertyName}.Return({fileSort.PropertyName},() => {{");

                        response.Executed = true;
                    }
                }

                // Cláusula NOT AT END
                if (line.Trim().StartsWith("NOT AT END") && !Result.IsIn.Any(x => x.Contains("READ_NOT_AT_END_")))
                {
                    output.AppendLine($@"    }}, () => {{");
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
