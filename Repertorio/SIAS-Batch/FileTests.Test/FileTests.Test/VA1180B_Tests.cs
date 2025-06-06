using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VA1180B;

namespace FileTests.Test
{
    [Collection("VA1180B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA1180B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-09-02"}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0000_00_PRINCIPAL_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_DTMVFDCAP" , "2023-02-01"}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_2_Query1", q1);

            #endregion

            #region VA1180B_CMVFDCAP

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "10000022205"},
                { "PROPOVA_COD_PRODUTO" , "9701"},
                { "PROPOVA_NUM_APOLICE" , "97010000889"},
                { "PROPOVA_COD_SUBGRUPO" , "1"},
                { "PROPOVA_NUM_PARCELA" , "376"},
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "10000022319"},
                { "PROPOVA_COD_PRODUTO" , "9701"},
                { "PROPOVA_NUM_APOLICE" , "97010000889"},
                { "PROPOVA_COD_SUBGRUPO" , "1"},
                { "PROPOVA_NUM_PARCELA" , "375"},
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "10000022347"},
                { "PROPOVA_COD_PRODUTO" , "9701"},
                { "PROPOVA_NUM_APOLICE" , "97010000889"},
                { "PROPOVA_COD_SUBGRUPO" , "1"},
                { "PROPOVA_NUM_PARCELA" , "375"},
            });
            AppSettings.TestSet.DynamicData.Add("VA1180B_CMVFDCAP", q2);

            #endregion

            #region R0100_00_GERA_MOVIMENTO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , "1"},
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , "20000.00"},
                { "HISCOBPR_VLPREMIO" , "158.75"},
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , "1"},
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , "20000.00"},
                { "HISCOBPR_VLPREMIO" , "80.82"},
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , "1"},
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , "20000.00"},
                { "HISCOBPR_VLPREMIO" , "80.82"},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_GERA_MOVIMENTO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0100_00_GERA_MOVIMENTO_DB_SELECT_2_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_QUANT_TIT_CAPITALI" , "0"}
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_QUANT_TIT_CAPITALI" , "0"}
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_QUANT_TIT_CAPITALI" , "7"}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_GERA_MOVIMENTO_DB_SELECT_2_Query1", q4);

            #endregion

            #region R0100_00_GERA_MOVIMENTO_DB_SELECT_3_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_QUANT_TIT_CAPITALI" , "0"}
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_QUANT_TIT_CAPITALI" , "0"}
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "MOVFEDCA_QUANT_TIT_CAPITALI" , "31"}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_GERA_MOVIMENTO_DB_SELECT_3_Query1", q5);

            #endregion

            #region R0100_00_GERA_MOVIMENTO_DB_SELECT_4_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "TCAPITVG_DATA_TERVIGENCIA" , "2000-01-31"}
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "TCAPITVG_DATA_TERVIGENCIA" , "2000-01-31"}
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "TCAPITVG_DATA_TERVIGENCIA" , "2000-01-31"}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_GERA_MOVIMENTO_DB_SELECT_4_Query1", q6);

            #endregion

            #region R0250_00_PESQUISA_SEGURADO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_SIT_REGISTRO" , "0"}
            });
            q7.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_SIT_REGISTRO" , "0"}
            });
            q7.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_SIT_REGISTRO" , "0"}
            });
            AppSettings.TestSet.DynamicData.Add("R0250_00_PESQUISA_SEGURADO_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1000_00_GRAVA_MOVIMENTO_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "MOVFEDCA_COD_OPERACAO" , ""},
                { "PRODUVG_DTMVFDCAP" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "MOVFEDCA_QUANT_TIT_CAPITALI" , ""},
                { "MOVFEDCA_VAL_CUSTO_CAPITALI" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_GRAVA_MOVIMENTO_DB_INSERT_1_Insert1", q8);

            #endregion

            #endregion
        }

        [Fact]
        public static void VA1180B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();

                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new VA1180B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 9);
            }
        }
        [Fact]
        public static void VA1180B_Tests_Fact1()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VA1180B();
                program.Execute();
                
                var envlist = AppSettings.TestSet.DynamicData["R1000_00_GRAVA_MOVIMENTO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envlist.Count > 1);
                Assert.True(envlist[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var valor) && valor.Contains("10000022205"));
                Assert.True(envlist[2].TryGetValue("PRODUVG_DTMVFDCAP", out var val5r) && val5r.Contains("2023-02-01"));

                Assert.True(program.AREA_WORK.AC_GRAVADOS == 2);
                
            }
        }
        [Fact]
        public static void VA1180B_Tests_Fact2()
        {
            lock (AppSettings.TestSet._lock)
            {
                //testar divide
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-02-02"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new VA1180B();
                program.Execute();

                Assert.True(program.AREA_WORK.RESTO == 0);
            }
        }
    }
}