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
using static Code.PF0003B;
using Sias.PessoaFisica.DB2.PF0003B;

namespace FileTests.Test
{
    [Collection("PF0003B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class PF0003B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region PF0003B_V0AGENCIAS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0ACEF_AGENCIA" , ""},
                { "V0ACEF_ESCNEG" , ""},
                { "V0ACEF_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0003B_V0AGENCIAS", q1);

            #endregion

            #region PF0003B_V0PRDSIVPF

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0PRPF_CODSIVPF" , ""},
                { "V0PRPF_CODPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0003B_V0PRDSIVPF", q2);

            #endregion

            #region PF0003B_V0PRODUTO

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_CODPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("PF0003B_V0PRODUTO", q3);

            #endregion

            #region PF0003B_V0BILCOBER

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0BCOB_RAMOFR" , ""},
                { "V0BCOB_CODOPCAO" , ""},
                { "V0BCOB_VLPRMTAR" , ""},
                { "V0BCOB_VLPRMTOT" , ""},
                { "V0BCOB_PCIOCC" , ""},
                { "V0BCOB_DTINIVIG" , ""},
                { "V0BCOB_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0003B_V0BILCOBER", q4);

            #endregion

            #region R0290_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0CEDE_NUMTIT" , ""},
                { "V0CEDE_NUMTITMAX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0290_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0SFRC_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0700_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0SFRC_CODPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0940_00_SELECT_V0CONTROLE_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0CTIT_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0940_00_SELECT_V0CONTROLE_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1030_00_SELECT_BILHEFAI_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "BILHEFAI_COD_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_BILHEFAI_DB_SELECT_1_Query1", q9);

            #endregion

            #region R2500_00_SELECT_V0AVISOCRED_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT_AVS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_SELECT_V0AVISOCRED_DB_SELECT_1_Query1", q10);

            #endregion

            #region R2850_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_PERI_PAGAMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2850_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q11);

            #endregion

            #region R2900_00_SELECT_CONVERSAO_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "CONVSICOB_NR_SICOB" , ""},
                { "CONVSICOB_AGEPGTO" , ""},
                { "CONVSICOB_DTQITBCO" , ""},
                { "CONVSICOB_VAL_RCAP" , ""},
                { "CONVSICOB_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2900_00_SELECT_CONVERSAO_DB_SELECT_1_Query1", q12);

            #endregion
            
            #region R3700_00_INSERT_V0RCAP_DB_INSERT_1_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R3700_00_INSERT_V0RCAP_DB_INSERT_1_Insert1", q13);

            #endregion

            #region R3710_00_SELECT_V1RCAP_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V1RCAP_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3710_00_SELECT_V1RCAP_DB_SELECT_1_Query1", q14);

            #endregion
            
            #region R3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1", q15);

            #endregion

            #region R3800_00_INSERT_CONVERSAO_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R3800_00_INSERT_CONVERSAO_DB_INSERT_1_Insert1", q16);

            #endregion

            #region R3950_00_UPDATE_CONVERSAO_DB_UPDATE_1_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "CONVSICOB_DTQITBCO" , ""},
                { "CONVSICOB_VAL_RCAP" , ""},
                { "CONVSICOB_AGEPGTO" , ""},
                { "V0FILT_NUMSIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3950_00_UPDATE_CONVERSAO_DB_UPDATE_1_Update1", q17);

            #endregion

            #region R3950_00_UPDATE_CONVERSAO_DB_UPDATE_2_Update1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "CONVSICOB_DTQITBCO" , ""},
                { "CONVSICOB_VAL_RCAP" , ""},
                { "CONVSICOB_AGEPGTO" , ""},
                { "V0RCOM_DTMOVTO" , ""},
                { "V0FILT_NUMSIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3950_00_UPDATE_CONVERSAO_DB_UPDATE_2_Update1", q18);

            #endregion
            
            #region R4050_00_INSERT_V0MOVICOB_DB_INSERT_1_Insert1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R4050_00_INSERT_V0MOVICOB_DB_INSERT_1_Insert1", q19);

            #endregion
            
            #region R4100_00_INSERT_DB_INSERT_1_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R4100_00_INSERT_DB_INSERT_1_Insert1", q20);

            #endregion

            #region R4550_00_INSERT_V0AVISOCRED_DB_INSERT_1_Insert1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R4550_00_INSERT_V0AVISOCRED_DB_INSERT_1_Insert1", q21);

            #endregion

            #region R4600_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R4600_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1", q22);

            #endregion
            
            #region R4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1_Insert1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0CNAB_COD_EMP" , ""},
                { "V0CNAB_ORGAO" , ""},
                { "V0CNAB_NRCTACED" , ""},
                { "V0CNAB_TIPOCOB" , ""},
                { "V0CNAB_DTMOVTO" , ""},
                { "V0CNAB_DATCEF" , ""},
                { "V0CNAB_NRSEQ" , ""},
                { "V0CNAB_QTDREG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1_Insert1", q23);

            #endregion
            
            #region R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V0CFEN_CODEMP" , ""},
                { "V0CFEN_NUMBIL" , ""},
                { "V0CFEN_AGECOBR" , ""},
                { "V0CFEN_VALADT" , ""},
                { "V0CFEN_DTCREDITO" , ""},
                { "V0CFEN_NRMATRVEN" , ""},
                { "V0CFEN_AGECTAVEN" , ""},
                { "V0CFEN_OPRCTAVEN" , ""},
                { "V0CFEN_NUMCTAVEN" , ""},
                { "V0CFEN_DIGCTAVEN" , ""},
                { "V0CFEN_AGECTADEB" , ""},
                { "V0CFEN_OPRCTADEB" , ""},
                { "V0CFEN_NUMCTADEB" , ""},
                { "V0CFEN_DIGCTADEB" , ""},
                { "V0CFEN_SINDICO" , ""},
                { "V0CFEN_DTQITBCO" , ""},
                { "V0CFEN_VLRCAP" , ""},
                { "V0CFEN_DTMOVTO" , ""},
                { "V0CFEN_SITUACAO" , ""},
                { "V0CFEN_NRMATRGER" , ""},
                { "V0CFEN_VALADTGER" , ""},
                { "V0CFEN_DTPAGGER" , ""},
                { "V0CFEN_DTCANCEL" , ""},
                { "V0CFEN_NRMATRSUN" , ""},
                { "V0CFEN_VALADTSUN" , ""},
                { "V0CFEN_DTPAGSUN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1", q24);

            #endregion
            
            #region R6200_00_INSERT_V0VENDASBIL_DB_INSERT_1_Insert1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V0VEND_NUMBIL" , ""},
                { "V0VEND_AGECOBR" , ""},
                { "V0VEND_DTQITBCO" , ""},
                { "V0VEND_VLRCAP" , ""},
                { "V0VEND_DTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6200_00_INSERT_V0VENDASBIL_DB_INSERT_1_Insert1", q25);

            #endregion

            #region R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1", q26);

            #endregion

            #region R7100_00_INSERT_V0ADIANTA_DB_INSERT_1_Insert1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "V0ADIA_CODPDT" , ""},
                { "V0ADIA_FONTE" , ""},
                { "V0ADIA_NUMOPG" , ""},
                { "V0ADIA_VALADT" , ""},
                { "V0ADIA_QTPRESTA" , ""},
                { "V0ADIA_NRPROPOS" , ""},
                { "V0ADIA_NUMAPOL" , ""},
                { "V0ADIA_NRENDOS" , ""},
                { "V0ADIA_NRPARCEL" , ""},
                { "V0ADIA_DTMOVTO" , ""},
                { "V0ADIA_SITUACAO" , ""},
                { "V0ADIA_CODEMP" , ""},
                { "V0ADIA_TIPO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7100_00_INSERT_V0ADIANTA_DB_INSERT_1_Insert1", q27);

            #endregion

            #region R7200_00_INSERT_V0FORMAREC_DB_INSERT_1_Insert1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V0FREC_CODPDT" , ""},
                { "V0FREC_FONTE" , ""},
                { "V0FREC_NUMOPG" , ""},
                { "V0FREC_NRPROPOS" , ""},
                { "V0FREC_NUMAPOL" , ""},
                { "V0FREC_NRENDOS" , ""},
                { "V0FREC_NRPARCEL" , ""},
                { "V0FREC_NUMPTC" , ""},
                { "V0FREC_VALRCP" , ""},
                { "V0FREC_PCGACM" , ""},
                { "V0FREC_SITUACAO" , ""},
                { "V0FREC_VALSDO" , ""},
                { "V0FREC_DTMOVTO" , ""},
                { "V0FREC_DTVENCTO" , ""},
                { "V0FREC_CODEMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7200_00_INSERT_V0FORMAREC_DB_INSERT_1_Insert1", q28);

            #endregion

            #region R7300_00_INSERT_V0HISTOREC_DB_INSERT_1_Insert1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "V0HREC_CODPDT" , ""},
                { "V0HREC_FONTE" , ""},
                { "V0HREC_NUMOPG" , ""},
                { "V0HREC_NRPROPOS" , ""},
                { "V0HREC_NUMAPOL" , ""},
                { "V0HREC_NRENDOS" , ""},
                { "V0HREC_NRPARCEL" , ""},
                { "V0HREC_NUMPTC" , ""},
                { "V0HREC_VALRCP" , ""},
                { "V0HREC_NUMREC" , ""},
                { "V0HREC_DTMOVTO" , ""},
                { "V0HREC_OPERACAO" , ""},
                { "V0HREC_HORSIS" , ""},
                { "V0HREC_CODEMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7300_00_INSERT_V0HISTOREC_DB_INSERT_1_Insert1", q29);

            #endregion
            
            #region R7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "V0CEDE_NUMTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1", q30);

            #endregion

            #region R8150_00_SELECT_V0BILHETE_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMAPOL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8150_00_SELECT_V0BILHETE_DB_SELECT_1_Query1", q31);

            #endregion

            #region R8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1", q32);

            #endregion

            #region R8850_00_INSERT_V0COMISICOB_DB_INSERT_1_Insert1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V0SICB_CODEMP" , ""},
                { "V0SICB_FONTE" , ""},
                { "V0SICB_NRRCAP" , ""},
                { "V0SICB_NUMBIL" , ""},
                { "V0SICB_AGECOBR" , ""},
                { "V0SICB_NRMATRVEN" , ""},
                { "V0SICB_AGECTAVEN" , ""},
                { "V0SICB_OPRCTAVEN" , ""},
                { "V0SICB_NUMCTAVEN" , ""},
                { "V0SICB_DIGCTAVEN" , ""},
                { "V0SICB_VLCOMIS" , ""},
                { "V0SICB_DTCREDITO" , ""},
                { "V0SICB_DTQITBCO" , ""},
                { "V0SICB_DTMOVTO" , ""},
                { "V0SICB_VLRCAP" , ""},
                { "V0SICB_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8850_00_INSERT_V0COMISICOB_DB_INSERT_1_Insert1", q33);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("ARQSORT_FILE_NAME_P", "PRD.GPF.M610DSEG.D241125.alterado")]
        public static void PF0003B_Tests_Theory(string ARQSORT_FILE_NAME_P, string MOVIMENTO_COBRANCA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";

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
                var program = new PF0003B();
                program.Execute(ARQSORT_FILE_NAME_P, MOVIMENTO_COBRANCA_FILE_NAME_P);

                var envList = AppSettings.TestSet.DynamicData["R4050_00_INSERT_V0MOVICOB_DB_INSERT_1_Insert1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R4100_00_INSERT_DB_INSERT_1_Insert1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1_Insert1"].DynamicList;
                var envList3 = AppSettings.TestSet.DynamicData["R7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1"].DynamicList;
                var envList4 = AppSettings.TestSet.DynamicData["R3700_00_INSERT_V0RCAP_DB_INSERT_1_Insert1"].DynamicList;
                var envList5 = AppSettings.TestSet.DynamicData["R3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1"].DynamicList;
                var envList6 = AppSettings.TestSet.DynamicData["R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1"].DynamicList;
                var envList7 = AppSettings.TestSet.DynamicData["R6200_00_INSERT_V0VENDASBIL_DB_INSERT_1_Insert1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);
                Assert.True(envList3?.Count > 1);
                Assert.True(envList4?.Count > 1);
                Assert.True(envList5?.Count > 1);
                Assert.True(envList6?.Count > 1);
                Assert.True(envList7?.Count > 1);

                Assert.True(envList[1].TryGetValue("V0MCOB_CODEMP", out var val1r) && val1r.Equals("000000000"));
                Assert.True(envList1[1].TryGetValue("V0FOLL_NUMAPOL", out val1r) && val1r.Equals("8888814558877"));
                Assert.True(envList2[1].TryGetValue("V0CNAB_COD_EMP", out val1r) && val1r.Equals("000000000"));
                Assert.True(envList3[1].TryGetValue("V0CEDE_NUMTIT", out val1r) && val1r.Equals("0000000000000"));
                Assert.True(envList4[1].TryGetValue("V0RCAP_FONTE", out val1r) && val1r.Equals("0000"));
                Assert.True(envList5[1].TryGetValue("V0RCOM_OPERACAO", out val1r) && val1r.Equals("0110"));
                Assert.True(envList6[1].TryGetValue("V0CFEN_CODEMP", out val1r) && val1r.Equals("000000000"));
                Assert.True(envList7[1].TryGetValue("V0VEND_NUMBIL", out val1r) && val1r.Equals("000000000000000"));
            }
        }
        [Theory]
        [InlineData("ARQSORT_FILE_NAME_P", "PRD.GPF.M610DSEG.D241125.alterado2")]
        public static void PF0003B_Tests_Theory_V0CEDENTE(string ARQSORT_FILE_NAME_P, string MOVIMENTO_COBRANCA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                AppSettings.TestSet.DynamicData.Remove("R3710_00_SELECT_V1RCAP_DB_SELECT_1_Query1");
                var q14 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R3710_00_SELECT_V1RCAP_DB_SELECT_1_Query1", q14);

                #endregion

                var program = new PF0003B();
                program.Execute(ARQSORT_FILE_NAME_P, MOVIMENTO_COBRANCA_FILE_NAME_P);

                var envList = AppSettings.TestSet.DynamicData["R3950_00_UPDATE_CONVERSAO_DB_UPDATE_1_Update1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R3950_00_UPDATE_CONVERSAO_DB_UPDATE_2_Update1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);

                Assert.True(envList[1].TryGetValue("CONVSICOB_VAL_RCAP", out var val1r) && val1r.Equals("000000000000000.00"));
                Assert.True(envList1[1].TryGetValue("V0FILT_NUMSIVPF", out val1r) && val1r.Equals("088888145588777"));
            }
        }
        [Theory]
        [InlineData("ARQSORT_FILE_NAME_P", "PRD.GPF.M610DSEG.D241125.alterado2")]
        public static void PF0003B_Tests_Theory_R2900(string ARQSORT_FILE_NAME_P, string MOVIMENTO_COBRANCA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                AppSettings.TestSet.DynamicData.Remove("R2900_00_SELECT_CONVERSAO_DB_SELECT_1_Query1");
                var q12 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R2900_00_SELECT_CONVERSAO_DB_SELECT_1_Query1", q12);

                AppSettings.TestSet.DynamicData.Remove("R3710_00_SELECT_V1RCAP_DB_SELECT_1_Query1");
                var q14 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R3710_00_SELECT_V1RCAP_DB_SELECT_1_Query1", q14);
                #endregion

                var program = new PF0003B();
                program.Execute(ARQSORT_FILE_NAME_P, MOVIMENTO_COBRANCA_FILE_NAME_P);

                var envList = AppSettings.TestSet.DynamicData["R3800_00_INSERT_CONVERSAO_DB_INSERT_1_Insert1"].DynamicList;

                Assert.True(envList?.Count > 1);

                Assert.True(envList[1].TryGetValue("V0FILT_NUMSIVPF", out var val1r) && val1r.Equals("088888145588777"));
            }
        }
    }
}