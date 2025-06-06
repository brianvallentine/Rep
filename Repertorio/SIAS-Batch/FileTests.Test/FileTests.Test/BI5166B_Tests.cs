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
using static Code.BI5166B;

namespace FileTests.Test
{
    [Collection("BI5166B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI5166B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "V1SIST_DTMOVABE_01Y" , ""},
                { "V1SIST_DTMOVABE_06D" , ""},
                { "V1SIST_DTMOVABE_15D" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region BI5166B_V0BILHETE

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , ""},
                { "BILHETE_NUM_APOLICE" , ""},
                { "BILHETE_FONTE" , ""},
                { "BILHETE_AGE_COBRANCA" , ""},
                { "BILHETE_NUM_CONTA" , ""},
                { "BILHETE_DIG_CONTA" , ""},
                { "BILHETE_COD_CLIENTE" , ""},
                { "BILHETE_PROFISSAO" , ""},
                { "BILHETE_IDE_SEXO" , ""},
                { "BILHETE_ESTADO_CIVIL" , ""},
                { "BILHETE_OCORR_ENDERECO" , ""},
                { "BILHETE_OPC_COBERTURA" , ""},
                { "BILHETE_DATA_QUITACAO" , ""},
                { "BILHETE_VAL_RCAP" , ""},
                { "BILHETE_RAMO" , ""},
                { "BILHETE_DATA_VENDA" , ""},
                { "BILHETE_NUM_APOL_ANTERIOR" , ""},
                { "BILHETE_SITUACAO" , ""},
                { "BILHETE_TIP_CANCELAMENTO" , ""},
                { "BILHETE_SIT_SINISTRO" , ""},
                { "BILHETE_COD_USUARIO" , ""},
                { "BILHETE_DATA_CANCELAMENTO" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI5166B_V0BILHETE", q1);

            #endregion

            #region BI5166B_V0BILHEERR

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "BILHEERR_COD_ERRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("BI5166B_V0BILHEERR", q2);

            #endregion

            #region R0210_00_SELECT_PROPOFID_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "PROPOFID_COD_PRODUTO_SIVPF" , ""},
                { "PROPOFID_NUMCTAVEN" , ""},
                { "PROPOFID_DIGCTAVEN" , ""},
                { "PROPOFID_ORIGEM_PROPOSTA" , ""},
                { "PROPOFID_OPCAO_COBER" , ""},
                { "PROPOFID_COD_PLANO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0210_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0220_00_SELECT_APOLICES_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_NUM_APOLICE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0220_00_SELECT_APOLICES_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0230_00_SELECT_RCAPS_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_DATA_CADASTRAMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0230_00_SELECT_RCAPS_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0240_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_DATA_ENVIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0240_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0300_00_SELECT_BILHECOB_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "BILHECOB_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_SELECT_BILHECOB_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0900_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_OPC_COBERTURA" , ""},
                { "BILHETE_SITUACAO" , ""},
                { "BILHETE_RAMO" , ""},
                { "BILHETE_NUM_BILHETE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0900_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q8);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SAIDA01.txt", "SAIDA02.txt", "SAIDA03.txt", "SAIDA04.txt")]
        public static void BI5166B_Tests_Theory_Movimento_ReturnCode00(string SAIDA01_FILE_NAME_P, string SAIDA02_FILE_NAME_P, string SAIDA03_FILE_NAME_P, string SAIDA04_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SAIDA01_FILE_NAME_P = $"{SAIDA01_FILE_NAME_P}_{timestamp}.txt";
            SAIDA02_FILE_NAME_P = $"{SAIDA02_FILE_NAME_P}_{timestamp}.txt";
            SAIDA03_FILE_NAME_P = $"{SAIDA03_FILE_NAME_P}_{timestamp}.txt";
            SAIDA04_FILE_NAME_P = $"{SAIDA04_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-27"},
                { "V1SIST_DTMOVABE_01Y" , "2024-01-27"},
                { "V1SIST_DTMOVABE_06D" , "2025-01-21"},
                { "V1SIST_DTMOVABE_15D" , "2025-01-12"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion
                #region BI5166B_V0BILHETE

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , "82621388879"},
                { "BILHETE_NUM_APOLICE" , "0"},
                { "BILHETE_FONTE" , "1"},
                { "BILHETE_AGE_COBRANCA" , ""},
                { "BILHETE_NUM_CONTA" , ""},
                { "BILHETE_DIG_CONTA" , ""},
                { "BILHETE_COD_CLIENTE" , "449800"},
                { "BILHETE_PROFISSAO" , ""},
                { "BILHETE_IDE_SEXO" , ""},
                { "BILHETE_ESTADO_CIVIL" , ""},
                { "BILHETE_OCORR_ENDERECO" , ""},
                { "BILHETE_OPC_COBERTURA" , ""},
                { "BILHETE_DATA_QUITACAO" , ""},
                { "BILHETE_VAL_RCAP" , "0000000000077.90"},
                { "BILHETE_RAMO" , "82"},
                { "BILHETE_DATA_VENDA" , ""},
                { "BILHETE_NUM_APOL_ANTERIOR" , ""},
                { "BILHETE_SITUACAO" , "4"},
                { "BILHETE_TIP_CANCELAMENTO" , ""},
                { "BILHETE_SIT_SINISTRO" , ""},
                { "BILHETE_COD_USUARIO" , ""},
                { "BILHETE_DATA_CANCELAMENTO" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("BI5166B_V0BILHETE");
                AppSettings.TestSet.DynamicData.Add("BI5166B_V0BILHETE", q1);

                #endregion
                #region R0210_00_SELECT_PROPOFID_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "8119"},
                { "PROPOFID_NUMCTAVEN" , ""},
                { "PROPOFID_DIGCTAVEN" , ""},
                { "PROPOFID_ORIGEM_PROPOSTA" , ""},
                { "PROPOFID_OPCAO_COBER" , ""},
                { "PROPOFID_COD_PLANO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0210_00_SELECT_PROPOFID_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0210_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q3);

                #endregion
                #endregion
                var program = new BI5166B();
                program.Execute(SAIDA01_FILE_NAME_P, SAIDA02_FILE_NAME_P, SAIDA03_FILE_NAME_P, SAIDA04_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                var envList = AppSettings.TestSet.DynamicData["R0900_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("BILHETE_OPC_COBERTURA", out var valor0) && valor0.Contains("0048"));
                Assert.True(envList[1].TryGetValue("BILHETE_NUM_BILHETE", out var valor1) && valor1.Contains("000082621388879"));

            }
        }
        [Theory]
        [InlineData("SAIDA01.txt", "SAIDA02.txt", "SAIDA03.txt", "SAIDA04.txt")]
        public static void BI5166B_Tests_Theory_SemMovimento_ReturnCode00(string SAIDA01_FILE_NAME_P, string SAIDA02_FILE_NAME_P, string SAIDA03_FILE_NAME_P, string SAIDA04_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SAIDA01_FILE_NAME_P = $"{SAIDA01_FILE_NAME_P}_{timestamp}.txt";
            SAIDA02_FILE_NAME_P = $"{SAIDA02_FILE_NAME_P}_{timestamp}.txt";
            SAIDA03_FILE_NAME_P = $"{SAIDA03_FILE_NAME_P}_{timestamp}.txt";
            SAIDA04_FILE_NAME_P = $"{SAIDA04_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-27"},
                { "V1SIST_DTMOVABE_01Y" , "2024-01-27"},
                { "V1SIST_DTMOVABE_06D" , "2025-01-21"},
                { "V1SIST_DTMOVABE_15D" , "2025-01-12"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion
                #region BI5166B_V0BILHETE

                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("BI5166B_V0BILHETE");
                AppSettings.TestSet.DynamicData.Add("BI5166B_V0BILHETE", q1);

                #endregion
                #endregion
                var program = new BI5166B();
                program.Execute(SAIDA01_FILE_NAME_P, SAIDA02_FILE_NAME_P, SAIDA03_FILE_NAME_P, SAIDA04_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(q1.DynamicList.Count == 0);
                
            }
        }
        [Theory]
        [InlineData("SAIDA01.txt", "SAIDA02.txt", "SAIDA03.txt", "SAIDA04.txt")]
        public static void BI5166B_Tests_Theory_ReturnCode99(string SAIDA01_FILE_NAME_P, string SAIDA02_FILE_NAME_P, string SAIDA03_FILE_NAME_P, string SAIDA04_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SAIDA01_FILE_NAME_P = $"{SAIDA01_FILE_NAME_P}_{timestamp}.txt";
            SAIDA02_FILE_NAME_P = $"{SAIDA02_FILE_NAME_P}_{timestamp}.txt";
            SAIDA03_FILE_NAME_P = $"{SAIDA03_FILE_NAME_P}_{timestamp}.txt";
            SAIDA04_FILE_NAME_P = $"{SAIDA04_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-27"},
                { "V1SIST_DTMOVABE_01Y" , "2024-01-27"},
                { "V1SIST_DTMOVABE_06D" , "2025-01-21"},
                { "V1SIST_DTMOVABE_15D" , "2025-01-12"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion
                #region BI5166B_V0BILHETE

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , ""},
                { "BILHETE_NUM_APOLICE" , ""},
                { "BILHETE_FONTE" , ""},
                { "BILHETE_AGE_COBRANCA" , ""},
                { "BILHETE_NUM_CONTA" , ""},
                { "BILHETE_DIG_CONTA" , ""},
                });

                AppSettings.TestSet.DynamicData.Remove("BI5166B_V0BILHETE");
                AppSettings.TestSet.DynamicData.Add("BI5166B_V0BILHETE", q1);

                #endregion
                #endregion
                var program = new BI5166B();
                program.Execute(SAIDA01_FILE_NAME_P, SAIDA02_FILE_NAME_P, SAIDA03_FILE_NAME_P, SAIDA04_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}