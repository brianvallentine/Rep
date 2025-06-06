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
using static Code.SI0891B;

namespace FileTests.Test
{

    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0891B_Tests")]
    public class SI0891B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R010_LE_SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SISTEMAS_DATULT_PROCESSAMEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region SI0891B_CTRAB

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_OPERACAO" , ""},
                { "SINISHIS_COD_PRODUTO" , ""},
                { "SINIHAB1_PONTO_VENDA" , ""},
                { "SINIHAB1_NUM_CONTRATO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "HOST_SITUACAO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "GEOPERAC_DES_ABREVIADA" , ""},
                { "HOST_VALOR_HABILIT" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISMES_NUM_PROTOCOLO_SINI" , ""},
                { "USUARIOS_COD_USUARIO" , ""},
                { "USUARIOS_NOME_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0891B_CTRAB", q1);

            #endregion

            #region SI0891B_CMOTI

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SITIPMOT_DES_TIPO_MOTIVO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("SI0891B_CMOTI", q2);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0891B_t1")]
        public static void SI0891B_Tests_Theory(string FENAE01_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            FENAE01_FILE_NAME_P = $"{FENAE01_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                SI1002S_Tests.Load_Parameters();
                SI1000S_Tests.Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R010_LE_SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"},
                { "SISTEMAS_DATULT_PROCESSAMEN" , "2020-01-01"},
                 });
                AppSettings.TestSet.DynamicData.Remove("R010_LE_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0891B_CTRAB

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_OPERACAO" , "1"},
                { "SINISHIS_COD_PRODUTO" , "2"},
                { "SINIHAB1_PONTO_VENDA" , "3"},
                { "SINIHAB1_NUM_CONTRATO" , "123"},
                { "SINISHIS_DATA_MOVIMENTO" , "2020-01-01"},
                { "HOST_SITUACAO" , "5"},
                { "SINISHIS_COD_OPERACAO" , "6"},
                { "GEOPERAC_DES_ABREVIADA" , "x"},
                { "HOST_VALOR_HABILIT" , "7"},
                { "SINISMES_NUM_APOL_SINISTRO" , "8"},
                { "SINISMES_COD_FONTE" , "9"},
                { "SINISMES_NUM_PROTOCOLO_SINI" , "12345"},
                { "USUARIOS_COD_USUARIO" , "1"},
                { "USUARIOS_NOME_USUARIO" , "X"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0891B_CTRAB");
                AppSettings.TestSet.DynamicData.Add("SI0891B_CTRAB", q1);

                #endregion

                #region SI0891B_CMOTI

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SITIPMOT_DES_TIPO_MOTIVO" , "X"}
            });
                AppSettings.TestSet.DynamicData.Remove("SI0891B_CMOTI");
                AppSettings.TestSet.DynamicData.Add("SI0891B_CMOTI", q2);

                #endregion

                #endregion
               
                var program = new SI0891B();
                program.Execute(FENAE01_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["R010_LE_SISTEMA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["SI0891B_CTRAB"].DynamicList;
                Assert.Empty(envList2);

                var envList3 = AppSettings.TestSet.DynamicData["SI0891B_CMOTI"].DynamicList;
                Assert.Empty(envList3);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("SI0891B_t2")]
        public static void SI0891B_Tests9_Theory(string FENAE01_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            FENAE01_FILE_NAME_P = $"{FENAE01_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R010_LE_SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R010_LE_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0891B_CTRAB

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_OPERACAO" , "1"},
                { "SINISHIS_COD_PRODUTO" , "2"},
                { "SINIHAB1_PONTO_VENDA" , "3"},
                { "SINIHAB1_NUM_CONTRATO" , "4"},
                { "SINISHIS_DATA_MOVIMENTO" , "2020-01-01"},
                { "HOST_SITUACAO" , "5"},
                { "SINISHIS_COD_OPERACAO" , "6"},
                { "GEOPERAC_DES_ABREVIADA" , "x"},
                { "HOST_VALOR_HABILIT" , "7"},
                { "SINISMES_NUM_APOL_SINISTRO" , "8"},
                { "SINISMES_COD_FONTE" , "9"},
                { "SINISMES_NUM_PROTOCOLO_SINI" , "10"},
                { "USUARIOS_COD_USUARIO" , "11"},
                { "USUARIOS_NOME_USUARIO" , "X"},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0891B_CTRAB");
                AppSettings.TestSet.DynamicData.Add("SI0891B_CTRAB", q1);

                #endregion

                #region SI0891B_CMOTI

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SITIPMOT_DES_TIPO_MOTIVO" , "X"}
            });
                AppSettings.TestSet.DynamicData.Remove("SI0891B_CMOTI");
                AppSettings.TestSet.DynamicData.Add("SI0891B_CMOTI", q2);

                #endregion

                #endregion

                var program = new SI0891B();
                program.Execute(FENAE01_FILE_NAME_P);
            

                Assert.True(program.RETURN_CODE == 99);


            }
        }
    }
}