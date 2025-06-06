//using FileResolver.Helper;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using Microsoft.Extensions.FileSystemGlobbing.Internal;
//using Microsoft.Extensions.Primitives;
//using System;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Xml.Linq;

//namespace Copybook.Converter;

//public class CopybookConverter
//{
//    ////private int currentIndentLevel = 1; // Iniciar com 1
//    //private string currentClassName;
//    //private readonly bool isCobolCode;
//    //private Dictionary<string, int> propertyCounters = new Dictionary<string, int>();
//    //private Dictionary<string, int> fillerClassCounters = new Dictionary<string, int>();
//    //private List<int> identationCounter = new List<int>();
//    //public static List<string> copyLinkageReferences = new List<string>();
//    //public List<string> copyReferences = new List<string>();
//    ////public static Dictionary<ReferenceIncludeModel, ReferenceModel> PropertyReferences = new Dictionary<ReferenceIncludeModel, ReferenceModel>();
//    //public static Dictionary<string, ReferenceModel> GlobalPropertyReferences = new Dictionary<string, ReferenceModel>();
//    //public static Dictionary<string, ReferenceModel> LocalPropertyReferences = new Dictionary<string, ReferenceModel>();
//    //public string classMarker = "WSS";
//    //public string projectFolder = FileResolverHelper.Conf.ProjectCopyName;

//    //public void ToDCLGEN()
//    //{
//    //    classMarker = "DCL";
//    //    projectFolder = FileResolverHelper.Conf.ProjectDclName;
//    //}

//    //public CopybookConverter(string currentClassName, string varName = "WSS", bool isCobolCode = false)
//    //{
//    //    this.currentClassName = currentClassName;
//    //    this.isCobolCode = isCobolCode;
//    //    this.classMarker = varName;
//    //}

//    //public string ConvertCopybookToCSharp(string copybookFilePath)
//    //{
//    //    //currentIndentLevel = 1; // Zerar o indent level no início do método
//    //    propertyCounters.Clear(); // Limpar contadores de propriedades no início do método
//    //    fillerClassCounters.Clear(); // Limpar contadores de propriedades no início do método
//    //    identationCounter = new List<int>();

//    //    var copybookCode = File.ReadAllText(copybookFilePath);

//    //    return ConvertCopybookToCSharpAllText(copybookCode);
//    //}

//    //public string ConvertCopybookToCSharpAllText(string copybookCode, bool isPrivate = false)
//    //{
//    //    var result = new StringBuilder();
//    //    var reference = "";
//    //    var mustIgnoreLine = true;
//    //    var modificator = isPrivate ? "private" : "public";

//    //    // Remover comentários
//    //    //copybookCode = RemoveComments(copybookCode);

//    //    //se a conversão está vindo do Cobol, precisa adicionar uma classe WSS por exemplo
//    //    if (isCobolCode)
//    //    {
//    //        result.AppendLine($"private {currentClassName} {classMarker} {{ get; set; }} = new {currentClassName}();");
//    //        reference = $"{classMarker}";

//    //        //adicionar class marker
//    //        if (!LocalPropertyReferences.ContainsKey(reference))
//    //            LocalPropertyReferences.Add(reference, new ReferenceModel(reference, currentClassName, true));
//    //    }

//    //    result.AppendLine($"{modificator} class {currentClassName}:VarBasis\n{{");
//    //    if (string.IsNullOrEmpty(reference))
//    //        reference = currentClassName;

//    //    // Obtém todas as linhas para análise 
//    //    string[] allLines = copybookCode.Split('\n');

//    //    //grupo de linhas mesmo que haja um "ENTER", irá agrupar as linhas mesmo estando na linha de baixo
//    //    var fullLineList = new List<string>();
//    //    var canSearchFirstDot = false;
//    //    foreach (string line in allLines)
//    //    {
//    //        var lenghtBasedLine = line.Trim().Length > 6 ? line.Substring(7).Trim() : line;
//    //        if (line.Length > 6)
//    //            lenghtBasedLine = line.Substring(7);
//    //        else
//    //            lenghtBasedLine = line.Trim();

