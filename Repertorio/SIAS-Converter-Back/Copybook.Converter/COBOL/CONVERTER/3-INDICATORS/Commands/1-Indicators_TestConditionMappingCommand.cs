using CobolLanguageConverter.Converter.DIVISION;
using CobolLanguageConverter.Converter.INDICATORS;
using FileResolver.Helper;
using IA_ConverterCommons;
using Newtonsoft.Json;
using System.Text;
using System.Text.RegularExpressions;

namespace CobolLanguageConverter.Converter.Commands.INDICATORS
{
    public class Indicators_TestConditionMappingCommand : IIndicatorsCommand
    {
        public int Order { get; set; } = 35;
        public ResultSet Result { get; set; }

        public StringBuilder Execute(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines, ref dynamic outData)
        {
            if (!FileResolverHelper.Conf.GenerateTestProject) return csharpCode;

            GenerateTestConditionIndicators(csharpCode, ref divisionAndLines, ref outData);
            return csharpCode;
        }

        void GenerateTestConditionIndicators(StringBuilder csharpCode, ref Dictionary<string, List<CurrentLineType>> divisionAndLines, ref dynamic outData)
        {
            //procurar o fluxo principal e qual a porcentagem de cobertura (sem condições) *MainFlowWithoutConditions
            //procurar o fluxo condicional, e qual a porcentagem de cobertura
        }
    }
}
