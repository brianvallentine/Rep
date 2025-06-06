using Cobol.Converter;
using CobolLanguageConverter.Converter.CSHARP;
using CobolLanguageConverter.Converter.DIVISION;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System;
using System.Text;
using System.Xml.Linq;
using IA_ConverterCommons;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;
using CobolLanguageConverter.Converter.Commands.DIVISIONS;
using DocumentFormat.OpenXml.Vml;

namespace CobolLanguageConverter.Converter.Commands.CSHARP
{
    public class CSharp_PROCEDUREPreProcessConverterCommand : ICSharpCommand
    {
        public int Order { get; set; } = 24;
        public ResultSet Result { get; set; }

        public StringBuilder Execute(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            csharpCode = PROCEDUREPreProcess(csharpCode, ref divisionAndLines);
            csharpCode = PROCEDUREPreProcessLines(csharpCode);
            return csharpCode;
        }

        StringBuilder PROCEDUREPreProcess(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            Match rex = null;
            KeyValuePair<string, List<CurrentLineType>>? procDivision = null;
            foreach (var item in divisionAndLines)
            {
                rex = Regex.Match(item.Key, @"^PROCEDURE DIVISION\s*(USING\s+(?<param>(\S|\s)*))*");
                if (rex.Success) { procDivision = item; break; }
                //PROCEDURE DIVISION USING PARAMETROS
            }

            if (!rex.Success || procDivision == null) return csharpCode;

            var sectionName = procDivision.Value.Key;
            var lines = procDivision.Value.Value;

            var lineList = new List<CurrentLineType>();
            var curName = sectionName.Contains(" USING") ? "USING" : "Execute";
            CurrentLineType? lastLineHeader = null;

            // Processar linhas
            foreach (var line in lines)
            {
                //string trimmedLine = line;
                if (curName == "USING" && sectionName.Contains("."))
                {
                    var threatedSectionName = rex.Groups["param"].Value.Trim().TrimEnd('.');

                    Result.ProcedureReference.Add(new CurrentMethodType(curName, line.LineNumber), new List<CurrentLineType> { new CurrentLineType(threatedSectionName, line.LineNumber) });
                    curName = "Execute";
                }

                //verifica se é fim dos parametros, pois pode acontecer de não ter métodos no inicio da procedure division
                if (curName == "USING" && line.Line.Trim().EndsWith('.'))
                {
                    lineList.Add(line);
                    lineList.ForEach(x => x.Line = x.Line.Trim().Replace(",", "").TrimEnd('.'));
                    Result.ProcedureReference.Add(new CurrentMethodType(curName, line.LineNumber), lineList);
                    curName = "Execute";
                    lineList = new List<CurrentLineType>();
                    lastLineHeader = line;
                    continue;
                }

                //verifica se a procedure tem um using na mesma linha do declare
                if (curName == "USING" && sectionName.Contains(" USING"))
                {
                    var splitted = sectionName.Split("USING", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                    if (splitted.Length > 0 && !lineList.Any(x => x.Line == splitted.LastOrDefault()))
                        lineList.Add(new CurrentLineType(splitted.LastOrDefault(), line.LineNumber));
                }

                if (!string.IsNullOrEmpty(line.Line) && line.Line.Length > 6)
                {
                    //       P010-TRATA-CPF-FIM. EXIT.
                    var utilLine = line;
                    // se é final da paramater

                    // Verificar se é início de um bloco de método
                    if (char.IsLetterOrDigit(line.Line[0]))
                    {
                        if (char.IsDigit(line.Line[0]))
                            utilLine.Line = $"{CSharp_CobolLineChangeCommand.ChangedKeyMarker}{line.Line}";

                        //existem métodos escritos na mesma linha, significa que vamos ter que dividir
                        var spliter = lastLineHeader?.Line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)?.Where(x => !x.Equals(".")) ?? new string[0];
                        if (lineList.Count == 0 && spliter?.Count() > 1)
                            lineList.Add(new CurrentLineType(spliter.LastOrDefault(), line.LineNumber));

                        Result.ProcedureReference.Add(new CurrentMethodType(curName, line.LineNumber), lineList);

                        curName = curName == "USING" ? "Execute" : GetMethodName(utilLine.Line);
                        lineList = new List<CurrentLineType>();
                        lastLineHeader = utilLine;
                        continue;
                    }

                    lineList.Add(utilLine);
                }
            }

            Result.ProcedureReference.Add(new CurrentMethodType(curName, lastLineHeader.LineNumber), lineList);

            return csharpCode;
        }

