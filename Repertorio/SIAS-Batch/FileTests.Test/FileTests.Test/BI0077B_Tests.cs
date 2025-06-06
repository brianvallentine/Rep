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
using static Code.BI0077B;

namespace FileTests.Test
{
    [Collection("BI0077B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class BI0077B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0330_00_SELECT_CONVERSI_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0330_00_SELECT_CONVERSI_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0340_00_CANCELA_BILHETE_DB_UPDATE_1_Update1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0340_00_CANCELA_BILHETE_DB_UPDATE_1_Update1", q2);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("MOVIMENTO_FILE_NAME_P")]
        public static void BI0077B_Tests_Theory(string MOVIMENTO_FILE_NAME_P)
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

                AppSettings.TestSet.DynamicData.Remove("R0330_00_SELECT_CONVERSI_DB_SELECT_1_Query1");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , "123456"}
                });
                AppSettings.TestSet.DynamicData.Add("R0330_00_SELECT_CONVERSI_DB_SELECT_1_Query1", q1);

                #endregion
                var program = new BI0077B();
                program.Execute(MOVIMENTO_FILE_NAME_P);

                var envList = AppSettings.TestSet.DynamicData["R0340_00_CANCELA_BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList?.Count > 1);

                Assert.True(envList[1].TryGetValue("BILHETE_NUM_BILHETE", out string valor) && valor == "000000000123456");
            }
        }
    }
}