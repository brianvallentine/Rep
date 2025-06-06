using CobolLanguageConverter.Converter.Commands.CSHARP;
using CobolLanguageConverter.Converter.DIVISION;
using Copybook.Converter;
using FileResolver.Helper;
using System.Text;
using System.Text.RegularExpressions;

namespace CobolLanguageConverter.Converter.Commands.DIVISIONS
{
    public class Division_CopyToFileCommand : IDivisionCommand
    {
        public int Order { get; set; } = 5;
        public string ProjectFolder { get; set; }
        public ResultSet Result { get; set; }

        public string Execute(string lines, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            var ret = CopyToFile(lines);
            ret = DclToFile(ret);
            return ret;
        }

        string CopyToFile(string lines)
        {
            var command = new CSharp_VariablesDeclarationCommand();
            command.Result = Result;

            //var copy = Result.CopybooksReference
            //                .Where(x => x.Key != "SQLCA" && x.Key != "SQLCODE" && x.Key != "SQLERRMC" && x.Key != "SQLSTATE" && x.Value.PropertyType != "SQLERRD")
            //                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            //if (!copy.Any()) return lines;

            ProjectFolder = FileResolverHelper.Conf.ProjectCopyName;

            var retStr = command.VariablesDeclaration(new StringBuilder(), Result.CopybooksReference);

            ExtractAndSaveInnermostClassesForCopybooks(retStr);

            return lines;
        }

        string DclToFile(string lines)
        {
            var command = new CSharp_VariablesDeclarationCommand();
            command.Result = Result;

            //var copy = Result.DclReference
            //                .Where(x => x.Key != "SQLCA" && x.Key != "SQLCODE" && x.Key != "SQLERRMC" && x.Key != "SQLSTATE" && x.Value.PropertyType != "SQLERRD")
            //                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            //if (!copy.Any()) return lines;

            ProjectFolder = FileResolverHelper.Conf.ProjectDclName;

            var retStr = command.VariablesDeclaration(new System.Text.StringBuilder(), Result.DclReference);

            ExtractAndSaveInnermostClassesForCopybooks(retStr);

            return lines;
        }

        public List<string> ExtractAndSaveInnermostClassesForCopybooks(StringBuilder remainingCode)
        {
            var outputDirectory = FileResolverHelper.Conf.OutputDirectory;
            var extractedClasses = new List<string>();
            var extrapolation = 5000;
            var i = 0;

            while (true)
            {
                i++;
                if (i == extrapolation) break;

                int startIndex = remainingCode.ToString().LastIndexOf("public class");

                if (startIndex <= 0)
                {
                    break; // Nenhuma classe mais interna encontrada
                }

                int endIndex = FindClosingBraceIndex(remainingCode.ToString(), startIndex + "public class".Length - 1);

                if (endIndex != -1)
                {
                    // Encontrar o nome da classe
                    int classNameStart = startIndex + "public class".Length;
                    int hasInherit = remainingCode.ToString().IndexOf(":", classNameStart) - classNameStart;
                    int classNameLength = hasInherit >= 0 ? hasInherit : remainingCode.ToString().IndexOf("{", classNameStart) - classNameStart;
                    string className = remainingCode.ToString().Substring(classNameStart, classNameLength).Trim();

                    // Se a classe não for a principal, mova-a para um arquivo separado
                    //if (!className.Equals(currentClassName, StringComparison.OrdinalIgnoreCase))
                    //{
                    // Extrair a classe
                    var extractedClass = remainingCode.ToString().Substring(startIndex, endIndex - startIndex + 1);
                    var indexOfOpenB = extractedClass.IndexOf("{");
                    var indexOfClass = $"public class {className}".Length;
                    var remainingTabs = extractedClass.Substring(indexOfClass, indexOfOpenB - indexOfClass).Replace("\n", "");
                    //extractedClass = extractedClass.Replace(remainingTabs, "");
                    extractedClasses.Add(extractedClass);

                    // Remover a classe do código restante
                    remainingCode.Remove(startIndex, endIndex - startIndex + 1);
                    //}
                    //else { break; }
                }
            }

            // Salvar as classes internas em arquivos separados
            foreach (string extractedClass in extractedClasses)
            {
                string className = GetClassNameFromCode(extractedClass);
                string fileName = $"{className}.cs";
                string filePath = Path.Combine(outputDirectory, ProjectFolder);

                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                try
                {
                    File.WriteAllText(Path.Combine(filePath, fileName), extractedClass.Replace("\n}", "}"));
                }
                catch (Exception ex)
                {
                }

                // Atualizar as referências das classes internas na classe principal
                //remainingCode.Replace(className, $"{className} {char.ToLower(className[0])}{className.Substring(1)} = new {className}()", 0, remainingCode.Length);
            }

            // Salvar a classe principal em um arquivo separado
            //string mainClassFileName = $"{currentClassName}.cs";
            //string mainClassFilePath = Path.Combine(outputDirectory, ProjectFolder, mainClassFileName);
            //File.WriteAllText(mainClassFilePath, remainingCode.ToString().Replace("\t\n}", "}"));

            return extractedClasses;
        }

        private string GetClassNameFromCode(string classCode)
        {
            int classNameStart = classCode.IndexOf("class") + "class".Length;
            int hasInherit = classCode.ToString().IndexOf(":", classNameStart);
            int classNameEnd = hasInherit >= 0 ? hasInherit : classCode.IndexOf("{", classNameStart);
            string className = classCode.Substring(classNameStart, classNameEnd - classNameStart).Trim();
            return className;
        }



        private int FindClosingBraceIndex(string code, int startIndex)
        {
            int count = 0;
            for (int i = startIndex; i < code.Length; i++)
            {
                if (code[i] == '{')
                {
                    count++;
                }
                else if (code[i] == '}')
                {
                    count--;
                    if (count == 0)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
    }
}