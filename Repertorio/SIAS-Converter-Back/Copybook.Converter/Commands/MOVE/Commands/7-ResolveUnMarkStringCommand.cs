using CobolLanguageConverter.Converter.Commands.MOVE;
using CobolLanguageConverter.Converter.DIVISION;
using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.Presentation;
using FileResolver.Helper;
using Microsoft.Extensions.FileSystemGlobbing;
using System.Linq;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class ResolveUnMarkStringCommand : IMoveCommand
    {
        public int Order { get; set; } = 7;
        public CurrentLineType? CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public string Execute(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            ret = ResolveUnMarkString(ret, ref markedList);

            return ret;
        }

        string ResolveUnMarkString(string line, ref Dictionary<string, string> markedList)
        {
            ValidationProcess(line);

            var isHigValues = Regex.IsMatch(line, @$"HIGH-VALUES\s+{H.CommaMarkRegex}");
            isHigValues = isHigValues || Regex.IsMatch(line, @$"HIGH-VALUE\s+{H.CommaMarkRegex}");

            var ret = line;
            var beforeCounter = ret.Split(H.CommaMark)[0].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Length;
            var qf = FileResolverHelper.Conf.ProjectQualifierGeneralCommands;

            var isInterpolation = markedList.Values.Any(x => x.Contains("'")) && beforeCounter > 1;
            ret = H.ToUnMarkedString(ret, markedList, isInterpolation);
            var splited = ret.Split(H.CommaMark, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            var isAll = Regex.IsMatch(splited[0].Trim(), @"^ALL\s+");

            //essas substituições são para, evitar aspas duplas dentro da string, e substituir alguns bug's de escrita
            var beforeValue = Regex.Replace(splited[0].Trim(), @"^((ALL\s+)*')", "I## ");
            beforeValue = Regex.Replace(beforeValue, @"'$", " F##");
            beforeValue = Regex.Replace(beforeValue, @"""", "\\\"");
            beforeValue = Regex.Replace(beforeValue, @"I## ", (isAll ? "ALL " : "") + "\"");
            beforeValue = Regex.Replace(beforeValue, @" F##", "\"");
            beforeValue = Regex.Replace(beforeValue, @"\\\\\\", "'");

            if (Regex.IsMatch(beforeValue, @"_.CurrentDate\(\\"""))
            {
                if (beforeValue.Contains("\\\""))
                    beforeValue = beforeValue.Replace("\\\"", "\"");
            }

            string retMultMov = string.Empty;
            for (int i = splited.Length - 1; i > 0; i--)
            {

                var afterValue = splited[i].Replace("}", "").Replace("{", "");
                //essas substituições são para, evitar aspas duplas dentro da string, e substituir alguns bug's de escrita

                if (isHigValues)
                {
                    ret = "";
                    foreach (var item in splited.Skip(1))
                    {
                        ret += $"\n{item}.IsHighValues = true;";
                    }

                    return ret;
                }

                var splVal = beforeValue.Replace("\" \"", "\"|_|\"")?.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (isInterpolation)
                {
                    if (splVal?.FirstOrDefault()?.Trim() == "ALL")
                        ret = $"{qf}.MoveAll({splVal?.Skip(1).FirstOrDefault().Replace("|_|", " ")}, {afterValue});";
                    else
                        ret = $"$\"{beforeValue.Replace(@"""", "")}\"\n.Move({afterValue});";
                }
                else
                {
                    if (splVal?.FirstOrDefault()?.Trim() == "ALL")
                        ret = $"{qf}.MoveAll(\"{splVal?.Skip(1).FirstOrDefault()}\", {afterValue});";
                    else if (splVal?.FirstOrDefault()?.Trim() == "CORR")
                        ret = $"{qf}.MoveCorr({splVal?.LastOrDefault()}, {afterValue});";
                    else
                    {
                        if (i > 1)
                            retMultMov = retMultMov + $"{qf}.Move({beforeValue}, {afterValue});" + "\r\n";
                        else
                            ret = retMultMov + $"{qf}.Move({beforeValue}, {afterValue});";
                    }
                }

                if (ret.Contains("_MoveAtPosition_"))
                    ret = ret.Replace("_MoveAtPosition_", "").Replace(".Move(", ".MoveAtPosition(");

            }

            var isRedefine = false;
            var isParentRedefine = false;
            string resultado = "";
            var match = Regex.Match(ret, @"(,\s).*", RegexOptions.IgnoreCase);

            //metodo feito para burlar redefines de moves sequenciais
            if (match.Success)
            {
                var matches = Regex.Matches(match.Value, @"(?<=\.)\w+", RegexOptions.IgnoreCase);

                if (matches.Count > 0)
                    if (!matches[0].Value.Equals("SQLERRD"))
                    {
                        isRedefine = H.GetReferenceProperty(matches[0].Value, Result, true).IsRedefine;
                        var parent = H.GetReferenceProperty(matches[0].Value, Result, true).PropertyParent;
                        if (parent != "DB")
                        {
                            isParentRedefine = H.GetReferenceProperty(parent!, Result, true).IsRedefine;
                        }
                    }

                if (isRedefine || isParentRedefine)
                {
                    int startArgs = ret.IndexOf('(') + 1;
                    int endArgs = ret.LastIndexOf(')');
                    string argumentos = ret.Substring(startArgs, endArgs - startArgs);

                    var substringsExtraidas = new List<string>();
                    string patternSubstring = @"Substring\s*\([^()]*\)";
                    string argumentosMascarado = Regex.Replace(argumentos, patternSubstring, match =>
                    {
                        substringsExtraidas.Add(match.Value);
                        return $"__SUBSTRING_{substringsExtraidas.Count - 1}__";
                    });

                    var argumentosSeparados = Regex.Split(argumentosMascarado, @",(?![^""]*"")");

                    for (int i = 0; i < argumentosSeparados.Length; i++)
                    {
                        foreach (var (valor, index) in substringsExtraidas.Select((v, j) => (v, j)))
                        {
                            argumentosSeparados[i] = argumentosSeparados[i].Replace($"__SUBSTRING_{index}__", valor);
                        }

                        argumentosSeparados[i] = argumentosSeparados[i].Trim();
                    }

                    string primeiroArgumento = argumentosSeparados[0];

                    if (argumentosSeparados.Length > 2 && !ret.Contains("_.MoveAtPosition"))
                    {
                        var resultadoBuilder = new System.Text.StringBuilder();

                        for (int i = 1; i < argumentosSeparados.Length; i++)
                        {
                            string parametro = argumentosSeparados[i];
                            resultadoBuilder.AppendLine($"_.Move({primeiroArgumento}, {parametro});");
                        }

                        resultado = resultadoBuilder.ToString();
                        return resultado;
                    }
                }
            }
            return ret;
        }

        private void ValidationProcess(string line)
        {
            var splited = line.Split(H.CommaMark, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            if (splited.Length < 2)
            {
            }
            foreach (var item in splited[1].Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
            {
                if (!H.HasStringMark(item)) throw new Exception($"Algo de errado no Move, seu conteudo não foi convertido Res: {line}");
            }
        }
    }
}
