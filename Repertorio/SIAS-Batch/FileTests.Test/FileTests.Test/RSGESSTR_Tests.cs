using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Copies;
using Code;
using static Code.RSGESSTR;

namespace FileTests.Test
{
    [Collection("RSGESSTR_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class RSGESSTR_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #endregion
        }

        [Fact]
        public static void RSGESSTR_Tests_Fact_ConverteGeral()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var param = new RSGEWSTR();
                param.LK_RSGEWSTR_FUNCAO.Value = 1;
                param.LK_RSGEWSTR_INP_STR.LK_RSGEWSTR_INP_STR_LGTH.Value = 100;
                param.LK_RSGEWSTR_INP_STR.LK_RSGEWSTR_INP_STR_DATA.Value = "DADOS";
                param.LK_RSGEWSTR_INP_NUM.LK_RSGEWSTR_INP_NUM_DATA.Value = "";
                #endregion
                var program = new RSGESSTR();
                program.Execute(param);

                Assert.True(program.RSGEWSTR.LK_RSGEWSTR_IND_ERRO.Value == 0);
                Assert.True(program.RSGEWSTR.LK_RSGEWSTR_FUNCAO.Value == 1);
                Assert.True(program.RSGEWSTR.LK_RSGEWSTR_INP_STR.LK_RSGEWSTR_INP_STR_DATA.Value == "DADOS");
            }
        }
        [Fact]
        public static void RSGESSTR_Tests_Fact_Erro()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var param = new RSGEWSTR();
                param.LK_RSGEWSTR_FUNCAO.Value = 6;
                param.LK_RSGEWSTR_INP_STR.LK_RSGEWSTR_INP_STR_LGTH.Value = 0;
                #endregion
                var program = new RSGESSTR();
                program.Execute(param);

                Assert.True(program.RSGEWSTR.LK_RSGEWSTR_IND_ERRO.Value == 5);
                Assert.True(program.RSGEWSTR.LK_RSGEWSTR_FUNCAO.Value == 6);
            }
        }
    }
}