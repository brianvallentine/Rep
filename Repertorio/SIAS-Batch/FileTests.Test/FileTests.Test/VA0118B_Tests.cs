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
using static Code.VA0118B;

namespace FileTests.Test
{
    [Collection("VA0118B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VA0118B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region VA0118B_CSR_RISCO

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_CERTIFICADO_RISCO" , ""},
                { "WS_SIT_REGISTRO_RISCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0118B_CSR_RISCO", q0);

            #endregion

            #region VA0118B_CSR_ERRO_DPS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_CERTIFICADO" , ""},
                { "VG103_SEQ_CRITICA" , ""},
                { "VG103_COD_MSG_CRITICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0118B_CSR_ERRO_DPS", q1);

            #endregion

            #region VA0118B_CSR_ERRO_ACAT

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_CERTIFICADO" , ""},
                { "VG103_SEQ_CRITICA" , ""},
                { "VG103_COD_MSG_CRITICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0118B_CSR_ERRO_ACAT", q2);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , ""},
                { "SISTEMA_CURRDATE" , ""},
                { "SISTEMA_DTMOVABE2" , ""},
                { "SISTEMA_DTMOVABE3" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_0010_LER_TITULO_V0BANCO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0010_LER_TITULO_V0BANCO_DB_SELECT_1_Query1", q4);

            #endregion

            #region VA0118B_CPROPVA

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
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
                { "PROPVA_SITUACAO_ORIGINAL" , ""},
                { "PROPVA_ACATAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0118B_CPROPVA", q5);

            #endregion

            #region M_0010_LER_TITULO_V0BANCO_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0010_LER_TITULO_V0BANCO_DB_UPDATE_1_Update1", q6);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SUBGRU_CODSUBES" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q7);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_0100_NEXT_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_NEXT_DB_UPDATE_1_Update1", q9);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , ""},
                { "CLIENT_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1", q10);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRPROPOS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1", q11);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_PERIPGTO" , ""},
                { "OPCAOP_OPCAOPAG" , ""},
                { "OPCAOP_DIA_DEB" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1", q12);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_OPCAOPAG" , ""},
                { "OPCAOP_PERIPGTO" , ""},
                { "OPCAOP_DIA_DEB" , ""},
                { "OPCAOP_AGECTADEB" , ""},
                { "OPCAOP_OPRCTADEB" , ""},
                { "OPCAOP_NUMCTADEB" , ""},
                { "OPCAOP_DIGCTADEB" , ""},
                { "OPCAOP_CARTAOCRED" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1", q13);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1", q14);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0AGCEF_COD_AGCOBR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1", q15);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0COBER_MINOCOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1", q16);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_UPDATE_2_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_DTPROXVEN" , ""},
                { "PROPVA_CODPRODU" , ""},
                { "PROPVA_SITUACAO" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_CODOPER" , ""},
                { "MDTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_UPDATE_2_Update1", q17);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1", q18);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1", q19);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1", q20);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_11_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_11_Query1", q21);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_12_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , ""},
                { "RELATO_CODSUBES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_12_Query1", q22);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_13_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , ""},
                { "RELATO_CODSUBES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_13_Query1", q23);

            #endregion

            #region M_0115_00_CONS_ERRO_DPS_FECHADO_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "WS_STA_CRITICA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0115_00_CONS_ERRO_DPS_FECHADO_DB_SELECT_1_Query1", q24);

            #endregion

            #region M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""},
                { "WHOST_PROXIMA_DATA" , ""},
                { "CALENDAR_DIA_SEMANA" , ""},
                { "CALENDAR_FERIADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1", q25);

            #endregion

            #region M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "RELATO_CODRELAT" , ""},
                { "PROPVA_NUM_APOLICE" , ""},
                { "RELATO_NRPARCEL" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "RELATO_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1", q26);

            #endregion

            #region M_0255_00_ACESSA_PROPOSTA_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_COD_PRODUTO_SIVPF" , ""},
                { "PROPOFID_AGECTADEB" , ""},
                { "PROPOFID_OPRCTADEB" , ""},
                { "PROPOFID_NUMCTADEB" , ""},
                { "PROPOFID_DIGCTADEB" , ""},
                { "PROPOFID_VAL_PAGO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0255_00_ACESSA_PROPOSTA_DB_SELECT_1_Query1", q27);

            #endregion

            #region M_0256_RECUPERA_PRODUTO_SIVPF_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_COD_PRODUTO_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0256_RECUPERA_PRODUTO_SIVPF_DB_SELECT_1_Query1", q28);

            #endregion

            #region VA0118B_V1RCAPCOMP

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("VA0118B_V1RCAPCOMP", q29);

            #endregion

            #region M_0282_00_VERIFICA_PU_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_PERI_PAGAMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0282_00_VERIFICA_PU_DB_SELECT_1_Query1", q30);

            #endregion

            #region M_0282_00_VERIFICA_PU_DB_SELECT_2_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0282_00_VERIFICA_PU_DB_SELECT_2_Query1", q31);

            #endregion

            #region M_0283_00_VERIFICA_VIGENCIA_DB_SELECT_1_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_DATA_INIVIGENCIA" , ""},
                { "APOLICOB_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0283_00_VERIFICA_VIGENCIA_DB_SELECT_1_Query1", q32);

            #endregion

            #region M_0284_00_SOMA_IS_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_IMP_MORNATU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0284_00_SOMA_IS_DB_SELECT_1_Query1", q33);

            #endregion

            #region M_0300_VERIFICA_CROT_DB_SELECT_1_Query1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_CGCCPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_VERIFICA_CROT_DB_SELECT_1_Query1", q34);

            #endregion

            #region M_0300_VERIFICA_CROT_DB_SELECT_2_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "CLIROT_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_VERIFICA_CROT_DB_SELECT_2_Query1", q35);

            #endregion

            #region M_0320_UPDATE_CROT_DB_UPDATE_1_Update1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "CLIROT_DTMOVABE" , ""},
                { "CLIENT_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0320_UPDATE_CROT_DB_UPDATE_1_Update1", q36);

            #endregion

            #region M_0330_INCLUI_CROT_DB_INSERT_1_Insert1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_CGCCPF" , ""},
                { "SISTEMA_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0330_INCLUI_CROT_DB_INSERT_1_Insert1", q37);

            #endregion

            #region R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "V0FOLHM_DTEMICAR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1", q38);

            #endregion

            #region R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V0FOLH_COD_CARTA" , ""},
                { "V0FOLH_DTEMICAR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1", q39);

            #endregion

            #region M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V0FOLH_COD_PRODUTO" , ""},
                { "V0FOLH_NRCERTIF" , ""},
                { "V0FOLH_COD_CARTA" , ""},
                { "V0FOLH_DTEMICAR" , ""},
                { "V0FOLH_DTSOLICIT" , ""},
                { "V0FOLH_CODUSU" , ""},
                { "V0FOLH_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1", q40);

            #endregion

            #region M_0550_00_REALIZA_DEVOLUCAO_DB_SELECT_1_Query1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0550_00_REALIZA_DEVOLUCAO_DB_SELECT_1_Query1", q41);

            #endregion

            #region M_0555_00_ATUALIZA_RELATORIOS_DB_UPDATE_1_Update1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "RELATO_CODRELAT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0555_00_ATUALIZA_RELATORIOS_DB_UPDATE_1_Update1", q42);

            #endregion

            #region M_0560_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , ""},
                { "RELATO_CODRELAT" , ""},
                { "RELATO_NUM_COPIAS" , ""},
                { "WS_BCO_RELAT" , ""},
                { "PROPOFID_AGECTADEB" , ""},
                { "PROPOFID_OPRCTADEB" , ""},
                { "PROPOFID_DIGCTADEB" , ""},
                { "PROPVA_NUM_APOLICE" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPOFID_NUMCTADEB" , ""},
                { "WS_NUM_ORDEM_RELAT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0560_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1", q43);

            #endregion

            #region M_0580_00_DECLINA_PROPOSTA_DB_UPDATE_1_Update1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_SITUACAO_ENVIO" , ""},
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0580_00_DECLINA_PROPOSTA_DB_UPDATE_1_Update1", q44);

            #endregion

            #region M_0590_00_ATUALIZA_PROPOSTAS_VA_DB_UPDATE_1_Update1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , ""},
                { "PROPVA_SITUACAO" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0590_00_ATUALIZA_PROPOSTAS_VA_DB_UPDATE_1_Update1", q45);

            #endregion

            #region M_0600_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "VG078_NUM_CERTIFICADO" , ""},
                { "VG078_DES_ANDAMENTO" , ""},
                { "VG078_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0600_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1", q46);

            #endregion

            #region M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "CONVER_NUM_SICOB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1", q47);

            #endregion

            #region M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , ""},
                { "V0RCAP_NRRCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1", q48);

            #endregion

            #region M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , ""},
                { "V0RCAP_NRRCAP" , ""},
                { "V0RCAP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1", q49);

            #endregion

            #region M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_BCOAVISO" , ""},
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
                { "V1RCAC_DATARCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1", q50);

            #endregion

            #region VA0118B_CBENEFP

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>{
                { "BENEF_NOMBENEF" , ""},
                { "BENEF_GRAUPAR" , ""},
                { "BENEF_PCTBENEF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0118B_CBENEFP", q51);

            #endregion

            #region M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_NRRCAPCO" , ""},
                { "V1RCAC_OPERACAO" , ""},
                { "V1RCAC_HORAOPER" , ""},
                { "V1RCAC_DTMOVTO" , ""},
                { "V1RCAC_NRRCAP" , ""},
                { "V1RCAC_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1", q52);

            #endregion

            #region M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1", q53);

            #endregion

            #region M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1

            var q54 = new DynamicData();
            q54.AddDynamic(new Dictionary<string, string>{
                { "V1RCAC_VLRCAP" , ""},
                { "V1RCAC_BCOAVISO" , ""},
                { "V1RCAC_AGEAVISO" , ""},
                { "V1RCAC_NRAVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1", q54);

            #endregion

            #region M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1

            var q55 = new DynamicData();
            q55.AddDynamic(new Dictionary<string, string>{
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
                { "PRODVG_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1", q55);

            #endregion

            #region M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1

            var q56 = new DynamicData();
            q56.AddDynamic(new Dictionary<string, string>{
                { "MTXVG" , ""},
                { "MTXAPMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1", q56);

            #endregion

            #region M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1

            var q57 = new DynamicData();
            q57.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODSUBES" , ""},
                { "MTXAPMA" , ""},
                { "MTXAPIP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1", q57);

            #endregion

            #region M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1

            var q58 = new DynamicData();
            q58.AddDynamic(new Dictionary<string, string>{
                { "APCORR_RAMO" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "APCORR_DTINIVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1", q58);

            #endregion

            #region M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1

            var q59 = new DynamicData();
            q59.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1", q59);

            #endregion

            #region R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1

            var q60 = new DynamicData();
            q60.AddDynamic(new Dictionary<string, string>{
                { "COMFEDCA_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1", q60);

            #endregion

            #region R6290_10_INSERT_DB_INSERT_1_Insert1

            var q61 = new DynamicData();
            q61.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_FONTE" , ""},
                { "SISTEMA_DTMOVABE" , ""},
                { "MOVFEDCA_VAL_CUSTO_CAPITALI" , ""},
                { "MOVFEDCA_NRTITFDCAP" , ""},
                { "PRODVG_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6290_10_INSERT_DB_INSERT_1_Insert1", q61);

            #endregion

            #region R6300_00_INSERT_DB_INSERT_1_Insert1

            var q62 = new DynamicData();
            q62.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_NRTITFDCAP" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "TITFEDCA_DATA_INIVIGENCIA" , ""},
                { "TITFEDCA_DATA_TERVIGENCIA" , ""},
                { "TITFEDCA_NRSORTEIO" , ""},
                { "TITFEDCA_VAL_CUSTO_TITULO" , ""},
                { "SISTEMA_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6300_00_INSERT_DB_INSERT_1_Insert1", q62);

            #endregion

            #region R6400_10_INSERT_DB_INSERT_1_Insert1

            var q63 = new DynamicData();
            q63.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "SISTEMA_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6400_10_INSERT_DB_INSERT_1_Insert1", q63);

            #endregion

            #region R6500_10_INSERT_DB_INSERT_1_Insert1

            var q64 = new DynamicData();
            q64.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_NRTITFDCAP" , ""},
                { "PARFEDCA_VAL_CUSTO_TITULO" , ""},
                { "SISTEMA_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6500_10_INSERT_DB_INSERT_1_Insert1", q64);

            #endregion

            #region R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1

            var q65 = new DynamicData();
            q65.AddDynamic(new Dictionary<string, string>{
                { "COMFEDCA_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1", q65);

            #endregion

            #region R7400_10_INSERT_DB_INSERT_1_Insert1

            var q66 = new DynamicData();
            q66.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "SISTEMA_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7400_10_INSERT_DB_INSERT_1_Insert1", q66);

            #endregion

            #region M_8000_INTEGRA_VG_DB_SELECT_1_Query1

            var q67 = new DynamicData();
            q67.AddDynamic(new Dictionary<string, string>{
                { "CONDTE_IEA" , ""},
                { "CONDTE_IPA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_1_Query1", q67);

            #endregion

            #region R8000_PROPAUTOM_DB_INSERT_1_Insert1

            var q68 = new DynamicData();
            q68.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_INSERT_1_Insert1", q68);

            #endregion

            #region R8000_PROPAUTOM_DB_UPDATE_1_Update1

            var q69 = new DynamicData();
            q69.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""},
                { "PROPVA_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_1_Update1", q69);

            #endregion

            #region M_8000_INTEGRA_VG_DB_SELECT_2_Query1

            var q70 = new DynamicData();
            q70.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_2_Query1", q70);

            #endregion

            #region R8000_PROPAUTOM_DB_UPDATE_2_Update1

            var q71 = new DynamicData();
            q71.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_2_Update1", q71);

            #endregion

            #region R8000_PROPAUTOM_DB_SELECT_1_Query1

            var q72 = new DynamicData();
            q72.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_VLPRMTOT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_SELECT_1_Query1", q72);

            #endregion

            #region R8000_PROPAUTOM_DB_UPDATE_3_Update1

            var q73 = new DynamicData();
            q73.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_3_Update1", q73);

            #endregion

            #region M_8000_INTEGRA_VG_DB_SELECT_3_Query1

            var q74 = new DynamicData();
            q74.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , ""},
                { "MTXVG" , ""},
                { "MTXAPMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_3_Query1", q74);

            #endregion

            #region R8000_PROPAUTOM_DB_SELECT_2_Query1

            var q75 = new DynamicData();
            q75.AddDynamic(new Dictionary<string, string>{
                { "COMISI_VALADT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_SELECT_2_Query1", q75);

            #endregion

            #region R8000_PROPAUTOM_DB_UPDATE_4_Update1

            var q76 = new DynamicData();
            q76.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_4_Update1", q76);

            #endregion

            #region M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1

            var q77 = new DynamicData();
            q77.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1", q77);

            #endregion

            #region R8000_PROPAUTOM_DB_UPDATE_5_Update1

            var q78 = new DynamicData();
            q78.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8000_PROPAUTOM_DB_UPDATE_5_Update1", q78);

            #endregion

            #region M_8000_INTEGRA_VG_DB_SELECT_4_Query1

            var q79 = new DynamicData();
            q79.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , ""},
                { "MTXVG" , ""},
                { "MTXAPMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_4_Query1", q79);

            #endregion

            #region M_8000_INTEGRA_VG_DB_SELECT_5_Query1

            var q80 = new DynamicData();
            q80.AddDynamic(new Dictionary<string, string>{
                { "MFAIXA" , ""},
                { "MTXVG" , ""},
                { "MTXAPMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_5_Query1", q80);

            #endregion

            #region VA0118B_C01_RCAPCOMP

            var q81 = new DynamicData();
            q81.AddDynamic(new Dictionary<string, string>{
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_BCO_AVISO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_AGE_AVISO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_RCAP" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0118B_C01_RCAPCOMP", q81);

            #endregion

            #region M_8000_INTEGRA_VG_DB_SELECT_6_Query1

            var q82 = new DynamicData();
            q82.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA_MOVIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8000_INTEGRA_VG_DB_SELECT_6_Query1", q82);

            #endregion

            #region M_8100_LOOP_DB_INSERT_1_Insert1

            var q83 = new DynamicData();
            q83.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_FONTE" , ""},
                { "FONTE_PROPAUTOM" , ""},
                { "BENEF_NRBENEF" , ""},
                { "BENEF_NOMBENEF" , ""},
                { "BENEF_GRAUPAR" , ""},
                { "BENEF_PCTBENEF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8100_LOOP_DB_INSERT_1_Insert1", q83);

            #endregion

            #region M_8120_INICIO_VERIFICA_DB_SELECT_1_Query1

            var q84 = new DynamicData();
            q84.AddDynamic(new Dictionary<string, string>{
                { "PROPAUTOM_BENEFI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8120_INICIO_VERIFICA_DB_SELECT_1_Query1", q84);

            #endregion

            #region M_8200_CONCEDE_CDG_DB_SELECT_1_Query1

            var q85 = new DynamicData();
            q85.AddDynamic(new Dictionary<string, string>{
                { "CDGCOB_DTINIVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8200_CONCEDE_CDG_DB_SELECT_1_Query1", q85);

            #endregion

            #region M_8200_CONCEDE_CDG_DB_SELECT_2_Query1

            var q86 = new DynamicData();
            q86.AddDynamic(new Dictionary<string, string>{
                { "REPCDG_DTREF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8200_CONCEDE_CDG_DB_SELECT_2_Query1", q86);

            #endregion

            #region M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1

            var q87 = new DynamicData();
            q87.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1", q87);

            #endregion

            #region M_8220_INCLUI_CDG_DB_INSERT_1_Insert1

            var q88 = new DynamicData();
            q88.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , ""},
                { "PROPVA_DTINICDG" , ""},
                { "COBERP_IMPSEGCDG" , ""},
                { "COBERP_VLCUSTCDG" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8220_INCLUI_CDG_DB_INSERT_1_Insert1", q88);

            #endregion

            #region M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1

            var q89 = new DynamicData();
            q89.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , ""},
                { "REPCDG_DTREF" , ""},
                { "COBERP_VLCUSTCDG" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "SISTEMA_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1", q89);

            #endregion

            #region M_8300_CONCEDE_SAF_DB_SELECT_1_Query1

            var q90 = new DynamicData();
            q90.AddDynamic(new Dictionary<string, string>{
                { "SAFCOB_DTINIVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8300_CONCEDE_SAF_DB_SELECT_1_Query1", q90);

            #endregion

            #region M_8300_CONCEDE_SAF_DB_SELECT_2_Query1

            var q91 = new DynamicData();
            q91.AddDynamic(new Dictionary<string, string>{
                { "REPSAF_DTREF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8300_CONCEDE_SAF_DB_SELECT_2_Query1", q91);

            #endregion

            #region M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1

            var q92 = new DynamicData();
            q92.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1", q92);

            #endregion

            #region M_8320_INCLUI_SAF_DB_INSERT_1_Insert1

            var q93 = new DynamicData();
            q93.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , ""},
                { "PROPVA_DTINISAF" , ""},
                { "COBERP_IMPSEGAUXF" , ""},
                { "COBERP_VLCUSTAUXF" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8320_INCLUI_SAF_DB_INSERT_1_Insert1", q93);

            #endregion

            #region M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1

            var q94 = new DynamicData();
            q94.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , ""},
                { "REPSAF_DTREF" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_NRMATRFUN" , ""},
                { "COBERP_VLCUSTAUXF" , ""},
                { "PROPVA_CODOPER" , ""},
                { "PROPVA_DTQITBCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1", q94);

            #endregion

            #region M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1

            var q95 = new DynamicData();
            q95.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , ""},
                { "REPSAF_DTREF" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_NRMATRFUN" , ""},
                { "COBERP_VLCUSTAUXF" , ""},
                { "PROPVA_DTQITBCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1", q95);

            #endregion

            #region M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1

            var q96 = new DynamicData();
            q96.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1", q96);

            #endregion

            #region M_8590_00_GRAVA_ANDAMENTO_PROP_DB_SELECT_1_Query1

            var q97 = new DynamicData();
            q97.AddDynamic(new Dictionary<string, string>{
                { "WS_QTD_RISCO_GRAVADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8590_00_GRAVA_ANDAMENTO_PROP_DB_SELECT_1_Query1", q97);

            #endregion

            #region M_8595_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1

            var q98 = new DynamicData();
            q98.AddDynamic(new Dictionary<string, string>{
                { "WS_ERRO_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8595_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1", q98);

            #endregion

            #region M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1

            var q99 = new DynamicData();
            q99.AddDynamic(new Dictionary<string, string>{
                { "W03_VENCIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1", q99);

            #endregion

            #region M_8600_10_CONTINUA_DB_SELECT_1_Query1

            var q100 = new DynamicData();
            q100.AddDynamic(new Dictionary<string, string>{
                { "DESCON_PERC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_SELECT_1_Query1", q100);

            #endregion

            #region M_8600_10_CONTINUA_DB_INSERT_1_Insert1

            var q101 = new DynamicData();
            q101.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "HISTCB_DTVENCTO" , ""},
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "OPCAOP_OPCAOPAG" , ""},
                { "PARCEL_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8600_10_CONTINUA_DB_INSERT_1_Insert1", q101);

            #endregion

            #region M_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_1_Insert1

            var q102 = new DynamicData();
            q102.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "BANCOS_NRTIT" , ""},
                { "HISTCB_DTVENCTO" , ""},
                { "DESCON_VLPREMIO" , ""},
                { "OPCAOP_OPCAOPAG" , ""},
                { "HISTCB_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_1_Insert1", q102);

            #endregion

            #region M_8600_CONTINUA_DB_UPDATE_1_Update1

            var q103 = new DynamicData();
            q103.AddDynamic(new Dictionary<string, string>{
                { "HISTCB_DTVENCTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8600_CONTINUA_DB_UPDATE_1_Update1", q103);

            #endregion

            #region M_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_2_Insert1

            var q104 = new DynamicData();
            q104.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "HISTCB_DTVENCTO" , ""},
                { "DESCON_PRMVG" , ""},
                { "DESCON_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_2_Insert1", q104);

            #endregion

            #region M_8605_00_VERIFICA_TP_MENS_DB_SELECT_1_Query1

            var q105 = new DynamicData();
            q105.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_TP_MSG_CRITICA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8605_00_VERIFICA_TP_MENS_DB_SELECT_1_Query1", q105);

            #endregion

            #region M_8700_GERA_DEBITO_DB_SELECT_1_Query1

            var q106 = new DynamicData();
            q106.AddDynamic(new Dictionary<string, string>{
                { "CONVEN_CODCONV" , ""},
                { "CONVEN_CARTAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8700_GERA_DEBITO_DB_SELECT_1_Query1", q106);

            #endregion

            #region M_8700_GERA_DEBITO_DB_INSERT_1_Insert1

            var q107 = new DynamicData();
            q107.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("M_8700_GERA_DEBITO_DB_INSERT_1_Insert1", q107);

            #endregion

            #region M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1

            var q108 = new DynamicData();
            q108.AddDynamic(new Dictionary<string, string>{
                { "FUNDO_PCCOMIND" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1", q108);

            #endregion

            #region M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1

            var q109 = new DynamicData();
            q109.AddDynamic(new Dictionary<string, string>{
                { "FUNDO_PCCOMGER" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1", q109);

            #endregion

            #region M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1

            var q110 = new DynamicData();
            q110.AddDynamic(new Dictionary<string, string>{
                { "FUNDO_PCCOMSUP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1", q110);

            #endregion

            #region M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1

            var q111 = new DynamicData();
            q111.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1", q111);

            #endregion

            #region M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1

            var q112 = new DynamicData();
            q112.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1", q112);

            #endregion

            #region R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1

            var q113 = new DynamicData();
            q113.AddDynamic(new Dictionary<string, string>{
                { "SIVPF_NR_IDENTIFI" , ""},
                { "SIVPF_NR_SICOB" , ""},
                { "SIVPF_SIT_PROPOSTA" , ""},
                { "SIVPF_DTQITBCO" , ""},
                { "SIVPF_VAL_PAGO" , ""},
                { "SIVPF_DATA_CREDITO" , ""},
                { "SIVPF_OPCAO_COBER" , ""},
                { "SIVPF_COD_PLANO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1", q113);

            #endregion

            #region M_8800_APROPRIA_FUNDO_DB_SELECT_5_Query1

            var q114 = new DynamicData();
            q114.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_PCIOF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_8800_APROPRIA_FUNDO_DB_SELECT_5_Query1", q114);

            #endregion

            #region R7773_00_LER_RCAPS_DB_SELECT_1_Query1

            var q115 = new DynamicData();
            q115.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7773_00_LER_RCAPS_DB_SELECT_1_Query1", q115);

            #endregion

            #region R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1

            var q116 = new DynamicData();
            q116.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1", q116);

            #endregion

            #region R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1

            var q117 = new DynamicData();
            q117.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SIT_PROP_FIDELIZ" , ""},
                { "WHOST_SITUACAO_ENVIO" , ""},
                { "SIVPF_DATA_CREDITO" , ""},
                { "SIVPF_OPCAO_COBER" , ""},
                { "SIVPF_DTQITBCO" , ""},
                { "SIVPF_VAL_PAGO" , ""},
                { "SIVPF_NR_PROPOSTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1", q117);

            #endregion

            #region M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1

            var q118 = new DynamicData();
            q118.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1", q118);

            #endregion

            #region M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1

            var q119 = new DynamicData();
            q119.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "DIFPAR_CODOPER" , ""},
                { "PROPVA_DTQITBCO" , ""},
                { "COBERP_VLPREMIO" , ""},
                { "V0HCOB_VLPRMTOT" , ""},
                { "DIFPAR_PRMVG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1", q119);

            #endregion

            #region M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1

            var q120 = new DynamicData();
            q120.AddDynamic(new Dictionary<string, string>{
                { "COBERP_PRMVG" , ""},
                { "COBERP_PRMAP" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1", q120);

            #endregion

            #endregion
        }

        [Fact]
        public static void VA0118B_Tests_Fact()
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
                #endregion
                var program = new VA0118B();
                program.Execute();

                Assert.True(true);
            }
        }
    }
}