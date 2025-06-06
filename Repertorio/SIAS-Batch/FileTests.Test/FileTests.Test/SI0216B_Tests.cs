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
using static Code.SI0216B;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0216B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class SI0216B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R010_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-27"},
                { "SISTEMAS_DATULT_PROCESSAMEN" , "2025-01-24"},
                { "HOST_DATA_CORRENTE" , "2025-03-11"},
            });
            AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "EMPRESAS_NOME_EMPRESA" , "CAIXA SEGURADORA S.A.                   "}
            });
            AppSettings.TestSet.DynamicData.Add("R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI0216B_PROVISAO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SI111_NUM_APOL_SINISTRO" , "101400033182"},
                { "SI111_NUM_RESSARC" , "1"},
                { "SI111_NUM_PARCELA" , "1"},
                { "SI111_NUM_NOSSO_TITULO" , "8000100043268445"},
                { "SI111_DTH_VENCIMENTO" , "2010-05-29"},
                { "SINISHIS_OCORR_HISTORICO" , "1"},
                { "SINISHIS_COD_OPERACAO" , "4000"},
                { "SINISHIS_VAL_OPERACAO" , "50000.00"},
                { "SINISHIS_DATA_MOVIMENTO" , "2025-01-25"},
                { "HOST_VALOR_HONORARIO" , "-146975.30"},
                { "HOST_VALOR_REPASSE" , "-146975.30"},
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "SI111_NUM_APOL_SINISTRO" , "101400033182"},
                { "SI111_NUM_RESSARC" , "1"},
                { "SI111_NUM_PARCELA" , "1"},
                { "SI111_NUM_NOSSO_TITULO" , "8000100043268445"},
                { "SI111_DTH_VENCIMENTO" , "2010-05-29"},
                { "SINISHIS_OCORR_HISTORICO" , "1"},
                { "SINISHIS_COD_OPERACAO" , "4003"},
                { "SINISHIS_VAL_OPERACAO" , "50000.00"},
                { "SINISHIS_DATA_MOVIMENTO" , "2025-01-25"},
                { "HOST_VALOR_HONORARIO" , "-146975.30"},
                { "HOST_VALOR_REPASSE" , "-146975.30"},
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "SI111_NUM_APOL_SINISTRO" , "101400033182"},
                { "SI111_NUM_RESSARC" , "1"},
                { "SI111_NUM_PARCELA" , "1"},
                { "SI111_NUM_NOSSO_TITULO" , "8000100043268445"},
                { "SI111_DTH_VENCIMENTO" , "2010-05-29"},
                { "SINISHIS_OCORR_HISTORICO" , "1"},
                { "SINISHIS_COD_OPERACAO" , "4005"},
                { "SINISHIS_VAL_OPERACAO" , "50000.00"},
                { "SINISHIS_DATA_MOVIMENTO" , "2025-01-25"},
                { "HOST_VALOR_HONORARIO" , "-146975.30"},
                { "HOST_VALOR_REPASSE" , "-146975.30"},
            });
            AppSettings.TestSet.DynamicData.Add("SI0216B_PROVISAO", q2);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0216B_OUTPUT_2025031109070000")]
        public static void SI0216B_Tests_Theory(string REG_RET_FILE_NAME_P)
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
                var program = new SI0216B();
                program.Execute(REG_RET_FILE_NAME_P);

                Assert.True(File.Exists(program.REG_RET.FilePath) && new FileInfo(program.REG_RET.FilePath)?.Length > 0);

                var select1 = AppSettings.TestSet.DynamicData["R010_LE_SISTEMAS_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select1);

                var select2 = AppSettings.TestSet.DynamicData["R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(select2);
                
                var select3 = AppSettings.TestSet.DynamicData["SI0216B_PROVISAO"].DynamicList.ToList();
                Assert.Empty(select3);

                Assert.True(program.RETURN_CODE == 0);
            }
        }
    }
}