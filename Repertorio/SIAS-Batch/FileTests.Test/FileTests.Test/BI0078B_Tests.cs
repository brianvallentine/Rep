using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.BI0078B;

namespace FileTests.Test
{
    [Collection("BI0078B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class BI0078B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region BI0078B_C01_RESULT

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "WF_NUM_PLANO" , "12345"},
                { "WF_NUM_SERIE" , "45325"},
                { "WF_NUM_TITULO" , "45252"},
                { "WF_COD_STA_TITULO" , "A"},
                { "WF_COD_SUB_STATUS" , "A"},
                { "WF_DTH_ATIVACAO" , "2020-01-01"},
                { "WF_DTH_CADUCACAO" , "2020-01-01"},
                { "WF_DTH_CRIACAO" , "2023-01-01"},
                { "WF_DTH_FIM_VIGENCIA" , "2024-10-25"},
                { "WF_DTH_INI_SORTEIO" , "2025-01-01"},
                { "WF_DTH_INI_VIGENCIA" , "2025-01-01"},
                { "WF_DTH_SUSPENSAO" , "2025-01-01"},
                { "WF_IND_DV" , "1"},
                { "WF_VLR_MENSALIDADE" , "11000"},
                { "WF_NUM_PROPOSTA" , "123123123"},
                { "WF_NUM_MOD_PLANO" , "12"},
                { "WF_DES_COMBINACAO" , "1212"},
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "WF_NUM_PLANO" , "12345"},
                { "WF_NUM_SERIE" , "45325"},
                { "WF_NUM_TITULO" , "45252"},
                { "WF_COD_STA_TITULO" , "A"},
                { "WF_COD_SUB_STATUS" , "A"},
                { "WF_DTH_ATIVACAO" , "2020-01-01"},
                { "WF_DTH_CADUCACAO" , "2020-01-01"},
                { "WF_DTH_CRIACAO" , "2023-01-01"},
                { "WF_DTH_FIM_VIGENCIA" , "2024-10-25"},
                { "WF_DTH_INI_SORTEIO" , "2025-01-01"},
                { "WF_DTH_INI_VIGENCIA" , "2025-01-01"},
                { "WF_DTH_SUSPENSAO" , "2025-01-01"},
                { "WF_IND_DV" , "1"},
                { "WF_VLR_MENSALIDADE" , "11000"},
                { "WF_NUM_PROPOSTA" , "123123123"},
                { "WF_NUM_MOD_PLANO" , "12"},
                { "WF_DES_COMBINACAO" , "1212"},
            });
            AppSettings.TestSet.DynamicData.Add("BI0078B_C01_RESULT", q0);

            #endregion

            #region R0050_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-10-28"},
                { "WS_DATA_MOVT_10" , "2024-10-08"},
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-10-28"},
                { "WS_DATA_MOVT_10" , "2024-10-08"},
            });
            AppSettings.TestSet.DynamicData.Add("R0050_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q1);

            #endregion

            #region BI0078B_CBILRENOV

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , "82599762440"},
                { "BILCOBER_COD_PRODUTO" , "8104"},
                { "BILCOBER_VAL_MAX_COBER_BAS" , "1"},
                { "PARAMGER_COD_EMPRESA_CAP" , ""},
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , "82599762440"},
                { "BILCOBER_COD_PRODUTO" , "8104"},
                { "BILCOBER_VAL_MAX_COBER_BAS" , "1"},
                { "PARAMGER_COD_EMPRESA_CAP" , ""},
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , "82599762440"},
                { "BILCOBER_COD_PRODUTO" , "8104"},
                { "BILCOBER_VAL_MAX_COBER_BAS" , "1"},
                { "PARAMGER_COD_EMPRESA_CAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI0078B_CBILRENOV", q2);

            #endregion

            #region R1400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1", q3);

            #endregion

            #region SEGUROS_SPBVG012_Call1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "LK_NUM_PLANO_FC12" , "EXECUTADO"},
                { "LK_NUM_PROPOSTA_FC12" , ""},
                { "LK_COD_RAMO_FC12" , ""},
                { "LK_TRACE_FC12" , ""},
                { "LK_OUT_COD_RET_FC12" , ""},
                { "LK_OUT_SQLCODE_FC12" , ""},
                { "LK_OUT_MENSAGEM_FC12" , ""},
                { "LK_OUT_SQLERRMC_FC12" , ""},
                { "LK_OUT_SQLSTATE_FC12" , ""},
            }, new SQLCA(466));
            AppSettings.TestSet.DynamicData.Add("SEGUROS_SPBVG012_Call1", q4);

            #endregion

            VG0105S_Tests.Load_Parameters();
            #endregion
        }

        [Fact]
        public static void BI0078B_Tests_Fact()
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
                #endregion
                var program = new BI0078B();
                program.Execute();

                //R1400_00_INSERT_COMFEDCA_Insert1
                var envList3 = AppSettings.TestSet.DynamicData["R1400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1"].DynamicList;
                //Assert.True(envList3?.Count > 1);
                //Assert.True(envList3[1].TryGetValue("BILHETE_NUM_BILHETE", out var val7r) && val7r.Contains("82599762440"));

                //Verifica se a SP SEGUROS.SPBVG012 foi chamada
                Assert.True(program.WS_WORK_AREAS.TEM_TITULO["W88_TEM_TITULO"]);


                Assert.True(program.RETURN_CODE == 9);
            }
        }
        [Fact]
        public static void BI0078B_Tests_FactErro99()
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
                #region R0050_00_SELECT_SISTEMAS_Query1

                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0050_00_SELECT_SISTEMAS_Query1");
                AppSettings.TestSet.DynamicData.Add("R0050_00_SELECT_SISTEMAS_Query1", q1);

                #endregion

                #endregion
                var program = new BI0078B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 9);
            }
        }
    }
}