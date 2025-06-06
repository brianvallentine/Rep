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
using static Code.EM8006B;

namespace FileTests.Test
{
    [Collection("EM8006B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class EM8006B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA_EM" , "2020-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0560_00_VER_PRODUTO_EF_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT" , "1"}
            });
            AppSettings.TestSet.DynamicData.Add("R0560_00_VER_PRODUTO_EF_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0575_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , "0019790324"},
                { "MOVDEBCE_NUM_ENDOSSO" , "0020100326"},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_COD_CONVENIO" , "792010"},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_NUM_REQUISICAO" , "156"},
                { "MOVDEBCE_NUM_CARTAO" , "4566789758251234"},
            });
            AppSettings.TestSet.DynamicData.Add("R0575_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1100_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_RETORNO_CEF" , ""},
                { "VIND_RETORNO" , ""},
                { "MOVDEBCE_DATA_RETORNO" , ""},
                { "VIND_DTRETORNO" , ""},
                { "MOVDEBCE_COD_USUARIO" , ""},
                { "VIND_USUARIO" , ""},
                { "MOVDEBCE_SEQUENCIA" , ""},
                { "VIND_SEQUENCIA" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1", q3);

            #endregion

            #region R1110_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_RETORNO_CEF" , ""},
                { "VIND_RETORNO" , ""},
                { "MOVDEBCE_DATA_RETORNO" , ""},
                { "VIND_DTRETORNO" , ""},
                { "MOVDEBCE_COD_USUARIO" , ""},
                { "VIND_USUARIO" , ""},
                { "MOVDEBCE_SEQUENCIA" , ""},
                { "VIND_SEQUENCIA" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1", q4);

            #endregion

            #region R1900_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_NUM_REQUISICAO" , ""},
                { "MOVDEBCE_NUM_CARTAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1900_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1910_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_NUM_REQUISICAO" , ""},
                { "MOVDEBCE_NUM_CARTAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1910_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1920_00_SELECT_HISLANCT_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NSL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1920_00_SELECT_HISLANCT_DB_SELECT_1_Query1", q7);

            #endregion

            #region R2000_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_NUM_REQUISICAO" , ""},
                { "MOVDEBCE_NUM_CARTAO" , "520333666888"},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1", q8);

            #endregion

            #region R2100_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_NUM_REQUISICAO" , ""},
                { "MOVDEBCE_STATUS_CARTAO" , ""},
                { "LOTERI01_COD_LOT_FENAL" , ""},
                { "APOLICES_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1", q9);

            #endregion

            #region R2100_00_SELECT_MOVDEBCC_DB_SELECT_2_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , "859632"},
                { "MOVDEBCE_NUM_ENDOSSO" , "789456"},
                { "MOVDEBCE_NUM_PARCELA" , "5"},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , "6"},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_NUM_REQUISICAO" , ""},
                { "MOVDEBCE_STATUS_CARTAO" , ""},
                { "LOTERI01_COD_LOT_FENAL" , ""},
                { "APOLICES_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_MOVDEBCC_DB_SELECT_2_Query1", q10);

            #endregion

            #region R2200_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_NUM_REQUISICAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1", q11);

            #endregion

            #region R2250_00_SELECT_APOLICES_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2250_00_SELECT_APOLICES_DB_SELECT_1_Query1", q12);

            #endregion

            #region R2300_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1", q13);

            #endregion

            #region R2520_00_SELECT_BILHETE_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2520_00_SELECT_BILHETE_DB_SELECT_1_Query1", q14);

            #endregion

            #region R2570_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "WSHOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2570_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1", q15);

            #endregion

            #region R5600_CONSULTA_NN_CNTRLE_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "GE403_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5600_CONSULTA_NN_CNTRLE_DB_SELECT_1_Query1", q16);

            #endregion

            #region R5610_INSERT_CNTRLE_SIGCB_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5610_INSERT_CNTRLE_SIGCB_DB_SELECT_1_Query1", q17);

            #endregion

            #region R5700_PESQUISA_IDLG_DEB_CONTA_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_APOLICE" , ""},
                { "WS_NUM_CERTIFICADO" , "123456"},
                { "WS_NUM_PARCELA" , "2"},
                { "WS_NUM_TITULO" , ""},
                { "WS_NUM_OCORR_MOVTO" , ""},
                { "WS_COD_PRODUTO" , ""},
                { "WS_COD_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5700_PESQUISA_IDLG_DEB_CONTA_DB_SELECT_1_Query1", q18);

            #endregion

            #region R5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_1_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_CERTIFICADO" , ""},
                { "WS_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_1_Update1", q19);

            #endregion

            #region R5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_2_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_CERTIFICADO" , ""},
                { "WS_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_2_Update1", q20);

            #endregion

            GE0350S_Tests.Load_Parameters();

            #endregion
        }

        [Theory]
        [InlineData("Entrada_EM8006B_Full.txt", "SAIDA1_FILE_NAME_P", "SAIDA2_FILE_NAME_P", "SAIDA3_FILE_NAME_P", "SAIDA4_FILE_NAME_P", "SAIDA5_FILE_NAME_P", "SAIDA6_FILE_NAME_P", "SAIDA7_FILE_NAME_P", "SAIDA9_FILE_NAME_P")]
        public static void EM8006B_Tests_Theory_Update_ReturnCode_00(string MOVARQH_FILE_NAME_P, string SAIDA1_FILE_NAME_P, string SAIDA2_FILE_NAME_P, string SAIDA3_FILE_NAME_P, string SAIDA4_FILE_NAME_P, string SAIDA5_FILE_NAME_P, string SAIDA6_FILE_NAME_P, string SAIDA7_FILE_NAME_P, string SAIDA9_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SAIDA1_FILE_NAME_P = $"{SAIDA1_FILE_NAME_P}_{timestamp}.txt";
            SAIDA2_FILE_NAME_P = $"{SAIDA2_FILE_NAME_P}_{timestamp}.txt";
            SAIDA3_FILE_NAME_P = $"{SAIDA3_FILE_NAME_P}_{timestamp}.txt";
            SAIDA4_FILE_NAME_P = $"{SAIDA4_FILE_NAME_P}_{timestamp}.txt";
            SAIDA5_FILE_NAME_P = $"{SAIDA5_FILE_NAME_P}_{timestamp}.txt";
            SAIDA6_FILE_NAME_P = $"{SAIDA6_FILE_NAME_P}_{timestamp}.txt";
            SAIDA7_FILE_NAME_P = $"{SAIDA7_FILE_NAME_P}_{timestamp}.txt";
            SAIDA9_FILE_NAME_P = $"{SAIDA9_FILE_NAME_P}_{timestamp}.txt";

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
                var program = new EM8006B();
                program.Execute(MOVARQH_FILE_NAME_P, SAIDA1_FILE_NAME_P, SAIDA2_FILE_NAME_P, SAIDA3_FILE_NAME_P, SAIDA4_FILE_NAME_P, SAIDA5_FILE_NAME_P, SAIDA6_FILE_NAME_P, SAIDA7_FILE_NAME_P, SAIDA9_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(program.W.LD_MOVIMENTO > 0);

                //R1100_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["R1100_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("MOVDEBCE_DATA_RETORNO", out var val0r) && val0r.Contains("2020-01-01"));

                //R1110_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["R1110_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("MOVDEBCE_NUM_APOLICE", out var val1r) && val1r.Contains("0000019790324"));

                //R2300_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R2300_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("MOVDEBCE_NUM_ENDOSSO", out var val2r) && val2r.Contains("000789456"));

            }
        }
        [Theory]
        [InlineData("Entrada_EM8006B_Full_SemMov.txt", "SAIDA1_FILE_NAME_P", "SAIDA2_FILE_NAME_P", "SAIDA3_FILE_NAME_P", "SAIDA4_FILE_NAME_P", "SAIDA5_FILE_NAME_P", "SAIDA6_FILE_NAME_P", "SAIDA7_FILE_NAME_P", "SAIDA9_FILE_NAME_P")]
        public static void EM8006B_Tests_Theory_SemMovimento_ReturnCode_00(string MOVARQH_FILE_NAME_P, string SAIDA1_FILE_NAME_P, string SAIDA2_FILE_NAME_P, string SAIDA3_FILE_NAME_P, string SAIDA4_FILE_NAME_P, string SAIDA5_FILE_NAME_P, string SAIDA6_FILE_NAME_P, string SAIDA7_FILE_NAME_P, string SAIDA9_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SAIDA1_FILE_NAME_P = $"{SAIDA1_FILE_NAME_P}_{timestamp}.txt";
            SAIDA2_FILE_NAME_P = $"{SAIDA2_FILE_NAME_P}_{timestamp}.txt";
            SAIDA3_FILE_NAME_P = $"{SAIDA3_FILE_NAME_P}_{timestamp}.txt";
            SAIDA4_FILE_NAME_P = $"{SAIDA4_FILE_NAME_P}_{timestamp}.txt";
            SAIDA5_FILE_NAME_P = $"{SAIDA5_FILE_NAME_P}_{timestamp}.txt";
            SAIDA6_FILE_NAME_P = $"{SAIDA6_FILE_NAME_P}_{timestamp}.txt";
            SAIDA7_FILE_NAME_P = $"{SAIDA7_FILE_NAME_P}_{timestamp}.txt";
            SAIDA9_FILE_NAME_P = $"{SAIDA9_FILE_NAME_P}_{timestamp}.txt";

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
                var program = new EM8006B();
                program.Execute(MOVARQH_FILE_NAME_P, SAIDA1_FILE_NAME_P, SAIDA2_FILE_NAME_P, SAIDA3_FILE_NAME_P, SAIDA4_FILE_NAME_P, SAIDA5_FILE_NAME_P, SAIDA6_FILE_NAME_P, SAIDA7_FILE_NAME_P, SAIDA9_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(program.W.LD_MOVIMENTO == 0);

            }
        }
        [Theory]
        [InlineData("Entrada_EM8006B_Full.txt", "SAIDA1_FILE_NAME_P", "SAIDA2_FILE_NAME_P", "SAIDA3_FILE_NAME_P", "SAIDA4_FILE_NAME_P", "SAIDA5_FILE_NAME_P", "SAIDA6_FILE_NAME_P", "SAIDA7_FILE_NAME_P", "SAIDA9_FILE_NAME_P")]
        public static void EM8006B_Tests_Theory_Erro_ReturnCode_99(string MOVARQH_FILE_NAME_P, string SAIDA1_FILE_NAME_P, string SAIDA2_FILE_NAME_P, string SAIDA3_FILE_NAME_P, string SAIDA4_FILE_NAME_P, string SAIDA5_FILE_NAME_P, string SAIDA6_FILE_NAME_P, string SAIDA7_FILE_NAME_P, string SAIDA9_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SAIDA1_FILE_NAME_P = $"{SAIDA1_FILE_NAME_P}_{timestamp}.txt";
            SAIDA2_FILE_NAME_P = $"{SAIDA2_FILE_NAME_P}_{timestamp}.txt";
            SAIDA3_FILE_NAME_P = $"{SAIDA3_FILE_NAME_P}_{timestamp}.txt";
            SAIDA4_FILE_NAME_P = $"{SAIDA4_FILE_NAME_P}_{timestamp}.txt";
            SAIDA5_FILE_NAME_P = $"{SAIDA5_FILE_NAME_P}_{timestamp}.txt";
            SAIDA6_FILE_NAME_P = $"{SAIDA6_FILE_NAME_P}_{timestamp}.txt";
            SAIDA7_FILE_NAME_P = $"{SAIDA7_FILE_NAME_P}_{timestamp}.txt";
            SAIDA9_FILE_NAME_P = $"{SAIDA9_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0560_00_VER_PRODUTO_EF_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0560_00_VER_PRODUTO_EF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0560_00_VER_PRODUTO_EF_DB_SELECT_1_Query1", q1);

                #endregion

                #endregion
                var program = new EM8006B();
                program.Execute(MOVARQH_FILE_NAME_P, SAIDA1_FILE_NAME_P, SAIDA2_FILE_NAME_P, SAIDA3_FILE_NAME_P, SAIDA4_FILE_NAME_P, SAIDA5_FILE_NAME_P, SAIDA6_FILE_NAME_P, SAIDA7_FILE_NAME_P, SAIDA9_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}