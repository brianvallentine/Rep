using CobolLanguageConverter.Converter.Commands.MOVE;
using CobolLanguageConverter.Converter.DIVISION;
using IA_ConverterCommons;
using System.Text.RegularExpressions;
using Copybook.Converter;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class StringSubstringConvertMarkCommand : IMoveCommand
    {
        public int Order { get; set; } = 6;
        public CurrentLineType? CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public string Execute(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            ret = StringSubstringConvertMark(ret, ref markedList);

            return ret;
        }

        string StringSubstringConvertMark(string line, ref Dictionary<string, string> markedList)
        {
            var ret = H.ToUnMarkedString(line, markedList);

            //resolucao para substring complexa abaixo
            //"WS-FONTE-NUM-DATA(VARIAVEIS_APOIO.WS_INI+1:WS-LGTH-NUM - VARIAVEIS_APOIO.WS_INI) {||} WS_FONTE_NUM.WS_FONTE_NUM_DATA"

            var backupRet = ret;
            Match match = Regex.Match(backupRet, @":([^\s\)]+)");
            if (match.Success)
            {
                string snippet = match.Groups[1].Value;
                string originSnippet = match.Value;

                string[] parts = snippet.Split('-');
                for (int i = parts.Length - 1; i > 0; i--)
                {
                    string left = string.Join("-", parts, 0, i);
                    string right = string.Join("-", parts, i, parts.Length - i);

                    if (right.Contains(".") && !left.Equals("") && !int.TryParse(left, out int numero))
                    {
                        var reference = H.GetReferenceProperty(left, Result).PropertyName;
                        // Construir novo trecho com espaço e sinal de subtração
                        string newSnippet = $":{reference} - {right}";

                        // Substituir no texto original
                        backupRet = backupRet.Replace(originSnippet, newSnippet);
                        ret = backupRet;
                        break;
                    }
                }
            }
            //ret = ret.Contains('\'') ? H.ToUnMarkedString(line, markedList, true) : ret;

            var afterMark = false;
            var passCommaMarkCounter = 0;

            //MOVE SISTEMAS-DATA-MOV-ABERTO (9:2) TO LC11-DATADIA(1:2)
            var rxsNumbers = Regex.Matches(ret, @"(?<varName>(\S+\s+OF\s+)*\S*)\s*\(\s*(?<Initial>\d+|[-\._A-z0-9]+(\s*(\+|-)\s*(\d+|[-\._A-z0-9]+))*)\s*:\s*(?<final>\d+|[-\._A-z0-9]+(\s*(\+|-)\s*(\d+|[-\._A-z0-9]+))*)\s*\)");

            foreach (Match rxNumbers in rxsNumbers.Where(x => x.Success))
            {
                afterMark = ret.IndexOf(rxNumbers.Value) > ret.IndexOf(H.CommaMark);
                if (afterMark)
                    passCommaMarkCounter++;

                var outterVariable = rxNumbers.Groups["varName"].Value.Split(".").LastOrDefault();//item.Substring(0, item.IndexOf("("));
                var outterProperty = H.GetReferenceProperty(outterVariable, Result);
                var varProcess = outterProperty?.PropertyName.Split(".");
                if (varProcess?.Any() != true) return line;

                var inNumberFirst = rxNumbers.Groups["Initial"].Value;
                var inNumberLast = rxNumbers.Groups["final"].Value;

                Func<ReferenceModel, string, string, string> SubStringCom = (refferPropValue, inNumberFirst, inNumberLast) =>
                {
                    var varToPutFirst = H.GetReferenceName(inNumberFirst, Result);
                    var varToPutLast = H.GetReferenceName(inNumberLast, Result);

                    if (varToPutFirst == null)
                    {
                        if (int.TryParse(inNumberFirst, out var pInNumberFirst) && varToPutFirst == null)
                            varToPutFirst = pInNumberFirst.ToString();
                        else
                            varToPutFirst = inNumberFirst;
                    }

                    if (varToPutLast == null)
                    {
                        if (int.TryParse(inNumberLast, out var pInNumberLast) && varToPutLast == null)
                            varToPutLast = pInNumberLast.ToString();
                        else
                            varToPutLast = inNumberLast;
                    }

                    if (afterMark)
                        //marked = H.Mark($"_MoveAtPosition_{(passCommaMarkCounter > 1 ? "," : "")}{refferPropValue},{varToPutFirst},{pInNumberLast}", ref markedList);
                        return $"_MoveAtPosition_{(passCommaMarkCounter > 1 ? "," : "")}{refferPropValue.PropertyName},{varToPutFirst},{varToPutLast}";
                    else
                        return $"{(passCommaMarkCounter > 1 ? "," : "")}{refferPropValue.PropertyName}.Substring({varToPutFirst},{varToPutLast})";
                    //return $"{(passCommaMarkCounter > 1 ? "," : "")}{refferPropValue}{(outterMarked ? ".GetMoveValues()" : "")}.Substring({varToPutFirst},{varToPutLast})";
                };

                //if (outterMarked)
                //{
                //    var toMark = SubStringCom(outterProperty, inNumberFirst, inNumberLast);
                //    var marked = H.Mark(toMark, ref markedList);
                //    ret = ret.Replace(rxNumbers.Value, marked);
                //    continue;
                //}

                for (int i = varProcess.Length; i > 0; i--)
                {
                    var innerVar = varProcess.Take(i).Last();
                    var refferProp = H.GetReferenceProperty(innerVar, Result);
                    if (refferProp.PropertyIsClass || refferProp?.PropertyType == typeof(StringBasis).Name.ToString() || refferProp?.PropertyType == typeof(IntBasis).Name.ToString())
                    {
                        var toMark = SubStringCom(refferProp, inNumberFirst, inNumberLast);
                        var marked = H.Mark(toMark, ref markedList);
                        ret = ret.Replace(rxNumbers.Value, marked);
                        break;
                    }
                }

            }

            foreach (var item in markedList)
                ret = ret.Replace(item.Value, item.Key);

            return ret;
        }
    }
}