//    //        // Ignorar linhas em branco
//    //        if (string.IsNullOrWhiteSpace(lenghtBasedLine))
//    //            continue;

//    //        //em caso de copybooks existentes
//    //        if (lenghtBasedLine.Trim().StartsWith("COPY "))
//    //        {
//    //            copyReferences.Add(lenghtBasedLine.Replace("COPY ", "").Replace("\r", "").Replace(".", "").Replace(" ", ""));
//    //            continue;
//    //        }

//    //        //em caso de SQL INCLUDE
//    //        if (Regex.IsMatch(lenghtBasedLine, @"(EXEC)\s+(SQL)\s+(INCLUDE)"))
//    //        {
//    //            var copyName = Regex.Replace(lenghtBasedLine, @"(EXEC)\s+(SQL)\s+(INCLUDE)", "").Replace("END-EXEC", "").Trim().TrimEnd('.');
//    //            var validTest = CobolConverter.VALID_LINES.Replace($"EXEC SQL INCLUDE {copyName}", "");
//    //            var rex = Regex.Matches(validTest, @$"[\s|\S]?{copyName}").Where(x => !"_-".Contains(x.Value.Trim()[0]));
//    //            if (rex.Count() > 0 || copyName == "SQLCA")
//    //                copyReferences.Add(copyName);

//    //            continue;
//    //        }

//    //        //em caso de EJECT
//    //        if (Regex.IsMatch(lenghtBasedLine, @"\s+EJECT"))
//    //        {
//    //            continue;
//    //        }

//    //        if (mustIgnoreLine)
//    //        {
//    //            //IGNORA O QUE NAO TIVER 01
//    //            if (!Regex.IsMatch(lenghtBasedLine.Trim(), @"^\d{2}") && !canSearchFirstDot)
//    //                continue;

//    //            canSearchFirstDot = true;
//    //        }

//    //        if ((lenghtBasedLine.StartsWith("EXEC SQL") || lenghtBasedLine.StartsWith("*") || string.IsNullOrWhiteSpace(lenghtBasedLine)))
//    //            continue;

//    //        if (line.Count() < 6 || line[6].Equals('*'))
//    //            continue;

//    //        var formatLine = lenghtBasedLine.Replace("\n", "").Replace("\r", "").TrimEnd();

//    //        if (!fullLineList.Any())
//    //            fullLineList.Add(formatLine);
//    //        else if (!formatLine.EndsWith(".") && fullLineList[fullLineList.Count - 1].EndsWith("."))
//    //            fullLineList.Add(formatLine);
//    //        else if (!fullLineList[fullLineList.Count - 1].EndsWith("."))
//    //            fullLineList[fullLineList.Count - 1] = fullLineList.Last() + formatLine;
//    //        else if (formatLine.EndsWith("."))
//    //            fullLineList.Add(formatLine);
//    //    }

//    //    //neste momento cada linha do fullLineList contem 1 representação de linha do Cobol
//    //    //por mais que o operador tenha pulado linha no documento.
//    //    foreach (string currentFullLine in fullLineList)
//    //    {
//    //        var splittedParts = currentFullLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
//    //        var level = splittedParts[0];

//    //        if (level == "88")
//    //            continue;

//    //        //é feita a conta de identação pois é a forma mais simples de contar "sem erro" 
//    //        //as variaveis como inner ou out de uma classe
//    //        var tabCounter = currentFullLine.TakeWhile(x => x == ' ').Count();

