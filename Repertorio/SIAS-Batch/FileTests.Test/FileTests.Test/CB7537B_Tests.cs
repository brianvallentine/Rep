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
using static Code.CB7537B;

namespace FileTests.Test
{
    [Collection("CB7537B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class CB7537B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SISTEMAS_DATULT_PROCESSAMEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region CB7537B_V0MOVICOB

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_BANCO" , ""},
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "MOVIMCOB_DATA_QUITACAO" , ""},
                { "MOVIMCOB_NUM_TITULO" , ""},
                { "MOVIMCOB_NUM_APOLICE" , ""},
                { "MOVIMCOB_NUM_PARCELA" , ""},
                { "MOVIMCOB_VAL_TITULO" , ""},
                { "MOVIMCOB_VAL_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB7537B_V0MOVICOB", q1);

            #endregion

            #region R0520_00_SELECT_SINISMES_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_FONTE" , ""},
                { "PRODUTO_COD_PRODUTO" , ""},
                { "PRODUTO_RAMO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0520_00_SELECT_SINISMES_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0530_00_SELECT_SINISMES_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_FONTE" , ""},
                { "PRODUTO_COD_PRODUTO" , ""},
                { "PRODUTO_RAMO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0530_00_SELECT_SINISMES_DB_SELECT_1_Query1", q3);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("RESSARCIMENTO")]
        public static void CB7537B_Tests_Theory(string RESSARCIMENTO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RESSARCIMENTO_FILE_NAME_P = $"{RESSARCIMENTO_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-12-27"},
                { "SISTEMAS_DATULT_PROCESSAMEN" , "2025-01-27"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region CB7537B_V0MOVICOB

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_BANCO" , "123"},
                { "MOVIMCOB_COD_AGENCIA" , "123"},
                { "MOVIMCOB_NUM_AVISO" , "123"},
                { "MOVIMCOB_DATA_QUITACAO" , "2025-01-01"},
                { "MOVIMCOB_NUM_TITULO" , "123"},
                { "MOVIMCOB_NUM_APOLICE" , "123"},
                { "MOVIMCOB_NUM_PARCELA" , "123"},
                { "MOVIMCOB_VAL_TITULO" , "123"},
                { "MOVIMCOB_VAL_CREDITO" , "123"},
            });
                AppSettings.TestSet.DynamicData.Remove("CB7537B_V0MOVICOB");
                AppSettings.TestSet.DynamicData.Add("CB7537B_V0MOVICOB", q1);

                #endregion

                #region R0520_00_SELECT_SINISMES_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_FONTE" , "16"},
                { "PRODUTO_COD_PRODUTO" , "1001"},
                { "PRODUTO_RAMO_EMISSOR" , "31"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0520_00_SELECT_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0520_00_SELECT_SINISMES_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0530_00_SELECT_SINISMES_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_FONTE" , "16"},
                { "PRODUTO_COD_PRODUTO" , "1001"},
                { "PRODUTO_RAMO_EMISSOR" , "31"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0530_00_SELECT_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0530_00_SELECT_SINISMES_DB_SELECT_1_Query1", q3);

                #endregion


                #endregion
                
                var program = new CB7537B();
                program.Execute(RESSARCIMENTO_FILE_NAME_P);

                var envList = AppSettings.TestSet.DynamicData["R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList);

                var envList1 = AppSettings.TestSet.DynamicData["CB7537B_V0MOVICOB"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["R0520_00_SELECT_SINISMES_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList2);              

                Assert.True(program.RETURN_CODE == 0);

             
            }
        }

        [Theory]
        [InlineData("RESSARCIMENTO")]
        public static void CB7537B_Tests99_Theory(string RESSARCIMENTO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RESSARCIMENTO_FILE_NAME_P = $"{RESSARCIMENTO_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-12-27"},
                { "SISTEMAS_DATULT_PROCESSAMEN" , "2025-01-27"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
               // AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region CB7537B_V0MOVICOB

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_BANCO" , "1"},
                { "MOVIMCOB_COD_AGENCIA" , "1"},
                { "MOVIMCOB_NUM_AVISO" , "1"},
                { "MOVIMCOB_DATA_QUITACAO" , "1"},
                { "MOVIMCOB_NUM_TITULO" , "1"},
                { "MOVIMCOB_NUM_APOLICE" , "1"},
                { "MOVIMCOB_NUM_PARCELA" , "1"},
                { "MOVIMCOB_VAL_TITULO" , "1"},
                { "MOVIMCOB_VAL_CREDITO" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("CB7537B_V0MOVICOB");
                AppSettings.TestSet.DynamicData.Add("CB7537B_V0MOVICOB", q1);

                #endregion

                #region R0520_00_SELECT_SINISMES_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_FONTE" , "1"},
                { "PRODUTO_COD_PRODUTO" , "1"},
                { "PRODUTO_RAMO_EMISSOR" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0520_00_SELECT_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0520_00_SELECT_SINISMES_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0530_00_SELECT_SINISMES_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_FONTE" , "1"},
                { "PRODUTO_COD_PRODUTO" , "1"},
                { "PRODUTO_RAMO_EMISSOR" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0530_00_SELECT_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0530_00_SELECT_SINISMES_DB_SELECT_1_Query1", q3);

                #endregion


                #endregion

                var program = new CB7537B();
                program.Execute(RESSARCIMENTO_FILE_NAME_P);               


                Assert.True(program.RETURN_CODE == 99);


            }
        }


    }
}