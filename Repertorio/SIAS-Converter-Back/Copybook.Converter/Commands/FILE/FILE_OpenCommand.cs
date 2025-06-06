using CobolLanguageConverter.Converter.Commands.IF;
using CobolLanguageConverter.Converter.DIVISION;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class FILE_OpenCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; } //Cobol Code
        public ResultSet Result { get; set; }
        StringBuilder output = new StringBuilder();

        public CobolCommandResponse Execute(string line)
        {
            var response = new CobolCommandResponse(line);
            var enteredOpen = false;

            try
            {
                if ((line.StartsWith("OUTPUT ") || line.StartsWith("INPUT ")) && Result.IsIn.Contains("OPEN"))
                {
                    enteredOpen = true;

                    var splited = Regex.Replace(line, @"\s+", " ").TrimEnd('.').Split(' ');
                    var openType = splited[0];

                    foreach (var item in splited.Skip(1))
                    {
                        output = Open($"OPEN {openType} {item}");
                    }

                    response.Executed = true;
                }

                if (line.StartsWith("OPEN "))
                {
                    enteredOpen = true;

                    output = Open(line);

                    //output.AppendLine(ret);

                    if (!Result.IsIn.Contains("OPEN"))
                        Result.IsIn.Add("OPEN");

                    response.Executed = true;
                }

                //este tratamento foi adicionado pois o COBOL aceita open em linha
                /*                                   
                   OPEN INPUT  ARQENT01                                                 
                        OUTPUT ARQSAI01                                                 
                               ARQSAI02.  
                 */
                if (!enteredOpen && Result.IsIn.Contains("OPEN"))
                    Result.IsIn.Remove("OPEN");
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            response.SetResponse(output);
            return response;
        }

        StringBuilder Open(string line)
        {
            var output = new StringBuilder();

            //// Regex para identificar padrões nas condições de OPEN de arquivo do COBOL
            var match = Regex.Match(line, @"OPEN\s+\S+\s+(?<varnames>((?<varname>\S+)\s*)+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (!match.Success) return new StringBuilder(line);

            var varname = match.Groups["varnames"].Value.Replace("-", "_").TrimEnd('.');
            varname = Regex.Replace(varname.Trim(), @",", "");
            //varname = Regex.Replace(varname, @"\s+", ",");
            if (string.IsNullOrEmpty(varname)) return new StringBuilder(line);

            var varnames = varname?
                        .Split(new[] { "\r\n", " " }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList()
                        ?? new List<string>();
            foreach (var item in varnames)
            {
                var varStatus = H.GetReferenceName(Result.FileSelectReference[$"{item}_STATUS"], Result);
                var varRelative = H.GetReferenceName(Result.FileSelectReference[$"{item}_RELATIVE0"], Result);
                var statusRelative = $", {varStatus}";

                if (string.IsNullOrEmpty(varStatus))
                    statusRelative = "";

                output.AppendLine($"{item}.Open({varRelative}{statusRelative});");
            }

            return output;
        }

        //string Open(string line)
        //{
        //    //// Regex para identificar padrões nas condições de open de arquivo do COBOL
        //    var match = Regex.Match(line, @"OPEN\s+\S+\s+(?<varname>\S+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
        //    if (!match.Success) return line;

        //    var varname = match.Groups["varname"].Value.Replace("-", "_").TrimEnd('.');
        //    var varStatus = H.GetReferenceName(Result.FileSelectReference[$"{varname}_STATUS"], Result);
        //    var varRelative = H.GetReferenceName(Result.FileSelectReference[$"{varname}_RELATIVE"], Result);
        //    var statusRelative = $", {varStatus}";

        //    if (string.IsNullOrEmpty(varStatus))
        //        statusRelative = "";

        //    return $"{varname}.Open({varRelative}{statusRelative});";
        //}
    }
}
