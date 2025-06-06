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
using static Code.VE0029B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("VE0029B_Tests")]
    public class VE0029B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region VE0029B_V0PENDENTE

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0PEND_NUM_APOL" , ""},
                { "V0PEND_COD_SUBG" , ""},
                { "V0PEND_NRENDOS" , ""},
                { "V0PEND_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0029B_V0PENDENTE", q1);

            #endregion

            #region VE0029B_V0ENDOSSO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_NRENDOS" , ""},
                { "V1ENDO_SITUACAO" , ""},
                { "V1ENDO_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0029B_V0ENDOSSO", q2);

            #endregion

            #region R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0TERMO_NUM_TERMO" , ""},
                { "V0TERMO_COD_SUBG" , ""},
                { "V0TERMO_PERIPGTO" , ""},
                { "V0TERMO_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0230_00_HOUVE_PGTO_FUTURO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_QTD_PGTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0230_00_HOUVE_PGTO_FUTURO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0250_00_VERIFICA_PGTO_PARCELA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUM_APOL" , ""},
                { "V1PARC_NRENDOS" , ""},
                { "V1PARC_SITUACAO" , ""},
                { "V1PARC_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0250_00_VERIFICA_PGTO_PARCELA_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0260_00_VERIFICA_PGTO_HISPARC_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1HISP_NUM_APOL" , ""},
                { "V1HISP_NRENDOS" , ""},
                { "V1HISP_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0260_00_VERIFICA_PGTO_HISPARC_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1REL_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0280_00_GERA_SOL_CANCELAMENTO_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V0PEND_NUM_APOL" , ""},
                { "V0PEND_COD_SUBG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0280_00_GERA_SOL_CANCELAMENTO_DB_INSERT_1_Insert1", q8);

            #endregion

            #endregion
        }

        [Fact]
        public static void VE0029B_Tests_Fact_Erro9()
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
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""}
                }, new SQLCA(999));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);
                #endregion
                var program = new VE0029B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 9);
            }
        }

        [Fact]
        public static void VE0029B_Tests_Fact()
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
                #region R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1
                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0TERMO_NUM_TERMO" , "800"},
                { "V0TERMO_COD_SUBG" , "1"},
                { "V0TERMO_PERIPGTO" , "3"},
                { "V0TERMO_SITUACAO" , "S"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V1REL_SITUACAO" , ""}
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("R0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1_Query1", q7);

                #endregion

                #endregion
                var program = new VE0029B();
                program.Execute();

                //R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1"].DynamicList);

                //R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1"].DynamicList);

                //R0230_00_HOUVE_PGTO_FUTURO_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["R0230_00_HOUVE_PGTO_FUTURO_DB_SELECT_1_Query1"].DynamicList);

                //R0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["R0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1_Query1"].DynamicList);

                //R0280_00_GERA_SOL_CANCELAMENTO_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["R0280_00_GERA_SOL_CANCELAMENTO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList[1].TryGetValue("V0PEND_NUM_APOL", out var valor) && valor.Contains("0"));
                Assert.True(envList.Count > 1);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}