//    //        // add tab = add identação = add class ou inicio da copybook
//    //        if (!identationCounter.Contains(tabCounter))
//    //        {
//    //            identationCounter.Add(tabCounter);
//    //        }
//    //        else
//    //        {
//    //            if (identationCounter.Last() != tabCounter)
//    //            {
//    //                var count = identationCounter.Count - 1;
//    //                for (int i = count; i >= 0; i--)
//    //                {
//    //                    var isSelectedTab = identationCounter[i] == tabCounter;
//    //                    if (!isSelectedTab)
//    //                    {
//    //                        identationCounter.RemoveAt(i);
//    //                        var indent = new string('\t', identationCounter.Count);
//    //                        result.Append($"{indent}}}\n");
//    //                        var splitted = reference.Split(".");
//    //                        reference = string.Join(".", reference.Split(".").Take(splitted.Length - 1));
//    //                    }
//    //                    else break;
//    //                }
//    //            }
//    //        }

//    //        //tratamento para PIC (PROPRIEDADE)
//    //        if (splittedParts.Length >= 3 && splittedParts[0].All(char.IsDigit) && splittedParts.Any(x => x.Trim().Equals("PIC", StringComparison.OrdinalIgnoreCase)))
//    //        {
//    //            var originalName = splittedParts[1].Replace("-", "_").Replace(":", "");
//    //            var name = GetUniquePropertyName(originalName).Trim();
//    //            var picDeclaration = string.Join(" ", splittedParts.Skip(2));
//    //            var valueIdx = splittedParts.ToList().IndexOf("VALUE");
//    //            var occursIdx = splittedParts.ToList().IndexOf("OCCURS");
//    //            var initialValue = valueIdx >= 0 ? splittedParts[valueIdx + 1] : null;
//    //            initialValue = initialValue?.Contains(".") == true && initialValue?.Last() == '.' ? string.Join("", initialValue?.Take((initialValue?.Length ?? 0) - 1)) : initialValue;

//    //            var indent = new string('\t', identationCounter.Count);

//    //            // Aplicar a expressão regular para remover parênteses
//    //            var withoutName = splittedParts.Length < 4 && splittedParts[1].Contains("PIC");
//    //            if (withoutName)
//    //                throw new Exception($"Variavel sem nome ::> {currentFullLine}");

//    //            var pic = GetNormalizedPicOcurrence(splittedParts[3]).Split(" ");
//    //            var dataType = GetDataType(pic[0]);
//    //            var initiWith = "";

//    //            if (!string.IsNullOrEmpty(initialValue))
//    //            {
//    //                initialValue = initialValue.Replace("'", "");
//    //                if (
//    //                       initialValue != "SPACES"
//    //                    && initialValue != "ZEROS"
//    //                    && initialValue != "ZEROES"
//    //                    && initialValue != "0"
//    //                )
//    //                {
//    //                    initiWith += ", ";
//    //                    initiWith += dataType.Name == "StringBasis" ? $"\"{initialValue}\"" : initialValue?.ToString();
//    //                }
//    //            }

//    //            var considerType = dataType.Name;
//    //            if (occursIdx < 0)
//    //                result.Append($"\n{indent}public {dataType.Name} {name} {{ get; set; }} = new {dataType.Name}(new PIC(\"{pic[0].Trim()}\",\"{pic[1].Trim()}\"){initiWith});");
//    //            else
//    //            {
//    //                var times = splittedParts[occursIdx + 1].Replace(".", "");
//    //                var append = $"\n{indent}public ListBasis<{dataType.Name}, {dataType.CSharpType}> {name} {{ get; set; }} = new ListBasis<{dataType.Name},{dataType.CSharpType}>(new PIC(\"{pic[0].Trim()}\",\"{pic[1].Trim()}\"),{times}{initiWith});";
//    //                result.Append(append);
//    //                considerType = $"ListBasis<{dataType.Name}, {dataType.CSharpType}>";
//    //            }

//    //            if (string.IsNullOrEmpty(reference))
//    //                reference = $"{classMarker}";

//    //            if (!isCobolCode)
//    //            {
//    //                if (!GlobalPropertyReferences.ContainsKey(name))
//    //                    GlobalPropertyReferences.Add(name, new ReferenceModel(reference + $".{name}", considerType));
//    //            }
//    //            else
//    //            {
//    //                if (!LocalPropertyReferences.ContainsKey(name))
//    //                    LocalPropertyReferences.Add(name, new ReferenceModel(reference + $".{name}", considerType));
//    //            }

