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
using static Code.CB1280B;

namespace FileTests.Test
{
    [Collection("CB1280B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class CB1280B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region CB1280B_CUR_PARCELAS

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_DATA_VENCIMENTO" , ""},
                { "PARCEHIS_PRM_TOTAL" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "PRODUTO_DESCR_PRODUTO" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_TIPO_PESSOA" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "ENDERECO_DDD" , ""},
                { "ENDERECO_TELEFONE" , ""},
                { "ENDERECO_FAX" , ""},
                { "ENDERECO_TELEX" , ""},
                { "CLIENEMA_EMAIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB1280B_CUR_PARCELAS", q0);

            #endregion

            #region P1000_00_INICIO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P1000_00_INICIO_DB_SELECT_1_Query1", q1);

            #endregion

            #region CB1280B_CUR_PARCELA_PAGA

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "CBAPOVIG_NUM_APOLICE" , ""},
                { "CBAPOVIG_NUM_ENDOSSO" , ""},
                { "CBAPOVIG_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB1280B_CUR_PARCELA_PAGA", q2);

            #endregion

            #region P2111_00_VALIDA_APOLICE_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "CBAPOVIG_NUM_ENDOSSO" , ""},
                { "CBAPOVIG_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P2111_00_VALIDA_APOLICE_DB_SELECT_1_Query1", q3);

            #endregion

            #region P2111_00_VALIDA_APOLICE_DB_SELECT_2_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WS_QT_REGISTRO_1" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P2111_00_VALIDA_APOLICE_DB_SELECT_2_Query1", q4);

            #endregion

            #region P2112_00_CALCULA_VIGENCIA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P2112_00_CALCULA_VIGENCIA_DB_SELECT_1_Query1", q5);

            #endregion

            #region P2111_00_VALIDA_APOLICE_DB_SELECT_3_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NSAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P2111_00_VALIDA_APOLICE_DB_SELECT_3_Query1", q6);

            #endregion

            #region P2112_00_CALCULA_VIGENCIA_DB_SELECT_2_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WS_QT_DIAS_VIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P2112_00_CALCULA_VIGENCIA_DB_SELECT_2_Query1", q7);

            #endregion

            #region P2111_00_VALIDA_APOLICE_DB_SELECT_4_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P2111_00_VALIDA_APOLICE_DB_SELECT_4_Query1", q8);

            #endregion

            #region P2113_00_CALCULA_VALORES_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "WS_VL_DEVIDO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P2113_00_CALCULA_VALORES_DB_SELECT_1_Query1", q9);

            #endregion

            #region P2111_00_VALIDA_APOLICE_DB_SELECT_5_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "WS_QT_SINISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P2111_00_VALIDA_APOLICE_DB_SELECT_5_Query1", q10);

            #endregion

            #region P2113_00_CALCULA_VALORES_DB_SELECT_2_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "WS_VL_PAGAMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P2113_00_CALCULA_VALORES_DB_SELECT_2_Query1", q11);

            #endregion

            #region P2113_00_CALCULA_VALORES_DB_SELECT_3_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "WS_VL_ESTORNO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P2113_00_CALCULA_VALORES_DB_SELECT_3_Query1", q12);

            #endregion

            #region P2113_00_CALCULA_VALORES_DB_SELECT_4_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "WS_DT_FIM_VIG_PROP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P2113_00_CALCULA_VALORES_DB_SELECT_4_Query1", q13);

            #endregion

            #region P2113_00_CALCULA_VALORES_DB_SELECT_5_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "WS_DT_CANCELAMENTO_1" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P2113_00_CALCULA_VALORES_DB_SELECT_5_Query1", q14);

            #endregion

            #region P2115_00_INCLUI_CBAPOVIG_DB_DELETE_1_Delete1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P2115_00_INCLUI_CBAPOVIG_DB_DELETE_1_Delete1", q15);

            #endregion

            #region P2115_00_INCLUI_CBAPOVIG_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "CBAPOVIG_NUM_APOLICE" , ""},
                { "CBAPOVIG_NUM_ENDOSSO" , ""},
                { "CBAPOVIG_NUM_PARCELA" , ""},
                { "CBAPOVIG_DATA_MOVIMENTO" , ""},
                { "CBAPOVIG_DATA_VENCIMENTO" , ""},
                { "CBAPOVIG_PREMIO_TOTAL_PAGO" , ""},
                { "CBAPOVIG_PREMIO_TOTAL_DEV" , ""},
                { "CBAPOVIG_QTD_DIAS_COBERTOS" , ""},
                { "CBAPOVIG_DATA_FIM_VIG_PROP" , ""},
                { "CBAPOVIG_DATA_CANCELAMENTO" , ""},
                { "CBAPOVIG_IDTAB_SITUACAO" , ""},
                { "CBAPOVIG_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P2115_00_INCLUI_CBAPOVIG_DB_INSERT_1_Insert1", q16);

            #endregion

            #region P2113_00_CALCULA_VALORES_DB_SELECT_6_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "WS_DT_CANCELAMENTO_2" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P2113_00_CALCULA_VALORES_DB_SELECT_6_Query1", q17);

            #endregion

            #region P2117_00_CALCULA_VL_PAGO_TST_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "WS_VL_PAGO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P2117_00_CALCULA_VL_PAGO_TST_DB_SELECT_1_Query1", q18);

            #endregion

            #region P2200_00_LE_CUR_PARCELA_PAGA_DB_UPDATE_1_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "CBAPOVIG_NUM_APOLICE" , ""},
                { "CBAPOVIG_NUM_ENDOSSO" , ""},
                { "CBAPOVIG_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P2200_00_LE_CUR_PARCELA_PAGA_DB_UPDATE_1_Update1", q19);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("CB1280B_OUTPUT_2025031701.txt", "CB1280B_OUTPUT_2025031702.txt", "CB1280B_OUTPUT_2025031703.txt")]
        public static void CB1280B_Tests_Theory_Erro99(string CB1280S01_FILE_NAME_P, string CB1280S02_FILE_NAME_P, string CB1280S03_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                CB1280S01_FILE_NAME_P = $"{CB1280S01_FILE_NAME_P}_{timestamp}.txt";
                CB1280S02_FILE_NAME_P = $"{CB1280S02_FILE_NAME_P}_{timestamp}.txt";
                CB1280S03_FILE_NAME_P = $"{CB1280S03_FILE_NAME_P}_{timestamp}.txt";

                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region P1000_00_INICIO_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("P1000_00_INICIO_DB_SELECT_1_Query1");

                var q1 = new DynamicData();
             
                AppSettings.TestSet.DynamicData.Add("P1000_00_INICIO_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion
                var program = new CB1280B();
                program.Execute(CB1280S01_FILE_NAME_P, CB1280S02_FILE_NAME_P, CB1280S03_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Theory]
        [InlineData("CB1280B_OUTPUT_2025031701.txt", "CB1280B_OUTPUT_2025031702.txt", "CB1280B_OUTPUT_2025031703.txt")]
        public static void CB1280B_Tests_Theory(string CB1280S01_FILE_NAME_P, string CB1280S02_FILE_NAME_P, string CB1280S03_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                CB1280S01_FILE_NAME_P = $"{CB1280S01_FILE_NAME_P}_{timestamp}.txt";
                CB1280S02_FILE_NAME_P = $"{CB1280S02_FILE_NAME_P}_{timestamp}.txt";
                CB1280S03_FILE_NAME_P = $"{CB1280S03_FILE_NAME_P}_{timestamp}.txt";
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region CB1280B_CUR_PARCELAS

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , "1"},
                { "PARCEHIS_NUM_ENDOSSO" , "1"},
                { "PARCEHIS_NUM_PARCELA" , "1"},
                { "PARCEHIS_DATA_VENCIMENTO" , ""},
                { "PARCEHIS_PRM_TOTAL" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "PRODUTO_DESCR_PRODUTO" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_TIPO_PESSOA" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "ENDERECO_DDD" , ""},
                { "ENDERECO_TELEFONE" , ""},
                { "ENDERECO_FAX" , ""},
                { "ENDERECO_TELEX" , ""},
                { "CLIENEMA_EMAIL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("CB1280B_CUR_PARCELAS");
                AppSettings.TestSet.DynamicData.Add("CB1280B_CUR_PARCELAS", q0);

                #endregion

                #region CB1280B_CUR_PARCELA_PAGA

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "CBAPOVIG_NUM_APOLICE" , "1"},
                { "CBAPOVIG_NUM_ENDOSSO" , "1"},
                { "CBAPOVIG_NUM_PARCELA" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("CB1280B_CUR_PARCELA_PAGA");
                AppSettings.TestSet.DynamicData.Add("CB1280B_CUR_PARCELA_PAGA", q2);

                #endregion

                #region P2111_00_VALIDA_APOLICE_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "CBAPOVIG_NUM_ENDOSSO" , "2"},
                { "CBAPOVIG_NUM_PARCELA" , "3"},
                });
                AppSettings.TestSet.DynamicData.Remove("P2111_00_VALIDA_APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P2111_00_VALIDA_APOLICE_DB_SELECT_1_Query1", q3);

                #endregion
                #region P2111_00_VALIDA_APOLICE_DB_SELECT_2_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "WS_QT_REGISTRO_1" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("P2111_00_VALIDA_APOLICE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("P2111_00_VALIDA_APOLICE_DB_SELECT_2_Query1", q4);

                #endregion


                #region P2111_00_VALIDA_APOLICE_DB_SELECT_3_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NSAS" , "2050"}
                });
                AppSettings.TestSet.DynamicData.Remove("P2111_00_VALIDA_APOLICE_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("P2111_00_VALIDA_APOLICE_DB_SELECT_3_Query1", q6);

                #endregion


                #region P2111_00_VALIDA_APOLICE_DB_SELECT_4_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_SITUACAO_COBRANCA" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("P2111_00_VALIDA_APOLICE_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("P2111_00_VALIDA_APOLICE_DB_SELECT_4_Query1", q8);

                #endregion

                #endregion
                var program = new CB1280B();
                program.Execute(CB1280S01_FILE_NAME_P, CB1280S02_FILE_NAME_P, CB1280S03_FILE_NAME_P);

                //P2115_00_INCLUI_CBAPOVIG_DB_DELETE_1_Delete1
                var envList = AppSettings.TestSet.DynamicData["P2115_00_INCLUI_CBAPOVIG_DB_DELETE_1_Delete1"].DynamicList;
                Assert.True(envList.Count == 0);

                //P2115_00_INCLUI_CBAPOVIG_DB_INSERT_1_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["P2115_00_INCLUI_CBAPOVIG_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("CBAPOVIG_IDTAB_SITUACAO", out var valor2) && valor2.Contains("19"));
                Assert.True(envList2.Count > 1);

                //P2200_00_LE_CUR_PARCELA_PAGA_DB_UPDATE_1_Update1
                var envList3 = AppSettings.TestSet.DynamicData["P2200_00_LE_CUR_PARCELA_PAGA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("CBAPOVIG_NUM_PARCELA", out var valor3) && valor3.Contains("1"));
                Assert.True(envList3.Count > 1);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}