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
using static Code.VA0860B;

namespace FileTests.Test
{
    [Collection("VA0860B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class VA0860B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0050_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0050_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0300_00_ACESSO_DADOS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_ACESSO_DADOS_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0300_00_ACESSO_DADOS_DB_SELECT_2_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_PARCELA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_ACESSO_DADOS_DB_SELECT_2_Query1", q2);

            #endregion

            #region R0300_00_ACESSO_DADOS_DB_SELECT_3_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_ACESSO_DADOS_DB_SELECT_3_Query1", q3);

            #endregion

            #region R0300_00_ACESSO_DADOS_DB_SELECT_4_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_ACESSO_DADOS_DB_SELECT_4_Query1", q4);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VA0860B_Entrada_R6090.txt", "VA0860B_Saida_R6090.txt")]
        public static void VA0860B_Tests_Theory_R6090(string RETDEB_FILE_NAME_P, string AVA0860B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            AVA0860B_FILE_NAME_P = $"{AVA0860B_FILE_NAME_P}_{timestamp}.txt";
            
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
                var program = new VA0860B();
                program.Execute(RETDEB_FILE_NAME_P, AVA0860B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(program.WORK_AREA.WS_CODCONV == 6090);
            }
        }
        [Theory]
        [InlineData("VA0860B_Entrada_R6131.txt", "VA0860B_Saida_R6131.txt")]
        public static void VA0860B_Tests_Theory_R6131(string RETDEB_FILE_NAME_P, string AVA0860B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            AVA0860B_FILE_NAME_P = $"{AVA0860B_FILE_NAME_P}_{timestamp}.txt";
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
                var program = new VA0860B();
                program.Execute(RETDEB_FILE_NAME_P, AVA0860B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(program.WORK_AREA.WS_CODCONV == 6131);
            }
        }
        [Theory]
        [InlineData("VA0860B_Entrada_R6088.txt", "VA0860B_Saida_R6088.txt")]
        public static void VA0860B_Tests_Theory_R6088(string RETDEB_FILE_NAME_P, string AVA0860B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            AVA0860B_FILE_NAME_P = $"{AVA0860B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0300_00_ACESSO_DADOS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "31617110000121"},
                { "PROPOVA_COD_PRODUTO" , "0"},
                { "PROPOVA_COD_CLIENTE" , "8320980"},
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "31617110000121"},
                { "PROPOVA_COD_PRODUTO" , "0"},
                { "PROPOVA_COD_CLIENTE" , "8320980"},
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "31617110000121"},
                { "PROPOVA_COD_PRODUTO" , "0"},
                { "PROPOVA_COD_CLIENTE" , "8320980"},
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "31617110000121"},
                { "PROPOVA_COD_PRODUTO" , "0"},
                { "PROPOVA_COD_CLIENTE" , "8320980"},
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "31617110000121"},
                { "PROPOVA_COD_PRODUTO" , "0"},
                { "PROPOVA_COD_CLIENTE" , "8320980"},
                }); 
                AppSettings.TestSet.DynamicData.Remove("R0300_00_ACESSO_DADOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0300_00_ACESSO_DADOS_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0300_00_ACESSO_DADOS_DB_SELECT_2_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_PARCELA" , "1"}
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_PARCELA" , "2"}
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_PARCELA" , "3"}
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_PARCELA" , "4"}
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_PARCELA" , "5"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0300_00_ACESSO_DADOS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0300_00_ACESSO_DADOS_DB_SELECT_2_Query1", q2);

                #endregion
                #region R0300_00_ACESSO_DADOS_DB_SELECT_3_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , "PREVIDENCIA PRIVADA                     "}
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , "PREVIDENCIA PUBLICA                     "}
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , "PREFERENCIAL VIDA                       "}
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , "PREVHAB                                 "}
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , "CAIXACAP MENSAL                         "}
                });
                AppSettings.TestSet.DynamicData.Remove("R0300_00_ACESSO_DADOS_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R0300_00_ACESSO_DADOS_DB_SELECT_3_Query1", q3);

                #endregion

                #region R0300_00_ACESSO_DADOS_DB_SELECT_4_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "CLAUDIO GARCIA MAIA                     "},
                { "CLIENTES_CGCCPF" , "0"},
                });
                q4.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "CARLOS ALBERTO NUNES COELHO             "},
                { "CLIENTES_CGCCPF" , "0"},
                });
                q4.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "ALCIR SOUZA FRANCO                      "},
                { "CLIENTES_CGCCPF" , "0"},
                });
                q4.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "TELMO TAVARES                           "},
                { "CLIENTES_CGCCPF" , "0"},
                });
                q4.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "FERNANDO DA SILVA FARIAS                "},
                { "CLIENTES_CGCCPF" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0300_00_ACESSO_DADOS_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R0300_00_ACESSO_DADOS_DB_SELECT_4_Query1", q4);

                #endregion
                #endregion
                var program = new VA0860B();
                program.Execute(RETDEB_FILE_NAME_P, AVA0860B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(program.WORK_AREA.WS_CODCONV == 6088);
                Assert.True(program.WORK_AREA.AC_LIDOS == 10);

            }
        }
        [Theory]
        [InlineData("VA0860B_Entrada_R6088_SemCabecalho.txt", "VA0860B_Saida_R6088_SemCabecalho.txt")]
        public static void VA0860B_Tests_Theory_R6088_SemCabecalho_ReturnCode_9(string RETDEB_FILE_NAME_P, string AVA0860B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            AVA0860B_FILE_NAME_P = $"{AVA0860B_FILE_NAME_P}_{timestamp}.txt";
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
                var program = new VA0860B();
                program.Execute(RETDEB_FILE_NAME_P, AVA0860B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 9);
                Assert.True(program.WORK_AREA.AC_LIDOS == 0);

            }
        }
        [Theory]
        [InlineData("VA0860B_Entrada_R6088_1.txt", "VA0860B_Saida_R6088_1.txt")]
        public static void VA0860B_Tests_Theory_R6088_Error_ReturnCode_9(string RETDEB_FILE_NAME_P, string AVA0860B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            AVA0860B_FILE_NAME_P = $"{AVA0860B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0300_00_ACESSO_DADOS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "31617110000121"},
                { "PROPOVA_COD_CLIENTE" , "8320980"},
                { "PROPOVA_COD_PRODUTO" , ""},
                }, new SQLCA(999));
                AppSettings.TestSet.DynamicData.Remove("R0300_00_ACESSO_DADOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0300_00_ACESSO_DADOS_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion
                var program = new VA0860B();
                program.Execute(RETDEB_FILE_NAME_P, AVA0860B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 9);
                Assert.True(program.WORK_AREA.AC_LIDOS == 1);

            }
        }
    }
}