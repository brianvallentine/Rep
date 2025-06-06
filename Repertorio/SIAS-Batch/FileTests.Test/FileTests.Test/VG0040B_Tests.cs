using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VG0040B;

namespace FileTests.Test
{
    [Collection("VG0040B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VG0040B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.Clear();
            #region PARAMETERS
            #region M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1PAR_RAMO_VG" , ""},
                { "V1PAR_RAMO_AP" , ""},
                { "V1PAR_RAMO_PST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_080_000_LER_V1MOEDA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1EN_COD_MOEDA_IMP" , "2"},
                { "DVLCRUZAD_IMP" , "2"},
            });
            AppSettings.TestSet.DynamicData.Add("M_080_000_LER_V1MOEDA_DB_SELECT_1_Query1", q2);

            #endregion

            #region VG0040B_TMOVIMENTO

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MNUM_APOLICE" , ""},
                { "MCOD_SUBGRUPO" , ""},
                { "MCOD_FONTE" , ""},
                { "MNUM_PROPOSTA" , ""},
                { "MTIPO_SEGURADO" , ""},
                { "MNUM_CERTIFICADO" , ""},
                { "MDAC_CERTIFICADO" , ""},
                { "MTIPO_INCLUSAO" , ""},
                { "MCOD_CLIENTE" , ""},
                { "MCOD_AGENCIADOR" , ""},
                { "MCOD_CORRETOR" , ""},
                { "MCOD_PLANOVGAP" , ""},
                { "MCOD_PLANOAP" , ""},
                { "MFAIXA" , ""},
                { "MAUTOR_AUM_AUTOMAT" , ""},
                { "MTIPO_BENEFICIARIO" , ""},
                { "MPERI_PAGAMENTO" , ""},
                { "MPERI_RENOVACAO" , ""},
                { "MCOD_OCUPACAO" , ""},
                { "MESTADO_CIVIL" , ""},
                { "MIDE_SEXO" , ""},
                { "MCOD_PROFISSAO" , ""},
                { "MNATURALIDADE" , ""},
                { "MOCORR_ENDERECO" , ""},
                { "MOCORR_END_COBRAN" , ""},
                { "MBCO_COBRANCA" , ""},
                { "MAGE_COBRANCA" , ""},
                { "MDAC_COBRANCA" , ""},
                { "MNUM_MATRICULA" , ""},
                { "MNUM_CTA_CORRENTE" , ""},
                { "MDAC_CTA_CORRENTE" , ""},
                { "MVAL_SALARIO" , ""},
                { "MTIPO_SALARIO" , ""},
                { "MTIPO_PLANO" , ""},
                { "MPCT_CONJUGE_VG" , ""},
                { "MPCT_CONJUGE_AP" , ""},
                { "MQTD_SAL_MORNATU" , ""},
                { "MQTD_SAL_MORACID" , ""},
                { "MQTD_SAL_INVPERM" , ""},
                { "MTAXA_AP_MORACID" , ""},
                { "MTAXA_AP_INVPERM" , ""},
                { "MTAXA_AP_AMDS" , ""},
                { "MTAXA_AP_DH" , ""},
                { "MTAXA_AP_DIT" , ""},
                { "MTAXA_VG" , ""},
                { "MIMP_MORNATU_ANT" , ""},
                { "MIMP_MORNATU_ATU" , "2"},
                { "MIMP_MORACID_ANT" , ""},
                { "MIMP_MORACID_ATU" , "1"},
                { "MIMP_INVPERM_ANT" , ""},
                { "MIMP_INVPERM_ATU" , ""},
                { "MIMP_AMDS_ANT" , ""},
                { "MIMP_AMDS_ATU" , ""},
                { "MIMP_DH_ANT" , ""},
                { "MIMP_DH_ATU" , ""},
                { "MIMP_DIT_ANT" , ""},
                { "MIMP_DIT_ATU" , ""},
                { "MPRM_VG_ANT" , ""},
                { "MPRM_VG_ATU" , "2"},
                { "MPRM_AP_ANT" , ""},
                { "MPRM_AP_ATU" , ""},
                { "MCOD_OPERACAO" , ""},
                { "MDATA_OPERACAO" , ""},
                { "COD_SUBGRUPO_TRANS" , ""},
                { "MSIT_REGISTRO" , ""},
                { "MCOD_USUARIO" , ""},
                { "MDATA_AVERBACAO" , ""},
                { "MDATA_ADMISSAO" , ""},
                { "MDATA_INCLUSAO" , ""},
                { "MDATA_NASCIMENTO" , ""},
                { "MDATA_FATURA" , ""},
                { "MDATA_REFERENCIA" , ""},
                { "MDATA_MOVIMENTO" , ""},
                { "SDATA_MOVIMENTO" , ""},
                { "MCOD_EMPRESA" , ""},
                { "V0APOL_RAMO" , ""},
                { "V0APOL_MODALIDA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0040B_TMOVIMENTO", q3);

            #endregion

