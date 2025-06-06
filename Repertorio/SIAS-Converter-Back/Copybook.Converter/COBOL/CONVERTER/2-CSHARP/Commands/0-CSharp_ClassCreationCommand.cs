using Cobol.Converter;
using CobolLanguageConverter.Converter.CSHARP;
using CobolLanguageConverter.Converter.DIVISION;
using System.Text;
using System.Text.RegularExpressions;

namespace CobolLanguageConverter.Converter.Commands.CSHARP
{
    public class CSharp_PreProcessCommand : ICSharpCommand
    {
        public int Order { get; set; } = 20;
        public ResultSet Result { get; set; }

        public StringBuilder Execute(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = PreProcessingCSharp(csharpCode, ref divisionAndLines);
            return ret;
        }

        StringBuilder PreProcessingCSharp(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = csharpCode;
            var identificationComment = divisionAndLines.FirstOrDefault(x => Regex.IsMatch(x.Key, @"IDENTIFICATION(.*?)+DIVISION_Comment"));

            ret.AppendLine($@"public class {Result.programName} 
            {{
                public bool IsCall {{ get; set; }}
            ");

            //Construtor para Load do settings
            ret.AppendLine($@"public {Result.programName}()
            {{
                AppSettings.Load();
            }}");

            if (identificationComment.Value != null)
                ret.AppendLine($@"
                #region PROG HEADER
                /*""{string.Join("      */" + Environment.NewLine + "/*\"", identificationComment.Value.Select(x => x.Line.Replace("//*", "*").Replace("*//", "*")))}      */
                #endregion
                ");

            ret.AppendLine($@"
            #region VARIABLES
            ");

            return ret;
        }
    }
}
