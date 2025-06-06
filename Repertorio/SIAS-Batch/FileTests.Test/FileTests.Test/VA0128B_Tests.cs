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
using static Code.VA0128B;

namespace FileTests.Test
{
    [Collection("VA0128B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0128B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , ""},
                { "SISTEMA_CURRENT" , ""},
                { "SISTEMA_DTTERCOT" , ""},
                { "SISTEMA_DTINICOT" , ""},
                { "SISTEMA_DTMOV01M" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_RAMO_VGAPC" , ""},
                { "PARAMRAM_RAMO_VG" , ""},
                { "PARAMRAM_RAMO_AP" , ""},
                { "PARAMRAM_RAMO_SAUDE" , ""},
                { "PARAMRAM_RAMO_SA_INDV" , ""},
                { "PARAMRAM_RAMO_EDUCACAO" , ""},
                { "PARAMRAM_NUM_RAMO_PRSTMISTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q1);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PRODVG_TEM_IGPM" , ""},
                { "PRODVG_RAMO" , ""},
                { "PRODVG_COBERADIC_PREMIO" , ""},
                { "PRODVG_CUSTOCAP_TOTAL" , ""},
                { "PRODVG_TEM_CDG" , ""},
                { "PRODVG_TEM_SAF" , ""},
                { "PRODVG_ORIG_PRODU" , ""},
                { "PRODVG_ESTR_COBR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1", q2);

            #endregion

            #region VA0128B_CPROPVA

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_CODCLIEN" , ""},
                { "PROPVA_OCOREND" , ""},
                { "PROPVA_FONTE" , ""},
                { "PROPVA_AGECOBR" , ""},
                { "PROPVA_OPCAO_COBER" , ""},
                { "PROPVA_DTPROXVEN" , ""},
                { "PROPVA_CODOPER" , ""},
                { "PROPVA_DTMOVTO" , ""},
                { "PROPVA_OCORHIST" , ""},
                { "PROPVA_SIT_INTERF" , ""},
                { "PROPVA_TIMESTAMP" , ""},
                { "PROPVA_SEXO" , ""},
                { "PROPVA_EST_CIV" , ""},
                { "PROPVA_DTQITBCO_1YEAR" , ""},
                { "PROPVA_DTQITBCO" , ""},
                { "PROPVA_IDADE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0128B_CPROPVA", q3);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "MOVTO_LIDOS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1", q4);

            #endregion

            #region VA0128B_VGHISRAMC

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "VGHISR_NRCERTIF" , ""},
                { "VGHISR_NUM_RAMO" , ""},
                { "VGHISR_NUM_COBERTURA" , ""},
                { "VGHISR_QTD_COBERTURA" , ""},
                { "VGHISR_IMPSEGURADA" , ""},
                { "VGHISR_CUSTO" , ""},
                { "VGHISR_PREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0128B_VGHISRAMC", q5);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SEGURA_NUM_ITEM" , ""},
                { "SEGURA_FAIXA" , ""},
                { "SEGURA_TXVG" , ""},
                { "SEGURA_TXAPMA" , ""},
                { "SEGURA_TXAPIP" , ""},
                { "SEGURA_TXAPAMDS" , ""},
                { "SEGURA_TXAPDH" , ""},
                { "SEGURA_TXAPDIT" , ""},
                { "SEGURA_SIT_REGISTRO" , ""},
                { "SEGURA_LOT_EMP_SEGURADO" , ""},
                { "SEGURA_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1", q6);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_3_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_DATA_INIVIGENCIA" , ""},
                { "V0RIND_DTMOVTO_1DAY" , ""},
                { "RAMOCOMP_PCT_IOCC_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_3_Query1", q7);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "HISTSG_DTMOVTO_DTTERVIG" , ""},
                { "HISTSG_DTMOVTO_1DAY" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1", q8);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "HISTSG_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1", q9);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_4_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_4_Query1", q10);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "HISTSG_DTMOVTO_ANT" , ""},
                { "HISTSG_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1", q11);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1", q12);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1", q13);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_PERIPGTO" , ""},
                { "OPCAOP_AGECTADEB" , ""},
                { "OPCAOP_OPRCTADEB" , ""},
                { "OPCAOP_NUMCTADEB" , ""},
                { "OPCAOP_DIGCTADEB" , ""},
                { "OPCAOP_OPCAOPAG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1", q14);

            #endregion

            #region M_0200_VERIFICA_COBER_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_NUM_APOLICE" , ""},
                { "CONDITEC_COD_SUBGRUPO" , ""},
                { "CONDITEC_QTD_SAL_MORNATU" , ""},
                { "CONDITEC_QTD_SAL_MORACID" , ""},
                { "CONDITEC_QTD_SAL_INVPERM" , ""},
                { "CONDITEC_TAXA_AP_MORACID" , ""},
                { "CONDITEC_TAXA_AP_INVPERM" , ""},
                { "CONDITEC_TAXA_AP_AMDS" , ""},
                { "CONDITEC_TAXA_AP_DH" , ""},
                { "CONDITEC_TAXA_AP_DIT" , ""},
                { "CONDITEC_TAXA_AP" , ""},
                { "CONDITEC_CARREGA_PRINCIPAL" , ""},
                { "CONDITEC_CARREGA_CONJUGE" , ""},
                { "CONDITEC_CARREGA_FILHOS" , ""},
                { "CONDITEC_GARAN_ADIC_IEA" , ""},
                { "CONDITEC_GARAN_ADIC_IPA" , ""},
                { "CONDITEC_GARAN_ADIC_IPD" , ""},
                { "CONDITEC_GARAN_ADIC_HD" , ""},
                { "CONDITEC_TAXA_DESPESA_ADM" , ""},
                { "CONDITEC_TAXA_IRB" , ""},
                { "CONDITEC_LIM_CAP_MORNATU" , ""},
                { "CONDITEC_LIM_CAP_MORACID" , ""},
                { "CONDITEC_LIM_CAP_INVAPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0200_VERIFICA_COBER_DB_SELECT_1_Query1", q15);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , ""},
                { "HISCOBPR_OCORR_HISTORICO" , ""},
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_DATA_TERVIGENCIA" , ""},
                { "HISCOBPR_IMPSEGUR" , ""},
                { "HISCOBPR_QUANT_VIDAS" , ""},
                { "HISCOBPR_IMPSEGIND" , ""},
                { "HISCOBPR_COD_OPERACAO" , ""},
                { "HISCOBPR_OPCAO_COBERTURA" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPMORACID" , ""},
                { "HISCOBPR_IMPINVPERM" , ""},
                { "HISCOBPR_IMPAMDS" , ""},
                { "HISCOBPR_IMPDH" , ""},
                { "HISCOBPR_IMPDIT" , ""},
                { "HISCOBPR_VLPREMIO" , ""},
                { "HISCOBPR_PRMVG" , ""},
                { "HISCOBPR_PRMAP" , ""},
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , ""},
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , ""},
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , ""},
                { "HISCOBPR_IMPSEGCDG" , ""},
                { "HISCOBPR_VLCUSTCDG" , ""},
                { "HISCOBPR_COD_USUARIO" , ""},
                { "HISCOBPR_TIMESTAMP" , ""},
                { "HISCOBPR_IMPSEGAUXF" , ""},
                { "HISCOBPR_VLCUSTAUXF" , ""},
                { "HISCOBPR_PRMDIT" , ""},
                { "HISCOBPR_QTMDIT" , ""},
                { "HISCOBPR_DTINIVIG_1DAY" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1", q16);

            #endregion

            #region M_0200_VERIFICA_COBER_DB_SELECT_2_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "FAIXAETA_TAXA_VG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0200_VERIFICA_COBER_DB_SELECT_2_Query1", q17);

            #endregion

            #region M_0200_VERIFICA_COBER_DB_SELECT_3_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "FAIXASAL_TAXA_VG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0200_VERIFICA_COBER_DB_SELECT_3_Query1", q18);

            #endregion

            #region M_0300_CORRIGE_IOF_DB_UPDATE_1_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "DATA_MOVIMENTO" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_CORRIGE_IOF_DB_UPDATE_1_Update1", q19);

            #endregion

            #region M_0300_PROPAUTOM_DB_INSERT_1_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_FONTE" , ""},
                { "FONTE_PROPAUTOM" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_CODCLIEN" , ""},
                { "SEGURA_FAIXA" , ""},
                { "OPCAOP_PERIPGTO" , ""},
                { "PROPVA_EST_CIV" , ""},
                { "PROPVA_SEXO" , ""},
                { "PROPVA_AGECOBR" , ""},
                { "MNUM_CTA_CORRENTE" , ""},
                { "MDAC_CTA_CORRENTE" , ""},
                { "SEGURA_TXAPMA" , ""},
                { "SEGURA_TXAPIP" , ""},
                { "SEGURA_TXAPAMDS" , ""},
                { "SEGURA_TXAPDH" , ""},
                { "SEGURA_TXAPDIT" , ""},
                { "SEGURA_TXVG" , ""},
                { "LK_PU_MORTE_NATURAL" , ""},
                { "LK_PU_MORTE_ACIDENTAL" , ""},
                { "LK_PU_INV_PERMANENTE" , ""},
                { "LK_PU_ASS_MEDICA" , ""},
                { "LK_PU_DI_HOSPITALAR" , ""},
                { "LK_PU_DI_INTERNACAO" , ""},
                { "HISCOBPR_PRMVG" , ""},
                { "COBERP_PRMVG_ATU" , ""},
                { "HISCOBPR_PRMAP" , ""},
                { "COBERP_PRMAP_ATU" , ""},
                { "COD_OPERACAO" , ""},
                { "SISTEMA_DTMOVABE" , ""},
                { "CLIENT_DTNASC" , ""},
                { "DATA_MOVIMENTO" , ""},
                { "SEGURA_LOT_EMP_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_PROPAUTOM_DB_INSERT_1_Insert1", q20);

            #endregion

            #region M_0300_PROPAUTOM_DB_UPDATE_1_Update1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""},
                { "PROPVA_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_PROPAUTOM_DB_UPDATE_1_Update1", q21);

            #endregion

            #region M_0300_CORRIGE_IOF_DB_UPDATE_2_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_CORRIGE_IOF_DB_UPDATE_2_Update1", q22);

            #endregion

            #region M_0300_CORRIGE_IOF_DB_INSERT_1_Insert1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_OCORHIST" , ""},
                { "DATA_MOVIMENTO" , ""},
                { "HISCOBPR_IMPSEGUR" , ""},
                { "HISCOBPR_QUANT_VIDAS" , ""},
                { "HISCOBPR_IMPSEGIND" , ""},
                { "COD_OPERACAO" , ""},
                { "HISCOBPR_OPCAO_COBERTURA" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPMORACID" , ""},
                { "HISCOBPR_IMPINVPERM" , ""},
                { "HISCOBPR_IMPAMDS" , ""},
                { "HISCOBPR_IMPDH" , ""},
                { "HISCOBPR_IMPDIT" , ""},
                { "COBERP_VLPREMIO_ATU" , ""},
                { "COBERP_PRMVG_ATU" , ""},
                { "COBERP_PRMAP_ATU" , ""},
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , ""},
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , ""},
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , ""},
                { "HISCOBPR_IMPSEGCDG" , ""},
                { "HISCOBPR_VLCUSTCDG" , ""},
                { "HISCOBPR_IMPSEGAUXF" , ""},
                { "HISCOBPR_VLCUSTAUXF" , ""},
                { "COBERP_PRMDIT_ATU" , ""},
                { "HISCOBPR_QTMDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_CORRIGE_IOF_DB_INSERT_1_Insert1", q23);

            #endregion

            #region M_0300_CORRIGE_IOF_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_CORRIGE_IOF_DB_SELECT_1_Query1", q24);

            #endregion

            #region M_0300_CORRIGE_IOF_DB_UPDATE_3_Update1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_OCORHIST" , ""},
                { "DATA_MOVIMENTO" , ""},
                { "COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_CORRIGE_IOF_DB_UPDATE_3_Update1", q25);

            #endregion

            #region M_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "COBERP_NRCERTIF" , ""},
                { "COBERP_OCORHIST" , ""},
                { "COBERP_DTINIVIG" , ""},
                { "COBERP_DTTERVIG" , ""},
                { "COBERP_IMPSEGUR" , ""},
                { "COBERP_QUANT_VIDAS" , ""},
                { "COBERP_IMPSEGIND" , ""},
                { "COBERP_CODOPER" , ""},
                { "COBERP_OPCAO_COBER" , ""},
                { "COBERP_IMPMORNATU_ATU" , ""},
                { "COBERP_IMPMORACID_ATU" , ""},
                { "COBERP_IMPINVPERM_ATU" , ""},
                { "COBERP_IMPAMDS_ATU" , ""},
                { "COBERP_IMPDH_ATU" , ""},
                { "COBERP_IMPDIT_ATU" , ""},
                { "COBERP_VLPREMIO_ATU" , ""},
                { "COBERP_PRMVG_ATU" , ""},
                { "COBERP_PRMAP_ATU" , ""},
                { "COBERP_QTTITCAP" , ""},
                { "COBERP_VLTITCAP" , ""},
                { "COBERP_VLCUSTCAP" , ""},
                { "COBERP_IMPSEGCDG" , ""},
                { "COBERP_VLCUSTCDG" , ""},
                { "COBERP_IMPSEGAUXF" , ""},
                { "COBERP_VLCUSTAUXF" , ""},
                { "COBERP_PRMDIT_ATU" , ""},
                { "COBERP_QTDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1", q26);

            #endregion

            #region VA0128B_VGHISTACE

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "VGHISA_NRCERTIF" , ""},
                { "VGHISA_NUM_ACESSORIO" , ""},
                { "VGHISA_QTD_COBERTURA" , ""},
                { "VGHISA_IMPSEGURADA" , ""},
                { "VGHISA_CUSTO" , ""},
                { "VGHISA_PREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0128B_VGHISTACE", q27);

            #endregion

            #region M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1_Insert1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "VGHISR_NRCERTIF" , ""},
                { "COBERP_OCORHIST" , ""},
                { "VGHISR_NUM_RAMO" , ""},
                { "VGHISR_NUM_COBERTURA" , ""},
                { "VGHISR_QTD_COBERTURA" , ""},
                { "VGHISR_IMPSEGURADA" , ""},
                { "VGHISR_CUSTO" , ""},
                { "VGHISR_PREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1_Insert1", q28);

            #endregion

            #region M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1_Insert1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "VGHISA_NRCERTIF" , ""},
                { "COBERP_OCORHIST" , ""},
                { "VGHISA_NUM_ACESSORIO" , ""},
                { "VGHISA_QTD_COBERTURA" , ""},
                { "VGHISA_IMPSEGURADA" , ""},
                { "VGHISA_CUSTO" , ""},
                { "VGHISA_PREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1_Insert1", q29);

            #endregion

            VG0710S_Tests.Load_Parameters();

            #endregion
        }

        [Fact]
        public static void VA0128B_Tests_Fact_ReturnCode_0()
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

                #region VA0128B_CPROPVA

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "1"},
                { "PROPVA_CODSUBES" , "2"},
                { "PROPVA_NRCERTIF" , "10019790324"},
                { "PROPVA_CODCLIEN" , ""},
                { "PROPVA_OCOREND" , ""},
                { "PROPVA_FONTE" , "12"},
                { "PROPVA_AGECOBR" , ""},
                { "PROPVA_OPCAO_COBER" , ""},
                { "PROPVA_DTPROXVEN" , ""},
                { "PROPVA_CODOPER" , ""},
                { "PROPVA_DTMOVTO" , ""},
                { "PROPVA_OCORHIST" , ""},
                { "PROPVA_SIT_INTERF" , ""},
                { "PROPVA_TIMESTAMP" , ""},
                { "PROPVA_SEXO" , ""},
                { "PROPVA_EST_CIV" , ""},
                { "PROPVA_DTQITBCO_1YEAR" , ""},
                { "PROPVA_DTQITBCO" , ""},
                { "PROPVA_IDADE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VA0128B_CPROPVA");
                AppSettings.TestSet.DynamicData.Add("VA0128B_CPROPVA", q3);

                #endregion
                #region M_0200_VERIFICA_COBER_DB_SELECT_2_Query1
                AppSettings.TestSet.DynamicData.Remove("M_0200_VERIFICA_COBER_DB_SELECT_2_Query1");

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "FAIXAETA_TAXA_VG" , "1"}
            });
                AppSettings.TestSet.DynamicData.Add("M_0200_VERIFICA_COBER_DB_SELECT_2_Query1", q17);

                #endregion
                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1");

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , ""},
                { "HISCOBPR_OCORR_HISTORICO" , ""},
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_DATA_TERVIGENCIA" , ""},
                { "HISCOBPR_IMPSEGUR" , "1"},
                { "HISCOBPR_QUANT_VIDAS" , ""},
                { "HISCOBPR_IMPSEGIND" , "1"},
                { "HISCOBPR_COD_OPERACAO" , ""},
                { "HISCOBPR_OPCAO_COBERTURA" , ""},
                { "HISCOBPR_IMP_MORNATU" , "12"},
                { "HISCOBPR_IMPMORACID" , "12"},
                { "HISCOBPR_IMPINVPERM" , "12"},
                { "HISCOBPR_IMPAMDS" , ""},
                { "HISCOBPR_IMPDH" , ""},
                { "HISCOBPR_IMPDIT" , ""},
                { "HISCOBPR_VLPREMIO" , ""},
                { "HISCOBPR_PRMVG" , "1"},
                { "HISCOBPR_PRMAP" , "1"},
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , ""},
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , ""},
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , ""},
                { "HISCOBPR_IMPSEGCDG" , ""},
                { "HISCOBPR_VLCUSTCDG" , ""},
                { "HISCOBPR_COD_USUARIO" , ""},
                { "HISCOBPR_TIMESTAMP" , ""},
                { "HISCOBPR_IMPSEGAUXF" , ""},
                { "HISCOBPR_VLCUSTAUXF" , ""},
                { "HISCOBPR_PRMDIT" , ""},
                { "HISCOBPR_QTMDIT" , ""},
                { "HISCOBPR_DTINIVIG_1DAY" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1", q16);

                #endregion
                #region M_0200_VERIFICA_COBER_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("M_0200_VERIFICA_COBER_DB_SELECT_1_Query1");

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_NUM_APOLICE" , ""},
                { "CONDITEC_COD_SUBGRUPO" , ""},
                { "CONDITEC_QTD_SAL_MORNATU" , ""},
                { "CONDITEC_QTD_SAL_MORACID" , ""},
                { "CONDITEC_QTD_SAL_INVPERM" , ""},
                { "CONDITEC_TAXA_AP_MORACID" , "1"},
                { "CONDITEC_TAXA_AP_INVPERM" , ""},
                { "CONDITEC_TAXA_AP_AMDS" , ""},
                { "CONDITEC_TAXA_AP_DH" , ""},
                { "CONDITEC_TAXA_AP_DIT" , ""},
                { "CONDITEC_TAXA_AP" , ""},
                { "CONDITEC_CARREGA_PRINCIPAL" , ""},
                { "CONDITEC_CARREGA_CONJUGE" , ""},
                { "CONDITEC_CARREGA_FILHOS" , ""},
                { "CONDITEC_GARAN_ADIC_IEA" , ""},
                { "CONDITEC_GARAN_ADIC_IPA" , ""},
                { "CONDITEC_GARAN_ADIC_IPD" , ""},
                { "CONDITEC_GARAN_ADIC_HD" , ""},
                { "CONDITEC_TAXA_DESPESA_ADM" , ""},
                { "CONDITEC_TAXA_IRB" , ""},
                { "CONDITEC_LIM_CAP_MORNATU" , ""},
                { "CONDITEC_LIM_CAP_MORACID" , ""},
                { "CONDITEC_LIM_CAP_INVAPER" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("M_0200_VERIFICA_COBER_DB_SELECT_1_Query1", q15);

                #endregion
                #region M_0000_PRINCIPAL_DB_SELECT_3_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_DATA_INIVIGENCIA" , "2020-01-01"},
                { "V0RIND_DTMOVTO_1DAY" , ""},
                { "RAMOCOMP_PCT_IOCC_RAMO" , "5"},
                }); 
                q7.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_DATA_INIVIGENCIA" , "2020-01-02"},
                { "V0RIND_DTMOVTO_1DAY" , ""},
                { "RAMOCOMP_PCT_IOCC_RAMO" , "6"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_3_Query1", q7);

                #endregion
                #region M_0000_PRINCIPAL_DB_SELECT_4_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , "10"}
                }); q10.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , "11"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_4_Query1", q10);

                #endregion
                #region VA0128B_VGHISRAMC

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "VGHISR_NRCERTIF" , "1005932"},
                { "VGHISR_NUM_RAMO" , ""},
                { "VGHISR_NUM_COBERTURA" , ""},
                { "VGHISR_QTD_COBERTURA" , ""},
                { "VGHISR_IMPSEGURADA" , ""},
                { "VGHISR_CUSTO" , ""},
                { "VGHISR_PREMIO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VA0128B_VGHISRAMC");
                AppSettings.TestSet.DynamicData.Add("VA0128B_VGHISRAMC", q5);

                #endregion
                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "PRODVG_TEM_IGPM" , ""},
                { "PRODVG_RAMO" , ""},
                { "PRODVG_COBERADIC_PREMIO" , ""},
                { "PRODVG_CUSTOCAP_TOTAL" , ""},
                { "PRODVG_TEM_CDG" , ""},
                { "PRODVG_TEM_SAF" , ""},
                { "PRODVG_ORIG_PRODU" , "MULT      "},
                { "PRODVG_ESTR_COBR" , "MULT      "},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1", q2);

                #endregion
                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , "1953-04-22"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1", q12);

                #endregion
                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_PERIPGTO" , ""},
                { "OPCAOP_AGECTADEB" , ""},
                { "OPCAOP_OPRCTADEB" , ""},
                { "OPCAOP_NUMCTADEB" , ""},
                { "OPCAOP_DIGCTADEB" , ""},
                { "OPCAOP_OPCAOPAG" , "3"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1", q14);

                #endregion
                #region VA0128B_VGHISTACE

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "VGHISA_NRCERTIF" , "1025963"},
                { "VGHISA_NUM_ACESSORIO" , ""},
                { "VGHISA_QTD_COBERTURA" , ""},
                { "VGHISA_IMPSEGURADA" , ""},
                { "VGHISA_CUSTO" , ""},
                { "VGHISA_PREMIO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VA0128B_VGHISTACE");
                AppSettings.TestSet.DynamicData.Add("VA0128B_VGHISTACE", q27);

                #endregion

                #region VG0710S

                #region M_1000_COBERTURAS_DB_SELECT_2_Query1
                AppSettings.TestSet.DynamicData.Remove("M_1000_COBERTURAS_DB_SELECT_2_Query1");

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VALCPR" , "2"}
            });
                AppSettings.TestSet.DynamicData.Add("M_1000_COBERTURAS_DB_SELECT_2_Query1", q6);

                #endregion

                #region M_1000_COBERTURAS_DB_SELECT_3_Query1
                AppSettings.TestSet.DynamicData.Remove("M_1000_COBERTURAS_DB_SELECT_3_Query1");

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "CIMP_SEGURADA_VG" , "2"},
                { "CPRM_TARIFARIO_VG" , "2"},
                { "CFATOR_MULTIPLICA" , "2"},
            });
                AppSettings.TestSet.DynamicData.Add("M_1000_COBERTURAS_DB_SELECT_3_Query1", q8);

                #endregion
                #endregion
                #endregion
                var program = new VA0128B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 0);

                //M_0300_CORRIGE_IOF_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["M_0300_CORRIGE_IOF_DB_UPDATE_1_Update1"].DynamicList;
                //Assert.True(envList0[1].TryGetValue("PROPVA_NRCERTIF", out var valor0) && valor0.Contains("000010019790324"));

                //M_0300_PROPAUTOM_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["M_0300_PROPAUTOM_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("PROPVA_NRCERTIF", out var valor1) && valor1.Contains("000010019790324"));
                Assert.True(envList1.Count > 1);

                //M_0300_PROPAUTOM_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["M_0300_PROPAUTOM_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("PROPVA_FONTE", out var valor2) && valor2.Contains("12"));

                //M_0300_CORRIGE_IOF_DB_UPDATE_2_Update1
                var envList3 = AppSettings.TestSet.DynamicData["M_0300_CORRIGE_IOF_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("PROPVA_NRCERTIF", out var valor3) && valor3.Contains("000010019790324"));

                //M_0300_CORRIGE_IOF_DB_INSERT_1_Insert1
                var envList4 = AppSettings.TestSet.DynamicData["M_0300_CORRIGE_IOF_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("COD_OPERACAO", out var valor4) && valor4.Contains("0796"));
                Assert.True(envList4.Count > 1);

                //M_0300_CORRIGE_IOF_DB_UPDATE_3_Update1
                var envList5 = AppSettings.TestSet.DynamicData["M_0300_CORRIGE_IOF_DB_UPDATE_3_Update1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("DATA_MOVIMENTO", out var valor5) && valor5.Contains("2020-01-01"));

                //M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1_Insert1
                var envList6 = AppSettings.TestSet.DynamicData["M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList6[1].TryGetValue("VGHISR_NRCERTIF", out var valor6) && valor6.Contains("1005932"));
                Assert.True(envList6.Count > 1);

                //M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1_Insert1
                var envList7 = AppSettings.TestSet.DynamicData["M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList7[1].TryGetValue("VGHISA_NRCERTIF", out var valor7) && valor7.Contains("1025963"));
                Assert.True(envList7.Count > 1);


            }
        }
        [Fact]
        public static void VA0128B_Tests_Fact_SemMudarAliq_ReturnCode_00()
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

                #region M_0000_PRINCIPAL_DB_SELECT_3_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_DATA_INIVIGENCIA" , "2020-01-01"},
                { "V0RIND_DTMOVTO_1DAY" , ""},
                { "RAMOCOMP_PCT_IOCC_RAMO" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_3_Query1", q7);

                #endregion
                #region M_0000_PRINCIPAL_DB_SELECT_4_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , "0"}
                }); 
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_4_Query1", q10);

                #endregion

                #endregion
                var program = new VA0128B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 00);
                Assert.True(program.V0RIND_PCIOF_ATU == program.V0RIND_PCIOF_ANT);

            }
        }
        [Fact]
        public static void VA0128B_Tests_Fact_SemMudarAliq_ReturnCode_99()
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

                #region M_0000_PRINCIPAL_DB_SELECT_3_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_DATA_INIVIGENCIA" , "2020-01-01"},
                { "V0RIND_DTMOVTO_1DAY" , ""},
                { "RAMOCOMP_PCT_IOCC_RAMO" , ""},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_3_Query1", q7);

                #endregion
                #endregion
                var program = new VA0128B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 9);

            }
        }
    }
}