            #region M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SOCORR_HISTORICO" , ""},
                { "SNUM_ITEM" , ""},
                { "SDATA_TERVIGENCIA" , ""},
                { "WDATA_TERVIGENCIA" , ""},
                { "SDATA_DTTERVIG" , ""},
                { "WDATA_DTTERVIG" , ""},
                { "SSIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0NUM_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_210_010_VERIFICA_PREMIO_VG_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "VGDATA_TERVIGENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_210_010_VERIFICA_PREMIO_VG_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "VGNUM_APOLICE" , ""},
                { "VGNRENDOS" , ""},
                { "VGNUM_ITEM" , ""},
                { "HOCORR_HISTORICO" , ""},
                { "VGRAMOFR" , ""},
                { "VGMODALIFR" , ""},
                { "VGCOD_COBERTURA" , ""},
                { "VGIMP_SEGURADA_IX" , ""},
                { "VGPRM_TARIFARIO_IX" , ""},
                { "VGIMP_SEGURADA_VAR" , ""},
                { "PRM_TARIFARIO_VAR" , ""},
                { "VGPCT_COBERTURA" , ""},
                { "VGFATOR_MULTIPLICA" , ""},
                { "VGDATA_INIVIGENCIA" , ""},
                { "VGDATA_TERVIGENCIA" , ""},
                { "MCOD_EMPRESA" , ""},
                { "VGSITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1", q7);

            #endregion

            #region M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "MNUM_APOLICE" , ""},
                { "MCOD_SUBGRUPO" , ""},
                { "SNUM_ITEM" , ""},
                { "MCOD_OPERACAO" , ""},
                { "V1SISTEMA_DTMOVABE" , ""},
                { "HHORA_OPERACAO" , ""},
                { "MDATA_MOVIMENTO" , ""},
                { "HOCORR_HISTORICO" , ""},
                { "HCOD_SUBGRUP_TRANS" , ""},
                { "MDATA_REFERENCIA" , ""},
                { "MCOD_USUARIO" , ""},
                { "MCOD_EMPRESA" , ""},
                { "V1EN_COD_MOEDA_IMP" , ""},
                { "V1EN_COD_MOEDA_PRM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1", q8);

            #endregion

            #region M_360_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SDATA_DTTERVIG" , ""},
                { "HOCORR_HISTORICO" , ""},
                { "MNUM_CERTIFICADO" , ""},
                { "MTIPO_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_360_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1", q9);

            #endregion

            #region M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""},
                { "MDATA_REFERENCIA" , ""},
                { "MCOD_FONTE" , ""},
                { "MNUM_PROPOSTA" , ""},
                { "MTIPO_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1", q10);

            #endregion

            #region M_390_000_UPDATE_V0MOVIMENTO_DB_SELECT_2_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_NUM_APOLICE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_390_000_UPDATE_V0MOVIMENTO_DB_SELECT_2_Query1", q11);

            #endregion

            #region M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_3_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""},
                { "MNUM_APOLICE" , ""},
                { "MNUM_CERTIFICADO" , ""},
                { "MCOD_SUBGRUPO" , ""},
                { "MCOD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_3_Insert1", q12);

            #endregion

            #region M_390_000_UPDATE_V0MOVIMENTODB_INSERT_4_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""},
                { "MNUM_APOLICE" , ""},
                { "MNUM_CERTIFICADO" , ""},
                { "MCOD_SUBGRUPO" , ""},
                { "MCOD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_390_000_UPDATE_V0MOVIMENTODB_INSERT_4_Insert1", q13);

            #endregion

            #region M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "MCOD_OPERACAO" , ""},
                { "MDATA_OPERACAO" , ""},
                { "MCOD_USUARIO" , ""},
                { "MNUM_PROPOSTA" , ""},
                { "MNUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1", q14);

            #endregion

            #region VG0040B_CDEBTO

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "SNUM_CARNE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VG0040B_CDEBTO", q15);

            #endregion

            #region M_430_000_MIGRACAO_VIDAZUL_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "SNUM_CARNE" , ""},
                { "MNUM_CERTIFICADO" , ""},
                { "MTIPO_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_430_000_MIGRACAO_VIDAZUL_DB_UPDATE_1_Update1", q16);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG0040B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VG0040B();
                program.Execute();
                var envList = AppSettings.TestSet.DynamicData["M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["M_360_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1"].DynamicList;
                var envList3 = AppSettings.TestSet.DynamicData["M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1"].DynamicList;
                var envList4 = AppSettings.TestSet.DynamicData["M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);
                Assert.True(envList3?.Count > 1);
                Assert.True(envList4?.Count > 1);

                Assert.True(envList[1].TryGetValue("VGDATA_TERVIGENCIA", out var valor) && valor == "9999-12-31");

                Assert.True(envList1[1].TryGetValue("V1EN_COD_MOEDA_IMP", out valor) && valor == "0002");

                Assert.True(envList2[1].TryGetValue("HOCORR_HISTORICO", out valor) && valor == "0001");

                Assert.True(envList3[1].TryGetValue("MCOD_FONTE", out valor) && valor == "0000");

                Assert.True(envList4[1].TryGetValue("MCOD_OPERACAO", out valor) && valor == "0000");

            }
        }
    }
}