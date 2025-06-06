using CobolLanguageConverter.Converter.CobolDivisions;
using CobolLanguageConverter.Converter.Commands.DIVISIONS;
using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using DocumentFormat.OpenXml.Presentation;
using Microsoft.CodeAnalysis.Differencing;
using System;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class PerformThruCommand : ICobolCommand
    {

        public CurrentMethodType MethodBefore { get; set; }
        public bool HasMethodBefore { get; set; }
        public string TimesVar { get; set; }
        public bool HasTimesVar { get; set; }
        public CurrentMethodType MethodAfter { get; set; }
        public bool HasMethodAfter { get; set; }
        public string VaryingVar { get; set; }
        public bool HasVaryingVar { get; set; }
        public string FromVar { get; set; }
        public bool HasFromVar { get; set; }
        public string ByVar { get; set; }
        public bool HasByVar { get; set; }
        public string UntilCond { get; set; }
        public bool HasUntilCond { get; set; }
        public bool IsThru { get; set; }
        public bool IsTimes { get; set; }
        public bool IsVarying { get; set; }
        public bool IsUntil { get; set; }
        public bool IsMethodPerform { get; set; }

        CobolCommandResponse? Response { get; set; }
        StringBuilder Output { get; set; } = new StringBuilder();

        public CurrentLineType CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public CobolCommandResponse Execute(string line)
        {
            Response = new CobolCommandResponse(line);

            try
            {
                if (line.StartsWith("END-PERFORM") && Result.IsIn.Contains("PERFORM_MUST_CLOSE"))
                {
                    Result.IsIn.Remove("PERFORM_MUST_CLOSE");

                    Output.AppendLine($"}}");

                    Response.Executed = true;
                    Response.SetResponse(Output);

                    return Response;
                }

                Match performComplex = null;

                //https://regex101.com/r/kLNzPZ
                //(PERFORM\s+(VARYING\s+(?<varyingVar>[-A-z0-9]+)\s+(FROM\s+(?<fromVar>[-+A-z0-9]+)\s+BY\s+(?<byVar>[-+A-z0-9]+))\s+)*(UNTIL\s+(?<untilCond>.+)))|(PERFORM\s+((?<timesVar>\d+)\s+TIMES))|(PERFORM\s+(?<methodBefore>[-A-z0-9]+)*(\s+((?<timesVar>[-+A-z0-9]+)\s+TIMES)*(THRU\s+(?<methodAfter>[-A-z0-9]+)\s*)*(VARYING\s+(?<varyingVar>[-A-z0-9]+)\s+(FROM\s+(?<fromVar>[-+A-z0-9]+)\s+BY\s+(?<byVar>[-+A-z0-9]+))\s+)*)*(UNTIL\s+(?<untilCond>.+))*)
                try { performComplex = Regex.Match(line.Replace(Environment.NewLine, " ").Trim().TrimEnd('.'), @"(PERFORM\s+(VARYING\s+(?<varyingVar>[-A-z0-9]+)\s+(FROM\s+(?<fromVar>[-+A-z0-9]+)\s+BY\s+(?<byVar>[-+A-z0-9]+))\s+)*(UNTIL\s+(?<untilCond>.+)))|(PERFORM\s+((?<timesVar>\d+)\s+TIMES))|(PERFORM\s+(?<methodBefore>[-A-z0-9]+)*(\s+((?<timesVar>[-+A-z0-9]+)\s+TIMES)*(THRU\s+(?<methodAfter>[-A-z0-9]+)\s*)*(VARYING\s+(?<varyingVar>[-A-z0-9]+)\s+(FROM\s+(?<fromVar>[-+A-z0-9]+)\s+BY\s+(?<byVar>[-+A-z0-9]+))\s+)*)*(UNTIL\s+(?<untilCond>.+))*)", RegexOptions.None, TimeSpan.FromMilliseconds(300)); } catch { }
                if (performComplex?.Success != true) return Response;

                MethodBefore = GetMethod(performComplex.Groups["methodBefore"].Value);
                HasMethodBefore = MethodBefore != null;
                TimesVar = performComplex.Groups["timesVar"].Value;
                HasTimesVar = !string.IsNullOrWhiteSpace(TimesVar);
                MethodAfter = GetMethod(performComplex.Groups["methodAfter"].Value);
                HasMethodAfter = MethodAfter != null;
                VaryingVar = performComplex.Groups["varyingVar"].Value;
                HasVaryingVar = !string.IsNullOrWhiteSpace(VaryingVar);
                FromVar = performComplex.Groups["fromVar"].Value;
                HasFromVar = !string.IsNullOrWhiteSpace(FromVar);
                ByVar = performComplex.Groups["byVar"].Value;
                HasByVar = !string.IsNullOrWhiteSpace(ByVar);
                UntilCond = performComplex.Groups["untilCond"].Value;
                HasUntilCond = !string.IsNullOrWhiteSpace(UntilCond);

                IsMethodPerform = HasMethodBefore;
                IsThru = HasMethodAfter;
                IsTimes = HasTimesVar;
                IsVarying = HasVaryingVar;
                IsUntil = HasUntilCond;

                //PERFORM M-010-00-ACHA-LETRA
                //OU
                //PERFORM M-010-00-ACHA-LETRA THRU M-010-00-EXIT
                PerformBasic(line);
                if (Response?.Executed == true) return Response;

                //PERFORM 15 TIMES
                //OU
                //PERFORM R0250-00-MOVE-TIPO 03 TIMES
                PerformTimes(line);
                if (Response?.Executed == true) return Response;

                //PERFORM R1500-00-PROCESSA-COSSHIST UNTIL WFIM-COSSHIST NOT = SPACES OR CHIST-NUM-APOL NOT = WNUM-APOL-ANT.
                PerformUntil(line);
                if (Response?.Executed == true) return Response;

                //PERFORM VARYING CNT-C FROM 1 BY 1 UNTIL WS-CHAR-OK   
                //OU
                //PERFORM R1830-00-GRAVA-INF-COMPLE VARYING W-IND-INFO FROM 1 BY 1 UNTIL W-IND-INFO GREATER W-IND-INFO-N.   
                PerformVarying(line);
                if (Response?.Executed == true) return Response;
            }
            catch (Exception ex)
            {
                Response.SetError(ex);
            }

            Response.SetResponse(Output);
            return Response;
        }

        private void PerformVarying(string line)
        {
            //para ser perform de varying
            if (!IsVarying) return;

            var varyingVar = H.GetReferenceName(VaryingVar, Result);
            if (varyingVar == null)
                varyingVar = VaryingVar;
            else
                varyingVar += ".Value";

            var iniFromNum = H.GetReferenceName(FromVar, Result);
            if (iniFromNum == null)
                iniFromNum = FromVar;

            //varying considerei que sempre terá condition
            var cond = $" {GetUntilCondition()}; ";

            //var condition = GetUntilCondition();
            //Output.AppendLine($"\nwhile({condition}) \n{{");
            Output.AppendLine($"\n for({varyingVar} = {iniFromNum};{cond}{varyingVar} += {ByVar}) \n{{");

            if (HasMethodBefore)
            {
                PerformWithOrWithoutThruProccess(line);
                Output.AppendLine("}");
            }
            else
                Result.IsIn.Add("PERFORM_MUST_CLOSE");

            Response.Executed = true;
            Response.SetResponse(Output);
        }

        private void PerformUntil(string line)
        {
            //para ser perform de until sem varying
            if (!IsUntil || IsVarying) return;

            var condition = GetUntilCondition();
            Output.AppendLine($"\nwhile({condition}) \n{{");

            if (HasMethodBefore)
            {
                PerformWithOrWithoutThruProccess(line);
                Output.AppendLine("}");
            }
            else
                Result.IsIn.Add("PERFORM_MUST_CLOSE");

            Response.Executed = true;
            Response.SetResponse(Output);
        }

        private string GetUntilCondition()
        {
            if (!IsUntil) return "";

            var cSharpCondition = H.GetIfResponseForLine(UntilCond.Trim().TrimEnd('.'), CurrentLine.LineNumber, Result)?.ToString();
            return $"!({cSharpCondition})";
        }

        private void PerformTimes(string line)
        {
            //para ser perform de times
            if (!IsTimes) return;

            var timerToConsider = "";
            if (int.TryParse(TimesVar, out var pTimes))
                timerToConsider = pTimes.ToString();
            else
            {
                var timeVarRef = H.GetReferenceProperty(TimesVar, Result);
                if (timeVarRef != null)
                    timerToConsider = timeVarRef.PropertyName;
            }

            if (string.IsNullOrEmpty(timerToConsider))
                throw new Exception($"Erro ao converter inteiro do TIMES considerando -> {TimesVar}");

            Output.AppendLine($"\nfor (int i = 0; i < {timerToConsider}; i++) \n{{");

            if (HasMethodBefore)
            {
                PerformWithOrWithoutThruProccess(line);
                Output.AppendLine($"\n}}");
            }
            else
                Result.IsIn.Add("PERFORM_MUST_CLOSE");

            Response.Executed = true;
            Response.SetResponse(Output);
        }

        private void PerformBasic(string line)
        {
            //para ser perform simples, deve ter método, e talvez THRU
            if (!IsMethodPerform || IsVarying || IsTimes || IsUntil) return;

            PerformWithOrWithoutThruProccess(line);

            Response.Executed = true;
            Response.SetResponse(Output);
        }

        private void PerformWithOrWithoutThruProccess(string line)
        {
            var methodsToAdd = new List<CurrentMethodType>
            {
                MethodBefore
            };

            //se for THRU, haverá alguns métodos em sequencia
            if (IsThru)
            {
                var indexBefore = Result.ProcedureReference.Keys.ToList().IndexOf(MethodBefore);
                var indexAfter = Result.ProcedureReference.Keys.ToList().IndexOf(MethodAfter);
                for (int i = indexBefore + 1; i <= indexAfter; i++)
                {
                    var item = Result.ProcedureReference.ElementAt(i);
                    methodsToAdd.Add(item.Key);
                }
            }

            foreach (var methodName in methodsToAdd)
            {
                if (H.IsIgnoredMethod(methodName, Result))
                {
                    Output.AppendLine($"/*Método Suprimido por falta de linha ou apenas EXIT nome: {methodName.Name}*/\n");
                    continue;
                }

                var isFluxControl = line.Trim().StartsWith("FLUXCONTROL_PERFORM");
                var hasToPutTrue = methodName.MethodType == CurrentMethodTypeEnum.PARAGRAPH;
                hasToPutTrue &= Result?.CurrentMethod?.MethodType != CurrentMethodTypeEnum.SECTION;
                hasToPutTrue &= !isFluxControl;
                hasToPutTrue &= !methodName.Name.Contains("_DB_");
                
                if (!methodName.Name.Contains("_DB_") || !IsThru)
                {
                    Output.AppendLine($"\n{methodName.Name}({(hasToPutTrue ? "true" : "")});");
                }
            }
        }

        private CurrentMethodType? GetMethod(string? methodName, bool cSharpName = true)
        {
            if (string.IsNullOrWhiteSpace(methodName)) return null;

            // Extrair o nome do método
            //string methodName = Regex.Match(line, @"(\bPERFORM\s*)?(?<NomeDoMetodo>\w+(?:-\w+)*)\b").Groups["NomeDoMetodo"].Value;
            if (cSharpName)
            {
                if (char.IsDigit(methodName[0]))
                    methodName = $"{CSharp_CobolLineChangeCommand.ChangedNewKeyMarker}{methodName}";

                methodName = methodName.Replace("-", "_");
            }

            return Result.ProcedureReference.Keys.FirstOrDefault(x => x.Name == methodName || x.Name == $"{methodName}_SECTION");
        }
    }
}
