using CobolLanguageConverter.Converter.DIVISION;
using CodeAnalyser.Helper;
using Copybook.Converter;
using FileResolver.Helper;
using IA_ConverterCommons;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.FileSystemGlobbing;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands.DISPLAY
{
    public class DisplayCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public static Dictionary<string, string> EquivalenceList = new Dictionary<string, string> {
            {"ZEROS","0" },
            {"ZEROES","0" },
            {"SPACE",@"''" },
            {"SPACES",@"''" },
        };

        StringBuilder output = new StringBuilder();

        //DONE
        public CobolCommandResponse Execute(string line)
        {
            var response = new CobolCommandResponse(line);

            if (!Regex.IsMatch(line, @"^DISPLAY\s+")) return response;

            var ret = line;
            var allCommands = ConvertHelper.FindCommands<IDisplayCommand>(Assembly.GetExecutingAssembly()).OrderBy(x => x.Order);
            var markedList = new Dictionary<string, string>();

            try
            {
                foreach (var command in allCommands)
                {
                    command.CurrentLine = CurrentLine;
                    command.Result = Result;
                    var exec = command.Execute(ret, ref markedList);
                    ret = exec;
                }

                output.AppendLine(ret);
                response.Executed = true;

            }
            catch (Exception ex)
            {
                var ax = new Exception($"ERRO - DISPLAY - {ex.Message}");
                response.SetError(ax);
            }

            response.SetResponse(output);
            return response;
        }

    }
}

