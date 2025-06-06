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
using static Code.LT3142S;

namespace FileTests.Test
{
    [Collection("LT3142S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class LT3142S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0300_00_LER_TAXA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_LER_TAXA_DB_SELECT_1_Query1", q0);

            #endregion

            #endregion
        }

        public static void Load_Parameters_to_LT3117S()
        {
            #region PARAMETERS
            #region R0300_00_LER_TAXA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "1.000378350"}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "1.000785466"}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "1.000785466"}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "1.000785466"}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "1.000785466"}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "1.000785466"}
            });
            AppSettings.TestSet.DynamicData.Remove("R0300_00_LER_TAXA_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R0300_00_LER_TAXA_DB_SELECT_1_Query1", q0);

            #endregion

            #endregion
        }

        [Fact]
        public static void LT3142S_Tests_Fact_Erro99()
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

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
                }, new SQLCA(999));
                
                AppSettings.TestSet.DynamicData.Remove("R0300_00_LER_TAXA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0300_00_LER_TAXA_DB_SELECT_1_Query1", q0);

                #endregion

                #endregion
                var program = new LT3142S();
                var parm = new LBLT3142_LT3142_AREA_PARAMETROS();

                parm.LT3142_DTINIVIG.Value = "2025-03-18";
                parm.LT3142_NUM_CLASSE.Value = 5;
                parm.LT3142_QTD_PARCELAS.Value = 10;

                program.Execute(parm);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Fact]
        public static void LT3142S_Tests_Fact()
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

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "10"}
                });
                
                AppSettings.TestSet.DynamicData.Remove("R0300_00_LER_TAXA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0300_00_LER_TAXA_DB_SELECT_1_Query1", q0);

                #endregion

                #endregion
                var program = new LT3142S();
                var parm = new LBLT3142_LT3142_AREA_PARAMETROS();

                parm.LT3142_DTINIVIG.Value = "2025-03-18";
                parm.LT3142_NUM_CLASSE.Value = 5;
                parm.LT3142_QTD_PARCELAS.Value = 10;

                program.Execute(parm);

                var envList = AppSettings.TestSet.DynamicData["R0300_00_LER_TAXA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}