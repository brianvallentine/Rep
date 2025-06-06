using Copybook.Converter;
using System.Text.RegularExpressions;
using CobolLanguageConverter.Converter.DIVISION;
using Cobol.Converter;
using IA_ConverterCommons;

namespace CobolLanguageConverter.Converter.Commands.DIVISIONS
{
    public class Division_VariablesReferenceCommand : IDivisionCommand
    {
        public int Order { get; set; } = 6;
        public ResultSet Result { get; set; }

        public string Execute(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = VariablesReference(lines, ref divisionAndLines);
            return ret;
        }

        string VariablesReference(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = lines;
            var sections = new List<string>
            {
                @"FILE\s+SECTION$"             ,
                @"WORKING-STORAGE\s+SECTION$"   ,
                @"LOCAL-STORAGE\s+SECTION$"   ,
                @"LINKAGE\s+SECTION$"           ,
            };

            var currResultReference = new Dictionary<string, ReferenceModel>();

            if (lines.Contains(" RETURN-CODE"))
                if (!Result.WorkingStorageReference.ContainsKey("RETURN_CODE"))
                    Result.WorkingStorageReference.Add("RETURN_CODE", new ReferenceModel("RETURN_CODE", "IntBasis", false, false, new PIC("S9", "04", "S9(04)"), nameSpace: "Working"));

            if (lines.Contains(" SORT-RETURN"))
                if (!Result.WorkingStorageReference.ContainsKey("SORT_RETURN"))
                    Result.WorkingStorageReference.Add("SORT_RETURN", new ReferenceModel("SORT_RETURN", "IntBasis", false, false, new PIC("S9", "04", "S9(04)"), nameSpace: "Working"));

            if (lines.Contains(" SORT-FILE-SIZE"))
                if (!Result.WorkingStorageReference.ContainsKey("SORT_FILE_SIZE"))
                    Result.WorkingStorageReference.Add("SORT_FILE_SIZE", new ReferenceModel("SORT_FILE_SIZE", "IntBasis", false, false, new PIC("S9", "08", "S9(08)"), "0", nameSpace: "Working"));

            for (int i = 0; i < divisionAndLines.Count; i++)
            {
                var secLine = divisionAndLines.ElementAt(i);
                var matchItem = sections.FirstOrDefault(x => Regex.IsMatch(secLine.Key, x, RegexOptions.None, TimeSpan.FromMilliseconds(500)));
                if (matchItem == null)
                    continue;

                var tp = "Copy";
                switch (sections.IndexOf(matchItem))
                {
                    case 0:
                        currResultReference = Result.FileReference; tp = "File"; break;
                    case 1:
                        currResultReference = Result.WorkingStorageReference; tp = "Working"; break;
                    case 2:
                        currResultReference = Result.LinkageReference; tp = "Linkage"; break;
                    default:
                        break;
                }

                var parser = new CommonVariableParser(Result);
                parser.classMarker = $"{Result.programName}_";
                parser.ParseToReference(secLine.Value, ref currResultReference, nameSpace: tp);
            }

            return ret;
        }
    }
}
