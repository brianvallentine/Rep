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
using static Code.PF2002B;

namespace FileTests.Test
{
    [Collection("PF2002B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class PF2002B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0105_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0105_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q1);

            #endregion

            #region PF2002B_V0AGENCIAS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0ACEF_AGENCIA" , ""},
                { "V0ACEF_ESCNEG" , ""},
                { "V0ACEF_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF2002B_V0AGENCIAS", q2);

            #endregion

            #region PF2002B_V0PRDSIVPF

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0PRPF_CODSIVPF" , ""},
                { "V0PRPF_CODPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF2002B_V0PRDSIVPF", q3);

            #endregion

            #region PF2002B_V0PRODUTO

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_CODPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("PF2002B_V0PRODUTO", q4);

            #endregion

            #region R0290_SELECT_MAX_TITULO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0CEDE_NUMTIT" , "95722565727"},
                { "V0CEDE_NUMTITMAX" , "95722565728"},
            });
            AppSettings.TestSet.DynamicData.Add("R0290_SELECT_MAX_TITULO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1750_SELECT_V0AGENCIAS_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0AGEN_ESTADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1750_SELECT_V0AGENCIAS_DB_SELECT_1_Query1", q6);

            #endregion

            #region R2500_SELECT_V0AVISOCRED_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT_AVS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2500_SELECT_V0AVISOCRED_DB_SELECT_1_Query1", q7);

            #endregion

            #region R2670_SELECT_RENOVACAO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PROPOSTA_DATA_INIVIGENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2670_SELECT_RENOVACAO_DB_SELECT_1_Query1", q8);

            #endregion

            #region R2690_INCLUI_V0MOVICOB_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0MCOB_CODEMP" , ""},
                { "V0MCOB_CODMOV" , ""},
                { "V0MCOB_BANCO" , ""},
                { "V0MCOB_AGENCIA" , ""},
                { "V0MCOB_NRAVISO" , ""},
                { "V0MCOB_NUMFITA" , ""},
                { "V0MCOB_DTMOVTO" , ""},
                { "V0MCOB_DTQITBCO" , ""},
                { "V0MCOB_NRTIT" , ""},
                { "V0MCOB_NUMAPOL" , ""},
                { "V0MCOB_NRENDOS" , ""},
                { "V0MCOB_NRPARCEL" , ""},
                { "V0MCOB_VALTIT" , ""},
                { "V0MCOB_VLIOCC" , ""},
                { "V0MCOB_VALCDT" , ""},
                { "V0MCOB_SITUACAO" , ""},
                { "V0MCOB_NOME" , ""},
                { "V0MCOB_TIPOMOV" , ""},
                { "V0MCOB_NUM_NOSSO_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2690_INCLUI_V0MOVICOB_DB_INSERT_1_Insert1", q9);

            #endregion

            #region R2710_SELECT_V0MESTSINI_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0MSIN_CODPRODU" , ""},
                { "V0MSIN_NUM_APOL_SINISTRO" , ""},
                { "V0MSIN_ACORDO" , ""},
                { "V0MSIN_NRPARCEL" , ""},
                { "V0MSIN_NUM_NOSSO_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2710_SELECT_V0MESTSINI_DB_SELECT_1_Query1", q10);

            #endregion

            #region R2720_SELECT_V0MESTSINI_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0MSIN_CODPRODU" , ""},
                { "V0MSIN_NUM_APOL_SINISTRO" , ""},
                { "V0MSIN_ACORDO" , ""},
                { "V0MSIN_NRPARCEL" , ""},
                { "V0MSIN_NUM_NOSSO_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2720_SELECT_V0MESTSINI_DB_SELECT_1_Query1", q11);

            #endregion

            #region R2850_SELECT_OPCPAGVI_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_PERI_PAGAMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2850_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q12);

            #endregion

            #region R2900_SELECT_CONVERSAO_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "CONVSICOB_NR_SICOB" , ""},
                { "CONVSICOB_AGEPGTO" , ""},
                { "CONVSICOB_DTQITBCO" , ""},
                { "CONVSICOB_VAL_RCAP" , ""},
                { "CONVSICOB_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2900_SELECT_CONVERSAO_DB_SELECT_1_Query1", q13);

            #endregion

            #region R2901_SELECT_CONVERSAO2_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "CONVSICOB_NR_SICOB" , ""},
                { "CONVSICOB_AGEPGTO" , ""},
                { "CONVSICOB_DTQITBCO" , ""},
                { "CONVSICOB_VAL_RCAP" , ""},
                { "CONVSICOB_COD_USUARIO" , ""},
                { "CONVSICOB_NUM_PROP_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2901_SELECT_CONVERSAO2_DB_SELECT_1_Query1", q14);

