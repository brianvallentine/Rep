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
using static Code.VP0121B;
using Moq;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("VP0121B_Tests")]
    public class VP0121B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , ""},
                { "SISTEMA_CURRDATE" , ""},
                { "SISTEMA_DTMOVABE2" , ""},
                { "SISTEMA_DTMOVABE3" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_NUM_RAMO_PRSTMISTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q1);

            #endregion

            #region VP0121B_CPROPVA

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_CODPRODU" , ""},
                { "PROPVA_CODCLIEN" , ""},
                { "PROPVA_OCOREND" , ""},
                { "PROPVA_FONTE" , ""},
                { "PROPVA_AGECOBR" , ""},
                { "PROPVA_OPCAO_COBER" , ""},
                { "PROPVA_DTQITBCO" , ""},
                { "PROPVA_DTINICDG" , ""},
                { "PROPVA_DTINISAF" , ""},
                { "PROPVA_DTPROXVEN" , ""},
                { "PROPVA_DTMINVEN" , ""},
                { "PROPVA_NRMATRVEN" , ""},
                { "PROPVA_CODOPER" , ""},
                { "PROPVA_DTMOVTO" , ""},
                { "PROPVA_SITUACAO" , ""},
                { "PROPVA_NUM_APOLICE1" , ""},
                { "PROPVA_CODSUBES1" , ""},
                { "PROPVA_OCORHIST" , ""},
                { "PROPVA_NRPARCEL" , ""},
                { "PROPVA_SIT_INTERF" , ""},
                { "PROPVA_TIMESTAMP" , ""},
                { "PROPVA_IDADE" , ""},
                { "PROPVA_SEXO" , ""},
                { "PROPVA_EST_CIV" , ""},
                { "PROPVA_COD_CRM" , ""},
                { "PROPVA_NRMATRFUN" , ""},
                { "PROPVA_DTADMIS" , ""},
                { "PROPVA_NRPROPOS" , ""},
                { "PROPVA_CODCCT" , ""},
                { "PROPVA_CODUSU" , ""},
                { "PROPVA_DTVENCTO" , ""},
                { "PROPVA_FAIXA_RENDA_IND" , ""},
                { "PROPVA_DATA" , ""},
                { "PROPVA_DPS_TITULAR" , ""},
                { "PROPVA_ORIGEM_PROPOSTA" , ""},
                { "PROPVA_ACATAMENTO" , ""},
                { "PROPVA_COD_OPER_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0121B_CPROPVA", q2);

            #endregion

            #region VP0121B_V1RCAPCOMP

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("VP0121B_V1RCAPCOMP", q3);

            #endregion

            #region M_0000_PRINCIPAL_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_UPDATE_1_Update1", q4);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_3_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SUBGRU_CODSUBES" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_3_Query1", q5);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_4_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_4_Query1", q6);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PRODVG_CODPRODAZ" , ""},
                { "PRODVG_PERIPGTO" , ""},
                { "PRODVG_ESTR_COBR" , ""},
                { "PRODVG_ORIG_PRODU" , ""},
                { "PRODVG_AGENCIADOR" , ""},
                { "PRODVG_TEM_SAF" , ""},
                { "PRODVG_TEM_CDG" , ""},
                { "PRODVG_CODRELAT" , ""},
                { "PRODVG_COBERADIC_PREMIO" , ""},
                { "PRODVG_CUSTOCAP_TOTAL" , ""},
                { "PRODVG_DESCONTO_ADESAO" , ""},
                { "PRODVG_COD_PRODUTO" , ""},
                { "PRODVG_RISCO" , ""},
                { "PRODVG_SITPLANCEF" , ""},
                { "PRODVG_ARQ_FDCAP" , ""},
                { "PRODVG_COD_RUBRICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_0100_OPCAOPAGVA_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_OPCAOPAG" , ""},
                { "OPCAOP_PERIPGTO" , ""},
                { "OPCAOP_DIA_DEB" , ""},
                { "OPCAOP_AGECTADEB" , ""},
                { "OPCAOP_OPRCTADEB" , ""},
                { "OPCAOP_NUMCTADEB" , ""},
                { "OPCAOP_DIGCTADEB" , ""},
                { "OPCAOP_CARTAOCRED" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_PERIPGTO" , ""},
                { "OPCAOP_OPCAOPAG" , ""},
                { "OPCAOP_DIA_DEB" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1", q9);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "WTEM_ERRO_7705" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1", q10);

            #endregion

            #region M_0100_OPCAOPAGVA_DB_SELECT_2_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0AGCEF_COD_AGCOBR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_2_Query1", q11);

            #endregion

            #region M_0100_NEXT_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_NEXT_DB_UPDATE_1_Update1", q12);

            #endregion

            #region M_0100_OPCAOPAGVA_DB_SELECT_3_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0COBER_MINOCOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_3_Query1", q13);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "WTEM_ERRO_7715" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1", q14);

            #endregion

            #region M_0100_OPCAOPAGVA_DB_SELECT_4_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "COBERP_DTINIVIG" , ""},
                { "COBERP_DTTERVIG" , ""},
                { "COBERP_IMPMORNATU" , ""},
                { "COBERP_IMPMORACID" , ""},
                { "COBERP_IMPINVPERM" , ""},
                { "COBERP_IMPAMDS" , ""},
                { "COBERP_IMPDH" , ""},
                { "COBERP_IMPDIT" , ""},
                { "COBERP_VLPREMIO" , ""},
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "COBERP_IMPSEGCDG" , ""},
                { "COBERP_VLCUSTCDG" , ""},
                { "COBERP_VLCUSTCAP" , ""},
                { "COBERP_IMPSEGAUXF" , ""},
                { "COBERP_VLCUSTAUXF" , ""},
                { "COBERP_QTTITCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_4_Query1", q15);

            #endregion

            #region M_0100_OPCAOPAGVA_DB_SELECT_5_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "COBERP_DTINIVIG" , ""},
                { "COBERP_IMPMORNATU" , ""},
                { "COBERP_IMPMORACID" , ""},
                { "COBERP_IMPINVPERM" , ""},
                { "COBERP_IMPAMDS" , ""},
                { "COBERP_IMPDH" , ""},
                { "COBERP_IMPDIT" , ""},
                { "COBERP_VLPREMIO" , ""},
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "COBERP_IMPSEGCDG" , ""},
                { "COBERP_VLCUSTCDG" , ""},
                { "COBERP_VLCUSTCAP" , ""},
                { "COBERP_IMPSEGAUXF" , ""},
                { "COBERP_VLCUSTAUXF" , ""},
                { "COBERP_QTTITCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_5_Query1", q16);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1", q17);

            #endregion

            #region M_0100_OPCAOPAGVA_DB_SELECT_6_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_6_Query1", q18);

            #endregion

            #region M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "ERRPROVI_COD_ERRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1", q19);

            #endregion

            #region M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_DTPROXVEN" , ""},
                { "PROPVA_CODPRODU" , ""},
                { "PROPVA_SITUACAO" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_CODOPER" , ""},
                { "MDTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1", q20);

            #endregion

            #region M_0100_OPCAOPAGVA_DB_SELECT_7_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_7_Query1", q21);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRPROPOS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1", q22);

            #endregion

            #region M_0100_OPCAOPAGVA_DB_SELECT_8_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , ""},
                { "RELATO_CODSUBES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_8_Query1", q23);

            #endregion

            #region M_0100_OPCAOPAGVA_DB_SELECT_9_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , ""},
                { "RELATO_CODSUBES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_9_Query1", q24);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1", q25);

            #endregion

            #region M_0100_OPCAOPAGVA_DB_SELECT_10_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , ""},
                { "RELATO_CODSUBES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_10_Query1", q26);

            #endregion

            #region M_0110_FETCH_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA_MOVIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_DB_SELECT_1_Query1", q27);

            #endregion

            #region M_0110_FETCH_DB_UPDATE_1_Update1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_DB_UPDATE_1_Update1", q28);

            #endregion

            #region M_0100_OPCAOPAGVA_DB_SELECT_11_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , ""},
                { "RELATO_CODSUBES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_11_Query1", q29);

            #endregion

            #region M_0110_FETCH_DB_SELECT_2_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_DB_SELECT_2_Query1", q30);

            #endregion

            #region M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""},
                { "WHOST_PROXIMA_DATA" , ""},
                { "CALENDAR_DIA_SEMANA" , ""},
                { "CALENDAR_FERIADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1", q31);

            #endregion

            #region M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "RELATO_CODRELAT" , ""},
                { "PROPVA_NUM_APOLICE" , ""},
                { "RELATO_NRPARCEL" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "RELATO_OPERACAO" , ""},
                { "WS_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1", q32);

            #endregion

            #region M_0300_VERIFICA_CROT_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_CGCCPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_VERIFICA_CROT_DB_SELECT_1_Query1", q33);

            #endregion

            #region M_0300_VERIFICA_CROT_DB_SELECT_2_Query1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "CLIROT_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_VERIFICA_CROT_DB_SELECT_2_Query1", q34);

            #endregion

            #region M_0320_UPDATE_CROT_DB_UPDATE_1_Update1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "CLIROT_DTMOVABE" , ""},
                { "CLIENT_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0320_UPDATE_CROT_DB_UPDATE_1_Update1", q35);

            #endregion

            #region M_0330_INCLUI_CROT_DB_INSERT_1_Insert1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_CGCCPF" , ""},
                { "SISTEMA_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0330_INCLUI_CROT_DB_INSERT_1_Insert1", q36);

            #endregion

            #region R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "V0FOLHM_DTEMICAR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1", q37);

            #endregion

            #region R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "V0FOLH_COD_CARTA" , ""},
                { "V0FOLH_DTEMICAR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1", q38);

            #endregion

            #region M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V0FOLH_COD_PRODUTO" , ""},
                { "V0FOLH_NRCERTIF" , ""},
                { "V0FOLH_COD_CARTA" , ""},
                { "V0FOLH_DTEMICAR" , ""},
                { "V0FOLH_DTSOLICIT" , ""},
                { "V0FOLH_CODUSU" , ""},
                { "V0FOLH_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1", q39);

            #endregion

            #region M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "CONVER_NUM_SICOB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1", q40);

            #endregion

            #region FINALIZA_1110_FIM_DB_UPDATE_1_Update1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "CONVER_NUM_PROPOSTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("FINALIZA_1110_FIM_DB_UPDATE_1_Update1", q41);

            #endregion

            #region M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , ""},
                { "V0RCAP_NRRCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1", q42);

            #endregion

            #region FINALIZA_1110_FIM_DB_UPDATE_2_Update1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "V0RCAP_NRRCAP" , ""},
                { "V0RCAP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("FINALIZA_1110_FIM_DB_UPDATE_2_Update1", q43);

            #endregion

            #region M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , ""},
                { "V0RCAP_NRRCAP" , ""},
                { "V0RCAP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1", q44);

            #endregion

            #region M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , ""},
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
                { "V1RCAC_DATARCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1", q45);

            # endregion

            #region VP0121B_CBENEFP

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "BENEF_NOMBENEF" , ""},
                { "BENEF_GRAUPAR" , ""},
                { "BENEF_PCTBENEF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0121B_CBENEFP", q46);

            #endregion

            #region M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_NRRCAPCO" , ""},
                { "V1RCAC_OPERACAO" , ""},
                { "V1RCAC_HORAOPER" , ""},
                { "V1RCAC_DTMOVTO" , ""},
                { "V1RCAC_NRRCAP" , ""},
                { "V1RCAC_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1", q47);

            #endregion

            #region M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , ""},
                { "V1RCAC_NRRCAP" , ""},
                { "V1RCAC_NRRCAPCO" , ""},
                { "V1RCAC_OPERACAO" , ""},
                { "SISTEMA_DTMOVABE" , ""},
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
            AppSettings.TestSet.DynamicData.Add("M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1", q48);

            #endregion

            #region M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_VLRCAP" , ""},
                { "V1RCAC_BCOAVISO" , ""},
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1", q49);

            #endregion

            #region M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "PRODVG_CODPRODAZ" , ""},
                { "PRODVG_ESTR_COBR" , ""},
                { "PRODVG_ORIG_PRODU" , ""},
                { "PRODVG_AGENCIADOR" , ""},
                { "PRODVG_TEM_SAF" , ""},
                { "PRODVG_TEM_CDG" , ""},
                { "PRODVG_CODRELAT" , ""},
                { "PRODVG_COBERADIC_PREMIO" , ""},
                { "PRODVG_CUSTOCAP_TOTAL" , ""},
                { "PRODVG_DESCONTO_ADESAO" , ""},
                { "PRODVG_COD_PRODUTO" , ""},
                { "PRODVG_RISCO" , ""},
                { "PRODVG_SITPLANCEF" , ""},
                { "PRODVG_ARQ_FDCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1", q50);

            #endregion

            #region M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>{
                { "MTXVG" , ""},
                { "MTXAPMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1", q51);

            #endregion

            #region M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODSUBES" , ""},
                { "MTXAPMA" , ""},
                { "MTXAPIP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1", q52);

            #endregion

            #region M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
                { "APCORR_RAMO" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "APCORR_DTINIVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1", q53);

            #endregion

            #region M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1

            var q54 = new DynamicData();
            q54.AddDynamic(new Dictionary<string, string>{
                { "COMISSOE_NUM_APOLICE" , ""},
                { "COMISSOE_NUM_ENDOSSO" , ""},
                { "COMISSOE_NUM_CERTIFICADO" , ""},
                { "COMISSOE_DAC_CERTIFICADO" , ""},
                { "COMISSOE_TIPO_SEGURADO" , ""},
                { "COMISSOE_NUM_PARCELA" , ""},
                { "COMISSOE_COD_OPERACAO" , ""},
                { "COMISSOE_COD_PRODUTOR" , ""},
                { "COMISSOE_RAMO_COBERTURA" , ""},
                { "COMISSOE_MODALI_COBERTURA" , ""},
                { "COMISSOE_OCORR_HISTORICO" , ""},
                { "COMISSOE_COD_FONTE" , ""},
                { "COMISSOE_COD_CLIENTE" , ""},
                { "COMISSOE_VAL_COMISSAO" , ""},
                { "COMISSOE_DATA_CALCULO" , ""},
                { "COMISSOE_NUM_RECIBO" , ""},
                { "COMISSOE_VAL_BASICO" , ""},
                { "COMISSOE_TIPO_COMISSAO" , ""},
                { "COMISSOE_QTD_PARCELAS" , ""},
                { "COMISSOE_PCT_COM_CORRETOR" , ""},
                { "COMISSOE_PCT_DESC_PREMIO" , ""},
                { "COMISSOE_COD_SUBGRUPO" , ""},
                { "COMISSOE_DATA_MOVIMENTO" , ""},
                { "COMISSOE_DATA_SELECAO" , ""},
                { "COMISSOE_COD_EMPRESA" , ""},
                { "COMISSOE_COD_PREPOSTO" , ""},
                { "COMISSOE_NUM_BILHETE" , ""},
                { "COMISSOE_VAL_VARMON" , ""},
                { "COMISSOE_DATA_QUITACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1", q54);

            #endregion

            #region M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1

            var q55 = new DynamicData();
            q55.AddDynamic(new Dictionary<string, string>{
                { "PROD_COD_EMPRESA" , ""},
                { "PARM_COD_EMPR_CAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1", q55);

            #endregion

            #region R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1

            var q56 = new DynamicData();
            q56.AddDynamic(new Dictionary<string, string>{
                { "COMFEDCA_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1", q56);

            #endregion

            #region R6290_10_INSERT_DB_INSERT_1_Insert1

            var q57 = new DynamicData();
            q57.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_FONTE" , ""},
                { "SISTEMA_DTMOVABE" , ""},
                { "MOVFEDCA_VAL_CUSTO_CAPITALI" , ""},
                { "MOVFEDCA_NRTITFDCAP" , ""},
                { "PRODVG_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6290_10_INSERT_DB_INSERT_1_Insert1", q57);

            #endregion

            #region R6300_00_INSERT_DB_INSERT_1_Insert1

            var q58 = new DynamicData();
            q58.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_NRTITFDCAP" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "TITFEDCA_DATA_INIVIGENCIA" , ""},
                { "TITFEDCA_DATA_TERVIGENCIA" , ""},
                { "TITFEDCA_NRSORTEIO" , ""},
                { "TITFEDCA_VAL_CUSTO_TITULO" , ""},
                { "SISTEMA_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6300_00_INSERT_DB_INSERT_1_Insert1", q58);

            #endregion

            #region R6400_10_INSERT_DB_INSERT_1_Insert1

            var q59 = new DynamicData();
            q59.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "SISTEMA_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6400_10_INSERT_DB_INSERT_1_Insert1", q59);

            #endregion

            #region R6500_10_INSERT_DB_INSERT_1_Insert1

            var q60 = new DynamicData();
            q60.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_NRTITFDCAP" , ""},
                { "PARFEDCA_VAL_CUSTO_TITULO" , ""},
                { "SISTEMA_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6500_10_INSERT_DB_INSERT_1_Insert1", q60);

            #endregion

            #region R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1

            var q61 = new DynamicData();
            q61.AddDynamic(new Dictionary<string, string>{
                { "COMFEDCA_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1", q61);

            #endregion

            #region R7400_10_INSERT_DB_INSERT_1_Insert1

            var q62 = new DynamicData();
            q62.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "SISTEMA_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7400_10_INSERT_DB_INSERT_1_Insert1", q62);

            #endregion

            #region M_8000_INTEGRA_VG_DB_SELECT_1_Query1

            var q63 = new DynamicData();
            q63.AddDynamic(new Dictionary<string, string>{
                { "CONDTE_IEA" , ""},
                { "CONDTE_IPA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_1_Query1", q63);

            #endregion

            #region R8000_PROPAUTOM_DB_INSERT_1_Insert1

            var q64 = new DynamicData();
            q64.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_FONTE" , ""},
                { "FONTE_PROPAUTOM" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "MTPINCLUS" , ""},
                { "PROPVA_CODCLIEN" , ""},
                { "MAGENCIADOR" , ""},
                { "MMFAIXA" , ""},
                { "MTPBENEF" , ""},
                { "OPCAOP_PERIPGTO" , ""},
                { "PROPVA_EST_CIV" , ""},
                { "PROPVA_SEXO" , ""},
                { "MAGECOBR" , ""},
                { "MMNUM_MATRICULA" , ""},
                { "MNUM_CTA_CORRENTE" , ""},
                { "MDAC_CTA_CORRENTE" , ""},
                { "MTXAPMA" , ""},
                { "MTXAPIP" , ""},
                { "MTXVG" , ""},
                { "COBERP_IMPMORNATU" , ""},
                { "COBERP_IMPMORACID" , ""},
                { "COBERP_IMPINVPERM" , ""},
                { "COBERP_IMPAMDS" , ""},
                { "COBERP_IMPDH" , ""},
                { "COBERP_IMPDIT" , ""},
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "MCODOPER" , ""},
                { "SISTEMA_DTMOVABE" , ""},
                { "PROPVA_CODUSU" , ""},
                { "WSISTEMA_DTMOVABE" , ""},
                { "CLIENT_DTNASC" , ""},
                { "MDTREF" , ""},
                { "MMDTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_INSERT_1_Insert1", q64);

            #endregion

            #region M_8000_INTEGRA_VG_DB_SELECT_2_Query1

            var q65 = new DynamicData();
            q65.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_2_Query1", q65);

            #endregion

            #region R8000_PROPAUTOM_DB_UPDATE_1_Update1

            var q66 = new DynamicData();
            q66.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""},
                { "PROPVA_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_1_Update1", q66);

            #endregion

            #region R8000_PROPAUTOM_DB_INSERT_2_Insert1

            var q67 = new DynamicData();
            q67.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_FONTE" , ""},
                { "FONTE_PROPAUTOM" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "MTPINCLUS" , ""},
                { "PROPVA_CODCLIEN" , ""},
                { "MAGENCIADOR" , ""},
                { "MMFAIXA" , ""},
                { "MTPBENEF" , ""},
                { "OPCAOP_PERIPGTO" , ""},
                { "PROPVA_EST_CIV" , ""},
                { "PROPVA_SEXO" , ""},
                { "MAGECOBR" , ""},
                { "MMNUM_MATRICULA" , ""},
                { "MNUM_CTA_CORRENTE" , ""},
                { "MDAC_CTA_CORRENTE" , ""},
                { "MTXAPMA" , ""},
                { "MTXAPIP" , ""},
                { "MTXVG" , ""},
                { "COBERP_IMPMORNATU" , ""},
                { "COBERP_IMPMORACID" , ""},
                { "COBERP_IMPINVPERM" , ""},
                { "COBERP_IMPAMDS" , ""},
                { "COBERP_IMPDH" , ""},
                { "COBERP_IMPDIT" , ""},
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "MCODOPER" , ""},
                { "SISTEMA_DTMOVABE" , ""},
                { "PROPVA_CODUSU" , ""},
                { "WSISTEMA_DTMOVABE" , ""},
                { "PROPVA_DTADMIS" , ""},
                { "CLIENT_DTNASC" , ""},
                { "MDTREF" , ""},
                { "MMDTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_INSERT_2_Insert1", q67);

            #endregion

            #region R8000_PROPAUTOM_DB_UPDATE_2_Update1

            var q68 = new DynamicData();
            q68.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_2_Update1", q68);

            #endregion

            #region R8000_PROPAUTOM_DB_SELECT_1_Query1

            var q69 = new DynamicData();
            q69.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_SELECT_1_Query1", q69);

            #endregion

            #region R8000_PROPAUTOM_DB_UPDATE_3_Update1

            var q70 = new DynamicData();
            q70.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_3_Update1", q70);

            #endregion

            #region M_8000_INTEGRA_VG_DB_SELECT_3_Query1

            var q71 = new DynamicData();
            q71.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , ""},
                { "MTXVG" , ""},
                { "MTXAPMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_3_Query1", q71);

            #endregion

            #region R8000_PROPAUTOM_DB_SELECT_2_Query1

            var q72 = new DynamicData();
            q72.AddDynamic(new Dictionary<string, string>{
                { "COMISI_VALADT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_SELECT_2_Query1", q72);

            #endregion

            #region R8000_PROPAUTOM_DB_UPDATE_4_Update1

            var q73 = new DynamicData();
            q73.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_4_Update1", q73);

            #endregion

            #region M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1

            var q74 = new DynamicData();
            q74.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , ""},
                { "MTXVG" , ""},
                { "MTXAPMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1", q74);

            #endregion

            #region R8000_PROPAUTOM_DB_UPDATE_5_Update1

            var q75 = new DynamicData();
            q75.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_5_Update1", q75);

            #endregion

            #region M_8000_INTEGRA_VG_DB_SELECT_4_Query1

            var q76 = new DynamicData();
            q76.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , ""},
                { "MTXVG" , ""},
                { "MTXAPMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_4_Query1", q76);

            #endregion

            #region M_8000_INTEGRA_VG_DB_SELECT_5_Query1

            var q77 = new DynamicData();
            q77.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , ""},
                { "MTXVG" , ""},
                { "MTXAPMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_5_Query1", q77);

            #endregion

            #region M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1

            var q78 = new DynamicData();
            q78.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1", q78);

            #endregion

            #region VP0121B_C01_RCAPCOMP

            var q79 = new DynamicData();
            q79.AddDynamic(new Dictionary<string, string>{
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_BCO_AVISO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_AGE_AVISO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_RCAP" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0121B_C01_RCAPCOMP", q79);

            #endregion

            #region M_8100_LOOP_DB_INSERT_1_Insert1

            var q80 = new DynamicData();
            q80.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_FONTE" , ""},
                { "FONTE_PROPAUTOM" , ""},
                { "BENEF_NRBENEF" , ""},
                { "BENEF_NOMBENEF" , ""},
                { "BENEF_GRAUPAR" , ""},
                { "BENEF_PCTBENEF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8100_LOOP_DB_INSERT_1_Insert1", q80);

            #endregion

            #region M_8200_CONCEDE_CDG_DB_SELECT_1_Query1

            var q81 = new DynamicData();
            q81.AddDynamic(new Dictionary<string, string>{
                { "CDGCOB_DTINIVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8200_CONCEDE_CDG_DB_SELECT_1_Query1", q81);

            #endregion

            #region M_8200_CONCEDE_CDG_DB_SELECT_2_Query1

            var q82 = new DynamicData();
            q82.AddDynamic(new Dictionary<string, string>{
                { "REPCDG_DTREF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8200_CONCEDE_CDG_DB_SELECT_2_Query1", q82);

            #endregion

            #region M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1

            var q83 = new DynamicData();
            q83.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1", q83);

            #endregion

            #region M_8220_INCLUI_CDG_DB_INSERT_1_Insert1

            var q84 = new DynamicData();
            q84.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , ""},
                { "PROPVA_DTINICDG" , ""},
                { "COBERP_IMPSEGCDG" , ""},
                { "COBERP_VLCUSTCDG" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8220_INCLUI_CDG_DB_INSERT_1_Insert1", q84);

            #endregion

            #region M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1

            var q85 = new DynamicData();
            q85.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , ""},
                { "REPCDG_DTREF" , ""},
                { "COBERP_VLCUSTCDG" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "SISTEMA_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1", q85);

            #endregion

            #region M_8300_CONCEDE_SAF_DB_SELECT_1_Query1

            var q86 = new DynamicData();
            q86.AddDynamic(new Dictionary<string, string>{
                { "SAFCOB_DTINIVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8300_CONCEDE_SAF_DB_SELECT_1_Query1", q86);

            #endregion

            #region M_8300_CONCEDE_SAF_DB_SELECT_2_Query1

            var q87 = new DynamicData();
            q87.AddDynamic(new Dictionary<string, string>{
                { "REPSAF_DTREF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8300_CONCEDE_SAF_DB_SELECT_2_Query1", q87);

            #endregion

            #region M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1

            var q88 = new DynamicData();
            q88.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1", q88);

            #endregion

            #region M_8320_INCLUI_SAF_DB_INSERT_1_Insert1

            var q89 = new DynamicData();
            q89.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , ""},
                { "PROPVA_DTINISAF" , ""},
                { "COBERP_IMPSEGAUXF" , ""},
                { "COBERP_VLCUSTAUXF" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8320_INCLUI_SAF_DB_INSERT_1_Insert1", q89);

            #endregion

            #region M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1

            var q90 = new DynamicData();
            q90.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , ""},
                { "REPSAF_DTREF" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_NRMATRFUN" , ""},
                { "COBERP_VLCUSTAUXF" , ""},
                { "PROPVA_CODOPER" , ""},
                { "PROPVA_DTQITBCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1", q90);

            #endregion

            #region M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1

            var q91 = new DynamicData();
            q91.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , ""},
                { "REPSAF_DTREF" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_NRMATRFUN" , ""},
                { "COBERP_VLCUSTAUXF" , ""},
                { "PROPVA_DTQITBCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1", q91);

            #endregion

            #region M_8400_00_DEBITO_CARTAO_DB_INSERT_1_Insert1

            var q92 = new DynamicData();
            q92.AddDynamic(new Dictionary<string, string>{
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
            });
            AppSettings.TestSet.DynamicData.Add("M_8400_00_DEBITO_CARTAO_DB_INSERT_1_Insert1", q92);

            #endregion

            #region M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1

            var q93 = new DynamicData();
            q93.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1", q93);

            #endregion

            #region M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1

            var q94 = new DynamicData();
            q94.AddDynamic(new Dictionary<string, string>{
                { "W03_VENCIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1", q94);

            #endregion

            #region M_8600_10_CONTINUA_DB_SELECT_1_Query1

            var q95 = new DynamicData();
            q95.AddDynamic(new Dictionary<string, string>{
                { "DESCON_PERC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_SELECT_1_Query1", q95);

            #endregion

            #region M_8600_10_CONTINUA_DB_INSERT_1_Insert1

            var q96 = new DynamicData();
            q96.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "HISTCB_DTVENCTO" , ""},
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "OPCAOP_OPCAOPAG" , ""},
                { "PARCEL_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_INSERT_1_Insert1", q96);

            #endregion

            #region M_8600_CONTINUA_DB_UPDATE_1_Update1

            var q97 = new DynamicData();
            q97.AddDynamic(new Dictionary<string, string>{
                { "HISTCB_DTVENCTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8600_CONTINUA_DB_UPDATE_1_Update1", q97);

            #endregion

            #region M_8600_10_CONTINUA_DB_INSERT_2_Insert1

            var q98 = new DynamicData();
            q98.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "BANCOS_NRTIT" , ""},
                { "HISTCB_DTVENCTO" , ""},
                { "DESCON_VLPREMIO" , ""},
                { "OPCAOP_OPCAOPAG" , ""},
                { "HISTCB_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_INSERT_2_Insert1", q98);

            #endregion

            #region M_8600_CONTINUA_DB_UPDATE_2_Update1

            var q99 = new DynamicData();
            q99.AddDynamic(new Dictionary<string, string>{
                { "WS_PROPVA_DTPROXVEN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8600_CONTINUA_DB_UPDATE_2_Update1", q99);

            #endregion

            #region M_8600_10_CONTINUA_DB_INSERT_3_Insert1

            var q100 = new DynamicData();
            q100.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "HISTCB_DTVENCTO" , ""},
                { "DESCON_PRMVG" , ""},
                { "DESCON_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_INSERT_3_Insert1", q100);

            #endregion

            #region M_8700_GERA_DEBITO_DB_SELECT_1_Query1

            var q101 = new DynamicData();
            q101.AddDynamic(new Dictionary<string, string>{
                { "CONVEN_CODCONV" , ""},
                { "CONVEN_CARTAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8700_GERA_DEBITO_DB_SELECT_1_Query1", q101);

            #endregion

            #region M_8700_GERA_DEBITO_DB_INSERT_1_Insert1

            var q102 = new DynamicData();
            q102.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "OPCAOP_AGECTADEB" , ""},
                { "OPCAOP_OPRCTADEB" , ""},
                { "OPCAOP_NUMCTADEB" , ""},
                { "OPCAOP_DIGCTADEB" , ""},
                { "HISTCB_DTVENCTO" , ""},
                { "DESCON_VLPREMIO" , ""},
                { "HOST_CODCONV" , ""},
                { "OPCAOP_CARTAOCRED" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8700_GERA_DEBITO_DB_INSERT_1_Insert1", q102);

            #endregion

            #region M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1

            var q103 = new DynamicData();
            q103.AddDynamic(new Dictionary<string, string>{
                { "FUNDO_PCCOMIND" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1", q103);

            #endregion

            #region M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1

            var q104 = new DynamicData();
            q104.AddDynamic(new Dictionary<string, string>{
                { "FUNDO_PCCOMGER" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1", q104);

            #endregion

            #region M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1

            var q105 = new DynamicData();
            q105.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODPRODU" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_FONTE" , ""},
                { "PROPVA_AGECOBR" , ""},
                { "PROPVA_CODCLIEN" , ""},
                { "PROPVA_NRMATRVEN" , ""},
                { "FUNDO_VALBASVG" , ""},
                { "FUNDO_VALBASAP" , ""},
                { "FUNDO_VLCOMISVG" , ""},
                { "FUNDO_VLCOMISAP" , ""},
                { "PROPVA_DTQITBCO" , ""},
                { "FUNDO_PCCOMIND" , ""},
                { "FUNDO_PCCOMGER" , ""},
                { "FUNDO_PCCOMSUP" , ""},
                { "SISTEMA_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1", q105);

            #endregion

            #region M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1

            var q106 = new DynamicData();
            q106.AddDynamic(new Dictionary<string, string>{
                { "FUNDO_PCCOMSUP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1", q106);

            #endregion

            #region M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1

            var q107 = new DynamicData();
            q107.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1", q107);

            #endregion

            #region R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1

            var q108 = new DynamicData();
            q108.AddDynamic(new Dictionary<string, string>{
                { "SIVPF_NR_IDENTIFI" , ""},
                { "SIVPF_NR_SICOB" , ""},
                { "SIVPF_SIT_PROPOSTA" , ""},
                { "SIVPF_DTQITBCO" , ""},
                { "SIVPF_VAL_PAGO" , ""},
                { "SIVPF_DATA_CREDITO" , ""},
                { "SIVPF_OPCAO_COBER" , ""},
                { "SIVPF_COD_PLANO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1", q108);

            #endregion

            #region R7773_00_LER_RCAPS_DB_SELECT_1_Query1

            var q109 = new DynamicData();
            q109.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7773_00_LER_RCAPS_DB_SELECT_1_Query1", q109);

            #endregion

            #region R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1

            var q110 = new DynamicData();
            q110.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1", q110);

            #endregion

            #region R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1

            var q111 = new DynamicData();
            q111.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SIT_PROP_FIDELIZ" , ""},
                { "WHOST_SITUACAO_ENVIO" , ""},
                { "SIVPF_DATA_CREDITO" , ""},
                { "SIVPF_OPCAO_COBER" , ""},
                { "SIVPF_DTQITBCO" , ""},
                { "SIVPF_VAL_PAGO" , ""},
                { "SIVPF_NR_PROPOSTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1", q111);

            #endregion

            #region R7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1_Update1

            var q112 = new DynamicData();
            q112.AddDynamic(new Dictionary<string, string>{
                { "CONVER_NUM_SICOB" , ""},
                { "SIVPF_NR_PROPOSTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1_Update1", q112);

            #endregion

            #region M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1

            var q113 = new DynamicData();
            q113.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1", q113);

            #endregion

            #region M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1

            var q114 = new DynamicData();
            q114.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "DIFPAR_CODOPER" , ""},
                { "PROPVA_DTQITBCO" , ""},
                { "COBERP_VLPREMIO" , ""},
                { "V0HCOB_VLPRMTOT" , ""},
                { "DIFPAR_PRMVG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1", q114);

            #endregion

            #region M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1

            var q115 = new DynamicData();
            q115.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1", q115);

            #endregion

            #endregion
        }              
                
        [Fact]
        public static void VP0121B_Tests_Selects1_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                PROSOCU1_Tests.Load_Parameters();
                PROTIT01_Tests.Load_Parameters();
                FC0105B_Tests.Load_Parameters();
                FC0001S_Tests.Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , "2025-03-17" },
                { "SISTEMA_CURRDATE" , "2025-05-14" },
                { "SISTEMA_DTMOVABE2" , "2025-05-22" },
                { "SISTEMA_DTMOVABE3" , "2025-06-14" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_NUM_RAMO_PRSTMISTA" , "77" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q1);

                #endregion

                #region VP0121B_CPROPVA

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "107700000011" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_CODPRODU" , "7705" },
                { "PROPVA_CODCLIEN" , "456789" },
                { "PROPVA_OCOREND" , "12345" },
                { "PROPVA_FONTE" , "CEF" },
                { "PROPVA_AGECOBR" , "001" },
                { "PROPVA_OPCAO_COBER" , "A" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
                { "PROPVA_DTINICDG" , "2023-01-01" },
                { "PROPVA_DTINISAF" , "2023-01-01" },
                { "PROPVA_DTPROXVEN" , "2024-01-01" },
                { "PROPVA_DTMINVEN" , "2023-12-31" },
                { "PROPVA_NRMATRVEN" , "123456" },
                { "PROPVA_CODOPER" , "OP123" },
                { "PROPVA_DTMOVTO" , "2023-12-01" },
                { "PROPVA_SITUACAO" , "7" },
                { "PROPVA_NUM_APOLICE1" , "107700000011" },
                { "PROPVA_CODSUBES1" , "002" },
                { "PROPVA_OCORHIST" , "Ocorrencia Teste" },
                { "PROPVA_NRPARCEL" , "12" },
                { "PROPVA_SIT_INTERF" , "Ativa" },
                { "PROPVA_TIMESTAMP" , "2023-12-01T12:00:00" },
                { "PROPVA_IDADE" , "35" },
                { "PROPVA_SEXO" , "M" },
                { "PROPVA_EST_CIV" , "Casado" },
                { "PROPVA_COD_CRM" , "CRM123" },
                { "PROPVA_NRMATRFUN" , "654321" },
                { "PROPVA_DTADMIS" , "2020-01-01" },
                { "PROPVA_NRPROPOS" , "27708000280671" },
                { "PROPVA_CODCCT" , "CCT001" },
                { "PROPVA_CODUSU" , "USU123" },
                { "PROPVA_DTVENCTO" , "2024-01-01" },
                { "PROPVA_FAIXA_RENDA_IND" , "Alta" },
                { "PROPVA_DATA" , "2023-12-01" },
                { "PROPVA_DPS_TITULAR" , "Sim" },
                { "PROPVA_ORIGEM_PROPOSTA" , "1000" },
                { "PROPVA_ACATAMENTO" , "N" },
                { "PROPVA_COD_OPER_CREDITO" , "CRED123" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0121B_CPROPVA");
                AppSettings.TestSet.DynamicData.Add("VP0121B_CPROPVA", q2);

                #endregion

                #region VP0121B_V1RCAPCOMP

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , "Fonte1" },
                { "V1RCAC_NRRCAP" , "321" },
                { "V1RCAC_NRRCAPCO" , "321CO" },
                { "V1RCAC_OPERACAO" , "Oper123" },
                { "V1RCAC_DTMOVTO" , "2023-12-01" },
                { "V1RCAC_HORAOPER" , "12:00" },
                { "V1RCAC_SITUACAO" , "Ativa" },
                { "V1RCAC_BCOAVISO" , "001" },
                { "V1RCAC_AGEAVISO" , "002" },
                { "V1RCAC_NRAVISO" , "003" },
                { "V1RCAC_VLRCAP" , "1000.00" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
                { "V1RCAC_DTCADAST" , "2023-12-01" },
                { "V1RCAC_SITCONTB" , "Confirmada" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0121B_V1RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("VP0121B_V1RCAPCOMP", q3);

                #endregion

                #region M_0000_PRINCIPAL_DB_UPDATE_1_Update1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NRTIT" , "85172719932" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_UPDATE_1_Update1", q4);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_3_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SUBGRU_CODSUBES" , "0" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_3_Query1", q5);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_4_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NRTIT" , "85172719932" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_4_Query1", q6);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "PRODVG_CODPRODAZ" , "P123" },
                { "PRODVG_PERIPGTO" , "Mensal" },
                { "PRODVG_ESTR_COBR" , "Estruturada" },
                { "PRODVG_ORIG_PRODU" , "MULTI" },
                { "PRODVG_AGENCIADOR" , "Agente123" },
                { "PRODVG_TEM_SAF" , "Sim" },
                { "PRODVG_TEM_CDG" , "Não" },
                { "PRODVG_CODRELAT" , "R123" },
                { "PRODVG_COBERADIC_PREMIO" , "100.00" },
                { "PRODVG_CUSTOCAP_TOTAL" , "200.00" },
                { "PRODVG_DESCONTO_ADESAO" , "10.00" },
                { "PRODVG_COD_PRODUTO" , "7705" },
                { "PRODVG_RISCO" , "Baixo" },
                { "PRODVG_SITPLANCEF" , "Ativo" },
                { "PRODVG_ARQ_FDCAP" , "Arquivo123" },
                { "PRODVG_COD_RUBRICA" , "RUB001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1", q7);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_OPCAOPAG" , "1" },
                { "OPCAOP_PERIPGTO" , "0" },
                { "OPCAOP_DIA_DEB" , "10" },
                { "OPCAOP_AGECTADEB" , "001" },
                { "OPCAOP_OPRCTADEB" , "OPR001" },
                { "OPCAOP_NUMCTADEB" , "123456" },
                { "OPCAOP_DIGCTADEB" , "7" },
                { "OPCAOP_CARTAOCRED" , "4111111111111111" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_1_Query1", q8);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_PERIPGTO" , "0" },
                { "OPCAOP_OPCAOPAG" , "1" },
                { "OPCAOP_DIA_DEB" , "10" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1", q9);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "WTEM_ERRO_7705" , "Erro7705" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1", q10);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_2_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V0AGCEF_COD_AGCOBR" , "AG001" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_2_Query1", q11);

                #endregion

                #region M_0100_NEXT_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_NEXT_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0100_NEXT_DB_UPDATE_1_Update1", q12);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_3_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V0COBER_MINOCOR" , "MinOcor001" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_3_Query1", q13);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "WTEM_ERRO_7715" , "Erro7715" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1", q14);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_4_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "COBERP_DTINIVIG" , "2023-01-01" },
                { "COBERP_DTTERVIG" , "2024-01-01" },
                { "COBERP_IMPMORNATU" , "50.00" },
                { "COBERP_IMPMORACID" , "100.00" },
                { "COBERP_IMPINVPERM" , "150.00" },
                { "COBERP_IMPAMDS" , "200.00" },
                { "COBERP_IMPDH" , "250.00" },
                { "COBERP_IMPDIT" , "300.00" },
                { "COBERP_VLPREMIO" , "350.00" },
                { "COBERP_PRMVG" , "400.00" },
                { "COBERP_PRMAP" , "450.00" },
                { "COBERP_IMPSEGCDG" , "500.00" },
                { "COBERP_VLCUSTCDG" , "550.00" },
                { "COBERP_VLCUSTCAP" , "600.00" },
                { "COBERP_IMPSEGAUXF" , "650.00" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "COBERP_QTTITCAP" , "750" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_4_Query1", q15);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_5_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "COBERP_DTINIVIG" , "2023-01-01" },
                { "COBERP_IMPMORNATU" , "50.00" },
                { "COBERP_IMPMORACID" , "100.00" },
                { "COBERP_IMPINVPERM" , "150.00" },
                { "COBERP_IMPAMDS" , "200.00" },
                { "COBERP_IMPDH" , "250.00" },
                { "COBERP_IMPDIT" , "300.00" },
                { "COBERP_VLPREMIO" , "350.00" },
                { "COBERP_PRMVG" , "400.00" },
                { "COBERP_PRMAP" , "450.00" },
                { "COBERP_IMPSEGCDG" , "500.00" },
                { "COBERP_VLCUSTCDG" , "550.00" },
                { "COBERP_VLCUSTCAP" , "600.00" },
                { "COBERP_IMPSEGAUXF" , "650.00" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "COBERP_QTTITCAP" , "750" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_5_Query1", q16);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , "1988-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1", q17);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_6_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , "800.00" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_6_Query1", q18);

                #endregion

                #region M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "ERRPROVI_COD_ERRO" , "1002" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1", q19);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_DTPROXVEN" , "2024-01-01" },
                { "PROPVA_CODPRODU" , "7705" },
                { "PROPVA_SITUACAO" , "7" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_CODOPER" , "OP123" },
                { "MDTMOVTO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1", q20);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_7_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , "800.00" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_7_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_7_Query1", q21);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRPROPOS" , "27708000280671" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1", q22);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_8_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , "109300000598" },
                { "RELATO_CODSUBES" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_8_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_8_Query1", q23);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_9_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , "109300000598" },
                { "RELATO_CODSUBES" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_9_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_9_Query1", q24);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRCERTIF" , "987654321" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1", q25);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_10_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , "109300000598" },
                { "RELATO_CODSUBES" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_10_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_10_Query1", q26);

                #endregion

                #region M_0110_FETCH_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA_MOVIMENTO" , "2023-12-01" }
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("M_0110_FETCH_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_DB_SELECT_1_Query1", q27);

                #endregion

                #region M_0110_FETCH_DB_UPDATE_1_Update1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0110_FETCH_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_DB_UPDATE_1_Update1", q28);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_11_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , "109300000598" },
                { "RELATO_CODSUBES" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_11_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_11_Query1", q29);

                #endregion

                #region M_0110_FETCH_DB_SELECT_2_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_RAMO" , "Vida" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0110_FETCH_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_DB_SELECT_2_Query1", q30);

                #endregion

                #region M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-12-01" },
                { "WHOST_PROXIMA_DATA" , "2023-12-02" },
                { "CALENDAR_DIA_SEMANA" , "Q" },
                { "CALENDAR_FERIADO" , "Não" },
            });

                q31.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-12-02" },
                { "WHOST_PROXIMA_DATA" , "2023-12-03" },
                { "CALENDAR_DIA_SEMANA" , "Q" },
                { "CALENDAR_FERIADO" , "Não" },
            });

                q31.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-12-03" },
                { "WHOST_PROXIMA_DATA" , "2023-12-04" },
                { "CALENDAR_DIA_SEMANA" , "Q" },
                { "CALENDAR_FERIADO" , "Não" },
            });
                q31.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-12-04" },
                { "WHOST_PROXIMA_DATA" , "2023-12-05" },
                { "CALENDAR_DIA_SEMANA" , "Q" },
                { "CALENDAR_FERIADO" , "Não" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1", q31);

                #endregion

                #region M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                { "RELATO_CODRELAT" , "R123" },
                { "PROPVA_NUM_APOLICE" , "107700000011" },
                { "RELATO_NRPARCEL" , "12" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_CODSUBES" , "001" },
                { "RELATO_OPERACAO" , "Oper123" },
                { "WS_SIT_REGISTRO" , "Ativo" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1", q32);

                #endregion

                #region M_0300_VERIFICA_CROT_DB_SELECT_1_Query1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_CGCCPF" , "12345678901" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0300_VERIFICA_CROT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0300_VERIFICA_CROT_DB_SELECT_1_Query1", q33);

                #endregion

                #region M_0300_VERIFICA_CROT_DB_SELECT_2_Query1

                var q34 = new DynamicData();
                q34.AddDynamic(new Dictionary<string, string>{
                { "CLIROT_DTMOVABE" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0300_VERIFICA_CROT_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0300_VERIFICA_CROT_DB_SELECT_2_Query1", q34);

                #endregion

                #region M_0320_UPDATE_CROT_DB_UPDATE_1_Update1

                var q35 = new DynamicData();
                q35.AddDynamic(new Dictionary<string, string>{
                { "CLIROT_DTMOVABE" , "2023-12-01" },
                { "CLIENT_CGCCPF" , "12345678901" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0320_UPDATE_CROT_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0320_UPDATE_CROT_DB_UPDATE_1_Update1", q35);

                #endregion

                #region M_0330_INCLUI_CROT_DB_INSERT_1_Insert1

                var q36 = new DynamicData();
                q36.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_CGCCPF" , "12345678901" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0330_INCLUI_CROT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0330_INCLUI_CROT_DB_INSERT_1_Insert1", q36);

                #endregion

                #region R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1

                var q37 = new DynamicData();
                q37.AddDynamic(new Dictionary<string, string>{
                { "V0FOLHM_DTEMICAR" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1", q37);

                #endregion

                #region R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1

                var q38 = new DynamicData();
                q38.AddDynamic(new Dictionary<string, string>{
                { "V0FOLH_COD_CARTA" , "C123" },
                { "V0FOLH_DTEMICAR" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1", q38);

                #endregion

                #region M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1

                var q39 = new DynamicData();
                q39.AddDynamic(new Dictionary<string, string>{
                { "V0FOLH_COD_PRODUTO" , "7705" },
                { "V0FOLH_NRCERTIF" , "987654321" },
                { "V0FOLH_COD_CARTA" , "C123" },
                { "V0FOLH_DTEMICAR" , "2023-12-01" },
                { "V0FOLH_DTSOLICIT" , "2023-12-01" },
                { "V0FOLH_CODUSU" , "USU123" },
                { "V0FOLH_SITUACAO" , "Ativa" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1", q39);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1

                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                { "CONVER_NUM_SICOB" , "SIC123" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1", q40);

                #endregion

                #region FINALIZA_1110_FIM_DB_UPDATE_1_Update1

                var q41 = new DynamicData();
                q41.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "CONVER_NUM_PROPOSTA" , "27708000280671" },
            });
                AppSettings.TestSet.DynamicData.Remove("FINALIZA_1110_FIM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("FINALIZA_1110_FIM_DB_UPDATE_1_Update1", q41);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1

                var q42 = new DynamicData();
                q42.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "Fonte1" },
                { "V0RCAP_NRRCAP" , "321" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1", q42);

                #endregion

                #region FINALIZA_1110_FIM_DB_UPDATE_2_Update1

                var q43 = new DynamicData();
                q43.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "V0RCAP_NRRCAP" , "321" },
                { "V0RCAP_FONTE" , "Fonte1" },
            });
                AppSettings.TestSet.DynamicData.Remove("FINALIZA_1110_FIM_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("FINALIZA_1110_FIM_DB_UPDATE_2_Update1", q43);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1

                var q44 = new DynamicData();
                q44.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "107700000011" },
                { "V0RCAP_NRRCAP" , "321" },
                { "V0RCAP_FONTE" , "Fonte1" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1", q44);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1

                var q45 = new DynamicData();
                q45.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "001" },
                { "V1RCAC_AGEAVISO" , "002" },
                { "V1RCAC_NRAVISO" , "003" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1", q45);

                #endregion

                #region VP0121B_CBENEFP

                var q46 = new DynamicData();
                q46.AddDynamic(new Dictionary<string, string>{
                { "BENEF_NOMBENEF" , "Nome Beneficiário" },
                { "BENEF_GRAUPAR" , "Grau Parentesco" },
                { "BENEF_PCTBENEF" , "50%" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0121B_CBENEFP");
                AppSettings.TestSet.DynamicData.Add("VP0121B_CBENEFP", q46);

                #endregion

                #region M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1

                var q47 = new DynamicData();
                q47.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_NRRCAPCO" , "321CO" },
                { "V1RCAC_OPERACAO" , "Oper123" },
                { "V1RCAC_HORAOPER" , "12:00" },
                { "V1RCAC_DTMOVTO" , "2023-12-01" },
                { "V1RCAC_NRRCAP" , "321" },
                { "V1RCAC_FONTE" , "Fonte1" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1", q47);

                #endregion

                #region M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1

                var q48 = new DynamicData();
                q48.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , "Fonte1" },
                { "V1RCAC_NRRCAP" , "321" },
                { "V1RCAC_NRRCAPCO" , "321CO" },
                { "V1RCAC_OPERACAO" , "Oper123" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
                { "V1RCAC_SITUACAO" , "Ativa" },
                { "V1RCAC_BCOAVISO" , "001" },
                { "V1RCAC_AGEAVISO" , "002" },
                { "V1RCAC_NRAVISO" , "003" },
                { "V1RCAC_VLRCAP" , "1000.00" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
                { "V1RCAC_DTCADAST" , "2023-12-01" },
                { "V1RCAC_SITCONTB" , "Confirmada" },
                { "V1RCAC_COD_EMPRESA" , "EMP123" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1", q48);

                #endregion

                #region M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1

                var q49 = new DynamicData();
                q49.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_VLRCAP" , "1000.00" },
                { "V1RCAC_BCOAVISO" , "001" },
                { "V1RCAC_AGEAVISO" , "002" },
                { "V1RCAC_NRAVISO" , "003" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1", q49);

                #endregion

                #region M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1

                var q50 = new DynamicData();
                q50.AddDynamic(new Dictionary<string, string>{
                { "PRODVG_CODPRODAZ" , "P123" },
                { "PRODVG_ESTR_COBR" , "Estruturada" },
                { "PRODVG_ORIG_PRODU" , "MULTI" },
                { "PRODVG_AGENCIADOR" , "Agente123" },
                { "PRODVG_TEM_SAF" , "Sim" },
                { "PRODVG_TEM_CDG" , "Não" },
                { "PRODVG_CODRELAT" , "R123" },
                { "PRODVG_COBERADIC_PREMIO" , "100.00" },
                { "PRODVG_CUSTOCAP_TOTAL" , "200.00" },
                { "PRODVG_DESCONTO_ADESAO" , "10.00" },
                { "PRODVG_COD_PRODUTO" , "7705" },
                { "PRODVG_RISCO" , "Baixo" },
                { "PRODVG_SITPLANCEF" , "Ativo" },
                { "PRODVG_ARQ_FDCAP" , "Arquivo123" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1", q50);

                #endregion

                #region M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1

                var q51 = new DynamicData();
                q51.AddDynamic(new Dictionary<string, string>{
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1", q51);

                #endregion

                #region M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1

                var q52 = new DynamicData();
                q52.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODSUBES" , "001" },
                { "MTXAPMA" , "Matriz AP MA" },
                { "MTXAPIP" , "Matriz AP IP" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1", q52);

                #endregion

                #region M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1

                var q53 = new DynamicData();
                q53.AddDynamic(new Dictionary<string, string>{
                { "APCORR_RAMO" , "Vida" },
                { "PROPVA_CODSUBES" , "001" },
                { "APCORR_DTINIVIG" , "2023-01-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1", q53);

                #endregion

                #region M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1

                var q54 = new DynamicData();
                q54.AddDynamic(new Dictionary<string, string>{
                { "COMISSOE_NUM_APOLICE" , "109300000598" },
                { "COMISSOE_NUM_ENDOSSO" , "E123" },
                { "COMISSOE_NUM_CERTIFICADO" , "7457254811" },
                { "COMISSOE_DAC_CERTIFICADO" , "DAC123" },
                { "COMISSOE_TIPO_SEGURADO" , "Titular" },
                { "COMISSOE_NUM_PARCELA" , "12" },
                { "COMISSOE_COD_OPERACAO" , "OP123" },
                { "COMISSOE_COD_PRODUTOR" , "Prod123" },
                { "COMISSOE_RAMO_COBERTURA" , "Vida" },
                { "COMISSOE_MODALI_COBERTURA" , "Modalidade1" },
                { "COMISSOE_OCORR_HISTORICO" , "Histórico Ocorrência" },
                { "COMISSOE_COD_FONTE" , "Fonte1" },
                { "COMISSOE_COD_CLIENTE" , "456789" },
                { "COMISSOE_VAL_COMISSAO" , "100.00" },
                { "COMISSOE_DATA_CALCULO" , "2023-12-01" },
                { "COMISSOE_NUM_RECIBO" , "R123456" },
                { "COMISSOE_VAL_BASICO" , "200.00" },
                { "COMISSOE_TIPO_COMISSAO" , "Tipo1" },
                { "COMISSOE_QTD_PARCELAS" , "12" },
                { "COMISSOE_PCT_COM_CORRETOR" , "10%" },
                { "COMISSOE_PCT_DESC_PREMIO" , "5%" },
                { "COMISSOE_COD_SUBGRUPO" , "SG001" },
                { "COMISSOE_DATA_MOVIMENTO" , "2023-12-01" },
                { "COMISSOE_DATA_SELECAO" , "2023-12-01" },
                { "COMISSOE_COD_EMPRESA" , "EMP123" },
                { "COMISSOE_COD_PREPOSTO" , "Prep123" },
                { "COMISSOE_NUM_BILHETE" , "B123456" },
                { "COMISSOE_VAL_VARMON" , "300.00" },
                { "COMISSOE_DATA_QUITACAO" , "2024-01-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1", q54);

                #endregion

                #region M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1

                var q55 = new DynamicData();
                q55.AddDynamic(new Dictionary<string, string>{
                { "PROD_COD_EMPRESA" , "EMP123" },
                { "PARM_COD_EMPR_CAP" , "EMP123" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1", q55);

                #endregion

                #region R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1

                var q56 = new DynamicData();
                q56.AddDynamic(new Dictionary<string, string>{
                { "COMFEDCA_SITUACAO" , "Ativa" }
            });
                AppSettings.TestSet.DynamicData.Remove("R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1", q56);

                #endregion

                #region R6290_10_INSERT_DB_INSERT_1_Insert1

                var q57 = new DynamicData();
                q57.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_FONTE" , "CEF" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
                { "MOVFEDCA_VAL_CUSTO_CAPITALI" , "100.00" },
                { "MOVFEDCA_NRTITFDCAP" , "123456" },
                { "PRODVG_COD_PRODUTO" , "7705" },
            });
                AppSettings.TestSet.DynamicData.Remove("R6290_10_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R6290_10_INSERT_DB_INSERT_1_Insert1", q57);

                #endregion

                #region R6300_00_INSERT_DB_INSERT_1_Insert1

                var q58 = new DynamicData();
                q58.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_NRTITFDCAP" , "123456" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "TITFEDCA_DATA_INIVIGENCIA" , "2023-01-01" },
                { "TITFEDCA_DATA_TERVIGENCIA" , "2024-01-01" },
                { "TITFEDCA_NRSORTEIO" , "S123456" },
                { "TITFEDCA_VAL_CUSTO_TITULO" , "150.00" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R6300_00_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R6300_00_INSERT_DB_INSERT_1_Insert1", q58);

                #endregion

                #region R6400_10_INSERT_DB_INSERT_1_Insert1

                var q59 = new DynamicData();
                q59.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R6400_10_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R6400_10_INSERT_DB_INSERT_1_Insert1", q59);

                #endregion

                #region R6500_10_INSERT_DB_INSERT_1_Insert1

                var q60 = new DynamicData();
                q60.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_NRTITFDCAP" , "123456" },
                { "PARFEDCA_VAL_CUSTO_TITULO" , "150.00" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R6500_10_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R6500_10_INSERT_DB_INSERT_1_Insert1", q60);

                #endregion

                #region R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1

                var q61 = new DynamicData();
                q61.AddDynamic(new Dictionary<string, string>{
                { "COMFEDCA_SITUACAO" , "Ativa" }
            });
                AppSettings.TestSet.DynamicData.Remove("R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1", q61);

                #endregion

                #region R7400_10_INSERT_DB_INSERT_1_Insert1

                var q62 = new DynamicData();
                q62.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7400_10_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R7400_10_INSERT_DB_INSERT_1_Insert1", q62);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_1_Query1

                var q63 = new DynamicData();
                q63.AddDynamic(new Dictionary<string, string>{
                { "CONDTE_IEA" , "Inclusão" },
                { "CONDTE_IPA" , "Proposta" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_1_Query1", q63);

                #endregion

                #region R8000_PROPAUTOM_DB_INSERT_1_Insert1

                var q64 = new DynamicData();
                q64.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "107700000011" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_FONTE" , "CEF" },
                { "FONTE_PROPAUTOM" , "Automática" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "MTPINCLUS" , "Inclusão Manual" },
                { "PROPVA_CODCLIEN" , "456789" },
                { "MAGENCIADOR" , "Agente123" },
                { "MMFAIXA" , "Faixa1" },
                { "MTPBENEF" , "Tipo Benefício" },
                { "OPCAOP_PERIPGTO" , "0" },
                { "PROPVA_EST_CIV" , "Casado" },
                { "PROPVA_SEXO" , "M" },
                { "MAGECOBR" , "Agência Cobrança" },
                { "MMNUM_MATRICULA" , "Mat123" },
                { "MNUM_CTA_CORRENTE" , "Conta123" },
                { "MDAC_CTA_CORRENTE" , "DAC123" },
                { "MTXAPMA" , "Matriz AP MA" },
                { "MTXAPIP" , "Matriz AP IP" },
                { "MTXVG" , "Matriz VG" },
                { "COBERP_IMPMORNATU" , "50.00" },
                { "COBERP_IMPMORACID" , "100.00" },
                { "COBERP_IMPINVPERM" , "150.00" },
                { "COBERP_IMPAMDS" , "200.00" },
                { "COBERP_IMPDH" , "250.00" },
                { "COBERP_IMPDIT" , "300.00" },
                { "COBERP_PRMVG" , "400.00" },
                { "COBERP_PRMAP" , "450.00" },
                { "MCODOPER" , "OP123" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
                { "PROPVA_CODUSU" , "USU123" },
                { "WSISTEMA_DTMOVABE" , "2023-12-01" },
                { "CLIENT_DTNASC" , "1988-01-01" },
                { "MDTREF" , "2023-12-01" },
                { "MMDTMOVTO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_INSERT_1_Insert1", q64);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_2_Query1

                var q65 = new DynamicData();
                q65.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , "1988-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_2_Query1", q65);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_1_Update1

                var q66 = new DynamicData();
                q66.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , "Automática" },
                { "PROPVA_FONTE" , "CEF" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_1_Update1", q66);

                #endregion

                #region R8000_PROPAUTOM_DB_INSERT_2_Insert1

                var q67 = new DynamicData();
                q67.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "107700000011" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_FONTE" , "CEF" },
                { "FONTE_PROPAUTOM" , "Automática" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "MTPINCLUS" , "Inclusão Manual" },
                { "PROPVA_CODCLIEN" , "456789" },
                { "MAGENCIADOR" , "Agente123" },
                { "MMFAIXA" , "Faixa1" },
                { "MTPBENEF" , "Tipo Benefício" },
                { "OPCAOP_PERIPGTO" , "0" },
                { "PROPVA_EST_CIV" , "Casado" },
                { "PROPVA_SEXO" , "M" },
                { "MAGECOBR" , "Agência Cobrança" },
                { "MMNUM_MATRICULA" , "Mat123" },
                { "MNUM_CTA_CORRENTE" , "Conta123" },
                { "MDAC_CTA_CORRENTE" , "DAC123" },
                { "MTXAPMA" , "Matriz AP MA" },
                { "MTXAPIP" , "Matriz AP IP" },
                { "MTXVG" , "Matriz VG" },
                { "COBERP_IMPMORNATU" , "50.00" },
                { "COBERP_IMPMORACID" , "100.00" },
                { "COBERP_IMPINVPERM" , "150.00" },
                { "COBERP_IMPAMDS" , "200.00" },
                { "COBERP_IMPDH" , "250.00" },
                { "COBERP_IMPDIT" , "300.00" },
                { "COBERP_PRMVG" , "400.00" },
                { "COBERP_PRMAP" , "450.00" },
                { "MCODOPER" , "OP123" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
                { "PROPVA_CODUSU" , "USU123" },
                { "WSISTEMA_DTMOVABE" , "2023-12-01" },
                { "PROPVA_DTADMIS" , "2020-01-01" },
                { "CLIENT_DTNASC" , "1988-01-01" },
                { "MDTREF" , "2023-12-01" },
                { "MMDTMOVTO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_INSERT_2_Insert1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_INSERT_2_Insert1", q67);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_2_Update1

                var q68 = new DynamicData();
                q68.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "400.00" },
                { "COBERP_PRMAP" , "450.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_2_Update1", q68);

                #endregion

                #region R8000_PROPAUTOM_DB_SELECT_1_Query1

                var q69 = new DynamicData();
                q69.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , "800.00" }
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_SELECT_1_Query1", q69);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_3_Update1

                var q70 = new DynamicData();
                q70.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "400.00" },
                { "COBERP_PRMAP" , "450.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_3_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_3_Update1", q70);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_3_Query1

                var q71 = new DynamicData();
                q71.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , "25-35" },
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_3_Query1", q71);

                #endregion

                #region R8000_PROPAUTOM_DB_SELECT_2_Query1

                var q72 = new DynamicData();
                q72.AddDynamic(new Dictionary<string, string>{
                { "COMISI_VALADT" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_SELECT_2_Query1", q72);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_4_Update1

                var q73 = new DynamicData();
                q73.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "400.00" },
                { "COBERP_PRMAP" , "450.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_4_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_4_Update1", q73);

                #endregion

                #region M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1

                var q74 = new DynamicData();
                q74.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , "25-35" },
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1", q74);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_5_Update1

                var q75 = new DynamicData();
                q75.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "400.00" },
                { "COBERP_PRMAP" , "450.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_5_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_5_Update1", q75);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_4_Query1

                var q76 = new DynamicData();
                q76.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , "25-35" },
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_4_Query1", q76);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_5_Query1

                var q77 = new DynamicData();
                q77.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , "25-35" },
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_5_Query1", q77);

                #endregion

                #region M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1

                var q78 = new DynamicData();
                q78.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "3" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1", q78);

                #endregion

                #region VP0121B_C01_RCAPCOMP

                var q79 = new DynamicData();
                q79.AddDynamic(new Dictionary<string, string>{
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_BCO_AVISO" , "237" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_AGE_AVISO" , "1234" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_NUM_AVISO_CREDITO" , "987654321" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_MOVIMENTO" , "2023-12-15" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_RCAP" , "2023-12-20" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_COD_OPERACAO" , "OP123" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0121B_C01_RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("VP0121B_C01_RCAPCOMP", q79);

                #endregion

                #region M_8100_LOOP_DB_INSERT_1_Insert1

                var q80 = new DynamicData();
                q80.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "107700000011" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_FONTE" , "CEF" },
                { "FONTE_PROPAUTOM" , "Automática" },
                { "BENEF_NRBENEF" , "BN1234567" },
                { "BENEF_NOMBENEF" , "Nome Beneficiário" },
                { "BENEF_GRAUPAR" , "Grau Parentesco" },
                { "BENEF_PCTBENEF" , "50%" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8100_LOOP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8100_LOOP_DB_INSERT_1_Insert1", q80);

                #endregion

                #region M_8200_CONCEDE_CDG_DB_SELECT_1_Query1

                var q81 = new DynamicData();
                q81.AddDynamic(new Dictionary<string, string>{
                { "CDGCOB_DTINIVIG" , "2023-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8200_CONCEDE_CDG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8200_CONCEDE_CDG_DB_SELECT_1_Query1", q81);

                #endregion

                #region M_8200_CONCEDE_CDG_DB_SELECT_2_Query1

                var q82 = new DynamicData();
                q82.AddDynamic(new Dictionary<string, string>{
                { "REPCDG_DTREF" , "2023-01-31" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8200_CONCEDE_CDG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8200_CONCEDE_CDG_DB_SELECT_2_Query1", q82);

                #endregion

                #region M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1

                var q83 = new DynamicData();
                q83.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1", q83);

                #endregion

                #region M_8220_INCLUI_CDG_DB_INSERT_1_Insert1

                var q84 = new DynamicData();
                q84.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "PROPVA_DTINICDG" , "2023-01-01" },
                { "COBERP_IMPSEGCDG" , "500.00" },
                { "COBERP_VLCUSTCDG" , "550.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_OCORHIST" , "Ocorrencia Teste" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8220_INCLUI_CDG_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8220_INCLUI_CDG_DB_INSERT_1_Insert1", q84);

                #endregion

                #region M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1

                var q85 = new DynamicData();
                q85.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "REPCDG_DTREF" , "2023-01-31" },
                { "COBERP_VLCUSTCDG" , "550.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1", q85);

                #endregion

                #region M_8300_CONCEDE_SAF_DB_SELECT_1_Query1

                var q86 = new DynamicData();
                q86.AddDynamic(new Dictionary<string, string>{
                { "SAFCOB_DTINIVIG" , "2023-02-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8300_CONCEDE_SAF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8300_CONCEDE_SAF_DB_SELECT_1_Query1", q86);

                #endregion

                #region M_8300_CONCEDE_SAF_DB_SELECT_2_Query1

                var q87 = new DynamicData();
                q87.AddDynamic(new Dictionary<string, string>{
                { "REPSAF_DTREF" , "2023-02-28" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8300_CONCEDE_SAF_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8300_CONCEDE_SAF_DB_SELECT_2_Query1", q87);

                #endregion

                #region M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1

                var q88 = new DynamicData();
                q88.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1", q88);

                #endregion

                #region M_8320_INCLUI_SAF_DB_INSERT_1_Insert1

                var q89 = new DynamicData();
                q89.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "PROPVA_DTINISAF" , "2023-01-01" },
                { "COBERP_IMPSEGAUXF" , "650.00" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_OCORHIST" , "Ocorrencia Teste" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8320_INCLUI_SAF_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8320_INCLUI_SAF_DB_INSERT_1_Insert1", q89);

                #endregion

                #region M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1

                var q90 = new DynamicData();
                q90.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "REPSAF_DTREF" , "2023-02-28" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_NRMATRFUN" , "654321" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "PROPVA_CODOPER" , "OP123" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1", q90);

                #endregion

                #region M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1

                var q91 = new DynamicData();
                q91.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "REPSAF_DTREF" , "2023-02-28" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_NRMATRFUN" , "654321" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1", q91);

                #endregion

                #region M_8400_00_DEBITO_CARTAO_DB_INSERT_1_Insert1

                var q92 = new DynamicData();
                q92.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_EMPRESA" , "EMP001" },
                { "MOVDEBCE_NUM_APOLICE" , "APL123456" },
                { "MOVDEBCE_NUM_ENDOSSO" , "END123456" },
                { "MOVDEBCE_NUM_PARCELA" , "PAR123456" },
                { "MOVDEBCE_SITUACAO_COBRANCA" , "Pendente" },
                { "MOVDEBCE_DATA_VENCIMENTO" , "2023-12-31" },
                { "MOVDEBCE_VALOR_DEBITO" , "500.00" },
                { "MOVDEBCE_DATA_MOVIMENTO" , "2023-12-01" },
                { "MOVDEBCE_DIA_DEBITO" , "15" },
                { "MOVDEBCE_COD_AGENCIA_DEB" , "0001" },
                { "MOVDEBCE_OPER_CONTA_DEB" , "013" },
                { "MOVDEBCE_NUM_CONTA_DEB" , "12345678" },
                { "MOVDEBCE_DIG_CONTA_DEB" , "9" },
                { "MOVDEBCE_COD_CONVENIO" , "CONV001" },
                { "MOVDEBCE_DATA_ENVIO" , "2023-12-02" },
                { "MOVDEBCE_DATA_RETORNO" , "2023-12-03" },
                { "MOVDEBCE_COD_RETORNO_CEF" , "RET001" },
                { "MOVDEBCE_NSAS" , "NS123456" },
                { "MOVDEBCE_COD_USUARIO" , "USR001" },
                { "MOVDEBCE_NUM_REQUISICAO" , "REQ123456" },
                { "MOVDEBCE_NUM_CARTAO" , "CARD1234567890" },
                { "MOVDEBCE_SEQUENCIA" , "SEQ123" },
                { "MOVDEBCE_NUM_LOTE" , "LOT123" },
                { "MOVDEBCE_DTCREDITO" , "2023-12-05" },
                { "MOVDEBCE_STATUS_CARTAO" , "Ativo" },
                { "MOVDEBCE_VLR_CREDITO" , "1000.00" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8400_00_DEBITO_CARTAO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8400_00_DEBITO_CARTAO_DB_INSERT_1_Insert1", q92);

                #endregion

                #region M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1

                var q93 = new DynamicData();
                q93.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , "Automática" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1", q93);

                #endregion

                #region M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1

                var q94 = new DynamicData();
                q94.AddDynamic(new Dictionary<string, string>{
                { "W03_VENCIMENTO" , "2023-12-10" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1", q94);

                #endregion

                #region M_8600_10_CONTINUA_DB_SELECT_1_Query1

                var q95 = new DynamicData();
                q95.AddDynamic(new Dictionary<string, string>{
                { "DESCON_PERC" , "10%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_10_CONTINUA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_SELECT_1_Query1", q95);

                #endregion

                #region M_8600_10_CONTINUA_DB_INSERT_1_Insert1

                var q96 = new DynamicData();
                q96.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "HISTCB_DTVENCTO" , "2023-12-20" },
                { "COBERP_PRMVG" , "400.00" },
                { "COBERP_PRMAP" , "450.00" },
                { "OPCAOP_OPCAOPAG" , "1" },
                { "PARCEL_OCORHIST" , "Ocorrência 1" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_10_CONTINUA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_INSERT_1_Insert1", q96);

                #endregion

                #region M_8600_CONTINUA_DB_UPDATE_1_Update1

                var q97 = new DynamicData();
                q97.AddDynamic(new Dictionary<string, string>{
                { "HISTCB_DTVENCTO" , "2023-12-20" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_CONTINUA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_8600_CONTINUA_DB_UPDATE_1_Update1", q97);

                #endregion

                #region M_8600_10_CONTINUA_DB_INSERT_2_Insert1

                var q98 = new DynamicData();
                q98.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "BANCOS_NRTIT" , "85172719932" },
                { "HISTCB_DTVENCTO" , "2023-12-20" },
                { "DESCON_VLPREMIO" , "50.00" },
                { "OPCAOP_OPCAOPAG" , "1" },
                { "HISTCB_SITUACAO" , "Ativa" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_10_CONTINUA_DB_INSERT_2_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_INSERT_2_Insert1", q98);

                #endregion

                #region M_8600_CONTINUA_DB_UPDATE_2_Update1

                var q99 = new DynamicData();
                q99.AddDynamic(new Dictionary<string, string>{
                { "WS_PROPVA_DTPROXVEN" , "2024-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_CONTINUA_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("M_8600_CONTINUA_DB_UPDATE_2_Update1", q99);

                #endregion

                #region M_8600_10_CONTINUA_DB_INSERT_3_Insert1

                var q100 = new DynamicData();
                q100.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "HISTCB_DTVENCTO" , "2023-12-20" },
                { "DESCON_PRMVG" , "5%" },
                { "DESCON_PRMAP" , "3%" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_10_CONTINUA_DB_INSERT_3_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_INSERT_3_Insert1", q100);

                #endregion

                #region M_8700_GERA_DEBITO_DB_SELECT_1_Query1

                var q101 = new DynamicData();
                q101.AddDynamic(new Dictionary<string, string>{
                { "CONVEN_CODCONV" , "C123" },
                { "CONVEN_CARTAO" , "1234567890123456" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8700_GERA_DEBITO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8700_GERA_DEBITO_DB_SELECT_1_Query1", q101);

                #endregion

                #region M_8700_GERA_DEBITO_DB_INSERT_1_Insert1

                var q102 = new DynamicData();
                q102.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "OPCAOP_AGECTADEB" , "001" },
                { "OPCAOP_OPRCTADEB" , "OPR001" },
                { "OPCAOP_NUMCTADEB" , "123456" },
                { "OPCAOP_DIGCTADEB" , "7" },
                { "HISTCB_DTVENCTO" , "2023-12-20" },
                { "DESCON_VLPREMIO" , "50.00" },
                { "HOST_CODCONV" , "H123" },
                { "OPCAOP_CARTAOCRED" , "4111111111111111" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8700_GERA_DEBITO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8700_GERA_DEBITO_DB_INSERT_1_Insert1", q102);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1

                var q103 = new DynamicData();
                q103.AddDynamic(new Dictionary<string, string>{
                { "FUNDO_PCCOMIND" , "0.5%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1", q103);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1

                var q104 = new DynamicData();
                q104.AddDynamic(new Dictionary<string, string>{
                { "FUNDO_PCCOMGER" , "1%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1", q104);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1

                var q105 = new DynamicData();
                q105.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODPRODU" , "7705" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_FONTE" , "CEF" },
                { "PROPVA_AGECOBR" , "001" },
                { "PROPVA_CODCLIEN" , "456789" },
                { "PROPVA_NRMATRVEN" , "123456" },
                { "FUNDO_VALBASVG" , "100000.00" },
                { "FUNDO_VALBASAP" , "50000.00" },
                { "FUNDO_VLCOMISVG" , "500.00" },
                { "FUNDO_VLCOMISAP" , "250.00" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
                { "FUNDO_PCCOMIND" , "0.5%" },
                { "FUNDO_PCCOMGER" , "1%" },
                { "FUNDO_PCCOMSUP" , "0.2%" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1", q105);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1

                var q106 = new DynamicData();
                q106.AddDynamic(new Dictionary<string, string>{
                { "FUNDO_PCCOMSUP" , "0.2%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1", q106);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1

                var q107 = new DynamicData();
                q107.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , "0.38%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1", q107);

                #endregion

                #region R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1

                var q108 = new DynamicData();
                q108.AddDynamic(new Dictionary<string, string>{
                { "SIVPF_NR_IDENTIFI" , "ID123456789" },
                { "SIVPF_NR_SICOB" , "SIC123456" },
                { "SIVPF_SIT_PROPOSTA" , "Aprovada" },
                { "SIVPF_DTQITBCO" , "2023-12-15" },
                { "SIVPF_VAL_PAGO" , "200.00" },
                { "SIVPF_DATA_CREDITO" , "2023-12-16" },
                { "SIVPF_OPCAO_COBER" , "Cobertura Total" },
                { "SIVPF_COD_PLANO" , "PLN123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1", q108);

                #endregion

                #region R7773_00_LER_RCAPS_DB_SELECT_1_Query1

                var q109 = new DynamicData();
                q109.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "FNT001" },
                { "RCAPS_NUM_RCAP" , "RC123456" },
                { "RCAPS_VAL_RCAP" , "1500.00" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7773_00_LER_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7773_00_LER_RCAPS_DB_SELECT_1_Query1", q109);

                #endregion

                #region R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1

                var q110 = new DynamicData();
                q110.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , "001" },
                { "RCAPCOMP_AGE_AVISO" , "0001" },
                { "RCAPCOMP_NUM_AVISO_CREDITO" , "987654321" },
                { "RCAPCOMP_DATA_MOVIMENTO" , "2023-12-15" },
                { "RCAPCOMP_DATA_RCAP" , "2023-12-20" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1", q110);

                #endregion

                #region R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1

                var q111 = new DynamicData();
                q111.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SIT_PROP_FIDELIZ" , "Fidelizado" },
                { "WHOST_SITUACAO_ENVIO" , "Enviado" },
                { "SIVPF_DATA_CREDITO" , "2023-12-16" },
                { "SIVPF_OPCAO_COBER" , "Cobertura Total" },
                { "SIVPF_DTQITBCO" , "2023-12-15" },
                { "SIVPF_VAL_PAGO" , "200.00" },
                { "SIVPF_NR_PROPOSTA" , "27708000280671" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1", q111);

                #endregion

                #region R7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1_Update1

                var q112 = new DynamicData();
                q112.AddDynamic(new Dictionary<string, string>{
                { "CONVER_NUM_SICOB" , "SIC123" },
                { "SIVPF_NR_PROPOSTA" , "27708000280671" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1_Update1", q112);

                #endregion

                #region M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1

                var q113 = new DynamicData();
                q113.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "400.00" },
                { "COBERP_PRMAP" , "450.00" },
                { "PROPVA_NRCERTIF" , "98763456811007445554321" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1", q113);

                #endregion

                #region M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1

                var q114 = new DynamicData();
                q114.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "DIFPAR_CODOPER" , "DIF123" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
                { "COBERP_VLPREMIO" , "350.00" },
                { "V0HCOB_VLPRMTOT" , "800.00" },
                { "DIFPAR_PRMVG" , "2%" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1", q114);

                #endregion

                #region M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1

                var q115 = new DynamicData();
                q115.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "400.00" },
                { "COBERP_PRMAP" , "450.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1", q115);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute();
                var program = new VP0121B();
                program.Execute();

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var distintos = allSelects.Except(selects).ToList();

                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0000_PRINCIPAL_DB_SELECT_1_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0000_PRINCIPAL_DB_SELECT_2_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0000_PRINCIPAL_DB_SELECT_3_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0000_PRINCIPAL_DB_SELECT_4_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0100_OPCAOPAGVA_DB_SELECT_1_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0100_OPCAOPAGVA_DB_SELECT_5_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0100_OPCAOPAGVA_DB_SELECT_7_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0110_FETCH_DB_SELECT_1_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0110_FETCH_DB_SELECT_2_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1")).ToList());

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void VP0121B_Tests_Selects2_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                PROSOCU1_Tests.Load_Parameters();
                PROTIT01_Tests.Load_Parameters();
                FC0105B_Tests.Load_Parameters();
                FC0001S_Tests.Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , "2025-03-17" },
                { "SISTEMA_CURRDATE" , "2025-05-14" },
                { "SISTEMA_DTMOVABE2" , "2025-05-22" },
                { "SISTEMA_DTMOVABE3" , "2025-06-14" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_NUM_RAMO_PRSTMISTA" , "77" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q1);

                #endregion

                #region VP0121B_CPROPVA

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "107700000011" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_CODPRODU" , "7705" },
                { "PROPVA_CODCLIEN" , "456789" },
                { "PROPVA_OCOREND" , "12345" },
                { "PROPVA_FONTE" , "CEF" },
                { "PROPVA_AGECOBR" , "001" },
                { "PROPVA_OPCAO_COBER" , "A" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
                { "PROPVA_DTINICDG" , "2023-01-01" },
                { "PROPVA_DTINISAF" , "2023-01-01" },
                { "PROPVA_DTPROXVEN" , "2024-01-01" },
                { "PROPVA_DTMINVEN" , "2023-12-31" },
                { "PROPVA_NRMATRVEN" , "123456" },
                { "PROPVA_CODOPER" , "OP123" },
                { "PROPVA_DTMOVTO" , "2023-12-01" },
                { "PROPVA_SITUACAO" , "1" },
                { "PROPVA_NUM_APOLICE1" , "107700000011" },
                { "PROPVA_CODSUBES1" , "002" },
                { "PROPVA_OCORHIST" , "Ocorrencia Teste" },
                { "PROPVA_NRPARCEL" , "12" },
                { "PROPVA_SIT_INTERF" , "Ativa" },
                { "PROPVA_TIMESTAMP" , "2023-12-01T12:00:00" },
                { "PROPVA_IDADE" , "35" },
                { "PROPVA_SEXO" , "M" },
                { "PROPVA_EST_CIV" , "Casado" },
                { "PROPVA_COD_CRM" , "CRM123" },
                { "PROPVA_NRMATRFUN" , "654321" },
                { "PROPVA_DTADMIS" , "2020-01-01" },
                { "PROPVA_NRPROPOS" , "27708000280671" },
                { "PROPVA_CODCCT" , "CCT001" },
                { "PROPVA_CODUSU" , "USU123" },
                { "PROPVA_DTVENCTO" , "2024-01-01" },
                { "PROPVA_FAIXA_RENDA_IND" , "Alta" },
                { "PROPVA_DATA" , "2023-12-01" },
                { "PROPVA_DPS_TITULAR" , "Sim" },
                { "PROPVA_ORIGEM_PROPOSTA" , "1000" },
                { "PROPVA_ACATAMENTO" , "N" },
                { "PROPVA_COD_OPER_CREDITO" , "CRED123" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0121B_CPROPVA");
                AppSettings.TestSet.DynamicData.Add("VP0121B_CPROPVA", q2);

                #endregion

                #region VP0121B_V1RCAPCOMP

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , "Fonte1" },
                { "V1RCAC_NRRCAP" , "321" },
                { "V1RCAC_NRRCAPCO" , "321CO" },
                { "V1RCAC_OPERACAO" , "Oper123" },
                { "V1RCAC_DTMOVTO" , "2023-12-01" },
                { "V1RCAC_HORAOPER" , "12:00" },
                { "V1RCAC_SITUACAO" , "Ativa" },
                { "V1RCAC_BCOAVISO" , "001" },
                { "V1RCAC_AGEAVISO" , "002" },
                { "V1RCAC_NRAVISO" , "003" },
                { "V1RCAC_VLRCAP" , "1000.00" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
                { "V1RCAC_DTCADAST" , "2023-12-01" },
                { "V1RCAC_SITCONTB" , "Confirmada" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0121B_V1RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("VP0121B_V1RCAPCOMP", q3);

                #endregion

                #region M_0000_PRINCIPAL_DB_UPDATE_1_Update1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NRTIT" , "85172719932" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_UPDATE_1_Update1", q4);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_3_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SUBGRU_CODSUBES" , "0" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_3_Query1", q5);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_4_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NRTIT" , "85172719932" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_4_Query1", q6);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "PRODVG_CODPRODAZ" , "P123" },
                { "PRODVG_PERIPGTO" , "Mensal" },
                { "PRODVG_ESTR_COBR" , "Estruturada" },
                { "PRODVG_ORIG_PRODU" , "CEF DEB CC" },
                { "PRODVG_AGENCIADOR" , "Agente123" },
                { "PRODVG_TEM_SAF" , "Sim" },
                { "PRODVG_TEM_CDG" , "Não" },
                { "PRODVG_CODRELAT" , "R123" },
                { "PRODVG_COBERADIC_PREMIO" , "100.00" },
                { "PRODVG_CUSTOCAP_TOTAL" , "200.00" },
                { "PRODVG_DESCONTO_ADESAO" , "10.00" },
                { "PRODVG_COD_PRODUTO" , "7705" },
                { "PRODVG_RISCO" , "Baixo" },
                { "PRODVG_SITPLANCEF" , "Ativo" },
                { "PRODVG_ARQ_FDCAP" , "Arquivo123" },
                { "PRODVG_COD_RUBRICA" , "RUB001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1", q7);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_OPCAOPAG" , "1" },
                { "OPCAOP_PERIPGTO" , "0" },
                { "OPCAOP_DIA_DEB" , "10" },
                { "OPCAOP_AGECTADEB" , "001" },
                { "OPCAOP_OPRCTADEB" , "OPR001" },
                { "OPCAOP_NUMCTADEB" , "123456" },
                { "OPCAOP_DIGCTADEB" , "7" },
                { "OPCAOP_CARTAOCRED" , "4111111111111111" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_1_Query1", q8);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_PERIPGTO" , "0" },
                { "OPCAOP_OPCAOPAG" , "1" },
                { "OPCAOP_DIA_DEB" , "10" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1", q9);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "WTEM_ERRO_7705" , "Erro7705" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1", q10);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_2_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V0AGCEF_COD_AGCOBR" , "AG001" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_2_Query1", q11);

                #endregion

                #region M_0100_NEXT_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_NEXT_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0100_NEXT_DB_UPDATE_1_Update1", q12);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_3_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V0COBER_MINOCOR" , "MinOcor001" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_3_Query1", q13);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "WTEM_ERRO_7715" , "Erro7715" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1", q14);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_4_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "COBERP_DTINIVIG" , "2023-01-01" },
                { "COBERP_DTTERVIG" , "2024-01-01" },
                { "COBERP_IMPMORNATU" , "50.00" },
                { "COBERP_IMPMORACID" , "100.00" },
                { "COBERP_IMPINVPERM" , "150.00" },
                { "COBERP_IMPAMDS" , "200.00" },
                { "COBERP_IMPDH" , "250.00" },
                { "COBERP_IMPDIT" , "300.00" },
                { "COBERP_VLPREMIO" , "350.00" },
                { "COBERP_PRMVG" , "400.00" },
                { "COBERP_PRMAP" , "450.00" },
                { "COBERP_IMPSEGCDG" , "500.00" },
                { "COBERP_VLCUSTCDG" , "550.00" },
                { "COBERP_VLCUSTCAP" , "600.00" },
                { "COBERP_IMPSEGAUXF" , "650.00" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "COBERP_QTTITCAP" , "750" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_4_Query1", q15);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_5_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "COBERP_DTINIVIG" , "2023-01-01" },
                { "COBERP_IMPMORNATU" , "50.00" },
                { "COBERP_IMPMORACID" , "100.00" },
                { "COBERP_IMPINVPERM" , "150.00" },
                { "COBERP_IMPAMDS" , "200.00" },
                { "COBERP_IMPDH" , "250.00" },
                { "COBERP_IMPDIT" , "300.00" },
                { "COBERP_VLPREMIO" , "350.00" },
                { "COBERP_PRMVG" , "400.00" },
                { "COBERP_PRMAP" , "450.00" },
                { "COBERP_IMPSEGCDG" , "500.00" },
                { "COBERP_VLCUSTCDG" , "550.00" },
                { "COBERP_VLCUSTCAP" , "600.00" },
                { "COBERP_IMPSEGAUXF" , "650.00" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "COBERP_QTTITCAP" , "750" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_5_Query1", q16);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , "1988-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1", q17);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_6_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , "800.00" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_6_Query1", q18);

                #endregion

                #region M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "ERRPROVI_COD_ERRO" , "1002" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1", q19);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_DTPROXVEN" , "2024-01-01" },
                { "PROPVA_CODPRODU" , "7705" },
                { "PROPVA_SITUACAO" , "1" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_CODOPER" , "OP123" },
                { "MDTMOVTO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1", q20);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_7_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , "800.00" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_7_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_7_Query1", q21);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRPROPOS" , "27708000280671" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1", q22);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_8_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , "109300000598" },
                { "RELATO_CODSUBES" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_8_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_8_Query1", q23);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_9_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , "109300000598" },
                { "RELATO_CODSUBES" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_9_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_9_Query1", q24);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRCERTIF" , "987654321" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1", q25);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_10_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , "109300000598" },
                { "RELATO_CODSUBES" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_10_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_10_Query1", q26);

                #endregion

                #region M_0110_FETCH_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA_MOVIMENTO" , "2023-12-01" }
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("M_0110_FETCH_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_DB_SELECT_1_Query1", q27);

                #endregion

                #region M_0110_FETCH_DB_UPDATE_1_Update1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0110_FETCH_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_DB_UPDATE_1_Update1", q28);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_11_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , "109300000598" },
                { "RELATO_CODSUBES" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_11_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_11_Query1", q29);

                #endregion

                #region M_0110_FETCH_DB_SELECT_2_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_RAMO" , "Vida" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0110_FETCH_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_DB_SELECT_2_Query1", q30);

                #endregion

                #region M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-12-01" },
                { "WHOST_PROXIMA_DATA" , "2023-12-02" },
                { "CALENDAR_DIA_SEMANA" , "Q" },
                { "CALENDAR_FERIADO" , "Não" },
            });

                q31.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-12-02" },
                { "WHOST_PROXIMA_DATA" , "2023-12-03" },
                { "CALENDAR_DIA_SEMANA" , "Q" },
                { "CALENDAR_FERIADO" , "Não" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1", q31);

                #endregion

                #region M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                { "RELATO_CODRELAT" , "R123" },
                { "PROPVA_NUM_APOLICE" , "107700000011" },
                { "RELATO_NRPARCEL" , "12" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_CODSUBES" , "001" },
                { "RELATO_OPERACAO" , "Oper123" },
                { "WS_SIT_REGISTRO" , "Ativo" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1", q32);

                #endregion

                #region M_0300_VERIFICA_CROT_DB_SELECT_1_Query1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_CGCCPF" , "12345678901" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0300_VERIFICA_CROT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0300_VERIFICA_CROT_DB_SELECT_1_Query1", q33);

                #endregion

                #region M_0300_VERIFICA_CROT_DB_SELECT_2_Query1

                var q34 = new DynamicData();
                q34.AddDynamic(new Dictionary<string, string>{
                { "CLIROT_DTMOVABE" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0300_VERIFICA_CROT_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0300_VERIFICA_CROT_DB_SELECT_2_Query1", q34);

                #endregion

                #region M_0320_UPDATE_CROT_DB_UPDATE_1_Update1

                var q35 = new DynamicData();
                q35.AddDynamic(new Dictionary<string, string>{
                { "CLIROT_DTMOVABE" , "2023-12-01" },
                { "CLIENT_CGCCPF" , "12345678901" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0320_UPDATE_CROT_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0320_UPDATE_CROT_DB_UPDATE_1_Update1", q35);

                #endregion

                #region M_0330_INCLUI_CROT_DB_INSERT_1_Insert1

                var q36 = new DynamicData();
                q36.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_CGCCPF" , "12345678901" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0330_INCLUI_CROT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0330_INCLUI_CROT_DB_INSERT_1_Insert1", q36);

                #endregion

                #region R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1

                var q37 = new DynamicData();
                q37.AddDynamic(new Dictionary<string, string>{
                { "V0FOLHM_DTEMICAR" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1", q37);

                #endregion

                #region R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1

                var q38 = new DynamicData();
                q38.AddDynamic(new Dictionary<string, string>{
                { "V0FOLH_COD_CARTA" , "C123" },
                { "V0FOLH_DTEMICAR" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1", q38);

                #endregion

                #region M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1

                var q39 = new DynamicData();
                q39.AddDynamic(new Dictionary<string, string>{
                { "V0FOLH_COD_PRODUTO" , "7705" },
                { "V0FOLH_NRCERTIF" , "987654321" },
                { "V0FOLH_COD_CARTA" , "C123" },
                { "V0FOLH_DTEMICAR" , "2023-12-01" },
                { "V0FOLH_DTSOLICIT" , "2023-12-01" },
                { "V0FOLH_CODUSU" , "USU123" },
                { "V0FOLH_SITUACAO" , "Ativa" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1", q39);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1

                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                { "CONVER_NUM_SICOB" , "SIC123" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1", q40);

                #endregion

                #region FINALIZA_1110_FIM_DB_UPDATE_1_Update1

                var q41 = new DynamicData();
                q41.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "CONVER_NUM_PROPOSTA" , "27708000280671" },
            });
                AppSettings.TestSet.DynamicData.Remove("FINALIZA_1110_FIM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("FINALIZA_1110_FIM_DB_UPDATE_1_Update1", q41);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1

                var q42 = new DynamicData();
                q42.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "Fonte1" },
                { "V0RCAP_NRRCAP" , "321" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1", q42);

                #endregion

                #region FINALIZA_1110_FIM_DB_UPDATE_2_Update1

                var q43 = new DynamicData();
                q43.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "V0RCAP_NRRCAP" , "321" },
                { "V0RCAP_FONTE" , "Fonte1" },
            });
                AppSettings.TestSet.DynamicData.Remove("FINALIZA_1110_FIM_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("FINALIZA_1110_FIM_DB_UPDATE_2_Update1", q43);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1

                var q44 = new DynamicData();
                q44.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "107700000011" },
                { "V0RCAP_NRRCAP" , "321" },
                { "V0RCAP_FONTE" , "Fonte1" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1", q44);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1

                var q45 = new DynamicData();
                q45.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "001" },
                { "V1RCAC_AGEAVISO" , "002" },
                { "V1RCAC_NRAVISO" , "003" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1", q45);

                #endregion

                #region VP0121B_CBENEFP

                var q46 = new DynamicData();
                q46.AddDynamic(new Dictionary<string, string>{
                { "BENEF_NOMBENEF" , "Nome Beneficiário" },
                { "BENEF_GRAUPAR" , "Grau Parentesco" },
                { "BENEF_PCTBENEF" , "50%" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0121B_CBENEFP");
                AppSettings.TestSet.DynamicData.Add("VP0121B_CBENEFP", q46);

                #endregion

                #region M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1

                var q47 = new DynamicData();
                q47.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_NRRCAPCO" , "321CO" },
                { "V1RCAC_OPERACAO" , "Oper123" },
                { "V1RCAC_HORAOPER" , "12:00" },
                { "V1RCAC_DTMOVTO" , "2023-12-01" },
                { "V1RCAC_NRRCAP" , "321" },
                { "V1RCAC_FONTE" , "Fonte1" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1", q47);

                #endregion

                #region M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1

                var q48 = new DynamicData();
                q48.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , "Fonte1" },
                { "V1RCAC_NRRCAP" , "321" },
                { "V1RCAC_NRRCAPCO" , "321CO" },
                { "V1RCAC_OPERACAO" , "Oper123" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
                { "V1RCAC_SITUACAO" , "Ativa" },
                { "V1RCAC_BCOAVISO" , "001" },
                { "V1RCAC_AGEAVISO" , "002" },
                { "V1RCAC_NRAVISO" , "003" },
                { "V1RCAC_VLRCAP" , "1000.00" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
                { "V1RCAC_DTCADAST" , "2023-12-01" },
                { "V1RCAC_SITCONTB" , "Confirmada" },
                { "V1RCAC_COD_EMPRESA" , "EMP123" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1", q48);

                #endregion

                #region M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1

                var q49 = new DynamicData();
                q49.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_VLRCAP" , "1000.00" },
                { "V1RCAC_BCOAVISO" , "001" },
                { "V1RCAC_AGEAVISO" , "002" },
                { "V1RCAC_NRAVISO" , "003" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1", q49);

                #endregion

                #region M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1

                var q50 = new DynamicData();
                q50.AddDynamic(new Dictionary<string, string>{
                { "PRODVG_CODPRODAZ" , "P123" },
                { "PRODVG_ESTR_COBR" , "Estruturada" },
                { "PRODVG_ORIG_PRODU" , "CEF DEB CC" },
                { "PRODVG_AGENCIADOR" , "Agente123" },
                { "PRODVG_TEM_SAF" , "Sim" },
                { "PRODVG_TEM_CDG" , "Não" },
                { "PRODVG_CODRELAT" , "R123" },
                { "PRODVG_COBERADIC_PREMIO" , "100.00" },
                { "PRODVG_CUSTOCAP_TOTAL" , "200.00" },
                { "PRODVG_DESCONTO_ADESAO" , "10.00" },
                { "PRODVG_COD_PRODUTO" , "7705" },
                { "PRODVG_RISCO" , "Baixo" },
                { "PRODVG_SITPLANCEF" , "Ativo" },
                { "PRODVG_ARQ_FDCAP" , "Arquivo123" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1", q50);

                #endregion

                #region M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1

                var q51 = new DynamicData();
                q51.AddDynamic(new Dictionary<string, string>{
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1", q51);

                #endregion

                #region M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1

                var q52 = new DynamicData();
                q52.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODSUBES" , "001" },
                { "MTXAPMA" , "Matriz AP MA" },
                { "MTXAPIP" , "Matriz AP IP" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1", q52);

                #endregion

                #region M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1

                var q53 = new DynamicData();
                q53.AddDynamic(new Dictionary<string, string>{
                { "APCORR_RAMO" , "Vida" },
                { "PROPVA_CODSUBES" , "001" },
                { "APCORR_DTINIVIG" , "2023-01-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1", q53);

                #endregion

                #region M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1

                var q54 = new DynamicData();
                q54.AddDynamic(new Dictionary<string, string>{
                { "COMISSOE_NUM_APOLICE" , "109300000598" },
                { "COMISSOE_NUM_ENDOSSO" , "E123" },
                { "COMISSOE_NUM_CERTIFICADO" , "7457254811" },
                { "COMISSOE_DAC_CERTIFICADO" , "DAC123" },
                { "COMISSOE_TIPO_SEGURADO" , "Titular" },
                { "COMISSOE_NUM_PARCELA" , "12" },
                { "COMISSOE_COD_OPERACAO" , "OP123" },
                { "COMISSOE_COD_PRODUTOR" , "Prod123" },
                { "COMISSOE_RAMO_COBERTURA" , "Vida" },
                { "COMISSOE_MODALI_COBERTURA" , "Modalidade1" },
                { "COMISSOE_OCORR_HISTORICO" , "Histórico Ocorrência" },
                { "COMISSOE_COD_FONTE" , "Fonte1" },
                { "COMISSOE_COD_CLIENTE" , "456789" },
                { "COMISSOE_VAL_COMISSAO" , "100.00" },
                { "COMISSOE_DATA_CALCULO" , "2023-12-01" },
                { "COMISSOE_NUM_RECIBO" , "R123456" },
                { "COMISSOE_VAL_BASICO" , "200.00" },
                { "COMISSOE_TIPO_COMISSAO" , "Tipo1" },
                { "COMISSOE_QTD_PARCELAS" , "12" },
                { "COMISSOE_PCT_COM_CORRETOR" , "10%" },
                { "COMISSOE_PCT_DESC_PREMIO" , "5%" },
                { "COMISSOE_COD_SUBGRUPO" , "SG001" },
                { "COMISSOE_DATA_MOVIMENTO" , "2023-12-01" },
                { "COMISSOE_DATA_SELECAO" , "2023-12-01" },
                { "COMISSOE_COD_EMPRESA" , "EMP123" },
                { "COMISSOE_COD_PREPOSTO" , "Prep123" },
                { "COMISSOE_NUM_BILHETE" , "B123456" },
                { "COMISSOE_VAL_VARMON" , "300.00" },
                { "COMISSOE_DATA_QUITACAO" , "2024-01-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1", q54);

                #endregion

                #region M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1

                var q55 = new DynamicData();
                q55.AddDynamic(new Dictionary<string, string>{
                { "PROD_COD_EMPRESA" , "EMP123" },
                { "PARM_COD_EMPR_CAP" , "EMP123" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1", q55);

                #endregion

                #region R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1

                var q56 = new DynamicData();
                q56.AddDynamic(new Dictionary<string, string>{
                { "COMFEDCA_SITUACAO" , "Ativa" }
            });
                AppSettings.TestSet.DynamicData.Remove("R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1", q56);

                #endregion

                #region R6290_10_INSERT_DB_INSERT_1_Insert1

                var q57 = new DynamicData();
                q57.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_FONTE" , "CEF" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
                { "MOVFEDCA_VAL_CUSTO_CAPITALI" , "100.00" },
                { "MOVFEDCA_NRTITFDCAP" , "123456" },
                { "PRODVG_COD_PRODUTO" , "7705" },
            });
                AppSettings.TestSet.DynamicData.Remove("R6290_10_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R6290_10_INSERT_DB_INSERT_1_Insert1", q57);

                #endregion

                #region R6300_00_INSERT_DB_INSERT_1_Insert1

                var q58 = new DynamicData();
                q58.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_NRTITFDCAP" , "123456" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "TITFEDCA_DATA_INIVIGENCIA" , "2023-01-01" },
                { "TITFEDCA_DATA_TERVIGENCIA" , "2024-01-01" },
                { "TITFEDCA_NRSORTEIO" , "S123456" },
                { "TITFEDCA_VAL_CUSTO_TITULO" , "150.00" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R6300_00_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R6300_00_INSERT_DB_INSERT_1_Insert1", q58);

                #endregion

                #region R6400_10_INSERT_DB_INSERT_1_Insert1

                var q59 = new DynamicData();
                q59.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R6400_10_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R6400_10_INSERT_DB_INSERT_1_Insert1", q59);

                #endregion

                #region R6500_10_INSERT_DB_INSERT_1_Insert1

                var q60 = new DynamicData();
                q60.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_NRTITFDCAP" , "123456" },
                { "PARFEDCA_VAL_CUSTO_TITULO" , "150.00" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R6500_10_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R6500_10_INSERT_DB_INSERT_1_Insert1", q60);

                #endregion

                #region R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1

                var q61 = new DynamicData();
                q61.AddDynamic(new Dictionary<string, string>{
                { "COMFEDCA_SITUACAO" , "Ativa" }
            });
                AppSettings.TestSet.DynamicData.Remove("R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1", q61);

                #endregion

                #region R7400_10_INSERT_DB_INSERT_1_Insert1

                var q62 = new DynamicData();
                q62.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7400_10_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R7400_10_INSERT_DB_INSERT_1_Insert1", q62);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_1_Query1

                var q63 = new DynamicData();
                q63.AddDynamic(new Dictionary<string, string>{
                { "CONDTE_IEA" , "Inclusão" },
                { "CONDTE_IPA" , "Proposta" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_1_Query1", q63);

                #endregion

                #region R8000_PROPAUTOM_DB_INSERT_1_Insert1

                var q64 = new DynamicData();
                q64.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "107700000011" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_FONTE" , "CEF" },
                { "FONTE_PROPAUTOM" , "Automática" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "MTPINCLUS" , "Inclusão Manual" },
                { "PROPVA_CODCLIEN" , "456789" },
                { "MAGENCIADOR" , "Agente123" },
                { "MMFAIXA" , "Faixa1" },
                { "MTPBENEF" , "Tipo Benefício" },
                { "OPCAOP_PERIPGTO" , "0" },
                { "PROPVA_EST_CIV" , "Casado" },
                { "PROPVA_SEXO" , "M" },
                { "MAGECOBR" , "Agência Cobrança" },
                { "MMNUM_MATRICULA" , "Mat123" },
                { "MNUM_CTA_CORRENTE" , "Conta123" },
                { "MDAC_CTA_CORRENTE" , "DAC123" },
                { "MTXAPMA" , "Matriz AP MA" },
                { "MTXAPIP" , "Matriz AP IP" },
                { "MTXVG" , "Matriz VG" },
                { "COBERP_IMPMORNATU" , "50.00" },
                { "COBERP_IMPMORACID" , "100.00" },
                { "COBERP_IMPINVPERM" , "150.00" },
                { "COBERP_IMPAMDS" , "200.00" },
                { "COBERP_IMPDH" , "250.00" },
                { "COBERP_IMPDIT" , "300.00" },
                { "COBERP_PRMVG" , "400.00" },
                { "COBERP_PRMAP" , "450.00" },
                { "MCODOPER" , "OP123" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
                { "PROPVA_CODUSU" , "USU123" },
                { "WSISTEMA_DTMOVABE" , "2023-12-01" },
                { "CLIENT_DTNASC" , "1988-01-01" },
                { "MDTREF" , "2023-12-01" },
                { "MMDTMOVTO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_INSERT_1_Insert1", q64);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_2_Query1

                var q65 = new DynamicData();
                q65.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , "1988-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_2_Query1", q65);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_1_Update1

                var q66 = new DynamicData();
                q66.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , "Automática" },
                { "PROPVA_FONTE" , "CEF" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_1_Update1", q66);

                #endregion

                #region R8000_PROPAUTOM_DB_INSERT_2_Insert1

                var q67 = new DynamicData();
                q67.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "107700000011" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_FONTE" , "CEF" },
                { "FONTE_PROPAUTOM" , "Automática" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "MTPINCLUS" , "Inclusão Manual" },
                { "PROPVA_CODCLIEN" , "456789" },
                { "MAGENCIADOR" , "Agente123" },
                { "MMFAIXA" , "Faixa1" },
                { "MTPBENEF" , "Tipo Benefício" },
                { "OPCAOP_PERIPGTO" , "0" },
                { "PROPVA_EST_CIV" , "Casado" },
                { "PROPVA_SEXO" , "M" },
                { "MAGECOBR" , "Agência Cobrança" },
                { "MMNUM_MATRICULA" , "Mat123" },
                { "MNUM_CTA_CORRENTE" , "Conta123" },
                { "MDAC_CTA_CORRENTE" , "DAC123" },
                { "MTXAPMA" , "Matriz AP MA" },
                { "MTXAPIP" , "Matriz AP IP" },
                { "MTXVG" , "Matriz VG" },
                { "COBERP_IMPMORNATU" , "50.00" },
                { "COBERP_IMPMORACID" , "100.00" },
                { "COBERP_IMPINVPERM" , "150.00" },
                { "COBERP_IMPAMDS" , "200.00" },
                { "COBERP_IMPDH" , "250.00" },
                { "COBERP_IMPDIT" , "300.00" },
                { "COBERP_PRMVG" , "400.00" },
                { "COBERP_PRMAP" , "450.00" },
                { "MCODOPER" , "OP123" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
                { "PROPVA_CODUSU" , "USU123" },
                { "WSISTEMA_DTMOVABE" , "2023-12-01" },
                { "PROPVA_DTADMIS" , "2020-01-01" },
                { "CLIENT_DTNASC" , "1988-01-01" },
                { "MDTREF" , "2023-12-01" },
                { "MMDTMOVTO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_INSERT_2_Insert1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_INSERT_2_Insert1", q67);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_2_Update1

                var q68 = new DynamicData();
                q68.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "400.00" },
                { "COBERP_PRMAP" , "450.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_2_Update1", q68);

                #endregion

                #region R8000_PROPAUTOM_DB_SELECT_1_Query1

                var q69 = new DynamicData();
                q69.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , "800.00" }
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_SELECT_1_Query1", q69);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_3_Update1

                var q70 = new DynamicData();
                q70.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "400.00" },
                { "COBERP_PRMAP" , "450.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_3_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_3_Update1", q70);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_3_Query1

                var q71 = new DynamicData();
                q71.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , "25-35" },
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_3_Query1", q71);

                #endregion

                #region R8000_PROPAUTOM_DB_SELECT_2_Query1

                var q72 = new DynamicData();
                q72.AddDynamic(new Dictionary<string, string>{
                { "COMISI_VALADT" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_SELECT_2_Query1", q72);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_4_Update1

                var q73 = new DynamicData();
                q73.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "400.00" },
                { "COBERP_PRMAP" , "450.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_4_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_4_Update1", q73);

                #endregion

                #region M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1

                var q74 = new DynamicData();
                q74.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , "25-35" },
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1", q74);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_5_Update1

                var q75 = new DynamicData();
                q75.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "400.00" },
                { "COBERP_PRMAP" , "450.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_5_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_5_Update1", q75);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_4_Query1

                var q76 = new DynamicData();
                q76.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , "25-35" },
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_4_Query1", q76);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_5_Query1

                var q77 = new DynamicData();
                q77.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , "25-35" },
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_5_Query1", q77);

                #endregion

                #region M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1

                var q78 = new DynamicData();
                q78.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "3" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1", q78);

                #endregion

                #region VP0121B_C01_RCAPCOMP

                var q79 = new DynamicData();
                q79.AddDynamic(new Dictionary<string, string>{
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_BCO_AVISO" , "237" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_AGE_AVISO" , "1234" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_NUM_AVISO_CREDITO" , "987654321" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_MOVIMENTO" , "2023-12-15" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_RCAP" , "2023-12-20" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_COD_OPERACAO" , "OP123" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0121B_C01_RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("VP0121B_C01_RCAPCOMP", q79);

                #endregion

                #region M_8100_LOOP_DB_INSERT_1_Insert1

                var q80 = new DynamicData();
                q80.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "107700000011" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_FONTE" , "CEF" },
                { "FONTE_PROPAUTOM" , "Automática" },
                { "BENEF_NRBENEF" , "BN1234567" },
                { "BENEF_NOMBENEF" , "Nome Beneficiário" },
                { "BENEF_GRAUPAR" , "Grau Parentesco" },
                { "BENEF_PCTBENEF" , "50%" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8100_LOOP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8100_LOOP_DB_INSERT_1_Insert1", q80);

                #endregion

                #region M_8200_CONCEDE_CDG_DB_SELECT_1_Query1

                var q81 = new DynamicData();
                q81.AddDynamic(new Dictionary<string, string>{
                { "CDGCOB_DTINIVIG" , "2023-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8200_CONCEDE_CDG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8200_CONCEDE_CDG_DB_SELECT_1_Query1", q81);

                #endregion

                #region M_8200_CONCEDE_CDG_DB_SELECT_2_Query1

                var q82 = new DynamicData();
                q82.AddDynamic(new Dictionary<string, string>{
                { "REPCDG_DTREF" , "2023-01-31" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8200_CONCEDE_CDG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8200_CONCEDE_CDG_DB_SELECT_2_Query1", q82);

                #endregion

                #region M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1

                var q83 = new DynamicData();
                q83.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1", q83);

                #endregion

                #region M_8220_INCLUI_CDG_DB_INSERT_1_Insert1

                var q84 = new DynamicData();
                q84.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "PROPVA_DTINICDG" , "2023-01-01" },
                { "COBERP_IMPSEGCDG" , "500.00" },
                { "COBERP_VLCUSTCDG" , "550.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_OCORHIST" , "Ocorrencia Teste" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8220_INCLUI_CDG_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8220_INCLUI_CDG_DB_INSERT_1_Insert1", q84);

                #endregion

                #region M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1

                var q85 = new DynamicData();
                q85.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "REPCDG_DTREF" , "2023-01-31" },
                { "COBERP_VLCUSTCDG" , "550.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1", q85);

                #endregion

                #region M_8300_CONCEDE_SAF_DB_SELECT_1_Query1

                var q86 = new DynamicData();
                q86.AddDynamic(new Dictionary<string, string>{
                { "SAFCOB_DTINIVIG" , "2023-02-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8300_CONCEDE_SAF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8300_CONCEDE_SAF_DB_SELECT_1_Query1", q86);

                #endregion

                #region M_8300_CONCEDE_SAF_DB_SELECT_2_Query1

                var q87 = new DynamicData();
                q87.AddDynamic(new Dictionary<string, string>{
                { "REPSAF_DTREF" , "2023-02-28" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8300_CONCEDE_SAF_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8300_CONCEDE_SAF_DB_SELECT_2_Query1", q87);

                #endregion

                #region M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1

                var q88 = new DynamicData();
                q88.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1", q88);

                #endregion

                #region M_8320_INCLUI_SAF_DB_INSERT_1_Insert1

                var q89 = new DynamicData();
                q89.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "PROPVA_DTINISAF" , "2023-01-01" },
                { "COBERP_IMPSEGAUXF" , "650.00" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_OCORHIST" , "Ocorrencia Teste" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8320_INCLUI_SAF_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8320_INCLUI_SAF_DB_INSERT_1_Insert1", q89);

                #endregion

                #region M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1

                var q90 = new DynamicData();
                q90.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "REPSAF_DTREF" , "2023-02-28" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_NRMATRFUN" , "654321" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "PROPVA_CODOPER" , "OP123" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1", q90);

                #endregion

                #region M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1

                var q91 = new DynamicData();
                q91.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "REPSAF_DTREF" , "2023-02-28" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_NRMATRFUN" , "654321" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1", q91);

                #endregion

                #region M_8400_00_DEBITO_CARTAO_DB_INSERT_1_Insert1

                var q92 = new DynamicData();
                q92.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_EMPRESA" , "EMP001" },
                { "MOVDEBCE_NUM_APOLICE" , "APL123456" },
                { "MOVDEBCE_NUM_ENDOSSO" , "END123456" },
                { "MOVDEBCE_NUM_PARCELA" , "PAR123456" },
                { "MOVDEBCE_SITUACAO_COBRANCA" , "Pendente" },
                { "MOVDEBCE_DATA_VENCIMENTO" , "2023-12-31" },
                { "MOVDEBCE_VALOR_DEBITO" , "500.00" },
                { "MOVDEBCE_DATA_MOVIMENTO" , "2023-12-01" },
                { "MOVDEBCE_DIA_DEBITO" , "15" },
                { "MOVDEBCE_COD_AGENCIA_DEB" , "0001" },
                { "MOVDEBCE_OPER_CONTA_DEB" , "013" },
                { "MOVDEBCE_NUM_CONTA_DEB" , "12345678" },
                { "MOVDEBCE_DIG_CONTA_DEB" , "9" },
                { "MOVDEBCE_COD_CONVENIO" , "CONV001" },
                { "MOVDEBCE_DATA_ENVIO" , "2023-12-02" },
                { "MOVDEBCE_DATA_RETORNO" , "2023-12-03" },
                { "MOVDEBCE_COD_RETORNO_CEF" , "RET001" },
                { "MOVDEBCE_NSAS" , "NS123456" },
                { "MOVDEBCE_COD_USUARIO" , "USR001" },
                { "MOVDEBCE_NUM_REQUISICAO" , "REQ123456" },
                { "MOVDEBCE_NUM_CARTAO" , "CARD1234567890" },
                { "MOVDEBCE_SEQUENCIA" , "SEQ123" },
                { "MOVDEBCE_NUM_LOTE" , "LOT123" },
                { "MOVDEBCE_DTCREDITO" , "2023-12-05" },
                { "MOVDEBCE_STATUS_CARTAO" , "Ativo" },
                { "MOVDEBCE_VLR_CREDITO" , "1000.00" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8400_00_DEBITO_CARTAO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8400_00_DEBITO_CARTAO_DB_INSERT_1_Insert1", q92);

                #endregion

                #region M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1

                var q93 = new DynamicData();
                q93.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , "Automática" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1", q93);

                #endregion

                #region M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1

                var q94 = new DynamicData();
                q94.AddDynamic(new Dictionary<string, string>{
                { "W03_VENCIMENTO" , "2023-12-10" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1", q94);

                #endregion

                #region M_8600_10_CONTINUA_DB_SELECT_1_Query1

                var q95 = new DynamicData();
                q95.AddDynamic(new Dictionary<string, string>{
                { "DESCON_PERC" , "10%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_10_CONTINUA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_SELECT_1_Query1", q95);

                #endregion

                #region M_8600_10_CONTINUA_DB_INSERT_1_Insert1

                var q96 = new DynamicData();
                q96.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "HISTCB_DTVENCTO" , "2023-12-20" },
                { "COBERP_PRMVG" , "400.00" },
                { "COBERP_PRMAP" , "450.00" },
                { "OPCAOP_OPCAOPAG" , "1" },
                { "PARCEL_OCORHIST" , "Ocorrência 1" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_10_CONTINUA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_INSERT_1_Insert1", q96);

                #endregion

                #region M_8600_CONTINUA_DB_UPDATE_1_Update1

                var q97 = new DynamicData();
                q97.AddDynamic(new Dictionary<string, string>{
                { "HISTCB_DTVENCTO" , "2023-12-20" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_CONTINUA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_8600_CONTINUA_DB_UPDATE_1_Update1", q97);

                #endregion

                #region M_8600_10_CONTINUA_DB_INSERT_2_Insert1

                var q98 = new DynamicData();
                q98.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "BANCOS_NRTIT" , "85172719932" },
                { "HISTCB_DTVENCTO" , "2023-12-20" },
                { "DESCON_VLPREMIO" , "50.00" },
                { "OPCAOP_OPCAOPAG" , "1" },
                { "HISTCB_SITUACAO" , "Ativa" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_10_CONTINUA_DB_INSERT_2_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_INSERT_2_Insert1", q98);

                #endregion

                #region M_8600_CONTINUA_DB_UPDATE_2_Update1

                var q99 = new DynamicData();
                q99.AddDynamic(new Dictionary<string, string>{
                { "WS_PROPVA_DTPROXVEN" , "2024-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_CONTINUA_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("M_8600_CONTINUA_DB_UPDATE_2_Update1", q99);

                #endregion

                #region M_8600_10_CONTINUA_DB_INSERT_3_Insert1

                var q100 = new DynamicData();
                q100.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "HISTCB_DTVENCTO" , "2023-12-20" },
                { "DESCON_PRMVG" , "5%" },
                { "DESCON_PRMAP" , "3%" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_10_CONTINUA_DB_INSERT_3_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_INSERT_3_Insert1", q100);

                #endregion

                #region M_8700_GERA_DEBITO_DB_SELECT_1_Query1

                var q101 = new DynamicData();
                q101.AddDynamic(new Dictionary<string, string>{
                { "CONVEN_CODCONV" , "C123" },
                { "CONVEN_CARTAO" , "1234567890123456" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8700_GERA_DEBITO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8700_GERA_DEBITO_DB_SELECT_1_Query1", q101);

                #endregion

                #region M_8700_GERA_DEBITO_DB_INSERT_1_Insert1

                var q102 = new DynamicData();
                q102.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "OPCAOP_AGECTADEB" , "001" },
                { "OPCAOP_OPRCTADEB" , "OPR001" },
                { "OPCAOP_NUMCTADEB" , "123456" },
                { "OPCAOP_DIGCTADEB" , "7" },
                { "HISTCB_DTVENCTO" , "2023-12-20" },
                { "DESCON_VLPREMIO" , "50.00" },
                { "HOST_CODCONV" , "H123" },
                { "OPCAOP_CARTAOCRED" , "4111111111111111" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8700_GERA_DEBITO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8700_GERA_DEBITO_DB_INSERT_1_Insert1", q102);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1

                var q103 = new DynamicData();
                q103.AddDynamic(new Dictionary<string, string>{
                { "FUNDO_PCCOMIND" , "0.5%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1", q103);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1

                var q104 = new DynamicData();
                q104.AddDynamic(new Dictionary<string, string>{
                { "FUNDO_PCCOMGER" , "1%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1", q104);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1

                var q105 = new DynamicData();
                q105.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODPRODU" , "7705" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_FONTE" , "CEF" },
                { "PROPVA_AGECOBR" , "001" },
                { "PROPVA_CODCLIEN" , "456789" },
                { "PROPVA_NRMATRVEN" , "123456" },
                { "FUNDO_VALBASVG" , "100000.00" },
                { "FUNDO_VALBASAP" , "50000.00" },
                { "FUNDO_VLCOMISVG" , "500.00" },
                { "FUNDO_VLCOMISAP" , "250.00" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
                { "FUNDO_PCCOMIND" , "0.5%" },
                { "FUNDO_PCCOMGER" , "1%" },
                { "FUNDO_PCCOMSUP" , "0.2%" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1", q105);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1

                var q106 = new DynamicData();
                q106.AddDynamic(new Dictionary<string, string>{
                { "FUNDO_PCCOMSUP" , "0.2%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1", q106);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1

                var q107 = new DynamicData();
                q107.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , "0.38%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1", q107);

                #endregion

                #region R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1

                var q108 = new DynamicData();
                q108.AddDynamic(new Dictionary<string, string>{
                { "SIVPF_NR_IDENTIFI" , "ID123456789" },
                { "SIVPF_NR_SICOB" , "SIC123456" },
                { "SIVPF_SIT_PROPOSTA" , "Aprovada" },
                { "SIVPF_DTQITBCO" , "2023-12-15" },
                { "SIVPF_VAL_PAGO" , "200.00" },
                { "SIVPF_DATA_CREDITO" , "2023-12-16" },
                { "SIVPF_OPCAO_COBER" , "Cobertura Total" },
                { "SIVPF_COD_PLANO" , "PLN123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1", q108);

                #endregion

                #region R7773_00_LER_RCAPS_DB_SELECT_1_Query1

                var q109 = new DynamicData();
                q109.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "FNT001" },
                { "RCAPS_NUM_RCAP" , "RC123456" },
                { "RCAPS_VAL_RCAP" , "1500.00" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7773_00_LER_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7773_00_LER_RCAPS_DB_SELECT_1_Query1", q109);

                #endregion

                #region R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1

                var q110 = new DynamicData();
                q110.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , "001" },
                { "RCAPCOMP_AGE_AVISO" , "0001" },
                { "RCAPCOMP_NUM_AVISO_CREDITO" , "987654321" },
                { "RCAPCOMP_DATA_MOVIMENTO" , "2023-12-15" },
                { "RCAPCOMP_DATA_RCAP" , "2023-12-20" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1", q110);

                #endregion

                #region R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1

                var q111 = new DynamicData();
                q111.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SIT_PROP_FIDELIZ" , "Fidelizado" },
                { "WHOST_SITUACAO_ENVIO" , "Enviado" },
                { "SIVPF_DATA_CREDITO" , "2023-12-16" },
                { "SIVPF_OPCAO_COBER" , "Cobertura Total" },
                { "SIVPF_DTQITBCO" , "2023-12-15" },
                { "SIVPF_VAL_PAGO" , "200.00" },
                { "SIVPF_NR_PROPOSTA" , "27708000280671" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1", q111);

                #endregion

                #region R7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1_Update1

                var q112 = new DynamicData();
                q112.AddDynamic(new Dictionary<string, string>{
                { "CONVER_NUM_SICOB" , "SIC123" },
                { "SIVPF_NR_PROPOSTA" , "27708000280671" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1_Update1", q112);

                #endregion

                #region M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1

                var q113 = new DynamicData();
                q113.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "400.00" },
                { "COBERP_PRMAP" , "450.00" },
                { "PROPVA_NRCERTIF" , "98763456811007445554321" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1", q113);

                #endregion

                #region M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1

                var q114 = new DynamicData();
                q114.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "DIFPAR_CODOPER" , "DIF123" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
                { "COBERP_VLPREMIO" , "350.00" },
                { "V0HCOB_VLPRMTOT" , "800.00" },
                { "DIFPAR_PRMVG" , "2%" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1", q114);

                #endregion

                #region M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1

                var q115 = new DynamicData();
                q115.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "400.00" },
                { "COBERP_PRMAP" , "450.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1", q115);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute();
                var program = new VP0121B();
                program.Execute();

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var distintos = allSelects.Except(selects).ToList();

                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0000_PRINCIPAL_DB_SELECT_1_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0000_PRINCIPAL_DB_SELECT_2_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0000_PRINCIPAL_DB_SELECT_3_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0000_PRINCIPAL_DB_SELECT_4_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0100_OPCAOPAGVA_DB_SELECT_1_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0100_OPCAOPAGVA_DB_SELECT_5_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0100_OPCAOPAGVA_DB_SELECT_7_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0110_FETCH_DB_SELECT_1_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0110_FETCH_DB_SELECT_2_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1")).ToList());

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void VP0121B_Tests_Insert1_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                PROSOCU1_Tests.Load_Parameters();
                PROTIT01_Tests.Load_Parameters();
                FC0105B_Tests.Load_Parameters();
                FC0001S_Tests.Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , "2025-03-17" },
                { "SISTEMA_CURRDATE" , "2025-05-14" },
                { "SISTEMA_DTMOVABE2" , "2025-05-22" },
                { "SISTEMA_DTMOVABE3" , "2025-06-14" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_NUM_RAMO_PRSTMISTA" , "77" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q1);

                #endregion

                #region VP0121B_CPROPVA

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "109300000598" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_CODPRODU" , "7706" },
                { "PROPVA_CODCLIEN" , "456789" },
                { "PROPVA_OCOREND" , "12345" },
                { "PROPVA_FONTE" , "0" },
                { "PROPVA_AGECOBR" , "001" },
                { "PROPVA_OPCAO_COBER" , "A" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
                { "PROPVA_DTINICDG" , "2023-01-01" },
                { "PROPVA_DTINISAF" , "2023-01-01" },
                { "PROPVA_DTPROXVEN" , "2024-01-01" },
                { "PROPVA_DTMINVEN" , "2023-12-31" },
                { "PROPVA_NRMATRVEN" , "123456" },
                { "PROPVA_CODOPER" , "OP123" },
                { "PROPVA_DTMOVTO" , "2023-12-01" },
                { "PROPVA_SITUACAO" , "7" },
                { "PROPVA_NUM_APOLICE1" , "109300000598" },
                { "PROPVA_CODSUBES1" , "002" },
                { "PROPVA_OCORHIST" , "Ocorrencia Teste" },
                { "PROPVA_NRPARCEL" , "12" },
                { "PROPVA_SIT_INTERF" , "Ativa" },
                { "PROPVA_TIMESTAMP" , "2023-12-01T12:00:00" },
                { "PROPVA_IDADE" , "35" },
                { "PROPVA_SEXO" , "M" },
                { "PROPVA_EST_CIV" , "Casado" },
                { "PROPVA_COD_CRM" , "CRM123" },
                { "PROPVA_NRMATRFUN" , "654321" },
                { "PROPVA_DTADMIS" , "2020-01-01" },
                { "PROPVA_NRPROPOS" , "27708000280671" },
                { "PROPVA_CODCCT" , "CCT001" },
                { "PROPVA_CODUSU" , "USU123" },
                { "PROPVA_DTVENCTO" , "2024-01-01" },
                { "PROPVA_FAIXA_RENDA_IND" , "Alta" },
                { "PROPVA_DATA" , "2023-12-01" },
                { "PROPVA_DPS_TITULAR" , "" },
                { "PROPVA_ORIGEM_PROPOSTA" , "999" },
                { "PROPVA_ACATAMENTO" , "N" },
                { "PROPVA_COD_OPER_CREDITO" , "CRED123" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0121B_CPROPVA");
                AppSettings.TestSet.DynamicData.Add("VP0121B_CPROPVA", q2);

                #endregion

                #region VP0121B_V1RCAPCOMP

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , "Fonte1" },
                { "V1RCAC_NRRCAP" , "321" },
                { "V1RCAC_NRRCAPCO" , "321CO" },
                { "V1RCAC_OPERACAO" , "Oper123" },
                { "V1RCAC_DTMOVTO" , "2023-12-01" },
                { "V1RCAC_HORAOPER" , "12:00" },
                { "V1RCAC_SITUACAO" , "Ativa" },
                { "V1RCAC_BCOAVISO" , "001" },
                { "V1RCAC_AGEAVISO" , "002" },
                { "V1RCAC_NRAVISO" , "003" },
                { "V1RCAC_VLRCAP" , "1000.00" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
                { "V1RCAC_DTCADAST" , "2023-12-01" },
                { "V1RCAC_SITCONTB" , "Confirmada" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0121B_V1RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("VP0121B_V1RCAPCOMP", q3);

                #endregion

                #region M_0000_PRINCIPAL_DB_UPDATE_1_Update1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NRTIT" , "85172719932" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_UPDATE_1_Update1", q4);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_3_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SUBGRU_CODSUBES" , "0" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_3_Query1", q5);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_4_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NRTIT" , "85172719932" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_4_Query1", q6);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "PRODVG_CODPRODAZ" , "P123" },
                { "PRODVG_PERIPGTO" , "Mensal" },
                { "PRODVG_ESTR_COBR" , "Estruturada" },
                { "PRODVG_ORIG_PRODU" , "MULT" },
                { "PRODVG_AGENCIADOR" , "Agente123" },
                { "PRODVG_TEM_SAF" , "Sim" },
                { "PRODVG_TEM_CDG" , "Não" },
                { "PRODVG_CODRELAT" , "R123" },
                { "PRODVG_COBERADIC_PREMIO" , "100.00" },
                { "PRODVG_CUSTOCAP_TOTAL" , "200.00" },
                { "PRODVG_DESCONTO_ADESAO" , "10.00" },
                { "PRODVG_COD_PRODUTO" , "7706" },
                { "PRODVG_RISCO" , "Baixo" },
                { "PRODVG_SITPLANCEF" , "Ativo" },
                { "PRODVG_ARQ_FDCAP" , "Arquivo123" },
                { "PRODVG_COD_RUBRICA" , "RUB001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1", q7);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_OPCAOPAG" , "1" },
                { "OPCAOP_PERIPGTO" , "4" },
                { "OPCAOP_DIA_DEB" , "0" },
                { "OPCAOP_AGECTADEB" , "0" },
                { "OPCAOP_OPRCTADEB" , "OPR001" },
                { "OPCAOP_NUMCTADEB" , "123456" },
                { "OPCAOP_DIGCTADEB" , "7" },
                { "OPCAOP_CARTAOCRED" , "4111111111111111" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_1_Query1", q8);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_PERIPGTO" , "4" },
                { "OPCAOP_OPCAOPAG" , "1" },
                { "OPCAOP_DIA_DEB" , "0" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1", q9);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "WTEM_ERRO_7705" , "Erro7705" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1", q10);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_2_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V0AGCEF_COD_AGCOBR" , "AG001" }
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_2_Query1", q11);

                #endregion

                #region M_0100_NEXT_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_NEXT_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0100_NEXT_DB_UPDATE_1_Update1", q12);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_3_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V0COBER_MINOCOR" , "MinOcor001" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_3_Query1", q13);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "WTEM_ERRO_7715" , "Erro7715" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1", q14);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_4_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "COBERP_DTINIVIG" , "2023-01-01" },
                { "COBERP_DTTERVIG" , "2024-01-01" },
                { "COBERP_IMPMORNATU" , "0" },
                { "COBERP_IMPMORACID" , "100.00" },
                { "COBERP_IMPINVPERM" , "150.00" },
                { "COBERP_IMPAMDS" , "200.00" },
                { "COBERP_IMPDH" , "250.00" },
                { "COBERP_IMPDIT" , "300.00" },
                { "COBERP_VLPREMIO" , "2" },
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "COBERP_IMPSEGCDG" , "500.00" },
                { "COBERP_VLCUSTCDG" , "550.00" },
                { "COBERP_VLCUSTCAP" , "600.00" },
                { "COBERP_IMPSEGAUXF" , "650.00" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "COBERP_QTTITCAP" , "750" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_4_Query1", q15);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_5_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "COBERP_DTINIVIG" , "2023-01-01" },
                { "COBERP_IMPMORNATU" , "0" },
                { "COBERP_IMPMORACID" , "100.00" },
                { "COBERP_IMPINVPERM" , "150.00" },
                { "COBERP_IMPAMDS" , "200.00" },
                { "COBERP_IMPDH" , "250.00" },
                { "COBERP_IMPDIT" , "300.00" },
                { "COBERP_VLPREMIO" , "2" },
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "COBERP_IMPSEGCDG" , "500.00" },
                { "COBERP_VLCUSTCDG" , "550.00" },
                { "COBERP_VLCUSTCAP" , "600.00" },
                { "COBERP_IMPSEGAUXF" , "650.00" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "COBERP_QTTITCAP" , "750" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_5_Query1", q16);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , "1988-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1", q17);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_6_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , "800.00" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_6_Query1", q18);

                #endregion

                #region M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "ERRPROVI_COD_ERRO" , "1002" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1", q19);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_DTPROXVEN" , "2024-01-01" },
                { "PROPVA_CODPRODU" , "7706" },
                { "PROPVA_SITUACAO" , "7" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_CODOPER" , "OP123" },
                { "MDTMOVTO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1", q20);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_7_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , "800.00" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_7_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_7_Query1", q21);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRPROPOS" , "27708000280671" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1", q22);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_8_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , "109300000598" },
                { "RELATO_CODSUBES" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_8_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_8_Query1", q23);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_9_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , "109300000598" },
                { "RELATO_CODSUBES" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_9_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_9_Query1", q24);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRCERTIF" , "987654321" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1", q25);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_10_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , "109300000598" },
                { "RELATO_CODSUBES" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_10_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_10_Query1", q26);

                #endregion

                #region M_0110_FETCH_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA_MOVIMENTO" , "2023-12-01" }
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("M_0110_FETCH_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_DB_SELECT_1_Query1", q27);

                #endregion

                #region M_0110_FETCH_DB_UPDATE_1_Update1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0110_FETCH_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_DB_UPDATE_1_Update1", q28);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_11_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , "109300000598" },
                { "RELATO_CODSUBES" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_11_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_11_Query1", q29);

                #endregion

                #region M_0110_FETCH_DB_SELECT_2_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_RAMO" , "77" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0110_FETCH_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_DB_SELECT_2_Query1", q30);

                #endregion

                #region M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-12-01" },
                { "WHOST_PROXIMA_DATA" , "2023-12-02" },
                { "CALENDAR_DIA_SEMANA" , "Q" },
                { "CALENDAR_FERIADO" , "Não" },
            });

                q31.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-12-02" },
                { "WHOST_PROXIMA_DATA" , "2023-12-03" },
                { "CALENDAR_DIA_SEMANA" , "Q" },
                { "CALENDAR_FERIADO" , "Não" },
            });

                q31.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-12-03" },
                { "WHOST_PROXIMA_DATA" , "2023-12-04" },
                { "CALENDAR_DIA_SEMANA" , "Q" },
                { "CALENDAR_FERIADO" , "Não" },
            });
                q31.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-12-04" },
                { "WHOST_PROXIMA_DATA" , "2023-12-05" },
                { "CALENDAR_DIA_SEMANA" , "Q" },
                { "CALENDAR_FERIADO" , "Não" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1", q31);

                #endregion

                #region M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                { "RELATO_CODRELAT" , "R123" },
                { "PROPVA_NUM_APOLICE" , "109300000598" },
                { "RELATO_NRPARCEL" , "12" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_CODSUBES" , "001" },
                { "RELATO_OPERACAO" , "Oper123" },
                { "WS_SIT_REGISTRO" , "Ativo" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1", q32);

                #endregion

                #region M_0300_VERIFICA_CROT_DB_SELECT_1_Query1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_CGCCPF" , "12345678901" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0300_VERIFICA_CROT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0300_VERIFICA_CROT_DB_SELECT_1_Query1", q33);

                #endregion

                #region M_0300_VERIFICA_CROT_DB_SELECT_2_Query1

                var q34 = new DynamicData();
                q34.AddDynamic(new Dictionary<string, string>{
                { "CLIROT_DTMOVABE" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0300_VERIFICA_CROT_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0300_VERIFICA_CROT_DB_SELECT_2_Query1", q34);

                #endregion

                #region M_0320_UPDATE_CROT_DB_UPDATE_1_Update1

                var q35 = new DynamicData();
                q35.AddDynamic(new Dictionary<string, string>{
                { "CLIROT_DTMOVABE" , "2023-12-01" },
                { "CLIENT_CGCCPF" , "12345678901" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0320_UPDATE_CROT_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0320_UPDATE_CROT_DB_UPDATE_1_Update1", q35);

                #endregion

                #region M_0330_INCLUI_CROT_DB_INSERT_1_Insert1

                var q36 = new DynamicData();
                q36.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_CGCCPF" , "12345678901" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0330_INCLUI_CROT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0330_INCLUI_CROT_DB_INSERT_1_Insert1", q36);

                #endregion

                #region R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1

                var q37 = new DynamicData();
                q37.AddDynamic(new Dictionary<string, string>{
                { "V0FOLHM_DTEMICAR" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1", q37);

                #endregion

                #region R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1

                var q38 = new DynamicData();
                q38.AddDynamic(new Dictionary<string, string>{
                { "V0FOLH_COD_CARTA" , "C123" },
                { "V0FOLH_DTEMICAR" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1", q38);

                #endregion

                #region M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1

                var q39 = new DynamicData();
                q39.AddDynamic(new Dictionary<string, string>{
                { "V0FOLH_COD_PRODUTO" , "7705" },
                { "V0FOLH_NRCERTIF" , "987654321" },
                { "V0FOLH_COD_CARTA" , "C123" },
                { "V0FOLH_DTEMICAR" , "2023-12-01" },
                { "V0FOLH_DTSOLICIT" , "2023-12-01" },
                { "V0FOLH_CODUSU" , "USU123" },
                { "V0FOLH_SITUACAO" , "Ativa" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1", q39);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1

                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                { "CONVER_NUM_SICOB" , "SIC123" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1", q40);

                #endregion

                #region FINALIZA_1110_FIM_DB_UPDATE_1_Update1

                var q41 = new DynamicData();
                q41.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "CONVER_NUM_PROPOSTA" , "27708000280671" },
            });
                AppSettings.TestSet.DynamicData.Remove("FINALIZA_1110_FIM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("FINALIZA_1110_FIM_DB_UPDATE_1_Update1", q41);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1

                var q42 = new DynamicData();
                q42.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "Fonte1" },
                { "V0RCAP_NRRCAP" , "321" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1", q42);

                #endregion

                #region FINALIZA_1110_FIM_DB_UPDATE_2_Update1

                var q43 = new DynamicData();
                q43.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "V0RCAP_NRRCAP" , "321" },
                { "V0RCAP_FONTE" , "Fonte1" },
            });
                AppSettings.TestSet.DynamicData.Remove("FINALIZA_1110_FIM_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("FINALIZA_1110_FIM_DB_UPDATE_2_Update1", q43);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1

                var q44 = new DynamicData();
                q44.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "109300000598" },
                { "V0RCAP_NRRCAP" , "321" },
                { "V0RCAP_FONTE" , "Fonte1" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1", q44);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1

                var q45 = new DynamicData();
                q45.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "001" },
                { "V1RCAC_AGEAVISO" , "002" },
                { "V1RCAC_NRAVISO" , "003" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1", q45);

                #endregion

                #region VP0121B_CBENEFP

                var q46 = new DynamicData();
                q46.AddDynamic(new Dictionary<string, string>{
                { "BENEF_NOMBENEF" , "Nome Beneficiário" },
                { "BENEF_GRAUPAR" , "Grau Parentesco" },
                { "BENEF_PCTBENEF" , "50%" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0121B_CBENEFP");
                AppSettings.TestSet.DynamicData.Add("VP0121B_CBENEFP", q46);

                #endregion

                #region M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1

                var q47 = new DynamicData();
                q47.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_NRRCAPCO" , "321CO" },
                { "V1RCAC_OPERACAO" , "Oper123" },
                { "V1RCAC_HORAOPER" , "12:00" },
                { "V1RCAC_DTMOVTO" , "2023-12-01" },
                { "V1RCAC_NRRCAP" , "321" },
                { "V1RCAC_FONTE" , "Fonte1" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1", q47);

                #endregion

                #region M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1

                var q48 = new DynamicData();
                q48.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , "Fonte1" },
                { "V1RCAC_NRRCAP" , "321" },
                { "V1RCAC_NRRCAPCO" , "321CO" },
                { "V1RCAC_OPERACAO" , "Oper123" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
                { "V1RCAC_SITUACAO" , "Ativa" },
                { "V1RCAC_BCOAVISO" , "001" },
                { "V1RCAC_AGEAVISO" , "002" },
                { "V1RCAC_NRAVISO" , "003" },
                { "V1RCAC_VLRCAP" , "1000.00" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
                { "V1RCAC_DTCADAST" , "2023-12-01" },
                { "V1RCAC_SITCONTB" , "Confirmada" },
                { "V1RCAC_COD_EMPRESA" , "EMP123" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1", q48);

                #endregion

                #region M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1

                var q49 = new DynamicData();
                q49.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_VLRCAP" , "1000.00" },
                { "V1RCAC_BCOAVISO" , "001" },
                { "V1RCAC_AGEAVISO" , "002" },
                { "V1RCAC_NRAVISO" , "003" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1", q49);

                #endregion

                #region M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1

                var q50 = new DynamicData();
                q50.AddDynamic(new Dictionary<string, string>{
                { "PRODVG_CODPRODAZ" , "P123" },
                { "PRODVG_ESTR_COBR" , "Estruturada" },
                { "PRODVG_ORIG_PRODU" , "MULT" },
                { "PRODVG_AGENCIADOR" , "Agente123" },
                { "PRODVG_TEM_SAF" , "Sim" },
                { "PRODVG_TEM_CDG" , "Não" },
                { "PRODVG_CODRELAT" , "R123" },
                { "PRODVG_COBERADIC_PREMIO" , "100.00" },
                { "PRODVG_CUSTOCAP_TOTAL" , "200.00" },
                { "PRODVG_DESCONTO_ADESAO" , "10.00" },
                { "PRODVG_COD_PRODUTO" , "7706" },
                { "PRODVG_RISCO" , "Baixo" },
                { "PRODVG_SITPLANCEF" , "Ativo" },
                { "PRODVG_ARQ_FDCAP" , "Arquivo123" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1", q50);

                #endregion

                #region M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1

                var q51 = new DynamicData();
                q51.AddDynamic(new Dictionary<string, string>{
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1", q51);

                #endregion

                #region M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1

                var q52 = new DynamicData();
                q52.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODSUBES" , "001" },
                { "MTXAPMA" , "Matriz AP MA" },
                { "MTXAPIP" , "Matriz AP IP" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1", q52);

                #endregion

                #region M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1

                var q53 = new DynamicData();
                q53.AddDynamic(new Dictionary<string, string>{
                { "APCORR_RAMO" , "Vida" },
                { "PROPVA_CODSUBES" , "001" },
                { "APCORR_DTINIVIG" , "2023-01-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1", q53);

                #endregion

                #region M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1

                var q54 = new DynamicData();
                q54.AddDynamic(new Dictionary<string, string>{
                { "COMISSOE_NUM_APOLICE" , "109300000598" },
                { "COMISSOE_NUM_ENDOSSO" , "E123" },
                { "COMISSOE_NUM_CERTIFICADO" , "7457254811" },
                { "COMISSOE_DAC_CERTIFICADO" , "DAC123" },
                { "COMISSOE_TIPO_SEGURADO" , "Titular" },
                { "COMISSOE_NUM_PARCELA" , "12" },
                { "COMISSOE_COD_OPERACAO" , "OP123" },
                { "COMISSOE_COD_PRODUTOR" , "Prod123" },
                { "COMISSOE_RAMO_COBERTURA" , "Vida" },
                { "COMISSOE_MODALI_COBERTURA" , "Modalidade1" },
                { "COMISSOE_OCORR_HISTORICO" , "Histórico Ocorrência" },
                { "COMISSOE_COD_FONTE" , "Fonte1" },
                { "COMISSOE_COD_CLIENTE" , "456789" },
                { "COMISSOE_VAL_COMISSAO" , "100.00" },
                { "COMISSOE_DATA_CALCULO" , "2023-12-01" },
                { "COMISSOE_NUM_RECIBO" , "R123456" },
                { "COMISSOE_VAL_BASICO" , "200.00" },
                { "COMISSOE_TIPO_COMISSAO" , "Tipo1" },
                { "COMISSOE_QTD_PARCELAS" , "12" },
                { "COMISSOE_PCT_COM_CORRETOR" , "10%" },
                { "COMISSOE_PCT_DESC_PREMIO" , "5%" },
                { "COMISSOE_COD_SUBGRUPO" , "SG001" },
                { "COMISSOE_DATA_MOVIMENTO" , "2023-12-01" },
                { "COMISSOE_DATA_SELECAO" , "2023-12-01" },
                { "COMISSOE_COD_EMPRESA" , "EMP123" },
                { "COMISSOE_COD_PREPOSTO" , "Prep123" },
                { "COMISSOE_NUM_BILHETE" , "B123456" },
                { "COMISSOE_VAL_VARMON" , "300.00" },
                { "COMISSOE_DATA_QUITACAO" , "2024-01-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1", q54);

                #endregion

                #region M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1

                var q55 = new DynamicData();
                q55.AddDynamic(new Dictionary<string, string>{
                { "PROD_COD_EMPRESA" , "EMP123" },
                { "PARM_COD_EMPR_CAP" , "EMP123" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1", q55);

                #endregion

                #region R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1

                var q56 = new DynamicData();
                q56.AddDynamic(new Dictionary<string, string>{
                { "COMFEDCA_SITUACAO" , "Ativa" }
            });
                AppSettings.TestSet.DynamicData.Remove("R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1", q56);

                #endregion

                #region R6290_10_INSERT_DB_INSERT_1_Insert1

                var q57 = new DynamicData();
                q57.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_FONTE" , "CEF" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
                { "MOVFEDCA_VAL_CUSTO_CAPITALI" , "100.00" },
                { "MOVFEDCA_NRTITFDCAP" , "123456" },
                { "PRODVG_COD_PRODUTO" , "7706" },
            });
                AppSettings.TestSet.DynamicData.Remove("R6290_10_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R6290_10_INSERT_DB_INSERT_1_Insert1", q57);

                #endregion

                #region R6300_00_INSERT_DB_INSERT_1_Insert1

                var q58 = new DynamicData();
                q58.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_NRTITFDCAP" , "123456" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "TITFEDCA_DATA_INIVIGENCIA" , "2023-01-01" },
                { "TITFEDCA_DATA_TERVIGENCIA" , "2024-01-01" },
                { "TITFEDCA_NRSORTEIO" , "S123456" },
                { "TITFEDCA_VAL_CUSTO_TITULO" , "150.00" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R6300_00_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R6300_00_INSERT_DB_INSERT_1_Insert1", q58);

                #endregion

                #region R6400_10_INSERT_DB_INSERT_1_Insert1

                var q59 = new DynamicData();
                q59.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R6400_10_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R6400_10_INSERT_DB_INSERT_1_Insert1", q59);

                #endregion

                #region R6500_10_INSERT_DB_INSERT_1_Insert1

                var q60 = new DynamicData();
                q60.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_NRTITFDCAP" , "123456" },
                { "PARFEDCA_VAL_CUSTO_TITULO" , "150.00" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R6500_10_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R6500_10_INSERT_DB_INSERT_1_Insert1", q60);

                #endregion

                #region R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1

                var q61 = new DynamicData();
                q61.AddDynamic(new Dictionary<string, string>{
                { "COMFEDCA_SITUACAO" , "Ativa" }
            });
                AppSettings.TestSet.DynamicData.Remove("R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1", q61);

                #endregion

                #region R7400_10_INSERT_DB_INSERT_1_Insert1

                var q62 = new DynamicData();
                q62.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7400_10_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R7400_10_INSERT_DB_INSERT_1_Insert1", q62);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_1_Query1

                var q63 = new DynamicData();
                q63.AddDynamic(new Dictionary<string, string>{
                { "CONDTE_IEA" , "Inclusão" },
                { "CONDTE_IPA" , "Proposta" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_1_Query1", q63);

                #endregion

                #region R8000_PROPAUTOM_DB_INSERT_1_Insert1

                var q64 = new DynamicData();
                q64.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "109300000598" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_FONTE" , "0" },
                { "FONTE_PROPAUTOM" , "Automática" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "MTPINCLUS" , "Inclusão Manual" },
                { "PROPVA_CODCLIEN" , "456789" },
                { "MAGENCIADOR" , "Agente123" },
                { "MMFAIXA" , "Faixa1" },
                { "MTPBENEF" , "Tipo Benefício" },
                { "OPCAOP_PERIPGTO" , "4" },
                { "PROPVA_EST_CIV" , "Casado" },
                { "PROPVA_SEXO" , "M" },
                { "MAGECOBR" , "Agência Cobrança" },
                { "MMNUM_MATRICULA" , "Mat123" },
                { "MNUM_CTA_CORRENTE" , "Conta123" },
                { "MDAC_CTA_CORRENTE" , "DAC123" },
                { "MTXAPMA" , "Matriz AP MA" },
                { "MTXAPIP" , "Matriz AP IP" },
                { "MTXVG" , "Matriz VG" },
                { "COBERP_IMPMORNATU" , "0" },
                { "COBERP_IMPMORACID" , "100.00" },
                { "COBERP_IMPINVPERM" , "150.00" },
                { "COBERP_IMPAMDS" , "200.00" },
                { "COBERP_IMPDH" , "250.00" },
                { "COBERP_IMPDIT" , "300.00" },
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "MCODOPER" , "OP123" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
                { "PROPVA_CODUSU" , "USU123" },
                { "WSISTEMA_DTMOVABE" , "2023-12-01" },
                { "CLIENT_DTNASC" , "1988-01-01" },
                { "MDTREF" , "2023-12-01" },
                { "MMDTMOVTO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_INSERT_1_Insert1", q64);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_2_Query1

                var q65 = new DynamicData();
                q65.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , "1988-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_2_Query1", q65);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_1_Update1

                var q66 = new DynamicData();
                q66.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , "Automática" },
                { "PROPVA_FONTE" , "0" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_1_Update1", q66);

                #endregion

                #region R8000_PROPAUTOM_DB_INSERT_2_Insert1

                var q67 = new DynamicData();
                q67.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "109300000598" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_FONTE" , "0" },
                { "FONTE_PROPAUTOM" , "Automática" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "MTPINCLUS" , "Inclusão Manual" },
                { "PROPVA_CODCLIEN" , "456789" },
                { "MAGENCIADOR" , "Agente123" },
                { "MMFAIXA" , "Faixa1" },
                { "MTPBENEF" , "Tipo Benefício" },
                { "OPCAOP_PERIPGTO" , "4" },
                { "PROPVA_EST_CIV" , "Casado" },
                { "PROPVA_SEXO" , "M" },
                { "MAGECOBR" , "Agência Cobrança" },
                { "MMNUM_MATRICULA" , "Mat123" },
                { "MNUM_CTA_CORRENTE" , "Conta123" },
                { "MDAC_CTA_CORRENTE" , "DAC123" },
                { "MTXAPMA" , "Matriz AP MA" },
                { "MTXAPIP" , "Matriz AP IP" },
                { "MTXVG" , "Matriz VG" },
                { "COBERP_IMPMORNATU" , "0" },
                { "COBERP_IMPMORACID" , "100.00" },
                { "COBERP_IMPINVPERM" , "150.00" },
                { "COBERP_IMPAMDS" , "200.00" },
                { "COBERP_IMPDH" , "250.00" },
                { "COBERP_IMPDIT" , "300.00" },
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "MCODOPER" , "OP123" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
                { "PROPVA_CODUSU" , "USU123" },
                { "WSISTEMA_DTMOVABE" , "2023-12-01" },
                { "PROPVA_DTADMIS" , "2020-01-01" },
                { "CLIENT_DTNASC" , "1988-01-01" },
                { "MDTREF" , "2023-12-01" },
                { "MMDTMOVTO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_INSERT_2_Insert1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_INSERT_2_Insert1", q67);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_2_Update1

                var q68 = new DynamicData();
                q68.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_2_Update1", q68);

                #endregion

                #region R8000_PROPAUTOM_DB_SELECT_1_Query1

                var q69 = new DynamicData();
                q69.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , "800.00" }
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_SELECT_1_Query1", q69);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_3_Update1

                var q70 = new DynamicData();
                q70.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_3_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_3_Update1", q70);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_3_Query1

                var q71 = new DynamicData();
                q71.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , "25-35" },
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_3_Query1", q71);

                #endregion

                #region R8000_PROPAUTOM_DB_SELECT_2_Query1

                var q72 = new DynamicData();
                q72.AddDynamic(new Dictionary<string, string>{
                { "COMISI_VALADT" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_SELECT_2_Query1", q72);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_4_Update1

                var q73 = new DynamicData();
                q73.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_4_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_4_Update1", q73);

                #endregion

                #region M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1

                var q74 = new DynamicData();
                q74.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , "25-35" },
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1", q74);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_5_Update1

                var q75 = new DynamicData();
                q75.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_5_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_5_Update1", q75);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_4_Query1

                var q76 = new DynamicData();
                q76.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , "25-35" },
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_4_Query1", q76);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_5_Query1

                var q77 = new DynamicData();
                q77.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , "25-35" },
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_5_Query1", q77);

                #endregion

                #region M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1

                var q78 = new DynamicData();
                q78.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "3" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1", q78);

                #endregion

                #region VP0121B_C01_RCAPCOMP

                var q79 = new DynamicData();
                q79.AddDynamic(new Dictionary<string, string>{
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_BCO_AVISO" , "237" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_AGE_AVISO" , "1234" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_NUM_AVISO_CREDITO" , "987654321" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_MOVIMENTO" , "2023-12-15" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_RCAP" , "2023-12-20" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_COD_OPERACAO" , "OP123" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0121B_C01_RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("VP0121B_C01_RCAPCOMP", q79);

                #endregion

                #region M_8100_LOOP_DB_INSERT_1_Insert1

                var q80 = new DynamicData();
                q80.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "109300000598" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_FONTE" , "0" },
                { "FONTE_PROPAUTOM" , "Automática" },
                { "BENEF_NRBENEF" , "BN1234567" },
                { "BENEF_NOMBENEF" , "Nome Beneficiário" },
                { "BENEF_GRAUPAR" , "Grau Parentesco" },
                { "BENEF_PCTBENEF" , "50%" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8100_LOOP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8100_LOOP_DB_INSERT_1_Insert1", q80);

                #endregion

                #region M_8200_CONCEDE_CDG_DB_SELECT_1_Query1

                var q81 = new DynamicData();
                q81.AddDynamic(new Dictionary<string, string>{
                { "CDGCOB_DTINIVIG" , "2023-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8200_CONCEDE_CDG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8200_CONCEDE_CDG_DB_SELECT_1_Query1", q81);

                #endregion

                #region M_8200_CONCEDE_CDG_DB_SELECT_2_Query1

                var q82 = new DynamicData();
                q82.AddDynamic(new Dictionary<string, string>{
                { "REPCDG_DTREF" , "2023-01-31" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8200_CONCEDE_CDG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8200_CONCEDE_CDG_DB_SELECT_2_Query1", q82);

                #endregion

                #region M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1

                var q83 = new DynamicData();
                q83.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1", q83);

                #endregion

                #region M_8220_INCLUI_CDG_DB_INSERT_1_Insert1

                var q84 = new DynamicData();
                q84.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "PROPVA_DTINICDG" , "2023-01-01" },
                { "COBERP_IMPSEGCDG" , "500.00" },
                { "COBERP_VLCUSTCDG" , "550.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_OCORHIST" , "Ocorrencia Teste" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8220_INCLUI_CDG_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8220_INCLUI_CDG_DB_INSERT_1_Insert1", q84);

                #endregion

                #region M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1

                var q85 = new DynamicData();
                q85.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "REPCDG_DTREF" , "2023-01-31" },
                { "COBERP_VLCUSTCDG" , "550.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1", q85);

                #endregion

                #region M_8300_CONCEDE_SAF_DB_SELECT_1_Query1

                var q86 = new DynamicData();
                q86.AddDynamic(new Dictionary<string, string>{
                { "SAFCOB_DTINIVIG" , "2023-02-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8300_CONCEDE_SAF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8300_CONCEDE_SAF_DB_SELECT_1_Query1", q86);

                #endregion

                #region M_8300_CONCEDE_SAF_DB_SELECT_2_Query1

                var q87 = new DynamicData();
                q87.AddDynamic(new Dictionary<string, string>{
                { "REPSAF_DTREF" , "2025-02-28" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8300_CONCEDE_SAF_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8300_CONCEDE_SAF_DB_SELECT_2_Query1", q87);

                #endregion

                #region M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1

                var q88 = new DynamicData();
                q88.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1", q88);

                #endregion

                #region M_8320_INCLUI_SAF_DB_INSERT_1_Insert1

                var q89 = new DynamicData();
                q89.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "PROPVA_DTINISAF" , "2023-01-01" },
                { "COBERP_IMPSEGAUXF" , "650.00" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_OCORHIST" , "Ocorrencia Teste" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8320_INCLUI_SAF_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8320_INCLUI_SAF_DB_INSERT_1_Insert1", q89);

                #endregion

                #region M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1

                var q90 = new DynamicData();
                q90.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "REPSAF_DTREF" , "2023-02-28" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_NRMATRFUN" , "654321" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "PROPVA_CODOPER" , "OP123" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1", q90);

                #endregion

                #region M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1

                var q91 = new DynamicData();
                q91.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "REPSAF_DTREF" , "2023-02-28" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_NRMATRFUN" , "654321" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1", q91);

                #endregion

                #region M_8400_00_DEBITO_CARTAO_DB_INSERT_1_Insert1

                var q92 = new DynamicData();
                q92.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_EMPRESA" , "EMP001" },
                { "MOVDEBCE_NUM_APOLICE" , "APL123456" },
                { "MOVDEBCE_NUM_ENDOSSO" , "END123456" },
                { "MOVDEBCE_NUM_PARCELA" , "PAR123456" },
                { "MOVDEBCE_SITUACAO_COBRANCA" , "Pendente" },
                { "MOVDEBCE_DATA_VENCIMENTO" , "2023-12-31" },
                { "MOVDEBCE_VALOR_DEBITO" , "500.00" },
                { "MOVDEBCE_DATA_MOVIMENTO" , "2023-12-01" },
                { "MOVDEBCE_DIA_DEBITO" , "15" },
                { "MOVDEBCE_COD_AGENCIA_DEB" , "0001" },
                { "MOVDEBCE_OPER_CONTA_DEB" , "013" },
                { "MOVDEBCE_NUM_CONTA_DEB" , "12345678" },
                { "MOVDEBCE_DIG_CONTA_DEB" , "9" },
                { "MOVDEBCE_COD_CONVENIO" , "CONV001" },
                { "MOVDEBCE_DATA_ENVIO" , "2023-12-02" },
                { "MOVDEBCE_DATA_RETORNO" , "2023-12-03" },
                { "MOVDEBCE_COD_RETORNO_CEF" , "RET001" },
                { "MOVDEBCE_NSAS" , "NS123456" },
                { "MOVDEBCE_COD_USUARIO" , "USR001" },
                { "MOVDEBCE_NUM_REQUISICAO" , "REQ123456" },
                { "MOVDEBCE_NUM_CARTAO" , "CARD1234567890" },
                { "MOVDEBCE_SEQUENCIA" , "SEQ123" },
                { "MOVDEBCE_NUM_LOTE" , "LOT123" },
                { "MOVDEBCE_DTCREDITO" , "2023-12-05" },
                { "MOVDEBCE_STATUS_CARTAO" , "Ativo" },
                { "MOVDEBCE_VLR_CREDITO" , "1000.00" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8400_00_DEBITO_CARTAO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8400_00_DEBITO_CARTAO_DB_INSERT_1_Insert1", q92);

                #endregion

                #region M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1

                var q93 = new DynamicData();
                q93.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , "Automática" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1", q93);

                #endregion

                #region M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1

                var q94 = new DynamicData();
                q94.AddDynamic(new Dictionary<string, string>{
                { "W03_VENCIMENTO" , "2023-12-10" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1", q94);

                #endregion

                #region M_8600_10_CONTINUA_DB_SELECT_1_Query1

                var q95 = new DynamicData();
                q95.AddDynamic(new Dictionary<string, string>{
                { "DESCON_PERC" , "10%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_10_CONTINUA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_SELECT_1_Query1", q95);

                #endregion

                #region M_8600_10_CONTINUA_DB_INSERT_1_Insert1

                var q96 = new DynamicData();
                q96.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "HISTCB_DTVENCTO" , "2023-12-20" },
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "OPCAOP_OPCAOPAG" , "1" },
                { "PARCEL_OCORHIST" , "Ocorrência 1" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_10_CONTINUA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_INSERT_1_Insert1", q96);

                #endregion

                #region M_8600_CONTINUA_DB_UPDATE_1_Update1

                var q97 = new DynamicData();
                q97.AddDynamic(new Dictionary<string, string>{
                { "HISTCB_DTVENCTO" , "2023-12-20" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_CONTINUA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_8600_CONTINUA_DB_UPDATE_1_Update1", q97);

                #endregion

                #region M_8600_10_CONTINUA_DB_INSERT_2_Insert1

                var q98 = new DynamicData();
                q98.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "BANCOS_NRTIT" , "85172719932" },
                { "HISTCB_DTVENCTO" , "2023-12-20" },
                { "DESCON_VLPREMIO" , "50.00" },
                { "OPCAOP_OPCAOPAG" , "1" },
                { "HISTCB_SITUACAO" , "Ativa" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_10_CONTINUA_DB_INSERT_2_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_INSERT_2_Insert1", q98);

                #endregion

                #region M_8600_CONTINUA_DB_UPDATE_2_Update1

                var q99 = new DynamicData();
                q99.AddDynamic(new Dictionary<string, string>{
                { "WS_PROPVA_DTPROXVEN" , "2024-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_CONTINUA_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("M_8600_CONTINUA_DB_UPDATE_2_Update1", q99);

                #endregion

                #region M_8600_10_CONTINUA_DB_INSERT_3_Insert1

                var q100 = new DynamicData();
                q100.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "HISTCB_DTVENCTO" , "2023-12-20" },
                { "DESCON_PRMVG" , "5%" },
                { "DESCON_PRMAP" , "3%" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_10_CONTINUA_DB_INSERT_3_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_INSERT_3_Insert1", q100);

                #endregion

                #region M_8700_GERA_DEBITO_DB_SELECT_1_Query1

                var q101 = new DynamicData();
                q101.AddDynamic(new Dictionary<string, string>{
                { "CONVEN_CODCONV" , "C123" },
                { "CONVEN_CARTAO" , "1234567890123456" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8700_GERA_DEBITO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8700_GERA_DEBITO_DB_SELECT_1_Query1", q101);

                #endregion

                #region M_8700_GERA_DEBITO_DB_INSERT_1_Insert1

                var q102 = new DynamicData();
                q102.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "OPCAOP_AGECTADEB" , "0" },
                { "OPCAOP_OPRCTADEB" , "OPR001" },
                { "OPCAOP_NUMCTADEB" , "123456" },
                { "OPCAOP_DIGCTADEB" , "7" },
                { "HISTCB_DTVENCTO" , "2023-12-20" },
                { "DESCON_VLPREMIO" , "50.00" },
                { "HOST_CODCONV" , "H123" },
                { "OPCAOP_CARTAOCRED" , "4111111111111111" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8700_GERA_DEBITO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8700_GERA_DEBITO_DB_INSERT_1_Insert1", q102);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1

                var q103 = new DynamicData();
                q103.AddDynamic(new Dictionary<string, string>{
                { "FUNDO_PCCOMIND" , "1%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1", q103);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1

                var q104 = new DynamicData();
                q104.AddDynamic(new Dictionary<string, string>{
                { "FUNDO_PCCOMGER" , "1%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1", q104);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1

                var q105 = new DynamicData();
                q105.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODPRODU" , "7706" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_FONTE" , "0" },
                { "PROPVA_AGECOBR" , "001" },
                { "PROPVA_CODCLIEN" , "456789" },
                { "PROPVA_NRMATRVEN" , "123456" },
                { "FUNDO_VALBASVG" , "100000.00" },
                { "FUNDO_VALBASAP" , "50000.00" },
                { "FUNDO_VLCOMISVG" , "500.00" },
                { "FUNDO_VLCOMISAP" , "250.00" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
                { "FUNDO_PCCOMIND" , "1%" },
                { "FUNDO_PCCOMGER" , "1%" },
                { "FUNDO_PCCOMSUP" , "1%" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1", q105);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1

                var q106 = new DynamicData();
                q106.AddDynamic(new Dictionary<string, string>{
                { "FUNDO_PCCOMSUP" , "1%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1", q106);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1

                var q107 = new DynamicData();
                q107.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , "0.38%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1", q107);

                #endregion

                #region R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1

                var q108 = new DynamicData();
                q108.AddDynamic(new Dictionary<string, string>{
                { "SIVPF_NR_IDENTIFI" , "ID123456789" },
                { "SIVPF_NR_SICOB" , "SIC123456" },
                { "SIVPF_SIT_PROPOSTA" , "Aprovada" },
                { "SIVPF_DTQITBCO" , "2023-12-15" },
                { "SIVPF_VAL_PAGO" , "200.00" },
                { "SIVPF_DATA_CREDITO" , "2023-12-16" },
                { "SIVPF_OPCAO_COBER" , "Cobertura Total" },
                { "SIVPF_COD_PLANO" , "PLN123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1", q108);

                #endregion

                #region R7773_00_LER_RCAPS_DB_SELECT_1_Query1

                var q109 = new DynamicData();
                q109.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "FNT001" },
                { "RCAPS_NUM_RCAP" , "RC123456" },
                { "RCAPS_VAL_RCAP" , "1500.00" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7773_00_LER_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7773_00_LER_RCAPS_DB_SELECT_1_Query1", q109);

                #endregion

                #region R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1

                var q110 = new DynamicData();
                q110.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , "001" },
                { "RCAPCOMP_AGE_AVISO" , "0001" },
                { "RCAPCOMP_NUM_AVISO_CREDITO" , "987654321" },
                { "RCAPCOMP_DATA_MOVIMENTO" , "2023-12-15" },
                { "RCAPCOMP_DATA_RCAP" , "2023-12-20" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1", q110);

                #endregion

                #region R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1

                var q111 = new DynamicData();
                q111.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SIT_PROP_FIDELIZ" , "Fidelizado" },
                { "WHOST_SITUACAO_ENVIO" , "Enviado" },
                { "SIVPF_DATA_CREDITO" , "2023-12-16" },
                { "SIVPF_OPCAO_COBER" , "Cobertura Total" },
                { "SIVPF_DTQITBCO" , "2023-12-15" },
                { "SIVPF_VAL_PAGO" , "200.00" },
                { "SIVPF_NR_PROPOSTA" , "27708000280671" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1", q111);

                #endregion

                #region R7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1_Update1

                var q112 = new DynamicData();
                q112.AddDynamic(new Dictionary<string, string>{
                { "CONVER_NUM_SICOB" , "SIC123" },
                { "SIVPF_NR_PROPOSTA" , "27708000280671" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1_Update1", q112);

                #endregion

                #region M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1

                var q113 = new DynamicData();
                q113.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "PROPVA_NRCERTIF" , "98763456811007445554321" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1", q113);

                #endregion

                #region M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1

                var q114 = new DynamicData();
                q114.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "DIFPAR_CODOPER" , "DIF123" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
                { "COBERP_VLPREMIO" , "2" },
                { "V0HCOB_VLPRMTOT" , "800.00" },
                { "DIFPAR_PRMVG" , "2%" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1", q114);

                #endregion

                #region M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1

                var q115 = new DynamicData();
                q115.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1", q115);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute();
                var program = new VP0121B();
                program.Execute();

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();

                Assert.NotEmpty(inserts.Where(x => x.Key.Equals("M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1")).ToList());
                Assert.NotEmpty(inserts.Where(x => x.Key.Equals("M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1")).ToList());
                Assert.NotEmpty(inserts.Where(x => x.Key.Equals("M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1")).ToList());
                Assert.NotEmpty(inserts.Where(x => x.Key.Equals("M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1")).ToList());
                Assert.NotEmpty(inserts.Where(x => x.Key.Equals("R8000_PROPAUTOM_DB_INSERT_2_Insert1")).ToList());
                Assert.NotEmpty(inserts.Where(x => x.Key.Equals("M_8100_LOOP_DB_INSERT_1_Insert1")).ToList());
                Assert.NotEmpty(inserts.Where(x => x.Key.Equals("M_8320_INCLUI_SAF_DB_INSERT_1_Insert1")).ToList());
                Assert.NotEmpty(inserts.Where(x => x.Key.Equals("M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1")).ToList());
                Assert.NotEmpty(inserts.Where(x => x.Key.Equals("M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1")).ToList());

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void VP0121B_Tests_Update1_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                PROSOCU1_Tests.Load_Parameters();
                PROTIT01_Tests.Load_Parameters();
                FC0105B_Tests.Load_Parameters();
                FC0001S_Tests.Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , "2025-03-17" },
                { "SISTEMA_CURRDATE" , "2025-05-14" },
                { "SISTEMA_DTMOVABE2" , "2025-05-22" },
                { "SISTEMA_DTMOVABE3" , "2025-06-14" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_NUM_RAMO_PRSTMISTA" , "77" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q1);

                #endregion

                #region VP0121B_CPROPVA

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "109300000598" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_CODPRODU" , "7706" },
                { "PROPVA_CODCLIEN" , "456789" },
                { "PROPVA_OCOREND" , "12345" },
                { "PROPVA_FONTE" , "0" },
                { "PROPVA_AGECOBR" , "001" },
                { "PROPVA_OPCAO_COBER" , "A" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
                { "PROPVA_DTINICDG" , "2023-01-01" },
                { "PROPVA_DTINISAF" , "2023-01-01" },
                { "PROPVA_DTPROXVEN" , "2024-01-01" },
                { "PROPVA_DTMINVEN" , "2023-12-31" },
                { "PROPVA_NRMATRVEN" , "123456" },
                { "PROPVA_CODOPER" , "OP123" },
                { "PROPVA_DTMOVTO" , "2023-12-01" },
                { "PROPVA_SITUACAO" , "7" },
                { "PROPVA_NUM_APOLICE1" , "109300000598" },
                { "PROPVA_CODSUBES1" , "002" },
                { "PROPVA_OCORHIST" , "Ocorrencia Teste" },
                { "PROPVA_NRPARCEL" , "12" },
                { "PROPVA_SIT_INTERF" , "Ativa" },
                { "PROPVA_TIMESTAMP" , "2023-12-01T12:00:00" },
                { "PROPVA_IDADE" , "35" },
                { "PROPVA_SEXO" , "M" },
                { "PROPVA_EST_CIV" , "Casado" },
                { "PROPVA_COD_CRM" , "CRM123" },
                { "PROPVA_NRMATRFUN" , "654321" },
                { "PROPVA_DTADMIS" , "2020-01-01" },
                { "PROPVA_NRPROPOS" , "27708000280671" },
                { "PROPVA_CODCCT" , "CCT001" },
                { "PROPVA_CODUSU" , "USU123" },
                { "PROPVA_DTVENCTO" , "2024-01-01" },
                { "PROPVA_FAIXA_RENDA_IND" , "Alta" },
                { "PROPVA_DATA" , "2023-12-01" },
                { "PROPVA_DPS_TITULAR" , "" },
                { "PROPVA_ORIGEM_PROPOSTA" , "999" },
                { "PROPVA_ACATAMENTO" , "N" },
                { "PROPVA_COD_OPER_CREDITO" , "CRED123" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0121B_CPROPVA");
                AppSettings.TestSet.DynamicData.Add("VP0121B_CPROPVA", q2);

                #endregion

                #region VP0121B_V1RCAPCOMP

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , "Fonte1" },
                { "V1RCAC_NRRCAP" , "321" },
                { "V1RCAC_NRRCAPCO" , "321CO" },
                { "V1RCAC_OPERACAO" , "Oper123" },
                { "V1RCAC_DTMOVTO" , "2023-12-01" },
                { "V1RCAC_HORAOPER" , "12:00" },
                { "V1RCAC_SITUACAO" , "Ativa" },
                { "V1RCAC_BCOAVISO" , "001" },
                { "V1RCAC_AGEAVISO" , "002" },
                { "V1RCAC_NRAVISO" , "003" },
                { "V1RCAC_VLRCAP" , "1000.00" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
                { "V1RCAC_DTCADAST" , "2023-12-01" },
                { "V1RCAC_SITCONTB" , "Confirmada" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0121B_V1RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("VP0121B_V1RCAPCOMP", q3);

                #endregion

                #region M_0000_PRINCIPAL_DB_UPDATE_1_Update1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NRTIT" , "85172719932" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_UPDATE_1_Update1", q4);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_3_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SUBGRU_CODSUBES" , "0" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_3_Query1", q5);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_4_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NRTIT" , "85172719932" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_4_Query1", q6);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "PRODVG_CODPRODAZ" , "P123" },
                { "PRODVG_PERIPGTO" , "Mensal" },
                { "PRODVG_ESTR_COBR" , "Estruturada" },
                { "PRODVG_ORIG_PRODU" , "MULT" },
                { "PRODVG_AGENCIADOR" , "Agente123" },
                { "PRODVG_TEM_SAF" , "Sim" },
                { "PRODVG_TEM_CDG" , "Não" },
                { "PRODVG_CODRELAT" , "R123" },
                { "PRODVG_COBERADIC_PREMIO" , "100.00" },
                { "PRODVG_CUSTOCAP_TOTAL" , "200.00" },
                { "PRODVG_DESCONTO_ADESAO" , "10.00" },
                { "PRODVG_COD_PRODUTO" , "7706" },
                { "PRODVG_RISCO" , "Baixo" },
                { "PRODVG_SITPLANCEF" , "Ativo" },
                { "PRODVG_ARQ_FDCAP" , "Arquivo123" },
                { "PRODVG_COD_RUBRICA" , "RUB001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1", q7);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_OPCAOPAG" , "1" },
                { "OPCAOP_PERIPGTO" , "4" },
                { "OPCAOP_DIA_DEB" , "0" },
                { "OPCAOP_AGECTADEB" , "0" },
                { "OPCAOP_OPRCTADEB" , "OPR001" },
                { "OPCAOP_NUMCTADEB" , "123456" },
                { "OPCAOP_DIGCTADEB" , "7" },
                { "OPCAOP_CARTAOCRED" , "4111111111111111" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_1_Query1", q8);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_PERIPGTO" , "4" },
                { "OPCAOP_OPCAOPAG" , "1" },
                { "OPCAOP_DIA_DEB" , "0" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1", q9);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "WTEM_ERRO_7705" , "Erro7705" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1", q10);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_2_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V0AGCEF_COD_AGCOBR" , "AG001" }
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_2_Query1", q11);

                #endregion

                #region M_0100_NEXT_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_NEXT_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0100_NEXT_DB_UPDATE_1_Update1", q12);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_3_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V0COBER_MINOCOR" , "MinOcor001" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_3_Query1", q13);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "WTEM_ERRO_7715" , "Erro7715" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1", q14);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_4_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "COBERP_DTINIVIG" , "2023-01-01" },
                { "COBERP_DTTERVIG" , "2024-01-01" },
                { "COBERP_IMPMORNATU" , "0" },
                { "COBERP_IMPMORACID" , "100.00" },
                { "COBERP_IMPINVPERM" , "150.00" },
                { "COBERP_IMPAMDS" , "200.00" },
                { "COBERP_IMPDH" , "250.00" },
                { "COBERP_IMPDIT" , "300.00" },
                { "COBERP_VLPREMIO" , "2" },
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "COBERP_IMPSEGCDG" , "500.00" },
                { "COBERP_VLCUSTCDG" , "550.00" },
                { "COBERP_VLCUSTCAP" , "600.00" },
                { "COBERP_IMPSEGAUXF" , "650.00" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "COBERP_QTTITCAP" , "750" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_4_Query1", q15);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_5_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "COBERP_DTINIVIG" , "2023-01-01" },
                { "COBERP_IMPMORNATU" , "0" },
                { "COBERP_IMPMORACID" , "100.00" },
                { "COBERP_IMPINVPERM" , "150.00" },
                { "COBERP_IMPAMDS" , "200.00" },
                { "COBERP_IMPDH" , "250.00" },
                { "COBERP_IMPDIT" , "300.00" },
                { "COBERP_VLPREMIO" , "2" },
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "COBERP_IMPSEGCDG" , "500.00" },
                { "COBERP_VLCUSTCDG" , "550.00" },
                { "COBERP_VLCUSTCAP" , "600.00" },
                { "COBERP_IMPSEGAUXF" , "650.00" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "COBERP_QTTITCAP" , "750" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_5_Query1", q16);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , "1988-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1", q17);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_6_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , "800.00" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_6_Query1", q18);

                #endregion

                #region M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "ERRPROVI_COD_ERRO" , "1002" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1", q19);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_DTPROXVEN" , "2024-01-01" },
                { "PROPVA_CODPRODU" , "7706" },
                { "PROPVA_SITUACAO" , "7" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_CODOPER" , "OP123" },
                { "MDTMOVTO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1", q20);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_7_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , "800.00" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_7_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_7_Query1", q21);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRPROPOS" , "27708000280671" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1", q22);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_8_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , "109300000598" },
                { "RELATO_CODSUBES" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_8_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_8_Query1", q23);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_9_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , "109300000598" },
                { "RELATO_CODSUBES" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_9_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_9_Query1", q24);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRCERTIF" , "987654321" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1", q25);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_10_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , "109300000598" },
                { "RELATO_CODSUBES" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_10_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_10_Query1", q26);

                #endregion

                #region M_0110_FETCH_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA_MOVIMENTO" , "2023-12-01" }
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("M_0110_FETCH_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_DB_SELECT_1_Query1", q27);

                #endregion

                #region M_0110_FETCH_DB_UPDATE_1_Update1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0110_FETCH_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_DB_UPDATE_1_Update1", q28);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_11_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , "109300000598" },
                { "RELATO_CODSUBES" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_11_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_11_Query1", q29);

                #endregion

                #region M_0110_FETCH_DB_SELECT_2_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_RAMO" , "77" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0110_FETCH_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_DB_SELECT_2_Query1", q30);

                #endregion

                #region M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-12-01" },
                { "WHOST_PROXIMA_DATA" , "2023-12-02" },
                { "CALENDAR_DIA_SEMANA" , "Q" },
                { "CALENDAR_FERIADO" , "Não" },
            });

                q31.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-12-02" },
                { "WHOST_PROXIMA_DATA" , "2023-12-03" },
                { "CALENDAR_DIA_SEMANA" , "Q" },
                { "CALENDAR_FERIADO" , "Não" },
            });

                q31.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-12-03" },
                { "WHOST_PROXIMA_DATA" , "2023-12-04" },
                { "CALENDAR_DIA_SEMANA" , "Q" },
                { "CALENDAR_FERIADO" , "Não" },
            });
                q31.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-12-04" },
                { "WHOST_PROXIMA_DATA" , "2023-12-05" },
                { "CALENDAR_DIA_SEMANA" , "Q" },
                { "CALENDAR_FERIADO" , "Não" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1", q31);

                #endregion

                #region M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                { "RELATO_CODRELAT" , "R123" },
                { "PROPVA_NUM_APOLICE" , "109300000598" },
                { "RELATO_NRPARCEL" , "12" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_CODSUBES" , "001" },
                { "RELATO_OPERACAO" , "Oper123" },
                { "WS_SIT_REGISTRO" , "Ativo" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1", q32);

                #endregion

                #region M_0300_VERIFICA_CROT_DB_SELECT_1_Query1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_CGCCPF" , "12345678901" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0300_VERIFICA_CROT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0300_VERIFICA_CROT_DB_SELECT_1_Query1", q33);

                #endregion

                #region M_0300_VERIFICA_CROT_DB_SELECT_2_Query1

                var q34 = new DynamicData();
                q34.AddDynamic(new Dictionary<string, string>{
                { "CLIROT_DTMOVABE" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0300_VERIFICA_CROT_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0300_VERIFICA_CROT_DB_SELECT_2_Query1", q34);

                #endregion

                #region M_0320_UPDATE_CROT_DB_UPDATE_1_Update1

                var q35 = new DynamicData();
                q35.AddDynamic(new Dictionary<string, string>{
                { "CLIROT_DTMOVABE" , "2023-12-01" },
                { "CLIENT_CGCCPF" , "12345678901" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0320_UPDATE_CROT_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0320_UPDATE_CROT_DB_UPDATE_1_Update1", q35);

                #endregion

                #region M_0330_INCLUI_CROT_DB_INSERT_1_Insert1

                var q36 = new DynamicData();
                q36.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_CGCCPF" , "12345678901" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0330_INCLUI_CROT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0330_INCLUI_CROT_DB_INSERT_1_Insert1", q36);

                #endregion

                #region R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1

                var q37 = new DynamicData();
                q37.AddDynamic(new Dictionary<string, string>{
                { "V0FOLHM_DTEMICAR" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1", q37);

                #endregion

                #region R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1

                var q38 = new DynamicData();
                q38.AddDynamic(new Dictionary<string, string>{
                { "V0FOLH_COD_CARTA" , "C123" },
                { "V0FOLH_DTEMICAR" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1", q38);

                #endregion

                #region M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1

                var q39 = new DynamicData();
                q39.AddDynamic(new Dictionary<string, string>{
                { "V0FOLH_COD_PRODUTO" , "7705" },
                { "V0FOLH_NRCERTIF" , "987654321" },
                { "V0FOLH_COD_CARTA" , "C123" },
                { "V0FOLH_DTEMICAR" , "2023-12-01" },
                { "V0FOLH_DTSOLICIT" , "2023-12-01" },
                { "V0FOLH_CODUSU" , "USU123" },
                { "V0FOLH_SITUACAO" , "Ativa" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1", q39);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1

                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                { "CONVER_NUM_SICOB" , "SIC123" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1", q40);

                #endregion

                #region FINALIZA_1110_FIM_DB_UPDATE_1_Update1

                var q41 = new DynamicData();
                q41.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "CONVER_NUM_PROPOSTA" , "27708000280671" },
            });
                AppSettings.TestSet.DynamicData.Remove("FINALIZA_1110_FIM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("FINALIZA_1110_FIM_DB_UPDATE_1_Update1", q41);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1

                var q42 = new DynamicData();
                q42.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "Fonte1" },
                { "V0RCAP_NRRCAP" , "321" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1", q42);

                #endregion

                #region FINALIZA_1110_FIM_DB_UPDATE_2_Update1

                var q43 = new DynamicData();
                q43.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "V0RCAP_NRRCAP" , "321" },
                { "V0RCAP_FONTE" , "Fonte1" },
            });
                AppSettings.TestSet.DynamicData.Remove("FINALIZA_1110_FIM_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("FINALIZA_1110_FIM_DB_UPDATE_2_Update1", q43);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1

                var q44 = new DynamicData();
                q44.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "109300000598" },
                { "V0RCAP_NRRCAP" , "321" },
                { "V0RCAP_FONTE" , "Fonte1" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1", q44);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1

                var q45 = new DynamicData();
                q45.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "001" },
                { "V1RCAC_AGEAVISO" , "002" },
                { "V1RCAC_NRAVISO" , "003" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1", q45);

                #endregion

                #region VP0121B_CBENEFP

                var q46 = new DynamicData();
                q46.AddDynamic(new Dictionary<string, string>{
                { "BENEF_NOMBENEF" , "Nome Beneficiário" },
                { "BENEF_GRAUPAR" , "Grau Parentesco" },
                { "BENEF_PCTBENEF" , "50%" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0121B_CBENEFP");
                AppSettings.TestSet.DynamicData.Add("VP0121B_CBENEFP", q46);

                #endregion

                #region M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1

                var q47 = new DynamicData();
                q47.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_NRRCAPCO" , "321CO" },
                { "V1RCAC_OPERACAO" , "Oper123" },
                { "V1RCAC_HORAOPER" , "12:00" },
                { "V1RCAC_DTMOVTO" , "2023-12-01" },
                { "V1RCAC_NRRCAP" , "321" },
                { "V1RCAC_FONTE" , "Fonte1" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1", q47);

                #endregion

                #region M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1

                var q48 = new DynamicData();
                q48.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , "Fonte1" },
                { "V1RCAC_NRRCAP" , "321" },
                { "V1RCAC_NRRCAPCO" , "321CO" },
                { "V1RCAC_OPERACAO" , "Oper123" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
                { "V1RCAC_SITUACAO" , "Ativa" },
                { "V1RCAC_BCOAVISO" , "001" },
                { "V1RCAC_AGEAVISO" , "002" },
                { "V1RCAC_NRAVISO" , "003" },
                { "V1RCAC_VLRCAP" , "1000.00" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
                { "V1RCAC_DTCADAST" , "2023-12-01" },
                { "V1RCAC_SITCONTB" , "Confirmada" },
                { "V1RCAC_COD_EMPRESA" , "EMP123" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1", q48);

                #endregion

                #region M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1

                var q49 = new DynamicData();
                q49.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_VLRCAP" , "1000.00" },
                { "V1RCAC_BCOAVISO" , "001" },
                { "V1RCAC_AGEAVISO" , "002" },
                { "V1RCAC_NRAVISO" , "003" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1", q49);

                #endregion

                #region M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1

                var q50 = new DynamicData();
                q50.AddDynamic(new Dictionary<string, string>{
                { "PRODVG_CODPRODAZ" , "P123" },
                { "PRODVG_ESTR_COBR" , "Estruturada" },
                { "PRODVG_ORIG_PRODU" , "MULT" },
                { "PRODVG_AGENCIADOR" , "Agente123" },
                { "PRODVG_TEM_SAF" , "Sim" },
                { "PRODVG_TEM_CDG" , "Não" },
                { "PRODVG_CODRELAT" , "R123" },
                { "PRODVG_COBERADIC_PREMIO" , "100.00" },
                { "PRODVG_CUSTOCAP_TOTAL" , "200.00" },
                { "PRODVG_DESCONTO_ADESAO" , "10.00" },
                { "PRODVG_COD_PRODUTO" , "7706" },
                { "PRODVG_RISCO" , "Baixo" },
                { "PRODVG_SITPLANCEF" , "Ativo" },
                { "PRODVG_ARQ_FDCAP" , "Arquivo123" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1", q50);

                #endregion

                #region M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1

                var q51 = new DynamicData();
                q51.AddDynamic(new Dictionary<string, string>{
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1", q51);

                #endregion

                #region M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1

                var q52 = new DynamicData();
                q52.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODSUBES" , "001" },
                { "MTXAPMA" , "Matriz AP MA" },
                { "MTXAPIP" , "Matriz AP IP" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1", q52);

                #endregion

                #region M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1

                var q53 = new DynamicData();
                q53.AddDynamic(new Dictionary<string, string>{
                { "APCORR_RAMO" , "Vida" },
                { "PROPVA_CODSUBES" , "001" },
                { "APCORR_DTINIVIG" , "2023-01-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1", q53);

                #endregion

                #region M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1

                var q54 = new DynamicData();
                q54.AddDynamic(new Dictionary<string, string>{
                { "COMISSOE_NUM_APOLICE" , "109300000598" },
                { "COMISSOE_NUM_ENDOSSO" , "E123" },
                { "COMISSOE_NUM_CERTIFICADO" , "7457254811" },
                { "COMISSOE_DAC_CERTIFICADO" , "DAC123" },
                { "COMISSOE_TIPO_SEGURADO" , "Titular" },
                { "COMISSOE_NUM_PARCELA" , "12" },
                { "COMISSOE_COD_OPERACAO" , "OP123" },
                { "COMISSOE_COD_PRODUTOR" , "Prod123" },
                { "COMISSOE_RAMO_COBERTURA" , "Vida" },
                { "COMISSOE_MODALI_COBERTURA" , "Modalidade1" },
                { "COMISSOE_OCORR_HISTORICO" , "Histórico Ocorrência" },
                { "COMISSOE_COD_FONTE" , "Fonte1" },
                { "COMISSOE_COD_CLIENTE" , "456789" },
                { "COMISSOE_VAL_COMISSAO" , "100.00" },
                { "COMISSOE_DATA_CALCULO" , "2023-12-01" },
                { "COMISSOE_NUM_RECIBO" , "R123456" },
                { "COMISSOE_VAL_BASICO" , "200.00" },
                { "COMISSOE_TIPO_COMISSAO" , "Tipo1" },
                { "COMISSOE_QTD_PARCELAS" , "12" },
                { "COMISSOE_PCT_COM_CORRETOR" , "10%" },
                { "COMISSOE_PCT_DESC_PREMIO" , "5%" },
                { "COMISSOE_COD_SUBGRUPO" , "SG001" },
                { "COMISSOE_DATA_MOVIMENTO" , "2023-12-01" },
                { "COMISSOE_DATA_SELECAO" , "2023-12-01" },
                { "COMISSOE_COD_EMPRESA" , "EMP123" },
                { "COMISSOE_COD_PREPOSTO" , "Prep123" },
                { "COMISSOE_NUM_BILHETE" , "B123456" },
                { "COMISSOE_VAL_VARMON" , "300.00" },
                { "COMISSOE_DATA_QUITACAO" , "2024-01-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1", q54);

                #endregion

                #region M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1

                var q55 = new DynamicData();
                q55.AddDynamic(new Dictionary<string, string>{
                { "PROD_COD_EMPRESA" , "EMP123" },
                { "PARM_COD_EMPR_CAP" , "EMP123" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1", q55);

                #endregion

                #region R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1

                var q56 = new DynamicData();
                q56.AddDynamic(new Dictionary<string, string>{
                { "COMFEDCA_SITUACAO" , "Ativa" }
            });
                AppSettings.TestSet.DynamicData.Remove("R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1", q56);

                #endregion

                #region R6290_10_INSERT_DB_INSERT_1_Insert1

                var q57 = new DynamicData();
                q57.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_FONTE" , "CEF" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
                { "MOVFEDCA_VAL_CUSTO_CAPITALI" , "100.00" },
                { "MOVFEDCA_NRTITFDCAP" , "123456" },
                { "PRODVG_COD_PRODUTO" , "7706" },
            });
                AppSettings.TestSet.DynamicData.Remove("R6290_10_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R6290_10_INSERT_DB_INSERT_1_Insert1", q57);

                #endregion

                #region R6300_00_INSERT_DB_INSERT_1_Insert1

                var q58 = new DynamicData();
                q58.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_NRTITFDCAP" , "123456" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "TITFEDCA_DATA_INIVIGENCIA" , "2023-01-01" },
                { "TITFEDCA_DATA_TERVIGENCIA" , "2024-01-01" },
                { "TITFEDCA_NRSORTEIO" , "S123456" },
                { "TITFEDCA_VAL_CUSTO_TITULO" , "150.00" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R6300_00_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R6300_00_INSERT_DB_INSERT_1_Insert1", q58);

                #endregion

                #region R6400_10_INSERT_DB_INSERT_1_Insert1

                var q59 = new DynamicData();
                q59.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R6400_10_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R6400_10_INSERT_DB_INSERT_1_Insert1", q59);

                #endregion

                #region R6500_10_INSERT_DB_INSERT_1_Insert1

                var q60 = new DynamicData();
                q60.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_NRTITFDCAP" , "123456" },
                { "PARFEDCA_VAL_CUSTO_TITULO" , "150.00" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R6500_10_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R6500_10_INSERT_DB_INSERT_1_Insert1", q60);

                #endregion

                #region R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1

                var q61 = new DynamicData();
                q61.AddDynamic(new Dictionary<string, string>{
                { "COMFEDCA_SITUACAO" , "Ativa" }
            });
                AppSettings.TestSet.DynamicData.Remove("R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1", q61);

                #endregion

                #region R7400_10_INSERT_DB_INSERT_1_Insert1

                var q62 = new DynamicData();
                q62.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7400_10_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R7400_10_INSERT_DB_INSERT_1_Insert1", q62);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_1_Query1

                var q63 = new DynamicData();
                q63.AddDynamic(new Dictionary<string, string>{
                { "CONDTE_IEA" , "Inclusão" },
                { "CONDTE_IPA" , "Proposta" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_1_Query1", q63);

                #endregion

                #region R8000_PROPAUTOM_DB_INSERT_1_Insert1

                var q64 = new DynamicData();
                q64.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "109300000598" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_FONTE" , "0" },
                { "FONTE_PROPAUTOM" , "Automática" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "MTPINCLUS" , "Inclusão Manual" },
                { "PROPVA_CODCLIEN" , "456789" },
                { "MAGENCIADOR" , "Agente123" },
                { "MMFAIXA" , "Faixa1" },
                { "MTPBENEF" , "Tipo Benefício" },
                { "OPCAOP_PERIPGTO" , "4" },
                { "PROPVA_EST_CIV" , "Casado" },
                { "PROPVA_SEXO" , "M" },
                { "MAGECOBR" , "Agência Cobrança" },
                { "MMNUM_MATRICULA" , "Mat123" },
                { "MNUM_CTA_CORRENTE" , "Conta123" },
                { "MDAC_CTA_CORRENTE" , "DAC123" },
                { "MTXAPMA" , "Matriz AP MA" },
                { "MTXAPIP" , "Matriz AP IP" },
                { "MTXVG" , "Matriz VG" },
                { "COBERP_IMPMORNATU" , "0" },
                { "COBERP_IMPMORACID" , "100.00" },
                { "COBERP_IMPINVPERM" , "150.00" },
                { "COBERP_IMPAMDS" , "200.00" },
                { "COBERP_IMPDH" , "250.00" },
                { "COBERP_IMPDIT" , "300.00" },
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "MCODOPER" , "OP123" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
                { "PROPVA_CODUSU" , "USU123" },
                { "WSISTEMA_DTMOVABE" , "2023-12-01" },
                { "CLIENT_DTNASC" , "1988-01-01" },
                { "MDTREF" , "2023-12-01" },
                { "MMDTMOVTO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_INSERT_1_Insert1", q64);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_2_Query1

                var q65 = new DynamicData();
                q65.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , "1988-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_2_Query1", q65);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_1_Update1

                var q66 = new DynamicData();
                q66.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , "Automática" },
                { "PROPVA_FONTE" , "0" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_1_Update1", q66);

                #endregion

                #region R8000_PROPAUTOM_DB_INSERT_2_Insert1

                var q67 = new DynamicData();
                q67.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "109300000598" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_FONTE" , "0" },
                { "FONTE_PROPAUTOM" , "Automática" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "MTPINCLUS" , "Inclusão Manual" },
                { "PROPVA_CODCLIEN" , "456789" },
                { "MAGENCIADOR" , "Agente123" },
                { "MMFAIXA" , "Faixa1" },
                { "MTPBENEF" , "Tipo Benefício" },
                { "OPCAOP_PERIPGTO" , "4" },
                { "PROPVA_EST_CIV" , "Casado" },
                { "PROPVA_SEXO" , "M" },
                { "MAGECOBR" , "Agência Cobrança" },
                { "MMNUM_MATRICULA" , "Mat123" },
                { "MNUM_CTA_CORRENTE" , "Conta123" },
                { "MDAC_CTA_CORRENTE" , "DAC123" },
                { "MTXAPMA" , "Matriz AP MA" },
                { "MTXAPIP" , "Matriz AP IP" },
                { "MTXVG" , "Matriz VG" },
                { "COBERP_IMPMORNATU" , "0" },
                { "COBERP_IMPMORACID" , "100.00" },
                { "COBERP_IMPINVPERM" , "150.00" },
                { "COBERP_IMPAMDS" , "200.00" },
                { "COBERP_IMPDH" , "250.00" },
                { "COBERP_IMPDIT" , "300.00" },
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "MCODOPER" , "OP123" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
                { "PROPVA_CODUSU" , "USU123" },
                { "WSISTEMA_DTMOVABE" , "2023-12-01" },
                { "PROPVA_DTADMIS" , "2020-01-01" },
                { "CLIENT_DTNASC" , "1988-01-01" },
                { "MDTREF" , "2023-12-01" },
                { "MMDTMOVTO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_INSERT_2_Insert1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_INSERT_2_Insert1", q67);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_2_Update1

                var q68 = new DynamicData();
                q68.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_2_Update1", q68);

                #endregion

                #region R8000_PROPAUTOM_DB_SELECT_1_Query1

                var q69 = new DynamicData();
                q69.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , "800.00" }
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_SELECT_1_Query1", q69);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_3_Update1

                var q70 = new DynamicData();
                q70.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_3_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_3_Update1", q70);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_3_Query1

                var q71 = new DynamicData();
                q71.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , "25-35" },
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_3_Query1", q71);

                #endregion

                #region R8000_PROPAUTOM_DB_SELECT_2_Query1

                var q72 = new DynamicData();
                q72.AddDynamic(new Dictionary<string, string>{
                { "COMISI_VALADT" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_SELECT_2_Query1", q72);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_4_Update1

                var q73 = new DynamicData();
                q73.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_4_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_4_Update1", q73);

                #endregion

                #region M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1

                var q74 = new DynamicData();
                q74.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , "25-35" },
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1", q74);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_5_Update1

                var q75 = new DynamicData();
                q75.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_5_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_5_Update1", q75);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_4_Query1

                var q76 = new DynamicData();
                q76.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , "25-35" },
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_4_Query1", q76);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_5_Query1

                var q77 = new DynamicData();
                q77.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , "25-35" },
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_5_Query1", q77);

                #endregion

                #region M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1

                var q78 = new DynamicData();
                q78.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "3" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1", q78);

                #endregion

                #region VP0121B_C01_RCAPCOMP

                var q79 = new DynamicData();
                q79.AddDynamic(new Dictionary<string, string>{
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_BCO_AVISO" , "237" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_AGE_AVISO" , "1234" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_NUM_AVISO_CREDITO" , "987654321" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_MOVIMENTO" , "2023-12-15" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_RCAP" , "2023-12-20" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_COD_OPERACAO" , "OP123" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0121B_C01_RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("VP0121B_C01_RCAPCOMP", q79);

                #endregion

                #region M_8100_LOOP_DB_INSERT_1_Insert1

                var q80 = new DynamicData();
                q80.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "109300000598" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_FONTE" , "0" },
                { "FONTE_PROPAUTOM" , "Automática" },
                { "BENEF_NRBENEF" , "BN1234567" },
                { "BENEF_NOMBENEF" , "Nome Beneficiário" },
                { "BENEF_GRAUPAR" , "Grau Parentesco" },
                { "BENEF_PCTBENEF" , "50%" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8100_LOOP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8100_LOOP_DB_INSERT_1_Insert1", q80);

                #endregion

                #region M_8200_CONCEDE_CDG_DB_SELECT_1_Query1

                var q81 = new DynamicData();
                q81.AddDynamic(new Dictionary<string, string>{
                { "CDGCOB_DTINIVIG" , "2023-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8200_CONCEDE_CDG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8200_CONCEDE_CDG_DB_SELECT_1_Query1", q81);

                #endregion

                #region M_8200_CONCEDE_CDG_DB_SELECT_2_Query1

                var q82 = new DynamicData();
                q82.AddDynamic(new Dictionary<string, string>{
                { "REPCDG_DTREF" , "2023-01-31" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8200_CONCEDE_CDG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8200_CONCEDE_CDG_DB_SELECT_2_Query1", q82);

                #endregion

                #region M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1

                var q83 = new DynamicData();
                q83.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1", q83);

                #endregion

                #region M_8220_INCLUI_CDG_DB_INSERT_1_Insert1

                var q84 = new DynamicData();
                q84.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "PROPVA_DTINICDG" , "2023-01-01" },
                { "COBERP_IMPSEGCDG" , "500.00" },
                { "COBERP_VLCUSTCDG" , "550.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_OCORHIST" , "Ocorrencia Teste" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8220_INCLUI_CDG_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8220_INCLUI_CDG_DB_INSERT_1_Insert1", q84);

                #endregion

                #region M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1

                var q85 = new DynamicData();
                q85.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "REPCDG_DTREF" , "2023-01-31" },
                { "COBERP_VLCUSTCDG" , "550.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1", q85);

                #endregion

                #region M_8300_CONCEDE_SAF_DB_SELECT_1_Query1

                var q86 = new DynamicData();
                q86.AddDynamic(new Dictionary<string, string>{
                { "SAFCOB_DTINIVIG" , "2023-02-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8300_CONCEDE_SAF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8300_CONCEDE_SAF_DB_SELECT_1_Query1", q86);

                #endregion

                #region M_8300_CONCEDE_SAF_DB_SELECT_2_Query1

                var q87 = new DynamicData();
                q87.AddDynamic(new Dictionary<string, string>{
                { "REPSAF_DTREF" , "2025-02-28" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8300_CONCEDE_SAF_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8300_CONCEDE_SAF_DB_SELECT_2_Query1", q87);

                #endregion

                #region M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1

                var q88 = new DynamicData();
                q88.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1", q88);

                #endregion

                #region M_8320_INCLUI_SAF_DB_INSERT_1_Insert1

                var q89 = new DynamicData();
                q89.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "PROPVA_DTINISAF" , "2023-01-01" },
                { "COBERP_IMPSEGAUXF" , "650.00" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_OCORHIST" , "Ocorrencia Teste" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8320_INCLUI_SAF_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8320_INCLUI_SAF_DB_INSERT_1_Insert1", q89);

                #endregion

                #region M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1

                var q90 = new DynamicData();
                q90.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "REPSAF_DTREF" , "2023-02-28" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_NRMATRFUN" , "654321" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "PROPVA_CODOPER" , "OP123" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1", q90);

                #endregion

                #region M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1

                var q91 = new DynamicData();
                q91.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "REPSAF_DTREF" , "2023-02-28" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_NRMATRFUN" , "654321" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1", q91);

                #endregion

                #region M_8400_00_DEBITO_CARTAO_DB_INSERT_1_Insert1

                var q92 = new DynamicData();
                q92.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_EMPRESA" , "EMP001" },
                { "MOVDEBCE_NUM_APOLICE" , "APL123456" },
                { "MOVDEBCE_NUM_ENDOSSO" , "END123456" },
                { "MOVDEBCE_NUM_PARCELA" , "PAR123456" },
                { "MOVDEBCE_SITUACAO_COBRANCA" , "Pendente" },
                { "MOVDEBCE_DATA_VENCIMENTO" , "2023-12-31" },
                { "MOVDEBCE_VALOR_DEBITO" , "500.00" },
                { "MOVDEBCE_DATA_MOVIMENTO" , "2023-12-01" },
                { "MOVDEBCE_DIA_DEBITO" , "15" },
                { "MOVDEBCE_COD_AGENCIA_DEB" , "0001" },
                { "MOVDEBCE_OPER_CONTA_DEB" , "013" },
                { "MOVDEBCE_NUM_CONTA_DEB" , "12345678" },
                { "MOVDEBCE_DIG_CONTA_DEB" , "9" },
                { "MOVDEBCE_COD_CONVENIO" , "CONV001" },
                { "MOVDEBCE_DATA_ENVIO" , "2023-12-02" },
                { "MOVDEBCE_DATA_RETORNO" , "2023-12-03" },
                { "MOVDEBCE_COD_RETORNO_CEF" , "RET001" },
                { "MOVDEBCE_NSAS" , "NS123456" },
                { "MOVDEBCE_COD_USUARIO" , "USR001" },
                { "MOVDEBCE_NUM_REQUISICAO" , "REQ123456" },
                { "MOVDEBCE_NUM_CARTAO" , "CARD1234567890" },
                { "MOVDEBCE_SEQUENCIA" , "SEQ123" },
                { "MOVDEBCE_NUM_LOTE" , "LOT123" },
                { "MOVDEBCE_DTCREDITO" , "2023-12-05" },
                { "MOVDEBCE_STATUS_CARTAO" , "Ativo" },
                { "MOVDEBCE_VLR_CREDITO" , "1000.00" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8400_00_DEBITO_CARTAO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8400_00_DEBITO_CARTAO_DB_INSERT_1_Insert1", q92);

                #endregion

                #region M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1

                var q93 = new DynamicData();
                q93.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , "Automática" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1", q93);

                #endregion

                #region M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1

                var q94 = new DynamicData();
                q94.AddDynamic(new Dictionary<string, string>{
                { "W03_VENCIMENTO" , "2023-12-10" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1", q94);

                #endregion

                #region M_8600_10_CONTINUA_DB_SELECT_1_Query1

                var q95 = new DynamicData();
                q95.AddDynamic(new Dictionary<string, string>{
                { "DESCON_PERC" , "10%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_10_CONTINUA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_SELECT_1_Query1", q95);

                #endregion

                #region M_8600_10_CONTINUA_DB_INSERT_1_Insert1

                var q96 = new DynamicData();
                q96.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "HISTCB_DTVENCTO" , "2023-12-20" },
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "OPCAOP_OPCAOPAG" , "1" },
                { "PARCEL_OCORHIST" , "Ocorrência 1" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_10_CONTINUA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_INSERT_1_Insert1", q96);

                #endregion

                #region M_8600_CONTINUA_DB_UPDATE_1_Update1

                var q97 = new DynamicData();
                q97.AddDynamic(new Dictionary<string, string>{
                { "HISTCB_DTVENCTO" , "2023-12-20" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_CONTINUA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_8600_CONTINUA_DB_UPDATE_1_Update1", q97);

                #endregion

                #region M_8600_10_CONTINUA_DB_INSERT_2_Insert1

                var q98 = new DynamicData();
                q98.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "BANCOS_NRTIT" , "85172719932" },
                { "HISTCB_DTVENCTO" , "2023-12-20" },
                { "DESCON_VLPREMIO" , "50.00" },
                { "OPCAOP_OPCAOPAG" , "1" },
                { "HISTCB_SITUACAO" , "Ativa" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_10_CONTINUA_DB_INSERT_2_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_INSERT_2_Insert1", q98);

                #endregion

                #region M_8600_CONTINUA_DB_UPDATE_2_Update1

                var q99 = new DynamicData();
                q99.AddDynamic(new Dictionary<string, string>{
                { "WS_PROPVA_DTPROXVEN" , "2024-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_CONTINUA_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("M_8600_CONTINUA_DB_UPDATE_2_Update1", q99);

                #endregion

                #region M_8600_10_CONTINUA_DB_INSERT_3_Insert1

                var q100 = new DynamicData();
                q100.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "HISTCB_DTVENCTO" , "2023-12-20" },
                { "DESCON_PRMVG" , "5%" },
                { "DESCON_PRMAP" , "3%" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_10_CONTINUA_DB_INSERT_3_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_INSERT_3_Insert1", q100);

                #endregion

                #region M_8700_GERA_DEBITO_DB_SELECT_1_Query1

                var q101 = new DynamicData();
                q101.AddDynamic(new Dictionary<string, string>{
                { "CONVEN_CODCONV" , "C123" },
                { "CONVEN_CARTAO" , "1234567890123456" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8700_GERA_DEBITO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8700_GERA_DEBITO_DB_SELECT_1_Query1", q101);

                #endregion

                #region M_8700_GERA_DEBITO_DB_INSERT_1_Insert1

                var q102 = new DynamicData();
                q102.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "OPCAOP_AGECTADEB" , "0" },
                { "OPCAOP_OPRCTADEB" , "OPR001" },
                { "OPCAOP_NUMCTADEB" , "123456" },
                { "OPCAOP_DIGCTADEB" , "7" },
                { "HISTCB_DTVENCTO" , "2023-12-20" },
                { "DESCON_VLPREMIO" , "50.00" },
                { "HOST_CODCONV" , "H123" },
                { "OPCAOP_CARTAOCRED" , "4111111111111111" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8700_GERA_DEBITO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8700_GERA_DEBITO_DB_INSERT_1_Insert1", q102);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1

                var q103 = new DynamicData();
                q103.AddDynamic(new Dictionary<string, string>{
                { "FUNDO_PCCOMIND" , "1%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1", q103);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1

                var q104 = new DynamicData();
                q104.AddDynamic(new Dictionary<string, string>{
                { "FUNDO_PCCOMGER" , "1%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1", q104);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1

                var q105 = new DynamicData();
                q105.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODPRODU" , "7706" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_FONTE" , "0" },
                { "PROPVA_AGECOBR" , "001" },
                { "PROPVA_CODCLIEN" , "456789" },
                { "PROPVA_NRMATRVEN" , "123456" },
                { "FUNDO_VALBASVG" , "100000.00" },
                { "FUNDO_VALBASAP" , "50000.00" },
                { "FUNDO_VLCOMISVG" , "500.00" },
                { "FUNDO_VLCOMISAP" , "250.00" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
                { "FUNDO_PCCOMIND" , "1%" },
                { "FUNDO_PCCOMGER" , "1%" },
                { "FUNDO_PCCOMSUP" , "1%" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1", q105);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1

                var q106 = new DynamicData();
                q106.AddDynamic(new Dictionary<string, string>{
                { "FUNDO_PCCOMSUP" , "1%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1", q106);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1

                var q107 = new DynamicData();
                q107.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , "0.38%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1", q107);

                #endregion

                #region R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1

                var q108 = new DynamicData();
                q108.AddDynamic(new Dictionary<string, string>{
                { "SIVPF_NR_IDENTIFI" , "ID123456789" },
                { "SIVPF_NR_SICOB" , "SIC123456" },
                { "SIVPF_SIT_PROPOSTA" , "Aprovada" },
                { "SIVPF_DTQITBCO" , "2023-12-15" },
                { "SIVPF_VAL_PAGO" , "200.00" },
                { "SIVPF_DATA_CREDITO" , "2023-12-16" },
                { "SIVPF_OPCAO_COBER" , "Cobertura Total" },
                { "SIVPF_COD_PLANO" , "PLN123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1", q108);

                #endregion

                #region R7773_00_LER_RCAPS_DB_SELECT_1_Query1

                var q109 = new DynamicData();
                q109.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "FNT001" },
                { "RCAPS_NUM_RCAP" , "RC123456" },
                { "RCAPS_VAL_RCAP" , "1500.00" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7773_00_LER_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7773_00_LER_RCAPS_DB_SELECT_1_Query1", q109);

                #endregion

                #region R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1

                var q110 = new DynamicData();
                q110.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , "001" },
                { "RCAPCOMP_AGE_AVISO" , "0001" },
                { "RCAPCOMP_NUM_AVISO_CREDITO" , "987654321" },
                { "RCAPCOMP_DATA_MOVIMENTO" , "2023-12-15" },
                { "RCAPCOMP_DATA_RCAP" , "2023-12-20" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1", q110);

                #endregion

                #region R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1

                var q111 = new DynamicData();
                q111.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SIT_PROP_FIDELIZ" , "Fidelizado" },
                { "WHOST_SITUACAO_ENVIO" , "Enviado" },
                { "SIVPF_DATA_CREDITO" , "2023-12-16" },
                { "SIVPF_OPCAO_COBER" , "Cobertura Total" },
                { "SIVPF_DTQITBCO" , "2023-12-15" },
                { "SIVPF_VAL_PAGO" , "200.00" },
                { "SIVPF_NR_PROPOSTA" , "27708000280671" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1", q111);

                #endregion

                #region R7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1_Update1

                var q112 = new DynamicData();
                q112.AddDynamic(new Dictionary<string, string>{
                { "CONVER_NUM_SICOB" , "SIC123" },
                { "SIVPF_NR_PROPOSTA" , "27708000280671" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1_Update1", q112);

                #endregion

                #region M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1

                var q113 = new DynamicData();
                q113.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "PROPVA_NRCERTIF" , "98763456811007445554321" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1", q113);

                #endregion

                #region M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1

                var q114 = new DynamicData();
                q114.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "DIFPAR_CODOPER" , "DIF123" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
                { "COBERP_VLPREMIO" , "2" },
                { "V0HCOB_VLPRMTOT" , "800.00" },
                { "DIFPAR_PRMVG" , "2%" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1", q114);

                #endregion

                #region M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1

                var q115 = new DynamicData();
                q115.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1", q115);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute();
                var program = new VP0121B();
                program.Execute();

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();

                Assert.NotEmpty(updates.Where(x => x.Key.Equals("M_0000_PRINCIPAL_DB_UPDATE_1_Update1")).ToList());
                Assert.NotEmpty(updates.Where(x => x.Key.Equals("M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1")).ToList());
                Assert.NotEmpty(updates.Where(x => x.Key.Equals("M_0100_NEXT_DB_UPDATE_1_Update1")).ToList());
                Assert.NotEmpty(updates.Where(x => x.Key.Equals("M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1")).ToList());
                Assert.NotEmpty(updates.Where(x => x.Key.Equals("M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1")).ToList());
                Assert.NotEmpty(updates.Where(x => x.Key.Equals("M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1")).ToList());
                Assert.NotEmpty(updates.Where(x => x.Key.Equals("M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1")).ToList());
                Assert.NotEmpty(updates.Where(x => x.Key.Equals("R8000_PROPAUTOM_DB_UPDATE_1_Update1")).ToList());
                Assert.NotEmpty(updates.Where(x => x.Key.Equals("R8000_PROPAUTOM_DB_UPDATE_2_Update1")).ToList());
                Assert.NotEmpty(updates.Where(x => x.Key.Equals("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1")).ToList());
                Assert.NotEmpty(updates.Where(x => x.Key.Equals("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1")).ToList());

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void VP0121B_Tests_Return99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                PROSOCU1_Tests.Load_Parameters();
                PROTIT01_Tests.Load_Parameters();
                FC0105B_Tests.Load_Parameters();
                FC0001S_Tests.Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
   
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_NUM_RAMO_PRSTMISTA" , "77" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q1);

                #endregion

                #region VP0121B_CPROPVA

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "109300000598" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_CODPRODU" , "7706" },
                { "PROPVA_CODCLIEN" , "456789" },
                { "PROPVA_OCOREND" , "12345" },
                { "PROPVA_FONTE" , "0" },
                { "PROPVA_AGECOBR" , "001" },
                { "PROPVA_OPCAO_COBER" , "A" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
                { "PROPVA_DTINICDG" , "2023-01-01" },
                { "PROPVA_DTINISAF" , "2023-01-01" },
                { "PROPVA_DTPROXVEN" , "2024-01-01" },
                { "PROPVA_DTMINVEN" , "2023-12-31" },
                { "PROPVA_NRMATRVEN" , "123456" },
                { "PROPVA_CODOPER" , "OP123" },
                { "PROPVA_DTMOVTO" , "2023-12-01" },
                { "PROPVA_SITUACAO" , "7" },
                { "PROPVA_NUM_APOLICE1" , "109300000598" },
                { "PROPVA_CODSUBES1" , "002" },
                { "PROPVA_OCORHIST" , "Ocorrencia Teste" },
                { "PROPVA_NRPARCEL" , "12" },
                { "PROPVA_SIT_INTERF" , "Ativa" },
                { "PROPVA_TIMESTAMP" , "2023-12-01T12:00:00" },
                { "PROPVA_IDADE" , "35" },
                { "PROPVA_SEXO" , "M" },
                { "PROPVA_EST_CIV" , "Casado" },
                { "PROPVA_COD_CRM" , "CRM123" },
                { "PROPVA_NRMATRFUN" , "654321" },
                { "PROPVA_DTADMIS" , "2020-01-01" },
                { "PROPVA_NRPROPOS" , "27708000280671" },
                { "PROPVA_CODCCT" , "CCT001" },
                { "PROPVA_CODUSU" , "USU123" },
                { "PROPVA_DTVENCTO" , "2024-01-01" },
                { "PROPVA_FAIXA_RENDA_IND" , "Alta" },
                { "PROPVA_DATA" , "2023-12-01" },
                { "PROPVA_DPS_TITULAR" , "" },
                { "PROPVA_ORIGEM_PROPOSTA" , "999" },
                { "PROPVA_ACATAMENTO" , "N" },
                { "PROPVA_COD_OPER_CREDITO" , "CRED123" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0121B_CPROPVA");
                AppSettings.TestSet.DynamicData.Add("VP0121B_CPROPVA", q2);

                #endregion

                #region VP0121B_V1RCAPCOMP

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , "Fonte1" },
                { "V1RCAC_NRRCAP" , "321" },
                { "V1RCAC_NRRCAPCO" , "321CO" },
                { "V1RCAC_OPERACAO" , "Oper123" },
                { "V1RCAC_DTMOVTO" , "2023-12-01" },
                { "V1RCAC_HORAOPER" , "12:00" },
                { "V1RCAC_SITUACAO" , "Ativa" },
                { "V1RCAC_BCOAVISO" , "001" },
                { "V1RCAC_AGEAVISO" , "002" },
                { "V1RCAC_NRAVISO" , "003" },
                { "V1RCAC_VLRCAP" , "1000.00" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
                { "V1RCAC_DTCADAST" , "2023-12-01" },
                { "V1RCAC_SITCONTB" , "Confirmada" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0121B_V1RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("VP0121B_V1RCAPCOMP", q3);

                #endregion

                #region M_0000_PRINCIPAL_DB_UPDATE_1_Update1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NRTIT" , "85172719932" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_UPDATE_1_Update1", q4);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_3_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SUBGRU_CODSUBES" , "0" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_3_Query1", q5);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_4_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NRTIT" , "85172719932" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_4_Query1", q6);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "PRODVG_CODPRODAZ" , "P123" },
                { "PRODVG_PERIPGTO" , "Mensal" },
                { "PRODVG_ESTR_COBR" , "Estruturada" },
                { "PRODVG_ORIG_PRODU" , "MULT" },
                { "PRODVG_AGENCIADOR" , "Agente123" },
                { "PRODVG_TEM_SAF" , "Sim" },
                { "PRODVG_TEM_CDG" , "Não" },
                { "PRODVG_CODRELAT" , "R123" },
                { "PRODVG_COBERADIC_PREMIO" , "100.00" },
                { "PRODVG_CUSTOCAP_TOTAL" , "200.00" },
                { "PRODVG_DESCONTO_ADESAO" , "10.00" },
                { "PRODVG_COD_PRODUTO" , "7706" },
                { "PRODVG_RISCO" , "Baixo" },
                { "PRODVG_SITPLANCEF" , "Ativo" },
                { "PRODVG_ARQ_FDCAP" , "Arquivo123" },
                { "PRODVG_COD_RUBRICA" , "RUB001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1", q7);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_OPCAOPAG" , "1" },
                { "OPCAOP_PERIPGTO" , "4" },
                { "OPCAOP_DIA_DEB" , "0" },
                { "OPCAOP_AGECTADEB" , "0" },
                { "OPCAOP_OPRCTADEB" , "OPR001" },
                { "OPCAOP_NUMCTADEB" , "123456" },
                { "OPCAOP_DIGCTADEB" , "7" },
                { "OPCAOP_CARTAOCRED" , "4111111111111111" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_1_Query1", q8);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_PERIPGTO" , "4" },
                { "OPCAOP_OPCAOPAG" , "1" },
                { "OPCAOP_DIA_DEB" , "0" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1", q9);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "WTEM_ERRO_7705" , "Erro7705" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1", q10);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_2_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V0AGCEF_COD_AGCOBR" , "AG001" }
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_2_Query1", q11);

                #endregion

                #region M_0100_NEXT_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_NEXT_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0100_NEXT_DB_UPDATE_1_Update1", q12);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_3_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V0COBER_MINOCOR" , "MinOcor001" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_3_Query1", q13);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "WTEM_ERRO_7715" , "Erro7715" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1", q14);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_4_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "COBERP_DTINIVIG" , "2023-01-01" },
                { "COBERP_DTTERVIG" , "2024-01-01" },
                { "COBERP_IMPMORNATU" , "0" },
                { "COBERP_IMPMORACID" , "100.00" },
                { "COBERP_IMPINVPERM" , "150.00" },
                { "COBERP_IMPAMDS" , "200.00" },
                { "COBERP_IMPDH" , "250.00" },
                { "COBERP_IMPDIT" , "300.00" },
                { "COBERP_VLPREMIO" , "2" },
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "COBERP_IMPSEGCDG" , "500.00" },
                { "COBERP_VLCUSTCDG" , "550.00" },
                { "COBERP_VLCUSTCAP" , "600.00" },
                { "COBERP_IMPSEGAUXF" , "650.00" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "COBERP_QTTITCAP" , "750" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_4_Query1", q15);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_5_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "COBERP_DTINIVIG" , "2023-01-01" },
                { "COBERP_IMPMORNATU" , "0" },
                { "COBERP_IMPMORACID" , "100.00" },
                { "COBERP_IMPINVPERM" , "150.00" },
                { "COBERP_IMPAMDS" , "200.00" },
                { "COBERP_IMPDH" , "250.00" },
                { "COBERP_IMPDIT" , "300.00" },
                { "COBERP_VLPREMIO" , "2" },
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "COBERP_IMPSEGCDG" , "500.00" },
                { "COBERP_VLCUSTCDG" , "550.00" },
                { "COBERP_VLCUSTCAP" , "600.00" },
                { "COBERP_IMPSEGAUXF" , "650.00" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "COBERP_QTTITCAP" , "750" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_5_Query1", q16);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , "1988-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1", q17);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_6_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , "800.00" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_6_Query1", q18);

                #endregion

                #region M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "ERRPROVI_COD_ERRO" , "1002" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1", q19);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_DTPROXVEN" , "2024-01-01" },
                { "PROPVA_CODPRODU" , "7706" },
                { "PROPVA_SITUACAO" , "7" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_CODOPER" , "OP123" },
                { "MDTMOVTO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1", q20);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_7_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , "800.00" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_7_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_7_Query1", q21);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRPROPOS" , "27708000280671" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1", q22);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_8_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , "109300000598" },
                { "RELATO_CODSUBES" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_8_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_8_Query1", q23);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_9_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , "109300000598" },
                { "RELATO_CODSUBES" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_9_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_9_Query1", q24);

                #endregion

                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRCERTIF" , "987654321" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1", q25);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_10_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , "109300000598" },
                { "RELATO_CODSUBES" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_10_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_10_Query1", q26);

                #endregion

                #region M_0110_FETCH_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA_MOVIMENTO" , "2023-12-01" }
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("M_0110_FETCH_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_DB_SELECT_1_Query1", q27);

                #endregion

                #region M_0110_FETCH_DB_UPDATE_1_Update1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0110_FETCH_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_DB_UPDATE_1_Update1", q28);

                #endregion

                #region M_0100_OPCAOPAGVA_DB_SELECT_11_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , "109300000598" },
                { "RELATO_CODSUBES" , "001" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0100_OPCAOPAGVA_DB_SELECT_11_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_OPCAOPAGVA_DB_SELECT_11_Query1", q29);

                #endregion

                #region M_0110_FETCH_DB_SELECT_2_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_RAMO" , "77" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0110_FETCH_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_DB_SELECT_2_Query1", q30);

                #endregion

                #region M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-12-01" },
                { "WHOST_PROXIMA_DATA" , "2023-12-02" },
                { "CALENDAR_DIA_SEMANA" , "Q" },
                { "CALENDAR_FERIADO" , "Não" },
            });

                q31.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-12-02" },
                { "WHOST_PROXIMA_DATA" , "2023-12-03" },
                { "CALENDAR_DIA_SEMANA" , "Q" },
                { "CALENDAR_FERIADO" , "Não" },
            });

                q31.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-12-03" },
                { "WHOST_PROXIMA_DATA" , "2023-12-04" },
                { "CALENDAR_DIA_SEMANA" , "Q" },
                { "CALENDAR_FERIADO" , "Não" },
            });
                q31.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-12-04" },
                { "WHOST_PROXIMA_DATA" , "2023-12-05" },
                { "CALENDAR_DIA_SEMANA" , "Q" },
                { "CALENDAR_FERIADO" , "Não" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1", q31);

                #endregion

                #region M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                { "RELATO_CODRELAT" , "R123" },
                { "PROPVA_NUM_APOLICE" , "109300000598" },
                { "RELATO_NRPARCEL" , "12" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_CODSUBES" , "001" },
                { "RELATO_OPERACAO" , "Oper123" },
                { "WS_SIT_REGISTRO" , "Ativo" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1", q32);

                #endregion

                #region M_0300_VERIFICA_CROT_DB_SELECT_1_Query1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_CGCCPF" , "12345678901" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0300_VERIFICA_CROT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0300_VERIFICA_CROT_DB_SELECT_1_Query1", q33);

                #endregion

                #region M_0300_VERIFICA_CROT_DB_SELECT_2_Query1

                var q34 = new DynamicData();
                q34.AddDynamic(new Dictionary<string, string>{
                { "CLIROT_DTMOVABE" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0300_VERIFICA_CROT_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0300_VERIFICA_CROT_DB_SELECT_2_Query1", q34);

                #endregion

                #region M_0320_UPDATE_CROT_DB_UPDATE_1_Update1

                var q35 = new DynamicData();
                q35.AddDynamic(new Dictionary<string, string>{
                { "CLIROT_DTMOVABE" , "2023-12-01" },
                { "CLIENT_CGCCPF" , "12345678901" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0320_UPDATE_CROT_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0320_UPDATE_CROT_DB_UPDATE_1_Update1", q35);

                #endregion

                #region M_0330_INCLUI_CROT_DB_INSERT_1_Insert1

                var q36 = new DynamicData();
                q36.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_CGCCPF" , "12345678901" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0330_INCLUI_CROT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0330_INCLUI_CROT_DB_INSERT_1_Insert1", q36);

                #endregion

                #region R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1

                var q37 = new DynamicData();
                q37.AddDynamic(new Dictionary<string, string>{
                { "V0FOLHM_DTEMICAR" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1", q37);

                #endregion

                #region R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1

                var q38 = new DynamicData();
                q38.AddDynamic(new Dictionary<string, string>{
                { "V0FOLH_COD_CARTA" , "C123" },
                { "V0FOLH_DTEMICAR" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1", q38);

                #endregion

                #region M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1

                var q39 = new DynamicData();
                q39.AddDynamic(new Dictionary<string, string>{
                { "V0FOLH_COD_PRODUTO" , "7705" },
                { "V0FOLH_NRCERTIF" , "987654321" },
                { "V0FOLH_COD_CARTA" , "C123" },
                { "V0FOLH_DTEMICAR" , "2023-12-01" },
                { "V0FOLH_DTSOLICIT" , "2023-12-01" },
                { "V0FOLH_CODUSU" , "USU123" },
                { "V0FOLH_SITUACAO" , "Ativa" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1", q39);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1

                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                { "CONVER_NUM_SICOB" , "SIC123" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1", q40);

                #endregion

                #region FINALIZA_1110_FIM_DB_UPDATE_1_Update1

                var q41 = new DynamicData();
                q41.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "CONVER_NUM_PROPOSTA" , "27708000280671" },
            });
                AppSettings.TestSet.DynamicData.Remove("FINALIZA_1110_FIM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("FINALIZA_1110_FIM_DB_UPDATE_1_Update1", q41);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1

                var q42 = new DynamicData();
                q42.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , "Fonte1" },
                { "V0RCAP_NRRCAP" , "321" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1", q42);

                #endregion

                #region FINALIZA_1110_FIM_DB_UPDATE_2_Update1

                var q43 = new DynamicData();
                q43.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "V0RCAP_NRRCAP" , "321" },
                { "V0RCAP_FONTE" , "Fonte1" },
            });
                AppSettings.TestSet.DynamicData.Remove("FINALIZA_1110_FIM_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("FINALIZA_1110_FIM_DB_UPDATE_2_Update1", q43);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1

                var q44 = new DynamicData();
                q44.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "109300000598" },
                { "V0RCAP_NRRCAP" , "321" },
                { "V0RCAP_FONTE" , "Fonte1" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1", q44);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1

                var q45 = new DynamicData();
                q45.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , "001" },
                { "V1RCAC_AGEAVISO" , "002" },
                { "V1RCAC_NRAVISO" , "003" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1", q45);

                #endregion

                #region VP0121B_CBENEFP

                var q46 = new DynamicData();
                q46.AddDynamic(new Dictionary<string, string>{
                { "BENEF_NOMBENEF" , "Nome Beneficiário" },
                { "BENEF_GRAUPAR" , "Grau Parentesco" },
                { "BENEF_PCTBENEF" , "50%" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0121B_CBENEFP");
                AppSettings.TestSet.DynamicData.Add("VP0121B_CBENEFP", q46);

                #endregion

                #region M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1

                var q47 = new DynamicData();
                q47.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_NRRCAPCO" , "321CO" },
                { "V1RCAC_OPERACAO" , "Oper123" },
                { "V1RCAC_HORAOPER" , "12:00" },
                { "V1RCAC_DTMOVTO" , "2023-12-01" },
                { "V1RCAC_NRRCAP" , "321" },
                { "V1RCAC_FONTE" , "Fonte1" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1", q47);

                #endregion

                #region M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1

                var q48 = new DynamicData();
                q48.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_FONTE" , "Fonte1" },
                { "V1RCAC_NRRCAP" , "321" },
                { "V1RCAC_NRRCAPCO" , "321CO" },
                { "V1RCAC_OPERACAO" , "Oper123" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
                { "V1RCAC_SITUACAO" , "Ativa" },
                { "V1RCAC_BCOAVISO" , "001" },
                { "V1RCAC_AGEAVISO" , "002" },
                { "V1RCAC_NRAVISO" , "003" },
                { "V1RCAC_VLRCAP" , "1000.00" },
                { "V1RCAC_DATARCAP" , "2023-12-01" },
                { "V1RCAC_DTCADAST" , "2023-12-01" },
                { "V1RCAC_SITCONTB" , "Confirmada" },
                { "V1RCAC_COD_EMPRESA" , "EMP123" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1", q48);

                #endregion

                #region M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1

                var q49 = new DynamicData();
                q49.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_VLRCAP" , "1000.00" },
                { "V1RCAC_BCOAVISO" , "001" },
                { "V1RCAC_AGEAVISO" , "002" },
                { "V1RCAC_NRAVISO" , "003" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1", q49);

                #endregion

                #region M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1

                var q50 = new DynamicData();
                q50.AddDynamic(new Dictionary<string, string>{
                { "PRODVG_CODPRODAZ" , "P123" },
                { "PRODVG_ESTR_COBR" , "Estruturada" },
                { "PRODVG_ORIG_PRODU" , "MULT" },
                { "PRODVG_AGENCIADOR" , "Agente123" },
                { "PRODVG_TEM_SAF" , "Sim" },
                { "PRODVG_TEM_CDG" , "Não" },
                { "PRODVG_CODRELAT" , "R123" },
                { "PRODVG_COBERADIC_PREMIO" , "100.00" },
                { "PRODVG_CUSTOCAP_TOTAL" , "200.00" },
                { "PRODVG_DESCONTO_ADESAO" , "10.00" },
                { "PRODVG_COD_PRODUTO" , "7706" },
                { "PRODVG_RISCO" , "Baixo" },
                { "PRODVG_SITPLANCEF" , "Ativo" },
                { "PRODVG_ARQ_FDCAP" , "Arquivo123" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1", q50);

                #endregion

                #region M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1

                var q51 = new DynamicData();
                q51.AddDynamic(new Dictionary<string, string>{
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1", q51);

                #endregion

                #region M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1

                var q52 = new DynamicData();
                q52.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODSUBES" , "001" },
                { "MTXAPMA" , "Matriz AP MA" },
                { "MTXAPIP" , "Matriz AP IP" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1", q52);

                #endregion

                #region M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1

                var q53 = new DynamicData();
                q53.AddDynamic(new Dictionary<string, string>{
                { "APCORR_RAMO" , "Vida" },
                { "PROPVA_CODSUBES" , "001" },
                { "APCORR_DTINIVIG" , "2023-01-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1", q53);

                #endregion

                #region M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1

                var q54 = new DynamicData();
                q54.AddDynamic(new Dictionary<string, string>{
                { "COMISSOE_NUM_APOLICE" , "109300000598" },
                { "COMISSOE_NUM_ENDOSSO" , "E123" },
                { "COMISSOE_NUM_CERTIFICADO" , "7457254811" },
                { "COMISSOE_DAC_CERTIFICADO" , "DAC123" },
                { "COMISSOE_TIPO_SEGURADO" , "Titular" },
                { "COMISSOE_NUM_PARCELA" , "12" },
                { "COMISSOE_COD_OPERACAO" , "OP123" },
                { "COMISSOE_COD_PRODUTOR" , "Prod123" },
                { "COMISSOE_RAMO_COBERTURA" , "Vida" },
                { "COMISSOE_MODALI_COBERTURA" , "Modalidade1" },
                { "COMISSOE_OCORR_HISTORICO" , "Histórico Ocorrência" },
                { "COMISSOE_COD_FONTE" , "Fonte1" },
                { "COMISSOE_COD_CLIENTE" , "456789" },
                { "COMISSOE_VAL_COMISSAO" , "100.00" },
                { "COMISSOE_DATA_CALCULO" , "2023-12-01" },
                { "COMISSOE_NUM_RECIBO" , "R123456" },
                { "COMISSOE_VAL_BASICO" , "200.00" },
                { "COMISSOE_TIPO_COMISSAO" , "Tipo1" },
                { "COMISSOE_QTD_PARCELAS" , "12" },
                { "COMISSOE_PCT_COM_CORRETOR" , "10%" },
                { "COMISSOE_PCT_DESC_PREMIO" , "5%" },
                { "COMISSOE_COD_SUBGRUPO" , "SG001" },
                { "COMISSOE_DATA_MOVIMENTO" , "2023-12-01" },
                { "COMISSOE_DATA_SELECAO" , "2023-12-01" },
                { "COMISSOE_COD_EMPRESA" , "EMP123" },
                { "COMISSOE_COD_PREPOSTO" , "Prep123" },
                { "COMISSOE_NUM_BILHETE" , "B123456" },
                { "COMISSOE_VAL_VARMON" , "300.00" },
                { "COMISSOE_DATA_QUITACAO" , "2024-01-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1", q54);

                #endregion

                #region M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1

                var q55 = new DynamicData();
                q55.AddDynamic(new Dictionary<string, string>{
                { "PROD_COD_EMPRESA" , "EMP123" },
                { "PARM_COD_EMPR_CAP" , "EMP123" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1", q55);

                #endregion

                #region R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1

                var q56 = new DynamicData();
                q56.AddDynamic(new Dictionary<string, string>{
                { "COMFEDCA_SITUACAO" , "Ativa" }
            });
                AppSettings.TestSet.DynamicData.Remove("R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1", q56);

                #endregion

                #region R6290_10_INSERT_DB_INSERT_1_Insert1

                var q57 = new DynamicData();
                q57.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_FONTE" , "CEF" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
                { "MOVFEDCA_VAL_CUSTO_CAPITALI" , "100.00" },
                { "MOVFEDCA_NRTITFDCAP" , "123456" },
                { "PRODVG_COD_PRODUTO" , "7706" },
            });
                AppSettings.TestSet.DynamicData.Remove("R6290_10_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R6290_10_INSERT_DB_INSERT_1_Insert1", q57);

                #endregion

                #region R6300_00_INSERT_DB_INSERT_1_Insert1

                var q58 = new DynamicData();
                q58.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_NRTITFDCAP" , "123456" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "TITFEDCA_DATA_INIVIGENCIA" , "2023-01-01" },
                { "TITFEDCA_DATA_TERVIGENCIA" , "2024-01-01" },
                { "TITFEDCA_NRSORTEIO" , "S123456" },
                { "TITFEDCA_VAL_CUSTO_TITULO" , "150.00" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R6300_00_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R6300_00_INSERT_DB_INSERT_1_Insert1", q58);

                #endregion

                #region R6400_10_INSERT_DB_INSERT_1_Insert1

                var q59 = new DynamicData();
                q59.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R6400_10_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R6400_10_INSERT_DB_INSERT_1_Insert1", q59);

                #endregion

                #region R6500_10_INSERT_DB_INSERT_1_Insert1

                var q60 = new DynamicData();
                q60.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_NRTITFDCAP" , "123456" },
                { "PARFEDCA_VAL_CUSTO_TITULO" , "150.00" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R6500_10_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R6500_10_INSERT_DB_INSERT_1_Insert1", q60);

                #endregion

                #region R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1

                var q61 = new DynamicData();
                q61.AddDynamic(new Dictionary<string, string>{
                { "COMFEDCA_SITUACAO" , "Ativa" }
            });
                AppSettings.TestSet.DynamicData.Remove("R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1", q61);

                #endregion

                #region R7400_10_INSERT_DB_INSERT_1_Insert1

                var q62 = new DynamicData();
                q62.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7400_10_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R7400_10_INSERT_DB_INSERT_1_Insert1", q62);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_1_Query1

                var q63 = new DynamicData();
                q63.AddDynamic(new Dictionary<string, string>{
                { "CONDTE_IEA" , "Inclusão" },
                { "CONDTE_IPA" , "Proposta" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_1_Query1", q63);

                #endregion

                #region R8000_PROPAUTOM_DB_INSERT_1_Insert1

                var q64 = new DynamicData();
                q64.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "109300000598" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_FONTE" , "0" },
                { "FONTE_PROPAUTOM" , "Automática" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "MTPINCLUS" , "Inclusão Manual" },
                { "PROPVA_CODCLIEN" , "456789" },
                { "MAGENCIADOR" , "Agente123" },
                { "MMFAIXA" , "Faixa1" },
                { "MTPBENEF" , "Tipo Benefício" },
                { "OPCAOP_PERIPGTO" , "4" },
                { "PROPVA_EST_CIV" , "Casado" },
                { "PROPVA_SEXO" , "M" },
                { "MAGECOBR" , "Agência Cobrança" },
                { "MMNUM_MATRICULA" , "Mat123" },
                { "MNUM_CTA_CORRENTE" , "Conta123" },
                { "MDAC_CTA_CORRENTE" , "DAC123" },
                { "MTXAPMA" , "Matriz AP MA" },
                { "MTXAPIP" , "Matriz AP IP" },
                { "MTXVG" , "Matriz VG" },
                { "COBERP_IMPMORNATU" , "0" },
                { "COBERP_IMPMORACID" , "100.00" },
                { "COBERP_IMPINVPERM" , "150.00" },
                { "COBERP_IMPAMDS" , "200.00" },
                { "COBERP_IMPDH" , "250.00" },
                { "COBERP_IMPDIT" , "300.00" },
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "MCODOPER" , "OP123" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
                { "PROPVA_CODUSU" , "USU123" },
                { "WSISTEMA_DTMOVABE" , "2023-12-01" },
                { "CLIENT_DTNASC" , "1988-01-01" },
                { "MDTREF" , "2023-12-01" },
                { "MMDTMOVTO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_INSERT_1_Insert1", q64);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_2_Query1

                var q65 = new DynamicData();
                q65.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , "1988-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_2_Query1", q65);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_1_Update1

                var q66 = new DynamicData();
                q66.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , "Automática" },
                { "PROPVA_FONTE" , "0" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_1_Update1", q66);

                #endregion

                #region R8000_PROPAUTOM_DB_INSERT_2_Insert1

                var q67 = new DynamicData();
                q67.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "109300000598" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_FONTE" , "0" },
                { "FONTE_PROPAUTOM" , "Automática" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "MTPINCLUS" , "Inclusão Manual" },
                { "PROPVA_CODCLIEN" , "456789" },
                { "MAGENCIADOR" , "Agente123" },
                { "MMFAIXA" , "Faixa1" },
                { "MTPBENEF" , "Tipo Benefício" },
                { "OPCAOP_PERIPGTO" , "4" },
                { "PROPVA_EST_CIV" , "Casado" },
                { "PROPVA_SEXO" , "M" },
                { "MAGECOBR" , "Agência Cobrança" },
                { "MMNUM_MATRICULA" , "Mat123" },
                { "MNUM_CTA_CORRENTE" , "Conta123" },
                { "MDAC_CTA_CORRENTE" , "DAC123" },
                { "MTXAPMA" , "Matriz AP MA" },
                { "MTXAPIP" , "Matriz AP IP" },
                { "MTXVG" , "Matriz VG" },
                { "COBERP_IMPMORNATU" , "0" },
                { "COBERP_IMPMORACID" , "100.00" },
                { "COBERP_IMPINVPERM" , "150.00" },
                { "COBERP_IMPAMDS" , "200.00" },
                { "COBERP_IMPDH" , "250.00" },
                { "COBERP_IMPDIT" , "300.00" },
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "MCODOPER" , "OP123" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
                { "PROPVA_CODUSU" , "USU123" },
                { "WSISTEMA_DTMOVABE" , "2023-12-01" },
                { "PROPVA_DTADMIS" , "2020-01-01" },
                { "CLIENT_DTNASC" , "1988-01-01" },
                { "MDTREF" , "2023-12-01" },
                { "MMDTMOVTO" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_INSERT_2_Insert1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_INSERT_2_Insert1", q67);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_2_Update1

                var q68 = new DynamicData();
                q68.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_2_Update1", q68);

                #endregion

                #region R8000_PROPAUTOM_DB_SELECT_1_Query1

                var q69 = new DynamicData();
                q69.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , "800.00" }
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_SELECT_1_Query1", q69);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_3_Update1

                var q70 = new DynamicData();
                q70.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_3_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_3_Update1", q70);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_3_Query1

                var q71 = new DynamicData();
                q71.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , "25-35" },
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_3_Query1", q71);

                #endregion

                #region R8000_PROPAUTOM_DB_SELECT_2_Query1

                var q72 = new DynamicData();
                q72.AddDynamic(new Dictionary<string, string>{
                { "COMISI_VALADT" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_SELECT_2_Query1", q72);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_4_Update1

                var q73 = new DynamicData();
                q73.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_4_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_4_Update1", q73);

                #endregion

                #region M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1

                var q74 = new DynamicData();
                q74.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , "25-35" },
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1", q74);

                #endregion

                #region R8000_PROPAUTOM_DB_UPDATE_5_Update1

                var q75 = new DynamicData();
                q75.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("R8000_PROPAUTOM_DB_UPDATE_5_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_5_Update1", q75);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_4_Query1

                var q76 = new DynamicData();
                q76.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , "25-35" },
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_4_Query1", q76);

                #endregion

                #region M_8000_INTEGRA_VG_DB_SELECT_5_Query1

                var q77 = new DynamicData();
                q77.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , "25-35" },
                { "MTXVG" , "Matriz VG" },
                { "MTXAPMA" , "Matriz AP MA" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8000_INTEGRA_VG_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_5_Query1", q77);

                #endregion

                #region M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1

                var q78 = new DynamicData();
                q78.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "3" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1", q78);

                #endregion

                #region VP0121B_C01_RCAPCOMP

                var q79 = new DynamicData();
                q79.AddDynamic(new Dictionary<string, string>{
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_BCO_AVISO" , "237" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_AGE_AVISO" , "1234" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_NUM_AVISO_CREDITO" , "987654321" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_MOVIMENTO" , "2023-12-15" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_RCAP" , "2023-12-20" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_COD_OPERACAO" , "OP123" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP0121B_C01_RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("VP0121B_C01_RCAPCOMP", q79);

                #endregion

                #region M_8100_LOOP_DB_INSERT_1_Insert1

                var q80 = new DynamicData();
                q80.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "109300000598" },
                { "PROPVA_CODSUBES" , "001" },
                { "PROPVA_FONTE" , "0" },
                { "FONTE_PROPAUTOM" , "Automática" },
                { "BENEF_NRBENEF" , "BN1234567" },
                { "BENEF_NOMBENEF" , "Nome Beneficiário" },
                { "BENEF_GRAUPAR" , "Grau Parentesco" },
                { "BENEF_PCTBENEF" , "50%" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8100_LOOP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8100_LOOP_DB_INSERT_1_Insert1", q80);

                #endregion

                #region M_8200_CONCEDE_CDG_DB_SELECT_1_Query1

                var q81 = new DynamicData();
                q81.AddDynamic(new Dictionary<string, string>{
                { "CDGCOB_DTINIVIG" , "2023-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8200_CONCEDE_CDG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8200_CONCEDE_CDG_DB_SELECT_1_Query1", q81);

                #endregion

                #region M_8200_CONCEDE_CDG_DB_SELECT_2_Query1

                var q82 = new DynamicData();
                q82.AddDynamic(new Dictionary<string, string>{
                { "REPCDG_DTREF" , "2023-01-31" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8200_CONCEDE_CDG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8200_CONCEDE_CDG_DB_SELECT_2_Query1", q82);

                #endregion

                #region M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1

                var q83 = new DynamicData();
                q83.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1", q83);

                #endregion

                #region M_8220_INCLUI_CDG_DB_INSERT_1_Insert1

                var q84 = new DynamicData();
                q84.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "PROPVA_DTINICDG" , "2023-01-01" },
                { "COBERP_IMPSEGCDG" , "500.00" },
                { "COBERP_VLCUSTCDG" , "550.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_OCORHIST" , "Ocorrencia Teste" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8220_INCLUI_CDG_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8220_INCLUI_CDG_DB_INSERT_1_Insert1", q84);

                #endregion

                #region M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1

                var q85 = new DynamicData();
                q85.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "REPCDG_DTREF" , "2023-01-31" },
                { "COBERP_VLCUSTCDG" , "550.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1", q85);

                #endregion

                #region M_8300_CONCEDE_SAF_DB_SELECT_1_Query1

                var q86 = new DynamicData();
                q86.AddDynamic(new Dictionary<string, string>{
                { "SAFCOB_DTINIVIG" , "2023-02-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8300_CONCEDE_SAF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8300_CONCEDE_SAF_DB_SELECT_1_Query1", q86);

                #endregion

                #region M_8300_CONCEDE_SAF_DB_SELECT_2_Query1

                var q87 = new DynamicData();
                q87.AddDynamic(new Dictionary<string, string>{
                { "REPSAF_DTREF" , "2025-02-28" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8300_CONCEDE_SAF_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8300_CONCEDE_SAF_DB_SELECT_2_Query1", q87);

                #endregion

                #region M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1

                var q88 = new DynamicData();
                q88.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1", q88);

                #endregion

                #region M_8320_INCLUI_SAF_DB_INSERT_1_Insert1

                var q89 = new DynamicData();
                q89.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "PROPVA_DTINISAF" , "2023-01-01" },
                { "COBERP_IMPSEGAUXF" , "650.00" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_OCORHIST" , "Ocorrencia Teste" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8320_INCLUI_SAF_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8320_INCLUI_SAF_DB_INSERT_1_Insert1", q89);

                #endregion

                #region M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1

                var q90 = new DynamicData();
                q90.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "REPSAF_DTREF" , "2023-02-28" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_NRMATRFUN" , "654321" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "PROPVA_CODOPER" , "OP123" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1", q90);

                #endregion

                #region M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1

                var q91 = new DynamicData();
                q91.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "456789" },
                { "REPSAF_DTREF" , "2023-02-28" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_NRMATRFUN" , "654321" },
                { "COBERP_VLCUSTAUXF" , "700.00" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1", q91);

                #endregion

                #region M_8400_00_DEBITO_CARTAO_DB_INSERT_1_Insert1

                var q92 = new DynamicData();
                q92.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_EMPRESA" , "EMP001" },
                { "MOVDEBCE_NUM_APOLICE" , "APL123456" },
                { "MOVDEBCE_NUM_ENDOSSO" , "END123456" },
                { "MOVDEBCE_NUM_PARCELA" , "PAR123456" },
                { "MOVDEBCE_SITUACAO_COBRANCA" , "Pendente" },
                { "MOVDEBCE_DATA_VENCIMENTO" , "2023-12-31" },
                { "MOVDEBCE_VALOR_DEBITO" , "500.00" },
                { "MOVDEBCE_DATA_MOVIMENTO" , "2023-12-01" },
                { "MOVDEBCE_DIA_DEBITO" , "15" },
                { "MOVDEBCE_COD_AGENCIA_DEB" , "0001" },
                { "MOVDEBCE_OPER_CONTA_DEB" , "013" },
                { "MOVDEBCE_NUM_CONTA_DEB" , "12345678" },
                { "MOVDEBCE_DIG_CONTA_DEB" , "9" },
                { "MOVDEBCE_COD_CONVENIO" , "CONV001" },
                { "MOVDEBCE_DATA_ENVIO" , "2023-12-02" },
                { "MOVDEBCE_DATA_RETORNO" , "2023-12-03" },
                { "MOVDEBCE_COD_RETORNO_CEF" , "RET001" },
                { "MOVDEBCE_NSAS" , "NS123456" },
                { "MOVDEBCE_COD_USUARIO" , "USR001" },
                { "MOVDEBCE_NUM_REQUISICAO" , "REQ123456" },
                { "MOVDEBCE_NUM_CARTAO" , "CARD1234567890" },
                { "MOVDEBCE_SEQUENCIA" , "SEQ123" },
                { "MOVDEBCE_NUM_LOTE" , "LOT123" },
                { "MOVDEBCE_DTCREDITO" , "2023-12-05" },
                { "MOVDEBCE_STATUS_CARTAO" , "Ativo" },
                { "MOVDEBCE_VLR_CREDITO" , "1000.00" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8400_00_DEBITO_CARTAO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8400_00_DEBITO_CARTAO_DB_INSERT_1_Insert1", q92);

                #endregion

                #region M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1

                var q93 = new DynamicData();
                q93.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , "Automática" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1", q93);

                #endregion

                #region M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1

                var q94 = new DynamicData();
                q94.AddDynamic(new Dictionary<string, string>{
                { "W03_VENCIMENTO" , "2023-12-10" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1", q94);

                #endregion

                #region M_8600_10_CONTINUA_DB_SELECT_1_Query1

                var q95 = new DynamicData();
                q95.AddDynamic(new Dictionary<string, string>{
                { "DESCON_PERC" , "10%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_10_CONTINUA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_SELECT_1_Query1", q95);

                #endregion

                #region M_8600_10_CONTINUA_DB_INSERT_1_Insert1

                var q96 = new DynamicData();
                q96.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "HISTCB_DTVENCTO" , "2023-12-20" },
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "OPCAOP_OPCAOPAG" , "1" },
                { "PARCEL_OCORHIST" , "Ocorrência 1" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_10_CONTINUA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_INSERT_1_Insert1", q96);

                #endregion

                #region M_8600_CONTINUA_DB_UPDATE_1_Update1

                var q97 = new DynamicData();
                q97.AddDynamic(new Dictionary<string, string>{
                { "HISTCB_DTVENCTO" , "2023-12-20" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_CONTINUA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_8600_CONTINUA_DB_UPDATE_1_Update1", q97);

                #endregion

                #region M_8600_10_CONTINUA_DB_INSERT_2_Insert1

                var q98 = new DynamicData();
                q98.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "BANCOS_NRTIT" , "85172719932" },
                { "HISTCB_DTVENCTO" , "2023-12-20" },
                { "DESCON_VLPREMIO" , "50.00" },
                { "OPCAOP_OPCAOPAG" , "1" },
                { "HISTCB_SITUACAO" , "Ativa" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_10_CONTINUA_DB_INSERT_2_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_INSERT_2_Insert1", q98);

                #endregion

                #region M_8600_CONTINUA_DB_UPDATE_2_Update1

                var q99 = new DynamicData();
                q99.AddDynamic(new Dictionary<string, string>{
                { "WS_PROPVA_DTPROXVEN" , "2024-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_CONTINUA_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("M_8600_CONTINUA_DB_UPDATE_2_Update1", q99);

                #endregion

                #region M_8600_10_CONTINUA_DB_INSERT_3_Insert1

                var q100 = new DynamicData();
                q100.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "HISTCB_DTVENCTO" , "2023-12-20" },
                { "DESCON_PRMVG" , "5%" },
                { "DESCON_PRMAP" , "3%" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8600_10_CONTINUA_DB_INSERT_3_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_INSERT_3_Insert1", q100);

                #endregion

                #region M_8700_GERA_DEBITO_DB_SELECT_1_Query1

                var q101 = new DynamicData();
                q101.AddDynamic(new Dictionary<string, string>{
                { "CONVEN_CODCONV" , "C123" },
                { "CONVEN_CARTAO" , "1234567890123456" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8700_GERA_DEBITO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8700_GERA_DEBITO_DB_SELECT_1_Query1", q101);

                #endregion

                #region M_8700_GERA_DEBITO_DB_INSERT_1_Insert1

                var q102 = new DynamicData();
                q102.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "OPCAOP_AGECTADEB" , "0" },
                { "OPCAOP_OPRCTADEB" , "OPR001" },
                { "OPCAOP_NUMCTADEB" , "123456" },
                { "OPCAOP_DIGCTADEB" , "7" },
                { "HISTCB_DTVENCTO" , "2023-12-20" },
                { "DESCON_VLPREMIO" , "50.00" },
                { "HOST_CODCONV" , "H123" },
                { "OPCAOP_CARTAOCRED" , "4111111111111111" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8700_GERA_DEBITO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8700_GERA_DEBITO_DB_INSERT_1_Insert1", q102);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1

                var q103 = new DynamicData();
                q103.AddDynamic(new Dictionary<string, string>{
                { "FUNDO_PCCOMIND" , "1%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1", q103);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1

                var q104 = new DynamicData();
                q104.AddDynamic(new Dictionary<string, string>{
                { "FUNDO_PCCOMGER" , "1%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1", q104);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1

                var q105 = new DynamicData();
                q105.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODPRODU" , "7706" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "PROPVA_FONTE" , "0" },
                { "PROPVA_AGECOBR" , "001" },
                { "PROPVA_CODCLIEN" , "456789" },
                { "PROPVA_NRMATRVEN" , "123456" },
                { "FUNDO_VALBASVG" , "100000.00" },
                { "FUNDO_VALBASAP" , "50000.00" },
                { "FUNDO_VLCOMISVG" , "500.00" },
                { "FUNDO_VLCOMISAP" , "250.00" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
                { "FUNDO_PCCOMIND" , "1%" },
                { "FUNDO_PCCOMGER" , "1%" },
                { "FUNDO_PCCOMSUP" , "1%" },
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1", q105);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1

                var q106 = new DynamicData();
                q106.AddDynamic(new Dictionary<string, string>{
                { "FUNDO_PCCOMSUP" , "1%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1", q106);

                #endregion

                #region M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1

                var q107 = new DynamicData();
                q107.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , "0.38%" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1", q107);

                #endregion

                #region R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1

                var q108 = new DynamicData();
                q108.AddDynamic(new Dictionary<string, string>{
                { "SIVPF_NR_IDENTIFI" , "ID123456789" },
                { "SIVPF_NR_SICOB" , "SIC123456" },
                { "SIVPF_SIT_PROPOSTA" , "Aprovada" },
                { "SIVPF_DTQITBCO" , "2023-12-15" },
                { "SIVPF_VAL_PAGO" , "200.00" },
                { "SIVPF_DATA_CREDITO" , "2023-12-16" },
                { "SIVPF_OPCAO_COBER" , "Cobertura Total" },
                { "SIVPF_COD_PLANO" , "PLN123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1", q108);

                #endregion

                #region R7773_00_LER_RCAPS_DB_SELECT_1_Query1

                var q109 = new DynamicData();
                q109.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "FNT001" },
                { "RCAPS_NUM_RCAP" , "RC123456" },
                { "RCAPS_VAL_RCAP" , "1500.00" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7773_00_LER_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7773_00_LER_RCAPS_DB_SELECT_1_Query1", q109);

                #endregion

                #region R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1

                var q110 = new DynamicData();
                q110.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , "001" },
                { "RCAPCOMP_AGE_AVISO" , "0001" },
                { "RCAPCOMP_NUM_AVISO_CREDITO" , "987654321" },
                { "RCAPCOMP_DATA_MOVIMENTO" , "2023-12-15" },
                { "RCAPCOMP_DATA_RCAP" , "2023-12-20" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1", q110);

                #endregion

                #region R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1

                var q111 = new DynamicData();
                q111.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SIT_PROP_FIDELIZ" , "Fidelizado" },
                { "WHOST_SITUACAO_ENVIO" , "Enviado" },
                { "SIVPF_DATA_CREDITO" , "2023-12-16" },
                { "SIVPF_OPCAO_COBER" , "Cobertura Total" },
                { "SIVPF_DTQITBCO" , "2023-12-15" },
                { "SIVPF_VAL_PAGO" , "200.00" },
                { "SIVPF_NR_PROPOSTA" , "27708000280671" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1", q111);

                #endregion

                #region R7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1_Update1

                var q112 = new DynamicData();
                q112.AddDynamic(new Dictionary<string, string>{
                { "CONVER_NUM_SICOB" , "SIC123" },
                { "SIVPF_NR_PROPOSTA" , "27708000280671" },
            });
                AppSettings.TestSet.DynamicData.Remove("R7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1_Update1", q112);

                #endregion

                #region M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1

                var q113 = new DynamicData();
                q113.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "PROPVA_NRCERTIF" , "98763456811007445554321" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1", q113);

                #endregion

                #region M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1

                var q114 = new DynamicData();
                q114.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "34568110074455" },
                { "DIFPAR_CODOPER" , "DIF123" },
                { "PROPVA_DTQITBCO" , "2023-12-10" },
                { "COBERP_VLPREMIO" , "2" },
                { "V0HCOB_VLPRMTOT" , "800.00" },
                { "DIFPAR_PRMVG" , "2%" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1", q114);

                #endregion

                #region M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1

                var q115 = new DynamicData();
                q115.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , "6" },
                { "COBERP_PRMAP" , "100" },
                { "PROPVA_NRCERTIF" , "34568110074455" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1", q115);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute();
                var program = new VP0121B();
                program.Execute();

                Assert.True(program.RETURN_CODE != 0);
            }
        }
    }
}