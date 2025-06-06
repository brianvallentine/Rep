using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using FileResolver.Helper;
using IA_ConverterCommons;
using System.Text;
using System.Text.RegularExpressions;

namespace CobolLanguageConverter.Converter.Commands.DIVISIONS
{
    public class Division_CopyReferenceCommand : IDivisionCommand
    {
        public int Order { get; set; } = 4;
        public ResultSet Result { get; set; }
        private StringBuilder _errorFounded = new StringBuilder();

        public string Execute(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = CopyReference(lines, ref divisionAndLines);
            ret = DclReference(ret, ref divisionAndLines);

            if (!string.IsNullOrWhiteSpace(_errorFounded.ToString()))
                throw new Exception(_errorFounded.ToString());

            return ret;
        }

        string CopyReference(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = lines;
            var sections = new List<string>
            {
                @"FILE(.*?)+SECTION"             ,
                @"WORKING-STORAGE(.*?)+SECTION"   ,
                @"LOCAL-STORAGE(.*?)+SECTION"   ,
                @"LINKAGE(.*?)+SECTION"           ,
            };

            var currResultReference = new Dictionary<string, ReferenceModel>();
            var allFiles = FileResolverHelper.GetAllInputFiles();

            for (int i = 0; i < divisionAndLines.Count; i++)
            {
                var secLine = divisionAndLines.ElementAt(i);
                var matchItem = sections.FirstOrDefault(x => Regex.IsMatch(secLine.Key, x, RegexOptions.None, TimeSpan.FromMilliseconds(500)));
                if (matchItem == null)
                    continue;

                currResultReference = Result.CopybooksReference;

                //neste momento cada linha do fullLineList contem 1 representação de linha do Cobol
                //por mais que o operador tenha pulado linha no documento.
                foreach (var currentCopy in secLine.Value)
                {
                    var currentCopyLine = currentCopy.Line;

                    //comentários não contam
                    if (currentCopyLine.Length > 6 && currentCopyLine[6] == '*') continue;

                    var rex = Regex.Match(currentCopyLine, @"\s*COPY\s+(?<copyName>\S+)\s*[\.]*");
                    if (!rex.Success) continue;

                    var copyName = rex.Groups["copyName"].Value.Trim().TrimEnd('.');
                    var copybookFilePath = allFiles.FirstOrDefault(x => Path.GetFileNameWithoutExtension(x) == copyName);

                    if (copybookFilePath == null)
                    {
                        _errorFounded.AppendLine($"COPY não encontrado! ->| {copyName} |");
                        continue;
                    }

                    var copybookCode = File.ReadAllText(copybookFilePath);
                    var copyCleanedLines = PreProcessingCleanLines(copybookCode).Select(x => new CurrentLineType(x, currentCopy.LineNumber)).ToList();

                    var parser = new CommonVariableParser(Result);
                    parser.classMarker = $"{copyName}_";

                    if (!Result.ALLCopiesReference.ContainsKey(copyName))
                        parser.ParseToReference(copyCleanedLines, ref currResultReference, copyName, true, "Copy");
                }
            }
            return ret;
        }

