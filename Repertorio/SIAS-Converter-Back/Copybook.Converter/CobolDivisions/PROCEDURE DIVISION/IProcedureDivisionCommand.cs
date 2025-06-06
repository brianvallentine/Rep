using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CobolLanguageConverter.Converter.Commands.IF
{
    internal interface IProcedureDivisionCommand
    {
        public int Order { get; set; }
        public string? CurrentLine { get; set; }
        public string Execute(string line, ref Dictionary<string, string> markedList);
    }

    public static class ProcedureHelper
    {
        public static string GetMethodName(string line, bool cSharpName = true)
        {
            // Extrair o nome do método
            string methodName = Regex.Match(line, @"(\bPERFORM\s*)?(?<NomeDoMetodo>\w+(?:-\w+)*)\b").Groups["NomeDoMetodo"].Value;
            if (cSharpName)
                methodName = methodName.Replace("-", "_");

            return methodName;
        }
    }
}