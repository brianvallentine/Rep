using SpreadsheetLight;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

namespace FileResolver.Helper
{
    public class ErrorAnalisysMD
    {
        public ErrorAnalisysMD(string line, int lineNumber)
        {
            LineNumber = lineNumber;
            Line = line;
            Type = Line?.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)?.Skip(1)?.FirstOrDefault() ?? "";
        }

        public int LineNumber { get; set; }
        public string Line { get; set; }
        public string Type { get; set; }
    }

    public class ExcelFinalanalisysMetaData
    {
        public string FileName { get; private set; }
        public bool Tested { get; private set; }
        public string Moment { get; private set; }
        public int Lines { get; private set; }
        public List<ErrorAnalisysMD> ErrorList { get; private set; } = null;

        public ExcelFinalanalisysMetaData(string fileName, string moment)
        {
            FileName = fileName;
            Moment = moment;

            var inputFolder = Path.Combine(Environment.CurrentDirectory, FileResolverHelper.Conf.InputDirectory);
            var inputFile = Path.Combine(inputFolder, fileName);

            //contador de linhas de entrada
            if (Directory.Exists(inputFolder) && File.Exists(inputFile))
                Lines = File.ReadLines(inputFile).Count(x => !string.IsNullOrEmpty(x) && x.Length > 6 && x[6] != '*');

            //contador de erros de saida
            var outputFile = "";
            foreach (var module in FileResolverHelper.Conf.InputConfig.Modules)
            {
                var outputFolder = Path.Combine(Environment.CurrentDirectory, FileResolverHelper.Conf.OutputDirectory, FileResolverHelper.Conf.SolutionName, module.Name, "Code");
                var outFileName = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(fileName) + ".cs");

                if (Directory.Exists(outputFolder) && File.Exists(outFileName))
                    outputFile = outFileName;
            }

            if (!string.IsNullOrEmpty(outputFile))
            {
                ErrorList = File.ReadLines(outputFile)
                                    .Select((x, i) => new ErrorAnalisysMD(x, i))
                                    .Where(x =>
                                                Regex.IsMatch(x.Line, @"/\* \S+")
                                            && !string.IsNullOrEmpty(x.Line)
                                            && x.Line.Length > 6
                                            && x.Line[6] != '*'
                                    )
                                    .ToList();
            }
        }
    }

    public class ExcelFinalAnalisys
    {
        public static string PreFileName { get; set; } = "Analise de transpilação";
        public static void GenerateExcelFromData()
        {
            var fileName = $"{PreFileName} {DateTime.Now:dd-MM-yyyy HH_mm_ss}.xlsx";
            var outputFolder = Path.Combine(Environment.CurrentDirectory, fileName);

            Console.WriteLine($"");
            Console.WriteLine($"Gerando Excel de saida...");

            //TODO: aqui temos a listagem de erros distintos, organizar para sair em EXEL no formato do link:
            //https://foursys-my.sharepoint.com/:x:/g/personal/daniel_lucia_foursys_com_br/ESkhX4_iU3BMouLwL8Jv2H8BBF74jRfiGWDF-Jm6TCISoQ?e=yiA9F1&wdOrigin=TEAMS-WEB.p2p_ns.rwc&wdExp=TEAMS-TREATMENT&wdhostclicktime=1721161268977&web=1

            var conversions = new List<InputConfigModules>();
            var stabilizations = new List<InputConfigModules>();
            var builds = new List<InputConfigModules>();
            var testeds = new List<InputConfigModules>();
            var testedsDb = new List<InputConfigModules>();
            var deactivateds = new List<InputConfigModules>();

            for (var i = 0; i < FileResolverHelper.Conf.InputConfig.Modules.Count; i++)
            {
                var item = FileResolverHelper.Conf.InputConfig.Modules.ToList()[i];

                var module = new InputConfigModules();
                module.Name = item.Name;
                InputConfigModulesFiles[] arr = new InputConfigModulesFiles[item.Files.Count];
                item.Files.CopyTo(arr, 0);
                module.Files = arr.ToList();

                var conversionErrors = module.Files.Where(x => !x.Convert && x.Error?.ToLower().Contains("erro grave na conversão do programa") == true).ToList();
                var stabilizationErros = module.Files.Where(x => !x.Convert && x.Error?.ToLower().Contains("erro de build") == true).ToList();
                var buildErros = module.Files.Where(x => x.Convert == true && x.Tested != true).ToList();
                var alreadyTested = module.Files.Where(x => x.Convert == true && x.Tested == true && x.TestedDb != true).ToList();
                var alreadyTestedDb = module.Files.Where(x => x.Convert == true && x.TestedDb == true).ToList();
                var alreadyDeactivated = module.Files.Where(x => x.Convert == true && x.Deactivated == true).ToList();

                if (conversionErrors.Any())
                {
                    var convMod = new InputConfigModules();
                    convMod.Name = module.Name;
                    convMod.Files = conversionErrors;
                    conversions.Add(convMod);
                }

                if (stabilizationErros.Any())
                {
                    var convMod = new InputConfigModules();
                    convMod.Name = module.Name;
                    convMod.Files = stabilizationErros;
                    stabilizations.Add(convMod);
                }

                if (buildErros.Any())
                {
                    var convMod = new InputConfigModules();
                    convMod.Name = module.Name;
                    convMod.Files = buildErros;
                    builds.Add(convMod);
                }

                if (alreadyTested.Any())
                {
                    var convMod = new InputConfigModules();
                    convMod.Name = module.Name;
                    convMod.Files = alreadyTested;
                    testeds.Add(convMod);
                }

                if (alreadyTestedDb.Any())
                {
                    var convMod = new InputConfigModules();
                    convMod.Name = module.Name;
                    convMod.Files = alreadyTestedDb;
                    testedsDb.Add(convMod);
                }

                if (alreadyDeactivated.Any())
                {
                    var convMod = new InputConfigModules();
                    convMod.Name = module.Name;
                    convMod.Files = alreadyDeactivated;
                    deactivateds.Add(convMod);
                }
            }

            using SLDocument document = new();
            document.RenameWorksheet("Sheet1", "CONVERSÃO");
            GenerateFromMetaData(document, conversions.ToDictionary(x => x.Name, x => x.Files.Select(a => new ExcelFinalanalisysMetaData(a.Name, a.Error)).ToList()));

            document.AddWorksheet("ESTABILIZAÇÃO");
            GenerateFromMetaData(document, stabilizations.ToDictionary(x => x.Name, x => x.Files.Select(a => new ExcelFinalanalisysMetaData(a.Name, a.Error)).ToList()));

            document.AddWorksheet("BUILD");
            GenerateFromMetaData(document, builds.ToDictionary(x => x.Name, x => x.Files.Select(a => new ExcelFinalanalisysMetaData(a.Name, a.Error)).Where(x => x.ErrorList?.Any() == true).ToList()));

            document.AddWorksheet("PRONTO PARA TESTES");
            GenerateFromMetaData(document, builds.ToDictionary(x => x.Name, x => x.Files.Select(a => new ExcelFinalanalisysMetaData(a.Name, a.Error)).Where(x => x.ErrorList?.Any() != true).ToList()));
            //tested
            document.AddWorksheet("TESTES COM SUCESSO");
            GenerateFromMetaData(document, testeds.ToDictionary(x => x.Name, x => x.Files.Select(a => new ExcelFinalanalisysMetaData(a.Name, a.Error)).ToList()));
            //tested with DB
            document.AddWorksheet("TESTES DB SUCESSO");
            GenerateFromMetaData(document, testedsDb.ToDictionary(x => x.Name, x => x.Files.Select(a => new ExcelFinalanalisysMetaData(a.Name, a.Error)).ToList()));

            document.AddWorksheet("Não Convertidos Build");
            GenerateErrosFromMetaData(document, builds.ToDictionary(x => x.Name, x => x.Files.Select(a => new ExcelFinalanalisysMetaData(a.Name, a.Error)).Where(x => x.ErrorList?.Any() == true).ToList()));

            GenerateIndicators(document);

            document.SaveAs(outputFolder);

            Console.WriteLine($"Excel de saida em {outputFolder}");
        }

        static void ShowAllErrors()
        {
            var problems = new List<string>();
            foreach (var item in FileResolverHelper.Conf.InputConfig.Modules)
                problems.AddRange(item.Files.Where(x => !string.IsNullOrEmpty(x.Error)).Select(x => x.Error));

            foreach (var item in problems.Distinct().OrderBy(x => x.Length))
            {
                Console.WriteLine(item);
            }
        }

        public static void GenerateErrosFromMetaData(SLDocument document, Dictionary<string, List<ExcelFinalanalisysMetaData>> metaData)
        {
            try
            {
                var dateStyle = document.CreateStyle();
                dateStyle.SetFontColor(Color.White);
                dateStyle.SetFontItalic(true);
                dateStyle.SetFontBold(true);
                dateStyle.SetPatternFill(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, Color.Black, Color.Black);

                var dataPercentCellStl = document.CreateStyle();
                dataPercentCellStl.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center);
                //dataPercentCellStl.ApplyNamedCellStyle(SLNamedCellStyleValues.Percentage);

                document.SetColumnStyle(4, 4, dataPercentCellStl);

                document.SetCellValue("A1", "Erros");
                document.SetCellValue("B1", "Qtd");
                document.SetCellValue("E1", "Projeto");
                document.SetCellValue("F1", "Arquivo");
                document.SetCellValue("G1", "Tipo Erro");
                document.SetCellValue("H1", "Linha");
                document.SetCellValue("I1", "Erro");
                document.SetCellStyle("E1", dateStyle);
                document.SetCellStyle("F1", dateStyle);
                document.SetCellStyle("G1", dateStyle);
                document.SetCellStyle("H1", dateStyle);
                document.SetCellStyle("I1", dateStyle);
                var considerLine = 1;
                var dicErr = new Dictionary<string, int>();

                foreach (var item in metaData)
                    for (int i = 0; i < item.Value.Count; i++)
                    {
                        var listItem = item.Value.ElementAtOrDefault(i);
                        var ordered = listItem?.ErrorList.OrderBy(x => x.Type);

                        foreach (var ord in ordered)
                        {
                            considerLine++;

                            document.SetCellValue(considerLine, 1 + 4, item.Key); //E
                            document.SetCellValue(considerLine, 2 + 4, listItem?.FileName); //F
                            document.SetCellValue(considerLine, 3 + 4, ord.Type); //G
                            document.SetCellValue(considerLine, 4 + 4, ord.LineNumber); //H
                            document.SetCellValue(considerLine, 5 + 4, ord.Line.Trim()); //I
                            //form dos erros completos

                            if (dicErr.ContainsKey(ord.Type))
                                dicErr[ord.Type]++;
                            else
                                dicErr.Add(ord.Type, 1);
                        }
                    }

                considerLine = 1;

                foreach (var item in dicErr)
                {
                    considerLine++;

                    document.SetCellValue(considerLine, 1, item.Key); //E
                    document.SetCellValue(considerLine, 2, item.Value); //E
                }
            }
            catch (Exception)
            {
            }
        }

        public static void GenerateFromMetaData(SLDocument document, Dictionary<string, List<ExcelFinalanalisysMetaData>> metaData)
        {

            try
            {
                var dateStyle = document.CreateStyle();
                dateStyle.SetFontColor(Color.White);
                dateStyle.SetFontItalic(true);
                dateStyle.SetFontBold(true);
                dateStyle.SetPatternFill(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, Color.Black, Color.Black);

                document.SetCellValue("A1", "Projeto");
                document.SetCellValue("B1", "Arquivo");
                document.SetCellValue("C1", "Momento");
                document.SetCellValue("D1", "Linhas");
                document.SetCellValue("E1", "=SUM(D:D)");
                document.SetCellStyle("A1", dateStyle);
                document.SetCellStyle("B1", dateStyle);
                document.SetCellStyle("C1", dateStyle);
                document.SetCellStyle("D1", dateStyle);
                var considerLine = 1;

                foreach (var item in metaData)
                    for (int i = 0; i < item.Value.Count; i++)
                    {
                        considerLine++;

                        var listItem = item.Value.ElementAt(i);

                        document.SetCellValue(considerLine, 1, item.Key);
                        document.SetCellValue(considerLine, 2, listItem.FileName);
                        document.SetCellValue(considerLine, 3, listItem.Moment);
                        document.SetCellValue(considerLine, 4, listItem.Lines);
                    }

                //document.AutoFitColumn("A");
                //document.AutoFitColumn("B");
                //document.AutoFitColumn("C");
                //document.AutoFitColumn("D");
                //document.AutoFitColumn("E");
            }
            catch (Exception)
            {
            }
        }

        public static void GenerateIndicators(SLDocument document)
        {
            try
            {
                document.AddWorksheet("STATUS");

                var blackCellStl = document.CreateStyle();
                var dataNumberCellStl = document.CreateStyle();
                var dataPercentCellStl = document.CreateStyle();

                blackCellStl.SetFontColor(Color.White);
                blackCellStl.SetFontItalic(true);
                blackCellStl.SetFontBold(true);
                blackCellStl.SetPatternFill(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, Color.Black, Color.Black);
                blackCellStl.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center);

                dataNumberCellStl.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center);
                dataNumberCellStl.FormatCode = "#,##0";

                dataPercentCellStl.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center);
                dataPercentCellStl.ApplyNamedCellStyle(SLNamedCellStyleValues.Percentage);

                document.SetCellValue("B1", "CONVERSÃO");
                document.SetCellValue("C1", "ESTABILIZAÇÃO");
                document.SetCellValue("D1", "BUILD");
                document.SetCellValue("E1", "PRONTO PARA TESTES");
                document.SetCellValue("F1", "TESTES COM SUCESSO");
                document.SetCellValue("G1", "TESTES DB SUCESSO");
                document.SetCellValue("I1", "TOTAL");
                document.SetCellValue("A2", "LINHAS");
                document.SetCellValue("A3", "% LINHAS");
                document.SetCellValue("A4", "ARQUIVOS");
                document.SetCellValue("A5", "% ARQUIVOS");
                document.SetCellValue("A7", "LINHAS Dia");
                document.SetCellValue("A8", "ARQUIVOS Dia");
                document.SetCellValue("B6", "CONVERSÃO");
                document.SetCellValue("C6", "ESTABILIZAÇÃO");
                document.SetCellValue("D6", "BUILD");
                document.SetCellValue("E6", "PRONTO PARA TESTES");
                document.SetCellValue("F6", "TESTES COM SUCESSO");
                document.SetCellValue("G6", "TESTES DB SUCESSO");

                document.SetCellStyle("B1", "I1", blackCellStl);
                document.SetCellStyle("B6", "G6", blackCellStl);
                document.SetCellStyle("A2", "A5", blackCellStl);
                document.SetCellStyle("A7", "A8", blackCellStl);

                document.SetCellStyle("B2", "I2", dataNumberCellStl);
                document.SetCellStyle("B4", "I4", dataNumberCellStl);

                document.SetCellStyle("B3", "G3", dataPercentCellStl);
                document.SetCellStyle("B5", "G5", dataPercentCellStl);

                document.SetCellValue("B2", "=SUM(CONVERSÃO!D:D)");
                document.SetCellValue("C2", "=SUM(ESTABILIZAÇÃO!E:E)");
                document.SetCellValue("D2", "=SUM(BUILD!E:E)");
                document.SetCellValue("E2", "=SUM('PRONTO PARA TESTES'!E:E)");
                document.SetCellValue("F2", "=SUM('TESTES COM SUCESSO'!E:E)");
                document.SetCellValue("G2", "=SUM('TESTES DB SUCESSO'!E:E)");
                document.SetCellValue("I2", "=B2+C2+D2+E2+F2+G2");

                document.SetCellValue("B3", "=B2/$I$2");
                document.SetCellValue("C3", "=C2/$I$2");
                document.SetCellValue("D3", "=D2/$I$2");
                document.SetCellValue("E3", "=E2/$I$2");
                document.SetCellValue("F3", "=F2/$I$2");
                document.SetCellValue("G3", "=G2/$I$2");

                document.SetCellValue("B4", "=COUNTA(CONVERSÃO!$A2:$A9999)");
                document.SetCellValue("C4", "=COUNTA(ESTABILIZAÇÃO!$A2:$A9999)");
                document.SetCellValue("D4", "=COUNTA(BUILD!$A2:$A9999)");
                document.SetCellValue("E4", "=COUNTA('PRONTO PARA TESTES'!$A2:$A9999)");
                document.SetCellValue("F4", "=COUNTA('TESTES COM SUCESSO'!$A2:$A9999)");
                document.SetCellValue("G4", "=COUNTA('TESTES DB SUCESSO'!$A2:$A9999)");

                document.SetCellValue("I4", "=B4+C4+D4+E4+F4+G4");

                document.SetCellValue("B5", "=B4/$I$4");
                document.SetCellValue("C5", "=C4/$I$4");
                document.SetCellValue("D5", "=D4/$I$4");
                document.SetCellValue("E5", "=E4/$I$4");
                document.SetCellValue("F5", "=F4/$I$4");
                document.SetCellValue("G5", "=G4/$I$4");

                var filePath = Directory.GetCurrentDirectory();
                var filesFounded = Directory.GetFiles(filePath, $"{PreFileName}*");
                if (filesFounded.Any())
                {
                    //var fls = filesFounded.Select(x => new { name = Path.GetFileNameWithoutExtension(x), when = DateTime.ParseExact(Regex.Match(x, @"\d+-\d+-\d+ \d+_\d+_\d+").Value.Replace("-", "/").Replace("_", ":"), "dd-MM-aaaa HH-mm-ss", CultureInfo.InvariantCulture) });k
                    var fls = filesFounded.Select(x => new { name = Path.GetFileName(x), when = DateTime.ParseExact(Regex.Match(x, @"\d+-\d+-\d+ \d+_\d+_\d+").Value, "dd-MM-yyyy HH_mm_ss", CultureInfo.InvariantCulture) });
                    fls = fls.OrderBy(x => x.when).ToList();
                    var yesterdayFile = fls.LastOrDefault(x => x.when.ToString("yyyyMMdd") == DateTime.Now.AddDays(-1).ToString("yyyyMMdd"));

                    if (yesterdayFile != null)
                    {
                        document.SetCellValue("B7", $"='{filePath}\\[{yesterdayFile.name}]STATUS'!B2-B2");
                        document.SetCellValue("C7", $"='{filePath}\\[{yesterdayFile.name}]STATUS'!C2-C2");
                        document.SetCellValue("D7", $"='{filePath}\\[{yesterdayFile.name}]STATUS'!D2-D2");
                        document.SetCellValue("E7", $"='{filePath}\\[{yesterdayFile.name}]STATUS'!E2-E2");
                        document.SetCellValue("F7", $"='{filePath}\\[{yesterdayFile.name}]STATUS'!F2-F2");
                        document.SetCellValue("G7", $"='{filePath}\\[{yesterdayFile.name}]STATUS'!G2-G2");

                        document.SetCellValue("B8", $"='{filePath}\\[{yesterdayFile.name}]STATUS'!B4-B4");
                        document.SetCellValue("C8", $"='{filePath}\\[{yesterdayFile.name}]STATUS'!C4-C4");
                        document.SetCellValue("D8", $"='{filePath}\\[{yesterdayFile.name}]STATUS'!D4-D4");
                        document.SetCellValue("E8", $"='{filePath}\\[{yesterdayFile.name}]STATUS'!E4-E4");
                        document.SetCellValue("F8", $"='{filePath}\\[{yesterdayFile.name}]STATUS'!F4-F4");
                        document.SetCellValue("G8", $"='{filePath}\\[{yesterdayFile.name}]STATUS'!G4-G4");
                    }
                }

                document.SetColumnWidth("A", "I", 21);
            }
            catch (Exception)
            {
            }
        }
    }
}
