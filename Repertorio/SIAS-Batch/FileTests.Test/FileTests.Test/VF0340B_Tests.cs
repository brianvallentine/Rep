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
using static Code.VF0340B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VF0340B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VF0340B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SIST_CURRDATE" , ""},
                { "SIST_DTMINDEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region VF0340B_DEBITO

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "NRCERTIF" , ""},
                { "NRPARCEL" , ""},
                { "AGECTADEB" , ""},
                { "OPRCTADEB" , ""},
                { "NUMCTADEB" , ""},
                { "DIGCTADEB" , ""},
                { "VLPRMTOT" , ""},
                { "SITUACAO" , ""},
                { "DTVENCTO" , ""},
                { "NSAS" , ""},
                { "NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VF0340B_DEBITO", q1);

            #endregion

            #region M_0000_PRINCIPAL_DB_INSERT_1_Insert1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SIST_CURRDATE" , ""},
                { "PARM_NSA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_INSERT_1_Insert1", q2);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PARM_CODCONV" , ""},
                { "PARM_NSA" , ""},
                { "PARM_VERSAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q3);

            #endregion

            #region M_1000_PROCESSA_DEBITO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DEBITO_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMAXDEB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1", q5);

            #endregion

            #region M_1000_PROCESSA_DEBITO_DB_SELECT_2_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DEBITO_DB_SELECT_2_Query1", q6);

            #endregion

            #region M_1000_PROCESSA_DEBITO_DB_UPDATE_2_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PARM_NSA" , ""},
                { "SQL_NOT_NULL" , ""},
                { "NSL" , ""},
                { "DTVENCTO" , ""},
                { "SIST_DTMAXDEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DEBITO_DB_UPDATE_2_Update1", q7);

            #endregion

            #region M_9000_FINALIZA_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PARM_NSA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_9000_FINALIZA_DB_UPDATE_1_Update1", q8);

            #endregion

            #region M_9000_FINALIZA_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "PARM_CODCONV" , ""},
                { "PARM_NSA" , ""},
                { "SIST_CURRDATE" , ""},
                { "SIST_DTMAXDEB" , ""},
                { "PARM_VERSAO" , ""},
                { "FITSAS_REG" , ""},
                { "FITSAS_VALOR" , ""},
                { "FITSAS_NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_9000_FINALIZA_DB_INSERT_1_Insert1", q9);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VF0340B_t1")]
        public static void VF0340B_Tests_Theory(string MOVIMENTO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVIMENTO_FILE_NAME_P = $"{MOVIMENTO_FILE_NAME_P}_{timestamp}.txt";

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
                #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SIST_CURRDATE" , ""},
                    { "SIST_DTMINDEB" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region VF0340B_DEBITO

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "NRCERTIF" , ""},
                    { "NRPARCEL" , ""},
                    { "AGECTADEB" , ""},
                    { "OPRCTADEB" , ""},
                    { "NUMCTADEB" , ""},
                    { "DIGCTADEB" , ""},
                    { "VLPRMTOT" , ""},
                    { "SITUACAO" , ""},
                    { "DTVENCTO" , ""},
                    { "NSAS" , ""},
                    { "NSL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VF0340B_DEBITO");
                AppSettings.TestSet.DynamicData.Add("VF0340B_DEBITO", q1);

                #endregion

                #region M_0000_PRINCIPAL_DB_INSERT_1_Insert1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "SIST_CURRDATE" , ""},
                    { "PARM_NSA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_INSERT_1_Insert1", q2);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "PARM_CODCONV" , ""},
                    { "PARM_NSA" , ""},
                    { "PARM_VERSAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q3);

                #endregion

                #region M_1000_PROCESSA_DEBITO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_SITUACAO" , "3"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_DEBITO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DEBITO_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "SIST_DTMAXDEB" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1", q5);

                #endregion

                #region M_1000_PROCESSA_DEBITO_DB_SELECT_2_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V0PARC_SITUACAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_DEBITO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DEBITO_DB_SELECT_2_Query1", q6);

                #endregion

                #region M_1000_PROCESSA_DEBITO_DB_UPDATE_2_Update1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "PARM_NSA" , ""},
                    { "SQL_NOT_NULL" , ""},
                    { "NSL" , ""},
                    { "DTVENCTO" , ""},
                    { "SIST_DTMAXDEB" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_DEBITO_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DEBITO_DB_UPDATE_2_Update1", q7);

                #endregion

                #region M_9000_FINALIZA_DB_UPDATE_1_Update1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "PARM_NSA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_9000_FINALIZA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_9000_FINALIZA_DB_UPDATE_1_Update1", q8);

                #endregion

                #region M_9000_FINALIZA_DB_INSERT_1_Insert1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "PARM_CODCONV" , ""},
                    { "PARM_NSA" , ""},
                    { "SIST_CURRDATE" , ""},
                    { "SIST_DTMAXDEB" , ""},
                    { "PARM_VERSAO" , ""},
                    { "FITSAS_REG" , ""},
                    { "FITSAS_VALOR" , ""},
                    { "FITSAS_NSL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_9000_FINALIZA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_9000_FINALIZA_DB_INSERT_1_Insert1", q9);

                #endregion

                #endregion
                #endregion
                var program = new VF0340B();
                program.Execute(MOVIMENTO_FILE_NAME_P);

                Assert.True(File.Exists(program.MOVIMENTO.FilePath));
                Assert.True(new FileInfo(program.MOVIMENTO.FilePath).Length > 0);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();

                var update1 = AppSettings.TestSet.DynamicData["M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(update1[1].TryGetValue("SIST_DTMAXDEB", out string value1) && value1.Equals("0000 00 00"));
                Assert.True(update1[1].TryGetValue("UpdateCheck", out string value2) && value2.Equals("UpdateCheck"));

                var update3 = AppSettings.TestSet.DynamicData["M_9000_FINALIZA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(update3[1].TryGetValue("PARM_NSA", out string value5) && value5.Equals("0001"));
                Assert.True(update3[1].TryGetValue("UpdateCheck", out string value6) && value6.Equals("UpdateCheck"));

                var insert1 = AppSettings.TestSet.DynamicData["M_0000_PRINCIPAL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(insert1[1].TryGetValue("PARM_NSA", out string value7) && value7.Equals("0001"));

                var insert2 = AppSettings.TestSet.DynamicData["M_9000_FINALIZA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(insert2[1].TryGetValue("PARM_NSA", out string value8) && value8.Equals("0001"));

                Assert.True(selects.Count > allSelects.Count / 2);

                Assert.True(program.RETURN_CODE.Value == 0);
            }
        }

        [Theory]
        [InlineData("VF0340B_t2")]
        public static void VF0340B_Tests_ReturnCode99_Theory(string MOVIMENTO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVIMENTO_FILE_NAME_P = $"{MOVIMENTO_FILE_NAME_P}_{timestamp}.txt";

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
                #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SIST_CURRDATE" , ""},
                    { "SIST_DTMINDEB" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region VF0340B_DEBITO

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "NRCERTIF" , ""},
                    { "NRPARCEL" , ""},
                    { "AGECTADEB" , ""},
                    { "OPRCTADEB" , ""},
                    { "NUMCTADEB" , ""},
                    { "DIGCTADEB" , ""},
                    { "VLPRMTOT" , ""},
                    { "SITUACAO" , ""},
                    { "DTVENCTO" , ""},
                    { "NSAS" , ""},
                    { "NSL" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("VF0340B_DEBITO");
                AppSettings.TestSet.DynamicData.Add("VF0340B_DEBITO", q1);

                #endregion

                #region M_0000_PRINCIPAL_DB_INSERT_1_Insert1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "SIST_CURRDATE" , ""},
                    { "PARM_NSA" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_INSERT_1_Insert1", q2);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "PARM_CODCONV" , ""},
                    { "PARM_NSA" , ""},
                    { "PARM_VERSAO" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q3);

                #endregion

                #region M_1000_PROCESSA_DEBITO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_SITUACAO" , "3"}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_DEBITO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DEBITO_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "SIST_DTMAXDEB" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1", q5);

                #endregion

                #region M_1000_PROCESSA_DEBITO_DB_SELECT_2_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V0PARC_SITUACAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_DEBITO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DEBITO_DB_SELECT_2_Query1", q6);

                #endregion

                #region M_1000_PROCESSA_DEBITO_DB_UPDATE_2_Update1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "PARM_NSA" , ""},
                    { "SQL_NOT_NULL" , ""},
                    { "NSL" , ""},
                    { "DTVENCTO" , ""},
                    { "SIST_DTMAXDEB" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_DEBITO_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DEBITO_DB_UPDATE_2_Update1", q7);

                #endregion

                #region M_9000_FINALIZA_DB_UPDATE_1_Update1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "PARM_NSA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_9000_FINALIZA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_9000_FINALIZA_DB_UPDATE_1_Update1", q8);

                #endregion

                #region M_9000_FINALIZA_DB_INSERT_1_Insert1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "PARM_CODCONV" , ""},
                    { "PARM_NSA" , ""},
                    { "SIST_CURRDATE" , ""},
                    { "SIST_DTMAXDEB" , ""},
                    { "PARM_VERSAO" , ""},
                    { "FITSAS_REG" , ""},
                    { "FITSAS_VALOR" , ""},
                    { "FITSAS_NSL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_9000_FINALIZA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_9000_FINALIZA_DB_INSERT_1_Insert1", q9);

                #endregion

                #endregion
                #endregion
                var program = new VF0340B();
                program.Execute(MOVIMENTO_FILE_NAME_P);

                Assert.True(program.RETURN_CODE.Value == 9);
            }
        }
    }
}