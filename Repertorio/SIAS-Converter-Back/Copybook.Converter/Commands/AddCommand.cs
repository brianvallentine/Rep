using CobolLanguageConverter.Converter.Commands.IF;
using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using DocumentFormat.OpenXml.Presentation;
using Microsoft.CodeAnalysis.RulesetToEditorconfig;
using System;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class AddCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public CobolCommandResponse Execute(string line)
        {
            var output = new StringBuilder();
            var response = new CobolCommandResponse(line);
            var converted = false;

            try
            {
                if (line.StartsWith("ADD "))
                {
                    line = line.Replace("\r\n", " ").Replace("END-RETURN", " ");
                    var matchLine = Regex.Replace(line, @"\s*\(", @"(");
                    matchLine = Regex.Replace(matchLine, @"\s*\)", @")");
                    //var match = Regex.Match(matchLine, @"ADD\s+(?<count>((?<countNum>\d+(,\d+)*)|(\S+)))\s+(TO)(\s+(?<number>\d+(,\d+)*)|(?<variables>(\s+((?:[^GIVING])|\S+(\s+OF\s+\S+)*))+))(\s*(?<isGiving>GIVING)\s+(?<givingVar>\S+))*");
                    //https://regex101.com/r/WPpOMM
                    var match = Regex.Match(matchLine, @"ADD(?<count>\s+((?<countNum>[+-]*\d+(,\d+)*)|\S+))+?(?>\s+TO)(\s+(?<number>\d+(,\d+)*)|(?<variables>\s+[^.]+))");
                    match = !match.Success ? Regex.Match(matchLine, @"ADD(?<variables>(?:\s+\S+)+)\s+(?<isGiving>GIVING)\s+(?<givingVar>\S+)") : match;

                    if (match.Success)
                    {
                        converted = true;
                        var countVar = match.Groups["count"].Value.TrimEnd('.');
                        var variablesString = match.Groups["variables"].Value.Trim();
                        variablesString = Regex.Replace(match.Groups["variables"].Value.Trim(), Environment.NewLine, " ").TrimEnd('.');
                        var isCountNum = !string.IsNullOrEmpty(match.Groups["countNum"].Value);
                        var contVarProp = H.GetReferenceProperty(countVar.Trim(), Result);

                        if (isCountNum)
                            countVar = countVar.Replace(",", ".");

                        //esta modificação contempla casos que a var é uma matrix
                        //ADD 1 TO WTABG-QTDE(WS-PRD WS-TIP WS-SIT)
                        if (Regex.IsMatch(variablesString, @"(?<varname>\S+)\s*\((?<innerVars>[^\)]+)\)\.*"))
                            variablesString = Regex.Replace(variablesString, @"(?<varname>\S+)\s*\((?<innerVars>[^\)]+)\)\.*", m => $"{m.Groups["varname"].Value}({m.Groups["innerVars"].Value.Replace(" ", "___SPACE___")})");

                        //$"{rex.Groups["varname"].Value}({rex.Groups["innerVars"].Value.Replace(" ", "___SPACE___")})";

                        //este caso é o OF, não pode dividir no split
                        //ADD 1 TO ENDERECO-OCORR-ENDERECO OF DCLENDERECOS.
                        var rex = Regex.Match(variablesString, @"(?<varPrinc>\S+)(?<ofName>\s+OF\s+\S+)");
                        if (rex.Success)
                            variablesString = $"{rex.Groups["varPrinc"].Value}{rex.Groups["ofName"].Value}".Replace(" ", "___SPACE___");

                        var isGiving = false;
                        var givingVar = "";

                        var variables = variablesString.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(x => x.TrimEnd('.')).ToList();

                        rex = Regex.Match(matchLine, @"ADD(?<count>\s+((?<countNum>[+-]*\d+(,\d+)*)|\S+))+?(?>\s+TO)(\s+(?<number>\d+(,\d+)*)|(?<variables>\s+[^.]+))(?<isGiving>GIVING)\s+(?<givingVar>\S+)");
                        #region matchGivingSum
                        /*
                        bMatchGivingSum para o cenário abaixo 
                        ADD V1TARI-VRFROBR-IX V1TARI - VRFRFACC - IX V1TARI - VRFRADIC - IX GIVING FAU1-VALFRANQ
                        */
                        bool bMatchGivingSum = false;
                        if (!rex.Success)
                        {
                            bMatchGivingSum = Regex.IsMatch(matchLine, @"ADD(?<variables>(?:\s+\S+)+)\s+(?<isGiving>GIVING)\s+(?<givingVar>\S+)"); 
                            rex = Regex.Match(matchLine, @"ADD(?<variables>(?:\s+\S+)+)\s+(?<isGiving>GIVING)\s+(?<givingVar>\S+)");
                        }
                        #endregion
                        if (rex.Success)
                        {
                            isGiving = !string.IsNullOrEmpty(rex.Groups["isGiving"].Value);
                            givingVar = rex.Groups["givingVar"].Value.TrimEnd('.');
                            variables = variables.TakeWhile(x => x.Trim() != "GIVING").ToList();
                        }

                        var number = match.Groups["number"].Value.TrimEnd('.').Replace(",", ".");
                        var isNumber = !string.IsNullOrEmpty(number);

                        if (isNumber)
                            variables.Add(number);

                        /* possibilidades mapeadas, não há possibilidade de Number e Variable, ou é 1 ou outro
                            - VARIABLE = VARIABLE - COUNT
                            - GIVING   = VARIABLE - COUNT
                            - COUNT    = NUMBER - COUNT
                            - GIVING   = NUMBER - COUNT
                        */

                        foreach (var item in variables)
                        {
                            var variableName = item.Replace("___SPACE___", " ").Replace("END-RETURN", " ");
                            var firstParam = variableName.TrimEnd(',');
                            if (isNumber) firstParam = countVar;
                            if (isGiving) firstParam = givingVar;

                            var firstParamVar = H.GetIfResponseForLine(firstParam, CurrentLine.LineNumber, Result);
                            firstParamVar = !string.IsNullOrEmpty(firstParamVar.ToString()) ? firstParamVar : new StringBuilder(H.GetReferenceProperty(firstParam.Trim(), Result)?.PropertyName);
                            if (firstParamVar != null && ((!isCountNum && isNumber) || !isNumber))
                                firstParam = firstParamVar.ToString() + ".Value ";

                            var secondParam = bMatchGivingSum ? givingVar.TrimEnd(',') : variableName.TrimEnd(',');
                            var secondParamVar = H.GetIfResponseForLine(secondParam, CurrentLine.LineNumber, Result);
                            secondParamVar = !string.IsNullOrEmpty(secondParamVar.ToString()) ? secondParamVar : new StringBuilder(H.GetReferenceProperty(secondParam.Trim(), Result)?.PropertyName);
                            if (secondParamVar != null && !isNumber)
                                secondParam = secondParamVar.ToString();

                            var thirdParam = bMatchGivingSum ? variableName.Trim() : countVar;
                            var thirdParamVar = H.GetIfResponseForLine(thirdParam, CurrentLine.LineNumber, Result);
                            thirdParamVar = !string.IsNullOrEmpty(thirdParamVar.ToString()) ? thirdParamVar : new StringBuilder(H.GetReferenceProperty(thirdParam.Trim(), Result)?.PropertyName);
                            if (thirdParamVar != null && !isCountNum)
                                thirdParam = thirdParamVar.ToString();

                            if (string.IsNullOrEmpty(firstParam) || string.IsNullOrEmpty(secondParam) || string.IsNullOrEmpty(thirdParam))
                            {
                                converted = false;
                                break;
                            }

                            output.AppendLine($"{firstParam} = {secondParam} + {thirdParam};");
                        }
                    }

                    if (converted)
                        response.Executed = true;
                }

                //{
                //    var match = Regex.Match(line, @"(ADD)?\s+(?<count>\S+(\s+OF\s+\S+)*)\s+(TO)\s+(?<variable>.+)");

                //    if (match.Success)
                //    {
                //        var count = match.Groups["count"].Value;
                //        count = count.Replace(",", ".");
                //        var variable = match.Groups["variable"].Value.TrimEnd('.').TrimEnd(',');
                //        var reffer = H.GetReferenceName(variable, Result);
                //        var to = H.GetReferenceName(count, Result);

                //        if (to == null)
                //            to = H.GetIfResponseForLine(count, Result)?.ToString();

                //        if (!string.IsNullOrWhiteSpace(to) && count?.Trim() != to?.Trim())
                //            count = to;

                //        //o IfResponse responde todas variaveis convertidas mesmo que mande um conjunto de 2 variaveis na mesma linha, com isso precisei separa-las
                //        var splitedRef = reffer?.Split(" ");
                //        if (reffer == null)
                //        {
                //            reffer = H.GetIfResponseForLine(variable, Result)?.ToString();
                //            if (reffer != null)
                //                splitedRef = reffer.Split(" ");

                //        }

                //        if (!string.IsNullOrEmpty(reffer) && variable?.Trim() != reffer?.Trim())
                //        {
                //            foreach (var item in splitedRef)
                //                output.AppendLine($"{item}.Value = {splitedRef[0]} + {count};");
                //        }

                //        response.Executed = true;
                //    }
                //}
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
