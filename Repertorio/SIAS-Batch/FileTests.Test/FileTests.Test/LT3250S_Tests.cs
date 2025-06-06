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
using static Code.LT3250S;
using Dclgens;

namespace FileTests.Test
{
    [Collection("LT3250S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class LT3250S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R1010_00_LER_TAXA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1010_00_LER_TAXA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R1110_00_LER_COEF_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_LER_COEF_DB_SELECT_1_Query1", q1);

            #endregion

            #region R1250_00_LER_PCT_PLURI_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1250_00_LER_PCT_PLURI_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WS_QTD_DIAS_VIGENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1_Query1", q3);

            #endregion

            #endregion
        }

       [Fact]
        public static void LT3250S_Tests_Fact()
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

                #region R1010_00_LER_TAXA_DB_SELECT_1_Query1             
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.108700000"}
                 });
                q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.108700000"}
                 });
                q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.108700000"}
                 });
                q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.108700000"}
                 });
                q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.108700000"}
                 });
                q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.108700000"}
                 });
                q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.108700000"}
                 });
                q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.108700000"}
                 });
                q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.108700000"}
                 });
                q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.108700000"}
                 });
                q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.108700000"}
                 });
                q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.108700000"}
                 });
                q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.108700000"}
                 });
                q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.108700000"}
                 });
                q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.108700000"}
                 });
                q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.108700000"}
                 });
                q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.108700000"}
                 });
                q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.108700000"}
                 });
                q0.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.108700000"}
                 });               
                AppSettings.TestSet.DynamicData.Remove("R1010_00_LER_TAXA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1010_00_LER_TAXA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R1110_00_LER_COEF_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.353226956"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.353226956"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.353226956"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.353226956"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.353226956"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.353226956"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.353226956"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.353226956"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.353226956"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.353226956"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.353226956"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.353226956"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.353226956"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.353226956"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.353226956"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.353226956"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.353226956"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.353226956"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.353226956"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.353226956"}
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "LOTTAX01_TAXA_IS_FENAL" , "0.353226956"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_LER_COEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_LER_COEF_DB_SELECT_1_Query1", q1);

                #endregion

                #region R1250_00_LER_PCT_PLURI_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
               { "LOTTAX01_TAXA_IS_FENAL" , "0.000258750"}
               });
                q2.AddDynamic(new Dictionary<string, string>{
               { "LOTTAX01_TAXA_IS_FENAL" , "0.000258750"}
               });
                q2.AddDynamic(new Dictionary<string, string>{
               { "LOTTAX01_TAXA_IS_FENAL" , "0.000258750"}
               });
                q2.AddDynamic(new Dictionary<string, string>{
               { "LOTTAX01_TAXA_IS_FENAL" , "0.000258750"}
               });
                q2.AddDynamic(new Dictionary<string, string>{
               { "LOTTAX01_TAXA_IS_FENAL" , "0.000258750"}
               });
                AppSettings.TestSet.DynamicData.Remove("R1250_00_LER_PCT_PLURI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1250_00_LER_PCT_PLURI_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "WS_QTD_DIAS_VIGENCIA" , "214"}
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "WS_QTD_DIAS_VIGENCIA" , "214"}
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "WS_QTD_DIAS_VIGENCIA" , "214"}
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "WS_QTD_DIAS_VIGENCIA" , "214"}
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "WS_QTD_DIAS_VIGENCIA" , "214"}
                });

                AppSettings.TestSet.DynamicData.Remove("R1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1_Query1", q3);


                #endregion

                #endregion
                var param = new LBLT3250_LT3250_AREA_PARAMETROS();
                param.LT3250_DTINIVIG.Value = "2021-06-01";
                param.LT3250_DTTERVIG.Value = "2025-01-02";
                param.LT3250_NUM_CLASSE.Value = 2;
                param.LT3250_COD_REGIAO.Value = 2;


                var program = new LT3250S();       
                program.Execute(param);               
                
                var envList = AppSettings.TestSet.DynamicData["R1010_00_LER_TAXA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList);
               
                var envList2 = AppSettings.TestSet.DynamicData["R1110_00_LER_COEF_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList2);

                var envList3 = AppSettings.TestSet.DynamicData["R1250_00_LER_PCT_PLURI_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList3);

                var envList4 = AppSettings.TestSet.DynamicData["R1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList4);

                Assert.True(program.RETURN_CODE == 0);
            }
        }


        [Fact]
        public static void LT3250S_Tests99_Fact()
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

                #region R1010_00_LER_TAXA_DB_SELECT_1_Query1    
                
                var q0 = new DynamicData();                
              
                AppSettings.TestSet.DynamicData.Remove("R1010_00_LER_TAXA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1010_00_LER_TAXA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R1110_00_LER_COEF_DB_SELECT_1_Query1

                var q1 = new DynamicData();

                AppSettings.TestSet.DynamicData.Remove("R1110_00_LER_COEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_LER_COEF_DB_SELECT_1_Query1", q1);

                #endregion

                #region R1250_00_LER_PCT_PLURI_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
               { "LOTTAX01_TAXA_IS_FENAL" , "0.000258750"}
               });
                q2.AddDynamic(new Dictionary<string, string>{
               { "LOTTAX01_TAXA_IS_FENAL" , "0.000258750"}
               });
                q2.AddDynamic(new Dictionary<string, string>{
               { "LOTTAX01_TAXA_IS_FENAL" , "0.000258750"}
               });
                q2.AddDynamic(new Dictionary<string, string>{
               { "LOTTAX01_TAXA_IS_FENAL" , "0.000258750"}
               });
                q2.AddDynamic(new Dictionary<string, string>{
               { "LOTTAX01_TAXA_IS_FENAL" , "0.000258750"}
               });
                AppSettings.TestSet.DynamicData.Remove("R1250_00_LER_PCT_PLURI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1250_00_LER_PCT_PLURI_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "WS_QTD_DIAS_VIGENCIA" , "214"}
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "WS_QTD_DIAS_VIGENCIA" , "214"}
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "WS_QTD_DIAS_VIGENCIA" , "214"}
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "WS_QTD_DIAS_VIGENCIA" , "214"}
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "WS_QTD_DIAS_VIGENCIA" , "214"}
                });

                AppSettings.TestSet.DynamicData.Remove("R1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1_Query1", q3);


                #endregion

                #endregion
                var param = new LBLT3250_LT3250_AREA_PARAMETROS();
                param.LT3250_DTINIVIG.Value = "2019-06-01";
                param.LT3250_DTTERVIG.Value = "2025-01-02";
                param.LT3250_NUM_CLASSE.Value = 2;
                param.LT3250_COD_REGIAO.Value = 1;


                var program = new LT3250S();
                program.Execute(param);

                var envList = AppSettings.TestSet.DynamicData["R1010_00_LER_TAXA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList);

                var envList2 = AppSettings.TestSet.DynamicData["R1110_00_LER_COEF_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList2);


                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}