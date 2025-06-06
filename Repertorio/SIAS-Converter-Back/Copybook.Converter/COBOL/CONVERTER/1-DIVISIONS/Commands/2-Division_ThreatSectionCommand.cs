using System.Collections.Generic;
using System.Text.RegularExpressions;
using CobolLanguageConverter.Converter.DIVISION;
using IA_ConverterCommons;


namespace CobolLanguageConverter.Converter.Commands.DIVISIONS
{
    public class Division_ThreatSectionCommand : IDivisionCommand
    {
        public int Order { get; set; } = 2;
        public ResultSet Result { get; set; } = new ResultSet();

        public string Execute(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = ThreatSection(lines, ref divisionAndLines);
            ret = ThreatSectionChangeName(lines, ref divisionAndLines);
            return ret;
        }

        string ThreatSection(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = lines;
            var currentLines = new List<CurrentLineType>();
            var commaSections = new List<string>
            {
                @"ENVIRONMENT\s+DIVISION$"      ,
                @"DATA\s+DIVISION$"             ,
                @"FILE-CONTROL$"              ,
                @"WORKING-STORAGE\s+SECTION$"   ,
                @"LOCAL-STORAGE\s+SECTION$"     ,
                @"LINKAGE\s+SECTION$"           ,
                @"CONFIGURATION\s+SECTION$"     ,
                @"FILE\s+SECTION$"     ,
                @"INPUT-OUTPUT\s+SECTION$"     ,
            };

            //algumas divisions separam seus comandos por "." outras nem tanto
            //aqui temos as divisions que com certeza funcionam com pontuação, até o momento
            for (int i = 0; i < divisionAndLines.Count; i++)
            {
                var secLine = divisionAndLines.ElementAt(i);
                if (!commaSections.Any(x => Regex.IsMatch(secLine.Key, x, RegexOptions.None, TimeSpan.FromMilliseconds(500))))
                    continue;

                if (secLine.Value.Count == 0)
                    continue;

                //todas as linhas da section
                var allList = secLine.Value.Select(x => x.Line).ToList();
                for (int j = 0; j < allList.Count; j++)
                {
                    var line = allList[j];

                    //se não contiver ponto, é importante adicionar, caso de EJECT 
                    if (line.Contains(" EJECT ") && !line.EndsWith("."))
                        line = line + ".";

                    //se não contiver ponto, é importante adicionar, caso de END-EXEC 
                    if (line.Trim().Contains("END-EXEC") && !line.Trim().EndsWith('.'))
                        line = line.TrimEnd() + '.';

                    //variable Check, se for variavel sem nome 01 REDEFINES é um caso que ocorreu bastante
                    var rex = Regex.Match(line, @"(^|\s+)\d{2}\s+(?<redef>REDEFINES)*(?<varName>\S+)*");
                    if (rex.Success)
                    {
                        var isRedef = !string.IsNullOrEmpty(rex.Groups["redef"].Value);
                        if (isRedef)
                            line = Regex.Replace(line, @"(?<1>\s+)(?<2>\d{2}\s+)(?<3>REDEFINES)\s+", @"${1}${2} FILLER ${3}    ");
                    }

                    //aqui mudamos o final da linha para retirar o ponto e depois fazer um split pelo simbolo adicionado, evitando splitar strings tipo 01 TESTE PIC X(10) VALUE 'teste . com . ponto' e acabar quebrando a linha
                    if (line.TrimEnd().EndsWith("."))
                        allList[j] = line.TrimEnd('.') + "|_|+|_|";
                }

                var fullLines = string.Join("", allList.Select(x => x.TrimEnd()));

                //removendo linhas que tem apenas EJECT
                var rexEject = Regex.Match(fullLines, @"(\|[_]\|\+\|[_]\|)(?<replace>\s*EJECT\s*(\|[_]\|\+\|[_]\||$)*)");
                if (rexEject.Success)
                    fullLines = fullLines.Replace(rexEject.Groups["replace"].Value, "");

                var splitedRex = fullLines.Split("|_|+|_|", StringSplitOptions.RemoveEmptyEntries).Select(x => x.TrimEnd()).Where(x => !string.IsNullOrEmpty(x)).ToList();

                //muito cuidado, aqui podemos perder linhas saudaveis
                for (int k = 0; k < splitedRex.Count; k++)
                {
                    var search = secLine.Value.Where(x => !string.IsNullOrWhiteSpace(x.Line.Replace(".", "").Trim())).FirstOrDefault(x => splitedRex[k].Contains(x.Line.Trim().TrimEnd('.')));
                    try { if (search == null) search = secLine.Value.Where(x => !string.IsNullOrWhiteSpace(x.Line.Replace(".", "").Trim())).FirstOrDefault(bool (x) => { try { return Regex.IsMatch(splitedRex[k].Replace(" FILLER ", ""), Regex.Replace(x.Line.Trim().TrimEnd('.'), @"\s+", @"\s+")); } catch { return false; } }); } catch { }
                    if (search == null) throw new Exception("ESTE ERRO NÃO DEVERIA OCORRER, TODA VARIAVEL DEVERIA SER ENCONTRADA NO SEARCH");

                    currentLines.Add(new CurrentLineType(splitedRex[k], search.LineNumber));
                }

                divisionAndLines[secLine.Key] = currentLines;
                currentLines = new List<CurrentLineType>();
            }

            return ret;
        }

