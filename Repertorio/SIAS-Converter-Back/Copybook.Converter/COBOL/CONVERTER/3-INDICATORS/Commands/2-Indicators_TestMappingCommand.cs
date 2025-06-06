using CobolLanguageConverter.Converter.DIVISION;
using CobolLanguageConverter.Converter.INDICATORS;
using FileResolver.Helper;
using Newtonsoft.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using IA_ConverterCommons;

namespace CobolLanguageConverter.Converter.Commands.INDICATORS
{
    public class Indicators_TestMappingCommand : IIndicatorsCommand
    {
        public int Order { get; set; } = 40;
        public ResultSet Result { get; set; }

        public StringBuilder Execute(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines, ref dynamic outData)
        {
            if (!FileResolverHelper.Conf.GenerateTestProject) return csharpCode;

            GenerateTestIndicators(csharpCode, ref divisionAndLines, ref outData);
            return csharpCode;
        }

        void GenerateTestIndicators(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines, ref dynamic outData)
        {
            var paramDatas = new List<string>();
            var methodDatas = new List<string>();
            var methodDatasTransformed = new List<string>();
            var ret = csharpCode.ToString();
            var filePath = Path.Combine(FileResolverHelper.Conf.OutputDirectory, FileResolverHelper.Conf.ProjectTestName);
            var programName = $"{Result.programName}_Tests";
            var collection = $"[Collection(\"{programName}\")]\r\n";
            var collectionDb = $"[Collection(\"{programName}_DB\")]\r\n";
            var programNameDB = $"{Result.programName}_Tests_DB";
            var fileNameExt = $"{programName}.cs";
            var isFact = true;
            var isCopy = false;
            var inlineData = "";
            var methodBrackets = "()";

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            if (outData?.MethodDescription?.Methods?.Count > 0)
            {
                var methods = (List<AnalisysMethodManager>)outData.MethodDescription.Methods;
                var executeMethod = methods.FirstOrDefault(x => x.EntraceMethod == true);

                if (executeMethod?.Parameters?.Count > 0)
                {
                    methodBrackets = "(";

                    isFact = false;
                    inlineData = "[InlineData(";
                    var iterator = 123456789;

                    foreach (string item in executeMethod.Parameters)
                    {
                        if (item.Contains("string") || item.Contains("StringBasis"))
                            paramDatas.Add($"\"{iterator}\"");
                        else if (item.Contains("int") || item.Contains("IntBasis") || item.Contains("DoubleBasis"))
                            paramDatas.Add($"{iterator}");

                        methodDatas.Add(item);
                    }

                    var considerCommomList = VarBasis.VarBasysCommomTypes.Select(x => x.Name).ToList();
                    considerCommomList.Add("string");
                    inlineData += string.Join(",", paramDatas);
                    methodBrackets += string.Join(",", methodDatas.Where(a => considerCommomList.Contains(a.Split(" ")?.FirstOrDefault()?.Trim())).Select(x => { var splt = x.Split(" "); return $"{splt[0].Replace("Basis", "").ToLower()} {splt[1]}"; }));
                    inlineData += ")]";
                    methodBrackets += ")";
                }

                if (inlineData == "[InlineData()]")
                {
                    isFact = true;
                    isCopy = true;
                    inlineData = "";
                }
            }

            var paramsToPass = new List<string>();
            foreach (var item in methodDatas)
            {
                //methodDatas.Select(x => { var splt = x.Split(" "); return !splt[0].ToString().Contains("Basis") ? splt[1] : $"new {splt[0]}(null, {splt[1]})"; })
                var splt = item.Split(" ");
                var varType = splt[0];
                var varCreation = splt[1];

                var isBasis = varType.ToString().Contains("Basis");
                if (isBasis)
                {
                    if (varType.ToString().Contains("DoubleBasis"))
                        varCreation = $"new {varType}(null,2, {varCreation})";
                    else
                        varCreation = $"new {varType}(null, {varCreation})";
                }
                else if (varType != "string")
                    varCreation = $"new {varType}()";

                paramsToPass.Add(varCreation);
            }

            var decorationName = isFact ? "Fact" : "Theory";
            var testFile = $"using static Code.{Result.programName};" + Environment.NewLine +
                           $"using {FileResolverHelper.Conf.ProjectCopyName};" + Environment.NewLine +
                           $"{collection}" + Environment.NewLine +
                           $"[Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]" + Environment.NewLine +
                           $"[Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package?)]" + Environment.NewLine +
                           $"public class {programName} {{" + Environment.NewLine +
                           $"//é de extrema importancia que este método seja modificado com cautela, " + Environment.NewLine +
                           $"//o melhor é manter aqui apenas os dados que serão COMUM a todos os {decorationName}'s criados" + Environment.NewLine +
                           $"public static void Load_Parameters()" +
                            @"{"
                                //+ @"AppSettings.TestSet.DynamicData.Clear();" + Environment.NewLine
                                + @"#region PARAMETERS" + Environment.NewLine;

            if (Result.SqlToTest.Any())
            {
                var strB = new StringBuilder();
                var i = 0;
                foreach (var sqlTestItem in Result.SqlToTest)
                {
                    strB.AppendLine($"#region {sqlTestItem.MethodName}");
                    strB.AppendLine("");

                    var qName = $"q{i++}";
                    strB.AppendLine($"var {qName} = new DynamicData();");
                    strB.AppendLine($"{qName}.AddDynamic(new Dictionary<string, string>{{");
                    foreach (var fieldItem in sqlTestItem.Fields)
                        strB.AppendLine($"\t\t\t\t{{ \"{fieldItem.Replace("\n","").Replace("\r","")}\" , \"\"}}{(sqlTestItem.Fields.Count > 1 ? "," : "")}");

                    strB.AppendLine($"\t\t\t}});");
                    strB.AppendLine($"AppSettings.TestSet.DynamicData.Add(\"{sqlTestItem.MethodName}\", {qName});");

                    strB.AppendLine("");
                    strB.AppendLine($"#endregion");
                    strB.AppendLine("");

                }

                testFile += strB.ToString();
            }

            testFile += $"#endregion" +
                        Environment.NewLine +
                        "}" +
                        Environment.NewLine +
                        Environment.NewLine +
                        $"[{decorationName}]"
                        + $"{inlineData}"
                        + $"public static void {programName}_{decorationName}{methodBrackets}"
                        + @"
                        {"
                        + @"lock (AppSettings.TestSet._lock) {" + Environment.NewLine
                          + @"AppSettings.TestSet.IsTest = true;" + Environment.NewLine
                          + @"AppSettings.TestSet.Clear();" + Environment.NewLine
                          + @"Load_Parameters();" + Environment.NewLine + Environment.NewLine +
                           @"//para testes quando necessário alterar alguma variavel do loadParameter faça assim:" + Environment.NewLine +
                           @"//AppSettings.TestSet.DynamicData[""R0100_00_INICIALIZA_Query1""][""SISTEMAS_DATA_MOV_ABERTO""] = ""10"";" + Environment.NewLine +
                           @"//dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso..." + Environment.NewLine + Environment.NewLine +
                           @"#region VARIAVEIS_TESTE" + Environment.NewLine +
                           @"#endregion" + Environment.NewLine +
                           $"var program = new {Result.programName}();" + Environment.NewLine +
                           $"program.Execute({string.Join(",", paramsToPass)});" + Environment.NewLine +
                           @"
                               Assert.True(true);
                           }
                           }
                          }
                       ";

