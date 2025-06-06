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
using static Code.CB0110B;

namespace FileTests.Test
{
    [Collection("CB0110B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class CB0110B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region CB0110B_CUR_FOLLOW_UP

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_FONTE" , "21"},
                { "ENDOSSOS_RAMO_EMISSOR" , "18"},
                { "APOLICES_COD_CLIENTE" , "30633335"},
                { "ENDOSSOS_OCORR_ENDERECO" , "1"},
                { "ENDOSSOS_COD_PRODUTO" , "1805"},
                { "ENDOSSOS_AGE_COBRANCA" , "2289"},
                { "FOLLOUP_NUM_APOLICE" , "101800269294"},
                { "FOLLOUP_NUM_ENDOSSO" , "809318"},
                { "FOLLOUP_NUM_PARCELA" , "11"},
                { "FOLLOUP_DATA_MOVIMENTO" , "2020-10-22"},
                { "FOLLOUP_HORA_OPERACAO" , "22:02:17"},
                { "FOLLOUP_VAL_OPERACAO" , "352.85"},
                { "FOLLOUP_AGE_AVISO" , "7999"},
                { "FOLLOUP_TIPO_SEGURO" , "1"},
                { "FOLLOUP_NUM_AVISO_CREDITO" , "914902767"},
                { "APOLCOBR_TIPO_COBRANCA" , "1"},
                { "PARCELAS_QTD_DOCUMENTOS" , "0"},
                { "AVISOSAL_SALDO_ATUAL" , "352.85"},
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_FONTE" , "21"},
                { "ENDOSSOS_RAMO_EMISSOR" , "18"},
                { "APOLICES_COD_CLIENTE" , "30633335"},
                { "ENDOSSOS_OCORR_ENDERECO" , "1"},
                { "ENDOSSOS_COD_PRODUTO" , "1805"},
                { "ENDOSSOS_AGE_COBRANCA" , "2289"},
                { "FOLLOUP_NUM_APOLICE" , "101800269294"},
                { "FOLLOUP_NUM_ENDOSSO" , "809318"},
                { "FOLLOUP_NUM_PARCELA" , "11"},
                { "FOLLOUP_DATA_MOVIMENTO" , "2020-10-22"},
                { "FOLLOUP_HORA_OPERACAO" , "22:02:17"},
                { "FOLLOUP_VAL_OPERACAO" , "352.85"},
                { "FOLLOUP_AGE_AVISO" , "7999"},
                { "FOLLOUP_TIPO_SEGURO" , "1"},
                { "FOLLOUP_NUM_AVISO_CREDITO" , "914902767"},
                { "APOLCOBR_TIPO_COBRANCA" , "1"},
                { "PARCELAS_QTD_DOCUMENTOS" , "0"},
                { "AVISOSAL_SALDO_ATUAL" , "352.85"},
            });
            AppSettings.TestSet.DynamicData.Add("CB0110B_CUR_FOLLOW_UP", q0);

            #endregion

            #region P10000_00_INICIO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("P10000_00_INICIO_DB_SELECT_1_Query1", q1);

            #endregion

