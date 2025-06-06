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
using static Code.VA0415B;

namespace FileTests.Test
{
    [Collection("VA0415B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0415B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R001_SELECT_SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R001_SELECT_SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region VA0415B_CPROPOVA

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_CODOPER" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_OCORHIST" , ""},
                { "V0PROP_NUM_MATRICULA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0415B_CPROPOVA", q1);

            #endregion

            #region R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0COBV_VLPREMIO" , ""},
                { "V0COBV_IMPSEGAUXF" , ""},
                { "V0COBV_VLCUSTAUXF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1", q2);

            #endregion

            #region R050_SELECT_SEGURAVG_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0SEGV_SITUACAO" , ""},
                { "V0SEGV_OCORHIST" , ""},
                { "V0SEGV_NUMITEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R050_SELECT_SEGURAVG_DB_SELECT_1_Query1", q3);

            #endregion

            #region R060_SELECT_HISTSEGVG_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0HSEG_CODOPER" , ""},
                { "V0HSEG_DTREFER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R060_SELECT_HISTSEGVG_DB_SELECT_1_Query1", q4);

            #endregion

            #region R070_TRATA_TRANS_CREDITO_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0HSEG_DTREFER" , ""},
                { "V0COBV_IMPSEGAUXF" , ""},
                { "V0COBV_VLCUSTAUXF" , ""},
                { "V0PROP_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R070_TRATA_TRANS_CREDITO_DB_INSERT_1_Insert1", q5);

            #endregion

            #region R070_TRATA_TRANS_CREDITO_DB_INSERT_2_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0HSEG_DTREFER" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NUM_MATRICULA" , ""},
                { "V0COBV_VLCUSTAUXF" , ""},
                { "V0PROP_CODOPER" , ""},
                { "V1SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R070_TRATA_TRANS_CREDITO_DB_INSERT_2_Insert1", q6);

            #endregion

            #region R080_TRATA_TRANS_DEBITO_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0HSEG_DTREFER" , ""},
                { "V0PROP_CODCLIEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R080_TRATA_TRANS_DEBITO_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R080_TRATA_TRANS_DEBITO_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "V0HSEG_DTREFER" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_NUM_MATRICULA" , ""},
                { "V0COBV_VLCUSTAUXF" , ""},
                { "V0PROP_CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R080_TRATA_TRANS_DEBITO_DB_INSERT_1_Insert1", q8);

            #endregion

            #region R080_TRATA_TRANS_DEBITO_DB_UPDATE_2_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R080_TRATA_TRANS_DEBITO_DB_UPDATE_2_Update1", q9);

            #endregion

            #endregion
        }

