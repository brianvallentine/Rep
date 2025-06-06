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
using static Code.VA0853B;

namespace FileTests.Test
{
    [Collection("VA0853B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0853B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region VA0853B_CPROPVAL

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "WS_TIPO_PROCESSAMENTO" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_CODPRODU" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_DTQITBCO" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0PROP_DTPROXVEN" , ""},
                { "V0PROP_NRPRIPARATZ" , ""},
                { "V0PROP_QTDPARATZ" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0PROP_TIMESTAMP" , ""},
                { "V0PROP_DTMINVEN" , ""},
                { "V0PROP_DTQITBCO_1YEAR" , ""},
                { "V0PROP_CODOPER" , ""},
                { "V0PROP_DTADMISSAO" , ""},
                { "V0PRDVG_ESTR_COBR" , ""},
                { "V0PRDVG_ORIG_PRODU" , ""},
                { "V0PRDVG_TEM_SAF" , ""},
                { "V0PRDVG_TEM_CDG" , ""},
                { "V0PRDVG_TEM_IGPM" , ""},
                { "V0PRDVG_CODPRODAZ" , ""},
                { "V0PRDVG_OPCAOCAP" , ""},
                { "V0PRDVG_COBERADIC_PREMIO" , ""},
                { "V0PRDVG_CUSTOCAP_TOTAL" , ""},
                { "V0PRDVG_OPCAOPAG" , ""},
                { "V0PRDVG_PERIPGTO" , ""},
                { "V0PRDVG_NOMPRODU" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0OPCP_PERIPGTO" , ""},
                { "V0OPCP_DIA_DEBITO" , ""},
                { "V0OPCP_AGECTADEB" , ""},
                { "V0OPCP_OPRCTADEB" , ""},
                { "V0OPCP_NUMCTADEB" , ""},
                { "V0OPCP_DIGCTADEB" , ""},
                { "V0OPCP_CARTAO_CRED" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0853B_CPROPVAL", q0);

            #endregion

            #region VA0853B_CPROPVAG

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WS_TIPO_PROCESSAMENTO" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_CODPRODU" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_DTQITBCO" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0PROP_DTPROXVEN" , ""},
                { "V0PROP_NRPRIPARATZ" , ""},
                { "V0PROP_QTDPARATZ" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0PROP_TIMESTAMP" , ""},
                { "V0PROP_DTMINVEN" , ""},
                { "V0PROP_DTQITBCO_1YEAR" , ""},
                { "V0PROP_CODOPER" , ""},
                { "V0PROP_DTADMISSAO" , ""},
                { "V0PRDVG_ESTR_COBR" , ""},
                { "V0PRDVG_ORIG_PRODU" , ""},
                { "V0PRDVG_TEM_SAF" , ""},
                { "V0PRDVG_TEM_CDG" , ""},
                { "V0PRDVG_TEM_IGPM" , ""},
                { "V0PRDVG_CODPRODAZ" , ""},
                { "V0PRDVG_OPCAOCAP" , ""},
                { "V0PRDVG_COBERADIC_PREMIO" , ""},
                { "V0PRDVG_CUSTOCAP_TOTAL" , ""},
                { "V0PRDVG_OPCAOPAG" , ""},
                { "V0PRDVG_PERIPGTO" , ""},
                { "V0PRDVG_NOMPRODU" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0OPCP_PERIPGTO" , ""},
                { "V0OPCP_DIA_DEBITO" , ""},
                { "V0OPCP_AGECTADEB" , ""},
                { "V0OPCP_OPRCTADEB" , ""},
                { "V0OPCP_NUMCTADEB" , ""},
                { "V0OPCP_DIGCTADEB" , ""},
                { "V0OPCP_CARTAO_CRED" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0853B_CPROPVAG", q1);

            #endregion

            #region R0100_00_INICIALIZA_PGM_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DT_15D_UTIL" , ""},
                { "V1SIST_DT_18D_UTIL" , ""},
                { "V1SIST_DTHOJE" , ""},
                { "V1SIST_DTVENFIM_6D_UTIL" , ""},
                { "V1SIST_DTVENFIM_CN_GE853S" , ""},
                { "V1SIST_DTVENFIM_1Y_GE853S" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_INICIALIZA_PGM_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0100_00_INICIALIZA_PGM_DB_SELECT_2_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DT_15D_UTIL" , ""},
                { "V1SIST_DT_18D_UTIL" , ""},
                { "V1SIST_DTHOJE" , ""},
                { "V1SIST_DTVENFIM_6D_UTIL" , ""},
                { "V1SIST_DTVENFIM_CN_GE853S" , ""},
                { "V1SIST_DTVENFIM_1Y_GE853S" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_INICIALIZA_PGM_DB_SELECT_2_Query1", q3);

            #endregion

            #region VA0853B_ERROPROC

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PF089_NUM_ERRO_PROPOSTA" , ""},
                { "PF089_DES_ERRO_PROPOSTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0853B_ERROPROC", q4);

            #endregion

            #region VA0853B_CPARCATZ

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WS_ATZ_NUM_TITULO" , ""},
                { "WS_ATZ_NUM_PARCELA" , ""},
                { "WS_ATZ_DT_VENCIMENTO" , ""},
                { "WS_ATZ_VLR_DEBITO" , ""},
                { "WS_ATZ_COD_RETORNO" , ""},
                { "WS_ATZ_COD_MOTIVO" , ""},
                { "WS_ATZ_OCORR_HISTCTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0853B_CPARCATZ", q5);

            #endregion

            #region R1015_00_VER_RETORNO_SICOV_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NSAS" , ""},
                { "V0HCTA_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1015_00_VER_RETORNO_SICOV_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1015_00_VER_RETORNO_SICOV_DB_SELECT_2_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0HCTA_NSAS" , ""},
                { "V0HCTA_NSL" , ""},
                { "WS_COD_IDLG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1015_00_VER_RETORNO_SICOV_DB_SELECT_2_Query1", q7);

            #endregion

            #region R1016_00_CONS_SEGURAVG_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0SEGV_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1016_00_CONS_SEGURAVG_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1017_00_CONS_HISTCOBVA_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0HICB_DTVENCTO" , ""},
                { "V0HICB_VLPRMTOT" , ""},
                { "V0HICB_SITUACAO" , ""},
                { "WS_NUMERO_TITULO" , ""},
                { "V0HICB_OPCAO_PGTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1017_00_CONS_HISTCOBVA_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1018_00_CONS_OPCAOPAGVA_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0OPCP_PERIPGTO" , ""},
                { "V0OPCP_DIA_DEBITO" , ""},
                { "V0OPCP_AGECTADEB" , ""},
                { "V0OPCP_OPRCTADEB" , ""},
                { "V0OPCP_NUMCTADEB" , ""},
                { "V0OPCP_DIGCTADEB" , ""},
                { "V0OPCP_CARTAO_CRED" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1018_00_CONS_OPCAOPAGVA_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1020_00_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRPRIPARATZ" , ""},
                { "V0PROP_DTPROXVEN" , ""},
                { "V0PROP_QTDPARATZ" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0PROP_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1020_00_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R1025_00_VER_RETORNO_CARTAO_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "GE408_DTA_CREDITO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1025_00_VER_RETORNO_CARTAO_DB_SELECT_1_Query1", q12);

            #endregion

            #region R1050_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0CONV_CODCONV" , ""},
                { "V0CONV_CCRED" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1", q13);

            #endregion

            #region VA0853B_CDIFPAR

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0DIFP_NRPARCEL" , ""},
                { "V0DIFP_CODOPER" , ""},
                { "V0DIFP_VLPRMTOT" , ""},
                { "V0DIFP_PRMDIFVG" , ""},
                { "V0DIFP_PRMDIFAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0853B_CDIFPAR", q14);

            #endregion

            #region R1105_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_PARCELA_PEND" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1105_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1", q15);

            #endregion

            #region R1140_00_UPD_PARC_ATZ_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_OCORRHISTCTA" , ""},
                { "WS_ATZ_NUM_PARCELA" , ""},
                { "V0PROP_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1140_00_UPD_PARC_ATZ_DB_UPDATE_1_Update1", q16);

            #endregion

            #region R1140_00_UPD_PARC_ATZ_DB_UPDATE_2_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_OCORRHISTCTA" , ""},
                { "V0PARC_CODOPER" , ""},
                { "WS_ATZ_NUM_PARCELA" , ""},
                { "V0PROP_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1140_00_UPD_PARC_ATZ_DB_UPDATE_2_Update1", q17);

            #endregion

            #region R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_PRMTOTANT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1", q18);

            #endregion

            #region R1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_DTPROXVEN" , ""},
                { "DESCON_PRMVG" , ""},
                { "DESCON_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1", q19);

            #endregion

            #region R1200_00_GERA_PARCELAS_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_UPDATE_1_Update1", q20);

            #endregion

            #region R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "DESCON_PERC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1", q21);

            #endregion

            #region R1200_00_GERA_PARCELAS_DB_UPDATE_2_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_UPDATE_2_Update1", q22);

            #endregion

            #region R1200_00_GERA_PARCELAS_DB_INSERT_2_Insert1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "WHOST_PRMVG" , ""},
                { "WHOST_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_INSERT_2_Insert1", q23);

            #endregion

            #region R1200_00_GERA_PARCELAS_DB_INSERT_3_Insert1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "WHOST_PRMVG_W" , ""},
                { "WHOST_PRMAP_W" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0PARC_SITUACAO" , ""},
                { "V0PARC_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_INSERT_3_Insert1", q24);

            #endregion

            #region R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V0MOVF_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1", q25);

            #endregion

            #region R1200_00_GERA_PARCELAS_DB_INSERT_4_Insert1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "WHOST_PARCELCAP" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0COBP_VLCUSTCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_GERA_PARCELAS_DB_INSERT_4_Insert1", q26);

            #endregion

            #region R1210_00_CONSULTA_COBERPROPVA_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_VLPREMIO" , ""},
                { "V0COBP_PRMVG" , ""},
                { "V0COBP_PRMAP" , ""},
                { "V0COBP_QTTITCAP" , ""},
                { "V0COBP_VLCUSTCAP" , ""},
                { "V0COBP_VLCUSTCDG" , ""},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0COBP_CODOPER" , ""},
                { "V0COBP_DTINIVIG_1" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_CONSULTA_COBERPROPVA_DB_SELECT_1_Query1", q27);

            #endregion

            #region R1210_00_CONSULTA_COBERPROPVA_DB_SELECT_2_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V0COBP_VLPREMIO" , ""},
                { "V0COBP_PRMVG" , ""},
                { "V0COBP_PRMAP" , ""},
                { "V0COBP_QTTITCAP" , ""},
                { "V0COBP_VLCUSTCAP" , ""},
                { "V0COBP_VLCUSTCDG" , ""},
                { "V0COBP_VLCUSTAUXF" , ""},
                { "V0COBP_CODOPER" , ""},
                { "V0COBP_DTINIVIG_1" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_CONSULTA_COBERPROPVA_DB_SELECT_2_Query1", q28);

            #endregion

            #region R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0HIST_OCORRHISTCTA" , ""},
                { "V0OPCP_AGECTADEB" , ""},
                { "V0OPCP_OPRCTADEB" , ""},
                { "V0OPCP_NUMCTADEB" , ""},
                { "V0OPCP_DIGCTADEB" , ""},
                { "V0HICB_DTVENCTO" , ""},
                { "WHOST_VLPREMIO_W" , ""},
                { "HOST_CODCONV" , ""},
                { "V0OPCP_CARTAO_CRED" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1", q29);

            #endregion

            #region R1320_INSERT_MOVTO_DEBITOCC_DB_INSERT_1_Insert1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_EMPRESA" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_VALOR_DEBITO" , ""},
                { "MOVDEBCE_DATA_MOVIMENTO" , ""},
                { "MOVDEBCE_DIA_DEBITO" , ""},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_DATA_ENVIO" , ""},
                { "MOVDEBCE_DATA_RETORNO" , ""},
                { "MOVDEBCE_COD_RETORNO_CEF" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_COD_USUARIO" , ""},
                { "MOVDEBCE_NUM_REQUISICAO" , ""},
                { "MOVDEBCE_NUM_CARTAO" , ""},
                { "MOVDEBCE_SEQUENCIA" , ""},
                { "MOVDEBCE_NUM_LOTE" , ""},
                { "MOVDEBCE_DTCREDITO" , ""},
                { "MOVDEBCE_STATUS_CARTAO" , ""},
                { "MOVDEBCE_VLR_CREDITO" , ""},
                { "MOVDEBCE_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1320_INSERT_MOVTO_DEBITOCC_DB_INSERT_1_Insert1", q30);

            #endregion

            #region R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "W_TITULO" , ""},
                { "V0HICB_DTVENCTO" , ""},
                { "WHOST_VLPREMIO_W" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0HICB_SITUACAO" , ""},
                { "V0HICB_CODOPER" , ""},
                { "V0HICB_CODDEVOLV" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1", q31);

            #endregion

            #region R1410_00_GERA_HIST_COBRANCA_DB_SELECT_1_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_SITUACAO1" , ""},
                { "V0PARC_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1410_00_GERA_HIST_COBRANCA_DB_SELECT_1_Query1", q32);

            #endregion

            #region R1410_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0RELA_NRPARCEL" , ""},
                { "W_TITULO" , ""},
                { "V0PARC_DTVENCTO" , ""},
                { "WHOST_VLPREMIO_W" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0PARC_SITUACAO1" , ""},
                { "V0HICB_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1410_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1", q33);

            #endregion

            #region R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_1_Update1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0RELA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_1_Update1", q34);

            #endregion

            #region R1410_00_GERA_HIST_COBRANCA_DB_SELECT_2_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_NRTIT" , ""},
                { "V0RELA_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1410_00_GERA_HIST_COBRANCA_DB_SELECT_2_Query1", q35);

            #endregion

            #region R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_2_Update1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0RELA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_2_Update1", q36);

            #endregion

            #region R1415_00_SEL_TITULO_DB_UPDATE_1_Update1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R1415_00_SEL_TITULO_DB_UPDATE_1_Update1", q37);

            #endregion

            #region R1415_00_SEL_TITULO_DB_SELECT_1_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1415_00_SEL_TITULO_DB_SELECT_1_Query1", q38);

            #endregion

            #region R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_3_Update1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0RELA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_3_Update1", q39);

            #endregion

            #region R1415_00_SEL_TITULO_DB_SELECT_2_Query1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V0BANC_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1415_00_SEL_TITULO_DB_SELECT_2_Query1", q40);

            #endregion

            #region R1415_00_SEL_TITULO_DB_UPDATE_2_Update1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V0BANC_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1415_00_SEL_TITULO_DB_UPDATE_2_Update1", q41);

            #endregion

            #region VA0853B_CGERARAT

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_PARCELA_ATZ" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VA0853B_CGERARAT", q42);

            #endregion

            #region R1500_10_UPDATE_DB_UPDATE_1_Update1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRPARCEL" , ""},
                { "V3DIFP_CODOPER" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_10_UPDATE_DB_UPDATE_1_Update1", q43);

            #endregion

            #region R1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1", q44);

            #endregion

            #region R1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "V0CDGC_VLCUSTCDG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1", q45);

            #endregion

            #region R1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "V0SAFC_VLCUSTSAF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1", q46);

            #endregion

            #region R1650_00_REPASSA_CDG_DB_SELECT_1_Query1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "V0RCDG_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1650_00_REPASSA_CDG_DB_SELECT_1_Query1", q47);

            #endregion

            #region R1650_00_REPASSA_CDG_DB_INSERT_1_Insert1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RCDG_DTREFER" , ""},
                { "V0CDGC_VLCUSTCDG" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V1SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1650_00_REPASSA_CDG_DB_INSERT_1_Insert1", q48);

            #endregion

            #region R1670_00_REPASSA_SAF_DB_SELECT_1_Query1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "V0RSAF_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1670_00_REPASSA_SAF_DB_SELECT_1_Query1", q49);

            #endregion

            #region R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0RSAF_DTREFER" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0SAFC_VLCUSTSAF" , ""},
                { "V0RSAF_CODOPER" , ""},
                { "V0PROP_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1", q50);

            #endregion

            #region R4500_00_SOLIC_RELAT_DB_SELECT_1_Query1

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_NRTIT" , ""},
                { "V0RELA_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4500_00_SOLIC_RELAT_DB_SELECT_1_Query1", q51);

            #endregion

            #region R4500_00_SOLIC_RELAT_DB_INSERT_1_Insert1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_DTVENCTO" , ""},
                { "V0RELA_NRPARCEL" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0RELA_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4500_00_SOLIC_RELAT_DB_INSERT_1_Insert1", q52);

            #endregion

            #region R5000_00_BUSCA_VLPREMIO_DB_SELECT_1_Query1

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLPREMIO_REL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_BUSCA_VLPREMIO_DB_SELECT_1_Query1", q53);

            #endregion

            #region R5000_00_BUSCA_VLPREMIO_DB_SELECT_2_Query1

            var q54 = new DynamicData();
            q54.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLPREMIO_REL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_BUSCA_VLPREMIO_DB_SELECT_2_Query1", q54);

            #endregion

            #region R8000_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1

            var q55 = new DynamicData();
            q55.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8000_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1", q55);

            #endregion

            #region R8100_00_GERAR_ARQSIVPF_DB_INSERT_1_Insert1

            var q56 = new DynamicData();
            q56.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8100_00_GERAR_ARQSIVPF_DB_INSERT_1_Insert1", q56);

            #endregion

            #region R8210_00_INSERT_CNTRLE_PROC_DB_INSERT_1_Insert1

            var q57 = new DynamicData();
            q57.AddDynamic(new Dictionary<string, string>{
                { "PF087_SIGLA_ARQUIVO" , ""},
                { "PF087_SISTEMA_ORIGEM" , ""},
                { "PF087_NSAS_SIVPF" , ""},
                { "PF087_NUM_PROPOSTA" , ""},
                { "PF087_SEQ_OCORRENCIA" , ""},
                { "PF087_NUM_DET_ARQ_PROPOSTA" , ""},
                { "PF087_NUM_ERRO_PROPOSTA" , ""},
                { "PF087_NUM_APOLICE_VINCULADA" , ""},
                { "PF087_NUM_LINHA_ARQUIVO" , ""},
                { "PF087_DES_CONTEUDO" , ""},
                { "PF087_STA_PROCESSAMENTO" , ""},
                { "PF087_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8210_00_INSERT_CNTRLE_PROC_DB_INSERT_1_Insert1", q57);

            #endregion

            #region R8220_00_SELECT_RELATORI_DB_SELECT_1_Query1

            var q58 = new DynamicData();
            q58.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_CODRELAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8220_00_SELECT_RELATORI_DB_SELECT_1_Query1", q58);

            #endregion

            #region R8230_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1

            var q59 = new DynamicData();
            q59.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V0PROP_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8230_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1", q59);

            #endregion

            #endregion
        }
        [Theory]
        [InlineData("Saida.txt")]
        public static void VA0853B_Tests_Theory(string ARQSAIDA_FILE_NAME_P)
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

                var parametroEntrada = new VA0853B_LK_PARAMETROS();
                parametroEntrada.LK_DT_PROCESSAMENTO.Value = "2024-08-21";
                parametroEntrada.LK_NUM_CERTIFICADO.Value = 333;
                parametroEntrada.LK_OPERACAO.Value = "1";

                var program = new VA0853B();
                program.Execute(parametroEntrada, ARQSAIDA_FILE_NAME_P);


                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}