            #region P10100_00_SELECT_CHEQUEMI_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "CHEQUEMI_NUM_CHEQUE_INTERNO" , "13716971"}
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "CHEQUEMI_NUM_CHEQUE_INTERNO" , "13716971"}
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "CHEQUEMI_NUM_CHEQUE_INTERNO" , "13716971"}
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "CHEQUEMI_NUM_CHEQUE_INTERNO" , "13716971"}
            });
            AppSettings.TestSet.DynamicData.Add("P10100_00_SELECT_CHEQUEMI_DB_SELECT_1_Query1", q2);

            #endregion

            #region P10200_00_SELECT_CBCONDEV_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_NUM_SEQUENCIA" , "380381"}
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_NUM_SEQUENCIA" , "380381"}
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_NUM_SEQUENCIA" , "380381"}
            });
            AppSettings.TestSet.DynamicData.Add("P10200_00_SELECT_CBCONDEV_DB_SELECT_1_Query1", q3);

            #endregion

            #region P22000_00_TRATA_REGISTRO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_OPER_CONTA_DEB" , "0"},
                { "MOVDEBCE_COD_AGENCIA_DEB" , "0"},
                { "MOVDEBCE_NUM_CONTA_DEB" , "0"},
                { "MOVDEBCE_DIG_CONTA_DEB" , "3"},
                { "MOVDEBCE_SITUACAO_COBRANCA" , "3"},
                { "MOVDEBCE_COD_RETORNO_CEF" , "0"},
                { "MOVDEBCE_VALOR_DEBITO" , "250.50"},
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_OPER_CONTA_DEB" , "0"},
                { "MOVDEBCE_COD_AGENCIA_DEB" , "0"},
                { "MOVDEBCE_NUM_CONTA_DEB" , "0"},
                { "MOVDEBCE_DIG_CONTA_DEB" , "3"},
                { "MOVDEBCE_SITUACAO_COBRANCA" , "3"},
                { "MOVDEBCE_COD_RETORNO_CEF" , "0"},
                { "MOVDEBCE_VALOR_DEBITO" , "250.50"},
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_OPER_CONTA_DEB" , "0"},
                { "MOVDEBCE_COD_AGENCIA_DEB" , "0"},
                { "MOVDEBCE_NUM_CONTA_DEB" , "0"},
                { "MOVDEBCE_DIG_CONTA_DEB" , "3"},
                { "MOVDEBCE_SITUACAO_COBRANCA" , "3"},
                { "MOVDEBCE_COD_RETORNO_CEF" , "0"},
                { "MOVDEBCE_VALOR_DEBITO" , "250.50"},
            });
            AppSettings.TestSet.DynamicData.Add("P22000_00_TRATA_REGISTRO_DB_SELECT_1_Query1", q4);

            #endregion

            #region P22100_00_SELECT_CLIENTES_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , "1"},
                { "CLIENTES_NOME_RAZAO" , "JOAO FORTES ENGENHARIA S/A              "},
                { "CLIENTES_TIPO_PESSOA" , "F"},
                { "CLIENTES_CGCCPF" , "06478013960"},
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , "1"},
                { "CLIENTES_NOME_RAZAO" , "JOAO FORTES ENGENHARIA S/A              "},
                { "CLIENTES_TIPO_PESSOA" , "F"},
                { "CLIENTES_CGCCPF" , "06478013960"},
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , "1"},
                { "CLIENTES_NOME_RAZAO" , "JOAO FORTES ENGENHARIA S/A              "},
                { "CLIENTES_TIPO_PESSOA" , "F"},
                { "CLIENTES_CGCCPF" , "06478013960"},
            });
            AppSettings.TestSet.DynamicData.Add("P22100_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q5);

            #endregion

            #region P22200_00_SELECT_ENDERECO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , "PRAIA DE BOTAFOGO N 228/18                                              "},
                { "ENDERECO_BAIRRO" , "BOTAFOGO                                                                "},
                { "ENDERECO_CIDADE" , "RIO DE JANEIRO                                                          "},
                { "ENDERECO_SIGLA_UF" , "RJ"},
                { "ENDERECO_CEP" , "22250000"},
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , "PRAIA DE BOTAFOGO N 228/18                                              "},
                { "ENDERECO_BAIRRO" , "BOTAFOGO                                                                "},
                { "ENDERECO_CIDADE" , "RIO DE JANEIRO                                                          "},
                { "ENDERECO_SIGLA_UF" , "RJ"},
                { "ENDERECO_CEP" , "22250000"},
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , "PRAIA DE BOTAFOGO N 228/18                                              "},
                { "ENDERECO_BAIRRO" , "BOTAFOGO                                                                "},
                { "ENDERECO_CIDADE" , "RIO DE JANEIRO                                                          "},
                { "ENDERECO_SIGLA_UF" , "RJ"},
                { "ENDERECO_CEP" , "22250000"},
            });
            AppSettings.TestSet.DynamicData.Add("P22200_00_SELECT_ENDERECO_DB_SELECT_1_Query1", q6);

            #endregion

            #region P22310_00_SELECT_GE381_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "GE381_COD_BCO" , ""},
                { "GE381_COD_AGENCIA" , ""},
                { "GE381_COD_AGENCIA_DV" , ""},
                { "GE381_COD_OPERACAO" , ""},
                { "GE381_NUM_CONTA" , ""},
                { "GE381_NUM_CONTA_DV1" , ""},
            });

            AppSettings.TestSet.DynamicData.Add("P22310_00_SELECT_GE381_DB_SELECT_1_Query1", q7);

            #endregion

            #region P22320_00_SELECT_AGENCCEF_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_COD_ESCNEG" , "1"},
                { "MALHACEF_COD_FONTE" , "2"},
            });
            q8.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_COD_ESCNEG" , "1"},
                { "MALHACEF_COD_FONTE" , "2"},
            });
            q8.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_COD_ESCNEG" , "1"},
                { "MALHACEF_COD_FONTE" , "2"},
            });
            q8.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_COD_ESCNEG" , "1"},
                { "MALHACEF_COD_FONTE" , "2"},
            });
            AppSettings.TestSet.DynamicData.Add("P22320_00_SELECT_AGENCCEF_DB_SELECT_1_Query1", q8);

            #endregion

            #region P22352_00_SELECT_CB040_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "CB040_NUM_OCORR_MOVTO" , "13952243"}
            });
            q9.AddDynamic(new Dictionary<string, string>{
                { "CB040_NUM_OCORR_MOVTO" , "13952243"}
            });
            q9.AddDynamic(new Dictionary<string, string>{
                { "CB040_NUM_OCORR_MOVTO" , "13952243"}
            });
            AppSettings.TestSet.DynamicData.Add("P22352_00_SELECT_CB040_DB_SELECT_1_Query1", q9);

            #endregion

            #region P22354_00_INCLUI_CBCONDEV_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_COD_EMPRESA" , ""},
                { "CBCONDEV_TIPO_MOVIMENTO" , ""},
                { "CBCONDEV_NUM_CHEQUE_INTERNO" , ""},
                { "CBCONDEV_DIG_CHEQUE_INTERNO" , ""},
                { "CBCONDEV_DATA_MOVIMENTO" , ""},
                { "CBCONDEV_NUM_SEQUENCIA" , ""},
                { "CBCONDEV_NUM_TITULO" , ""},
                { "CBCONDEV_COD_FONTE" , ""},
                { "CBCONDEV_NUM_RCAP" , ""},
                { "CBCONDEV_NUM_RCAP_COMPLEMEN" , ""},
                { "CBCONDEV_NUM_APOLICE" , ""},
                { "CBCONDEV_NUM_ENDOSSO" , ""},
                { "CBCONDEV_NUM_PARCELA" , ""},
                { "CBCONDEV_COD_SUBGRUPO" , ""},
                { "CBCONDEV_NUM_CERTIFICADO" , ""},
                { "CBCONDEV_DATA_OCORRENCIA" , ""},
                { "CBCONDEV_HORA_OPERACAO" , ""},
                { "CBCONDEV_NUM_MATRICULA" , ""},
                { "CBCONDEV_RAMO_EMISSOR" , ""},
                { "CBCONDEV_COD_PRODUTO" , ""},
                { "CBCONDEV_COD_FILIAL" , ""},
                { "CBCONDEV_COD_ESCNEG" , ""},
                { "CBCONDEV_AGE_COBRANCA" , ""},
                { "CBCONDEV_TIPO_FAVORECIDO" , ""},
                { "CBCONDEV_COD_FAVORECIDO" , ""},
                { "CBCONDEV_COD_ENDERECO" , ""},
                { "CBCONDEV_OCORR_ENDERECO" , ""},
                { "CBCONDEV_COD_AGENCIA" , ""},
                { "CBCONDEV_OPERACAO_CONTA" , ""},
                { "CBCONDEV_NUM_CONTA" , ""},
                { "CBCONDEV_DIG_CONTA" , ""},
                { "CBCONDEV_SIT_REGISTRO" , ""},
                { "CBCONDEV_DATA_QUITACAO" , ""},
                { "CBCONDEV_VAL_TITULO" , ""},
                { "CBCONDEV_VAL_DESCONTO" , ""},
                { "CBCONDEV_VAL_OPERACAO" , ""},
                { "CBCONDEV_COD_DESPESA" , ""},
                { "CBCONDEV_COD_DEVOLUCAO" , ""},
                { "CBCONDEV_COD_SISTEMA" , ""},
                { "CBCONDEV_COD_USU_SOLICITA" , ""},
                { "CBCONDEV_DATA_CANCELAMENTO" , ""},
                { "CBCONDEV_COD_USU_CANCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P22354_00_INCLUI_CBCONDEV_DB_INSERT_1_Insert1", q10);

            #endregion

            #region P22362_00_INCLUI_CHEQUEMI_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "CHEQUEMI_TIPO_MOVIMENTO" , ""},
                { "CHEQUEMI_COD_FONTE" , ""},
                { "CHEQUEMI_NUM_DOCUMENTO" , ""},
                { "CHEQUEMI_NOME_FAVORECIDO" , ""},
                { "CHEQUEMI_VAL_CHEQUE" , ""},
                { "CHEQUEMI_DATA_MOVIMENTO" , ""},
                { "CHEQUEMI_DATA_EMISSAO" , ""},
                { "CHEQUEMI_NUM_CHEQUE_INTERNO" , ""},
                { "CHEQUEMI_DIG_CHEQUE_INTERNO" , ""},
                { "CHEQUEMI_SIT_REGISTRO" , ""},
                { "CHEQUEMI_TIPO_PAGAMENTO" , ""},
                { "CHEQUEMI_DATA_COMPETENCIA" , ""},
                { "CHEQUEMI_PRACA_PAGAMENTO" , ""},
                { "CHEQUEMI_NUM_RECIBO" , ""},
                { "CHEQUEMI_OCORR_HISTORICO" , ""},
                { "CHEQUEMI_COD_OPERACAO" , ""},
                { "CHEQUEMI_COD_DESPESA" , ""},
                { "CHEQUEMI_VAL_IRF" , ""},
                { "CHEQUEMI_VAL_ISS" , ""},
                { "CHEQUEMI_VAL_IAPAS" , ""},
                { "CHEQUEMI_COD_LANCAMENTO" , ""},
                { "CHEQUEMI_DATA_LANCAMENTO" , ""},
                { "CHEQUEMI_COD_EMPRESA" , ""},
                { "CHEQUEMI_COD_FAVORECIDO" , ""},
                { "CHEQUEMI_VAL_INSS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P22362_00_INCLUI_CHEQUEMI_DB_INSERT_1_Insert1", q11);

            #endregion

            #region P22363_00_INCLUI_HISTOCHE_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "HISTOCHE_NUM_CHEQUE_INTERNO" , ""},
                { "HISTOCHE_DIG_CHEQUE_INTERNO" , ""},
                { "HISTOCHE_DATA_MOVIMENTO" , ""},
                { "HISTOCHE_COD_OPERACAO" , ""},
                { "HISTOCHE_COD_EMPRESA" , ""},
                { "HISTOCHE_DATA_COMPENSACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P22363_00_INCLUI_HISTOCHE_DB_INSERT_1_Insert1", q12);

            #endregion

            #region P22400_00_ATUALIZACOES_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "FOLLOUP_DATA_LIBERACAO" , ""},
                { "FOLLOUP_SIT_REGISTRO" , ""},
                { "FOLLOUP_COD_OPERACAO" , ""},
                { "FOLLOUP_DATA_MOVIMENTO" , ""},
                { "FOLLOUP_HORA_OPERACAO" , ""},
                { "FOLLOUP_NUM_APOLICE" , ""},
                { "FOLLOUP_NUM_ENDOSSO" , ""},
                { "FOLLOUP_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P22400_00_ATUALIZACOES_DB_UPDATE_1_Update1", q13);

            #endregion

            #region P22400_00_ATUALIZACOES_DB_UPDATE_2_Update1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_QTD_DOCUMENTOS" , ""},
                { "FOLLOUP_NUM_APOLICE" , ""},
                { "FOLLOUP_NUM_ENDOSSO" , ""},
                { "FOLLOUP_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P22400_00_ATUALIZACOES_DB_UPDATE_2_Update1", q14);

            #endregion

            #region P22400_00_ATUALIZACOES_DB_UPDATE_3_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "AVISOSAL_SALDO_ATUAL" , ""},
                { "FOLLOUP_NUM_AVISO_CREDITO" , ""},
                { "FOLLOUP_TIPO_SEGURO" , ""},
                { "FOLLOUP_AGE_AVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P22400_00_ATUALIZACOES_DB_UPDATE_3_Update1", q15);

            #endregion


            #endregion

            #region Execute_DB_SELECT_1_Query1

            var q100 = new DynamicData();
            q100.AddDynamic(new Dictionary<string, string>{
                { "HOST_CURRENT_DATE" , "2024-10-25"},
                { "HOST_CURRENT_TIMESTAMP" , "2024-10-25 12:51:10.699"},
            });
            q100.AddDynamic(new Dictionary<string, string>{
                { "HOST_CURRENT_DATE" , "2024-10-25"},
                { "HOST_CURRENT_TIMESTAMP" , "2024-10-25 12:51:10.699"},
            });
            q100.AddDynamic(new Dictionary<string, string>{
                { "HOST_CURRENT_DATE" , "2024-10-25"},
                { "HOST_CURRENT_TIMESTAMP" , "2024-10-25 12:51:10.699"},
            });
            q100.AddDynamic(new Dictionary<string, string>{
                { "HOST_CURRENT_DATE" , "2024-10-25"},
                { "HOST_CURRENT_TIMESTAMP" , "2024-10-25 12:51:10.699"},
            });
            q100.AddDynamic(new Dictionary<string, string>{
                { "HOST_CURRENT_DATE" , "2024-10-25"},
                { "HOST_CURRENT_TIMESTAMP" , "2024-10-25 12:51:10.699"},
            });
            q100.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"},
                { "" , ""},
            });

            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q100);

            #endregion

            GE0500B_Tests.Load_Parameters();
            GE0501B_Tests.Load_Parameters();
            GE0502B_Tests.Load_Parameters();
            GE0503B_Tests.Load_Parameters();
            GE0550B_Tests.Load_Parameters();
        }

        [Theory]
        [InlineData("CB0110S01_FILE_NAME_P")]
        public static void CB0110B_Tests_Theory_Fluxo1PJ(string CB0110S01_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CB0110S01_FILE_NAME_P = $"{CB0110S01_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region P22100_00_SELECT_CLIENTES_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , "659"},
                { "CLIENTES_NOME_RAZAO" , "AAAAAAAAAA"},
                { "CLIENTES_TIPO_PESSOA" , "J"},
                { "CLIENTES_CGCCPF" , "12414256000105"},
            });
                q5.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , "659"},
                { "CLIENTES_NOME_RAZAO" , "AAAAAAAAAA                                            "},
                { "CLIENTES_TIPO_PESSOA" , "J"},
                { "CLIENTES_CGCCPF" , "12414256000105"},
            });
                q5.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , "1"},
                { "CLIENTES_NOME_RAZAO" , "AAAAAAAAAA                                            "},
                { "CLIENTES_TIPO_PESSOA" , "J"},
                { "CLIENTES_CGCCPF" , "12414256000105"},
            });
                AppSettings.TestSet.DynamicData.Remove("P22100_00_SELECT_CLIENTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P22100_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q5);

                #endregion


                #endregion
                var program = new CB0110B();
                program.Execute(CB0110S01_FILE_NAME_P);

                Assert.True(program.LK_PJ_PARAMETRO.LK_PJ_NUM_PESSOA == 1);

                Assert.True(program.RETURN_CODE == 00);

                Assert.True(program.LK_PF_PARAMETRO.LK_PF_NUM_PESSOA == 0);
                Assert.True(program.LK_LEGADO_PARAMETRO.LK_HORA_OPERACAO == "22:02:17");

                //R100_INSERT_ENDERECO_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["R100_INSERT_ENDERECO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList?.Count > 1);


                //P22354_00_INCLUI_CBCONDEV_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["P22354_00_INCLUI_CBCONDEV_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1?.Count > 1);

                //P22400_00_ATUALIZACOES_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["P22400_00_ATUALIZACOES_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("FOLLOUP_DATA_LIBERACAO", out var val7r) && val7r.Contains("2020-01-01"));

                //R0910_00_INSERT_GE366_DB_INSERT_1_Insert1
                var envList3 = AppSettings.TestSet.DynamicData["R0910_00_INSERT_GE366_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3?.Count > 1);
                Assert.True(envList3[1].TryGetValue("GE366_IDE_SISTEMA", out var val8r) && val8r.Contains("CB"));
                
            }
        }



        [Theory]
        [InlineData("CB0110S01_FILE_NAME_P")]
        public static void CB0110B_Tests_Theory_Fluxo1ComSUB99(string CB0110S01_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CB0110S01_FILE_NAME_P = $"{CB0110S01_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new CB0110B();
                program.Execute(CB0110S01_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);

                Assert.True(program.LK_PF_PARAMETRO.LK_PF_NUM_PESSOA == 0);

                //var envList = AppSettings.TestSet.DynamicData["R100_INSERT_PF_DB_SELECT_1_Query1"].DynamicList;
                //Assert.True(envList?.Count > 1);
                //Assert.True(envList[1].TryGetValue("OD001_NUM_PESSOA", out var val7r) && val7r.Contains("2"));
            }
        }

        [Theory]
        [InlineData("CB0110S01_FILE_NAME_P")]
        public static void CB0110B_Tests_Theory_Fluxo1ComTIPOCOBRANCA2(string CB0110S01_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CB0110S01_FILE_NAME_P = $"{CB0110S01_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region CB0110B_CUR_FOLLOW_UP

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_FONTE" , "21"},
                { "ENDOSSOS_RAMO_EMISSOR" , "18"},
                { "APOLICES_COD_CLIENTE" , "30633335"},
                { "ENDOSSOS_OCORR_ENDERECO" , "1"},
                { "ENDOSSOS_COD_PRODUTO" , "1805"},
                { "ENDOSSOS_AGE_COBRANCA" , "2289"},
                { "FOLLOUP_NUM_APOLICE" , "101800269294"},
                { "FOLLOUP_NUM_ENDOSSO" , "809318"},
                { "FOLLOUP_NUM_PARCELA" , "11"},
                { "FOLLOUP_DATA_MOVIMENTO" , "2020-10-22"},
                { "FOLLOUP_HORA_OPERACAO" , "22:02:17"},
                { "FOLLOUP_VAL_OPERACAO" , "352.85"},
                { "FOLLOUP_AGE_AVISO" , "7999"},
                { "FOLLOUP_TIPO_SEGURO" , "1"},
                { "FOLLOUP_NUM_AVISO_CREDITO" , "914902767"},
                { "APOLCOBR_TIPO_COBRANCA" , "2"},
                { "PARCELAS_QTD_DOCUMENTOS" , "0"},
                { "AVISOSAL_SALDO_ATUAL" , "352.85"},
            });
                q0.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_FONTE" , "21"},
                { "ENDOSSOS_RAMO_EMISSOR" , "18"},
                { "APOLICES_COD_CLIENTE" , "30633335"},
                { "ENDOSSOS_OCORR_ENDERECO" , "1"},
                { "ENDOSSOS_COD_PRODUTO" , "1805"},
                { "ENDOSSOS_AGE_COBRANCA" , "2289"},
                { "FOLLOUP_NUM_APOLICE" , "101800269294"},
                { "FOLLOUP_NUM_ENDOSSO" , "809318"},
                { "FOLLOUP_NUM_PARCELA" , "11"},
                { "FOLLOUP_DATA_MOVIMENTO" , "2020-10-22"},
                { "FOLLOUP_HORA_OPERACAO" , "22:02:17"},
                { "FOLLOUP_VAL_OPERACAO" , "352.85"},
                { "FOLLOUP_AGE_AVISO" , "7999"},
                { "FOLLOUP_TIPO_SEGURO" , "1"},
                { "FOLLOUP_NUM_AVISO_CREDITO" , "914902767"},
                { "APOLCOBR_TIPO_COBRANCA" , "2"},
                { "PARCELAS_QTD_DOCUMENTOS" , "0"},
                { "AVISOSAL_SALDO_ATUAL" , "352.85"},
            });
                AppSettings.TestSet.DynamicData.Remove("CB0110B_CUR_FOLLOW_UP");
                AppSettings.TestSet.DynamicData.Add("CB0110B_CUR_FOLLOW_UP", q0);

                #endregion
                #endregion
                var program = new CB0110B();
                program.Execute(CB0110S01_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 00);

                Assert.True(program.FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE == 101800269294);

                //var envList = AppSettings.TestSet.DynamicData["R100_INSERT_PF_DB_SELECT_1_Query1"].DynamicList;
                //Assert.True(envList?.Count > 1);
                //Assert.True(envList[1].TryGetValue("OD001_NUM_PESSOA", out var val7r) && val7r.Contains("2"));
            }
        }
        [Theory]
        [InlineData("CB0110S01_FILE_NAME_P")]
        public static void CB0110B_Tests_Theory_Fluxo2(string CB0110S01_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CB0110S01_FILE_NAME_P = $"{CB0110S01_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region P22000_00_TRATA_REGISTRO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_OPER_CONTA_DEB" , "3"},
                { "MOVDEBCE_COD_AGENCIA_DEB" , "16"},
                { "MOVDEBCE_NUM_CONTA_DEB" , "4944"},
                { "MOVDEBCE_DIG_CONTA_DEB" , "3"},
                { "MOVDEBCE_SITUACAO_COBRANCA" , "3"},
                { "MOVDEBCE_COD_RETORNO_CEF" , "18"},
                { "MOVDEBCE_VALOR_DEBITO" , "250.50"},
            });
                q4.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_OPER_CONTA_DEB" , "3"},
                { "MOVDEBCE_COD_AGENCIA_DEB" , "16"},
                { "MOVDEBCE_NUM_CONTA_DEB" , "4944"},
                { "MOVDEBCE_DIG_CONTA_DEB" , "3"},
                { "MOVDEBCE_SITUACAO_COBRANCA" , "3"},
                { "MOVDEBCE_COD_RETORNO_CEF" , "18"},
                { "MOVDEBCE_VALOR_DEBITO" , "250.50"},
            });
                q4.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_OPER_CONTA_DEB" , "3"},
                { "MOVDEBCE_COD_AGENCIA_DEB" , "16"},
                { "MOVDEBCE_NUM_CONTA_DEB" , "4944"},
                { "MOVDEBCE_DIG_CONTA_DEB" , "3"},
                { "MOVDEBCE_SITUACAO_COBRANCA" , "3"},
                { "MOVDEBCE_COD_RETORNO_CEF" , "18"},
                { "MOVDEBCE_VALOR_DEBITO" , "250.50"},
            });
                AppSettings.TestSet.DynamicData.Remove("P22000_00_TRATA_REGISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P22000_00_TRATA_REGISTRO_DB_SELECT_1_Query1", q4);

                #endregion
                #endregion
                var program = new CB0110B();
                program.Execute(CB0110S01_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 00);

                Assert.True(program.FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE == 101800269294);

            }
        }
    }
}