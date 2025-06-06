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
using static Code.VG0853B;

namespace FileTests.Test
{
    [Collection("VG0853B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG0853B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DT_15" , "2024-12-13"},
                { "V1SIST_DT_08" , "2023-07-27"},
                { "V1SIST_DTVENFIM_DB" , "2024-11-29"},
                { "V1SIST_DT_23_CYRELA" , "2024-12-21"},
                { "V1SIST_DTMOVABE" , "2023-07-19"},
                { "V1SIST_DTTERCOT" , "2023-06-19"},
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0000_00_PRINCIPAL_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0COTA_DTINIVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_2_Query1", q1);

            #endregion

            #region VG0853B_CPROPVA

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NUM_APOLICE" , "97010000889"},
                { "V0PROP_CODSUBES" , "3603"},
                { "V0PROP_NRCERTIF" , "100000266"},
                { "V0PROP_CODPRODU" , "9320"},
                { "V0PROP_CODCLIEN" , "4853934"},
                { "V0PROP_NRPARCEL" , "1"},
                { "V0PROP_SITUACAO" , "2"},
                { "V0PROP_DTQITBCO" , "0001-01-01"},
                { "V0PROP_DTVENCTO" , "0001-01-01"},
                { "V0PROP_DTPROXVEN" , "0001-02-15"},
                { "V0PROP_NRPRIPARATZ" , "0"},
                { "V0PROP_QTDPARATZ" , "0"},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0PROP_TIMESTAMP" , "2006-06-21T22,52,09.679Z"},
                { "V0PROP_DTMINVEN" , "0001-02-01"},
                { "V0PROP_DTQITBCO_1YEAR" , "0002-01-01"},
                { "V0PROP_CODOPER" , "106"},
                { "V0PROP_DTADMISSAO" , "1900-01-01"},
                { "V0PROP_STANTECIP" , ""},
                { "V0PROP_OCORHIST" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("VG0853B_CPROPVA", q2);

            #endregion

            #region VG0853B_CATRASO

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "HOST_PARCELA_ATRASO" , "1"}
            });
            AppSettings.TestSet.DynamicData.Add("VG0853B_CATRASO", q3);

            #endregion

            #region R0000_00_PRINCIPAL_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0BANC_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_UPDATE_1_Update1", q4);

            #endregion

            #region R0000_00_PRINCIPAL_DB_SELECT_3_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_MIN_DTPROXVEN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_3_Query1", q5);

            #endregion

            #region R0000_00_PRINCIPAL_DB_SELECT_4_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0BANC_NRTIT" , "1234"}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_4_Query1", q6);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_OCORR_HISTORICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1000_10_LEITURA_RAMO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_10_LEITURA_RAMO_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_OCORR_HISTORICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q9);

            #endregion

            #region R1000_10_LEITURA_RAMO_DB_SELECT_2_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_DTTERVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_10_LEITURA_RAMO_DB_SELECT_2_Query1", q10);

            #endregion

            #region VG0853B_CTERMO

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_NUM_APOLICE" , ""},
                { "TERMOADE_COD_SUBGRUPO" , ""},
                { "TERMOADE_NUM_TERMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0853B_CTERMO", q11);

            #endregion

            #region R1000_90_LEITURA_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0BANC_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_90_LEITURA_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRPRIPARATZ" , ""},
                { "V0PROP_DTPROXVEN" , ""},
                { "V0PROP_QTDPARATZ" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0PROP_OCORHIST" , ""},
                { "WHOST_MIN_DTPROXVEN" , ""},
                { "V1SIST_DT_23_CYRELA" , ""},
                { "JVPRD8203" , ""},
                { "JVPRD8205" , ""},
                { "JVPRD8206" , ""},
                { "JVPRD8209" , ""},
                { "JVPRD8214" , ""},
                { "JVPRD9311" , ""},
                { "JVPRD9329" , ""},
                { "JVPRD9330" , ""},
                { "JVPRD9343" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1", q13);

            #endregion

            #region R1000_10_LEITURA_RAMO_DB_SELECT_3_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_CODCONV" , ""},
                { "V0CONV_CCRED" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_10_LEITURA_RAMO_DB_SELECT_3_Query1", q14);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0SUBG_NUM_APOLICE" , "19790324"},
                { "V0SUBG_SIT_REGISTRO" , "1"},
                { "V0SUBG_TIPO_FATURA" , "2"},
                { "V0SUBG_FORMA_FATURA" , "2"},
                { "V0SUBG_PERI_FATURA" , "12"},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q15);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0PRDVG_ORIG_PRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1", q16);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0PRDVG_ESTR_COBR" , ""},
                { "V0PRDVG_ORIG_PRODU" , "EMPRE"},
                { "V0PRDVG_TEM_SAF" , ""},
                { "V0PRDVG_TEM_IGPM" , ""},
                { "V0PRDVG_CODPRODAZ" , ""},
                { "V0PRDVG_OPCAOCAP" , ""},
                { "V0PRDVG_COBERADIC_PREMIO" , ""},
                { "V0PRDVG_CUSTOCAP_TOTAL" , ""},
                { "V0PRDVG_NOMPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1", q17);

            #endregion

            #region R1100_00_LE_OPCAOPAG_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_OPCAOPAG" , "1"},
                { "V0OPCP_PERIPGTO" , "12"},
                { "V0OPCP_DIA_DEBITO" , "9"},
                { "V0OPCP_AGECTADEB" , "0001"},
                { "V0OPCP_OPRCTADEB" , "1"},
                { "V0OPCP_NUMCTADEB" , "1454515"},
                { "V0OPCP_DIGCTADEB" , "1"},
                { "V0OPCP_CARTAO_CRED" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_LE_OPCAOPAG_DB_SELECT_1_Query1", q18);

            #endregion

            #region R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "WS_CONT_PARC_AT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1", q19);

            #endregion

            #region R1200_10_GERA_PARCELAS_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_PRMTOTANT" , "1200"}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_10_GERA_PARCELAS_DB_SELECT_1_Query1", q20);

            #endregion

            #region R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0HICB_DTVENCTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1", q21);

            #endregion

            #region R1200_10_GERA_PARCELAS_DB_INSERT_1_Insert1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_DTPROXVEN" , ""},
                { "DESCON_PRMVG" , ""},
                { "DESCON_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_10_GERA_PARCELAS_DB_INSERT_1_Insert1", q22);

            #endregion

            #region R1200_10_GERA_PARCELAS_DB_UPDATE_1_Update1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_10_GERA_PARCELAS_DB_UPDATE_1_Update1", q23);

            #endregion

            #region R1200_10_GERA_PARCELAS_DB_SELECT_2_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "DESCON_PERC" , "12"}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_10_GERA_PARCELAS_DB_SELECT_2_Query1", q24);

            #endregion

            #region R1200_10_GERA_PARCELAS_DB_UPDATE_2_Update1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_10_GERA_PARCELAS_DB_UPDATE_2_Update1", q25);

            #endregion

            #region R1200_10_GERA_PARCELAS_DB_INSERT_2_Insert1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "WHOST_PRMVG" , ""},
                { "WHOST_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_10_GERA_PARCELAS_DB_INSERT_2_Insert1", q26);

            #endregion

            #region R1200_10_GERA_PARCELAS_DB_UPDATE_3_Update1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_10_GERA_PARCELAS_DB_UPDATE_3_Update1", q27);

            #endregion

            #region R1200_10_GERA_PARCELAS_DB_INSERT_3_Insert1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "WHOST_PRMVG_W" , ""},
                { "WHOST_PRMAP_W" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0PARC_SITUACAO" , ""},
                { "V0PARC_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_10_GERA_PARCELAS_DB_INSERT_3_Insert1", q28);

            #endregion

            #region R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_VLPREMIO" , "-1"},
                { "V0COBP_PRMVG" , "1400"},
                { "V0COBP_PRMAP" , "1500"},
                { "V0COBP_QTTITCAP" , "1"},
                { "V0COBP_VLCUSTCAP" , "1000"},
                { "V0COBP_VLCUSTCDG" , "1100"},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0COBP_CODOPER" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1", q29);

            #endregion

            #region R1220_00_SELECT_TERMOADE_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_DATA_ADESAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1220_00_SELECT_TERMOADE_DB_SELECT_1_Query1", q30);

            #endregion

            #region R1230_00_SELECT_CLIENTE_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_CGCCPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1230_00_SELECT_CLIENTE_DB_SELECT_1_Query1", q31);

            #endregion

            #region VG0853B_CTERMO1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_NUM_APOLICE" , ""},
                { "TERMOADE_COD_SUBGRUPO" , ""},
                { "TERMOADE_NUM_TERMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0853B_CTERMO1", q32);

            #endregion

            #region VG0853B_CDIFPAR

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V0DIFP_NRPARCEL" , ""},
                { "V0DIFP_CODOPER" , ""},
                { "V0DIFP_VLPRMTOT" , ""},
                { "V0DIFP_PRMDIFVG" , ""},
                { "V0DIFP_PRMDIFAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0853B_CDIFPAR", q33);

            #endregion

            #region R1260_00_CONSULTA_SITUACAO_DB_SELECT_1_Query1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1260_00_CONSULTA_SITUACAO_DB_SELECT_1_Query1", q34);

            #endregion

            #region R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1", q35);

            #endregion

            #region R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "WHOST_NRTIT" , ""},
                { "V0HICB_DTVENCTO" , ""},
                { "WHOST_VLPREMIO_W" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0HICB_SITUACAO" , ""},
                { "V0HICB_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1", q36);

            #endregion

            #region R1420_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R1420_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1", q37);

            #endregion

            #region R1420_00_GERA_NUM_TITULO_DB_SELECT_1_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1420_00_GERA_NUM_TITULO_DB_SELECT_1_Query1", q38);

            #endregion

            #region VG0853B_CDEBANT

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_CERTIFICADO" , ""},
                { "HISLANCT_NUM_PARCELA" , ""},
                { "HISLANCT_OCORR_HISTORICOCTA" , ""},
                { "HISLANCT_COD_AGENCIA_DEBITO" , ""},
                { "HISLANCT_OPE_CONTA_DEBITO" , ""},
                { "HISLANCT_NUM_CONTA_DEBITO" , ""},
                { "HISLANCT_DIG_CONTA_DEBITO" , ""},
                { "HISLANCT_DATA_VENCIMENTO" , ""},
                { "HISLANCT_PRM_TOTAL" , ""},
                { "HISLANCT_TIPLANC" , ""},
                { "HISLANCT_OCORR_HISTORICO" , ""},
                { "HISLANCT_CODCONV" , ""},
                { "HISLANCT_CODRET" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0853B_CDEBANT", q39);

            #endregion

            #region R1500_10_UPDATE_DB_UPDATE_1_Update1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRPARCEL" , ""},
                { "V3DIFP_CODOPER" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_10_UPDATE_DB_UPDATE_1_Update1", q40);

            #endregion

            #region R1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1", q41);

            #endregion

            #region R1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "V0CDGC_VLCUSTCDG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1", q42);

            #endregion

            #region R1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "V0SAFC_VLCUSTSAF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1", q43);

            #endregion

            #region R1650_00_REPASSA_CDG_DB_SELECT_1_Query1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "V0RCDG_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1650_00_REPASSA_CDG_DB_SELECT_1_Query1", q44);

            #endregion

            #region R1650_00_REPASSA_CDG_DB_INSERT_1_Insert1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RCDG_DTREFER" , ""},
                { "V0CDGC_VLCUSTCDG" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V1SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1650_00_REPASSA_CDG_DB_INSERT_1_Insert1", q45);

            #endregion

            #region R1670_00_REPASSA_SAF_DB_SELECT_1_Query1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "V0RSAF_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1670_00_REPASSA_SAF_DB_SELECT_1_Query1", q46);

            #endregion

            #region R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RSAF_DTREFER" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0SAFC_VLCUSTSAF" , ""},
                { "V0RSAF_CODOPER" , ""},
                { "V0PROP_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1", q47);

            #endregion

            #region R1700_10_LOOP_DB_SELECT_1_Query1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_DB_SELECT_1_Query1", q48);

            #endregion

            #region R1700_10_LOOP_DB_SELECT_2_Query1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_DTVENCTO_PAR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_DB_SELECT_2_Query1", q49);

            #endregion

            #region R1700_10_LOOP_DB_SELECT_3_Query1

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_PERIPGTO_ANT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_DB_SELECT_3_Query1", q50);

            #endregion

            #region R1700_10_LOOP_DB_SELECT_4_Query1

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_PERIPGTO_ANT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_DB_SELECT_4_Query1", q51);

            #endregion

            #region R1700_10_LOOP_DB_UPDATE_1_Update1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTTERVIG" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_DB_UPDATE_1_Update1", q52);

            #endregion

            #region R1700_10_LOOP_DB_INSERT_1_Insert1

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_DB_INSERT_1_Insert1", q53);

            #endregion

            #region R1700_10_LOOP_DB_SELECT_5_Query1

            var q54 = new DynamicData();
            q54.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG" , ""},
                { "WHOST_DTTERVIG_ORIG" , ""},
                { "WHOST_DTTERVIG" , ""},
                { "WHOST_DTINIVIG_NEW" , ""},
                { "WHOST_DTINIVIG_NEW2" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_DB_SELECT_5_Query1", q54);

            #endregion

            #region R1700_10_LOOP_DB_SELECT_6_Query1

            var q55 = new DynamicData();
            q55.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG" , ""},
                { "WHOST_DTTERVIG_ORIG" , ""},
                { "WHOST_DTTERVIG" , ""},
                { "WHOST_DTINIVIG_NEW" , ""},
                { "WHOST_DTINIVIG_NEW2" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_DB_SELECT_6_Query1", q55);

            #endregion

            #region R1700_10_LOOP_DB_SELECT_7_Query1

            var q56 = new DynamicData();
            q56.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG" , ""},
                { "WHOST_DTTERVIG_ORIG" , ""},
                { "WHOST_DTTERVIG" , ""},
                { "WHOST_DTINIVIG_NEW" , ""},
                { "WHOST_DTINIVIG_NEW2" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_DB_SELECT_7_Query1", q56);

            #endregion

            #region R1700_10_LOOP_DB_SELECT_8_Query1

            var q57 = new DynamicData();
            q57.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_DB_SELECT_8_Query1", q57);

            #endregion

            #region R2500_00_PROCESSA_DEB_ANTERIOR_DB_INSERT_1_Insert1

            var q58 = new DynamicData();
            q58.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_CERTIFICADO" , ""},
                { "HISLANCT_NUM_PARCELA" , ""},
                { "HISLANCT_OCORR_HISTORICOCTA" , ""},
                { "HISLANCT_COD_AGENCIA_DEBITO" , ""},
                { "HISLANCT_OPE_CONTA_DEBITO" , ""},
                { "HISLANCT_NUM_CONTA_DEBITO" , ""},
                { "HISLANCT_DIG_CONTA_DEBITO" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "HISLANCT_PRM_TOTAL" , ""},
                { "HISLANCT_OCORR_HISTORICO" , ""},
                { "HISLANCT_CODCONV" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_PROCESSA_DEB_ANTERIOR_DB_INSERT_1_Insert1", q58);

            #endregion

            #region R2600_00_UPDATE_COBERHISTVA_DB_UPDATE_1_Update1

            var q59 = new DynamicData();
            q59.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_OCORR_HISTORICO" , ""},
                { "HISLANCT_NUM_CERTIFICADO" , ""},
                { "HISLANCT_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2600_00_UPDATE_COBERHISTVA_DB_UPDATE_1_Update1", q59);

            #endregion

            #region R2700_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1

            var q60 = new DynamicData();
            q60.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_CERTIFICADO" , ""},
                { "HISLANCT_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2700_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1", q60);

            #endregion

            #region R5000_00_BUSCA_VLPREMIO_DB_SELECT_1_Query1

            var q61 = new DynamicData();
            q61.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLPREMIO_REL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_BUSCA_VLPREMIO_DB_SELECT_1_Query1", q61);

            #endregion

            #region R5000_00_BUSCA_VLPREMIO_DB_SELECT_2_Query1

            var q62 = new DynamicData();
            q62.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLPREMIO_REL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_BUSCA_VLPREMIO_DB_SELECT_2_Query1", q62);

            #endregion

            #region R6000_00_VERIFICA_CONTROLE_MNL_DB_SELECT_1_Query1

            var q63 = new DynamicData();
            q63.AddDynamic(new Dictionary<string, string>{
                { "VG083_NUM_APOLICE" , ""},
                { "VG083_COD_SUBGRUPO" , ""},
                { "VG083_SEQ_FATURAMENTO" , ""},
                { "VG083_DTA_INI_FATURA" , ""},
                { "VG083_DTA_VENC_FATURA" , ""},
                { "VG083_IND_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_VERIFICA_CONTROLE_MNL_DB_SELECT_1_Query1", q63);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Saida1_VG0853B.txt", "Saida2_VG0853B.txt", "Saida3_VG0853B.txt")]
        public static void VG0853B_Tests_Theory_SemMovimento_0(string DSAIDA_FILE_NAME_P, string SSAIDA_FILE_NAME_P, string ARQSAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            DSAIDA_FILE_NAME_P = $"{DSAIDA_FILE_NAME_P}_{timestamp}.txt";
            SSAIDA_FILE_NAME_P = $"{SSAIDA_FILE_NAME_P}_{timestamp}.txt";
            ARQSAIDA_FILE_NAME_P = $"{ARQSAIDA_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region VG0853B_CPROPVA

                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("VG0853B_CPROPVA");
                AppSettings.TestSet.DynamicData.Add("VG0853B_CPROPVA", q2);

                #endregion


                #endregion
                var program = new VG0853B();
                program.Execute(DSAIDA_FILE_NAME_P, SSAIDA_FILE_NAME_P, ARQSAIDA_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

            }
        }
        [Theory]
        [InlineData("Saida1_VG0853B.txt", "Saida2_VG0853B.txt", "Saida3_VG0853B.txt")]
        public static void VG0853B_Tests_Theory_ReturnCodeError_99(string DSAIDA_FILE_NAME_P, string SSAIDA_FILE_NAME_P, string ARQSAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            DSAIDA_FILE_NAME_P = $"{DSAIDA_FILE_NAME_P}_{timestamp}.txt";
            SSAIDA_FILE_NAME_P = $"{SSAIDA_FILE_NAME_P}_{timestamp}.txt";
            ARQSAIDA_FILE_NAME_P = $"{ARQSAIDA_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region VG0853B_CPROPVA

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NUM_APOLICE" , "97010000889"},
                { "V0PROP_CODSUBES" , "3603"},
                { "V0PROP_NRCERTIF" , "100000266"},
                { "V0PROP_CODPRODU" , "9320"},
                { "V0PROP_CODCLIEN" , "4853934"},
                { "V0PROP_NRPARCEL" , "1"},
                { "V0PROP_SITUACAO" , "2"},
                { "V0PROP_DTQITBCO" , "2010-01-01"},
                { "V0PROP_DTVENCTO" , "2023-01-01"},
                { "V0PROP_DTPROXVEN" , "2023-01-30"},
                { "V0PROP_NRPRIPARATZ" , "0"},
                { "V0PROP_QTDPARATZ" , "0"},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0PROP_TIMESTAMP" , "2006-06-21T22,52,09.679Z"},
                { "V0PROP_DTMINVEN" , "2001-02-01"},
                { "V0PROP_DTQITBCO_1YEAR" , "2003-01-01"},
                { "V0PROP_CODOPER" , "106"},
                { "V0PROP_DTADMISSAO" , "2004-01-01"},
                { "V0PROP_STANTECIP" , ""},
                { "V0PROP_OCORHIST" , "1"},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("VG0853B_CPROPVA");
                AppSettings.TestSet.DynamicData.Add("VG0853B_CPROPVA", q2);

                #endregion
                #endregion
                var program = new VG0853B();
                program.Execute(DSAIDA_FILE_NAME_P, SSAIDA_FILE_NAME_P, ARQSAIDA_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);

            }
        }
        [Theory]
        [InlineData("Saida1_VG0853B.txt", "Saida2_VG0853B.txt", "Saida3_VG0853B.txt")]
        public static void VG0853B_Tests_Theory_Sucesso_ReturnCode_03(string DSAIDA_FILE_NAME_P, string SSAIDA_FILE_NAME_P, string ARQSAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            DSAIDA_FILE_NAME_P = $"{DSAIDA_FILE_NAME_P}_{timestamp}.txt";
            SSAIDA_FILE_NAME_P = $"{SSAIDA_FILE_NAME_P}_{timestamp}.txt";
            ARQSAIDA_FILE_NAME_P = $"{ARQSAIDA_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R1650_00_REPASSA_CDG_DB_SELECT_1_Query1

                var q44 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1650_00_REPASSA_CDG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1650_00_REPASSA_CDG_DB_SELECT_1_Query1", q44);

                #endregion
                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V0PRDVG_ESTR_COBR" , ""},
                { "V0PRDVG_ORIG_PRODU" , "EMPRE"},
                { "V0PRDVG_TEM_SAF" , "S"},
                { "V0PRDVG_TEM_IGPM" , ""},
                { "V0PRDVG_CODPRODAZ" , ""},
                { "V0PRDVG_OPCAOCAP" , ""},
                { "V0PRDVG_COBERADIC_PREMIO" , ""},
                { "V0PRDVG_CUSTOCAP_TOTAL" , ""},
                { "V0PRDVG_NOMPRODU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1", q17);

                #endregion
                #region R1670_00_REPASSA_SAF_DB_SELECT_1_Query1

                var q46 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1670_00_REPASSA_SAF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1670_00_REPASSA_SAF_DB_SELECT_1_Query1", q46);

                #endregion

                #region R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_VLPREMIO" , "10"},
                { "V0COBP_PRMVG" , "1400"},
                { "V0COBP_PRMAP" , "1500"},
                { "V0COBP_QTTITCAP" , "1"},
                { "V0COBP_VLCUSTCAP" , "1000"},
                { "V0COBP_VLCUSTCDG" , "1100"},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0COBP_CODOPER" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1", q29);

                #endregion


                #endregion
                var program = new VG0853B();
                program.Execute(DSAIDA_FILE_NAME_P, SSAIDA_FILE_NAME_P, ARQSAIDA_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 3);

                //R0000_00_PRINCIPAL_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["R0000_00_PRINCIPAL_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("V0BANC_NRTIT", out var val0r) && val0r.Contains("0000000001234"));

                //R1200_10_GERA_PARCELAS_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R1200_10_GERA_PARCELAS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("V0PROP_NRCERTIF", out var val1r) && val1r.Contains("000000100000266"));
                Assert.True(envList1.Count > 1);

                //R1200_10_GERA_PARCELAS_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R1200_10_GERA_PARCELAS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("V0PROP_NRCERTIF", out var val2r) && val2r.Contains("000000100000266"));

                //R1200_10_GERA_PARCELAS_DB_INSERT_3_Insert1
                var envList5 = AppSettings.TestSet.DynamicData["R1200_10_GERA_PARCELAS_DB_INSERT_3_Insert1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("WHOST_PRMAP_W", out var val5r) && val5r.Contains("0000000001500.00"));
                Assert.True(envList5.Count > 1);

                //R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1
                var envList6 = AppSettings.TestSet.DynamicData["R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList6[1].TryGetValue("WHOST_VLPREMIO_W", out var val6r) && val6r.Contains("00000000010.00"));
                Assert.True(envList6.Count > 1);

                //R1420_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1
                var envList7 = AppSettings.TestSet.DynamicData["R1420_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList7[1].TryGetValue("UpdateCheck", out var val7r) && val7r.Contains("UpdateCheck"));


            }
        }
        [Theory]
        [InlineData("Saida1_VG0853B.txt", "Saida2_VG0853B.txt", "Saida3_VG0853B.txt")]
        public static void VG0853B_Tests_Theory_Sucesso_CenarioValorPremio_0_ReturnCode_03(string DSAIDA_FILE_NAME_P, string SSAIDA_FILE_NAME_P, string ARQSAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            DSAIDA_FILE_NAME_P = $"{DSAIDA_FILE_NAME_P}_{timestamp}.txt";
            SSAIDA_FILE_NAME_P = $"{SSAIDA_FILE_NAME_P}_{timestamp}.txt";
            ARQSAIDA_FILE_NAME_P = $"{ARQSAIDA_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R1650_00_REPASSA_CDG_DB_SELECT_1_Query1

                var q44 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1650_00_REPASSA_CDG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1650_00_REPASSA_CDG_DB_SELECT_1_Query1", q44);

                #endregion
                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V0PRDVG_ESTR_COBR" , ""},
                { "V0PRDVG_ORIG_PRODU" , "EMPRE"},
                { "V0PRDVG_TEM_SAF" , "S"},
                { "V0PRDVG_TEM_IGPM" , ""},
                { "V0PRDVG_CODPRODAZ" , ""},
                { "V0PRDVG_OPCAOCAP" , ""},
                { "V0PRDVG_COBERADIC_PREMIO" , ""},
                { "V0PRDVG_CUSTOCAP_TOTAL" , ""},
                { "V0PRDVG_NOMPRODU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1", q17);

                #endregion
                #region R1670_00_REPASSA_SAF_DB_SELECT_1_Query1

                var q46 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1670_00_REPASSA_SAF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1670_00_REPASSA_SAF_DB_SELECT_1_Query1", q46);

                #endregion
                #region R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_VLPREMIO" , "0"},
                { "V0COBP_PRMVG" , "1400"},
                { "V0COBP_PRMAP" , "1500"},
                { "V0COBP_QTTITCAP" , "1"},
                { "V0COBP_VLCUSTCAP" , "1000"},
                { "V0COBP_VLCUSTCDG" , "1100"},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0COBP_CODOPER" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1", q29);

                #endregion

                #endregion
                var program = new VG0853B();
                program.Execute(DSAIDA_FILE_NAME_P, SSAIDA_FILE_NAME_P, ARQSAIDA_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 3);

                //R0000_00_PRINCIPAL_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["R0000_00_PRINCIPAL_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("V0BANC_NRTIT", out var val0r) && val0r.Contains("0000000001234"));

                //R1200_10_GERA_PARCELAS_DB_INSERT_3_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R1200_10_GERA_PARCELAS_DB_INSERT_3_Insert1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("V0PROP_NRCERTIF", out var val1r) && val1r.Contains("000000100000266"));
                Assert.True(envList1.Count > 1);

                //R1200_10_GERA_PARCELAS_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R1200_10_GERA_PARCELAS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("V0PROP_NRCERTIF", out var val2r) && val2r.Contains("000000100000266"));

                //R1200_10_GERA_PARCELAS_DB_UPDATE_2_Update1
                var envList3 = AppSettings.TestSet.DynamicData["R1200_10_GERA_PARCELAS_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("V0PROP_NRCERTIF", out var val3r) && val3r.Contains("000000100000266"));

                //R1200_10_GERA_PARCELAS_DB_INSERT_3_Insert1
                var envList5 = AppSettings.TestSet.DynamicData["R1200_10_GERA_PARCELAS_DB_INSERT_3_Insert1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("WHOST_PRMAP_W", out var val5r) && val5r.Contains("0000000001500.00"));
                Assert.True(envList5.Count > 1);

                //R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1
                var envList6 = AppSettings.TestSet.DynamicData["R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList6[1].TryGetValue("WHOST_VLPREMIO_W", out var val6r) && val6r.Contains("0"));
                Assert.True(envList6.Count > 1);

                //R1420_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1
                var envList7 = AppSettings.TestSet.DynamicData["R1420_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList7[1].TryGetValue("UpdateCheck", out var val7r) && val7r.Contains("UpdateCheck"));

                //R1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1
                var envList8 = AppSettings.TestSet.DynamicData["R1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList8[1].TryGetValue("V0PROP_NRCERTIF", out var val8r) && val8r.Contains("000000100000266"));

                //R1650_00_REPASSA_CDG_DB_INSERT_1_Insert1
                var envList9 = AppSettings.TestSet.DynamicData["R1650_00_REPASSA_CDG_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList9[1].TryGetValue("V0PROP_CODCLIEN", out var val9r) && val9r.Contains("004853934"));
                Assert.True(envList9.Count > 1);

                //R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1
                var envList10 = AppSettings.TestSet.DynamicData["R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList10[1].TryGetValue("V0RSAF_CODOPER", out var val10r) && val10r.Contains("1100"));
                Assert.True(envList10.Count > 1);
            }
        }
        [Theory]
        [InlineData("Saida1_VG0853B.txt", "Saida2_VG0853B.txt", "Saida3_VG0853B.txt")]
        public static void VG0853B_Tests_Theory_Sucesso_CenarioValorPremio_0_CursorAtraso_ReturnCode_03(string DSAIDA_FILE_NAME_P, string SSAIDA_FILE_NAME_P, string ARQSAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            DSAIDA_FILE_NAME_P = $"{DSAIDA_FILE_NAME_P}_{timestamp}.txt";
            SSAIDA_FILE_NAME_P = $"{SSAIDA_FILE_NAME_P}_{timestamp}.txt";
            ARQSAIDA_FILE_NAME_P = $"{ARQSAIDA_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R1650_00_REPASSA_CDG_DB_SELECT_1_Query1

                var q44 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1650_00_REPASSA_CDG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1650_00_REPASSA_CDG_DB_SELECT_1_Query1", q44);

                #endregion
                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V0PRDVG_ESTR_COBR" , ""},
                { "V0PRDVG_ORIG_PRODU" , "EMPRE"},
                { "V0PRDVG_TEM_SAF" , "S"},
                { "V0PRDVG_TEM_IGPM" , ""},
                { "V0PRDVG_CODPRODAZ" , ""},
                { "V0PRDVG_OPCAOCAP" , ""},
                { "V0PRDVG_COBERADIC_PREMIO" , ""},
                { "V0PRDVG_CUSTOCAP_TOTAL" , ""},
                { "V0PRDVG_NOMPRODU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1", q17);

                #endregion
                #region R1670_00_REPASSA_SAF_DB_SELECT_1_Query1

                var q46 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1670_00_REPASSA_SAF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1670_00_REPASSA_SAF_DB_SELECT_1_Query1", q46);

                #endregion
                #region R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_VLPREMIO" , "0"},
                { "V0COBP_PRMVG" , "1400"},
                { "V0COBP_PRMAP" , "1500"},
                { "V0COBP_QTTITCAP" , "1"},
                { "V0COBP_VLCUSTCAP" , "1000"},
                { "V0COBP_VLCUSTCDG" , "1100"},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0COBP_CODOPER" , "1"},
                });
                q29.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_VLPREMIO" , "0"},
                { "V0COBP_PRMVG" , "1400"},
                { "V0COBP_PRMAP" , "1500"},
                { "V0COBP_QTTITCAP" , "1"},
                { "V0COBP_VLCUSTCAP" , "1000"},
                { "V0COBP_VLCUSTCDG" , "1100"},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0COBP_CODOPER" , "1"},
                });

                AppSettings.TestSet.DynamicData.Remove("R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1", q29);

                #endregion
                #region VG0853B_CATRASO

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "HOST_PARCELA_ATRASO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("VG0853B_CATRASO");
                AppSettings.TestSet.DynamicData.Add("VG0853B_CATRASO", q3);

                #endregion

                #region VG0853B_CPROPVA

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NUM_APOLICE" , "97010000889"},
                { "V0PROP_CODSUBES" , "3603"},
                { "V0PROP_NRCERTIF" , "100000266"},
                { "V0PROP_CODPRODU" , "9320"},
                { "V0PROP_CODCLIEN" , "4853934"},
                { "V0PROP_NRPARCEL" , "1"},
                { "V0PROP_SITUACAO" , "2"},
                { "V0PROP_DTQITBCO" , "2010-01-01"},
                { "V0PROP_DTVENCTO" , "2023-01-01"},
                { "V0PROP_DTPROXVEN" , "2023-01-30"},
                { "V0PROP_NRPRIPARATZ" , "0"},
                { "V0PROP_QTDPARATZ" , "0"},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0PROP_TIMESTAMP" , "2006-06-21T22,52,09.679Z"},
                { "V0PROP_DTMINVEN" , "2001-02-01"},
                { "V0PROP_DTQITBCO_1YEAR" , "2003-01-01"},
                { "V0PROP_CODOPER" , "106"},
                { "V0PROP_DTADMISSAO" , "2004-01-01"},
                { "V0PROP_STANTECIP" , ""},
                { "V0PROP_OCORHIST" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("VG0853B_CPROPVA");
                AppSettings.TestSet.DynamicData.Add("VG0853B_CPROPVA", q2);

                #endregion

                #region R1100_00_LE_OPCAOPAG_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_OPCAOPAG" , "1"},
                { "V0OPCP_PERIPGTO" , "12"},
                { "V0OPCP_DIA_DEBITO" , "9"},
                { "V0OPCP_AGECTADEB" , "0001"},
                { "V0OPCP_OPRCTADEB" , "1"},
                { "V0OPCP_NUMCTADEB" , "1454515"},
                { "V0OPCP_DIGCTADEB" , "1"},
                { "V0OPCP_CARTAO_CRED" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_OPCAOPAG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_OPCAOPAG_DB_SELECT_1_Query1", q18);

                #endregion

                #region R1260_00_CONSULTA_SITUACAO_DB_SELECT_1_Query1

                var q34 = new DynamicData();
                q34.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_SITUACAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1260_00_CONSULTA_SITUACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1260_00_CONSULTA_SITUACAO_DB_SELECT_1_Query1", q34);

                #endregion
                #region R1700_10_LOOP_DB_SELECT_3_Query1

                var q50 = new DynamicData();
                q50.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_PERIPGTO_ANT" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1700_10_LOOP_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_10_LOOP_DB_SELECT_3_Query1", q50);

                #endregion
                #region R1200_10_GERA_PARCELAS_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_PRMTOTANT" , "1200"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_10_GERA_PARCELAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_10_GERA_PARCELAS_DB_SELECT_1_Query1", q20);

                #endregion

                #endregion
                var program = new VG0853B();
                program.Execute(DSAIDA_FILE_NAME_P, SSAIDA_FILE_NAME_P, ARQSAIDA_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 3);

                //R0000_00_PRINCIPAL_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["R0000_00_PRINCIPAL_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("V0BANC_NRTIT", out var val0r) && val0r.Contains("0000000001234"));

                //R1200_10_GERA_PARCELAS_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R1200_10_GERA_PARCELAS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("DESCON_PRMVG", out var val1r) && val1r.Contains("0000000016800.00"));
                Assert.True(envList1.Count > 1);

                //R1200_10_GERA_PARCELAS_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R1200_10_GERA_PARCELAS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("V0PROP_NRCERTIF", out var val2r) && val2r.Contains("000000100000266"));

                //R1200_10_GERA_PARCELAS_DB_UPDATE_2_Update1
                var envList3 = AppSettings.TestSet.DynamicData["R1200_10_GERA_PARCELAS_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("V0PROP_NRCERTIF", out var val3r) && val3r.Contains("000000100000266"));

                //R1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1
                var envList4 = AppSettings.TestSet.DynamicData["R1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("V0PROP_SITUACAO", out var val4r) && val4r.Contains("2"));

                //R1200_10_GERA_PARCELAS_DB_INSERT_3_Insert1
                var envList5 = AppSettings.TestSet.DynamicData["R1200_10_GERA_PARCELAS_DB_INSERT_3_Insert1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("WHOST_PRMAP_W", out var val5r) && val5r.Contains("0000000001500.00"));
                Assert.True(envList5.Count > 1);

                //R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1
                var envList6 = AppSettings.TestSet.DynamicData["R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList6[1].TryGetValue("WHOST_VLPREMIO_W", out var val6r) && val6r.Contains("0"));
                Assert.True(envList6.Count > 1);

                //R1420_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1
                var envList7 = AppSettings.TestSet.DynamicData["R1420_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList7[1].TryGetValue("UpdateCheck", out var val7r) && val7r.Contains("UpdateCheck"));

                //R1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1
                var envList8 = AppSettings.TestSet.DynamicData["R1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList8[1].TryGetValue("V0PROP_NRCERTIF", out var val8r) && val8r.Contains("000000100000266"));

                //R1650_00_REPASSA_CDG_DB_INSERT_1_Insert1
                var envList9 = AppSettings.TestSet.DynamicData["R1650_00_REPASSA_CDG_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList9[1].TryGetValue("V0PROP_CODCLIEN", out var val9r) && val9r.Contains("004853934"));
                Assert.True(envList9.Count > 1);

                //R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1
                var envList10 = AppSettings.TestSet.DynamicData["R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList10[1].TryGetValue("V0RSAF_CODOPER", out var val10r) && val10r.Contains("1100"));
                Assert.True(envList10.Count > 1);
            }
        }
    }
}