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
using static Code.SI4922B;

namespace FileTests.Test
{
    [Collection("SI4922B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SI4922B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R000_INICIO_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R000_INICIO_DB_SELECT_1_Query1", q0);

            #endregion

            #region R000_INICIO_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R000_INICIO_DB_SELECT_2_Query1", q1);

            #endregion

            #region R100_LIMITE_MAXIMO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "W_DATA_CORRENTE" , ""},
                { "W_DATA_LIMITE_MAXIMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R100_LIMITE_MAXIMO_DB_SELECT_1_Query1", q2);

            #endregion

            #region R110_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "W_DATA_PROXIMO_DIA_UTIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R110_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1", q3);

            #endregion

            #region SI4922B_CURSOR_DATA

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("SI4922B_CURSOR_DATA", q4);

            #endregion

            #endregion
        }

        [Fact]
        public static void SI4922B_Tests_Fact()
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
                var program = new SI4922B();
                program.Execute(new SI4922B_LK_PARAMETRO());

                Assert.True(true);
            }
        }
    }
}