        [Fact]
        public static void VA0415B_Tests_Fact1_ReturnCode00()
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
                #region VA0415B_CPROPOVA

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , "33"},
                { "V0PROP_APOLICE" , "93010000890"},
                { "V0PROP_CODSUBES" , "1"},
                { "V0PROP_NRCERTIF" , "10000199079"},
                { "V0PROP_CODOPER" , "30"},
                { "V0PROP_SITUACAO" , "4"},
                { "V0PROP_OCORHIST" , "7"},
                { "V0PROP_NUM_MATRICULA" , "8858231"},
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , "33"},
                { "V0PROP_APOLICE" , "93010000890"},
                { "V0PROP_CODSUBES" , "1"},
                { "V0PROP_NRCERTIF" , "10000199079"},
                { "V0PROP_CODOPER" , "200"},
                { "V0PROP_SITUACAO" , "4"},
                { "V0PROP_OCORHIST" , "7"},
                { "V0PROP_NUM_MATRICULA" , "8858231"},
                });
                AppSettings.TestSet.DynamicData.Remove("VA0415B_CPROPOVA");
                AppSettings.TestSet.DynamicData.Add("VA0415B_CPROPOVA", q1);

                #endregion
                #region R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0COBV_VLPREMIO" , "3"},
                { "V0COBV_IMPSEGAUXF" , "5"},
                { "V0COBV_VLCUSTAUXF" , "10"},
                });
                AppSettings.TestSet.DynamicData.Remove("R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1", q2);

                #endregion
                #region R050_SELECT_SEGURAVG_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0SEGV_SITUACAO" , "2"},
                { "V0SEGV_OCORHIST" , "2"},
                { "V0SEGV_NUMITEM" , "4"},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0SEGV_SITUACAO" , "2"},
                { "V0SEGV_OCORHIST" , "2"},
                { "V0SEGV_NUMITEM" , "4"},
                });
                AppSettings.TestSet.DynamicData.Remove("R050_SELECT_SEGURAVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R050_SELECT_SEGURAVG_DB_SELECT_1_Query1", q3);

                #endregion
                #region R060_SELECT_HISTSEGVG_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0HSEG_CODOPER" , "101"},
                { "V0HSEG_DTREFER" , "2020-01-01"},
                });
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0HSEG_CODOPER" , "101"},
                { "V0HSEG_DTREFER" , "2020-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R060_SELECT_HISTSEGVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R060_SELECT_HISTSEGVG_DB_SELECT_1_Query1", q4);

                #endregion
                #endregion
                var program = new VA0415B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 0);

                //R080_TRATA_TRANS_DEBITO_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["R080_TRATA_TRANS_DEBITO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("V0PROP_CODCLIEN", out var valor0) && valor0.Contains("33"));

                //R080_TRATA_TRANS_DEBITO_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R080_TRATA_TRANS_DEBITO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("V0PROP_NRCERTIF", out var valor1) && valor1.Contains("000010000199079"));
                Assert.True(envList1.Count > 1);

            }
        }
        [Fact]
        public static void VA0415B_Tests_Fact2_ReturnCode00()
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
                #region VA0415B_CPROPOVA

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , "33"},
                { "V0PROP_APOLICE" , "93010000890"},
                { "V0PROP_CODSUBES" , "1"},
                { "V0PROP_NRCERTIF" , "10000199079"},
                { "V0PROP_CODOPER" , "200"},
                { "V0PROP_SITUACAO" , "4"},
                { "V0PROP_OCORHIST" , "7"},
                { "V0PROP_NUM_MATRICULA" , "8858231"},
                });
                AppSettings.TestSet.DynamicData.Remove("VA0415B_CPROPOVA");
                AppSettings.TestSet.DynamicData.Add("VA0415B_CPROPOVA", q1);

                #endregion
                #region R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0COBV_VLPREMIO" , "3"},
                { "V0COBV_IMPSEGAUXF" , "5"},
                { "V0COBV_VLCUSTAUXF" , "10"},
                });
                AppSettings.TestSet.DynamicData.Remove("R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1", q2);

                #endregion
                #region R050_SELECT_SEGURAVG_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0SEGV_SITUACAO" , "2"},
                { "V0SEGV_OCORHIST" , "2"},
                { "V0SEGV_NUMITEM" , "4"},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0SEGV_SITUACAO" , "2"},
                { "V0SEGV_OCORHIST" , "2"},
                { "V0SEGV_NUMITEM" , "4"},
                });
                AppSettings.TestSet.DynamicData.Remove("R050_SELECT_SEGURAVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R050_SELECT_SEGURAVG_DB_SELECT_1_Query1", q3);

                #endregion
                #region R060_SELECT_HISTSEGVG_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0HSEG_CODOPER" , "101"},
                { "V0HSEG_DTREFER" , "2020-01-01"},
                });
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0HSEG_CODOPER" , "101"},
                { "V0HSEG_DTREFER" , "2020-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R060_SELECT_HISTSEGVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R060_SELECT_HISTSEGVG_DB_SELECT_1_Query1", q4);

                #endregion
                #endregion
                var program = new VA0415B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 0);

                //R070_TRATA_TRANS_CREDITO_DB_INSERT_1_Insert1
                var envList0 = AppSettings.TestSet.DynamicData["R070_TRATA_TRANS_CREDITO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("V0PROP_NRCERTIF", out var valor0) && valor0.Contains("000010000199079"));
                Assert.True(envList0.Count > 1);

                //R070_TRATA_TRANS_CREDITO_DB_INSERT_2_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R070_TRATA_TRANS_CREDITO_DB_INSERT_2_Insert1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("V0PROP_CODOPER", out var valor1) && valor1.Contains("0200"));
                Assert.True(envList1.Count > 1);
            }
        }
        [Fact]
        public static void VA0415B_Tests_Fact_Error_ReturnCode99()
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
                #region VA0415B_CPROPOVA

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , "33"},
                { "V0PROP_APOLICE" , "93010000890"},
                { "V0PROP_CODSUBES" , "1"},
                { "V0PROP_NRCERTIF" , "10000199079"},
                { "V0PROP_CODOPER" , "200"},
                { "V0PROP_SITUACAO" , "4"},
                { "V0PROP_OCORHIST" , "7"},
                { "V0PROP_NUM_MATRICULA" , "8858231"},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("VA0415B_CPROPOVA");
                AppSettings.TestSet.DynamicData.Add("VA0415B_CPROPOVA", q1);

                #endregion
                #endregion
                var program = new VA0415B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 9);
            }
        }
    }
}