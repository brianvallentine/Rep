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
using static Code.CB0055B;

namespace FileTests.Test
{
    [Collection("CB0055B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class CB0055B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2020-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region CB0055B_V1ENDOSSO

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_NUM_APOL" , "107900324"},
                { "V1ENDO_NUMBIL" , "1234"},
            });
            AppSettings.TestSet.DynamicData.Add("CB0055B_V1ENDOSSO", q1);

            #endregion

            #region R2000_00_SELECT_ADIANTA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1ADIA_NUMOPG" , "7890"}
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_SELECT_ADIANTA_DB_SELECT_1_Query1", q2);

            #endregion

            #region R4200_00_UPDATE_V0ADIANTA_DB_UPDATE_1_Update1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0ADIA_NUM_APOL" , ""},
                { "WHOST_NUM_APOL" , ""},
                { "V1ADIA_NUMOPG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4200_00_UPDATE_V0ADIANTA_DB_UPDATE_1_Update1", q3);

            #endregion

            #region R4300_00_UPDATE_V0FORMAREC_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0FORM_NUM_APOL" , ""},
                { "WHOST_NUM_APOL" , ""},
                { "V1ADIA_NUMOPG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4300_00_UPDATE_V0FORMAREC_DB_UPDATE_1_Update1", q4);

            #endregion

            #region R4400_00_UPDATE_V0HISTOREC_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0HISR_NUM_APOL" , ""},
                { "WHOST_NUM_APOL" , ""},
                { "V1ADIA_NUMOPG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4400_00_UPDATE_V0HISTOREC_DB_UPDATE_1_Update1", q5);

            #endregion

            #endregion
        }

        [Fact]
        public static void CB0055B_Tests_Fact_ReturnCode_0()
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
                #endregion
                var program = new CB0055B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 0);

                //R4200_00_UPDATE_V0ADIANTA_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["R4200_00_UPDATE_V0ADIANTA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("V0ADIA_NUM_APOL", out var valor0) && valor0.Contains("0000107900324"));

                //R4300_00_UPDATE_V0FORMAREC_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["R4300_00_UPDATE_V0FORMAREC_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("WHOST_NUM_APOL", out var valor1) && valor1.Contains("0000000001234"));

                //R4400_00_UPDATE_V0HISTOREC_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R4400_00_UPDATE_V0HISTOREC_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("V1ADIA_NUMOPG", out var valor2) && valor2.Contains("000007890"));

            }
        }
        [Fact]
        public static void CB0055B_Tests_Fact_ReturnCode_99()
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

                #region CB0055B_V1ENDOSSO

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_NUM_APOL" , "107900324"},
                });
                AppSettings.TestSet.DynamicData.Remove("CB0055B_V1ENDOSSO");
                AppSettings.TestSet.DynamicData.Add("CB0055B_V1ENDOSSO", q1);

                #endregion
                #endregion
                var program = new CB0055B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
        [Fact]
        public static void CB0055B_Tests_Fact_SemMovimento_ReturnCode_00()
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

                #region CB0055B_V1ENDOSSO

                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("CB0055B_V1ENDOSSO");
                AppSettings.TestSet.DynamicData.Add("CB0055B_V1ENDOSSO", q1);

                #endregion
                #endregion
                var program = new CB0055B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 0);
            }
        }

    }
}