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
using static Code.CB0009B;

namespace FileTests.Test
{
    [Collection("CB0009B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class CB0009B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""},
                { "V0SIST_DTPARAM" , ""},
                { "V0SIST_DTLIBERA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region CB0009B_V0AGENCIAS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0ACEF_AGENCIA" , ""},
                { "V0ACEF_ESCNEG" , ""},
                { "V0ACEF_SITUACAO" , ""},
                { "V0ACEF_FONTE" , ""},
                { "V0FONT_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0009B_V0AGENCIAS", q1);

            #endregion

            #region CB0009B_V0BILHETE

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , ""},
                { "V0BILH_NUMAPOL" , ""},
                { "V0BILH_FONTE" , ""},
                { "V0BILH_AGECOBR" , ""},
                { "V0BILH_MATRICULA" , ""},
                { "V0BILH_AGECONTA" , ""},
                { "V0BILH_OPECONTA" , ""},
                { "V0BILH_NUMCONTA" , ""},
                { "V0BILH_DIGCONTA" , ""},
                { "V0BILH_CODCLIEN" , ""},
                { "V0BILH_PROFISSAO" , ""},
                { "V0BILH_SEXO" , ""},
                { "V0BILH_ESTCIV" , ""},
                { "V0BILH_OPCOBER" , ""},
                { "V0BILH_DTQITBCO" , ""},
                { "V0BILH_VLRCAP" , ""},
                { "V0BILH_RAMO" , ""},
                { "V0BILH_DTVENDA" , ""},
                { "V0BILH_DTMOVTO" , ""},
                { "V0BILH_SITUACAO" , ""},
                { "V0BILH_CODUSU" , ""},
                { "V0BILH_FX_RENDA_IND" , ""},
                { "V0BILH_FX_RENDA_FAM" , ""},
                { "V0BILH_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0009B_V0BILHETE", q2);

            #endregion

            #region CB0009B_V0ERRO

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0ERRO_NUMBIL" , ""},
                { "V0ERRO_CODERRO" , ""},
                { "V0ERRO_MSG_CRITICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0009B_V0ERRO", q3);

            #endregion

            #region R0451_00_SELECT_BI_BIL_ACAT_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "BI_COD_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0451_00_SELECT_BI_BIL_ACAT_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0455_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0FOLL_VLPREMIO" , ""},
                { "V0FOLL_BCOAVISO" , ""},
                { "V0FOLL_AGEAVISO" , ""},
                { "V0FOLL_NRAVISO" , ""},
                { "V0FOLL_DTQITBCO" , ""},
                { "V0FOLL_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0455_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0460_00_SELECT_V0RCAP_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_VLRCAP" , ""},
                { "V0RCAP_VALPRI" , ""},
                { "V0RCAP_SITUACAO" , ""},
                { "V0RCAP_AGECOBR" , ""},
                { "V0RCOM_FONTE" , ""},
                { "V0RCOM_NRRCAP" , ""},
                { "V0RCOM_BCOAVISO" , ""},
                { "V0RCOM_AGEAVISO" , ""},
                { "V0RCOM_NRAVISO" , ""},
                { "V0RCOM_VLRCAP" , ""},
                { "V0RCOM_DATARCAP" , ""},
                { "V0RCOM_DTCADAST" , ""},
                { "V0RCOM_DTMOVTO" , ""},
                { "V0RCOM_SITCONTB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0460_00_SELECT_V0RCAP_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0460_00_SELECT_V0RCAP_DB_SELECT_2_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_VLRCAP" , ""},
                { "V0RCAP_VALPRI" , ""},
                { "V0RCAP_SITUACAO" , ""},
                { "V0RCAP_AGECOBR" , ""},
                { "V0RCOM_FONTE" , ""},
                { "V0RCOM_NRRCAP" , ""},
                { "V0RCOM_BCOAVISO" , ""},
                { "V0RCOM_AGEAVISO" , ""},
                { "V0RCOM_NRAVISO" , ""},
                { "V0RCOM_VLRCAP" , ""},
                { "V0RCOM_DATARCAP" , ""},
                { "V0RCOM_DTCADAST" , ""},
                { "V0RCOM_DTMOVTO" , ""},
                { "V0RCOM_SITCONTB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0460_00_SELECT_V0RCAP_DB_SELECT_2_Query1", q7);

            #endregion

            #region R0470_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0CFEN_AGECOBR" , ""},
                { "V0CFEN_MATRICULA" , ""},
                { "V0CFEN_AGECONTA" , ""},
                { "V0CFEN_OPECONTA" , ""},
                { "V0CFEN_NUMCONTA" , ""},
                { "V0CFEN_DIGCONTA" , ""},
                { "V0CFEN_DTQITBCO" , ""},
                { "V0CFEN_VLRCAP" , ""},
                { "V0CFEN_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0470_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1", q8);

            #endregion

            #region CB0009B_V1ERRO

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0ERRO_NUMBIL" , ""},
                { "V0ERRO_CODERRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0009B_V1ERRO", q9);

            #endregion

            #region R0565_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_SEXO" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0565_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q10);

            #endregion

            #region R0575_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_ESTCIV" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0575_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R0610_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0CLIE_CODCLIEN" , ""},
                { "V0CLIE_NOME" , ""},
                { "V0CLIE_DTNASC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0610_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0620_00_TRATA_ANO_CLIENTE_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0CLIE_DTNASC" , ""},
                { "V0CLIE_CODCLIEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0620_00_TRATA_ANO_CLIENTE_DB_UPDATE_1_Update1", q13);

            #endregion

            #region R0665_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_FX_RENDA_IND" , ""},
                { "V0BILH_FX_RENDA_FAM" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0665_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q14);

            #endregion

            #region R0900_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0BCOB_CODOPCAO" , ""},
                { "V0BCOB_DTINIVIG" , ""},
                { "V0BCOB_VLPRMTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1", q15);

            #endregion

            #region R0910_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0BCOB_CODOPCAO" , ""},
                { "V0BCOB_DTINIVIG" , ""},
                { "V0BCOB_VLPRMTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0910_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1", q16);

            #endregion

            #region R0920_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0BCOB_CODOPCAO" , ""},
                { "V0BCOB_DTINIVIG" , ""},
                { "V0BCOB_VLPRMTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0920_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1", q17);

            #endregion

            #region R0930_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0BCOB_CODOPCAO" , ""},
                { "V0BCOB_DTINIVIG" , ""},
                { "V0BCOB_VLPRMTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0930_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1", q18);

            #endregion

            #region R0940_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V0BCOB_CODOPCAO" , ""},
                { "V0BCOB_DTINIVIG" , ""},
                { "V0BCOB_VLPRMTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0940_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1", q19);

            #endregion

            #region R1510_00_SELECT_V0ERRO_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0ERRO_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1510_00_SELECT_V0ERRO_DB_SELECT_1_Query1", q20);

            #endregion

            #region R1515_00_SELECT_V0ERRO_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0ERRO_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1515_00_SELECT_V0ERRO_DB_SELECT_1_Query1", q21);

            #endregion

            #region R1550_00_SELECT_SEQ_CRTCA_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "WS_SEQ_CRITICA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1550_00_SELECT_SEQ_CRTCA_DB_SELECT_1_Query1", q22);

            #endregion

            #region R2000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "WSHOST_AGECOBR" , ""},
                { "WSHOST_FONTE" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q23);

            #endregion

            #region R2100_00_UPDATE_V0COFENAE_DB_UPDATE_1_Update1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_AGECOBR" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_UPDATE_V0COFENAE_DB_UPDATE_1_Update1", q24);

            #endregion

            #region R2230_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_PROFISSAO" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2230_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q25);

            #endregion

            #region R2250_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V0BCOB_CODOPCAO" , ""},
                { "V0RCOM_DATARCAP" , ""},
                { "V0BCOB_VLPRMTOT" , ""},
                { "V0SIST_DTMOVABE" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2250_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q26);

            #endregion

            #region R2255_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "VAL_PAGO_FIDELIZ" , ""},
                { "V0RCOM_DATARCAP" , ""},
                { "V0RCOM_DTMOVTO" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2255_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1", q27);

            #endregion

            #region R2400_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_SITUACAO" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q28);

            #endregion

            #region R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_SITUACAO" , ""},
                { "V0BILH_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q29);

            #endregion

            #region CB0009B_V2ERRO

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "V0ERRO_NUMBIL" , ""},
                { "V0ERRO_CODERRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0009B_V2ERRO", q30);

            #endregion

            #region CB0009B_V0COBERTURA

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "V0BCOB_CODOPCAO" , ""},
                { "V0BCOB_DTINIVIG" , ""},
                { "V0BCOB_VLPRMTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0009B_V0COBERTURA", q31);

            #endregion

            #region CB0009B_V1BILHETE

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , ""},
                { "V0BILH_SITUACAO" , ""},
                { "V0BILH_CODUSU" , ""},
                { "V0BILH_DTCANCEL" , ""},
                { "V0BILH_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0009B_V1BILHETE", q32);

