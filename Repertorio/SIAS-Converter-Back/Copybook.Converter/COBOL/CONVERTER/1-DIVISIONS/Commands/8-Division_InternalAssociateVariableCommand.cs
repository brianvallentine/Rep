using CobolLanguageConverter.Converter.Commands.CSHARP;
using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using DocumentFormat.OpenXml.Vml;
using FileResolver;
using FileResolver.Helper;
using System.Text.RegularExpressions;

namespace CobolLanguageConverter.Converter.Commands.DIVISIONS
{
    public class Division_InternalAssociateVariableCommand : IDivisionCommand
    {
        public int Order { get; set; } = 8;
        public ResultSet Result { get; set; }

        public string Execute(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = InternalAssociateVariable(lines, ref divisionAndLines);
            return ret;
        }

        string InternalAssociateVariable(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = lines;
            var associateResultReference = new Dictionary<string, ReferenceModel>();
            var secLine = divisionAndLines.FirstOrDefault(x => Regex.IsMatch(x.Key.TrimEnd('.'), @"PROCEDURE\s+DIVISION", RegexOptions.None, TimeSpan.FromMilliseconds(500)));

            associateResultReference = Result.DclReference;

            for (int j = 0; j < secLine.Value.Count; j++)
            {
                var currentCopyLine = secLine.Value[j];
                var sqlRex = Regex.IsMatch(currentCopyLine.Line.Trim(), @"EXEC\s+SQL", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(200));
                if (!sqlRex)
                    continue;

                var idxTake = secLine.Value.Skip(j).TakeWhile(x => !x.Line.Trim().EndsWith(".") && !x.Line.Trim().EndsWith("END-EXEC")).Count();
                var sqlLines = string.Join("\n", secLine.Value.Skip(j).Take(idxTake + 1).Select(x => x.Line));

                var rex = Regex.Match(sqlLines, @"EXEC\s+SQL\s+ASSOCIATE\s+LOCATORS\s*\((?<locators>(:[-A-z0-9]+\s*)+)\s*\)\s*WITH\s+PROCEDURE\s+(?<procName>\S+\s*\.\s*\S+)\s+END-EXEC");
                if (!rex.Success) continue;

                var locators = rex.Groups["locators"].Value;
                var procName = rex.Groups["procName"].Value;

                foreach (var locator in locators.Split(":", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)) //{                
                    InternalAllocateVariable(lines, ref divisionAndLines, locator, procName);
            }

            return ret;
        }

        string InternalAllocateVariable(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines, string locator, string procName)
        {
            var ret = lines;
            var associateResultReference = new Dictionary<string, ReferenceModel>();
            var secLine = divisionAndLines.FirstOrDefault(x => Regex.IsMatch(x.Key.TrimEnd('.'), @"PROCEDURE\s+DIVISION", RegexOptions.None, TimeSpan.FromMilliseconds(500)));

            associateResultReference = Result.DclReference;

            for (int j = 0; j < secLine.Value.Count; j++)
            {
                var currentCopyLine = secLine.Value[j];
                var sqlRex = Regex.IsMatch(currentCopyLine.Line.Trim(), @"EXEC\s+SQL", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(200));
                if (!sqlRex)
                    continue;

                var idxTake = secLine.Value.Skip(j).TakeWhile(x => !x.Line.Trim().EndsWith(".") && !x.Line.Trim().EndsWith("END-EXEC")).Count();
                var sqlLines = string.Join("\n", secLine.Value.Skip(j).Take(idxTake + 1).Select(x => x.Line));

                //https://regex101.com/r/FzUEsG
                var rex = Regex.Match(sqlLines, $@"EXEC\s+SQL\s+ALLOCATE\s+(?<cursorName>\S+)\s+CURSOR\s+FOR\s+RESULT\s+SET\s+:{locator}\s+END-EXEC");
                if (!rex.Success) continue;

                var cursorName = rex.Groups["cursorName"].Value.Replace("-", "_");

                InternalFetchVariable(lines, ref divisionAndLines, locator, cursorName);
            }

            return ret;
        }

        string InternalFetchVariable(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines, string locator, string cursorName)
        {
            var ret = lines;
            var associateResultReference = new Dictionary<string, ReferenceModel>();
            var secLine = divisionAndLines.FirstOrDefault(x => Regex.IsMatch(x.Key.TrimEnd('.'), @"PROCEDURE\s+DIVISION", RegexOptions.None, TimeSpan.FromMilliseconds(500)));

            associateResultReference = Result.DclReference;

            for (int j = 0; j < secLine.Value.Count; j++)
            {
                var currentCopyLine = secLine.Value[j];
                var sqlRex = Regex.IsMatch(currentCopyLine.Line.Trim(), @"EXEC\s+SQL", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(200));
                if (!sqlRex)
                    continue;

                //https://regex101.com/r/CVxIY2
                var idxTake = secLine.Value.Skip(j).TakeWhile(x => !x.Line.Trim().EndsWith(".") && !x.Line.Trim().EndsWith("END-EXEC")).Count();
                var sqlLines = string.Join("\n", secLine.Value.Skip(j).Take(idxTake + 1).Select(x => x.Line));
                var rex = Regex.Match(sqlLines, @"(EXEC[\s]+SQL)?\s+(FETCH(\s+NEXT)*)+\s+(?<cursor>\S+)\s+INTO\s+(?<variables>\S+(\s+,)*\s+)+(END-EXEC)", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(300));
                if (!rex.Success) continue;

                var cursor = rex.Groups["cursor"].Value.Replace("-", "_");
                var variables = string.Join(" ", rex.Groups["variables"].Captures.Select(x => x.Value.Replace("\n", ""))).Replace(":", " ").Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                if (cursor != cursorName) continue;

                var cursorClassName = $"{Result.programName}_{cursorName}";
                Result.DclReference.Add(cursorName, new ReferenceModel($"{cursorName}", cursorClassName, true));

                var comm = new CSharp_ResolveSqlToFileCommand();
                comm.Result = Result;
                comm.GenerateSQLCopy(currentCopyLine, cursorName, "", false, string.Join(",", variables), new List<string>());

                foreach (var db2Class in comm.db2ClassNames)
                {
                    var generator = new FileGenerator();
                    generator.PushClassToDb2Folder(db2Class.Key, db2Class.Value, Result.programName);
                }
            }

            return ret;
        }
    }
}