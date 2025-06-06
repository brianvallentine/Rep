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
using static Code.SI0202B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0202B_Tests")]
    public class SI0202B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R010_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "HOST_CURRENT_DATE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region SI0202B_XXXXX

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "HOST_DATA_HOJE_MENOS_05_DIAS" , ""},
                { "HOST_DATA_HOJE_MENOS_40_DIAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0202B_XXXXX", q1);

            #endregion

            #region SI0202B_C01_SINISHIS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SINISMES_NUM_PROTOCOLO_SINI" , ""},
                { "SINIHAB1_OPERACAO" , ""},
                { "SINIHAB1_PONTO_VENDA" , ""},
                { "SINIHAB1_NUM_CONTRATO" , ""},
                { "SINIHAB1_NOME_SEGURADO" , ""},
                { "SINIHAB1_COD_CLIENTE" , ""},
                { "SINIHAB1_CGCCPF" , ""},
                { "SINISCAU_GRUPO_CAUSAS" , ""},
                { "SINISCAU_DESCR_CAUSA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0202B_C01_SINISHIS", q2);

            #endregion

            #region SI0202B_YYY

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "RALCHEDO_AGE_CENTRAL_PROD01" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0202B_YYY", q3);

            #endregion

            #region R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_DATA_MOVIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1", q4);

            #endregion

            #region R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_DATA_MOVIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1_Query1", q5);

            #endregion

            #region R107_LE_VALOR_PREMIO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R107_LE_VALOR_PREMIO_DB_SELECT_1_Query1", q6);

            #endregion

            #region SI0202B_XXX

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "HOST_DATA_HOJE_MENOS_05_DIAS" , ""},
                { "HOST_DATA_HOJE_MENOS_40_DIAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0202B_XXX", q7);

            #endregion

            #region R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "HOST_TOTAL_PRE_LIBERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1", q8);

            #endregion

            #region R200_LE_PRE_LIBERACOES_DB_SELECT_2_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "HOST_TOTAL_CANC_PRE_LIBERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R200_LE_PRE_LIBERACOES_DB_SELECT_2_Query1", q9);

            #endregion

            #region R210_LE_ESTORNO_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R210_LE_ESTORNO_DB_SELECT_1_Query1", q10);

            #endregion

            #region R220_LE_VALOR_PAGO_EST_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R220_LE_VALOR_PAGO_EST_DB_SELECT_1_Query1", q11);

            #endregion

            #region R510_LE_PLANILHA_SELECT_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINIPLAN_VAL_INDENIZACAO" , ""},
                { "SINIPLAN_VAL_SALDO_DEVEDOR" , ""},
                { "SINIPLAN_VAL_ACORRIGIR" , ""},
                { "SINIPLAN_QTD_PRE_ARECUPERAR" , ""},
                { "SINIPLAN_VAL_PREMIO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R510_LE_PLANILHA_SELECT_DB_SELECT_1_Query1", q12);

            #endregion

            #region R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_1_Query1", q13);

            #endregion

            #region R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2_Query1", q14);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("123456789")]
        public static void SI0202B_Tests_Theory(string SIH202A_FILE_NAME_P)
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


                #region R010_SELECT_SISTEMAS_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R010_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                     { "SISTEMAS_DATA_MOV_ABERTO" , "2024-01-01"},
                     { "HOST_CURRENT_DATE" , "2025-04-09"},
                });
                AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0202B_XXXXX

                AppSettings.TestSet.DynamicData.Remove("SI0202B_XXXXX");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                     { "HOST_DATA_HOJE_MENOS_05_DIAS" , "2025-04-09"},
                     { "HOST_DATA_HOJE_MENOS_40_DIAS" , "2025-04-09"},
                });
                AppSettings.TestSet.DynamicData.Add("SI0202B_XXXXX", q1);

                #endregion

                #region SI0202B_C01_SINISHIS

                AppSettings.TestSet.DynamicData.Remove("SI0202B_C01_SINISHIS");
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                     { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                     { "SINISMES_NUM_APOLICE" , "1"},
                     { "SINISMES_COD_PRODUTO" , "1"},
                     { "SINISMES_COD_FONTE" , "1"},
                     { "SINISMES_DATA_OCORRENCIA" , "2025-04-02"},
                     { "SINISMES_SIT_REGISTRO" , "1"},
                     { "SINISMES_NUM_PROTOCOLO_SINI" , "1"},
                     { "SINIHAB1_OPERACAO" , "1"},
                     { "SINIHAB1_PONTO_VENDA" , "1"},
                     { "SINIHAB1_NUM_CONTRATO" , "1"},
                     { "SINIHAB1_NOME_SEGURADO" , "1"},
                     { "SINIHAB1_COD_CLIENTE" , "1"},
                     { "SINIHAB1_CGCCPF" , "1"},
                     { "SINISCAU_GRUPO_CAUSAS" , "1"},
                     { "SINISCAU_DESCR_CAUSA" , "1"},
                });
                AppSettings.TestSet.DynamicData.Add("SI0202B_C01_SINISHIS", q2);

                #endregion

                #region SI0202B_YYY

                AppSettings.TestSet.DynamicData.Remove("SI0202B_YYY");
                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                     { "RALCHEDO_AGE_CENTRAL_PROD01" , "1"},
                     { "SINISHIS_OCORR_HISTORICO" , "1"},
                     { "SINISHIS_DATA_MOVIMENTO" , "2025-04-09"},
                });
                AppSettings.TestSet.DynamicData.Add("SI0202B_YYY", q3);

                #endregion

                #region R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1");
                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_DATA_MOVIMENTO" , "2025-04-09"}
                });
                AppSettings.TestSet.DynamicData.Add("R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1", q4);

                #endregion

                #region R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1_Query1");
                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_DATA_MOVIMENTO" , "2025-04-09"}
                });
                AppSettings.TestSet.DynamicData.Add("R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1_Query1", q5);

                #endregion

                #region R107_LE_VALOR_PREMIO_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R107_LE_VALOR_PREMIO_DB_SELECT_1_Query1");
                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("R107_LE_VALOR_PREMIO_DB_SELECT_1_Query1", q6);

                #endregion

                #region SI0202B_XXX

                AppSettings.TestSet.DynamicData.Remove("SI0202B_XXX");
                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                     { "HOST_DATA_HOJE_MENOS_05_DIAS" , "2025-04-09"},
                     { "HOST_DATA_HOJE_MENOS_40_DIAS" , "2025-04-09"},
                });
                AppSettings.TestSet.DynamicData.Add("SI0202B_XXX", q7);

                #endregion

                #region R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1");
                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "HOST_TOTAL_PRE_LIBERACAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1", q8);

                #endregion

                #region R200_LE_PRE_LIBERACOES_DB_SELECT_2_Query1

                AppSettings.TestSet.DynamicData.Remove("R200_LE_PRE_LIBERACOES_DB_SELECT_2_Query1");
                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "HOST_TOTAL_CANC_PRE_LIBERACAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("R200_LE_PRE_LIBERACOES_DB_SELECT_2_Query1", q9);

                #endregion

                #region R210_LE_ESTORNO_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R210_LE_ESTORNO_DB_SELECT_1_Query1");
                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("R210_LE_ESTORNO_DB_SELECT_1_Query1", q10);

                #endregion

                #region R220_LE_VALOR_PAGO_EST_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R220_LE_VALOR_PAGO_EST_DB_SELECT_1_Query1");
                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("R220_LE_VALOR_PAGO_EST_DB_SELECT_1_Query1", q11);

                #endregion

                #region R510_LE_PLANILHA_SELECT_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R510_LE_PLANILHA_SELECT_DB_SELECT_1_Query1");
                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                     { "SINISHIS_NUM_APOL_SINISTRO" , "1"},
                     { "SINIPLAN_VAL_INDENIZACAO" , "1"},
                     { "SINIPLAN_VAL_SALDO_DEVEDOR" , "1"},
                     { "SINIPLAN_VAL_ACORRIGIR" , "1"},
                     { "SINIPLAN_QTD_PRE_ARECUPERAR" , "1"},
                     { "SINIPLAN_VAL_PREMIO" , "1"},
                     { "SINISHIS_DATA_MOVIMENTO" , "2025-04-02"},
                });
                AppSettings.TestSet.DynamicData.Add("R510_LE_PLANILHA_SELECT_DB_SELECT_1_Query1", q12);

                #endregion

                #region R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_1_Query1");
                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_1_Query1", q13);

                #endregion

                #region R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2_Query1

                AppSettings.TestSet.DynamicData.Remove("R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2_Query1");
                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "1" }
                });
                AppSettings.TestSet.DynamicData.Add("R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2_Query1", q14);

                #endregion

                #endregion
                var program = new SI0202B();

                var param = new SI0202B_LINK_PARM_DE_EXECUCAO();
                param.PARM_FORMA_EXECUCAO.Value = "111";

                program.Execute(param, SIH202A_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var quantQuerys = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("123456789")]
        public static void SI0202B_Tests_TheoryReturn99(string SIH202A_FILE_NAME_P)
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


                #region R010_SELECT_SISTEMAS_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R010_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                     { "SISTEMAS_DATA_MOV_ABERTO" , "2024-01-01"},
                     { "HOST_CURRENT_DATE" , "2025-04-09"},
                });
                AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0202B_XXXXX

                AppSettings.TestSet.DynamicData.Remove("SI0202B_XXXXX");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                     { "HOST_DATA_HOJE_MENOS_05_DIAS" , "2025-04-09"},
                     { "HOST_DATA_HOJE_MENOS_40_DIAS" , "2025-04-09"},
                });
                AppSettings.TestSet.DynamicData.Add("SI0202B_XXXXX", q1);

                #endregion

                #region SI0202B_C01_SINISHIS

                AppSettings.TestSet.DynamicData.Remove("SI0202B_C01_SINISHIS");
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                     { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                     { "SINISMES_NUM_APOLICE" , "1"},
                     { "SINISMES_COD_PRODUTO" , "1"},
                     { "SINISMES_COD_FONTE" , "1"},
                     { "SINISMES_DATA_OCORRENCIA" , "2025-04-02"},
                     { "SINISMES_SIT_REGISTRO" , "1"},
                     { "SINISMES_NUM_PROTOCOLO_SINI" , "1"},
                     { "SINIHAB1_OPERACAO" , "1"},
                     { "SINIHAB1_PONTO_VENDA" , "1"},
                     { "SINIHAB1_NUM_CONTRATO" , "1"},
                     { "SINIHAB1_NOME_SEGURADO" , "1"},
                     { "SINIHAB1_COD_CLIENTE" , "1"},
                     { "SINIHAB1_CGCCPF" , "1"},
                     { "SINISCAU_GRUPO_CAUSAS" , "1"},
                     { "SINISCAU_DESCR_CAUSA" , "1"},
                });
                AppSettings.TestSet.DynamicData.Add("SI0202B_C01_SINISHIS", q2);

                #endregion

                #region SI0202B_YYY

                AppSettings.TestSet.DynamicData.Remove("SI0202B_YYY");
                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                     { "RALCHEDO_AGE_CENTRAL_PROD01" , "1"},
                     { "SINISHIS_OCORR_HISTORICO" , "1"},
                     { "SINISHIS_DATA_MOVIMENTO" , "2025-04-09"},
                });
                AppSettings.TestSet.DynamicData.Add("SI0202B_YYY", q3);

                #endregion

                #region R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1");
                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_DATA_MOVIMENTO" , "2025-04-09"}
                });
                AppSettings.TestSet.DynamicData.Add("R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1", q4);

                #endregion

                #region R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1_Query1");
                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_DATA_MOVIMENTO" , "2025-04-09"}
                });
                AppSettings.TestSet.DynamicData.Add("R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1_Query1", q5);

                #endregion

                #region R107_LE_VALOR_PREMIO_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R107_LE_VALOR_PREMIO_DB_SELECT_1_Query1");
                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("R107_LE_VALOR_PREMIO_DB_SELECT_1_Query1", q6);

                #endregion

                #region SI0202B_XXX

                AppSettings.TestSet.DynamicData.Remove("SI0202B_XXX");
                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{

                });
                AppSettings.TestSet.DynamicData.Add("SI0202B_XXX", q7);

                #endregion

                #region R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1");
                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "HOST_TOTAL_PRE_LIBERACAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1", q8);

                #endregion

                #region R200_LE_PRE_LIBERACOES_DB_SELECT_2_Query1

                AppSettings.TestSet.DynamicData.Remove("R200_LE_PRE_LIBERACOES_DB_SELECT_2_Query1");
                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "HOST_TOTAL_CANC_PRE_LIBERACAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("R200_LE_PRE_LIBERACOES_DB_SELECT_2_Query1", q9);

                #endregion

                #region R210_LE_ESTORNO_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R210_LE_ESTORNO_DB_SELECT_1_Query1");
                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                  
                });
                AppSettings.TestSet.DynamicData.Add("R210_LE_ESTORNO_DB_SELECT_1_Query1", q10);

                #endregion

                #region R220_LE_VALOR_PAGO_EST_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R220_LE_VALOR_PAGO_EST_DB_SELECT_1_Query1");
                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                  
                });
                AppSettings.TestSet.DynamicData.Add("R220_LE_VALOR_PAGO_EST_DB_SELECT_1_Query1", q11);

                #endregion

                #region R510_LE_PLANILHA_SELECT_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R510_LE_PLANILHA_SELECT_DB_SELECT_1_Query1");
                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{

                });
                AppSettings.TestSet.DynamicData.Add("R510_LE_PLANILHA_SELECT_DB_SELECT_1_Query1", q12);

                #endregion

                #region R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_1_Query1");
                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_1_Query1", q13);

                #endregion

                #region R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2_Query1

                AppSettings.TestSet.DynamicData.Remove("R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2_Query1");
                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "1" }
                });
                AppSettings.TestSet.DynamicData.Add("R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2_Query1", q14);

                #endregion

                #endregion
                var program = new SI0202B();

                var param = new SI0202B_LINK_PARM_DE_EXECUCAO();
                param.PARM_FORMA_EXECUCAO.Value = "111";

                program.Execute(param, SIH202A_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var quantQuerys = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}