            #endregion

            #region R4100_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V0RCOM_FONTE" , ""},
                { "V0RCOM_NRRCAP" , ""},
                { "V0RCOM_NRRCAPCO" , ""},
                { "V0RCOM_OPERACAO" , ""},
                { "V0RCOM_DTMOVTO" , ""},
                { "V0RCOM_SITUACAO" , ""},
                { "V0FOLL_BCOAVISO" , ""},
                { "V0FOLL_AGEAVISO" , ""},
                { "V0FOLL_NRAVISO" , ""},
                { "V0FOLL_VLPREMIO" , ""},
                { "V0FOLL_DTQITBCO" , ""},
                { "V0RCOM_DTCADAST" , ""},
                { "V0RCOM_SITCONTB" , ""},
                { "V0RCOM_CODEMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4100_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1", q33);

            #endregion

            #region R4150_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_VLRCAP" , ""},
                { "V0RCAP_NRRCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4150_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1", q34);

            #endregion

            #region R4200_00_UPDATE_V0FOLLOWUP_DB_UPDATE_1_Update1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""},
                { "V0FOLL_NUMAPOL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4200_00_UPDATE_V0FOLLOWUP_DB_UPDATE_1_Update1", q35);

            #endregion

            #region R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "V0CFEN_CODEMP" , ""},
                { "V0CFEN_NUMBIL" , ""},
                { "V0CFEN_AGECOBR" , ""},
                { "V0CFEN_VALADT" , ""},
                { "V0CFEN_DTCREDITO" , ""},
                { "V0CFEN_MATRICULA" , ""},
                { "V0CFEN_AGECONTA" , ""},
                { "V0CFEN_OPECONTA" , ""},
                { "V0CFEN_NUMCONTA" , ""},
                { "V0CFEN_DIGCONTA" , ""},
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
            AppSettings.TestSet.DynamicData.Add("R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1", q36);

