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
using Dclgens;
using Code;
using static Code.SI0850B;

namespace FileTests.Test
{
    [Collection("SI0850B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0850B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region SI0850B_CSINISTRO

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISMES_RAMO" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "SINISMES_DATA_COMUNICADO" , ""},
                { "SINISMES_DATA_TECNICA" , ""},
                { "SINISMES_COD_CAUSA" , ""},
                { "DIAS_PENDENTES" , ""},
                { "DCLCLIENTES_NOME_RAZAO" , ""},
                { "WS_DATE_AMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0850B_CSINISTRO", q0);

            #endregion

            #region R0010_PROCURAR_DATA_SISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0010_PROCURAR_DATA_SISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0020_PROCURAR_RELATORIO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "W_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0020_PROCURAR_RELATORIO_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0030_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0030_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1", q3);

            #endregion

            #region R1070_ENCONTRAR_FONTE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "FONTES_NOME_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1070_ENCONTRAR_FONTE_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1080_ENCONTRAR_RAMOS_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "RAMOS_NOME_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1080_ENCONTRAR_RAMOS_DB_SELECT_1_Query1", q5);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0850B_OUTPUT_202504170000", "SI0850B_OUTPUT_202504170001")]
        public static void SI0850B_Tests_Theory(string RSI0850B_FILE_NAME_P, string S0850B_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                SI1000S_Tests.Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region SI0850B_CSINISTRO

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                    { "SINISMES_COD_FONTE" , ""},
                    { "SINISMES_RAMO" , ""},
                    { "SINISMES_DATA_OCORRENCIA" , ""},
                    { "SINISMES_DATA_COMUNICADO" , ""},
                    { "SINISMES_DATA_TECNICA" , ""},
                    { "SINISMES_COD_CAUSA" , ""},
                    { "DIAS_PENDENTES" , ""},
                    { "DCLCLIENTES_NOME_RAZAO" , ""},
                    { "WS_DATE_AMP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0850B_CSINISTRO");
                AppSettings.TestSet.DynamicData.Add("SI0850B_CSINISTRO", q0);

                #endregion

                #region R0010_PROCURAR_DATA_SISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0010_PROCURAR_DATA_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_PROCURAR_DATA_SISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0020_PROCURAR_RELATORIO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "W_COUNT" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0020_PROCURAR_RELATORIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0020_PROCURAR_RELATORIO_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0030_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0030_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0030_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1", q3);

                #endregion

                #region R1070_ENCONTRAR_FONTE_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "FONTES_NOME_FONTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1070_ENCONTRAR_FONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1070_ENCONTRAR_FONTE_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1080_ENCONTRAR_RAMOS_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "RAMOS_NOME_RAMO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1080_ENCONTRAR_RAMOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1080_ENCONTRAR_RAMOS_DB_SELECT_1_Query1", q5);

                #endregion

                #endregion
                #endregion
                var program = new SI0850B();
                program.Execute(RSI0850B_FILE_NAME_P, S0850B_FILE_NAME_P);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();

                var update = AppSettings.TestSet.DynamicData["R0030_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(update[1].TryGetValue("SISTEMAS_DATA_MOV_ABERTO", out string value1) && value1.Equals("          "));
                Assert.True(update[1].TryGetValue("UpdateCheck", out string value2) && value2.Equals("UpdateCheck"));

                Assert.True(selects.Count > allSelects.Count / 2);

                Assert.True(program.RETURN_CODE.Value == 0);
            }
        }

        [Theory]
        [InlineData("SI0850B_OUTPUT_202504170002", "SI0850B_OUTPUT_202504170003")]
        public static void SI0850B_Tests_ReturnCode99_Theory(string RSI0850B_FILE_NAME_P, string S0850B_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                SI1000S_Tests.Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region SI0850B_CSINISTRO

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                    { "SINISMES_COD_FONTE" , ""},
                    { "SINISMES_RAMO" , ""},
                    { "SINISMES_DATA_OCORRENCIA" , ""},
                    { "SINISMES_DATA_COMUNICADO" , ""},
                    { "SINISMES_DATA_TECNICA" , ""},
                    { "SINISMES_COD_CAUSA" , ""},
                    { "DIAS_PENDENTES" , ""},
                    { "DCLCLIENTES_NOME_RAZAO" , ""},
                    { "WS_DATE_AMP" , ""},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("SI0850B_CSINISTRO");
                AppSettings.TestSet.DynamicData.Add("SI0850B_CSINISTRO", q0);

                #endregion

                #region R0010_PROCURAR_DATA_SISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""}
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("R0010_PROCURAR_DATA_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_PROCURAR_DATA_SISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0020_PROCURAR_RELATORIO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "W_COUNT" , "1"}
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("R0020_PROCURAR_RELATORIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0020_PROCURAR_RELATORIO_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0030_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0030_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0030_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1", q3);

                #endregion

                #region R1070_ENCONTRAR_FONTE_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "FONTES_NOME_FONTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1070_ENCONTRAR_FONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1070_ENCONTRAR_FONTE_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1080_ENCONTRAR_RAMOS_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "RAMOS_NOME_RAMO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1080_ENCONTRAR_RAMOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1080_ENCONTRAR_RAMOS_DB_SELECT_1_Query1", q5);

                #endregion

                #endregion
                #endregion
                var program = new SI0850B();
                program.Execute(RSI0850B_FILE_NAME_P, S0850B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE.Value == 99);
            }
        }
    }
}