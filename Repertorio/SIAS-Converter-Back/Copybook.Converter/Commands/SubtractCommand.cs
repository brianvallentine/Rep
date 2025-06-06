using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using Microsoft.CodeAnalysis.Differencing;
using System;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class SubtractCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public CobolCommandResponse Execute(string line)
        {
            var output = new StringBuilder();
            var response = new CobolCommandResponse(line);
            var converted = true;

            try
            {
                if (line.StartsWith("SUBTRACT "))
                {
                    /* Detalhes do comando:
                     * From é obrigatório
                     * 
                     * ANTES do FROM
                     *  - a variavel pode ser qualquer uma inclusive seguida de () ou (1 2)
                     * 
                     * APÓS o FROM
                     *  - pode ser seguido de um GIVING que pode ser variavel ou literal
                     *  - pode ser seguido de uma lista de variaveis que pode ou não contem ROUNDED
                     *  - 
                     */

                    var handlerLine = line.Replace(Environment.NewLine, " ").Replace("SUBTRACT ", "");
                    var splitedFrom = handlerLine.Split(" FROM ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                    var splitedGiving = splitedFrom[1].Split(" GIVING ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                    var isGiving = splitedGiving.Length > 1;
                    var isLengthOf = Regex.IsMatch(splitedGiving[0], @"LENGTH\s+OF\s+");
                    if (isLengthOf)
                    {
                        splitedGiving[0] = Regex.Replace(splitedGiving[0], @"LENGTH\s+OF\s+","");
                        splitedFrom[1] = Regex.Replace(splitedFrom[1], @"LENGTH\s+OF\s+", "");
                    }

                    var countVars = (Regex.Replace(splitedFrom[0], @"\(\s*(?<n1>[-A-z0-9]+)\s+(?<n2>[-A-z0-9]+)\s*\)", @"(${n1}___${n2})")).Split(" ").Select(x => x.TrimEnd('.')).Select(x => x.Replace("___", " ")).ToList();
                    var variablesList = (Regex.Replace(splitedGiving[0], @"\(\s*(?<n1>[-A-z0-9]+)\s+(?<n2>[-A-z0-9]+)\s*\)", @"(${n1}___${n2})")).Split(" ").Select(x => x.TrimEnd('.')).Select(x => x.Replace("___", " ")).ToList();
                    var givingVar = "";
                    if (isGiving)
                        givingVar = string.Join(" ", (Regex.Replace(splitedGiving[1], @"\(\s*(?<n1>[-A-z0-9]+)\s+(?<n2>[-A-z0-9]+)\s*\)", @"(${n1}___${n2})")).Split(" ").Select(x => x.TrimEnd('.')).Select(x => x.Replace("___", " ")));


                    var countVar = string.Join(" ", countVars);
                    var number = double.TryParse(splitedGiving[0], out var pNum) ? splitedGiving[0] : "";
                    var isNumber = !string.IsNullOrEmpty(number);

                    //if (isNumber)
                    //{
                    //    variablesList.Clear();
                    //    variablesList.Add(number);
                    //}

                    /* possibilidades mapeadas, não há possibilidade de Number e Variable, ou é 1 ou outro
                        - VARIABLE = VARIABLE - COUNT
                        - GIVING   = VARIABLE - COUNT
                        - COUNT    = NUMBER - COUNT
                        - GIVING   = NUMBER - COUNT
                    */

                    foreach (var variableName in variablesList)
                    {
                        var firstParam = variableName;
                        if (isNumber) firstParam = countVar;
                        if (isGiving) firstParam = givingVar;

                        var firstParamVar = H.GetIfResponseForLine(firstParam, CurrentLine.LineNumber, Result);
                        if (firstParamVar != null)
                            firstParam = firstParamVar.ToString() + ".Value ";

                        var secondParam = variableName;
                        var secondParamVar = H.GetIfResponseForLine(secondParam, CurrentLine.LineNumber, Result);
                        if (secondParamVar != null && !isNumber)
                            secondParam = !isLengthOf ? secondParamVar.ToString() : secondParamVar.ToString() + ".Value.Length";

                        var thirdParam = countVar;
                        var thirdParamVar = H.GetIfResponseForLine(thirdParam, CurrentLine.LineNumber, Result);
                        if (thirdParamVar != null)
                            thirdParam = thirdParamVar.ToString();

                        if (string.IsNullOrEmpty(firstParam) || string.IsNullOrEmpty(secondParam) || string.IsNullOrEmpty(thirdParam))
                        {
                            converted = false;
                            break;
                        }

                        output.AppendLine($"{firstParam} = {secondParam} - {thirdParam};");
                    }


                    if (converted)
                        response.Executed = true;



                    //var matchLine = Regex.Replace(line, @"\s*\(", @"(");
                    //matchLine = Regex.Replace(matchLine, @"\s*\)", @")");

                    ////https://regex101.com/r/IQJixm/1
                    //var match = Regex.Match(matchLine, @"SUBTRACT\s+(?<count>\S+)\s+(FROM)(\s+(?<number>\d+)|(?<variables>(\s+\S+(?:[^\)])|(?:[^GIVING])*)+\)*))(\s*(?<isGiving>GIVING)\s+(?<givingVar>\S+))*");

                    //if (match.Success)
                    //{
                    //    var countVar = match.Groups["count"].Value.TrimEnd('.');
                    //    var variable = match.Groups["variables"].Value.Trim();
                    //    variable = Regex.Replace(variable, @"\(\s*(?<n1>[-A-z0-9]+)\s+(?<n2>[-A-z0-9]+)\s*\)", @"(${n1}___${n2})");
                    //    var variablesList = (Regex.Replace(variable, Environment.NewLine, " ")).Split(" ").Select(x => x.TrimEnd('.')).Select(x => x.Replace("___", " ")).ToList();
                    //    var number = match.Groups["number"].Value.TrimEnd('.');
                    //    var givingVar = match.Groups["givingVar"].Value.TrimEnd('.');
                    //    var isGiving = !string.IsNullOrEmpty(match.Groups["isGiving"].Value);
                    //    var isNumber = !string.IsNullOrEmpty(number);

                    //    if (isNumber)
                    //    {
                    //        variablesList.Clear();
                    //        variablesList.Add(number);
                    //    }

                    //    /* possibilidades mapeadas, não há possibilidade de Number e Variable, ou é 1 ou outro
                    //        - VARIABLE = VARIABLE - COUNT
                    //        - GIVING   = VARIABLE - COUNT
                    //        - COUNT    = NUMBER - COUNT
                    //        - GIVING   = NUMBER - COUNT
                    //    */

                    //    foreach (var variableName in variablesList)
                    //    {
                    //        var firstParam = variableName;
                    //        if (isNumber) firstParam = countVar;
                    //        if (isGiving) firstParam = givingVar;

                    //        var firstParamVar = H.GetIfResponseForLine(firstParam, CurrentLine.LineNumber, Result);
                    //        if (firstParamVar != null)
                    //            firstParam = firstParamVar.ToString() + ".Value ";

                    //        var secondParam = variableName;
                    //        var secondParamVar = H.GetIfResponseForLine(secondParam, CurrentLine.LineNumber, Result);
                    //        if (secondParamVar != null && !isNumber)
                    //            secondParam = secondParamVar.ToString();

                    //        var thirdParam = countVar;
                    //        var thirdParamVar = H.GetIfResponseForLine(thirdParam, CurrentLine.LineNumber, Result);
                    //        if (thirdParamVar != null)
                    //            thirdParam = thirdParamVar.ToString();

                    //        if (string.IsNullOrEmpty(firstParam) || string.IsNullOrEmpty(secondParam) || string.IsNullOrEmpty(thirdParam))
                    //        {
                    //            converted = false;
                    //            break;
                    //        }

                    //        output.AppendLine($"{firstParam} = {secondParam} - {thirdParam};");
                    //    }
                    //}

                    //if (converted)
                    //    response.Executed = true;
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