            #endregion

            #region R3210_VER_MOVIMENTO_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_NUM_APOLICE" , ""},
                { "MOVIMCOB_NUM_ENDOSSO" , ""},
                { "MOVIMCOB_NUM_PARCELA" , ""},
                { "MOVIMCOB_TIPO_MOVIMENTO" , ""},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3210_VER_MOVIMENTO_DB_SELECT_1_Query1", q15);

            #endregion

            #region R3222_SELECT_COBHISVI_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3222_SELECT_COBHISVI_DB_SELECT_1_Query1", q16);

            #endregion

            #region R3224_SELECT_GE403_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "GE403_NUM_APOLICE" , ""},
                { "GE403_NUM_ENDOSSO" , ""},
                { "GE403_NUM_IDLG" , ""},
                { "GE403_NUM_NOSSO_NUMERO_SAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3224_SELECT_GE403_DB_SELECT_1_Query1", q17);

            #endregion

            #region R3226_SELECT_PARCELAS_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3226_SELECT_PARCELAS_DB_SELECT_1_Query1", q18);

            #endregion

            #region R3228_SELECT_MOVDEBCE_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_NUM_CARTAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3228_SELECT_MOVDEBCE_DB_SELECT_1_Query1", q19);

            #endregion

            #region R3230_SELECT_COBHISVI_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3230_SELECT_COBHISVI_DB_SELECT_1_Query1", q20);

            #endregion

            #region R3250_SELECT_V1ENDOSSO_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NUMAPOL" , ""},
                { "V0PARC_NRENDOS" , ""},
                { "V0PARC_NRPARCEL" , ""},
                { "V1ENDO_CODPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3250_SELECT_V1ENDOSSO_DB_SELECT_1_Query1", q21);

            #endregion

            #region R3300_SELECT_CBMALPAR_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3300_SELECT_CBMALPAR_DB_SELECT_1_Query1", q22);

            #endregion

            #region R3400_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_CODPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3400_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1", q23);

            #endregion

            #region R3500_TRATA_ADESAO_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "PF087_SIGLA_ARQUIVO" , ""},
                { "PF087_NUM_PROPOSTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3500_TRATA_ADESAO_DB_SELECT_1_Query1", q24);

            #endregion

            #region R3700_INCLUI_V0RCAP_DB_INSERT_1_Insert1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_FONTE" , ""},
                { "V0RCAP_NRRCAP" , ""},
                { "V0RCAP_NRPROPOS" , ""},
                { "V0RCAP_NOME" , ""},
                { "V0RCAP_VLRCAP" , ""},
                { "V0RCAP_VALPRI" , ""},
                { "V0RCAP_DTCADAST" , ""},
                { "V0RCAP_DTMOVTO" , ""},
                { "V0RCAP_SITUACAO" , ""},
                { "V0RCAP_OPERACAO" , ""},
                { "V0RCAP_CODEMP" , ""},
                { "V0RCAP_NUMAPOL" , ""},
                { "V0RCAP_NRENDOS" , ""},
                { "V0RCAP_NRPARCEL" , ""},
                { "V0RCAP_NRTIT" , ""},
                { "V0RCAP_CODPRODU" , ""},
                { "V0RCAP_AGECOBR" , ""},
                { "V0RCAP_RECUPERA" , ""},
                { "V0RCAP_ACRESCIMO" , ""},
                { "V0RCAP_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3700_INCLUI_V0RCAP_DB_INSERT_1_Insert1", q25);

            #endregion

            #region R3710_SELECT_V1RCAP_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V1RCAP_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3710_SELECT_V1RCAP_DB_SELECT_1_Query1", q26);

            #endregion

            #region R3750_INCLUI_V0RCAPCOMP_DB_INSERT_1_Insert1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "V0RCOM_FONTE" , ""},
                { "V0RCOM_NRRCAP" , ""},
                { "V0RCOM_NRRCAPCO" , ""},
                { "V0RCOM_OPERACAO" , ""},
                { "V0RCOM_DTMOVTO" , ""},
                { "V0RCOM_HORAOPER" , ""},
                { "V0RCOM_SITUACAO" , ""},
                { "V0RCOM_BCOAVISO" , ""},
                { "V0RCOM_AGEAVISO" , ""},
                { "V0RCOM_NRAVISO" , ""},
                { "V0RCOM_VLRCAP" , ""},
                { "V0RCOM_DATARCAP" , ""},
                { "V0RCOM_DTCADAST" , ""},
                { "V0RCOM_SITCONTB" , ""},
                { "V0RCOM_CODEMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3750_INCLUI_V0RCAPCOMP_DB_INSERT_1_Insert1", q27);

