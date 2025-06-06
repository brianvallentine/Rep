using Cobol.Converter;
using CobolLanguageConverter.Converter.CSHARP;
using CobolLanguageConverter.Converter.DIVISION;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System;
using System.Text;
using System.Xml.Linq;
using IA_ConverterCommons;
using System.Text.RegularExpressions;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;
using Copybook.Converter;
using CodeAnalyser.Helper;
using FileResolver.Helper;
using System.Reflection;
using System.Linq;

namespace CobolLanguageConverter.Converter.Commands.CSHARP
{
    public class CSharp_PROCEDURECobolExecutorLikeCommand : ICSharpCommand
    {
        public int Order { get; set; } = 27;
        public ResultSet Result { get; set; }

        public StringBuilder Execute(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = PROCEDURECobolExecutorLike(csharpCode, ref divisionAndLines);
            return ret;
        }

        StringBuilder PROCEDURECobolExecutorLike(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var jumpingMethods = new List<string>();
            var procedureDivision = divisionAndLines.FirstOrDefault(x => Regex.IsMatch(x.Key, @"^PROCEDURE DIVISION\s*(USING\s+(?<param>(\S|\s)*))*"));
            if (procedureDivision.Key == null)
                return csharpCode;


            for (int i = 0; i < Result.ProcedureReference.Count; i++)
            {
                var procItem = Result.ProcedureReference.ElementAt(i);
                var methodName = procItem.Key.Name;
                var lines = procItem.Value;

                if (methodName == "USING" || methodName == "Execute") continue;

                //todo código excluindo o método corrente
                //e dentro da linha onde contém "jump" cancelamos esta ocorrencia, para não dar erro nas buscas
                var allProcCode = string.Join("\n\n", Result.ProcedureReference.Where(x => x.Key.Name != methodName).Select(x => string.Join("\n", x.Value.Select(a => a.Line.Replace(Environment.NewLine, " ")))));

                //este if verifica se o método é "chamado" por outro em algum momento, evitando métodos órfãos 
                if (
                            Regex.IsMatch(allProcCode, @$"PERFORM\s+(.*?)\s*{methodName.Replace("_", "-")}")
                        || Regex.IsMatch(allProcCode, @$"GO\s+TO\s+(.*?)\s*{methodName.Replace("_", "-")}")
                    )
                    continue;

                var currentIndex = 1;
                var lastProcItem = Result.ProcedureReference.ElementAt(i - currentIndex);
                var lastMethod = lastProcItem.Key;
                while (jumpingMethods.Contains(lastMethod.Name)) { lastMethod = Result.ProcedureReference.ElementAt(i - (++currentIndex)).Key; }

                var lastLines = Result.ProcedureReference[lastMethod];

                // procura também a ocorrência de EXIT para não poluir muito o resultado
                // aqui fazemos o jump de métodos com EXIT
                if (lines.Count == 1 && Regex.IsMatch(lines.FirstOrDefault().Line.Replace("EJECT", "").Trim(), @"EXIT[.]*$"))
                {
                    jumpingMethods.Add(methodName);

                    continue;
                }

                //caso não haja chamada, pode ser que o desenvolvedor COBOL optou pela execução linear da procedure, neste caso, alteramos o comportamento do método
                //para agrupar as linhas dos métodos não encontrados, adicionado a sua execução ao método anterior, mantendo a logica pre-existente no Cobol linear
                if (lastLines.Count == 1 && Regex.IsMatch(lastLines.FirstOrDefault().Line.Replace("EJECT", "").Trim(), @"EXIT[.]*$"))
                {
                    var last = lastLines.Last();
                    lastLines.Remove(last);

                    if (FileResolverHelper.Conf.LogAllLines)
                        lastLines.Add(new CurrentLineType($"/*- Removido na conversão: {last.Line}", last.LineNumber));
                }

                var methodNameIsSection = Regex.IsMatch(string.Join(Environment.NewLine, procedureDivision.Value.Select(x => string.Join(Environment.NewLine, x.Line))), @$"{methodName.Replace("_", "-")}\s+SECTION");
                //if (lastMethod == "Execute" || !methodNameIsSection)
                if (lastMethod.Name == "Execute")
                    lastLines.Add(new CurrentLineType($"FLUXCONTROL_PERFORM {methodName.Replace("_", "-")}", lastLines?.LastOrDefault()?.LineNumber ?? 0));
            }

            return csharpCode;
        }
    }
}
