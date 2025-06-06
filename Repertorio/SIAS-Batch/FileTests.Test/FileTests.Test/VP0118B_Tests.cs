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
using static Code.VP0118B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VP0118B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VP0118B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region VP0118B_CPROPOS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_OCORHIST" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0118B_CPROPOS", q1);

            #endregion

            #region VP0118B_CCOB

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "HOST_IMPSEGCDC" , ""},
                { "HOST_IMPMORNATU" , ""},
                { "HOST_OCORHIST" , ""},
                { "HOST_DTINIVIG" , ""},
                { "HOST_DTTERVIG" , ""},
                { "HOST_VLCUSTCDG" , ""},
                { "HOST_DTINIVIG_1DAY" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0118B_CCOB", q2);

            #endregion

            #region R0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1_Update1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "HOST_IMPSEGCDC_NEW" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "HOST_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1_Update1", q3);

            #endregion

            #region R0800_00_VERIFICA_CDG_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0CDGC_VLCUSTCDG" , ""},
                { "V0CDGC_DTINIVIG" , ""},
                { "V0CDGC_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0800_00_VERIFICA_CDG_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0810_00_UPDATE_CDG_VIG_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_DTINIVIG_1DAY" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "HOST_DTINIVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0810_00_UPDATE_CDG_VIG_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R0820_00_INSERT_CDG_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODCLIEN" , ""},
                { "HOST_DTINIVIG" , ""},
                { "HOST_DTTERVIG" , ""},
                { "HOST_IMPSEGCDC_NEW" , ""},
                { "HOST_VLCUSTCDG" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "HOST_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0820_00_INSERT_CDG_DB_INSERT_1_Insert1", q6);

            #endregion

            #region R0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "HOST_IMPSEGCDC_NEW" , ""},
                { "HOST_VLCUSTCDG" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "HOST_DTINIVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1_Update1", q7);

            #endregion

            #endregion
        }

        [Fact]
        public static void VP0118B_Tests_Fact()
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
                #region PARAMETERS
                #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0SIST_DTMOVABE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region VP0118B_CPROPOS

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_NRCERTIF" , ""},
                    { "V0PROP_OCORHIST" , ""},
                    { "V0PROP_CODCLIEN" , ""},
                    { "V0PROP_APOLICE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VP0118B_CPROPOS");
                AppSettings.TestSet.DynamicData.Add("VP0118B_CPROPOS", q1);

                #endregion

                #region VP0118B_CCOB

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "HOST_IMPSEGCDC" , "1"},
                    { "HOST_IMPMORNATU" , ""},
                    { "HOST_OCORHIST" , ""},
                    { "HOST_DTINIVIG" , ""},
                    { "HOST_DTTERVIG" , ""},
                    { "HOST_VLCUSTCDG" , ""},
                    { "HOST_DTINIVIG_1DAY" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VP0118B_CCOB");
                AppSettings.TestSet.DynamicData.Add("VP0118B_CCOB", q2);

                #endregion

                #region R0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1_Update1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "HOST_IMPSEGCDC_NEW" , ""},
                    { "V0PROP_NRCERTIF" , ""},
                    { "HOST_OCORHIST" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1_Update1", q3);

                #endregion

                #region R0800_00_VERIFICA_CDG_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0CDGC_VLCUSTCDG" , ""},
                    { "V0CDGC_DTINIVIG" , ""},
                    { "V0CDGC_DTTERVIG" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0800_00_VERIFICA_CDG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0800_00_VERIFICA_CDG_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0810_00_UPDATE_CDG_VIG_DB_UPDATE_1_Update1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "HOST_DTINIVIG_1DAY" , ""},
                    { "V0PROP_CODCLIEN" , ""},
                    { "HOST_DTINIVIG" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0810_00_UPDATE_CDG_VIG_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0810_00_UPDATE_CDG_VIG_DB_UPDATE_1_Update1", q5);

                #endregion

                #region R0820_00_INSERT_CDG_DB_INSERT_1_Insert1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_CODCLIEN" , ""},
                    { "HOST_DTINIVIG" , ""},
                    { "HOST_DTTERVIG" , ""},
                    { "HOST_IMPSEGCDC_NEW" , ""},
                    { "HOST_VLCUSTCDG" , ""},
                    { "V0PROP_NRCERTIF" , ""},
                    { "HOST_OCORHIST" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0820_00_INSERT_CDG_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0820_00_INSERT_CDG_DB_INSERT_1_Insert1", q6);

                #endregion

                #region R0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1_Update1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "HOST_IMPSEGCDC_NEW" , ""},
                    { "HOST_VLCUSTCDG" , ""},
                    { "V0PROP_CODCLIEN" , ""},
                    { "HOST_DTINIVIG" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1_Update1", q7);

                #endregion

                #endregion
                #endregion
                var program = new VP0118B();
                program.Execute();

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();

                var update3 = AppSettings.TestSet.DynamicData["R0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(update3[1].TryGetValue("V0PROP_NRCERTIF", out string value1) && value1.Equals("000000000000000"));
                Assert.True(update3[1].TryGetValue("UpdateCheck", out string value2) && value2.Equals("UpdateCheck"));

                // QUERY COMENTADA NO COBOL
                //var update1 = AppSettings.TestSet.DynamicData["R0810_00_UPDATE_CDG_VIG_DB_UPDATE_1_Update1"].DynamicList;
                //Assert.True(update1[1].TryGetValue("SIST_DTMAXDEB", out string value3) && value3.Equals("0000 00 00"));
                //Assert.True(update1[1].TryGetValue("UpdateCheck", out string value4) && value4.Equals("UpdateCheck"));

                // QUERY COMENTADA NO COBOL
                //var update4 = AppSettings.TestSet.DynamicData["R0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1_Update1"].DynamicList;
                //Assert.True(update4[1].TryGetValue("PARM_NSA", out string value5) && value5.Equals("0001"));
                //Assert.True(update4[1].TryGetValue("UpdateCheck", out string value6) && value6.Equals("UpdateCheck"));

                // QUERY COMENTADA NO COBOL
                //var insert1 = AppSettings.TestSet.DynamicData["R0820_00_INSERT_CDG_DB_INSERT_1_Insert1"].DynamicList;
                //Assert.True(insert1[1].TryGetValue("PARM_NSA", out string value7) && value7.Equals("0001"));

                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE.Value == 0);
            }
        }

        [Fact]
        public static void VP0118B_Tests_ReturnCode99_Fact()
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
                #region PARAMETERS
                #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0SIST_DTMOVABE" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region VP0118B_CPROPOS

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_NRCERTIF" , ""},
                    { "V0PROP_OCORHIST" , ""},
                    { "V0PROP_CODCLIEN" , ""},
                    { "V0PROP_APOLICE" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("VP0118B_CPROPOS");
                AppSettings.TestSet.DynamicData.Add("VP0118B_CPROPOS", q1);

                #endregion

                #region VP0118B_CCOB

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "HOST_IMPSEGCDC" , "1"},
                    { "HOST_IMPMORNATU" , ""},
                    { "HOST_OCORHIST" , ""},
                    { "HOST_DTINIVIG" , ""},
                    { "HOST_DTTERVIG" , ""},
                    { "HOST_VLCUSTCDG" , ""},
                    { "HOST_DTINIVIG_1DAY" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("VP0118B_CCOB");
                AppSettings.TestSet.DynamicData.Add("VP0118B_CCOB", q2);

                #endregion

                #region R0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1_Update1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "HOST_IMPSEGCDC_NEW" , ""},
                    { "V0PROP_NRCERTIF" , ""},
                    { "HOST_OCORHIST" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1_Update1", q3);

                #endregion

                #region R0800_00_VERIFICA_CDG_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0CDGC_VLCUSTCDG" , ""},
                    { "V0CDGC_DTINIVIG" , ""},
                    { "V0CDGC_DTTERVIG" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0800_00_VERIFICA_CDG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0800_00_VERIFICA_CDG_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0810_00_UPDATE_CDG_VIG_DB_UPDATE_1_Update1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "HOST_DTINIVIG_1DAY" , ""},
                    { "V0PROP_CODCLIEN" , ""},
                    { "HOST_DTINIVIG" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0810_00_UPDATE_CDG_VIG_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0810_00_UPDATE_CDG_VIG_DB_UPDATE_1_Update1", q5);

                #endregion

                #region R0820_00_INSERT_CDG_DB_INSERT_1_Insert1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_CODCLIEN" , ""},
                    { "HOST_DTINIVIG" , ""},
                    { "HOST_DTTERVIG" , ""},
                    { "HOST_IMPSEGCDC_NEW" , ""},
                    { "HOST_VLCUSTCDG" , ""},
                    { "V0PROP_NRCERTIF" , ""},
                    { "HOST_OCORHIST" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0820_00_INSERT_CDG_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0820_00_INSERT_CDG_DB_INSERT_1_Insert1", q6);

                #endregion

                #region R0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1_Update1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "HOST_IMPSEGCDC_NEW" , ""},
                    { "HOST_VLCUSTCDG" , ""},
                    { "V0PROP_CODCLIEN" , ""},
                    { "HOST_DTINIVIG" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1_Update1", q7);

                #endregion

                #endregion
                #endregion
                var program = new VP0118B();
                program.Execute();

                Assert.True(program.RETURN_CODE.Value == 8);
            }
        }
    }
}