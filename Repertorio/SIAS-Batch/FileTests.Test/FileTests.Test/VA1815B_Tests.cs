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
using static Code.VA1815B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VA1815B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA1815B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NSAC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q1);

            #endregion

            #region VA1815B_CMOVDEB

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_COD_RETORNO_CEF" , "99"},
                { "MOVDEBCE_VALOR_DEBITO" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("VA1815B_CMOVDEB", q2);

            #endregion

            #region R0020_00_PROCESSA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_PRMVG" , ""},
                { "V0PARC_PRMAP" , ""},
                { "V0PARC_PRMTOT" , ""},
                { "V0PARC_OPCAOPAG" , ""},
                { "V0PARC_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_PROCESSA_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0020_00_PROCESSA_DB_SELECT_2_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRTIT" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "V0HCOB_SITUACAO" , ""},
                { "V0HCOB_VLPRMTOT" , ""},
                { "V0HCOB_OPCAOPAG" , ""},
                { "V0HCOB_DTALTOPC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_PROCESSA_DB_SELECT_2_Query1", q4);

            #endregion

            #region R0020_00_PROCESSA_DB_SELECT_3_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_PERIPGTO" , ""},
                { "V0OPCP_DIADEB" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_PROCESSA_DB_SELECT_3_Query1", q5);

            #endregion

            #region R0020_00_PROCESSA_DB_SELECT_4_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0PROP_QTDPARATZ" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0PROP_CODPRODU" , ""},
                { "V0PROP_NRPARCE" , ""},
                { "V0PRVG_PERIPGTO" , ""},
                { "V0PRVG_TEM_SAF" , ""},
                { "V0PRVG_TEM_CDG" , ""},
                { "V0PRVG_RISCO" , ""},
                { "V0PRVG_OPCAOPAG" , ""},
                { "V0PRVG_CUSTOCAP_TOTAL" , ""},
                { "V0PRVG_ORIG_PRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_PROCESSA_DB_SELECT_4_Query1", q6);

            #endregion

            #region R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SITUACAO" , ""},
                { "V0FTCF_NSAC" , ""},
                { "V0HCTA_CODRET" , ""},
                { "V0HCTA_OCORHISTCOB" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_2_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SITUACAO" , ""},
                { "V0FTCF_NSAC" , ""},
                { "V0HCTA_CODRET" , ""},
                { "V0HCTA_OCORHISTCOB" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_2_Update1", q8);

            #endregion

            #region VA1815B_CHCONTA2

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCTA_OCORHISTCTA" , ""},
                { "V0HCTA_NSAS" , ""},
                { "V0HCTA_NSL" , ""},
                { "V0HCTA_TIPLANC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA1815B_CHCONTA2", q9);

            #endregion

            #region VA1815B_CHCONTA3

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCTA_OCORHISTCTA" , ""},
                { "V0HCTA_TIPLANC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA1815B_CHCONTA3", q10);

            #endregion

            #region R0036_00_ACESSO_NSAS_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCTA_OCORHISTCTA" , ""},
                { "V0HCTA_TIPLANC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0036_00_ACESSO_NSAS_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0050_00_GERA_FITACEF_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0FTCF_DTRET" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0050_00_GERA_FITACEF_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0053_00_UPDATE_FITACEF_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0FTCF_DTRET2" , ""},
                { "V0FTCF_QTLANCDB" , ""},
                { "V0FTCF_TOTDBEFET" , ""},
                { "V0FTCF_TOTDBNEFET" , ""},
                { "V0FTCF_QTDBEFET" , ""},
                { "V0FTCF_NSAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0053_00_UPDATE_FITACEF_DB_UPDATE_1_Update1", q13);

            #endregion

            #region R0055_00_INSERT_FITACEF_DB_INSERT_1_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0FTCF_NSAC" , ""},
                { "V0FTCF_DTRET" , ""},
                { "V0FTCF_VERSAO" , ""},
                { "V0FTCF_QTREG" , ""},
                { "V0FTCF_QTLANCDB" , ""},
                { "V0FTCF_TOTDBEFET" , ""},
                { "V0FTCF_TOTDBNEFET" , ""},
                { "V0FTCF_QTDBEFET" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0055_00_INSERT_FITACEF_DB_INSERT_1_Insert1", q14);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_PRMVG" , ""},
                { "V0COBP_PRMAP" , ""},
                { "V0COBP_VLPREMIO" , ""},
                { "V0COBP_VLCUSTCDG" , ""},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0COBP_IMPSEGCDG" , ""},
                { "V0COBP_IMPSEGAUXF" , ""},
                { "V0COBP_VLCUSTCAP" , ""},
                { "V0COBP_QTTITCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_SELECT_1_Query1", q15);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_INSERT_2_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0HCTVA_PRMVG" , ""},
                { "V0HCTVA_PRMAP" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "V0HCTB_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_INSERT_2_Insert1", q16);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_3_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_OCORHIST" , ""},
                { "V0HCOB_OPCAOPAG" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_3_Update1", q17);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_4_Update1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_SITUACAO" , ""},
                { "V0HCTA_VLPRMTOT" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0HCOB_OPCAOPAG" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_4_Update1", q18);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1", q19);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_6_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_QTDPARATZ" , ""},
                { "V0HCTA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_6_Update1", q20);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_DTVENCTO" , ""},
                { "V0HCTA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1", q21);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_8_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_8_Update1", q22);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_SELECT_9_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0CDGC_VLCUSTCDG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_SELECT_9_Query1", q23);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_SELECT_10_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V0SAFC_VLCUSTSAF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_SELECT_10_Query1", q24);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_1_Update11

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_VLPRMTOT" , ""},
                { "WHOST_CODCONV" , ""},
                { "V0HCTA_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_1_Update11", q25);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_1_Update12

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0CAPI_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_1_Update12", q26);

            #endregion

            #region R1050_00_LOOP_DB_INSERT_1_Insert1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1050_00_LOOP_DB_INSERT_1_Insert1", q27);

            #endregion

            #region R1050_00_LOOP_DB_SELECT_2_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_DTVENCTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_LOOP_DB_SELECT_2_Query1", q28);

            #endregion

            #region R1099_00_INCLUI_CDG_DB_INSERT_1_Insert1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RCDG_DTREFER" , ""},
                { "V0COBP_IMPSEGCDG" , ""},
                { "V0COBP_VLCUSTCDG" , ""},
                { "V0HCTA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1099_00_INCLUI_CDG_DB_INSERT_1_Insert1", q29);

            #endregion

            #region R1100_00_REPASSA_CDG_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "V0RCDG_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_REPASSA_CDG_DB_SELECT_1_Query1", q30);

            #endregion

            #region R1100_00_REPASSA_CDG_DB_INSERT_2_Insert1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RCDG_DTREFER" , ""},
                { "V0CDGC_VLCUSTCDG" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_REPASSA_CDG_DB_INSERT_2_Insert1", q31);

            #endregion

            #region R1199_00_INCLUI_SAF_DB_INSERT_1_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RSAF_DTREFER" , ""},
                { "V0COBP_IMPSEGAUXF" , ""},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0HCTA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1199_00_INCLUI_SAF_DB_INSERT_1_Insert1", q32);

            #endregion

            #region R1199_00_INCLUI_SAF_DB_SELECT_2_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V0RSAF_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1199_00_INCLUI_SAF_DB_SELECT_2_Query1", q33);

            #endregion

            #region R1199_00_INCLUI_SAF_DB_INSERT_3_Insert1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RSAF_DTREFER" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0SAFC_VLCUSTSAF" , ""},
                { "V0PARC_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1199_00_INCLUI_SAF_DB_INSERT_3_Insert1", q34);

            #endregion

            #region R1200_00_REPASSA_SAF_DB_SELECT_1_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "V0RSAF_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_REPASSA_SAF_DB_SELECT_1_Query1", q35);

            #endregion

            #region R1200_00_REPASSA_SAF_DB_INSERT_2_Insert1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RSAF_DTREFER" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0SAFC_VLCUSTSAF" , ""},
                { "V0PARC_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_REPASSA_SAF_DB_INSERT_2_Insert1", q36);

            #endregion

            #region R2000_00_REJEITA_PARCELA_DB_UPDATE_1_Update1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_VLPRMTOT" , ""},
                { "WHOST_CODCONV" , ""},
                { "V0HCTA_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_REJEITA_PARCELA_DB_UPDATE_1_Update1", q37);

            #endregion

            #region R2000_00_REJEITA_PARCELA_DB_UPDATE_2_Update1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_SITUACAO" , ""},
                { "V0HCOB_OPCAOPAG" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_REJEITA_PARCELA_DB_UPDATE_2_Update1", q38);

            #endregion

            #region R2000_00_REJEITA_PARCELA_DB_UPDATE_3_Update1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_SITUACAO" , ""},
                { "V0PARC_OPCAOPAG" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_REJEITA_PARCELA_DB_UPDATE_3_Update1", q39);

            #endregion

            #region R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1_Update1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_DTALTOPC" , ""},
                { "V0HCTA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1_Update1", q40);

            #endregion

            #region R2100_00_MUDA_OPCAOPAG_DB_INSERT_2_Insert1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0OPCP_PERIPGTO" , ""},
                { "V0OPCP_DIADEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_MUDA_OPCAOPAG_DB_INSERT_2_Insert1", q41);

            #endregion

            #region R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRPARCEL" , ""},
                { "VGFOLLOW_NUM_CERTIFICADO" , ""},
                { "VGFOLLOW_NUM_NOSSA_FITA" , ""},
                { "VGFOLLOW_NUM_LANCAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1", q42);

            #endregion

            #endregion
        }


        private static void Load_Parameters2()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NSAC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q1);

            #endregion

            #region VA1815B_CMOVDEB

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_COD_RETORNO_CEF" , "99"},
                { "MOVDEBCE_VALOR_DEBITO" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("VA1815B_CMOVDEB", q2);

            #endregion

            #region R0020_00_PROCESSA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_PRMVG" , ""},
                { "V0PARC_PRMAP" , ""},
                { "V0PARC_PRMTOT" , ""},
                { "V0PARC_OPCAOPAG" , ""},
                { "V0PARC_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_PROCESSA_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0020_00_PROCESSA_DB_SELECT_2_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRTIT" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "V0HCOB_SITUACAO" , ""},
                { "V0HCOB_VLPRMTOT" , ""},
                { "V0HCOB_OPCAOPAG" , ""},
                { "V0HCOB_DTALTOPC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_PROCESSA_DB_SELECT_2_Query1", q4);

            #endregion

            #region R0020_00_PROCESSA_DB_SELECT_3_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_PERIPGTO" , ""},
                { "V0OPCP_DIADEB" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_PROCESSA_DB_SELECT_3_Query1", q5);

            #endregion

            #region R0020_00_PROCESSA_DB_SELECT_4_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0PROP_QTDPARATZ" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0PROP_CODPRODU" , ""},
                { "V0PROP_NRPARCE" , ""},
                { "V0PRVG_PERIPGTO" , ""},
                { "V0PRVG_TEM_SAF" , ""},
                { "V0PRVG_TEM_CDG" , ""},
                { "V0PRVG_RISCO" , ""},
                { "V0PRVG_OPCAOPAG" , ""},
                { "V0PRVG_CUSTOCAP_TOTAL" , ""},
                { "V0PRVG_ORIG_PRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_PROCESSA_DB_SELECT_4_Query1", q6);

            #endregion

            #region R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SITUACAO" , ""},
                { "V0FTCF_NSAC" , ""},
                { "V0HCTA_CODRET" , ""},
                { "V0HCTA_OCORHISTCOB" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_2_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SITUACAO" , ""},
                { "V0FTCF_NSAC" , ""},
                { "V0HCTA_CODRET" , ""},
                { "V0HCTA_OCORHISTCOB" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_2_Update1", q8);

            #endregion

            #region VA1815B_CHCONTA2

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCTA_OCORHISTCTA" , ""},
                { "V0HCTA_NSAS" , ""},
                { "V0HCTA_NSL" , ""},
                { "V0HCTA_TIPLANC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA1815B_CHCONTA2", q9);

            #endregion

            #region VA1815B_CHCONTA3

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCTA_OCORHISTCTA" , ""},
                { "V0HCTA_TIPLANC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA1815B_CHCONTA3", q10);

            #endregion

            #region R0036_00_ACESSO_NSAS_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCTA_OCORHISTCTA" , ""},
                { "V0HCTA_TIPLANC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0036_00_ACESSO_NSAS_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0050_00_GERA_FITACEF_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0FTCF_DTRET" , ""}
            });
            //AppSettings.TestSet.DynamicData.Add("R0050_00_GERA_FITACEF_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0053_00_UPDATE_FITACEF_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0FTCF_DTRET2" , ""},
                { "V0FTCF_QTLANCDB" , ""},
                { "V0FTCF_TOTDBEFET" , ""},
                { "V0FTCF_TOTDBNEFET" , ""},
                { "V0FTCF_QTDBEFET" , ""},
                { "V0FTCF_NSAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0053_00_UPDATE_FITACEF_DB_UPDATE_1_Update1", q13);

            #endregion

            #region R0055_00_INSERT_FITACEF_DB_INSERT_1_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0FTCF_NSAC" , ""},
                { "V0FTCF_DTRET" , ""},
                { "V0FTCF_VERSAO" , ""},
                { "V0FTCF_QTREG" , ""},
                { "V0FTCF_QTLANCDB" , ""},
                { "V0FTCF_TOTDBEFET" , ""},
                { "V0FTCF_TOTDBNEFET" , ""},
                { "V0FTCF_QTDBEFET" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0055_00_INSERT_FITACEF_DB_INSERT_1_Insert1", q14);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_PRMVG" , ""},
                { "V0COBP_PRMAP" , ""},
                { "V0COBP_VLPREMIO" , ""},
                { "V0COBP_VLCUSTCDG" , ""},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0COBP_IMPSEGCDG" , ""},
                { "V0COBP_IMPSEGAUXF" , ""},
                { "V0COBP_VLCUSTCAP" , ""},
                { "V0COBP_QTTITCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_SELECT_1_Query1", q15);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_INSERT_2_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0HCTVA_PRMVG" , ""},
                { "V0HCTVA_PRMAP" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "V0HCTB_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_INSERT_2_Insert1", q16);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_3_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_OCORHIST" , ""},
                { "V0HCOB_OPCAOPAG" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_3_Update1", q17);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_4_Update1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_SITUACAO" , ""},
                { "V0HCTA_VLPRMTOT" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0HCOB_OPCAOPAG" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_4_Update1", q18);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1", q19);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_6_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_QTDPARATZ" , ""},
                { "V0HCTA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_6_Update1", q20);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_DTVENCTO" , ""},
                { "V0HCTA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1", q21);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_8_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_8_Update1", q22);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_SELECT_9_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0CDGC_VLCUSTCDG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_SELECT_9_Query1", q23);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_SELECT_10_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V0SAFC_VLCUSTSAF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_SELECT_10_Query1", q24);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_1_Update11

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_VLPRMTOT" , ""},
                { "WHOST_CODCONV" , ""},
                { "V0HCTA_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_1_Update11", q25);

            #endregion

            #region R1000_00_QUITA_PARCELA_DB_UPDATE_1_Update12

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0CAPI_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_QUITA_PARCELA_DB_UPDATE_1_Update12", q26);

            #endregion

            #region R1050_00_LOOP_DB_INSERT_1_Insert1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1050_00_LOOP_DB_INSERT_1_Insert1", q27);

            #endregion

            #region R1050_00_LOOP_DB_SELECT_2_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_DTVENCTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_LOOP_DB_SELECT_2_Query1", q28);

            #endregion

            #region R1099_00_INCLUI_CDG_DB_INSERT_1_Insert1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RCDG_DTREFER" , ""},
                { "V0COBP_IMPSEGCDG" , ""},
                { "V0COBP_VLCUSTCDG" , ""},
                { "V0HCTA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1099_00_INCLUI_CDG_DB_INSERT_1_Insert1", q29);

            #endregion

            #region R1100_00_REPASSA_CDG_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "V0RCDG_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_REPASSA_CDG_DB_SELECT_1_Query1", q30);

            #endregion

            #region R1100_00_REPASSA_CDG_DB_INSERT_2_Insert1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RCDG_DTREFER" , ""},
                { "V0CDGC_VLCUSTCDG" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_REPASSA_CDG_DB_INSERT_2_Insert1", q31);

            #endregion

            #region R1199_00_INCLUI_SAF_DB_INSERT_1_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RSAF_DTREFER" , ""},
                { "V0COBP_IMPSEGAUXF" , ""},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0HCTA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1199_00_INCLUI_SAF_DB_INSERT_1_Insert1", q32);

            #endregion

            #region R1199_00_INCLUI_SAF_DB_SELECT_2_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V0RSAF_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1199_00_INCLUI_SAF_DB_SELECT_2_Query1", q33);

            #endregion

            #region R1199_00_INCLUI_SAF_DB_INSERT_3_Insert1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RSAF_DTREFER" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0SAFC_VLCUSTSAF" , ""},
                { "V0PARC_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1199_00_INCLUI_SAF_DB_INSERT_3_Insert1", q34);

            #endregion

            #region R1200_00_REPASSA_SAF_DB_SELECT_1_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "V0RSAF_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_REPASSA_SAF_DB_SELECT_1_Query1", q35);

            #endregion

            #region R1200_00_REPASSA_SAF_DB_INSERT_2_Insert1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RSAF_DTREFER" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0SAFC_VLCUSTSAF" , ""},
                { "V0PARC_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_REPASSA_SAF_DB_INSERT_2_Insert1", q36);

            #endregion

            #region R2000_00_REJEITA_PARCELA_DB_UPDATE_1_Update1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_VLPRMTOT" , ""},
                { "WHOST_CODCONV" , ""},
                { "V0HCTA_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_REJEITA_PARCELA_DB_UPDATE_1_Update1", q37);

            #endregion

            #region R2000_00_REJEITA_PARCELA_DB_UPDATE_2_Update1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_SITUACAO" , ""},
                { "V0HCOB_OPCAOPAG" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_REJEITA_PARCELA_DB_UPDATE_2_Update1", q38);

            #endregion

            #region R2000_00_REJEITA_PARCELA_DB_UPDATE_3_Update1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_SITUACAO" , ""},
                { "V0PARC_OPCAOPAG" , ""},
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCTA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_REJEITA_PARCELA_DB_UPDATE_3_Update1", q39);

            #endregion

            #region R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1_Update1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_DTALTOPC" , ""},
                { "V0HCTA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1_Update1", q40);

            #endregion

            #region R2100_00_MUDA_OPCAOPAG_DB_INSERT_2_Insert1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRCERTIF" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0OPCP_PERIPGTO" , ""},
                { "V0OPCP_DIADEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_MUDA_OPCAOPAG_DB_INSERT_2_Insert1", q41);

            #endregion

            #region R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NRPARCEL" , ""},
                { "VGFOLLOW_NUM_CERTIFICADO" , ""},
                { "VGFOLLOW_NUM_NOSSA_FITA" , ""},
                { "VGFOLLOW_NUM_LANCAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1", q42);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("RETREL_FILE_00.txt")]
        public static void VA1815B_Tests_Theory(string RETREL_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RETREL_FILE_NAME_P = $"{RETREL_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VA1815B();
                program.Execute(RETREL_FILE_NAME_P);

                //
                //
                //
                //
                //
                //

                Assert.True(File.Exists(program.RETREL.FilePath));
                Assert.True(new FileInfo(program.RETREL.FilePath)?.Length > 0);

                var envList = AppSettings.TestSet.DynamicData["R2000_00_REJEITA_PARCELA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList?.Count > 1);

                var envList1 = AppSettings.TestSet.DynamicData["R2000_00_REJEITA_PARCELA_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList1?.Count > 1);

                var envList2 = AppSettings.TestSet.DynamicData["R2000_00_REJEITA_PARCELA_DB_UPDATE_3_Update1"].DynamicList;
                Assert.True(envList2?.Count > 1);

                var envList3 = AppSettings.TestSet.DynamicData["R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3?.Count > 1);

                var envList4 = AppSettings.TestSet.DynamicData["R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4?.Count > 1);

                var envList5 = AppSettings.TestSet.DynamicData["R0053_00_UPDATE_FITACEF_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList5?.Count > 1);


                Assert.True(envList[1].TryGetValue("WHOST_CODCONV", out var valor) && valor == "000006088");

                Assert.True(envList1[1].TryGetValue("V0HCTA_SITUACAO", out valor) && valor == "2");

                Assert.True(envList2[1].TryGetValue("V0HCTA_SITUACAO", out valor) && valor == "2");

                Assert.True(envList3[1].TryGetValue("V0FTCF_NSAC", out valor) && valor == "4000");

                Assert.True(envList5[1].TryGetValue("V0FTCF_NSAC", out valor) && valor == "4000");


            }
        }
        [Theory]
        [InlineData("RETREL_FILE_01.txt")]
        public static void VA1815B_Tests_Theory2(string RETREL_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RETREL_FILE_NAME_P = $"{RETREL_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters2();

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VA1815B();
                program.Execute(RETREL_FILE_NAME_P);

                //R0050_00_GERA_FITACEF_DB_SELECT_1_Query1

                Assert.True(File.Exists(program.RETREL.FilePath));
                Assert.True(new FileInfo(program.RETREL.FilePath)?.Length > 0);

                var envList = AppSettings.TestSet.DynamicData["R2000_00_REJEITA_PARCELA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList?.Count > 1);

                var envList1 = AppSettings.TestSet.DynamicData["R2000_00_REJEITA_PARCELA_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList1?.Count > 1);

                var envList2 = AppSettings.TestSet.DynamicData["R2000_00_REJEITA_PARCELA_DB_UPDATE_3_Update1"].DynamicList;
                Assert.True(envList2?.Count > 1);

                var envList3 = AppSettings.TestSet.DynamicData["R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3?.Count > 1);

                var envList4 = AppSettings.TestSet.DynamicData["R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4?.Count > 1);
                
                var envList5 = AppSettings.TestSet.DynamicData["R0055_00_INSERT_FITACEF_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList5?.Count > 1);


                Assert.True(envList[1].TryGetValue("WHOST_CODCONV", out var valor) && valor == "000006088");

                Assert.True(envList1[1].TryGetValue("V0HCTA_SITUACAO", out valor) && valor == "2");

                Assert.True(envList2[1].TryGetValue("V0HCTA_SITUACAO", out valor) && valor == "2");

                Assert.True(envList3[1].TryGetValue("V0FTCF_NSAC", out valor) && valor == "4000");

                Assert.True(envList5[1].TryGetValue("V0FTCF_TOTDBNEFET", out valor) && valor == "0000000000001.00");


            }
        }
    }
}