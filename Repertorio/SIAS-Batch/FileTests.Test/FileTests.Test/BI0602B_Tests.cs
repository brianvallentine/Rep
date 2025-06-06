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
using static Code.BI0602B;

namespace FileTests.Test
{
    [Collection("BI0602B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI0602B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region BI0602B_CURSOR01

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CANAL_DE_VENDA" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOFID_COD_PRODUTO_SIVPF" , ""},
                { "PROPOFID_ORIGEM_PROPOSTA" , ""},
                { "PROPOFID_DATA_PROPOSTA" , ""},
                { "PROPOFID_DIA_DEBITO" , ""},
                { "PROPOFID_NUM_SICOB" , ""},
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_AGECOBR" , ""},
                { "PROPOFID_VAL_PAGO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI0602B_CURSOR01", q0);

            #endregion

            #region BI0602B_CURSOR02

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WS_SITUAC_CEF" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI0602B_CURSOR02", q1);

            #endregion

            #region R0200_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q2);

            #endregion

            #region BI0602B_CORIGEM

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("BI0602B_CORIGEM", q3);

            #endregion

            #region R1501_00_SELECT_BILHETE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WS_BILHETE_AUX" , ""},
                { "WS_APOLICE_AUX" , ""},
                { "WS_CLIENTE_AUX" , ""},
                { "WS_OPC_COBERT_AUX" , ""},
                { "WS_VAL_RCAP_AUX" , ""},
                { "WS_DATA_QUITACAO_AUX" , ""},
                { "WS_PROXIMA_DT_QUIT" , ""},
                { "WS_SITUACAO" , ""},
                { "WS_TIP_CANCELAMENTO" , ""},
                { "WS_SIT_SINISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1501_00_SELECT_BILHETE_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1501_00_SELECT_BILHETE_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_CGCCPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1501_00_SELECT_BILHETE_DB_SELECT_2_Query1", q5);

            #endregion

            #region R1502_00_SELECT_UNIDACEF_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "UNIDACEF_NOME_UNIDADE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1502_00_SELECT_UNIDACEF_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1503_00_SELECT_PROPOVA_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WS_HISTCON_NRCERTIF" , ""},
                { "WS_APOLICE_AUX" , ""},
                { "WS_CLIENTE_AUX" , ""},
                { "WS_DATA_QUITACAO_AUX" , ""},
                { "WS_PROXIMA_DT_QUIT" , ""},
                { "WS_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1503_00_SELECT_PROPOVA_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1503_00_SELECT_PROPOVA_DB_SELECT_2_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_CGCCPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1503_00_SELECT_PROPOVA_DB_SELECT_2_Query1", q8);

            #endregion

