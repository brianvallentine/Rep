using CobolLanguageConverter.Converter.Commands.DIVISIONS;
using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class GoToCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public CobolCommandResponse Execute(string line)
        {
            var output = new StringBuilder();
            var response = new CobolCommandResponse(line);

            try
            {
                var isGoto = false;
                Match rexGoTo = null;
                try { rexGoTo = Regex.Match(line.Trim(), @"^GO\s+TO\s+(?<method>\S+)", RegexOptions.None, TimeSpan.FromSeconds(1)); isGoto = rexGoTo.Success; } catch { }

                if (isGoto)
                {
                    var threatedLine = rexGoTo.Groups["method"].Value;
                    var methodName = GetMethodName(threatedLine);
                    var isExecute = Result.CurrentMethod.Name == "Execute";

                    if (string.IsNullOrEmpty(methodName))
                        throw new Exception("Erro ao definir nome do Go To.");

                    var searchMethod = Result.ProcedureReference.Keys.FirstOrDefault(x => x.Name == methodName || x.Name == $"{methodName}_SECTION");
                    methodName = searchMethod?.Name ?? methodName;
                        
                    var isIgnoredMethod = methodName != "Execute" && H.IsIgnoredMethod(searchMethod, Result);
                    var isRecursivity = methodName == Result.CurrentMethod.Name;
                    var isReadMode = Result.IsIn.Any(x => x.Contains("READ_"));
                    var converted = "";

                    if (isIgnoredMethod)
                        converted = $"/*Método Suprimido por falta de linha ou apenas EXIT nome: {methodName}*/ //GOTO";
                    else if (isRecursivity)
                        converted = $@"new Task(() => {methodName}()).RunSynchronously(); //GOTO";
                    else
                        converted = $"\n{methodName}(); //GOTO";

                    output.AppendLine(converted);

                    //precisa de throw no isReadMode, quando não for método ignorado ou quando não for recursividade
                    //if ((isIgnoredMethod || isRecursivity) && !isReadMode)
                    output.AppendLine($"return {(isExecute ? "Result" : "")};{(isRecursivity ? "//Recursividade detectada, cuidado..." : "")}");
                    //else
                    //output.AppendLine($"throw new GoToException();");

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

        private string GetMethodName(string line, bool cSharpName = true)
        {
            // Extrair o nome do método
            string methodName = Regex.Match(line, @"(\bPERFORM\s*)?(?<NomeDoMetodo>\w+(?:-\w+)*)\b").Groups["NomeDoMetodo"].Value;
            if (cSharpName)
            {
                if (char.IsDigit(methodName[0]))
                    methodName = $"{CSharp_CobolLineChangeCommand.ChangedNewKeyMarker}{methodName}";

                methodName = methodName.Replace("-", "_");
            }

            return methodName;
        }
    }
}
