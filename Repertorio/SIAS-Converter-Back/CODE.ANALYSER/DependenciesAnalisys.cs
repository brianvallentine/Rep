using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CODE.ANALYSER
{
    public class DependenciesAnalisys
    {
        public static Dictionary<string, List<ExcelDependenciesGeneratorMetaData>> AllProgrsDic = new Dictionary<string, List<ExcelDependenciesGeneratorMetaData>>();

        public static void CallerAnalisysRun(string sourceFolder)
        {
            CallerFindProccess(sourceFolder);

            ExcelDependenciesGenerator.GenerateFromMetaData(AllProgrsDic);
        }

        static void CallerFindProccess(string sourceFolder)
        {
            var allFolders = Directory.GetDirectories(sourceFolder);
            var allFiles = Directory.GetFiles(sourceFolder);

            foreach (var folder in allFolders)
                CallerFindProccess(folder);

            foreach (var file in allFiles)
                try { FindCallerInFile(file); } catch (Exception) { }
        }

        private static void FindCallerInFile(string file)
        {
            var fileName = Path.GetFileName(file).ToLower();
            var lstCallers = new List<ExcelDependenciesGeneratorMetaData>();
            var lstAlreadyPassedLines = new List<string>();
            var lineNumber = 0;

            foreach (var line in File.ReadAllLines(file))
            {
                lineNumber++;

                if (IsValidLine(line, out var lineOut))
                {
                    if (IsCallLine(lstAlreadyPassedLines, lineOut.Trim(), out var calledProgram))
                        lstCallers.Add(new ExcelDependenciesGeneratorMetaData(lineNumber, calledProgram));

                    lstAlreadyPassedLines.Add(lineOut);
                }
            }

            AllProgrsDic.Add(fileName, lstCallers);
        }

        static bool IsCallLine(List<string> lstAlreadyPassedLines, string line, out string calledProgram)
        {
            calledProgram = null;

            if (line.Trim().Contains(".")) return false;
            if (!Regex.IsMatch(line.Trim(), @"^CALL ")) return false;
            var regexCleanName = Regex.Match(line, @"^CALL\s+((?<name>[']\S+['])|((?<name>\S+)))");
            if (!regexCleanName.Success) return false;
            if (Regex.IsMatch(lstAlreadyPassedLines.Last(), @"EXEC\s+SQL")) return false;

            var name = regexCleanName.Groups["name"].Value;
            if (name.Contains("'") || name.Contains("\"")) //neste caso, é o nome direto do programa
            {
                calledProgram = name.Replace("'", "").Replace("\"", "");
                return true;
            }

            var varName = name;

            for (int i = lstAlreadyPassedLines.Count - 1; i >= 0; i--)
            {
                var passedLine = lstAlreadyPassedLines.ElementAtOrDefault(i);

                if (passedLine?.Contains(varName) != true) continue;
                if (Regex.IsMatch(passedLine, @$"MOVE\s+{varName}")) continue;

                //neste caso o nome está declarado direto na declaração da variavel, seria como uma constante
                var rexVariableCreation = Regex.Match(passedLine, @$"{varName}\s+PIC\s+X.+(?<progName>[']\S+['])");
                if (rexVariableCreation.Success)
                {
                    name = rexVariableCreation.Groups["progName"].Value;
                    calledProgram = name.Replace("'", "");
                    return true;
                }

                //neste caso o nome está declarado direto na declaração da variavel, seria como uma constante
                var rexVariableMove = Regex.Match(passedLine, @$"MOVE\s+(?<progName>[']\S+['])\s+TO\s+{varName}");
                if (rexVariableMove.Success)
                {
                    name = rexVariableMove.Groups["progName"].Value;
                    calledProgram = name.Replace("'", "");
                    return true;
                }

            }

            return true;
        }

        static bool IsValidLine(string line, out string lineOut)
        {
            lineOut = line;
            if (string.IsNullOrEmpty(line)) return false;
            if (line.Length < 7) return false;
            if (line[6] == '*') return false;
            if (line[6] == 'D') return false;
            if (string.IsNullOrEmpty(line.Substring(7).Trim())) return false;

            lineOut = line.Substring(7);
            return true;
        }

    }
}
