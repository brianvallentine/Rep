using Newtonsoft.Json;

namespace FileResolver.Helper;

public static class FileResolverHelper
{
    public static FileResolverConfig Conf { get; private set; } = null;

    public static void Load(FileResolverConfig fileResolverConfig)
    {
        Conf = fileResolverConfig;
    }

    public static string[] GetAllInputFiles()
    {
        var inputFiles = Directory.GetFiles(Conf.InputDirectory, "*").ToList();
        foreach (var pathInner in Directory.GetDirectories(Path.Combine(Conf.InputDirectory)))
        {
            var innerFiles = Directory.GetFiles(pathInner, "*");
            if (innerFiles?.Any() == true)
                inputFiles.AddRange(innerFiles);
        }
        return inputFiles.ToArray();
    }

    public static string GetOutputPathCombined(string outputFileName = "")
    {
        var outputDirectory = Conf.OutputDirectory;

        if (string.IsNullOrEmpty(outputFileName))
            return outputDirectory;
        else
        {
            Directory.CreateDirectory(outputDirectory);

            if (string.IsNullOrEmpty(Path.GetExtension(outputFileName)))
                Directory.CreateDirectory(Path.Combine(outputDirectory, outputFileName));
            else
            {
                Directory.CreateDirectory(Path.Combine(outputDirectory, outputFileName).Replace("\\" + Path.GetFileName(outputFileName), ""));
            }

            return Path.Combine(outputDirectory, outputFileName);
        }
    }

    public static string GetCopyProjectPath(bool fullpath = false, bool withName = false)
    {
        Directory.CreateDirectory(Path.Combine(Conf.OutputDirectory, Conf.SolutionName, Conf.ProjectCopyName));

        var path = Path.Combine(Conf.OutputDirectory, Conf.SolutionName, Conf.ProjectCopyName, (withName ? Conf.ProjectCopyNameAndExt : ""));

        if (fullpath)
            return Path.Combine(Directory.GetCurrentDirectory(), path);

        return path;
    }

    public static string GetSolutionPath(bool fullpath = false, bool withName = false)
    {
        Directory.CreateDirectory(Path.Combine(Conf.OutputDirectory, Conf.SolutionName, Conf.ProjectCopyName));

        var path = Path.Combine(Conf.OutputDirectory, Conf.SolutionName, (withName ? Conf.SolutionNameAndExt : "")); ;

        if (fullpath)
            return Path.Combine(Directory.GetCurrentDirectory(), path);

        return path;
    }

    public static string ChangeFileExtention(string fileName, string newExt)
    {
        return Path.GetFileNameWithoutExtension(fileName) + newExt;
    }

    public static void Write(string outputPath, string allText)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None))
        using (StreamWriter writer = new StreamWriter(fs, System.Text.Encoding.UTF8))
        {
            writer.Write(allText);
        }
    }
}

public class FileResolverConfig
{
    // Obter valores das configurações
    public string InputDirectory { get; set; }
    public string OutputDirectory { get; set; }
    public string SolutionName { get; set; }
    public string ProjectCopyName { get; set; }
    public string ProjectCobolName { get; set; }
    public string ProjectDclName { get; set; }
    public string ProjectTestName { get; set; }
    public bool ConvertToSqlServer { get; set; }
    public string DatabaseOriginalPrefixes { get; set; }
    public string DatabasePrefixes { get; set; }
    public bool GenerateTestProject { get; set; }
    public bool JustAnalyse { get; set; }
    public bool ParallelExecution { get; set; }
    public bool LogAllLines { get; set; }
    public bool LogAllBlocks { get; set; }
    public bool LogNumber { get; set; }
    public bool LogTimeLine { get; set; }
    public bool ShowErrors { get; set; }
    public bool GenerateAtSingleProject { get; set; }
    public bool AddTestProject { get; set; }
    public bool GenerateApiProject { get; set; }
    public bool RenamePascalCase { get; set; }
    public bool GenerateJsonIndicators { get; set; }
    public bool BuildAndShow { get; set; }
    public bool GenerateExcelIndicators { get; set; }
    public string OutputCobolDirectory { get; set; }

