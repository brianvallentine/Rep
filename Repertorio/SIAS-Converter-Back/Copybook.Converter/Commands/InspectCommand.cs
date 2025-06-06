using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Presentation;
using FileResolver.Helper;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class InspectCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        StringBuilder output = new StringBuilder();
        CobolCommandResponse response;

        public CobolCommandResponse Execute(string line)
        {
            response = new CobolCommandResponse(line);

            try
            {
                if (Regex.IsMatch(line, @"^\s*INSPECT\b", RegexOptions.IgnoreCase))
                {
                    InspectTallying(line);
                    InspectTallyingAllSlash(line);
                    InspectReplacingBy(line);
                    InspectConvertingToUpper(line);
                    InspectConvertingLowValues(line);
                
                if (!response.Executed)
                    InspectConvertingToVarArray(line);
                }
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            response.SetResponse(output);
            return response;
        }

        private void InspectReplacingBy(string line)
        {
            //INSPECT WS-TXT-NUM REPLACING ALL ' ' BY '0'
            //INSPECT LC11-LINHA11 REPLACING ALL ';' BY ' '        

            var match = Regex.Match(line.Trim().TrimEnd('.').Trim(), @"^INSPECT\s*(?<varname>\S+)\s*REPLACING\s*ALL\s*(('(?<allVar>[^']+)')|(LOW-VALUES))\s*BY\s*(('(?<byVar>[^']+)')|(SPACES))$");
            if (match.Success)
            {
                var qf = FileResolverHelper.Conf.ProjectQualifierGeneralCommands;
                var varname = match.Groups["varname"].Value;
                var allVar = match.Groups["allVar"].Value;
                var byVar = match.Groups["byVar"].Value;
                var varRef = H.GetReferenceName(varname, Result);

                if (!match.Value.Contains("LOW-VALUE"))
                {
                    output.AppendLine($"{varRef}.Replace(\"{allVar}\",\"{byVar}\");");
                }

                response.Executed = true;
            }
        }
        private void InspectTallyingAllSlash(string line)
        {
            //INSPECT USUARIO-REG TALLYING WS-TALLYING FOR ALL '/'
            var match = Regex.Match(line.Trim(), @"^INSPECT\s+(?<sourcevar>[-A-a0-9]+)*\s+TALLYING\s+(?<resultvar>\S+)\s+FOR\s+ALL\s+(?<leadingvar>.+)$");

            if (match.Success)
            {
                var sourcevar = match.Groups["sourcevar"].Value;
                var resultvar = match.Groups["resultvar"].Value;
                var leadingvar = match.Groups["leadingvar"].Value.Trim().TrimEnd('.');

                var sourceVarName = H.GetReferenceName(sourcevar, Result);
                if (sourceVarName == null)
                    throw new Exception($"nome não encontrado :> {sourcevar}");

                var leadingVarName = H.GetReferenceName(leadingvar, Result);
                if (leadingVarName == null)
                {
                    leadingVarName = Regex.Replace(leadingvar, @"/", @"/");
                }

                var resultVarName = H.GetReferenceName(resultvar, Result);
                if (resultVarName == null)
                    throw new Exception($"nome não encontrado :> {resultvar}");

                output.AppendLine($"{resultVarName}.Value = {sourceVarName}.ToString().TakeWhile(x => x == {leadingVarName}).Count();");
                response.Executed = true;
            }
        }

        private void InspectTallying(string line)
        {
            //INSPECT LKE-NOME-FAVORECIDO-007 TALLYING WS-IND1 FOR LEADING ' ' 
            var match = Regex.Match(line.Trim(), @"^INSPECT\s+(?<isReverse>FUNCTION\s+REVERSE\s*\(\s*)*(?<sourcevar>[-A-a0-9]+)(\s*\))*\s+TALLYING\s+(?<resultvar>\S+)\s+FOR\s+LEADING\s+(?<leadingvar>.+)$");
            if (match.Success)
            {
                var sourcevar = match.Groups["sourcevar"].Value;
                var resultvar = match.Groups["resultvar"].Value;
                var leadingvar = match.Groups["leadingvar"].Value.Trim().TrimEnd('.');
                var isReverse = !string.IsNullOrWhiteSpace(match.Groups["isReverse"].Value);

                var sourceVarName = H.GetReferenceName(sourcevar, Result);
                if (sourceVarName == null)
                    throw new Exception($"nome não encontrado :> {sourcevar}");

                var leadingVarName = H.GetReferenceName(leadingvar, Result);
                if (leadingVarName == null)
                {
                    leadingVarName = Regex.Replace(leadingvar, @"SPACES", @"' '");
                    leadingVarName = Regex.Replace(leadingVarName, @"SPACE", @"' '");
                    leadingVarName = Regex.Replace(leadingVarName, @"ZEROS", @"'0'");
                    leadingVarName = Regex.Replace(leadingVarName, @"ZEROES", @"'0'");
                    leadingVarName = Regex.Replace(leadingVarName, @"ZERO", @"'0'");
                }

                var resultVarName = H.GetReferenceName(resultvar, Result);
                if (resultVarName == null)
                    throw new Exception($"nome não encontrado :> {resultvar}");

                output.AppendLine($"{resultVarName}.Value = {sourceVarName}.ToString(){(isReverse ? ".Reverse()" : "")}.TakeWhile(x => x == {leadingVarName}).Count();");
                response.Executed = true;
            }
        }

        private void InspectConvertingToUpper(string line)
        {
            //INSPECT LKE-NOME-FAVORECIDO-007 TALLYING WS-IND1 FOR LEADING ' ' 
            var match = Regex.Match(line.Trim(), @"^INSPECT\s+(?<sourcevar>\S+)\s+CONVERTING\s+'abcdefghijklmnopqrstuvwxyz'\s+TO\s+'ABCDEFGHIJKLMNOPQRSTUVWXYZAAAAAAAAEEEEIIOOOOUUUUCC'");
            if (match.Success)
            {
                var sourcevar = match.Groups["sourcevar"].Value;
                var varName = H.GetReferenceName(sourcevar, Result);
                if (varName == null)
                    throw new Exception($"nome não encontrado :> {sourcevar}");

                output.AppendLine($"var regex = new Regex(@\"[a-záàãâéèêíìîóòõôúùûç]\");");
                output.AppendLine($"{varName}.Value = regex.Replace({varName}, m => m.Value.ToUpper());");
                response.Executed = true;
            }
        }
        private void InspectConvertingLowValues(string line)
        {
            var match = Regex.Match(line.Trim(), @"^INSPECT\s+(?<sourcevar>\S+)\s+CONVERTING\s+LOW-VALUE(S)?\s+TO\s+' '");

            if (match.Success)
            {
                var sourcevar = match.Groups["sourcevar"].Value;
                var varName = H.GetReferenceName(sourcevar, Result);
                if (varName == null)
                    throw new Exception($"Nome não encontrado: {sourcevar}");

                if (Regex.IsMatch(sourcevar, @"REG\-"))
                {
                    var initialize = $"if ({varName}.IsEmpty())\n" +
                        "{\n          _.Initialize(" + varName.Trim() + ");\n}";
                    output.AppendLine($"{initialize}");
                }
                else
                    output.AppendLine($"{varName}.Value = {varName}.Value.Replace(\"\\0\", \" \");");
                response.Executed = true;
            }
        }

        private void InspectConvertingToVarArray(string line)
        {
            //INSPECT LKE-NOME-FAVORECIDO-007 TALLYING WS-IND1 FOR LEADING ' ' 
            //var match = Regex.Match(line.Trim(), @"^INSPECT\s+(?<sourcevar>\S+)\s+CONVERTING\s+(?<varNameFrom>[-A-z0-9]+)\s+TO\s+(?<varNameTo>[-A-z0-9]+)");
            var match = Regex.Match(line.Trim(), @"^INSPECT\s+(?<sourcevar>\S+)\s+CONVERTING\s+(?<varNameFrom>[-A-Za-z0-9'"";&]+)\s+TO\s+(?<varNameTo>[-A-Za-z0-9' ';&]+)");

            if (match.Success)
            {
                var inspectVarName = $"inspectIn{Result.IsIn.Count(x => x == "INSPECT_COUNT")}";

                var sourcevar = match.Groups["sourcevar"].Value;
                var varNameFrom = match.Groups["varNameFrom"].Value;
                var varNameTo = match.Groups["varNameTo"].Value;

                var refSourceVar = H.GetReferenceProperty(sourcevar, Result);
                var refVarNameFrom = H.GetReferenceProperty(varNameFrom, Result);
                var refVarNameTo = H.GetReferenceProperty(varNameTo, Result);

                var refSourceVarName = refSourceVar?.PropertyName;
                var refVarNameFromName = refVarNameFrom?.PropertyName;
                var refVarNameToName = refVarNameTo?.PropertyName;

                if (refVarNameFrom == null)
                    if ("|SPACE|SPACES|".Contains($"|{varNameFrom}|"))
                        refVarNameFromName = " ";
                    else if ("|';'|'&'|".Contains($"|{varNameFrom}|"))
                        refVarNameFromName = varNameFrom;

                    else if ("|\"'\"|".Contains($"|{varNameFrom}|"))
                        refVarNameFromName = "'";

                if (refVarNameTo == null)
                    if ("|ZERO|ZEROS|ZEROES|".Contains($"|{varNameTo}|"))
                        refVarNameToName = "0";
                    else if ("|' '|''|".Contains($"{varNameTo}".Trim())) 
                        refVarNameToName = varNameTo.Trim();

                if (refSourceVar == null) throw new Exception($"nome não encontrado :> {sourcevar}");
                if (string.IsNullOrEmpty(refVarNameFromName)) throw new Exception($"nome não encontrado :> {varNameFrom}");
                if (string.IsNullOrEmpty(refVarNameToName)) throw new Exception($"nome não encontrado :> {varNameTo}");

                /*C# WAY
                output.AppendLine($"var {inspectVarName} = \"\";");
                output.AppendLine($"foreach (var c in {refSourceVar.PropertyName}.Value)");
                output.AppendLine($"{{");
                output.AppendLine($"var foundedChar = c;");
                output.AppendLine($"for (int l = 0; l < {refVarNameFrom.PropertyName}.Value.Length; l++)");
                output.AppendLine($"{{");
                output.AppendLine($"var searchVal = {refVarNameFrom.PropertyName}.Value[l];");
                output.AppendLine($"var toVal = {refVarNameTo.PropertyName}.Value[l];");
                output.AppendLine($"");
                output.AppendLine($"if (searchVal == c)");
                output.AppendLine($"{{");
                output.AppendLine($"foundedChar = toVal;");
                output.AppendLine($"break;");
                output.AppendLine($"}}");
                output.AppendLine($"}}");
                output.AppendLine($"");
                output.AppendLine($"{inspectVarName}.Append(foundedChar);");
                output.AppendLine($"}}");
                */

                if (refVarNameFrom != null && refVarNameTo != null)
                {
                    /*Framework Way*/
                    output.AppendLine($"{refSourceVar.PropertyName}.Value = {FileResolverHelper.Conf.ProjectQualifierGeneralCommands}.InspectConvert({refSourceVarName},{refVarNameFromName}, {refVarNameToName});");
                }
                else
                    output.AppendLine($"{refSourceVarName}.Value = System.Text.RegularExpressions.Regex.Replace({refSourceVarName}, @\"{refVarNameFromName}\", @\"{refVarNameToName}\");");

                response.Executed = true;

                Result.IsIn.Add("INSPECT_COUNT");
            }
        }
    }
}
