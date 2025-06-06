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
using static Code.VA0132B;

namespace FileTests.Test
{
    [Collection("VA0132B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0132B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R2200_00_PROCESSA_INSERT_DB_INSERT_1_Insert1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "VA111_NUM_CPF_CNPJ" , ""},
                { "VA111_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_INSERT_DB_INSERT_1_Insert1", q0);

            #endregion

            #region R2210_ATUALIZA_REGISTRO_DB_UPDATE_1_Update1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "VA111_COD_USUARIO" , ""},
                { "REG_STA_CARENCIA" , ""},
                { "VA111_NUM_CPF_CNPJ" , ""},
                { "WS_STA_CARENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2210_ATUALIZA_REGISTRO_DB_UPDATE_1_Update1", q1);

            #endregion

            #region R2211_00_VERIFICA_SITUACAO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "WS_STA_CARENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2211_00_VERIFICA_SITUACAO_DB_SELECT_1_Query1", q2);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("26358787000151N", "saida_VA0132B.txt")]
        public static void VA0132B_Tests_Theory(string SCARENCIA_FILE_NAME_P, string RCARENCIA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RCARENCIA_FILE_NAME_P = $"{RCARENCIA_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VA0132B();
                AppSettings.Settings.MemoryFiles.Add(SCARENCIA_FILE_NAME_P);
                program.Execute(SCARENCIA_FILE_NAME_P, RCARENCIA_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["R2200_00_PROCESSA_INSERT_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1?.Count > 1);

            }
        }

        [Theory]
        [InlineData("26358787000151N", "saida_VA0132B.txt")]
        public static void VA0132B_Tests_Theory_Update(string SCARENCIA_FILE_NAME_P, string RCARENCIA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RCARENCIA_FILE_NAME_P = $"{RCARENCIA_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE
                var q68 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R2200_00_PROCESSA_INSERT_DB_INSERT_1_Insert1");
                q68.AddDynamic(new Dictionary<string, string>
                {
                }, new SQLCA(-803));
                AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_INSERT_DB_INSERT_1_Insert1", q68);

                #endregion
                var program = new VA0132B();
                AppSettings.Settings.MemoryFiles.Add(SCARENCIA_FILE_NAME_P);
                program.Execute(SCARENCIA_FILE_NAME_P, RCARENCIA_FILE_NAME_P);

                var envList2 = AppSettings.TestSet.DynamicData["R2210_ATUALIZA_REGISTRO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("REG_STA_CARENCIA", out var val1r) && val1r.Contains("N"));
            }
        }
    }
}