//    //            if (!string.IsNullOrEmpty(initialValue))
//    //            {
//    //                initialValue = initialValue.Replace("'", "");
//    //                var toResult = "";
//    //                if (initialValue == "SPACES")
//    //                    toResult = "  //INITIALIZED WITH SPACES";
//    //                else
//    //                if (initialValue == "ZEROS" || initialValue == "ZEROES")
//    //                    toResult = "  //INITIALIZED WITH ZEROS";
//    //                else if (initialValue == "0")
//    //                    toResult = "  //INITIALIZED WITH '0'";

//    //                result.Append(toResult);
//    //            }

//    //            result.AppendLine();
//    //        }

//    //        // Linha sem PIC, trata como classe
//    //        else
//    //        {
//    //            var rexOcc = Regex.Match(currentFullLine, @"OCCURS(\s+|\n)(?<times>\d+)(\s+|\n)TIMES(\s+|\n)*.");
//    //            var propertyName = Regex.Replace(rexOcc.Success ? currentFullLine.Replace(rexOcc.Value, "") : currentFullLine, @"^(\s*\d+\s)", "").TrimEnd('.').Replace("-", "_").Replace(":", "").Trim();
//    //            var isRedefine = false;
//    //            var occursIdx = splittedParts.ToList().IndexOf("OCCURS");

//    //            var redefVarName = "";

//    //            if (propertyName.ToUpper().Contains("REDEFINES"))
//    //            {
//    //                var redefIndex = propertyName.ToUpper().IndexOf("REDEFINES");
//    //                var rex = Regex.Match(propertyName, @"REDEFINES\s+(?<redefVar>\S+[^.])");
//    //                if (rex.Success)
//    //                    redefVarName = rex.Groups["redefVar"].Value.Replace("-", "_");

//    //                propertyName = propertyName.Replace(propertyName.Substring(redefIndex, propertyName.Length - redefIndex), "").Trim();

//    //                isRedefine = true;
//    //            }

//    //            string indent = new string('\t', identationCounter.Count);

//    //            // Adiciona uma propriedade de referência para a classe interna
//    //            var currentName = propertyName.ToString();
//    //            currentName = GetUniquePropertyName(currentName);
//    //            currentName = currentName.Replace(":", "");

//    //            if (isCobolCode)
//    //                currentName = currentClassName + "_" + currentName;

//    //            string outerClassName = Regex.Replace(currentClassName, @"\d+\s", "").TrimEnd('.').Replace("-", "_");
//    //            string localClass = occursIdx < 0 ? currentName : $"ListBasis<{currentName}>";
//    //            var times = occursIdx < 0 ? "" : splittedParts[occursIdx + 1].Replace(".", "");

//    //            //if (occursIdx < 0)
//    //            if (!isRedefine || string.IsNullOrWhiteSpace(redefVarName))
//    //                result.AppendLine($"{indent}{(currentName.ToUpper().Contains("FILLER") ? "private" : "public")} {localClass} {propertyName} {{ get; set; }} = new {localClass}({times});");
//    //            else
//    //            {
//    //                result.AppendLine($@"public {localClass} {propertyName} 
//    //                    {{
//    //                        get {{ var ret = new {localClass}(); _.Move({redefVarName}, ret); this.RedefinePassValue({redefVarName}, ret, {redefVarName}); return ret; }}
//    //                        set {{ this.RedefinePassValue(value, {propertyName}, {redefVarName}); }}
//    //                    }}  //Redefines");
//    //            }

//    //            //else
//    //            //{
//    //            //    result.Append($"\n{indent}public ListBasis<{currentName}> {propertyName} {{ get; set; }} = new ListBasis<{currentName}>({times});");
//    //            //}

