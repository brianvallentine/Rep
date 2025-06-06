using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CobolLanguageConverter.Converter.DIVISION;
using FileResolver.Helper;
using IA_ConverterCommons;


namespace CobolLanguageConverter.Converter.Commands.DIVISIONS
{
    public class Division_NormalizeInternalProcedureDivision : IDivisionCommand
    {
        public int Order { get; set; } = 3;
        public ResultSet Result { get; set; } = new ResultSet();

        public string Execute(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            //return lines;

            var ret = NormalizeCopyInternal("^PROCEDURE(.*?)+DIVISION", lines, ref divisionAndLines);
            ret = NormalizeCopyInternal("^FILE(.*?)+SECTION", lines, ref divisionAndLines);

            return ret;
        }

        /// <summary>
        /// Método para normalizar os "copy's" dentro da procedure division, deve-se copiar o código encontrado para dentro do método
        /// </summary>
        string NormalizeCopyInternal(string commaSection, string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = lines;
           // var commaSection = @"^PROCEDURE(.*?)+DIVISION";
            var secLine = divisionAndLines.FirstOrDefault(x => Regex.IsMatch(x.Key, commaSection, RegexOptions.None, TimeSpan.FromMilliseconds(500)));

            var allLines = secLine.Value;
            if (allLines is null) 
                return ret;


            for (int j = 0; j < allLines.Count; j++)
            {
                var line = allLines[j].Line.Trim();

                #region Include Copy Routine
                var rex = Regex.Match(line, @"^COPY\s+(?<copyName>\S+)[.]*?");
                if (rex.Success)
                {
                    var copyName = rex.Groups["copyName"].Value.TrimEnd('.');
                    var fileDir = Path.Combine(Directory.GetCurrentDirectory(), FileResolverHelper.Conf.InputDirectory, "COPY");
                    var filePath = Path.Combine(fileDir, copyName);

                    if (!Directory.Exists(fileDir) || !File.Exists(filePath))
                    {
                        //alguns arquivos estão com .BKL
                        copyName += ".bkl";
                        filePath = Path.Combine(fileDir, copyName);
                        if (!Directory.Exists(fileDir) || !File.Exists(filePath))
                        {
                            line += "//Erro ao encontrar o local do arquivo de copy";
                            continue;
                        }
                    }

                    var fileLines = File.ReadAllLines(filePath);

                    //Replacing by command
                    Match replacingBy = Regex.Match(line, @"REPLACING\s+==(?<old>.*?)==\s+BY\s+==(?<new>.*?)==");

                    if (replacingBy.Success)
                    {
                        string oldValue = replacingBy.Groups["old"].Value;
                        string newValue = replacingBy.Groups["new"].Value;
                        
                        // Cria uma nova lista com as linhas já substituídas (simulando a inclusão do COPY com REPLACING)
                        List<string> processedLines = new();
                        processedLines.AddRange(from string x in fileLines
                                                select x.Replace(oldValue, newValue));
                        fileLines = processedLines.ToArray();
                    }

                    var validLines = fileLines.Where(x => x.Length > 6 && x[6] != '*').Select(x => new CurrentLineType(x.Substring(7, (x.Length > 72 ? 72 : x.Length) - 7), allLines[j].LineNumber)).ToList();

                    if (validLines.Any())
                    {
                        allLines.RemoveAt(j);
                        allLines.InsertRange(j, validLines);
                    }
                }
                #endregion
            }

            return ret;
        }
    }
}
