using Copybook.Converter;
using System.Text.RegularExpressions;
using IA_ConverterCommons;
using System.Linq;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CobolLanguageConverter.Converter.DIVISION
{
    internal class CommonVariableParser
    {
        private List<int> identationCounter = new List<int>();
        public string classMarker { get; set; } = "";
        public ResultSet Result { get; set; }

        public CommonVariableParser(ResultSet result)
        {
            Result = result;
        }

        public void ParseToReference(List<CurrentLineType> lines, ref Dictionary<string, ReferenceModel> currResultReference, string reference = "", bool isCopy = false, string nameSpace = "")
        {
            var refParam = reference.ToString();
            if (reference != "")
                currResultReference.Add(reference, new ReferenceModel(reference, reference, true, isCopy, nameSpace: nameSpace));

            //bloco quando tem INDEXED BY
            var rexIndexed = Regex.Matches(string.Join(Environment.NewLine, lines.Select(x => string.Join(Environment.NewLine, x.Line))), @"\d+\s+(?<containerName>\S+)(?<pic>\s+PIC.+?)*\s+(REDEFINES\s+\S+\s+)*OCCURS\s+\d+\s+(TIMES\s+)*(?<indexed>INDEXED\s+BY\s+(?<varname>\S+))+");
            if (rexIndexed?.Any(x => x.Success) == true)
            {
                foreach (Match item in rexIndexed)
                {
                    var varName = item.Groups["varname"].Value.Trim().TrimEnd('.').Replace("-", "_");
                    var containerName = item.Groups["containerName"].Value.Trim().TrimEnd('.');
                    var indexed = item.Groups["indexed"].Value.Trim().TrimEnd('.');

                    var refName = varName;
                    if (!string.IsNullOrEmpty(refParam))
                        refName = $"{refParam}.{varName}";

                    if (!Result.ALLReference.ContainsKey(varName)) //
                    {
                        var refModel = new ReferenceModel(refName, "IntBasis", false, isCopy, new PIC("9", "4", "9(4)"), "0", nameSpace: nameSpace);
                        refModel.IndexedFor = containerName.Replace("-", "_");
                        currResultReference.Add(refName, refModel);
                    }

                    //var liners = string.Join(" ====ALT==== ", lines);
                    //liners = liners.Replace(indexed, "");
                    //lines = liners.Split(" ====ALT==== ").ToList();
                }
            }
            //bloco quando tem INDEXED BY

            //neste momento cada linha do fullLineList contem 1 representação de linha do Cobol
            //por mais que o operador tenha pulado linha no documento.
            foreach (var currentF in lines)
            {
                var currentFLine = currentF.Line;
                if (string.IsNullOrWhiteSpace(currentFLine.Trim())) continue;

                var markedList = new Dictionary<string, string>();
                var currentFullLine = H.ToMarkedString(currentFLine, out markedList);

                var splittedParts = currentFullLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var level = splittedParts[0];
                var isResultSetLocator = false;

                if (!Regex.IsMatch(level.Trim(), @"^\d+"))
                    continue;

                if (level == "88")
                    continue;

                //tratamento para RESULT-SET-LOCATOR, é uma variavel que irá compor o resultado do SQL em algum local
                if (Regex.IsMatch(currentFLine, @"USAGE\s+SQL\s+TYPE\s+IS"))
                {
                    var rex = Regex.Match(currentFLine, @"\d{2}\s+(?<variableName>\S+)\s+USAGE\s+SQL\s+TYPE\s+IS\s+RESULT-SET-LOCATOR\s+VARYING");
                    if (rex.Success)
                        isResultSetLocator = true;
                    else
                        continue;
                }

                //é feita a conta de identação pois é a forma mais simples de contar "sem erro" 
                //as variaveis como inner ou out de uma classe
                var tabCounter = currentFullLine.TakeWhile(x => x == ' ').Count();

                // add tab = add identação = add class ou inicio da copybook
                if (!identationCounter.Contains(tabCounter))
                {
                    identationCounter.Add(tabCounter);
                }
                else
                {
                    if (identationCounter.Last() != tabCounter)
                    {
                        var count = identationCounter.Count - 1;
                        for (int j = count; j >= 0; j--)
                        {
                            var isSelectedTab = identationCounter[j] == tabCounter;
                            if (!isSelectedTab)
                            {
                                identationCounter.RemoveAt(j);
                                if (!string.IsNullOrWhiteSpace(reference))
                                {
                                    if (!reference.Contains("."))
                                        reference = "";
                                    else
                                    {
                                        reference = string.Join(".", reference.Split(".").SkipLast(1));
                                    }
                                }
                            }
                            else break;
                        }
                    }
                }

                //tratamento para RESULT-SET-LOCATOR, é uma variavel que irá compor o resultado do SQL em algum local
                if (isResultSetLocator)
                {
                    isResultSetLocator = false;

                    var rex = Regex.Match(currentFLine, @"\d{2}\s+(?<variableName>\S+)\s+USAGE\s+SQL\s+TYPE\s+IS\s+RESULT-SET-LOCATOR\s+VARYING");
                    var variableName = GetUniquePropertyName(rex.Groups["variableName"].Value.Replace("-", "_"));
                    var refModel = new ReferenceModel(reference, "IntBasis", false, isCopy, new PIC("S9", "4", "S9(4)"), nameSpace: nameSpace);
                    refModel.CurrentLine = currentFLine;
                    currResultReference.Add(variableName, refModel);

                    continue;
                }

                var isPic = splittedParts.Any(x => x.Trim().Equals("PIC", StringComparison.OrdinalIgnoreCase));

                if (!isPic && splittedParts.Any(x => x.Trim().Equals("COMP-2.", StringComparison.OrdinalIgnoreCase)))
                {
                    currentFullLine = Regex.Replace(currentFullLine, @"\s+USAGE\s+COMP-2", " PIC S9(17)V USAGE COMP-2").Trim();
                    splittedParts = currentFullLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    isPic = true;
                }

                //tratamento para PIC (PROPRIEDADE) (com excessão de REDEFINES)
                if ((splittedParts.Length >= 3 && splittedParts[0].All(char.IsDigit) && isPic) && !splittedParts.Any(x => x.Trim().Equals("REDEFINES", StringComparison.OrdinalIgnoreCase)))
                {
                    var originalName = splittedParts[1].Replace("-", "_").Replace(":", "");

                    var refName = originalName;
                    if (!string.IsNullOrEmpty(refParam))
                        refName = $"{refParam}.{originalName}";

                    var name = GetUniquePropertyName(refName);
                    var picDeclaration = string.Join(" ", splittedParts.Skip(2));
                    var valueIdx = splittedParts.ToList().IndexOf("VALUE");
                    var occursIdx = splittedParts.ToList().IndexOf("OCCURS");
                    var initialValue = valueIdx >= 0 ? splittedParts[valueIdx + 1] : null;
                    var indexedIdx = splittedParts.ToList().IndexOf("INDEXED");
                    var indexedByIdx = indexedIdx > 0 ? splittedParts.Skip(indexedIdx).ToList().IndexOf("BY") + indexedIdx : -1;

                    initialValue = initialValue?.Contains(".") == true && initialValue?.Last() == '.' ? string.Join("", initialValue?.Take((initialValue?.Length ?? 0) - 1)) : initialValue;
                    if (initialValue?.Trim() == "IS")
                        initialValue = "";

                    if (H.HasStringMark(initialValue))
                        initialValue = H.ToUnMarkedString(initialValue, markedList);

                    var indent = new string('\t', identationCounter.Count);

                    // Aplicar a expressão regular para remover parênteses
                    var withoutName = splittedParts.Length < 4 && splittedParts[1].Contains("PIC");
                    if (withoutName)
                        throw new Exception($"Variavel sem nome ::> {currentFullLine}");

                    var indexPic = 3;
                    if (Regex.IsMatch(currentFLine, @"\s+OCCURS\s+\d+\s+TIMES\s+PIC"))
                        indexPic = 6;

                    var picIdx = splittedParts.ToList().IndexOf("PIC");
                    var pic = GetNormalizedPicOcurrence(ref splittedParts[indexPic]).Split(" ");
                    //var dataType = DataTypeModel.GetDataType(pic[0], splittedParts[3]);
                    var dataType = DataTypeModel.GetDataType(splittedParts[picIdx + 1], pic[0]);

                    var PIC = new PIC(pic[0].Trim(), dataType.Length.ToString(), splittedParts[picIdx + 1]);

                    var considerType = dataType.Name;
                    var times = "";
                    if (occursIdx >= 0)
                    {
                        times = splittedParts[occursIdx + 1].Replace(".", "");
                        considerType = $"ListBasis<{dataType.Name}, {dataType.CSharpType}>";
                    }

                    if (!Result.ALLReference.ContainsKey(name))
                    {
                        var reffModel = new ReferenceModel($"{(string.IsNullOrWhiteSpace(reference) ? "" : $"{reference}.")}{name.Split(".").LastOrDefault()}", considerType, false, isCopy, PIC, initialValue, times, nameSpace: nameSpace);

                        //caso houver precisão na PIC este valor é considerado na montagem da variavel
                        if (dataType.Precision > 0)
                            reffModel.PropertyPrecision = dataType.Precision;

                        reffModel.CurrentLine = currentFLine;

                        if (indexedByIdx > 0)
                            reffModel.IndexedBy = splittedParts[indexedByIdx + 1].Replace(".", "");

                        currResultReference.Add(name, reffModel);
                    }
                }

                // Linha sem PIC, trata como classe ( com excessão de REDEFINES )
                else
                {
                    // Aplicar a expressão regular para remover parênteses
                    var withoutName = splittedParts.Length < 2;
                    if (withoutName)
                        throw new Exception($"Variavel sem nome ::> {currentFullLine}");

                    var rexOcc = Regex.Match(currentFullLine, @"OCCURS\s+(?<times>\d+)*\s*(TIMES\s*)*(?<times>\d+)*[.]*");
                    var propertyName = Regex.Replace(rexOcc.Success ? currentFullLine.Replace(rexOcc.Value, "") : currentFullLine.TrimEnd(), @"^(\s*\d+\s)+[.]*", "").TrimEnd('.').Replace("-", "_").Replace(":", "").Trim();
                    //if (propertyName.Contains(" "))
                    //    propertyName = splittedParts[1].Replace("-", "_").Replace(":", "");

                    propertyName = Regex.Replace(propertyName, @"\s+(USAGE\s+)*COMP_3", "").Trim();
                    propertyName = Regex.Replace(propertyName, @"\s+(USAGE\s+)*COMP_2", "").Trim();

                    var isRedefine = false;
                    var occursIdx = splittedParts.ToList().IndexOf("OCCURS");
                    var indexedIdx = splittedParts.ToList().IndexOf("INDEXED");
                    var indexedByIdx = indexedIdx > 0 ? splittedParts.Skip(indexedIdx).ToList().IndexOf("BY") + indexedIdx : -1;

                    var redefVarName = "";

                    if (propertyName.ToUpper().Contains("INDEXED"))
                    {
                        var redefIndex = propertyName.ToUpper().IndexOf("INDEXED");
                        var rex = Regex.Match(propertyName, @"INDEXED\s+BY\s+(?<idxVar>\S+[^.])");
                        if (rex.Success)
                            propertyName = propertyName.Replace(propertyName.Substring(redefIndex, propertyName.Length - redefIndex), "").Trim();
                    }

                    if (propertyName.ToUpper().Contains("REDEFINES"))
                    {
                        var redefIndex = propertyName.ToUpper().IndexOf("REDEFINES");
                        var rex = Regex.Match(propertyName, @"REDEFINES\s+(?<redefVar>\S+[^.])");
                        if (rex.Success)
                            redefVarName = rex.Groups["redefVar"].Value.Replace("-", "_").Trim();

                        propertyName = propertyName.Replace(propertyName.Substring(redefIndex, propertyName.Length - redefIndex), "").Trim();

                        isRedefine = true;
                    }

                    string indent = new string('\t', identationCounter.Count);

                    // Adiciona uma propriedade de referência para a classe interna
                    var currentName = splittedParts[1].Replace("-", "_").Replace(".", "");

                    var refName = currentName;
                    if (!string.IsNullOrEmpty(refParam))
                        refName = $"{refParam}.{currentName}";

                    currentName = GetUniquePropertyName(refName);
                    currentName = currentName.Replace(":", "");

                    string localClass = occursIdx < 0 ? classMarker + currentName.Split(".").LastOrDefault() : $"ListBasis<{classMarker + currentName.Split(".").LastOrDefault()}>";
                    var times = occursIdx < 0 ? "" : splittedParts[occursIdx + 1].Replace(".", "");

                    PIC? PIC = null;
                    DataTypeModel dataType = null;
                    var localRef = reference + (string.IsNullOrEmpty(reference) ? "" : ".") + $"{currentName.Split(".").LastOrDefault()}";
                    if (isPic)
                    {
                        var picRef = splittedParts[splittedParts.ToList().FindIndex(x => x.Contains("PIC")) + 1];
                        var pic = GetNormalizedPicOcurrence(ref picRef).Split(" ");
                        dataType = DataTypeModel.GetDataType(picRef);
                        //dataType = DataTypeModel.GetDataType(pic[0], picRef);
                        PIC = new PIC(pic[0].Trim(), pic[1].Trim(), picRef);
                    }
                    else
                        reference = localRef;

                    if (!Result.ALLReference.ContainsKey(currentName))
                    {
                        //var reffModel =
                        //new ReferenceModel($"{(string.IsNullOrWhiteSpace(reference) ? "" : $"{reference}.")}{name.Split(".").LastOrDefault()}", considerType, false, isCopy, PIC, initialValue, times, nameSpace: nameSpace);
                        //no momento de fazer o MOVE para classes com REDEFINES, não tem como identificar quando é Redefines, então coloquei um marcador nas classes de redefines
                        var localClassName = isPic ? dataType?.Name : localClass;
                        if (isRedefine)
                        {
                            var isListBasis = localClassName.Contains("ListBasis<");
                            if (isListBasis)
                                localClassName = localClassName.Replace("ListBasis<", $"ListBasis<_REDEF_");
                            else
                                localClassName = $"_REDEF_{localClassName}";
                        }

                        var refModel = new ReferenceModel(localRef, localClassName, true, isCopy, PIC, "", times, isRedefine, redefVarName, nameSpace: nameSpace);
                        refModel.CurrentLine = currentFLine;

                        if (indexedByIdx > 0)
                            refModel.IndexedBy = splittedParts[indexedByIdx + 1].Replace(".", "");

                        currResultReference.Add(currentName, refModel);
                    }
                }
            }

            Threat88VarSectionSelector(refParam, lines);
        }

        private void Threat88VarSectionSelector(string reference, List<CurrentLineType> lines)
        {
            //adicionado bloco que trata de 88
            var allLines = lines;
            var searchNext88 = false;
            var selectors = new Dictionary<string, SelectorBasis>();
            var first88Level = false;

            for (int j = 0; j < allLines.Count; j++)
            {
                var lineRef = allLines[j];
                var line = lineRef.Line.Trim();

                if (!Regex.IsMatch(line, @"^\d{2}"))
                    continue;

                var splittedParts = Regex.Replace(line, @",\s*", ",").Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (splittedParts.Length < 4) continue;

                var originalName = splittedParts[1].Replace("-", "_").Replace(":", "");
                var varName = originalName;

                //correção quando o nome do 88 era FILLER
                if (varName == "FILLER" && first88Level)
                {
                    varName = $"{varName}_0";
                }

                if (selectors.ContainsKey(varName))
                {
                    if (varName.Contains("FILLER"))
                    {
                        var i = 0;
                        var searchName = $"FILLER_{i}";
                        while (selectors.ContainsKey(searchName))
                            searchName = $"FILLER_{++i}";

                        varName = searchName;
                    }
                }

                var level = splittedParts[0];
                var picDeclaration = string.Join(" ", splittedParts.Skip(2));
                var refVar = splittedParts[3].ToString();
                var picNormalized = GetNormalizedPicOcurrence(ref refVar);
                var pic = picNormalized.Split(" ");
                var PIC = new PIC(pic[0].Trim(), pic[1].Trim(), picNormalized);
                var valueIdx = splittedParts.ToList().IndexOf("VALUE");
                valueIdx = valueIdx != -1 ? valueIdx : splittedParts.ToList().IndexOf("VALUES");
                var initialValue = "";// valueIdx >= 0 ? splittedParts[valueIdx + 1].TrimEnd('.') : null;

                //ou seja, tem valor inicial
                if (valueIdx >= 0)
                {
                    var coteCount = 0;
                    foreach (var item in splittedParts.Skip(valueIdx + 1))
                    {
                        if (coteCount >= 2) break;

                        coteCount += item.Count(x => x == '\'');
                        initialValue += (" " + item);
                        initialValue = initialValue.Trim();
                    }

                    initialValue = initialValue.TrimEnd('.');
                }

                //se não "trombou" com 88 ainda, continue para proxima linha
                if (level != "88" && !searchNext88 && !first88Level)
                    continue;

                //se não "trombou" com 88 ainda, significa que este é o primeiro 88 da lista, então volta para o anterior que é a variavel de controle
                if (level == "88" && !first88Level)
                {
                    first88Level = true;
                    j -= 2;
                    continue;
                }

                if (!searchNext88)
                {
                    searchNext88 = true;
                    selectors.Add(varName, new SelectorBasis(PIC.CobolLength, initialValue));
                    continue;
                }

                if (searchNext88 && level != "88")
                {
                    searchNext88 = false;
                    var last = selectors.LastOrDefault();
                    if (last.Value.Items.Count == 0)
                        selectors.Remove(last.Key);

                    j--;
                    first88Level = false;
                    continue;
                }

                //neste ponto é 88 e a variavel inicial ja foi colocada
                if (selectors.Count > 0)
                {
                    var last = selectors.LastOrDefault();
                    last.Value.Items.Add(new SelectorItemBasis(varName, initialValue, line));
                }
            }

            if (selectors.Count > 0)
                foreach (var item in selectors)
                    //Result.SelectorsList.Add(item.Key, item.Value);
                    Result.SelectorsList.Add(string.IsNullOrEmpty(reference) ? item.Key : $"{reference}.{item.Key}", item.Value);
        }

        private string GetUniquePropertyName(string originalName)
        {
            try
            {
                var i = 0;
                var searchName = originalName;
                if (!Result.ALLReference.TryGetValue(searchName, out var @type))
                    searchName = $"{originalName}_{i}";

                while (Result.ALLReference.TryGetValue(searchName, out @type))
                    searchName = $"{originalName}_{i++}";

                var resName = originalName;
                if (searchName != $"{originalName}_{i}" || originalName == "FILLER")
                    resName = searchName;

                return resName;
            }
            catch (Exception)
            {
                return originalName;
            }
        }

        public static string GetNormalizedPicOcurrence(ref string picLength)
        {
            var output = picLength;
            var regValue = picLength.Replace("Z", "").Replace(",", "").Replace(".", "");

            if (Regex.IsMatch(picLength, @"Z\(\d+\)"))
                output = output.Replace("Z", "S9");

            if (Regex.IsMatch(regValue, @"\d+") && !regValue.Contains("9 ") && !regValue.Contains("X ") && picLength.IndexOf("(") < 0)
                output = "9 " + output;
            else
            if (picLength.IndexOf("(") < 0) ////pic com formato incomum, PIC -9999 | PIC 999-            
                output = "X " + output;

            if (picLength.Contains(",") && !picLength.Contains("V"))
                picLength = picLength.Replace(",", "V");

            var reg = Regex.Replace(output, "[()]", " ").Trim();
            reg = reg.Last() == '.' ? reg.Substring(0, reg.Length - 1) : reg;
            return reg;
        }
    }
}
