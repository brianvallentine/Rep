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
using static Code.GE0071S;

namespace FileTests.Test
{
    [Collection("GE0071S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class GE0071S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region GE0071S_GE0071S_C01

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "GE091_COD_COBERTURA" , ""},
                { "GE091_VLR_IS" , ""},
                { "GE091_VLR_PREMIO" , ""},
                { "GE091_PCT_PARTICIPACAO" , ""},
                { "GE118_IND_TIPO_COBERTURA" , ""},
                { "GE118_IND_SINISTRO_CANCELA" , ""},
                { "GE118_IND_INDENIZA_MAIS_VEZES" , ""},
                { "GE118_COD_RAMO_COBERTURA" , ""},
                { "GE118_DES_APRESENTA_DOC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("GE0071S_GE0071S_C01", q0);

            #endregion

            #region P0050_05_INICIO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0050_05_INICIO_DB_SELECT_1_Query1", q1);

            #endregion

            #region P0101_05_INICIO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "GE089_IND_FLUXO_PARAMTRIZADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0101_05_INICIO_DB_SELECT_1_Query1", q2);

            #endregion

            #region P0201_05_INICIO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "GE090_COD_OPC_COBERTURA" , "33"},
                { "GE090_NUM_IDADE_INI" , ""},
                { "GE090_NUM_IDADE_FIM" , ""},
                { "GE090_COD_OPC_PLANO" , "22"},
                { "GE090_VLR_INI_PREMIO" , ""},
                { "GE090_VLR_FIM_PREMIO" , ""},
                { "GE090_PCT_IOF" , ""},
                { "GE090_PCT_REENQUADRAMENTO" , ""},
                { "GE090_IND_PERMIT_VENDA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0201_05_INICIO_DB_SELECT_1_Query1", q3);

            #endregion

            #region P0202_05_INICIO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "GE090_COD_OPC_COBERTURA" , ""},
                { "GE090_NUM_IDADE_INI" , ""},
                { "GE090_NUM_IDADE_FIM" , ""},
                { "GE090_COD_OPC_PLANO" , ""},
                { "GE090_VLR_INI_PREMIO" , ""},
                { "GE090_VLR_FIM_PREMIO" , ""},
                { "GE090_PCT_IOF" , ""},
                { "GE090_PCT_REENQUADRAMENTO" , ""},
                { "GE090_IND_PERMIT_VENDA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0202_05_INICIO_DB_SELECT_1_Query1", q4);

            #endregion

            #endregion
        }

        [Fact]
        public static void GE0071S_Tests_Fact_ReturnCodeError_1()
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
                var param = new GE0071W();
                param.LK_0071_E_ACAO.Value = 1;
                param.LK_0071_E_TRACE.Value = "S";
                param.LK_0071_E_COD_USUARIO.Value = "TESTE";
                param.LK_0071_E_NOM_PROGRAMA.Value = "GE0071S";
                #endregion
                var program = new GE0071S();
                program.Execute(param, new GE0071W_LK_0071_S_ARR());

                Assert.True(program.GE0071W.LK_0071_S_ARR.LK_0071_IND_ERRO.Value == 1);
            }
        }
        [Fact]
        public static void GE0071S_Tests_Fact_ReturnCodeOk_1()
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
                var param = new GE0071W();
                param.LK_0071_E_ACAO.Value = 1;
                param.LK_0071_E_TRACE.Value = "S";
                param.LK_0071_E_COD_USUARIO.Value = "TESTE";
                param.LK_0071_E_NOM_PROGRAMA.Value = "GE0071S";
                param.LK_0071_I_COD_OPC_COBERTURA.Value = "12";
                param.LK_0071_S_QTD_OCC.Value = 100;
                #endregion
                var program = new GE0071S();
                program.Execute(param, new GE0071W_LK_0071_S_ARR());

                Assert.True(program.GE0071W.LK_0071_S_ARR.LK_0071_IND_ERRO.Value == 0);
                Assert.True(program.GE0071W.LK_0071_I_COD_OPC_PLANO.Value == 22);
            }
        }
    }
}