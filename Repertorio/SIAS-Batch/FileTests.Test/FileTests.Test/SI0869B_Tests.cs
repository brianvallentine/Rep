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
using static Code.SI0869B;

namespace FileTests.Test
{
    [Collection("SI0869B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0869B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R010_LE_SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SISTEMAS_DATULT_PROCESSAMEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region SI0869B_INDENIZACOES

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "SINISMES_COD_CAUSA" , ""},
                { "SINISCAU_DESCR_CAUSA" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_COD_PRODUTO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINILT01_COD_CLIENTE" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_TIPO_PESSOA" , ""},
                { "SINILT01_COD_LOT_FENAL" , ""},
                { "SINILT01_COD_LOT_CEF" , ""},
                { "SINILT01_COD_COBERTURA" , ""},
                { "SIMOLOT1_VALOR_INFORMADO" , ""},
                { "SIMOLOT1_VALOR_REGISTRADO" , ""},
                { "SIMOLOT1_VAL_IS" , ""},
                { "SIMOLOT1_DATA_AVISO" , ""},
                { "SIMOLOT1_VAL_ADIANTAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0869B_INDENIZACOES", q1);

            #endregion

            #region SI0869B_RETENCOES

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SINLOAB2_VALOR_RETENCAO" , ""},
                { "SINLOAB2_VLR_RETENCAO_CALC" , ""},
                { "SINLOAB2_IND_VLR_RETENCAO" , ""},
                { "SINLOAB2_PERCENT_RETENCAO" , ""},
                { "SINLOAB2_COD_RETENCAO" , ""},
                { "SINLOAB2_QTD_SINISTRO_PAGO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0869B_RETENCOES", q2);

            #endregion

            #region R105_BUSCA_SINISTRO_PREST_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SIMOLOT1_NUM_SINI_PREST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R105_BUSCA_SINISTRO_PREST_DB_SELECT_1_Query1", q3);

            #endregion

            #region R110_CALCULA_PROX_DIA_UTIL_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R110_CALCULA_PROX_DIA_UTIL_DB_SELECT_1_Query1", q4);

            #endregion

            #region R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_DATA_ENVIO" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1", q5);

            #endregion

            #region R130_VALOR_APURADO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR_APURADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R130_VALOR_APURADO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R135_VALOR_ESTORNADO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR_APURADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R135_VALOR_ESTORNADO_DB_SELECT_1_Query1", q7);

            #endregion

            #region SI0869B_LOTERICO

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "LOTERI01_DDD" , ""},
                { "LOTERI01_NUM_FONE" , ""},
                { "LOTERI01_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0869B_LOTERICO", q8);

            #endregion

            #region R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR_ADIANTAMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1", q9);

            #endregion

            #region R200_VALOR_DIFERENCA_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR_DIFERENCA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R200_VALOR_DIFERENCA_DB_SELECT_1_Query1", q10);

            #endregion

            #region R230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "GEOPERAC_DES_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1_Query1", q11);

            #endregion

            #region R240_MONTA_TIPO_ESTORNO_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "HOST_OPERACAO_EST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R240_MONTA_TIPO_ESTORNO_DB_SELECT_1_Query1", q12);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0869B_t1")]
        public static void SI0869B_Tests_Theory(string ARQ_SAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQ_SAIDA_FILE_NAME_P = $"{ARQ_SAIDA_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R010_LE_SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                    { "SISTEMAS_DATULT_PROCESSAMEN" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R010_LE_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0869B_INDENIZACOES

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                    { "SINISMES_NUM_APOLICE" , ""},
                    { "SINISMES_DATA_OCORRENCIA" , ""},
                    { "SINISMES_COD_CAUSA" , ""},
                    { "SINISCAU_DESCR_CAUSA" , ""},
                    { "SINISHIS_COD_OPERACAO" , ""},
                    { "SINISHIS_COD_PRODUTO" , ""},
                    { "SINISHIS_DATA_MOVIMENTO" , ""},
                    { "SINISHIS_OCORR_HISTORICO" , ""},
                    { "SINISHIS_VAL_OPERACAO" , ""},
                    { "SINISHIS_SIT_CONTABIL" , "2"},
                    { "SINILT01_COD_CLIENTE" , ""},
                    { "CLIENTES_NOME_RAZAO" , ""},
                    { "CLIENTES_CGCCPF" , ""},
                    { "CLIENTES_TIPO_PESSOA" , ""},
                    { "SINILT01_COD_LOT_FENAL" , ""},
                    { "SINILT01_COD_LOT_CEF" , ""},
                    { "SINILT01_COD_COBERTURA" , ""},
                    { "SIMOLOT1_VALOR_INFORMADO" , ""},
                    { "SIMOLOT1_VALOR_REGISTRADO" , ""},
                    { "SIMOLOT1_VAL_IS" , ""},
                    { "SIMOLOT1_DATA_AVISO" , ""},
                    { "SIMOLOT1_VAL_ADIANTAMENTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0869B_INDENIZACOES");
                AppSettings.TestSet.DynamicData.Add("SI0869B_INDENIZACOES", q1);

                #endregion

                #region SI0869B_RETENCOES

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "SINLOAB2_VALOR_RETENCAO" , ""},
                    { "SINLOAB2_VLR_RETENCAO_CALC" , ""},
                    { "SINLOAB2_IND_VLR_RETENCAO" , ""},
                    { "SINLOAB2_PERCENT_RETENCAO" , ""},
                    { "SINLOAB2_COD_RETENCAO" , ""},
                    { "SINLOAB2_QTD_SINISTRO_PAGO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0869B_RETENCOES");
                AppSettings.TestSet.DynamicData.Add("SI0869B_RETENCOES", q2);

