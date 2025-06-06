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
using static Code.VF0813B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VF0813B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VF0813B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0020_PROCESSA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_PERIPGTO" , ""},
                { "V0OPCP_DIADEB" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0020_PROCESSA_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_0020_PROCESSA_DB_SELECT_2_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_OCORHIST" , ""},
                { "V0HCOB_NRPARCEL" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "V0HCOB_SITUACAO" , ""},
                { "V0HCOB_DTALTOPC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0020_PROCESSA_DB_SELECT_2_Query1", q2);

            #endregion

            #region VF0813B_CCMPTIT

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0CMPT_NRPARCEL" , ""},
                { "V0CMPT_CODOPER" , ""},
                { "V0CMPT_VLPRMDIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VF0813B_CCMPTIT", q3);

            #endregion

            #region VF0813B_CPLCOM

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0PLCO_CODPDT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VF0813B_CPLCOM", q4);

            #endregion

            #region M_0020_PROCESSA_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCOB_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0HCTB_PRMVG" , ""},
                { "V0HCTB_PRMAP" , ""},
                { "V0HCOB_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0020_PROCESSA_DB_INSERT_1_Insert1", q5);

            #endregion

            #region M_0020_PROCESSA_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_OCORHIST" , ""},
                { "V0AVIS_BCOAVISO" , ""},
                { "V0AVIS_AGEAVISO" , ""},
                { "V0AVIS_NRAVISO" , ""},
                { "V0HCOB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0020_PROCESSA_DB_UPDATE_1_Update1", q6);

            #endregion

            #region M_0020_PROCESSA_DB_SELECT_3_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_CODPRODU" , ""},
                { "V0PRVG_TEM_SAF" , ""},
                { "V0PRVG_TEM_CDG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0020_PROCESSA_DB_SELECT_3_Query1", q7);

            #endregion

            #region M_0020_PROCESSA_DB_UPDATE_2_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , ""},
                { "WHOST_CODCONV" , ""},
                { "V0HCTA_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0020_PROCESSA_DB_UPDATE_2_Update1", q8);

            #endregion

            #region M_0021_LOCALIZA_TIT_DEB_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRPARCEL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0021_LOCALIZA_TIT_DEB_DB_SELECT_1_Query1", q9);

            #endregion

            #region M_0020_PROCESSA_DB_SELECT_4_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_PRMVG" , ""},
                { "V0PARC_PRMAP" , ""},
                { "V0PARC_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0020_PROCESSA_DB_SELECT_4_Query1", q10);

            #endregion

            #region M_0021_LOCALIZA_TIT_DEB_DB_SELECT_2_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0021_LOCALIZA_TIT_DEB_DB_SELECT_2_Query1", q11);

            #endregion

            #region M_0021_LOCALIZA_TIT_DEB_DB_SELECT_3_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0021_LOCALIZA_TIT_DEB_DB_SELECT_3_Query1", q12);

            #endregion

            #region M_0022_LOCALIZA_TIT_CRN_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRPARCEL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0022_LOCALIZA_TIT_CRN_DB_SELECT_1_Query1", q13);

            #endregion

            #region M_0021_LOCALIZA_TIT_DEB_DB_SELECT_4_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0021_LOCALIZA_TIT_DEB_DB_SELECT_4_Query1", q14);

            #endregion

            #region M_0022_LOCALIZA_TIT_CRN_DB_SELECT_2_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0022_LOCALIZA_TIT_CRN_DB_SELECT_2_Query1", q15);

            #endregion

            #region M_0022_LOCALIZA_TIT_CRN_DB_SELECT_3_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0022_LOCALIZA_TIT_CRN_DB_SELECT_3_Query1", q16);

            #endregion

            #region M_0025_ACESSO_NSA_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0025_ACESSO_NSA_DB_SELECT_1_Query1", q17);

            #endregion

            #region M_0050_GERA_FITACEF_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0FTCF_DTRET" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0050_GERA_FITACEF_DB_SELECT_1_Query1", q18);

            #endregion

            #region M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V0FTCF_TOTDBNEFET" , ""},
                { "V0FTCF_TOTDBEFET" , ""},
                { "V0FTCF_QTLANCDB" , ""},
                { "V0FTCF_QTDBEFET" , ""},
                { "V0FTCF_NSAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1", q19);

            #endregion

            #region M_0055_INSERT_FITACEF_DB_INSERT_1_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0FTCF_NSAC" , ""},
                { "V0FTCF_DTRET" , ""},
                { "V0FTCF_VERSAO" , ""},
                { "V0FTCF_QTREG" , ""},
                { "V0FTCF_QTLANCDB" , ""},
                { "V0FTCF_TOTDBEFET" , ""},
                { "V0FTCF_TOTDBNEFET" , ""},
                { "V0FTCF_QTDBEFET" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0055_INSERT_FITACEF_DB_INSERT_1_Insert1", q20);

            #endregion

            #region M_0100_INSERT_AVISOS_DB_INSERT_1_Insert1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0AVIS_BCOAVISO" , ""},
                { "V0AVIS_AGEAVISO" , ""},
                { "V0AVIS_NRAVISO" , ""},
                { "V0AVIS_NRSEQ" , ""},
                { "V0AVIS_DTMOVTO" , ""},
                { "V0AVIS_OPERACAO" , ""},
                { "V0AVIS_TIPAVI" , ""},
                { "V0AVIS_DTAVISO" , ""},
                { "V0AVIS_VLIOCC" , ""},
                { "V0AVIS_VLDESPES" , ""},
                { "V0AVIS_PRECED" , ""},
                { "V0AVIS_VLPRMLIQ" , ""},
                { "V0AVIS_VLPRMTOT" , ""},
                { "V0AVIS_SITCONTB" , ""},
                { "V0AVIS_CODEMP" , ""},
                { "V0AVIS_ORIGAVISO" , ""},
                { "V0AVIS_VALADT" , ""},
                { "V0AVIS_SITDEPTER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_INSERT_AVISOS_DB_INSERT_1_Insert1", q21);

            #endregion

            #region M_0100_INSERT_AVISOS_DB_INSERT_2_Insert1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V0SALD_CODEMP" , ""},
                { "V0SALD_BCOAVISO" , ""},
                { "V0SALD_AGEAVISO" , ""},
                { "V0SALD_TIPSGU" , ""},
                { "V0SALD_NRAVISO" , ""},
                { "V0SALD_DTAVISO" , ""},
                { "V0SALD_DTMOVTO" , ""},
                { "V0SALD_SDOATU" , ""},
                { "V0SALD_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_INSERT_AVISOS_DB_INSERT_2_Insert1", q22);

            #endregion

            #region M_1033_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0CMPT_NRPARCEL" , ""},
                { "V0CMPT_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1033_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1", q23);

            #endregion

            #region M_1035_QUITA_PARCELA_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_OCORHISTCTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1035_QUITA_PARCELA_DB_SELECT_1_Query1", q24);

            #endregion

            #region M_1035_QUITA_PARCELA_DB_SELECT_2_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_OCORHISTCTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1035_QUITA_PARCELA_DB_SELECT_2_Query1", q25);

            #endregion

            #region M_1036_BAIXA_HISTCTA_DB_UPDATE_1_Update1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V0FTCF_NSAC" , ""},
                { "WHOST_CODCONV" , ""},
                { "V0HCTA_NSAS" , ""},
                { "V0HCTA_NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1036_BAIXA_HISTCTA_DB_UPDATE_1_Update1", q26);

            #endregion

            #region M_1035_QUITA_PARCELA_DB_UPDATE_1_Update1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0PARC_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1035_QUITA_PARCELA_DB_UPDATE_1_Update1", q27);

            #endregion

            #region M_1035_QUITA_PARCELA_DB_SELECT_3_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRPARCEL" , ""},
                { "V0HCTA_OCORHISTCTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1035_QUITA_PARCELA_DB_SELECT_3_Query1", q28);

            #endregion

            #region M_1035_QUITA_PARCELA_DB_UPDATE_2_Update1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_OCORHISTCOB" , ""},
                { "V0HCTA_CODRET" , ""},
                { "V0FTCF_NSAC" , ""},
                { "V0HCTA_OCORHISTCTA" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0PARC_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1035_QUITA_PARCELA_DB_UPDATE_2_Update1", q29);

            #endregion

            #region M_1035_QUITA_PARCELA_DB_SELECT_4_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_DTVENCTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1035_QUITA_PARCELA_DB_SELECT_4_Query1", q30);

            #endregion

            #region VF0813B_CPARC1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRPARCEL" , ""},
                { "V0PARC_VLPRMTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VF0813B_CPARC1", q31);

            #endregion

            #region M_1040_GERA_EVENTO_DB_SELECT_1_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "V0PDTV_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1040_GERA_EVENTO_DB_SELECT_1_Query1", q32);

            #endregion

            #region M_1035_QUITA_PARCELA_DB_SELECT_5_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_VLCUSTCDG" , ""},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0COBP_IMPSEGCDG" , ""},
                { "V0COBP_IMPSEGAUXF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1035_QUITA_PARCELA_DB_SELECT_5_Query1", q33);

            #endregion

            #region M_1040_LOOP_DB_UPDATE_1_Update1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "V0PDTV_OCORHIST" , ""},
                { "V0PLCO_CODPDT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1040_LOOP_DB_UPDATE_1_Update1", q34);

            #endregion

            #region M_1040_LOOP_DB_INSERT_1_Insert1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "V0PLCO_CODPDT" , ""},
                { "V0PDTV_OCORHIST" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0PARC_NRPARCEL" , ""},
                { "V0SIST_DTMOVABE" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "V0CMPT_VLPRMDIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1040_LOOP_DB_INSERT_1_Insert1", q35);

            #endregion

            #region M_1035_QUITA_PARCELA_DB_SELECT_6_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "V0CDGC_VLCUSTCDG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1035_QUITA_PARCELA_DB_SELECT_6_Query1", q36);

            #endregion

            #region M_1035_QUITA_PARCELA_DB_SELECT_7_Query1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "V0SAFC_VLCUSTSAF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1035_QUITA_PARCELA_DB_SELECT_7_Query1", q37);

            #endregion

            #region M_1050_GERA_DIFERENCA_DB_INSERT_1_Insert1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCOB_NRPARCEL" , ""},
                { "V0PARC_DTVENCTO" , ""},
                { "V0PARC_PRMVG" , ""},
                { "V0PARC_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1050_GERA_DIFERENCA_DB_INSERT_1_Insert1", q38);

            #endregion

            #region M_1050_GERA_DIFERENCA_DB_UPDATE_1_Update1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0CMPT_NRPARCEL" , ""},
                { "V0CMPT_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1050_GERA_DIFERENCA_DB_UPDATE_1_Update1", q39);

            #endregion

            #region M_1099_INCLUI_CDG_DB_INSERT_1_Insert1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RCDG_DTREFER" , ""},
                { "V0COBP_IMPSEGCDG" , ""},
                { "V0COBP_VLCUSTCDG" , ""},
                { "V0HCTA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1099_INCLUI_CDG_DB_INSERT_1_Insert1", q40);

            #endregion

            #region M_1100_REPASSA_CDG_DB_SELECT_1_Query1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V0RCDG_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1100_REPASSA_CDG_DB_SELECT_1_Query1", q41);

            #endregion

            #region M_1100_REPASSA_CDG_DB_INSERT_1_Insert1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RCDG_DTREFER" , ""},
                { "V0CDGC_VLCUSTCDG" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0PARC_NRPARCEL" , ""},
                { "V0SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1100_REPASSA_CDG_DB_INSERT_1_Insert1", q42);

            #endregion

            #region M_1199_INCLUI_SAF_DB_INSERT_1_Insert1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RSAF_DTREFER" , ""},
                { "V0COBP_IMPSEGAUXF" , ""},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0HCTA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1199_INCLUI_SAF_DB_INSERT_1_Insert1", q43);

            #endregion

            #region M_1199_INCLUI_SAF_DB_SELECT_1_Query1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "V0RSAF_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1199_INCLUI_SAF_DB_SELECT_1_Query1", q44);

            #endregion

            #region M_1199_INCLUI_SAF_DB_INSERT_2_Insert1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RSAF_DTREFER" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0PARC_NRPARCEL" , ""},
                { "V0SAFC_VLCUSTSAF" , ""},
                { "V0PARC_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1199_INCLUI_SAF_DB_INSERT_2_Insert1", q45);

            #endregion

            #region M_1200_REPASSA_SAF_DB_SELECT_1_Query1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "V0RSAF_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1200_REPASSA_SAF_DB_SELECT_1_Query1", q46);

            #endregion

            #region M_1200_REPASSA_SAF_DB_INSERT_1_Insert1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RSAF_DTREFER" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0PARC_NRPARCEL" , ""},
                { "V0SAFC_VLCUSTSAF" , ""},
                { "V0PARC_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1200_REPASSA_SAF_DB_INSERT_1_Insert1", q47);

            #endregion

            #region M_1037_REJEITA_PARCELA_DB_UPDATE_1_Update1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , ""},
                { "WHOST_CODCONV" , ""},
                { "V0HCTA_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1037_REJEITA_PARCELA_DB_UPDATE_1_Update1", q48);

            #endregion

            #region M_1037_REJEITA_PARCELA_DB_UPDATE_2_Update1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_CODRET" , ""},
                { "V0FTCF_NSAC" , ""},
                { "WHOST_CODCONV" , ""},
                { "V0HCTA_NSAS" , ""},
                { "V0HCTA_NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1037_REJEITA_PARCELA_DB_UPDATE_2_Update1", q49);

            #endregion

            #region M_1038_MUDA_OPCAOPAG_DB_UPDATE_1_Update1

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_DTALTOPC" , ""},
                { "V0HCTA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1038_MUDA_OPCAOPAG_DB_UPDATE_1_Update1", q50);

            #endregion

            #region M_1038_MUDA_OPCAOPAG_DB_INSERT_1_Insert1

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "V0OPCP_PERIPGTO" , ""},
                { "V0OPCP_DIADEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1038_MUDA_OPCAOPAG_DB_INSERT_1_Insert1", q51);

            #endregion

            #region M_1037_REJEITA_PARCELA_DB_UPDATE_3_Update1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCOB_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1037_REJEITA_PARCELA_DB_UPDATE_3_Update1", q52);

            #endregion

            #region VF0813B_V0PRODUTO

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_CODPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VF0813B_V0PRODUTO", q53);

            #endregion

            #region R8010_00_VER_PRODUTO_DB_SELECT_1_Query1

            var q54 = new DynamicData();
            q54.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8010_00_VER_PRODUTO_DB_SELECT_1_Query1", q54);

            #endregion

            #region R8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1

            var q55 = new DynamicData();
            q55.AddDynamic(new Dictionary<string, string>{
                { "V0DPCF_CODEMP" , ""},
                { "V0DPCF_ANOREF" , ""},
                { "V0DPCF_MESREF" , ""},
                { "V0DPCF_BCOAVISO" , ""},
                { "V0DPCF_AGEAVISO" , ""},
                { "V0DPCF_NRAVISO" , ""},
                { "V0DPCF_CODPRODU" , ""},
                { "V0DPCF_TIPOREG" , ""},
                { "V0DPCF_SITUACAO" , ""},
                { "V0DPCF_TIPOCOB" , ""},
                { "V0DPCF_DTMOVTO" , ""},
                { "V0DPCF_DTAVISO" , ""},
                { "V0DPCF_QTDREG" , ""},
                { "V0DPCF_VLPRMTOT" , ""},
                { "V0DPCF_VLPRMLIQ" , ""},
                { "V0DPCF_VLTARIFA" , ""},
                { "V0DPCF_VLBALCAO" , ""},
                { "V0DPCF_VLIOCC" , ""},
                { "V0DPCF_VLDESCON" , ""},
                { "V0DPCF_VLJUROS" , ""},
                { "V0DPCF_VLMULTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1", q55);

            #endregion

            #region R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1

            var q56 = new DynamicData();
            q56.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRPARCEL" , ""},
                { "VGFOLLOW_NUM_CERTIFICADO" , ""},
                { "VGFOLLOW_NUM_NOSSA_FITA" , ""},
                { "VGFOLLOW_NUM_LANCAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1", q56);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("PRD.VA.D240902.VA0805B.RETDEB.R6131", "VF0813B.SAIDA1")]
        public static void VF0813B_Tests_Theory(string RETDEB_FILE_NAME_P, string RETERR_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmssffftt");

            RETERR_FILE_NAME_P = $"{RETERR_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_0022_LOCALIZA_TIT_CRN_DB_SELECT_3_Query1
                AppSettings.TestSet.DynamicData.Remove("M_0022_LOCALIZA_TIT_CRN_DB_SELECT_3_Query1");
                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRTIT" , "1"}
            });
                AppSettings.TestSet.DynamicData.Add("M_0022_LOCALIZA_TIT_CRN_DB_SELECT_3_Query1", q16);

                #endregion
                #region VF0813B_CCMPTIT
                AppSettings.TestSet.DynamicData.Remove("VF0813B_CCMPTIT");

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0CMPT_NRPARCEL" , "1"},
                { "V0CMPT_CODOPER" , "1"},
                { "V0CMPT_VLPRMDIF" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("VF0813B_CCMPTIT", q3);

                #endregion
                #region M_0020_PROCESSA_DB_SELECT_4_Query1
                AppSettings.TestSet.DynamicData.Remove("M_0020_PROCESSA_DB_SELECT_4_Query1");

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_PRMVG" , "1"},
                { "V0PARC_PRMAP" , "1"},
                { "V0PARC_DTVENCTO" , "2000-10-10"},
            });
                AppSettings.TestSet.DynamicData.Add("M_0020_PROCESSA_DB_SELECT_4_Query1", q10);

                #endregion
                #endregion
                var program = new VF0813B();
                program.Execute(RETDEB_FILE_NAME_P, RETERR_FILE_NAME_P);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(File.Exists(program.RETERR.FilePath));
                Assert.True(new FileInfo(program.RETERR.FilePath)?.Length > 0);

                Assert.True(program.RETURN_CODE == 0);

                var envList = AppSettings.TestSet.DynamicData["M_0020_PROCESSA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("V0HCOB_NRTIT", out var valor) && valor == "0000000000001");

                envList = AppSettings.TestSet.DynamicData["M_0020_PROCESSA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("V0HCOB_OCORHIST", out valor) && valor == "0001");

                envList = AppSettings.TestSet.DynamicData["M_0020_PROCESSA_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("V0HCOB_VLPRMTOT", out valor) && valor == "0000000000132.82");

                envList = AppSettings.TestSet.DynamicData["M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("V0FTCF_TOTDBEFET", out valor) && valor == "0000000000132.82");

                envList = AppSettings.TestSet.DynamicData["M_0100_INSERT_AVISOS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("V0AVIS_BCOAVISO", out valor) && valor == "0104");

                envList = AppSettings.TestSet.DynamicData["M_0100_INSERT_AVISOS_DB_INSERT_2_Insert1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("V0SALD_AGEAVISO", out valor) && valor == "7383");

                envList = AppSettings.TestSet.DynamicData["M_1033_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("V0CMPT_NRPARCEL", out valor) && valor == "0001");

                envList = AppSettings.TestSet.DynamicData["R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("VGFOLLOW_NUM_CERTIFICADO", out valor) && valor == "000093000367710");

            }
        }
        [Theory]
        [InlineData("PRD.VA.D240902.VA0805B.RETDEB.R6131", "VF0813B.SAIDA2")]
        public static void VF0813B_Tests_TheoryErro(string RETDEB_FILE_NAME_P, string RETERR_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmssffftt");

            RETERR_FILE_NAME_P = $"{RETERR_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_0000_PRINCIPAL_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_1_Query1");

                var q0 = new DynamicData();
                
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new VF0813B();
                program.Execute(RETDEB_FILE_NAME_P, RETERR_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 9);


            }
        }
    }
}