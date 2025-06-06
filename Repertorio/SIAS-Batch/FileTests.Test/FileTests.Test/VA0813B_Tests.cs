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
using static Code.VA0813B;
using System.IO;
using System.Diagnostics.Metrics;

namespace FileTests.Test
{
    [Collection("VA0813B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0813B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""},
                { "V0SIST_DTMOVABE_1" , ""},
                { "V0SIST_DTMOVABE_A1" , ""},
                { "V0SIST_DTCURR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0020_00_PROCESSA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_PRMVG" , "0"},
                { "V0PARC_PRMAP" , "0"},
                { "V0PARC_PRMTOT" , "0"},
                { "V0PARC_OPCAOPAG" , "0"},
                { "V0PARC_DTVENCTO" , "2025-03-07"},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_PROCESSA_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0020_00_PROCESSA_DB_SELECT_2_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRTIT" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "V0HCOB_SITUACAO" , ""},
                { "V0HCOB_VLPRMTOT" , ""},
                { "V0HCOB_OPCAOPAG" , ""},
                { "V0HCOB_DTALTOPC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_PROCESSA_DB_SELECT_2_Query1", q2);

            #endregion

            #region R0020_00_PROCESSA_DB_SELECT_3_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_PERIPGTO" , ""},
                { "V0OPCP_DIADEB" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_PROCESSA_DB_SELECT_3_Query1", q3);

            #endregion

            #region R0020_00_PROCESSA_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_OCORHISTCOB" , ""},
                { "V0HCTA_SITUACAO" , ""},
                { "V0HCTA_CODRET" , ""},
                { "V0FTCF_NSAC" , ""},
                { "V0HCTA_OCORHISTCTA" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_PROCESSA_DB_UPDATE_1_Update1", q4);

            #endregion

            #region R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_OCORHISTCOB" , ""},
                { "WHOST_SITUACAO" , ""},
                { "V0HCTA_CODRET" , ""},
                { "V0FTCF_NSAC" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R0020_00_PROCESSA_DB_UPDATE_2_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_OCORHISTCOB" , ""},
                { "V0HCTA_SITUACAO" , ""},
                { "V0HCTA_CODRET" , ""},
                { "V0FTCF_NSAC" , ""},
                { "V0HCTA_OCORHISTCTA" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_PROCESSA_DB_UPDATE_2_Update1", q6);

            #endregion

            #region R0020_00_PROCESSA_DB_SELECT_4_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0PROP_DTQITBCO" , ""},
                { "V0PROP_AGECOBR" , ""},
                { "V0PROP_OPCAO_COBER" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0PROP_OCORHIST" , ""},
                { "V0PROP_QTDPARATZ" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0PROP_CODPRODU" , ""},
                { "V0PROP_NRPARCE" , ""},
                { "V0PRVG_TEM_SAF" , ""},
                { "V0PRVG_TEM_CDG" , ""},
                { "V0PRVG_RISCO" , ""},
                { "V0PRVG_OPCAOPAG" , ""},
                { "V0PRVG_CUSTOCAP_TOTAL" , ""},
                { "V0PRVG_ORIG_PRODU" , ""},
                { "V0PRVG_RAMO" , ""},
                { "V0APOL_MODALIDA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_PROCESSA_DB_SELECT_4_Query1", q7);

            #endregion

            #region R0020_00_PROCESSA_DB_UPDATE_3_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_SITUACAO" , ""},
                { "V0PARC_OPCAOPAG" , ""},
                { "V0PARC_PRMVG" , ""},
                { "V0PARC_PRMAP" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_PROCESSA_DB_UPDATE_3_Update1", q8);

            #endregion

            #region R0020_00_PROCESSA_DB_UPDATE_4_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_SITUACAO" , ""},
                { "V0HCTA_VLPRMTOT" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0AVIS_BCOAVISO" , ""},
                { "V0AVIS_AGEAVISO" , ""},
                { "V0AVIS_NRAVISO" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_PROCESSA_DB_UPDATE_4_Update1", q9);

            #endregion

            #region R0020_00_PROCESSA_DB_SELECT_5_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "WHOST_ORIGEM_PROPOSTA" , ""},
                { "WHOST_AGECTADEB_FID" , ""},
                { "WHOST_OPRCTADEB_FID" , ""},
                { "WHOST_NUMCTADEB_FID" , ""},
                { "WHOST_DIGCTADEB_FID" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_PROCESSA_DB_SELECT_5_Query1", q10);

            #endregion

            #region VA0813B_CHCONTA2

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCTA_OCORHISTCTA" , ""},
                { "V0HCTA_NSAS" , ""},
                { "V0HCTA_NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0813B_CHCONTA2", q11);

            #endregion

            #region VA0813B_CHCONTA3

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCTA_OCORHISTCTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0813B_CHCONTA3", q12);

            #endregion

            #region VA0813B_V0PRODUTO

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_CODPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VA0813B_V0PRODUTO", q13);

            #endregion

            #region R0036_00_ACESSO_NSAS_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCTA_OCORHISTCTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0036_00_ACESSO_NSAS_DB_SELECT_1_Query1", q14);

            #endregion

            #region R0040_00_SEL_V0HISTCOBVA_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRTIT" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "V0HCOB_SITUACAO" , ""},
                { "V0HCOB_VLPRMTOT" , ""},
                { "V0HCOB_OPCAOPAG" , ""},
                { "V0HCOB_DTALTOPC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0040_00_SEL_V0HISTCOBVA_DB_SELECT_1_Query1", q15);

            #endregion

            #region R0041_00_SEL_V0HISTCOBVA_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRTIT" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "V0HCOB_SITUACAO" , ""},
                { "V0HCOB_VLPRMTOT" , ""},
                { "V0HCOB_OPCAOPAG" , ""},
                { "V0HCOB_DTALTOPC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0041_00_SEL_V0HISTCOBVA_DB_SELECT_1_Query1", q16);

            #endregion

            #region R0042_00_SEL_V0HISTCOBVA_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0042_00_SEL_V0HISTCOBVA_DB_SELECT_1_Query1", q17);

            #endregion

            #region R0042_00_SEL_V0HISTCOBVA_DB_SELECT_2_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRTIT" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "V0HCOB_SITUACAO" , ""},
                { "V0HCOB_VLPRMTOT" , ""},
                { "V0HCOB_OPCAOPAG" , ""},
                { "V0HCOB_DTALTOPC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0042_00_SEL_V0HISTCOBVA_DB_SELECT_2_Query1", q18);

            #endregion

            #region R0050_00_GERA_FITACEF_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V0FTCF_DTRET" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0050_00_GERA_FITACEF_DB_SELECT_1_Query1", q19);

            #endregion

            #region R0053_00_UPDATE_FITACEF_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0FTCF_TOTDBNEFET" , ""},
                { "V0FTCF_TOTDBEFET" , ""},
                { "V0FTCF_QTLANCDB" , ""},
                { "V0FTCF_QTDBEFET" , ""},
                { "V0FTCF_DTRET2" , ""},
                { "V0FTCF_NSAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0053_00_UPDATE_FITACEF_DB_UPDATE_1_Update1", q20);

            #endregion

            #region R0055_00_INSERT_FITACEF_DB_INSERT_1_Insert1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0FTCF_NSAC" , ""},
                { "V0FTCF_DTRET" , ""},
                { "V0FTCF_VERSAO" , ""},
                { "V0FTCF_QTREG" , ""},
                { "V0FTCF_QTLANCDB" , ""},
                { "V0FTCF_TOTDBEFET" , ""},
                { "V0FTCF_TOTDBNEFET" , ""},
                { "V0FTCF_QTDBEFET" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0055_00_INSERT_FITACEF_DB_INSERT_1_Insert1", q21);

            #endregion

            #region R0100_00_INSERT_AVISOS_DB_INSERT_1_Insert1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R0100_00_INSERT_AVISOS_DB_INSERT_1_Insert1", q22);

            #endregion

            #region R0100_00_INSERT_AVISOS_DB_INSERT_2_Insert1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R0100_00_INSERT_AVISOS_DB_INSERT_2_Insert1", q23);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_PRMVG" , ""},
                { "V0COBP_PRMAP" , ""},
                { "V0COBP_VLPREMIO" , ""},
                { "V0COBP_IMPMORNATU" , ""},
                { "V0COBP_IMPMORACID" , ""},
                { "V0COBP_IMPDIT" , ""},
                { "V0COBP_QUANT_VIDAS" , ""},
                { "V0COBP_IMPINVPERM" , ""},
                { "V0COBP_IMPDH" , ""},
                { "V0COBP_VLCUSTCDG" , ""},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0COBP_IMPSEGCDG" , ""},
                { "V0COBP_IMPSEGAUXF" , ""},
                { "V0COBP_VLCUSTCAP" , ""},
                { "V0COBP_QTTITCAP" , ""},
                { "V0COBP_PRMDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_SELECT_1_Query1", q24);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_SELECT_2_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_PRMVG" , ""},
                { "V0COBP_PRMAP" , ""},
                { "V0COBP_VLPREMIO" , ""},
                { "V0COBP_VLCUSTCDG" , ""},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0COBP_IMPSEGCDG" , ""},
                { "V0COBP_IMPSEGAUXF" , ""},
                { "V0COBP_VLCUSTCAP" , ""},
                { "V0COBP_QTTITCAP" , ""},
                { "V0COBP_PRMDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_SELECT_2_Query1", q25);

            #endregion

            #region R0060_00_GERA_NOVO_NRTIT_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V0BANC_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0060_00_GERA_NOVO_NRTIT_DB_SELECT_1_Query1", q26);

            #endregion

            #region R0060_00_GERA_NOVO_NRTIT_DB_UPDATE_1_Update1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "V0BANC_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0060_00_GERA_NOVO_NRTIT_DB_UPDATE_1_Update1", q27);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_INSERT_1_Insert1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0HCTVA_PRMVG" , ""},
                { "V0HCTVA_PRMAP" , ""},
                { "V0SIST_DTMOVABE" , ""},
                { "V0HCTB_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_INSERT_1_Insert1", q28);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_SELECT_3_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_PRMVG" , ""},
                { "V0COBP_PRMAP" , ""},
                { "V0COBP_VLPREMIO" , ""},
                { "V0COBP_VLCUSTCDG" , ""},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0COBP_IMPSEGCDG" , ""},
                { "V0COBP_IMPSEGAUXF" , ""},
                { "V0COBP_VLCUSTCAP" , ""},
                { "V0COBP_QTTITCAP" , ""},
                { "V0COBP_PRMDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_SELECT_3_Query1", q29);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_1_Update1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_SITUACAO" , ""},
                { "V0HCTA_VLPRMTOT" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0AVIS_BCOAVISO" , ""},
                { "V0AVIS_AGEAVISO" , ""},
                { "V0AVIS_NRAVISO" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_1_Update1", q30);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_2_Update1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_2_Update1", q31);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_SELECT_4_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_PRMVG" , ""},
                { "V0COBP_PRMAP" , ""},
                { "V0COBP_VLPREMIO" , ""},
                { "V0COBP_VLCUSTCDG" , ""},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0COBP_IMPSEGCDG" , ""},
                { "V0COBP_IMPSEGAUXF" , ""},
                { "V0COBP_VLCUSTCAP" , ""},
                { "V0COBP_QTTITCAP" , ""},
                { "V0COBP_PRMDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_SELECT_4_Query1", q32);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_3_Update1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_QTDPARATZ" , ""},
                { "V0HCTA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_3_Update1", q33);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_4_Update1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "WHOST_ORIGEM_PROPOSTA" , ""},
                { "V0PARC_DTVENCTO" , ""},
                { "V0HCTA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_4_Update1", q34);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_SELECT_5_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_DATA_NASCIMENTO" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_TIPO_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_SELECT_5_Query1", q35);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1", q36);

            #endregion

            #region R1050_00_LOOP_DB_INSERT_1_Insert1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0DIFP_NRPARCEL" , ""},
                { "V0DIFP_CODOPER" , ""},
                { "V0PARC_DTVENCTO" , ""},
                { "V0DIFP_PRMDEVVG" , ""},
                { "V0DIFP_PRMDEVAP" , ""},
                { "V0DIFP_PRMPAGVG" , ""},
                { "V0DIFP_PRMPAGAP" , ""},
                { "V0DIFP_PRMDIFVG" , ""},
                { "V0DIFP_PRMDIFAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_LOOP_DB_INSERT_1_Insert1", q37);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_SELECT_6_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "V0CDGC_VLCUSTCDG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_SELECT_6_Query1", q38);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_6_Update1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_VLPRMTOT" , ""},
                { "WHOST_CODCONV" , ""},
                { "WHOST_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_6_Update1", q39);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_SELECT_7_Query1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V0SAFC_VLCUSTSAF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_SELECT_7_Query1", q40);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0CAPI_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1", q41);

            #endregion

            #region R1099_00_INCLUI_CDG_DB_INSERT_1_Insert1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RCDG_DTREFER" , ""},
                { "V0COBP_IMPSEGCDG" , ""},
                { "V0COBP_VLCUSTCDG" , ""},
                { "V0HCTA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1099_00_INCLUI_CDG_DB_INSERT_1_Insert1", q42);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_SELECT_8_Query1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "V0FITA_DATA_GERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_SELECT_8_Query1", q43);

            #endregion

            #region R1100_00_REPASSA_CDG_DB_SELECT_1_Query1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "V0RCDG_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_REPASSA_CDG_DB_SELECT_1_Query1", q44);

            #endregion

            #region R1100_00_REPASSA_CDG_DB_INSERT_1_Insert1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RCDG_DTREFER" , ""},
                { "V0CDGC_VLCUSTCDG" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_REPASSA_CDG_DB_INSERT_1_Insert1", q45);

            #endregion

            #region R1199_00_INCLUI_SAF_DB_INSERT_1_Insert1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RSAF_DTREFER" , ""},
                { "V0COBP_IMPSEGAUXF" , ""},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0HCTA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1199_00_INCLUI_SAF_DB_INSERT_1_Insert1", q46);

            #endregion

            #region R1199_00_INCLUI_SAF_DB_SELECT_1_Query1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "V0RSAF_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1199_00_INCLUI_SAF_DB_SELECT_1_Query1", q47);

            #endregion

            #region R1199_00_INCLUI_SAF_DB_INSERT_2_Insert1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RSAF_DTREFER" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0SAFC_VLCUSTSAF" , ""},
                { "V0PARC_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1199_00_INCLUI_SAF_DB_INSERT_2_Insert1", q48);

            #endregion

            #region R1200_00_REPASSA_SAF_DB_SELECT_1_Query1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "V0RSAF_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_REPASSA_SAF_DB_SELECT_1_Query1", q49);

            #endregion

            #region R1200_00_REPASSA_SAF_DB_INSERT_1_Insert1

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RSAF_DTREFER" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0SAFC_VLCUSTSAF" , ""},
                { "V0PARC_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_REPASSA_SAF_DB_INSERT_1_Insert1", q50);

            #endregion

            #region R2000_00_REJEITA_PARCELA_DB_SELECT_1_Query1

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_CODRET" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_REJEITA_PARCELA_DB_SELECT_1_Query1", q51);

            #endregion

            #region R2000_CONTINUA_DB_UPDATE_1_Update1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_VLPRMTOT" , ""},
                { "WHOST_CODCONV" , ""},
                { "WHOST_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_CONTINUA_DB_UPDATE_1_Update1", q52);

            #endregion

            #region R2000_CONTINUA_DB_UPDATE_2_Update1

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2000_CONTINUA_DB_UPDATE_2_Update1", q53);

            #endregion

            #region R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1_Update1

            var q54 = new DynamicData();
            q54.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE_1" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCOB_DTALTOPC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1_Update1", q54);

            #endregion

            #region R2000_CONTINUA_DB_UPDATE_3_Update1

            var q55 = new DynamicData();
            q55.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0HCOB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_CONTINUA_DB_UPDATE_3_Update1", q55);

            #endregion

            #region R2100_00_MUDA_OPCAOPAG_DB_INSERT_1_Insert1

            var q56 = new DynamicData();
            q56.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0OPCP_DTINIVIG" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0OPCP_PERIPGTO" , ""},
                { "V0OPCP_DIADEB" , ""},
                { "V0OPCP_AGECTADEB" , ""},
                { "V0OPCP_OPRCTADEB" , ""},
                { "V0OPCP_NUMCTADEB" , ""},
                { "V0OPCP_DIGCTADEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_MUDA_OPCAOPAG_DB_INSERT_1_Insert1", q56);

            #endregion

            #region R2100_00_MUDA_OPCAOPAG_DB_UPDATE_2_Update1

            var q57 = new DynamicData();
            q57.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCOB_DTALTOPC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_MUDA_OPCAOPAG_DB_UPDATE_2_Update1", q57);

            #endregion

            #region R2000_CONTINUA_DB_UPDATE_4_Update1

            var q58 = new DynamicData();
            q58.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_SITUACAO" , ""},
                { "V0HCTA_VLPRMTOT" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_CONTINUA_DB_UPDATE_4_Update1", q58);

            #endregion

            #region R2000_CONTINUA_DB_UPDATE_5_Update1

            var q59 = new DynamicData();
            q59.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2000_CONTINUA_DB_UPDATE_5_Update1", q59);

            #endregion

            #region VA0813B_CVGRAMOCOMP

            var q60 = new DynamicData();
            q60.AddDynamic(new Dictionary<string, string>{
                { "VG081_NUM_APOLICE" , ""},
                { "VG081_COD_SUBGRUPO" , ""},
                { "VG081_COD_GRUPO_SUSEP" , ""},
                { "VG081_RAMO_EMISSOR" , ""},
                { "VG081_COD_MODALIDADE" , ""},
                { "VG081_DTH_INI_VIGENCIA" , ""},
                { "VG081_COD_OPCAO_COBERTURA" , ""},
                { "VG081_NUM_IDADE_INICIAL" , ""},
                { "VG081_NUM_IDADE_FINAL" , ""},
                { "VG081_VLR_PERC_PREMIO" , ""},
                { "VG081_COD_USUARIO" , ""},
                { "VG081_DTH_ATUALIZACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0813B_CVGRAMOCOMP", q60);

            #endregion

            #region R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_1_Query1

            var q61 = new DynamicData();
            q61.AddDynamic(new Dictionary<string, string>{
                { "VGPROSIA_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_1_Query1", q61);

            #endregion

            #region R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_2_Query1

            var q62 = new DynamicData();
            q62.AddDynamic(new Dictionary<string, string>{
                { "VGPROSIA_NUM_PERIODO_PAG" , ""},
                { "SUBGVGAP_COD_FONTE" , ""},
                { "SUBGVGAP_COD_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_2_Query1", q62);

            #endregion

            #region R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_3_Query1

            var q63 = new DynamicData();
            q63.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_NUM_TERMO" , ""},
                { "TERMOADE_COD_AGENCIA_OP" , ""},
                { "TERMOADE_NUM_MATRICULA_VEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_3_Query1", q63);

            #endregion

            #region R0400_00_INSERT_COMISSAO_DB_INSERT_1_Insert1

            var q64 = new DynamicData();
            q64.AddDynamic(new Dictionary<string, string>{
                { "V0COMI_NUMAPOL" , ""},
                { "V0COMI_NRENDOS" , ""},
                { "V0COMI_NRCERTIF" , ""},
                { "V0COMI_DIGCERT" , ""},
                { "V0COMI_IDTPSEGU" , ""},
                { "V0COMI_NRPARCEL" , ""},
                { "V0COMI_OPERACAO" , ""},
                { "V0COMI_CODPDT" , ""},
                { "V0COMI_RAMOFR" , ""},
                { "V0COMI_MODALIFR" , ""},
                { "V0COMI_OCORHIST" , ""},
                { "V0COMI_FONTE" , ""},
                { "V0COMI_CODCLIEN" , ""},
                { "V0COMI_VLCOMIS" , ""},
                { "V0COMI_DATCLO" , ""},
                { "V0COMI_NUMREC" , ""},
                { "V0COMI_VALBAS" , ""},
                { "V0COMI_TIPCOM" , ""},
                { "V0COMI_QTPARCEL" , ""},
                { "V0COMI_PCCOMCOR" , ""},
                { "V0COMI_PCDESCON" , ""},
                { "V0COMI_CODSUBES" , ""},
                { "V0COMI_DTMOVTO" , ""},
                { "V0COMI_DATSEL" , ""},
                { "V0COMI_CODEMP" , ""},
                { "V0COMI_CODPRP" , ""},
                { "V0COMI_NUMBIL" , ""},
                { "V0COMI_VLVARMON" , ""},
                { "V0COMI_DTQITBCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0400_00_INSERT_COMISSAO_DB_INSERT_1_Insert1", q64);

            #endregion

            #region R0300_00_GERA_FUNDOCOMISVA_DB_INSERT_1_Insert1

            var q65 = new DynamicData();
            q65.AddDynamic(new Dictionary<string, string>{
                { "VGPROSIA_COD_PRODUTO" , ""},
                { "TERMOADE_NUM_TERMO" , ""},
                { "SUBGVGAP_COD_FONTE" , ""},
                { "TERMOADE_COD_AGENCIA_OP" , ""},
                { "SUBGVGAP_COD_CLIENTE" , ""},
                { "TERMOADE_NUM_MATRICULA_VEN" , ""},
                { "V0HCTVA_PRMVG" , ""},
                { "V0HCTVA_PRMAP" , ""},
                { "V0FUND_VLCOMISVG" , ""},
                { "V0FUND_VLCOMISAP" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "PARAGEEM_PCCOMVEN" , ""},
                { "V0SIST_DTMOVABE" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0HCOB_NRTIT" , ""},
                { "V0HCTA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_GERA_FUNDOCOMISVA_DB_INSERT_1_Insert1", q65);

            #endregion

            #region R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_4_Query1

            var q66 = new DynamicData();
            q66.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_4_Query1", q66);

            #endregion

            #region R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_5_Query1

            var q67 = new DynamicData();
            q67.AddDynamic(new Dictionary<string, string>{
                { "VGPROSIA_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_5_Query1", q67);

            #endregion

            #region R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_6_Query1

            var q68 = new DynamicData();
            q68.AddDynamic(new Dictionary<string, string>{
                { "PARAGEEM_PCCOMVEN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_6_Query1", q68);

            #endregion

            #region R6920_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q69 = new DynamicData();
            q69.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_IMPMORNATU" , ""},
                { "V0COBP_IMPMORACID" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6920_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q69);

            #endregion

            #region R7160_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1

            var q70 = new DynamicData();
            q70.AddDynamic(new Dictionary<string, string>{
                { "VGCOBSUB_IMP_SEGURADA_IX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7160_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1", q70);

            #endregion

            #region R7170_00_SELECT_CONDITEC_DB_SELECT_1_Query1

            var q71 = new DynamicData();
            q71.AddDynamic(new Dictionary<string, string>{
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
            });
            AppSettings.TestSet.DynamicData.Add("R7170_00_SELECT_CONDITEC_DB_SELECT_1_Query1", q71);

            #endregion

            #region R7200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1

            var q72 = new DynamicData();
            q72.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "WHOST_GRUPO_SUSEP" , ""},
                { "WHOST_COD_RAMO" , ""},
                { "VG082_COD_MODALIDADE" , ""},
                { "VG082_COD_COBERTURA" , ""},
                { "WHOST_PREMIO_CONJ" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1", q72);

            #endregion

            #region R8010_00_VER_PRODUTO_DB_SELECT_1_Query1

            var q73 = new DynamicData();
            q73.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8010_00_VER_PRODUTO_DB_SELECT_1_Query1", q73);

            #endregion

            #region R8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1

            var q74 = new DynamicData();
            q74.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1", q74);

            #endregion

            #region R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1

            var q75 = new DynamicData();
            q75.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRPARCEL" , ""},
                { "VGFOLLOW_NUM_CERTIFICADO" , ""},
                { "VGFOLLOW_NUM_NOSSA_FITA" , ""},
                { "VGFOLLOW_NUM_LANCAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1", q75);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VA0813B_INPUT_20250306161200", "VA0813B_OUTPUT_20250306161201", "VA0813B_OUTPUT_20250306161202", "VA0813B_OUTPUT_20250306161203")]
        public static void VA0813B_Tests_Theory_ReturnCode_00(string RETDEB_FILE_NAME_P, string RETERR_FILE_NAME_P, string MAUDIT_FILE_NAME_P, string SVADEB_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            RETERR_FILE_NAME_P = $"{RETERR_FILE_NAME_P}_{timestamp}.txt";
            MAUDIT_FILE_NAME_P = $"{MAUDIT_FILE_NAME_P}_{timestamp}.txt";
            SVADEB_FILE_NAME_P = $"{SVADEB_FILE_NAME_P}_{timestamp}.txt";
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
                q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , "2025-01-27"},
                { "V0SIST_DTMOVABE_1" , "2025-01-26"},
                { "V0SIST_DTMOVABE_A1" , "2025-01-28"},
                { "V0SIST_DTCURR" , "2025-03-06"},
            });
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion
                #region VA0813B_CHCONTA2
                AppSettings.TestSet.DynamicData.Remove("VA0813B_CHCONTA2");

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , "3"},
                { "V0HCTA_OCORHISTCTA" , ""},
                { "V0HCTA_NSAS" , ""},
                { "V0HCTA_NSL" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("VA0813B_CHCONTA2", q11);

                #endregion
                #region VA0813B_CHCONTA3
                AppSettings.TestSet.DynamicData.Remove("VA0813B_CHCONTA3");

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "V0HCTA_NRCERTIF" , ""},
                    { "V0HCTA_NRPARCEL" , "3"},
                    { "V0HCTA_OCORHISTCTA" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("VA0813B_CHCONTA3", q12);

                #endregion
                #region R0036_00_ACESSO_NSAS_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R0036_00_ACESSO_NSAS_DB_SELECT_1_Query1");

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                 { "V0HCTA_NRCERTIF" , ""},
                 { "V0HCTA_NRPARCEL" , "3"},
                 { "V0HCTA_OCORHISTCTA" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R0036_00_ACESSO_NSAS_DB_SELECT_1_Query1", q14);

                #endregion
                #region R0020_00_PROCESSA_DB_SELECT_4_Query1
                AppSettings.TestSet.DynamicData.Remove("R0020_00_PROCESSA_DB_SELECT_4_Query1");

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0PROP_DTQITBCO" , "2008-08-31"},
                { "V0PROP_AGECOBR" , ""},
                { "V0PROP_OPCAO_COBER" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0PROP_OCORHIST" , ""},
                { "V0PROP_QTDPARATZ" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0PROP_CODPRODU" , "9320"},
                { "V0PROP_NRPARCE" , ""},
                { "V0PRVG_TEM_SAF" , ""},
                { "V0PRVG_TEM_CDG" , ""},
                { "V0PRVG_RISCO" , ""},
                { "V0PRVG_OPCAOPAG" , ""},
                { "V0PRVG_CUSTOCAP_TOTAL" , ""},
                { "V0PRVG_ORIG_PRODU" , ""},
                { "V0PRVG_RAMO" , ""},
                { "V0APOL_MODALIDA" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R0020_00_PROCESSA_DB_SELECT_4_Query1", q7);

                #endregion

                #region R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_4_Query1
                AppSettings.TestSet.DynamicData.Remove("R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_4_Query1");

                var q66 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_4_Query1", q66);

                #endregion

                #endregion
                var program = new VA0813B();
                DB.SQLCODE.Value = 0;
                program.Execute(RETDEB_FILE_NAME_P, RETERR_FILE_NAME_P, MAUDIT_FILE_NAME_P, SVADEB_FILE_NAME_P);

                Assert.True(File.Exists(program.RETDEB.FilePath));
                Assert.True(File.Exists(program.MAUDIT.FilePath));

                Assert.Empty(AppSettings.TestSet.DynamicData["M_0000_PRINCIPAL_DB_SELECT_1_Query1"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["R0020_00_PROCESSA_DB_SELECT_1_Query1"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["R0020_00_PROCESSA_DB_SELECT_2_Query1"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["R0020_00_PROCESSA_DB_SELECT_3_Query1"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["R0020_00_PROCESSA_DB_SELECT_4_Query1"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["R0020_00_PROCESSA_DB_SELECT_5_Query1"].DynamicList.ToList());

                var update1 = AppSettings.TestSet.DynamicData["R0020_00_PROCESSA_DB_UPDATE_1_Update1"].DynamicList.ToList();
                Assert.NotEmpty(update1);

                var update2 = AppSettings.TestSet.DynamicData["R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1_Update1"].DynamicList.ToList();
                Assert.NotEmpty(update2);

                var update3 = AppSettings.TestSet.DynamicData["R0020_00_PROCESSA_DB_UPDATE_2_Update1"].DynamicList.ToList();
                Assert.NotEmpty(update3);

                var update4 = AppSettings.TestSet.DynamicData["R0020_00_PROCESSA_DB_UPDATE_3_Update1"].DynamicList.ToList();
                Assert.NotEmpty(update4);

                var update5 = AppSettings.TestSet.DynamicData["R0020_00_PROCESSA_DB_UPDATE_4_Update1"].DynamicList.ToList();
                Assert.NotEmpty(update5);

                var insert1 = AppSettings.TestSet.DynamicData["R0100_00_INSERT_AVISOS_DB_INSERT_1_Insert1"].DynamicList.ToList();
                Assert.NotEmpty(insert1);

                var insert2 = AppSettings.TestSet.DynamicData["R0100_00_INSERT_AVISOS_DB_INSERT_2_Insert1"].DynamicList.ToList();
                Assert.NotEmpty(insert2);

                var insert3 = AppSettings.TestSet.DynamicData["R1000_00_QUITA_PARCELA_DB_INSERT_1_Insert1"].DynamicList.ToList();
                Assert.NotEmpty(insert3);

                var insert4 = AppSettings.TestSet.DynamicData["R1050_00_LOOP_DB_INSERT_1_Insert1"].DynamicList.ToList();
                Assert.NotEmpty(insert4);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("VA0813B_INPUT_20250307161200", "VA0813B_OUTPUT_20250307161201", "VA0813B_OUTPUT_20250307161202", "VA0813B_OUTPUT_20250307161203")]
        public static void VA0813B_Tests_Theory_ReturnCode_99(string RETDEB_FILE_NAME_P, string RETERR_FILE_NAME_P, string MAUDIT_FILE_NAME_P, string SVADEB_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RETERR_FILE_NAME_P = $"{RETERR_FILE_NAME_P}_{timestamp}.txt";
            MAUDIT_FILE_NAME_P = $"{MAUDIT_FILE_NAME_P}_{timestamp}.txt";
            SVADEB_FILE_NAME_P = $"{SVADEB_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);
                #endregion
                var program = new VA0813B();

                program.Execute(RETDEB_FILE_NAME_P, RETERR_FILE_NAME_P, MAUDIT_FILE_NAME_P, SVADEB_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 9);
            }
        }
    }
}