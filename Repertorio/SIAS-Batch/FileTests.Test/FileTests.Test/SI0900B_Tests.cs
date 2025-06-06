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
using static Code.SI0900B;

namespace FileTests.Test
{
    [Collection("SI0900B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0900B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region Execute_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SISTEMA_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

            #endregion

            #region Execute_DB_UPDATE_1_Update1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0SISTEMA_DTULTPCS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_UPDATE_1_Update1", q1);

            #endregion

            #endregion
        }

        [Fact]
        public static void SI0900B_Tests_Fact_Returning00()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region Execute_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0SISTEMA_DTMOVABE" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

                #endregion

                #region Execute_DB_UPDATE_1_Update1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V0SISTEMA_DTULTPCS" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_UPDATE_1_Update1", q1);

                #endregion
                #endregion
                var program = new SI0900B();
                program.Execute();

                var envList1 = AppSettings.TestSet.DynamicData["Execute_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envListUpdate = AppSettings.TestSet.DynamicData["Execute_DB_UPDATE_1_Update1"].DynamicList.ToList();
                Assert.True(envListUpdate.Count() > 1);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Fact]
        public static void SI0900B_Tests_Fact_Returning99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region Execute_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0SISTEMA_DTMOVABE" , "2020-01-01"}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

                #endregion

                #region Execute_DB_UPDATE_1_Update1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V0SISTEMA_DTULTPCS" , "2020-01-01"}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_UPDATE_1_Update1", q1);

                #endregion
                #endregion
                var program = new SI0900B();
                program.Execute();

                var envList1 = AppSettings.TestSet.DynamicData["Execute_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envListUpdate = AppSettings.TestSet.DynamicData["Execute_DB_UPDATE_1_Update1"].DynamicList.ToList();
                Assert.True(envListUpdate.Count() > 0);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}