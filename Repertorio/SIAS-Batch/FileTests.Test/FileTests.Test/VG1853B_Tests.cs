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
using static Code.VG1853B;
using Sias.VidaEmGrupo.DB2.VG1853B;

namespace FileTests.Test
{
    [Collection("VG1853B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VG1853B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.Clear();
            #region PARAMETERS
            #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTVENFIM_CN" , "2024-10-10"},
                { "V1SIST_DTVENFIM_DB" , "2024-10-11"},
                { "V1SIST_DTMOVABE" , "2024-01-11"},
                { "V1SIST_DTTERCOT" , "2024-01-12"},
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0000_00_PRINCIPAL_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0COTA_DTINIVIG" , "2024-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_2_Query1", q1);

            #endregion

            #region R0000_00_PRINCIPAL_DB_SELECT_3_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_MIN_DTPROXVEN" , "2024-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_3_Query1", q2);

            #endregion

            #region VG1853B_CPROPVA

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NUM_APOLICE" , "3009300012344"},
                { "V0PROP_CODSUBES" , "2"},
                { "V0PROP_NRCERTIF" , "73189110446483"},
                { "V0PROP_CODPRODU" , "9721"},
                { "V0PROP_CODCLIEN" , "36578578"},
                { "V0PROP_NRPARCEL" , "1"},
                { "V0PROP_SITUACAO" , "2"},
                { "V0PROP_DTQITBCO" , "2023-11-06"},
                { "V0PROP_DTVENCTO" , "2023-12-01"},
                { "V0PROP_DTPROXVEN" , "2024-01-01"},
                { "V0PROP_NRPRIPARATZ" , "0"},
                { "V0PROP_QTDPARATZ" , "0"},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0PROP_TIMESTAMP" , "2023-11-10 01:39:28.235"},
                { "V0PROP_DTMINVEN" , "2023-12-06"},
                { "V0PROP_DTQITBCO_1YEAR" , "2024-11-06"},
                { "V0PROP_CODOPER" , "106"},
                { "V0PROP_DTADMISSAO" , "1900-01-01"},
                { "V0PROP_OCORHIST" , "1"},
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NUM_APOLICE" , "3009300012345"},
                { "V0PROP_CODSUBES" , "2"},
                { "V0PROP_NRCERTIF" , "73189110446484"},
                { "V0PROP_CODPRODU" , "9721"},
                { "V0PROP_CODCLIEN" , "36578578"},
                { "V0PROP_NRPARCEL" , "1"},
                { "V0PROP_SITUACAO" , "2"},
                { "V0PROP_DTQITBCO" , "2023-11-06"},
                { "V0PROP_DTVENCTO" , "2023-12-01"},
                { "V0PROP_DTPROXVEN" , "2024-12-01"},
                { "V0PROP_NRPRIPARATZ" , "0"},
                { "V0PROP_QTDPARATZ" , "0"},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0PROP_TIMESTAMP" , "2023-11-10 01:39:28.235"},
                { "V0PROP_DTMINVEN" , "2023-12-06"},
                { "V0PROP_DTQITBCO_1YEAR" , "2024-11-06"},
                { "V0PROP_CODOPER" , "106"},
                { "V0PROP_DTADMISSAO" , "1900-01-01"},
                { "V0PROP_OCORHIST" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("VG1853B_CPROPVA", q3);

            #endregion

            #region R0000_00_PRINCIPAL_DB_SELECT_4_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0BANC_NRTIT" , "85172300176"}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_4_Query1", q4);

            #endregion

            #region R0000_00_PRINCIPAL_DB_UPDATE_5_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0BANC_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_UPDATE_5_Update1", q5);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NRPARCEL1" , "1"}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0SUBG_NUM_APOLICE" , "3009300012344"},
                { "V0SUBG_SIT_REGISTRO" , "1"},
                { "V0SUBG_TIPO_FATURA" , "2"},
                { "V0SUBG_FORMA_FATURA" , "2"},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q7);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0PRDVG_ESTR_COBR" , ""},
                { "V0PRDVG_ORIG_PRODU" , "ESPE1"},
                { "V0PRDVG_TEM_SAF" , ""},
                { "V0PRDVG_TEM_IGPM" , ""},
                { "V0PRDVG_CODPRODAZ" , ""},
                { "V0PRDVG_OPCAOCAP" , ""},
                { "V0PRDVG_COBERADIC_PREMIO" , ""},
                { "V0PRDVG_CUSTOCAP_TOTAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q8);

            #endregion

            #region R1000_10_LEITURA_RAMO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_RAMO" , "93"}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_10_LEITURA_RAMO_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1000_10_LEITURA_RAMO_DB_SELECT_2_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_DTTERVIG" , "2024-10-10"}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_10_LEITURA_RAMO_DB_SELECT_2_Query1", q10);

            #endregion

            #region R1000_10_LEITURA_RAMO_DB_SELECT_3_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_CODCONV" , "6088"},
                { "V0CONV_CCRED" , "9020"},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_10_LEITURA_RAMO_DB_SELECT_3_Query1", q11);

            #endregion

            #region VG1853B_CATRASO

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "HOST_PARCELA_ATRASO" , "1"}
            });
            AppSettings.TestSet.DynamicData.Add("VG1853B_CATRASO", q12);

