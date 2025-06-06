using FileResolver.Helper;
using Microsoft.Extensions.Configuration;

namespace Executor.ConsoleApp;

public static class ConfigLoad
{
    public static void Load(string loadPath = "app.json")
    {
        // Configurar o builder de configuração
        var configurationBuilder = new ConfigurationBuilder()
            .AddJsonFile(loadPath, optional: false, reloadOnChange: true);

        // Construir a configuração
        var configuration = configurationBuilder.Build();
        var resolveConfig = new FileResolverConfig
        {
            InputDirectory = configuration["inputDirectory"],
            OutputDirectory = configuration["outputDirectory"],
            OutputCobolDirectory = configuration["outputCobolDirectory"],
            SolutionName = configuration["solutionName"],
            ProjectCobolName = configuration["projectCobolName"],
            ProjectCopyName = configuration["projectCopyName"],
            ProjectDclName = configuration["projectDclName"],
            ProjectTestName = configuration["projectTestName"],
            DatabasePrefixes = configuration["databasePrefixes"],
            DatabasePrefix = configuration["databasePrefixes"]?.Split(",").ToList() ?? new List<string>(),
            DatabaseOriginalPrefixes = configuration["databaseOriginalPrefixes"],
            DatabaseOriginalPrefix = configuration["databaseOriginalPrefixes"]?.Split(",").ToList() ?? new List<string>(),
            LogAllLines = bool.TryParse(configuration["logAllLines"], out var pLog) ? pLog : false,
            LogAllBlocks = bool.TryParse(configuration["logAllBlocks"], out pLog) ? pLog : false,
            LogNumber = bool.TryParse(configuration["logNumber"], out var pLogLin) ? pLogLin : false,
            ConvertToSqlServer = bool.TryParse(configuration["convertToSqlServer"], out var pConvSql) ? pConvSql : false,
            GenerateAtSingleProject = bool.TryParse(configuration["generateAtSingleProject"], out var pGen) ? pGen : false,
            AddTestProject = bool.TryParse(configuration["addTestProject"], out var pTest) ? pTest : false,
            GenerateApiProject = bool.TryParse(configuration["generateApiProject"], out var pGenApi) ? pGenApi : false,
            RenamePascalCase = bool.TryParse(configuration["renamePascalCase"], out var pRenPCase) ? pRenPCase : false,
            GenerateJsonIndicators = bool.TryParse(configuration["generateJsonIndicators"], out var pGenJson) ? pGenJson : false,
            GenerateExcelIndicators = bool.TryParse(configuration["generateExcelIndicators"], out var pGenExcel) ? pGenExcel : false,
            ShowErrors = bool.TryParse(configuration["showErrors"], out var pShow) ? pShow : false,
            JustAnalyse = bool.TryParse(configuration["justAnalyse"], out var pAna) ? pAna : false,
            ParallelExecution = bool.TryParse(configuration["parallelExecution"], out var pPar) ? pPar : false,
            GenerateTestProject = bool.TryParse(configuration["generateTestProject"], out var pGenTest) ? pGenTest : false,
            BuildAndShow = bool.TryParse(configuration["buildAndShow"], out var pBuildAndShow) ? pBuildAndShow : false,
            LogTimeLine = bool.TryParse(configuration["logTimeLine"], out var pLogTimeLine) ? pLogTimeLine : false,
        };

        configuration.GetSection("inputConfig").Bind(resolveConfig.InputConfig);

        // Obter valores das configurações
        FileResolverHelper.Load(resolveConfig);
    }
}

