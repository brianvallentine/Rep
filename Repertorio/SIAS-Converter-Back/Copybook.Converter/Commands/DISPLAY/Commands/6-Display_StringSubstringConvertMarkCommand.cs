using CobolLanguageConverter.Converter.Commands.IF;
using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using IA_ConverterCommons;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands.DISPLAY
{
    public class Display_StringSubstringConvertMarkCommand : IDisplayCommand
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
            var ret = line;
            var splited = ret.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var afterMark = false;

            foreach (var item in splited)
            {
                if (item == H.CommaMark)
                    afterMark = true;

                if (H.HasStringMark(item)) continue;

                var lstMath = new List<Match>();
                //old var rxNumbers = Regex.Match(item, @"\S*\((?<Initial>\d+)[:]*(?<final>\d+)*\)");
                var rxNumbers = Regex.Match(item, @"\S*\((?<Initial>[^:]+)[:]*(?<Final>[^)]+)*\)");
                if (rxNumbers.Success)
                {
                    var outterVariable = item.Substring(0, item.IndexOf("("));
                    var outterProperty = H.GetReferenceProperty(outterVariable, Result);
                    var varProcess = outterProperty?.PropertyName?.Split(".");
                    if (varProcess?.Any() != true) return line;

                    bool isNumberIni = int.TryParse(rxNumbers.Groups[1].Value, out int result);
                    bool isNumberFin = int.TryParse(rxNumbers.Groups[2].Value, out result);

                    ReferenceModel refferIni = null;
                    ReferenceModel refferFin = null;

                    if (!isNumberFin && isNumberIni)
                    {
                        refferIni = H.GetReferenceProperty(rxNumbers.Groups[1].Value, Result);
                        refferFin = H.GetReferenceProperty(rxNumbers.Groups[2].Value, Result);
                    }

                    for (int i = varProcess.Length; i > 0; i--)
                    {
                        var innerVar = varProcess.Take(i).Last();
                        var refferProp = H.GetReferenceProperty(innerVar, Result);
                        if (refferProp?.PropertyType == typeof(StringBasis).Name.ToString())
                        {
                            var inNumberFirst = rxNumbers.Groups["Initial"].Value;
                            var inNumberLast = rxNumbers.Groups["Final"].Value;
                            int.TryParse(inNumberFirst, out var pInNumberFirst);
                            int.TryParse(inNumberLast, out var pInNumberLast);

                            if (refferIni != null || refferFin != null)
                            {
                                var marca = "";
                                object inicio = refferIni != null ? refferIni.PropertyName : pInNumberFirst;
                                object fim = refferFin != null ? refferFin.PropertyName : pInNumberLast;

                                var marka = "";
                                if (afterMark)
                                    marka = H.Mark($"{refferProp.PropertyName},{inicio},{fim}", ref markedList);
                                else
                                    marka = H.Mark($"{refferProp.PropertyName}.Substring({inicio},{fim})", ref markedList);
                                ret = ret.Replace(item, marka);

                                break;
                            }
                            if (int.TryParse(inNumberFirst, out var validFirst) && int.TryParse(inNumberLast, out var validLast))
                            {
                                if (validFirst > 0 && validLast == 0)
                                {
                                    validLast = validFirst;
                                    validFirst = 0;
                                }

                                var marked = "";
                                if (afterMark)
                                    marked = H.Mark($"{refferProp.PropertyName},{validFirst},{validLast}", ref markedList);
                                else
                                    marked = H.Mark($"{refferProp.PropertyName}.Substring({validFirst},{validLast})", ref markedList);

                                ret = ret.Replace(item, marked);
                                break;
                            }
                        }
                    }
                }
            }
            return ret;
        }
    }
}
