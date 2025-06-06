using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VG1139B;

namespace FileTests.Test
{
    [Collection("VG1139B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VG1139B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2024-02-02"},
                { "V1SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0000_00_PRINCIPAL_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVACB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_2_Query1", q1);

            #endregion

            #region VG1139B_CHISTCTBL

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_SITUACAO" , "0"},
                { "V0HCTB_NUM_APOLICE" , "123"},
                { "V0HCTB_CODSUBES" , "000"},
                { "V0HCTB_FONTE" , ""},
                { "V0HCTB_PRMVG" , ""},
                { "V0HCTB_PRMAP" , ""},
                { "V0HCTB_CODOPER" , "1000"},
                { "V0HCTB_NRCERTIF" , "123456789012345"},
                { "V0HCTB_NRPARCEL" , "1"},
                { "V0HCTB_NRTIT" , "1234567890123"},
                { "V0HCTB_OCORHIST" , "4213"},
                { "V0HCTB_DTMOVTO" , ""},
                { "V0PROP_DTQITBCO" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "V0PRVG_ESTR_COBR" , "MULT"},
                { "V0PRVG_ORIG_PRODU" , ""},
                { "V0PROP_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG1139B_CHISTCTBL", q2);

            #endregion

            #region R0910_00_FETCH_HCTBVA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0SUBG_NUM_APOLICE" , "32111"}
            });
            AppSettings.TestSet.DynamicData.Add("R0910_00_FETCH_HCTBVA_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_RAMO" , ""},
                { "V0APOL_CODPRODU" , ""},
                { "V0APOL_ORGAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0SUBG_IND_IOF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q5);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_DTVENCTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q6);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_DTVENCTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1", q7);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_DTVENCTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1", q8);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_DTINIVIG_ENDO" , ""},
                { "V0COBP_DTTERVIG_ENDO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1", q9);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_DTINIVIG_ENDO" , ""},
                { "V0COBP_DTTERVIG_ENDO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1", q10);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_PERIPGTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1", q11);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_9_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_DTTERVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_9_Query1", q12);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_10_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODSUBES" , ""},
                { "WHOST_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_10_Query1", q13);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_11_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , "123"}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_11_Query1", q14);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update12

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , ""},
                { "V0APOL_ORGAO" , ""},
                { "V0APOL_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update12", q15);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query13

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query13", q16);

            #endregion

            #region R1000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , ""},
                { "V0ENDO_NRENDOS" , ""},
                { "V0ENDO_CODSUBES" , ""},
                { "V0ENDO_FONTE" , ""},
                { "V0ENDO_NRPROPOS" , ""},
                { "V0ENDO_DATPRO" , ""},
                { "V0ENDO_DT_LIBER" , ""},
                { "V0ENDO_DTEMIS" , ""},
                { "V0ENDO_NRRCAP" , ""},
                { "V0ENDO_VLRCAP" , ""},
                { "V0ENDO_BCORCAP" , ""},
                { "V0ENDO_AGERCAP" , ""},
                { "V0ENDO_DACRCAP" , ""},
                { "V0ENDO_IDRCAP" , ""},
                { "V0ENDO_BCOCOBR" , ""},
                { "V0ENDO_AGECOBR" , ""},
                { "V0ENDO_DACCOBR" , ""},
                { "V0ENDO_DTINIVIG" , ""},
                { "V0ENDO_DTTERVIG" , ""},
                { "V0ENDO_CDFRACIO" , ""},
                { "V0ENDO_PCENTRAD" , ""},
                { "V0ENDO_PCADICIO" , ""},
                { "V0ENDO_PRESTA1" , ""},
                { "V0ENDO_QTPARCEL" , ""},
                { "V0ENDO_QTPRESTA" , ""},
                { "V0ENDO_QTITENS" , ""},
                { "V0ENDO_CODTXT" , ""},
                { "V0ENDO_CDACEITA" , ""},
                { "V0ENDO_MOEDA_IMP" , ""},
                { "V0ENDO_MOEDA_PRM" , ""},
                { "V0ENDO_TIPO_ENDO" , ""},
                { "V0ENDO_COD_USUAR" , ""},
                { "V0ENDO_OCORR_END" , ""},
                { "V0ENDO_SITUACAO" , ""},
                { "V0ENDO_DATARCAP" , ""},
                { "V0ENDO_COD_EMPRESA" , ""},
                { "V0ENDO_CORRECAO" , ""},
                { "V0ENDO_ISENTA_CST" , ""},
                { "V0ENDO_DTVENCTO" , ""},
                { "V0ENDO_CFPREFIX" , ""},
                { "V0ENDO_VLCUSEMI" , ""},
                { "V0ENDO_RAMO" , ""},
                { "V0ENDO_CODPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1", q17);

            #endregion

            #region R1000_10_LOOP_PROPAUTOM_DB_UPDATE_2_Update1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , ""},
                { "V0ENDO_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_10_LOOP_PROPAUTOM_DB_UPDATE_2_Update1", q18);

            #endregion

            #region R1000_10_LOOP_PROPAUTOM_DB_INSERT_3_Insert1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NUM_APOL" , ""},
                { "V0PARC_NRENDOS" , ""},
                { "V0PARC_NRPARCEL" , ""},
                { "V0PARC_DACPARC" , ""},
                { "V0PARC_FONTE" , ""},
                { "V0PARC_NRTIT" , ""},
                { "V0PARC_PRM_TAR_IX" , ""},
                { "V0PARC_VAL_DES_IX" , ""},
                { "V0PARC_OTNPRLIQ" , ""},
                { "V0PARC_OTNADFRA" , ""},
                { "V0PARC_OTNCUSTO" , ""},
                { "V0PARC_OTNIOF" , ""},
                { "V0PARC_OTNTOTAL" , ""},
                { "V0PARC_OCORHIST" , ""},
                { "V0PARC_QTDDOC" , ""},
                { "V0PARC_SITUACAO" , ""},
                { "V0PARC_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_10_LOOP_PROPAUTOM_DB_INSERT_3_Insert1", q19);

            #endregion

            #region R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , ""},
                { "V0ENDO_CODSUBES" , ""},
                { "V0ENDO_FONTE" , ""},
                { "V0ENDO_NRENDOS" , ""},
                { "V1SIST_DTMOVABE" , ""},
                { "WHOST_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1", q20);

            #endregion

            #region R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , ""},
                { "V0APOL_ORGAO" , ""},
                { "V0APOL_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1", q21);

            #endregion

            #region R1100_00_ACUMULA_PREMIO_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , "111"}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_PREMIO_DB_SELECT_1_Query1", q22);

            #endregion

            #region R1100_00_ACUMULA_PREMIO_DB_UPDATE_2_Update1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , ""},
                { "V1SIST_DTMOVABE" , ""},
                { "V0HCTB_NRCERTIF" , ""},
                { "V0HCTB_NRPARCEL" , ""},
                { "V0HCTB_NRTIT" , ""},
                { "V0HCTB_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_ACUMULA_PREMIO_DB_UPDATE_2_Update1", q23);

            #endregion

            #region R1102_00_SELECT_RCAP_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1102_00_SELECT_RCAP_DB_SELECT_1_Query1", q24);

            #endregion

            #region R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , "1"}
            });
            q25.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , "2"}
            });
            q25.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , "3"}
            });
            q25.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , "4"}
            });
            q25.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , "4"}
            });
            AppSettings.TestSet.DynamicData.Add("R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1", q25);

            #endregion

            #region R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "2"},
                { "V0RCAP_NRRCAP" , "3"},
                { "V0RCAP_SITUACAO" , "1"},
            });
            q26.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "2"},
                { "V0RCAP_NRRCAP" , "3"},
                { "V0RCAP_SITUACAO" , "1"},
            });
            q26.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "2"},
                { "V0RCAP_NRRCAP" , "3"},
                { "V0RCAP_SITUACAO" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1", q26);

            #endregion

            #region R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , ""},
                { "V0RCAP_NRRCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1", q27);

            #endregion

            #region R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , ""},
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
                { "V1RCAC_DATARCAP" , ""},
            });
            q28.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , ""},
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
                { "V1RCAC_DATARCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1", q28);

            #endregion

            #region R1110_00_VERIFICA_RCAP_DB_UPDATE_4_Update1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , ""},
                { "V0ENDO_NRENDOS" , ""},
                { "V0RCAP_NRRCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_UPDATE_4_Update1", q29);

            #endregion

            #region VG1139B_V1RCAPCOMP

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , ""},
                { "V1RCAC_NRRCAP" , ""},
                { "V1RCAC_NRRCAPCO" , ""},
                { "V1RCAC_OPERACAO" , ""},
                { "V1RCAC_DTMOVTO" , ""},
                { "V1RCAC_HORAOPER" , ""},
                { "V1RCAC_SITUACAO" , ""},
                { "V1RCAC_BCOAVISO" , ""},
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
                { "V1RCAC_VLRCAP" , ""},
                { "V1RCAC_DATARCAP" , ""},
                { "V1RCAC_DTCADAST" , ""},
                { "V1RCAC_SITCONTB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG1139B_V1RCAPCOMP", q30);

            #endregion

            #region R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_NRRCAP" , ""},
                { "V1RCAC_NRRCAPCO" , ""},
                { "V1RCAC_OPERACAO" , ""},
                { "V1RCAC_DTMOVTO" , ""},
                { "V1RCAC_HORAOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1", q31);

            #endregion

            #region R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , ""},
                { "V1RCAC_NRRCAP" , ""},
                { "V1RCAC_NRRCAPCO" , ""},
                { "V1RCAC_OPERACAO" , ""},
                { "V1SIST_DTMOVACB" , ""},
                { "V1RCAC_SITUACAO" , ""},
                { "V1RCAC_BCOAVISO" , ""},
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
                { "V1RCAC_VLRCAP" , ""},
                { "V1RCAC_DATARCAP" , ""},
                { "V1RCAC_DTCADAST" , ""},
                { "V1RCAC_SITCONTB" , ""},
                { "V1RCAC_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1", q32);

            #endregion

            #region R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_VLRCAP" , ""},
                { "V1RCAC_BCOAVISO" , ""},
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1", q33);

            #endregion

            #region R1210_00_ACUMULA_IS_DB_SELECT_1_Query1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "V0CBPR_IMPMORNATU" , ""},
                { "V0CBPR_IMPMORACID" , ""},
                { "V0CBPR_IMPINVPERM" , ""},
                { "V0CBPR_IMPAMDS" , ""},
                { "V0CBPR_IMPDH" , ""},
                { "V0CBPR_IMPDIT" , ""},
                { "V0CBPR_PRMDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_ACUMULA_IS_DB_SELECT_1_Query1", q34);

            #endregion

            #region VG1139B_V1APOLCOSCED

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "V1COSP_CONGENER" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VG1139B_V1APOLCOSCED", q35);

            #endregion

            #region R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1", q36);

            #endregion

            #region R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_2_Insert1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "V0ORDC_NUM_APOL" , ""},
                { "V0ORDC_NRENDOS" , ""},
                { "V0ORDC_CODCOSS" , ""},
                { "V0ORDC_ORDEM_CED" , ""},
                { "V0ORDC_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_2_Insert1", q37);

            #endregion

            #region R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_3_Update1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , ""},
                { "V1NCOS_ORGAO" , ""},
                { "V1NCOS_CONGENER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_3_Update1", q38);

            #endregion

            #region R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , ""},
                { "V0HISP_NRENDOS" , ""},
                { "V0HISP_NRPARCEL" , ""},
                { "V0HISP_DACPARC" , ""},
                { "V0HISP_DTMOVTO" , ""},
                { "V0HISP_OPERACAO" , ""},
                { "V0HISP_OCORHIST" , ""},
                { "V0HISP_PRM_TARIFA" , ""},
                { "V0HISP_VAL_DESCON" , ""},
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
                { "V0HISP_COD_USUAR" , ""},
                { "V0HISP_RNUDOC" , ""},
                { "V0HISP_DTQITBCO" , ""},
                { "V0HISP_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q39);

            #endregion

            #region R1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , ""},
                { "V0HCTB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1", q40);

            #endregion

            #region R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_NUM_APOL" , ""},
                { "V0COBA_NRENDOS" , ""},
                { "V0COBA_NUM_ITEM" , ""},
                { "V0COBA_OCORHIST" , ""},
                { "V0COBA_RAMOFR" , ""},
                { "V0COBA_MODALIFR" , ""},
                { "V0COBA_COD_COBER" , ""},
                { "V0COBA_IMP_SEG_IX" , ""},
                { "V0COBA_PRM_TAR_IX" , ""},
                { "V0COBA_IMP_SEG_VR" , ""},
                { "V0COBA_PRM_TAR_VR" , ""},
                { "V0COBA_PCT_COBERT" , ""},
                { "V0COBA_FATOR_MULT" , ""},
                { "V0COBA_DATA_INIVI" , ""},
                { "V0COBA_DATA_TERVI" , ""},
                { "V0COBA_COD_EMPRESA" , ""},
                { "V0COBA_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1", q41);

            #endregion

            #region R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "V0EDIA_CODRELAT" , ""},
                { "V0EDIA_NUM_APOL" , ""},
                { "V0EDIA_NRENDOS" , ""},
                { "V0EDIA_NRPARCEL" , ""},
                { "V0EDIA_DTMOVTO" , ""},
                { "V0EDIA_ORGAO" , ""},
                { "V0EDIA_RAMO" , ""},
                { "V0EDIA_FONTE" , ""},
                { "V0EDIA_CONGENER" , ""},
                { "V0EDIA_CODCORR" , ""},
                { "V0EDIA_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1", q42);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG1139B_Tests_Fact()
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
                var program = new VG1139B();
                program.Execute();

                //var envList0 = AppSettings.TestSet.DynamicData["R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update12"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1"].DynamicList;

                //Assert.True(envList0.Count > 1);
                Assert.True(envList1.Count > 1);
                Assert.True(envList2.Count > 1);


                //Assert.True(envList0[1].TryGetValue("V0ENDO_NRENDOS", out var V0ENDO_NRENDOS) && V0ENDO_NRENDOS == "000000124");
                Assert.True(envList1[1].TryGetValue("V0ENDO_NUM_APOLICE", out var V0ENDO_NUM_APOLICE) && V0ENDO_NUM_APOLICE == "0000000000123");
                Assert.True(envList2[1].TryGetValue("V0ENDO_NRENDOS", out var V0ENDO_NRENDOS1) && V0ENDO_NRENDOS1 == "000000123");

                Assert.True(program.RETURN_CODE == 0);
            }
        }
    }
}