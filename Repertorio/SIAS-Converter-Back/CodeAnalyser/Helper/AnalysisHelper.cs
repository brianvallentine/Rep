using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeAnalyser.Helper
{
    public enum ProgramType
    {
        COPY = 0,
        DCL,
        COBOL,
        DB2,
        JCL,
        IGNORE,
        ANOTHER
    }

    public static class AnalysisHelper
    {
        public static ProgramType IsProgram(string filePath)
        {
            var destructiveList = new List<string>() {
                @"NOME DO BOOK.......:\s+RSPRW019",
            };

            var cobolList = new List<string>() {
                @"IDENTIFICATION\s+DIVISION",
                @"ID\s+DIVISION",
            };

            var copyList = new List<string>() {
                @"PIC(.*?)+",
            };

            var dclList = new List<string>()
            {
                @"DCLGEN\s+TABLE",
                @"IS\s+THE\s+DCLGEN\s+COMMAND"
            };

            var db2List = new List<string>()
            {
            };

            var jclList = new List<string>() {
                @"SORT\s+FIELDS",
                @"SUMT\s+FIELDS=",
                @"INREC\s+FIELDS=",
                @"RECORDING\s+MODE\s+IS\s+F",
            };

            var fileContent = File.ReadAllText(filePath);
            if (fileContent.StartsWith("//*") || destructiveList.Any(x => fileContent.Contains(x)))
                return ProgramType.IGNORE;

            if (cobolList.Any(x => Regex.IsMatch(fileContent, x)))
                return ProgramType.COBOL;

            if (jclList.Any(x => Regex.IsMatch(fileContent, x)))
                return ProgramType.JCL;

            if (dclList.Any(x => Regex.IsMatch(fileContent, x, RegexOptions.None, TimeSpan.FromSeconds(2))))
                return ProgramType.DCL;

            if (db2List.Any(x => Regex.IsMatch(fileContent, x)))
                return ProgramType.DB2;

            if (copyList.Any(x => Regex.IsMatch(fileContent, x)))
                return ProgramType.COPY;

            return ProgramType.ANOTHER;
        }
    }
}
