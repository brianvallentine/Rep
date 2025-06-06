using Cobol.Converter;
using CobolLanguageConverter.Converter.CSHARP;
using CobolLanguageConverter.Converter.DIVISION;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System;
using System.Text;
using System.Xml.Linq;
using IA_ConverterCommons;
using Copybook.Converter;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;
using System.Collections.Generic;
using FileResolver.Helper;
using DocumentFormat.OpenXml.Spreadsheet;

namespace CobolLanguageConverter.Converter.Commands.CSHARP
{
    public class CSharp_VariablesDeclarationCommand : ICSharpCommand
    {
        public int Order { get; set; } = 22;
        private int alreadyInsideClass { get; set; } = 0;
        private ReferenceModel lastPropName { get; set; } = null;
        public ResultSet Result { get; set; }

        public StringBuilder Execute(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines)
        {
            //Result.ALLWorkingReference.Where(x => !Result.FileSelectReference.Any(a => $"{x.Key}_ASSIGN" == a.Key)).ToDictionary(x => x.Key, x => x.Value);
            //var considerList = Result.ALLWorkingReference.Where(x => !Result.FileSelectReference.Any(a => $"{x.Key}_ASSIGN" == a.Key)).ToDictionary(x => x.Key, x => x.Value);
            //var ret = VariablesDeclaration(csharpCode, ref considerList);
            //return ret;

            var ret = VariablesDeclaration(csharpCode, Result.FileReference);
            ret = VariablesDeclaration(csharpCode, Result.WorkingStorageReference);
            ret = VariablesDeclaration(csharpCode, Result.LinkageReference);

            return ret;
        }

        public StringBuilder VariablesDeclaration(StringBuilder csharpCode, Dictionary<string, ReferenceModel> considerList)
        {
            var ret = csharpCode;
            if (!considerList.Any()) return ret;

            lastPropName = null;
            alreadyInsideClass = 0;

            foreach (var line in considerList.ToList())
            {
                if (Result.FileSelectReference.Any(a => $"{line.Key}_ASSIGN" == a.Key)) continue;
                if (line.Key == "SQLCA" || line.Key == "SQLCODE" || line.Key == "SQLERRMC" || line.Key == "SQLSTATE" || line.Key == "SQLCAID" || line.Value.PropertyType == "SQLERRD" || line.Value.PropertyType == "SQLCABC" || line.Value.PropertyType == "SQLERRP" || line.Value.PropertyType == "SQLWARN") continue;

                var retorno = ReferenceToCSharpClass(line, ref considerList);

                if (FileResolverHelper.Conf.LogAllLines)
                    ret.AppendLine($"/*\"{line.Value.CurrentLine?.Replace("_", "-")}*/");

                ret.Append(retorno);
            }

            ret.AppendLine(GetClosingBraces());

            return ret;
        }