/*
 
        ////DOING
        //void ConvertCobolMoveToCSharp(string line)
        //{
        //    var ret = PreProcessingMove(line, out var markedList); // marcado
        //    ret = ProcessMove(ret);
        //    ret = PostProcessingMove(ret, markedList);

        //    output.AppendLine(ret);
        //}

        ////DONE
        //string PreProcessingMove(string line, out Dictionary<string, string> markedList)
        //{
        //    var ret = PreProcessingCleanMove(line);
        //    ret = PreProcessingVariablesMove(ret, out markedList);

        //    return ret;
        //}

        //string PostProcessingMove(string line, Dictionary<string, string> markedList)
        //{
        //    //var ret = PostProcessingMoveList(line);
        //    var ret = PostProcessingReturnData(line, markedList);
        //    ret = DataValidation(ret);
        //    return ret.Trim();
        //}

        //#endregion

        //string DataValidation(string line)
        //{
        //    var ret = line;

        //    if (ret.Contains(" COMPUTE") || ret.Contains(" COMPUTE,"))
        //        throw new Exception("Linha contém referencia a COMPUTE");

        //    return ret;
        //}




        ////DONE
        //string PreProcessingCleanMove(string line)
        //{
        //    line = line
        //            .Replace("END-STRING", "")
        //            .Replace(Environment.NewLine, " ")
        //            .TrimEnd('.')
        //            ;

        //    return line;
        //}

        ////DONE
        ///// <summary>
        ///// retorna os dados do MOVE de forma MARCADA
        ///// EX: |{0}| |{1}| WS_DADOS, WS_RET_DADOS
        ///// </summary>
        ///// <param name="line"></param>
        ///// <returns></returns>
        //string PreProcessingVariablesMove(string line, out Dictionary<string, string> markedList)
        //{
        //    markedList = new Dictionary<string, string>();
        //    var ret = line;
        //    var isInterpolation = line.Contains("'");

        //    var match = Regex.Match(line, @"MOVE(?<before>.*)\s+TO\s+(?<after>.*)");

        //    if (!match.Success) return ret;

        //    var before = match.Groups["before"].Value.Trim();
        //    var after = match.Groups["after"].Value.Trim();

        //    ret = H.ToMarkedString(before, out markedList);
        //    ret = Regex.Replace(ret, @"\s+", " ");

        //    //converto todas as referencias dentro da lina
        //    var allBeforeItems = ret.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        //    foreach (var item in allBeforeItems)
        //        if (EquivalenceList.ContainsKey(item))
        //            ret = ret.Replace(item, EquivalenceList[item]);

        //    isInterpolation = isInterpolation || ret.Contains("'");

        //    //converto todas as variaveis dentro da linha
        //    allBeforeItems = ret.Replace("(", " ").Replace(")", " ").Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        //    foreach (var item in allBeforeItems)
        //    {
        //        //sem a marca de string
        //        if (H.HasStringMark(item)) continue;

        //        var beforVar = H.GetReferenceProperty(item);
        //        if (beforVar != null)
        //        {
        //            var add = beforVar.PropertyName;
        //            if (isInterpolation)
        //                add = $@"{{{add}}}";

        //            ret = ret.Replace(item, $"{add}");
        //        }
        //    }

        //    //neste momento estamos com as variaveis convertidas do before  (ANTES DO TO)
        //    var allAfterItems = after.Replace("(", " ").Replace(")", " ").Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        //    foreach (var item in allAfterItems)
        //    {
        //        var afterVar = H.GetReferenceProperty(item);
        //        if (afterVar != null)
        //            after = after.Replace(item, afterVar.PropertyName);
        //    }

        //    return $"{ret}{H.CommaMark} {after}";
        //}




        ////DONE
        //string ProcessMove(string line)
        //{
        //    var ret = line;

        //    //tratando FUNCTION CURRENT_DATE(1:10)
        //    if (H.TryCurrentDateTransform(ret, H.HasStringMark(line), out var pLine))
        //        ret = pLine;

        //    //tratando FUNCTION CURRENT_DATE(1:10)
        //    if (H.TryWhenCompileTransform(ret, out var wLine))
        //        ret = wLine;

        //    ret = PostProcessingMoveList(ret);

        //    var splitter = ret.Split(H.CommaMark, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        //    var source = splitter[0];
        //    var destinies = splitter[1];

        //    source = ResolveParenthesisString(source);
        //    destinies = ResolveParenthesisString(destinies);

        //    return ret
        //            .Replace(splitter[0], source)
        //            .Replace(splitter[1], string.Join(", ", destinies.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)))
        //            ;
        //}



        ////DONE
        ///// <summary>
        ///// Método que trata o retorno dos dados, retransformando as diactrics novamente
        ///// </summary>
        ///// <param name="line"></param>
        ///// <param name="markedList"></param>
        ///// <returns></returns>
        //private string PostProcessingReturnData(string line, Dictionary<string, string> markedList)
        //{
        //    var ret = line;
        //    var isInterpolation = H.HasStringMark(ret);
        //    var isSpaces = ret.Split(H.CommaMark, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ElementAtOrDefault(0) != "''";

        //    var splitedBefore = ret.Split(H.CommaMark, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
        //                            ?.ElementAtOrDefault(0)
        //                            ?.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        //    ret = $"{H.ToUnMarkedString(ret.Replace(" ", "").Replace("'", @""""), markedList)}".Replace("'", @"""");
        //    var splited = ret.Split(H.CommaMark, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        //    var qf = FileResolverHelper.Conf.ProjectQualifierGeneralCommands;

        //    if (isInterpolation && isSpaces && splitedBefore.Length > 1)
        //        ret = $"$\"{splited[0].Replace(@"""", "")}\"\n.Move({splited[1]});";
        //    else
        //        ret = $"{qf}.Move({splited[0]}, {splited[1]});";

        //    return ret;
        //}

        ////DONE
        ///// <summary>
        ///// processa variaveis de LISTA no COBOL
        ///// </summary>
        ///// <param name="line"></param>
        ///// <returns></returns>
        //string PostProcessingMoveList(string line)
        //{
        //    var ret = line.Replace(" (", "(");
        //    var matchRs = Regex.Matches(ret, @"\S*\((?<initial>[\s]*\d+[\s]*)\)");
        //    var valueRs = Regex.Matches(ret, @"\S*\((?<values>[\s]*\S+[\s]*)\)");

        //    if (matchRs.Count > 0 || valueRs.Count > 0)
        //    {
        //        foreach (Match matchR in valueRs)
        //        {
        //            var testResult = matchR.Value.Replace(" ", "").Replace("\n", "").Trim();
        //            var isInvalidString =
        //                               testResult == "()"
        //                            || testResult.Contains("=")
        //                            || testResult.Contains("||")
        //                            || testResult.Contains("_.")
        //                            || testResult.Contains("!")
        //                            || testResult.Contains(",")
        //                        ;

        //            if (isInvalidString) return line;

        //            var substringVariableR = Regex.Match(testResult, @"\S+\(");
        //            var varProcess = substringVariableR.Value.Replace("(", "").Split(".", StringSplitOptions.RemoveEmptyEntries);
        //            if (!varProcess.Any()) return line;

        //            var considerStringbasis = false;
        //            for (int i = varProcess.Length; i > 0; i--)
        //            {
        //                try
        //                {
        //                    var refferProp = H.GetReferenceProperty(varProcess.Take(i).Last());
        //                    if (considerStringbasis && refferProp.PropertyType == typeof(StringBasis).Name.ToString())
        //                    {
        //                        ret = ret.Replace(matchR.Value, $"{refferProp.PropertyName}.Substring({matchR.Groups["values"].Value})");
        //                        break;
        //                    }

        //                    if (refferProp.PropertyType.Contains("ListBasis") == true)
        //                    {
        //                        ret = ret.Replace(matchR.Value, $"{refferProp.PropertyName}[{matchR.Groups["values"].Value.Trim()}]");
        //                        break;
        //                    }
        //                }
        //                catch (NullReferenceException ex)
        //                {
        //                    if (considerStringbasis) throw;

        //                    i = varProcess.Length + 1;
        //                    considerStringbasis = true;
        //                }
        //            }

        //        }

        //        foreach (Match matchR in matchRs)
        //        {
        //            var testResult = matchR.Value.Replace(" ", "").Replace("\n", "").Trim();
        //            var isInvalidString =
        //                               testResult == "()"
        //                            || testResult.Contains("=")
        //                            || testResult.Contains("||")
        //                            || testResult.Contains("_.")
        //                            || testResult.Contains("!")
        //                            || testResult.Contains(",")
        //                        ;

        //            if (isInvalidString) return line;

        //            var substringVariableR = Regex.Match(testResult, @"\S+\(");
        //            var varProcess = substringVariableR.Value.Replace("(", "").Split(".", StringSplitOptions.RemoveEmptyEntries);
        //            if (!varProcess.Any()) return line;

        //            var considerStringbasis = false;
        //            for (int i = varProcess.Length; i > 0; i--)
        //            {
        //                try
        //                {
        //                    var refferProp = H.GetReferenceProperty(varProcess.Take(i).Last());
        //                    if (considerStringbasis && refferProp.PropertyType == typeof(StringBasis).Name.ToString())
        //                    {
        //                        ret = ret.Replace(matchR.Value, $"{refferProp.PropertyName}.Substring({matchR.Groups["initial"].Value})");
        //                        break;
        //                    }

        //                    if (refferProp.PropertyType.Contains("ListBasis"))
        //                    {
        //                        testResult = testResult.Replace("(", "[").Replace(")", "]");
        //                        ret = ret.Replace(matchR.Value, testResult);
        //                        break;
        //                    }
        //                }
        //                catch (NullReferenceException ex)
        //                {
        //                    if (considerStringbasis) throw;

        //                    i = varProcess.Length + 1;
        //                    considerStringbasis = true;
        //                }
        //            }
        //        }
        //    }

        //    return ret;
        //}

        //string ResolveParenthesisString(string line)
        //{
        //    var ret = line;
        //    var matchRs = Regex.Matches(ret, @"[\s]*\((?<initial>[\s]*\d+[\s]*):(?<final>[\s]*\d+[\s]*)\)");
        //    if (matchRs.Count > 0)
        //    {
        //        var matchR = matchRs[0];
        //        var validLineRx = Regex.Match(ret, @"[\S|\s]*\((?<initial>[\s]*\d+[\s]*):(?<final>[\s]*\d+[\s]*)\)");
        //        if (validLineRx.Value.Contains("Substring")) return line;

        //        var testResult = matchR.Value.Replace(" ", "").Replace("\n", "").Trim();
        //        var isInvalidString =
        //                           testResult == "()"
        //                        || testResult.Contains("=")
        //                        || testResult.Contains("||")
        //                        || testResult.Contains("!")
        //                        || testResult.Contains(",")
        //                    ;

        //        if (isInvalidString) return line;

        //        var match = matchR.Value;
        //        var indexOf = ret.IndexOf(match);
        //        if (indexOf < 0) return line;

        //        var pattern = @$"\S+{match.Replace(")", @"\)").Replace("(", @"\(").Replace(".", @"\.")}";
        //        var substringVariableR = Regex.Match(ret, pattern);
        //        var substringVariable = substringVariableR.Value.Replace(match, "");
        //        var varProcess = substringVariable.Split(".", StringSplitOptions.RemoveEmptyEntries);
        //        if (!varProcess.Any()) return line;

        //        var initial = int.TryParse(matchR.Groups["initial"].Value, out var pIni) ? pIni : -1;
        //        var final = int.TryParse(matchR.Groups["final"].Value, out var pFim) ? pFim : -1;

        //        var parameter = $"{(initial <= 1 ? "" : $"{initial - 1},")}{(final == -1 ? "" : final)}";
        //        var considerStringbasis = false;
        //        for (int i = varProcess.Length; i > 0; i--)
        //        {
        //            try
        //            {
        //                var refferProp = H.GetReferenceProperty(varProcess.Take(i).Last());
        //                if (considerStringbasis && refferProp.PropertyType == typeof(StringBasis).Name.ToString())
        //                {
        //                    ret = ret.Replace(matchR.Value, $".Substring({parameter})");
        //                    break;
        //                }

        //                if (refferProp.PropertyType.Contains("ListBasis"))
        //                {
        //                    ret = ret.Replace(substringVariable, refferProp.PropertyName);
        //                    ret = ret.Replace(match, match.Replace("(", "[").Replace(")", "]"));
        //                    break;
        //                }
        //            }
        //            catch (NullReferenceException ex)
        //            {
        //                if (considerStringbasis) throw;

        //                i = varProcess.Length + 1;
        //                considerStringbasis = true;
        //            }
        //        }
        //    }

        //    return ret;
        //}
 */