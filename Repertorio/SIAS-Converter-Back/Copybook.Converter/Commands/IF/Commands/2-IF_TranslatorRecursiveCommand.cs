using CobolLanguageConverter.Converter.Commands.IF;
using CobolLanguageConverter.Converter.Commands.MOVE;
using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2010.Excel;
using IA_ConverterCommons;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class IF_TranslatorRecursiveCommand : IIfCommand
    {
        public int Order { get; set; } = 2;
        public static int teste = 0;
        public CurrentLineType? CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public static Dictionary<string, string> OperationReferences = new Dictionary<string, string>
        {
            {"NOT EQUAL","!=" },
            {"NOT EQUALS","!=" },
            {"EQUALS","==" },
            {"EQUAL","==" },
        };

        public string Execute(string line, ref Dictionary<string, string> markedList)
        {
            var ret = H.ToMarkedString(line, out markedList);

            NormalizeMarkedList(ref markedList);

            ret = TranslateIf(ret, ref markedList, false);
            ret = NormalizeExit(ret, ref markedList);
            TranslationValidator(ret, markedList);

            return ret;
        }

        //strings do tipo 'teste(a)' ficam 'teste(a) ' com um espaço adicional este método previne isso
        private void NormalizeMarkedList(ref Dictionary<string, string> markedList)
        {
            for (int i = 0; i < markedList.Count; i++)
            {
                var item = markedList.ElementAtOrDefault(i);
                if (!item.Value.Contains("'")) continue;
                if (!item.Value.Contains(")")) continue;

                var val = Regex.Replace(item.Value, @"\)\s*'", ")'");
                markedList[item.Key] = val;
            }
        }

        //normalizando os parentesis a mais, talvez este método precise ser amadurecido
        private string NormalizeExit(string condition, ref Dictionary<string, string> markedList)
        {
            var ret = condition;
            var counterValidator = H.ToUnMarkedString(ret, markedList);
            var isValidBrackets = counterValidator.Count(x => x.Equals('(')) == counterValidator.Count(x => x.Equals(')'));
            for (int i = 0; i < 3 && !isValidBrackets; i++)
            {
                counterValidator = counterValidator.Trim();
                counterValidator = string.Join("", counterValidator.SkipLast(1));
                ret = H.Mark(counterValidator, ref markedList);
                isValidBrackets = counterValidator.Count(x => x.Equals('(')) == counterValidator.Count(x => x.Equals(')'));
            }

            return ret;
        }

        private void TranslationValidator(string ret, Dictionary<string, string> markedList)
        {
            //neste momento o IF não é para ter mais nenhum simbolo, a não ser (,),||,&& e as marcas de tradução
            var validator = ret;
            var counterValidator = H.ToUnMarkedString(ret, markedList);
            var isValidBrackets = counterValidator.Count(x => x.Equals('(')) == counterValidator.Count(x => x.Equals(')'));

            validator = Regex.Replace(validator, @"\<\+\+\+\+\+\d+\>", "");
            validator = Regex.Replace(validator, @"\(", "");
            validator = Regex.Replace(validator, @"\)", "");
            validator = Regex.Replace(validator, H.MarkRegex, "");
            validator = Regex.Replace(validator, @"", "");
            validator = Regex.Replace(validator, @"\s+", "");
            validator = Regex.Replace(validator, @"\W+", "");
            validator = Regex.Replace(validator, @"\d+", "");
            validator = Regex.Replace(validator, @"NotIsNumeric", "");
            validator = Regex.Replace(validator, @"IsNumeric", "");
            validator = Regex.Replace(validator, @"stringEmpty", "");
            validator = Regex.Replace(validator, @"SQLCODE", "");

            //validator disabled
            if (!string.IsNullOrEmpty(validator) && !isValidBrackets)
                throw new Exception($"Erro ao converter if:> {ret}");
        }

        string TranslateIf(string condition, ref Dictionary<string, string> markedList, bool isRecursiveCall)
        {
            var ret = condition;
            // junta "X (" em "X( para resolver somas dentro de indices"
            string preprocessed = Regex.Replace(ret, @"(\S)\s+\(", "$1(");
            if (preprocessed.Contains("||("))
            {
                preprocessed = preprocessed.Replace("||(", "|| (");
            }

            preprocessed = Regex.Replace(preprocessed, @"\(\s*([^)]*?)\s*\)", m =>
            {
                string inner = Regex.Replace(m.Groups[1].Value, @"(?<!-)\s+|\s+(?![\w])", "");
                return $"({inner})";
            });
            if (preprocessed.Contains("+") && !preprocessed.Contains("SQLCODE"))
                ret = preprocessed;

            var markedString = ret;
            //Obtem uma listagem organizada dos itens de "IN" a CHAIN do COBOL IF
            var resolvedList = GetChainListAtString(ret);

            //aqui fazemos uma manobra, na hora de fazer o REPLACE da string original utilizaremos o ITEM, e o conteúdo a ser convertido será o Send
            var varList = resolvedList
                            .Select(x => new { Item = x.Trim().StartsWith("(") ? x.Trim().TrimStart('(').TrimEnd(')') : x, Send = x.Replace("( ", " ").Replace(" )", " ").Trim() })
                            .Select(x => new { Item = x.Item.Replace("! ", ""), Send = x.Send.Replace("! ", "") })
                            .Select(x => new { Item = Regex.Replace(x.Item, @"(\)\s*)+$", @""), Send = x.Send.Trim().StartsWith("(") ? Regex.Replace(x.Send, @"(\)\s*)+$", @"") : x.Send })
                            .Select(x => new { Item = Regex.Replace(x.Item, @"^(\s*\()+", @""), Send = x.Send.Trim().StartsWith("(") ? Regex.Replace(x.Send, @"^(\s*\()+", @"") : x.Send })

                            .Select(x => new { Item = x.Item.Replace("__F__",")"), Send = x.Send.Replace("__F__", ")") })
                            //.Select(x => new { Item = Regex.Replace(x.Item, @"(?<var>\s+(==|!=)\s+)\(", @"${var}"), Send = Regex.Replace(x.Send, @"(\)\s*)+$", @"") })
                            .ToList();

            //resolvendo ZEROES == TAL || TAL ou SPACES == TAL && TAL
            for (int i = 0; i < varList.Count; i++)
            {
                var item = varList[i];
                var zeroRex = Regex.Match(item.Send, @"(?<word>((ZERO((E)*(S)*))|(SPACE(S)*)))\s*(?<signal>(==|!=|<=|>=|<|>|))\s*(?<variables>((\s*[-A-z0-9]+\s*(?<symbol>\|\||&&)*)+))$");
                if (!zeroRex.Success) continue;

                var word = zeroRex.Groups["word"].Value; //ZEROES
                word = word.Contains("ZERO") ? "00" : "string.Empty";

                var signal = zeroRex.Groups["signal"].Value; // ==
                var variables = zeroRex.Groups["variables"].Value; // LK-APOLICE && LK-APOLICE && LK-APOLICE
                var symbol = zeroRex.Groups["symbol"].Value; // &&

                var newStringList = new List<string>();
                foreach (var v in variables.Split(symbol.Trim(), StringSplitOptions.TrimEntries))
                    newStringList.Add($"{v} {signal} {word}");

                varList[i] = new { Item = varList[i].Item, Send = string.Join($" {symbol} ", newStringList) };
                //markedString = markedString.Replace(item.Item, string.Join($" {symbol} ", newStringList));
            }

            //for para resolver LOW-VALUES ou HIGH-VALUES em chain ex: IF LK-VG013-SISTEMA-CHAMADOR EQUAL LOW-VALUES OR HIGH-VALUES
            for (int i = 0; i < varList.Count; i++)
            {
                var item = varList[i];
                var highLowRex = Regex.Match(item.Send, @"^(?<varName>\S+(\s+OF\s+\S+)*)\s*(?<signal>(==|!=|<=|>=|<|>|))(\s*(?<variables>(SPACES|string.Empty|LOW-VALUES|HIGH-VALUES))\s*(?<symbol>\|\||&&)*)+");
                if (!highLowRex.Success) continue;

                var varName = highLowRex.Groups["varName"].Value;// variavel antes do ==
                var signal = highLowRex.Groups["signal"].Value; // ==
                var variables = highLowRex.Groups["variables"].Captures.Select(x => x.Value); // LK-APOLICE && LK-APOLICE && LK-APOLICE
                var symbol = highLowRex.Groups["symbol"].Value; // &&

                if (!variables.Contains("HIGH-VALUES") && !variables.Contains("LOW-VALUES")) continue;

                var newStringList = new List<string>();
                foreach (var v in variables)
                    newStringList.Add($"{varName} {signal} {v}");

                varList[i] = new { Item = varList[i].Item, Send = string.Join($" {symbol} ", newStringList) };
                //markedString = markedString.Replace(item.Item, string.Join($" {symbol} ", newStringList));
            }

            //aqui é feita em uma string de apoio, uma manobra para verificar AS DEMAIS variaveis da string de entrada, ou seja, primeiramente marco todas as entradas conhecidas
            foreach (var x in varList)
                markedString = markedString.Replace(x.Item, "");

            //com as entradas conhecidas marcadas
            //esta manobra pega variaveis do tipo Lista ou substring REG-NOME-ARQUIVO(6:2) W-TB-NUM-PROPOSTA ( W-INDICE-2 )  R1NUMFONE(W-INDEX:OMD1)
            //condições usadas no teste https://regex101.com/r/RC5aIy
            //var rex = Regex.Matches(markedString, @"(?<vars>[-A-z0-9]+(\s+OF\s+[-A-z0-9]+)*[-A-z0-9]+(\s+OF\s+[-A-z0-9]+)*(\s*\(\s*\d+\s*\)|\s*\(\s*[-A-z0-9]+\s*\)|\s*\(\s*\S+\s*:\s*\S+\s*\)|\s*\(\s*[-A-z0-9]+-*\s*[-A-z0-9-]+\s*\)|\s*\(\s*[-A-z0-9]+\s*[-A-z0-9]*\s[-A-z0-9]+\s*\))*(\s*(.NotIsNumeric|.IsNumeric|.IsEmpty()|(\s*==\s*LOW-VALUES)|(\s*(==|!=)\s*string.Empty)))*)");
            var rex = Regex.Matches(markedString, @"((?<variable>(\S+\s+OF\s+)*[-A-z0-9]+)\s*(\((?<substr>\s*[-A-Za-z0-9+]+\s*((:|\s*|,)[-A-Za-z0-9+]*\s*))+\))+)(\s*(.NotIsNumeric|.IsNumeric|.IsEmpty\(\)|(\s*==\s*LOW-VALUES)|(\s*(==|!=)\s*string.Empty)))*");
            varList.AddRange(rex.Where(x => x.Success)
                            .Select(x => new { Item = x.Value, Send = Regex.Replace(Regex.Replace(x.Value, @"\s*\)\s*", @")"), @"\s*\(\s*", @"(") })
                            .Select(x => new { Item = x.Item.Replace("! ", ""), Send = x.Send.Replace("! ", "") })
                            .ToList());

            //aqui é feita em uma string de apoio, uma manobra para verificar AS DEMAIS variaveis da string de entrada, ou seja, primeiramente marco todas as entradas conhecidas
            foreach (var x in varList)
                markedString = markedString.Replace(x.Item, "");

            //obtem as condições de ALL
            //VALIDAR O + 50 aqui
            rex = Regex.Matches(markedString, @"(?<vars>[-A-z0-9]+(\s+OF\s+\S+)*\s*(==|!=)\s*ALL\s*\S+)");
            varList.AddRange(rex.Select(x => x.Groups["vars"])
                            .Select(x => new { Item = x.Value, Send = x.Value })
                            //.Select(x => new { Item = x.Value, Send = Regex.Replace(Regex.Replace(x.Value, @"\s*\)\s*", @")"), @"\s*\(\s*", @"(") })
                            //.Select(x => new { Item = x.Item.Replace("! ", ""), Send = x.Send.Replace("! ", "") })
                            .ToList());

            //aqui é feita em uma string de apoio, uma manobra para verificar AS DEMAIS variaveis da string de entrada, ou seja, primeiramente marco todas as entradas conhecidas
            foreach (var x in varList)
                markedString = markedString.Replace(x.Item, "");

            //adicionada a validacao para não separar os indices exemplo:
            //var (indVar) errado
            //var(indVar) correto
            varList.AddRange(Regex.Matches(markedString, @"(?<vars>(\S+\s+OF\s+)*[-A-Za-z0-9_().]+)(\s*(.NotIsNumeric|.IsNumeric|.IsEmpty\(\)|(\s*==\s*LOW-VALUES)|(\s*(==|!=)\s*string.Empty)))*")
            //varList.AddRange(Regex.Matches(markedString, @"(?<vars>(\S+\s+OF\s+)*[-A-z0-9]+)(\s*(.NotIsNumeric|.IsNumeric|.IsEmpty\(\)|(\s*==\s*LOW-VALUES)|(\s*(==|!=)\s*string.Empty)))*")
                                        .Where(x => !long.TryParse(x.Value,out _) && x.Value != "-")
                                        .Select(x => new { Item = x.Value, Send = x.Value })
                                        //.Select(x => new { Item = x.Value, Send = Regex.Replace(Regex.Replace(x.Value, @"\s*\)\s*", @")"), @"\s*\(\s*", @"(") })
                                        //.Select(x => new { Item = x.Item.Replace("! ", ""), Send = x.Send.Replace("! ", "") })
                                        .ToList());
            //aqui ordenamos por ordem de tamanho, caso tenhamos itens concorrentes com mesmo nome e valores
            varList = varList
                        .DistinctBy(x => x.Item)
                        .OrderByDescending(x => x.Item.Length)
                        .ToList();

            foreach (var it in varList)
            {
                var translatedLine = Translate(it.Send, ref markedList);
                var exec = ret.Replace(it.Item, H.Mark(translatedLine, ref markedList));
                ret = exec;
            }

            return ret;
        }

        /// <summary>
        /// Método para obter uma lista de condições do tipo CHAIN no cobol
        /// </summary>
        /// <param name="condition">condição na linguagem COBOL</param>
        /// <returns></returns>
        private List<string> GetChainListAtString(string condition)
        {
            var resolvedList = new List<string>();

            //inicialmente vamos fazer split por || transformando todo inicio de linha em {||}
            //a ideia aqui é identificar depois do split o que é || e o que é &&
            var orSplited = condition.Split("||").ToList();
            orSplited = orSplited
                            .Select((x, i) => i == 0 ? x : $"{{||}}{x}")
                            .ToList();

            var allSplited = new List<string>();

            //neste FOR vamos apenas fazer split das variaveis internas do split ANTERIOR "split do ||"
            //para fazer split por &&, e transformar as iniciais em {&&} 
            //depois disso teremos uma lista de condições separadas por || e && sem perder a referencia de qual é qual
            for (int i = 0; i < orSplited.Count; i++)
            {
                var andSplited = orSplited[i].Split("&&").ToList();
                andSplited = andSplited
                            .Select((x, i) => i == 0 ? x : $"{{&&}}{x}")
                                .ToList();

                allSplited.AddRange(andSplited);
            }

            //aqui montamos a decisão se é CHAIN ou não
            /* Exemplos:
             * isso é CHAIN
             * LK-NUM-APOL == 3 || 4 || 5 || 6
             * SIGAT(02:7) ==  '1' || '2' || '3'
             * RH-TIPO-ARQUIVO OF REG-HEADER == 1 || 0
             * REG-NUM-PROPOSTA == 00084694639010 || 00084694652416 || 00084694666786 || 00084694669181 || 00084694670562 || 00084694675467
             * REG-NUM-PROPOSTA == 0 || > 2
             * 
             *isso Não
             * WTABG-TIPO ( 1 WIND WIND2 ) == 1 || RH-TIPO-ARQUIVO OF REG-HEADER == 1
             * RH-TIPO-ARQUIVO OF REG-HEADER == 0 && RH-NOME OF REG-HEADER ==  |{1|}
             */
            for (int i = 0; i < allSplited.Count; i++)
            {
                var it = allSplited[i];

                //temos uma lista que controla o retorno, e o primeiro item é sempre adicionado
                if (i == 0)
                {
                    resolvedList.Add(it);
                    continue;
                }

                //após o primeiro item, testamos se a linha atual tem alguns simbolos que exclusivamente são de condição
                //porém o teste && > ou || < por exemplo, são dados como Chain
                if ((it.Contains("==") || it.Contains("!=") || it.Contains("<") || it.Contains(">") || it.Contains(".NotIsNumeric")) && !Regex.IsMatch(it, @"({&&}|{\|\|})\s*(<|>)"))
                {
                    //caso o item atual conter um simbolo de controle
                    //vamos testar se o ultimo item tem alguma variavel de controle também
                    //e caso não conter || ou && este item é removido da lista pois seria uma condição por sí só
                    var lastItem = resolvedList.LastOrDefault();
                    if ((lastItem.Contains("==") || lastItem.Contains("!=") || lastItem.Contains("<") || lastItem.Contains(">") || lastItem.Contains(".NotIsNumeric")) && (!lastItem.Contains("{||}") && !lastItem.Contains("{&&}")))
                        resolvedList.RemoveAt(resolvedList.Count - 1);

                    //aqui adicionamos a lista a nova condição de controle
                    //neste momento provavelmente temos então uma variavel com == ou != por exemplo
                    resolvedList.Add(it.Replace("{||}", "").Replace("{&&}", ""));
                    continue;
                }

                //aqui, idependente do que ocorreu anteriormente, temos pelo menos 1 item na lista de controle
                //ou seja, o começo ou continuidade da ultima condição
                //e caso o item atual não conter SELECTOR BASIS ( variavel 88 ) 
                //é adicionado à frente do ultimo item da lista
                //o Selector Basis é um "true" "false" ou seja, caso estiver na frente de um simbolo || ou && não é considerado um CHAIN
                var selectorTest = H.GetReferenceProperty(it.Replace("{||}", "").Replace("{&&}", "").Replace("(", "").Replace(")", "").Trim(), Result, true);
                if (selectorTest?.PropertyType != typeof(SelectorBasis).Name)
                {
                    //ocorreram momentos que o it precisa ser protegido de perder o ")" do final do comando pois ao invés de ser if((teste)) é {||} JVPROD(9320) 
                    var rexMatch = Regex.Match(it.Trim(), @"\S+\s*\([-A-z0-9]+\)");
                    if (rexMatch.Success)
                    {
                        it = it.Replace(rexMatch.Value, rexMatch.Value.Replace(")","__F__"));
                    }

                    resolvedList[resolvedList.Count - 1] += $"{it}";
                }
            }

            //ao retornar, precisamos normalizar a STRING
            //e ainda sim, retornar apenas os itens que contém realmente um CHAIN
            return resolvedList
                        .Where(x => x.Contains("{||}") || x.Contains("{&&}"))
                        .Select(x => x.Replace("{||}", "||").Replace("{&&}", "&&").Trim())
                        //.Select(x => Regex.Replace(x, @"\(\s+", @""))
                        //.Select(x => Regex.Replace(x, @"\s+\)", @""))
                        .ToList();
        }



        //string TranslatorRecursive(string condition, ref Dictionary<string, string> markedList, bool isRecursiveCall)
        //{
        //    var ret = condition;

        //    var rexSplit = ret.ToCharArray();
        //    var parenthesysList = new List<IfStatementModel>();
        //    var currentStringBuilder = new StringBuilder();
        //    var parenthesysCounter = 0;
        //    var readytoBreak = false;

        //    //a consulta por caracteres se faz presente para repartir e fazer a recursividade dentro de cada "bloco" de parentesis
        //    for (int i = 0; i < rexSplit.Length; i++)
        //    {
        //        var rex = rexSplit[i];

        //        if (rex == '(')
        //        {
        //            parenthesysCounter++;

        //            //este if significa que é o primeiro parenteses encotrado, abertura do primeiro na row
        //            if (!readytoBreak)
        //            {
        //                //apenas copia na lista se houver algo, pode ser que começe com parenteses, neste caso desconsidera a primeira posição caso for parentesis de cara
        //                if (!string.IsNullOrWhiteSpace(currentStringBuilder.ToString()))
        //                {
        //                    parenthesysList.Add(new IfStatementModel(currentStringBuilder.ToString()));
        //                    currentStringBuilder = new StringBuilder();
        //                }

        //                readytoBreak = true;
        //                continue;
        //            }
        //        }

        //        if (rex == ')')
        //            parenthesysCounter--;

        //        //só entra neste if quando a posição do "CARRET" for o "fecha" de uma sentença
        //        if (readytoBreak && parenthesysCounter == 0)
        //        {
        //            // a intenção aqui é verificar se temos um If de Substring VAR_1(1) ou um IF de Lista VAR_1(IND)
        //            // podemos verificar também a sequencia WDATA-MM-SQL EQUAL ( 04 || 06 || 09 || 11)
        //            //adicionado comportamento para validar VAR(W1 W2 W3)
        //            var lineChainCompareVerify = Regex.IsMatch(currentStringBuilder.ToString(), @"(\s*\d{0,4}\s*\|\|\s*\d{1,4})") && !currentStringBuilder.ToString().Contains("==");
        //            var lineSplitedSpaces = currentStringBuilder.ToString().Trim().Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();
        //            var isAllIndexedVariable = lineSplitedSpaces.All(x => H.GetReferenceProperty(x, Result) != null);
        //            var isOfVariable = lineSplitedSpaces.Count == 3 && lineSplitedSpaces[1] == "OF";
        //            if (int.TryParse(currentStringBuilder.ToString().Trim(), out var pRes) || isAllIndexedVariable || currentStringBuilder.ToString().Contains(":") || lineChainCompareVerify || isOfVariable)
        //            {
        //                if (lineChainCompareVerify || isAllIndexedVariable || isOfVariable)
        //                {
        //                    var tst = parenthesysList.Last();
        //                    tst.Condition += "(" + currentStringBuilder + ") ";
        //                    currentStringBuilder = new StringBuilder(tst.Condition);
        //                    parenthesysList = parenthesysList.SkipLast(1).ToList();

        //                    //começou a faltar caracteres em alguns cenários
        //                    if (rexSplit[i + 1] != '(')
        //                        i++;

        //                    readytoBreak = false;
        //                    continue;
        //                }

        //                //aqui verificamos se o que precede o parentesis é uma variavel, assim obtendo o que vem antes do parentesis "andando para trás"
        //                var possibleVariableNameList = new List<char>();
        //                var searchChar = "(";
        //                for (int j = i; j >= 0 && (rexSplit[j] != ' ' || searchChar == "("); j--)
        //                {
        //                    if (string.IsNullOrEmpty(searchChar))
        //                        possibleVariableNameList.Add(rexSplit[j]);

        //                    if (rexSplit[j] == '(')
        //                        searchChar = "";
        //                }

        //                possibleVariableNameList.Reverse();
        //                var possibleVariableName = string.Join("", possibleVariableNameList);

        //                //confirmação se esta é uma Substring Type
        //                //caso for, o método esta tratando para voltar o passo anterior para substring, evitando quebrar a linha onde não deveria
        //                if (!string.IsNullOrEmpty(possibleVariableName) && H.GetReferenceProperty(possibleVariableName, Result) != null && parenthesysList.Count > 0)
        //                {
        //                    var tst = parenthesysList.Last();
        //                    tst.Condition += "(" + currentStringBuilder + ") ";
        //                    currentStringBuilder = new StringBuilder(tst.Condition);
        //                    parenthesysList = parenthesysList.SkipLast(1).ToList();
        //                    i++;

        //                    //verificação necessária de string substring
        //                    if (i < rexSplit.Length && rexSplit[i] == '(')
        //                        i--;
        //                    //verificação necessária de string substring

        //                    readytoBreak = false;
        //                    continue;
        //                }

        //                //confirmação se esta é uma Substring Type
        //                //caso for, o método esta tratando para voltar o passo anterior para substring, evitando quebrar a linha onde não deveria
        //                if (Regex.IsMatch(currentStringBuilder.ToString(), @"^\d+:\d+$") && parenthesysList.Count > 0)
        //                {
        //                    var tst = parenthesysList.Last();
        //                    tst.Condition += "(" + currentStringBuilder + ") ";
        //                    currentStringBuilder = new StringBuilder(tst.Condition);
        //                    parenthesysList = parenthesysList.SkipLast(1).ToList();
        //                    i++;
        //                    readytoBreak = false;
        //                    continue;
        //                }

        //            }
        //            // a intenção aqui é verificar se temos um If de Substring VAR_1(1) ou um IF de Lista VAR_1(IND)

        //            parenthesysList.Add(new IfStatementModel(currentStringBuilder.ToString().Trim(), true));
        //            currentStringBuilder = new StringBuilder();
        //            readytoBreak = false;
        //        }
        //        else
        //            currentStringBuilder.Append(rex);
        //    }

        //    if (!string.IsNullOrWhiteSpace(currentStringBuilder.ToString()))
        //    {
        //        parenthesysList.Add(new IfStatementModel(currentStringBuilder.ToString().Trim(), false));
        //        currentStringBuilder.Clear();
        //    }

        //    foreach (var parenthesysItem in parenthesysList)
        //    {
        //        var parLine = parenthesysItem.Condition;
        //        var markedItem = "";

        //        if (parenthesysItem.IsInsideParenthesys)
        //        {
        //            parLine = TranslatorRecursive(parenthesysItem.Condition.Trim(), ref markedList, true);
        //            ret = ret.Replace(parenthesysItem.Condition, parLine);
        //        }
        //        else
        //        {
        //            //neste momento é que ocorre a tradução literal da parte da linha, do comando corrente
        //            //TESTE VISUAL: //    ret = ret.Replace(parLine, $"<+++++{++teste}>");
        //            if (parLine.Trim() != "||" && parLine.Trim() != "&&" && parLine.Trim() != "!")
        //            {
        //                var translatedLine = Translate(parLine, ref markedList);

        //                //precisamos normalizar o retorno, por que em alguns cenários um espaço evitava a conversão
        //                //ret = ret.Replace(parLine, H.Mark(translatedLine, ref markedList));

        //                //alterado dia 16/08/2024, pode dar problema, a ideia aqui é que PARLINE precisa estar dentro de RET, 1 espaço de diferença e a substituição não acontece
        //                ret = Regex.Replace(ret, Regex.Replace(Regex.Escape(parLine).Replace("\\ ", " "), @"\s+", @"\s*"), H.Mark(translatedLine, ref markedList));
        //            }
        //        }
        //    }

        //    return ret;
        //}

        string Translate(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;
            ret = TranslateSubstring(ret, ref markedList);
            ret = TranslateNumberComma(ret, ref markedList);
            ret = TranslateMarkMatrix(ret, ref markedList);
            ret = TranslateIfList(true, ret, ref markedList);
            ret = TranslateIfList(false, ret, ref markedList);
            ret = TranslateChain(ret, ref markedList);
            ret = TranslateConditionDate(ret, ref markedList);
            ret = TranslateConditionGreaterLess(ret, ref markedList);
            ret = TranslateConditionAll(ret, ref markedList);
            ret = TranslateVariables(ret, ref markedList);
            ret = TranslateConditionDefault(ret, ref markedList);
            return ret;
        }

        string TranslateMarkMatrix(string line, ref Dictionary<string, string> markedList)
        {
            var localLine = H.ToUnMarkedString(line, markedList);
            var ret = Regex.Replace(localLine, @"\(", @"\(");
            ret = Regex.Replace(ret, @"\)", $@")");//(\s+OF\s+\S+)*

            ////custom lists
            var matches = Regex.Matches(ret, @"(?<varName>\S+(\s+OF\s+\S+)*)\s*\\\((?<indexes>.*?)\)");
            if (!matches.Any(x => x.Success)) return line;

            foreach (Match match in matches)
            {
                var indexes = match.Groups["indexes"].Value.Trim();
                var varName = match.Groups["varName"].Value;
                var varProp = H.GetReferenceProperty(varName, Result);

                if (indexes.Contains(":")) continue;
                if (varProp == null) continue;
                //if (!indexes.Trim().Contains(" ")) continue;

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

                var exploded = 50;
                //for inverso, pois vamos da ultima variavel para a primeira
                for (int i = indexesSplited.Count - 1; i >= 0; i--)
                {
                    var localControl = 0;
                    //este IF garante que não vá subir em casos que a variavel JÁ ESTÁ no nivel de lista
                    while (!isListPropAlready && currentVarProp != null)
                    {
                        //a propriedade é atualizada com seu "parent" assim mantemos a classe "subindo"
                        currentVarProp = H.GetReferenceProperty(currentVarProp?.PropertyParent + $" OF {currentVarProp.PropertyName.Split(".").FirstOrDefault()}", Result);
                        isListPropAlready = currentVarProp?.PropertyType?.Contains("ListBasis") == true;
                        if (!isListPropAlready)
                            outList.Add($"{currentVarProp.PropertyName.Split(".").Last()}");

                        localControl++;

                        if (localControl > exploded)
                            break;
                    }

                    var indexer = indexesSplited?.ElementAtOrDefault(i)?.Replace(",", "");
                    var indexerProp = H.GetReferenceProperty(indexer, Result);

                    //caso o indexer não for PROPERTY for um número, estará resolvido da mesma forma
                    outList.Add($"{currentVarProp.PropertyName.Split(".").Last()}[{indexerProp?.PropertyName ?? indexer}]");

                    //feito para voltar no while
                    isListPropAlready = false;
                }

                //adicionando todos os níveis anteriores da variavel atual, para dar a profundidade correta da variavel
                outList.AddRange(currentVarProp.PropertyName.Split(".").SkipLast(1).Reverse());

                //controla as "virgulas" no final da linha quando o MOVE tem mais de 1 parametro após o TO
                var toMarkString = string.Join('.', outList.ToArray().Reverse());

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


        string TranslateChain(string line, ref Dictionary<string, string> markedList)
        {
            var ret = Regex.Replace(line, @"' '", "'{SPACE}'");
            var mathes = Regex.Matches(ret, @"(?<important>(?<variableIn>\S+(\s+OF\s+\S+)*)\s+(?<signal>(==|!=))(\s*\(\s*)*(\s+(?<variables>\S+)\s+(?<variablesSign>(\|\||&&)))+\s+(?<lastVar>\S+)(\s*\)\s*)*)($|(\s+(&&|\|\|)))");

            foreach (Match match in mathes)
            {
                var important = match.Groups["important"].Value;
                var variableIn = match.Groups["variableIn"].Value;
                var signal = match.Groups["signal"].Value;
                var variables = match.Groups["variables"].Captures?.Select(x => x.Value)?.ToList() ?? new List<string>();
                var variablesSign = match.Groups["variablesSign"].Captures?.Select(x => x.Value)?.ToList() ?? new List<string>();
                var lastVar = match.Groups["lastVar"].Value;
                var toReplace = important;

                var negate = signal == "!=";
                var variableInProp = H.GetReferenceProperty(variableIn, Result);
                var variableInPropName = variableInProp?.PropertyName;
                if (H.HasStringMark(variableIn))
                    variableInPropName = H.ToUnMarkedString(variableIn, markedList);

                if (string.IsNullOrEmpty(variableInPropName))
                    variableInPropName = variableIn;

                var allVariables = variables;
                allVariables.Add(lastVar);

                var inVariables = new List<string>();

                foreach (var itemVar in allVariables)
                {
                    var variable = H.GetReferenceProperty(itemVar, Result);
                    var isListItem = false;

                    //no caso de listitem do Cobol, precisamos verificar este caso, pois é possivel fazer chain também
                    if (variable == null && itemVar.Contains("[") && itemVar.Contains("]"))
                    {
                        var idx = itemVar.IndexOf("[");
                        var probVarname = itemVar.Substring(0, idx);
                        variable = H.GetReferenceProperty(probVarname.Split(".", StringSplitOptions.RemoveEmptyEntries).Last(), Result);
                        isListItem = true;
                    }

                    if (variable != null && !isListItem)
                        inVariables.Add($"{variable.PropertyName}.ToString()");
                    //inVariables.Add(variable.PropertyIsClass ? $"{variable.PropertyName}.ToString()" : variable.PropertyName);
                    else
                    {
                        if (H.HasStringMark(itemVar))
                        {
                            var unString = H.ToUnMarkedString(itemVar, markedList);
                            var isVar = unString.Length > 1 && (unString.Contains("[") || unString.Contains("(") || unString.Contains("_"));
                            inVariables.Add($"{(isVar ? itemVar : unString)}{(isVar ? ".ToString()" : "")}");
                        }
                        else
                            inVariables.Add($"\"{itemVar.Replace("'", "").Replace("\"", "")}\"");
                    }
                }

                var joined = string.Join(",", inVariables);
                joined = Regex.Replace(joined, @"{SPACE}", " ");

                ret = ret.Replace(toReplace, H.Mark($"{(negate ? "!" : "")}{variableInPropName}.In({joined})", ref markedList));
            }

            return ret;
        }

        /// <summary>
        /// Busca por if que contenham substring (100:200)
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        string TranslateSubstring(string condition, ref Dictionary<string, string> markedList)
        {
            var ret = condition;
            var matches = Regex.Matches(ret, @"(?<variable>(\S+\s+OF\s+)*[A-a,0-9]+\S+)\((?<substr>\s*\S+:\S+\s*)\)");
            foreach (Match item in matches.Where(x => x.Success))
            {
                var substr = item.Groups["substr"].Value;

                //list e substring na mesma variavel, tratado mais pra frente
                if (Regex.IsMatch(item.Value.Replace(substr, ""), @"\S*(?<initial>\([\s]*\S+(\s+OF\s+\S+)*[\s]*\))")) continue;

                var variable = item.Groups["variable"].Value;
                substr = substr.Replace(":", ",");
                variable = H.GetReferenceName(variable, Result);

                //verifica a ocorrencia de variaveis dentro da substring
                var splitVar = substr.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                if (splitVar.Length > 0)
                {
                    foreach (var varItem in splitVar)
                    {
                        var val = varItem;
                        var firstVariableName = H.GetReferenceName(val, Result);
                        if (!string.IsNullOrEmpty(firstVariableName))
                            substr = substr.Replace(val, firstVariableName);
                    }

                }

                //splitVar contem as variaveis de : SI502-NOME-FAVORECIDO(WS_AUXILIARES.WS_IND1:1)
                substr = $"{variable}.Substring({substr.Trim()})";

                ret = ret.Replace(item.Value, H.Mark(substr, ref markedList));
            }



            return ret;
        }

        /// <summary>
        /// Translate number withComma
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="markedList"></param>
        /// <returns></returns>
        string TranslateNumberComma(string condition, ref Dictionary<string, string> markedList)
        {
            var ret = condition;
            var matches = Regex.Matches(ret, @"\s+\-*\d{1,4},\d{1,4}");
            if (matches.Any(x => x.Success) == true)
            {
                foreach (Match item in matches)
                {
                    ret = ret.Replace(item.Value, H.Mark(item.Value.Replace(",", "."), ref markedList));
                }

            }

            return ret;
        }

        /// <summary>
        /// processa variaveis de LISTA no COBOL
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        string searchPatternIfList = @"\S*(?<initial>\([\s]*\S+(\s+OF\s+\S+)*[\s]*\))\s*(?<substring>\s*\(.+?\))";
        string TranslateIfList(bool considerNumber, string condition, ref Dictionary<string, string> markedList)
        {
            //var searchPatternIfList = @"\S*(?<initial>\([\s]*\S+(\s+OF\s+\S+)*[\s]*\))";
            searchPatternIfList = @"\S*(?<initial>\([\s]*\S+(\s+OF\s+\S+)*[\s]*\))\s*(?<substring>\s*\(.+?\))";
            if (considerNumber)
                searchPatternIfList = @"\S*(?<initial>\([\s]*\d+[\s]*\))\s*(?<substring>\s*\(.+?\))";

            var ret = condition;
            var matches = Regex.Matches(ret, searchPatternIfList);

            //essa modificação foi feita para o IF TAB-DESCR-CBO-C(COD-CBO OF DCLPESSOA-FISICA)(1:5) EQUAL 'APOSE'
            //que trata substring junto com List
            if (!matches.Any(x => x.Success))
            {
                searchPatternIfList = @"\S*(?<initial>\([\s]*\S+(\s+OF\s+\S+)*[\s]*\))";
                if (considerNumber)
                    searchPatternIfList = @"\S*(?<initial>\([\s]*\d+[\s]*\))";

                matches = Regex.Matches(ret, searchPatternIfList);
            }

            foreach (Match matchR in matches.DistinctBy(x => x.Value).Where(x => x.Success))
            {
                //testa valores dentro dos parenteses
                var testResult = matchR.Value.Replace(" ", "").Replace("\n", "").Trim();
                var substringVar = matchR.Groups["substring"].Value;
                var isSubstring = !string.IsNullOrEmpty(substringVar);

                var isInvalidString =
                                   testResult == "()"
                                || testResult.Contains("=")
                                || testResult.Contains("||")
                                || testResult.Contains("!")
                                || testResult.Contains(",")
                            ;

                if (isInvalidString) return condition;
                var match = matchR.Groups["initial"].Value.Replace("\\)", ")").Replace("\\(", "(");
                var indexOf = ret.IndexOf(matchR.Groups["initial"].Value);
                if (indexOf < 0) return condition;

                var pattern = @$"\S+{match.Replace(")", @"\)").Replace("(", @"\(").Replace(".", @"\.")}";
                var substringVariableR = Regex.Match(ret, pattern);
                bool isSQLERRD = Regex.IsMatch(substringVariableR.Value.ToString(), @"SQLERRD\(\d+\)");
                var substringVariable = !isSQLERRD ? substringVariableR.Value.Replace(match, "") : substringVariableR.Value.ToString();
                
                //var substringVariable = substringVariableR.Value.Replace(match, "");
                var varProcess = substringVariable.Split(".", StringSplitOptions.RemoveEmptyEntries);
                if (!varProcess.Any()) return condition;

                var considerStringbasis = varProcess.Length == 1;

                var varOfProccess = H.GetReferenceProperty(substringVariable, Result);
                if (varOfProccess != null)
                {
                    varProcess = varOfProccess.PropertyName.Split(".", StringSplitOptions.RemoveEmptyEntries);
                    considerStringbasis = varProcess.Length == 1;
                }

                for (int i = varProcess.Length; i > 0; i--)
                {
                    try
                    {
                        var refferProp = H.GetReferenceProperty(varProcess.Take(i).Last(), Result);
                        var considerVal = matchR.Groups["initial"].Value.Replace("(", "").Replace(")", "").Trim();
                        if (considerStringbasis && refferProp.PropertyType == typeof(StringBasis).Name.ToString())
                        {
                            var localV = considerNumber ? considerVal : H.GetReferenceName(considerVal, Result);
                            ret = ret.Replace(matchR.Value, H.Mark($"{refferProp.PropertyName}.Substring({localV})", ref markedList));
                            break;
                        }

                        if (!isSQLERRD && refferProp.PropertyType.Contains("ListBasis") == true)
                        {
                            var localV = considerNumber ? considerVal : H.GetReferenceName(considerVal, Result);
                            var frontVar = string.Join(".", varProcess).Replace(refferProp.PropertyName, "");
                            var toSend = $"{refferProp.PropertyName}[{localV}]{(!string.IsNullOrEmpty(frontVar) ? frontVar : "")}";

                            if (isSubstring)
                                toSend += $".Substring{substringVar.Replace(":", ",")}";

                            ret = ret.Replace(matchR.Value, toSend);
                            break;
                        }
                    }
                    catch (NullReferenceException ex)
                    {
                        if (considerStringbasis) throw;

                        i = varProcess.Length + 1;
                        considerStringbasis = true;
                    }
                }

            }

            return ret;
        }

        /// <summary>
        /// Processamento padrão para trocar métodos locais do IF
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        string TranslateConditionDefault(string condition, ref Dictionary<string, string> markedList)
        {
            var matchs = new List<Match>();
            var ret = condition.Replace(" .", ".");
            ret = Regex.Replace(ret.ToString(), @"\s+SQLCODE\s+==\s+0+", "DB.SQLCODE.IsSuccess()");

            if (ret.ToString().Contains("!= 0"))
            {
                ret = Regex.Replace(ret.ToString(), @"\s+SQLCODE\s+!=\s+0+", "DB.SQLCODE.NotIsSuccess()");

                var str = ret.ToString();
                var regex = Regex.Matches(str.Trim(), @"\S+.NotIsSuccess");
                matchs.AddRange(regex.Where(x => x.Value.Contains("NotIsSuccess")).ToList());
            }

            if (ret.ToString().Contains("!= string.Empty"))
            {
                var rexVar = Regex.Match(ret, @"(?<variable>\S+)\s*!=\s+string.Empty");
                if (rexVar.Success)
                {
                    var variable = H.GetReferenceName(rexVar.Groups["variable"].Value, Result);
                    if (!string.IsNullOrWhiteSpace(variable))
                        ret = ret.Replace(rexVar.Groups["variable"].Value, variable);
                }

                ret = Regex.Replace(ret.ToString(), @" != string.Empty", ".NotIsEmpty()");

                var str = ret.ToString();
                var regex = Regex.Matches(str.Trim(), @"\S+.NotIsEmpty");
                matchs.AddRange(regex.Where(x => x.Value.Contains("NotIsEmpty")).ToList());
            }

            if (ret.ToString().Contains("== LOW-VALUES"))
            {
                var rexVar = Regex.Match(ret, @"(?<variable>\S+)\s*==\s+LOW-VALUES");
                if (rexVar.Success)
                {
                    var variable = H.GetReferenceName(rexVar.Groups["variable"].Value, Result);
                    if (!string.IsNullOrWhiteSpace(variable))
                        ret = ret.Replace(rexVar.Groups["variable"].Value, variable);
                }

                ret = Regex.Replace(ret.ToString(), @"\s+==\s+LOW-VALUES", ".IsLowValues()");
                ret = Regex.Replace(ret.ToString(), @"\.ToString\(\)\.IsLowValues", ".IsLowValues");
            }

            if (ret.ToString().Contains("!= LOW-VALUES"))
            {
                var rexVar = Regex.Match(ret, @"(?<variable>\S+)\s*!=\s+LOW-VALUES");
                if (rexVar.Success)
                {
                    var variable = H.GetReferenceName(rexVar.Groups["variable"].Value, Result);
                    if (!string.IsNullOrWhiteSpace(variable))
                        ret = ret.Replace(rexVar.Groups["variable"].Value, variable);
                }

                ret = Regex.Replace(ret.ToString(), @"\s+!=\s+LOW-VALUES", ".NotIsLowValues()");

                var str = ret.ToString();
                var regex = Regex.Matches(str.Trim(), @"\S+.NotIsLowValues");
                matchs.AddRange(regex.Where(x => x.Value.Contains("NotIsLowValues")).ToList());
            }

            if (ret.ToString().Contains(".InNot"))
            {
                var rexVar = Regex.Match(ret, @"(?<variable>\S+)\s*.InNot");
                if (rexVar.Success)
                {
                    var variable = H.GetReferenceName(rexVar.Groups["variable"].Value, Result);
                    if (!string.IsNullOrWhiteSpace(variable))
                        ret = ret.Replace(rexVar.Groups["variable"].Value, variable);
                }

                var str = ret.ToString();
                var regex = Regex.Matches(str.Trim(), @"\S+.InNot");
                matchs.AddRange(regex.Where(x => x.Value.Contains("InNot")).ToList());
            }

            if (ret.ToString().Contains(".NotIsNumeric"))
            {
                var rexVar = Regex.Match(ret, @"(?<variable>\S+(\s+OF\s+\S+)*)\s*.NotIsNumeric");
                if (rexVar.Success)
                {
                    var variable = H.GetReferenceName(rexVar.Groups["variable"].Value, Result);
                    if (!string.IsNullOrWhiteSpace(variable))
                        ret = ret.Replace(rexVar.Groups["variable"].Value, variable);
                }

                var str = ret.ToString();
                var regex = Regex.Matches(str.Trim(), @"\S+.[NotIsNumeric]");
                matchs.AddRange(regex.Where(x => x.Value.Contains("NotIsNumeric")).ToList());
            }

            foreach (Match item in matchs)
                ret = ret.Replace(item.Value, $"!{item.Value}");

            ret = ret.Replace(" == string.Empty", ".IsEmpty()");
            ret = ret.Replace("NotIsSuccess", "IsSuccess");
            ret = ret.Replace("HIGH-VALUES", ".IsHighValues");
            ret = ret.Replace("LOW-VALUES", "''");
            ret = ret.Replace("LOW-VALUE", "''");
            ret = ret.Replace(".IsNumeric", ".IsNumeric()");
            ret = ret.Replace("NotIsNumeric", "IsNumeric()");
            ret = ret.Replace("NotIsEmpty", "IsEmpty");
            ret = ret.Replace("NotIsLowValues", "IsLowValues");
            ret = ret.Replace("ToString().IsLowValues", "IsLowValues");
            ret = ret.Replace("InNot", "In");
            ret = ret.Replace("!)", ")");
            ret = ret.Replace("===", "==");
            ret = ret.Replace("!==", "!=");
            ret = ret.Replace("<==", "<=");
            ret = ret.Replace(">==", ">=");
            ret = ret.Replace("!DB.SQLCODE.IsSuccess() && 100", "!DB.SQLCODE.IsSuccess() && DB.SQLCODE != 100");
            ret = ret.Replace("!DB.SQLCODE.IsSuccess() && +100", "!DB.SQLCODE.IsSuccess() && DB.SQLCODE != 100");
            ret = ret.Replace("DB.DB.SQLCODE", "DB.SQLCODE");
            ret = ret.Replace("DB.DB.SQLCODE", "DB.SQLCODE");
            ret = ret.Replace("DB.DB.SQLCODE", "DB.SQLCODE");

            ret = Regex.Replace(ret, @"IsEmpty\(\)\s+\|\|\s+0+(\s|$)", @"IsEmpty()");
            //ret = ret.Replace("IsEmpty() || 00", "IsEmpty()");

            ret = Regex.Replace(ret, @"==\s+0+\s+\|\|\s+string.Empty", @".IsEmpty()");
            //ret = ret.Replace(" == 00 || string.Empty", ".IsEmpty()");

            ret = Regex.Replace(ret, @"==\s+0+(\s|$)", @".IsEmpty()");
            //ret = ret.Replace(" == 00", ".IsEmpty()");

            ret = ret.Replace("'", "\"");
            ret = ret.Replace("IS NEGATIVE", " < 0");

            return ret.ToString();
        }

        /// <summary>
        /// condição de datas <= data AND >= data
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="markedList"></param>
        /// <returns></returns>
        string TranslateConditionDate(string condition, ref Dictionary<string, string> markedList)
        {
            var ret = condition;

            var match = Regex.Match(ret, @"(?<var1>\S+)\s+(?<symbol1>>=)\s+(?<compare1>\S+)\s+(?<symbol2>&&)\s+(?<symbol3><=)\s+(?<compare2>\S+)");
            if (match.Success)
            {
                var var1 = match.Groups["var1"].Value;
                var symbol1 = match.Groups["symbol1"].Value;
                var compare1 = match.Groups["compare1"].Value;
                var symbol2 = match.Groups["symbol2"].Value;
                var symbol3 = match.Groups["symbol3"].Value;
                var compare2 = match.Groups["compare2"].Value;

                var refVar = H.GetReferenceProperty(var1, Result);
                if (refVar != null)
                    var1 = refVar.PropertyName;

                var newLine = $"{var1} {symbol1} {compare1} {symbol2} {var1} {symbol3} {compare2}";
                ret = ret.Replace(ret, H.Mark(newLine, ref markedList));
            }

            return ret;
        }

        string TranslateConditionGreaterLess(string condition, ref Dictionary<string, string> markedList)
        {
            var ret = condition;

            var match = Regex.Match(ret, @"(?<var1>\S+)\s*(?<g1>>\s*\d+|<\s*\d+|==\s*\d+|!=\s*\d+)\s*(?<op>&&|\|\|)\s*(?<g2><\s*\d+|>\s*\d+)");
            if (!match.Success) return ret;

            var var1 = match.Groups["var1"].Value;
            var g1 = match.Groups["g1"].Value;
            var op = match.Groups["op"].Value;
            var g2 = match.Groups["g2"].Value;

            //var newLine = Regex.Replace(ret, @"(?<var1>\S+)(?<g1>\s+>\s+\S+\s+&&\s+)(?<g2><\s+.+?$)", @"${var1} ${g1} ${var1} ${g2}");
            var newLine = var1 + " " + g1 + " " + op + " " + var1 + " " + g2;
            ret = ret.Replace(ret, H.Mark(newLine, ref markedList));

            return ret;
        }

        string TranslateConditionAll(string condition, ref Dictionary<string, string> markedList)
        {
            var ret = condition;

            var match = Regex.Match(ret, @"(?<varname>\S+(\s+OF\s+\S+)*)\s+\S+\s+ALL\s+(?<varCompare>\S+)");
            if (!match.Success) return ret;

            var matchSignal = Regex.Match(ret, @"(?<varname>\S+(?:\s+OF\s+\S+)*)\s+(?<varsignal>!=)\s+ALL\s+(?<varCompare>\S+)");
            var varname = !matchSignal.Success ? match.Groups["varname"].Value : "!" + match.Groups["varname"].Value;
            var varCompare = match.Groups["varCompare"].Value.Replace("'", "").Replace("\"", "");

            if (matchSignal.Success)
            {
                var refVar = H.GetReferenceProperty(varname.Replace("!", ""), Result, true);
                varname = refVar.PropertyName;
                ret = ret.Replace(match.Value, H.Mark($"!{varname}.All({varCompare})", ref markedList));
            }
            else
                ret = ret.Replace(match.Value, H.Mark($"{varname}.All({varCompare})", ref markedList));
            return ret;
        }

        string TranslateVariables(string condition, ref Dictionary<string, string> markedList)
        {
            var ret = condition;
            var matchRs = Regex.Matches(ret, @"\(*(?<variable>\S+(\s+OF\s+\S+)*)\)*");
            var mtcLst = matchRs.OrderByDescending(r => r.Groups["variable"].Length).ToList();

            foreach (Match matchR in mtcLst.Where(x => x.Success).DistinctBy((Match x) => x.Value).OrderByDescending(x => x.Length))
            {
                var matchVarname = matchR.Groups["variable"].Value
                                .Replace(".IsEmpty()", "")
                                .Replace(".IsNumeric", "")
                                .Replace(".NotIsNumeric", "")
                                .Replace("(", "")
                                .Replace(")", "");

                var hasNot = matchVarname.Contains("!");
                var variable = matchVarname.Replace("!", "");

                var refVar = H.GetReferenceProperty(variable, Result, true);
                var refVarName = refVar?.PropertyName;

                if (refVarName != null)
                {
                    //esta condição evita alterar variaveis que já tem "." ou seja "CLASS1.W01IND" não será alterado quando um item for "W01IND"
                    //isso serve para evitar que uma variavel seja convertida 2 vezes saindo da conversão correta "CLASS1.W01IND" para "CLASS1.CLASS1.W01IND"
                    var rex = Regex.Match(ret, $@"\S+\.{variable}\S+");
                    if (rex.Success)
                        ret = ret.Replace(rex.Value, H.Mark(rex.Value, ref markedList));

                    //existem ocasiões que a listbasis está debaixo de outra lista, e com isso não consegue ser acessada
                    //se for o caso, aqui faremos este tratamento
                    if (refVar.PropertyType.Contains("ListBasis"))
                    {
                        var parentRefVar = H.GetReferenceProperty(refVar.PropertyParent, Result, true);
                        if (parentRefVar != null && !string.IsNullOrEmpty(parentRefVar.IndexedBy))
                        {
                            var splitedByDot = refVarName.Split(".", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                            var localStrings = new List<string>();
                            foreach (var item in splitedByDot)
                            {
                                var itemRef = H.GetReferenceProperty(item, Result, true);
                                var itemStr = item;

                                //o intuito deste IF é pular a ultima ocorrencia, pois se for lista, a intenção de quem escreveu o código é acessar a lista e não o index
                                if (refVar != itemRef)
                                    if (!string.IsNullOrEmpty(itemRef.IndexedBy))
                                        itemStr = $"{itemStr}[{H.GetReferenceProperty(itemRef.IndexedBy, Result)?.PropertyName}]";

                                localStrings.Add(itemStr);
                            }

                            if (localStrings.Count > 0)
                                refVarName = string.Join(".", localStrings);
                        }
                    }

                    if (hasNot)
                        refVarName = $"!{refVarName}";

                    ret = Regex.Replace(ret, $@"{matchVarname}", H.Mark(refVarName, ref markedList));
                }
            }

            return H.ToUnMarkedString(ret, markedList);
        }

    }


    public class IfStatementModel
    {
        public string Condition { get; set; }
        public bool IsInsideParenthesys { get; set; }

        public IfStatementModel(string condition, bool isInsideParenthesys = false)
        {
            Condition = condition;
            IsInsideParenthesys = isInsideParenthesys;
        }
    }
}
