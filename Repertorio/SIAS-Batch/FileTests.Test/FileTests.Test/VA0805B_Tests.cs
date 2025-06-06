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
using static Code.VA0805B;

namespace FileTests.Test
{
    [Collection("VA0805B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class VA0805B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0001_INICIO_PROCESSO_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTCURRENT" , ""},
                { "V1SIST_DTCURRENT_18" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0001_INICIO_PROCESSO_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0002_00_PROC_FITACEF_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NOME_CONVENIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0002_00_PROC_FITACEF_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_0011_CONSISTE_NSA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "FITCEF_NSAC" , ""},
                { "FITCEF_DATA_GERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0011_CONSISTE_NSA_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_0011_CONSISTE_NSA_DB_DELETE_1_Delete1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "FITCEF_NSA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0011_CONSISTE_NSA_DB_DELETE_1_Delete1", q3);

            #endregion

            #region M_2000_CONSISTE_RET_LANCAMENTO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_CODPRODAZ" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_CONSISTE_RET_LANCAMENTO_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_2300_PESQUISA_NOME_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_2300_PESQUISA_NOME_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_2300_10_PESQUISA_CONTA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_2300_10_PESQUISA_CONTA_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_2300_20_PESQUISA_NOME_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NOME" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_2300_20_PESQUISA_NOME_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_2300_10_PESQUISA_CONTA_DB_SELECT_2_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NOME" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_2300_10_PESQUISA_CONTA_DB_SELECT_2_Query1", q8);

            #endregion

            #region M_5600_MOVIMENTO_VAZIO_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "FITCEF_NSA" , ""},
                { "FITCEF_DTRET" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_5600_MOVIMENTO_VAZIO_DB_INSERT_1_Insert1", q9);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("RVA0805B_FILE_NAME_P", "VA0805B_R6131.txt", "RETOPT_FILE_NAME_P", "RETDEB_FILE_NAME_P", "RETCRE_FILE_NAME_P", "SVA0805B_FILE_NAME_P")]
        public static void VA0805B_Tests_Theory_R6131_ReturnCode_9(string RVA0805B_FILE_NAME_P, string RETCEF_FILE_NAME_P, string RETOPT_FILE_NAME_P, string RETDEB_FILE_NAME_P, string RETCRE_FILE_NAME_P, string SVA0805B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVA0805B_FILE_NAME_P = $"{RVA0805B_FILE_NAME_P}_{timestamp}.txt";
            RETOPT_FILE_NAME_P = $"{RETOPT_FILE_NAME_P}_{timestamp}.txt";
            RETDEB_FILE_NAME_P = $"{RETDEB_FILE_NAME_P}_{timestamp}.txt";
            RETCRE_FILE_NAME_P = $"{RETCRE_FILE_NAME_P}_{timestamp}.txt";
            SVA0805B_FILE_NAME_P = $"{SVA0805B_FILE_NAME_P}_{timestamp}.txt";
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
                var program = new VA0805B();
                program.Execute(RVA0805B_FILE_NAME_P, RETCEF_FILE_NAME_P, RETOPT_FILE_NAME_P, RETDEB_FILE_NAME_P, RETCRE_FILE_NAME_P, SVA0805B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 9);
            }
        }
        [Theory]
        [InlineData("RVA0805B_FILE_NAME_P", "VA0805B_R6090.txt", "RETOPT_R6090.txt", "RETDEB_R6090.txt", "RETCRE_R6090.txt", "SVA_R6090.txt")]
        public static void VA0805B_Tests_Theory_R6090_ReturnCode_0(string RVA0805B_FILE_NAME_P, string RETCEF_FILE_NAME_P, string RETOPT_FILE_NAME_P, string RETDEB_FILE_NAME_P, string RETCRE_FILE_NAME_P, string SVA0805B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVA0805B_FILE_NAME_P = $"{RVA0805B_FILE_NAME_P}_{timestamp}.txt";
            RETOPT_FILE_NAME_P = $"{RETOPT_FILE_NAME_P}_{timestamp}.txt";
            RETDEB_FILE_NAME_P = $"{RETDEB_FILE_NAME_P}_{timestamp}.txt";
            RETCRE_FILE_NAME_P = $"{RETCRE_FILE_NAME_P}_{timestamp}.txt";
            SVA0805B_FILE_NAME_P = $"{SVA0805B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_0001_INICIO_PROCESSO_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2020-01-04"},
                { "V1SIST_DTCURRENT" , "2020-01-04"},
                { "V1SIST_DTCURRENT_18" , "2023-01-04"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0001_INICIO_PROCESSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0001_INICIO_PROCESSO_DB_SELECT_1_Query1", q0);

                #endregion
                #region M_0011_CONSISTE_NSA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "FITCEF_NSAC" , ""},
                { "FITCEF_DATA_GERACAO" , "2023-01-03"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0011_CONSISTE_NSA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0011_CONSISTE_NSA_DB_SELECT_1_Query1", q2);

                #endregion

                #region M_0002_00_PROC_FITACEF_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NOME_CONVENIO" , "NOME 6090"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0002_00_PROC_FITACEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0002_00_PROC_FITACEF_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion
                var program = new VA0805B();
                program.Execute(RVA0805B_FILE_NAME_P, RETCEF_FILE_NAME_P, RETOPT_FILE_NAME_P, RETDEB_FILE_NAME_P, RETCRE_FILE_NAME_P, SVA0805B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(program.WHOST_COD_CONVENIO == 6090);
                //M_0011_CONSISTE_NSA_DB_DELETE_1_Delete1
                var envList = AppSettings.TestSet.DynamicData["M_0011_CONSISTE_NSA_DB_DELETE_1_Delete1"].DynamicList;
                Assert.True(envList.Count == 0);

            }
        }
        [Theory]
        [InlineData("RVA0805B_FILE_NAME_P", "VA0805B_R6088.txt", "RETOPT_R6090.txt", "RETDEB_R6090.txt", "RETCRE_R6090.txt", "SVA0805B_FILE_NAME_P")]
        public static void VA0805B_Tests_Theory_R6088_ReturnCode_0(string RVA0805B_FILE_NAME_P, string RETCEF_FILE_NAME_P, string RETOPT_FILE_NAME_P, string RETDEB_FILE_NAME_P, string RETCRE_FILE_NAME_P, string SVA0805B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVA0805B_FILE_NAME_P = $"{RVA0805B_FILE_NAME_P}_{timestamp}.txt";
            RETOPT_FILE_NAME_P = $"{RETOPT_FILE_NAME_P}_{timestamp}.txt";
            RETDEB_FILE_NAME_P = $"{RETDEB_FILE_NAME_P}_{timestamp}.txt";
            RETCRE_FILE_NAME_P = $"{RETCRE_FILE_NAME_P}_{timestamp}.txt";
            SVA0805B_FILE_NAME_P = $"{SVA0805B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_0001_INICIO_PROCESSO_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2020-01-04"},
                { "V1SIST_DTCURRENT" , "2020-01-04"},
                { "V1SIST_DTCURRENT_18" , "2023-01-04"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0001_INICIO_PROCESSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0001_INICIO_PROCESSO_DB_SELECT_1_Query1", q0);

                #endregion
                #region M_0011_CONSISTE_NSA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "FITCEF_NSAC" , ""},
                { "FITCEF_DATA_GERACAO" , "2023-01-03"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0011_CONSISTE_NSA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0011_CONSISTE_NSA_DB_SELECT_1_Query1", q2);

                #endregion

                #region M_0002_00_PROC_FITACEF_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NOME_CONVENIO" , "NOME 6088"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0002_00_PROC_FITACEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0002_00_PROC_FITACEF_DB_SELECT_1_Query1", q1);

                #endregion
                #region M_2000_CONSISTE_RET_LANCAMENTO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_CODPRODAZ" , "AES"}
                });
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_CODPRODAZ" , "AES"}
                });
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_CODPRODAZ" , "ESP"}
                });
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_CODPRODAZ" , "BAS"}
                });
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_CODPRODAZ" , "ESP"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_2000_CONSISTE_RET_LANCAMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_2000_CONSISTE_RET_LANCAMENTO_DB_SELECT_1_Query1", q4);

                #endregion
                #endregion
                var program = new VA0805B();
                program.Execute(RVA0805B_FILE_NAME_P, RETCEF_FILE_NAME_P, RETOPT_FILE_NAME_P, RETDEB_FILE_NAME_P, RETCRE_FILE_NAME_P, SVA0805B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                
                //M_5600_MOVIMENTO_VAZIO_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["M_5600_MOVIMENTO_VAZIO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList[1].TryGetValue("FITCEF_NSA", out var valor0) && valor0.Contains("0376"));
                Assert.True(envList[1].TryGetValue("FITCEF_DTRET", out var valor1) && valor1.Contains("2024-11-26"));
                Assert.True(envList.Count > 1);

            }
        }
    }
}