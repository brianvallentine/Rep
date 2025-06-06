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
using static Code.EM0202B;

namespace FileTests.Test
{
    [Collection("EM0202B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM0202B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_ULTIMO_NUMERO_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0CHEQ_CHQINT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_ULTIMO_NUMERO_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_SISTEMAS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_HRMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_SISTEMAS_DB_SELECT_1_Query1", q1);

            #endregion

            #region EM0202B_V1RELATORIOS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_NUM_APOL" , ""},
                { "V1RELA_NRENDOS" , ""},
                { "V1RELA_ORGAO" , ""},
                { "V1RELA_RAMO" , ""},
                { "V1RELA_FONTE" , ""},
                { "V1RELA_CODPDT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0202B_V1RELATORIOS", q2);

            #endregion

            #region EM0202B_EMISDIA

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1EDIA_CODRELAT" , ""},
                { "V1EDIA_NUM_APOL" , ""},
                { "V1EDIA_NRENDOS" , ""},
                { "V1EDIA_FONTE" , ""},
                { "V1EDIA_ORGAO" , ""},
                { "V1EDIA_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0202B_EMISDIA", q3);

            #endregion

            #region R0330_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1EDIA_CODRELAT" , ""},
                { "V1EDIA_NUM_APOL" , ""},
                { "V1EDIA_NRENDOS" , ""},
                { "V1EDIA_NRPARCEL" , ""},
                { "V1EDIA_DTMOVTO" , ""},
                { "V1EDIA_ORGAO" , ""},
                { "V1EDIA_RAMO" , ""},
                { "V1EDIA_FONTE" , ""},
                { "V1EDIA_CONGENER" , ""},
                { "V1EDIA_CODCORR" , ""},
                { "V1EDIA_SITUACAO" , ""},
                { "V1EDIA_COD_EMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0330_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1", q4);

            #endregion

            #region R0340_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0340_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q5);

            #endregion

            #region R0400_00_LER_FINANCEIRO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE_FI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0400_00_LER_FINANCEIRO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1100_00_LER_HISTOPARC_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1HIST_NUM_APOL" , ""},
                { "V1HIST_NRENDOS" , ""},
                { "V1HIST_NRPARCEL" , ""},
                { "V1HIST_DACPARC" , ""},
                { "V1HIST_DTMOVTO" , ""},
                { "V1HIST_OPERACAO" , ""},
                { "V1HIST_OCORHIST" , ""},
                { "V1HIST_PRM_TARIF" , ""},
                { "V1HIST_DESCONTO" , ""},
                { "V1HIST_VLPRMLIQ" , ""},
                { "V1HIST_VLADIFRA" , ""},
                { "V1HIST_VLCUSEMI" , ""},
                { "V1HIST_VLIOCC" , ""},
                { "V1HIST_VLPRMTOT" , ""},
                { "V1HIST_VLPREMIO" , ""},
                { "V1HIST_DTVENCTO" , ""},
                { "V1HIST_BCOCOBR" , ""},
                { "V1HIST_AGECOBR" , ""},
                { "V1HIST_NRAVISO" , ""},
                { "V1HIST_NRENDOCA" , ""},
                { "V1HIST_SITCONTB" , ""},
                { "V1HIST_USUARIO" , ""},
                { "V1HIST_RNUDOC" , ""},
                { "V1HIST_DTQITBCO" , ""},
                { "V1HIST_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_LER_HISTOPARC_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1200_00_LER_PARCELA_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_LER_PARCELA_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1200_00_LER_PARCELA_DB_SELECT_2_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_LER_PARCELA_DB_SELECT_2_Query1", q9);

            #endregion

            #region R1300_00_LER_ENDOSSO_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_TIPO_END" , ""},
                { "V1ENDO_RAMO" , ""},
                { "V1ENDO_CODPRODU" , ""},
                { "V1ENDO_OCORREND" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_LER_ENDOSSO_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1400_00_LER_APOLICE_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NOME" , ""},
                { "V1APOL_CODCLIEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_LER_APOLICE_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1400_00_LER_APOLICE_DB_SELECT_2_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NOME" , ""},
                { "V1APOL_CODCLIEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_LER_APOLICE_DB_SELECT_2_Query1", q12);

            #endregion

            #region R1410_00_LER_APOLICE_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NOME" , ""},
                { "V1APOL_CODCLIEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1410_00_LER_APOLICE_DB_SELECT_1_Query1", q13);

            #endregion

            #region R1500_00_LER_FONTE_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_NOMEFTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_LER_FONTE_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1500_00_LER_FONTE_DB_SELECT_2_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_CIDADE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_LER_FONTE_DB_SELECT_2_Query1", q15);

            #endregion

            #region R1710_00_GRAVA_TCHEQUES_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0CHEQ_TPMOVTO" , ""},
                { "V0CHEQ_FONTE" , ""},
                { "V0CHEQ_NUMDOC" , ""},
                { "V0CHEQ_NOMFAV" , ""},
                { "V0CHEQ_VALCHQ" , ""},
                { "V0CHEQ_DTMOVTO" , ""},
                { "V0CHEQ_CHQINT" , ""},
                { "V0CHEQ_DIGINT" , ""},
                { "V0CHEQ_SITUACAO" , ""},
                { "V0CHEQ_TIPPAG" , ""},
                { "V0CHEQ_DATCMP" , ""},
                { "V0CHEQ_PRAPAG" , ""},
                { "V0CHEQ_NUMREC" , ""},
                { "V0CHEQ_OCORHIST" , ""},
                { "V0CHEQ_OPERACAO" , ""},
                { "V0CHEQ_CODDSA" , ""},
                { "V0CHEQ_VALIRF" , ""},
                { "V0CHEQ_VALISS" , ""},
                { "V0CHEQ_VALIAP" , ""},
                { "V0CHEQ_CODLAN" , ""},
                { "V0CHEQ_DATLAN" , ""},
                { "V0CHEQ_EMPRESA" , ""},
                { "V0CHEQ_CODFAV" , ""},
                { "V0CHEQ_VALINSS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1710_00_GRAVA_TCHEQUES_DB_INSERT_1_Insert1", q16);

            #endregion

            #region R1710_00_GRAVA_TCHEQUES_DB_INSERT_2_Insert1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0HCHE_CHQINT" , ""},
                { "V0HCHE_DIGINT" , ""},
                { "V0HCHE_DTMOVTO" , ""},
                { "V0HCHE_OPERACAO" , ""},
                { "V0HCHE_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1710_00_GRAVA_TCHEQUES_DB_INSERT_2_Insert1", q17);

            #endregion

            #region R1720_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_PRM_TARIF" , ""},
                { "V0HIST_DESCONTO" , ""},
                { "V0HIST_VLPRMLIQ" , ""},
                { "V0HIST_VLADIFRA" , ""},
                { "V0HIST_VLCUSEMI" , ""},
                { "V0HIST_VLIOCC" , ""},
                { "V0HIST_VLPRMTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1720_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1", q18);

            #endregion

            #region R1730_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V1HIST_NUM_APOL" , ""},
                { "V1HIST_NRENDOS" , ""},
                { "V1HIST_NRPARCEL" , ""},
                { "V1HIST_DACPARC" , ""},
                { "V1HIST_DTMOVTO" , ""},
                { "V1HIST_OPERACAO" , ""},
                { "V1HIST_OCORHIST" , ""},
                { "V2HIST_PRM_TARIF" , ""},
                { "V2HIST_DESCONTO" , ""},
                { "V2HIST_VLPRMLIQ" , ""},
                { "V2HIST_VLADIFRA" , ""},
                { "V2HIST_VLCUSEMI" , ""},
                { "V2HIST_VLIOCC" , ""},
                { "V2HIST_VLPRMTOT" , ""},
                { "V2HIST_VLPREMIO" , ""},
                { "V1HIST_DTVENCTO" , ""},
                { "V1HIST_BCOCOBR" , ""},
                { "V1HIST_AGECOBR" , ""},
                { "V1HIST_NRAVISO" , ""},
                { "V1HIST_NRENDOCA" , ""},
                { "V1HIST_SITCONTB" , ""},
                { "V1HIST_USUARIO" , ""},
                { "V1HIST_RNUDOC" , ""},
                { "V1HIST_DTQITBCO" , ""},
                { "V1HIST_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1730_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q19);

            #endregion

            #region R1740_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_OCORHIST" , ""},
                { "V1HIST_NUM_APOL" , ""},
                { "V1HIST_NRPARCEL" , ""},
                { "V1HIST_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1740_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1", q20);

            #endregion

            #region R1750_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V1HIST_NUM_APOL" , ""},
                { "V1HIST_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1750_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1", q21);

            #endregion

            #region R2100_00_VERIFICA_CB041_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "CB041_NUM_OCORR_MOVTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_VERIFICA_CB041_DB_SELECT_1_Query1", q22);

            #endregion

            #region R3010_00_MAX_OCOR_CBCONDEV_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_NUM_SEQUENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3010_00_MAX_OCOR_CBCONDEV_DB_SELECT_1_Query1", q23);

            #endregion

            #region R3020_00_SELECT_CB041_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "CB041_NUM_OCORR_MOVTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3020_00_SELECT_CB041_DB_SELECT_1_Query1", q24);

            #endregion

            #region R3030_00_SELECT_GE368_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "GE368_NUM_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3030_00_SELECT_GE368_DB_SELECT_1_Query1", q25);

            #endregion

            #region R3040_00_SELECT_OD009_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "OD009_COD_BANCO" , ""},
                { "OD009_COD_AGENCIA" , ""},
                { "OD009_NUM_OPERACAO_CONTA" , ""},
                { "OD009_NUM_CONTA" , ""},
                { "OD009_NUM_DV_CONTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3040_00_SELECT_OD009_DB_SELECT_1_Query1", q26);

            #endregion

            #region R3105_00_SELECT_AGENCCEF_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_COD_ESCNEG" , ""},
                { "MALHACEF_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3105_00_SELECT_AGENCCEF_DB_SELECT_1_Query1", q27);

            #endregion

            #region R3110_00_INSERT_CBCONDEV_DB_INSERT_1_Insert1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_COD_EMPRESA" , ""},
                { "CBCONDEV_TIPO_MOVIMENTO" , ""},
                { "CBCONDEV_NUM_CHEQUE_INTERNO" , ""},
                { "CBCONDEV_DIG_CHEQUE_INTERNO" , ""},
                { "CBCONDEV_DATA_MOVIMENTO" , ""},
                { "CBCONDEV_NUM_SEQUENCIA" , ""},
                { "CBCONDEV_NUM_TITULO" , ""},
                { "CBCONDEV_COD_FONTE" , ""},
                { "CBCONDEV_NUM_RCAP" , ""},
                { "CBCONDEV_NUM_RCAP_COMPLEMEN" , ""},
                { "CBCONDEV_NUM_APOLICE" , ""},
                { "CBCONDEV_NUM_ENDOSSO" , ""},
                { "CBCONDEV_NUM_PARCELA" , ""},
                { "CBCONDEV_COD_SUBGRUPO" , ""},
                { "CBCONDEV_NUM_CERTIFICADO" , ""},
                { "CBCONDEV_DATA_OCORRENCIA" , ""},
                { "CBCONDEV_HORA_OPERACAO" , ""},
                { "CBCONDEV_NUM_MATRICULA" , ""},
                { "CBCONDEV_RAMO_EMISSOR" , ""},
                { "CBCONDEV_COD_PRODUTO" , ""},
                { "CBCONDEV_COD_FILIAL" , ""},
                { "CBCONDEV_COD_ESCNEG" , ""},
                { "CBCONDEV_AGE_COBRANCA" , ""},
                { "CBCONDEV_TIPO_FAVORECIDO" , ""},
                { "CBCONDEV_COD_FAVORECIDO" , ""},
                { "CBCONDEV_COD_ENDERECO" , ""},
                { "CBCONDEV_OCORR_ENDERECO" , ""},
                { "CBCONDEV_COD_AGENCIA" , ""},
                { "CBCONDEV_OPERACAO_CONTA" , ""},
                { "CBCONDEV_NUM_CONTA" , ""},
                { "CBCONDEV_DIG_CONTA" , ""},
                { "CBCONDEV_SIT_REGISTRO" , ""},
                { "CBCONDEV_DATA_QUITACAO" , ""},
                { "CBCONDEV_VAL_TITULO" , ""},
                { "CBCONDEV_VAL_DESCONTO" , ""},
                { "CBCONDEV_VAL_OPERACAO" , ""},
                { "CBCONDEV_COD_DESPESA" , ""},
                { "CBCONDEV_COD_DEVOLUCAO" , ""},
                { "CBCONDEV_COD_SISTEMA" , ""},
                { "CBCONDEV_COD_USU_SOLICITA" , ""},
                { "CBCONDEV_DATA_CANCELAMENTO" , ""},
                { "CBCONDEV_COD_USU_CANCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3110_00_INSERT_CBCONDEV_DB_INSERT_1_Insert1", q28);

            #endregion

            #region R9000_00_ALTERA_SITUACAO_DB_UPDATE_1_Update1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R9000_00_ALTERA_SITUACAO_DB_UPDATE_1_Update1", q29);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("EM0202M01")]
        public static void EM0202B_Tests_Theory_Erro99(string EM0202M01_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            EM0202M01_FILE_NAME_P = $"{EM0202M01_FILE_NAME_P}_{timestamp}.txt";
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
                var program = new EM0202B();
                program.Execute(EM0202M01_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Theory]
        [InlineData("EM0202M01")]
        public static void EM0202B_Tests_Theory_Case1(string EM0202M01_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            EM0202M01_FILE_NAME_P = $"{EM0202M01_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                GE0540S_Tests.Load_Parameters();

                #region EM0202B_EMISDIA

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1EDIA_CODRELAT" , "EM0202B1"},
                { "V1EDIA_NUM_APOL" , ""},
                { "V1EDIA_NRENDOS" , ""},
                { "V1EDIA_FONTE" , ""},
                { "V1EDIA_ORGAO" , "110"},
                { "V1EDIA_RAMO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("EM0202B_EMISDIA");
                AppSettings.TestSet.DynamicData.Add("EM0202B_EMISDIA", q3);

                #endregion

                #region R1100_00_LER_HISTOPARC_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V1HIST_NUM_APOL" , "08005255"},
                { "V1HIST_NRENDOS" , ""},
                { "V1HIST_NRPARCEL" , ""},
                { "V1HIST_DACPARC" , ""},
                { "V1HIST_DTMOVTO" , ""},
                { "V1HIST_OPERACAO" , ""},
                { "V1HIST_OCORHIST" , ""},
                { "V1HIST_PRM_TARIF" , ""},
                { "V1HIST_DESCONTO" , ""},
                { "V1HIST_VLPRMLIQ" , "50000"},
                { "V1HIST_VLADIFRA" , ""},
                { "V1HIST_VLCUSEMI" , ""},
                { "V1HIST_VLIOCC" , ""},
                { "V1HIST_VLPRMTOT" , "10000"},
                { "V1HIST_VLPREMIO" , ""},
                { "V1HIST_DTVENCTO" , ""},
                { "V1HIST_BCOCOBR" , ""},
                { "V1HIST_AGECOBR" , ""},
                { "V1HIST_NRAVISO" , ""},
                { "V1HIST_NRENDOCA" , ""},
                { "V1HIST_SITCONTB" , ""},
                { "V1HIST_USUARIO" , ""},
                { "V1HIST_RNUDOC" , ""},
                { "V1HIST_DTQITBCO" , ""},
                { "V1HIST_EMPRESA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LER_HISTOPARC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LER_HISTOPARC_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1300_00_LER_ENDOSSO_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_TIPO_END" , "3"},
                { "V1ENDO_RAMO" , ""},
                { "V1ENDO_CODPRODU" , "4801"},
                { "V1ENDO_OCORREND" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_LER_ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_LER_ENDOSSO_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1720_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_PRM_TARIF" , ""},
                { "V0HIST_DESCONTO" , ""},
                { "V0HIST_VLPRMLIQ" , ""},
                { "V0HIST_VLADIFRA" , ""},
                { "V0HIST_VLCUSEMI" , ""},
                { "V0HIST_VLIOCC" , ""},
                { "V0HIST_VLPRMTOT" , "8000"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1720_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1720_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1", q18);

                #endregion

                #region R2100_00_VERIFICA_CB041_DB_SELECT_1_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "CB041_NUM_OCORR_MOVTO" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_VERIFICA_CB041_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_VERIFICA_CB041_DB_SELECT_1_Query1", q22);

                #endregion

                #endregion
                var program = new EM0202B();

                program.Execute(EM0202M01_FILE_NAME_P);

                //R0330_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["R0330_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList[1].TryGetValue("V1EDIA_NRPARCEL", out var valor) && valor.Contains("0000"));
                Assert.True(envList.Count > 1);

                //R1730_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1
                var envList3 = AppSettings.TestSet.DynamicData["R1730_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("V1HIST_OPERACAO", out var valor3) && valor3.Contains("0802"));
                Assert.True(envList3.Count > 1);

                //R3110_00_INSERT_CBCONDEV_DB_INSERT_1_Insert1
                var envList4 = AppSettings.TestSet.DynamicData["R3110_00_INSERT_CBCONDEV_DB_INSERT_1_Insert1"].DynamicList;
                //Assert.True(envList4[1].TryGetValue("CBCONDEV_COD_DESPESA", out var valor4) && valor4.Contains("1204"));
                //Assert.True(envList4.Count > 1);

                //R1740_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1
                var envList5 = AppSettings.TestSet.DynamicData["R1740_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("V1PARC_OCORHIST", out var valor5) && valor5.Contains("2"));
                Assert.True(envList5.Count > 1);

                //R1750_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1
                var envList6 = AppSettings.TestSet.DynamicData["R1750_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList6[1].TryGetValue("V1HIST_NUM_APOL", out var valor6) && valor6.Contains("08005255"));
                Assert.True(envList6.Count > 1);

                //R9000_00_ALTERA_SITUACAO_DB_UPDATE_1_Update1
                var envList7 = AppSettings.TestSet.DynamicData["R9000_00_ALTERA_SITUACAO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList7.Count > 1);

                //R0340_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1
                var envList8 = AppSettings.TestSet.DynamicData["R0340_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1"].DynamicList;
                Assert.Empty(envList8);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("EM0202M01")]
        public static void EM0202B_Tests_Theory_Case2(string EM0202M01_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            EM0202M01_FILE_NAME_P = $"{EM0202M01_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                GE0540S_Tests.Load_Parameters();

                #region EM0202B_EMISDIA

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1EDIA_CODRELAT" , "EM0202B1"},
                { "V1EDIA_NUM_APOL" , ""},
                { "V1EDIA_NRENDOS" , ""},
                { "V1EDIA_FONTE" , ""},
                { "V1EDIA_ORGAO" , "110"},
                { "V1EDIA_RAMO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("EM0202B_EMISDIA");
                AppSettings.TestSet.DynamicData.Add("EM0202B_EMISDIA", q3);

                #endregion

                #region R1100_00_LER_HISTOPARC_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V1HIST_NUM_APOL" , ""},
                { "V1HIST_NRENDOS" , ""},
                { "V1HIST_NRPARCEL" , ""},
                { "V1HIST_DACPARC" , ""},
                { "V1HIST_DTMOVTO" , ""},
                { "V1HIST_OPERACAO" , ""},
                { "V1HIST_OCORHIST" , ""},
                { "V1HIST_PRM_TARIF" , ""},
                { "V1HIST_DESCONTO" , ""},
                { "V1HIST_VLPRMLIQ" , "50000"},
                { "V1HIST_VLADIFRA" , ""},
                { "V1HIST_VLCUSEMI" , ""},
                { "V1HIST_VLIOCC" , ""},
                { "V1HIST_VLPRMTOT" , "10000"},
                { "V1HIST_VLPREMIO" , ""},
                { "V1HIST_DTVENCTO" , ""},
                { "V1HIST_BCOCOBR" , ""},
                { "V1HIST_AGECOBR" , ""},
                { "V1HIST_NRAVISO" , ""},
                { "V1HIST_NRENDOCA" , ""},
                { "V1HIST_SITCONTB" , ""},
                { "V1HIST_USUARIO" , ""},
                { "V1HIST_RNUDOC" , ""},
                { "V1HIST_DTQITBCO" , ""},
                { "V1HIST_EMPRESA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LER_HISTOPARC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LER_HISTOPARC_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1300_00_LER_ENDOSSO_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_TIPO_END" , "3"},
                { "V1ENDO_RAMO" , ""},
                { "V1ENDO_CODPRODU" , ""},
                { "V1ENDO_OCORREND" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_LER_ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_LER_ENDOSSO_DB_SELECT_1_Query1", q10);

                #endregion

                #region R2100_00_VERIFICA_CB041_DB_SELECT_1_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "CB041_NUM_OCORR_MOVTO" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_VERIFICA_CB041_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_VERIFICA_CB041_DB_SELECT_1_Query1", q22);

                #endregion

                #endregion
                var program = new EM0202B();

                program.Execute(EM0202M01_FILE_NAME_P);

                //R0330_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["R0330_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList[1].TryGetValue("V1EDIA_NRPARCEL", out var valor) && valor.Contains("0000"));
                Assert.True(envList.Count > 1);

                //R1710_00_GRAVA_TCHEQUES_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R1710_00_GRAVA_TCHEQUES_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("V0CHEQ_VALCHQ", out var valor1) && valor1.Contains("10000"));
                Assert.True(envList1.Count > 1);

                //R1710_00_GRAVA_TCHEQUES_DB_INSERT_2_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["R1710_00_GRAVA_TCHEQUES_DB_INSERT_2_Insert1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("V0HCHE_OPERACAO", out var valor2) && valor2.Contains("101"));
                Assert.True(envList2.Count > 1);

                //R3110_00_INSERT_CBCONDEV_DB_INSERT_1_Insert1
                var envList4 = AppSettings.TestSet.DynamicData["R3110_00_INSERT_CBCONDEV_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("CBCONDEV_TIPO_MOVIMENTO", out var valor4) && valor4.Contains("8"));
                Assert.True(envList4.Count > 1);

                //R9000_00_ALTERA_SITUACAO_DB_UPDATE_1_Update1
                var envList7 = AppSettings.TestSet.DynamicData["R9000_00_ALTERA_SITUACAO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList7.Count > 1);

                //R0340_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1
                var envList8 = AppSettings.TestSet.DynamicData["R0340_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1"].DynamicList;
                Assert.Empty(envList8);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}