        private Dictionary<string, List<string>> _constructorVariablesRedefinesDic = new Dictionary<string, List<string>>();
        private string _currentRedefClass = "";
        StringBuilder ReferenceToCSharpClass(KeyValuePair<string, Copybook.Converter.ReferenceModel> line, ref Dictionary<string, ReferenceModel> considerList)
        {
            var ret = new StringBuilder();
            var r = line.Value;
            var localDot = line.Value.PropertyName.Count(x => x.Equals('.'));
            var currentDot = lastPropName?.PropertyName.Count(x => x.Equals('.')) ?? 0;
            var localAlreadyInsideClass = alreadyInsideClass;

            /* EXPLICAÇÃO
             * considerando que cada entrada neste método reflete uma linha de variavel
             * este método está preparado para o seguinte tratamento:
             *   - recebe sempre em ordem que esta no Cobol, não deve ser reordenado
             *   - exemplo:
             *      01 WS_TESTE.
             *        05 WS_TESTE_01 PIC X(1) 
             *        05 WS_TESTE_02 PIC X(1)
             *        05 WS_TESTE_03 PIC X(1)
             *        05 WS_TESTE_04 PIC X(1)
             *        05 WS_TESTE_05.
             *          10 WS_TESTE_10 PIC X(1)
             *          10 WS_TESTE_11 PIC X(1)
             *          10 WS_TESTE_12 PIC X(1)
             *          10 WS_TESTE_13 PIC X(1)
             *          
             *      01 WS_TESTE_1 PIC X(1)
             *      
             *   - a ultima variavel exposta foi o mais crítico, pois precisa fechar as demais "classes" de variaveis
             *   - sendo assim, a matemática é:
             *     - obter a quantidade de "pontos" da variavel anterior com a variavel atual, sendo que uma variavel dentro de uma classe teria 1 ponto :=> WS_TESTE.WS_TESTE_01
             *     - e qualquer variavel que entrar dentro dela terá a mesma quantidade de pontos, só diminuindo caso troque de classe para "menos"
             *     - quando essa troca ocorre, pode acontecer de precisar de mais de 1 "fechamento" dessa forma, obtemos os nomes de cada "ponto" assim, quando forem iguais não geram fechamento, gerando fechamento apenas quando forem diferentes
            */
            if (currentDot > localDot)
                for (var i = 0; i < alreadyInsideClass; i++)
                {
                    var splitedLine = string.Join(".", line.Value.PropertyName.Split(".").Take(alreadyInsideClass - i));
                    var splitedLast = string.Join(".", lastPropName?.PropertyName?.Split(".").Take(alreadyInsideClass - i));
                    if (splitedLast != splitedLine)
                    {
                        var splited = lastPropName?.PropertyName?.Split(".");
                        var taker = splited.Take(alreadyInsideClass - i);

                        var possibleVar = line.Value.PropertyIsCopy ? null : H.GetReferenceProperty($"{taker.LastOrDefault()} OF {taker.FirstOrDefault()}", Result, true);
                        ConstructorRedefinesAdd(ret, possibleVar);

                        ret.AppendLine("}");
                        localAlreadyInsideClass--;
                    }
                }

            alreadyInsideClass = localAlreadyInsideClass;

            var currentVarCheck = r;
            while (!string.IsNullOrWhiteSpace(_currentRedefClass) && currentVarCheck != null)
            {
                var checkCurrentOcc = _currentRedefClass == currentVarCheck.PropertyType && (currentVarCheck.PropertyIsClass && currentVarCheck.PIC == null);

                //correção feita por necessidade do programa VG1613B variavel redefines WS-CHAVE-ANT-R não tinha ValueChanged no construtor
                var checkContainedOcc = _currentRedefClass == H.GetReferenceProperty(currentVarCheck.PropertyParent, Result).PropertyType;
                if (checkCurrentOcc || checkContainedOcc)
                {
                    var tpName = H.GetReferenceProperty(r.PropertyParent, Result).PropertyType;
                    if (!_constructorVariablesRedefinesDic.ContainsKey(tpName))
                        _constructorVariablesRedefinesDic.Add(tpName, new List<string> { line.Key });
                    else
                        _constructorVariablesRedefinesDic[tpName].Add(line.Key);

                    break;
                }

                currentVarCheck = H.GetReferenceProperty(currentVarCheck.PropertyParent, Result);
                if (currentVarCheck?.PropertyParent == currentVarCheck?.PropertyName) currentVarCheck = null;
            }

            if (r.PropertyIsClass)
            {
                ret.Append(ThreatClassToCSharp(line));

                if (r.PIC == null)
                    alreadyInsideClass++;

                lastPropName = r;
            }
            else
            {
                ret.Append(ThreatLineToCSharp(line, ref considerList));
                lastPropName = r;
            }

            return ret;
        }