            #endregion

            #region R3800_INCLUI_CONVERSAO_DB_INSERT_1_Insert1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V0FILT_NUMSIVPF" , ""},
                { "V0FILT_NUMSICOB" , ""},
                { "V0FILT_CODEMP" , ""},
                { "V0FILT_CODSIVPF" , ""},
                { "V0FILT_AGECOBR" , ""},
                { "V0FILT_DTMOVTO" , ""},
                { "V0FILT_DTQITBCO" , ""},
                { "V0FILT_VLRCAP" , ""},
                { "V0FILT_CODUSU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3800_INCLUI_CONVERSAO_DB_INSERT_1_Insert1", q28);

            #endregion

            #region R3860_UPDATE_V0RCAP_DB_INSERT_1_Insert1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_NRRCAP" , ""},
                { "V0RCAP_NRTIT" , ""},
                { "V0RCOM_FONTE" , ""},
                { "V0RCOM_NRRCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3860_UPDATE_V0RCAP_DB_INSERT_1_Insert1", q29);

            #endregion

            #region R3860_UPDATE_V0RCAP_DB_UPDATE_1_Update1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_NRRCAP" , ""},
                { "V0RCOM_NRRCAP" , ""},
                { "V0RCOM_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3860_UPDATE_V0RCAP_DB_UPDATE_1_Update1", q30);

            #endregion

            #region R3860_UPDATE_V0RCAP_DB_DELETE_1_Delete1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "V0RCOM_FONTE" , ""},
                { "V0RCOM_NRRCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3860_UPDATE_V0RCAP_DB_DELETE_1_Delete1", q31);

            #endregion

            #region R3950_UPDATE_CONVERSAO_DB_UPDATE_1_Update1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "CONVSICOB_DTQITBCO" , ""},
                { "CONVSICOB_VAL_RCAP" , ""},
                { "CONVSICOB_AGEPGTO" , ""},
                { "V0FILT_NUMSIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3950_UPDATE_CONVERSAO_DB_UPDATE_1_Update1", q32);

            #endregion

            #region R3950_UPDATE_CONVERSAO_DB_UPDATE_2_Update1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "CONVSICOB_DTQITBCO" , ""},
                { "CONVSICOB_VAL_RCAP" , ""},
                { "CONVSICOB_AGEPGTO" , ""},
                { "V0RCOM_DTMOVTO" , ""},
                { "V0FILT_NUMSIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3950_UPDATE_CONVERSAO_DB_UPDATE_2_Update1", q33);

            #endregion

            #region R4100_INCLUI_V0FOLLOWUP_DB_INSERT_1_Insert1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "V0FOLL_NUMAPOL" , ""},
                { "V0FOLL_NRENDOS" , ""},
                { "V0FOLL_NRPARCEL" , ""},
                { "V0FOLL_DACPARC" , ""},
                { "V0FOLL_DTMOVTO" , ""},
                { "V0FOLL_HORAOPER" , ""},
                { "V0FOLL_VLPREMIO" , ""},
                { "V0FOLL_BCOAVISO" , ""},
                { "V0FOLL_AGEAVISO" , ""},
                { "V0FOLL_NRAVISO" , ""},
                { "V0FOLL_CODBAIXA" , ""},
                { "V0FOLL_CDERRO01" , ""},
                { "V0FOLL_CDERRO02" , ""},
                { "V0FOLL_CDERRO03" , ""},
                { "V0FOLL_CDERRO04" , ""},
                { "V0FOLL_CDERRO05" , ""},
                { "V0FOLL_CDERRO06" , ""},
                { "V0FOLL_SITUACAO" , ""},
                { "V0FOLL_SITCONTB" , ""},
                { "V0FOLL_OPERACAO" , ""},
                { "V0FOLL_DTLIBER" , ""},
                { "V0FOLL_DTQITBCO" , ""},
                { "V0FOLL_CODEMP" , ""},
                { "V0FOLL_ORDLIDER" , ""},
                { "V0FOLL_TIPSGU" , ""},
                { "V0FOLL_APOLIDER" , ""},
                { "V0FOLL_ENDOSLID" , ""},
                { "V0FOLL_CODLIDER" , ""},
                { "V0FOLL_FONTE" , ""},
                { "V0FOLL_NRRCAP" , ""},
                { "V0FOLL_NUM_NOSSO_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4100_INCLUI_V0FOLLOWUP_DB_INSERT_1_Insert1", q34);

