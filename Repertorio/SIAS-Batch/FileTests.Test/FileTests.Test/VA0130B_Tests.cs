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
using static Code.VA0130B;

namespace FileTests.Test
{
    [Collection("VA0130B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0130B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0010_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , ""},
                { "SISTEMA_CURRENT" , ""},
                { "SISTEMA_DTTERCOT" , ""},
                { "SISTEMA_DTINICOT" , ""},
                { "SISTEMA_DTMOV01M" , ""},
                { "SISTEMA_DTMOV20D" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0010_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0010_SELECT_SISTEMAS_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , ""},
                { "SISTEMA_CURRENT" , ""},
                { "SISTEMA_DTTERCOT" , ""},
                { "SISTEMA_DTINICOT" , ""},
                { "SISTEMA_DTMOV01M" , ""},
                { "SISTEMA_DTMOV20D" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0010_SELECT_SISTEMAS_DB_SELECT_2_Query1", q1);

            #endregion

            #region VA0130B_V0COTACAO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "COTACAO_DTINIVIG" , ""},
                { "COTACAO_VAL_VENDA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0130B_V0COTACAO", q2);

            #endregion

            #region VA0130B_CPROPVA

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_TEM_ANTECIP" , ""},
                { "PROPVA_NUM_APOLICE" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_CODCLIEN" , ""},
                { "PROPVA_OCOREND" , ""},
                { "PROPVA_FONTE" , ""},
                { "PROPVA_AGECOBR" , ""},
                { "PROPVA_OPCAO_COBER" , ""},
                { "PROPVA_DTPROXVEN" , ""},
                { "PROPVA_DTPROXVEN_1" , ""},
                { "PROPVA_NRPARCEL" , ""},
                { "PROPVA_CODOPER" , ""},
                { "PROPVA_DTMOVTO" , ""},
                { "PROPVA_OCORHIST" , ""},
                { "PROPVA_SIT_INTERF" , ""},
                { "PROPVA_TIMESTAMP" , ""},
                { "PROPVA_SEXO" , ""},
                { "PROPVA_EST_CIV" , ""},
                { "PROPVA_DTQITBCO_1YEAR" , ""},
                { "PROPVA_DTQITBCO" , ""},
                { "PROPVA_IDADE" , ""},
                { "PROPVA_CODPRODU" , ""},
                { "PROPVA_STA_ANTECIPACAO" , ""},
                { "PROPVA_STA_MUDANCA_PLANO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0130B_CPROPVA", q3);

            #endregion

            #region M_0010_SELECT_SISTEMAS_DB_SELECT_3_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0010_SELECT_SISTEMAS_DB_SELECT_3_Query1", q4);

            #endregion

            #region M_0010_SELECT_SISTEMAS_DB_SELECT_4_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0010_SELECT_SISTEMAS_DB_SELECT_4_Query1", q5);

            #endregion

            #region M_0040_SELECT_VG_INDICE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "VG077_COD_MOEDA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0040_SELECT_VG_INDICE_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_0045_SELECT_COTACAO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "COTACAO_DTINIVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0045_SELECT_COTACAO_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_0050_DATA_ENCERRAMENTO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0050_DATA_ENCERRAMENTO_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_PERIPGTO" , ""},
                { "OPCAOP_AGECTADEB" , ""},
                { "OPCAOP_OPRCTADEB" , ""},
                { "OPCAOP_NUMCTADEB" , ""},
                { "OPCAOP_DIGCTADEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1", q9);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "SEGURA_NUM_ITEM" , ""},
                { "SEGURA_FAIXA" , ""},
                { "SEGURA_TXVG" , ""},
                { "SEGURA_TXAPMA" , ""},
                { "SEGURA_TXAPIP" , ""},
                { "SEGURA_TXAPAMDS" , ""},
                { "SEGURA_TXAPDH" , ""},
                { "SEGURA_TXAPDIT" , ""},
                { "SEGURA_SIT_REGISTRO" , ""},
                { "SEGURA_LOT_EMP_SEGURADO" , ""},
                { "SEGURA_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1", q10);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "HISTSG_DTMOVTO_DTTERVIG" , ""},
                { "HISTSG_DTMOVTO_1DAY" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1", q11);

            #endregion

            #region VA0130B_VGHISRAMC

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "VGHISR_NRCERTIF" , ""},
                { "VGHISR_NUM_RAMO" , ""},
                { "VGHISR_NUM_COBERTURA" , ""},
                { "VGHISR_QTD_COBERTURA" , ""},
                { "VGHISR_IMPSEGURADA" , ""},
                { "VGHISR_CUSTO" , ""},
                { "VGHISR_PREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0130B_VGHISRAMC", q12);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "HISTSG_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1", q13);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "HISTSG_DTMOVTO_1YEAR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1", q14);

            #endregion

