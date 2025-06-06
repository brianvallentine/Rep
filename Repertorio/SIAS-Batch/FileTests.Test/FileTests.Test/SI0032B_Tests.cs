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
using static Code.SI0032B;

namespace FileTests.Test
{
    [Collection("SI0032B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0032B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1", q2);

            #endregion

            #region SI0032B_LISTA

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SIANAROD_COD_USUARIO" , ""},
                { "SISINACO_COD_FONTE" , ""},
                { "SISINACO_NUM_PROTOCOLO_SINI" , ""},
                { "SISINACO_DAC_PROTOCOLO_SINI" , ""},
                { "SISINACO_COD_EVENTO" , ""},
                { "SISINACO_DATA_MOVTO_SINIACO" , ""},
                { "SIMOVSIN_NATUREZA_SINISTRO" , ""},
                { "SIMOVSIN_NOME_SEGURADO" , ""},
                { "SINISMES_NUM_IRB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0032B_LISTA", q3);

            #endregion

            #region R1100_00_LE_USUARIOS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_NOME_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_LE_USUARIOS_DB_SELECT_1_Query1", q4);

            #endregion

            #region R2100_00_LE_SISINACO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_DATA_AVISO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_LE_SISINACO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R2200_00_LE_SIEVETIP_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SIEVETIP_DESCR_EVENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_LE_SIEVETIP_DB_SELECT_1_Query1", q6);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0032B_t1")]
        public static void SI0032B_Tests_Theory_Return00(string SI0032B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0032B1_FILE_NAME_P = $"{SI0032B1_FILE_NAME_P}_{timestamp}.txt";
           
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1", q2);

                #endregion

                #region SI0032B_LISTA

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SIANAROD_COD_USUARIO" , "0"},
                { "SISINACO_COD_FONTE" , "0"},
                { "SISINACO_NUM_PROTOCOLO_SINI" , "0"},
                { "SISINACO_DAC_PROTOCOLO_SINI" , "0"},
                { "SISINACO_COD_EVENTO" , "0"},
                { "SISINACO_DATA_MOVTO_SINIACO" , "2020-01-01"},
                { "SIMOVSIN_NATUREZA_SINISTRO" , "0"},
                { "SIMOVSIN_NOME_SEGURADO" , "0"},
                { "SINISMES_NUM_IRB" , "0"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0032B_LISTA");
                AppSettings.TestSet.DynamicData.Add("SI0032B_LISTA", q3);

                #endregion

                #region R1100_00_LE_USUARIOS_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_NOME_USUARIO" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_USUARIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_USUARIOS_DB_SELECT_1_Query1", q4);

                #endregion

                #region R2100_00_LE_SISINACO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_DATA_AVISO" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_LE_SISINACO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_LE_SISINACO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R2200_00_LE_SIEVETIP_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SIEVETIP_DESCR_EVENTO" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_LE_SIEVETIP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_LE_SIEVETIP_DB_SELECT_1_Query1", q6);

                #endregion
                #endregion
                var program = new SI0032B();
                program.Execute(SI0032B1_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList4 = AppSettings.TestSet.DynamicData["SI0032B_LISTA"].DynamicList;
                Assert.Empty(envList1);

                var envList5 = AppSettings.TestSet.DynamicData["R1100_00_LE_USUARIOS_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList6 = AppSettings.TestSet.DynamicData["R2100_00_LE_SISINACO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList7 = AppSettings.TestSet.DynamicData["R2200_00_LE_SIEVETIP_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var updates = AppSettings.TestSet.DynamicData.Where(
                   x => x.Key.Contains("UPDATE") &&
                   x.Value.DynamicList.Count > 1 &&
                   x.Value.DynamicList.Where(
                       y => y.ContainsKey("UpdateCheck")).ToList().Count > 0).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();

                Assert.True(updates.Count > (allUpdates.Count / 2));

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("SI0032B_t2")]
        public static void SI0032B_Tests_Theory_Return99(string SI0032B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0032B1_FILE_NAME_P = $"{SI0032B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , "0"}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1", q2);

                #endregion

                #region SI0032B_LISTA

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SIANAROD_COD_USUARIO" , "0"},
                { "SISINACO_COD_FONTE" , "0"},
                { "SISINACO_NUM_PROTOCOLO_SINI" , "0"},
                { "SISINACO_DAC_PROTOCOLO_SINI" , "0"},
                { "SISINACO_COD_EVENTO" , "0"},
                { "SISINACO_DATA_MOVTO_SINIACO" , "2020-01-01"},
                { "SIMOVSIN_NATUREZA_SINISTRO" , "0"},
                { "SIMOVSIN_NOME_SEGURADO" , "0"},
                { "SINISMES_NUM_IRB" , "0"},
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("SI0032B_LISTA");
                AppSettings.TestSet.DynamicData.Add("SI0032B_LISTA", q3);

                #endregion

                #region R1100_00_LE_USUARIOS_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_NOME_USUARIO" , "0"}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_USUARIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_USUARIOS_DB_SELECT_1_Query1", q4);

                #endregion

                #region R2100_00_LE_SISINACO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_DATA_AVISO" , "0"}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2100_00_LE_SISINACO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_LE_SISINACO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R2200_00_LE_SIEVETIP_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SIEVETIP_DESCR_EVENTO" , "0"}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2200_00_LE_SIEVETIP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_LE_SIEVETIP_DB_SELECT_1_Query1", q6);

                #endregion
                #endregion
                var program = new SI0032B();
                program.Execute(SI0032B1_FILE_NAME_P);
                
                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}