//    //            reference += (string.IsNullOrEmpty(reference) ? "" : ".") + $"{propertyName}";
//    //            result.AppendLine($"{indent}{(currentName.ToUpper().Contains("FILLER") && !isRedefine ? "private" : "public")} class {currentName}:VarBasis\n{indent}{{");

//    //            if (!isCobolCode)
//    //            {
//    //                if (!GlobalPropertyReferences.ContainsKey(propertyName))
//    //                    GlobalPropertyReferences.Add(propertyName, new ReferenceModel(reference, localClass, true));
//    //            }
//    //            else
//    //            {
//    //                if (!LocalPropertyReferences.ContainsKey(propertyName))
//    //                    LocalPropertyReferences.Add(propertyName, new ReferenceModel(reference, localClass, true));
//    //            }
//    //        }
//    //    }

//    //    // Adicione mais lógica de conversão conforme necessário
//    //    // Finalizar a classe principal
//    //    result.AppendLine(GetClosingBraces());

//    //    if (copyReferences.Any())
//    //    {
//    //        copyReferences.AddRange(copyLinkageReferences);
//    //        copyReferences = copyReferences.Distinct().ToList();

//    //        //neste momento obtem todos do Cobol más talvez ainda não tenha todos os copy's
//    //        //necessário obter os demais copys primeiro
//    //        //iniciar a conversão pelos copybooks
//    //        foreach (var copy in copyReferences)
//    //        {
//    //            var reffer = GlobalPropertyReferences?.Where(x => x.Value.PropertyName.Contains(copy, StringComparison.OrdinalIgnoreCase));
//    //            if (reffer?.Any() == true)
//    //                for (int i = 0; i < reffer.Count(); i++)
//    //                {
//    //                    var element = reffer.ElementAt(i);
//    //                    var refferKey = element.Key;
//    //                    if (!LocalPropertyReferences.ContainsKey(refferKey))
//    //                    {
//    //                        var newelement = new ReferenceModel(element.Value.PropertyName.Replace($"{copy}.", $"{classMarker}.{copy}."), element.Value.PropertyType, element.Value.PropertyIsClass, true);
//    //                        LocalPropertyReferences.Add(refferKey, newelement);
//    //                    }
//    //                }

//    //            if (copy.Contains("SQLCA") && !LocalPropertyReferences.ContainsKey("SQLCA"))
//    //            {
//    //                LocalPropertyReferences.Add("SQLCA", new ReferenceModel("DB.SQLCA", "SQLCA", false));
//    //                LocalPropertyReferences.Add("SQLCODE", new ReferenceModel("DB.SQLCODE", "SQLCODE", false));
//    //                LocalPropertyReferences.Add("SQLERRMC", new ReferenceModel("DB.SQLERRMC", "SQLERRMC", false));
//    //                LocalPropertyReferences.Add("SQLSTATE", new ReferenceModel("DB.SQLSTATE", "SQLSTATE", false));
//    //            }
//    //        }

//    //        result.Append(string.Join("\n", copyReferences.Where(x => x != "SQLCA").Select(x => $"\tpublic {x} {x} {{ get; set; }} = new {x}();")));
//    //    }

//    //    result.AppendLine($"{new string('\t', 0)}\n}}");

//    //    copyLinkageReferences.Clear();
//    //    return result.ToString();
//    //}

//    //public List<string> ExtractAndSaveInnermostClassesForCopybooks(string convertedCode)
//    //{
//    //    var outputDirectory = FileResolverHelper.Conf.OutputDirectory;
//    //    var extractedClasses = new List<string>();
//    //    var remainingCode = new StringBuilder(convertedCode);

//    //    while (true)
//    //    {
//    //        int startIndex = remainingCode.ToString().LastIndexOf("public class");

//    //        if (startIndex <= 0)
//    //        {
//    //            break; // Nenhuma classe mais interna encontrada
//    //        }

//    //        int endIndex = FindClosingBraceIndex(remainingCode.ToString(), startIndex + "public class".Length - 1);