            #endregion

            #region R4550_INCLUI_V0AVISOCRED_DB_INSERT_1_Insert1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R4550_INCLUI_V0AVISOCRED_DB_INSERT_1_Insert1", q35);

            #endregion

            #region R4600_INCLUI_V0AVISOSALDO_DB_INSERT_1_Insert1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R4600_INCLUI_V0AVISOSALDO_DB_INSERT_1_Insert1", q36);

            #endregion

            #region R4650_INCLUI_V0CONTROCNAB_DB_INSERT_1_Insert1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "V0CNAB_COD_EMP" , ""},
                { "V0CNAB_ORGAO" , ""},
                { "V0CNAB_NRCTACED" , ""},
                { "V0CNAB_TIPOCOB" , ""},
                { "V0CNAB_DTMOVTO" , ""},
                { "V0CNAB_DATCEF" , ""},
                { "V0CNAB_NRSEQ" , ""},
                { "V0CNAB_QTDREG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4650_INCLUI_V0CONTROCNAB_DB_INSERT_1_Insert1", q37);

            #endregion

            #region R6700_INCLUI_TARIFA_BALCAO_DB_INSERT_1_Insert1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "V0TRBL_CODEMP" , ""},
                { "V0TRBL_MATRICULA" , ""},
                { "V0TRBL_TIPOFUNC" , ""},
                { "V0TRBL_NRCERTIF" , ""},
                { "V0TRBL_DTMOVTO" , ""},
                { "V0TRBL_CODPRODU" , ""},
                { "V0TRBL_SITUACAO" , ""},
                { "V0TRBL_FONTE" , ""},
                { "V0TRBL_ESCNEG" , ""},
                { "V0TRBL_AGECOBR" , ""},
                { "V0TRBL_BCOAVISO" , ""},
                { "V0TRBL_AGEAVISO" , ""},
                { "V0TRBL_NRAVISO" , ""},
                { "V0TRBL_TARIFA" , ""},
                { "V0TRBL_BALCAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6700_INCLUI_TARIFA_BALCAO_DB_INSERT_1_Insert1", q38);

            #endregion

            #region R7050_SELECT_PROPOSTA_DB_SELECT_1_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "PROPOSTA_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7050_SELECT_PROPOSTA_DB_SELECT_1_Query1", q39);

            #endregion

            #region R7050_SELECT_PROPOSTA_DB_SELECT_2_Query1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "PROPOSTA_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7050_SELECT_PROPOSTA_DB_SELECT_2_Query1", q40);

            #endregion

            #region R7500_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V0CEDE_NUMTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7500_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1", q41);

            #endregion

