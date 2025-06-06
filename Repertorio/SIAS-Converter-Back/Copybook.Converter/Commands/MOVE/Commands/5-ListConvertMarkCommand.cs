using System.Text;
using CobolLanguageConverter.Converter.Commands.MOVE;
using CobolLanguageConverter.Converter.DIVISION;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class ListConvertMarkCommand : IMoveCommand
    {
        public int Order { get; set; } = 5;
        public CurrentLineType? CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public string Execute(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            //caso não haja linha útil, então apenas não executamos os métodos abaixo
            if (!H.HasUtilLine(line)) return ret;

            ret = ListConvertMarkMatrix(ret, ref markedList);
            //código antigo
            ret = ListConvertMarkVariables(ret, ref markedList);
            ret = ListConvertMarkNumbers(ret, ref markedList);
            //código antigo

            return ret;
        }

        string ListConvertMarkMatrix(string line, ref Dictionary<string, string> markedList)
        {
            var localLine = H.ToUnMarkedString(line, markedList);
            var ret = Regex.Replace(localLine, @"\s*\(\s*", @"\(");
            ret = Regex.Replace(ret, @"\s*\)\s*", $@"){Environment.NewLine}");//(\s+OF\s+\S+)*

            ////TODO: move list of list
            ////WTABG-SITUACAO(WS-PRD WS-TIP WS-SIT)
            //
            //MOVE 'A' TO WTABG-TIPO(WS-PRO WS-TIP)
            //
            ////custom lists
            var matches = Regex.Matches(ret, @"(?<varName>\S+(\s+OF\s+\S+)*)\\\((?<indexes>.*)\)");
            //flag de controle para cenário com comando SUBSTRING fazendo o MOVE com substring
            var isMatchSubstringOff = Regex.IsMatch(ret, @"\.Substring\\\((\d+)\s*,\s*(\d+)\)");
            if (!matches.Any(x => x.Success) || isMatchSubstringOff) return line;

            //este é o controle de virgulas após o TO do MOVE, fazendo com que os argumentos tenham virgulas entre sí

            //este é o controle para sabermos se ESTAMOS após o TO do MOVE, se não, acontece de colocar virgula adicional se houver parametros a serem convertidos antes do TO
            var isAfterMoveComma = false;

            foreach (Match match in matches)
            {
                isAfterMoveComma = localLine.IndexOf(match.Value.Replace("\\(", "(")) > localLine.IndexOf(H.CommaMark);

                if (!match.Success) return line;

                var varName = match.Groups["varName"].Value;
                var varProp = H.GetReferenceProperty(varName, Result);

                var indexes = match.Groups["indexes"].Value;
                if (indexes.Contains(":")) continue;
                if (!indexes.Trim().Contains(" ")) continue;

                //neste momento consigo recuperar as variaveis de dentro do parenteses
                //var indexesSplited = indexes.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                var indexesSplited = new List<string>();
                var matchIdx = Regex.Matches(indexes, @"(?<varname>\S+(\s+OF\s+\S+)*)");
                foreach (Match item in matchIdx)
                    if (item.Success)
                        indexesSplited.Add(item.Groups["varname"].Value);

                //para manter a propriedade da classe em "movimento" no for, precisamos de uma propriedade que será atualizada
                var currentVarProp = varProp;
                var isListPropAlready = currentVarProp.PropertyType.Contains("ListBasis");

                //manter uma lista de propriedades traduzidas
                var outList = new List<string>();
                if (!isListPropAlready)
                    outList.Add(varProp.PropertyName.Split(".").Last());

                //for inverso, pois vamos da ultima variavel para a primeira
                for (int i = indexesSplited.Count - 1; i >= 0; i--)
                {
                    //este IF garante que não vá subir em casos que a variavel JÁ ESTÁ no nivel de lista
                    if (!isListPropAlready)
                    {
                        //a propriedade é atualizada com seu "parent" assim mantemos a classe "subindo"
                        currentVarProp = H.GetReferenceProperty(currentVarProp?.PropertyParent + $" OF {currentVarProp.PropertyName.Split(".").FirstOrDefault()}", Result);
                    }

                    var indexer = indexesSplited.ElementAt(i).Replace(",", "");
                    var indexerProp = H.GetReferenceProperty(indexer, Result);

                    //caso o indexer não for PROPERTY for um número, estará resolvido da mesma forma
                    outList.Add($"{currentVarProp.PropertyName.Split(".").Last()}[{indexerProp?.PropertyName ?? indexer}]");
                }

                //adicionando todos os níveis anteriores da variavel atual, para dar a profundidade correta da variavel
                outList.AddRange(currentVarProp.PropertyName.Split(".").SkipLast(1).Reverse());

                //controla as "virgulas" no final da linha quando o MOVE tem mais de 1 parametro após o TO
                var toMarkString = string.Join('.', outList.ToArray().Reverse());
                
                if (!Regex.IsMatch(localLine, @$"{H.CommaMarkRegex}\s+{match.Value.Replace(")", "\\)")}") && isAfterMoveComma)
                    toMarkString = "," + toMarkString;

                localLine = localLine.Replace(match.Value.Replace("\\(", "("), H.Mark(toMarkString, ref markedList));
            }

            //quando trocamos line por localLine fizemos a substituição das marcas, então
            //se faz necessário marcar novamente de uma forma "não natural"
            for (int i = markedList.Count - 1; i >= 0; i--)
            {
                var item = markedList.ElementAt(i);
                localLine = localLine.Replace(item.Value, item.Key);
            }

            //return ret;
            return localLine;
        }

        //Código Antigo


        string ListConvertMarkVariables(string line, ref Dictionary<string, string> markedList)
        {
            var localMark = "^^";
            var ret = line.Replace("(", " (").Replace(")", ") ").Replace(")  (", $"){localMark}(").Replace(" (", "(").Replace(") ", ")");
            var splited = ret.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();
            var passCommaMark = false;
            var passCommaMarkCounter = 0;

            try
            {
                foreach (var item in splited)
                {
                    if (passCommaMark)
                        passCommaMarkCounter++;

                    if (H.HasStringMark(item)) continue;
                    if (H.CommaMark == item)
                    {
                        passCommaMark = true;
                        continue;
                    }

                    var localItem = item.Split(localMark).FirstOrDefault()?.Replace(" ", "");

                    //commomLists
                    var rxVariables = Regex.Match(localItem, @"\S*\((?<variable>[\s]*\S+[\s]*)\)");
                    if (rxVariables.Success)
                    {
                        var afterListVariable = new StringBuilder();
                        var outterVariable = localItem.Substring(0, localItem.IndexOf("("));
                        var outterProperty = H.GetReferenceProperty(outterVariable, Result);
                        var varProcess = outterProperty?.PropertyName.Split(".");
                        if (varProcess?.Any() != true) return line;

                        for (int i = varProcess.Length; i > 0; i--)
                        {
                            
                            var innerVar = varProcess.Take(i).Last();
                            var refferProp = H.GetReferenceProperty($"{innerVar} OF {varProcess.FirstOrDefault()}", Result);
                            if (refferProp?.PropertyType.Contains("ListBasis") == true)
                            {
                                var innerProperty = H.GetReferenceProperty(rxVariables.Groups["variable"].Value, Result);
                                if (innerProperty == null) return line;

                                //if (!ret.Contains(localMark))
                                ret = ret.Replace(localItem, H.Mark($"{(passCommaMarkCounter > 1 ? "," : "")}{refferProp.PropertyName}[{innerProperty.PropertyName}]{afterListVariable.ToString()}", ref markedList));
                                //else
                                //    ret = ret.Replace(localItem, $"{(passCommaMarkCounter > 1 ? "," : "")}{refferProp.PropertyName}[{innerProperty.PropertyName}]");

                                break;
                            }
                            else
                            {
                                afterListVariable.Insert(0, $".{innerVar}");
                            }
                        }
                    }
                }
            }
            catch
            {
            }

            return ret.Replace($"{localMark}", "");
        }

        string ListConvertMarkNumbers(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;
            var splited = ret.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var passCommaMark = false;
            var passCommaMarkCounter = 0;

            foreach (var item in splited)
            {
                if (passCommaMark)
                    passCommaMarkCounter++;

                if (H.HasStringMark(item)) continue;
                if (H.CommaMark == item)
                {
                    passCommaMark = true;
                    continue;
                }

                var lstMath = new List<Match>();
                var rxNumbers = Regex.Match(item, @"\S*\((?<number>[\s]*\d+[\s]*)\)");
                if (rxNumbers.Success)
                {
                    var outterVariable = item.Substring(0, item.IndexOf("("));
                    var outterProperty = H.GetReferenceProperty(outterVariable, Result);
                    var varProcess = outterProperty?.PropertyName.Split(".");
                    if (varProcess?.Any() != true) return line;

                    for (int i = varProcess.Length; i > 0; i--)
                    {
                        var innerVar = varProcess.Take(i).Last();
                        var refferProp = H.GetReferenceProperty(innerVar, Result);
                        if (refferProp?.PropertyType.Contains("ListBasis") == true)
                        {
                            var innerProperty = rxNumbers.Groups["number"].Value;
                            if (!int.TryParse(innerProperty, out var pInnerProperty)) return line;

                            ret = ret.Replace(item, H.Mark($"{(passCommaMarkCounter > 1 ? "," : "")}{refferProp.PropertyName}[{pInnerProperty}]", ref markedList));
                            break;
                        }
                    }
                }
            }

            return ret;
        }


    }
}
