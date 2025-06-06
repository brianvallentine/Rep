using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.VA0139B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VA0139B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VA0139B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region VA0139B_CHISTCTBL

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_SITUACAO" , ""},
                { "V0HCTB_NUM_APOLICE" , ""},
                { "V0HCTB_CODSUBES" , ""},
                { "V0HCTB_FONTE" , ""},
                { "V0HCTB_PRMVG" , ""},
                { "V0HCTB_PRMAP" , ""},
                { "V0HCTB_CODOPER" , ""},
                { "V0HCTB_NRCERTIF" , ""},
                { "V0HCTB_NRPARCEL" , ""},
                { "V0HCTB_NRTIT" , ""},
                { "V0HCTB_OCORHIST" , ""},
                { "V0HCTB_DTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0139B_CHISTCTBL", q1);

            #endregion

            #region VA0139B_CPROPOVA

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0139B_CPROPOVA", q2);

            #endregion

            #region R0000_00_PRINCIPAL_DB_SELECT_2_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVACB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_2_Query1", q3);

            #endregion

            #region R0000_00_PRINCIPAL_DB_INSERT_1_Insert1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_INSERT_1_Insert1", q4);

            #endregion

            #region R0000_00_PRINCIPAL_DB_SELECT_3_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_3_Query1", q5);

            #endregion

            #region VA0139B_V1RCAPCOMP

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("VA0139B_V1RCAPCOMP", q6);

            #endregion

            #region R0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0CBPR_IMPMORNATU" , ""},
                { "V0CBPR_IMPMORACID" , ""},
                { "V0CBPR_IMPINVPERM" , ""},
                { "V0CBPR_IMPAMDS" , ""},
                { "V0CBPR_IMPDH" , ""},
                { "V0CBPR_IMPDIT" , ""},
                { "V0CBPR_PRMDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0PRVG_ESTR_COBR" , ""},
                { "V0PRVG_CODPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q8);

            #endregion

            #region R0930_00_SELECT_HCTBVA_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NRENDOS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0930_00_SELECT_HCTBVA_DB_SELECT_1_Query1", q9);

            #endregion

            #region R0940_00_SELECT_HCTBVA_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NRENDOS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0940_00_SELECT_HCTBVA_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_RAMO" , ""},
                { "V0APOL_CODPRODU" , ""},
                { "V0APOL_MODALIDA" , ""},
                { "V0APOL_ORGAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODSUBES" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q12);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0COND_IEA" , ""},
                { "V0COND_IPA" , ""},
                { "V0COND_IPD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q13);

            #endregion

            #region R1010_00_PROCESSA_ENDOSSO_DB_INSERT_1_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1010_00_PROCESSA_ENDOSSO_DB_INSERT_1_Insert1", q14);

            #endregion

            #region R1010_00_PROCESSA_ENDOSSO_DB_UPDATE_1_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , ""},
                { "V0ENDO_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1010_00_PROCESSA_ENDOSSO_DB_UPDATE_1_Update1", q15);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS_COB" , ""},
                { "V0ENDO_NRENDOS_RES" , ""},
                { "V0APOL_ORGAO" , ""},
                { "V0APOL_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1", q16);

            #endregion

            #region R1010_00_PROCESSA_ENDOSSO_DB_INSERT_2_Insert1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1010_00_PROCESSA_ENDOSSO_DB_INSERT_2_Insert1", q17);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS_COB" , ""},
                { "V0ENDO_NRENDOS_RES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1", q18);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V0ENDO_NRENDOS" , ""},
                { "V0HCTB_NRCERTIF" , ""},
                { "V0HCTB_NRPARCEL" , ""},
                { "V0HCTB_OCORHIST" , ""},
                { "V0HCTB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1", q19);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "VG080_COD_GRUPO_SUSEP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1", q20);

            #endregion

            #region R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRPROPOS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1", q21);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1", q22);

            #endregion

            #region R1102_00_SELECT_RCAP_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , ""},
                { "V0RCAP_NRRCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1102_00_SELECT_RCAP_DB_SELECT_1_Query1", q23);

            #endregion

            #region R1102_00_SELECT_RCAP_DB_SELECT_2_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , ""},
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
                { "V1RCAC_DATARCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1102_00_SELECT_RCAP_DB_SELECT_2_Query1", q24);

            #endregion

            #region R1102_00_SELECT_RCAP_DB_SELECT_3_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , ""},
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
                { "V1RCAC_DATARCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1102_00_SELECT_RCAP_DB_SELECT_3_Query1", q25);

            #endregion

            #region R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1", q26);

            #endregion

            #region R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "V0PRVF_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1", q27);

            #endregion

            #region R1109_00_CALCULA_RTO_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V0CBPR_IMPMORNATU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1109_00_CALCULA_RTO_DB_SELECT_1_Query1", q28);

            #endregion

            #region R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1", q29);

            #endregion

            #region R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , ""},
                { "V0RCAP_NRRCAP" , ""},
                { "V0RCAP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1", q30);

            #endregion

            #region R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , ""},
                { "V0RCAP_NRRCAP" , ""},
                { "V0RCAP_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1", q31);

            #endregion

            #region R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , ""},
                { "V0ENDO_NRENDOS" , ""},
                { "V0RCAP_NRRCAP" , ""},
                { "V0RCAP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1", q32);

            #endregion

            #region R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , ""},
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
                { "V1RCAC_DATARCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1", q33);

            #endregion

            #region VA0139B_CVGHISTCONT

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "VG082_NUM_CERTIFICADO" , ""},
                { "VG082_NUM_PARCELA" , ""},
                { "VG082_NUM_TITULO" , ""},
                { "VG082_OCORR_HISTORICO" , ""},
                { "VG082_COD_GRUPO_SUSEP" , ""},
                { "VG082_RAMO_EMISSOR" , ""},
                { "VG082_COD_MODALIDADE" , ""},
                { "VG082_COD_COBERTURA" , ""},
                { "VG082_VLR_PREMIO_RAMO" , ""},
                { "VG082_COD_USUARIO" , ""},
                { "VG082_DTH_ATUALIZACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0139B_CVGHISTCONT", q34);

            #endregion

            #region R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_NRRCAPCO" , ""},
                { "V1RCAC_OPERACAO" , ""},
                { "V1RCAC_HORAOPER" , ""},
                { "V1RCAC_DTMOVTO" , ""},
                { "V1RCAC_NRRCAP" , ""},
                { "V1RCAC_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1", q35);

            #endregion

            #region R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1", q36);

            #endregion

            #region R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_VLRCAP" , ""},
                { "V1RCAC_BCOAVISO" , ""},
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1", q37);

            #endregion

            #region VA0139B_V1APOLCOSCED

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "V1COSP_CONGENER" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VA0139B_V1APOLCOSCED", q38);

            #endregion

            #region R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V0SEGVG_DTINIVIG" , ""},
                { "V0SEGVG_DTRENOVA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1", q39);

            #endregion

            #region R1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V0SEGVG_DTINIVIG" , ""},
                { "V0SEGVG_DTRENOVA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1", q40);

            #endregion

            #region R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1", q41);

            #endregion

            #region R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "V0ORDC_NUM_APOL" , ""},
                { "V0ORDC_NRENDOS" , ""},
                { "V0ORDC_CODCOSS" , ""},
                { "V0ORDC_ORDEM_CED" , ""},
                { "V0ORDC_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1", q42);

            #endregion

            #region R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , ""},
                { "V1NCOS_CONGENER" , ""},
                { "V1NCOS_ORGAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1", q43);

            #endregion

            #region R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1", q44);

            #endregion

            #region R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q45);

            #endregion

            #region R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1", q46);

            #endregion

            #region R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1", q47);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VA0139B_o1")]
        public void VA0139B_Test_Cenario_1(string SVA0139B_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" },
                { "V1SIST_DTCURRENT" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region VA0139B_CHISTCTBL

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_SITUACAO" , "Active" },
                { "V0HCTB_NUM_APOLICE" , "123456" },
                { "V0HCTB_CODSUBES" , "001" },
                { "V0HCTB_FONTE" , "Internal" },
                { "V0HCTB_PRMVG" , "1000" },
                { "V0HCTB_PRMAP" , "500" },
                { "V0HCTB_CODOPER" , "OP123" },
                { "V0HCTB_NRCERTIF" , "CERT123" },
                { "V0HCTB_NRPARCEL" , "1" },
                { "V0HCTB_NRTIT" , "TIT100" },
                { "V0HCTB_OCORHIST" , "None" },
                { "V0HCTB_DTMOVTO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("VA0139B_CHISTCTBL");
                AppSettings.TestSet.DynamicData.Add("VA0139B_CHISTCTBL", q1);

                #endregion

                #region VA0139B_CPROPOVA

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_SITUACAO" , "Pending" },
                { "V0PROP_OCORHIST" , "None" },
            });
                AppSettings.TestSet.DynamicData.Remove("VA0139B_CPROPOVA");
                AppSettings.TestSet.DynamicData.Add("VA0139B_CPROPOVA", q2);

                #endregion

                #region R0000_00_PRINCIPAL_DB_SELECT_2_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVACB" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_2_Query1", q3);

                #endregion

                #region R0000_00_PRINCIPAL_DB_INSERT_1_Insert1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_CODUSU" , "USR100" },
                { "V0RELA_DATA_SOLICITACAO" , "2023-12-01" },
                { "V0RELA_IDSISTEM" , "SYS100" },
                { "V0RELA_CODRELAT" , "REL100" },
                { "V0RELA_NRCOPIAS" , "1" },
                { "V0RELA_QUANTIDADE" , "1" },
                { "V0RELA_PERI_INICIAL" , "2023-01-01" },
                { "V0RELA_PERI_FINAL" , "2023-12-31" },
                { "V0RELA_DATA_REFERENCIA" , "2023-12-01" },
                { "V0RELA_MES_REFERENCIA" , "12" },
                { "V0RELA_ANO_REFERENCIA" , "2023" },
                { "V0RELA_ORGAO" , "Org100" },
                { "V0RELA_FONTE" , "Source100" },
                { "V0RELA_CODPDT" , "PDT100" },
                { "V0RELA_RAMO" , "Ramo100" },
                { "V0RELA_MODALIDA" , "Mod100" },
                { "V0RELA_CONGENER" , "Gen100" },
                { "V0RELA_NUM_APOLICE" , "Apol100" },
                { "V0RELA_NRENDOS" , "1" },
                { "V0RELA_NRPARCEL" , "1" },
                { "V0RELA_NRCERTIF" , "Cert100" },
                { "V0RELA_NRTIT" , "Tit200" },
                { "V0RELA_CODSUBES" , "Sub200" },
                { "V0RELA_OPERACAO" , "Oper200" },
                { "V0RELA_COD_PLANO" , "Plan200" },
                { "V0RELA_OCORHIST" , "Hist200" },
                { "V0RELA_APOLIDER" , "Lid200" },
                { "V0RELA_ENDOSLID" , "End200" },
                { "V0RELA_NUM_PARC_LIDER" , "1" },
                { "V0RELA_NUM_SINISTRO" , "Sin200" },
                { "V0RELA_NUM_SINI_LIDER" , "SLid200" },
                { "V0RELA_NUM_ORDEM" , "1" },
                { "V0RELA_CODUNIMO" , "Uni200" },
                { "V0RELA_CORRECAO" , "Corr200" },
                { "V0RELA_SITUACAO" , "Sit200" },
                { "V0RELA_PREVIA_DEFINITIVA" , "Def200" },
                { "V0RELA_ANAL_RESUMO" , "Res200" },
                { "V0RELA_COD_EMPRESA" , "Emp200" },
                { "V0RELA_PERI_RENOVACAO" , "2024-01-01" },
                { "V0RELA_PCT_AUMENTO" , "10" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_INSERT_1_Insert1", q4);

                #endregion

                #region R0000_00_PRINCIPAL_DB_SELECT_3_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_3_Query1", q5);

                #endregion

                #region VA0139B_V1RCAPCOMP

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , "Fnt300" },
                { "V1RCAC_NRRCAP" , "Rcap300" },
                { "V1RCAC_NRRCAPCO" , "Rco300" },
                { "V1RCAC_OPERACAO" , "Op300" },
                { "V1RCAC_DTMOVTO" , "2023-12-01" },
                { "V1RCAC_HORAOPER" , "12:00" },
                { "V1RCAC_SITUACAO" , "Active" },
                { "V1RCAC_BCOAVISO" , "Bco300" },
                { "V1RCAC_AGEAVISO" , "Age300" },
                { "V1RCAC_NRAVISO" , "Aviso300" },
                { "V1RCAC_VLRCAP" , "1000" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
                { "V1RCAC_DTCADAST" , "2023-12-01" },
                { "V1RCAC_SITCONTB" , "Good" },
            });
                AppSettings.TestSet.DynamicData.Remove("VA0139B_V1RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("VA0139B_V1RCAPCOMP", q6);

                #endregion

                #region R0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0CBPR_IMPMORNATU" , "0" },
                { "V0CBPR_IMPMORACID" , "0" },
                { "V0CBPR_IMPINVPERM" , "0" },
                { "V0CBPR_IMPAMDS" , "0" },
                { "V0CBPR_IMPDH" , "0" },
                { "V0CBPR_IMPDIT" , "0" },
                { "V0CBPR_PRMDIT" , "0" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q7);

                #endregion

                #region R0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V0PRVG_ESTR_COBR" , "Cobr400" },
                { "V0PRVG_CODPRODU" , "Prod400" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q8);

                #endregion

                #region R0930_00_SELECT_HCTBVA_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NRENDOS" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0930_00_SELECT_HCTBVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0930_00_SELECT_HCTBVA_DB_SELECT_1_Query1", q9);

                #endregion

                #region R0940_00_SELECT_HCTBVA_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NRENDOS" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0940_00_SELECT_HCTBVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0940_00_SELECT_HCTBVA_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_RAMO" , "Ramo400" },
                { "V0APOL_CODPRODU" , "Prod500" },
                { "V0APOL_MODALIDA" , "Mod500" },
                { "V0APOL_ORGAO" , "Org500" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q11);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODSUBES" , "Sub500" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q12);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V0COND_IEA" , "0" },
                { "V0COND_IPA" , "0" },
                { "V0COND_IPD" , "0" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q13);

                #endregion

                #region R1010_00_PROCESSA_ENDOSSO_DB_INSERT_1_Insert1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , "Apol600" },
                { "V0ENDO_NRENDOS" , "1" },
                { "V0ENDO_CODSUBES" , "Sub600" },
                { "V0ENDO_FONTE" , "Fnt600" },
                { "V0ENDO_NRPROPOS" , "Prop600" },
                { "V0ENDO_DATPRO" , "2023-12-01" },
                { "V0ENDO_DT_LIBER" , "2023-12-01" },
                { "V0ENDO_DTEMIS" , "2023-12-01" },
                { "V0ENDO_NRRCAP" , "Rcap600" },
                { "V0ENDO_VLRCAP" , "1000" },
                { "V0ENDO_BCORCAP" , "Bco600" },
                { "V0ENDO_AGERCAP" , "Age600" },
                { "V0ENDO_DACRCAP" , "Dac600" },
                { "V0ENDO_IDRCAP" , "Id600" },
                { "V0ENDO_BCOCOBR" , "Bco700" },
                { "V0ENDO_AGECOBR" , "Age700" },
                { "V0ENDO_DACCOBR" , "Dac700" },
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
                { "V0ENDO_DTTERVIG" , "2024-12-01" },
                { "V0ENDO_CDFRACIO" , "Frac700" },
                { "V0ENDO_PCENTRAD" , "10" },
                { "V0ENDO_PCADICIO" , "5" },
                { "V0ENDO_PRESTA1" , "100" },
                { "V0ENDO_QTPARCEL" , "1" },
                { "V0ENDO_QTPRESTA" , "1" },
                { "V0ENDO_QTITENS" , "1" },
                { "V0ENDO_CODTXT" , "Txt700" },
                { "V0ENDO_CDACEITA" , "Ace700" },
                { "V0ENDO_MOEDA_IMP" , "USD" },
                { "V0ENDO_MOEDA_PRM" , "EUR" },
                { "V0ENDO_TIPO_ENDO" , "Type700" },
                { "V0ENDO_COD_USUAR" , "User700" },
                { "V0ENDO_OCORR_END" , "Occur700" },
                { "V0ENDO_SITUACAO" , "Active" },
                { "V0ENDO_DATARCAP" , "2023-12-01" },
                { "V0ENDO_COD_EMPRESA" , "Emp700" },
                { "V0ENDO_CORRECAO" , "Corr700" },
                { "V0ENDO_ISENTA_CST" , "No" },
                { "V0ENDO_DTVENCTO" , "2024-01-01" },
                { "V0ENDO_CFPREFIX" , "CF700" },
                { "V0ENDO_VLCUSEMI" , "500" },
                { "V0ENDO_RAMO" , "Ramo800" },
                { "V0ENDO_CODPRODU" , "Prod800" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1010_00_PROCESSA_ENDOSSO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1010_00_PROCESSA_ENDOSSO_DB_INSERT_1_Insert1", q14);

                #endregion

                #region R1010_00_PROCESSA_ENDOSSO_DB_UPDATE_1_Update1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , "Auto800" },
                { "V0ENDO_FONTE" , "Fnt600" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1010_00_PROCESSA_ENDOSSO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1010_00_PROCESSA_ENDOSSO_DB_UPDATE_1_Update1", q15);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS_COB" , "1" },
                { "V0ENDO_NRENDOS_RES" , "1" },
                { "V0APOL_ORGAO" , "Org500" },
                { "V0APOL_RAMO" , "Ramo400" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1", q16);

                #endregion

                #region R1010_00_PROCESSA_ENDOSSO_DB_INSERT_2_Insert1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NUM_APOL" , "Apol900" },
                { "V0PARC_NRENDOS" , "1" },
                { "V0PARC_NRPARCEL" , "1" },
                { "V0PARC_DACPARC" , "2023-12-01" },
                { "V0PARC_FONTE" , "Fnt900" },
                { "V0PARC_NRTIT" , "Tit900" },
                { "V0PARC_PRM_TAR_IX" , "100" },
                { "V0PARC_VAL_DES_IX" , "10" },
                { "V0PARC_OTNPRLIQ" , "90" },
                { "V0PARC_OTNADFRA" , "5" },
                { "V0PARC_OTNCUSTO" , "15" },
                { "V0PARC_OTNIOF" , "2" },
                { "V0PARC_OTNTOTAL" , "112" },
                { "V0PARC_OCORHIST" , "Hist900" },
                { "V0PARC_QTDDOC" , "1" },
                { "V0PARC_SITUACAO" , "Active" },
                { "V0PARC_COD_EMPRESA" , "Emp900" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1010_00_PROCESSA_ENDOSSO_DB_INSERT_2_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1010_00_PROCESSA_ENDOSSO_DB_INSERT_2_Insert1", q17);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS_COB" , "1" },
                { "V0ENDO_NRENDOS_RES" , "1" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1", q18);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" },
                { "V0ENDO_NRENDOS" , "1" },
                { "V0HCTB_NRCERTIF" , "CERT123" },
                { "V0HCTB_NRPARCEL" , "1" },
                { "V0HCTB_OCORHIST" , "None" },
                { "V0HCTB_NRTIT" , "TIT100" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1", q19);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "VG080_COD_GRUPO_SUSEP" , "Susep900" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1", q20);

                #endregion

                #region R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRPROPOS" , "Prop600" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1", q21);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , "Auto800" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1", q22);

                #endregion

                #region R1102_00_SELECT_RCAP_DB_SELECT_1_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "Fnt1000" },
                { "V0RCAP_NRRCAP" , "Rcap1000" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1102_00_SELECT_RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1102_00_SELECT_RCAP_DB_SELECT_1_Query1", q23);

                #endregion

                #region R1102_00_SELECT_RCAP_DB_SELECT_2_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "Bco300" },
                { "V1RCAC_AGEAVISO" , "Age300" },
                { "V1RCAC_NRAVISO" , "Aviso300" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1102_00_SELECT_RCAP_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1102_00_SELECT_RCAP_DB_SELECT_2_Query1", q24);

                #endregion

                #region R1102_00_SELECT_RCAP_DB_SELECT_3_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "Bco300" },
                { "V1RCAC_AGEAVISO" , "Age300" },
                { "V1RCAC_NRAVISO" , "Aviso300" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1102_00_SELECT_RCAP_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1102_00_SELECT_RCAP_DB_SELECT_3_Query1", q25);

                #endregion

                #region R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , "0.1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1", q26);

                #endregion

                #region R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "V0PRVF_NRTIT" , "Tit1000" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1", q27);

                #endregion

                #region R1109_00_CALCULA_RTO_DB_SELECT_1_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "V0CBPR_IMPMORNATU" , "0" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1109_00_CALCULA_RTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1109_00_CALCULA_RTO_DB_SELECT_1_Query1", q28);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , "Sicob1000" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1", q29);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , "1" },
                { "V0RCAP_NRRCAP" , "Rcap1000" },
                { "V0RCAP_FONTE" , "Fnt1000" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1", q30);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "Fnt1000" },
                { "V0RCAP_NRRCAP" , "Rcap1000" },
                { "V0RCAP_SITUACAO" , "Active" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1", q31);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , "Apol600" },
                { "V0ENDO_NRENDOS" , "1" },
                { "V0RCAP_NRRCAP" , "Rcap1000" },
                { "V0RCAP_FONTE" , "Fnt1000" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1", q32);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "Bco300" },
                { "V1RCAC_AGEAVISO" , "Age300" },
                { "V1RCAC_NRAVISO" , "Aviso300" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1", q33);

                #endregion

                #region VA0139B_CVGHISTCONT

                var q34 = new DynamicData();
                q34.AddDynamic(new Dictionary<string, string>{
                { "VG082_NUM_CERTIFICADO" , "Cert1000" },
                { "VG082_NUM_PARCELA" , "1" },
                { "VG082_NUM_TITULO" , "Title1000" },
                { "VG082_OCORR_HISTORICO" , "Hist1000" },
                { "VG082_COD_GRUPO_SUSEP" , "Susep1000" },
                { "VG082_RAMO_EMISSOR" , "Ramo1000" },
                { "VG082_COD_MODALIDADE" , "Mod1000" },
                { "VG082_COD_COBERTURA" , "Cob1000" },
                { "VG082_VLR_PREMIO_RAMO" , "1000" },
                { "VG082_COD_USUARIO" , "User1000" },
                { "VG082_DTH_ATUALIZACAO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("VA0139B_CVGHISTCONT");
                AppSettings.TestSet.DynamicData.Add("VA0139B_CVGHISTCONT", q34);

                #endregion

                #region R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1

                var q35 = new DynamicData();
                q35.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_NRRCAPCO" , "Rco300" },
                { "V1RCAC_OPERACAO" , "Op300" },
                { "V1RCAC_HORAOPER" , "12:00" },
                { "V1RCAC_DTMOVTO" , "2023-12-01" },
                { "V1RCAC_NRRCAP" , "Rcap300" },
                { "V1RCAC_FONTE" , "Fnt300" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1", q35);

                #endregion

                #region R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1

                var q36 = new DynamicData();
                q36.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , "Fnt300" },
                { "V1RCAC_NRRCAP" , "Rcap300" },
                { "V1RCAC_NRRCAPCO" , "Rco300" },
                { "V1RCAC_OPERACAO" , "Op300" },
                { "V1SIST_DTMOVACB" , "2023-12-01" },
                { "V1RCAC_SITUACAO" , "Active" },
                { "V1RCAC_BCOAVISO" , "Bco300" },
                { "V1RCAC_AGEAVISO" , "Age300" },
                { "V1RCAC_NRAVISO" , "Aviso300" },
                { "V1RCAC_VLRCAP" , "1000" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
                { "V1RCAC_DTCADAST" , "2023-12-01" },
                { "V1RCAC_SITCONTB" , "Good" },
                { "V1RCAC_COD_EMPRESA" , "Emp1000" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1", q36);

                #endregion

                #region R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1

                var q37 = new DynamicData();
                q37.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_VLRCAP" , "1000" },
                { "V1RCAC_BCOAVISO" , "Bco300" },
                { "V1RCAC_AGEAVISO" , "Age300" },
                { "V1RCAC_NRAVISO" , "Aviso300" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1", q37);

                #endregion

                #region VA0139B_V1APOLCOSCED

                var q38 = new DynamicData();
                q38.AddDynamic(new Dictionary<string, string>{
                { "V1COSP_CONGENER" , "Gen1000" }
            });
                AppSettings.TestSet.DynamicData.Remove("VA0139B_V1APOLCOSCED");
                AppSettings.TestSet.DynamicData.Add("VA0139B_V1APOLCOSCED", q38);

                #endregion

                #region R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1

                var q39 = new DynamicData();
                q39.AddDynamic(new Dictionary<string, string>{
                { "V0SEGVG_DTINIVIG" , "2023-12-01" },
                { "V0SEGVG_DTRENOVA" , "2024-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1", q39);

                #endregion

                #region R1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1

                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                { "V0SEGVG_DTINIVIG" , "2023-12-01" },
                { "V0SEGVG_DTRENOVA" , "2024-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1", q40);

                #endregion

                #region R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1

                var q41 = new DynamicData();
                q41.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1", q41);

                #endregion

                #region R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1

                var q42 = new DynamicData();
                q42.AddDynamic(new Dictionary<string, string>{
                { "V0ORDC_NUM_APOL" , "Apol1100" },
                { "V0ORDC_NRENDOS" , "1" },
                { "V0ORDC_CODCOSS" , "Coss1100" },
                { "V0ORDC_ORDEM_CED" , "Ced1100" },
                { "V0ORDC_COD_EMPRESA" , "Emp1100" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1", q42);

                #endregion

                #region R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1

                var q43 = new DynamicData();
                q43.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , "1" },
                { "V1NCOS_CONGENER" , "Gen1100" },
                { "V1NCOS_ORGAO" , "Org1100" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1", q43);

                #endregion

                #region R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1

                var q44 = new DynamicData();
                q44.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "Cash" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1", q44);

                #endregion

                #region R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

                var q45 = new DynamicData();
                q45.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , "Apol1200" },
                { "V0HISP_NRENDOS" , "1" },
                { "V0HISP_NRPARCEL" , "1" },
                { "V0HISP_DACPARC" , "2023-12-01" },
                { "V0HISP_DTMOVTO" , "2023-12-01" },
                { "V0HISP_OPERACAO" , "Oper1200" },
                { "V0HISP_OCORHIST" , "Hist1200" },
                { "V0HISP_PRM_TARIFA" , "100" },
                { "V0HISP_VAL_DESCON" , "10" },
                { "V0HISP_VLPRMLIQ" , "90" },
                { "V0HISP_VLADIFRA" , "5" },
                { "V0HISP_VLCUSEMI" , "15" },
                { "V0HISP_VLIOCC" , "2" },
                { "V0HISP_VLPRMTOT" , "112" },
                { "V0HISP_VLPREMIO" , "100" },
                { "V0HISP_DTVENCTO" , "2024-01-01" },
                { "V0HISP_BCOCOBR" , "Bco1200" },
                { "V0HISP_AGECOBR" , "Age1200" },
                { "V0HISP_NRAVISO" , "Aviso1200" },
                { "V0HISP_NRENDOCA" , "Endo1200" },
                { "V0HISP_SITCONTB" , "Good" },
                { "V0HISP_COD_USUAR" , "User1200" },
                { "V0HISP_RNUDOC" , "Doc1200" },
                { "V0HISP_DTQITBCO" , "2023-12-01" },
                { "V0HISP_COD_EMPRESA" , "Emp1200" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q45);

                #endregion

                #region R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1

                var q46 = new DynamicData();
                q46.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_NUM_APOL" , "Apol1300" },
                { "V0COBA_NRENDOS" , "1" },
                { "V0COBA_NUM_ITEM" , "1" },
                { "V0COBA_OCORHIST" , "Hist1300" },
                { "V0COBA_RAMOFR" , "Ramo1300" },
                { "V0COBA_MODALIFR" , "Mod1300" },
                { "V0COBA_COD_COBER" , "Cob1300" },
                { "V0COBA_IMP_SEG_IX" , "1000" },
                { "V0COBA_PRM_TAR_IX" , "100" },
                { "V0COBA_IMP_SEG_VR" , "500" },
                { "V0COBA_PRM_TAR_VR" , "50" },
                { "V0COBA_PCT_COBERT" , "10" },
                { "V0COBA_FATOR_MULT" , "1.5" },
                { "V0COBA_DATA_INIVI" , "2023-12-01" },
                { "V0COBA_DATA_TERVI" , "2024-12-01" },
                { "V0COBA_COD_EMPRESA" , "Emp1300" },
                { "V0COBA_SITUACAO" , "Active" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1", q46);

                #endregion

                #region R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1

                var q47 = new DynamicData();
                q47.AddDynamic(new Dictionary<string, string>{
                { "V0EDIA_CODRELAT" , "Rel1400" },
                { "V0EDIA_NUM_APOL" , "Apol1400" },
                { "V0EDIA_NRENDOS" , "1" },
                { "V0EDIA_NRPARCEL" , "1" },
                { "V0EDIA_DTMOVTO" , "2023-12-01" },
                { "V0EDIA_ORGAO" , "Org1400" },
                { "V0EDIA_RAMO" , "Ramo1400" },
                { "V0EDIA_FONTE" , "Fnt1400" },
                { "V0EDIA_CONGENER" , "Gen1400" },
                { "V0EDIA_CODCORR" , "Corr1400" },
                { "V0EDIA_SITUACAO" , "Active" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1", q47);

                #endregion
                #endregion
                #endregion

                var program = new VA0139B();
                program.Execute(SVA0139B_FILE_NAME_P);

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);

            }
        }

        [Theory]
        [InlineData("VA0139B_o2")]
        public void VA0139B_Test_Cenario_2(string SVA0139B_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" },
                { "V1SIST_DTCURRENT" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region VA0139B_CHISTCTBL

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_SITUACAO" , "Active" },
                { "V0HCTB_NUM_APOLICE" , "123456" },
                { "V0HCTB_CODSUBES" , "001" },
                { "V0HCTB_FONTE" , "Internal" },
                { "V0HCTB_PRMVG" , "1000" },
                { "V0HCTB_PRMAP" , "500" },
                { "V0HCTB_CODOPER" , "150" },
                { "V0HCTB_NRCERTIF" , "CERT123" },
                { "V0HCTB_NRPARCEL" , "12" },
                { "V0HCTB_NRTIT" , "TIT100" },
                { "V0HCTB_OCORHIST" , "None" },
                { "V0HCTB_DTMOVTO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("VA0139B_CHISTCTBL");
                AppSettings.TestSet.DynamicData.Add("VA0139B_CHISTCTBL", q1);

                #endregion

                #region VA0139B_CPROPOVA

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_SITUACAO" , "Valid" },
                { "V0PROP_OCORHIST" , "None" },
            });
                AppSettings.TestSet.DynamicData.Remove("VA0139B_CPROPOVA");
                AppSettings.TestSet.DynamicData.Add("VA0139B_CPROPOVA", q2);

                #endregion

                #region R0000_00_PRINCIPAL_DB_SELECT_2_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVACB" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_2_Query1", q3);

                #endregion

                #region R0000_00_PRINCIPAL_DB_INSERT_1_Insert1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_CODUSU" , "USR100" },
                { "V0RELA_DATA_SOLICITACAO" , "2023-12-01" },
                { "V0RELA_IDSISTEM" , "SYS01" },
                { "V0RELA_CODRELAT" , "RPT100" },
                { "V0RELA_NRCOPIAS" , "1" },
                { "V0RELA_QUANTIDADE" , "1" },
                { "V0RELA_PERI_INICIAL" , "2023-01-01" },
                { "V0RELA_PERI_FINAL" , "2023-12-31" },
                { "V0RELA_DATA_REFERENCIA" , "2023-12-01" },
                { "V0RELA_MES_REFERENCIA" , "12" },
                { "V0RELA_ANO_REFERENCIA" , "2023" },
                { "V0RELA_ORGAO" , "Agency" },
                { "V0RELA_FONTE" , "Internal" },
                { "V0RELA_CODPDT" , "PDT100" },
                { "V0RELA_RAMO" , "General" },
                { "V0RELA_MODALIDA" , "TypeA" },
                { "V0RELA_CONGENER" , "GenA" },
                { "V0RELA_NUM_APOLICE" , "123456" },
                { "V0RELA_NRENDOS" , "5" },
                { "V0RELA_NRPARCEL" , "12" },
                { "V0RELA_NRCERTIF" , "CERT123" },
                { "V0RELA_NRTIT" , "TIT100" },
                { "V0RELA_CODSUBES" , "001" },
                { "V0RELA_OPERACAO" , "OperationA" },
                { "V0RELA_COD_PLANO" , "PLN100" },
                { "V0RELA_OCORHIST" , "None" },
                { "V0RELA_APOLIDER" , "LeaderA" },
                { "V0RELA_ENDOSLID" , "EndoLeader" },
                { "V0RELA_NUM_PARC_LIDER" , "12" },
                { "V0RELA_NUM_SINISTRO" , "SIN100" },
                { "V0RELA_NUM_SINI_LIDER" , "SINL100" },
                { "V0RELA_NUM_ORDEM" , "ORD100" },
                { "V0RELA_CODUNIMO" , "UNI100" },
                { "V0RELA_CORRECAO" , "Correct" },
                { "V0RELA_SITUACAO" , "Active" },
                { "V0RELA_PREVIA_DEFINITIVA" , "Definitive" },
                { "V0RELA_ANAL_RESUMO" , "Summary" },
                { "V0RELA_COD_EMPRESA" , "CMP100" },
                { "V0RELA_PERI_RENOVACAO" , "2024-01-01" },
                { "V0RELA_PCT_AUMENTO" , "10" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_INSERT_1_Insert1", q4);

                #endregion

                #region R0000_00_PRINCIPAL_DB_SELECT_3_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_3_Query1", q5);

                #endregion

                #region VA0139B_V1RCAPCOMP

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , "Internal" },
                { "V1RCAC_NRRCAP" , "RCAP100" },
                { "V1RCAC_NRRCAPCO" , "RCAPCO100" },
                { "V1RCAC_OPERACAO" , "OperationA" },
                { "V1RCAC_DTMOVTO" , "2023-12-01" },
                { "V1RCAC_HORAOPER" , "12:00" },
                { "V1RCAC_SITUACAO" , "Active" },
                { "V1RCAC_BCOAVISO" , "BankA" },
                { "V1RCAC_AGEAVISO" , "BranchA" },
                { "V1RCAC_NRAVISO" , "AVISO100" },
                { "V1RCAC_VLRCAP" , "10000" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
                { "V1RCAC_DTCADAST" , "2023-12-01" },
                { "V1RCAC_SITCONTB" , "Balanced" },
            });
                AppSettings.TestSet.DynamicData.Remove("VA0139B_V1RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("VA0139B_V1RCAPCOMP", q6);

                #endregion

                #region R0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0CBPR_IMPMORNATU" , "100" },
                { "V0CBPR_IMPMORACID" , "200" },
                { "V0CBPR_IMPINVPERM" , "300" },
                { "V0CBPR_IMPAMDS" , "400" },
                { "V0CBPR_IMPDH" , "500" },
                { "V0CBPR_IMPDIT" , "600" },
                { "V0CBPR_PRMDIT" , "700" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q7);

                #endregion

                #region R0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V0PRVG_ESTR_COBR" , "StructureA" },
                { "V0PRVG_CODPRODU" , "PRD200" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q8);

                #endregion

                #region R0930_00_SELECT_HCTBVA_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NRENDOS" , "5" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0930_00_SELECT_HCTBVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0930_00_SELECT_HCTBVA_DB_SELECT_1_Query1", q9);

                #endregion

                #region R0940_00_SELECT_HCTBVA_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NRENDOS" , "5" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0940_00_SELECT_HCTBVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0940_00_SELECT_HCTBVA_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_RAMO" , "BranchA" },
                { "V0APOL_CODPRODU" , "PRD100" },
                { "V0APOL_MODALIDA" , "TypeA" },
                { "V0APOL_ORGAO" , "AgencyA" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q11);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODSUBES" , "002" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q12);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V0COND_IEA" , "0.1" },
                { "V0COND_IPA" , "0.2" },
                { "V0COND_IPD" , "0.3" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q13);

                #endregion

                #region R1010_00_PROCESSA_ENDOSSO_DB_INSERT_1_Insert1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , "123457" },
                { "V0ENDO_NRENDOS" , "6" },
                { "V0ENDO_CODSUBES" , "002" },
                { "V0ENDO_FONTE" , "External" },
                { "V0ENDO_NRPROPOS" , "PROP200" },
                { "V0ENDO_DATPRO" , "2023-12-01" },
                { "V0ENDO_DT_LIBER" , "2023-12-02" },
                { "V0ENDO_DTEMIS" , "2023-12-01" },
                { "V0ENDO_NRRCAP" , "RCAP200" },
                { "V0ENDO_VLRCAP" , "20000" },
                { "V0ENDO_BCORCAP" , "BankB" },
                { "V0ENDO_AGERCAP" , "BranchB" },
                { "V0ENDO_DACRCAP" , "2023-12-01" },
                { "V0ENDO_IDRCAP" , "IDCAP200" },
                { "V0ENDO_BCOCOBR" , "BankC" },
                { "V0ENDO_AGECOBR" , "BranchC" },
                { "V0ENDO_DACCOBR" , "2023-12-01" },
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
                { "V0ENDO_DTTERVIG" , "2024-12-01" },
                { "V0ENDO_CDFRACIO" , "Frac100" },
                { "V0ENDO_PCENTRAD" , "10" },
                { "V0ENDO_PCADICIO" , "5" },
                { "V0ENDO_PRESTA1" , "1000" },
                { "V0ENDO_QTPARCEL" , "12" },
                { "V0ENDO_QTPRESTA" , "24" },
                { "V0ENDO_QTITENS" , "10" },
                { "V0ENDO_CODTXT" , "TXT100" },
                { "V0ENDO_CDACEITA" , "Accept" },
                { "V0ENDO_MOEDA_IMP" , "USD" },
                { "V0ENDO_MOEDA_PRM" , "EUR" },
                { "V0ENDO_TIPO_ENDO" , "TypeB" },
                { "V0ENDO_COD_USUAR" , "USR200" },
                { "V0ENDO_OCORR_END" , "EventA" },
                { "V0ENDO_SITUACAO" , "Pending" },
                { "V0ENDO_DATARCAP" , "2023-12-01" },
                { "V0ENDO_COD_EMPRESA" , "CMP200" },
                { "V0ENDO_CORRECAO" , "Correction" },
                { "V0ENDO_ISENTA_CST" , "Exempt" },
                { "V0ENDO_DTVENCTO" , "2024-01-01" },
                { "V0ENDO_CFPREFIX" , "CF100" },
                { "V0ENDO_VLCUSEMI" , "500" },
                { "V0ENDO_RAMO" , "BranchB" },
                { "V0ENDO_CODPRODU" , "PRD200" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1010_00_PROCESSA_ENDOSSO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1010_00_PROCESSA_ENDOSSO_DB_INSERT_1_Insert1", q14);

                #endregion

                #region R1010_00_PROCESSA_ENDOSSO_DB_UPDATE_1_Update1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , "Auto" },
                { "V0ENDO_FONTE" , "External" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1010_00_PROCESSA_ENDOSSO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1010_00_PROCESSA_ENDOSSO_DB_UPDATE_1_Update1", q15);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS_COB" , "7" },
                { "V0ENDO_NRENDOS_RES" , "8" },
                { "V0APOL_ORGAO" , "AgencyA" },
                { "V0APOL_RAMO" , "BranchA" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1", q16);

                #endregion

                #region R1010_00_PROCESSA_ENDOSSO_DB_INSERT_2_Insert1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NUM_APOL" , "123458" },
                { "V0PARC_NRENDOS" , "9" },
                { "V0PARC_NRPARCEL" , "13" },
                { "V0PARC_DACPARC" , "2023-12-01" },
                { "V0PARC_FONTE" , "SourceA" },
                { "V0PARC_NRTIT" , "TIT200" },
                { "V0PARC_PRM_TAR_IX" , "800" },
                { "V0PARC_VAL_DES_IX" , "50" },
                { "V0PARC_OTNPRLIQ" , "750" },
                { "V0PARC_OTNADFRA" , "25" },
                { "V0PARC_OTNCUSTO" , "100" },
                { "V0PARC_OTNIOF" , "5" },
                { "V0PARC_OTNTOTAL" , "880" },
                { "V0PARC_OCORHIST" , "None" },
                { "V0PARC_QTDDOC" , "2" },
                { "V0PARC_SITUACAO" , "Active" },
                { "V0PARC_COD_EMPRESA" , "CMP300" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1010_00_PROCESSA_ENDOSSO_DB_INSERT_2_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1010_00_PROCESSA_ENDOSSO_DB_INSERT_2_Insert1", q17);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS_COB" , "7" },
                { "V0ENDO_NRENDOS_RES" , "8" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1", q18);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" },
                { "V0ENDO_NRENDOS" , "6" },
                { "V0HCTB_NRCERTIF" , "CERT123" },
                { "V0HCTB_NRPARCEL" , "12" },
                { "V0HCTB_OCORHIST" , "None" },
                { "V0HCTB_NRTIT" , "TIT100" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1", q19);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "VG080_COD_GRUPO_SUSEP" , "SUSEP100" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1", q20);

                #endregion

                #region R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRPROPOS" , "PROP200" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1", q21);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , "Auto" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1", q22);

                #endregion

                #region R1102_00_SELECT_RCAP_DB_SELECT_1_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "Internal" },
                { "V0RCAP_NRRCAP" , "RCAP300" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1102_00_SELECT_RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1102_00_SELECT_RCAP_DB_SELECT_1_Query1", q23);

                #endregion

                #region R1102_00_SELECT_RCAP_DB_SELECT_2_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "BankA" },
                { "V1RCAC_AGEAVISO" , "BranchA" },
                { "V1RCAC_NRAVISO" , "AVISO100" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1102_00_SELECT_RCAP_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1102_00_SELECT_RCAP_DB_SELECT_2_Query1", q24);

                #endregion

                #region R1102_00_SELECT_RCAP_DB_SELECT_3_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "BankA" },
                { "V1RCAC_AGEAVISO" , "BranchA" },
                { "V1RCAC_NRAVISO" , "AVISO100" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1102_00_SELECT_RCAP_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1102_00_SELECT_RCAP_DB_SELECT_3_Query1", q25);

                #endregion

                #region R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , "0.05" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1", q26);

                #endregion

                #region R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "V0PRVF_NRTIT" , "TIT300" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1", q27);

                #endregion

                #region R1109_00_CALCULA_RTO_DB_SELECT_1_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "V0CBPR_IMPMORNATU" , "100" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1109_00_CALCULA_RTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1109_00_CALCULA_RTO_DB_SELECT_1_Query1", q28);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , "SICOB100" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1", q29);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , "6" },
                { "V0RCAP_NRRCAP" , "RCAP300" },
                { "V0RCAP_FONTE" , "Internal" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1", q30);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "Internal" },
                { "V0RCAP_NRRCAP" , "RCAP300" },
                { "V0RCAP_SITUACAO" , "Valid" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1", q31);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , "123457" },
                { "V0ENDO_NRENDOS" , "6" },
                { "V0RCAP_NRRCAP" , "RCAP300" },
                { "V0RCAP_FONTE" , "Internal" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1", q32);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "BankA" },
                { "V1RCAC_AGEAVISO" , "BranchA" },
                { "V1RCAC_NRAVISO" , "AVISO100" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1", q33);

                #endregion

                #region VA0139B_CVGHISTCONT

                var q34 = new DynamicData();
                q34.AddDynamic(new Dictionary<string, string>{
                { "VG082_NUM_CERTIFICADO" , "CERT200" },
                { "VG082_NUM_PARCELA" , "14" },
                { "VG082_NUM_TITULO" , "TIT400" },
                { "VG082_OCORR_HISTORICO" , "None" },
                { "VG082_COD_GRUPO_SUSEP" , "SUSEP200" },
                { "VG082_RAMO_EMISSOR" , "BranchC" },
                { "VG082_COD_MODALIDADE" , "MOD100" },
                { "VG082_COD_COBERTURA" , "COV100" },
                { "VG082_VLR_PREMIO_RAMO" , "1500" },
                { "VG082_COD_USUARIO" , "USR300" },
                { "VG082_DTH_ATUALIZACAO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("VA0139B_CVGHISTCONT");
                AppSettings.TestSet.DynamicData.Add("VA0139B_CVGHISTCONT", q34);

                #endregion

                #region R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1

                var q35 = new DynamicData();
                q35.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_NRRCAPCO" , "RCAPCO100" },
                { "V1RCAC_OPERACAO" , "OperationA" },
                { "V1RCAC_HORAOPER" , "12:00" },
                { "V1RCAC_DTMOVTO" , "2023-12-01" },
                { "V1RCAC_NRRCAP" , "RCAP100" },
                { "V1RCAC_FONTE" , "Internal" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1", q35);

                #endregion

                #region R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1

                var q36 = new DynamicData();
                q36.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , "Internal" },
                { "V1RCAC_NRRCAP" , "RCAP100" },
                { "V1RCAC_NRRCAPCO" , "RCAPCO100" },
                { "V1RCAC_OPERACAO" , "OperationA" },
                { "V1SIST_DTMOVACB" , "2023-12-01" },
                { "V1RCAC_SITUACAO" , "Active" },
                { "V1RCAC_BCOAVISO" , "BankA" },
                { "V1RCAC_AGEAVISO" , "BranchA" },
                { "V1RCAC_NRAVISO" , "AVISO100" },
                { "V1RCAC_VLRCAP" , "10000" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
                { "V1RCAC_DTCADAST" , "2023-12-01" },
                { "V1RCAC_SITCONTB" , "Balanced" },
                { "V1RCAC_COD_EMPRESA" , "CMP400" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1", q36);

                #endregion

                #region R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1

                var q37 = new DynamicData();
                q37.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_VLRCAP" , "10000" },
                { "V1RCAC_BCOAVISO" , "BankA" },
                { "V1RCAC_AGEAVISO" , "BranchA" },
                { "V1RCAC_NRAVISO" , "AVISO100" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1", q37);

                #endregion

                #region VA0139B_V1APOLCOSCED

                var q38 = new DynamicData();
                q38.AddDynamic(new Dictionary<string, string>{
                { "V1COSP_CONGENER" , "GenB" }
            });
                AppSettings.TestSet.DynamicData.Remove("VA0139B_V1APOLCOSCED");
                AppSettings.TestSet.DynamicData.Add("VA0139B_V1APOLCOSCED", q38);

                #endregion

                #region R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1

                var q39 = new DynamicData();
                q39.AddDynamic(new Dictionary<string, string>{
                { "V0SEGVG_DTINIVIG" , "2023-12-01" },
                { "V0SEGVG_DTRENOVA" , "2024-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1", q39);

                #endregion

                #region R1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1

                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                { "V0SEGVG_DTINIVIG" , "2023-12-01" },
                { "V0SEGVG_DTRENOVA" , "2024-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1", q40);

                #endregion

                #region R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1

                var q41 = new DynamicData();
                q41.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , "ORD200" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1", q41);

                #endregion

                #region R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1

                var q42 = new DynamicData();
                q42.AddDynamic(new Dictionary<string, string>{
                { "V0ORDC_NUM_APOL" , "123459" },
                { "V0ORDC_NRENDOS" , "10" },
                { "V0ORDC_CODCOSS" , "COSS100" },
                { "V0ORDC_ORDEM_CED" , "OrderA" },
                { "V0ORDC_COD_EMPRESA" , "CMP500" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1", q42);

                #endregion

                #region R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1

                var q43 = new DynamicData();
                q43.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , "ORD200" },
                { "V1NCOS_CONGENER" , "GenC" },
                { "V1NCOS_ORGAO" , "AgencyB" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1", q43);

                #endregion

                #region R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1

                var q44 = new DynamicData();
                q44.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "OptionA" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1", q44);

                #endregion

                #region R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

                var q45 = new DynamicData();
                q45.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , "123460" },
                { "V0HISP_NRENDOS" , "11" },
                { "V0HISP_NRPARCEL" , "15" },
                { "V0HISP_DACPARC" , "2023-12-01" },
                { "V0HISP_DTMOVTO" , "2023-12-01" },
                { "V0HISP_OPERACAO" , "OperationB" },
                { "V0HISP_OCORHIST" , "None" },
                { "V0HISP_PRM_TARIFA" , "900" },
                { "V0HISP_VAL_DESCON" , "60" },
                { "V0HISP_VLPRMLIQ" , "840" },
                { "V0HISP_VLADIFRA" , "30" },
                { "V0HISP_VLCUSEMI" , "550" },
                { "V0HISP_VLIOCC" , "10" },
                { "V0HISP_VLPRMTOT" , "930" },
                { "V0HISP_VLPREMIO" , "920" },
                { "V0HISP_DTVENCTO" , "2024-02-01" },
                { "V0HISP_BCOCOBR" , "BankD" },
                { "V0HISP_AGECOBR" , "BranchD" },
                { "V0HISP_NRAVISO" , "AVISO200" },
                { "V0HISP_NRENDOCA" , "ENDO200" },
                { "V0HISP_SITCONTB" , "Unbalanced" },
                { "V0HISP_COD_USUAR" , "USR400" },
                { "V0HISP_RNUDOC" , "DOC200" },
                { "V0HISP_DTQITBCO" , "2023-12-02" },
                { "V0HISP_COD_EMPRESA" , "CMP600" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q45);

                #endregion

                #region R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1

                var q46 = new DynamicData();
                q46.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_NUM_APOL" , "123461" },
                { "V0COBA_NRENDOS" , "12" },
                { "V0COBA_NUM_ITEM" , "1" },
                { "V0COBA_OCORHIST" , "None" },
                { "V0COBA_RAMOFR" , "BranchD" },
                { "V0COBA_MODALIFR" , "TypeC" },
                { "V0COBA_COD_COBER" , "COV200" },
                { "V0COBA_IMP_SEG_IX" , "1100" },
                { "V0COBA_PRM_TAR_IX" , "1200" },
                { "V0COBA_IMP_SEG_VR" , "1300" },
                { "V0COBA_PRM_TAR_VR" , "1400" },
                { "V0COBA_PCT_COBERT" , "20" },
                { "V0COBA_FATOR_MULT" , "1.1" },
                { "V0COBA_DATA_INIVI" , "2023-12-01" },
                { "V0COBA_DATA_TERVI" , "2024-12-01" },
                { "V0COBA_COD_EMPRESA" , "CMP700" },
                { "V0COBA_SITUACAO" , "Active" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1", q46);

                #endregion

                #region R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1

                var q47 = new DynamicData();
                q47.AddDynamic(new Dictionary<string, string>{
                { "V0EDIA_CODRELAT" , "RPT200" },
                { "V0EDIA_NUM_APOL" , "123462" },
                { "V0EDIA_NRENDOS" , "13" },
                { "V0EDIA_NRPARCEL" , "16" },
                { "V0EDIA_DTMOVTO" , "2023-12-01" },
                { "V0EDIA_ORGAO" , "AgencyC" },
                { "V0EDIA_RAMO" , "BranchE" },
                { "V0EDIA_FONTE" , "SourceB" },
                { "V0EDIA_CONGENER" , "GenD" },
                { "V0EDIA_CODCORR" , "CORR100" },
                { "V0EDIA_SITUACAO" , "Valid" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1", q47);

                #endregion
                #endregion
                #endregion


                var program = new VA0139B();
                program.Execute(SVA0139B_FILE_NAME_P);

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);

            }
        }

        [Theory]
        [InlineData("VA0139B_o3")]
        public void VA0139B_Test_ReturnCode99(string SVA0139B_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" },
                { "V1SIST_DTCURRENT" , "2023-12-01" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region VA0139B_CHISTCTBL

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_SITUACAO" , "Active" },
                { "V0HCTB_NUM_APOLICE" , "123456" },
                { "V0HCTB_CODSUBES" , "001" },
                { "V0HCTB_FONTE" , "Internal" },
                { "V0HCTB_PRMVG" , "1000" },
                { "V0HCTB_PRMAP" , "500" },
                { "V0HCTB_CODOPER" , "150" },
                { "V0HCTB_NRCERTIF" , "CERT123" },
                { "V0HCTB_NRPARCEL" , "12" },
                { "V0HCTB_NRTIT" , "TIT100" },
                { "V0HCTB_OCORHIST" , "None" },
                { "V0HCTB_DTMOVTO" , "2023-12-01" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("VA0139B_CHISTCTBL");
                AppSettings.TestSet.DynamicData.Add("VA0139B_CHISTCTBL", q1);

                #endregion

                #region VA0139B_CPROPOVA

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_SITUACAO" , "Valid" },
                { "V0PROP_OCORHIST" , "None" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("VA0139B_CPROPOVA");
                AppSettings.TestSet.DynamicData.Add("VA0139B_CPROPOVA", q2);

                #endregion

                #region R0000_00_PRINCIPAL_DB_SELECT_2_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVACB" , "2023-12-01" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_2_Query1", q3);

                #endregion

                #region R0000_00_PRINCIPAL_DB_INSERT_1_Insert1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_CODUSU" , "USR100" },
                { "V0RELA_DATA_SOLICITACAO" , "2023-12-01" },
                { "V0RELA_IDSISTEM" , "SYS01" },
                { "V0RELA_CODRELAT" , "RPT100" },
                { "V0RELA_NRCOPIAS" , "1" },
                { "V0RELA_QUANTIDADE" , "1" },
                { "V0RELA_PERI_INICIAL" , "2023-01-01" },
                { "V0RELA_PERI_FINAL" , "2023-12-31" },
                { "V0RELA_DATA_REFERENCIA" , "2023-12-01" },
                { "V0RELA_MES_REFERENCIA" , "12" },
                { "V0RELA_ANO_REFERENCIA" , "2023" },
                { "V0RELA_ORGAO" , "Agency" },
                { "V0RELA_FONTE" , "Internal" },
                { "V0RELA_CODPDT" , "PDT100" },
                { "V0RELA_RAMO" , "General" },
                { "V0RELA_MODALIDA" , "TypeA" },
                { "V0RELA_CONGENER" , "GenA" },
                { "V0RELA_NUM_APOLICE" , "123456" },
                { "V0RELA_NRENDOS" , "5" },
                { "V0RELA_NRPARCEL" , "12" },
                { "V0RELA_NRCERTIF" , "CERT123" },
                { "V0RELA_NRTIT" , "TIT100" },
                { "V0RELA_CODSUBES" , "001" },
                { "V0RELA_OPERACAO" , "OperationA" },
                { "V0RELA_COD_PLANO" , "PLN100" },
                { "V0RELA_OCORHIST" , "None" },
                { "V0RELA_APOLIDER" , "LeaderA" },
                { "V0RELA_ENDOSLID" , "EndoLeader" },
                { "V0RELA_NUM_PARC_LIDER" , "12" },
                { "V0RELA_NUM_SINISTRO" , "SIN100" },
                { "V0RELA_NUM_SINI_LIDER" , "SINL100" },
                { "V0RELA_NUM_ORDEM" , "ORD100" },
                { "V0RELA_CODUNIMO" , "UNI100" },
                { "V0RELA_CORRECAO" , "Correct" },
                { "V0RELA_SITUACAO" , "Active" },
                { "V0RELA_PREVIA_DEFINITIVA" , "Definitive" },
                { "V0RELA_ANAL_RESUMO" , "Summary" },
                { "V0RELA_COD_EMPRESA" , "CMP100" },
                { "V0RELA_PERI_RENOVACAO" , "2024-01-01" },
                { "V0RELA_PCT_AUMENTO" , "10" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_INSERT_1_Insert1", q4);

                #endregion

                #region R0000_00_PRINCIPAL_DB_SELECT_3_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_3_Query1", q5);

                #endregion

                #region VA0139B_V1RCAPCOMP

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , "Internal" },
                { "V1RCAC_NRRCAP" , "RCAP100" },
                { "V1RCAC_NRRCAPCO" , "RCAPCO100" },
                { "V1RCAC_OPERACAO" , "OperationA" },
                { "V1RCAC_DTMOVTO" , "2023-12-01" },
                { "V1RCAC_HORAOPER" , "12:00" },
                { "V1RCAC_SITUACAO" , "Active" },
                { "V1RCAC_BCOAVISO" , "BankA" },
                { "V1RCAC_AGEAVISO" , "BranchA" },
                { "V1RCAC_NRAVISO" , "AVISO100" },
                { "V1RCAC_VLRCAP" , "10000" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
                { "V1RCAC_DTCADAST" , "2023-12-01" },
                { "V1RCAC_SITCONTB" , "Balanced" },
            });
                AppSettings.TestSet.DynamicData.Remove("VA0139B_V1RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("VA0139B_V1RCAPCOMP", q6);

                #endregion

                #region R0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0CBPR_IMPMORNATU" , "100" },
                { "V0CBPR_IMPMORACID" , "200" },
                { "V0CBPR_IMPINVPERM" , "300" },
                { "V0CBPR_IMPAMDS" , "400" },
                { "V0CBPR_IMPDH" , "500" },
                { "V0CBPR_IMPDIT" , "600" },
                { "V0CBPR_PRMDIT" , "700" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q7);

                #endregion

                #region R0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V0PRVG_ESTR_COBR" , "StructureA" },
                { "V0PRVG_CODPRODU" , "PRD200" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q8);

                #endregion

                #region R0930_00_SELECT_HCTBVA_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NRENDOS" , "5" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0930_00_SELECT_HCTBVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0930_00_SELECT_HCTBVA_DB_SELECT_1_Query1", q9);

                #endregion

                #region R0940_00_SELECT_HCTBVA_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NRENDOS" , "5" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0940_00_SELECT_HCTBVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0940_00_SELECT_HCTBVA_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_RAMO" , "BranchA" },
                { "V0APOL_CODPRODU" , "PRD100" },
                { "V0APOL_MODALIDA" , "TypeA" },
                { "V0APOL_ORGAO" , "AgencyA" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q11);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODSUBES" , "002" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q12);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V0COND_IEA" , "0.1" },
                { "V0COND_IPA" , "0.2" },
                { "V0COND_IPD" , "0.3" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q13);

                #endregion

                #region R1010_00_PROCESSA_ENDOSSO_DB_INSERT_1_Insert1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , "123457" },
                { "V0ENDO_NRENDOS" , "6" },
                { "V0ENDO_CODSUBES" , "002" },
                { "V0ENDO_FONTE" , "External" },
                { "V0ENDO_NRPROPOS" , "PROP200" },
                { "V0ENDO_DATPRO" , "2023-12-01" },
                { "V0ENDO_DT_LIBER" , "2023-12-02" },
                { "V0ENDO_DTEMIS" , "2023-12-01" },
                { "V0ENDO_NRRCAP" , "RCAP200" },
                { "V0ENDO_VLRCAP" , "20000" },
                { "V0ENDO_BCORCAP" , "BankB" },
                { "V0ENDO_AGERCAP" , "BranchB" },
                { "V0ENDO_DACRCAP" , "2023-12-01" },
                { "V0ENDO_IDRCAP" , "IDCAP200" },
                { "V0ENDO_BCOCOBR" , "BankC" },
                { "V0ENDO_AGECOBR" , "BranchC" },
                { "V0ENDO_DACCOBR" , "2023-12-01" },
                { "V0ENDO_DTINIVIG" , "2023-12-01" },
                { "V0ENDO_DTTERVIG" , "2024-12-01" },
                { "V0ENDO_CDFRACIO" , "Frac100" },
                { "V0ENDO_PCENTRAD" , "10" },
                { "V0ENDO_PCADICIO" , "5" },
                { "V0ENDO_PRESTA1" , "1000" },
                { "V0ENDO_QTPARCEL" , "12" },
                { "V0ENDO_QTPRESTA" , "24" },
                { "V0ENDO_QTITENS" , "10" },
                { "V0ENDO_CODTXT" , "TXT100" },
                { "V0ENDO_CDACEITA" , "Accept" },
                { "V0ENDO_MOEDA_IMP" , "USD" },
                { "V0ENDO_MOEDA_PRM" , "EUR" },
                { "V0ENDO_TIPO_ENDO" , "TypeB" },
                { "V0ENDO_COD_USUAR" , "USR200" },
                { "V0ENDO_OCORR_END" , "EventA" },
                { "V0ENDO_SITUACAO" , "Pending" },
                { "V0ENDO_DATARCAP" , "2023-12-01" },
                { "V0ENDO_COD_EMPRESA" , "CMP200" },
                { "V0ENDO_CORRECAO" , "Correction" },
                { "V0ENDO_ISENTA_CST" , "Exempt" },
                { "V0ENDO_DTVENCTO" , "2024-01-01" },
                { "V0ENDO_CFPREFIX" , "CF100" },
                { "V0ENDO_VLCUSEMI" , "500" },
                { "V0ENDO_RAMO" , "BranchB" },
                { "V0ENDO_CODPRODU" , "PRD200" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1010_00_PROCESSA_ENDOSSO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1010_00_PROCESSA_ENDOSSO_DB_INSERT_1_Insert1", q14);

                #endregion

                #region R1010_00_PROCESSA_ENDOSSO_DB_UPDATE_1_Update1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , "Auto" },
                { "V0ENDO_FONTE" , "External" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1010_00_PROCESSA_ENDOSSO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1010_00_PROCESSA_ENDOSSO_DB_UPDATE_1_Update1", q15);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS_COB" , "7" },
                { "V0ENDO_NRENDOS_RES" , "8" },
                { "V0APOL_ORGAO" , "AgencyA" },
                { "V0APOL_RAMO" , "BranchA" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1", q16);

                #endregion

                #region R1010_00_PROCESSA_ENDOSSO_DB_INSERT_2_Insert1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NUM_APOL" , "123458" },
                { "V0PARC_NRENDOS" , "9" },
                { "V0PARC_NRPARCEL" , "13" },
                { "V0PARC_DACPARC" , "2023-12-01" },
                { "V0PARC_FONTE" , "SourceA" },
                { "V0PARC_NRTIT" , "TIT200" },
                { "V0PARC_PRM_TAR_IX" , "800" },
                { "V0PARC_VAL_DES_IX" , "50" },
                { "V0PARC_OTNPRLIQ" , "750" },
                { "V0PARC_OTNADFRA" , "25" },
                { "V0PARC_OTNCUSTO" , "100" },
                { "V0PARC_OTNIOF" , "5" },
                { "V0PARC_OTNTOTAL" , "880" },
                { "V0PARC_OCORHIST" , "None" },
                { "V0PARC_QTDDOC" , "2" },
                { "V0PARC_SITUACAO" , "Active" },
                { "V0PARC_COD_EMPRESA" , "CMP300" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1010_00_PROCESSA_ENDOSSO_DB_INSERT_2_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1010_00_PROCESSA_ENDOSSO_DB_INSERT_2_Insert1", q17);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS_COB" , "7" },
                { "V0ENDO_NRENDOS_RES" , "8" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1", q18);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" },
                { "V0ENDO_NRENDOS" , "6" },
                { "V0HCTB_NRCERTIF" , "CERT123" },
                { "V0HCTB_NRPARCEL" , "12" },
                { "V0HCTB_OCORHIST" , "None" },
                { "V0HCTB_NRTIT" , "TIT100" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1", q19);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "VG080_COD_GRUPO_SUSEP" , "SUSEP100" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1", q20);

                #endregion

                #region R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRPROPOS" , "PROP200" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1", q21);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_PROPAUTOM" , "Auto" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1", q22);

                #endregion

                #region R1102_00_SELECT_RCAP_DB_SELECT_1_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "Internal" },
                { "V0RCAP_NRRCAP" , "RCAP300" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1102_00_SELECT_RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1102_00_SELECT_RCAP_DB_SELECT_1_Query1", q23);

                #endregion

                #region R1102_00_SELECT_RCAP_DB_SELECT_2_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "BankA" },
                { "V1RCAC_AGEAVISO" , "BranchA" },
                { "V1RCAC_NRAVISO" , "AVISO100" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1102_00_SELECT_RCAP_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1102_00_SELECT_RCAP_DB_SELECT_2_Query1", q24);

                #endregion

                #region R1102_00_SELECT_RCAP_DB_SELECT_3_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "BankA" },
                { "V1RCAC_AGEAVISO" , "BranchA" },
                { "V1RCAC_NRAVISO" , "AVISO100" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1102_00_SELECT_RCAP_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1102_00_SELECT_RCAP_DB_SELECT_3_Query1", q25);

                #endregion

                #region R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , "0.05" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1", q26);

                #endregion

                #region R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "V0PRVF_NRTIT" , "TIT300" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1", q27);

                #endregion

                #region R1109_00_CALCULA_RTO_DB_SELECT_1_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "V0CBPR_IMPMORNATU" , "100" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1109_00_CALCULA_RTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1109_00_CALCULA_RTO_DB_SELECT_1_Query1", q28);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , "SICOB100" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1", q29);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRENDOS" , "6" },
                { "V0RCAP_NRRCAP" , "RCAP300" },
                { "V0RCAP_FONTE" , "Internal" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1", q30);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "Internal" },
                { "V0RCAP_NRRCAP" , "RCAP300" },
                { "V0RCAP_SITUACAO" , "Valid" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1", q31);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOLICE" , "123457" },
                { "V0ENDO_NRENDOS" , "6" },
                { "V0RCAP_NRRCAP" , "RCAP300" },
                { "V0RCAP_FONTE" , "Internal" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1", q32);

                #endregion

                #region R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "BankA" },
                { "V1RCAC_AGEAVISO" , "BranchA" },
                { "V1RCAC_NRAVISO" , "AVISO100" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1", q33);

                #endregion

                #region VA0139B_CVGHISTCONT

                var q34 = new DynamicData();
                q34.AddDynamic(new Dictionary<string, string>{
                { "VG082_NUM_CERTIFICADO" , "CERT200" },
                { "VG082_NUM_PARCELA" , "14" },
                { "VG082_NUM_TITULO" , "TIT400" },
                { "VG082_OCORR_HISTORICO" , "None" },
                { "VG082_COD_GRUPO_SUSEP" , "SUSEP200" },
                { "VG082_RAMO_EMISSOR" , "BranchC" },
                { "VG082_COD_MODALIDADE" , "MOD100" },
                { "VG082_COD_COBERTURA" , "COV100" },
                { "VG082_VLR_PREMIO_RAMO" , "1500" },
                { "VG082_COD_USUARIO" , "USR300" },
                { "VG082_DTH_ATUALIZACAO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("VA0139B_CVGHISTCONT");
                AppSettings.TestSet.DynamicData.Add("VA0139B_CVGHISTCONT", q34);

                #endregion

                #region R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1

                var q35 = new DynamicData();
                q35.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_NRRCAPCO" , "RCAPCO100" },
                { "V1RCAC_OPERACAO" , "OperationA" },
                { "V1RCAC_HORAOPER" , "12:00" },
                { "V1RCAC_DTMOVTO" , "2023-12-01" },
                { "V1RCAC_NRRCAP" , "RCAP100" },
                { "V1RCAC_FONTE" , "Internal" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1", q35);

                #endregion

                #region R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1

                var q36 = new DynamicData();
                q36.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , "Internal" },
                { "V1RCAC_NRRCAP" , "RCAP100" },
                { "V1RCAC_NRRCAPCO" , "RCAPCO100" },
                { "V1RCAC_OPERACAO" , "OperationA" },
                { "V1SIST_DTMOVACB" , "2023-12-01" },
                { "V1RCAC_SITUACAO" , "Active" },
                { "V1RCAC_BCOAVISO" , "BankA" },
                { "V1RCAC_AGEAVISO" , "BranchA" },
                { "V1RCAC_NRAVISO" , "AVISO100" },
                { "V1RCAC_VLRCAP" , "10000" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
                { "V1RCAC_DTCADAST" , "2023-12-01" },
                { "V1RCAC_SITCONTB" , "Balanced" },
                { "V1RCAC_COD_EMPRESA" , "CMP400" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1", q36);

                #endregion

                #region R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1

                var q37 = new DynamicData();
                q37.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_VLRCAP" , "10000" },
                { "V1RCAC_BCOAVISO" , "BankA" },
                { "V1RCAC_AGEAVISO" , "BranchA" },
                { "V1RCAC_NRAVISO" , "AVISO100" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1", q37);

                #endregion

                #region VA0139B_V1APOLCOSCED

                var q38 = new DynamicData();
                q38.AddDynamic(new Dictionary<string, string>{
                { "V1COSP_CONGENER" , "GenB" }
            });
                AppSettings.TestSet.DynamicData.Remove("VA0139B_V1APOLCOSCED");
                AppSettings.TestSet.DynamicData.Add("VA0139B_V1APOLCOSCED", q38);

                #endregion

                #region R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1

                var q39 = new DynamicData();
                q39.AddDynamic(new Dictionary<string, string>{
                { "V0SEGVG_DTINIVIG" , "2023-12-01" },
                { "V0SEGVG_DTRENOVA" , "2024-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1", q39);

                #endregion

                #region R1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1

                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                { "V0SEGVG_DTINIVIG" , "2023-12-01" },
                { "V0SEGVG_DTRENOVA" , "2024-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1", q40);

                #endregion

                #region R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1

                var q41 = new DynamicData();
                q41.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , "ORD200" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1", q41);

                #endregion

                #region R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1

                var q42 = new DynamicData();
                q42.AddDynamic(new Dictionary<string, string>{
                { "V0ORDC_NUM_APOL" , "123459" },
                { "V0ORDC_NRENDOS" , "10" },
                { "V0ORDC_CODCOSS" , "COSS100" },
                { "V0ORDC_ORDEM_CED" , "OrderA" },
                { "V0ORDC_COD_EMPRESA" , "CMP500" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1", q42);

                #endregion

                #region R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1

                var q43 = new DynamicData();
                q43.AddDynamic(new Dictionary<string, string>{
                { "V1NCOS_NRORDEM" , "ORD200" },
                { "V1NCOS_CONGENER" , "GenC" },
                { "V1NCOS_ORGAO" , "AgencyB" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1", q43);

                #endregion

                #region R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1

                var q44 = new DynamicData();
                q44.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "OptionA" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1", q44);

                #endregion

                #region R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

                var q45 = new DynamicData();
                q45.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , "123460" },
                { "V0HISP_NRENDOS" , "11" },
                { "V0HISP_NRPARCEL" , "15" },
                { "V0HISP_DACPARC" , "2023-12-01" },
                { "V0HISP_DTMOVTO" , "2023-12-01" },
                { "V0HISP_OPERACAO" , "OperationB" },
                { "V0HISP_OCORHIST" , "None" },
                { "V0HISP_PRM_TARIFA" , "900" },
                { "V0HISP_VAL_DESCON" , "60" },
                { "V0HISP_VLPRMLIQ" , "840" },
                { "V0HISP_VLADIFRA" , "30" },
                { "V0HISP_VLCUSEMI" , "550" },
                { "V0HISP_VLIOCC" , "10" },
                { "V0HISP_VLPRMTOT" , "930" },
                { "V0HISP_VLPREMIO" , "920" },
                { "V0HISP_DTVENCTO" , "2024-02-01" },
                { "V0HISP_BCOCOBR" , "BankD" },
                { "V0HISP_AGECOBR" , "BranchD" },
                { "V0HISP_NRAVISO" , "AVISO200" },
                { "V0HISP_NRENDOCA" , "ENDO200" },
                { "V0HISP_SITCONTB" , "Unbalanced" },
                { "V0HISP_COD_USUAR" , "USR400" },
                { "V0HISP_RNUDOC" , "DOC200" },
                { "V0HISP_DTQITBCO" , "2023-12-02" },
                { "V0HISP_COD_EMPRESA" , "CMP600" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q45);

                #endregion

                #region R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1

                var q46 = new DynamicData();
                q46.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_NUM_APOL" , "123461" },
                { "V0COBA_NRENDOS" , "12" },
                { "V0COBA_NUM_ITEM" , "1" },
                { "V0COBA_OCORHIST" , "None" },
                { "V0COBA_RAMOFR" , "BranchD" },
                { "V0COBA_MODALIFR" , "TypeC" },
                { "V0COBA_COD_COBER" , "COV200" },
                { "V0COBA_IMP_SEG_IX" , "1100" },
                { "V0COBA_PRM_TAR_IX" , "1200" },
                { "V0COBA_IMP_SEG_VR" , "1300" },
                { "V0COBA_PRM_TAR_VR" , "1400" },
                { "V0COBA_PCT_COBERT" , "20" },
                { "V0COBA_FATOR_MULT" , "1.1" },
                { "V0COBA_DATA_INIVI" , "2023-12-01" },
                { "V0COBA_DATA_TERVI" , "2024-12-01" },
                { "V0COBA_COD_EMPRESA" , "CMP700" },
                { "V0COBA_SITUACAO" , "Active" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1", q46);

                #endregion

                #region R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1

                var q47 = new DynamicData();
                q47.AddDynamic(new Dictionary<string, string>{
                { "V0EDIA_CODRELAT" , "RPT200" },
                { "V0EDIA_NUM_APOL" , "123462" },
                { "V0EDIA_NRENDOS" , "13" },
                { "V0EDIA_NRPARCEL" , "16" },
                { "V0EDIA_DTMOVTO" , "2023-12-01" },
                { "V0EDIA_ORGAO" , "AgencyC" },
                { "V0EDIA_RAMO" , "BranchE" },
                { "V0EDIA_FONTE" , "SourceB" },
                { "V0EDIA_CONGENER" , "GenD" },
                { "V0EDIA_CODCORR" , "CORR100" },
                { "V0EDIA_SITUACAO" , "Valid" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1", q47);

                #endregion
                #endregion
                #endregion


                var program = new VA0139B();
                program.Execute(SVA0139B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 9);

            }
        }


    }
}