            #endregion

            #region R6300_00_SELECIONA_PRODUTO_DB_SELECT_1_Query1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "V0BILP_CODPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6300_00_SELECIONA_PRODUTO_DB_SELECT_1_Query1", q37);

            #endregion

            #region R6550_00_SELECT_TARIFA_BALCAO_DB_SELECT_1_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "V0ERRO_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6550_00_SELECT_TARIFA_BALCAO_DB_SELECT_1_Query1", q38);

            #endregion

            #region R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1", q39);

            #endregion

            #region CB0009B_CCBO

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , ""},
                { "CBO_DESCR_CBO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0009B_CCBO", q40);

            #endregion

            #region R7160_00_SELECT_V0RCAP_DB_SELECT_1_Query1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7160_00_SELECT_V0RCAP_DB_SELECT_1_Query1", q41);

            #endregion

            #region R7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1_Query1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "BILFAI_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1_Query1", q42);

            #endregion

            #region R7170_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_DTCANCEL" , ""},
                { "VIND_DTCANCEL" , ""},
                { "V0BILH_SITUACAO" , ""},
                { "V0BILH_RAMO" , ""},
                { "V0SIST_DTLIBERA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7170_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q43);

            #endregion

            #region R7180_00_SELECT_PROPIDELIZ_DB_SELECT_1_Query1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "PRPFIDEL_ORIGEM" , ""},
                { "PRPFIDEL_COD_PLANO" , ""},
                { "PRPFIDEL_CANAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7180_00_SELECT_PROPIDELIZ_DB_SELECT_1_Query1", q44);

            #endregion

            #region R7200_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_DTCANCEL" , ""},
                { "VIND_DTCANCEL" , ""},
                { "V0BILH_SITUACAO" , ""},
                { "V0BILH_RAMO" , ""},
                { "V0SIST_DTLIBERA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7200_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q45);

            #endregion

            #region R7210_00_DELETE_V0COMISSAO_DB_DELETE_1_Delete1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7210_00_DELETE_V0COMISSAO_DB_DELETE_1_Delete1", q46);

            #endregion

            #region R7600_00_SELECT_V0BILHETE_DB_SELECT_1_Query1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMAPOL" , ""},
                { "V0BILH_FONTE" , ""},
                { "V0BILH_AGECOBR" , ""},
                { "V0BILH_MATRICULA" , ""},
                { "V0BILH_AGECONTA" , ""},
                { "V0BILH_OPECONTA" , ""},
                { "V0BILH_NUMCONTA" , ""},
                { "V0BILH_DIGCONTA" , ""},
                { "V0BILH_CODCLIEN" , ""},
                { "V0BILH_PROFISSAO" , ""},
                { "V0BILH_SEXO" , ""},
                { "V0BILH_ESTCIV" , ""},
                { "V0BILH_OCOREND" , ""},
                { "V0BILH_AGECONDEB" , ""},
                { "V0BILH_OPECONDEB" , ""},
                { "V0BILH_NUMCONDEB" , ""},
                { "V0BILH_DIGCONDEB" , ""},
                { "V0BILH_OPCOBER" , ""},
                { "V0BILH_DTQITBCO" , ""},
                { "V0BILH_VLRCAP" , ""},
                { "V0BILH_RAMO" , ""},
                { "V0BILH_DTVENDA" , ""},
                { "V0BILH_NUMAPOLANT" , ""},
                { "V0BILH_TIPCANCEL" , ""},
                { "V0BILH_TIPSINIST" , ""},
                { "V0BILH_FX_RENDA_IND" , ""},
                { "V0BILH_FX_RENDA_FAM" , ""},
                { "V0BILH_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7600_00_SELECT_V0BILHETE_DB_SELECT_1_Query1", q47);

            #endregion

            #region R7650_00_INSERT_V0BILHETE_DB_INSERT_1_Insert1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , ""},
                { "V0BILH_NUMAPOL" , ""},
                { "V0BILH_FONTE" , ""},
                { "V0BILH_AGECOBR" , ""},
                { "V0BILH_MATRICULA" , ""},
                { "V0BILH_AGECONTA" , ""},
                { "V0BILH_OPECONTA" , ""},
                { "V0BILH_NUMCONTA" , ""},
                { "V0BILH_DIGCONTA" , ""},
                { "V0BILH_CODCLIEN" , ""},
                { "V0BILH_PROFISSAO" , ""},
                { "V0BILH_SEXO" , ""},
                { "V0BILH_ESTCIV" , ""},
                { "V0BILH_OCOREND" , ""},
                { "V0BILH_AGECONDEB" , ""},
                { "V0BILH_OPECONDEB" , ""},
                { "V0BILH_NUMCONDEB" , ""},
                { "V0BILH_DIGCONDEB" , ""},
                { "V0BILH_OPCOBER" , ""},
                { "V0BILH_DTQITBCO" , ""},
                { "V0BILH_VLRCAP" , ""},
                { "V0BILH_RAMO" , ""},
                { "V0BILH_DTVENDA" , ""},
                { "V0BILH_DTMOVTO" , ""},
                { "V0BILH_NUMAPOLANT" , ""},
                { "V0BILH_SITUACAO" , ""},
                { "V0BILH_TIPCANCEL" , ""},
                { "V0BILH_TIPSINIST" , ""},
                { "V0BILH_CODUSU" , ""},
                { "V0BILH_DTCANCEL" , ""},
                { "V0BILH_FX_RENDA_IND" , ""},
                { "V0BILH_FX_RENDA_FAM" , ""},
                { "V0BILH_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7650_00_INSERT_V0BILHETE_DB_INSERT_1_Insert1", q48);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("CB0009B_SortFile.txt")]
        public static void CB0009B_Tests_Theory_Execution1_ReturnCode_0(string ARQSORT_FILE_NAME_P)
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
                #region CB0009B_V0BILHETE

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , "84510068880"},
                { "V0BILH_NUMAPOL" , "0"},
                { "V0BILH_FONTE" , "21"},
                { "V0BILH_AGECOBR" , "2741"},
                { "V0BILH_MATRICULA" , "7777777"},
                { "V0BILH_AGECONTA" , "0"},
                { "V0BILH_OPECONTA" , "0"},
                { "V0BILH_NUMCONTA" , "0"},
                { "V0BILH_DIGCONTA" , "0"},
                { "V0BILH_CODCLIEN" , "18329689"},
                { "V0BILH_PROFISSAO" , "ESTAGIARIA          "},
                { "V0BILH_SEXO" , "F"},
                { "V0BILH_ESTCIV" , "C"},
                { "V0BILH_OPCOBER" , "21"},
                { "V0BILH_DTQITBCO" , "2012-04-05"},
                { "V0BILH_VLRCAP" , "60.00"},
                { "V0BILH_RAMO" , "81"},
                { "V0BILH_DTVENDA" , "2012-05-04"},
                { "V0BILH_DTMOVTO" , "2012-05-04"},
                { "V0BILH_SITUACAO" , "1"},
                { "V0BILH_CODUSU" , "CB0009B"},
                { "V0BILH_FX_RENDA_IND" , "1"},
                { "V0BILH_FX_RENDA_FAM" , "1"},
                { "V0BILH_COD_PRODUTO" , "0"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , "84510068880"},
                { "V0BILH_NUMAPOL" , "0"},
                { "V0BILH_FONTE" , "21"},
                { "V0BILH_AGECOBR" , "2741"},
                { "V0BILH_MATRICULA" , "7777777"},
                { "V0BILH_AGECONTA" , "0"},
                { "V0BILH_OPECONTA" , "0"},
                { "V0BILH_NUMCONTA" , "0"},
                { "V0BILH_DIGCONTA" , "0"},
                { "V0BILH_CODCLIEN" , "18329689"},
                { "V0BILH_PROFISSAO" , "ESTAGIARIA          "},
                { "V0BILH_SEXO" , "F"},
                { "V0BILH_ESTCIV" , "C"},
                { "V0BILH_OPCOBER" , "21"},
                { "V0BILH_DTQITBCO" , "2012-04-05"},
                { "V0BILH_VLRCAP" , "60.00"},
                { "V0BILH_RAMO" , "81"},
                { "V0BILH_DTVENDA" , "2012-05-04"},
                { "V0BILH_DTMOVTO" , "2012-05-04"},
                { "V0BILH_SITUACAO" , "1"},
                { "V0BILH_CODUSU" , "CB0009B"},
                { "V0BILH_FX_RENDA_IND" , "1"},
                { "V0BILH_FX_RENDA_FAM" , "1"},
                { "V0BILH_COD_PRODUTO" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("CB0009B_V0BILHETE");
                AppSettings.TestSet.DynamicData.Add("CB0009B_V0BILHETE", q2);

                #endregion
                #region R1510_00_SELECT_V0ERRO_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "V0ERRO_COUNT" , "1"}
                });
                q20.AddDynamic(new Dictionary<string, string>{
                { "V0ERRO_COUNT" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1510_00_SELECT_V0ERRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1510_00_SELECT_V0ERRO_DB_SELECT_1_Query1", q20);

                #endregion
                #region CB0009B_V1BILHETE

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                //{ "V0BILH_NUMBIL" , "84693721643"},
                { "V0BILH_NUMBIL" , "84693721641"},
                { "V0BILH_SITUACAO" , "0"},
                { "V0BILH_CODUSU" , "CB0009B "},
                { "V0BILH_DTCANCEL" , ""},
                { "V0BILH_RAMO" , "82"},
                });
                AppSettings.TestSet.DynamicData.Remove("CB0009B_V1BILHETE");
                AppSettings.TestSet.DynamicData.Add("CB0009B_V1BILHETE", q32);

                #endregion
                #region R7160_00_SELECT_V0RCAP_DB_SELECT_1_Query1

                var q41 = new DynamicData();
                q41.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_SITUACAO" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R7160_00_SELECT_V0RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7160_00_SELECT_V0RCAP_DB_SELECT_1_Query1", q41);

                #endregion
                #region R7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1_Query1

                var q42 = new DynamicData();
                q42.AddDynamic(new Dictionary<string, string>{
                { "BILFAI_RAMO" , "81"}
                });
                AppSettings.TestSet.DynamicData.Remove("R7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1_Query1", q42);

                #endregion

                #region CB0009B_CCBO

                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "4"},
                { "CBO_DESCR_CBO" , "PROFESSOR"},
                });
                q40.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "2"},
                { "CBO_DESCR_CBO" , "AUTONOMO"},
                });
                AppSettings.TestSet.DynamicData.Remove("CB0009B_CCBO");
                AppSettings.TestSet.DynamicData.Add("CB0009B_CCBO", q40);

                #endregion
                #region R7600_00_SELECT_V0BILHETE_DB_SELECT_1_Query1

                var q47 = new DynamicData();
                q47.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMAPOL" , "1019790324"},
                { "V0BILH_FONTE" , "21"},
                { "V0BILH_AGECOBR" , "345"},
                { "V0BILH_MATRICULA" , "2592750"},
                { "V0BILH_AGECONTA" , ""},
                { "V0BILH_OPECONTA" , ""},
                { "V0BILH_NUMCONTA" , ""},
                { "V0BILH_DIGCONTA" , ""},
                { "V0BILH_CODCLIEN" , "5746706"},
                { "V0BILH_PROFISSAO" , "CONTADOR            "},
                { "V0BILH_SEXO" , "M"},
                { "V0BILH_ESTCIV" , "S"},
                { "V0BILH_OCOREND" , "1"},
                { "V0BILH_AGECONDEB" , ""},
                { "V0BILH_OPECONDEB" , ""},
                { "V0BILH_NUMCONDEB" , ""},
                { "V0BILH_DIGCONDEB" , ""},
                { "V0BILH_OPCOBER" , ""},
                { "V0BILH_DTQITBCO" , ""},
                { "V0BILH_VLRCAP" , ""},
                { "V0BILH_RAMO" , "82"},
                { "V0BILH_DTVENDA" , ""},
                { "V0BILH_NUMAPOLANT" , ""},
                { "V0BILH_TIPCANCEL" , ""},
                { "V0BILH_TIPSINIST" , ""},
                { "V0BILH_FX_RENDA_IND" , ""},
                { "V0BILH_FX_RENDA_FAM" , ""},
                { "V0BILH_COD_PRODUTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R7600_00_SELECT_V0BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7600_00_SELECT_V0BILHETE_DB_SELECT_1_Query1", q47);

                #endregion

                #endregion
                var program = new CB0009B();
                program.Execute(ARQSORT_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                //R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("V0BILH_NUMBIL", out var valor0) && valor0.Contains("000084510068880"));
                
                //R7170_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["R7170_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("V0BILH_RAMO", out var valor1) && valor1.Contains("81"));
                
                //R7200_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R7200_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("V0BILH_SITUACAO", out var valor2) && valor2.Contains("8"));
                
                //R7650_00_INSERT_V0BILHETE_DB_INSERT_1_Insert1
                var envList3 = AppSettings.TestSet.DynamicData["R7650_00_INSERT_V0BILHETE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("V0BILH_NUMAPOL", out var valor3) && valor3.Contains("000001019790324"));
                Assert.True(envList3.Count > 1);
            }
        }
        [Theory]
        [InlineData("CB0009B_SortFile.txt")]
        public static void CB0009B_Tests_Theory_Execution2_ReturnCode_0(string ARQSORT_FILE_NAME_P)
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
                #region CB0009B_V0BILHETE

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
               // { "V0BILH_NUMBIL" , "84510068880"},
                { "V0BILH_NUMBIL" , "84518482341"},
                { "V0BILH_NUMAPOL" , "0"},
                { "V0BILH_FONTE" , "21"},
                { "V0BILH_AGECOBR" , "2741"},
                { "V0BILH_MATRICULA" , "7777777"},
                { "V0BILH_AGECONTA" , "0"},
                { "V0BILH_OPECONTA" , "0"},
                { "V0BILH_NUMCONTA" , "0"},
                { "V0BILH_DIGCONTA" , "0"},
                { "V0BILH_CODCLIEN" , "18329689"},
                { "V0BILH_PROFISSAO" , "ESTAGIARIA          "},
                { "V0BILH_SEXO" , "T"},
                { "V0BILH_ESTCIV" , "C"},
                { "V0BILH_OPCOBER" , "21"},
                { "V0BILH_DTQITBCO" , "2012-04-05"},
                { "V0BILH_VLRCAP" , "60.00"},
                { "V0BILH_RAMO" , "81"},
                { "V0BILH_DTVENDA" , "2012-05-04"},
                { "V0BILH_DTMOVTO" , "2012-05-04"},
                { "V0BILH_SITUACAO" , "1"},
                { "V0BILH_CODUSU" , "CB0009B"},
                { "V0BILH_FX_RENDA_IND" , "1"},
                { "V0BILH_FX_RENDA_FAM" , "1"},
                { "V0BILH_COD_PRODUTO" , "0"},
                });

                AppSettings.TestSet.DynamicData.Remove("CB0009B_V0BILHETE");
                AppSettings.TestSet.DynamicData.Add("CB0009B_V0BILHETE", q2);

                #endregion
                #region CB0009B_V0ERRO

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0ERRO_NUMBIL" , ""},
                { "V0ERRO_CODERRO" , "1200"},
                { "V0ERRO_MSG_CRITICA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("CB0009B_V0ERRO");
                AppSettings.TestSet.DynamicData.Add("CB0009B_V0ERRO", q3);

                #endregion

                #region R0455_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V0FOLL_VLPREMIO" , "1"},
                { "V0FOLL_BCOAVISO" , "104"},
                { "V0FOLL_AGEAVISO" , "545"},
                { "V0FOLL_NRAVISO" , "8837"},
                { "V0FOLL_DTQITBCO" , "2020-03-03"},
                { "V0FOLL_SITUACAO" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0455_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0455_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1", q5);

                #endregion
                #region R0460_00_SELECT_V0RCAP_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_VLRCAP" , "0"},
                { "V0RCAP_VALPRI" , "0"},
                { "V0RCAP_SITUACAO" , "0"},
                { "V0RCAP_AGECOBR" , ""},
                { "V0RCOM_FONTE" , "21"},
                { "V0RCOM_NRRCAP" , "25493"},
                { "V0RCOM_BCOAVISO" , "104"},
                { "V0RCOM_AGEAVISO" , "545"},
                { "V0RCOM_NRAVISO" , "20925"},
                { "V0RCOM_VLRCAP" , "0"},
                { "V0RCOM_DATARCAP" , "1999-05-05"},
                { "V0RCOM_DTCADAST" , "2022-05-18"},
                { "V0RCOM_DTMOVTO" , "2012-06-12"},
                { "V0RCOM_SITCONTB" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0460_00_SELECT_V0RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0460_00_SELECT_V0RCAP_DB_SELECT_1_Query1", q6);

                #endregion
                #region R0470_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1

                var q8 = new DynamicData();
               // q8.AddDynamic(new Dictionary<string, string>{
               // { "V0CFEN_AGECOBR" , "345"},
               // { "V0CFEN_MATRICULA" , "426259"},
               // { "V0CFEN_AGECONTA" , "0"},
               // { "V0CFEN_OPECONTA" , "0"},
               // { "V0CFEN_NUMCONTA" , "0"},
               // { "V0CFEN_DIGCONTA" , "0"},
               // { "V0CFEN_DTQITBCO" , "2020-01-01"},
               // { "V0CFEN_VLRCAP" , "41"},
               // { "V0CFEN_SITUACAO" , "0"},
               // });
                AppSettings.TestSet.DynamicData.Remove("R0470_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0470_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1", q8);

                #endregion
                #region R0900_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "V0BCOB_CODOPCAO" , "1"},
                { "V0BCOB_DTINIVIG" , "2009-03-03"},
                { "V0BCOB_VLPRMTOT" , "41"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1", q15);

                #endregion

                #region R1515_00_SELECT_V0ERRO_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1515_00_SELECT_V0ERRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1515_00_SELECT_V0ERRO_DB_SELECT_1_Query1", q21);

                #endregion

                #region R1510_00_SELECT_V0ERRO_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "V0ERRO_COUNT" , "1"}
                });
                q20.AddDynamic(new Dictionary<string, string>{
                { "V0ERRO_COUNT" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1510_00_SELECT_V0ERRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1510_00_SELECT_V0ERRO_DB_SELECT_1_Query1", q20);

                #endregion
                #region CB0009B_V1BILHETE

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , "84693721643"},
                //{ "V0BILH_NUMBIL" , "84693721641"},
                { "V0BILH_SITUACAO" , "0"},
                { "V0BILH_CODUSU" , "CB0009B "},
                { "V0BILH_DTCANCEL" , ""},
                { "V0BILH_RAMO" , "82"},
                });
                q32.AddDynamic(new Dictionary<string, string>{
                //{ "V0BILH_NUMBIL" , "84693721643"},
                { "V0BILH_NUMBIL" , "84693721641"},
                { "V0BILH_SITUACAO" , "1"},
                { "V0BILH_CODUSU" , "CB0009B "},
                { "V0BILH_DTCANCEL" , ""},
                { "V0BILH_RAMO" , "82"},
                });
                AppSettings.TestSet.DynamicData.Remove("CB0009B_V1BILHETE");
                AppSettings.TestSet.DynamicData.Add("CB0009B_V1BILHETE", q32);

                #endregion
                #region R6550_00_SELECT_TARIFA_BALCAO_DB_SELECT_1_Query1

                var q38 = new DynamicData();
                q38.AddDynamic(new Dictionary<string, string>{
                { "V0ERRO_COUNT" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R6550_00_SELECT_TARIFA_BALCAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R6550_00_SELECT_TARIFA_BALCAO_DB_SELECT_1_Query1", q38);

                #endregion
                #region R7160_00_SELECT_V0RCAP_DB_SELECT_1_Query1

                var q41 = new DynamicData();
                q41.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_SITUACAO" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R7160_00_SELECT_V0RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7160_00_SELECT_V0RCAP_DB_SELECT_1_Query1", q41);

                #endregion
                #region R7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1_Query1

                var q42 = new DynamicData();
                q42.AddDynamic(new Dictionary<string, string>{
                { "BILFAI_RAMO" , "81"}
                });
                AppSettings.TestSet.DynamicData.Remove("R7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1_Query1", q42);

                #endregion

                #region CB0009B_CCBO

                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "4"},
                { "CBO_DESCR_CBO" , "PROFESSOR"},
                });
                q40.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "2"},
                { "CBO_DESCR_CBO" , "AUTONOMO"},
                });
                AppSettings.TestSet.DynamicData.Remove("CB0009B_CCBO");
                AppSettings.TestSet.DynamicData.Add("CB0009B_CCBO", q40);

                #endregion

                #region R7180_00_SELECT_PROPIDELIZ_DB_SELECT_1_Query1

                var q44 = new DynamicData();
                q44.AddDynamic(new Dictionary<string, string>{
                { "PRPFIDEL_ORIGEM" , "6"},
                { "PRPFIDEL_COD_PLANO" , "0"},
                { "PRPFIDEL_CANAL" , "1"},
                });
                q44.AddDynamic(new Dictionary<string, string>{
                { "PRPFIDEL_ORIGEM" , "6"},
                { "PRPFIDEL_COD_PLANO" , "1"},
                { "PRPFIDEL_CANAL" , "2"},
                });
                AppSettings.TestSet.DynamicData.Remove("R7180_00_SELECT_PROPIDELIZ_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7180_00_SELECT_PROPIDELIZ_DB_SELECT_1_Query1", q44);

                #endregion


                #region R7600_00_SELECT_V0BILHETE_DB_SELECT_1_Query1

                var q47 = new DynamicData();
                q47.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMAPOL" , "1019790324"},
                { "V0BILH_FONTE" , "21"},
                { "V0BILH_AGECOBR" , "345"},
                { "V0BILH_MATRICULA" , "2592750"},
                { "V0BILH_AGECONTA" , ""},
                { "V0BILH_OPECONTA" , ""},
                { "V0BILH_NUMCONTA" , ""},
                { "V0BILH_DIGCONTA" , ""},
                { "V0BILH_CODCLIEN" , "5746706"},
                { "V0BILH_PROFISSAO" , "CONTADOR            "},
                { "V0BILH_SEXO" , "M"},
                { "V0BILH_ESTCIV" , "S"},
                { "V0BILH_OCOREND" , "1"},
                { "V0BILH_AGECONDEB" , ""},
                { "V0BILH_OPECONDEB" , ""},
                { "V0BILH_NUMCONDEB" , ""},
                { "V0BILH_DIGCONDEB" , ""},
                { "V0BILH_OPCOBER" , ""},
                { "V0BILH_DTQITBCO" , ""},
                { "V0BILH_VLRCAP" , ""},
                { "V0BILH_RAMO" , "82"},
                { "V0BILH_DTVENDA" , ""},
                { "V0BILH_NUMAPOLANT" , ""},
                { "V0BILH_TIPCANCEL" , ""},
                { "V0BILH_TIPSINIST" , ""},
                { "V0BILH_FX_RENDA_IND" , ""},
                { "V0BILH_FX_RENDA_FAM" , ""},
                { "V0BILH_COD_PRODUTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R7600_00_SELECT_V0BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7600_00_SELECT_V0BILHETE_DB_SELECT_1_Query1", q47);

                #endregion

                #endregion
                var program = new CB0009B();
                program.Execute(ARQSORT_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                //R0565_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["R0565_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("V0BILH_NUMBIL", out var valor0) && valor0.Contains("000084518482341"));

                //R2250_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["R2250_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("V0RCOM_DATARCAP", out var valor1) && valor1.Contains("1999-05-05"));

                //R2255_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R2255_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("V0RCOM_DTMOVTO", out var valor2) && valor2.Contains("2012-06-12"));

                //R2400_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList3 = AppSettings.TestSet.DynamicData["R2400_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("V0BILH_SITUACAO", out var valor3) && valor3.Contains("0"));

                //R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList4 = AppSettings.TestSet.DynamicData["R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("V0BILH_NUMBIL", out var valor4) && valor4.Contains("000084518482341"));

                //R4100_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1
                var envList5 = AppSettings.TestSet.DynamicData["R4100_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("V0RCOM_NRRCAPCO", out var valor5) && valor5.Contains("000025493"));
                Assert.True(envList5.Count > 1);

                //R4150_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1
                var envList6 = AppSettings.TestSet.DynamicData["R4150_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList6[1].TryGetValue("V0RCAP_NRRCAP", out var valor6) && valor6.Contains("451848234"));

                //R4200_00_UPDATE_V0FOLLOWUP_DB_UPDATE_1_Update1
                var envList7 = AppSettings.TestSet.DynamicData["R4200_00_UPDATE_V0FOLLOWUP_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList7[1].TryGetValue("V0FOLL_NUMAPOL", out var valor7) && valor7.Contains("0084518482341"));

                //R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1
                var envList8 = AppSettings.TestSet.DynamicData["R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList8[1].TryGetValue("V0CFEN_AGECOBR", out var valor8) && valor8.Contains("2741"));
                Assert.True(envList8.Count > 1);

                //R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1
                var envList9 = AppSettings.TestSet.DynamicData["R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList9[1].TryGetValue("V0TRBL_CODPRODU", out var valor9) && valor9.Contains("8201"));
                Assert.True(envList9.Count > 1);

                //R7170_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList10 = AppSettings.TestSet.DynamicData["R7170_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList10[1].TryGetValue("V0BILH_RAMO", out var valor10) && valor10.Contains("81"));

                //R7200_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList11 = AppSettings.TestSet.DynamicData["R7200_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList11[1].TryGetValue("V0BILH_SITUACAO", out var valor11) && valor11.Contains("8"));

                //R7650_00_INSERT_V0BILHETE_DB_INSERT_1_Insert1
                var envList12 = AppSettings.TestSet.DynamicData["R7650_00_INSERT_V0BILHETE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList12[1].TryGetValue("V0BILH_NUMAPOL", out var valor12) && valor12.Contains("000001019790324"));
                Assert.True(envList12.Count > 1);


            }
        }
        [Theory]
        [InlineData("CB0009B_SortFile.txt")]
        public static void CB0009B_Tests_Theory_ReturnCode_99(string ARQSORT_FILE_NAME_P)
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
                #region CB0009B_V0BILHETE

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUMBIL" , "84510068880"},
                { "V0BILH_NUMAPOL" , "0"},
                { "V0BILH_FONTE" , "21"},
                { "V0BILH_AGECOBR" , "2741"},
                { "V0BILH_MATRICULA" , "7777777"},
                { "V0BILH_AGECONTA" , "0"},
                { "V0BILH_OPECONTA" , "0"},
                { "V0BILH_NUMCONTA" , "0"},
                { "V0BILH_RAMO" , "81"},
                { "V0BILH_DTVENDA" , "2012-05-04"},
                { "V0BILH_DTMOVTO" , "2012-05-04"},
                { "V0BILH_SITUACAO" , "1"},
                { "V0BILH_CODUSU" , "CB0009B"},
                { "V0BILH_FX_RENDA_IND" , "1"},
                { "V0BILH_FX_RENDA_FAM" , "1"},
                { "V0BILH_COD_PRODUTO" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("CB0009B_V0BILHETE");
                AppSettings.TestSet.DynamicData.Add("CB0009B_V0BILHETE", q2);

                #endregion
                
                #endregion
                var program = new CB0009B();
                program.Execute(ARQSORT_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}