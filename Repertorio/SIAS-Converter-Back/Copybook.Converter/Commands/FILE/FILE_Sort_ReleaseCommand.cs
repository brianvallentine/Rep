using CobolLanguageConverter.Converter.Commands.IF;
using CobolLanguageConverter.Converter.DIVISION;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class FILE_Sort_ReleaseCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; } //Cobol Code
        public ResultSet Result { get; set; }
        StringBuilder output = new StringBuilder();

        public CobolCommandResponse Execute(string line)
        {
            var response = new CobolCommandResponse(line);

            try
            {
                //inicio do RELEASE
                if (line.StartsWith("RELEASE "))
                {
                    //RELEASE REG-ARQSORT  Exactly
                    var match = Regex.Match(line, @"RELEASE\s+(?<variable>\S+)");
                    if (match.Success)
                    {
                        var variable = match.Groups["variable"].Value.Replace(".", "");
                        var variableRef = H.GetReferenceProperty(variable, Result);

                        var pType = $"SortBasis<{variableRef.PropertyType}>";
                        var fileSort = H.GetReferencePropertyByClass(pType, Result);

                        output.AppendLine($@"{fileSort.PropertyName}.Release({variableRef.PropertyName});");

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
