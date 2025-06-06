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
using static Code.VG0100B;

namespace FileTests.Test
{
    [Collection("VG0100B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG0100B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1PRAM_RAMO_VG" , ""},
                { "V1PRAM_RAMO_AP" , ""},
                { "V1PRAM_RAMO_VGAP" , ""},
                { "V1PRAM_RAMO_PRESTAMISTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "NUM_TERMO" , ""},
                { "COD_SUBGRUPO" , ""},
                { "DATA_ADESAO" , ""},
                { "PERI_PAGTO" , ""},
                { "MODALIDADE_CAPITAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q2);

            #endregion

            #region VG0100B_V1SOLICFAT

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1SOLF_NUM_APOL" , ""},
                { "V1SOLF_COD_SUBG" , ""},
                { "V1SOLF_NUM_FAT" , ""},
                { "V1SOLF_NUM_RCAP" , ""},
                { "V1SOLF_VAL_RCAP" , ""},
                { "V1SOLF_COD_OPER" , ""},
                { "V1SOLF_SIT_REG" , ""},
                { "V1SOLF_DATA_RCAP" , ""},
                { "V1SOLF_DATA_VENC" , ""},
                { "V1SOLF_DATA_SOLI" , ""},
                { "V1SOLF_COD_USUAR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0100B_V1SOLICFAT", q3);

            #endregion

            #region VG0100B_V1FATURAST

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1FATT_NUM_APOL" , ""},
                { "V1FATT_COD_SUBG" , ""},
                { "V1FATT_NUM_FATUR" , ""},
                { "V1FATT_COD_OPER" , ""},
                { "V1FATT_QT_VIDA_VG" , ""},
                { "V1FATT_QT_VIDA_AP" , ""},
                { "V1FATT_IMP_MORNAT" , ""},
                { "V1FATT_IMP_MORACI" , ""},
                { "V1FATT_IMP_INVPER" , ""},
                { "V1FATT_IMP_AMDS" , ""},
                { "V1FATT_IMP_DH" , ""},
                { "V1FATT_IMP_DIT" , ""},
                { "V1FATT_PRM_VG" , ""},
                { "V1FATT_PRM_AP" , ""},
                { "V1FATT_SIT_REG" , ""},
                { "V1FATT_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0100B_V1FATURAST", q4);

            #endregion

            #region R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0910_00_FETCH_V1SOLICFAT_DB_SELECT_2_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0910_00_FETCH_V1SOLICFAT_DB_SELECT_2_Query1", q6);

            #endregion

            #region R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1SUBG_TIPO_FAT" , ""},
                { "V1SUBG_COD_FONTE" , ""},
                { "V1SUBG_COD_SUBG" , ""},
                { "V1SUBG_END_COB" , ""},
                { "V1SUBG_BCO_COB" , ""},
                { "V1SUBG_AGE_COB" , ""},
                { "V1SUBG_DAC_COB" , ""},
                { "V1SUBG_PERI_FATUR" , ""},
                { "V1SUBG_DTTERVIG" , ""},
                { "V1SUBG_IND_IOF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1200_00_SELECT_V1FATURA_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1FATR_NUM_APOL" , ""},
                { "V1FATR_COD_SUBG" , ""},
                { "V1FATR_NUM_FATUR" , ""},
                { "V1FATR_COD_OPER" , ""},
                { "V1FATR_TIPO_ENDOS" , ""},
                { "V1FATR_NUM_ENDOS" , ""},
                { "V1FATR_VAL_FATURA" , ""},
                { "V1FATR_COD_FONTE" , ""},
                { "V1FATR_NUM_RCAP" , ""},
                { "V1FATR_VAL_RCAP" , ""},
                { "V1FATR_DATA_INIVIG" , ""},
                { "V1FATR_DATA_TERVIG" , ""},
                { "V1FATR_SIT_REG" , ""},
                { "V1FATR_DATA_FATUR" , ""},
                { "V1FATR_DATA_RCAP" , ""},
                { "V1FATR_COD_EMPRESA" , ""},
                { "V1FATR_DATA_VENC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V1FATURA_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1FATR_NUM_APOL" , ""},
                { "V1FATR_COD_SUBG" , ""},
                { "V1FATR_NUM_FATUR" , ""},
                { "V1FATR_COD_OPER" , ""},
                { "V1FATR_TIPO_ENDOS" , ""},
                { "V1FATR_NUM_ENDOS" , ""},
                { "V1FATR_VAL_FATURA" , ""},
                { "V1FATR_COD_FONTE" , ""},
                { "V1FATR_NUM_RCAP" , ""},
                { "V1FATR_VAL_RCAP" , ""},
                { "V1FATR_DATA_INIVIG" , ""},
                { "V1FATR_DATA_TERVIG" , ""},
                { "V1FATR_SIT_REG" , ""},
                { "V1FATR_DATA_FATUR" , ""},
                { "V1FATR_DATA_RCAP" , ""},
                { "V1FATR_COD_EMPRESA" , ""},
                { "V1FATR_DATA_VENC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1_Query1", q9);

            #endregion

            #region VG0100B_V1SUBGRUPO

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1SUBG_TIPO_FAT" , ""},
                { "V1SUBG_NUM_APOL" , ""},
                { "V1SUBG_COD_SUBG" , ""},
                { "V1SUBG_COD_FONTE" , ""},
                { "V1SUBG_BCO_COB" , ""},
                { "V1SUBG_AGE_COB" , ""},
                { "V1SUBG_DAC_COB" , ""},
                { "V1SUBG_END_COB" , ""},
                { "V1SUBG_PERI_FATUR" , ""},
                { "V1SUBG_IND_IOF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0100B_V1SUBGRUPO", q10);

            #endregion

            #region R1400_00_SELECT_V0NUMEROAES_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0NAES_ENDOSCOB" , ""},
                { "V0NAES_ENDOSRES" , ""},
                { "V0NAES_ENDOSSEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_V0NUMEROAES_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0NAES_ENDOSCOB" , ""},
                { "V0NAES_ENDOSRES" , ""},
                { "V0NAES_ENDOSSEM" , ""},
                { "V1APOL_ORGAO" , ""},
                { "V1APOL_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R1420_00_UPDATE_V0FONTE_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_PROPAUTOM" , ""},
                { "W1SUBG_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1420_00_UPDATE_V0FONTE_DB_UPDATE_1_Update1", q13);

            #endregion

            #region VG0100B_V1FATURTOT1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V1FATT_NUM_APOL" , ""},
                { "V1FATT_COD_SUBG" , ""},
                { "V1FATT_NUM_FATUR" , ""},
                { "V1FATT_COD_OPER" , ""},
                { "V1FATT_QT_VIDA_VG" , ""},
                { "V1FATT_QT_VIDA_AP" , ""},
                { "V1FATT_IMP_MORNAT" , ""},
                { "V1FATT_IMP_MORACI" , ""},
                { "V1FATT_IMP_INVPER" , ""},
                { "V1FATT_IMP_AMDS" , ""},
                { "V1FATT_IMP_DH" , ""},
                { "V1FATT_IMP_DIT" , ""},
                { "V1FATT_PRM_VG" , ""},
                { "V1FATT_PRM_AP" , ""},
                { "V1FATT_SIT_REG" , ""},
                { "V1FATT_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0100B_V1FATURTOT1", q14);

            #endregion

            #region R1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_ORGAO" , ""},
                { "V1APOL_RAMO" , ""},
                { "V1APOL_MODALIDA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1", q15);

            #endregion

            #region VG0100B_MOVIMENTO

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0MOVI_MORNATU_ANT" , ""},
                { "V0MOVI_MORNATU_ATU" , ""},
                { "V0MOVI_MORACID_ANT" , ""},
                { "V0MOVI_MORACID_ATU" , ""},
                { "V0MOVI_INVPERM_ANT" , ""},
                { "V0MOVI_INVPERM_ATU" , ""},
                { "V0MOVI_AMDS_ANT" , ""},
                { "V0MOVI_AMDS_ATU" , ""},
                { "V0MOVI_DH_ANT" , ""},
                { "V0MOVI_DH_ATU" , ""},
                { "V0MOVI_DIT_ANT" , ""},
                { "V0MOVI_DIT_ATU" , ""},
                { "V0MOVI_VG_ANT" , ""},
                { "V0MOVI_VG_ATU" , ""},
                { "V0MOVI_AP_ANT" , ""},
                { "V0MOVI_AP_ATU" , ""},
                { "V0MOVI_COD_OPER" , ""},
                { "V0MOVI_DATA_MOVI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0100B_MOVIMENTO", q16);

            #endregion

            #region R1800_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_RAMO" , ""},
                { "V1ENDO_MOEDA_IMP" , ""},
                { "V1ENDO_MOEDA_PRM" , ""},
                { "V1ENDO_OCORR_END" , ""},
                { "V1ENDO_CORRECAO" , ""},
                { "V1ENDO_CODPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1", q17);

            #endregion

            #region R1850_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_CODUNIMO" , ""},
                { "V1MOED_VLCRUZAD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1850_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q18);

            #endregion

            #region R1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_ISECUSTO" , ""},
                { "V1RIND_PCIOF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1", q19);

            #endregion

            #region R1940_00_ACESSA_RCAPCOMP_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V1RCAP_BCOAVISO" , ""},
                { "V1RCAP_AGEAVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1940_00_ACESSA_RCAPCOMP_DB_SELECT_1_Query1", q20);

            #endregion

            #region R1950_00_SELECT_V1FONTE_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1950_00_SELECT_V1FONTE_DB_SELECT_1_Query1", q21);

            #endregion

            #region R2305_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA_TERVIGENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2305_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1", q22);

            #endregion

            #region R2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V1FATC_DATA_REFER" , ""},
                { "DATA_TERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1", q23);

            #endregion

            #region R2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V1FATC_DATA_REFER" , ""},
                { "DATA_TERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1", q24);

            #endregion

            #region R2450_00_INSERE_COBERAPOL_DB_INSERT_1_Insert1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V0COBE_NUM_APOL" , ""},
                { "V0COBE_NUM_ENDOS" , ""},
                { "V0COBE_NUM_ITEM" , ""},
                { "V0COBE_OCORR_HIST" , ""},
                { "V0COBE_RAMOFR" , ""},
                { "V0COBE_MODALIFR" , ""},
                { "V0COBE_COD_COBER" , ""},
                { "V0COBE_IMP_SEGUR_I" , ""},
                { "V0COBE_PRM_TARIF_I" , ""},
                { "V0COBE_IMP_SEGUR_V" , ""},
                { "V0COBE_PRM_TARIF_V" , ""},
                { "V0COBE_PCT_COBER" , ""},
                { "V0COBE_FAT_MULT" , ""},
                { "V0COBE_DATA_INIVIG" , ""},
                { "V0COBE_DATA_TERVIG" , ""},
                { "V0COBE_COD_EMPRESA" , ""},
                { "V0COBE_COD_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2450_00_INSERE_COBERAPOL_DB_INSERT_1_Insert1", q25);

            #endregion

            #region R3080_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V0RELT_COD_USUAR" , ""},
                { "V0RELT_DATA_SOLI" , ""},
                { "V0RELT_CODREL" , ""},
                { "V1SIST_DTMOVABE" , ""},
                { "V0RELT_DATA_REFER" , ""},
                { "V0RELT_FONTE" , ""},
                { "V1SOLF_NUM_APOL" , ""},
                { "V0RELT_NRENDOS" , ""},
                { "V0RELT_CODSUBES" , ""},
                { "V0RELT_COD_EMPRESA" , ""},
                { "V0RELT_PERI_RENOVA" , ""},
                { "V0RELT_PCT_AUMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3080_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1", q26);

            #endregion

            #region R3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "V0FATR_NUM_APOL" , ""},
                { "V0FATR_COD_SUBG" , ""},
                { "V0FATR_NUM_FATUR" , ""},
                { "V0FATR_COD_OPER" , ""},
                { "V0FATR_TIPO_ENDOS" , ""},
                { "V0FATR_NUM_ENDOS" , ""},
                { "V0FATR_VAL_FATURA" , ""},
                { "V0FATR_COD_FONTE" , ""},
                { "V0FATR_NUM_RCAP" , ""},
                { "V0FATR_VAL_RCAP" , ""},
                { "V0FATR_DATA_INIVIG" , ""},
                { "V0FATR_DATA_TERVIG" , ""},
                { "V0FATR_SIT_REG" , ""},
                { "V0FATR_DATA_FATUR" , ""},
                { "V0FATR_DATA_RCAP" , ""},
                { "V0FATR_COD_EMPRESA" , ""},
                { "V0FATR_DATA_VENC" , ""},
                { "V0FATR_VLIOCC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1", q27);

            #endregion

            #region R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1_Insert1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V0FATT_NUM_APOL" , ""},
                { "V0FATT_COD_SUBG" , ""},
                { "V0FATT_NUM_FATUR" , ""},
                { "V0FATT_COD_OPER" , ""},
                { "V0FATT_QT_VIDA_VG" , ""},
                { "V0FATT_QT_VIDA_AP" , ""},
                { "V0FATT_IMP_MORNAT" , ""},
                { "V0FATT_IMP_MORACI" , ""},
                { "V0FATT_IMP_INVPER" , ""},
                { "V0FATT_IMP_AMDS" , ""},
                { "V0FATT_IMP_DH" , ""},
                { "V0FATT_IMP_DIT" , ""},
                { "V0FATT_PRM_VG" , ""},
                { "V0FATT_PRM_AP" , ""},
                { "V0FATT_SIT_REG" , ""},
                { "V0FATT_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1_Insert1", q28);

            #endregion

            #region R3300_00_V0ENDOSSO_PROPAUTOM_DB_INSERT_1_Insert1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOL" , ""},
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
                { "V0ENDO_TIPEND" , ""},
                { "V0ENDO_COD_USUAR" , ""},
                { "V0ENDO_OCORR_END" , ""},
                { "V0ENDO_SITUACAO" , ""},
                { "V0ENDO_DATARCAP" , ""},
                { "V0ENDO_COD_EMPRESA" , ""},
                { "V0ENDO_CORRECAO" , ""},
                { "V0ENDO_ISENTA_CST" , ""},
                { "V0ENDO_DTVENCTO" , ""},
                { "V0ENDO_RAMO" , ""},
                { "V0ENDO_CODPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3300_00_V0ENDOSSO_PROPAUTOM_DB_INSERT_1_Insert1", q29);

            #endregion

            #region R3500_00_SELECT_V1FATURA_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "V1FATR_DATA_INIVIG" , ""},
                { "V1FATR_DATA_TERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3500_00_SELECT_V1FATURA_DB_SELECT_1_Query1", q30);

            #endregion

            #region R4100_00_DELETE_V0FATURASTOT_DB_DELETE_1_Delete1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "W1SOLF_NUM_APOL" , ""},
                { "W1SOLF_COD_SUBG" , ""},
                { "W1SOLF_NUM_FAT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4100_00_DELETE_V0FATURASTOT_DB_DELETE_1_Delete1", q31);

            #endregion

            #region R5100_00_DELETE_V0FATURAS_DB_DELETE_1_Delete1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "W1SOLF_NUM_APOL" , ""},
                { "W1SOLF_COD_SUBG" , ""},
                { "W1SOLF_NUM_FAT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5100_00_DELETE_V0FATURAS_DB_DELETE_1_Delete1", q32);

            #endregion

            #region R5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1_Update1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V1SUBG_PERI_FATUR" , ""},
                { "V1SIST_DTMOVABE" , ""},
                { "W1SOLF_NUM_APOL" , ""},
                { "W1SOLF_COD_SUBG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1_Update1", q33);

            #endregion

            #region R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1_Update1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "V1SOLF_SIT_REG" , ""},
                { "V1SOLF_NUM_APOL" , ""},
                { "V1SOLF_COD_SUBG" , ""},
                { "V1SOLF_NUM_FAT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1_Update1", q34);

            #endregion

            #region R5400_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "V1FATC_DATA_REFER" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5400_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1", q35);

            #endregion

            #region R5400_00_SELECT_V1FATURCONT_DB_SELECT_2_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "V9SOLF_NUM_FAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5400_00_SELECT_V1FATURCONT_DB_SELECT_2_Query1", q36);

            #endregion

            #region R5500_00_INSERT_V0SOLICITAFAT_DB_INSERT_1_Insert1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "W1SOLF_NUM_APOL" , ""},
                { "W1SOLF_COD_SUBG" , ""},
                { "V0SOLF_NUM_FATUR" , ""},
                { "V1SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5500_00_INSERT_V0SOLICITAFAT_DB_INSERT_1_Insert1", q37);

            #endregion

            #region R5600_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_DTTERVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5600_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q38);

            #endregion

            #region VG0100B_CMOVTO2

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V0MOVI_MORNATU_ANT" , ""},
                { "V0MOVI_MORNATU_ATU" , ""},
                { "V0MOVI_MORACID_ANT" , ""},
                { "V0MOVI_MORACID_ATU" , ""},
                { "V0MOVI_INVPERM_ANT" , ""},
                { "V0MOVI_INVPERM_ATU" , ""},
                { "V0MOVI_AMDS_ANT" , ""},
                { "V0MOVI_AMDS_ATU" , ""},
                { "V0MOVI_DH_ANT" , ""},
                { "V0MOVI_DH_ATU" , ""},
                { "V0MOVI_DIT_ANT" , ""},
                { "V0MOVI_DIT_ATU" , ""},
                { "V0MOVI_VG_ANT" , ""},
                { "V0MOVI_VG_ATU" , ""},
                { "V0MOVI_AP_ANT" , ""},
                { "V0MOVI_AP_ATU" , ""},
                { "V0MOVI_COD_OPER" , ""},
                { "V0MOVI_DATA_MOVI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0100B_CMOVTO2", q39);

            #endregion

            #region M_6510_ATUALIZA_MOV_DB_UPDATE_1_Update1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V0MOVI_DATA_FATURA" , ""},
                { "V1FATC_DATA_REFER" , ""},
                { "W1SOLF_NUM_APOL" , ""},
                { "W1SUB_GRUPO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_6510_ATUALIZA_MOV_DB_UPDATE_1_Update1", q40);

            #endregion

            #region M_6520_ATUALIZA_MOV_DB_UPDATE_1_Update1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V0MOVI_DATA_FATURA" , ""},
                { "V1FATC_DATA_REFER" , ""},
                { "W1SOLF_NUM_APOL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_6520_ATUALIZA_MOV_DB_UPDATE_1_Update1", q41);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG0100B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                GE0510S_Tests.Load_Parameters_To_VG0100B();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1PRAM_RAMO_VG" , ""},
                    { "V1PRAM_RAMO_AP" , ""},
                    { "V1PRAM_RAMO_VGAP" , ""},
                    { "V1PRAM_RAMO_PRESTAMISTA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "NUM_TERMO" , ""},
                    { "COD_SUBGRUPO" , ""},
                    { "DATA_ADESAO" , ""},
                    { "PERI_PAGTO" , ""},
                    { "MODALIDADE_CAPITAL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                    q2.AddDynamic(new Dictionary<string, string>{
                    { "V1SIST_DTMOVABE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q2);

                #endregion

                #region VG0100B_V1SOLICFAT

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V1SOLF_NUM_APOL" , "1"},
                    { "V1SOLF_COD_SUBG" , ""},
                    { "V1SOLF_NUM_FAT" , ""},
                    { "V1SOLF_NUM_RCAP" , ""},
                    { "V1SOLF_VAL_RCAP" , ""},
                    { "V1SOLF_COD_OPER" , "100"},
                    { "V1SOLF_SIT_REG" , ""},
                    { "V1SOLF_DATA_RCAP" , ""},
                    { "V1SOLF_DATA_VENC" , ""},
                    { "V1SOLF_DATA_SOLI" , ""},
                    { "V1SOLF_COD_USUAR" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V1SOLF_NUM_APOL" , ""},
                    { "V1SOLF_COD_SUBG" , ""},
                    { "V1SOLF_NUM_FAT" , ""},
                    { "V1SOLF_NUM_RCAP" , ""},
                    { "V1SOLF_VAL_RCAP" , ""},
                    { "V1SOLF_COD_OPER" , "100"},
                    { "V1SOLF_SIT_REG" , ""},
                    { "V1SOLF_DATA_RCAP" , ""},
                    { "V1SOLF_DATA_VENC" , ""},
                    { "V1SOLF_DATA_SOLI" , ""},
                    { "V1SOLF_COD_USUAR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VG0100B_V1SOLICFAT");
                AppSettings.TestSet.DynamicData.Add("VG0100B_V1SOLICFAT", q3);

                #endregion

                #region VG0100B_V1FATURAST

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V1FATT_NUM_APOL" , ""},
                    { "V1FATT_COD_SUBG" , ""},
                    { "V1FATT_NUM_FATUR" , ""},
                    { "V1FATT_COD_OPER" , ""},
                    { "V1FATT_QT_VIDA_VG" , ""},
                    { "V1FATT_QT_VIDA_AP" , ""},
                    { "V1FATT_IMP_MORNAT" , ""},
                    { "V1FATT_IMP_MORACI" , ""},
                    { "V1FATT_IMP_INVPER" , ""},
                    { "V1FATT_IMP_AMDS" , ""},
                    { "V1FATT_IMP_DH" , ""},
                    { "V1FATT_IMP_DIT" , ""},
                    { "V1FATT_PRM_VG" , ""},
                    { "V1FATT_PRM_AP" , ""},
                    { "V1FATT_SIT_REG" , ""},
                    { "V1FATT_COD_EMPRESA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VG0100B_V1FATURAST");
                AppSettings.TestSet.DynamicData.Add("VG0100B_V1FATURAST", q4);

                #endregion

                #region R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                //q5.AddDynamic(new Dictionary<string, string>{
                //    { "V0PROP_NRCERTIF" , ""}
                //});
                AppSettings.TestSet.DynamicData.Remove("R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0910_00_FETCH_V1SOLICFAT_DB_SELECT_2_Query1

                var q6 = new DynamicData();
                //q6.AddDynamic(new Dictionary<string, string>{
                //    { "NUM_TITULO" , ""}
                //});
                AppSettings.TestSet.DynamicData.Remove("R0910_00_FETCH_V1SOLICFAT_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0910_00_FETCH_V1SOLICFAT_DB_SELECT_2_Query1", q6);

                #endregion

                #region R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V1SUBG_TIPO_FAT" , ""},
                    { "V1SUBG_COD_FONTE" , ""},
                    { "V1SUBG_COD_SUBG" , ""},
                    { "V1SUBG_END_COB" , ""},
                    { "V1SUBG_BCO_COB" , ""},
                    { "V1SUBG_AGE_COB" , ""},
                    { "V1SUBG_DAC_COB" , ""},
                    { "V1SUBG_PERI_FATUR" , ""},
                    { "V1SUBG_DTTERVIG" , ""},
                    { "V1SUBG_IND_IOF" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1200_00_SELECT_V1FATURA_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V1FATR_NUM_APOL" , ""},
                    { "V1FATR_COD_SUBG" , ""},
                    { "V1FATR_NUM_FATUR" , ""},
                    { "V1FATR_COD_OPER" , ""},
                    { "V1FATR_TIPO_ENDOS" , ""},
                    { "V1FATR_NUM_ENDOS" , ""},
                    { "V1FATR_VAL_FATURA" , ""},
                    { "V1FATR_COD_FONTE" , ""},
                    { "V1FATR_NUM_RCAP" , ""},
                    { "V1FATR_VAL_RCAP" , ""},
                    { "V1FATR_DATA_INIVIG" , ""},
                    { "V1FATR_DATA_TERVIG" , ""},
                    { "V1FATR_SIT_REG" , ""},
                    { "V1FATR_DATA_FATUR" , ""},
                    { "V1FATR_DATA_RCAP" , ""},
                    { "V1FATR_COD_EMPRESA" , ""},
                    { "V1FATR_DATA_VENC" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_V1FATURA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V1FATURA_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "V1FATR_NUM_APOL" , ""},
                    { "V1FATR_COD_SUBG" , ""},
                    { "V1FATR_NUM_FATUR" , ""},
                    { "V1FATR_COD_OPER" , ""},
                    { "V1FATR_TIPO_ENDOS" , ""},
                    { "V1FATR_NUM_ENDOS" , ""},
                    { "V1FATR_VAL_FATURA" , ""},
                    { "V1FATR_COD_FONTE" , ""},
                    { "V1FATR_NUM_RCAP" , ""},
                    { "V1FATR_VAL_RCAP" , ""},
                    { "V1FATR_DATA_INIVIG" , ""},
                    { "V1FATR_DATA_TERVIG" , ""},
                    { "V1FATR_SIT_REG" , ""},
                    { "V1FATR_DATA_FATUR" , ""},
                    { "V1FATR_DATA_RCAP" , ""},
                    { "V1FATR_COD_EMPRESA" , ""},
                    { "V1FATR_DATA_VENC" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1_Query1", q9);

                #endregion

                #region VG0100B_V1SUBGRUPO

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "V1SUBG_TIPO_FAT" , ""},
                    { "V1SUBG_NUM_APOL" , ""},
                    { "V1SUBG_COD_SUBG" , ""},
                    { "V1SUBG_COD_FONTE" , ""},
                    { "V1SUBG_BCO_COB" , ""},
                    { "V1SUBG_AGE_COB" , ""},
                    { "V1SUBG_DAC_COB" , ""},
                    { "V1SUBG_END_COB" , ""},
                    { "V1SUBG_PERI_FATUR" , ""},
                    { "V1SUBG_IND_IOF" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VG0100B_V1SUBGRUPO");
                AppSettings.TestSet.DynamicData.Add("VG0100B_V1SUBGRUPO", q10);

                #endregion

                #region R1400_00_SELECT_V0NUMEROAES_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V0NAES_ENDOSCOB" , ""},
                    { "V0NAES_ENDOSRES" , ""},
                    { "V0NAES_ENDOSSEM" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_V0NUMEROAES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_V0NUMEROAES_DB_SELECT_1_Query1", q11);

                #endregion

                #region R1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "V0NAES_ENDOSCOB" , ""},
                    { "V0NAES_ENDOSRES" , ""},
                    { "V0NAES_ENDOSSEM" , ""},
                    { "V1APOL_ORGAO" , ""},
                    { "V1APOL_RAMO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1_Update1", q12);

                #endregion

                #region R1420_00_UPDATE_V0FONTE_DB_UPDATE_1_Update1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "V0FONT_PROPAUTOM" , ""},
                    { "W1SUBG_COD_FONTE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1420_00_UPDATE_V0FONTE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1420_00_UPDATE_V0FONTE_DB_UPDATE_1_Update1", q13);

                #endregion

                #region VG0100B_V1FATURTOT1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "V1FATT_NUM_APOL" , ""},
                    { "V1FATT_COD_SUBG" , ""},
                    { "V1FATT_NUM_FATUR" , ""},
                    { "V1FATT_COD_OPER" , ""},
                    { "V1FATT_QT_VIDA_VG" , ""},
                    { "V1FATT_QT_VIDA_AP" , ""},
                    { "V1FATT_IMP_MORNAT" , ""},
                    { "V1FATT_IMP_MORACI" , ""},
                    { "V1FATT_IMP_INVPER" , ""},
                    { "V1FATT_IMP_AMDS" , ""},
                    { "V1FATT_IMP_DH" , ""},
                    { "V1FATT_IMP_DIT" , ""},
                    { "V1FATT_PRM_VG" , ""},
                    { "V1FATT_PRM_AP" , ""},
                    { "V1FATT_SIT_REG" , ""},
                    { "V1FATT_COD_EMPRESA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VG0100B_V1FATURTOT1");
                AppSettings.TestSet.DynamicData.Add("VG0100B_V1FATURTOT1", q14);

                #endregion

                #region R1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "V1APOL_ORGAO" , ""},
                    { "V1APOL_RAMO" , ""},
                    { "V1APOL_MODALIDA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1", q15);

                #endregion

                #region VG0100B_MOVIMENTO

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "V0MOVI_MORNATU_ANT" , ""},
                    { "V0MOVI_MORNATU_ATU" , ""},
                    { "V0MOVI_MORACID_ANT" , ""},
                    { "V0MOVI_MORACID_ATU" , ""},
                    { "V0MOVI_INVPERM_ANT" , ""},
                    { "V0MOVI_INVPERM_ATU" , ""},
                    { "V0MOVI_AMDS_ANT" , ""},
                    { "V0MOVI_AMDS_ATU" , ""},
                    { "V0MOVI_DH_ANT" , ""},
                    { "V0MOVI_DH_ATU" , ""},
                    { "V0MOVI_DIT_ANT" , ""},
                    { "V0MOVI_DIT_ATU" , ""},
                    { "V0MOVI_VG_ANT" , ""},
                    { "V0MOVI_VG_ATU" , ""},
                    { "V0MOVI_AP_ANT" , ""},
                    { "V0MOVI_AP_ATU" , ""},
                    { "V0MOVI_COD_OPER" , ""},
                    { "V0MOVI_DATA_MOVI" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VG0100B_MOVIMENTO");
                AppSettings.TestSet.DynamicData.Add("VG0100B_MOVIMENTO", q16);

                #endregion

                #region R1800_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "V1ENDO_RAMO" , ""},
                    { "V1ENDO_MOEDA_IMP" , ""},
                    { "V1ENDO_MOEDA_PRM" , ""},
                    { "V1ENDO_OCORR_END" , ""},
                    { "V1ENDO_CORRECAO" , ""},
                    { "V1ENDO_CODPRODU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1", q17);

                #endregion

                #region R1850_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "V1MOED_CODUNIMO" , ""},
                    { "V1MOED_VLCRUZAD" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1850_00_SELECT_V1MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1850_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q18);

                #endregion

                #region R1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "V1RIND_ISECUSTO" , ""},
                    { "V1RIND_PCIOF" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1", q19);

                #endregion

                #region R1940_00_ACESSA_RCAPCOMP_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "V1RCAP_BCOAVISO" , ""},
                    { "V1RCAP_AGEAVISO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1940_00_ACESSA_RCAPCOMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1940_00_ACESSA_RCAPCOMP_DB_SELECT_1_Query1", q20);

                #endregion

                #region R1950_00_SELECT_V1FONTE_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                    { "V0FONT_PROPAUTOM" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1950_00_SELECT_V1FONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1950_00_SELECT_V1FONTE_DB_SELECT_1_Query1", q21);

                #endregion

                #region R2305_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_DATA_TERVIGENCIA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R2305_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2305_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1", q22);

                #endregion

                #region R2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                    { "V1FATC_DATA_REFER" , ""},
                    { "DATA_TERVIG" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1", q23);

                #endregion

                #region R2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                    { "V1FATC_DATA_REFER" , ""},
                    { "DATA_TERVIG" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1", q24);

                #endregion

                #region R2450_00_INSERE_COBERAPOL_DB_INSERT_1_Insert1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                    { "V0COBE_NUM_APOL" , ""},
                    { "V0COBE_NUM_ENDOS" , ""},
                    { "V0COBE_NUM_ITEM" , ""},
                    { "V0COBE_OCORR_HIST" , ""},
                    { "V0COBE_RAMOFR" , ""},
                    { "V0COBE_MODALIFR" , ""},
                    { "V0COBE_COD_COBER" , ""},
                    { "V0COBE_IMP_SEGUR_I" , ""},
                    { "V0COBE_PRM_TARIF_I" , ""},
                    { "V0COBE_IMP_SEGUR_V" , ""},
                    { "V0COBE_PRM_TARIF_V" , ""},
                    { "V0COBE_PCT_COBER" , ""},
                    { "V0COBE_FAT_MULT" , ""},
                    { "V0COBE_DATA_INIVIG" , ""},
                    { "V0COBE_DATA_TERVIG" , ""},
                    { "V0COBE_COD_EMPRESA" , ""},
                    { "V0COBE_COD_SITUACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2450_00_INSERE_COBERAPOL_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2450_00_INSERE_COBERAPOL_DB_INSERT_1_Insert1", q25);

                #endregion

                #region R3080_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                    { "V0RELT_COD_USUAR" , ""},
                    { "V0RELT_DATA_SOLI" , ""},
                    { "V0RELT_CODREL" , ""},
                    { "V1SIST_DTMOVABE" , ""},
                    { "V0RELT_DATA_REFER" , ""},
                    { "V0RELT_FONTE" , ""},
                    { "V1SOLF_NUM_APOL" , ""},
                    { "V0RELT_NRENDOS" , ""},
                    { "V0RELT_CODSUBES" , ""},
                    { "V0RELT_COD_EMPRESA" , ""},
                    { "V0RELT_PERI_RENOVA" , ""},
                    { "V0RELT_PCT_AUMENTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3080_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3080_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1", q26);

                #endregion

                #region R3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                    { "V0FATR_NUM_APOL" , ""},
                    { "V0FATR_COD_SUBG" , ""},
                    { "V0FATR_NUM_FATUR" , ""},
                    { "V0FATR_COD_OPER" , ""},
                    { "V0FATR_TIPO_ENDOS" , ""},
                    { "V0FATR_NUM_ENDOS" , ""},
                    { "V0FATR_VAL_FATURA" , ""},
                    { "V0FATR_COD_FONTE" , ""},
                    { "V0FATR_NUM_RCAP" , ""},
                    { "V0FATR_VAL_RCAP" , ""},
                    { "V0FATR_DATA_INIVIG" , ""},
                    { "V0FATR_DATA_TERVIG" , ""},
                    { "V0FATR_SIT_REG" , ""},
                    { "V0FATR_DATA_FATUR" , ""},
                    { "V0FATR_DATA_RCAP" , ""},
                    { "V0FATR_COD_EMPRESA" , ""},
                    { "V0FATR_DATA_VENC" , ""},
                    { "V0FATR_VLIOCC" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1", q27);

                #endregion

                #region R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1_Insert1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                    { "V0FATT_NUM_APOL" , ""},
                    { "V0FATT_COD_SUBG" , ""},
                    { "V0FATT_NUM_FATUR" , ""},
                    { "V0FATT_COD_OPER" , ""},
                    { "V0FATT_QT_VIDA_VG" , ""},
                    { "V0FATT_QT_VIDA_AP" , ""},
                    { "V0FATT_IMP_MORNAT" , ""},
                    { "V0FATT_IMP_MORACI" , ""},
                    { "V0FATT_IMP_INVPER" , ""},
                    { "V0FATT_IMP_AMDS" , ""},
                    { "V0FATT_IMP_DH" , ""},
                    { "V0FATT_IMP_DIT" , ""},
                    { "V0FATT_PRM_VG" , ""},
                    { "V0FATT_PRM_AP" , ""},
                    { "V0FATT_SIT_REG" , ""},
                    { "V0FATT_COD_EMPRESA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1_Insert1", q28);

                #endregion

                #region R3300_00_V0ENDOSSO_PROPAUTOM_DB_INSERT_1_Insert1

                var q29 = new DynamicData();
                    q29.AddDynamic(new Dictionary<string, string>{
                    { "V0ENDO_NUM_APOL" , ""},
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
                    { "V0ENDO_TIPEND" , ""},
                    { "V0ENDO_COD_USUAR" , ""},
                    { "V0ENDO_OCORR_END" , ""},
                    { "V0ENDO_SITUACAO" , ""},
                    { "V0ENDO_DATARCAP" , ""},
                    { "V0ENDO_COD_EMPRESA" , ""},
                    { "V0ENDO_CORRECAO" , ""},
                    { "V0ENDO_ISENTA_CST" , ""},
                    { "V0ENDO_DTVENCTO" , ""},
                    { "V0ENDO_RAMO" , ""},
                    { "V0ENDO_CODPRODU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3300_00_V0ENDOSSO_PROPAUTOM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3300_00_V0ENDOSSO_PROPAUTOM_DB_INSERT_1_Insert1", q29);

                #endregion

                #region R3500_00_SELECT_V1FATURA_DB_SELECT_1_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                    { "V1FATR_DATA_INIVIG" , ""},
                    { "V1FATR_DATA_TERVIG" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3500_00_SELECT_V1FATURA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3500_00_SELECT_V1FATURA_DB_SELECT_1_Query1", q30);

                #endregion

                #region R4100_00_DELETE_V0FATURASTOT_DB_DELETE_1_Delete1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                    { "W1SOLF_NUM_APOL" , ""},
                    { "W1SOLF_COD_SUBG" , ""},
                    { "W1SOLF_NUM_FAT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R4100_00_DELETE_V0FATURASTOT_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R4100_00_DELETE_V0FATURASTOT_DB_DELETE_1_Delete1", q31);

                #endregion

                #region R5100_00_DELETE_V0FATURAS_DB_DELETE_1_Delete1

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                    { "W1SOLF_NUM_APOL" , ""},
                    { "W1SOLF_COD_SUBG" , ""},
                    { "W1SOLF_NUM_FAT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R5100_00_DELETE_V0FATURAS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R5100_00_DELETE_V0FATURAS_DB_DELETE_1_Delete1", q32);

                #endregion

                #region R5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1_Update1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                    { "V1SUBG_PERI_FATUR" , ""},
                    { "V1SIST_DTMOVABE" , ""},
                    { "W1SOLF_NUM_APOL" , ""},
                    { "W1SOLF_COD_SUBG" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1_Update1", q33);

                #endregion

                #region R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1_Update1

                var q34 = new DynamicData();
                q34.AddDynamic(new Dictionary<string, string>{
                    { "V1SOLF_SIT_REG" , ""},
                    { "V1SOLF_NUM_APOL" , ""},
                    { "V1SOLF_COD_SUBG" , ""},
                    { "V1SOLF_NUM_FAT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1_Update1", q34);

                #endregion

                #region R5400_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1

                var q35 = new DynamicData();
                q35.AddDynamic(new Dictionary<string, string>{
                    { "V1FATC_DATA_REFER" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R5400_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R5400_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1", q35);

                #endregion

                #region R5400_00_SELECT_V1FATURCONT_DB_SELECT_2_Query1

                var q36 = new DynamicData();
                q36.AddDynamic(new Dictionary<string, string>{
                    { "V9SOLF_NUM_FAT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R5400_00_SELECT_V1FATURCONT_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R5400_00_SELECT_V1FATURCONT_DB_SELECT_2_Query1", q36);

                #endregion

                #region R5500_00_INSERT_V0SOLICITAFAT_DB_INSERT_1_Insert1

                var q37 = new DynamicData();
                q37.AddDynamic(new Dictionary<string, string>{
                    { "W1SOLF_NUM_APOL" , ""},
                    { "W1SOLF_COD_SUBG" , ""},
                    { "V0SOLF_NUM_FATUR" , ""},
                    { "V1SIST_DTMOVABE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R5500_00_INSERT_V0SOLICITAFAT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R5500_00_INSERT_V0SOLICITAFAT_DB_INSERT_1_Insert1", q37);

                #endregion

                #region R5600_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

                var q38 = new DynamicData();
                q38.AddDynamic(new Dictionary<string, string>{
                    { "V0ENDO_DTTERVIG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R5600_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R5600_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q38);

                #endregion

                #region VG0100B_CMOVTO2

                var q39 = new DynamicData();
                q39.AddDynamic(new Dictionary<string, string>{
                    { "V0MOVI_MORNATU_ANT" , ""},
                    { "V0MOVI_MORNATU_ATU" , ""},
                    { "V0MOVI_MORACID_ANT" , ""},
                    { "V0MOVI_MORACID_ATU" , ""},
                    { "V0MOVI_INVPERM_ANT" , ""},
                    { "V0MOVI_INVPERM_ATU" , ""},
                    { "V0MOVI_AMDS_ANT" , ""},
                    { "V0MOVI_AMDS_ATU" , ""},
                    { "V0MOVI_DH_ANT" , ""},
                    { "V0MOVI_DH_ATU" , ""},
                    { "V0MOVI_DIT_ANT" , ""},
                    { "V0MOVI_DIT_ATU" , ""},
                    { "V0MOVI_VG_ANT" , ""},
                    { "V0MOVI_VG_ATU" , ""},
                    { "V0MOVI_AP_ANT" , ""},
                    { "V0MOVI_AP_ATU" , ""},
                    { "V0MOVI_COD_OPER" , ""},
                    { "V0MOVI_DATA_MOVI" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VG0100B_CMOVTO2");
                AppSettings.TestSet.DynamicData.Add("VG0100B_CMOVTO2", q39);

                #endregion

                #region M_6510_ATUALIZA_MOV_DB_UPDATE_1_Update1

                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                    { "V0MOVI_DATA_FATURA" , ""},
                    { "V1FATC_DATA_REFER" , ""},
                    { "W1SOLF_NUM_APOL" , ""},
                    { "W1SUB_GRUPO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_6510_ATUALIZA_MOV_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_6510_ATUALIZA_MOV_DB_UPDATE_1_Update1", q40);

                #endregion

                #region M_6520_ATUALIZA_MOV_DB_UPDATE_1_Update1

                var q41 = new DynamicData();
                q41.AddDynamic(new Dictionary<string, string>{
                    { "V0MOVI_DATA_FATURA" , ""},
                    { "V1FATC_DATA_REFER" , ""},
                    { "W1SOLF_NUM_APOL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_6520_ATUALIZA_MOV_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_6520_ATUALIZA_MOV_DB_UPDATE_1_Update1", q41);

                #endregion
                #endregion
                var program = new VG0100B();
                program.Execute();

                var select1 = AppSettings.TestSet.DynamicData["R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select1);

                var select2 = AppSettings.TestSet.DynamicData["R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select2);

                var select3 = AppSettings.TestSet.DynamicData["VG0100B_V1SOLICFAT"].DynamicList.ToList();
                Assert.Empty(select3);

                var select4 = AppSettings.TestSet.DynamicData["R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select4);

                var select5 = AppSettings.TestSet.DynamicData["R1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select5);

                var select6 = AppSettings.TestSet.DynamicData["R2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select6);

                var select7 = AppSettings.TestSet.DynamicData["R1200_00_SELECT_V1FATURA_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select7);

                var select8 = AppSettings.TestSet.DynamicData["VG0100B_V1FATURAST"].DynamicList.ToList();
                Assert.Empty(select8);

                var select9 = AppSettings.TestSet.DynamicData["R1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select9);

                var select10 = AppSettings.TestSet.DynamicData["VG0100B_CMOVTO2"].DynamicList.ToList();
                Assert.Empty(select10);

                var insert1 = AppSettings.TestSet.DynamicData["R3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1"].DynamicList.ToList();
                Assert.NotEmpty(insert1);
                Assert.True(insert1[^1].TryGetValue("V0FATR_NUM_APOL", out string value1) && value1.Equals("0000000000001"));
                Assert.True(insert1[^1].TryGetValue("V0FATR_COD_OPER", out string value2) && value2.Equals("0100"));

                var update1 = AppSettings.TestSet.DynamicData["R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1_Update1"].DynamicList.ToList();
                Assert.NotEmpty(update1);
                Assert.True(update1[^1].TryGetValue("V1SOLF_SIT_REG", out string value3) && value3.Equals("1"));
                Assert.True(update1[^1].TryGetValue("V1SOLF_NUM_APOL", out string value4) && value4.Equals("0000000000001"));
                Assert.True(update1[^1].TryGetValue("UpdateCheck", out string value5) && value5.Equals("UpdateCheck"));

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void VG0100B_Tests_Fact_2()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();

                Load_Parameters();

                GE0510S_Tests.Load_Parameters_To_VG0100B();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1PRAM_RAMO_VG" , ""},
                    { "V1PRAM_RAMO_AP" , ""},
                    { "V1PRAM_RAMO_VGAP" , ""},
                    { "V1PRAM_RAMO_PRESTAMISTA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "NUM_TERMO" , ""},
                    { "COD_SUBGRUPO" , ""},
                    { "DATA_ADESAO" , ""},
                    { "PERI_PAGTO" , ""},
                    { "MODALIDADE_CAPITAL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V1SIST_DTMOVABE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q2);

                #endregion

                #region VG0100B_V1SOLICFAT

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V1SOLF_NUM_APOL" , "1"},
                    { "V1SOLF_COD_SUBG" , "1"},
                    { "V1SOLF_NUM_FAT" , ""},
                    { "V1SOLF_NUM_RCAP" , ""},
                    { "V1SOLF_VAL_RCAP" , ""},
                    { "V1SOLF_COD_OPER" , "300"},
                    { "V1SOLF_SIT_REG" , ""},
                    { "V1SOLF_DATA_RCAP" , ""},
                    { "V1SOLF_DATA_VENC" , ""},
                    { "V1SOLF_DATA_SOLI" , ""},
                    { "V1SOLF_COD_USUAR" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V1SOLF_NUM_APOL" , ""},
                    { "V1SOLF_COD_SUBG" , "1"},
                    { "V1SOLF_NUM_FAT" , ""},
                    { "V1SOLF_NUM_RCAP" , ""},
                    { "V1SOLF_VAL_RCAP" , ""},
                    { "V1SOLF_COD_OPER" , "300"},
                    { "V1SOLF_SIT_REG" , ""},
                    { "V1SOLF_DATA_RCAP" , ""},
                    { "V1SOLF_DATA_VENC" , ""},
                    { "V1SOLF_DATA_SOLI" , ""},
                    { "V1SOLF_COD_USUAR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VG0100B_V1SOLICFAT");
                AppSettings.TestSet.DynamicData.Add("VG0100B_V1SOLICFAT", q3);

                #endregion

                #region VG0100B_V1FATURAST

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V1FATT_NUM_APOL" , ""},
                    { "V1FATT_COD_SUBG" , ""},
                    { "V1FATT_NUM_FATUR" , ""},
                    { "V1FATT_COD_OPER" , ""},
                    { "V1FATT_QT_VIDA_VG" , ""},
                    { "V1FATT_QT_VIDA_AP" , ""},
                    { "V1FATT_IMP_MORNAT" , ""},
                    { "V1FATT_IMP_MORACI" , ""},
                    { "V1FATT_IMP_INVPER" , ""},
                    { "V1FATT_IMP_AMDS" , ""},
                    { "V1FATT_IMP_DH" , ""},
                    { "V1FATT_IMP_DIT" , ""},
                    { "V1FATT_PRM_VG" , ""},
                    { "V1FATT_PRM_AP" , ""},
                    { "V1FATT_SIT_REG" , ""},
                    { "V1FATT_COD_EMPRESA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VG0100B_V1FATURAST");
                AppSettings.TestSet.DynamicData.Add("VG0100B_V1FATURAST", q4);

                #endregion

                #region R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                //q5.AddDynamic(new Dictionary<string, string>{
                //    { "V0PROP_NRCERTIF" , ""}
                //});
                AppSettings.TestSet.DynamicData.Remove("R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0910_00_FETCH_V1SOLICFAT_DB_SELECT_2_Query1

                var q6 = new DynamicData();
                //q6.AddDynamic(new Dictionary<string, string>{
                //    { "NUM_TITULO" , ""}
                //});
                AppSettings.TestSet.DynamicData.Remove("R0910_00_FETCH_V1SOLICFAT_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0910_00_FETCH_V1SOLICFAT_DB_SELECT_2_Query1", q6);

                #endregion

                #region R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V1SUBG_TIPO_FAT" , "1"},
                    { "V1SUBG_COD_FONTE" , ""},
                    { "V1SUBG_COD_SUBG" , ""},
                    { "V1SUBG_END_COB" , ""},
                    { "V1SUBG_BCO_COB" , ""},
                    { "V1SUBG_AGE_COB" , ""},
                    { "V1SUBG_DAC_COB" , ""},
                    { "V1SUBG_PERI_FATUR" , ""},
                    { "V1SUBG_DTTERVIG" , ""},
                    { "V1SUBG_IND_IOF" , "N"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1200_00_SELECT_V1FATURA_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V1FATR_NUM_APOL" , ""},
                    { "V1FATR_COD_SUBG" , ""},
                    { "V1FATR_NUM_FATUR" , ""},
                    { "V1FATR_COD_OPER" , "200"},
                    { "V1FATR_TIPO_ENDOS" , ""},
                    { "V1FATR_NUM_ENDOS" , ""},
                    { "V1FATR_VAL_FATURA" , ""},
                    { "V1FATR_COD_FONTE" , ""},
                    { "V1FATR_NUM_RCAP" , ""},
                    { "V1FATR_VAL_RCAP" , ""},
                    { "V1FATR_DATA_INIVIG" , ""},
                    { "V1FATR_DATA_TERVIG" , ""},
                    { "V1FATR_SIT_REG" , "2"},
                    { "V1FATR_DATA_FATUR" , ""},
                    { "V1FATR_DATA_RCAP" , ""},
                    { "V1FATR_COD_EMPRESA" , ""},
                    { "V1FATR_DATA_VENC" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_V1FATURA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V1FATURA_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "V1FATR_NUM_APOL" , ""},
                    { "V1FATR_COD_SUBG" , ""},
                    { "V1FATR_NUM_FATUR" , ""},
                    { "V1FATR_COD_OPER" , "200"},
                    { "V1FATR_TIPO_ENDOS" , ""},
                    { "V1FATR_NUM_ENDOS" , ""},
                    { "V1FATR_VAL_FATURA" , ""},
                    { "V1FATR_COD_FONTE" , ""},
                    { "V1FATR_NUM_RCAP" , ""},
                    { "V1FATR_VAL_RCAP" , ""},
                    { "V1FATR_DATA_INIVIG" , ""},
                    { "V1FATR_DATA_TERVIG" , ""},
                    { "V1FATR_SIT_REG" , "2"},
                    { "V1FATR_DATA_FATUR" , ""},
                    { "V1FATR_DATA_RCAP" , ""},
                    { "V1FATR_COD_EMPRESA" , ""},
                    { "V1FATR_DATA_VENC" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1_Query1", q9);

                #endregion

                #region VG0100B_V1SUBGRUPO

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "V1SUBG_TIPO_FAT" , "1"},
                    { "V1SUBG_NUM_APOL" , ""},
                    { "V1SUBG_COD_SUBG" , ""},
                    { "V1SUBG_COD_FONTE" , ""},
                    { "V1SUBG_BCO_COB" , ""},
                    { "V1SUBG_AGE_COB" , ""},
                    { "V1SUBG_DAC_COB" , ""},
                    { "V1SUBG_END_COB" , ""},
                    { "V1SUBG_PERI_FATUR" , ""},
                    { "V1SUBG_IND_IOF" , "N"},
                });
                AppSettings.TestSet.DynamicData.Remove("VG0100B_V1SUBGRUPO");
                AppSettings.TestSet.DynamicData.Add("VG0100B_V1SUBGRUPO", q10);

                #endregion

                #region R1400_00_SELECT_V0NUMEROAES_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V0NAES_ENDOSCOB" , ""},
                    { "V0NAES_ENDOSRES" , ""},
                    { "V0NAES_ENDOSSEM" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_V0NUMEROAES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_V0NUMEROAES_DB_SELECT_1_Query1", q11);

                #endregion

                #region R1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "V0NAES_ENDOSCOB" , ""},
                    { "V0NAES_ENDOSRES" , ""},
                    { "V0NAES_ENDOSSEM" , ""},
                    { "V1APOL_ORGAO" , ""},
                    { "V1APOL_RAMO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1_Update1", q12);

                #endregion

                #region R1420_00_UPDATE_V0FONTE_DB_UPDATE_1_Update1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "V0FONT_PROPAUTOM" , ""},
                    { "W1SUBG_COD_FONTE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1420_00_UPDATE_V0FONTE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1420_00_UPDATE_V0FONTE_DB_UPDATE_1_Update1", q13);

                #endregion

                #region VG0100B_V1FATURTOT1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "V1FATT_NUM_APOL" , ""},
                    { "V1FATT_COD_SUBG" , ""},
                    { "V1FATT_NUM_FATUR" , ""},
                    { "V1FATT_COD_OPER" , ""},
                    { "V1FATT_QT_VIDA_VG" , ""},
                    { "V1FATT_QT_VIDA_AP" , ""},
                    { "V1FATT_IMP_MORNAT" , ""},
                    { "V1FATT_IMP_MORACI" , ""},
                    { "V1FATT_IMP_INVPER" , ""},
                    { "V1FATT_IMP_AMDS" , ""},
                    { "V1FATT_IMP_DH" , ""},
                    { "V1FATT_IMP_DIT" , ""},
                    { "V1FATT_PRM_VG" , "100"},
                    { "V1FATT_PRM_AP" , ""},
                    { "V1FATT_SIT_REG" , ""},
                    { "V1FATT_COD_EMPRESA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VG0100B_V1FATURTOT1");
                AppSettings.TestSet.DynamicData.Add("VG0100B_V1FATURTOT1", q14);

                #endregion

                #region R1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "V1APOL_ORGAO" , ""},
                    { "V1APOL_RAMO" , ""},
                    { "V1APOL_MODALIDA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1", q15);

                #endregion

                #region VG0100B_MOVIMENTO

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "V0MOVI_MORNATU_ANT" , ""},
                    { "V0MOVI_MORNATU_ATU" , ""},
                    { "V0MOVI_MORACID_ANT" , ""},
                    { "V0MOVI_MORACID_ATU" , ""},
                    { "V0MOVI_INVPERM_ANT" , ""},
                    { "V0MOVI_INVPERM_ATU" , ""},
                    { "V0MOVI_AMDS_ANT" , ""},
                    { "V0MOVI_AMDS_ATU" , ""},
                    { "V0MOVI_DH_ANT" , ""},
                    { "V0MOVI_DH_ATU" , ""},
                    { "V0MOVI_DIT_ANT" , ""},
                    { "V0MOVI_DIT_ATU" , ""},
                    { "V0MOVI_VG_ANT" , ""},
                    { "V0MOVI_VG_ATU" , ""},
                    { "V0MOVI_AP_ANT" , ""},
                    { "V0MOVI_AP_ATU" , ""},
                    { "V0MOVI_COD_OPER" , ""},
                    { "V0MOVI_DATA_MOVI" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VG0100B_MOVIMENTO");
                AppSettings.TestSet.DynamicData.Add("VG0100B_MOVIMENTO", q16);

                #endregion

                #region R1800_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "V1ENDO_RAMO" , "1"},
                    { "V1ENDO_MOEDA_IMP" , ""},
                    { "V1ENDO_MOEDA_PRM" , ""},
                    { "V1ENDO_OCORR_END" , ""},
                    { "V1ENDO_CORRECAO" , ""},
                    { "V1ENDO_CODPRODU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1800_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1", q17);

                #endregion

                #region R1850_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "V1MOED_CODUNIMO" , ""},
                    { "V1MOED_VLCRUZAD" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1850_00_SELECT_V1MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1850_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q18);

                #endregion

                #region R1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "V1RIND_ISECUSTO" , ""},
                    { "V1RIND_PCIOF" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1", q19);

                #endregion

                #region R1940_00_ACESSA_RCAPCOMP_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "V1RCAP_BCOAVISO" , ""},
                    { "V1RCAP_AGEAVISO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1940_00_ACESSA_RCAPCOMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1940_00_ACESSA_RCAPCOMP_DB_SELECT_1_Query1", q20);

                #endregion

                #region R1950_00_SELECT_V1FONTE_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                    { "V0FONT_PROPAUTOM" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1950_00_SELECT_V1FONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1950_00_SELECT_V1FONTE_DB_SELECT_1_Query1", q21);

                #endregion

                #region R2305_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_DATA_TERVIGENCIA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R2305_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2305_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1", q22);

                #endregion

                #region R2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                    { "V1FATC_DATA_REFER" , ""},
                    { "DATA_TERVIG" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1", q23);

                #endregion

                #region R2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                    { "V1FATC_DATA_REFER" , ""},
                    { "DATA_TERVIG" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1", q24);

                #endregion

                #region R2450_00_INSERE_COBERAPOL_DB_INSERT_1_Insert1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                    { "V0COBE_NUM_APOL" , ""},
                    { "V0COBE_NUM_ENDOS" , ""},
                    { "V0COBE_NUM_ITEM" , ""},
                    { "V0COBE_OCORR_HIST" , ""},
                    { "V0COBE_RAMOFR" , ""},
                    { "V0COBE_MODALIFR" , ""},
                    { "V0COBE_COD_COBER" , ""},
                    { "V0COBE_IMP_SEGUR_I" , ""},
                    { "V0COBE_PRM_TARIF_I" , ""},
                    { "V0COBE_IMP_SEGUR_V" , ""},
                    { "V0COBE_PRM_TARIF_V" , ""},
                    { "V0COBE_PCT_COBER" , ""},
                    { "V0COBE_FAT_MULT" , ""},
                    { "V0COBE_DATA_INIVIG" , ""},
                    { "V0COBE_DATA_TERVIG" , ""},
                    { "V0COBE_COD_EMPRESA" , ""},
                    { "V0COBE_COD_SITUACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2450_00_INSERE_COBERAPOL_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2450_00_INSERE_COBERAPOL_DB_INSERT_1_Insert1", q25);

                #endregion

                #region R3080_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                    { "V0RELT_COD_USUAR" , ""},
                    { "V0RELT_DATA_SOLI" , ""},
                    { "V0RELT_CODREL" , ""},
                    { "V1SIST_DTMOVABE" , ""},
                    { "V0RELT_DATA_REFER" , ""},
                    { "V0RELT_FONTE" , ""},
                    { "V1SOLF_NUM_APOL" , ""},
                    { "V0RELT_NRENDOS" , ""},
                    { "V0RELT_CODSUBES" , ""},
                    { "V0RELT_COD_EMPRESA" , ""},
                    { "V0RELT_PERI_RENOVA" , ""},
                    { "V0RELT_PCT_AUMENTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3080_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3080_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1", q26);

                #endregion

                #region R3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                    { "V0FATR_NUM_APOL" , ""},
                    { "V0FATR_COD_SUBG" , ""},
                    { "V0FATR_NUM_FATUR" , ""},
                    { "V0FATR_COD_OPER" , ""},
                    { "V0FATR_TIPO_ENDOS" , ""},
                    { "V0FATR_NUM_ENDOS" , ""},
                    { "V0FATR_VAL_FATURA" , ""},
                    { "V0FATR_COD_FONTE" , ""},
                    { "V0FATR_NUM_RCAP" , ""},
                    { "V0FATR_VAL_RCAP" , ""},
                    { "V0FATR_DATA_INIVIG" , ""},
                    { "V0FATR_DATA_TERVIG" , ""},
                    { "V0FATR_SIT_REG" , ""},
                    { "V0FATR_DATA_FATUR" , ""},
                    { "V0FATR_DATA_RCAP" , ""},
                    { "V0FATR_COD_EMPRESA" , ""},
                    { "V0FATR_DATA_VENC" , ""},
                    { "V0FATR_VLIOCC" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1", q27);

                #endregion

                #region R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1_Insert1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                    { "V0FATT_NUM_APOL" , ""},
                    { "V0FATT_COD_SUBG" , ""},
                    { "V0FATT_NUM_FATUR" , ""},
                    { "V0FATT_COD_OPER" , ""},
                    { "V0FATT_QT_VIDA_VG" , ""},
                    { "V0FATT_QT_VIDA_AP" , ""},
                    { "V0FATT_IMP_MORNAT" , ""},
                    { "V0FATT_IMP_MORACI" , ""},
                    { "V0FATT_IMP_INVPER" , ""},
                    { "V0FATT_IMP_AMDS" , ""},
                    { "V0FATT_IMP_DH" , ""},
                    { "V0FATT_IMP_DIT" , ""},
                    { "V0FATT_PRM_VG" , "100"},
                    { "V0FATT_PRM_AP" , ""},
                    { "V0FATT_SIT_REG" , ""},
                    { "V0FATT_COD_EMPRESA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1_Insert1", q28);

                #endregion

                #region R3300_00_V0ENDOSSO_PROPAUTOM_DB_INSERT_1_Insert1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                    { "V0ENDO_NUM_APOL" , ""},
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
                    { "V0ENDO_DTINIVIG" , "2025-01-01"},
                    { "V0ENDO_DTTERVIG" , "2024-11-11"},
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
                    { "V0ENDO_TIPEND" , ""},
                    { "V0ENDO_COD_USUAR" , ""},
                    { "V0ENDO_OCORR_END" , ""},
                    { "V0ENDO_SITUACAO" , ""},
                    { "V0ENDO_DATARCAP" , ""},
                    { "V0ENDO_COD_EMPRESA" , ""},
                    { "V0ENDO_CORRECAO" , ""},
                    { "V0ENDO_ISENTA_CST" , ""},
                    { "V0ENDO_DTVENCTO" , ""},
                    { "V0ENDO_RAMO" , ""},
                    { "V0ENDO_CODPRODU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3300_00_V0ENDOSSO_PROPAUTOM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3300_00_V0ENDOSSO_PROPAUTOM_DB_INSERT_1_Insert1", q29);

                #endregion

                #region R3500_00_SELECT_V1FATURA_DB_SELECT_1_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                    { "V1FATR_DATA_INIVIG" , ""},
                    { "V1FATR_DATA_TERVIG" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3500_00_SELECT_V1FATURA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3500_00_SELECT_V1FATURA_DB_SELECT_1_Query1", q30);

                #endregion

                #region R4100_00_DELETE_V0FATURASTOT_DB_DELETE_1_Delete1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                    { "W1SOLF_NUM_APOL" , ""},
                    { "W1SOLF_COD_SUBG" , ""},
                    { "W1SOLF_NUM_FAT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R4100_00_DELETE_V0FATURASTOT_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R4100_00_DELETE_V0FATURASTOT_DB_DELETE_1_Delete1", q31);

                #endregion

                #region R5100_00_DELETE_V0FATURAS_DB_DELETE_1_Delete1

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                    { "W1SOLF_NUM_APOL" , ""},
                    { "W1SOLF_COD_SUBG" , ""},
                    { "W1SOLF_NUM_FAT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R5100_00_DELETE_V0FATURAS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R5100_00_DELETE_V0FATURAS_DB_DELETE_1_Delete1", q32);

                #endregion

                #region R5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1_Update1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                    { "V1SUBG_PERI_FATUR" , ""},
                    { "V1SIST_DTMOVABE" , ""},
                    { "W1SOLF_NUM_APOL" , ""},
                    { "W1SOLF_COD_SUBG" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1_Update1", q33);

                #endregion

                #region R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1_Update1

                var q34 = new DynamicData();
                q34.AddDynamic(new Dictionary<string, string>{
                    { "V1SOLF_SIT_REG" , ""},
                    { "V1SOLF_NUM_APOL" , ""},
                    { "V1SOLF_COD_SUBG" , "1"},
                    { "V1SOLF_NUM_FAT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1_Update1", q34);

                #endregion

                #region R5400_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1

                var q35 = new DynamicData();
                q35.AddDynamic(new Dictionary<string, string>{
                    { "V1FATC_DATA_REFER" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R5400_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R5400_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1", q35);

                #endregion

                #region R5400_00_SELECT_V1FATURCONT_DB_SELECT_2_Query1

                var q36 = new DynamicData();
                q36.AddDynamic(new Dictionary<string, string>{
                    { "V9SOLF_NUM_FAT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R5400_00_SELECT_V1FATURCONT_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R5400_00_SELECT_V1FATURCONT_DB_SELECT_2_Query1", q36);

                #endregion

                #region R5500_00_INSERT_V0SOLICITAFAT_DB_INSERT_1_Insert1

                var q37 = new DynamicData();
                q37.AddDynamic(new Dictionary<string, string>{
                    { "W1SOLF_NUM_APOL" , ""},
                    { "W1SOLF_COD_SUBG" , ""},
                    { "V0SOLF_NUM_FATUR" , ""},
                    { "V1SIST_DTMOVABE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R5500_00_INSERT_V0SOLICITAFAT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R5500_00_INSERT_V0SOLICITAFAT_DB_INSERT_1_Insert1", q37);

                #endregion

                #region R5600_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1

                var q38 = new DynamicData();
                q38.AddDynamic(new Dictionary<string, string>{
                    { "V0ENDO_DTTERVIG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R5600_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R5600_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1", q38);

                #endregion

                #region VG0100B_CMOVTO2

                var q39 = new DynamicData();
                q39.AddDynamic(new Dictionary<string, string>{
                    { "V0MOVI_MORNATU_ANT" , ""},
                    { "V0MOVI_MORNATU_ATU" , ""},
                    { "V0MOVI_MORACID_ANT" , ""},
                    { "V0MOVI_MORACID_ATU" , ""},
                    { "V0MOVI_INVPERM_ANT" , ""},
                    { "V0MOVI_INVPERM_ATU" , ""},
                    { "V0MOVI_AMDS_ANT" , ""},
                    { "V0MOVI_AMDS_ATU" , ""},
                    { "V0MOVI_DH_ANT" , ""},
                    { "V0MOVI_DH_ATU" , ""},
                    { "V0MOVI_DIT_ANT" , ""},
                    { "V0MOVI_DIT_ATU" , ""},
                    { "V0MOVI_VG_ANT" , ""},
                    { "V0MOVI_VG_ATU" , ""},
                    { "V0MOVI_AP_ANT" , ""},
                    { "V0MOVI_AP_ATU" , ""},
                    { "V0MOVI_COD_OPER" , ""},
                    { "V0MOVI_DATA_MOVI" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VG0100B_CMOVTO2");
                AppSettings.TestSet.DynamicData.Add("VG0100B_CMOVTO2", q39);

                #endregion

                #region M_6510_ATUALIZA_MOV_DB_UPDATE_1_Update1

                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                    { "V0MOVI_DATA_FATURA" , ""},
                    { "V1FATC_DATA_REFER" , ""},
                    { "W1SOLF_NUM_APOL" , ""},
                    { "W1SUB_GRUPO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_6510_ATUALIZA_MOV_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_6510_ATUALIZA_MOV_DB_UPDATE_1_Update1", q40);

                #endregion

                #region M_6520_ATUALIZA_MOV_DB_UPDATE_1_Update1

                var q41 = new DynamicData();
                q41.AddDynamic(new Dictionary<string, string>{
                    { "V0MOVI_DATA_FATURA" , ""},
                    { "V1FATC_DATA_REFER" , ""},
                    { "W1SOLF_NUM_APOL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_6520_ATUALIZA_MOV_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_6520_ATUALIZA_MOV_DB_UPDATE_1_Update1", q41);

                #endregion
                #endregion
                var program = new VG0100B();
                program.Execute();

                var select1 = AppSettings.TestSet.DynamicData["R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select1);

                var select2 = AppSettings.TestSet.DynamicData["R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select2);

                var select3 = AppSettings.TestSet.DynamicData["VG0100B_V1SOLICFAT"].DynamicList.ToList();
                Assert.Empty(select3);

                var select4 = AppSettings.TestSet.DynamicData["R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select4);

                var select5 = AppSettings.TestSet.DynamicData["R1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select5);

                var select6 = AppSettings.TestSet.DynamicData["R2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select6);

                var select7 = AppSettings.TestSet.DynamicData["R3500_00_SELECT_V1FATURA_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select7);

                var select8 = AppSettings.TestSet.DynamicData["VG0100B_V1FATURAST"].DynamicList.ToList();
                Assert.Empty(select8);

                var select9 = AppSettings.TestSet.DynamicData["R1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select9);

                var select10 = AppSettings.TestSet.DynamicData["R1800_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select10);

                var insert1 = AppSettings.TestSet.DynamicData["R3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1"].DynamicList.ToList();
                Assert.NotEmpty(insert1);
                Assert.True(insert1[^1].TryGetValue("V0FATR_NUM_APOL", out string value1) && value1.Equals("0000000000001"));
                Assert.True(insert1[^1].TryGetValue("V0FATR_COD_OPER", out string value2) && value2.Equals("0300"));

                var insert2 = AppSettings.TestSet.DynamicData["R3080_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1"].DynamicList.ToList();
                Assert.NotEmpty(insert2);
                Assert.True(insert2[^1].TryGetValue("V1SOLF_NUM_APOL", out string value3) && value3.Equals("0000000000001"));

                var update1 = AppSettings.TestSet.DynamicData["R1420_00_UPDATE_V0FONTE_DB_UPDATE_1_Update1"].DynamicList.ToList();
                Assert.NotEmpty(update1);
                Assert.True(update1[^1].TryGetValue("V0FONT_PROPAUTOM", out string value5) && value5.Equals("000000001"));
                Assert.True(update1[^1].TryGetValue("UpdateCheck", out string value7) && value7.Equals("UpdateCheck"));

                var update2 = AppSettings.TestSet.DynamicData["R1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1_Update1"].DynamicList.ToList();
                Assert.NotEmpty(update2);
                Assert.True(update2[^1].TryGetValue("V0NAES_ENDOSSEM", out string value8) && value8.Equals("000000001"));
                Assert.True(update2[^1].TryGetValue("UpdateCheck", out string value9) && value9.Equals("UpdateCheck"));

                var update3 = AppSettings.TestSet.DynamicData["R5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1_Update1"].DynamicList.ToList();
                Assert.NotEmpty(update2);
                Assert.True(update2[^1].TryGetValue("V0NAES_ENDOSSEM", out string value10) && value10.Equals("000000001"));
                Assert.True(update2[^1].TryGetValue("UpdateCheck", out string value11) && value11.Equals("UpdateCheck"));

                var delete1 = AppSettings.TestSet.DynamicData["R5100_00_DELETE_V0FATURAS_DB_DELETE_1_Delete1"].DynamicList.ToList();
                Assert.Empty(delete1);
                
                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void VG0100B_Tests_Fact_ReturnCode99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();

                Load_Parameters();

                GE0510S_Tests.Load_Parameters_To_VG0100B();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_NRCERTIF" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1", q5);
                #endregion
                #endregion

                var program = new VG0100B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}