    [JsonIgnore] public string SolutionNameAndExt => SolutionName + ".sln";
    [JsonIgnore] public string ProjectCopyNameAndExt => ProjectCopyName + ".csproj";
    [JsonIgnore] public List<string> DatabaseOriginalPrefix { get; set; }
    [JsonIgnore] public List<string> DatabasePrefix { get; set; }
    [JsonIgnore] public string ProjectQualifierGeneralCommands { get; set; } = "_";
    [JsonIgnore] public string ProjectDBQualifierGeneralCommands { get; set; } = "DB";

    public InputConfig InputConfig { get; set; } = new InputConfig();
}

public class InputConfig
{
    public int AnalisysBlock { get; set; }
    public string AnalisysProject { get; set; }
    public bool GenerateSingleProject { get; set; }
    public bool OnlySprint { get; set; }
    public bool OnlyTested { get; set; }
    public bool OnlyTestedDb { get; set; }
    public bool OnlyDeactivated { get; set; }
    public bool? SprintAndConvert { get; set; }

    public List<InputConfigModules> Modules { get; set; } = new List<InputConfigModules>();
    [JsonIgnore] public List<InputConfigModules> ListModuleConsider { get; set; }
    public List<string> Sprint { get; set; } = new List<string>();

    public void ConsiderModuleLoad()
    {
        var considerList = new List<InputConfigModules>();
        var justOnlyMe = Modules.Any(x => x.Files.Any(x => x.OnlyMe == true));

        var modCopy = new List<InputConfigModules>(Modules);
        var allAnalisys = FileResolverHelper.Conf.InputConfig.AnalisysBlock;

        for (var i = 0; i < modCopy.Count; i++)
        {
            var item = modCopy[i];
            var modAdd = new InputConfigModules();
            modAdd.Name = item.Name;
            modAdd.LaunchSettings = item.LaunchSettings;

            if (justOnlyMe)
                modAdd.Files = item.Files.Where(x => x.OnlyMe == true).ToList();
            else if (OnlyTested)
                modAdd.Files = item.Files.Where(x => x.Tested == true).ToList();
            else if (OnlyDeactivated)
                modAdd.Files = item.Files.Where(x => x.Deactivated == true).ToList();
            else if (OnlyTestedDb)
                modAdd.Files = item.Files.Where(x => x.TestedDb == true).ToList();
            else
                modAdd.Files = item.Files.Where(x => x.Convert || OnlySprint).ToList();

            if (!string.IsNullOrEmpty(AnalisysProject))
            {
                if (modAdd?.Name?.Equals(AnalisysProject, StringComparison.InvariantCultureIgnoreCase) != true)
                    continue;
            }

            if (OnlySprint && Sprint.Count > 0)
            {
                modAdd.Files = modAdd.Files.Where(x => Sprint.Any(s => Path.GetFileNameWithoutExtension(s).ToUpper() == Path.GetFileNameWithoutExtension(x.Name).ToUpper()) && (SprintAndConvert == null || (x.Convert == SprintAndConvert))).ToList();
            }

            if (AnalisysBlock > 0)
            {
                if (allAnalisys <= 0) continue;

                modAdd.Files = modAdd.Files.Take(allAnalisys).ToList();
                allAnalisys -= modAdd.Files.Count;
            }

            if (modAdd.Files.Any())
                considerList.Add(modAdd);
        }

        ListModuleConsider = considerList;
    }
}

public class InputConfigModules
{
    public string? Name { get; set; }
    public LaunchSettings? LaunchSettings { get; set; }
    public List<InputConfigModulesFiles> Files { get; set; } = new List<InputConfigModulesFiles>();
}

public class LaunchSettings
{
    public string? ApplicationUrl { get; set; }
}

public class InputConfigModulesFiles
{
    public bool? TestedDb { get; set; }
    public bool? Deactivated { get; set; }
    public bool? Tested { get; set; }
    public bool Convert { get; set; }
    public string? Name { get; set; }
    public string? Error { get; set; }
    public bool? OnlyMe { get; set; }

    public bool? ReadBuildMark { get; set; }
}