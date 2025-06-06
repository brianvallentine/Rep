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
using static Code.SI0861B;

namespace FileTests.Test
{
    [Collection("SI0861B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0861B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region Execute_DB_UPDATE_1_Update1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_UPDATE_1_Update1", q0);

            #endregion

            #region R010_SELECT_SISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI0861B_RELATORIOS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , ""},
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "HOST_DATA_INICIAL" , ""},
                { "HOST_DATA_FINAL" , ""},
                { "HOST_RAMO_INICIAL" , ""},
                { "HOST_CODSUBES_INICIAL" , ""},
                { "HOST_APOLICE_INICIAL" , ""},
                { "HOST_PRODUTO_INICIAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0861B_RELATORIOS", q2);

            #endregion

            #region SI0861B_PAGO

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_TIPO_REGISTRO" , ""},
                { "HOST_FONTE" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0861B_PAGO", q3);

            #endregion

            #region R021_FETCH_RELATORIO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_NOME_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R021_FETCH_RELATORIO_DB_SELECT_1_Query1", q4);

            #endregion

            #region SI0861B_PENDENTE

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_TIPO_REGISTRO" , ""},
                { "HOST_FONTE" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0861B_PENDENTE", q5);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0861B_t1")]
        public static void SI0861B_Tests_Theory(string ARQ_SAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQ_SAIDA_FILE_NAME_P = $"{ARQ_SAIDA_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                SI1001S_Tests.Load_Parameters();
                SI1002S_Tests.Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R010_SELECT_SISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2022-02-02"}
                });
                AppSettings.TestSet.DynamicData.Remove("R010_SELECT_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0861B_RELATORIOS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , "1"},
                { "RELATORI_DATA_SOLICITACAO" , "2022-02-02"},
                { "HOST_DATA_INICIAL" , "2020-01-01"},
                { "HOST_DATA_FINAL" , "2020-01-01"},
                { "HOST_RAMO_INICIAL" , "x"},
                { "HOST_CODSUBES_INICIAL" , "2"},
                { "HOST_APOLICE_INICIAL" , "123"},
                { "HOST_PRODUTO_INICIAL" , "8"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0861B_RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0861B_RELATORIOS", q2);

                #endregion

                #region SI0861B_PAGO

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_TIPO_REGISTRO" , "X"},
                { "HOST_FONTE" , "X"},
                { "SINISMES_NUM_APOL_SINISTRO" , "123456"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0861B_PAGO");
                AppSettings.TestSet.DynamicData.Add("SI0861B_PAGO", q3);

                #endregion

                #region R021_FETCH_RELATORIO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_NOME_USUARIO" , "X"}
                });
                AppSettings.TestSet.DynamicData.Remove("R021_FETCH_RELATORIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R021_FETCH_RELATORIO_DB_SELECT_1_Query1", q4);

                #endregion

                #region SI0861B_PENDENTE

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_TIPO_REGISTRO" , "X"},
                { "HOST_FONTE" , "X"},
                { "SINISMES_NUM_APOL_SINISTRO" , "123456"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0861B_PENDENTE");
                AppSettings.TestSet.DynamicData.Add("SI0861B_PENDENTE", q5);

                #endregion
               
                #endregion
                
                var program = new SI0861B();
                program.Execute(ARQ_SAIDA_FILE_NAME_P);

                  

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                #region Execute_DB_UPDATE_1_Update1         

                var envList = AppSettings.TestSet.DynamicData["Execute_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList?.Count > 1);
            
                #endregion

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0861B_t2")]
        public static void SI0861B_Tests99_Theory(string ARQ_SAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQ_SAIDA_FILE_NAME_P = $"{ARQ_SAIDA_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE


                #region R010_SELECT_SISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();

                AppSettings.TestSet.DynamicData.Remove("R010_SELECT_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0861B_RELATORIOS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , null},
                { "RELATORI_DATA_SOLICITACAO" , null},
                { "HOST_DATA_INICIAL" , null},
                { "HOST_DATA_FINAL" , null},
                { "HOST_RAMO_INICIAL" , null},
                { "HOST_CODSUBES_INICIAL" , null},
                { "HOST_APOLICE_INICIAL" , null},
                { "HOST_PRODUTO_INICIAL" , null},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0861B_RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0861B_RELATORIOS", q2);

                #endregion

                #region SI0861B_PAGO

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_TIPO_REGISTRO" , null},
                { "HOST_FONTE" , null},
                { "SINISMES_NUM_APOL_SINISTRO" , null},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0861B_PAGO");
                AppSettings.TestSet.DynamicData.Add("SI0861B_PAGO", q3);

                #endregion

                #region R021_FETCH_RELATORIO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_NOME_USUARIO" , null}
                });
                AppSettings.TestSet.DynamicData.Remove("R021_FETCH_RELATORIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R021_FETCH_RELATORIO_DB_SELECT_1_Query1", q4);

                #endregion

                #region SI0861B_PENDENTE

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_TIPO_REGISTRO" , null},
                { "HOST_FONTE" , null},
                { "SINISMES_NUM_APOL_SINISTRO" , null},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0861B_PENDENTE");
                AppSettings.TestSet.DynamicData.Add("SI0861B_PENDENTE", q5);

                #endregion

                #endregion
                var program = new SI0861B();
                program.Execute(ARQ_SAIDA_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}