        string DclReference(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = lines;
            var sections = new List<string>
            {
                @"FILE\s+SECTION$"             ,
                @"WORKING-STORAGE\s+SECTION$"   ,
                @"LOCAL-STORAGE\s+SECTION$"   ,
                @"LINKAGE\s+SECTION$"           ,
            };

            var sqlDefaults = new List<string>
            {
                "SQLCA",
            };

            var currResultReference = new Dictionary<string, ReferenceModel>();
            var allFiles = FileResolverHelper.GetAllInputFiles();

            for (int i = 0; i < divisionAndLines.Count; i++)
            {
                var secLine = divisionAndLines.ElementAt(i);
                var matchItem = sections.FirstOrDefault(x => Regex.IsMatch(secLine.Key, x, RegexOptions.None, TimeSpan.FromMilliseconds(500)));
                if (matchItem == null)
                    continue;

                currResultReference = Result.DclReference;

                //neste momento cada linha do fullLineList contem 1 representação de linha do Cobol
                //por mais que o operador tenha pulado linha no documento.
                foreach (var currentCopy in secLine.Value)
                {
                    var currentCopyLine = currentCopy.Line;

                    var rex = Regex.Match(currentCopyLine, @"\s*EXEC\s+SQL\s+INCLUDE\s+(?<copyName>.*?)\s+(END-EXEC)*[\.]*");
                    if (!rex.Success) continue;

                    var copyName = rex.Groups["copyName"].Value;
                    var copybookFilePath = allFiles.FirstOrDefault(x => Path.GetFileNameWithoutExtension(x) == copyName);

                    if (copyName == "SQLCA" && !currResultReference.ContainsKey(copyName))
                    {
                        currResultReference.Add("SQLCA", new ReferenceModel("DB.SQLCA", "SQLCA", false));
                        currResultReference.Add("SQLCODE", new ReferenceModel("DB.SQLCODE", "SQLCODE", false));
                        currResultReference.Add("SQLERRMC", new ReferenceModel("DB.SQLERRMC", "SQLERRMC", false));
                        currResultReference.Add("SQLSTATE", new ReferenceModel("DB.SQLSTATE", "SQLSTATE", false));
                        currResultReference.Add("SQLCAID", new ReferenceModel("DB.SQLCAID", "SQLCAID", false));
                        currResultReference.Add("SQLCABC", new ReferenceModel("DB.SQLCABC", "SQLCABC", false));
                        currResultReference.Add("SQLERRP", new ReferenceModel("DB.SQLERRP", "SQLERRP", false));
                        for (int j = 1; j <= DatabaseBasis.SQLERRD.Items.Count; j++)
                            currResultReference.Add($"SQLERRD({j})", new ReferenceModel($"DB.SQLERRD[{j}]", "SQLERRD", false));
                        currResultReference.Add("SQLWARN", new ReferenceModel("DB.SQLWARN", "SQLWARN", false));
                        continue;
                    }

                    if (copybookFilePath == null)
                    {
                        _errorFounded.AppendLine($"DCLGEN não encontrado! ->| {copyName} |");
                        continue;
                    }

                    var copybookCode = File.ReadAllText(copybookFilePath);
                    var copyCleanedLines = PreProcessingCleanLines(copybookCode).Select(x => new CurrentLineType(x, currentCopy.LineNumber)).ToList();

                    var parser = new CommonVariableParser(Result);
                    parser.classMarker = $"{copyName}_";

                    if (!Result.ALLCopiesReference.ContainsKey(copyName))
                        parser.ParseToReference(copyCleanedLines, ref currResultReference, copyName, true, "Dcl");
                }
            }
            return ret;
        }

        List<string> PreProcessingCleanLines(string lines)
        {
            var validLines = new List<string>();

            try
            {
                foreach (var line in lines.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
                {
                    // Skip lines with less than 7 characters
                    if (line.Length < 7) continue;

                    // Check if the line is a comment (*) at position 7
                    if (line[6] == '*') continue;

                    // Check if the line is a comment --
                    if (line.StartsWith("--")) continue;

                    var lineLength = line.Length - 7;
                    if (lineLength > (72 - 7))
                        lineLength = 72 - 7;

                    validLines.Add(line.Substring(7, lineLength));
                }

                var allList = validLines;
                for (int j = 0; j < allList.Count; j++)
                {
                    var line = allList[j];

                    var rex = Regex.Match(line, @"\d+\s+REDEFINES\s+");
                    if (rex.Success)
                        allList[j] = Regex.Replace(line, @"(?<1>\d+\s+)(?<2>REDEFINES)\s+", @"${1} FILLER ${2}    ");


                    if (line.TrimEnd().EndsWith("."))
                    {
                        allList[j] = line.TrimEnd('.') + "|_|+|_|";
                    }
                }

                var fullLines = string.Join("", validLines.Select(x => x.TrimEnd()));
                var splitedRex = fullLines.Split("|_|+|_|", StringSplitOptions.RemoveEmptyEntries).Select(x => x.TrimEnd()).Where(x => !string.IsNullOrEmpty(x));
                validLines = splitedRex.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading the COPY file: {ex.Message}");
            }


            return validLines;
        }
    }
}