            #region R1950_00_BUSCA_MOTIVO_CEF_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "WS_SITUAC_CEF" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_DATA_MOVIMENTO" , ""},
                { "MOVDEBCE_TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1950_00_BUSCA_MOTIVO_CEF_DB_SELECT_1_Query1", q9);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("RELATORIO.txt")]
        public static void BI0602B_Tests_TheorySemMovimento_ReturnCode_0(string RELATORIO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RELATORIO_FILE_NAME_P = $"{RELATORIO_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0200_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q2);

                #endregion
                #region BI0602B_CURSOR01

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("BI0602B_CURSOR01");
                AppSettings.TestSet.DynamicData.Add("BI0602B_CURSOR01", q0);

                #endregion
                #endregion
                var program = new BI0602B();
                program.Execute(RELATORIO_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(q0.DynamicList.Count == 0);


            }
        }
        [Theory]
        [InlineData("RELATORIO.txt")]
        public static void BI0602B_Tests_Theory_Produto11_VidaGente_ReturnCode_0(string RELATORIO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RELATORIO_FILE_NAME_P = $"{RELATORIO_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0200_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q2);

                #endregion
                #region BI0602B_CORIGEM

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SISTEMA_ORIGEM" , "1001"}
                });
                AppSettings.TestSet.DynamicData.Remove("BI0602B_CORIGEM");
                AppSettings.TestSet.DynamicData.Add("BI0602B_CORIGEM", q3);

                #endregion
                #region BI0602B_CURSOR01

                var q0 = new DynamicData();

                q0.AddDynamic(new Dictionary<string, string>{
                 { "WHOST_CANAL_DE_VENDA" , "REDE1"},
                 { "PROPOFID_NUM_PROPOSTA_SIVPF" , "80021058960"},
                 { "PROPOFID_COD_PRODUTO_SIVPF" , "11"},
                 { "PROPOFID_ORIGEM_PROPOSTA" , "1006"},
                 { "PROPOFID_DATA_PROPOSTA" , "2000-02-14"},
                 { "PROPOFID_DIA_DEBITO" , "14"},
                 { "PROPOFID_NUM_SICOB" , "80000000017"},
                 { "PROPOFID_SIT_PROPOSTA" , "EMT"},
                 { "PROPOFID_AGECOBR" , "55"},
                 { "PROPOFID_VAL_PAGO" , "300"},
                 });
                q0.AddDynamic(new Dictionary<string, string>{
                 { "WHOST_CANAL_DE_VENDA" , "EXTRA-REDE"},
                 { "PROPOFID_NUM_PROPOSTA_SIVPF" , "80021058960"},
                 { "PROPOFID_COD_PRODUTO_SIVPF" , "11"},
                 { "PROPOFID_ORIGEM_PROPOSTA" , "1003"},
                 { "PROPOFID_DATA_PROPOSTA" , "2000-02-14"},
                 { "PROPOFID_DIA_DEBITO" , "14"},
                 { "PROPOFID_NUM_SICOB" , "80000000017"},
                 { "PROPOFID_SIT_PROPOSTA" , "EMT"},
                 { "PROPOFID_AGECOBR" , "55"},
                 { "PROPOFID_VAL_PAGO" , "300"},
                 });
                AppSettings.TestSet.DynamicData.Remove("BI0602B_CURSOR01");
                AppSettings.TestSet.DynamicData.Add("BI0602B_CURSOR01", q0);

                #endregion
                #region R1503_00_SELECT_PROPOVA_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "WS_HISTCON_NRCERTIF" , "24"},
                { "WS_APOLICE_AUX" , "109300000550"},
                { "WS_CLIENTE_AUX" , "13527943"},
                { "WS_DATA_QUITACAO_AUX" , "2008-07-31"},
                { "WS_PROXIMA_DT_QUIT" , "2009-07-31"},
                { "WS_SITUACAO" , "2"},
                });
                q7.AddDynamic(new Dictionary<string, string>{
                { "WS_HISTCON_NRCERTIF" , "24"},
                { "WS_APOLICE_AUX" , "109300000550"},
                { "WS_CLIENTE_AUX" , "13527943"},
                { "WS_DATA_QUITACAO_AUX" , "2008-07-31"},
                { "WS_PROXIMA_DT_QUIT" , "2009-07-31"},
                { "WS_SITUACAO" , "2"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1503_00_SELECT_PROPOVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1503_00_SELECT_PROPOVA_DB_SELECT_1_Query1", q7);

                #endregion
                #region BI0602B_CURSOR02

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "WS_SITUAC_CEF" , "0"},
                { "MOVDEBCE_DATA_VENCIMENTO" , "2015-02-10"},
                { "MOVDEBCE_TIMESTAMP" , "2015-01-19 23:04:26.085"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI0602B_CURSOR02");
                AppSettings.TestSet.DynamicData.Add("BI0602B_CURSOR02", q1);

                #endregion
                #endregion
                var program = new BI0602B();
                program.Execute(RELATORIO_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(program.REG_SAIDA.SAIDA_PRODUTO.Value == "VIDA DA GENTE            ");
                Assert.True(program.REG_SAIDA.SAIDA_NUM_PROPOSTA_SIVPF == "000080021058960");

            }
        }
        [Theory]
        [InlineData("RELATORIO.txt")]
        public static void BI0602B_Tests_Theory_ReturnCode_99(string RELATORIO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RELATORIO_FILE_NAME_P = $"{RELATORIO_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0200_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q2);

                #endregion
                #region BI0602B_CURSOR01

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                 { "WHOST_CANAL_DE_VENDA" , "REDE1"},
                 { "PROPOFID_NUM_PROPOSTA_SIVPF" , "80021058960"},
                 { "PROPOFID_COD_PRODUTO_SIVPF" , "11"},
                 { "PROPOFID_SIT_PROPOSTA" , "EMT"},
                 { "PROPOFID_AGECOBR" , "55"},
                 { "PROPOFID_VAL_PAGO" , "300"},
                 });
                AppSettings.TestSet.DynamicData.Remove("BI0602B_CURSOR01");
                AppSettings.TestSet.DynamicData.Add("BI0602B_CURSOR01", q0);

                #endregion
                #endregion
                var program = new BI0602B();
                program.Execute(RELATORIO_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);


            }
        }
    }
}