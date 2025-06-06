using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VG0030B;
using Sias.VidaEmGrupo.DB2.VG0030B;

namespace FileTests.Test
{
    [Collection("VG0030B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VG0030B_Tests
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
                { "V1SISTEMA_DTMOVABE" , "2024-08-21"},
                { "V1SISTEMA_DTMOVABE_1" , "2024-08-20"},
            });
            AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1PAR_RAMO_VG" , "93"},
                { "V1PAR_RAMO_AP" , "82"},
                { "V1PAR_RAMO_PST" , "77"},
            });
            AppSettings.TestSet.DynamicData.Add("M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_080_000_LER_V1MOEDA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1EN_COD_MOEDA_IMP" , "1"},
                { "DVLCRUZAD_IMP" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("M_080_000_LER_V1MOEDA_DB_SELECT_1_Query1", q2);

            #endregion

            #region VG0030B_TMOVIMENTO

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                {"MNUM_APOLICE" , "97010000889"},
                {"MCOD_SUBGRUPO" , "1948"},
                {"MCOD_FONTE" , "15"},
                {"MNUM_PROPOSTA" , "13933236"},
                {"MTIPO_SEGURADO" , "1"},
                {"MNUM_CERTIFICADO" , "10001618480"},
                {"MDAC_CERTIFICADO" , "3"},
                {"MTIPO_INCLUSAO" , "4"},
                {"MCOD_CLIENTE" , "232954"},
                {"MCOD_AGENCIADOR" , "0"},
                {"MCOD_CORRETOR" , "0"},
                {"MCOD_PLANOVGAP" , "2005"},
                {"MCOD_PLANOAP" , "0"},
                {"MFAIXA" , "1"},
                {"MAUTOR_AUM_AUTOMAT" , "S"},
                {"MTIPO_BENEFICIARIO" , "N"},
                {"MPERI_PAGAMENTO" , "0"},
                {"MPERI_RENOVACAO" , "8"},
                {"MCOD_OCUPACAO" , "    "},
                {"MESTADO_CIVIL" , "V"},
                {"MIDE_SEXO" , "M"},
                {"MCOD_PROFISSAO" , "0"},
                {"MNATURALIDADE" , "IRATI                         "},
                {"MOCORR_ENDERECO" , "6"},
                {"MOCORR_END_COBRAN" , "5"},
                {"MBCO_COBRANCA" , "104"},
                {"MAGE_COBRANCA" , "390"},
                {"MDAC_COBRANCA" , " "},
                {"MNUM_MATRICULA" , "0"},
                {"MNUM_CTA_CORRENTE" , "0"},
                {"MDAC_CTA_CORRENTE" , " "},
                {"MVAL_SALARIO" , "0.00"},
                {"MTIPO_SALARIO" , " "},
                {"MTIPO_PLANO" , "1"},
                {"MPCT_CONJUGE_VG" , "0.00"},
                {"MPCT_CONJUGE_AP" , "0.00"},
                {"MQTD_SAL_MORNATU" , "0"},
                {"MQTD_SAL_MORACID" , "0"},
                {"MQTD_SAL_INVPERM" , "0"},
                {"MTAXA_AP_MORACID" , "0.1285"},
                {"MTAXA_AP_INVPERM" , "0.1285"},
                {"MTAXA_AP_AMDS" , "0.0000"},
                {"MTAXA_AP_DH" , "0.0000"},
                {"MTAXA_AP_DIT" , "0.0000"},
                {"MTAXA_VG" , "0.4200"},
                {"MIMP_MORNATU_ANT" , "464247.56"},
                {"MIMP_MORNATU_ATU" , "464247.56"},
                {"MIMP_MORACID_ANT" , "928495.03"},
                {"MIMP_MORACID_ATU" , "928495.03"},
                {"MIMP_INVPERM_ANT" , "464247.56"},
                {"MIMP_INVPERM_ATU" , "464247.56"},
                {"MIMP_AMDS_ANT" , "0.00"},
                {"MIMP_AMDS_ATU" , "0.00"},
                {"MIMP_DH_ANT" , "0.00"},
                {"MIMP_DH_ATU" , "0.00"},
                {"MIMP_DIT_ANT" , "0.00"},
                {"MIMP_DIT_ATU" , "0.00"},
                {"MPRM_VG_ANT" , "181.07"},
                {"MPRM_VG_ATU" , "181.07"},
                {"MPRM_AP_ANT" , "77.74"},
                {"MPRM_AP_ATU" , "77.74"},
                {"MCOD_OPERACAO" , "402"},
                {"MDATA_OPERACAO" , "2024-03-13"},
                {"COD_SUBGRUPO_TRANS" , "0"},
                {"MSIT_REGISTRO" , "1"},
                {"MCOD_USUARIO" , "SIHBA   "},
                {"MDATA_AVERBACAO" , "2024-03-13"},
                {"MDATA_ADMISSAO" , "1999-08-05"},
                {"MDATA_INCLUSAO" , "null"},
                {"MDATA_NASCIMENTO" , "1962-12-14"},
                {"MDATA_FATURA" , "null"},
                {"MDATA_REFERENCIA" , "2024-04-01"},
                {"MDATA_MOVIMENTO" , "2023-11-21"},
                {"SDATA_MOVIMENTO" , "2023-11-20"},
                {"MCOD_EMPRESA" , "null"},
                {"V0APOL_RAMO" , "97"},
                {"V0APOL_MODALIDA" , "0"}
            });
            AppSettings.TestSet.DynamicData.Add("VG0030B_TMOVIMENTO", q3);

            #endregion

            #region M_095_000_CALCULO_QTD_PROCESSAR_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WS_QTD_A_PROCESSAR" , "77741"}
            });
            AppSettings.TestSet.DynamicData.Add("M_095_000_CALCULO_QTD_PROCESSAR_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SOCORR_HISTORICO" , "28"},
                { "SNUM_ITEM" , "514289"},
                { "SSIT_REGISTRO" , "9"},
            });
            AppSettings.TestSet.DynamicData.Add("M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT_MOV" , "0"}
            });
            AppSettings.TestSet.DynamicData.Add("M_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SDATA_MOVIMENTO" , ""},
                { "MNUM_APOLICE" , ""},
                { "SNUM_ITEM" , ""},
                { "SOCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1_Update1", q7);

            #endregion

            #region M_190_000_BUSCA_V0COBERAPOL_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "DATA_INIVIGENCIA_C" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_190_000_BUSCA_V0COBERAPOL_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "VGNUM_APOLICE" , ""},
                { "VGNRENDOS" , ""},
                { "VGNUM_ITEM" , ""},
                { "MAX_OCORR_HIST" , ""},
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
                { "VGCOD_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1", q9);

            #endregion

            #region M_310_000_SELECIONA_V0COBERAPOL_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "MAX_OCORR_HIST" , "29"}
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "MAX_OCORR_HIST" , "29"}
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "MAX_OCORR_HIST" , "29"}
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "MAX_OCORR_HIST" , "29"}
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "MAX_OCORR_HIST" , "29"}
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "MAX_OCORR_HIST" , "29"}
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "MAX_OCORR_HIST" , "29"}
            });
            AppSettings.TestSet.DynamicData.Add("M_310_000_SELECIONA_V0COBERAPOL_DB_SELECT_1_Query1", q10);

            #endregion

            #region M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1", q11);

            #endregion

            #region M_360_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "HOCORR_HISTORICO" , ""},
                { "MNUM_CERTIFICADO" , ""},
                { "MTIPO_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_360_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1", q12);

            #endregion

            #region M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""},
                { "MDATA_REFERENCIA" , ""},
                { "MCOD_FONTE" , ""},
                { "MNUM_PROPOSTA" , ""},
                { "MTIPO_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1", q13);

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

            #region M_430_000_UPDATE_CARENCIAS_DB_UPDATE_1_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "MNUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_430_000_UPDATE_CARENCIAS_DB_UPDATE_1_Update1", q15);

            #endregion

            #region M_500_000_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRPARCELA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_500_000_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1", q16);

            #endregion

            #region M_510_000_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRTIT" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0HCOB_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_510_000_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1", q17);

            #endregion

            #region M_520_000_SELECT_V0PARCELVA_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_PRMVG" , ""},
                { "V0PARC_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_520_000_SELECT_V0PARCELVA_DB_SELECT_1_Query1", q18);

            #endregion

            #region M_530_000_INCLUI_DB_INSERT_1_Insert1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "MNUM_CERTIFICADO" , ""},
                { "V0PROP_NRPARCELA" , ""},
                { "V0HCOB_NRTIT" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "MNUM_APOLICE" , ""},
                { "MCOD_SUBGRUPO" , ""},
                { "MCOD_FONTE" , ""},
                { "V0PARC_PRMVG" , ""},
                { "V0PARC_PRMAP" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "MCOD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_530_000_INCLUI_DB_INSERT_1_Insert1", q19);

            #endregion

            #region M_530_000_INCLUI_DB_SELECT_2_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0HCON_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_530_000_INCLUI_DB_SELECT_2_Query1", q20);

            #endregion

            #region M_530_000_INCLUI_DB_UPDATE_3_Update1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_OCORHIST" , ""},
                { "MNUM_CERTIFICADO" , ""},
                { "V0PROP_NRPARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_530_000_INCLUI_DB_UPDATE_3_Update1", q21);

            #endregion

            #region M_600_000_VER_ORIG_PRODUTO_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "WTIPO_FATURAMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_600_000_VER_ORIG_PRODUTO_DB_SELECT_1_Query1", q22);

            #endregion

            #region M_600_000_VER_ORIG_PRODUTO_DB_SELECT_2_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "WORIG_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_600_000_VER_ORIG_PRODUTO_DB_SELECT_2_Query1", q23);

            #endregion

            #region M_600_000_VER_ORIG_PRODUTO_DB_SELECT_3_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "WNUM_CERTIFICADO" , ""},
                { "WSIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_600_000_VER_ORIG_PRODUTO_DB_SELECT_3_Query1", q24);

            #endregion

            #region M_610_000_CONSULTA_APOLCOBER_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "SNUM_ITEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_610_000_CONSULTA_APOLCOBER_DB_SELECT_1_Query1", q25);

            #endregion

            #region M_610_000_CONSULTA_APOLCOBER_DB_SELECT_2_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "MIMP_MORNATU_ATU" , ""},
                { "MPRM_VG_ATU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_610_000_CONSULTA_APOLCOBER_DB_SELECT_2_Query1", q26);

            #endregion

            #region M_610_000_CONSULTA_APOLCOBER_DB_SELECT_3_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "MIMP_MORACID_ATU" , ""},
                { "MPRM_AP_ATU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_610_000_CONSULTA_APOLCOBER_DB_SELECT_3_Query1", q27);

            #endregion

            #region M_610_000_CONSULTA_APOLCOBER_DB_SELECT_4_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "MIMP_INVPERM_ATU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_610_000_CONSULTA_APOLCOBER_DB_SELECT_4_Query1", q28);

            #endregion

            #region M_610_000_CONSULTA_APOLCOBER_DB_SELECT_5_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "MIMP_DIT_ATU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_610_000_CONSULTA_APOLCOBER_DB_SELECT_5_Query1", q29);

            #endregion

            #region M_615_000_CONSULTA_HISCOBER_VG_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "WIMP_MORNATU_ATU" , ""},
                { "WPRM_VG_ATU" , ""},
                { "WQUANT_VIDAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_615_000_CONSULTA_HISCOBER_VG_DB_SELECT_1_Query1", q30);

            #endregion

            #region M_620_000_CONSULTA_HISCOBER_AP_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "WIMP_MORACID_ATU" , ""},
                { "WPRM_AP_ATU" , ""},
                { "WQUANT_VIDAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_620_000_CONSULTA_HISCOBER_AP_DB_SELECT_1_Query1", q31);

            #endregion

            #region M_625_000_CONSULTA_HISCOBER_DB_SELECT_1_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "WPRM_VG_ATU" , ""},
                { "WPRM_AP_ATU" , ""},
                { "WIMP_MORNATU_ATU" , ""},
                { "WIMP_MORACID_ATU" , ""},
                { "WQUANT_VIDAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_625_000_CONSULTA_HISCOBER_DB_SELECT_1_Query1", q32);

            #endregion

            #region M_630_000_CONSULTA_HISCOBER_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "MPRM_VG_ATU" , ""},
                { "MPRM_AP_ATU" , ""},
                { "MIMP_MORNATU_ATU" , ""},
                { "MIMP_MORACID_ATU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_630_000_CONSULTA_HISCOBER_DB_SELECT_1_Query1", q33);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG0030B_Tests_Fact()
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
                var program = new VG0030B();
                program.Execute();
                
                var envList = AppSettings.TestSet.DynamicData["M_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1_Update1"].DynamicList;
                                Assert.True(envList[1].TryGetValue("SDATA_MOVIMENTO", out var val5r) && val5r.Contains("2023-11-20"));
                Assert.True(envList[1].TryGetValue("MNUM_APOLICE", out var val6r) && val6r.Contains("0097010000889"));
                Assert.True(envList[1].TryGetValue("SNUM_ITEM", out var val7r) && val7r.Contains("000514289"));

                var envList1 = AppSettings.TestSet.DynamicData["M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("VGNUM_APOLICE", out var val8r) && val8r.Contains("0097010000889"));


                Assert.True(true);
            }
        }
    }
}