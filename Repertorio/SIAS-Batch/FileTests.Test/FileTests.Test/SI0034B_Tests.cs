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
using static Code.SI0034B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("SI0034B_Tests")]
    public class SI0034B_Tests
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

            #region SI0034B_LISTA

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SIANAROD_COD_USUARIO" , ""},
                { "SIDOCPAR_COD_TIPO_CARTA" , ""},
                { "SIEVETIP_DESCR_EVENTO" , ""},
                { "SIDOCACO_COD_FONTE" , ""},
                { "SIDOCACO_NUM_PROTOCOLO_SINI" , ""},
                { "SIDOCACO_DAC_PROTOCOLO_SINI" , ""},
                { "SIDOCACO_DATA_MOVTO_DOCACO" , ""},
                { "SIDOCACO_NUM_CARTA" , ""},
                { "SIMOVSIN_NATUREZA_SINISTRO" , ""},
                { "SIMOVSIN_NOME_SEGURADO" , ""},
                { "SIMOVSIN_COD_GIAFI" , ""},
                { "GERECADE_COD_DESTINATARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0034B_LISTA", q3);

            #endregion

            #region R1100_00_LE_USUARIOS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_NOME_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_LE_USUARIOS_DB_SELECT_1_Query1", q4);

            #endregion

            #region R2100_00_LE_GEDESTIN_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "GEDESTIN_NOME_DESTINATARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_LE_GEDESTIN_DB_SELECT_1_Query1", q5);

            #endregion

            #region R3100_00_LE_SISINACO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_DATA_MOVTO_SINIACO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_LE_SISINACO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R3200_00_LE_SINISMES_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_IRB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_LE_SINISMES_DB_SELECT_1_Query1", q7);

            #endregion

            #region R3300_00_CARTA_ORIGINAL_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "GECARTA_NUM_CARTA_REITERA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3300_00_CARTA_ORIGINAL_DB_SELECT_1_Query1", q8);

            #endregion

            #region R3300_00_CARTA_ORIGINAL_DB_SELECT_2_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "HOST_DATA_CARTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3300_00_CARTA_ORIGINAL_DB_SELECT_2_Query1", q9);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0034B_t1")]
        public static void SI0034B_Tests_Theory_Erro99(string SI0034B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0034B1_FILE_NAME_P = $"{SI0034B1_FILE_NAME_P}_{timestamp}.txt";

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
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #endregion
                var program = new SI0034B();
                program.Execute(SI0034B1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Theory]
        [InlineData("SI0034B_t2")]
        public static void SI0034B_Tests_Theory(string SI0034B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0034B1_FILE_NAME_P = $"{SI0034B1_FILE_NAME_P}_{timestamp}.txt";

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
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-04-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion
                #region R3300_00_CARTA_ORIGINAL_DB_SELECT_2_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "HOST_DATA_CARTA" , "10"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3300_00_CARTA_ORIGINAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R3300_00_CARTA_ORIGINAL_DB_SELECT_2_Query1", q9);

                #endregion
                #endregion
                var program = new SI0034B();
                program.Execute(SI0034B1_FILE_NAME_P);

                //R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1"].DynamicList);

                //R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1
                var envList = AppSettings.TestSet.DynamicData["R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("SISTEMAS_DATA_MOV_ABERTO", out var valor) && valor.Contains("2020-04-01"));
                Assert.True(envList.Count > 1);

                //R1100_00_LE_USUARIOS_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["R1100_00_LE_USUARIOS_DB_SELECT_1_Query1"].DynamicList);

                //R2100_00_LE_GEDESTIN_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["R2100_00_LE_GEDESTIN_DB_SELECT_1_Query1"].DynamicList);

                //R3100_00_LE_SISINACO_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["R3100_00_LE_SISINACO_DB_SELECT_1_Query1"].DynamicList);

                //R3200_00_LE_SINISMES_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["R3200_00_LE_SINISMES_DB_SELECT_1_Query1"].DynamicList);

                //R3300_00_CARTA_ORIGINAL_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["R3300_00_CARTA_ORIGINAL_DB_SELECT_1_Query1"].DynamicList);

                //R3300_00_CARTA_ORIGINAL_DB_SELECT_2_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["R3300_00_CARTA_ORIGINAL_DB_SELECT_2_Query1"].DynamicList);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}