        StringBuilder PROCEDUREPreProcessLines(StringBuilder csharpCode)
        {
            var statements = new List<string> {
                "IF",
                "PERFORM",
                "EVALUATE",
                "MOVE",
                "ADD",
                "INITIALIZE",
                "SUBTRACT",
                "MULTIPLY",
                "DIVIDE",
                "STRING",
                "UNSTRING",
                "DISPLAY ",
                "ACCEPT",
                "READ",
                "WHEN ",
                "WRITE ",
                "REWRITE",
                "DELETE",
                "START",
                "GOBACK",
                "STOP RUN.",
                "STOP RUN",
                "CALL",
                "ELSE",
                "END-IF",
                "END-EVALUATE",
                "GO TO",
                "GO ",
                "EXIT",
                "EXEC SQL",
                "END-PERFORM",
                "COMPUTE",
                "SORT ",
                "INPUT",
                "OUTPUT",
                "RETURN",
                "RELEASE",
                "INSPECT",
                "OPEN",
                "SET",
                "CLOSE",
                "SEARCH",
                "END-SEARCH",
                "CONTINUE",
                "COPY",
                "NOT AT END",
                "NOT END",
                "END-READ",
                "EJECT", //recentemente adicionado, pode ser que quebre algo
                "SKIP1", //recentemente adicionado, pode ser que quebre algo
                " .",
            };

            #region converte as linhas em blocos de comando
            for (int i = 0; i < Result.ProcedureReference.Count; i++)
            {
                var fullCommandLines = new List<CurrentLineType>();
                var commandBlock = new StringBuilder();
                var methodName = Result.ProcedureReference.ElementAt(i).Key.Name;
                var lastLineNumber = 1;
                var compactString = false;
                var jumpEvaluateCommands = false;

                if (methodName == "USING") continue;

                for (int j = 0; j < Result.ProcedureReference.ElementAt(i).Value.Count; j++)
                {
                    var lineRef = Result.ProcedureReference.ElementAt(i).Value[j];
                    var line = lineRef.Line.Trim();
                    lastLineNumber = lineRef.LineNumber - 1;

                    if (string.IsNullOrEmpty(line)) continue;

                    if (Regex.IsMatch(line, @"EJECT")) continue;

                    var ifMatch = Regex.Match(line.Trim(), @"^THEN\s+");
                    if (ifMatch.Success && !Result.IsIn.Contains("EXEC SQL"))
                        line = line.Replace(ifMatch.Value, "");

                    if (Regex.IsMatch(line, @"EXEC\s+SQL") && !jumpEvaluateCommands)
                    {
                        Result.IsIn.Add("EXEC SQL");
                        if (!string.IsNullOrWhiteSpace(commandBlock.ToString()))
                        {
                            fullCommandLines.Add(new CurrentLineType(commandBlock.ToString(), lastLineNumber));
                            commandBlock.Clear();
                        }
                    }

                    if (Regex.IsMatch(line, @"END-EVALUATE"))
                    {
                        jumpEvaluateCommands = false;
                        Result.IsIn.RemoveAll(x => x.Contains("WHEN_CONTROL_"));
                        if (!string.IsNullOrWhiteSpace(commandBlock.ToString()))
                        {
                            fullCommandLines.Add(new CurrentLineType(commandBlock.ToString(), lastLineNumber));
                            commandBlock.Clear();
                            commandBlock.AppendLine(line);
                        }
                        continue;
                    }

                    if (line.StartsWith("SORT ") && !jumpEvaluateCommands)
                    {
                        Result.IsIn.Add("SORT ");
                        if (!string.IsNullOrWhiteSpace(commandBlock.ToString()))
                        {
                            fullCommandLines.Add(new CurrentLineType(commandBlock.ToString(), lastLineNumber));
                            commandBlock.Clear();
                        }
                    }

                    if (line.StartsWith("SEARCH "))
                    {
                        Result.IsIn.Add("SEARCH ");
                        if (!string.IsNullOrWhiteSpace(commandBlock.ToString()))
                        {
                            fullCommandLines.Add(new CurrentLineType(commandBlock.ToString(), lastLineNumber));
                            commandBlock.Clear();
                        }
                    }

                    // para que o WHEN não quebre o código, é preciso considerar a proxima linha, sendo assim
                    if (line.Trim().Contains("WHEN ") && !Result.IsIn.Contains("EXEC SQL") && !Result.IsIn.Contains("SORT ")
                        && !Result.IsIn.Contains("SEARCH ")
                        )
                    {
                        //var matches = Regex.Match(line, @"WHEN\s+('[^']*'|[^\s]+)");
                        var matches = Regex.Match(line, @"WHEN((\s+('[^']*'|[^\s]+)+(?<condition>(.?)+)$)|$)");
                        if (matches.Success)
                        {
                            var whenControl = Regex.Replace(line, @"\s+", " ").Replace("WHEN ", "");

                            //controle feito para impedir linhas do Evaluate de serem adicionadas a listagem quando o when for condição ja existente
                            if (Result.IsIn.Contains($"WHEN_CONTROL_{whenControl}"))
                            {
                                jumpEvaluateCommands = true;
                                continue;
                            }
                            else
                            {
                                //caso esteja vindo de um jump, dar clear nas linhas anteriores
                                //if(jumpEvaluateCommands)
                                //    commandBlock.Clear();

                                jumpEvaluateCommands = false;
                                Result.IsIn.Add($"WHEN_CONTROL_{whenControl}");
                            }

                            var condition = matches.Groups["condition"].Value.Trim();
                            if (statements.Any(x => condition.StartsWith(x, StringComparison.OrdinalIgnoreCase)))
                            {
                                if (!string.IsNullOrWhiteSpace(commandBlock.ToString()))
                                {
                                    fullCommandLines.Add(new CurrentLineType(commandBlock.ToString(), lastLineNumber));
                                    commandBlock.Clear();
                                }

                                fullCommandLines.Add(new CurrentLineType(line.Replace(condition, string.Empty).Trim(), lastLineNumber));
                                fullCommandLines.Add(new CurrentLineType(condition, lastLineNumber));

                                continue;
                            }

                            if (!string.IsNullOrEmpty(commandBlock.ToString()))
                            {
                                fullCommandLines.Add(new CurrentLineType(commandBlock.ToString(), lastLineNumber));
                                commandBlock.Clear();
                            }

                            commandBlock.AppendLine(matches.Value);

                            continue;
                        }

                        //if (!string.IsNullOrEmpty(commandBlock.ToString()))
                        //    fullCommandLines.Add(commandBlock.ToString());

                        //commandBlock.AppendLine(line);
                    }

                    //usado para marcar a string, para não confundir string com comando
                    var marked = H.ToMarkedString(line, out var markedList).Trim();
                    marked = Regex.Replace(marked, @"\s+", " ");
                    var stat = statements.FirstOrDefault(x => marked.StartsWith(x, StringComparison.OrdinalIgnoreCase) || marked == x.Trim());
                    if (stat != null && !Result.IsIn.Contains("EXEC SQL") && !Result.IsIn.Contains("SORT ")
                    //&& !Result.IsIn.Contains("SEARCH ")
                    && !jumpEvaluateCommands
                    )
                    {
                        marked = marked.Replace(stat, stat, StringComparison.OrdinalIgnoreCase);
                        if (!string.IsNullOrWhiteSpace(commandBlock.ToString()))
                        {
                            fullCommandLines.Add(new CurrentLineType(commandBlock.ToString(), lastLineNumber));
                            commandBlock.Clear();
                        }
                    }

                    //tratamento para string que pulava de linha sem a adição de aspas simples
                    if (compactString) // feito para pegar a proxima linha
                    {
                        compactString = false;
                        var tmarked = H.ToUnMarkedString(marked, markedList);
                        tmarked = tmarked.Trim();
                        if (tmarked.FirstOrDefault() == '\'')
                            marked = tmarked.Substring(1);
                    }

                    var considerCompactString = stat == "STRING" && marked.Contains("STRING");
                    considerCompactString = considerCompactString || stat == "MOVE" && marked.Contains("MOVE");

                    if (!jumpEvaluateCommands)
                    {
                        if (considerCompactString && marked.Count(x => x.Equals('\'')) % 2 > 0)
                        {
                            compactString = true;
                            marked = marked.Trim();

                            commandBlock.Append(H.ToUnMarkedString(marked, markedList));
                        }
                        else
                            commandBlock.AppendLine(H.ToUnMarkedString(marked, markedList));
                        //tratamento para string que pulava de linha sem a adição de aspas simples
                    }

                    if (line.Contains("END-EXEC") && !jumpEvaluateCommands)
                    {
                        Result.IsIn.Remove("EXEC SQL");
                        if (!string.IsNullOrWhiteSpace(commandBlock.ToString()))
                        {
                            fullCommandLines.Add(new CurrentLineType(commandBlock.ToString(), lastLineNumber));
                            commandBlock.Clear();
                        }
                    }

                    if (commandBlock.ToString().StartsWith("READ ") && !jumpEvaluateCommands)
                    {
                        var localComBlock = commandBlock.ToString();
                        var inlineReadRegex = Regex.Match(localComBlock, @"\s+AT\s+END");
                        if (inlineReadRegex.Success)
                        {
                            var splitedLine = Regex.Split(localComBlock, @"\s+AT\s+END");
                            var firstLine = splitedLine.FirstOrDefault() + " AT END\r\n";
                            var nextLine = splitedLine.LastOrDefault();

                            fullCommandLines.Add(new CurrentLineType(firstLine, lastLineNumber));
                            commandBlock.Clear();

                            commandBlock.AppendLine(nextLine);
                        }
                    }

                    if (line.Contains(".") && Result.IsIn.Contains("SORT ") && !jumpEvaluateCommands)
                    {
                        Result.IsIn.Remove("SORT ");
                        if (!string.IsNullOrWhiteSpace(commandBlock.ToString()))
                        {
                            fullCommandLines.Add(new CurrentLineType(commandBlock.ToString(), lastLineNumber));
                            commandBlock.Clear();
                        }
                    }

                    if (line.Contains(".") && Result.IsIn.Contains("SEARCH "))
                    {
                        Result.IsIn.Remove("SEARCH ");
                        if (!string.IsNullOrWhiteSpace(commandBlock.ToString()))
                        {
                            if (!commandBlock.ToString().Contains("END-SEARCH"))
                                commandBlock.Replace('.', ' ').AppendLine("END-SEARCH.");

                            fullCommandLines.Add(new CurrentLineType(commandBlock.ToString(), lastLineNumber));
                            commandBlock.Clear();
                        }
                    }
                }

                fullCommandLines.Add(new CurrentLineType(commandBlock.ToString(), lastLineNumber));

                Result.ProcedureReference[Result.ProcedureReference.ElementAt(i).Key] = fullCommandLines.Where(x => !string.IsNullOrWhiteSpace(x.Line)).ToList();
            }

            Result.IsIn.RemoveAll(x => x.Contains("WHEN_CONTROL_"));
            #endregion

            return csharpCode;
        }

        private string GetMethodName(string line, bool cSharpName = true)
        {
            // Extrair o nome do método
            var methodName = Regex.Match(line, @"(\bPERFORM\s*)?(?<NomeDoMetodo>\S+(\s+SECTION)*)\s*\.*").Groups["NomeDoMetodo"].Value.Trim();
            methodName = Regex.Replace(methodName, @"\s+", " ").TrimEnd('.').Trim().Replace(" ", "-");

            if (cSharpName)
                methodName = methodName.Replace("-", "_");

            return methodName;
        }

    }
}
