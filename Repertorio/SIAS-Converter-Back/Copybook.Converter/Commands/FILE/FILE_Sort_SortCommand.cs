using CobolLanguageConverter.Converter.Commands.DIVISIONS;
using CobolLanguageConverter.Converter.Commands.IF;
using CobolLanguageConverter.Converter.DIVISION;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class FILE_Sort_SortCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; } //Cobol Code
        public ResultSet Result { get; set; }
        StringBuilder output = new StringBuilder();

        public CobolCommandResponse Execute(string line)
        {
            var response = new CobolCommandResponse(line);

            try
            {
                //inicio do SORT
                if (line.StartsWith("SORT "))
                {
                    //TODO:
                    /*  SORT ARQSORT ON ASCENDING KEY
                                            SOR-COD-BANCO
                                            SOR-COD-AGENCIA
                                            SOR-NUM-AVISO
                                            SOR-COD-PRODUTO
                        INPUT PROCEDURE R0200-00-INPUT-SORT THRU
                        R0200-99-SAIDA
                        OUTPUT PROCEDURE R0450-00-OUTPUT-SORT THRU
                        R0450-99-SAIDA.  
                    Exactly
                    */

                    //https://regex101.com/r/BrokWf
                    //sort de arquivo de sort
                    var match = Regex.Match(line, @"SORT\s+(?<fileName>\S+)\s+ON\s+(?<ascDesc>\S+)\s+KEY\s+(?<group>(?<keys>\S+)\s+)+INPUT\s+PROCEDURE\s+(?<inProc>\S+)(\s+THRU\s+(?<tInProc>\S+))*\s+OUTPUT\s+PROCEDURE\s+(?<outProc>\S+)(\s+THRU\s+(?<tOutProc>\S+))*");
                    if (match.Success)
                    {
                        var fileName = match.Groups["fileName"].Value;
                        var keys = string.Join(",", match.Groups["keys"].Captures.Select(x => x.Value).ToList());
                        var inProc = match.Groups["inProc"].Value.Replace("-", "_");
                        var tInProc = match.Groups["tInProc"].Value;
                        var outProc = match.Groups["outProc"].Value.Replace("-", "_").Replace(".","");
                        var tOutProc = match.Groups["tOutProc"].Value;
                        var ascDesc = match.Groups["ascDesc"].Value;
                        var isAscending = ascDesc.Trim() == "ASCENDING";
                        var key = $"SORT_{fileName}";

                        var sortVar = H.GetReferenceProperty("SORT-RETURN", Result);
                        var sortEqual = sortVar == null ? "" : $"{sortVar.PropertyName}.Value = ";

                        if (!string.IsNullOrEmpty(inProc))
                        {
                            if (Regex.IsMatch(inProc, @"^\d"))
                                inProc = $"{CSharp_CobolLineChangeCommand.ChangedNewKeyMarker.Replace("-", "_")}{inProc}";

                            var inProcK = Result.ProcedureReference.Keys.FirstOrDefault(x => x.Name == inProc || x.Name == $"{inProc}_SECTION");
                            inProc = $"() => {inProcK.Name}({(inProcK.MethodType == CurrentMethodTypeEnum.PARAGRAPH ? "true" : "")})";
                        }

                        if (!string.IsNullOrEmpty(outProc))
                        {
                            if (Regex.IsMatch(outProc, @"^\d"))
                                outProc = $"{CSharp_CobolLineChangeCommand.ChangedNewKeyMarker.Replace("-", "_")}{outProc}";

                            var outProcK = Result.ProcedureReference.Keys.FirstOrDefault(x => x.Name == outProc || x.Name == $"{outProc}_SECTION");
                            outProc = $"() => {outProcK.Name}({(outProcK.MethodType == CurrentMethodTypeEnum.PARAGRAPH ? "true" : "")})";
                        }

                        var fileRef = H.GetReferenceProperty(fileName, Result);
                        if (fileRef != null)
                            fileName = fileRef.PropertyName;

                        output.AppendLine($@"{sortEqual}{fileName}.Sort(""{keys}"", {inProc}, {outProc});");
                        response.Executed = true;
                    }

                    //https://regex101.com/r/8VsUrY
                    //sort de arquivos de leitura
                    if (!match.Success)
                    {
                        match = Regex.Match(line, @"SORT\s+(?<fileName>\S+)\s+ON\s+(?<ascDesc>\S+)\s+KEY\s+(?<group>((?<keys>\S+)\s+)+)USING\s+(?<using>\S+)\s+GIVING\s+(?<giving>\S+)");
                        if (match.Success)
                        {
                            var fileName = match.Groups["fileName"].Value;
                            var usingFile = match.Groups["using"].Value;
                            var givingFile = match.Groups["giving"].Value.TrimEnd('.');
                            var keys = string.Join(",", match.Groups["keys"].Captures.Select(x => x.Value).ToList());
                            var ascDesc = match.Groups["ascDesc"].Value;
                            var isAscending = ascDesc.Trim() == "ASCENDING";
                            var key = $"SORT_{fileName}";


                            output.AppendLine($@"{givingFile}.AllLines = {usingFile}.SortFile(""{keys}"", {fileName}.FileLayout);");
                            response.Executed = true;
                        }
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
