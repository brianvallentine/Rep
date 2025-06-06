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
using static Code.SI0181B;
using Newtonsoft.Json;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0181B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SI0181B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0090_00_OBTER_DATA_SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0090_00_OBTER_DATA_SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region SI0181B_PRINCIPAL

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_HORA_OPERACAO" , ""},
                { "SINISHIS_COD_USUARIO" , ""},
                { "USUARIOS_NOME_USUARIO" , ""},
                { "SINISHIS_COD_PRODUTO" , ""},
                { "SINISHIS_NUM_APOLICE" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISHIS_NOM_PROGRAMA" , ""},
                { "ESTRUTUR_NOME_GRUPO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "GEOPERAC_DES_OPERACAO" , ""},
                { "WHOST_SIT_MOVIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0181B_PRINCIPAL", q1);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("ARQSAIDA")]
        public static void SI0181B_Tests_Theory(string ARQSAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSAIDA_FILE_NAME_P = $"{ARQSAIDA_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                var program = new SI0181B();

                var fileName = Path.GetFileNameWithoutExtension(ARQSAIDA_FILE_NAME_P);
                ARQSAIDA_FILE_NAME_P = ARQSAIDA_FILE_NAME_P.Replace(fileName, fileName + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"));

                Console.WriteLine($"#### Arquivo {JsonConvert.SerializeObject(AppSettings.Settings, Formatting.Indented)}");
                Console.WriteLine($"#### Arquivo {ARQSAIDA_FILE_NAME_P} em : {AppSettings.Settings.FileFolderPath}");


                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                program.Execute(ARQSAIDA_FILE_NAME_P);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(File.Exists(program.ARQSAIDA.FilePath));
                Assert.True(new FileInfo(program.ARQSAIDA.FilePath)?.Length > 0);
            }
        }
        [Theory]
        [InlineData("ARQSAIDA")]
        public static void SI0181B_Tests_SemDados(string ARQSAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSAIDA_FILE_NAME_P = $"{ARQSAIDA_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                var program = new SI0181B();

                Load_Parameters();


                #region VARIAVEIS_TESTE
                #region R0100_00_SELECT_SISTEMAS_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0090_00_OBTER_DATA_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0090_00_OBTER_DATA_SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                program.Execute(ARQSAIDA_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);

            }
        }
    }
}