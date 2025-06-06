public enum AnalisysType
{
    LINER,
    CALLER
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
