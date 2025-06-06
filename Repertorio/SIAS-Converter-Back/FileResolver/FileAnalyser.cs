using FileResolver.Helper;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;
using System.Text.RegularExpressions;

namespace FileResolver;

public class FileAnalyser
{
    //public static Dictionary<string, List<string>> programsToRefferNamespace = new Dictionary<string, List<string>>();

    public void QuantifyPerformance()
    {
        Console.WriteLine($"Analisando código convertido...");
        Console.WriteLine($"...");

        var outputFolderName = FileResolverHelper.Conf.OutputDirectory;
        var inputFolderName = FileResolverHelper.Conf.InputDirectory;
        var solutionName = FileResolverHelper.Conf.SolutionName;
        var inputFolderPath = Path.Combine(Directory.GetCurrentDirectory(), inputFolderName);

        var allReadedLines = 0f;
        var allConvertedLines = 0f;
        var allErrorLines = 0f;

        var modules = new List<string>();
        FileResolverHelper.Conf.InputConfig.ConsiderModuleLoad();
        FileResolverHelper.Conf.InputConfig.ListModuleConsider.ForEach(x => modules.AddRange(x.Files.Select(x => x.Name).ToList()));

        var fileFolders = Directory.GetFiles(inputFolderPath).Where(x => modules.Any(m => Path.GetFileNameWithoutExtension(m) == Path.GetFileNameWithoutExtension(x))).ToList();

        foreach (var inputFile in fileFolders)
        {
            var module = FileResolverHelper.Conf.InputConfig.ListModuleConsider.FirstOrDefault(x => x.Files.Any(f => Path.GetFileNameWithoutExtension(f.Name) == Path.GetFileNameWithoutExtension(inputFile)));

            var cobolProjecPath = Path.Combine(Directory.GetCurrentDirectory(), outputFolderName, solutionName, module.Name, "Code");
            var errorConversionCounter = 0f;
            var progName = Path.GetFileNameWithoutExtension(inputFile);
            var inputFileLines = File.ReadAllLines(inputFile).ToList();
            var inputFileLinesFree = inputFileLines.Where(x => IsValidLine(x)).ToList();

            var csharpFilePath = Path.Combine(cobolProjecPath, $"{progName}.cs");
            var allLines = new List<string>();
            var isOutputFileError = !File.Exists(csharpFilePath);

            if (isOutputFileError)
                errorConversionCounter += inputFileLinesFree.Count;
            else
                allLines = File.ReadAllLines(csharpFilePath).ToList();

            foreach (var line in allLines)
            {
                var mustCountLine =
                                (line.Trim().StartsWith("/* ") && !line.Trim().Contains("/* Removido na conversão"))
                            || line.Trim().Contains("/*Err")
                            || line.Trim().Contains("equal zeroes")
                            || line.Trim().Contains("VARYING()")
                            || (!line.Trim().Contains("\"") && !line.Trim().Contains("'") && line.Trim().Contains(".."))
                            || (!line.Trim().Contains("\"") && !line.Trim().Contains("'") && Regex.IsMatch(Regex.Replace(line.Trim(), @"-\d+", ""), @"\S+-\S+"))
                            || (
                                    !line.Trim().Contains("\"")
                                 && !line.Trim().Contains(" class ")
                                 && !line.Trim().Contains(" FROM ")
                                 && !line.Trim().Contains(" INTO ")
                                 && Regex.IsMatch(line, @"\d+\s*:\s*\d+")
                               )
                            ;

                if (
                    line.Trim().StartsWith(@"/*-") ||
                    line.Trim().Contains(@"//Recursividade")
                )
                    mustCountLine = false;

                if (line.Trim().StartsWith(@"/* EXEC SQL WHENEVER"))
                    mustCountLine = false;

                if (line.Trim().StartsWith(@"---"))
                    mustCountLine = false;

                if (line.Trim().Contains(@":00:00.000000"))
                    mustCountLine = false;

                if (mustCountLine)
                    errorConversionCounter++;
            }

            //parametros de entrada, remover quando solucionar
            //errorConversionCounter++;

            allReadedLines += inputFileLinesFree.Count;
            allConvertedLines += (inputFileLinesFree.Count - errorConversionCounter);
            allErrorLines += errorConversionCounter;

            float percent = (((errorConversionCounter / inputFileLinesFree.Count) - 1f) * 100f) * -1;
            Console.WriteLine($"***** {progName} ***** {(!isOutputFileError ? "" : "( não convertido )")}");
            Console.WriteLine($" -> (COBOL) - número de linhas total origem ( úteis e inúteis ):  {inputFileLines.Count}");
            Console.WriteLine($" -> (C#)    - número de linhas total destino ( úteis e inúteis ): {allLines.Count}");
            Console.WriteLine($" -> (COBOL) - número de linhas úteis origem :                 {inputFileLinesFree.Count}");
            Console.WriteLine($" -> (C#)    - linhas de erros encontrados ( não convertido ): {errorConversionCounter}");
            Console.WriteLine($" -> (C#)    - % Convertido : % {percent.ToString("N0")}");
            Console.WriteLine($"***** {progName} *****");
            Console.WriteLine($"");
        }

        float convertedPercent = (((allErrorLines / allReadedLines) - 1f) * 100f) * -1;
        Console.WriteLine($"----------------------------------------------------------------");
        Console.WriteLine($"  ----- Total de programas lidos: {fileFolders.Count}");
        Console.WriteLine($"  ----- Total de linhas lidas: {allReadedLines}");
        Console.WriteLine($"  ----- Total de linhas convertidas: {allConvertedLines}");
        Console.WriteLine($"  ----- Erros: {allErrorLines}");
        Console.WriteLine($"  ----- Média geral de conversão: % {convertedPercent.ToString("N0")}");
    }

    bool IsValidLine(string line)
    {
        if (string.IsNullOrEmpty(line)) return false;
        if (line.Length < 7) return false;
        if (line[6] == '*') return false;

        return true;
    }
}
