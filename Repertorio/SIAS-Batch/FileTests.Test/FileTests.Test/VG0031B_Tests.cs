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
using static Code.VG0031B;

namespace FileTests.Test
{
    [Collection("VG0031B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG0031B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region VG0031B_V0RELATORIOS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1REL_COD_USUR" , ""},
                { "V1REL_CODRELAT" , ""},
                { "V1REL_NUM_APOL" , ""},
                { "V1REL_COD_SUBG" , ""},
                { "V1REL_SIT_REGISTRO" , ""},
                { "V1REL_APOL_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0031B_V0RELATORIOS", q1);

            #endregion

            #region VG0031B_V0SUBGRUPO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0SUBG_NUM_APOL" , ""},
                { "V0SUBG_COD_SUBG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0031B_V0SUBGRUPO", q2);

            #endregion

            #region R0215_00_LER_V1PARAMRAMO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1PAR_RAMO_VG" , ""},
                { "V1PAR_RAMO_AP" , ""},
                { "V1PAR_RAMO_PST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0215_00_LER_V1PARAMRAMO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0220_10_UPDATE_ENDOSSO_ZERO_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1REL_NUM_APOL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0220_10_UPDATE_ENDOSSO_ZERO_DB_UPDATE_1_Update1", q4);

            #endregion

            #region R0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1REL_NUM_APOL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_2_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V0PROP_CODOPER" , ""},
                { "V1REL_NUM_APOL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_2_Update1", q6);

            #endregion

            #region VG0031B_V0SEGURAVG

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0SEG_NUM_APOL" , ""},
                { "V0SEG_COD_SUBG" , ""},
                { "V0SEG_NUM_CERTIF" , ""},
                { "V0SEG_DAC_CERTIF" , ""},
                { "V0SEG_TP_SEGURADO" , ""},
                { "V0SEG_NUM_ITEM" , ""},
                { "V0SEG_TP_INCLUSAO" , ""},
                { "V0SEG_COD_CLIENTE" , ""},
                { "V0SEG_COD_FONTE" , ""},
                { "V0SEG_NUM_PROPOSTA" , ""},
                { "V0SEG_AGENCIADOR" , ""},
                { "V0SEG_CORRETOR" , ""},
                { "V0SEG_CD_PLANOVGAP" , ""},
                { "V0SEG_CD_PLANOAP" , ""},
                { "V0SEG_FAIXA" , ""},
                { "V0SEG_AUT_AUM_AUT" , ""},
                { "V0SEG_TP_BENEFICIA" , ""},
                { "V0SEG_OCORR_HIST" , ""},
                { "V0SEG_PERI_PGTO" , ""},
                { "V0SEG_PERI_RENOVA" , ""},
                { "V0SEG_NUM_CARNE" , ""},
                { "V0SEG_COD_OCUPACAO" , ""},
                { "V0SEG_EST_CIVIL" , ""},
                { "V0SEG_SEXO" , ""},
                { "V0SEG_CD_PROFISSAO" , ""},
                { "V0SEG_NATURALIDADE" , ""},
                { "V0SEG_OCOR_ENDERE" , ""},
                { "V0SEG_OCOR_END_COB" , ""},
                { "V0SEG_BCO_COBRANCA" , ""},
                { "V0SEG_AGE_COBRANCA" , ""},
                { "V0SEG_DAC_COBRANCA" , ""},
                { "V0SEG_NUM_MATRIC" , ""},
                { "V0SEG_VAL_SALARIO" , ""},
                { "V0SEG_TP_SALARIO" , ""},
                { "V0SEG_TP_PLANO" , ""},
                { "V0SEG_DT_INIVIG" , ""},
                { "V0SEG_PCT_CONJ_VG" , ""},
                { "V0SEG_PCT_CONJ_AP" , ""},
                { "V0SEG_QTD_S_MONATU" , ""},
                { "V0SEG_QTD_S_MOACID" , ""},
                { "V0SEG_QTD_S_INVPER" , ""},
                { "V0SEG_TX_AP_MOACID" , ""},
                { "V0SEG_TX_AP_INVPER" , ""},
                { "V0SEG_TX_AP_AMDS" , ""},
                { "V0SEG_TX_AP_DH" , ""},
                { "V0SEG_TX_AP_DIT" , ""},
                { "V0SEG_TAXA_AP" , ""},
                { "V0SEG_TAXA_VG" , ""},
                { "V0SEG_SIT_REGISTRO" , ""},
                { "V0SEG_DT_ADMISSAO" , ""},
                { "V0SEG_DT_NASCI" , ""},
                { "V0SEG_LOT_EMP_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0031B_V0SEGURAVG", q7);

            #endregion

            #region R0223_00_PROCESSA_V0SUBGRUPO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_CODPRODU" , ""},
                { "V0PROD_NOMPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0223_00_PROCESSA_V0SUBGRUPO_DB_SELECT_1_Query1", q8);

            #endregion

            #region R0224_00_OBTER_DT_REFERENCIA_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1FATC_DT_REFER" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0224_00_OBTER_DT_REFERENCIA_DB_SELECT_1_Query1", q9);

            #endregion

            #region R0224_00_OBTER_DT_REFERENCIA_DB_SELECT_2_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1FATC_DT_REFER" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0224_00_OBTER_DT_REFERENCIA_DB_SELECT_2_Query1", q10);

            #endregion

            #region VG0031B_V1ENDOSSO

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_NUM_APOL" , ""},
                { "V1ENDO_NRENDOS" , ""},
                { "V1ENDO_DTEMIS" , ""},
                { "V1ENDO_DTINIVIG" , ""},
                { "V1ENDO_DTTERVIG" , ""},
                { "V1ENDO_BCORCAP" , ""},
                { "V1ENDO_AGERCAP" , ""},
                { "V1ENDO_DACRCAP" , ""},
                { "V1ENDO_BCOCOBR" , ""},
                { "V1ENDO_AGECOBR" , ""},
                { "V1ENDO_DACCOBR" , ""},
                { "V1ENDO_QTPARCEL" , ""},
                { "V1ENDO_ORGAO" , ""},
                { "V1ENDO_RAMO" , ""},
                { "V1ENDO_CODPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0031B_V1ENDOSSO", q11);

            #endregion

            #region RB224_00_LER_APOL_EXPURGO_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "APOLIEXP_NUM_APOLICE" , "123456"},
                { "APOLIEXP_NUM_ITEM" , ""},
                { "APOLIEXP_ID_MESTRE_EXPURGO" , ""},
                { "APOLIEXP_RAMO" , ""},
                { "APOLIEXP_SITUACAO_APOLICE" , ""},
                { "APOLIEXP_DATA_SITUACAO" , ""},
                { "APOLIEXP_COD_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("RB224_00_LER_APOL_EXPURGO_DB_SELECT_1_Query1", q12);

            #endregion

            #region RD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "RETOREXP_NUM_APOLICE" , ""},
                { "RETOREXP_SITUACAO_RETORNO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("RD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1_Query1", q13);

            #endregion

            #region RE224_00_GRAVAR_TORNO_EXPURGO_DB_INSERT_1_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "APOLIEXP_NUM_APOLICE" , ""},
                { "APOLIEXP_NUM_ITEM" , ""},
                { "APOLIEXP_ID_MESTRE_EXPURGO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("RE224_00_GRAVAR_TORNO_EXPURGO_DB_INSERT_1_Insert1", q14);

            #endregion

            #region R0224_25_OBTER_NUM_PROPOSTA_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0FONTE_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0224_25_OBTER_NUM_PROPOSTA_DB_SELECT_1_Query1", q15);

            #endregion

            #region R0224_25_OBTER_NUM_PROPOSTA_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0FONTE_PROPAUTOM" , ""},
                { "V0SEG_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0224_25_OBTER_NUM_PROPOSTA_DB_UPDATE_1_Update1", q16);

            #endregion

            #region R0224_30_SELECT_V0HISTSEG_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V1HSEG_DT_MOVTO" , ""},
                { "V1HSEG_MOEDA_IMP" , ""},
                { "V1HSEG_MOEDA_PRM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0224_30_SELECT_V0HISTSEG_DB_SELECT_1_Query1", q17);

            #endregion

            #region R0224_32_UPD_SEGURAVG_DB_UPDATE_1_Update1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0SEG_NUM_APOL" , ""},
                { "V0SEG_NUM_ITEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0224_32_UPD_SEGURAVG_DB_UPDATE_1_Update1", q18);

            #endregion

            #region R0224_35_OBTER_MOEDA_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V0VLCRUZAD_IMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0224_35_OBTER_MOEDA_DB_SELECT_1_Query1", q19);

            #endregion

            #region R0224_35_OBTER_MOEDA_DB_SELECT_2_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0VLCRUZAD_PRM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0224_35_OBTER_MOEDA_DB_SELECT_2_Query1", q20);

            #endregion

            #region R0224_45_SELECT_V1COBERAPOL_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0CBA_NUM_APOLICE" , ""},
                { "V0CBA_NRENDOS" , ""},
                { "V0CBA_NUM_ITEM" , ""},
                { "V0CBA_OCOR_HIST" , ""},
                { "V0CBA_RAMOFR" , ""},
                { "V0CBA_MODALIFR" , ""},
                { "V0CBA_CD_COBERTURA" , ""},
                { "V0CBA_IMP_SEGURADA" , ""},
                { "V0CBA_PR_TARIFARIO" , ""},
                { "V0CBA_FATOR_MULTIP" , ""},
                { "V0CBA_DTINIVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0224_45_SELECT_V1COBERAPOL_DB_SELECT_1_Query1", q21);

            #endregion

            #region R0224_46_SELECT_V1COBERAPOL_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V0CBA_NUM_APOLICE" , ""},
                { "V0CBA_NRENDOS" , ""},
                { "V0CBA_NUM_ITEM" , ""},
                { "V0CBA_OCOR_HIST" , ""},
                { "V0CBA_RAMOFR" , ""},
                { "V0CBA_MODALIFR" , ""},
                { "V0CBA_CD_COBERTURA" , ""},
                { "V0CBA_IMP_SEGURADA" , ""},
                { "V0CBA_PR_TARIFARIO" , ""},
                { "V0CBA_FATOR_MULTIP" , ""},
                { "V0CBA_DTINIVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0224_46_SELECT_V1COBERAPOL_DB_SELECT_1_Query1", q22);

            #endregion

            #region R0224_50_OBTER_CONTA_CORR_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0CTAC_COD_CLIENTE" , ""},
                { "V0CTAC_NUM_APOLICE" , ""},
                { "V0CTAC_NUM_CTA_COR" , ""},
                { "V0CTAC_DAC_CTA_COR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0224_50_OBTER_CONTA_CORR_DB_SELECT_1_Query1", q23);

            #endregion

            #region R0224_55_CANCELA_SEGURADO_DB_INSERT_1_Insert1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V0SEG_NUM_APOL" , ""},
                { "V0SEG_COD_SUBG" , ""},
                { "V0SEG_COD_FONTE" , ""},
                { "V0FONTE_PROPAUTOM" , ""},
                { "V0SEG_TP_SEGURADO" , ""},
                { "V0SEG_NUM_CERTIF" , ""},
                { "V0SEG_DAC_CERTIF" , ""},
                { "V0SEG_TP_INCLUSAO" , ""},
                { "V0SEG_COD_CLIENTE" , ""},
                { "V0SEG_AGENCIADOR" , ""},
                { "V0SEG_CORRETOR" , ""},
                { "V0SEG_CD_PLANOVGAP" , ""},
                { "V0SEG_CD_PLANOAP" , ""},
                { "V0SEG_FAIXA" , ""},
                { "V0SEG_AUT_AUM_AUT" , ""},
                { "V0SEG_TP_BENEFICIA" , ""},
                { "V0SEG_PERI_PGTO" , ""},
                { "V0SEG_PERI_RENOVA" , ""},
                { "V0SEG_COD_OCUPACAO" , ""},
                { "V0SEG_EST_CIVIL" , ""},
                { "V0SEG_SEXO" , ""},
                { "V0SEG_CD_PROFISSAO" , ""},
                { "V0SEG_NATURALIDADE" , ""},
                { "V0SEG_OCOR_ENDERE" , ""},
                { "V0SEG_OCOR_END_COB" , ""},
                { "V0SEG_BCO_COBRANCA" , ""},
                { "V0SEG_AGE_COBRANCA" , ""},
                { "V0SEG_DAC_COBRANCA" , ""},
                { "V0SEG_NUM_MATRIC" , ""},
                { "V0CTAC_NUM_CTA_COR" , ""},
                { "V0CTAC_DAC_CTA_COR" , ""},
                { "V0SEG_VAL_SALARIO" , ""},
                { "V0SEG_TP_SALARIO" , ""},
                { "V0SEG_TP_PLANO" , ""},
                { "V0SEG_PCT_CONJ_VG" , ""},
                { "V0SEG_PCT_CONJ_AP" , ""},
                { "V0SEG_QTD_S_MONATU" , ""},
                { "V0SEG_QTD_S_MOACID" , ""},
                { "V0SEG_QTD_S_INVPER" , ""},
                { "V0SEG_TX_AP_MOACID" , ""},
                { "V0SEG_TX_AP_INVPER" , ""},
                { "V0SEG_TX_AP_AMDS" , ""},
                { "V0SEG_TX_AP_DH" , ""},
                { "V0SEG_TX_AP_DIT" , ""},
                { "V0SEG_TAXA_VG" , ""},
                { "V0MOV_IMP_MORNATU" , ""},
                { "V0MOV_IMP_MORACID" , ""},
                { "V0MOV_IMP_INVPERM" , ""},
                { "V0MOV_IMP_AMDS" , ""},
                { "V0MOV_IMP_DH" , ""},
                { "V0MOV_IMP_DIT" , ""},
                { "V0MOV_PRM_VG" , ""},
                { "V0MOV_PRM_AP" , ""},
                { "V1SIST_DTMOVABE" , ""},
                { "V0SEG_DT_ADMISSAO" , ""},
                { "V0SEG_DT_NASCI" , ""},
                { "V1FATC_DT_REFER" , ""},
                { "V0SEG_LOT_EMP_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0224_55_CANCELA_SEGURADO_DB_INSERT_1_Insert1", q24);

            #endregion

            #region VG0031B_V1PARCELA

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUM_APOL" , ""},
                { "V1PARC_NRENDOS" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1PARC_DACPARC" , ""},
                { "V1PARC_FONTE" , ""},
                { "V1PARC_NRTIT" , ""},
                { "V1PARC_OCORHIST" , ""},
                { "V1PARC_QTDDOC" , ""},
                { "V1PARC_SITUACAO" , ""},
                { "V1PARC_COD_EMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0031B_V1PARCELA", q25);

            #endregion

            #region R0230_35_SELECT_NUMERO_AES_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V0NAES_NRENDOCA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0230_35_SELECT_NUMERO_AES_DB_SELECT_1_Query1", q26);

            #endregion

            #region R0230_40_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "V0NAES_NRENDOCA" , ""},
                { "V1ENDO_ORGAO" , ""},
                { "V1ENDO_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0230_40_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1", q27);

            #endregion

            #region R0230_50_ACUMULA_CORRECAO_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "WC_PRM_TAR" , ""},
                { "WC_VAL_DESC" , ""},
                { "WC_VLPRMLIQ" , ""},
                { "WC_VLADIFRA" , ""},
                { "WC_VLCUSEMI" , ""},
                { "WC_VLIOCC" , ""},
                { "WC_VLPRMTOT" , ""},
                { "WC_VLPREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0230_50_ACUMULA_CORRECAO_DB_SELECT_1_Query1", q28);

            #endregion

            #region R0230_60_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , ""},
                { "V0HISP_NRENDOS" , ""},
                { "V0HISP_NRPARCEL" , ""},
                { "V0HISP_DACPARC" , ""},
                { "V0HISP_DTMOVTO" , ""},
                { "V0HISP_OPERACAO" , ""},
                { "V0HISP_HORAOPER" , ""},
                { "V0HISP_OCORHIST" , ""},
                { "V0HISP_PRM_TAR" , ""},
                { "V0HISP_VAL_DESC" , ""},
                { "V0HISP_VLPRMLIQ" , ""},
                { "V0HISP_VLADIFRA" , ""},
                { "V0HISP_VLCUSEMI" , ""},
                { "V0HISP_VLIOCC" , ""},
                { "V0HISP_VLPRMTOT" , ""},
                { "V0HISP_VLPREMIO" , ""},
                { "V0HISP_DTVENCTO" , ""},
                { "V0HISP_BCOCOBR" , ""},
                { "V0HISP_AGECOBR" , ""},
                { "V0HISP_NRAVISO" , ""},
                { "V0HISP_NRENDOCA" , ""},
                { "V0HISP_SITCONTB" , ""},
                { "V0HISP_COD_USUARIO" , ""},
                { "V0HISP_RNUDOC" , ""},
                { "V0HISP_DTQITBCO" , ""},
                { "V0HISP_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0230_60_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q29);

            #endregion

            #region R0230_65_ACUMULA_PREMIOS_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "WP_PRM_TAR" , ""},
                { "WP_VAL_DESC" , ""},
                { "WP_VLPRMLIQ" , ""},
                { "WP_VLADIFRA" , ""},
                { "WP_VLCUSEMI" , ""},
                { "WP_VLIOCC" , ""},
                { "WP_VLPRMTOT" , ""},
                { "WP_VLPREMIO" , ""},
                { "V1HISP_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0230_65_ACUMULA_PREMIOS_DB_SELECT_1_Query1", q30);

            #endregion

            #region R0230_75_UPDATE_V0PARCELA_DB_UPDATE_1_Update1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "WOCORHIST" , ""},
                { "V1PARC_NUM_APOL" , ""},
                { "V0HISP_NRPARCEL" , ""},
                { "V1PARC_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0230_75_UPDATE_V0PARCELA_DB_UPDATE_1_Update1", q31);

            #endregion

            #region R0230_80_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , ""},
                { "V0HISP_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0230_80_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1", q32);

            #endregion

            #region R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V0SUBG_NUM_APOL" , ""},
                { "V0SUBG_COD_SUBG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1", q33);

            #endregion

            #region R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_2_Update1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V0PROP_CODOPER" , ""},
                { "V0SUBG_NUM_APOL" , ""},
                { "V0SUBG_COD_SUBG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_2_Update1", q34);

            #endregion

            #region R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "V1REL_COD_USUR" , ""},
                { "V1REL_CODRELAT" , ""},
                { "V1REL_NUM_APOL" , ""},
                { "V1REL_COD_SUBG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1", q35);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("DSAIDA_FILE_NAME_P", "SSAIDA_FILE_NAME_P")]
        public static void VG0031B_Tests_Theory(string DSAIDA_FILE_NAME_P, string SSAIDA_FILE_NAME_P)
        {
        	string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        	DSAIDA_FILE_NAME_P = $"{DSAIDA_FILE_NAME_P}_{timestamp}.txt";
            SSAIDA_FILE_NAME_P = $"{SSAIDA_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                SQLCA sQLCA = new SQLCA();
                sQLCA.SQLCODE.SetValue(100);
                AppSettings.TestSet.DynamicData.Remove("RD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1_Query1");
                var q12 = new DynamicData();

                AppSettings.TestSet.DynamicData.Add("RD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1_Query1", q12);

                #endregion
                var program = new VG0031B();
                program.Execute(DSAIDA_FILE_NAME_P, SSAIDA_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["RE224_00_GRAVAR_TORNO_EXPURGO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("APOLIEXP_NUM_APOLICE", out var val1r) && val1r.Equals("0000000123456"));

            }
        }

        [Theory]
        [InlineData("DSAIDA_FILE_NAME_P", "SSAIDA_FILE_NAME_P")]
        public static void VG0031B_Tests_Theory_OBTER_NUM_PROPOSTA(string DSAIDA_FILE_NAME_P, string SSAIDA_FILE_NAME_P)
        {
        	string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        	DSAIDA_FILE_NAME_P = $"{DSAIDA_FILE_NAME_P}_{timestamp}.txt";
            SSAIDA_FILE_NAME_P = $"{SSAIDA_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                SQLCA sQLCA = new SQLCA();
                sQLCA.SQLCODE.SetValue(100);

                AppSettings.TestSet.DynamicData.Remove("RD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1_Query1");
                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "RETOREXP_NUM_APOLICE" , ""},
                { "RETOREXP_SITUACAO_RETORNO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Add("RD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1_Query1", q12);

                AppSettings.TestSet.DynamicData.Remove("VG0031B_V0SEGURAVG");
                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0SEG_NUM_APOL" , ""},
                { "V0SEG_COD_SUBG" , "1234"},
                { "V0SEG_NUM_CERTIF" , ""},
                { "V0SEG_DAC_CERTIF" , ""},
                { "V0SEG_TP_SEGURADO" , ""},
                { "V0SEG_NUM_ITEM" , ""},
                { "V0SEG_TP_INCLUSAO" , ""},
                { "V0SEG_COD_CLIENTE" , ""},
                { "V0SEG_COD_FONTE" , ""},
                { "V0SEG_NUM_PROPOSTA" , ""},
                { "V0SEG_AGENCIADOR" , ""},
                { "V0SEG_CORRETOR" , ""},
                { "V0SEG_CD_PLANOVGAP" , ""},
                { "V0SEG_CD_PLANOAP" , ""},
                { "V0SEG_FAIXA" , ""},
                { "V0SEG_AUT_AUM_AUT" , ""},
                { "V0SEG_TP_BENEFICIA" , ""},
                { "V0SEG_OCORR_HIST" , ""},
                { "V0SEG_PERI_PGTO" , ""},
                { "V0SEG_PERI_RENOVA" , ""},
                { "V0SEG_NUM_CARNE" , ""},
                { "V0SEG_COD_OCUPACAO" , ""},
                { "V0SEG_EST_CIVIL" , ""},
                { "V0SEG_SEXO" , ""},
                { "V0SEG_CD_PROFISSAO" , ""},
                { "V0SEG_NATURALIDADE" , ""},
                { "V0SEG_OCOR_ENDERE" , ""},
                { "V0SEG_OCOR_END_COB" , ""},
                { "V0SEG_BCO_COBRANCA" , ""},
                { "V0SEG_AGE_COBRANCA" , ""},
                { "V0SEG_DAC_COBRANCA" , ""},
                { "V0SEG_NUM_MATRIC" , ""},
                { "V0SEG_VAL_SALARIO" , ""},
                { "V0SEG_TP_SALARIO" , ""},
                { "V0SEG_TP_PLANO" , ""},
                { "V0SEG_DT_INIVIG" , ""},
                { "V0SEG_PCT_CONJ_VG" , ""},
                { "V0SEG_PCT_CONJ_AP" , ""},
                { "V0SEG_QTD_S_MONATU" , ""},
                { "V0SEG_QTD_S_MOACID" , ""},
                { "V0SEG_QTD_S_INVPER" , ""},
                { "V0SEG_TX_AP_MOACID" , ""},
                { "V0SEG_TX_AP_INVPER" , ""},
                { "V0SEG_TX_AP_AMDS" , ""},
                { "V0SEG_TX_AP_DH" , ""},
                { "V0SEG_TX_AP_DIT" , ""},
                { "V0SEG_TAXA_AP" , ""},
                { "V0SEG_TAXA_VG" , ""},
                { "V0SEG_SIT_REGISTRO" , ""},
                { "V0SEG_DT_ADMISSAO" , ""},
                { "V0SEG_DT_NASCI" , ""},
                { "V0SEG_LOT_EMP_SEGURADO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("VG0031B_V0SEGURAVG", q10);

                #endregion
                var program = new VG0031B();
                program.Execute(DSAIDA_FILE_NAME_P, SSAIDA_FILE_NAME_P);

                var envList = AppSettings.TestSet.DynamicData["R0224_25_OBTER_NUM_PROPOSTA_DB_UPDATE_1_Update1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R0224_55_CANCELA_SEGURADO_DB_INSERT_1_Insert1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);

                Assert.True(envList[1].TryGetValue("V0FONTE_PROPAUTOM", out var val1r) && val1r.Equals("000000001"));
                Assert.True(envList1[1].TryGetValue("V0SEG_COD_SUBG", out val1r) && val1r.Equals("1234"));

            }
        }

        [Theory]
        [InlineData("DSAIDA_FILE_NAME_P", "SSAIDA_FILE_NAME_P")]
        public static void VG0031B_Tests_Theory_UPD_SEGURAVG(string DSAIDA_FILE_NAME_P, string SSAIDA_FILE_NAME_P)
        {
        	string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        	DSAIDA_FILE_NAME_P = $"{DSAIDA_FILE_NAME_P}_{timestamp}.txt";
            SSAIDA_FILE_NAME_P = $"{SSAIDA_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                SQLCA sQLCA = new SQLCA();
                sQLCA.SQLCODE.SetValue(100);

                AppSettings.TestSet.DynamicData.Remove("RD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1_Query1");
                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "RETOREXP_NUM_APOLICE" , ""},
                { "RETOREXP_SITUACAO_RETORNO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Add("RD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1_Query1", q12);

                AppSettings.TestSet.DynamicData.Remove("VG0031B_V0SEGURAVG");
                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0SEG_NUM_APOL" , ""},
                { "V0SEG_COD_SUBG" , "1234"},
                { "V0SEG_NUM_CERTIF" , ""},
                { "V0SEG_DAC_CERTIF" , ""},
                { "V0SEG_TP_SEGURADO" , ""},
                { "V0SEG_NUM_ITEM" , "999999999"},
                { "V0SEG_TP_INCLUSAO" , ""},
                { "V0SEG_COD_CLIENTE" , ""},
                { "V0SEG_COD_FONTE" , ""},
                { "V0SEG_NUM_PROPOSTA" , ""},
                { "V0SEG_AGENCIADOR" , ""},
                { "V0SEG_CORRETOR" , ""},
                { "V0SEG_CD_PLANOVGAP" , ""},
                { "V0SEG_CD_PLANOAP" , ""},
                { "V0SEG_FAIXA" , ""},
                { "V0SEG_AUT_AUM_AUT" , ""},
                { "V0SEG_TP_BENEFICIA" , ""},
                { "V0SEG_OCORR_HIST" , ""},
                { "V0SEG_PERI_PGTO" , ""},
                { "V0SEG_PERI_RENOVA" , ""},
                { "V0SEG_NUM_CARNE" , ""},
                { "V0SEG_COD_OCUPACAO" , ""},
                { "V0SEG_EST_CIVIL" , ""},
                { "V0SEG_SEXO" , ""},
                { "V0SEG_CD_PROFISSAO" , ""},
                { "V0SEG_NATURALIDADE" , ""},
                { "V0SEG_OCOR_ENDERE" , ""},
                { "V0SEG_OCOR_END_COB" , ""},
                { "V0SEG_BCO_COBRANCA" , ""},
                { "V0SEG_AGE_COBRANCA" , ""},
                { "V0SEG_DAC_COBRANCA" , ""},
                { "V0SEG_NUM_MATRIC" , ""},
                { "V0SEG_VAL_SALARIO" , ""},
                { "V0SEG_TP_SALARIO" , ""},
                { "V0SEG_TP_PLANO" , ""},
                { "V0SEG_DT_INIVIG" , ""},
                { "V0SEG_PCT_CONJ_VG" , ""},
                { "V0SEG_PCT_CONJ_AP" , ""},
                { "V0SEG_QTD_S_MONATU" , ""},
                { "V0SEG_QTD_S_MOACID" , ""},
                { "V0SEG_QTD_S_INVPER" , ""},
                { "V0SEG_TX_AP_MOACID" , ""},
                { "V0SEG_TX_AP_INVPER" , ""},
                { "V0SEG_TX_AP_AMDS" , ""},
                { "V0SEG_TX_AP_DH" , ""},
                { "V0SEG_TX_AP_DIT" , ""},
                { "V0SEG_TAXA_AP" , ""},
                { "V0SEG_TAXA_VG" , ""},
                { "V0SEG_SIT_REGISTRO" , ""},
                { "V0SEG_DT_ADMISSAO" , ""},
                { "V0SEG_DT_NASCI" , ""},
                { "V0SEG_LOT_EMP_SEGURADO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("VG0031B_V0SEGURAVG", q10);

                AppSettings.TestSet.DynamicData.Remove("R0224_30_SELECT_V0HISTSEG_DB_SELECT_1_Query1");
                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V1HSEG_DT_MOVTO" , ""},
                { "V1HSEG_MOEDA_IMP" , ""},
                { "V1HSEG_MOEDA_PRM" , ""},
                }, new SQLCA() { SQLCODE = sQLCA.SQLCODE });
                AppSettings.TestSet.DynamicData.Add("R0224_30_SELECT_V0HISTSEG_DB_SELECT_1_Query1", q16);

                AppSettings.TestSet.DynamicData.Remove("VG0031B_V1PARCELA");
                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUM_APOL" , ""},
                { "V1PARC_NRENDOS" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1PARC_DACPARC" , ""},
                { "V1PARC_FONTE" , ""},
                { "V1PARC_NRTIT" , ""},
                { "V1PARC_OCORHIST" , ""},
                { "V1PARC_QTDDOC" , ""},
                { "V1PARC_SITUACAO" , "0"},
                { "V1PARC_COD_EMP" , ""},
                });
                q25.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUM_APOL" , ""},
                { "V1PARC_NRENDOS" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1PARC_DACPARC" , ""},
                { "V1PARC_FONTE" , ""},
                { "V1PARC_NRTIT" , ""},
                { "V1PARC_OCORHIST" , ""},
                { "V1PARC_QTDDOC" , ""},
                { "V1PARC_SITUACAO" , ""},
                { "V1PARC_COD_EMP" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("VG0031B_V1PARCELA", q25);

                AppSettings.TestSet.DynamicData.Remove("VG0031B_V1ENDOSSO");
                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_NUM_APOL" , ""},
                { "V1ENDO_NRENDOS" , ""},
                { "V1ENDO_DTEMIS" , ""},
                { "V1ENDO_DTINIVIG" , ""},
                { "V1ENDO_DTTERVIG" , ""},
                { "V1ENDO_BCORCAP" , ""},
                { "V1ENDO_AGERCAP" , ""},
                { "V1ENDO_DACRCAP" , ""},
                { "V1ENDO_BCOCOBR" , ""},
                { "V1ENDO_AGECOBR" , ""},
                { "V1ENDO_DACCOBR" , ""},
                { "V1ENDO_QTPARCEL" , ""},
                { "V1ENDO_ORGAO" , "1234"},
                { "V1ENDO_RAMO" , ""},
                { "V1ENDO_CODPRODU" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("VG0031B_V1ENDOSSO", q24);

                #endregion
                var program = new VG0031B();
                program.Execute(DSAIDA_FILE_NAME_P, SSAIDA_FILE_NAME_P);

                var envList = AppSettings.TestSet.DynamicData["R0224_32_UPD_SEGURAVG_DB_UPDATE_1_Update1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R0230_40_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R0230_60_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1"].DynamicList;
                var envList3 = AppSettings.TestSet.DynamicData["R0230_75_UPDATE_V0PARCELA_DB_UPDATE_1_Update1"].DynamicList;
                var envList4 = AppSettings.TestSet.DynamicData["R0230_80_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);
                Assert.True(envList3?.Count > 1);
                Assert.True(envList4?.Count > 1);

                Assert.True(envList[1].TryGetValue("V0SEG_NUM_ITEM", out var val1r) && val1r.Equals("999999999"));
                Assert.True(envList1[1].TryGetValue("V1ENDO_ORGAO", out val1r) && val1r.Equals("1234"));
                Assert.True(envList2[1].TryGetValue("V0HISP_OPERACAO", out val1r) && val1r.Equals("0403"));
                Assert.True(envList3[1].TryGetValue("WOCORHIST", out val1r) && val1r.Equals("0001"));
                Assert.True(envList4[1].TryGetValue("V0HISP_NRENDOS", out val1r) && val1r.Equals("000000000"));

            }
        }
    }
}