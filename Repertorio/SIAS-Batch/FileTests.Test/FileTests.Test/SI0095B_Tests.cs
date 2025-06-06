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
using static Code.SI0095B;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0095B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0095B_Tests
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

            #region SI0095B_INDENIZACOES

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
            AppSettings.TestSet.DynamicData.Add("SI0095B_INDENIZACOES", q1);

            #endregion

            #region SI0095B_LOTERICO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "LOTERI01_ENDERECO" , ""},
                { "LOTERI01_COMPL_ENDERECO" , ""},
                { "LOTERI01_BAIRRO" , ""},
                { "LOTERI01_CEP" , ""},
                { "LOTERI01_CIDADE" , ""},
                { "LOTERI01_SIGLA_UF" , ""},
                { "LOTERI01_AGENCIA" , ""},
                { "LOTERI01_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0095B_LOTERICO", q2);

            #endregion

            #region R110_ACESSA_OPERACAO_SICOV_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "HOST_COD_OPERACAO_SICOV" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R110_ACESSA_OPERACAO_SICOV_DB_SELECT_1_Query1", q3);

            #endregion

            #region R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_DATA_MOVIMENTO" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1", q4);

            #endregion

            #region R130_VALOR_APURADO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR_APURADO" , ""},
                { "HOST_DATA_VALOR_APURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R130_VALOR_APURADO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R140_VALOR_FRANQUIA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR_FRANQUIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R140_VALOR_FRANQUIA_DB_SELECT_1_Query1", q6);

            #endregion

            #region R150_VALOR_REINTEG_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR_REINTEG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R150_VALOR_REINTEG_DB_SELECT_1_Query1", q7);

            #endregion

            #region R160_VALOR_IOF_REINTEG_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR_IOF_REINTEG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R160_VALOR_IOF_REINTEG_DB_SELECT_1_Query1", q8);

            #endregion

            #region R170_VALOR_AGRAV_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR_AGRAV" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R170_VALOR_AGRAV_DB_SELECT_1_Query1", q9);

            #endregion

            #region R180_VALOR_IOF_AGRAV_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR_IOF_AGRAV" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R180_VALOR_IOF_AGRAV_DB_SELECT_1_Query1", q10);

            #endregion

            #region R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR_ADIANTAMENTO" , ""},
                { "HOST_DATA_ADIANTAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1", q11);

            #endregion

            #region R200_VALOR_DIFERENCA_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "HOST_VALOR_DIFERENCA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R200_VALOR_DIFERENCA_DB_SELECT_1_Query1", q12);

            #endregion

            #region R220_BUSCA_DATA_AVISO_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "HOST_DATA_MOVIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R220_BUSCA_DATA_AVISO_DB_SELECT_1_Query1", q13);

            #endregion

            #region R1010_ACESSA_CHEQUE_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "CHEQUEMI_NUM_CHEQUE_INTERNO" , ""},
                { "CHEQUEMI_DIG_CHEQUE_INTERNO" , ""},
                { "LOTECHEQ_COD_BANCO" , ""},
                { "LOTECHEQ_COD_AGENCIA" , ""},
                { "LOTECHEQ_NUM_CHEQUE" , ""},
                { "LOTECHEQ_SERIE_CHEQUE" , ""},
                { "LOTECHEQ_DIG_CHEQUE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1010_ACESSA_CHEQUE_DB_SELECT_1_Query1", q14);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0095B_OUTPUT_202504090000")]
        public static void SI0095B_Tests_Theory(string SI0090M1_FILE_NAME_P)
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
                #region R010_LE_SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                    { "SISTEMAS_DATULT_PROCESSAMEN" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R010_LE_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0095B_INDENIZACOES

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
                AppSettings.TestSet.DynamicData.Remove("SI0095B_INDENIZACOES");
                AppSettings.TestSet.DynamicData.Add("SI0095B_INDENIZACOES", q1);

                #endregion

                #region SI0095B_LOTERICO

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "LOTERI01_ENDERECO" , ""},
                    { "LOTERI01_COMPL_ENDERECO" , ""},
                    { "LOTERI01_BAIRRO" , ""},
                    { "LOTERI01_CEP" , ""},
                    { "LOTERI01_CIDADE" , ""},
                    { "LOTERI01_SIGLA_UF" , ""},
                    { "LOTERI01_AGENCIA" , ""},
                    { "LOTERI01_DTTERVIG" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0095B_LOTERICO");
                AppSettings.TestSet.DynamicData.Add("SI0095B_LOTERICO", q2);

                #endregion

                #region R110_ACESSA_OPERACAO_SICOV_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "HOST_COD_OPERACAO_SICOV" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R110_ACESSA_OPERACAO_SICOV_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R110_ACESSA_OPERACAO_SICOV_DB_SELECT_1_Query1", q3);

                #endregion

                #region R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                    { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                    { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                    { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                    { "MOVDEBCE_DATA_MOVIMENTO" , ""},
                    { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1", q4);

                #endregion

                #region R130_VALOR_APURADO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_APURADO" , ""},
                    { "HOST_DATA_VALOR_APURADO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R130_VALOR_APURADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R130_VALOR_APURADO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R140_VALOR_FRANQUIA_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_FRANQUIA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R140_VALOR_FRANQUIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R140_VALOR_FRANQUIA_DB_SELECT_1_Query1", q6);

                #endregion

                #region R150_VALOR_REINTEG_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_REINTEG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R150_VALOR_REINTEG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R150_VALOR_REINTEG_DB_SELECT_1_Query1", q7);

                #endregion

                #region R160_VALOR_IOF_REINTEG_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_IOF_REINTEG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R160_VALOR_IOF_REINTEG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R160_VALOR_IOF_REINTEG_DB_SELECT_1_Query1", q8);

                #endregion

                #region R170_VALOR_AGRAV_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_AGRAV" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R170_VALOR_AGRAV_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R170_VALOR_AGRAV_DB_SELECT_1_Query1", q9);

                #endregion

                #region R180_VALOR_IOF_AGRAV_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_IOF_AGRAV" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R180_VALOR_IOF_AGRAV_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R180_VALOR_IOF_AGRAV_DB_SELECT_1_Query1", q10);

                #endregion

                #region R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_ADIANTAMENTO" , ""},
                    { "HOST_DATA_ADIANTAMENTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1", q11);

                #endregion

                #region R200_VALOR_DIFERENCA_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_DIFERENCA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R200_VALOR_DIFERENCA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R200_VALOR_DIFERENCA_DB_SELECT_1_Query1", q12);

                #endregion

                #region R220_BUSCA_DATA_AVISO_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "HOST_DATA_MOVIMENTO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R220_BUSCA_DATA_AVISO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R220_BUSCA_DATA_AVISO_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1010_ACESSA_CHEQUE_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "CHEQUEMI_NUM_CHEQUE_INTERNO" , ""},
                    { "CHEQUEMI_DIG_CHEQUE_INTERNO" , ""},
                    { "LOTECHEQ_COD_BANCO" , ""},
                    { "LOTECHEQ_COD_AGENCIA" , ""},
                    { "LOTECHEQ_NUM_CHEQUE" , ""},
                    { "LOTECHEQ_SERIE_CHEQUE" , ""},
                    { "LOTECHEQ_DIG_CHEQUE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1010_ACESSA_CHEQUE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1010_ACESSA_CHEQUE_DB_SELECT_1_Query1", q14);

                #endregion

                #endregion
                #endregion
                var program = new SI0095B();
                program.Execute(SI0090M1_FILE_NAME_P);

                Assert.True(File.Exists(program.SI0090M1.FilePath));
                Assert.True(new FileInfo(program.SI0090M1.FilePath).Length > 0);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0095B_OUTPUT_202504090001")]
        public static void SI0095B_Tests_Theory_ReturnCode99(string SI0090M1_FILE_NAME_P)
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
                #region R010_LE_SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                    { "SISTEMAS_DATULT_PROCESSAMEN" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R010_LE_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0095B_INDENIZACOES

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
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("SI0095B_INDENIZACOES");
                AppSettings.TestSet.DynamicData.Add("SI0095B_INDENIZACOES", q1);

                #endregion

                #region SI0095B_LOTERICO

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "LOTERI01_ENDERECO" , ""},
                    { "LOTERI01_COMPL_ENDERECO" , ""},
                    { "LOTERI01_BAIRRO" , ""},
                    { "LOTERI01_CEP" , ""},
                    { "LOTERI01_CIDADE" , ""},
                    { "LOTERI01_SIGLA_UF" , ""},
                    { "LOTERI01_AGENCIA" , ""},
                    { "LOTERI01_DTTERVIG" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0095B_LOTERICO");
                AppSettings.TestSet.DynamicData.Add("SI0095B_LOTERICO", q2);

                #endregion

                #region R110_ACESSA_OPERACAO_SICOV_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "HOST_COD_OPERACAO_SICOV" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R110_ACESSA_OPERACAO_SICOV_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R110_ACESSA_OPERACAO_SICOV_DB_SELECT_1_Query1", q3);

                #endregion

                #region R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                    { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                    { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                    { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                    { "MOVDEBCE_DATA_MOVIMENTO" , ""},
                    { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1", q4);

                #endregion

                #region R130_VALOR_APURADO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_APURADO" , ""},
                    { "HOST_DATA_VALOR_APURADO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R130_VALOR_APURADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R130_VALOR_APURADO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R140_VALOR_FRANQUIA_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_FRANQUIA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R140_VALOR_FRANQUIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R140_VALOR_FRANQUIA_DB_SELECT_1_Query1", q6);

                #endregion

                #region R150_VALOR_REINTEG_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_REINTEG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R150_VALOR_REINTEG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R150_VALOR_REINTEG_DB_SELECT_1_Query1", q7);

                #endregion

                #region R160_VALOR_IOF_REINTEG_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_IOF_REINTEG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R160_VALOR_IOF_REINTEG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R160_VALOR_IOF_REINTEG_DB_SELECT_1_Query1", q8);

                #endregion

                #region R170_VALOR_AGRAV_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_AGRAV" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R170_VALOR_AGRAV_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R170_VALOR_AGRAV_DB_SELECT_1_Query1", q9);

                #endregion

                #region R180_VALOR_IOF_AGRAV_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_IOF_AGRAV" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R180_VALOR_IOF_AGRAV_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R180_VALOR_IOF_AGRAV_DB_SELECT_1_Query1", q10);

                #endregion

                #region R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_ADIANTAMENTO" , ""},
                    { "HOST_DATA_ADIANTAMENTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1", q11);

                #endregion

                #region R200_VALOR_DIFERENCA_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VALOR_DIFERENCA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R200_VALOR_DIFERENCA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R200_VALOR_DIFERENCA_DB_SELECT_1_Query1", q12);

                #endregion

                #region R220_BUSCA_DATA_AVISO_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "HOST_DATA_MOVIMENTO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R220_BUSCA_DATA_AVISO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R220_BUSCA_DATA_AVISO_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1010_ACESSA_CHEQUE_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "CHEQUEMI_NUM_CHEQUE_INTERNO" , ""},
                    { "CHEQUEMI_DIG_CHEQUE_INTERNO" , ""},
                    { "LOTECHEQ_COD_BANCO" , ""},
                    { "LOTECHEQ_COD_AGENCIA" , ""},
                    { "LOTECHEQ_NUM_CHEQUE" , ""},
                    { "LOTECHEQ_SERIE_CHEQUE" , ""},
                    { "LOTECHEQ_DIG_CHEQUE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1010_ACESSA_CHEQUE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1010_ACESSA_CHEQUE_DB_SELECT_1_Query1", q14);

                #endregion

                #endregion
                #endregion
                var program = new SI0095B();
                program.Execute(SI0090M1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}