            #endregion

            #region R1000_10_LEITURA_RAMO_DB_UPDATE_4_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRPRIPARATZ" , ""},
                { "V0PROP_DTPROXVEN" , ""},
                { "V0PROP_QTDPARATZ" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0PROP_OCORHIST" , ""},
                { "V0PROP_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_10_LEITURA_RAMO_DB_UPDATE_4_Update1", q13);

            #endregion

            #region R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_OPCAOPAG" , "1"},
                { "V0OPCP_PERIPGTO" , "1"},
                { "V0OPCP_DIA_DEBITO" , "1"},
                { "V0OPCP_AGECTADEB" , "3189"},
                { "V0OPCP_OPRCTADEB" , "3701"},
                { "V0OPCP_NUMCTADEB" , "21276"},
                { "V0OPCP_DIGCTADEB" , "3"},
                { "V0OPCP_CARTAO_CRED" , ""},
            });
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_OPCAOPAG" , "2"},
                { "V0OPCP_PERIPGTO" , "2"},
                { "V0OPCP_DIA_DEBITO" , "2"},
                { "V0OPCP_AGECTADEB" , "3190"},
                { "V0OPCP_OPRCTADEB" , "3702"},
                { "V0OPCP_NUMCTADEB" , "21277"},
                { "V0OPCP_DIGCTADEB" , "3"},
                { "V0OPCP_CARTAO_CRED" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0HICB_DTVENCTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1", q15);

            #endregion

            #region R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_VLPREMIO" , "38.68"},
                { "V0COBP_PRMVG" , "38.68"},
                { "V0COBP_PRMAP" , "0"},
                { "V0COBP_QTTITCAP" , "1"},
                { "V0COBP_VLCUSTCAP" , "9"},
                { "V0COBP_VLCUSTCDG" , "0"},
                { "V0COBP_VLCUSTAUXF" , "0"},
                { "V0COBP_CODOPER" , "106"},
            });
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_VLPREMIO" , "39.68"},
                { "V0COBP_PRMVG" , "39.68"},
                { "V0COBP_PRMAP" , "0"},
                { "V0COBP_QTTITCAP" , "2"},
                { "V0COBP_VLCUSTCAP" , "10"},
                { "V0COBP_VLCUSTCDG" , "0"},
                { "V0COBP_VLCUSTAUXF" , "0"},
                { "V0COBP_CODOPER" , "1076"},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1", q16);

            #endregion

            #region R1200_10_GERA_PARCELAS_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_PRMTOTANT" , "1"}
            });
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_PRMTOTANT" , "2"}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_10_GERA_PARCELAS_DB_SELECT_1_Query1", q17);

            #endregion

            #region R1200_10_GERA_PARCELAS_DB_INSERT_2_Insert1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "WHOST_PRMVG_W" , ""},
                { "WHOST_PRMAP_W" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0PARC_SITUACAO" , ""},
                { "V0PARC_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_10_GERA_PARCELAS_DB_INSERT_2_Insert1", q18);

            #endregion

            #region R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0OPCP_AGECTADEB" , ""},
                { "V0OPCP_OPRCTADEB" , ""},
                { "V0OPCP_NUMCTADEB" , ""},
                { "V0OPCP_DIGCTADEB" , ""},
                { "V0HICB_DTVENCTO" , ""},
                { "WHOST_VLPREMIO_W" , ""},
                { "HOST_CODCONV" , ""},
                { "V0OPCP_CARTAO_CRED" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1", q19);

            #endregion

            #region R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0BANC_NRTIT" , ""},
                { "V0HICB_DTVENCTO" , ""},
                { "WHOST_VLPREMIO_W" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0HICB_SITUACAO" , ""},
                { "V0HICB_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1", q20);

            #endregion

            #region VG1853B_CDIFPAR

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0DIFP_NRPARCEL" , ""},
                { "V0DIFP_CODOPER" , ""},
                { "V0DIFP_VLPRMTOT" , ""},
                { "V0DIFP_PRMDIFVG" , ""},
                { "V0DIFP_PRMDIFAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG1853B_CDIFPAR", q21);

            #endregion

            #region R1500_10_UPDATE_DB_UPDATE_1_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRPARCEL" , ""},
                { "V3DIFP_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_10_UPDATE_DB_UPDATE_1_Update1", q22);

            #endregion

            #region R1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1", q23);

            #endregion

            #region R1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V0CDGC_VLCUSTCDG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1", q24);

            #endregion

            #region R1600_00_VERIFICA_REPASSE_DB_SELECT_3_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V0SAFC_VLCUSTSAF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_VERIFICA_REPASSE_DB_SELECT_3_Query1", q25);

            #endregion

            #region R1650_00_REPASSA_CDG_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V0RCDG_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1650_00_REPASSA_CDG_DB_SELECT_1_Query1", q26);

            #endregion

            #region R1650_00_REPASSA_CDG_DB_INSERT_2_Insert1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RCDG_DTREFER" , ""},
                { "V0CDGC_VLCUSTCDG" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V1SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1650_00_REPASSA_CDG_DB_INSERT_2_Insert1", q27);

            #endregion

            #region R1670_00_REPASSA_SAF_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V0RSAF_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1670_00_REPASSA_SAF_DB_SELECT_1_Query1", q28);

            #endregion

            #region R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RSAF_DTREFER" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0SAFC_VLCUSTSAF" , ""},
                { "V0RSAF_CODOPER" , ""},
                { "V0PROP_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1", q29);

            #endregion

            #region R1700_10_LOOP_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG" , "2023-01-01"}
            });
            q30.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG" , "2022-01-02"}
            });
            AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_DB_SELECT_1_Query1", q30);

            #endregion

            #region R1700_10_LOOP_DB_SELECT_2_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_DTVENCTO_PAR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_DB_SELECT_2_Query1", q31);

            #endregion

            #region R1700_10_LOOP_DB_SELECT_3_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_PERIPGTO_ANT" , "1"}
            });
            q32.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_PERIPGTO_ANT" , "2"}
            });
            AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_DB_SELECT_3_Query1", q32);

            #endregion

            #region R1700_10_LOOP_DB_SELECT_4_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG" , "2021-10-10"},
                { "WHOST_DTTERVIG_ORIG" , "2021-10-11"},
                { "WHOST_DTTERVIG" , "2021-10-11"},
                { "WHOST_DTINIVIG_NEW" , "2021-10-12"},
                { "WHOST_DTINIVIG_NEW2" , "2021-10-13"},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_DB_SELECT_4_Query1", q33);

            #endregion

            #region R1700_10_LOOP_DB_SELECT_5_Query1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG" , "2021-10-10"},
                { "WHOST_DTTERVIG_ORIG" , "2021-10-11"},
                { "WHOST_DTTERVIG" , "2021-10-11"},
                { "WHOST_DTINIVIG_NEW" , "2021-10-12"},
                { "WHOST_DTINIVIG_NEW2" , "2021-10-13"},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_DB_SELECT_5_Query1", q34);

            #endregion

            #region R1700_10_LOOP_DB_SELECT_6_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG" , "2021-10-10"},
                { "WHOST_DTTERVIG_ORIG" , "2021-10-11"},
                { "WHOST_DTTERVIG" , "2021-10-11"},
                { "WHOST_DTINIVIG_NEW" , "2021-10-12"},
                { "WHOST_DTINIVIG_NEW2" , "2021-10-13"},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_DB_SELECT_6_Query1", q35);

            #endregion

            #region R1700_10_LOOP_DB_SELECT_7_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , "777777"},
                { "HISCOBPR_OCORR_HISTORICO" , "12"},
                { "HISCOBPR_DATA_INIVIGENCIA" , "2024-10-10"},
                { "HISCOBPR_DATA_TERVIGENCIA" , "2024-11-10"},
                { "HISCOBPR_IMPSEGUR" , "1"},
                { "HISCOBPR_QUANT_VIDAS" , "1"},
                { "HISCOBPR_IMPSEGIND" , "1"},
                { "HISCOBPR_COD_OPERACAO" , "2"},
                { "HISCOBPR_OPCAO_COBERTURA" , "3"},
                { "HISCOBPR_IMP_MORNATU" , "1"},
                { "HISCOBPR_IMPMORACID" , "3"},
                { "HISCOBPR_IMPINVPERM" , "4"},
                { "HISCOBPR_IMPAMDS" , "5"},
                { "HISCOBPR_IMPDH" , "6"},
                { "HISCOBPR_IMPDIT" , "7"},
                { "HISCOBPR_VLPREMIO" , "123"},
                { "HISCOBPR_PRMVG" , "123"},
                { "HISCOBPR_PRMAP" , "456"},
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , "6"},
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , "7"},
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , "77"},
                { "HISCOBPR_IMPSEGCDG" , "8"},
                { "HISCOBPR_VLCUSTCDG" , "87"},
                { "HISCOBPR_COD_USUARIO" , "1"},
                { "HISCOBPR_IMPSEGAUXF" , "1"},
                { "HISCOBPR_VLCUSTAUXF" , "22"},
                { "HISCOBPR_PRMDIT" , "66"},
                { "HISCOBPR_QTMDIT" , "1"},
            });
            q36.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , "777777"},
                { "HISCOBPR_OCORR_HISTORICO" , "12"},
                { "HISCOBPR_DATA_INIVIGENCIA" , "2024-10-10"},
                { "HISCOBPR_DATA_TERVIGENCIA" , "2024-11-10"},
                { "HISCOBPR_IMPSEGUR" , "1"},
                { "HISCOBPR_QUANT_VIDAS" , "1"},
                { "HISCOBPR_IMPSEGIND" , "1"},
                { "HISCOBPR_COD_OPERACAO" , "2"},
                { "HISCOBPR_OPCAO_COBERTURA" , "3"},
                { "HISCOBPR_IMP_MORNATU" , "1"},
                { "HISCOBPR_IMPMORACID" , "3"},
                { "HISCOBPR_IMPINVPERM" , "4"},
                { "HISCOBPR_IMPAMDS" , "5"},
                { "HISCOBPR_IMPDH" , "6"},
                { "HISCOBPR_IMPDIT" , "7"},
                { "HISCOBPR_VLPREMIO" , "123"},
                { "HISCOBPR_PRMVG" , "123"},
                { "HISCOBPR_PRMAP" , "456"},
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , "6"},
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , "7"},
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , "77"},
                { "HISCOBPR_IMPSEGCDG" , "8"},
                { "HISCOBPR_VLCUSTCDG" , "87"},
                { "HISCOBPR_COD_USUARIO" , "1"},
                { "HISCOBPR_IMPSEGAUXF" , "1"},
                { "HISCOBPR_VLCUSTAUXF" , "22"},
                { "HISCOBPR_PRMDIT" , "66"},
                { "HISCOBPR_QTMDIT" , "1"},
            });

            AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_DB_SELECT_7_Query1", q36);

            #endregion

            #region R1700_10_LOOP_DB_UPDATE_8_Update1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTTERVIG" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_DB_UPDATE_8_Update1", q37);

            #endregion

            #region R1700_10_LOOPDB_INSERT_9_Insert1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , "13456"},
                { "HISCOBPR_OCORR_HISTORICO" , "2"},
                { "HISCOBPR_DATA_INIVIGENCIA" , "2024-10-10"},
                { "HISCOBPR_DATA_TERVIGENCIA" , "2024-10-11"},
                { "HISCOBPR_IMPSEGUR" , ""},
                { "HISCOBPR_QUANT_VIDAS" , "3"},
                { "HISCOBPR_IMPSEGIND" , "1"},
                { "HISCOBPR_COD_OPERACAO" , "4"},
                { "HISCOBPR_OPCAO_COBERTURA" , "5"},
                { "HISCOBPR_IMP_MORNATU" , "6"},
                { "HISCOBPR_IMPMORACID" , "4"},
                { "HISCOBPR_IMPINVPERM" , "3"},
                { "HISCOBPR_IMPAMDS" , "1"},
                { "HISCOBPR_IMPDH" , "1"},
                { "HISCOBPR_IMPDIT" , "1"},
                { "HISCOBPR_VLPREMIO" , "56.56"},
                { "HISCOBPR_PRMVG" , "57.57"},
                { "HISCOBPR_PRMAP" , "77.77"},
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , "6"},
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , "7"},
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , "12.12"},
                { "HISCOBPR_IMPSEGCDG" , "7"},
                { "HISCOBPR_VLCUSTCDG" , "8"},
                { "HISCOBPR_COD_USUARIO" , "2"},
                { "HISCOBPR_IMPSEGAUXF" , "8"},
                { "HISCOBPR_VLCUSTAUXF" , "23.23"},
                { "HISCOBPR_PRMDIT" , "12.12"},
                { "HISCOBPR_QTMDIT" , "44.33"},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_10_LOOPDB_INSERT_9_Insert1", q38);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG1853B_Tests_FactReturnCode_00_DB_UPDATE_5_Update1()
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
                var program = new VG1853B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Fact]
        public static void VG1853B_Tests_Fact_ErroGerarParcelaReturnCode_99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1
                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NRPARCEL1" , "1"}
                },new SQLCA(-803));
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q6);
                #endregion
                #endregion
                var program = new VG1853B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Fact]
        public static void VG1853B_Tests_FactReturnCode_99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region VG1853B_CPROPVA
                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NUM_APOLICE" , "3009300012344"},
                { "V0PROP_CODSUBES" , "2"},
                { "V0PROP_NRCERTIF" , "73189110446483"},
                { "V0PROP_CODPRODU" , "9721"},
                { "V0PROP_CODCLIEN" , "36578578"},
                { "V0PROP_NRPARCEL" , "1"},
                { "V0PROP_SITUACAO" , "2"},
                { "V0PROP_DTQITBCO" , "2023-11-06"},
                { "V0PROP_DTVENCTO" , "2023-12-01"},
                { "V0PROP_DTPROXVEN" , "2024-01-01"},
                { "V0PROP_NRPRIPARATZ" , "0"},
                { "V0PROP_QTDPARATZ" , "0"},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0PROP_TIMESTAMP" , "2023-11-10 01:39:28.235"},
                { "V0PROP_DTMINVEN" , "2023-12-06"},
                { "V0PROP_DTQITBCO_1YEAR" , "2024-11-06"},
                { "V0PROP_CODOPER" , "106"},
                { "V0PROP_DTADMISSAO" , "1900-01-01"},
                { "V0PROP_OCORHIST" , "1"},
            }, new SQLCA(-803));
                AppSettings.TestSet.DynamicData.Remove("VG1853B_CPROPVA");
                AppSettings.TestSet.DynamicData.Add("VG1853B_CPROPVA", q3);
                #endregion

                #endregion
                var program = new VG1853B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }

    }
}