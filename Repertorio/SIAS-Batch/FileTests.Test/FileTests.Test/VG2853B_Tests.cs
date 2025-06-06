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
using static Code.VG2853B;

namespace FileTests.Test
{
    [Collection("VG2853B_Tests")]
   [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
   [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
   public class VG2853B_Tests
   {
       //é de extrema importancia que este método seja modificado com cautela, 
       //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
       public static void Load_Parameters()
       {
           #region PARAMETERS
           #region R0000_00_PRINCIPAL_Query1

           var q0 = new DynamicData();
           q0.AddDynamic(new Dictionary<string, string>{
               { "V1SIST_DTVENFIM_CN" , "2024-12-01"},
               { "V1SIST_DTVENFIM_DB" , ""},
               { "V1SIST_DTMOVABE" , ""},
               { "V1SIST_DTTERCOT" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_Query1", q0);

           #endregion

           #region R0000_00_PRINCIPAL_Query2

           var q1 = new DynamicData();
           q1.AddDynamic(new Dictionary<string, string>{
               { "V0COTA_DTINIVIG" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_Query2", q1);

           #endregion

           #region R0000_00_PRINCIPAL_Query3

           var q2 = new DynamicData();
           q2.AddDynamic(new Dictionary<string, string>{
               { "WHOST_MIN_DTPROXVEN" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_Query3", q2);

           #endregion

           #region VG2853B_CPROPVA

           var q3 = new DynamicData();
           q3.AddDynamic(new Dictionary<string, string>{
               { "V0PROP_NUM_APOLICE" , "93010000890"},
               { "V0PROP_CODSUBES" , "13"},
               { "V0PROP_NRCERTIF" , "10001658775"},
               { "V0PROP_CODPRODU" , "9304"},
               { "V0PROP_CODCLIEN" , "176611"},
               { "V0PROP_NRPARCEL" , "0"},
               { "V0PROP_SITUACAO" , "3"},
               { "V0PROP_DTQITBCO" , "2022-01-01"},
               { "V0PROP_DTVENCTO" , "2024-10-31"},
               { "V0PROP_DTPROXVEN" , "2024-11-30"},
               { "V0PROP_NRPRIPARATZ" , "0"},
               { "V0PROP_QTDPARATZ" , "0"},
               { "V0PROP_NRMATRFUN" , "181266"},
               { "V0PROP_TIMESTAMP" , "2024-02-02T18:38:10.461Z"},
               { "V0PROP_DTMINVEN" , "2024-08-01"},
               { "V0PROP_DTQITBCO_1YEAR" , "2023-08-01"},
               { "V0PROP_CODOPER" , "201"},
               { "V0PROP_DTADMISSAO" , "1900-01-01"},
               { "V0PROP_OCORHIST" , "1"},
           });
           AppSettings.TestSet.DynamicData.Add("VG2853B_CPROPVA", q3);

           #endregion

           #region R0000_00_PRINCIPAL_Query4

           var q4 = new DynamicData();
           q4.AddDynamic(new Dictionary<string, string>{
               { "V0BANC_NRTIT" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_Query4", q4);

           #endregion

           #region R0000_00_PRINCIPAL_Update5

           var q5 = new DynamicData();
           q5.AddDynamic(new Dictionary<string, string>{
               { "V0BANC_NRTIT" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_Update5", q5);

           #endregion

           #region R1000_00_PROCESSA_REGISTRO_Query1

           var q6 = new DynamicData();
           q6.AddDynamic(new Dictionary<string, string>{
               { "V0SUBG_NUM_APOLICE" , ""},
               { "V0SUBG_SIT_REGISTRO" , ""},
               { "V0SUBG_TIPO_FATURA" , ""},
               { "V0SUBG_FORMA_FATURA" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_Query1", q6);

           #endregion

           #region R1000_00_PROCESSA_REGISTRO_Query2

           var q7 = new DynamicData();
           q7.AddDynamic(new Dictionary<string, string>{
               { "V0PRDVG_ESTR_COBR" , ""},
               { "V0PRDVG_ORIG_PRODU" , ""},
               { "V0PRDVG_TEM_SAF" , ""},
               { "V0PRDVG_TEM_IGPM" , ""},
               { "V0PRDVG_CODPRODAZ" , ""},
               { "V0PRDVG_OPCAOCAP" , ""},
               { "V0PRDVG_COBERADIC_PREMIO" , ""},
               { "V0PRDVG_CUSTOCAP_TOTAL" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_Query2", q7);

           #endregion

           #region R1000_10_LEITURA_RAMO_Query1

           var q8 = new DynamicData();
           q8.AddDynamic(new Dictionary<string, string>{
               { "V0APOL_RAMO" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R1000_10_LEITURA_RAMO_Query1", q8);

           #endregion

           #region R1000_10_LEITURA_RAMO_Query2

           var q9 = new DynamicData();
           q9.AddDynamic(new Dictionary<string, string>{
               { "V0ENDO_DTTERVIG" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R1000_10_LEITURA_RAMO_Query2", q9);

           #endregion

           #region R1000_10_LEITURA_RAMO_Query3

           var q10 = new DynamicData();
           q10.AddDynamic(new Dictionary<string, string>{
               { "V0CONV_CODCONV" , ""},
               { "V0CONV_CCRED" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1000_10_LEITURA_RAMO_Query3", q10);

           #endregion

           #region VG2853B_CATRASO

           var q11 = new DynamicData();
           q11.AddDynamic(new Dictionary<string, string>{
               { "HOST_PARCELA_ATRASO" , "1"}
           });
           AppSettings.TestSet.DynamicData.Add("VG2853B_CATRASO", q11);

           #endregion

           #region R1000_10_LEITURA_RAMO_Update4

           var q12 = new DynamicData();
           q12.AddDynamic(new Dictionary<string, string>{
               { "V0PROP_NRPRIPARATZ" , ""},
               { "V0PROP_DTPROXVEN" , ""},
               { "V0PROP_QTDPARATZ" , ""},
               { "V0PROP_NRPARCEL" , ""},
               { "V0PROP_SITUACAO" , ""},
               { "V0PROP_DTVENCTO" , ""},
               { "V0PROP_OCORHIST" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1000_10_LEITURA_RAMO_Update4", q12);

           #endregion

           #region R1000_90_LEITURA_Update1

           var q13 = new DynamicData();
           q13.AddDynamic(new Dictionary<string, string>{
               { "V0BANC_NRTIT" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R1000_90_LEITURA_Update1", q13);

           #endregion

           #region R1200_00_GERA_PARCELAS_Query1

           var q14 = new DynamicData();
           q14.AddDynamic(new Dictionary<string, string>{
               { "V0OPCP_OPCAOPAG" , ""},
               { "V0OPCP_PERIPGTO" , ""},
               { "V0OPCP_DIA_DEBITO" , ""},
               { "V0OPCP_AGECTADEB" , ""},
               { "V0OPCP_OPRCTADEB" , ""},
               { "V0OPCP_NUMCTADEB" , ""},
               { "V0OPCP_DIGCTADEB" , ""},
               { "V0OPCP_CARTAO_CRED" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_Query1", q14);

           #endregion

           #region R1200_00_GERA_PARCELAS_Query2

           var q15 = new DynamicData();
           q15.AddDynamic(new Dictionary<string, string>{
               { "V0HICB_DTVENCTO" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_Query2", q15);

           #endregion

           #region R1200_00_GERA_PARCELAS_Query3

           var q16 = new DynamicData();
           q16.AddDynamic(new Dictionary<string, string>{
               { "V0COBP_VLPREMIO" , "0"},
               { "V0COBP_PRMVG" , "130"},
               { "V0COBP_PRMAP" , "140"},
               { "V0COBP_QTTITCAP" , "1"},
               { "V0COBP_VLCUSTCAP" , "100"},
               { "V0COBP_VLCUSTCDG" , "100"},
               { "V0COBP_VLCUSTAUXF" , ""},
               { "V0COBP_CODOPER" , "101"},
           });
           q16.AddDynamic(new Dictionary<string, string>{
               { "V0COBP_VLPREMIO" , "0"},
               { "V0COBP_PRMVG" , "130"},
               { "V0COBP_PRMAP" , "140"},
               { "V0COBP_QTTITCAP" , "1"},
               { "V0COBP_VLCUSTCAP" , "100"},
               { "V0COBP_VLCUSTCDG" , "100"},
               { "V0COBP_VLCUSTAUXF" , ""},
               { "V0COBP_CODOPER" , "101"},
           });
           AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_Query3", q16);

           #endregion

           #region R1200_10_GERA_PARCELAS_Query1

           var q17 = new DynamicData();
           q17.AddDynamic(new Dictionary<string, string>{
               { "V0PARC_PRMTOTANT" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R1200_10_GERA_PARCELAS_Query1", q17);

           #endregion

           #region R1200_10_GERA_PARCELAS_Query2

           var q18 = new DynamicData();
           q18.AddDynamic(new Dictionary<string, string>{
               { "DESCON_PERC" , "11"}
           });
           AppSettings.TestSet.DynamicData.Add("R1200_10_GERA_PARCELAS_Query2", q18);

           #endregion

           #region R1200_10_GERA_PARCELAS_Insert3

           var q19 = new DynamicData();
           q19.AddDynamic(new Dictionary<string, string>{
               { "V0PROP_NRCERTIF" , ""},
               { "V0PROP_NRPARCEL" , ""},
               { "V0PROP_DTPROXVEN" , ""},
               { "DESCON_PRMVG" , ""},
               { "DESCON_PRMAP" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1200_10_GERA_PARCELAS_Insert3", q19);

           #endregion

           #region R1200_10_GERA_PARCELAS_Update4

           var q20 = new DynamicData();
           q20.AddDynamic(new Dictionary<string, string>{
               { "V0PROP_NRCERTIF" , ""},
               { "V0PROP_NRPARCEL" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1200_10_GERA_PARCELAS_Update4", q20);

           #endregion

           #region R1200_10_GERA_PARCELAS_Update5

           var q21 = new DynamicData();
           q21.AddDynamic(new Dictionary<string, string>{
               { "V0PROP_NRCERTIF" , ""},
               { "V0PROP_NRPARCEL" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1200_10_GERA_PARCELAS_Update5", q21);

           #endregion

           #region R1200_10_GERA_PARCELAS_Insert6

           var q22 = new DynamicData();
           q22.AddDynamic(new Dictionary<string, string>{
               { "V0PROP_NRCERTIF" , ""},
               { "V0PROP_NRPARCEL" , ""},
               { "V0PROP_DTVENCTO" , ""},
               { "WHOST_PRMVG" , ""},
               { "WHOST_PRMAP" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1200_10_GERA_PARCELAS_Insert6", q22);

           #endregion

           #region R1200_10_GERA_PARCELAS_Insert7

           var q23 = new DynamicData();
           q23.AddDynamic(new Dictionary<string, string>{
               { "V0PROP_NRCERTIF" , ""},
               { "V0PROP_NRPARCEL" , ""},
               { "V0PROP_DTVENCTO" , ""},
               { "WHOST_PRMVG_W" , ""},
               { "WHOST_PRMAP_W" , ""},
               { "V0OPCP_OPCAOPAG" , ""},
               { "V0PARC_SITUACAO" , ""},
               { "V0PARC_OCORHIST" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1200_10_GERA_PARCELAS_Insert7", q23);

           #endregion

           #region R1300_00_GERA_DEBITO_Insert1

           var q24 = new DynamicData();
           q24.AddDynamic(new Dictionary<string, string>{
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
           AppSettings.TestSet.DynamicData.Add("R1300_00_GERA_DEBITO_Insert1", q24);

           #endregion

           #region R1400_00_GERA_HIST_COBRANCA_Insert1

           var q25 = new DynamicData();
           q25.AddDynamic(new Dictionary<string, string>{
               { "V0PROP_NRCERTIF" , ""},
               { "V0PROP_NRPARCEL" , ""},
               { "V0BANC_NRTIT" , ""},
               { "V0HICB_DTVENCTO" , ""},
               { "WHOST_VLPREMIO_W" , ""},
               { "V0OPCP_OPCAOPAG" , ""},
               { "V0HICB_SITUACAO" , ""},
               { "V0HICB_CODOPER" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1400_00_GERA_HIST_COBRANCA_Insert1", q25);

           #endregion

           #region VG2853B_CDIFPAR

           var q26 = new DynamicData();
           q26.AddDynamic(new Dictionary<string, string>{
               { "V0DIFP_NRPARCEL" , ""},
               { "V0DIFP_CODOPER" , ""},
               { "V0DIFP_VLPRMTOT" , ""},
               { "V0DIFP_PRMDIFVG" , ""},
               { "V0DIFP_PRMDIFAP" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("VG2853B_CDIFPAR", q26);

           #endregion

           #region R1500_10_UPDATE_Update1

           var q27 = new DynamicData();
           q27.AddDynamic(new Dictionary<string, string>{
               { "V0PROP_NRPARCEL" , ""},
               { "V3DIFP_CODOPER" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1500_10_UPDATE_Update1", q27);

           #endregion

           #region R1600_00_VERIFICA_REPASSE_Update1

           var q28 = new DynamicData();
           q28.AddDynamic(new Dictionary<string, string>{
               { "V0PROP_NRCERTIF" , ""},
               { "V0PROP_NRPARCEL" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1600_00_VERIFICA_REPASSE_Update1", q28);

           #endregion

           #region R1600_00_VERIFICA_REPASSE_Query2

           var q29 = new DynamicData();
           q29.AddDynamic(new Dictionary<string, string>{
               { "V0CDGC_VLCUSTCDG" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R1600_00_VERIFICA_REPASSE_Query2", q29);

           #endregion

           #region R1600_00_VERIFICA_REPASSE_Query3

           var q30 = new DynamicData();
           q30.AddDynamic(new Dictionary<string, string>{
               { "V0SAFC_VLCUSTSAF" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R1600_00_VERIFICA_REPASSE_Query3", q30);

           #endregion

           #region R1650_00_REPASSA_CDG_Query1

           var q31 = new DynamicData();
           q31.AddDynamic(new Dictionary<string, string>{
               { "V0RCDG_SITUACAO" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R1650_00_REPASSA_CDG_Query1", q31);

           #endregion

           #region R1650_00_REPASSA_CDG_Insert2

           var q32 = new DynamicData();
           q32.AddDynamic(new Dictionary<string, string>{
               { "V0PROP_CODCLIEN" , ""},
               { "V0RCDG_DTREFER" , ""},
               { "V0CDGC_VLCUSTCDG" , ""},
               { "V0PROP_NRCERTIF" , ""},
               { "V0PROP_NRPARCEL" , ""},
               { "V1SIST_DTMOVABE" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1650_00_REPASSA_CDG_Insert2", q32);

           #endregion

           #region R1670_00_REPASSA_SAF_Query1

           var q33 = new DynamicData();
           q33.AddDynamic(new Dictionary<string, string>{
               { "V0RSAF_SITUACAO" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R1670_00_REPASSA_SAF_Query1", q33);

           #endregion

           #region R1675_00_INSERT_V0HISTREPSAF_Insert1

           var q34 = new DynamicData();
           q34.AddDynamic(new Dictionary<string, string>{
               { "V0PROP_CODCLIEN" , ""},
               { "V0RSAF_DTREFER" , ""},
               { "V0PROP_NRCERTIF" , ""},
               { "V0PROP_NRPARCEL" , ""},
               { "V0PROP_NRMATRFUN" , ""},
               { "V0SAFC_VLCUSTSAF" , ""},
               { "V0RSAF_CODOPER" , ""},
               { "V0PROP_DTVENCTO" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1675_00_INSERT_V0HISTREPSAF_Insert1", q34);

           #endregion

           #region R1700_10_LOOP_Query1

           var q35 = new DynamicData();
           q35.AddDynamic(new Dictionary<string, string>{
               { "WHOST_DTINIVIG" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_Query1", q35);

           #endregion

           #region R1700_10_LOOP_Query2

           var q36 = new DynamicData();
           q36.AddDynamic(new Dictionary<string, string>{
               { "V0PARC_DTVENCTO_PAR" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_Query2", q36);

           #endregion

           #region R1700_10_LOOP_Query3

           var q37 = new DynamicData();
           q37.AddDynamic(new Dictionary<string, string>{
               { "V0OPCP_PERIPGTO_ANT" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_Query3", q37);

           #endregion

           #region R1700_10_LOOP_Query4

           var q38 = new DynamicData();
           q38.AddDynamic(new Dictionary<string, string>{
               { "WHOST_DTINIVIG" , ""},
               { "WHOST_DTTERVIG_ORIG" , ""},
               { "WHOST_DTTERVIG" , ""},
               { "WHOST_DTINIVIG_NEW" , ""},
               { "WHOST_DTINIVIG_NEW2" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_Query4", q38);

           #endregion

           #region R1700_10_LOOP_Query5

           var q39 = new DynamicData();
           q39.AddDynamic(new Dictionary<string, string>{
               { "WHOST_DTINIVIG" , ""},
               { "WHOST_DTTERVIG_ORIG" , ""},
               { "WHOST_DTTERVIG" , ""},
               { "WHOST_DTINIVIG_NEW" , ""},
               { "WHOST_DTINIVIG_NEW2" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_Query5", q39);

           #endregion

           #region R1700_10_LOOP_Query6

           var q40 = new DynamicData();
           q40.AddDynamic(new Dictionary<string, string>{
               { "WHOST_DTINIVIG" , ""},
               { "WHOST_DTTERVIG_ORIG" , ""},
               { "WHOST_DTTERVIG" , ""},
               { "WHOST_DTINIVIG_NEW" , ""},
               { "WHOST_DTINIVIG_NEW2" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_Query6", q40);

           #endregion

           #region R1700_10_LOOP_Query7

           var q41 = new DynamicData();
           q41.AddDynamic(new Dictionary<string, string>{
           { "HISCOBPR_NUM_CERTIFICADO" , "211523067"},
           { "HISCOBPR_OCORR_HISTORICO" , "1"},
           { "HISCOBPR_DATA_INIVIGENCIA" , "2000-07-21"},
           { "HISCOBPR_DATA_TERVIGENCIA" , "9999-12-31"},
           { "HISCOBPR_IMPSEGUR" , "12000.00"},
           { "HISCOBPR_QUANT_VIDAS" , "1"},
           { "HISCOBPR_IMPSEGIND" , "12000.00"},
           { "HISCOBPR_COD_OPERACAO" , "101"},
           { "HISCOBPR_OPCAO_COBERTURA" , "L"},
           { "HISCOBPR_IMP_MORNATU" , "12000.00"},
           { "HISCOBPR_IMPMORACID" , "24000.00"},
           { "HISCOBPR_IMPINVPERM" , "12000.00"},
           { "HISCOBPR_IMPAMDS" , "0.00"},
           { "HISCOBPR_IMPDH" , "0.00"},
           { "HISCOBPR_IMPDIT" , "0.00"},
           { "HISCOBPR_VLPREMIO" , "75.50"},
           { "HISCOBPR_PRMVG" , "52.80"},
           { "HISCOBPR_PRMAP" , "22.70"},
           { "HISCOBPR_QTDE_TIT_CAPITALIZ" , "0"},
           { "HISCOBPR_VAL_TIT_CAPITALIZ" , "0.00"},
           { "HISCOBPR_VAL_CUSTO_CAPITALI" , "0.00"},
           { "HISCOBPR_IMPSEGCDG" , "0.00"},
           { "HISCOBPR_VLCUSTCDG" , "0.00"},
           { "HISCOBPR_COD_USUARIO" , "MARLENE "},
           { "HISCOBPR_IMPSEGAUXF" , ""},
           { "HISCOBPR_VLCUSTAUXF" , ""},
           { "HISCOBPR_PRMDIT" , ""},
           { "HISCOBPR_QTMDIT" , ""},
           });
           q41.AddDynamic(new Dictionary<string, string>{
           { "HISCOBPR_NUM_CERTIFICADO" , "211523067"},
           { "HISCOBPR_OCORR_HISTORICO" , "1"},
           { "HISCOBPR_DATA_INIVIGENCIA" , "2000-07-21"},
           { "HISCOBPR_DATA_TERVIGENCIA" , "9999-12-31"},
           { "HISCOBPR_IMPSEGUR" , "12000.00"},
           { "HISCOBPR_QUANT_VIDAS" , "1"},
           { "HISCOBPR_IMPSEGIND" , "12000.00"},
           { "HISCOBPR_COD_OPERACAO" , "101"},
           { "HISCOBPR_OPCAO_COBERTURA" , "L"},
           { "HISCOBPR_IMP_MORNATU" , "12000.00"},
           { "HISCOBPR_IMPMORACID" , "24000.00"},
           { "HISCOBPR_IMPINVPERM" , "12000.00"},
           { "HISCOBPR_IMPAMDS" , "0.00"},
           { "HISCOBPR_IMPDH" , "0.00"},
           { "HISCOBPR_IMPDIT" , "0.00"},
           { "HISCOBPR_VLPREMIO" , "75.50"},
           { "HISCOBPR_PRMVG" , "52.80"},
           { "HISCOBPR_PRMAP" , "22.70"},
           { "HISCOBPR_QTDE_TIT_CAPITALIZ" , "0"},
           { "HISCOBPR_VAL_TIT_CAPITALIZ" , "0.00"},
           { "HISCOBPR_VAL_CUSTO_CAPITALI" , "0.00"},
           { "HISCOBPR_IMPSEGCDG" , "0.00"},
           { "HISCOBPR_VLCUSTCDG" , "0.00"},
           { "HISCOBPR_COD_USUARIO" , "MARLENE "},
           { "HISCOBPR_IMPSEGAUXF" , ""},
           { "HISCOBPR_VLCUSTAUXF" , ""},
           { "HISCOBPR_PRMDIT" , ""},
           { "HISCOBPR_QTMDIT" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_Query7", q41);

           #endregion

           #region R1700_10_LOOP_Update8

           var q42 = new DynamicData();
           q42.AddDynamic(new Dictionary<string, string>{
               { "WHOST_DTTERVIG" , ""},
               { "V0PROP_NRCERTIF" , ""},
               { "V0PROP_OCORHIST" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_Update8", q42);

           #endregion

           #region R1700_10_LOOP_Insert9

           var q43 = new DynamicData();
           q43.AddDynamic(new Dictionary<string, string>{
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
               { "HISCOBPR_IMPSEGAUXF" , ""},
               { "HISCOBPR_VLCUSTAUXF" , ""},
               { "HISCOBPR_PRMDIT" , ""},
               { "HISCOBPR_QTMDIT" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_Insert9", q43);

           #endregion

           #endregion
       }

       [Fact]
       public static void VG2853B_Tests_Fact_ReturnCode_0()
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
               #region R1000_00_PROCESSA_REGISTRO_Query1

               var q6 = new DynamicData();
               q6.AddDynamic(new Dictionary<string, string>{
               { "V0SUBG_NUM_APOLICE" , "000019790324"},
               { "V0SUBG_SIT_REGISTRO" , "1"},
               { "V0SUBG_TIPO_FATURA" , "2"},
               { "V0SUBG_FORMA_FATURA" , "4"},
               });
               AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_Query1");
               AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_Query1", q6);

               #endregion
               #region R1000_00_PROCESSA_REGISTRO_Query2

               var q7 = new DynamicData();
               q7.AddDynamic(new Dictionary<string, string>{
               { "V0PRDVG_ESTR_COBR" , ""},
               { "V0PRDVG_ORIG_PRODU" , "EMPRE"},
               { "V0PRDVG_TEM_SAF" , "S"},
               { "V0PRDVG_TEM_IGPM" , ""},
               { "V0PRDVG_CODPRODAZ" , "PVD"},
               { "V0PRDVG_OPCAOCAP" , "0"},
               { "V0PRDVG_COBERADIC_PREMIO" , "N"},
               { "V0PRDVG_CUSTOCAP_TOTAL" , "N"},
               });
               AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_Query2");
               AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_Query2", q7);

               #endregion
               #region R1700_10_LOOP_Query1

               var q35 = new DynamicData();
               AppSettings.TestSet.DynamicData.Remove("R1700_10_LOOP_Query1");
               AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_Query1", q35);

               #endregion
               #region R1700_10_LOOP_Query4

               var q38 = new DynamicData();
               q38.AddDynamic(new Dictionary<string, string>{
               { "WHOST_DTINIVIG" , ""},
               { "WHOST_DTTERVIG_ORIG" , "2024-01-01"},
               { "WHOST_DTTERVIG" , ""},
               { "WHOST_DTINIVIG_NEW" , ""},
               { "WHOST_DTINIVIG_NEW2" , ""},
               });
               AppSettings.TestSet.DynamicData.Remove("R1700_10_LOOP_Query4");
               AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_Query4", q38);

               #endregion
               #region R1200_00_GERA_PARCELAS_Query1

               var q14 = new DynamicData();
               q14.AddDynamic(new Dictionary<string, string>{
               { "V0OPCP_OPCAOPAG" , "1"},
               { "V0OPCP_PERIPGTO" , "12"},
               { "V0OPCP_DIA_DEBITO" , "9"},
               { "V0OPCP_AGECTADEB" , "0001"},
               { "V0OPCP_OPRCTADEB" , "1"},
               { "V0OPCP_NUMCTADEB" , "145422"},
               { "V0OPCP_DIGCTADEB" , "1"},
               { "V0OPCP_CARTAO_CRED" , ""},
               });
               q14.AddDynamic(new Dictionary<string, string>{
               { "V0OPCP_OPCAOPAG" , "1"},
               { "V0OPCP_PERIPGTO" , "12"},
               { "V0OPCP_DIA_DEBITO" , "10"},
               { "V0OPCP_AGECTADEB" , "0001"},
               { "V0OPCP_OPRCTADEB" , "1"},
               { "V0OPCP_NUMCTADEB" , "145427"},
               { "V0OPCP_DIGCTADEB" , "2"},
               { "V0OPCP_CARTAO_CRED" , ""},
               });
               AppSettings.TestSet.DynamicData.Remove("R1200_00_GERA_PARCELAS_Query1");
               AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_Query1", q14);

               #endregion


               #region R1650_00_REPASSA_CDG_Query1

               var q31 = new DynamicData();
               AppSettings.TestSet.DynamicData.Remove("R1650_00_REPASSA_CDG_Query1");
               AppSettings.TestSet.DynamicData.Add("R1650_00_REPASSA_CDG_Query1", q31);

               #endregion
               #region R1670_00_REPASSA_SAF_Query1

               var q33 = new DynamicData();
               AppSettings.TestSet.DynamicData.Remove("R1670_00_REPASSA_SAF_Query1");
               AppSettings.TestSet.DynamicData.Add("R1670_00_REPASSA_SAF_Query1", q33);

               #endregion

               #region R1700_10_LOOP_Query3

               var q37 = new DynamicData();
               q37.AddDynamic(new Dictionary<string, string>{
               { "V0OPCP_PERIPGTO_ANT" , "1"}
               });
               q37.AddDynamic(new Dictionary<string, string>{
               { "V0OPCP_PERIPGTO_ANT" , "2"}
               });
               AppSettings.TestSet.DynamicData.Remove("R1700_10_LOOP_Query3");
               AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_Query3", q37);

               #endregion
               #endregion
               var program = new VG2853B();
               program.Execute();

               AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

               Assert.True(program.RETURN_CODE ==0);
               //R0000_00_PRINCIPAL_Update5
               var envList0 = AppSettings.TestSet.DynamicData["R0000_00_PRINCIPAL_Update5"].DynamicList;
               Assert.True(envList0[1].TryGetValue("V0BANC_NRTIT", out var val0r) && val0r.Contains("0"));

               //R1000_10_LEITURA_RAMO_Update4
               var envList1 = AppSettings.TestSet.DynamicData["R1000_10_LEITURA_RAMO_Update4"].DynamicList;
               Assert.True(envList1[1].TryGetValue("V0PROP_SITUACAO", out var val1r) && val1r.Contains("3"));

               //R1200_10_GERA_PARCELAS_Insert3
               var envList2 = AppSettings.TestSet.DynamicData["R1200_10_GERA_PARCELAS_Insert3"].DynamicList;
               Assert.True(envList2[1].TryGetValue("DESCON_PRMVG", out var val2r) && val2r.Contains("0000000001430.00"));
               Assert.True(envList2.Count > 1);
                
               //R1200_10_GERA_PARCELAS_Update4
               var envList3 = AppSettings.TestSet.DynamicData["R1200_10_GERA_PARCELAS_Update4"].DynamicList;
               Assert.True(envList3[1].TryGetValue("V0PROP_NRCERTIF", out var val3r) && val3r.Contains("000010001658775"));

               //R1200_10_GERA_PARCELAS_Insert7
               var envList4 = AppSettings.TestSet.DynamicData["R1200_10_GERA_PARCELAS_Insert7"].DynamicList;
               Assert.True(envList4[1].TryGetValue("V0PROP_NRCERTIF", out var val4r) && val4r.Contains("000010001658775"));
               Assert.True(envList4.Count > 1);

               //R1400_00_GERA_HIST_COBRANCA_Insert1
               var envList5 = AppSettings.TestSet.DynamicData["R1400_00_GERA_HIST_COBRANCA_Insert1"].DynamicList;
               Assert.True(envList5[1].TryGetValue("WHOST_VLPREMIO_W", out var val5r) && val5r.Contains("0000000000270.00"));
               Assert.True(envList5.Count > 1);

               //R1600_00_VERIFICA_REPASSE_Update1
               var envList6 = AppSettings.TestSet.DynamicData["R1600_00_VERIFICA_REPASSE_Update1"].DynamicList;
               Assert.True(envList6[1].TryGetValue("V0PROP_NRCERTIF", out var val6r) && val6r.Contains("000010001658775"));

               //R1650_00_REPASSA_CDG_Insert2
               var envList7 = AppSettings.TestSet.DynamicData["R1650_00_REPASSA_CDG_Insert2"].DynamicList;
               Assert.True(envList7[1].TryGetValue("V0PROP_CODCLIEN", out var val7r) && val7r.Contains("000176611"));
               Assert.True(envList7.Count > 1);

               //R1675_00_INSERT_V0HISTREPSAF_Insert1
               var envList8 = AppSettings.TestSet.DynamicData["R1675_00_INSERT_V0HISTREPSAF_Insert1"].DynamicList;
               Assert.True(envList8[1].TryGetValue("V0PROP_NRMATRFUN", out var val8r) && val8r.Contains("000000000181266"));
               Assert.True(envList8.Count > 1);

               //R1700_10_LOOP_Update8
               var envList9 = AppSettings.TestSet.DynamicData["R1700_10_LOOP_Update8"].DynamicList;
               Assert.True(envList9[1].TryGetValue("V0PROP_NRCERTIF", out var val9r) && val9r.Contains("000010001658775"));

               //R1700_10_LOOP_Insert9
               var envList10 = AppSettings.TestSet.DynamicData["R1700_10_LOOP_Insert9"].DynamicList;
               Assert.True(envList10[1].TryGetValue("HISCOBPR_NUM_CERTIFICADO", out var val10r) && val10r.Contains("000000211523067"));
               Assert.True(envList10.Count > 1);

           }
       }
       [Fact]
       public static void VG2853B_Tests_Fact_ReturnCode_99()
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
               #region VG2853B_CPROPVA

               var q3 = new DynamicData();
               q3.AddDynamic(new Dictionary<string, string>{
               { "V0PROP_NUM_APOLICE" , "93010000890"},
               { "V0PROP_CODSUBES" , "13"},
               { "V0PROP_NRCERTIF" , "10001658775"},
               { "V0PROP_CODPRODU" , "9304"},
               { "V0PROP_CODCLIEN" , "176611"},
               { "V0PROP_NRPARCEL" , "0"},
               });
               AppSettings.TestSet.DynamicData.Remove("VG2853B_CPROPVA");
               AppSettings.TestSet.DynamicData.Add("VG2853B_CPROPVA", q3);

               #endregion
               #endregion
               var program = new VG2853B();
               program.Execute();

               AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

               Assert.True(program.RETURN_CODE == 99);
           }
       }
       [Fact]
       public static void VG2853B_Tests_Fact_SemMovimento_ReturnCode_00()
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
               #region VG2853B_CPROPVA

               var q3 = new DynamicData();
               AppSettings.TestSet.DynamicData.Remove("VG2853B_CPROPVA");
               AppSettings.TestSet.DynamicData.Add("VG2853B_CPROPVA", q3);

               #endregion
               #endregion
               var program = new VG2853B();
               program.Execute();

               Assert.True(program.RETURN_CODE == 0);
           }
       }
   }
}