//    //        if (endIndex != -1)
//    //        {
//    //            // Encontrar o nome da classe
//    //            int classNameStart = startIndex + "public class".Length;
//    //            int hasInherit = remainingCode.ToString().IndexOf(":", classNameStart) - classNameStart;
//    //            int classNameLength = hasInherit >= 0 ? hasInherit : remainingCode.ToString().IndexOf("{", classNameStart) - classNameStart;
//    //            string className = remainingCode.ToString().Substring(classNameStart, classNameLength).Trim();

//    //            // Se a classe não for a principal, mova-a para um arquivo separado
//    //            if (!className.Equals(currentClassName, StringComparison.OrdinalIgnoreCase))
//    //            {
//    //                // Extrair a classe
//    //                var extractedClass = remainingCode.ToString().Substring(startIndex, endIndex - startIndex + 1);
//    //                var indexOfOpenB = extractedClass.IndexOf("{");
//    //                var indexOfClass = $"public class {className}".Length;
//    //                var remainingTabs = extractedClass.Substring(indexOfClass, indexOfOpenB - indexOfClass).Replace("\n", "");
//    //                //extractedClass = extractedClass.Replace(remainingTabs, "");
//    //                extractedClasses.Add(extractedClass);

//    //                // Remover a classe do código restante
//    //                remainingCode.Remove(startIndex, endIndex - startIndex + 1);
//    //            }
//    //            else { break; }
//    //        }
//    //    }

//    //    // Salvar as classes internas em arquivos separados
//    //    foreach (string extractedClass in extractedClasses)
//    //    {
//    //        string className = GetClassNameFromCode(extractedClass);
//    //        string fileName = $"{className}.cs";
//    //        string filePath = Path.Combine(outputDirectory, projectFolder);

//    //        if (!Directory.Exists(filePath))
//    //            Directory.CreateDirectory(filePath);

//    //        File.WriteAllText(Path.Combine(filePath, fileName), extractedClass.Replace("\n}", "}"));

//    //        // Atualizar as referências das classes internas na classe principal
//    //        //remainingCode.Replace(className, $"{className} {char.ToLower(className[0])}{className.Substring(1)} = new {className}()", 0, remainingCode.Length);
//    //    }

//    //    // Salvar a classe principal em um arquivo separado
//    //    string mainClassFileName = $"{currentClassName}.cs";
//    //    string mainClassFilePath = Path.Combine(outputDirectory, projectFolder, mainClassFileName);
//    //    File.WriteAllText(mainClassFilePath, remainingCode.ToString().Replace("\t\n}", "}"));

//    //    return extractedClasses;
//    //}

//    //private string GetClassNameFromCode(string classCode)
//    //{
//    //    int classNameStart = classCode.IndexOf("class") + "class".Length;
//    //    int hasInherit = classCode.ToString().IndexOf(":", classNameStart);
//    //    int classNameEnd = hasInherit >= 0 ? hasInherit : classCode.IndexOf("{", classNameStart);
//    //    string className = classCode.Substring(classNameStart, classNameEnd - classNameStart).Trim();
//    //    return className;
//    //}



//    //private int FindClosingBraceIndex(string code, int startIndex)
//    //{
//    //    int count = 0;
//    //    for (int i = startIndex; i < code.Length; i++)
//    //    {
//    //        if (code[i] == '{')
//    //        {
//    //            count++;
//    //        }
//    //        else if (code[i] == '}')
//    //        {
//    //            count--;
//    //            if (count == 0)
//    //            {
//    //                return i;
//    //            }
//    //        }
//    //    }
//    //    return -1;
//    //}

//    //private string RemoveComments(string code)
//    //{
//    //    // Remove comentários sem quebrar a linha
//    //    var res = Regex.Replace(code, @"(?<!\bPROCEDURE\s)(?<!\bDIVISION\s)\*.*$", "", RegexOptions.Multiline);
//    //    return res.Replace(":", "");
//    //}