            File.WriteAllText(Path.Combine(filePath, fileNameExt), testFile);


            ///gerando código do banco de dados SECO
            testFile = $"using static Code.{Result.programName};" + Environment.NewLine +
                          $"using {FileResolverHelper.Conf.ProjectCopyName};" + Environment.NewLine +
                          $"{collectionDb}" + Environment.NewLine +
                          $"[Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]" + Environment.NewLine +
                          $"[Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package?)]" + Environment.NewLine +
                          $"public class {programNameDB} {{" + Environment.NewLine;

            testFile += $"\n[Fact]";
            testFile += $"\npublic static void {Result.programName}_Database()";
            testFile += $"\n{{";
            testFile += $"\nvar program = new {Result.programName}();";
            testFile += $"\nAppSettings.TestSet.DB_Test.Is_DB_Test = true;\n";
            if (csharpCode.ToString().Contains("InitializeGetQuery"))
                testFile += $"\nprogram.InitializeGetQuery();\n\n";
            var k = 0;
            if (Result.SqlToTest.Any())
            {
                var strB = new StringBuilder();
                foreach (var sqlTestItem in Result.SqlToTest)
                    strB.AppendLine($"try{{ /*{++k}*/ {string.Join(" ", sqlTestItem.ParentMethodName.Split("|").Select(x => $"program.{x}();"))} }}catch(Exception ex) {{ {FileResolverHelper.Conf.ProjectQualifierGeneralCommands}.ThreatableTestError(ex); }}");

                testFile += strB.ToString();
            }
            testFile += $"\n}}";
            testFile += $"\n}}";

            File.WriteAllText(Path.Combine(filePath, $"{programNameDB}.cs"), testFile);
        }
    }
}