        private void ConstructorRedefinesAdd(StringBuilder ret, ReferenceModel possibleVar = null)
        {
            if (_constructorVariablesRedefinesDic.Any())
            {
                var dicConsider = _constructorVariablesRedefinesDic.LastOrDefault();
                var ctorName = dicConsider.Key.Replace("ListBasis<", "").Replace(">", "");
                if (possibleVar != null && possibleVar.PropertyType != dicConsider.Key) return;

                ret.AppendLine($@"
                                public {ctorName}()
                                {{
                                    {string.Join(Environment.NewLine, dicConsider.Value.Select(x => $"{x.Split(".").LastOrDefault()}.ValueChanged += OnValueChanged;"))}
                                }}
                            ");

                _constructorVariablesRedefinesDic.Remove(dicConsider.Key);
            }

            if (!_constructorVariablesRedefinesDic.Any())
                _currentRedefClass = "";
        }

        StringBuilder ThreatClassToCSharp(KeyValuePair<string, Copybook.Converter.ReferenceModel> line)
        {
            var ret = new StringBuilder();
            var r = line.Value;
            var keyValue = line.Key?.Split(".")?.LastOrDefault();
            var varName = !string.IsNullOrWhiteSpace(keyValue) ? keyValue : $"REDEF_{line.Value.RedefineName}";
            var isPic = r?.PIC != null;

            if (string.IsNullOrWhiteSpace(varName))
            {
                ret.AppendLine("/* Erro ao converter nome da variavel, nome vazio !");
                return ret;
            }

            if (!r.IsRedefine || string.IsNullOrWhiteSpace(r.RedefineName))
            {
                ret.AppendLine($"public {r.PropertyType} {varName} {{ get; set; }} = new {r.PropertyType}({r.Times});");
            }
            else //neste else ja é REDEFINES
            {

                _currentRedefClass = r.PropertyType;
                var privateName = $"_{varName.ToLower()}";
                //var propType = !isPic ? r.PropertyType : r.DataType.Name;
                var propType = r.PropertyType; //: r.DataType.Name;

                var precValue = propType == typeof(DoubleBasis).Name.ToString() || propType == $"_REDEF_{typeof(DoubleBasis).Name.ToString()}" ? $"{r.DataType.Precision}" : "";
                var commaThrPrecision = !string.IsNullOrEmpty(precValue) ? "," : "";

                var translatedType = !isPic ? $"{propType}({r.Times})" : $"{propType}(new PIC(\"{r.PIC.CobolType}\",\"{r.PIC.CobolLength}\",\"{r.PIC.FullPic}\"){commaThrPrecision}{precValue});";



                ret.AppendLine($@"private {propType} {privateName} {{ get; set; }}");
                ret.AppendLine($@"public {propType} {varName} 
                {{
                    get {{ {privateName} = new {translatedType}; _.Move({r.RedefineName}, {privateName}); VarBasis.RedefinePassValue({r.RedefineName}, {privateName}, {r.RedefineName}); {privateName}.ValueChanged += () => {{ _.Move({privateName}, {r.RedefineName}); }}; return {privateName}; }}
                    set {{ VarBasis.RedefinePassValue(value, {privateName}, {r.RedefineName}); }}
                }}  //Redefines");
            }

            var type = r.PropertyType;
            if (type.Contains("ListBasis"))
                type = type.Replace("ListBasis", "").Replace("<", "").Replace(">", "");

            if (!isPic)
                ret.AppendLine($@"public class {type}:VarBasis
                {{");

            return ret;
        }

        StringBuilder ThreatLineToCSharp(KeyValuePair<string, Copybook.Converter.ReferenceModel> line, ref Dictionary<string, ReferenceModel> considerList)
        {
            var ret = new StringBuilder();
            var r = line.Value;
            var varName = line.Key;

            if (Result.SelectorsList.ContainsKey(varName))
            {
                var selector = Result.SelectorsList[varName];
                var initValue = $"\"{selector?.Pic?.CobolLength}\"";

                if (!string.IsNullOrEmpty(selector?.Value))
                    initValue += $",\"{selector.Value.Replace("'", "").TrimEnd('.')}\"";

                ret.AppendLine(@$"
                    public SelectorBasis {varName.Split(".")?.LastOrDefault()} {{ get; set; }} = new SelectorBasis({initValue})
                    {{
                        Items = new List<SelectorItemBasis> {{
                            {string.Join(",\r\n\t\t\t\t\t\t\t", selector.Items.Select(x => (FileResolverHelper.Conf.LogAllLines ? $"/*\" {x.Line} */\r\n\t\t\t\t\t\t\t" : "") + $"new SelectorItemBasis(\"{x.Name}\", \"{x.Value.Replace("'", "").TrimEnd('.')}\")"))}
                }}
                    }};
                ");

                foreach (var item in selector.Items)
                {
                    var refModel = new ReferenceModel($"{r.PropertyName}[\"{item.Name}\"]", "SelectorBasis", true, nameSpace: "Working");
                    var splited = varName.Split(".").SkipLast(1).ToList();
                    var name = (splited.Count > 0 ? string.Join(".", splited) + "." : "") + item.Name;

                    considerList.Add(name, refModel);
                }

                return ret;
            }

            #region INITIAL VALUE
            var iniVal = r.InitialValue?.TrimStart('\'').TrimEnd('\'') ?? "";

            //tratamento de precisão adicionado
            if (r.PropertyType == typeof(DoubleBasis).Name.ToString())
                iniVal = iniVal.Replace(",", ".").Replace(" ", "");
            else if (r.PropertyType == typeof(StringBasis).Name.ToString())
                iniVal = $@"@""{iniVal}""";
            if (iniVal.Contains("LOW-VALUE"))
                iniVal = iniVal.Replace("LOW-VALUE", "");
            else
                iniVal = $@"{iniVal}";
            #endregion

            var precValue = r.PropertyType == typeof(DoubleBasis).Name.ToString() ? $"{r.PropertyPrecision}" : "";
            var commaThrTimes = !string.IsNullOrEmpty(r.Times) ? "," : "";
            var commaThrIni = !string.IsNullOrEmpty(iniVal) ? "," : "";
            var commaThrPrecision = !string.IsNullOrEmpty(precValue) ? "," : "";

            ret.AppendLine($"public {r.PropertyType} {varName?.Split(".").LastOrDefault()} {{ get; set; }} = new {r.PropertyType}(new PIC(\"{r.PIC.CobolType}\",\"{r.PIC.CobolLength}\",\"{r.PIC.FullPic}\"){commaThrPrecision}{precValue}{commaThrTimes}{r.Times}{commaThrIni}{iniVal});");

            return ret;
        }

        private string GetClosingBraces()
        {
            var ret = new StringBuilder();

            for (int i = alreadyInsideClass; i >= 1; i--)
            {
                ConstructorRedefinesAdd(ret);
                ret.AppendLine($"{new string('\t', i - 1)}}}");
            }

            return ret.ToString();
        }
    }
}
