//var sourceFolder = "E:\\PROJETOS\\FOURSYS\\CVP Downsizing\\Fontes-SMART v3\\Fontes-SMART v3\\ARQUIVOSMAPEADOSv2";
//var sourceFolder = "E:\\PROJETOS\\Pessoal\\IA_REPO\\IA_Converter";
//var sourceFolder = "E:\\PROJETOS\\FOURSYS\\CVP Downsizing\\Fontes-SMART v3\\Fontes-SMART v3\\ARQUIVOSMAPEADOSv2";
//var sourceFolder = "E:\\PROJETOS\\FOURSYS\\CVP\\SIAS_Analise\\Cobol\\COB2P";
//var sourceFolder = "E:\\PROJETOS\\Pessoal\\IA_NEW_WORK\\IA_Converter\\Executor.Console\\InputFiles\\CONTAR";
//var sourceFolder = "C:\\Users\\danie\\Downloads\\Programas_20240315";

using CODE.ANALYSER;

var analiseType = AnalisysType.CALLER;
var sourceFolder = "E:\\PROJETOS\\FOURSYS\\CVP\\SIAS_NOVO\\COB2P";

switch (analiseType)
{
    case AnalisysType.LINER:
        LineAnalisys.LineAnalisysRun(sourceFolder);
        break;
    case AnalisysType.CALLER:
        DependenciesAnalisys.CallerAnalisysRun(sourceFolder);
        break;
    default:
        break;
}

//var excludeList = new List<string>
//{
//    "\\bin",
//    "\\debug",
//    "\\obj",
//    "\\Telas",
//    "\\ESF",
//    "\\.git",
//};

//var includeList = new List<string>
//{
//    //".cs",
//};

//ReadAndCountLines(sourceFolder);

//Console.Write($"\n\n----TOTAL GERAL---->: \nFiles: {allFilesCounter.ToString("N0")}\nLines: {allLinesCounter.ToString("N0")}\n\n");

//void ReadAndCountLines(string sourceFolder)
//{
//    var allFolders = Directory.GetDirectories(sourceFolder);
//    var allFiles = Directory.GetFiles(sourceFolder);

//    foreach (var folder in allFolders)
//        ReadAndCountLines(folder);

//    foreach (var file in allFiles)
//    {
//        if (includeList.Any() && !includeList.Contains(Path.GetExtension(file))) continue;
//        if (excludeList.Any(x => file.Contains(x))) continue;

//        try
//        {
//            var counter = 0;
//            var fileName = Path.GetFileName(file).ToLower();
//            if (mustConsiderUniqueFiles)
//            {
//                var mustBreak = false;
//                if (uniqueList.Contains(fileName))
//                    mustBreak = true;

//                uniqueList.Add(fileName);

//                if (mustBreak)
//                    break;
//            }

//            allFilesCounter++;

//            foreach (var line in File.ReadAllLines(file))
//            {
//                if (IsValidLine(line, mustConsiderCleanLines))
//                    counter++;
//            }

//            Console.Write($"----{file}---->: {counter}\n");
//            allLinesCounter += counter;
//        }
//        catch (Exception)
//        {
//        }
//    }
//}

//bool IsValidLine(string line, bool cleanResult = false)
//{
//    if (cleanResult)
//    {
//        if (string.IsNullOrEmpty(line)) return false;
//        if (line.Length < 7) return false;
//        if (line[6] == '*') return false;
//    }

//    return true;
//}
