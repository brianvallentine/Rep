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
using static Code.SI0862B;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0862B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0862B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region Execute_DB_UPDATE_1_Update1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_UPDATE_1_Update1", q0);

            #endregion

            #region R010_SELECT_SISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI0862B_RELATORIOS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , ""},
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "HOST_DATA_INICIAL" , ""},
                { "HOST_DATA_FINAL" , ""},
                { "HOST_RAMO_INICIAL" , ""},
                { "HOST_CODSUBES_INICIAL" , ""},
                { "HOST_APOLICE" , ""},
                { "HOST_PRODUTO_INICIAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0862B_RELATORIOS", q2);

            #endregion

            #region R021_FETCH_RELATORIO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_NOME_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R021_FETCH_RELATORIO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R040_GRAVA_COLUNA_A_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R040_GRAVA_COLUNA_A_DB_SELECT_1_Query1", q4);

            #endregion

            #region R050_GRAVA_COLUNA_B_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R050_GRAVA_COLUNA_B_DB_SELECT_1_Query1", q5);

            #endregion

            #region R060_GRAVA_COLUNA_C_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "HOST_QTDE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R060_GRAVA_COLUNA_C_DB_SELECT_1_Query1", q6);

            #endregion

            #region R070_GRAVA_COLUNA_D_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R070_GRAVA_COLUNA_D_DB_SELECT_1_Query1", q7);

            #endregion

            #region R080_GRAVA_COLUNA_E_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "HOST_QTDE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R080_GRAVA_COLUNA_E_DB_SELECT_1_Query1", q8);

            #endregion

            #region R090_GRAVA_COLUNA_F_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R090_GRAVA_COLUNA_F_DB_SELECT_1_Query1", q9);

            #endregion

            #region R100_GRAVA_COLUNA_G_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "HOST_QTDE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R100_GRAVA_COLUNA_G_DB_SELECT_1_Query1", q10);

            #endregion

            #region R110_GRAVA_COLUNA_H_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R110_GRAVA_COLUNA_H_DB_SELECT_1_Query1", q11);

            #endregion

            #region R120_GRAVA_COLUNA_I_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "HOST_QTDE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R120_GRAVA_COLUNA_I_DB_SELECT_1_Query1", q12);

            #endregion

            #region R130_GRAVA_COLUNA_J_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R130_GRAVA_COLUNA_J_DB_SELECT_1_Query1", q13);

            #endregion

            #region R140_GRAVA_COLUNA_K_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R140_GRAVA_COLUNA_K_DB_SELECT_1_Query1", q14);

            #endregion

            #region R150_GRAVA_COLUNA_L_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R150_GRAVA_COLUNA_L_DB_SELECT_1_Query1", q15);

            #endregion

            #region R160_GRAVA_COLUNA_M_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R160_GRAVA_COLUNA_M_DB_SELECT_1_Query1", q16);

            #endregion

            #region R170_GRAVA_COLUNA_N_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R170_GRAVA_COLUNA_N_DB_SELECT_1_Query1", q17);

            #endregion

            #region R180_GRAVA_COLUNA_O_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R180_GRAVA_COLUNA_O_DB_SELECT_1_Query1", q18);

            #endregion

            #region R190_GRAVA_COLUNA_P_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R190_GRAVA_COLUNA_P_DB_SELECT_1_Query1", q19);

            #endregion

            #region R200_GRAVA_COLUNA_Q_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R200_GRAVA_COLUNA_Q_DB_SELECT_1_Query1", q20);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0862B_OUTPUT_202504040000")]
        public static void SI0862B_Tests_Theory(string ARQ_SAIDA_FILE_NAME_P)
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
                #region Execute_DB_UPDATE_1_Update1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_UPDATE_1_Update1", q0);

                #endregion

                #region R010_SELECT_SISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R010_SELECT_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0862B_RELATORIOS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_COD_USUARIO" , ""},
                    { "RELATORI_DATA_SOLICITACAO" , ""},
                    { "HOST_DATA_INICIAL" , ""},
                    { "HOST_DATA_FINAL" , ""},
                    { "HOST_RAMO_INICIAL" , ""},
                    { "HOST_CODSUBES_INICIAL" , ""},
                    { "HOST_APOLICE" , ""},
                    { "HOST_PRODUTO_INICIAL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0862B_RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0862B_RELATORIOS", q2);

                #endregion

                #region R021_FETCH_RELATORIO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "USUARIOS_NOME_USUARIO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R021_FETCH_RELATORIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R021_FETCH_RELATORIO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R040_GRAVA_COLUNA_A_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R040_GRAVA_COLUNA_A_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R040_GRAVA_COLUNA_A_DB_SELECT_1_Query1", q4);

                #endregion

                #region R050_GRAVA_COLUNA_B_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R050_GRAVA_COLUNA_B_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R050_GRAVA_COLUNA_B_DB_SELECT_1_Query1", q5);

                #endregion

                #region R060_GRAVA_COLUNA_C_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "HOST_QTDE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R060_GRAVA_COLUNA_C_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R060_GRAVA_COLUNA_C_DB_SELECT_1_Query1", q6);

                #endregion

                #region R070_GRAVA_COLUNA_D_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R070_GRAVA_COLUNA_D_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R070_GRAVA_COLUNA_D_DB_SELECT_1_Query1", q7);

                #endregion

                #region R080_GRAVA_COLUNA_E_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "HOST_QTDE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R080_GRAVA_COLUNA_E_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R080_GRAVA_COLUNA_E_DB_SELECT_1_Query1", q8);

                #endregion

                #region R090_GRAVA_COLUNA_F_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R090_GRAVA_COLUNA_F_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R090_GRAVA_COLUNA_F_DB_SELECT_1_Query1", q9);

                #endregion

                #region R100_GRAVA_COLUNA_G_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "HOST_QTDE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R100_GRAVA_COLUNA_G_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R100_GRAVA_COLUNA_G_DB_SELECT_1_Query1", q10);

                #endregion

                #region R110_GRAVA_COLUNA_H_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R110_GRAVA_COLUNA_H_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R110_GRAVA_COLUNA_H_DB_SELECT_1_Query1", q11);

                #endregion

                #region R120_GRAVA_COLUNA_I_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "HOST_QTDE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R120_GRAVA_COLUNA_I_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R120_GRAVA_COLUNA_I_DB_SELECT_1_Query1", q12);

                #endregion

                #region R130_GRAVA_COLUNA_J_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R130_GRAVA_COLUNA_J_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R130_GRAVA_COLUNA_J_DB_SELECT_1_Query1", q13);

                #endregion

                #region R140_GRAVA_COLUNA_K_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R140_GRAVA_COLUNA_K_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R140_GRAVA_COLUNA_K_DB_SELECT_1_Query1", q14);

                #endregion

                #region R150_GRAVA_COLUNA_L_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R150_GRAVA_COLUNA_L_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R150_GRAVA_COLUNA_L_DB_SELECT_1_Query1", q15);

                #endregion

                #region R160_GRAVA_COLUNA_M_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R160_GRAVA_COLUNA_M_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R160_GRAVA_COLUNA_M_DB_SELECT_1_Query1", q16);

                #endregion

                #region R170_GRAVA_COLUNA_N_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R170_GRAVA_COLUNA_N_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R170_GRAVA_COLUNA_N_DB_SELECT_1_Query1", q17);

                #endregion

                #region R180_GRAVA_COLUNA_O_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R180_GRAVA_COLUNA_O_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R180_GRAVA_COLUNA_O_DB_SELECT_1_Query1", q18);

                #endregion

                #region R190_GRAVA_COLUNA_P_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R190_GRAVA_COLUNA_P_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R190_GRAVA_COLUNA_P_DB_SELECT_1_Query1", q19);

                #endregion

                #region R200_GRAVA_COLUNA_Q_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R200_GRAVA_COLUNA_Q_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R200_GRAVA_COLUNA_Q_DB_SELECT_1_Query1", q20);

                #endregion

                #endregion
                #endregion
                var program = new SI0862B();
                program.Execute(ARQ_SAIDA_FILE_NAME_P);

                Assert.True(File.Exists(program.ARQ_SAIDA.FilePath));
                Assert.True(new FileInfo(program.ARQ_SAIDA.FilePath).Length > 0);

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
        [InlineData("SI0862B_OUTPUT_202504040001")]
        public static void SI0862B_Tests_Theory_ReturnCode99(string ARQ_SAIDA_FILE_NAME_P)
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
                #region Execute_DB_UPDATE_1_Update1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>
                {
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_UPDATE_1_Update1", q0);

                #endregion

                #region R010_SELECT_SISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R010_SELECT_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0862B_RELATORIOS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_COD_USUARIO" , ""},
                    { "RELATORI_DATA_SOLICITACAO" , ""},
                    { "HOST_DATA_INICIAL" , ""},
                    { "HOST_DATA_FINAL" , ""},
                    { "HOST_RAMO_INICIAL" , ""},
                    { "HOST_CODSUBES_INICIAL" , ""},
                    { "HOST_APOLICE" , ""},
                    { "HOST_PRODUTO_INICIAL" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("SI0862B_RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0862B_RELATORIOS", q2);

                #endregion

                #region R021_FETCH_RELATORIO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "USUARIOS_NOME_USUARIO" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R021_FETCH_RELATORIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R021_FETCH_RELATORIO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R040_GRAVA_COLUNA_A_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R040_GRAVA_COLUNA_A_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R040_GRAVA_COLUNA_A_DB_SELECT_1_Query1", q4);

                #endregion

                #region R050_GRAVA_COLUNA_B_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R050_GRAVA_COLUNA_B_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R050_GRAVA_COLUNA_B_DB_SELECT_1_Query1", q5);

                #endregion

                #region R060_GRAVA_COLUNA_C_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "HOST_QTDE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R060_GRAVA_COLUNA_C_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R060_GRAVA_COLUNA_C_DB_SELECT_1_Query1", q6);

                #endregion

                #region R070_GRAVA_COLUNA_D_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R070_GRAVA_COLUNA_D_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R070_GRAVA_COLUNA_D_DB_SELECT_1_Query1", q7);

                #endregion

                #region R080_GRAVA_COLUNA_E_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "HOST_QTDE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R080_GRAVA_COLUNA_E_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R080_GRAVA_COLUNA_E_DB_SELECT_1_Query1", q8);

                #endregion

                #region R090_GRAVA_COLUNA_F_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R090_GRAVA_COLUNA_F_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R090_GRAVA_COLUNA_F_DB_SELECT_1_Query1", q9);

                #endregion

                #region R100_GRAVA_COLUNA_G_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "HOST_QTDE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R100_GRAVA_COLUNA_G_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R100_GRAVA_COLUNA_G_DB_SELECT_1_Query1", q10);

                #endregion

                #region R110_GRAVA_COLUNA_H_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R110_GRAVA_COLUNA_H_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R110_GRAVA_COLUNA_H_DB_SELECT_1_Query1", q11);

                #endregion

                #region R120_GRAVA_COLUNA_I_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "HOST_QTDE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R120_GRAVA_COLUNA_I_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R120_GRAVA_COLUNA_I_DB_SELECT_1_Query1", q12);

                #endregion

                #region R130_GRAVA_COLUNA_J_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R130_GRAVA_COLUNA_J_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R130_GRAVA_COLUNA_J_DB_SELECT_1_Query1", q13);

                #endregion

                #region R140_GRAVA_COLUNA_K_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R140_GRAVA_COLUNA_K_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R140_GRAVA_COLUNA_K_DB_SELECT_1_Query1", q14);

                #endregion

                #region R150_GRAVA_COLUNA_L_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R150_GRAVA_COLUNA_L_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R150_GRAVA_COLUNA_L_DB_SELECT_1_Query1", q15);

                #endregion

                #region R160_GRAVA_COLUNA_M_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R160_GRAVA_COLUNA_M_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R160_GRAVA_COLUNA_M_DB_SELECT_1_Query1", q16);

                #endregion

                #region R170_GRAVA_COLUNA_N_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R170_GRAVA_COLUNA_N_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R170_GRAVA_COLUNA_N_DB_SELECT_1_Query1", q17);

                #endregion

                #region R180_GRAVA_COLUNA_O_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R180_GRAVA_COLUNA_O_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R180_GRAVA_COLUNA_O_DB_SELECT_1_Query1", q18);

                #endregion

                #region R190_GRAVA_COLUNA_P_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R190_GRAVA_COLUNA_P_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R190_GRAVA_COLUNA_P_DB_SELECT_1_Query1", q19);

                #endregion

                #region R200_GRAVA_COLUNA_Q_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R200_GRAVA_COLUNA_Q_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R200_GRAVA_COLUNA_Q_DB_SELECT_1_Query1", q20);

                #endregion

                #endregion
                #endregion
                var program = new SI0862B();
                program.Execute(ARQ_SAIDA_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}