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
using static Code.SI0851B;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0851B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0851B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_005_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SISTEMA_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_005_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_007_SELECT_V0RELAT_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_007_SELECT_V0RELAT_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI0851B_RELATORIO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0REL_PERI_INICIAL" , ""},
                { "V0REL_PERI_FINAL" , ""},
                { "V0REL_NUM_APOLICE" , ""},
                { "V0REL_DATA_SOLICITACAO" , ""},
                { "V0REL_CODUSU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0851B_RELATORIO", q2);

            #endregion

            #region SI0851B_LOTERICO

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0MEST_NUM_APOLICE" , ""},
                { "V0MEST_NUM_APOL_SINISTRO" , ""},
                { "V0MEST_SITUACAO" , ""},
                { "V0MEST_DATORR" , ""},
                { "V0MEST_DATCMD" , ""},
                { "V0SLOT_COD_LOT_FENAL" , ""},
                { "V0SLOT_COD_LOT_CEF" , ""},
                { "V0CLI_NOME_RAZAO" , ""},
                { "V0END_SIGLA_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0851B_LOTERICO", q3);

            #endregion

            #region M_030_PROCESSA_LOTERICO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_030_PROCESSA_LOTERICO_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_2_Query1", q5);

            #endregion

            #region M_100_SELECT_CANCELAMENTO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_DTMOVTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_100_SELECT_CANCELAMENTO_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_030_PROCESSA_LOTERICO_DB_SELECT_3_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_3_Query1", q7);

            #endregion

            #region M_030_PROCESSA_LOTERICO_DB_SELECT_4_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_4_Query1", q8);

            #endregion

            #region M_200_ATUALIZA_RELATORIO_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_200_ATUALIZA_RELATORIO_DB_UPDATE_1_Update1", q9);

            #endregion

            #region M_030_PROCESSA_LOTERICO_DB_SELECT_5_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_5_Query1", q10);

            #endregion

            #region M_030_PROCESSA_LOTERICO_DB_SELECT_6_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_6_Query1", q11);

            #endregion

            #region M_030_PROCESSA_LOTERICO_DB_SELECT_7_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_7_Query1", q12);

            #endregion

            #region M_030_PROCESSA_LOTERICO_DB_SELECT_8_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_8_Query1", q13);

            #endregion

            #region M_030_PROCESSA_LOTERICO_DB_SELECT_9_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_9_Query1", q14);

            #endregion

            #region M_030_PROCESSA_LOTERICO_DB_SELECT_10_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_10_Query1", q15);

            #endregion

            #region M_030_PROCESSA_LOTERICO_DB_SELECT_11_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_11_Query1", q16);

            #endregion

            #region M_030_PROCESSA_LOTERICO_DB_SELECT_12_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_12_Query1", q17);

            #endregion

            #region M_030_PROCESSA_LOTERICO_DB_SELECT_13_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_13_Query1", q18);

            #endregion

            #region M_030_PROCESSA_LOTERICO_DB_SELECT_14_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_14_Query1", q19);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0851B_OUTPUT_202504040000")]
        public static void SI0851B_Tests_Theory(string ARQMOV_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();

                Load_Parameters();
                SI1000S_Tests.Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region M_005_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0SISTEMA_DTMOVABE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_005_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_005_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_007_SELECT_V0RELAT_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "HOST_COUNT" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_007_SELECT_V0RELAT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_007_SELECT_V0RELAT_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0851B_RELATORIO

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V0REL_PERI_INICIAL" , ""},
                    { "V0REL_PERI_FINAL" , ""},
                    { "V0REL_NUM_APOLICE" , ""},
                    { "V0REL_DATA_SOLICITACAO" , ""},
                    { "V0REL_CODUSU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0851B_RELATORIO");
                AppSettings.TestSet.DynamicData.Add("SI0851B_RELATORIO", q2);

                #endregion

                #region SI0851B_LOTERICO

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0MEST_NUM_APOLICE" , "1"},
                    { "V0MEST_NUM_APOL_SINISTRO" , "1"},
                    { "V0MEST_SITUACAO" , "2"},
                    { "V0MEST_DATORR" , ""},
                    { "V0MEST_DATCMD" , ""},
                    { "V0SLOT_COD_LOT_FENAL" , ""},
                    { "V0SLOT_COD_LOT_CEF" , ""},
                    { "V0CLI_NOME_RAZAO" , ""},
                    { "V0END_SIGLA_UF" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0851B_LOTERICO");
                AppSettings.TestSet.DynamicData.Add("SI0851B_LOTERICO", q3);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_2_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_2_Query1", q5);

                #endregion

                #region M_100_SELECT_CANCELAMENTO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_DTMOVTO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_100_SELECT_CANCELAMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_100_SELECT_CANCELAMENTO_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_3_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_3_Query1", q7);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_4_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_4_Query1", q8);

                #endregion

                #region M_200_ATUALIZA_RELATORIO_DB_UPDATE_1_Update1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("M_200_ATUALIZA_RELATORIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_200_ATUALIZA_RELATORIO_DB_UPDATE_1_Update1", q9);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_5_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_5_Query1", q10);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_6_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_6_Query1", q11);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_7_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_7_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_7_Query1", q12);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_8_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_8_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_8_Query1", q13);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_9_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_9_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_9_Query1", q14);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_10_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_10_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_10_Query1", q15);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_11_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_11_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_11_Query1", q16);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_12_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_12_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_12_Query1", q17);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_13_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_13_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_13_Query1", q18);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_14_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_14_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_14_Query1", q19);

                #endregion

                #region R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1

                var si1000s_1 = new DynamicData();
                si1000s_1.AddDynamic(new Dictionary<string, string>{
                    { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
                });
                si1000s_1.AddDynamic(new Dictionary<string, string>{
                    { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
                });
                si1000s_1.AddDynamic(new Dictionary<string, string>{
                    { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
                });
                si1000s_1.AddDynamic(new Dictionary<string, string>{
                    { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
                });
                si1000s_1.AddDynamic(new Dictionary<string, string>{
                    { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
                });
                si1000s_1.AddDynamic(new Dictionary<string, string>{
                    { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
                });
                AppSettings.TestSet.DynamicData.Remove("R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1", si1000s_1);

                #endregion

                #region R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1

                var si1000s_2 = new DynamicData();
                si1000s_2.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
                });
                si1000s_2.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
                });
                si1000s_2.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
                });
                si1000s_2.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
                });
                si1000s_2.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
                });
                si1000s_2.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1", si1000s_2);

                #endregion

                #region R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1

                var si1000s_3 = new DynamicData();
                si1000s_3.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "500000"}
                });
                si1000s_3.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "500000"}
                });
                si1000s_3.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "500000"}
                });
                si1000s_3.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "500000"}
                });
                si1000s_3.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "500000"}
                });
                si1000s_3.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "500000"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1", si1000s_3);

                #endregion

                #endregion
                #endregion
                var program = new SI0851B();
                program.Execute(ARQMOV_FILE_NAME_P);

                Assert.True(File.Exists(program.ARQMOV.FilePath));
                Assert.True(new FileInfo(program.ARQMOV.FilePath).Length > 0);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                Assert.True(selects.Count > (allSelects.Count / 2));

                var updates = AppSettings.TestSet.DynamicData.Where(
                    x => x.Key.Contains("UPDATE") &&
                    x.Value.DynamicList.Count > 1 &&
                    x.Value.DynamicList.Where(
                        y => y.ContainsKey("UpdateCheck")).ToList().Count > 0).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();

                Assert.True(updates.Count > (allUpdates.Count / 2));

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0851B_OUTPUT_202504040001")]
        public static void SI0851B_Tests_Theory_ReturnCode99(string ARQMOV_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();

                Load_Parameters();
                SI1000S_Tests.Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region M_005_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0SISTEMA_DTMOVABE" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_005_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_005_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_007_SELECT_V0RELAT_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "HOST_COUNT" , "1"}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_007_SELECT_V0RELAT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_007_SELECT_V0RELAT_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0851B_RELATORIO

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V0REL_PERI_INICIAL" , ""},
                    { "V0REL_PERI_FINAL" , ""},
                    { "V0REL_NUM_APOLICE" , ""},
                    { "V0REL_DATA_SOLICITACAO" , ""},
                    { "V0REL_CODUSU" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("SI0851B_RELATORIO");
                AppSettings.TestSet.DynamicData.Add("SI0851B_RELATORIO", q2);

                #endregion

                #region SI0851B_LOTERICO

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0MEST_NUM_APOLICE" , "1"},
                    { "V0MEST_NUM_APOL_SINISTRO" , "1"},
                    { "V0MEST_SITUACAO" , "2"},
                    { "V0MEST_DATORR" , ""},
                    { "V0MEST_DATCMD" , ""},
                    { "V0SLOT_COD_LOT_FENAL" , ""},
                    { "V0SLOT_COD_LOT_CEF" , ""},
                    { "V0CLI_NOME_RAZAO" , ""},
                    { "V0END_SIGLA_UF" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0851B_LOTERICO");
                AppSettings.TestSet.DynamicData.Add("SI0851B_LOTERICO", q3);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_2_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_2_Query1", q5);

                #endregion

                #region M_100_SELECT_CANCELAMENTO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_DTMOVTO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_100_SELECT_CANCELAMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_100_SELECT_CANCELAMENTO_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_3_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_3_Query1", q7);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_4_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_4_Query1", q8);

                #endregion

                #region M_200_ATUALIZA_RELATORIO_DB_UPDATE_1_Update1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("M_200_ATUALIZA_RELATORIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_200_ATUALIZA_RELATORIO_DB_UPDATE_1_Update1", q9);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_5_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_5_Query1", q10);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_6_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_6_Query1", q11);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_7_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_7_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_7_Query1", q12);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_8_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_8_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_8_Query1", q13);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_9_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_9_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_9_Query1", q14);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_10_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_10_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_10_Query1", q15);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_11_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_11_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_11_Query1", q16);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_12_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_12_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_12_Query1", q17);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_13_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_13_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_13_Query1", q18);

                #endregion

                #region M_030_PROCESSA_LOTERICO_DB_SELECT_14_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "V0HIST_VAL_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_030_PROCESSA_LOTERICO_DB_SELECT_14_Query1");
                AppSettings.TestSet.DynamicData.Add("M_030_PROCESSA_LOTERICO_DB_SELECT_14_Query1", q19);

                #endregion

                #region R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1

                var si1000s_1 = new DynamicData();
                si1000s_1.AddDynamic(new Dictionary<string, string>{
                    { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
                });
                si1000s_1.AddDynamic(new Dictionary<string, string>{
                    { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
                });
                si1000s_1.AddDynamic(new Dictionary<string, string>{
                    { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
                });
                si1000s_1.AddDynamic(new Dictionary<string, string>{
                    { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
                });
                si1000s_1.AddDynamic(new Dictionary<string, string>{
                    { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
                });
                si1000s_1.AddDynamic(new Dictionary<string, string>{
                    { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
                });
                AppSettings.TestSet.DynamicData.Remove("R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1", si1000s_1);

                #endregion

                #region R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1

                var si1000s_2 = new DynamicData();
                si1000s_2.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
                });
                si1000s_2.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
                });
                si1000s_2.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
                });
                si1000s_2.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
                });
                si1000s_2.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
                });
                si1000s_2.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1", si1000s_2);

                #endregion

                #region R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1

                var si1000s_3 = new DynamicData();
                si1000s_3.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "500000"}
                });
                si1000s_3.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "500000"}
                });
                si1000s_3.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "500000"}
                });
                si1000s_3.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "500000"}
                });
                si1000s_3.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "500000"}
                });
                si1000s_3.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "500000"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1", si1000s_3);

                #endregion

                #endregion
                #endregion
                var program = new SI0851B();
                program.Execute(ARQMOV_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}