            #region M_0110_FETCH_PROPOSTAS_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "PRODVG_TEM_IGPM" , ""},
                { "PRODVG_TEM_FAIXAETA" , ""},
                { "PRODVG_RAMO" , ""},
                { "PRODVG_COBERADIC_PREMIO" , ""},
                { "PRODVG_CUSTOCAP_TOTAL" , ""},
                { "PRODVG_TEM_CDG" , ""},
                { "PRODVG_TEM_SAF" , ""},
                { "PRODVG_COD_PRODUTO" , ""},
                { "PRODVG_NOME_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_PROPOSTAS_DB_SELECT_1_Query1", q15);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1", q16);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1", q17);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "MIMP_MORNATU_ATU" , ""},
                { "MIMP_MORACID_ATU" , ""},
                { "MPRM_VG_ATU" , ""},
                { "MPRM_AP_ATU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1", q18);

            #endregion

            #region M_0120_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "COBERP_IMPSEGUR_ANT" , ""},
                { "COBERP_QUANT_VIDAS_ANT" , ""},
                { "COBERP_IMPSEGIND_ANT" , ""},
                { "COBERP_OPCAO_COBER_ANT" , ""},
                { "COBERP_IMPMORNATU_ANT" , ""},
                { "COBERP_IMPMORACID_ANT" , ""},
                { "COBERP_IMPINVPERM_ANT" , ""},
                { "COBERP_IMPAMDS_ANT" , ""},
                { "COBERP_IMPDH_ANT" , ""},
                { "COBERP_IMPDIT_ANT" , ""},
                { "COBERP_VLPREMIO_ANT" , ""},
                { "COBERP_PRMVG_ANT" , ""},
                { "COBERP_PRMAP_ANT" , ""},
                { "COBERP_QTTITCAP" , ""},
                { "COBERP_VLTITCAP" , ""},
                { "COBERP_VLCUSTCAP" , ""},
                { "COBERP_IMPSEGCDG" , ""},
                { "COBERP_VLCUSTCDG" , ""},
                { "COBERP_IMPSEGAUXF" , ""},
                { "COBERP_VLCUSTAUXF" , ""},
                { "COBERP_PRMDIT_ANT" , ""},
                { "COBERP_QTDIT" , ""},
                { "COBERP_DTINIVIG_ANT" , ""},
                { "COBERP_DTINIVIG_NEW" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0120_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1", q19);

            #endregion

            #region M_0130_VERIFICA_MUDANCA_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "PLAVAVGA_IDADE_FINAL" , ""},
                { "PLAVAVGA_TAXAAP" , ""},
                { "PLAVAVGA_FAIXA" , ""},
                { "PLAVAVGA_PCT_FAIXA_ETARIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0130_VERIFICA_MUDANCA_DB_SELECT_1_Query1", q20);

            #endregion

            #region M_0130_VERIFICA_MUDANCA_DB_SELECT_2_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "PLAVAVGA_IDADE_FINAL" , ""},
                { "PLAVAVGA_TAXAAP" , ""},
                { "PLAVAVGA_FAIXA" , ""},
                { "PLAVAVGA_PCT_FAIXA_ETARIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0130_VERIFICA_MUDANCA_DB_SELECT_2_Query1", q21);

            #endregion

            #region M_0300_CORRIGE_IGPM_DB_UPDATE_1_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "COBERP_DTINIVIG" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_CORRIGE_IGPM_DB_UPDATE_1_Update1", q22);

            #endregion

            #region M_0300_PROPAUTOM_DB_INSERT_1_Insert1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_FONTE" , ""},
                { "FONTE_PROPAUTOM" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_CODCLIEN" , ""},
                { "SEGURA_FAIXA" , ""},
                { "OPCAOP_PERIPGTO" , ""},
                { "PROPVA_EST_CIV" , ""},
                { "PROPVA_SEXO" , ""},
                { "PROPVA_AGECOBR" , ""},
                { "MNUM_CTA_CORRENTE" , ""},
                { "MDAC_CTA_CORRENTE" , ""},
                { "SEGURA_TXAPMA" , ""},
                { "SEGURA_TXAPIP" , ""},
                { "SEGURA_TXAPAMDS" , ""},
                { "SEGURA_TXAPDH" , ""},
                { "SEGURA_TXAPDIT" , ""},
                { "SEGURA_TXVG" , ""},
                { "COBERP_IMPMORNATU_ANT" , ""},
                { "COBERP_IMPMORNATU_ATU" , ""},
                { "COBERP_IMPMORACID_ANT" , ""},
                { "COBERP_IMPMORACID_ATU" , ""},
                { "COBERP_IMPINVPERM_ANT" , ""},
                { "COBERP_IMPINVPERM_ATU" , ""},
                { "COBERP_IMPAMDS_ANT" , ""},
                { "COBERP_IMPAMDS_ATU" , ""},
                { "COBERP_IMPDH_ANT" , ""},
                { "COBERP_IMPDH_ATU" , ""},
                { "COBERP_IMPDIT_ANT" , ""},
                { "COBERP_IMPDIT_ATU" , ""},
                { "COBERP_PRMVG_ANT" , ""},
                { "COBERP_PRMVG_ATU" , ""},
                { "COBERP_PRMAP_ANT" , ""},
                { "COBERP_PRMAP_ATU" , ""},
                { "SISTEMA_DTMOVABE" , ""},
                { "CLIENT_DTNASC" , ""},
                { "SISTEMA_DTMAXALTIGPM" , ""},
                { "COBERP_DTINIVIG" , ""},
                { "SEGURA_LOT_EMP_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_PROPAUTOM_DB_INSERT_1_Insert1", q23);

            #endregion

            #region M_0300_PROPAUTOM_DB_UPDATE_1_Update1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""},
                { "PROPVA_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_PROPAUTOM_DB_UPDATE_1_Update1", q24);

            #endregion

            #region M_0300_CORRIGE_IGPM_DB_INSERT_1_Insert1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_OCORHIST" , ""},
                { "COBERP_DTINIVIG" , ""},
                { "COBERP_IMPMORNATU_ATU" , ""},
                { "PROPVA_OPCAO_COBER" , ""},
                { "COBERP_IMPMORACID_ATU" , ""},
                { "COBERP_IMPINVPERM_ATU" , ""},
                { "COBERP_IMPAMDS_ATU" , ""},
                { "COBERP_IMPDH_ATU" , ""},
                { "COBERP_IMPDIT_ATU" , ""},
                { "COBERP_VLPREMIO_ATU" , ""},
                { "COBERP_PRMVG_ATU" , ""},
                { "COBERP_PRMAP_ATU" , ""},
                { "COBERP_QTTITCAP" , ""},
                { "COBERP_VLTITCAP" , ""},
                { "COBERP_VLCUSTCAP" , ""},
                { "COBERP_IMPSEGCDG" , ""},
                { "COBERP_VLCUSTCDG" , ""},
                { "COBERP_IMPSEGAUXF" , ""},
                { "COBERP_VLCUSTAUXF" , ""},
                { "COBERP_PRMDIT_ATU" , ""},
                { "COBERP_QTDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_CORRIGE_IGPM_DB_INSERT_1_Insert1", q25);

            #endregion

            #region M_0300_CORRIGE_IGPM_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_CORRIGE_IGPM_DB_SELECT_1_Query1", q26);

            #endregion

            #region M_0300_CORRIGE_IGPM_DB_UPDATE_2_Update1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , ""},
                { "PROPVA_OCORHIST" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_CORRIGE_IGPM_DB_UPDATE_2_Update1", q27);

            #endregion

            #region M_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "COBERP_NRCERTIF" , ""},
                { "COBERP_OCORHIST" , ""},
                { "COBERP_DTINIVIG" , ""},
                { "COBERP_DTTERVIG" , ""},
                { "COBERP_IMPSEGUR" , ""},
                { "COBERP_QUANT_VIDAS" , ""},
                { "COBERP_IMPSEGIND" , ""},
                { "COBERP_CODOPER" , ""},
                { "COBERP_OPCAO_COBER" , ""},
                { "COBERP_IMPMORNATU_ATU" , ""},
                { "COBERP_IMPMORACID_ATU" , ""},
                { "COBERP_IMPINVPERM_ATU" , ""},
                { "COBERP_IMPAMDS_ATU" , ""},
                { "COBERP_IMPDH_ATU" , ""},
                { "COBERP_IMPDIT_ATU" , ""},
                { "COBERP_VLPREMIO_ATU" , ""},
                { "COBERP_PRMVG_ATU" , ""},
                { "COBERP_PRMAP_ATU" , ""},
                { "COBERP_QTTITCAP" , ""},
                { "COBERP_VLTITCAP" , ""},
                { "COBERP_VLCUSTCAP" , ""},
                { "COBERP_IMPSEGCDG" , ""},
                { "COBERP_VLCUSTCDG" , ""},
                { "COBERP_IMPSEGAUXF" , ""},
                { "COBERP_VLCUSTAUXF" , ""},
                { "COBERP_PRMDIT_ATU" , ""},
                { "COBERP_QTDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1", q28);

            #endregion

            #region VA0130B_VGHISTACE

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "VGHISA_NRCERTIF" , ""},
                { "VGHISA_NUM_ACESSORIO" , ""},
                { "VGHISA_QTD_COBERTURA" , ""},
                { "VGHISA_IMPSEGURADA" , ""},
                { "VGHISA_CUSTO" , ""},
                { "VGHISA_PREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0130B_VGHISTACE", q29);

            #endregion

            #region M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1_Insert1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "VGHISR_NRCERTIF" , ""},
                { "COBERP_OCORHIST" , ""},
                { "VGHISR_NUM_RAMO" , ""},
                { "VGHISR_NUM_COBERTURA" , ""},
                { "VGHISR_QTD_COBERTURA" , ""},
                { "VGHISR_IMPSEGURADA" , ""},
                { "VGHISR_CUSTO" , ""},
                { "VGHISR_PREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1_Insert1", q30);

            #endregion

            #region VA0130B_VGPLAACES

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "VGPLAA_NUM_ACESSORIO" , ""},
                { "VGPLAA_QTD_COBERTURA" , ""},
                { "VGPLAA_IMPSEGURADA" , ""},
                { "VGPLAA_CUSTO" , ""},
                { "VGPLAA_PREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0130B_VGPLAACES", q31);

            #endregion

            #region M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "VGHISA_NRCERTIF" , ""},
                { "COBERP_OCORHIST" , ""},
                { "VGHISA_NUM_ACESSORIO" , ""},
                { "VGHISA_QTD_COBERTURA" , ""},
                { "VGHISA_IMPSEGURADA" , ""},
                { "VGHISA_CUSTO" , ""},
                { "VGHISA_PREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1_Insert1", q32);

            #endregion

            #region M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_1_Update1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "PLAVAVGA_FAIXA" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_1_Update1", q33);

            #endregion

            #region M_1000_PROPAUTOM_DB_INSERT_1_Insert1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_FONTE" , ""},
                { "FONTE_PROPAUTOM" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_CODCLIEN" , ""},
                { "PLAVAVGA_FAIXA" , ""},
                { "OPCAOP_PERIPGTO" , ""},
                { "PROPVA_EST_CIV" , ""},
                { "PROPVA_SEXO" , ""},
                { "PROPVA_AGECOBR" , ""},
                { "MNUM_CTA_CORRENTE" , ""},
                { "MDAC_CTA_CORRENTE" , ""},
                { "COBERP_IMPMORNATU_ANT" , ""},
                { "COBERP_IMPMORNATU_ATU" , ""},
                { "COBERP_PRMVG_ANT" , ""},
                { "COBERP_PRMVG_ATU" , ""},
                { "SISTEMA_DTMOVABE" , ""},
                { "CLIENT_DTNASC" , ""},
                { "PROPVA_DTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROPAUTOM_DB_INSERT_1_Insert1", q34);

            #endregion

            #region M_1000_PROPAUTOM_DB_UPDATE_1_Update1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""},
                { "PROPVA_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROPAUTOM_DB_UPDATE_1_Update1", q35);

            #endregion

            #region M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_2_Update1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "COBERP_DTINIVIG" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_2_Update1", q36);

            #endregion

            #region M_1000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_OCORHIST" , ""},
                { "COBERP_DTINIVIG" , ""},
                { "COBERP_IMPMORNATU_ANT" , ""},
                { "PROPVA_OPCAO_COBER" , ""},
                { "COBERP_IMPMORACID_ANT" , ""},
                { "COBERP_IMPINVPERM_ANT" , ""},
                { "COBERP_IMPAMDS_ANT" , ""},
                { "COBERP_IMPDH_ANT" , ""},
                { "COBERP_IMPDIT_ANT" , ""},
                { "COBERP_PRMVG_ATU" , ""},
                { "COBERP_PRMAP_ANT" , ""},
                { "COBERP_QTTITCAP" , ""},
                { "COBERP_VLTITCAP" , ""},
                { "COBERP_VLCUSTCAP" , ""},
                { "COBERP_IMPSEGCDG" , ""},
                { "COBERP_VLCUSTCDG" , ""},
                { "COBERP_IMPSEGAUXF" , ""},
                { "COBERP_VLCUSTAUXF" , ""},
                { "COBERP_PRMDIT_ANT" , ""},
                { "COBERP_QTDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1", q37);

            #endregion

            #region M_1000_MUDA_FAIXA_ETARIA_DB_SELECT_1_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_MUDA_FAIXA_ETARIA_DB_SELECT_1_Query1", q38);

            #endregion

            #region M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_OCORHIST" , ""},
                { "PROPVA_DTMOVTO" , ""},
                { "PROPVA_IDADE" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1", q39);

            #endregion

            #region M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_1_Update1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "PLAVAVGA_FAIXA" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_1_Update1", q40);

            #endregion

            #region M_2000_PROPAUTOM_DB_INSERT_1_Insert1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_FONTE" , ""},
                { "FONTE_PROPAUTOM" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_CODCLIEN" , ""},
                { "PLAVAVGA_FAIXA" , ""},
                { "OPCAOP_PERIPGTO" , ""},
                { "PROPVA_EST_CIV" , ""},
                { "PROPVA_SEXO" , ""},
                { "PROPVA_AGECOBR" , ""},
                { "MNUM_CTA_CORRENTE" , ""},
                { "MDAC_CTA_CORRENTE" , ""},
                { "PLAVAVGA_TAXAAP" , ""},
                { "WHOST_TXAPIP" , ""},
                { "SEGURA_TXAPAMDS" , ""},
                { "SEGURA_TXAPDH" , ""},
                { "SEGURA_TXAPDIT" , ""},
                { "SEGURA_TXVG" , ""},
                { "COBERP_IMPMORNATU_ANT" , ""},
                { "COBERP_IMPMORNATU_ATU" , ""},
                { "COBERP_IMPMORACID_ANT" , ""},
                { "COBERP_IMPMORACID_ATU" , ""},
                { "COBERP_IMPINVPERM_ANT" , ""},
                { "COBERP_IMPINVPERM_ATU" , ""},
                { "COBERP_IMPAMDS_ANT" , ""},
                { "COBERP_IMPAMDS_ATU" , ""},
                { "COBERP_IMPDH_ANT" , ""},
                { "COBERP_IMPDH_ATU" , ""},
                { "COBERP_IMPDIT_ANT" , ""},
                { "COBERP_IMPDIT_ATU" , ""},
                { "COBERP_PRMVG_ANT" , ""},
                { "COBERP_PRMVG_ATU" , ""},
                { "COBERP_PRMAP_ANT" , ""},
                { "COBERP_PRMAP_ATU" , ""},
                { "COD_OPERACAO" , ""},
                { "SISTEMA_DTMOVABE" , ""},
                { "CLIENT_DTNASC" , ""},
                { "DATA_MOVIMENTO" , ""},
                { "SEGURA_LOT_EMP_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_PROPAUTOM_DB_INSERT_1_Insert1", q41);

            #endregion

            #region M_2000_PROPAUTOM_DB_UPDATE_1_Update1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""},
                { "PROPVA_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_PROPAUTOM_DB_UPDATE_1_Update1", q42);

            #endregion

            #region M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_2_Update1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "COBERP_DTTERVIG" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_2_Update1", q43);

            #endregion

            #region M_2000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_OCORHIST" , ""},
                { "COBERP_DTINIVIG" , ""},
                { "COBERP_IMPSEGUR_ANT" , ""},
                { "COBERP_QUANT_VIDAS_ANT" , ""},
                { "COBERP_IMPSEGIND_ANT" , ""},
                { "COD_OPERACAO" , ""},
                { "COBERP_OPCAO_COBER_ANT" , ""},
                { "COBERP_IMPMORNATU_ANT" , ""},
                { "COBERP_IMPMORACID_ANT" , ""},
                { "COBERP_IMPINVPERM_ANT" , ""},
                { "COBERP_IMPAMDS_ANT" , ""},
                { "COBERP_IMPDH_ANT" , ""},
                { "COBERP_IMPDIT_ANT" , ""},
                { "COBERP_VLPREMIO_ATU" , ""},
                { "COBERP_PRMVG_ATU" , ""},
                { "COBERP_PRMAP_ATU" , ""},
                { "COBERP_QTTITCAP" , ""},
                { "COBERP_VLTITCAP" , ""},
                { "COBERP_VLCUSTCAP" , ""},
                { "COBERP_IMPSEGCDG" , ""},
                { "COBERP_VLCUSTCDG" , ""},
                { "COBERP_IMPSEGAUXF" , ""},
                { "COBERP_VLCUSTAUXF" , ""},
                { "COBERP_PRMDIT_ATU" , ""},
                { "COBERP_QTDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1", q44);

            #endregion

            #region M_2000_MUDA_FAIXA_ETARIA_DB_SELECT_1_Query1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_MUDA_FAIXA_ETARIA_DB_SELECT_1_Query1", q45);

            #endregion

            #region M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_OCORHIST" , ""},
                { "DATA_MOVIMENTO" , ""},
                { "COD_OPERACAO" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1", q46);

            #endregion

            #region M_2220_00_INSERT_VG_HISTACESSCOB_DB_INSERT_1_Insert1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_OCORHIST" , ""},
                { "VGPLAA_NUM_ACESSORIO" , ""},
                { "VGPLAA_QTD_COBERTURA" , ""},
                { "VGPLAA_IMPSEGURADA" , ""},
                { "VGPLAA_CUSTO" , ""},
                { "VGPLAA_PREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2220_00_INSERT_VG_HISTACESSCOB_DB_INSERT_1_Insert1", q47);

            #endregion

            #region M_2500_SELECT_V0COBERAPOL_DB_SELECT_1_Query1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "SOCORR_HISTORICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_2500_SELECT_V0COBERAPOL_DB_SELECT_1_Query1", q48);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VAMOVTO_FILE_NAME_P", "MOVCORR_FILE_NAME_P", "MOVDESP_FILE_NAME_P")]
        public static void VA0130B_Tests_Theory(string VAMOVTO_FILE_NAME_P, string MOVCORR_FILE_NAME_P, string MOVDESP_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            VAMOVTO_FILE_NAME_P = $"{VAMOVTO_FILE_NAME_P}_{timestamp}.txt";
            MOVCORR_FILE_NAME_P = $"{MOVCORR_FILE_NAME_P}_{timestamp}.txt";
            MOVDESP_FILE_NAME_P = $"{MOVDESP_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                AppSettings.TestSet.DynamicData.Remove("M_0010_SELECT_SISTEMAS_DB_SELECT_3_Query1");
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("M_0010_SELECT_SISTEMAS_DB_SELECT_3_Query1", q2);


                AppSettings.TestSet.DynamicData.Remove("M_0010_SELECT_SISTEMAS_DB_SELECT_4_Query1");
                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("M_0010_SELECT_SISTEMAS_DB_SELECT_4_Query1", q3);

                AppSettings.TestSet.DynamicData.Remove("VA0130B_CPROPVA");
                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_TEM_ANTECIP" , ""},
                { "PROPVA_NUM_APOLICE" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_CODCLIEN" , ""},
                { "PROPVA_OCOREND" , ""},
                { "PROPVA_FONTE" , ""},
                { "PROPVA_AGECOBR" , ""},
                { "PROPVA_OPCAO_COBER" , ""},
                { "PROPVA_DTPROXVEN" , ""},
                { "PROPVA_DTPROXVEN_1" , ""},
                { "PROPVA_NRPARCEL" , ""},
                { "PROPVA_CODOPER" , ""},
                { "PROPVA_DTMOVTO" , ""},
                { "PROPVA_OCORHIST" , ""},
                { "PROPVA_SIT_INTERF" , ""},
                { "PROPVA_TIMESTAMP" , ""},
                { "PROPVA_SEXO" , ""},
                { "PROPVA_EST_CIV" , ""},
                { "PROPVA_DTQITBCO_1YEAR" , ""},
                { "PROPVA_DTQITBCO" , "0000-00-01"},
                { "PROPVA_IDADE" , ""},
                { "PROPVA_CODPRODU" , ""},
                { "PROPVA_STA_ANTECIPACAO" , ""},
                { "PROPVA_STA_MUDANCA_PLANO" , ""},
                });
                q16.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_TEM_ANTECIP" , ""},
                { "PROPVA_NUM_APOLICE" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_CODCLIEN" , ""},
                { "PROPVA_OCOREND" , ""},
                { "PROPVA_FONTE" , ""},
                { "PROPVA_AGECOBR" , ""},
                { "PROPVA_OPCAO_COBER" , ""},
                { "PROPVA_DTPROXVEN" , ""},
                { "PROPVA_DTPROXVEN_1" , ""},
                { "PROPVA_NRPARCEL" , ""},
                { "PROPVA_CODOPER" , ""},
                { "PROPVA_DTMOVTO" , ""},
                { "PROPVA_OCORHIST" , ""},
                { "PROPVA_SIT_INTERF" , ""},
                { "PROPVA_TIMESTAMP" , ""},
                { "PROPVA_SEXO" , ""},
                { "PROPVA_EST_CIV" , ""},
                { "PROPVA_DTQITBCO_1YEAR" , ""},
                { "PROPVA_DTQITBCO" , "0000-00-01"},
                { "PROPVA_IDADE" , ""},
                { "PROPVA_CODPRODU" , ""},
                { "PROPVA_STA_ANTECIPACAO" , ""},
                { "PROPVA_STA_MUDANCA_PLANO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("VA0130B_CPROPVA", q16);

                AppSettings.TestSet.DynamicData.Remove("M_0110_FETCH_PROPOSTAS_DB_SELECT_1_Query1");
                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "PRODVG_TEM_IGPM" , "S"},
                { "PRODVG_TEM_FAIXAETA" , "S"},
                { "PRODVG_RAMO" , ""},
                { "PRODVG_COBERADIC_PREMIO" , ""},
                { "PRODVG_CUSTOCAP_TOTAL" , ""},
                { "PRODVG_TEM_CDG" , ""},
                { "PRODVG_TEM_SAF" , ""},
                { "PRODVG_COD_PRODUTO" , ""},
                { "PRODVG_NOME_PRODUTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_PROPOSTAS_DB_SELECT_1_Query1", q17);

                AppSettings.TestSet.DynamicData.Remove("VA0130B_V0COTACAO");
                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "COTACAO_DTINIVIG" , ""},
                { "COTACAO_VAL_VENDA" , "150000"},
                });
                AppSettings.TestSet.DynamicData.Add("VA0130B_V0COTACAO", q4);


                AppSettings.TestSet.DynamicData.Remove("M_2500_SELECT_V0COBERAPOL_DB_SELECT_1_Query1");
                var q48 = new DynamicData();
                q48.AddDynamic(new Dictionary<string, string>{
                { "SOCORR_HISTORICO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("M_2500_SELECT_V0COBERAPOL_DB_SELECT_1_Query1", q48);

                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1");
                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , "20000101"}
                });
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1", q14);

                AppSettings.TestSet.DynamicData.Remove("M_0120_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1");
                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "COBERP_IMPSEGUR_ANT" , ""},
                { "COBERP_QUANT_VIDAS_ANT" , ""},
                { "COBERP_IMPSEGIND_ANT" , ""},
                { "COBERP_OPCAO_COBER_ANT" , ""},
                { "COBERP_IMPMORNATU_ANT" , ""},
                { "COBERP_IMPMORACID_ANT" , "1"},
                { "COBERP_IMPINVPERM_ANT" , ""},
                { "COBERP_IMPAMDS_ANT" , ""},
                { "COBERP_IMPDH_ANT" , ""},
                { "COBERP_IMPDIT_ANT" , ""},
                { "COBERP_VLPREMIO_ANT" , ""},
                { "COBERP_PRMVG_ANT" , "1"},
                { "COBERP_PRMAP_ANT" , ""},
                { "COBERP_QTTITCAP" , ""},
                { "COBERP_VLTITCAP" , ""},
                { "COBERP_VLCUSTCAP" , ""},
                { "COBERP_IMPSEGCDG" , ""},
                { "COBERP_VLCUSTCDG" , ""},
                { "COBERP_IMPSEGAUXF" , ""},
                { "COBERP_VLCUSTAUXF" , ""},
                { "COBERP_PRMDIT_ANT" , ""},
                { "COBERP_QTDIT" , ""},
                { "COBERP_DTINIVIG_ANT" , ""},
                { "COBERP_DTINIVIG_NEW" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("M_0120_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1", q18);

                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1");
                var q15 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1", q15);

                AppSettings.TestSet.DynamicData.Remove("M_0130_VERIFICA_MUDANCA_DB_SELECT_1_Query1");
                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "PLAVAVGA_IDADE_FINAL" , ""},
                { "PLAVAVGA_TAXAAP" , ""},
                { "PLAVAVGA_FAIXA" , "90"},
                { "PLAVAVGA_PCT_FAIXA_ETARIA" , "42"},
                });
                AppSettings.TestSet.DynamicData.Add("M_0130_VERIFICA_MUDANCA_DB_SELECT_1_Query1", q19);

                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1");
                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "MIMP_MORNATU_ATU" , ""},
                { "MIMP_MORACID_ATU" , "10"},
                { "MPRM_VG_ATU" , ""},
                { "MPRM_AP_ATU" , "10"},
                });
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1", q20);

                #endregion
                var program = new VA0130B();
                program.Execute(new VA0130B_LK_PARAMETRO(), VAMOVTO_FILE_NAME_P, MOVCORR_FILE_NAME_P, MOVDESP_FILE_NAME_P);

                var envList = AppSettings.TestSet.DynamicData["M_0300_CORRIGE_IGPM_DB_UPDATE_1_Update1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["M_0300_CORRIGE_IGPM_DB_UPDATE_2_Update1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["M_0300_CORRIGE_IGPM_DB_INSERT_1_Insert1"].DynamicList;
                var envList3 = AppSettings.TestSet.DynamicData["M_0300_PROPAUTOM_DB_INSERT_1_Insert1"].DynamicList;
                var envList4 = AppSettings.TestSet.DynamicData["M_0300_PROPAUTOM_DB_UPDATE_1_Update1"].DynamicList;
                var envList5 = AppSettings.TestSet.DynamicData["M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1_Insert1"].DynamicList;
                var envList6 = AppSettings.TestSet.DynamicData["M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1_Insert1"].DynamicList;
                var envList7 = AppSettings.TestSet.DynamicData["M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_1_Update1"].DynamicList;
                var envList8 = AppSettings.TestSet.DynamicData["M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_2_Update1"].DynamicList;
                var envList9 = AppSettings.TestSet.DynamicData["M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1"].DynamicList;
                var envList10 = AppSettings.TestSet.DynamicData["M_2000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1"].DynamicList;
                var envList11 = AppSettings.TestSet.DynamicData["M_2000_PROPAUTOM_DB_INSERT_1_Insert1"].DynamicList;
                var envList12 = AppSettings.TestSet.DynamicData["M_2000_PROPAUTOM_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);
                Assert.True(envList3?.Count > 1);
                Assert.True(envList4?.Count > 1);
                Assert.True(envList5?.Count > 1);
                Assert.True(envList6?.Count > 1);
                Assert.True(envList7?.Count > 1);
                Assert.True(envList8?.Count > 1);
                Assert.True(envList9?.Count > 1);
                Assert.True(envList10?.Count > 1);
                Assert.True(envList11?.Count > 1);
                Assert.True(envList12?.Count > 1);

                Assert.True(envList[1].TryGetValue("PROPVA_NRCERTIF", out string valor) && valor == "000000000000000");
                Assert.True(envList1[1].TryGetValue("PROPVA_OCORHIST", out valor) && valor == "0001");
                Assert.True(envList2[1].TryGetValue("COBERP_IMPMORACID_ATU", out valor) && valor == "0000000001501.00");
                Assert.True(envList3[1].TryGetValue("COBERP_PRMVG_ATU", out valor) && valor == "0000000001501.00");
                Assert.True(envList4[1].TryGetValue("FONTE_PROPAUTOM", out valor) && valor == "000000001");
                Assert.True(envList5[1].TryGetValue("VGHISR_NRCERTIF", out valor) && valor == "000000000000000");
                Assert.True(envList6[1].TryGetValue("VGHISA_IMPSEGURADA", out valor) && valor == "0000000000000.00");
                Assert.True(envList7[1].TryGetValue("PLAVAVGA_FAIXA", out valor) && valor == "0090");
                Assert.True(envList8[1].TryGetValue("PROPVA_OCORHIST", out valor) && valor == "0001");
                Assert.True(envList9[1].TryGetValue("PROPVA_OCORHIST", out valor) && valor == "0002");
                Assert.True(envList10[1].TryGetValue("COBERP_PRMVG_ATU", out valor) && valor == "0000000000001.00");
                Assert.True(envList11[1].TryGetValue("FONTE_PROPAUTOM", out valor) && valor == "000000001");
                Assert.True(envList12[1].TryGetValue("FONTE_PROPAUTOM", out valor) && valor == "000000001");

            }
        }

        [Theory]
        [InlineData("VAMOVTO_FILE_NAME_P", "MOVCORR_FILE_NAME_P", "MOVDESP_FILE_NAME_P")]
        public static void VA0130B_Tests_Theory_1000_MUDA_FAIXA_ETARIA(string VAMOVTO_FILE_NAME_P, string MOVCORR_FILE_NAME_P, string MOVDESP_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            VAMOVTO_FILE_NAME_P = $"{VAMOVTO_FILE_NAME_P}_{timestamp}.txt";
            MOVCORR_FILE_NAME_P = $"{MOVCORR_FILE_NAME_P}_{timestamp}.txt";
            MOVDESP_FILE_NAME_P = $"{MOVDESP_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                AppSettings.TestSet.DynamicData.Remove("M_0010_SELECT_SISTEMAS_DB_SELECT_3_Query1");
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("M_0010_SELECT_SISTEMAS_DB_SELECT_3_Query1", q2);


                AppSettings.TestSet.DynamicData.Remove("M_0010_SELECT_SISTEMAS_DB_SELECT_4_Query1");
                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("M_0010_SELECT_SISTEMAS_DB_SELECT_4_Query1", q3);

                AppSettings.TestSet.DynamicData.Remove("VA0130B_CPROPVA");
                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_TEM_ANTECIP" , ""},
                { "PROPVA_NUM_APOLICE" , "3009300000559"},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_CODCLIEN" , ""},
                { "PROPVA_OCOREND" , ""},
                { "PROPVA_FONTE" , ""},
                { "PROPVA_AGECOBR" , ""},
                { "PROPVA_OPCAO_COBER" , ""},
                { "PROPVA_DTPROXVEN" , ""},
                { "PROPVA_DTPROXVEN_1" , ""},
                { "PROPVA_NRPARCEL" , ""},
                { "PROPVA_CODOPER" , ""},
                { "PROPVA_DTMOVTO" , ""},
                { "PROPVA_OCORHIST" , ""},
                { "PROPVA_SIT_INTERF" , ""},
                { "PROPVA_TIMESTAMP" , ""},
                { "PROPVA_SEXO" , ""},
                { "PROPVA_EST_CIV" , ""},
                { "PROPVA_DTQITBCO_1YEAR" , ""},
                { "PROPVA_DTQITBCO" , "0000 00 01"},
                { "PROPVA_IDADE" , ""},
                { "PROPVA_CODPRODU" , ""},
                { "PROPVA_STA_ANTECIPACAO" , ""},
                { "PROPVA_STA_MUDANCA_PLANO" , ""},
                });

                AppSettings.TestSet.DynamicData.Add("VA0130B_CPROPVA", q16);

                AppSettings.TestSet.DynamicData.Remove("M_0110_FETCH_PROPOSTAS_DB_SELECT_1_Query1");
                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "PRODVG_TEM_IGPM" , "S"},
                { "PRODVG_TEM_FAIXAETA" , "S"},
                { "PRODVG_RAMO" , ""},
                { "PRODVG_COBERADIC_PREMIO" , ""},
                { "PRODVG_CUSTOCAP_TOTAL" , ""},
                { "PRODVG_TEM_CDG" , ""},
                { "PRODVG_TEM_SAF" , ""},
                { "PRODVG_COD_PRODUTO" , ""},
                { "PRODVG_NOME_PRODUTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_PROPOSTAS_DB_SELECT_1_Query1", q17);

                AppSettings.TestSet.DynamicData.Remove("VA0130B_V0COTACAO");
                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "COTACAO_DTINIVIG" , ""},
                { "COTACAO_VAL_VENDA" , "150000"},
                });
                AppSettings.TestSet.DynamicData.Add("VA0130B_V0COTACAO", q4);


                AppSettings.TestSet.DynamicData.Remove("M_2500_SELECT_V0COBERAPOL_DB_SELECT_1_Query1");
                var q48 = new DynamicData();
                q48.AddDynamic(new Dictionary<string, string>{
                { "SOCORR_HISTORICO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("M_2500_SELECT_V0COBERAPOL_DB_SELECT_1_Query1", q48);

                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1");
                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , "20000101"}
                });
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1", q14);

                AppSettings.TestSet.DynamicData.Remove("M_0120_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1");
                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "COBERP_IMPSEGUR_ANT" , ""},
                { "COBERP_QUANT_VIDAS_ANT" , ""},
                { "COBERP_IMPSEGIND_ANT" , ""},
                { "COBERP_OPCAO_COBER_ANT" , ""},
                { "COBERP_IMPMORNATU_ANT" , ""},
                { "COBERP_IMPMORACID_ANT" , "1"},
                { "COBERP_IMPINVPERM_ANT" , ""},
                { "COBERP_IMPAMDS_ANT" , ""},
                { "COBERP_IMPDH_ANT" , ""},
                { "COBERP_IMPDIT_ANT" , ""},
                { "COBERP_VLPREMIO_ANT" , ""},
                { "COBERP_PRMVG_ANT" , "1"},
                { "COBERP_PRMAP_ANT" , ""},
                { "COBERP_QTTITCAP" , ""},
                { "COBERP_VLTITCAP" , ""},
                { "COBERP_VLCUSTCAP" , ""},
                { "COBERP_IMPSEGCDG" , ""},
                { "COBERP_VLCUSTCDG" , ""},
                { "COBERP_IMPSEGAUXF" , ""},
                { "COBERP_VLCUSTAUXF" , ""},
                { "COBERP_PRMDIT_ANT" , ""},
                { "COBERP_QTDIT" , ""},
                { "COBERP_DTINIVIG_ANT" , ""},
                { "COBERP_DTINIVIG_NEW" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("M_0120_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1", q18);

                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1");
                var q15 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1", q15);

                AppSettings.TestSet.DynamicData.Remove("M_0130_VERIFICA_MUDANCA_DB_SELECT_1_Query1");
                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "PLAVAVGA_IDADE_FINAL" , ""},
                { "PLAVAVGA_TAXAAP" , ""},
                { "PLAVAVGA_FAIXA" , "90"},
                { "PLAVAVGA_PCT_FAIXA_ETARIA" , "42"},
                });
                AppSettings.TestSet.DynamicData.Add("M_0130_VERIFICA_MUDANCA_DB_SELECT_1_Query1", q19);

                #endregion
                var program = new VA0130B();
                program.Execute(new VA0130B_LK_PARAMETRO(), VAMOVTO_FILE_NAME_P, MOVCORR_FILE_NAME_P, MOVDESP_FILE_NAME_P);

                var envList = AppSettings.TestSet.DynamicData["M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_1_Update1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_2_Update1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1"].DynamicList;
                var envList3 = AppSettings.TestSet.DynamicData["M_1000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1"].DynamicList;
                var envList4 = AppSettings.TestSet.DynamicData["M_1000_PROPAUTOM_DB_INSERT_1_Insert1"].DynamicList;
                var envList5 = AppSettings.TestSet.DynamicData["M_1000_PROPAUTOM_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);
                Assert.True(envList3?.Count > 1);
                Assert.True(envList4?.Count > 1);
                Assert.True(envList5?.Count > 1);

                Assert.True(envList[1].TryGetValue("PLAVAVGA_FAIXA", out string valor) && valor == "0090");
                Assert.True(envList1[1].TryGetValue("PROPVA_OCORHIST", out valor) && valor == "0001");
                Assert.True(envList2[1].TryGetValue("PROPVA_OCORHIST", out valor) && valor == "0002");
                Assert.True(envList3[1].TryGetValue("COBERP_PRMVG_ATU", out valor) && valor == "0000000000001.00");
                Assert.True(envList4[1].TryGetValue("PROPVA_NUM_APOLICE", out valor) && valor == "3009300000559");
                Assert.True(envList5[1].TryGetValue("FONTE_PROPAUTOM", out valor) && valor == "000000001");

            }
        }
    }
}