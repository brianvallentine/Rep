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
using static Code.VA2721B;
using System.IO;
using Dclgens;

namespace FileTests.Test
{
    [Collection("VA2721B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA2721B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-27"}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_SOLICITACAO" , "2025-01-25"}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1", q1);

            #endregion

            #region VA2721B_TPROPOVA

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , "1"},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "PROPOVA_DATA_MOVIMENTO" , ""},
                { "WHOST_VLPREMIO" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "HISCONPA_SIT_REGISTRO" , "1"},
                { "HISCONPA_DATA_MOVIMENTO" , "2025-01-27"},
                { "HISCONPA_NUM_PARCELA" , "2"},
                { "HISCONPA_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA2721B_TPROPOVA", q2);

            #endregion

            #region R1400_00_SELECT_PROPOFID_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_SIT_PROPOSTA" , "AAAA"},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , "1111"},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_VLPREMIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1600_00_SELECT_PARCEVID_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_PARCEVID_DB_SELECT_1_Query1", q5);

            #endregion

            #region R8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1", q6);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VA2721B_OUTPUT_20250226100700")]
        public static void VA2721B_Tests_Theory_ReturnCode_00(string AVA2721B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            AVA2721B_FILE_NAME_P = $"{AVA2721B_FILE_NAME_P}_{timestamp}.txt";
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

                var program = new VA2721B();
                program.WORK_AREA.WS_NUM_PROPOSTA.Value = 1;
                program.WHOST_OPERACAO.Value = "EMISSAO";

                program.Execute(AVA2721B_FILE_NAME_P);

                Assert.True(File.Exists(program.AVA2721B.FilePath));

                Assert.Empty(AppSettings.TestSet.DynamicData["R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1400_00_SELECT_PROPOFID_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1600_00_SELECT_PARCEVID_DB_SELECT_1_Query1"].DynamicList);

                var index = AppSettings.TestSet.DynamicData["R8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1"].DynamicList.Count - 1;
                var updateCheck = AppSettings.TestSet.DynamicData["R8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1"].DynamicList[index].Where(x => x.Value.Contains("UpdateCheck")).ToList();

                Assert.NotEmpty(updateCheck);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("VA2721B_OUTPUT_20250226100700")]
        public static void VA2721B_Tests_Theory_ReturnCode_99(string AVA2721B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            AVA2721B_FILE_NAME_P = $"{AVA2721B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-27"}
                }, new SQLCA(999));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);
                #endregion

                var program = new VA2721B();
                program.WORK_AREA.WS_NUM_PROPOSTA.Value = 1;
                program.WHOST_OPERACAO.Value = "EMISSAO";

                program.Execute(AVA2721B_FILE_NAME_P);


                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}