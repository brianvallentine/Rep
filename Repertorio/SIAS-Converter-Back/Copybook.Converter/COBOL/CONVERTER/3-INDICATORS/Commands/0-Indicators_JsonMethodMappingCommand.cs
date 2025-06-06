using CobolLanguageConverter.Converter.DIVISION;
using CobolLanguageConverter.Converter.INDICATORS;
using FileResolver.Helper;
using Newtonsoft.Json;
using System.Text;
using System.Text.RegularExpressions;

namespace CobolLanguageConverter.Converter.Commands.INDICATORS
{
    public class Indicators_JsonMethodMappingCommand : IIndicatorsCommand
    {
        public int Order { get; set; } = 30;
        public ResultSet Result { get; set; }

        public StringBuilder Execute(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines, ref dynamic outData)
        {
            if (!FileResolverHelper.Conf.GenerateJsonIndicators) return csharpCode;

            var ret = GenerateJsonIndicators(csharpCode, ref divisionAndLines, ref outData);
            return ret;
        }

        StringBuilder GenerateJsonIndicators(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines, ref dynamic outData)
        {
            var ret = csharpCode;
            var filePath = Path.Combine(FileResolverHelper.Conf.OutputDirectory, FileResolverHelper.Conf.ProjectCobolName, "Properties");
            var fileName = $"{Result.programName}_Methods.json";

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            var methods = new List<AnalisysMethodManager>();
            foreach (var item in Result.ProcedureReference)
            {
                var ignoredMethod = item.Value.Count == 1 && item.Value.FirstOrDefault().Line.Contains("EXIT");
                var isEntraceMethod = item.Key.Name == "Execute";
                List<string> parameters = new List<string>();

                if (isEntraceMethod)
                    parameters = Result.ParametersReference.Select(x => $"{x.Value} {x.Key}").ToList();

                methods.Add(
                    new AnalisysMethodManager
                    {
                        EntraceMethod = isEntraceMethod,
                        Parameters = parameters,
                        Name = item.Key.Name,
                        Lines = item.Value.Count,
                        Calls = Result.ProcedureReference.Where(x => item.Value.Any(v => Regex.IsMatch(v.Line, @$"(?<!'){x.Key.Name.Replace("_", "-")}"))).Select(x => x.Key.Name).ToList(),
                        Obs = ignoredMethod ? "Método ignorado por falta de comandos" : ""
                    }
                );
            }

            Result.MethodsToAnalise = methods;
            var queryDes = new
            {
                Inserts = Result.SqlToTest.Count(x => x.Type == SqlTestType.INSERT),
                Updates = Result.SqlToTest.Count(x => x.Type == SqlTestType.UPDATE),
                Deletes = Result.SqlToTest.Count(x => x.Type == SqlTestType.DELETE),
                Selects = Result.SqlToTest.Count(x => x.Type == SqlTestType.SELECT),
                Cursors = Result.SqlToTest.Count(x => x.Type == SqlTestType.CURSOR),
                Procedures = Result.SqlToTest.Count(x => x.Type == SqlTestType.PROCEDURE),
                All = Result.SqlToTest.Count,
            };

            outData = new
            {
                QueryDescription = new
                {
                    Inserts = queryDes.Inserts,
                    Updates = queryDes.Updates,
                    Deletes = queryDes.Deletes,
                    Selects = queryDes.Selects,
                    Cursors = queryDes.Cursors,
                    Procedures = queryDes.Procedures,
                    All = queryDes.All,
                },
                MethodDescription = new
                {
                    ProgramName = Result.programName,
                    Quantity = methods.Count,
                    Methods = methods
                },
                CopyDescription = new
                {
                    Quantity = Result.CopybooksReference.Count(x => !x.Value.PropertyName.Contains(".")),
                    Names = Result.CopybooksReference.Where(x => !x.Value.PropertyName.Contains(".")).Select(x => x.Key)
                },
                DclDescription = new
                {
                    Quantity = Result.DclReference.Count(x => !x.Value.PropertyName.Contains(".")),
                    Names = Result.DclReference.Where(x => !x.Value.PropertyName.Contains(".")).Select(x => x.Key)
                },
                FilesDescription = new
                {
                    Quantity = Result.FileSelectReference.Count(x => x.Key.Contains("_RELATIVE")),
                    Names = Result.FileSelectReference.Where(x => x.Key.Contains("_RELATIVE")).Select(x => x.Key.Replace("_RELATIVE", ""))
                }
            };

            File.WriteAllText(Path.Combine(filePath, fileName), JsonConvert.SerializeObject(outData, Formatting.Indented));

            return ret;
        }
    }
}