            #region R8455_SELECT_MAX_AVISO_DB_SELECT_1_Query1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "V0MCOB_NUMFITA" , "5959"}
            });
            AppSettings.TestSet.DynamicData.Add("R8455_SELECT_MAX_AVISO_DB_SELECT_1_Query1", q42);

            #endregion

            #region R8700_INCLUI_DESPESAS_DB_INSERT_1_Insert1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R8700_INCLUI_DESPESAS_DB_INSERT_1_Insert1", q43);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("ARQSORT", "PRD.EM.D241203.EM8006B.SIGCB_teste.txt", "PF2002B1")]
        public static void PF2002B_Tests_Theory_ReturnCode_99(string ARQSORT_FILE_NAME_P, string MOVIMENTO_COBRANCA_FILE_NAME_P, string PF2002B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";
            PF2002B1_FILE_NAME_P = $"{PF2002B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0105_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0105_SELECT_V0RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0105_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q1);

                #endregion

                #endregion
                var program = new PF2002B();
                program.Execute(new PF2002B_PF2002B_SYSIN(), ARQSORT_FILE_NAME_P, MOVIMENTO_COBRANCA_FILE_NAME_P, PF2002B1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Theory]
        [InlineData("ARQSORT", "PRD.EM.D241203.EM8006B.SIGCB_teste.txt", "PF2002B1")]
        public static void PF2002B_Tests_Theory_R3700_INCLUI_V0RCAP_Insert1(string ARQSORT_FILE_NAME_P, string MOVIMENTO_COBRANCA_FILE_NAME_P, string PF2002B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";
            PF2002B1_FILE_NAME_P = $"{PF2002B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                SQLCA sQLCA = new SQLCA();
                sQLCA.SQLCODE.SetValue(100);
                var q26 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R3710_SELECT_V1RCAP_DB_SELECT_1_Query1");

                q26.AddDynamic(new Dictionary<string, string>{
                { "V1RCAP_NRTIT" , ""}
                }, new SQLCA() { SQLCODE = sQLCA.SQLCODE });

                AppSettings.TestSet.DynamicData.Add("R3710_SELECT_V1RCAP_DB_SELECT_1_Query1", q26);


                #endregion
                var program = new PF2002B();
                program.Execute(new PF2002B_PF2002B_SYSIN(), ARQSORT_FILE_NAME_P, MOVIMENTO_COBRANCA_FILE_NAME_P, PF2002B1_FILE_NAME_P);

                var envList0 = AppSettings.TestSet.DynamicData["R2690_INCLUI_V0MOVICOB_DB_INSERT_1_Insert1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R3700_INCLUI_V0RCAP_DB_INSERT_1_Insert1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R3750_INCLUI_V0RCAPCOMP_DB_INSERT_1_Insert1"].DynamicList;
                var envList3 = AppSettings.TestSet.DynamicData["R3800_INCLUI_CONVERSAO_DB_INSERT_1_Insert1"].DynamicList;
                var envList4 = AppSettings.TestSet.DynamicData["R4100_INCLUI_V0FOLLOWUP_DB_INSERT_1_Insert1"].DynamicList;
                var envList5 = AppSettings.TestSet.DynamicData["R4550_INCLUI_V0AVISOCRED_DB_INSERT_1_Insert1"].DynamicList;
                var envList6 = AppSettings.TestSet.DynamicData["R4600_INCLUI_V0AVISOSALDO_DB_INSERT_1_Insert1"].DynamicList;
                var envList7 = AppSettings.TestSet.DynamicData["R4650_INCLUI_V0CONTROCNAB_DB_INSERT_1_Insert1"].DynamicList;
                var envList8 = AppSettings.TestSet.DynamicData["R6700_INCLUI_TARIFA_BALCAO_DB_INSERT_1_Insert1"].DynamicList;
                var envList9 = AppSettings.TestSet.DynamicData["R7500_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1"].DynamicList;
                var envList10 = AppSettings.TestSet.DynamicData["R8700_INCLUI_DESPESAS_DB_INSERT_1_Insert1"].DynamicList;

                Assert.True(envList0?.Count > 1);
                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);
                Assert.True(envList3?.Count > 1);
               // Assert.True(envList4?.Count > 1);
                Assert.True(envList5?.Count > 1);
                Assert.True(envList6?.Count > 1);
                Assert.True(envList7?.Count > 1);
                Assert.True(envList8?.Count > 1);
                Assert.True(envList9?.Count > 1);
                Assert.True(envList10?.Count > 1);

                Assert.True(envList0[1].TryGetValue("V0MCOB_NRTIT", out var val0r) && val0r.Equals("0040000040067"));
                Assert.True(envList1[1].TryGetValue("V0RCAP_NRRCAP", out var val1r) && val1r.Equals("000000000"));
                Assert.True(envList2[1].TryGetValue("V0RCOM_NRAVISO", out var val2r) && val2r.Equals("882805959"));
                Assert.True(envList3[1].TryGetValue("V0FILT_NUMSICOB", out var val3r) && val3r.Equals("000095722565727"));
               // Assert.True(envList4[1].TryGetValue("V0FOLL_NUMAPOL", out var val4r) && val4r.Equals("3053929002779"));
                Assert.True(envList5[1].TryGetValue("V0AVIS_AGEAVISO", out var val5r) && val5r.Equals("7828"));
                Assert.True(envList6[1].TryGetValue("V0SALD_SDOATU", out var val6r) && val6r.Equals("0000000000080.00"));
                Assert.True(envList7[1].TryGetValue("V0CNAB_NRCTACED", out var val7r) && val7r.Equals("000000882805959"));
                Assert.True(envList8[1].TryGetValue("V0TRBL_NRCERTIF", out var val8r) && val8r.Equals("030539290027791"));
                Assert.True(envList9[1].TryGetValue("V0CEDE_NUMTIT", out var val9r) && val9r.Equals("0095722565727"));
                Assert.True(envList10[1].TryGetValue("V0DPCF_BCOAVISO", out var val10r) && val10r.Equals("0104"));
            }
        }
    }
}