        string ThreatSectionChangeName(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = lines;
            var currentLines = new List<CurrentLineType>();
            var commaSections = new List<string>
            {
                @"ENVIRONMENT\s+DIVISION$"      ,
                @"DATA\s+DIVISION$"             ,
                @"FILE-CONTROL$"              ,
                @"WORKING-STORAGE\s+SECTION$"   ,
                @"LOCAL-STORAGE\s+SECTION$"     ,
                @"LINKAGE\s+SECTION$"           ,
                @"CONFIGURATION\s+SECTION$"     ,
                @"FILE\s+SECTION$"     ,
                @"INPUT-OUTPUT\s+SECTION$"     ,
            };

            //aqui fazemos algumas mudançãs nos nomes das variaveis caso comece com numero tipo 5work
            for (int i = 0; i < divisionAndLines.Count; i++)
            {
                var secLine = divisionAndLines.ElementAt(i);
                if (!commaSections.Any(x => Regex.IsMatch(secLine.Key, x, RegexOptions.None, TimeSpan.FromMilliseconds(500))))
                    continue;

                var allList = secLine.Value;
                for (int j = 0; j < allList.Count; j++)
                {
                    var line = allList[j];

                    //variable Check
                    var rex = Regex.Match(line.Line, @"(^|\s+)\d{2}\s+(?<redef>REDEFINES)*(?<varName>\S+)*");
                    if (rex.Success && string.IsNullOrEmpty(rex.Groups["redef"].Value))
                    {
                        //procurando numeros no inicio da string
                        var varName = rex.Groups["varName"].Value;
                        if (Regex.IsMatch(varName.Trim(), @"^\d+\S+"))
                        {
                            var newVarName = $"N" + varName;
                            line.Line = Regex.Replace(line.Line, varName, newVarName);

                            //PERIGO !!!
                            //alterando todas as linhas que contem este nome
                            for (int k = 0; k < divisionAndLines.Count; k++)
                            {
                                var secToChange = divisionAndLines.ElementAt(k);
                                for (int l = 0; l < secToChange.Value.Count; l++)
                                {
                                    var valueToChange = secToChange.Value[l];
                                    if (Regex.IsMatch(valueToChange.Line, @$"\s+{varName}"))
                                    {
                                        valueToChange.Line = Regex.Replace(valueToChange.Line, $@"\s+{varName}", $@" {newVarName}");
                                        secToChange.Value[l] = valueToChange;
                                    }
                                }

                            }
                        }

                    }
                }
            }

            return ret;
        }

    }
}
