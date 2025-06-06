using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using FileResolver.Helper;
using System.Text.RegularExpressions;

namespace CobolLanguageConverter.Converter.Commands.DIVISIONS
{
    public class Division_InternalCursorVariableCommand : IDivisionCommand
    {
        public int Order { get; set; } = 7;
        public ResultSet Result { get; set; }

        public string Execute(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = InternalCursorVariable(lines, ref divisionAndLines);
            return ret;
        }

        string InternalCursorVariable(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = lines;
            //var sections = new List<string>
            //{
            //    @"PROCEDURE(.*?)+DIVISION"        ,
            //};

            var currResultReference = new Dictionary<string, ReferenceModel>();
            //for (int i = 0; i < divisionAndLines.Count; i++)
            //{
            var secLine = divisionAndLines.FirstOrDefault(x => Regex.IsMatch(x.Key.TrimEnd('.'), @"PROCEDURE\s+DIVISION", RegexOptions.None, TimeSpan.FromMilliseconds(500)));
            //var secLine = divisionAndLines.ElementAt(i);
            //var matchItem = sections.FirstOrDefault(x => Regex.IsMatch(secLine.Key, x, RegexOptions.None, TimeSpan.FromMilliseconds(500)));
            //if (matchItem == null)
            //    continue;

            currResultReference = Result.DclReference;
            for (int j = 0; j < secLine.Value.Count; j++)
            //foreach (string currentCopyLine in secLine.Value)
            {
                var currentCopyLine = secLine.Value[j];
                var sqlRex = Regex.IsMatch(currentCopyLine.Line.Trim(), @"EXEC\s+SQL", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(200));
                if (!sqlRex)
                    continue;

                var idxTake = secLine.Value.Skip(j).TakeWhile(x => !x.Line.Trim().EndsWith(".") && !x.Line.Trim().EndsWith("END-EXEC")).Count();
                var sqlLines = string.Join("\n", secLine.Value.Skip(j).Take(idxTake + 1).Select(x => x.Line));

                var rex = Regex.Match(sqlLines, @"EXEC\s+SQL\s+DECLARE\s+(?<cursorName>\S+)\s+", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(200));
                if (!rex.Success)
                    continue;

                var cursorName = rex.Groups["cursorName"].Value.Replace("-", "_");
                if (!Result.ALLReference.ContainsKey(cursorName))
                    currResultReference.Add(cursorName, new ReferenceModel($"{cursorName}", $"{Result.programName}_{cursorName}", true));
                else
                {
                    //caso o nome do cursor for repetido, significa que temos que alterar para um nome unico a fim de não conflitar
                    var ind = 1;
                    var cursorNewName = $"C{ind:00}_{cursorName}";
                    while (Result.ALLReference.ContainsKey(cursorNewName))
                        cursorNewName = Regex.Replace(cursorNewName, @"C\d+_", $"C{++ind:00}_");

                    //for (int K = 0; K < divisionAndLines.Count; K++)
                    //{
                    var SECLINE = divisionAndLines.FirstOrDefault(x => Regex.IsMatch(x.Key, @"PROCEDURE(.*?)+DIVISION", RegexOptions.None, TimeSpan.FromMilliseconds(500)));
                    for (int R = 0; R < SECLINE.Value.Count; R++)
                    {
                        var CURRENTLINE = SECLINE.Value[R].Line;

                        var REX = Regex.Match(CURRENTLINE, @$"DECLARE\s+{cursorName}\s+CURSOR", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(200));
                        if (REX.Success)
                            SECLINE.Value[R].Line = Regex.Replace(CURRENTLINE, @$"DECLARE\s+{cursorName}\s+CURSOR", $"DECLARE {cursorNewName} CURSOR");

                        REX = Regex.Match(CURRENTLINE, @$"FETCH\s+{cursorName}\s+", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(200));
                        if (REX.Success)
                            SECLINE.Value[R].Line = Regex.Replace(CURRENTLINE, @$"FETCH\s+{cursorName}\s+", $"FETCH {cursorNewName} ");

                        REX = Regex.Match(CURRENTLINE, @$"CLOSE\s+{cursorName}\s+", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(200));
                        if (REX.Success)
                            SECLINE.Value[R].Line = Regex.Replace(CURRENTLINE, @$"CLOSE\s+{cursorName}\s+", $"CLOSE {cursorNewName} ");

                        REX = Regex.Match(CURRENTLINE, @$"OPEN\s+{cursorName}\s+", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(200));
                        if (REX.Success)
                            SECLINE.Value[R].Line = Regex.Replace(CURRENTLINE, @$"OPEN\s+{cursorName}\s+", $"OPEN {cursorNewName} ");
                    }
                    //}

                    cursorName = cursorNewName;
                    currResultReference.Add(cursorName, new ReferenceModel($"{cursorName}", $"{Result.programName}_{cursorName}", true));
                }

                if (Regex.IsMatch(sqlLines, @"WITH\s+RETURN\s+FOR"))
                    Result.CursorReturnName.Add(cursorName);

                if (Regex.IsMatch(sqlLines, @"WITH\s+RETURN\s+WITH\s+HOLD\s+FOR"))
                    Result.CursorReturnName.Add(cursorName);
            }
            //}
            return ret;
        }
    }
}