                #endregion

                #region R105_BUSCA_SINISTRO_PREST_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "SIMOLOT1_NUM_SINI_PREST" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R105_BUSCA_SINISTRO_PREST_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R105_BUSCA_SINISTRO_PREST_DB_SELECT_1_Query1", q3);

                #endregion

                #region R110_CALCULA_PROX_DIA_UTIL_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R110_CALCULA_PROX_DIA_UTIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R110_CALCULA_PROX_DIA_UTIL_DB_SELECT_1_Query1", q4);

                #endregion

                #region R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                    { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                    { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                    { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                    { "MOVDEBCE_DATA_ENVIO" , ""},
                    { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1", q5);

                #endregion

                #region R130_VALOR_APURADO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_APURADO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R130_VALOR_APURADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R130_VALOR_APURADO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R135_VALOR_ESTORNADO_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_APURADO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R135_VALOR_ESTORNADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R135_VALOR_ESTORNADO_DB_SELECT_1_Query1", q7);

                #endregion

                #region SI0869B_LOTERICO

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "LOTERI01_DDD" , ""},
                    { "LOTERI01_NUM_FONE" , ""},
                    { "LOTERI01_DTTERVIG" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0869B_LOTERICO");
                AppSettings.TestSet.DynamicData.Add("SI0869B_LOTERICO", q8);

                #endregion

                #region R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_ADIANTAMENTO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1", q9);

                #endregion

                #region R200_VALOR_DIFERENCA_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_DIFERENCA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R200_VALOR_DIFERENCA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R200_VALOR_DIFERENCA_DB_SELECT_1_Query1", q10);

                #endregion

                #region R230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "GEOPERAC_DES_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1_Query1", q11);

                #endregion

                #region R240_MONTA_TIPO_ESTORNO_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "HOST_OPERACAO_EST" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R240_MONTA_TIPO_ESTORNO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R240_MONTA_TIPO_ESTORNO_DB_SELECT_1_Query1", q12);

                #endregion

                #endregion
                var program = new SI0869B();
                program.Execute(ARQ_SAIDA_FILE_NAME_P);

                var cruds = AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                var allDeletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE")).ToList();

                var total = AppSettings.TestSet.DynamicData.Count();

                //"Inserts": 0,
                //"Updates": 0,
                //"Deletes": 0,
                //"Selects": 10,
                //"Cursors": 3,
                //"Procedures": 0,
                //"All": 13

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0869B_t2")]
        public static void SI0869B_Tests_TheoryReturn99(string ARQ_SAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQ_SAIDA_FILE_NAME_P = $"{ARQ_SAIDA_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R010_LE_SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                    { "SISTEMAS_DATULT_PROCESSAMEN" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R010_LE_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0869B_INDENIZACOES

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                    { "SINISMES_NUM_APOLICE" , ""},
                    { "SINISMES_DATA_OCORRENCIA" , ""},
                    { "SINISMES_COD_CAUSA" , ""},
                    { "SINISCAU_DESCR_CAUSA" , ""},
                    { "SINISHIS_COD_OPERACAO" , ""},
                    { "SINISHIS_COD_PRODUTO" , ""},
                    { "SINISHIS_DATA_MOVIMENTO" , ""},
                    { "SINISHIS_OCORR_HISTORICO" , ""},
                    { "SINISHIS_VAL_OPERACAO" , ""},
                    { "SINISHIS_SIT_CONTABIL" , ""},
                    { "SINILT01_COD_CLIENTE" , ""},
                    { "CLIENTES_NOME_RAZAO" , ""},
                    { "CLIENTES_CGCCPF" , ""},
                    { "CLIENTES_TIPO_PESSOA" , ""},
                    { "SINILT01_COD_LOT_FENAL" , ""},
                    { "SINILT01_COD_LOT_CEF" , ""},
                    { "SINILT01_COD_COBERTURA" , ""},
                    { "SIMOLOT1_VALOR_INFORMADO" , ""},
                    { "SIMOLOT1_VALOR_REGISTRADO" , ""},
                    { "SIMOLOT1_VAL_IS" , ""},
                    { "SIMOLOT1_DATA_AVISO" , ""},
                    { "SIMOLOT1_VAL_ADIANTAMENTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0869B_INDENIZACOES");
                AppSettings.TestSet.DynamicData.Add("SI0869B_INDENIZACOES", q1);

                #endregion

                #region SI0869B_RETENCOES

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "SINLOAB2_VALOR_RETENCAO" , ""},
                    { "SINLOAB2_VLR_RETENCAO_CALC" , ""},
                    { "SINLOAB2_IND_VLR_RETENCAO" , ""},
                    { "SINLOAB2_PERCENT_RETENCAO" , ""},
                    { "SINLOAB2_COD_RETENCAO" , ""},
                    { "SINLOAB2_QTD_SINISTRO_PAGO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0869B_RETENCOES");
                AppSettings.TestSet.DynamicData.Add("SI0869B_RETENCOES", q2);

                #endregion

                #region R105_BUSCA_SINISTRO_PREST_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "SIMOLOT1_NUM_SINI_PREST" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R105_BUSCA_SINISTRO_PREST_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R105_BUSCA_SINISTRO_PREST_DB_SELECT_1_Query1", q3);

                #endregion

                #region R110_CALCULA_PROX_DIA_UTIL_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R110_CALCULA_PROX_DIA_UTIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R110_CALCULA_PROX_DIA_UTIL_DB_SELECT_1_Query1", q4);

                #endregion

                #region R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                    { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                    { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                    { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                    { "MOVDEBCE_DATA_ENVIO" , ""},
                    { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1", q5);

                #endregion

                #region R130_VALOR_APURADO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_APURADO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R130_VALOR_APURADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R130_VALOR_APURADO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R135_VALOR_ESTORNADO_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_APURADO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R135_VALOR_ESTORNADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R135_VALOR_ESTORNADO_DB_SELECT_1_Query1", q7);

                #endregion

                #region SI0869B_LOTERICO

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "LOTERI01_DDD" , ""},
                    { "LOTERI01_NUM_FONE" , ""},
                    { "LOTERI01_DTTERVIG" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0869B_LOTERICO");
                AppSettings.TestSet.DynamicData.Add("SI0869B_LOTERICO", q8);

                #endregion

                #region R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_ADIANTAMENTO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1", q9);

                #endregion

                #region R200_VALOR_DIFERENCA_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_DIFERENCA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R200_VALOR_DIFERENCA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R200_VALOR_DIFERENCA_DB_SELECT_1_Query1", q10);

                #endregion

                #region R230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "GEOPERAC_DES_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1_Query1", q11);

                #endregion

                #region R240_MONTA_TIPO_ESTORNO_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "HOST_OPERACAO_EST" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R240_MONTA_TIPO_ESTORNO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R240_MONTA_TIPO_ESTORNO_DB_SELECT_1_Query1", q12);

                #endregion

                #endregion
                var program = new SI0869B();
                program.Execute(ARQ_SAIDA_FILE_NAME_P);

                var cruds = AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                var allDeletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE")).ToList();

                var total = AppSettings.TestSet.DynamicData.Count();

                //"Inserts": 0,
                //"Updates": 0,
                //"Deletes": 0,
                //"Selects": 10,
                //"Cursors": 3,
                //"Procedures": 0,
                //"All": 13

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}