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
using static Code.VG0716S;

namespace FileTests.Test
{
    [Collection("VG0716S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VG0716S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0105_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0105_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region SEGUROS_SPBVG012_Call1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "LK_NUM_PLANO_FC12" , ""},
                { "LK_NUM_PROPOSTA_FC12" , ""},
                { "LK_COD_RAMO_FC12" , ""},
                { "LK_TRACE_FC12" , ""},
                { "LK_OUT_COD_RET_FC12" , ""},
                { "LK_OUT_SQLCODE_FC12" , ""},
                { "LK_OUT_MENSAGEM_FC12" , ""},
                { "LK_OUT_SQLERRMC_FC12" , ""},
                { "LK_OUT_SQLSTATE_FC12" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SEGUROS_SPBVG012_Call1", q1);

            #endregion

            #region R1010_00_SELECT_TITFEDCA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_NRTITFDCAP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1010_00_SELECT_TITFEDCA_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1100_10_INSERT_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_NUM_CERTIFICADO" , ""},
                { "FONTES_COD_FONTE" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "MOVFEDCA_VAL_CUSTO_CAPITALI" , ""},
                { "MOVFEDCA_NRTITFDCAP" , ""},
                { "MOVFEDCA_NUM_SEQUENCIA" , ""},
                { "PRODUVG_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_10_INSERT_DB_INSERT_1_Insert1", q3);

            #endregion

            #region R1150_00_SELECT_TITFEDCA_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "TITFEDCA_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1150_00_SELECT_TITFEDCA_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1200_10_INSERT_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_NRTITFDCAP" , ""},
                { "TITFEDCA_NUM_CERTIFICADO" , ""},
                { "TITFEDCA_DATA_INIVIGENCIA" , ""},
                { "TITFEDCA_DATA_TERVIGENCIA" , ""},
                { "TITFEDCA_NRSORTEIO" , ""},
                { "TITFEDCA_VAL_CUSTO_TITULO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_10_INSERT_DB_INSERT_1_Insert1", q5);

            #endregion

            #region R1300_10_INSERT_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_NRTITFDCAP" , ""},
                { "PARFEDCA_VAL_CUSTO_TITULO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_10_INSERT_DB_INSERT_1_Insert1", q6);

            #endregion

            #region R1400_10_UPDATE_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "TITFEDCA_DATA_INIVIGENCIA" , ""},
                { "TITFEDCA_DATA_TERVIGENCIA" , ""},
                { "TITFEDCA_NUM_CERTIFICADO" , ""},
                { "MOVFEDCA_NRTITFDCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_10_UPDATE_DB_UPDATE_1_Update1", q7);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData(123456789, 123456789, 123456789, 123456789, 123456789, 123456789, 123456789, 123456789, "VG0716S_DTH_INI_VIGENCIA_P", "VG0716S_DTH_FIM_VIGENCIA_P", "VG0716S_DES_COMBINACAO_P", "VG0716S_COD_STA_TITULO_P", 123456789, 123456789, "VG0716S_DES_MENSAGEM_P")]
        public static void VG0716S_Tests_Theory(int VG0716S_COD_FONTE_P, int VG0716S_COD_PRODUTO_P, int VG0716S_NUM_PROPOSTA_P, double VG0716S_VLR_MENSALIDADE_P, int VG0716S_NUM_PLANO_P, int VG0716S_NUM_SERIE_P, int VG0716S_NUM_TITULO_P, int VG0716S_IND_DV_P, string VG0716S_DTH_INI_VIGENCIA_P, string VG0716S_DTH_FIM_VIGENCIA_P, string VG0716S_DES_COMBINACAO_P, string VG0716S_COD_STA_TITULO_P, int VG0716S_SQLCODE_P, int VG0716S_COD_RETORNO_P, string VG0716S_DES_MENSAGEM_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            VG0716S_DTH_INI_VIGENCIA_P = $"{VG0716S_DTH_INI_VIGENCIA_P}_{timestamp}.txt";
            VG0716S_DTH_FIM_VIGENCIA_P = $"{VG0716S_DTH_FIM_VIGENCIA_P}_{timestamp}.txt";
            VG0716S_DES_COMBINACAO_P = $"{VG0716S_DES_COMBINACAO_P}_{timestamp}.txt";
            VG0716S_COD_STA_TITULO_P = $"{VG0716S_COD_STA_TITULO_P}_{timestamp}.txt";
            VG0716S_DES_MENSAGEM_P = $"{VG0716S_DES_MENSAGEM_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                var q00 = new DynamicData();
                q00.AddDynamic(new Dictionary<string, string>{
                { "WF_NUM_PLANO" , ""},
                { "WF_NUM_SERIE" , ""},
                { "WF_NUM_TITULO" , ""},
                { "WF_COD_STA_TITULO" , ""},
                { "WF_COD_SUB_STATUS" , ""},
                { "WF_DTH_ATIVACAO" , ""},
                { "WF_DTH_CADUCACAO" , ""},
                { "WF_DTH_CRIACAO" , ""},
                { "WF_DTH_FIM_VIGENCIA" , ""},
                { "WF_DTH_INI_SORTEIO" , ""},
                { "WF_DTH_INI_VIGENCIA" , ""},
                { "WF_DTH_SUSPENSAO" , ""},
                { "WF_IND_DV" , ""},
                { "WF_VLR_MENSALIDADE" , ""},
                { "WF_NUM_PROPOSTA" , ""},
                { "WF_NUM_MOD_PLANO" , ""},
                { "WF_DES_COMBINACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("VG0716S_C01_RESULT", q00);

                AppSettings.TestSet.DynamicData.Remove("SEGUROS_SPBVG012_Call1");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "LK_NUM_PLANO_FC12" , "5050"},
                { "LK_NUM_PROPOSTA_FC12" , "6060"},
                { "LK_COD_RAMO_FC12" , ""},
                { "LK_TRACE_FC12" , ""},
                { "LK_OUT_COD_RET_FC12" , ""},
                { "LK_OUT_SQLCODE_FC12" , ""},
                { "LK_OUT_MENSAGEM_FC12" , ""},
                { "LK_OUT_SQLERRMC_FC12" , ""},
                { "LK_OUT_SQLSTATE_FC12" , ""},
                }, sqlcaFetch: new SQLCA(466));
                AppSettings.TestSet.DynamicData.Add("SEGUROS_SPBVG012_Call1", q1);

                AppSettings.TestSet.DynamicData.Remove("R1010_00_SELECT_TITFEDCA_DB_SELECT_1_Query1");
                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R1010_00_SELECT_TITFEDCA_DB_SELECT_1_Query1", q2);

                #endregion

                var program = new VG0716S();
                program.Execute(new IntBasis(null, VG0716S_COD_FONTE_P), new IntBasis(null, VG0716S_COD_PRODUTO_P), new IntBasis(null, VG0716S_NUM_PROPOSTA_P), new DoubleBasis(null, 2, VG0716S_VLR_MENSALIDADE_P), new IntBasis(null, VG0716S_NUM_PLANO_P), new IntBasis(null, VG0716S_NUM_SERIE_P), new IntBasis(null, VG0716S_NUM_TITULO_P), new IntBasis(null, VG0716S_IND_DV_P), new StringBasis(null, VG0716S_DTH_INI_VIGENCIA_P), new StringBasis(null, VG0716S_DTH_FIM_VIGENCIA_P), new StringBasis(null, VG0716S_DES_COMBINACAO_P), new StringBasis(null, VG0716S_COD_STA_TITULO_P), new IntBasis(null, VG0716S_SQLCODE_P), new IntBasis(null, VG0716S_COD_RETORNO_P), new StringBasis(null, VG0716S_DES_MENSAGEM_P));

                var envList = AppSettings.TestSet.DynamicData["R1100_10_INSERT_DB_INSERT_1_Insert1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R1200_10_INSERT_DB_INSERT_1_Insert1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R1300_10_INSERT_DB_INSERT_1_Insert1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);

                Assert.True(envList[1].TryGetValue("MOVFEDCA_NUM_CERTIFICADO", out string valor) && valor == "000000123456789");
                Assert.True(envList1[1].TryGetValue("TITFEDCA_NUM_CERTIFICADO", out valor) && valor == "000000123456789");
                Assert.True(envList2[1].TryGetValue("MOVFEDCA_NRTITFDCAP", out valor) && valor == "000000000000");
            }
        }
    }
}