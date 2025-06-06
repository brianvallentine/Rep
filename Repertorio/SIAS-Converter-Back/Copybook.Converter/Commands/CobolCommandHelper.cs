using CobolLanguageConverter.Converter.Commands.IF;
using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using FileResolver.Helper;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace CobolLanguageConverter.Converter.Commands
{
    public class CobolCommandHelper
    {
        public static string CommaMark = "{||}";
        public static string CommaMarkRegex => string.Join('\\', CommaMark.ToCharArray());
        public static string MarkRegex => @"\|\{\d+\|\}";

        public static bool TryCurrentDateTransform(string line, bool insideString, out string newLine)
        {
            newLine = line;
            if (!newLine.Contains("CURRENT-DATE") || newLine.Contains("-CURRENT-DATE")) return false;

            var ql = FileResolverHelper.Conf.ProjectQualifierGeneralCommands;

            var matches = Regex.Matches(newLine, @"(FUNCTION)*\s*CURRENT-DATE([\s]*\((?<initial>[\s]*\d+[\s]*):(?<final>[\s]*\d+[\s]*)\))*");

            var referrences = new Dictionary<string, string>();

            if (!insideString)
                referrences = new Dictionary<string, string>
                {
                    { "7:2",  @$"{ql}.CurrentDate(""dd"")"},
                    { "5:2",  @$"{ql}.CurrentDate(""MM"")"},
                    { "1:4",  @$"{ql}.CurrentDate(""yyyy"")"},
                    { "9:2",  @$"{ql}.CurrentDate(""HH"")"},
                    { "11:2", @$"{ql}.CurrentDate(""mm"")"} ,
                    { "13:2", @$"{ql}.CurrentDate(""ss"")"},
                    { "15:2", @$"{ql}.CurrentDate(""ff"")"},
                };
            else
                referrences = new Dictionary<string, string>
                {
                    { "7:2",  @$"{ql}.CurrentDateAsDate():dd"},
                    { "5:2",  @$"{ql}.CurrentDateAsDate():MM"},
                    { "1:4",  @$"{ql}.CurrentDateAsDate():yyyy"},
                    { "9:2",  @$"{ql}.CurrentDateAsDate():HH"},
                    { "11:2", @$"{ql}.CurrentDateAsDate():mm"} ,
                    { "13:2", @$"{ql}.CurrentDateAsDate():ss"},
                    { "15:2", @$"{ql}.CurrentDateAsDate():ff"},
                };

            if (matches.Count() > 0)
            {
                foreach (Match match in matches)
                {
                    var fullReplacement = match.Groups[0].Value;
                    var initial = int.TryParse(match.Groups["initial"]?.Value, out var pIni) ? pIni : -1;
                    var final = int.TryParse(match.Groups["final"]?.Value, out var pFim) ? pFim : -1;

                    var pattern = $"{initial}:{final}";
                    var patternItem = referrences.FirstOrDefault(x => x.Key == pattern).Value;

                    if (string.IsNullOrEmpty(patternItem))
                    {
                        var param = $"{(initial == -1 ? "" : $"{initial - 1},")}{final}";
                        if (initial == -1 && final == -1)
                            param = $"";

                        patternItem = @$"{ql}.CurrentDate({param})";
                    }

                    newLine = newLine.Replace(fullReplacement, patternItem);
                }
            }

            return newLine != line;
        }

        public static string GetReferenceName(string name, ResultSet Result)
        {
            return GetReferenceProperty(name, Result)?.PropertyName;
        }

        /// <summary>
        /// este método recebe como parametro um KEY do Result.ProcedureReference que é o nome do método
        /// </summary>
        /// <param name="methodName">Result.ProcedureReference KEY que é o nome do método</param>
        /// <returns>retorna true se o método deve ser ignorado</returns>
        public static bool IsIgnoredMethod(CurrentMethodType method, ResultSet Result)
        {
            var i = Result.ProcedureReference.Keys.ToList().IndexOf(method);
            var item = Result.ProcedureReference.ElementAt(i);
            var firstLine = item.Value?.FirstOrDefault()?.Line;
            var exitEjectTest = false;

            if (firstLine != null)
            {
                exitEjectTest = Regex.IsMatch(firstLine?.Trim(), @"^(EXIT|EJECT)");
                exitEjectTest = firstLine?.Contains("Removido na conversão") == true || exitEjectTest;
            }

            return
                //este return define se o método deve ser ignorado ou não, as condições são:
                //se o método for vazio OU
                item.Value?.Count == 0 ||
                (
                    //tiver apenas 1 linha E
                    item.Value?.Count == 1 &&
                    //a linha for EXIT ou EJECT
                    exitEjectTest
                );
        }

        public static StringBuilder GetIfResponseForLine(string line, int lineNumber, ResultSet Result, bool putIfOnResult = false)
        {
            var res = new StringBuilder();
            Result.IfControl.Add("NOT_INSIDE_IF");

            if (!putIfOnResult)
                Result.IfControl.Add("DONT_PUT_IF");

            //adicionando comando de IF
            var ifComm = new IfCommand();
            ifComm.Result = Result;
            ifComm.CurrentLine = new CurrentLineType($"IF {line}", lineNumber);
            var exec = ifComm.Execute(ifComm.CurrentLine.Line);
            res = exec.Output;
            //output.AppendLine(exec.Output.ToString());

            if (!putIfOnResult)
            {
                Result.IfControl.Remove("DONT_PUT_IF");
                res = new StringBuilder(exec.Output.ToString().Trim());
            }

            Result.IfControl.Remove("NOT_INSIDE_IF");

            return res;
        }

        public static ReferenceModel GetReferenceProperty(string name, ResultSet Result, bool verifyNamedReference = false)
        {
            var isSQLERRD = Regex.IsMatch(name, @"SQLERRD\[\d+\]");
            if (isSQLERRD) name = name.Trim().Replace("[", "(").Replace("]", ")");

            var splitedVar = name?.ToUpper().Split(' ')?.ToList();
            var searchName = splitedVar?.FirstOrDefault() ?? "";
            var isOfSearch = name?.Contains(" OF ") == true;

            //se não houver o OF e houver espaços em branco, não considerar a busca, pois é "lixo"
            if (!isOfSearch && splitedVar?.Count > 1) return null;

            var ofSearch = isOfSearch ? splitedVar?.Skip(splitedVar.IndexOf("OF") + 1).FirstOrDefault().Replace("-", "_") : "";

            if (string.IsNullOrEmpty(searchName) || int.TryParse(searchName, out var pName)) return null;

            searchName = searchName
                    .Trim()
                    .Replace(":", "")
                    .Replace(",", "")
                    .Replace("-", "_")
                    .Replace("!", "")
                    .Replace(".IsEmpty()", "")
                    .Replace("()", "")
                    .TrimEnd('.')
                    ;

            var reference = string.IsNullOrEmpty(ofSearch) ? Result.ALLReference.FirstOrDefault(x => x.Key.Equals(searchName, StringComparison.OrdinalIgnoreCase)).Value : null;
            if (reference == null)
                reference = Result.ALLReference.FirstOrDefault(x => (x.Key.Contains($".{searchName}", StringComparison.OrdinalIgnoreCase) || x.Key.Equals($"{searchName}", StringComparison.OrdinalIgnoreCase)) && (string.IsNullOrEmpty(ofSearch) || x.Value.PropertyParent.Equals($"{ofSearch}", StringComparison.OrdinalIgnoreCase))).Value;

            //no caso de ofSearch, procurar primeiro por keys compostas A.B.C
            //tentativa de obter o nome da variavel pelo nome da classe
            if (reference == null && isOfSearch)
                reference = Result.ALLReference.FirstOrDefault(x => x.Key.Contains($".{searchName}", StringComparison.OrdinalIgnoreCase) && x.Key.Contains($"{ofSearch}", StringComparison.OrdinalIgnoreCase)).Value;

            //não contendo key composta, procurar por nome simples e Property Name composta 
            //tentativa de obter o nome da variavel pelo nome da key
            if (reference == null && isOfSearch)
                reference = Result.ALLReference.FirstOrDefault(x => x.Key.Equals($"{searchName}", StringComparison.OrdinalIgnoreCase) && x.Value.PropertyName.Contains($"{ofSearch}", StringComparison.OrdinalIgnoreCase)).Value;

            //ultima tentativa irá fazer um search na property name, essa pode encontrar "qualquer coisa" cuidado
            //tentativa de obter o nome da variavel pelo nome da variavel
            if (reference == null && isOfSearch && verifyNamedReference)
                reference = Result.ALLReference.FirstOrDefault(x => x.Value.PropertyName.Contains($".{searchName}", StringComparison.OrdinalIgnoreCase) && x.Value.PropertyName.Contains($"{ofSearch}", StringComparison.OrdinalIgnoreCase)).Value;

            return reference;
        }

        public static ReferenceModel GetReferencePropertyByClass(string @class, ResultSet Result)
        {
            @class = @class.Trim().Replace("-", "_");
            var reference = Result.ALLReference.FirstOrDefault(x => x.Value.PropertyType.Equals(@class, StringComparison.OrdinalIgnoreCase)).Value;
            return reference;
        }

        public static bool TryChangeRelativePositionTransform(string line, out string newLine, ResultSet Result)
        {
            newLine = line;

            if (!line.Contains("(") || !line.Contains(")") || !line.Contains(":")) return false;

            //var rex = Regex.Match(line, @"(?<variable>[\S*|^\(]?)*\(?(?<initial>\d+)?:(?<final>\d+)");
            var rex = Regex.Match(line, @"^(?<varname>(.*?))\((?<initial>(.*?))\:(?<length>(.*?))\)");
            var varname = rex.Groups["varname"].Value;
            var initial = rex.Groups["initial"].Value;
            var length = rex.Groups["length"].Value;
            var refferName = GetReferenceName(varname, Result);

            if (!string.IsNullOrEmpty(refferName))
                newLine = newLine.Replace($"{varname}({initial}:{length})", $"{refferName}.Substring({int.Parse(initial) - 1},{length})");

            return true;
        }

        /// <summary>
        /// método verifica se STRING tem linhas úteis ou ja foi completamente convertida
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static bool HasUtilLine(string line)
        {
            var splitedLine = line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var utilLines = new List<string>();

            foreach (var item in splitedLine)
            {
                if (!HasStringMark(item) && CommaMark != item)
                    utilLines.Add(item);
            }

            return utilLines.Any();
        }

        public static bool TryWhenCompileTransform(string line, out string newLine)
        {
            newLine = line;
            if (!line.Contains("WHEN-COMPILED")) return false;

            var ql = FileResolverHelper.Conf.ProjectQualifierGeneralCommands;
            //if (!line.Contains("(") || !line.Contains(")") || !line.Contains(":")) return false;

            var matches = Regex.Matches(line, @"(FUNCTION)*\s*WHEN-COMPILED([\s]*\((?<initial>[\s]*\d+[\s]*):(?<final>[\s]*\d+[\s]*)\))*");
            //var rex = Regex.Match(line, @"^(WHEN-COMPILED)?\((?<initial>\d?)\:(?<length>\d?)\)");
            if (matches.Count() > 0)
            {
                foreach (Match match in matches)
                {
                    var fullReplacement = match.Groups[0].Value;
                    var initial = int.TryParse(match.Groups["initial"].Value, out var pIni) ? pIni : 0;
                    var final = int.TryParse(match.Groups["final"].Value, out var pFim) ? pFim : 0;

                    var pattern = $"{initial},{final}";
                    if (initial == 0 && final == 0) pattern = "";

                    var newData = $"{FileResolverHelper.Conf.ProjectQualifierGeneralCommands}.WhenCompiled({pattern})";
                    if (HasStringMark(newLine))
                        newData = $"{{{newData}}}";

                    newLine = newLine.Replace(fullReplacement, newData);
                }
            }

            return newLine != line;
        }

        internal static string ToMarkedString(string item, out Dictionary<string, string> markedList)
        {
            //cenário em que os valore default vem com aspas duplas tratar para aspas simples
            //item = item.Replace("\"", "'");
            //obter tudo dentro que é string 
            var ret = item;

            //bool considerMarkedSymbols = Regex.IsMatch(item, @"\|\|") || Regex.IsMatch(item, @"&&") || Regex.IsMatch(item, @"\'\s*\'");
            //var matches = !considerMarkedSymbols ? Regex.Matches(item, @"(?<strings>['""][^""]*['""])") : Regex.Matches(item, @"(?<strings>['].*?['])");
            
            var matches = Regex.Matches(item, @"(?<strings>['].*?['])");
            //var matches = Regex.Matches(item, @"(?<strings>['""""]([^'""""]|['""""][^'""""]*['""])*['""""])");

            //expressão regular para atender os 2 cenários de aspas simples e duplas para valor default do PIC
            //var matches = Regex.Matches(item, @"(?<strings>['""][^""]*['""])");

            markedList = new Dictionary<string, string>();
            if (matches.Count > 0)
            {
                for (int i = 0; i < matches.Count; i++)
                {
                    var match = matches[i];
                    var marker = $"|{{{i}|}}";
                    var value = match.Groups["strings"].Value;

                    value = value.Replace("\"", "'");
                    markedList.Add(marker, value);
                    ret = ret.Replace(value, $" {marker} ");
                }
            }

            return ret;
        }

        internal static string Mark(string toMark, ref Dictionary<string, string> markedList)
        {
            var ret = "|{0|}";
            if (markedList.Any())
            {
                var lastMarker = markedList.Last();
                var match = Regex.Match(lastMarker.Key, @"\|\{(?<index>\d+)\|\}");
                var currentIndex = int.Parse(match.Groups["index"].Value) + 1;

                ret = $"|{{{currentIndex}|}}";
            }

            markedList.Add(ret, toMark);
            return ret;
        }

        internal static bool HasStringMark(string line)
        {
            return line?.Contains("|{") == true || line == CommaMark;
        }

        public static List<string> OfNormalizeFromSpaceSplitedList(List<string> origin)
        {
            var ret = new List<string>();
            if (origin == null)
                return ret;

            var stringJoin = "";

            foreach (var item in origin)
            {
                if (item.ToUpper() == "OF")
                {
                    stringJoin += item;
                    continue;
                }

                if (stringJoin.ToUpper() == "OF")
                {
                    stringJoin += " " + item;
                    ret[ret.Count - 1] += " " + stringJoin;
                    stringJoin = "";
                    continue;
                }

                ret.Add(item);
            }

            return ret;
        }

        internal static string ToUnMarkedString(string line, Dictionary<string, string> markedList, bool considerInterpolation = false)
        {
            //obter tudo dentro que é string 
            var ret = line;
            while (HasStringMark(ret))
            {
                //if de contenção para evitar loop infinito
                if (markedList?.Any(x => ret.Contains(x.Key)) != true)
                    break;

                foreach (var item in markedList)
                {
                    var value = item.Value;

                    if (considerInterpolation)
                        if (!item.Value.Contains("'"))
                            value = $"{{{value}}}";
                        else
                            value = value.Replace("\\", "\\\\");

                    //esta condição foi colocada para evitar futuros loops infinitos
                    if (value.Contains(item.Key))
                        throw new Exception("ToUnMarkedString - Erro ao converter string");

                    ret = ret.Replace(item.Key, value);
                }
            }

            //essa marca significa que a string contém ' que é marcação de string literal
            //if (ret.Contains("|{0|}"))
            //{
            //    var splited = ret.Split(new string[] { ",", " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            //    var splitedFrom = splited[0].Split(new string[] { " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            //    var stringResolver = @"$""";

            //    var index = 0;
            //    foreach (var item in splitedFrom)
            //    {
            //        if (item.Contains("|{"))
            //        {
            //            stringResolver += markedList.ElementAt(index).Value.Replace("'", "");
            //            index++;
            //        }
            //        else
            //            stringResolver += $@"{{{item}}}";
            //    }
            //    stringResolver += @"""";

            //    ret = $"{stringResolver}, {splited[1]}";
            //}

            return ret;
        }
    }
}
