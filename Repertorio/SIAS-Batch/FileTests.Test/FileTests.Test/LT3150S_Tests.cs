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
using static Code.LT3150S;
using Dclgens;
using Copies;


namespace FileTests.Test
{
    [Collection("LT3150S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class LT3150S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0300_00_LER_TAXA_DB_SELECT_1_Query1
            AppSettings.TestSet.DynamicData.Remove("R0300_00_LER_TAXA_DB_SELECT_1_Query1");

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_LER_TAXA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0400_00_LER_COEF_DB_SELECT_1_Query1
            AppSettings.TestSet.DynamicData.Remove("R0400_00_LER_COEF_DB_SELECT_1_Query1");

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0400_00_LER_COEF_DB_SELECT_1_Query1", q1);

            #endregion

            #endregion
        }
        public static void Load_Parameters_To_EM0030B()
        {
            #region PARAMETERS
            #region R0300_00_LER_TAXA_DB_SELECT_1_Query1
            AppSettings.TestSet.DynamicData.Remove("R0300_00_LER_TAXA_DB_SELECT_1_Query1");

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Remove("R0300_00_LER_TAXA_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R0300_00_LER_TAXA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0400_00_LER_COEF_DB_SELECT_1_Query1
            AppSettings.TestSet.DynamicData.Remove("R0400_00_LER_COEF_DB_SELECT_1_Query1");

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "2"}
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "1"}
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "1"}
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "1"}
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "1"}
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "1"}
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "1"}
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "1"}
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "1"}
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "1"}
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "1"}
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "1"}
            });
            AppSettings.TestSet.DynamicData.Remove("R0400_00_LER_COEF_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R0400_00_LER_COEF_DB_SELECT_1_Query1", q1);

            #endregion

            #endregion
        }

        [Fact]
        public static void LT3150S_Tests_Fact()
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
                #region R0300_00_LER_TAXA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R0300_00_LER_TAXA_DB_SELECT_1_Query1");

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "LOTTAX01_TAXA_IS_FENAL" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("R0300_00_LER_TAXA_DB_SELECT_1_Query1", q0);

                var param = new LBLT3150_LT3150_AREA_PARAMETROS();
                param.LT3150_COD_REGIAO.Value = 1;
                param.LT3150_COD_RETORNO.Value = 1;
                param.LT3150_DTINIVIG.Value = "A";
                param.LT3150_DTTERVIG.Value = "A";
                param.LT3150_NUM_CLASSE.Value = 1;
                #endregion
                #endregion

                var program = new LT3150S();
                program.Execute(param);

                var envList1 = AppSettings.TestSet.DynamicData["R0300_00_LER_TAXA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["R0300_00_LER_TAXA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList2);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Fact]
        public static void LT3150S_Tests_Fact_Error_DTINIVIG_INVALIDO()
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
                #region R0300_00_LER_TAXA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R0300_00_LER_TAXA_DB_SELECT_1_Query1");

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "LOTTAX01_TAXA_IS_FENAL" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("R0300_00_LER_TAXA_DB_SELECT_1_Query1", q0);

                var param = new LBLT3150_LT3150_AREA_PARAMETROS();
                #endregion
                #endregion

                var program = new LT3150S();
                program.Execute(param);

                Assert.True(program.WS_PARAGRAFO == 110 && program.RETURN_CODE == 0 && param.LT3150_MENSAGEM == "DTINIVIG INVALIDO");
            }
        }

        [Fact]
        public static void LT3150S_Tests_Fact_Error_99()
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
                #region R0300_00_LER_TAXA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R0300_00_LER_TAXA_DB_SELECT_1_Query1");

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "LOTTAX01_TAXA_IS_FENAL" , "1"},
                }, new SQLCA(999));
                AppSettings.TestSet.DynamicData.Add("R0300_00_LER_TAXA_DB_SELECT_1_Query1", q0);

                var param = new LBLT3150_LT3150_AREA_PARAMETROS();
                param.LT3150_COD_REGIAO.Value = 1;
                param.LT3150_COD_RETORNO.Value = 1;
                param.LT3150_DTINIVIG.Value = "A";
                param.LT3150_DTTERVIG.Value = "A";
                param.LT3150_NUM_CLASSE.Value = 1;
                #endregion
                #endregion

                var program = new LT3150S();
                program.Execute(param);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}