//    //private class DataTypeModel
//    //{
//    //    public string Name { get; set; }
//    //    public string DefaultValue { get; set; }
//    //    public string CSharpType { get; set; }
//    //}

//    //private DataTypeModel GetDataType(string variableDeclaration)
//    //{
//    //    var ret = new DataTypeModel();
//    //    // Adapte essa função para mapear os tipos de dados COBOL para os tipos de dados C#
//    //    // Este é um exemplo simples que pode precisar ser expandido
//    //    if (variableDeclaration == "X")
//    //    {
//    //        ret.Name = "StringBasis";
//    //        ret.DefaultValue = "\"\"";
//    //        ret.CSharpType = "string";
//    //    }
//    //    else if (variableDeclaration == "9" || variableDeclaration == "S9")
//    //    {
//    //        ret.Name = "IntBasis";
//    //        ret.DefaultValue = "0";
//    //        ret.CSharpType = "Int64";
//    //    }
//    //    else if (variableDeclaration.Contains("9") && variableDeclaration.Contains("V"))
//    //    {
//    //        ret.Name = "DoubleBasis";
//    //        ret.DefaultValue = "0";
//    //        ret.CSharpType = "double";
//    //    }
//    //    else
//    //    { // Adicione mais casos conforme necessário
//    //        ret.Name = "object"; // Tipo padrão se não reconhecermos o tipo
//    //        ret.DefaultValue = "NOTHING";
//    //        ret.CSharpType = "object";
//    //    }

//    //    return ret;
//    //}

//    //private string GetClosingBraces()
//    //{
//    //    string closingBraces = "";

//    //    for (int i = identationCounter.Count; i > 1; i--)
//    //    {
//    //        closingBraces += $"\n{new string('\t', i - 1)}}}";
//    //    }

//    //    return closingBraces;
//    //}

//    //private string GetNormalizedPicOcurrence(string picLength)
//    //{
//    //    var output = picLength;
//    //    ////pic com formato incomum, PIC -9999 | PIC 999-
//    //    if (picLength.IndexOf("(") < 0)
//    //    {
//    //        output = "X " + output;
//    //        //    output = $"PIC 9({picLength.Count(x => x == '9')})";
//    //    }

//    //    var reg = Regex.Replace(output, "[()]", " ").Trim();
//    //    reg = reg.Last() == '.' ? reg.Substring(0, reg.Length - 1) : reg;
//    //    return reg;
//    //}

//    ////private string GetUniqueClassName(string originalName, string firstName)
//    ////{
//    ////    if (fillerClassCounters.TryGetValue(originalName, out int count))
//    ////    {
//    ////        fillerClassCounters[firstName + originalName] = count + 1;
//    ////        return $"{firstName}_{originalName}_{count}";
//    ////    }
//    ////    else
//    ////    {
//    ////        var output = originalName;
//    ////        if (originalName.ToUpper() == "FILLER")
//    ////        {
//    ////            output = $"{firstName}_{originalName}";
//    ////        }

//    ////        fillerClassCounters[firstName + originalName] = 1;
//    ////        return output;
//    ////    }
//    ////}

//    //private string GetUniquePropertyName(string originalName)
//    //{
//    //    if (propertyCounters.TryGetValue(originalName, out int count))
//    //    {
//    //        propertyCounters[originalName] = count + 1;
//    //        return $"{originalName}_{count}";
//    //    }
//    //    else
//    //    {
//    //        propertyCounters[originalName] = 1;

//    //        if (originalName == "FILLER")
//    //            originalName = originalName + "_0";

//    //        return originalName;
//    //    }
//    //}
//}

//public class ReferenceIncludeModel
//{
//    public string ReferenceName { get; set; }
//    public string ReferenceClass { get; set; }

//    public ReferenceIncludeModel(string referenceName, string referenceClass)
//    {
//        ReferenceName = referenceName;
//        ReferenceClass = referenceClass;
//    }
//}
