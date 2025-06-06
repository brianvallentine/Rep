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
using static Code.BI6253B;

namespace FileTests.Test
{
    [Collection("BI6253B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI6253B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region BI6253B_V0MOVIMCOB

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , ""},
                { "MOVIMCOB_COD_MOVIMENTO" , ""},
                { "MOVIMCOB_COD_BANCO" , ""},
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "MOVIMCOB_NUM_FITA" , ""},
                { "MOVIMCOB_DATA_MOVIMENTO" , ""},
                { "MOVIMCOB_DATA_QUITACAO" , ""},
                { "MOVIMCOB_NUM_TITULO" , ""},
                { "MOVIMCOB_NUM_APOLICE" , ""},
                { "MOVIMCOB_NUM_ENDOSSO" , ""},
                { "MOVIMCOB_NUM_PARCELA" , ""},
                { "MOVIMCOB_VAL_TITULO" , ""},
                { "MOVIMCOB_VAL_CREDITO" , ""},
                { "MOVIMCOB_SIT_REGISTRO" , ""},
                { "MOVIMCOB_NOME_SEGURADO" , ""},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , ""},
                { "MOVIMCOB_TIPO_MOVIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI6253B_V0MOVIMCOB", q1);

            #endregion

            #region R0360_00_SELECT_BILHETE_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "CONVERSI_NUM_PROPOSTA_SIVPF" , ""},
                { "CONVERSI_COD_PRODUTO_SIVPF" , ""},
                { "BILHETE_NUM_BILHETE" , ""},
                { "BILHETE_NUM_APOLICE" , ""},
                { "BILHETE_FONTE" , ""},
                { "BILHETE_AGE_COBRANCA" , ""},
                { "BILHETE_NUM_MATRICULA" , ""},
                { "BILHETE_COD_AGENCIA" , ""},
                { "BILHETE_OPERACAO_CONTA" , ""},
                { "BILHETE_NUM_CONTA" , ""},
                { "BILHETE_DIG_CONTA" , ""},
                { "BILHETE_COD_CLIENTE" , ""},
                { "BILHETE_OCORR_ENDERECO" , ""},
                { "BILHETE_COD_AGENCIA_DEB" , ""},
                { "BILHETE_OPERACAO_CONTA_DEB" , ""},
                { "BILHETE_NUM_CONTA_DEB" , ""},
                { "BILHETE_DIG_CONTA_DEB" , ""},
                { "BILHETE_OPC_COBERTURA" , ""},
                { "BILHETE_DATA_QUITACAO" , ""},
                { "BILHETE_VAL_RCAP" , ""},
                { "BILHETE_RAMO" , ""},
                { "BILHETE_DATA_VENDA" , ""},
                { "BILHETE_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0360_00_SELECT_BILHETE_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0370_00_SELECT_PARCELAS_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_SIT_REGISTRO" , ""},
                { "PARCELAS_OCORR_HISTORICO" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0370_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0530_00_SELECT_AVISOCRE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_NUM_AVISO_CREDITO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0530_00_SELECT_AVISOCRE_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1150_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_OCORR_HISTORICO" , ""},
                { "PARCELAS_SIT_REGISTRO" , ""},
                { "PARCELAS_NUM_APOLICE" , ""},
                { "PARCELAS_NUM_ENDOSSO" , ""},
                { "PARCELAS_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1150_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R1200_00_SELECT_PARCEHIS_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_DAC_PARCELA" , ""},
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "PARCEHIS_PRM_TARIFARIO" , ""},
                { "PARCEHIS_VAL_DESCONTO" , ""},
                { "PARCEHIS_PRM_LIQUIDO" , ""},
                { "PARCEHIS_ADICIONAL_FRACIO" , ""},
                { "PARCEHIS_VAL_CUSTO_EMISSAO" , ""},
                { "PARCEHIS_VAL_IOCC" , ""},
                { "PARCEHIS_PRM_TOTAL" , ""},
                { "PARCEHIS_DATA_VENCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_PARCEHIS_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1250_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_DAC_PARCELA" , ""},
                { "PARCEHIS_DATA_MOVIMENTO" , ""},
                { "PARCEHIS_COD_OPERACAO" , ""},
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "PARCEHIS_PRM_TARIFARIO" , ""},
                { "PARCEHIS_VAL_DESCONTO" , ""},
                { "PARCEHIS_PRM_LIQUIDO" , ""},
                { "PARCEHIS_ADICIONAL_FRACIO" , ""},
                { "PARCEHIS_VAL_CUSTO_EMISSAO" , ""},
                { "PARCEHIS_VAL_IOCC" , ""},
                { "PARCEHIS_PRM_TOTAL" , ""},
                { "PARCEHIS_VAL_OPERACAO" , ""},
                { "PARCEHIS_DATA_VENCIMENTO" , ""},
                { "PARCEHIS_BCO_COBRANCA" , ""},
                { "PARCEHIS_AGE_COBRANCA" , ""},
                { "PARCEHIS_NUM_AVISO_CREDITO" , ""},
                { "PARCEHIS_ENDOS_CANCELA" , ""},
                { "PARCEHIS_SIT_CONTABIL" , ""},
                { "PARCEHIS_COD_USUARIO" , ""},
                { "PARCEHIS_RENUM_DOCUMENTO" , ""},
                { "PARCEHIS_DATA_QUITACAO" , ""},
                { "PARCEHIS_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1250_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_NUM_PARCELA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1350_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_SIT_REGISTRO" , ""},
                { "PARCELAS_NUM_APOLICE" , ""},
                { "PARCELAS_NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1350_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1", q9);

            #endregion

            #region R1520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1530_00_SELECT_PROPOSTA_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1530_00_SELECT_PROPOSTA_DB_SELECT_1_Query1", q11);

            #endregion

            #region R2100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "FOLLOUP_NUM_APOLICE" , ""},
                { "FOLLOUP_NUM_ENDOSSO" , ""},
                { "FOLLOUP_NUM_PARCELA" , ""},
                { "FOLLOUP_DAC_PARCELA" , ""},
                { "FOLLOUP_DATA_MOVIMENTO" , ""},
                { "FOLLOUP_HORA_OPERACAO" , ""},
                { "FOLLOUP_VAL_OPERACAO" , ""},
                { "FOLLOUP_BCO_AVISO" , ""},
                { "FOLLOUP_AGE_AVISO" , ""},
                { "FOLLOUP_NUM_AVISO_CREDITO" , ""},
                { "FOLLOUP_COD_BAIXA_PARCELA" , ""},
                { "FOLLOUP_COD_ERRO01" , ""},
                { "FOLLOUP_COD_ERRO02" , ""},
                { "FOLLOUP_COD_ERRO03" , ""},
                { "FOLLOUP_COD_ERRO04" , ""},
                { "FOLLOUP_COD_ERRO05" , ""},
                { "FOLLOUP_COD_ERRO06" , ""},
                { "FOLLOUP_SIT_REGISTRO" , ""},
                { "FOLLOUP_SIT_CONTABIL" , ""},
                { "FOLLOUP_COD_OPERACAO" , ""},
                { "FOLLOUP_DATA_LIBERACAO" , ""},
                { "FOLLOUP_DATA_QUITACAO" , ""},
                { "FOLLOUP_COD_EMPRESA" , ""},
                { "FOLLOUP_ORDEM_LIDER" , ""},
                { "FOLLOUP_TIPO_SEGURO" , ""},
                { "FOLLOUP_NUM_APOL_LIDER" , ""},
                { "FOLLOUP_ENDOS_LIDER" , ""},
                { "FOLLOUP_COD_LIDER" , ""},
                { "FOLLOUP_COD_FONTE" , ""},
                { "FOLLOUP_NUM_RCAP" , ""},
                { "FOLLOUP_NUM_NOSSO_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1", q12);

            #endregion

            #region R5100_00_INSERT_AVISOCRE_DB_INSERT_1_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_BCO_AVISO" , ""},
                { "AVISOCRE_AGE_AVISO" , ""},
                { "AVISOCRE_NUM_AVISO_CREDITO" , ""},
                { "AVISOCRE_NUM_SEQUENCIA" , ""},
                { "AVISOCRE_DATA_MOVIMENTO" , ""},
                { "AVISOCRE_COD_OPERACAO" , ""},
                { "AVISOCRE_TIPO_AVISO" , ""},
                { "AVISOCRE_DATA_AVISO" , ""},
                { "AVISOCRE_VAL_IOCC" , ""},
                { "AVISOCRE_VAL_DESPESA" , ""},
                { "AVISOCRE_PRM_COSSEGURO_CED" , ""},
                { "AVISOCRE_PRM_LIQUIDO" , ""},
                { "AVISOCRE_PRM_TOTAL" , ""},
                { "AVISOCRE_SIT_CONTABIL" , ""},
                { "AVISOCRE_COD_EMPRESA" , ""},
                { "AVISOCRE_ORIGEM_AVISO" , ""},
                { "AVISOCRE_VAL_ADIANTAMENTO" , ""},
                { "AVISOCRE_STA_DEPOSITO_TER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5100_00_INSERT_AVISOCRE_DB_INSERT_1_Insert1", q13);

            #endregion

            #region R5200_00_INSERT_AVISOSAL_DB_INSERT_1_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "AVISOSAL_COD_EMPRESA" , ""},
                { "AVISOSAL_BCO_AVISO" , ""},
                { "AVISOSAL_AGE_AVISO" , ""},
                { "AVISOSAL_TIPO_SEGURO" , ""},
                { "AVISOSAL_NUM_AVISO_CREDITO" , ""},
                { "AVISOSAL_DATA_AVISO" , ""},
                { "AVISOSAL_DATA_MOVIMENTO" , ""},
                { "AVISOSAL_SALDO_ATUAL" , ""},
                { "AVISOSAL_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5200_00_INSERT_AVISOSAL_DB_INSERT_1_Insert1", q14);

            #endregion

            #region R5300_00_INSERT_CONDESCE_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "CONDESCE_COD_EMPRESA" , ""},
                { "CONDESCE_ANO_REFERENCIA" , ""},
                { "CONDESCE_MES_REFERENCIA" , ""},
                { "CONDESCE_BCO_AVISO" , ""},
                { "CONDESCE_AGE_AVISO" , ""},
                { "CONDESCE_NUM_AVISO_CREDITO" , ""},
                { "CONDESCE_COD_PRODUTO" , ""},
                { "CONDESCE_TIPO_REGISTRO" , ""},
                { "CONDESCE_SITUACAO" , ""},
                { "CONDESCE_TIPO_COBRANCA" , ""},
                { "CONDESCE_DATA_MOVIMENTO" , ""},
                { "CONDESCE_DATA_AVISO" , ""},
                { "CONDESCE_QTD_REGISTROS" , ""},
                { "CONDESCE_PRM_TOTAL" , ""},
                { "CONDESCE_PRM_LIQUIDO" , ""},
                { "CONDESCE_VAL_TARIFA" , ""},
                { "CONDESCE_VAL_BALCAO" , ""},
                { "CONDESCE_VAL_IOCC" , ""},
                { "CONDESCE_VAL_DESCONTO" , ""},
                { "CONDESCE_VAL_JUROS" , ""},
                { "CONDESCE_VAL_MULTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5300_00_INSERT_CONDESCE_DB_INSERT_1_Insert1", q15);

            #endregion

            #region R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_SIT_REGISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1", q16);

            #endregion

            #region R9000_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_DATA_RETORNO" , ""},
                { "VIND_DTRETORNO" , ""},
                { "MOVDEBCE_COD_RETORNO_CEF" , ""},
                { "VIND_CODRET" , ""},
                { "MOVDEBCE_VLR_CREDITO" , ""},
                { "VIND_VLRCREDITO" , ""},
                { "MOVDEBCE_COD_USUARIO" , ""},
                { "VIND_USUARIO" , ""},
                { "MOVDEBCE_DTCREDITO" , ""},
                { "VIND_DTCREDITO" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9000_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1", q17);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("ARQSORT_FILE_NAME_P", "BI6253B1_FILE_NAME_P")]
        public static void BI6253B_Tests_Theory_Case1(string ARQSORT_FILE_NAME_P, string BI6253B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";
            BI6253B1_FILE_NAME_P = $"{BI6253B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region BI6253B_V0MOVIMCOB

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , "300"},
                { "MOVIMCOB_COD_MOVIMENTO" , "21"},
                { "MOVIMCOB_COD_BANCO" , "104"},
                { "MOVIMCOB_COD_AGENCIA" , "8222"},
                { "MOVIMCOB_NUM_AVISO" , "23000"},
                { "MOVIMCOB_NUM_FITA" , "352"},
                { "MOVIMCOB_DATA_MOVIMENTO" , "1998-03-20"},
                { "MOVIMCOB_DATA_QUITACAO" , "1998-03-19"},
                { "MOVIMCOB_NUM_TITULO" , "82465679611"},
                { "MOVIMCOB_NUM_APOLICE" , "0"},
                { "MOVIMCOB_NUM_ENDOSSO" , "0"},
                { "MOVIMCOB_NUM_PARCELA" , "0"},
                { "MOVIMCOB_VAL_TITULO" , "35.70"},
                { "MOVIMCOB_VAL_CREDITO" , "31.00"},
                { "MOVIMCOB_SIT_REGISTRO" , "*"},
                { "MOVIMCOB_NOME_SEGURADO" , "Teste Foursys"},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , "0"},
                { "MOVIMCOB_TIPO_MOVIMENTO" , "Y"},
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , "300"},
                { "MOVIMCOB_COD_MOVIMENTO" , "21"},
                { "MOVIMCOB_COD_BANCO" , "104"},
                { "MOVIMCOB_COD_AGENCIA" , "8222"},
                { "MOVIMCOB_NUM_AVISO" , "21000"},
                { "MOVIMCOB_NUM_FITA" , "352"},
                { "MOVIMCOB_DATA_MOVIMENTO" , "1998-03-20"},
                { "MOVIMCOB_DATA_QUITACAO" , "1998-03-19"},
                { "MOVIMCOB_NUM_TITULO" , "82465679611"},
                { "MOVIMCOB_NUM_APOLICE" , "0"},
                { "MOVIMCOB_NUM_ENDOSSO" , "0"},
                { "MOVIMCOB_NUM_PARCELA" , "0"},
                { "MOVIMCOB_VAL_TITULO" , "35.70"},
                { "MOVIMCOB_VAL_CREDITO" , "31.00"},
                { "MOVIMCOB_SIT_REGISTRO" , "2"},
                { "MOVIMCOB_NOME_SEGURADO" , "Teste Foursys2"},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , "0"},
                { "MOVIMCOB_TIPO_MOVIMENTO" , "Y"},
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , "100"},
                { "MOVIMCOB_COD_MOVIMENTO" , "21"},
                { "MOVIMCOB_COD_BANCO" , "108"},
                { "MOVIMCOB_COD_AGENCIA" , "8222"},
                { "MOVIMCOB_NUM_AVISO" , "21000"},
                { "MOVIMCOB_NUM_FITA" , "352"},
                { "MOVIMCOB_DATA_MOVIMENTO" , "1998-03-20"},
                { "MOVIMCOB_DATA_QUITACAO" , "1998-03-25"},
                { "MOVIMCOB_NUM_TITULO" , "82465679611"},
                { "MOVIMCOB_NUM_APOLICE" , "0"},
                { "MOVIMCOB_NUM_ENDOSSO" , "0"},
                { "MOVIMCOB_NUM_PARCELA" , "0"},
                { "MOVIMCOB_VAL_TITULO" , "35.70"},
                { "MOVIMCOB_VAL_CREDITO" , "31.00"},
                { "MOVIMCOB_SIT_REGISTRO" , "3"},
                { "MOVIMCOB_NOME_SEGURADO" , "Teste Foursys3"},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , "0"},
                { "MOVIMCOB_TIPO_MOVIMENTO" , "Y"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI6253B_V0MOVIMCOB");
                AppSettings.TestSet.DynamicData.Add("BI6253B_V0MOVIMCOB", q1);


                #region R0370_00_SELECT_PARCELAS_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_SIT_REGISTRO" , "1"},
                { "PARCELAS_OCORR_HISTORICO" , "300"},
                { "ENDOSSOS_COD_PRODUTO" , "2080"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0370_00_SELECT_PARCELAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0370_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q3);

                #endregion

                #endregion

                #endregion
                var program = new BI6253B();
                program.Execute(ARQSORT_FILE_NAME_P, BI6253B1_FILE_NAME_P);

                //R2100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1
                var envList4 = AppSettings.TestSet.DynamicData["R2100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("FOLLOUP_AGE_AVISO", out var valor4) && valor4.Contains("8222"));
                Assert.True(envList4.Count > 1);

                //R5100_00_INSERT_AVISOCRE_DB_INSERT_1_Insert1
                var envList5 = AppSettings.TestSet.DynamicData["R5100_00_INSERT_AVISOCRE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("AVISOCRE_NUM_AVISO_CREDITO", out var valor5) && valor5.Contains("802100001"));
                Assert.True(envList5.Count > 1);

                //R5200_00_INSERT_AVISOSAL_DB_INSERT_1_Insert1
                var envList6 = AppSettings.TestSet.DynamicData["R5200_00_INSERT_AVISOSAL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList6[1].TryGetValue("AVISOSAL_BCO_AVISO", out var valor6) && valor6.Contains("108"));
                Assert.True(envList6.Count > 1);

                //R5300_00_INSERT_CONDESCE_DB_INSERT_1_Insert1
                var envList7 = AppSettings.TestSet.DynamicData["R5300_00_INSERT_CONDESCE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList7[1].TryGetValue("CONDESCE_COD_PRODUTO", out var valor7) && valor7.Contains("2080"));
                Assert.True(envList7.Count > 1);

                //R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1
                var envList8 = AppSettings.TestSet.DynamicData["R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList8[1].TryGetValue("MOVIMCOB_SIT_REGISTRO", out var valor8) && valor8.Contains("3"));
                Assert.True(envList8.Count > 1);

                //R9000_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1
                var envList9 = AppSettings.TestSet.DynamicData["R9000_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList9[1].TryGetValue("MOVDEBCE_SITUACAO_COBRANCA", out var valor9) && valor9.Contains("3"));
                Assert.True(envList9.Count > 1);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("ARQSORT_FILE_NAME_P", "BI6253B1_FILE_NAME_P")]
        public static void BI6253B_Tests_Theory_Case2(string ARQSORT_FILE_NAME_P, string BI6253B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";
            BI6253B1_FILE_NAME_P = $"{BI6253B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region BI6253B_V0MOVIMCOB

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , "300"},
                { "MOVIMCOB_COD_MOVIMENTO" , "21"},
                { "MOVIMCOB_COD_BANCO" , "104"},
                { "MOVIMCOB_COD_AGENCIA" , "8222"},
                { "MOVIMCOB_NUM_AVISO" , "23000"},
                { "MOVIMCOB_NUM_FITA" , "352"},
                { "MOVIMCOB_DATA_MOVIMENTO" , "1998-03-20"},
                { "MOVIMCOB_DATA_QUITACAO" , "1998-03-19"},
                { "MOVIMCOB_NUM_TITULO" , "82465679611"},
                { "MOVIMCOB_NUM_APOLICE" , "0"},
                { "MOVIMCOB_NUM_ENDOSSO" , "0"},
                { "MOVIMCOB_NUM_PARCELA" , "0"},
                { "MOVIMCOB_VAL_TITULO" , "35.70"},
                { "MOVIMCOB_VAL_CREDITO" , "31.00"},
                { "MOVIMCOB_SIT_REGISTRO" , "*"},
                { "MOVIMCOB_NOME_SEGURADO" , "Teste Foursys"},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , "0"},
                { "MOVIMCOB_TIPO_MOVIMENTO" , "Y"},
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , "300"},
                { "MOVIMCOB_COD_MOVIMENTO" , "21"},
                { "MOVIMCOB_COD_BANCO" , "104"},
                { "MOVIMCOB_COD_AGENCIA" , "8222"},
                { "MOVIMCOB_NUM_AVISO" , "21000"},
                { "MOVIMCOB_NUM_FITA" , "352"},
                { "MOVIMCOB_DATA_MOVIMENTO" , "1998-03-20"},
                { "MOVIMCOB_DATA_QUITACAO" , "1998-03-19"},
                { "MOVIMCOB_NUM_TITULO" , "82465679611"},
                { "MOVIMCOB_NUM_APOLICE" , "0"},
                { "MOVIMCOB_NUM_ENDOSSO" , "0"},
                { "MOVIMCOB_NUM_PARCELA" , "0"},
                { "MOVIMCOB_VAL_TITULO" , "35.70"},
                { "MOVIMCOB_VAL_CREDITO" , "31.00"},
                { "MOVIMCOB_SIT_REGISTRO" , "2"},
                { "MOVIMCOB_NOME_SEGURADO" , "Teste Foursys2"},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , "0"},
                { "MOVIMCOB_TIPO_MOVIMENTO" , "Y"},
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , "100"},
                { "MOVIMCOB_COD_MOVIMENTO" , "21"},
                { "MOVIMCOB_COD_BANCO" , "108"},
                { "MOVIMCOB_COD_AGENCIA" , "8222"},
                { "MOVIMCOB_NUM_AVISO" , "21000"},
                { "MOVIMCOB_NUM_FITA" , "352"},
                { "MOVIMCOB_DATA_MOVIMENTO" , "1998-03-20"},
                { "MOVIMCOB_DATA_QUITACAO" , "1998-03-25"},
                { "MOVIMCOB_NUM_TITULO" , "82465679611"},
                { "MOVIMCOB_NUM_APOLICE" , "0"},
                { "MOVIMCOB_NUM_ENDOSSO" , "0"},
                { "MOVIMCOB_NUM_PARCELA" , "0"},
                { "MOVIMCOB_VAL_TITULO" , "35.70"},
                { "MOVIMCOB_VAL_CREDITO" , "31.00"},
                { "MOVIMCOB_SIT_REGISTRO" , "3"},
                { "MOVIMCOB_NOME_SEGURADO" , "Teste Foursys3"},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , "0"},
                { "MOVIMCOB_TIPO_MOVIMENTO" , "Y"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI6253B_V0MOVIMCOB");
                AppSettings.TestSet.DynamicData.Add("BI6253B_V0MOVIMCOB", q1);


                #region R0370_00_SELECT_PARCELAS_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_SIT_REGISTRO" , "0"},
                { "PARCELAS_OCORR_HISTORICO" , "300"},
                { "ENDOSSOS_COD_PRODUTO" , "2080"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0370_00_SELECT_PARCELAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0370_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q3);

                #endregion

                #endregion

                #endregion
                var program = new BI6253B();
                program.Execute(ARQSORT_FILE_NAME_P, BI6253B1_FILE_NAME_P);

                //R1150_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1
                var envList = AppSettings.TestSet.DynamicData["R1150_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("PARCELAS_OCORR_HISTORICO", out var valor) && valor.Contains("301"));
                Assert.True(envList.Count > 1);

                //R1250_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["R1250_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("PARCEHIS_VAL_OPERACAO", out var valor2) && valor2.Contains("0000000000035.70"));
                Assert.True(envList2.Count > 1);

                //R1350_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1
                var envList3 = AppSettings.TestSet.DynamicData["R1350_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("ENDOSSOS_SIT_REGISTRO", out var valor3) && valor3.Contains("1"));
                Assert.True(envList3.Count > 1);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("ARQSORT_FILE_NAME_P", "BI6253B1_FILE_NAME_P")]
        public static void BI6253B_Tests_Theory_Erro99(string ARQSORT_FILE_NAME_P, string BI6253B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";
            BI6253B1_FILE_NAME_P = $"{BI6253B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #endregion
                var program = new BI6253B();
                program.Execute(ARQSORT_FILE_NAME_P, BI6253B1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}