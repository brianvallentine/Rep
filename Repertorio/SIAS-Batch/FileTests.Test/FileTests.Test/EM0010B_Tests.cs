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
using static Code.EM0010B;

namespace FileTests.Test
{
    [Collection("EM0010B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM0010B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region A1000_LE_SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE" , ""},
                { "WHOST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("A1000_LE_SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region A1000_LE_SISTEMA_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE_CO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("A1000_LE_SISTEMA_DB_SELECT_2_Query1", q1);

            #endregion

            #region A1500_LE_V1PARAMRAMO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PARM_RAMO_VG" , ""},
                { "PARM_RAMO_AP" , ""},
                { "PARM_RAMO_VGAPC" , ""},
                { "PARM_RAMO_SAUDE" , ""},
                { "PARM_RAMO_PRESTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("A1500_LE_V1PARAMRAMO_DB_SELECT_1_Query1", q2);

            #endregion

            #region A1600_LE_V1PARAMETRO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PARM_CODLIDER" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("A1600_LE_V1PARAMETRO_DB_SELECT_1_Query1", q3);

            #endregion

            #region EM0010B_V0ENDOS

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "ENDO_NUM_APOLICE" , ""},
                { "ENDO_NRENDOS" , ""},
                { "ENDO_CODSUBES" , ""},
                { "ENDO_FONTE" , ""},
                { "ENDO_NRPROPOS" , ""},
                { "ENDO_ORGAO" , ""},
                { "ENDO_RAMO" , ""},
                { "ENDO_DATPRO" , ""},
                { "ENDO_DT_LIBERACAO" , ""},
                { "ENDO_DTEMIS" , ""},
                { "ENDO_DTINIVIG" , ""},
                { "ENDO_DTTERVIG" , ""},
                { "ENDO_PCENTRAD" , ""},
                { "ENDO_PCADICIO" , ""},
                { "ENDO_PCDESCON" , ""},
                { "ENDO_PRESTA1" , ""},
                { "ENDO_QTPARCEL" , ""},
                { "ENDO_COD_MOEDA_PRM" , ""},
                { "ENDO_NRRCAP" , ""},
                { "ENDO_VLRCAP" , ""},
                { "ENDO_DATARCAP" , ""},
                { "ENDO_TIPO_ENDOSSO" , ""},
                { "ENDO_BCORCAP" , ""},
                { "ENDO_AGERCAP" , ""},
                { "ENDO_BCOCOBR" , ""},
                { "ENDO_AGECOBR" , ""},
                { "ENDO_ISENTA_CUSTO" , ""},
                { "ENDO_TIPO_APOL" , ""},
                { "ENDO_QTITENS" , ""},
                { "ENDO_CORRECAO" , ""},
                { "ENDO_DTVENCTO" , ""},
                { "ENDO_NUMBIL" , ""},
                { "ENDO_CODPRODU" , ""},
                { "ENDO_PODPUBL" , ""},
                { "ENDO_TIPSEGU" , ""},
                { "ENDO_VLCUSEMI" , ""},
                { "ENDO_COD_USUARIO" , ""},
                { "ENDO_CFPREFIX" , ""},
                { "ENDO_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0010B_V0ENDOS", q4);

            #endregion

            #region EM0010B_V1COBERAPOL

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "COBT_TARIFARIO_VAR" , ""},
                { "COBT_TARIFARIO_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0010B_V1COBERAPOL", q5);

            #endregion

            #region A3500_LE_SUBGRUPO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SUB_OPC_CORRETAGEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("A3500_LE_SUBGRUPO_DB_SELECT_1_Query1", q6);

            #endregion

            #region A3510_LE_RAMOIND_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "RAMOIND_PCIOF" , ""},
                { "RAMO_PERC_IOF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("A3510_LE_RAMOIND_DB_SELECT_1_Query1", q7);

            #endregion

            #region A4000_LE_APOLICE_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "APOL_COD_CLIENTE" , ""},
                { "APOL_NUM_APOLICE" , ""},
                { "APOL_MODALIDA" , ""},
                { "APOL_ORGAO" , ""},
                { "APOL_RAMO" , ""},
                { "APOL_TIPO_SEGURO" , ""},
                { "APOL_TIPO_APOLICE" , ""},
                { "APOL_TIPO_CALCULO" , ""},
                { "APOL_IND_ENDOS_MAN" , ""},
                { "APOL_PCDESCON" , ""},
                { "APOL_PCIOCC" , ""},
                { "APOL_TPCOSSEG" , ""},
                { "APOL_QTCOSSEG" , ""},
                { "APOL_PCCOSSEG" , ""},
                { "APOL_TIPO_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("A4000_LE_APOLICE_DB_SELECT_1_Query1", q8);

            #endregion

            #region A4100_LE_PROPCOB_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "PRCB_TIPO_COBRANCA" , ""},
                { "PRCB_DIA_DEBITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("A4100_LE_PROPCOB_DB_SELECT_1_Query1", q9);

            #endregion

            #region A4200_LE_AU085_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "AU085_IND_FORMA_PAGTO_AD" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("A4200_LE_AU085_DB_SELECT_1_Query1", q10);

            #endregion

            #region EM0010B_V0APOLCOS

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "COSS_CODCOSS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("EM0010B_V0APOLCOS", q11);

            #endregion

            #region A4600_LE_MR_APOL_COBER_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "PCT_DESCONTO_TOTAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("A4600_LE_MR_APOL_COBER_DB_SELECT_1_Query1", q12);

            #endregion

            #region A5000_LE_APOLITEM_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "APIT_QTITENS" , ""},
                { "APIT_TARIFARIO_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("A5000_LE_APOLITEM_DB_SELECT_1_Query1", q13);

            #endregion

            #region A6200_000_LE_RCAP_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("A6200_000_LE_RCAP_DB_SELECT_1_Query1", q14);

            #endregion

            #region A6200_000_LE_RCAP_DB_SELECT_2_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("A6200_000_LE_RCAP_DB_SELECT_2_Query1", q15);

            #endregion

            #region A6200_000_LE_RCAP_DB_SELECT_3_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("A6200_000_LE_RCAP_DB_SELECT_3_Query1", q16);

            #endregion

            #region EM0010B_V1RCAPCOMP

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "PCOM_FONTE" , ""},
                { "PCOM_NRRCAP" , ""},
                { "PCOM_NRRCAPCO" , ""},
                { "PCOM_OPERACAO" , ""},
                { "PCOM_DTMOVTO" , ""},
                { "PCOM_HORAOPER" , ""},
                { "PCOM_SITUACAO" , ""},
                { "PCOM_BCOAVISO" , ""},
                { "PCOM_AGEAVISO" , ""},
                { "PCOM_NRAVISO" , ""},
                { "PCOM_VLRCAP" , ""},
                { "PCOM_DATARCAP" , ""},
                { "PCOM_DTCADAST" , ""},
                { "PCOM_SITCONTB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0010B_V1RCAPCOMP", q17);

            #endregion

            #region B1000_GRAVA_V0ORDECOSCED_DB_INSERT_1_Insert1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "NORD_NUM_APOLICE" , ""},
                { "NORD_NRENDOS" , ""},
                { "NORD_CODCOSS" , ""},
                { "WORD_NRORDEM" , ""},
                { "NORD_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B1000_GRAVA_V0ORDECOSCED_DB_INSERT_1_Insert1", q18);

            #endregion

            #region B1050_LE_NUMERO_COSCED_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "NUME_NRORDEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B1050_LE_NUMERO_COSCED_DB_SELECT_1_Query1", q19);

            #endregion

            #region B1060_ATU_NUMERO_COSCED_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "NORD_NRORDEM" , ""},
                { "COSS_CODCOSS" , ""},
                { "ENDO_ORGAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B1060_ATU_NUMERO_COSCED_DB_UPDATE_1_Update1", q20);

            #endregion

            #region B1100_LE_V2RAMO_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "RAMO_TIPOFRAC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B1100_LE_V2RAMO_DB_SELECT_1_Query1", q21);

            #endregion

            #region B2000_GRAVA_PARCELA_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "AUTA_NRPRRESS" , ""},
                { "AUTA_TIPO_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2000_GRAVA_PARCELA_DB_SELECT_1_Query1", q22);

            #endregion

            #region B2000_CONTINUA_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "FATU_VLPRMTOT" , ""},
                { "FATU_VLIOCC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2000_CONTINUA_DB_SELECT_1_Query1", q23);

            #endregion

            #region B2000_CONTINUA_DB_SELECT_2_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "FATU_VLPRMTOT" , ""},
                { "FATU_VLIOCC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2000_CONTINUA_DB_SELECT_2_Query1", q24);

            #endregion

            #region B2002_CONTINUA_DB_INSERT_1_Insert1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "PARC_NUM_APOLICE" , ""},
                { "PARC_NRENDOS" , ""},
                { "PARC_NRPARCEL" , ""},
                { "PARC_DACPARC" , ""},
                { "PARC_FONTE" , ""},
                { "PARC_NRTIT" , ""},
                { "PARC_TARIFARIO_IX" , ""},
                { "PARC_DESCONTO_IX" , ""},
                { "PARC_OTNPRLIQ" , ""},
                { "PARC_OTNADFRA" , ""},
                { "PARC_OTNCUSTO" , ""},
                { "PARC_OTNIOF" , ""},
                { "PARC_OTNTOTAL" , ""},
                { "PARC_OCORHIST" , ""},
                { "PARC_QTDDOC" , ""},
                { "PARC_SITUACAO" , ""},
                { "PARC_COD_EMPRESA" , ""},
                { "PARC_SIT_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2002_CONTINUA_DB_INSERT_1_Insert1", q25);

            #endregion

            #region B2018_RECUPERA_AU084_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "AU084_IND_FORMA_PAGTO_AD" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B2018_RECUPERA_AU084_DB_SELECT_1_Query1", q26);

            #endregion

            #region B2020_SELECT_MR021_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "MR021_PCT_DESC_COBERTURA" , ""},
                { "MR021_PCT_BONUS_RENOVCAO" , ""},
                { "MR021_PCT_DESC_CORRETOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2020_SELECT_MR021_DB_SELECT_1_Query1", q27);

            #endregion

            #region B2025_TRATA_2PCELA_CCA_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_PARAM_DATE03" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B2025_TRATA_2PCELA_CCA_DB_SELECT_1_Query1", q28);

            #endregion

            #region B2030_SELECT_MR022_DB_SELECT_1_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "MR022_PCT_DESC_COBERTURA" , ""},
                { "MR022_PCT_BONUS_RENOVCAO" , ""},
                { "MR022_PCT_DESC_CORRETOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2030_SELECT_MR022_DB_SELECT_1_Query1", q29);

            #endregion

            #region B2031_SELECT_MRAPOITE_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "MRAPOITE_PCT_DESC_FIDEL" , ""},
                { "MRAPOITE_PCT_DESC_COMERCIAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2031_SELECT_MRAPOITE_DB_SELECT_1_Query1", q30);

            #endregion

            #region B2035_SELECT_MRAPOCOB_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "MRAPOCOB_PRM_TARIFARIO_IX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B2035_SELECT_MRAPOCOB_DB_SELECT_1_Query1", q31);

            #endregion

            #region B2040_SELECT_V0APOL_HABIT_DB_SELECT_1_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "V0PRHA_CODCLIEN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B2040_SELECT_V0APOL_HABIT_DB_SELECT_1_Query1", q32);

            #endregion

            #region B2061_SELECT_LTMVPROP_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "LTMVPROP_SEQ_PROPOSTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B2061_SELECT_LTMVPROP_DB_SELECT_1_Query1", q33);

            #endregion

            #region B2061_SELECT_LTMVPROP_DB_SELECT_2_Query1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "LTMVPROP_COD_EXT_SEGURADO" , ""},
                { "LTMVPROP_COD_CLASSE_ADESAO" , ""},
                { "LTMVPROP_NUM_CLASSE_ADESAO" , ""},
                { "LTMVPROP_COMPL_ENDER" , ""},
                { "LTMVPROP_DT_INIVIG_PROPOSTA" , ""},
                { "LTMVPROP_NUM_APOLICE" , ""},
                { "LTMVPROP_QTD_PARCELAS" , ""},
                { "LTMVPROP_VLR_JUROS_MENSAL" , ""},
                { "LTMVPROP_VLR_CUSTO_APOLICE" , ""},
                { "LTMVPROP_PCT_JUROS" , ""},
                { "LTMVPROP_DATA_MOVIMENTO" , ""},
                { "LTMVPROP_HORA_MOVIMENTO" , ""},
                { "LTMVPROP_COD_MOVIMENTO" , ""},
                { "LTMVPROP_SIT_MOVIMENTO" , ""},
                { "LTMVPROP_COD_PRODUTO" , ""},
                { "LTMVPROP_COD_EXT_ESTIP" , ""},
                { "LTMVPROP_PCT_IOF" , ""},
                { "LTMVPROP_CGCCPF" , ""},
                { "LTMVPROP_IND_REGIAO" , ""},
                { "LTMVPROP_PCT_DESC_FIDEL" , ""},
                { "LTMVPROP_PCT_DESC_EXP" , ""},
                { "LTMVPROP_PCT_DESC_AGRUP" , ""},
                { "LTMVPROP_PCT_DESC_EQUIP" , ""},
                { "LTMVPROP_PCT_DESC_BLINDAGEM" , ""},
                { "LTMVPROP_NUM_PROPOSTA_SIM" , ""},
                { "LTMVPROP_IND_TIPO_VIGENCIA" , ""},
                { "LTMVPROP_QTD_REN_SEM_SINI" , ""},
                { "LTMVPROP_QTD_REN_SEM_SINI_INF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2061_SELECT_LTMVPROP_DB_SELECT_2_Query1", q34);

            #endregion

            #region B2061_00_SELECT_COBER_DB_SELECT_1_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "LTMVPRCO_VAL_IMP_SEGURADA" , ""},
                { "LTMVPRCO_VAL_TAXA_PREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2061_00_SELECT_COBER_DB_SELECT_1_Query1", q35);

            #endregion

            #region B2061_10_00_LER_PREMIO_2021_DB_SELECT_1_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "LT028_DIA_VENC_DEMAIS_PARCELAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B2061_10_00_LER_PREMIO_2021_DB_SELECT_1_Query1", q36);

            #endregion

            #region B2064_SELECT_LTMVPROP_DB_SELECT_1_Query1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "LTMVPROP_COD_MOVIMENTO" , ""},
                { "LTMVPROP_VLR_JUROS_MENSAL" , ""},
                { "LTMVPROP_VLR_CUSTO_APOLICE" , ""},
                { "LTMVPROP_NUM_CLASSE_ADESAO" , ""},
                { "LTMVPROP_IND_REGIAO" , ""},
                { "LTMVPROP_PCT_DESC_AGRUP" , ""},
                { "LTMVPROP_PCT_DESC_FIDEL" , ""},
                { "LTMVPROP_PCT_DESC_EXP" , ""},
                { "LTMVPROP_PCT_DESC_EQUIP" , ""},
                { "LTMVPROP_PCT_DESC_BLINDAGEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2064_SELECT_LTMVPROP_DB_SELECT_1_Query1", q37);

            #endregion

            #region B2070_SELECT_V0NOVACAO_DB_SELECT_1_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "V0NOVA_VL_IOF_MIP" , ""},
                { "V0NOVA_VL_IOF_DFI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2070_SELECT_V0NOVACAO_DB_SELECT_1_Query1", q38);

            #endregion

            #region B2080_SELECT_V0PREMIO_HAB_DB_SELECT_1_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V0PRHA_VAL_IOF_TOTAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B2080_SELECT_V0PREMIO_HAB_DB_SELECT_1_Query1", q39);

            #endregion

            #region B2080_SELECT_V0PREMIO_HAB_DB_SELECT_2_Query1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V0PRHA_VAL_IOF_TOTAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B2080_SELECT_V0PREMIO_HAB_DB_SELECT_2_Query1", q40);

            #endregion

            #region B2081_SELECT_V0PREMIO_HAB_DB_SELECT_1_Query1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V0PRHA_VAL_IOF_TOTAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B2081_SELECT_V0PREMIO_HAB_DB_SELECT_1_Query1", q41);

            #endregion

            #region B2081_SELECT_V0PREMIO_HAB_DB_SELECT_2_Query1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "V0PRHA_VAL_IOF_TOTAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B2081_SELECT_V0PREMIO_HAB_DB_SELECT_2_Query1", q42);

            #endregion

            #region B2090_00_SELECT_EFPREMIO_DB_SELECT_1_Query1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "WS_EF_VLR_EMISSAO" , ""},
                { "WS_EF_VLR_CREDITO" , ""},
                { "WS_EF_IOF_EMISSAO" , ""},
                { "WS_EF_IOF_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2090_00_SELECT_EFPREMIO_DB_SELECT_1_Query1", q43);

            #endregion

            #region B2090_10_SELECT_EFFATURA_DB_SELECT_1_Query1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "WS_EF_VLR_EMISSAO" , ""},
                { "WS_EF_VLR_CREDITO" , ""},
                { "WS_EF_IOF_EMISSAO" , ""},
                { "WS_EF_IOF_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2090_10_SELECT_EFFATURA_DB_SELECT_1_Query1", q44);

            #endregion

            #region B2091_00_SELECT_EFPREMIO_DB_SELECT_1_Query1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "WS_EF_VLR_EMISSAO" , ""},
                { "WS_EF_VLR_CREDITO" , ""},
                { "WS_EF_IOF_EMISSAO" , ""},
                { "WS_EF_IOF_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2091_00_SELECT_EFPREMIO_DB_SELECT_1_Query1", q45);

            #endregion

            #region B2091_20_SEL_EFPRM_POR_COB_DB_SELECT_1_Query1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "WS_EF_VLR_EMISSAO" , ""},
                { "WS_EF_VLR_CREDITO" , ""},
                { "WS_EF_IOF_EMISSAO" , ""},
                { "WS_EF_IOF_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2091_20_SEL_EFPRM_POR_COB_DB_SELECT_1_Query1", q46);

            #endregion

            #region B2091_31_SEL_EFPRM_POR_COB_DFI_DB_SELECT_1_Query1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "WS_EF_VLR_EMISSAO_65" , ""},
                { "WS_EF_VLR_CREDITO_65" , ""},
                { "WS_EF_IOF_EMISSAO_65" , ""},
                { "WS_EF_IOF_CREDITO_65" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2091_31_SEL_EFPRM_POR_COB_DFI_DB_SELECT_1_Query1", q47);

            #endregion

            #region B2091_32_SEL_EFPRM_POR_COB_RD_DB_SELECT_1_Query1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "WS_EF_VLR_EMISSAO_14" , ""},
                { "WS_EF_VLR_CREDITO_14" , ""},
                { "WS_EF_IOF_EMISSAO_14" , ""},
                { "WS_EF_IOF_CREDITO_14" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2091_32_SEL_EFPRM_POR_COB_RD_DB_SELECT_1_Query1", q48);

            #endregion

            #region B2094_ALTERA_V0COBERAPOL_DB_UPDATE_1_Update1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "WS_VL_COB" , ""},
                { "ENDO_NUM_APOLICE" , ""},
                { "ENDO_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2094_ALTERA_V0COBERAPOL_DB_UPDATE_1_Update1", q49);

            #endregion

            #region B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_1_Update1

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "WS_APOLICOB_PCT_COB_61" , ""},
                { "ENDO_NUM_APOLICE" , ""},
                { "ENDO_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_1_Update1", q50);

            #endregion

            #region B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_2_Update1

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>{
                { "WS_APOLICOB_PCT_COB_65" , ""},
                { "WS_EF_VLR_EMISSAO_65" , ""},
                { "ENDO_NUM_APOLICE" , ""},
                { "ENDO_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_2_Update1", q51);

            #endregion

            #region B2096_ALTERA_V0COBERAPOL_EF_DB_UPDATE_1_Update1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "WS_APOLICOB_PCT_COB_14" , ""},
                { "WS_EF_VLR_EMISSAO_14" , ""},
                { "ENDO_NUM_APOLICE" , ""},
                { "ENDO_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2096_ALTERA_V0COBERAPOL_EF_DB_UPDATE_1_Update1", q52);

            #endregion

            #region B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_3_Update1

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
                { "WS_APOLICOB_PCT_COB_65" , ""},
                { "WS_EF_VLR_CREDITO_65" , ""},
                { "ENDO_NUM_APOLICE" , ""},
                { "ENDO_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_3_Update1", q53);

            #endregion

            #region B2096_ALTERA_V0COBERAPOL_EF_DB_UPDATE_2_Update1

            var q54 = new DynamicData();
            q54.AddDynamic(new Dictionary<string, string>{
                { "WS_APOLICOB_PCT_COB_14" , ""},
                { "WS_EF_VLR_CREDITO_14" , ""},
                { "ENDO_NUM_APOLICE" , ""},
                { "ENDO_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2096_ALTERA_V0COBERAPOL_EF_DB_UPDATE_2_Update1", q54);

            #endregion

            #region B2200_010_ALTERA_V0RCAP_DB_UPDATE_1_Update1

            var q55 = new DynamicData();
            q55.AddDynamic(new Dictionary<string, string>{
                { "HIST_NUM_APOLICE" , ""},
                { "HIST_NRPARCEL" , ""},
                { "HIST_NRENDOS" , ""},
                { "V0RCAP_NRRCAP" , ""},
                { "V0RCAP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2200_010_ALTERA_V0RCAP_DB_UPDATE_1_Update1", q55);

            #endregion

            #region B2200_040_ALTERA_V0RCAPCOMP_DB_UPDATE_1_Update1

            var q56 = new DynamicData();
            q56.AddDynamic(new Dictionary<string, string>{
                { "PCOM_NRRCAPCO" , ""},
                { "PCOM_OPERACAO" , ""},
                { "PCOM_HORAOPER" , ""},
                { "PCOM_DTMOVTO" , ""},
                { "PCOM_NRRCAP" , ""},
                { "PCOM_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2200_040_ALTERA_V0RCAPCOMP_DB_UPDATE_1_Update1", q56);

            #endregion

            #region B2200_050_INCLUI_V0RCAPCOMP_DB_INSERT_1_Insert1

            var q57 = new DynamicData();
            q57.AddDynamic(new Dictionary<string, string>{
                { "PCOM_AGEAVISO" , ""},
                { "PCOM_BCOAVISO" , ""},
                { "PCOM_DATARCAP" , ""},
                { "PCOM_DTCADAST" , ""},
                { "SIST_DTMOVABE" , ""},
                { "PCOM_FONTE" , ""},
                { "PCOM_HORAOPER" , ""},
                { "PCOM_NRAVISO" , ""},
                { "PCOM_NRRCAP" , ""},
                { "PCOM_NRRCAPCO" , ""},
                { "PCOM_OPERACAO" , ""},
                { "PCOM_SITCONTB" , ""},
                { "PCOM_SITUACAO" , ""},
                { "PCOM_VLRCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B2200_050_INCLUI_V0RCAPCOMP_DB_INSERT_1_Insert1", q57);

            #endregion

            #region B2500_LE_MOEDA_DB_SELECT_1_Query1

            var q58 = new DynamicData();
            q58.AddDynamic(new Dictionary<string, string>{
                { "MOED_VALOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B2500_LE_MOEDA_DB_SELECT_1_Query1", q58);

            #endregion

            #region B3000_GRAVA_HISTOPARC_DB_INSERT_1_Insert1

            var q59 = new DynamicData();
            q59.AddDynamic(new Dictionary<string, string>{
                { "HIST_NUM_APOLICE" , ""},
                { "HIST_NRENDOS" , ""},
                { "HIST_NRPARCEL" , ""},
                { "HIST_DACPARC" , ""},
                { "HIST_DTMOVTO" , ""},
                { "HIST_OPERACAO" , ""},
                { "HIST_HORAOPER" , ""},
                { "HIST_OCORHIST" , ""},
                { "HIST_PRM_TARIFARIO" , ""},
                { "HIST_VAL_DESCONTO" , ""},
                { "HIST_VLPRMLIQ" , ""},
                { "HIST_VLADIFRA" , ""},
                { "HIST_VLCUSEMI" , ""},
                { "HIST_VLIOCC" , ""},
                { "HIST_VLPRMTOT" , ""},
                { "HIST_VLPREMIO" , ""},
                { "HIST_DTVENCTO" , ""},
                { "HIST_BCOCOBR" , ""},
                { "HIST_AGECOBR" , ""},
                { "HIST_NRAVISO" , ""},
                { "HIST_NRENDOCA" , ""},
                { "HIST_SITCONTB" , ""},
                { "HIST_COD_USUARIO" , ""},
                { "HIST_RNUDOC" , ""},
                { "HIST_DTQITBCO" , ""},
                { "HIST_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B3000_GRAVA_HISTOPARC_DB_INSERT_1_Insert1", q59);

            #endregion

            #region B3005_PEGAR_ULTIMO_DIA_DB_SELECT_1_Query1

            var q60 = new DynamicData();
            q60.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DTH_ULT_DIA_MES" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B3005_PEGAR_ULTIMO_DIA_DB_SELECT_1_Query1", q60);

            #endregion

            #region B3100_SELECT_V1RCAPCOMP_DB_SELECT_1_Query1

            var q61 = new DynamicData();
            q61.AddDynamic(new Dictionary<string, string>{
                { "PCOM_FONTE" , ""},
                { "PCOM_NRRCAP" , ""},
                { "PCOM_BCOAVISO" , ""},
                { "PCOM_AGEAVISO" , ""},
                { "PCOM_NRAVISO" , ""},
                { "PCOM_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B3100_SELECT_V1RCAPCOMP_DB_SELECT_1_Query1", q61);

            #endregion

            #region B3150_SELECT_V1RCAPCOMP_DB_SELECT_1_Query1

            var q62 = new DynamicData();
            q62.AddDynamic(new Dictionary<string, string>{
                { "PCOM_FONTE" , ""},
                { "PCOM_NRRCAP" , ""},
                { "PCOM_BCOAVISO" , ""},
                { "PCOM_AGEAVISO" , ""},
                { "PCOM_NRAVISO" , ""},
                { "PCOM_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B3150_SELECT_V1RCAPCOMP_DB_SELECT_1_Query1", q62);

            #endregion

            #region B3160_ALTERA_V0PARCELA_DB_UPDATE_1_Update1

            var q63 = new DynamicData();
            q63.AddDynamic(new Dictionary<string, string>{
                { "PARC_NUM_APOLICE" , ""},
                { "PARC_NRPARCEL" , ""},
                { "PARC_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B3160_ALTERA_V0PARCELA_DB_UPDATE_1_Update1", q63);

            #endregion

            #region B3200_SELECT_V1AVISALDOS_DB_SELECT_1_Query1

            var q64 = new DynamicData();
            q64.AddDynamic(new Dictionary<string, string>{
                { "V1ASAL_SDOATU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B3200_SELECT_V1AVISALDOS_DB_SELECT_1_Query1", q64);

            #endregion

            #region B3300_ALTERA_V0AVISALDOS_DB_UPDATE_1_Update1

            var q65 = new DynamicData();
            q65.AddDynamic(new Dictionary<string, string>{
                { "V1ASAL_SDOATU" , ""},
                { "V1ASAL_BCOAVISO" , ""},
                { "V1ASAL_AGEAVISO" , ""},
                { "V1ASAL_NRAVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B3300_ALTERA_V0AVISALDOS_DB_UPDATE_1_Update1", q65);

            #endregion

            #region B4000_ATUALIZA_ENDOSSO_DB_UPDATE_1_Update1

            var q66 = new DynamicData();
            q66.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE" , ""},
                { "WSITUACAO" , ""},
                { "ENDO_NUM_APOLICE" , ""},
                { "ENDO_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B4000_ATUALIZA_ENDOSSO_DB_UPDATE_1_Update1", q66);

            #endregion

            #region B4055_00_VALIDA_TITULO_CAP_DB_SELECT_1_Query1

            var q67 = new DynamicData();
            q67.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_PARAM_DATE03" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B4055_00_VALIDA_TITULO_CAP_DB_SELECT_1_Query1", q67);

            #endregion

            #region B4101_SELECT_APOLICE_DB_SELECT_1_Query1

            var q68 = new DynamicData();
            q68.AddDynamic(new Dictionary<string, string>{
                { "V0EDIA_CODCORR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B4101_SELECT_APOLICE_DB_SELECT_1_Query1", q68);

            #endregion

            #region B4102_SELECT_ENDOSSO_DB_SELECT_1_Query1

            var q69 = new DynamicData();
            q69.AddDynamic(new Dictionary<string, string>{
                { "V0EDIA_CODCORR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B4102_SELECT_ENDOSSO_DB_SELECT_1_Query1", q69);

            #endregion

            #region B4200_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1

            var q70 = new DynamicData();
            q70.AddDynamic(new Dictionary<string, string>{
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
                { "V0EDIA_COD_EMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B4200_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1", q70);

            #endregion

            #region B4201_00_V1PRODUTO_DB_SELECT_1_Query1

            var q71 = new DynamicData();
            q71.AddDynamic(new Dictionary<string, string>{
                { "V1PROD_IDEIMPESPC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B4201_00_V1PRODUTO_DB_SELECT_1_Query1", q71);

            #endregion

            #region B4210_00_INCLUI_RELATORIO_DB_INSERT_1_Insert1

            var q72 = new DynamicData();
            q72.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_CODUSU" , ""},
                { "V0RELA_DATA_SOLICITACAO" , ""},
                { "V0RELA_IDSISTEM" , ""},
                { "V0RELA_CODRELAT" , ""},
                { "V0RELA_NRCOPIAS" , ""},
                { "V0RELA_QUANTIDADE" , ""},
                { "V0RELA_PERI_INICIAL" , ""},
                { "V0RELA_PERI_FINAL" , ""},
                { "V0RELA_DATA_REFERENCIA" , ""},
                { "V0RELA_MES_REFERENCIA" , ""},
                { "V0RELA_ANO_REFERENCIA" , ""},
                { "V0RELA_ORGAO" , ""},
                { "V0RELA_FONTE" , ""},
                { "V0RELA_CODPDT" , ""},
                { "V0RELA_RAMO" , ""},
                { "V0RELA_MODALIDA" , ""},
                { "V0RELA_CONGENER" , ""},
                { "V0RELA_NUM_APOLICE" , ""},
                { "V0RELA_NRENDOS" , ""},
                { "V0RELA_NRPARCEL" , ""},
                { "V0RELA_NRCERTIF" , ""},
                { "V0RELA_NRTIT" , ""},
                { "V0RELA_CODSUBES" , ""},
                { "V0RELA_OPERACAO" , ""},
                { "V0RELA_COD_PLANO" , ""},
                { "V0RELA_OCORHIST" , ""},
                { "V0RELA_APOLIDER" , ""},
                { "V0RELA_ENDOSLID" , ""},
                { "V0RELA_NUM_PARC_LIDER" , ""},
                { "V0RELA_NUM_SINISTRO" , ""},
                { "V0RELA_NUM_SINI_LIDER" , ""},
                { "V0RELA_NUM_ORDEM" , ""},
                { "V0RELA_CODUNIMO" , ""},
                { "V0RELA_CORRECAO" , ""},
                { "V0RELA_SITUACAO" , ""},
                { "V0RELA_PREVIA_DEFINITIVA" , ""},
                { "V0RELA_ANAL_RESUMO" , ""},
                { "V0RELA_COD_EMPRESA" , ""},
                { "V0RELA_PERI_RENOVACAO" , ""},
                { "V0RELA_PCT_AUMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B4210_00_INCLUI_RELATORIO_DB_INSERT_1_Insert1", q72);

            #endregion

            #region B4292_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1

            var q73 = new DynamicData();
            q73.AddDynamic(new Dictionary<string, string>{
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
                { "V0EDIA_COD_EMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B4292_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1", q73);

            #endregion

            #region B4295_00_UPDATE_DATAPROP_DB_UPDATE_1_Update1

            var q74 = new DynamicData();
            q74.AddDynamic(new Dictionary<string, string>{
                { "ENDO_DATPRO" , ""},
                { "ENDO_NUM_APOLICE" , ""},
                { "ENDO_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B4295_00_UPDATE_DATAPROP_DB_UPDATE_1_Update1", q74);

            #endregion

            #region R0320_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1

            var q75 = new DynamicData();
            q75.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_COD_CEDENTE" , ""},
                { "CEDENTE_OPERACAO_CONTA" , ""},
                { "CEDENTE_NUM_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0320_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1", q75);

            #endregion

            #region R1110_00_RECUPERA_AU080_DB_SELECT_1_Query1

            var q76 = new DynamicData();
            q76.AddDynamic(new Dictionary<string, string>{
                { "AU080_PCT_TOTAL_ENCARGO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_RECUPERA_AU080_DB_SELECT_1_Query1", q76);

            #endregion

            #region R1120_00_RECUPERA_AU077_DB_SELECT_1_Query1

            var q77 = new DynamicData();
            q77.AddDynamic(new Dictionary<string, string>{
                { "AU077_VLR_PREMIO_LIQUIDO" , ""},
                { "AU077_VLR_CUSTO" , ""},
                { "AU077_VLR_IOF" , ""},
                { "AU077_VLR_PREMIO_TOTAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1120_00_RECUPERA_AU077_DB_SELECT_1_Query1", q77);

            #endregion

            #region R2060_00_ALTERA_V0CEDENTE_DB_UPDATE_1_Update1

            var q78 = new DynamicData();
            q78.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , ""},
                { "CEDENTE_COD_CEDENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2060_00_ALTERA_V0CEDENTE_DB_UPDATE_1_Update1", q78);

            #endregion

            #region R3000_LE_CUSTO_APOLICE_DB_SELECT_1_Query1

            var q79 = new DynamicData();
            q79.AddDynamic(new Dictionary<string, string>{
                { "PARC_OTNCUSTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3000_LE_CUSTO_APOLICE_DB_SELECT_1_Query1", q79);

            #endregion

            #region R5000_00_LE_PCIOCC_DB_SELECT_1_Query1

            var q80 = new DynamicData();
            q80.AddDynamic(new Dictionary<string, string>{
                { "V1RAMO_PCIOF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_LE_PCIOCC_DB_SELECT_1_Query1", q80);

            #endregion

            #region R7100_00_INCLUI_PARC_COMPL_DB_INSERT_1_Insert1

            var q81 = new DynamicData();
            q81.AddDynamic(new Dictionary<string, string>{
                { "AU071_NUM_APOLICE" , ""},
                { "AU071_NUM_ENDOSSO" , ""},
                { "AU071_NUM_PARCELA" , ""},
                { "AU071_DTA_VENCTO" , ""},
                { "AU071_NUM_VENCTO" , ""},
                { "AU071_VLR_PREMIO_LIQUIDO" , ""},
                { "AU071_VLR_JUROS" , ""},
                { "AU071_VLR_ADIC_FRAC" , ""},
                { "AU071_VLR_MULTA" , ""},
                { "AU071_VLR_CUSTO" , ""},
                { "AU071_VLR_IOF" , ""},
                { "AU071_VLR_PREMIO_TOTAL" , ""},
                { "AU071_NUM_RECIBO_CONV" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7100_00_INCLUI_PARC_COMPL_DB_INSERT_1_Insert1", q81);

            #endregion

            #region R7210_00_APURA_QTD_DIAS_DB_SELECT_1_Query1

            var q82 = new DynamicData();
            q82.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTDIAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7210_00_APURA_QTD_DIAS_DB_SELECT_1_Query1", q82);

            #endregion

            #region R7220_00_CONSULTA_NN_DB_SELECT_1_Query1

            var q83 = new DynamicData();
            q83.AddDynamic(new Dictionary<string, string>{
                { "APOLIAUT_CANAL_PROPOSTA" , ""},
                { "APOLIAUT_NUM_PROPOSTA_CONV" , ""},
                { "APOLIAUT_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7220_00_CONSULTA_NN_DB_SELECT_1_Query1", q83);

            #endregion

            #region R7220_00_CONSULTA_NN_DB_UPDATE_1_Update1

            var q84 = new DynamicData();
            q84.AddDynamic(new Dictionary<string, string>{
                { "PARC_NRTIT" , ""},
                { "PARC_NUM_APOLICE" , ""},
                { "PARC_NRPARCEL" , ""},
                { "PARC_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7220_00_CONSULTA_NN_DB_UPDATE_1_Update1", q84);

            #endregion

            #region M_999_999_ROT_ERRO_DB_UPDATE_1_Update1

            var q85 = new DynamicData();
            q85.AddDynamic(new Dictionary<string, string>{
                { "ENDO_NUM_APOLICE" , ""},
                { "ENDO_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_999_999_ROT_ERRO_DB_UPDATE_1_Update1", q85);

            #endregion

            #endregion
        }

        [Fact]
        public static void EM0010B_Tests_Fact()
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

                #region R0320_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R0320_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1");
                var q75 = new DynamicData();
                q75.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_COD_CEDENTE" , "123"},
                { "CEDENTE_OPERACAO_CONTA" , "870"},
                { "CEDENTE_NUM_TITULO" , "123"},
            }); q75.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_COD_CEDENTE" , "123"},
                { "CEDENTE_OPERACAO_CONTA" , "870"},
                { "CEDENTE_NUM_TITULO" , "123"},
            });
                AppSettings.TestSet.DynamicData.Add("R0320_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1", q75);

                #endregion

                #region A4000_LE_APOLICE_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("A4000_LE_APOLICE_DB_SELECT_1_Query1");

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "APOL_COD_CLIENTE" , ""},
                { "APOL_NUM_APOLICE" , ""},
                { "APOL_MODALIDA" , ""},
                { "APOL_ORGAO" , ""},
                { "APOL_RAMO" , ""},
                { "APOL_TIPO_SEGURO" , ""},
                { "APOL_TIPO_APOLICE" , ""},
                { "APOL_TIPO_CALCULO" , ""},
                { "APOL_IND_ENDOS_MAN" , ""},
                { "APOL_PCDESCON" , ""},
                { "APOL_PCIOCC" , ""},
                { "APOL_TPCOSSEG" , ""},
                { "APOL_QTCOSSEG" , "2"},
                { "APOL_PCCOSSEG" , ""},
                { "APOL_TIPO_PESSOA" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("A4000_LE_APOLICE_DB_SELECT_1_Query1", q8);

                #endregion
                #region EM0010B_V0ENDOS
                AppSettings.TestSet.DynamicData.Remove("EM0010B_V0ENDOS");
                var q4 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("EM0010B_V0ENDOS", q4);

                #endregion
                #region B2500_LE_MOEDA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("B2500_LE_MOEDA_DB_SELECT_1_Query1");

                var q58 = new DynamicData();
                q58.AddDynamic(new Dictionary<string, string>{
                { "MOED_VALOR" , "2"}
            });
                AppSettings.TestSet.DynamicData.Add("B2500_LE_MOEDA_DB_SELECT_1_Query1", q58);

                #endregion

                #endregion
                var program = new EM0010B();
                program.Execute();

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                var envList = AppSettings.TestSet.DynamicData["B4210_00_INCLUI_RELATORIO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("V0RELA_CODUSU", out var valor) && valor == "EM0010B ");


                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void EM0010B_Tests_FactErro99()
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

                #region R0320_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R0320_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1");
                var q75 = new DynamicData();
                q75.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_COD_CEDENTE" , "123"},
                { "CEDENTE_OPERACAO_CONTA" , "870"},
                { "CEDENTE_NUM_TITULO" , "123"},
            }); q75.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_COD_CEDENTE" , "123"},
                { "CEDENTE_OPERACAO_CONTA" , "870"},
                { "CEDENTE_NUM_TITULO" , "123"},
            });
                AppSettings.TestSet.DynamicData.Add("R0320_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1", q75);

                #endregion

                #region A4000_LE_APOLICE_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("A4000_LE_APOLICE_DB_SELECT_1_Query1");

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "APOL_COD_CLIENTE" , ""},
                { "APOL_NUM_APOLICE" , ""},
                { "APOL_MODALIDA" , ""},
                { "APOL_ORGAO" , ""},
                { "APOL_RAMO" , ""},
                { "APOL_TIPO_SEGURO" , ""},
                { "APOL_TIPO_APOLICE" , ""},
                { "APOL_TIPO_CALCULO" , ""},
                { "APOL_IND_ENDOS_MAN" , ""},
                { "APOL_PCDESCON" , ""},
                { "APOL_PCIOCC" , ""},
                { "APOL_TPCOSSEG" , ""},
                { "APOL_QTCOSSEG" , "2"},
                { "APOL_PCCOSSEG" , ""},
                { "APOL_TIPO_PESSOA" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("A4000_LE_APOLICE_DB_SELECT_1_Query1", q8);

                #endregion
                #region EM0010B_V0ENDOS
                AppSettings.TestSet.DynamicData.Remove("EM0010B_V0ENDOS");

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "ENDO_NUM_APOLICE" , ""},
                { "ENDO_NRENDOS" , ""},
                { "ENDO_CODSUBES" , ""},
                { "ENDO_FONTE" , ""},
                { "ENDO_NRPROPOS" , ""},
                { "ENDO_ORGAO" , "10"},
                { "ENDO_RAMO" , "53"},
                { "ENDO_DATPRO" , ""},
                { "ENDO_DT_LIBERACAO" , ""},
                { "ENDO_DTEMIS" , ""},
                { "ENDO_DTINIVIG" , ""},
                { "ENDO_DTTERVIG" , ""},
                { "ENDO_PCENTRAD" , ""},
                { "ENDO_PCADICIO" , ""},
                { "ENDO_PCDESCON" , ""},
                { "ENDO_PRESTA1" , ""},
                { "ENDO_QTPARCEL" , "3"},
                { "ENDO_COD_MOEDA_PRM" , ""},
                { "ENDO_NRRCAP" , ""},
                { "ENDO_VLRCAP" , ""},
                { "ENDO_DATARCAP" , ""},
                { "ENDO_TIPO_ENDOSSO" , "1"},
                { "ENDO_BCORCAP" , ""},
                { "ENDO_AGERCAP" , ""},
                { "ENDO_BCOCOBR" , ""},
                { "ENDO_AGECOBR" , ""},
                { "ENDO_ISENTA_CUSTO" , ""},
                { "ENDO_TIPO_APOL" , ""},
                { "ENDO_QTITENS" , ""},
                { "ENDO_CORRECAO" , ""},
                { "ENDO_DTVENCTO" , ""},
                { "ENDO_NUMBIL" , ""},
                { "ENDO_CODPRODU" , "5302"},
                { "ENDO_PODPUBL" , ""},
                { "ENDO_TIPSEGU" , ""},
                { "ENDO_VLCUSEMI" , "0"},
                { "ENDO_COD_USUARIO" , ""},
                { "ENDO_CFPREFIX" , ""},
                { "ENDO_COD_EMPRESA" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("EM0010B_V0ENDOS", q4);

                #endregion
                #region B2500_LE_MOEDA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("B2500_LE_MOEDA_DB_SELECT_1_Query1");

                var q58 = new DynamicData();
                q58.AddDynamic(new Dictionary<string, string>{
                { "MOED_VALOR" , "2"}
            });
                AppSettings.TestSet.DynamicData.Add("B2500_LE_MOEDA_DB_SELECT_1_Query1", q58);

                #endregion

                #endregion
                var program = new EM0010B();
                program.Execute();

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                var envList = AppSettings.TestSet.DynamicData["B1000_GRAVA_V0ORDECOSCED_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("WORD_NRORDEM", out var valor) && valor == "000000100000001");

                envList = AppSettings.TestSet.DynamicData["B1060_ATU_NUMERO_COSCED_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("ENDO_ORGAO", out valor) && valor == "0010");

                envList = AppSettings.TestSet.DynamicData["B4200_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("V0EDIA_CODRELAT", out valor) && valor == "EM0103B1");

                envList = AppSettings.TestSet.DynamicData["M_999_999_ROT_ERRO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("ENDO_NRENDOS", out valor) && valor == "000000000");

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}