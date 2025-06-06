using SpreadsheetLight;
using System.Drawing;

namespace CODE.ANALYSER
{
    public class ExcelDependenciesGeneratorMetaData
    {
        public int LineNumber { get; private set; }
        public string Name { get; private set; }

        public ExcelDependenciesGeneratorMetaData(int lineNumber, string calledProgram)
        {
            LineNumber = lineNumber;
            Name = calledProgram;
        }
    }

    public class ExcelDependenciesGenerator
    {
        public static void GenerateFromMetaData(Dictionary<string, List<ExcelDependenciesGeneratorMetaData>> metaData)
        {
            using SLDocument document = new();

            try
            {
                document.RenameWorksheet("Sheet1", "Analise de Chamadas");

                var dateStyle = document.CreateStyle();
                dateStyle.SetFontColor(Color.White);
                dateStyle.SetFontItalic(true);
                dateStyle.SetFontBold(true);
                dateStyle.SetPatternFill(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, Color.Black, Color.Black);

                document.SetCellValue("A1", "Linha");
                document.SetCellValue("B1", "Programa");
                document.SetCellValue("C1", "Chamada");
                document.SetCellStyle("A1", dateStyle);
                document.SetCellStyle("B1", dateStyle);
                document.SetCellStyle("C1", dateStyle);
                var considerLine = 1;

                foreach (var item in metaData)
                    for (int i = 0; i < item.Value.Count; i++)
                    {
                        considerLine++;

                        var listItem = item.Value.ElementAt(i);

                        if (listItem.LineNumber > 0)
                            document.SetCellValue(considerLine, 1, listItem.LineNumber);

                        document.SetCellValue(considerLine, 2, item.Key);
                        document.SetCellValue(considerLine, 3, listItem.Name);
                    }

                var fileName = $"Analise de Chamadas {DateTime.Now:dd-MM-yyyy HH_mm_ss}.xlsx";
                document.SaveAs(Path.Combine(Environment.CurrentDirectory, fileName));
            }
            catch (Exception)
            {
            }
        }
    }
}
