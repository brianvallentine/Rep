using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using FileResolver.Helper;
using IA_ConverterCommons;
using Microsoft.Build.Tasks;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.CodeAnalysis.Elfie.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Text;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class ComputeCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public CobolCommandResponse Execute(string line)
        {
            var output = new StringBuilder();
            var response = new CobolCommandResponse(line);
            var qf = FileResolverHelper.Conf.ProjectQualifierGeneralCommands;

            try
            {
                var tst = Regex.Replace(line, @"\s+", " ").Trim();
                if (tst.StartsWith("COMPUTE "))
                {
                    bool matchSizeErrorDisplay = Regex.Match(line, @"ON\s+SIZE\s+ERROR\s+DISPLAY\s\'+([A-Z0-9-]+)+\sERRO\s\=\s\'\s+([A-Z0-9-]+)\s\'\s\'\s+([A-Z0-9-]+)").Success;

                    var withoutSizeError = Regex.Replace(tst, @"ON\s+SIZE\s+ERROR\s+MOVE\s+ZEROS\s+TO\s+([A-Z0-9-]+)\s+END-COMPUTE", "");
                    var withoutSizeErrorDisplay = Regex.Replace(tst, @"ON\s+SIZE\s+ERROR\s+DISPLAY\s\'+([A-Z0-9-]+)+\sERRO\s\=\s\'\s+([A-Z0-9-]+)\s\'\s\'\s+([A-Z0-9-]+)\sMOVE\s\+([0-9-]+)\sTO\s+([A-Z0-9-]+)\sEND-COMPUTE", "");
                    var rex = !matchSizeErrorDisplay ? Regex.Match(withoutSizeError, @"^COMPUTE\s+(?<computation>.+)$") : Regex.Match(withoutSizeErrorDisplay, @"^COMPUTE\s+(?<computation>.+)$");

                    if (!rex.Success) throw new Exception("COMPUTE não encontrado...");
                    var sizeErro = Regex.IsMatch(tst, @"ON\s+SIZE\s+ERROR");
                    //if (sizeErro) throw new Exception("COMPUTE precisa ser treinado...");
                    if (sizeErro)
                    {
                        var varMovZeroes = Regex.Match(tst, @"(?<=ON\s+SIZE\s+ERROR\s+MOVE\s+ZEROS\s+TO\s+)[A-Z0-9-]+(?=\s+END-COMPUTE)");
                        if (varMovZeroes.Success)
                        {
                            //expressão regular anterior
                            //var hasSum = Regex.IsMatch(tst, @"\w+\s*\+\s*\w+");
                            var hasSumOrSubtract = Regex.IsMatch(tst, @"\(\s*\w+(?:-\w+)*\s*[\+\-]\s*\w+(?:-\w+)*\s*\)");
                            Match sumOrDivMatch;
                            Match nestedDivMatch;
                            Match varMove;
                            if (!hasSumOrSubtract)
                            {
                                var hasDivTotal = Regex.IsMatch(tst, @"\(\w+\)\s*\/\s*\w+") || Regex.IsMatch(tst, @"(?:\([\w-]+\)|[\w-]+)\s*/\s*[\w-]+") || Regex.IsMatch(tst, @"\([\w-]+\s*\*\s*100\)\s*\/\s*\w+");
                                if (hasDivTotal)
                                {
                                    /*  
                                      COMPUTE WPCT-PROP-COM-RMO ROUNDED =                           
                                            (WVLR-COMCOSG-RMO * 100) /                             
                                            (WVLR-BASE-COMS *(WPRM-TARIF-RMO / WPRM-TARIF-TOT))   
                                            ON SIZE ERROR MOVE ZEROS TO WPCT-PROP-COM-RMO             
                                     END-COMPUTE 
                                    */
                                    //nestedDivMatch atende divisão aninhada com o regex abaixo
                                    nestedDivMatch = Regex.Match(tst, @"\(\s*([^)]+?)\s*\)\s*([\/])\s*\(\s*([\w-]+)\s*\*\s*\(\s*([\w-]+)\s*\/\s*([\w-]+)\s*\)\s*\)");
                                    if (!nestedDivMatch.Success)
                                    {
                                        sumOrDivMatch = Regex.Match(tst, @"\(\s*([^()]+?\(\w+\)+?)\s*([\/])\s*([^()]+?)\)");
                                        if (!sumOrDivMatch.Success) sumOrDivMatch = Regex.Match(tst, @"([\w-]+)\s*([\/])\s*([\w-]+)");
                                        if (!sumOrDivMatch.Success) sumOrDivMatch = Regex.Match(tst, @"\(\s*([^)]+?)\s*\)\s*([\/])\s*([\w-]+)");


                                        var varA = H.GetReferenceProperty(sumOrDivMatch.Groups[3].Value.Trim(), Result);
                                        var varB = H.GetReferenceProperty(varMovZeroes.Value.Trim(), Result);
                                        var Ifmove = "if( " + varA.PropertyName.Trim() + ".Value == 0)\n" +
                                        "          _.Move( 0 ," + varB.PropertyName.Trim() + " );\n" +
                                        "else\n";

                                        output.AppendLine($"{Ifmove}");
                                    }
                                    else
                                    {
                                        //nestedDivMatch => divisão aninhada
                                        var varA1 = H.GetReferenceProperty(nestedDivMatch.Groups[3].Value.Trim(), Result);
                                        var varA2 = H.GetReferenceProperty(nestedDivMatch.Groups[4].Value.Trim(), Result);
                                        var varA3 = H.GetReferenceProperty(nestedDivMatch.Groups[5].Value.Trim(), Result);
                                        var varB = H.GetReferenceProperty(varMovZeroes.Value.Trim(), Result);
                                        var Ifmove = "if( " + varA1.PropertyName.Trim() + ".Value == 0 || "  + varA2.PropertyName.Trim() +".Value == 0 || " + varA3.PropertyName.Trim() + ".Value == 0)\n" +
                                        "          _.Move( 0 ," + varB.PropertyName.Trim() + " );\n" +
                                        "else\n";

                                        output.AppendLine($"{Ifmove}");
                                    }
                                }
                                else
                                {

                                    var regexContent = Regex.Match(tst, @"=\s*\(([^()]+(?:\([^\)]+\))?[^()]+)\)");
                                    string result = Regex.Replace(regexContent.Value, @"\(([^()]*?)\)", "$1");
                                    var hasDiv = Regex.IsMatch(result, @"\(\s*[^()]*\s*/\s*[^()]*\s*\)");
                                    if (hasDiv)
                                    {
                                        var div = Regex.IsMatch(tst, @"\w+\s*/\s*\w+");
                                        sumOrDivMatch = Regex.Match(result, @"\(\s*([^()]+?)\s*([\+/])\s*([^()]+?)\s*\)");
                                        var varA = H.GetReferenceProperty(sumOrDivMatch.Groups[1].Value.Trim(), Result);
                                        var varB = H.GetReferenceProperty(sumOrDivMatch.Groups[3].Value.Trim(), Result);
                                        var varC = H.GetReferenceProperty(varMovZeroes.Value.Trim(), Result);

                                        var Ifmove = "if( " + varA.PropertyName.Trim() + ".Value + " + varB.PropertyName.Trim() + ".Value == 0)\n" +
                                    "          _.Move( 0 ," + varC.PropertyName.Trim() + " );\n" +
                                    "else\n";

                                        output.AppendLine($"{Ifmove}");

                                    }
                                }
                            }
                            else
                            {

                                var parenMatches = Regex.Matches(tst, @"\((?>[^()]+|(?<Open>\()|(?<-Open>\)))*(?(Open)(?!))\)");
                                var moveMatch = Regex.Match(tst, @"MOVE\s+ZEROS\s+TO\s+([\w\-]+)", RegexOptions.IgnoreCase);
                                foreach (Match m in parenMatches)
                                {
                                    var content = m.Value; 
                                    int index = tst.IndexOf(content);
                                    string before = tst.Substring(0, index); 

                                    // Caso 1: Soma ou Subtração dentro dos parênteses
                                    var sumOrSub = Regex.Match(content, @"\(\s*([\w\-]+)\s+([\+\-])\s+([\w\-]+)\s*\)");
                                    if (sumOrSub.Success && moveMatch.Success)
                                    {
                                        var varA = H.GetReferenceProperty(sumOrSub.Groups[1].Value.Trim(), Result);
                                        var varB = H.GetReferenceProperty(sumOrSub.Groups[3].Value.Trim(), Result);
                                        var op = sumOrSub.Groups[2].Value.Trim();
                                        var varC = H.GetReferenceProperty(moveMatch.Groups[1].Value.Trim(), Result);

                                        output.AppendLine(
                                            $"if( {varA.PropertyName}.Value {op} {varB.PropertyName}.Value == 0)\n" +
                                            $"          _.Move(0, {varC.PropertyName});\n" +
                                            $"else\n"
                                        );
                                        break;
                                    }

                                    // Caso 2: Apenas uma variável entre parênteses, mas NÃO se for parte de uma divisão/multiplicação
                                    var singleVar = Regex.Match(content, @"\(\s*([\w\-]+)\s*\)");
                                    if (singleVar.Success && moveMatch.Success)
                                    {
                                        // verifica se há uma divisão ou multiplicação logo antes do parêntese
                                        if (!Regex.IsMatch(before.TrimEnd(), @"[/\*]\s*$"))
                                        {
                                            var varA = H.GetReferenceProperty(singleVar.Groups[1].Value.Trim(), Result);
                                            var varC = H.GetReferenceProperty(moveMatch.Groups[1].Value.Trim(), Result);

                                            output.AppendLine(
                                                $"if( {varA.PropertyName}.Value == 0)\n" +
                                                $"          _.Move(0, {varC.PropertyName});\n" +
                                                $"else\n"
                                            );
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            var varDisplayZeros = Regex.Match(tst, @"(?<=COMPUTE\s+([A-Z0-9-]+)\sROUNDED\s\=\s\(+([A-Z0-9-]+)\s\*\s+([0-9-]+)\)\s\/\s+)[A-Z0-9-]+(?=\s+ON\s+SIZE)");
                            if (varDisplayZeros.Success)
                            {
                                //montar o display
                                Match sumOrDivMatch = Regex.Match(tst, @"DISPLAY\s*\'([^()]+?)\s+ERRO\s*\=\s*\'\s*([^()]+?)\s*\'\s\'\s([^()]+?)+");
                                var varDivZero = H.GetReferenceProperty(varDisplayZeros.Value.Trim(), Result);
                                var varA = H.GetReferenceProperty(sumOrDivMatch.Groups[1].Value.Trim(), Result);
                                var varB = H.GetReferenceProperty(sumOrDivMatch.Groups[2].Value.Trim(), Result);
                                var display = "if( " + varDivZero.PropertyName.Trim() + ".Value == 0)\n" +
                                               "{\n          _.Display($\"" + varA.PropertyName.Trim() + " ERRO = " +
                                               "{" + varB.PropertyName.Trim() + "} " + " {" + varDivZero.PropertyName.Trim() + "}" + "\");\n" +
                                               "          _.Move( 0 ," + varA.PropertyName.Trim() + " );\n}" +

                                               "else\n";

                                output.AppendLine($"{display}");
                            }
                            else
                            {
                                throw new Exception("COMPUTE precisa ser treinado...");
                            }
                        }
                    }
                    var markedList = new Dictionary<string, string>();
                    var computation = rex.Groups["computation"].Value.Trim().TrimEnd('.').Replace(",", ".");
                    bool matchMod = Regex.Match(computation, @"FUNCTION\s+MOD").Success;
                    bool matchIntOfDate = Regex.Match(computation, @"FUNCTION\s+INTEGER-OF-DATE").Success;

                    computation = computation.Replace(")", " ) ");
                    computation = computation.Replace("/", " / ");
                    computation = computation.Replace("(", " ( ");
                    computation = computation.Replace(" ROUNDED ", " ");
                    computation = computation.Replace(" FUNCTION MOD ", " ");
                    computation = computation.Replace(" FUNCTION INTEGER-OF-DATE ", " ");
                    computation = computation.Replace(" EQUAL ", " = ");
                    computation = computation.Replace(" END-COMPUTE", "");
                    //nova condição para resolver COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER-STA =
                    //removendo o OF REG-TRAILLER-STA
                    computation = Regex.Replace(computation, @"(?<v1>\S+)\s+OF\s+(?<of>\S+)", @"${v1}__OF__${of}");
                    computation = Regex.Replace(computation, @"FUNCTION\s+LENGTH\s*\(\s*(?<v1>\S+)\s*\)", @"FUNCTION__LENGTH__(${v1})");

                    //trecho que faz o COMPUTE múltiplo 
                    //COMPUTE WS-COD-PES-ATU BI0003L-S-COD-PES =(WS-COD-PES-ATU + 001)
                    var matchDuo = Regex.Match(tst, @"COMPUTE\s([A-Z0-9-]+)\s+([A-Z0-9-]+)\s+\=\s+\(([A-Z0-9-]+)\s+\+\s([0-9-]+)\)").Success
                                || Regex.Match(tst, @"COMPUTE\s([A-Z0-9-]+)\s([A-Z0-9-]+)\s\=\s([A-Z0-9-]+)\s+\+\s([0-9-]+)").Success;

                    if (matchDuo)
                    {
                        var splittedMult = computation.Split('=', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).OrderByDescending(x => x.Length).Distinct().ToList();

                        var splitFirst = splittedMult.FirstOrDefault();
                        var lst = Regex.Matches(splitFirst, @"[A-z0-9-]+");
                        for (int i = lst.Count - 1; i >= 0; i--)
                        {
                            computation = lst[i].Value + " = " + splittedMult[1].Trim();
                            computation = Regex.Replace(computation, @"\s+", " ");
                            var splittedSpace = computation.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).OrderByDescending(x => x.Length).Distinct().ToList();
                            for (int x = 0; x < splittedSpace.Count; x++)
                            {
                                var item = splittedSpace[x];
                                var toReplace = splittedSpace[x];
                                item = item.Replace("__", " ");
                                if (H.HasStringMark(item)) continue;
                                var varRef = H.GetReferenceProperty(item, Result, true);
                                var varName = varRef?.PropertyName;

                                if (varName == null) continue;

                                var rexFirst = Regex.Match(computation, @$"^{toReplace.Replace("(", "\\(").Replace(")", "\\)")}");
                                if (rexFirst.Success)
                                {
                                    //condição nova 05-09-2024, / 300"f" foi adicionado em casos que não seja "intbasis"
                                    if (varRef.PropertyType != typeof(IntBasis).Name)
                                    {
                                        var matchDivisions = Regex.Matches(computation, @"/\s*(?<firstArgument>\d+(\.\d+)*)");
                                        foreach (Match matchDivision in matchDivisions.Where(x => x.Success))
                                        {
                                            var firstA = matchDivision.Groups["firstArgument"].Value.Trim();
                                            computation = computation.Replace(matchDivision.Value, "/" + firstA + "f");
                                        }
                                    }

                                    //condição nova 12-11 / foi adicionado valor "toString"
                                    if (varRef.PropertyType == typeof(StringBasis).Name)
                                    {
                                        var matchBeforeEqual = Regex.Match(computation, $@"{item}\s*=");
                                        if (matchBeforeEqual.Success)
                                        {
                                            computation = Regex.Replace(computation, @$"^{toReplace.Replace("(", "\\(").Replace(")", "\\)")}\s*=", H.Mark($"{varName}.Value", ref markedList) + " = ( ");
                                            computation = computation + " ).ToString()";
                                        }
                                    }
                                    computation = Regex.Replace(computation, @$"^{toReplace.Replace("(", "\\(").Replace(")", "\\)")}", H.Mark($"{varName}.Value", ref markedList));
                                }
                                var toMark = varName;
                                computation = computation.Replace(toReplace, H.Mark($"{toMark}", ref markedList));
                            }
                            computation = H.ToUnMarkedString(computation, markedList);
                            output.AppendLine($"{computation};");
                            response.Executed = true;
                        }
                    }
                    else
                    {
                        computation = Regex.Replace(computation, @"\s+", " ");

                        var matchPow = Regex.Match(computation, @"(\()*\s*(?<firstArgument>\S+)\s+\*\*\s+(?<secondArgument>\S+)\s*(\))*");
                        if (matchPow.Success)
                        {
                            var firstA = matchPow.Groups["firstArgument"].Value.Trim();
                            var secA = matchPow.Groups["secondArgument"].Value.Trim();

                            var firstAVar = H.GetReferenceName(firstA, Result);
                            var secAAVar = H.GetReferenceName(secA, Result);

                            if (firstAVar != null) firstA = firstAVar;
                            if (secAAVar != null) secA = secAAVar;

                            var toPow = $"(int)Math.Pow({firstA},{secA})";

                            computation = computation.Replace(matchPow.Value, H.Mark(toPow, ref markedList));
                        }

                        var splitted = computation.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).OrderByDescending(x => x.Length).Distinct().ToList();
                        var beforeEqual = true;
                        //var isFirstToPutValue = true;
                        for (int i = 0; i < splitted.Count; i++)
                        //foreach (var item in splitted.Distinct())
                        {
                            var item = splitted[i];
                            var toReplace = splitted[i];

                            if (matchMod && i == 1) computation = computation.Replace(item, item + " %");

                            if (matchIntOfDate && i == 0) computation = computation.Replace(item, "(DateTime.ParseExact(" + item + ".ToString(), \"yyyyMMdd\", null) - new DateTime(1600, 12, 31)).Days");

                            if (item == "=" && beforeEqual) beforeEqual = false;

                            item = item.Replace("__", " ");
                            if (H.HasStringMark(item)) continue;

                            //Comando Compute Length
                            //COMPUTE  WS-JV1-LGTH-INI = FUNCTION LENGTH(SVA-COD-CEDENTE).
                            var rexFunc = Regex.Match(item, @"FUNCTION\s+LENGTH\s*\(\s*(?<v1>\S+)\s*\)");
                            if (rexFunc.Success)
                            {
                                var v1 = rexFunc.Groups["v1"].Value;
                                var varRefv1 = H.GetReferenceProperty(v1, Result);

                                computation = computation.Replace(toReplace, H.Mark($"{varRefv1.PropertyName}.Value.Length", ref markedList));
                                continue;
                            }
                            //COMPUTE  WS-JV1-LGTH-INI = FUNCTION LENGTH(SVA-COD-CEDENTE).

                            var lenRex = Regex.Match(item.Trim(), @"^LENGTH\s+OF\s+");
                            var isLength = lenRex.Success;
                            if (isLength)
                                item = item.Replace(lenRex.Value, "");

                            var varRef = H.GetReferenceProperty(item, Result, true);
                            var varName = varRef?.PropertyName;
                            if (item.Contains("-") && item != "-" && varName == null)
                            {
                                var isInteger = int.TryParse(item, out var pInt);
                                if (isInteger) continue;

                                if (item == "NUMVAL-C") continue;

                                throw new Exception($"provavel variavel não encontrada :> {item}");
                            }

                            if (varName == null) continue;

                            //COMPUTE WS-TAM = LK-NUM-POS-FIM-2064(WS-IND) - LK-NUM-POS-INI-2064(WS-IND) + 1 
                            var rexInds = Regex.Matches(computation.Replace(" ", ""), @$"{item}\((?<varInd>\S*?)\)");
                            foreach (var rexInd in rexInds.Where(x => x.Success))
                            {
                                //var RexComp = Regex.Match(computation.Replace(" ", ""), @$"{item}\((?<varInd>\S*?)\)");
                                var varInd = rexInd.Groups["varInd"].Value;
                                var indVar = H.GetReferenceName(varInd, Result);
                                if (indVar == null) indVar = varInd;

                                var localVarname = varName;
                                var lastDot = localVarname.Split(".").Last();

                                var lastDotProp = H.GetReferenceProperty(lastDot, Result);
                                if (lastDotProp.PropertyType.Contains("ListBasis")) localVarname = localVarname.Replace($".{lastDot}", $".{lastDot}[{indVar}]");
                                else localVarname = localVarname.Replace($".{lastDot}", $"[{indVar}].{lastDot}");

                                var localRepl = $"{toReplace} ( {varInd} )";
                                var toRepl = beforeEqual ? $"{localVarname}.Value" : $"{localVarname}";
                                computation = computation.Replace(localRepl, H.Mark(toRepl, ref markedList));

                            }

                            var rexFirst = Regex.Match(computation, @$"^{toReplace.Replace("(", "\\(").Replace(")", "\\)")}");
                            if (rexFirst.Success)
                            {
                                //condição nova 05-09-2024, / 300"f" foi adicionado em casos que não seja "intbasis"
                                if (varRef.PropertyType != typeof(IntBasis).Name)
                                {
                                    var matchDivisions = Regex.Matches(computation, @"/\s*(?<firstArgument>\d+(\.\d+)*)");
                                    foreach (Match matchDivision in matchDivisions.Where(x => x.Success))
                                    {
                                        var firstA = matchDivision.Groups["firstArgument"].Value.Trim();
                                        computation = computation.Replace(matchDivision.Value, "/" + firstA + "f");
                                    }
                                }

                                //condição nova 12-11 / foi adicionado valor "toString"
                                if (varRef.PropertyType == typeof(StringBasis).Name)
                                {
                                    var matchBeforeEqual = Regex.Match(computation, $@"{item}\s*=");
                                    if (matchBeforeEqual.Success)
                                    {
                                        computation = Regex.Replace(computation, @$"^{toReplace.Replace("(", "\\(").Replace(")", "\\)")}\s*=", H.Mark($"{varName}.Value", ref markedList) + " = ( ");
                                        computation = computation + " ).ToString()";
                                    }
                                }

                                computation = Regex.Replace(computation, @$"^{toReplace.Replace("(", "\\(").Replace(")", "\\)")}", H.Mark($"{varName}.Value", ref markedList));
                            }

                            var toMark = varName;
                            if (isLength)
                                toMark = $"{varName}.Pic.Length";

                            computation = computation.Replace(toReplace, H.Mark($"{toMark}", ref markedList));
                            computation = computation.Replace("FUNCTION NUMVAL-C", $"{qf}.NumValC");
                            computation = computation.Replace("FUNCTION NUMVAL", $"{qf}.NumVal");
                        }
                        computation = H.ToUnMarkedString(computation, markedList);

                        output.AppendLine($"{computation};");

                        response.Executed = true;
                    }
                }
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            response.SetResponse(output);
            return response;
        }
    }
}
