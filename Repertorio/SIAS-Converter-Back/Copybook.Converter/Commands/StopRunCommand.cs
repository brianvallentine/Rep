using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using System.Text;
using System.Text.RegularExpressions;

namespace CobolLanguageConverter.Converter.Commands
{
    public class StopRunCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public CobolCommandResponse Execute(string line)
        {
            var output = new StringBuilder();
            var response = new CobolCommandResponse(line);

            try
            {
                var match = Regex.Match(line, @"STOP\s+RUN\s*\.*");
                if (match.Success)
                {
                    output.AppendLine($"\nthrow new GoBack();   // => STOP RUN.");
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
