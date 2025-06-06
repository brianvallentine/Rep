using Cobol.Converter;
using CobolLanguageConverter.Converter.DIVISION;
using CodeAnalyser.Helper;
using Copybook.Converter;
using Executor.ConsoleApp;
using FileResolver;
using FileResolver.Helper;
using FileResolver.Model;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Executor.ConsoleApp;

public class Program
{
    public static void Main(string[] args)
    {
        if(args.Length == 0 || args.Length > 0 && args[0] != "--pipeline")
            Console.Clear();

        ConfigLoad.Load();

        var isJustAnalyse = FileResolverHelper.Conf.JustAnalyse;
        var isBuildAndShow = FileResolverHelper.Conf.BuildAndShow;
        var isParallelExecution = FileResolverHelper.Conf.ParallelExecution;
        var index = 0;
        var apiMethodsReference = new List<MethodReferenceInfo>();

        var stopWatchConversion = new Stopwatch();
        stopWatchConversion.Start();

        if (isJustAnalyse)
        {
            if (FileResolverHelper.Conf.BuildAndShow)
            {
                BuildAndShowProcess.BuildAndShowFromData();
                return;
            }

            if (FileResolverHelper.Conf.RenamePascalCase)
            {
                FileGenerator.ConvertNamesToPascalCase();
                return;
            }

            var analyser = new FileAnalyser();
            //resolver.CreateSolutionForGeneratedCode();
            analyser.QuantifyPerformance();
            stopWatchConversion.Stop();

            Console.WriteLine($"");
            Console.WriteLine($"  ----- Tempo de execução do conversor: => {stopWatchConversion.Elapsed}");

            if (FileResolverHelper.Conf.GenerateExcelIndicators)
                ExcelFinalAnalisys.GenerateExcelFromData();

            return;
        }

        var resolver = new FileGenerator();
        resolver.RemoveConvertedFiles();

        var cobolFiles = FileResolverHelper.GetAllInputFiles();
        var fileAndTypes = new Dictionary<string, ProgramType>();

        var modules = new List<string>();
        FileResolverHelper.Conf.InputConfig.ConsiderModuleLoad();
        FileResolverHelper.Conf.InputConfig.ListModuleConsider.ForEach(x => modules.AddRange(x.Files.Select(x => x.Name)));

        cobolFiles = cobolFiles.Where(x => modules.Any(m => Path.GetFileNameWithoutExtension(m) == Path.GetFileNameWithoutExtension(x))).ToArray();

        var notFounded = modules.Where(x => !cobolFiles.Any(m => Path.GetFileNameWithoutExtension(m) == Path.GetFileNameWithoutExtension(x))).ToList();
        if (notFounded.Any())
        {
            Console.WriteLine($"{notFounded.Count()} files NOT founded...");
            foreach (var item in notFounded)
            {
                Console.WriteLine($"Not Found -> {Path.GetFileNameWithoutExtension(item)}");
            }
            Console.WriteLine($"");
        }

        var i = 1;
        var length = cobolFiles.Length;

        if (FileResolverHelper.Conf.InputConfig.AnalisysBlock > 0)
            Console.WriteLine($"{cobolFiles.Length} To Analisys");

        Console.WriteLine($"{length} files founded");
        Console.WriteLine($"");

        foreach (var cobolFile in cobolFiles)
        {
            var fileProgType = AnalysisHelper.IsProgram(cobolFile);
            //if (
            //           fileProgType != ProgramType.IGNORE
            //        && fileProgType != ProgramType.ANOTHER
            //        //&& fileProgType != ProgramType.DCL

            //        && fileProgType != ProgramType.DB2
            //        && fileProgType != ProgramType.JCL
            //    )
            if (fileProgType == ProgramType.COBOL)
                fileAndTypes.Add(cobolFile, fileProgType);
        }

        Console.WriteLine($"Modules:");
        foreach (var module in FileResolverHelper.Conf.InputConfig.ListModuleConsider)
            Console.WriteLine($"   * {module.Name}      with {module.Files.Count} file(s).");

        Console.WriteLine($"");

        var orderedToDo = fileAndTypes.OrderBy(x => x.Value);
        resolver.ClearInputFiles();

        if (!isParallelExecution)
            foreach (var orderedItem in orderedToDo)
            {
                ExecutionPlan(orderedItem);
            }
        else
        {
            int numThreads = Environment.ProcessorCount;
            Parallel.ForEach(orderedToDo, new ParallelOptions { MaxDegreeOfParallelism = numThreads }, ExecutionPlan);
        }

        stopWatchConversion.Stop();
        var stopWatchFormat = new Stopwatch();
        stopWatchFormat.Start();

        resolver.CreateSolutionForGeneratedCode(apiMethodsReference);

        stopWatchFormat.Stop();

        if (!isJustAnalyse)
        {
            var analyser = new FileAnalyser();
            analyser.QuantifyPerformance();
        }

        if (FileResolverHelper.Conf.GenerateExcelIndicators)
            ExcelFinalAnalisys.GenerateExcelFromData();

        Console.WriteLine($"");
        Console.WriteLine($"  -----      Tempo de execução do conversor:  => {stopWatchConversion.Elapsed}");
        Console.WriteLine($"  -----      Tempo de execução do formatador: => {stopWatchFormat.Elapsed}");
        Console.WriteLine($"  -----      Tempo de execução Total:         => {stopWatchFormat.Elapsed.Add(stopWatchConversion.Elapsed)}");

        void ExecutionPlan(KeyValuePair<string, ProgramType> orderedToDo)
        {
            var cobolFile = orderedToDo.Key;
            try
            {
                var fileProgType = AnalysisHelper.IsProgram(cobolFile);
                var csharpCode = "";
                //IDivisionCommand.Result = new ResultSet();
                //DclGenConverter? converterDcl = null;

                // Adicionar classe principal
                var currentClassName = Path.GetFileNameWithoutExtension(cobolFile).Replace("-", "_");
                var projNameFolder = "";

                if (fileProgType == ProgramType.COBOL)
                {
                    // Lógica para lidar com programas COBOL (caso necessário)
                    Console.WriteLine($"Programa COBOL encontrado: {cobolFile} -> {++index}°");
                    //continue;
                    var cobolConv = new CobolConverter(cobolFile);
                    csharpCode = cobolConv.Run();
                    lock (apiMethodsReference)
                    {
                        apiMethodsReference.AddRange(cobolConv.Result.ApiMethodsReference);
                    }
                    projNameFolder = "CODE";

                    var outputFileName = FileResolverHelper.ChangeFileExtention(cobolFile, ".cs");
                    var outputPath = FileResolverHelper.GetOutputPathCombined(Path.Combine(projNameFolder, outputFileName));

                    FileResolverHelper.Write(outputPath, csharpCode);
                }
            }
            catch (Exception ex)
            {
                ///*FileResolverHelper.Conf.InputConfig.Modules*/.FirstOrDefault(x=>x.);
                for (int i = 0; i < FileResolverHelper.Conf.InputConfig.Modules.Count; i++)
                {
                    var module = FileResolverHelper.Conf.InputConfig.Modules[i];
                    for (int j = 0; j < module.Files.Count; j++)
                    {
                        var file = module.Files[j];
                        if (Path.GetFileNameWithoutExtension(file.Name) == Path.GetFileNameWithoutExtension(cobolFile))
                            file.Convert = false;
                    }
                }

                Console.WriteLine(" - Erro grave na conversão do programa: {0} {1}", Path.GetFileNameWithoutExtension(cobolFile), ex.Message);
            }
        }
    }
}