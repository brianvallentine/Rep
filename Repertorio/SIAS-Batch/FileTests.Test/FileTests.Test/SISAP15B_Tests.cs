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
using static Code.SISAP15B;

namespace FileTests.Test
{

    [Collection("SISAP15B_Tests")]

    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class SISAP15B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SISTEMAS_DATULT_PROCESSAMEN" , ""},
                { "HOST_CURRENT_DATE" , ""},
                { "HOST_CURRENT_TIME" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0010_SELECT_SISTEMAS_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "HOST_SI_DATA_MOV_ABERTO" , ""},
                { "HOST_SI_CURRENT_DATE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0010_SELECT_SISTEMAS_DB_SELECT_2_Query1", q1);

            #endregion

            #region R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1", q2);

            #endregion

            #region SISAP15B_LE_MOVDEBCE

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "W_NOME_QUERY" , ""},
                { "SINISHIS_TIPO_REGISTRO" , ""},
                { "W_NOME_TIPO_SEGURO" , ""},
                { "SINISHIS_NUM_APOLICE" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "W_ANO_OPERACIONAL_MOVIMENTO" , ""},
                { "W_ANO_CONTABIL_MOVIMENTO" , ""},
                { "GEOPERAC_FUNCAO_OPERACAO" , ""},
                { "GEOPERAC_DES_OPERACAO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "MOVDEBCE_VLR_CREDITO" , ""},
                { "MOVDEBCE_VALOR_DEBITO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_COD_PREST_SERVICO" , ""},
                { "SINISHIS_COD_SERVICO" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "W_NOME_FORMA_PAGAMENTO" , ""},
                { "SINISHIS_NOM_PROGRAMA" , ""},
                { "SINISHIS_COD_USUARIO" , ""},
                { "SINISMES_RAMO" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "W_DATA_AVISO_SIAS" , ""},
                { "SINISMES_DATA_COMUNICADO" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "PRODUTO_DESCR_PRODUTO" , ""},
                { "CHEQUEMI_NUM_CHEQUE_INTERNO" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "W_NOME_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_DATA_MOVIMENTO" , ""},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_DATA_ENVIO" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_NUM_REQUISICAO" , ""},
                { "GE369_COD_AGENCIA" , ""},
                { "GE369_COD_BANCO" , ""},
                { "GE369_NUM_CONTA_CNB" , ""},
                { "GE369_NUM_DV_CONTA_CNB" , ""},
                { "GE369_IND_CONTA_BANCARIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SISAP15B_LE_MOVDEBCE", q3);

            #endregion

            #region SISAP15B_IMPOSTOS

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SIPADOFI_NUM_DOCF_INTERNO" , ""},
                { "FIPADOLA_COD_TP_LANCDOCF" , ""},
                { "GETPLADO_ABREV_LANCDOCF" , ""},
                { "FIPADOLA_VALOR_LANCAMENTO" , ""},
                { "GETIPIMP_COD_IMP_INTERNO" , ""},
                { "GETIPIMP_SIGLA_IMP" , ""},
                { "FIPADOIM_ALIQ_TRIBUTACAO" , ""},
                { "FIPADOIM_VALOR_IMPOSTO" , ""},
                { "FIPADOFI_NUM_DOC_FISCAL" , ""},
                { "FIPADOFI_SERIE_DOC_FISCAL" , ""},
                { "FIPADOFI_DATA_EMISSAO_DOC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SISAP15B_IMPOSTOS", q4);

            #endregion

            #region R3010_ACESSA_SCPJUD_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3010_ACESSA_SCPJUD_DB_SELECT_1_Query1", q5);

            #endregion

            #region R3010_ACESSA_SCPJUD_DB_SELECT_2_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SIPROJUD_COD_PROCESSO_JURID" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3010_ACESSA_SCPJUD_DB_SELECT_2_Query1", q6);

            #endregion

            #region R3210_LE_FORNECEDOR_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "FORNECED_INSC_PREFEITURA" , ""},
                { "FORNECED_INSC_ESTADUAL" , ""},
                { "FORNECED_OPT_SIMPLES_FED" , ""},
                { "FORNECED_OPT_SIMPLES_MUN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3210_LE_FORNECEDOR_DB_SELECT_1_Query1", q7);

            #endregion

            #region R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "GEOPERAC_FUNCAO_OPERACAO" , ""},
                { "GEOPERAC_DES_OPERACAO" , ""},
                { "GE368_NUM_OCORR_MOVTO" , ""},
                { "GE368_NUM_PESSOA" , ""},
                { "OD001_IND_PESSOA" , ""},
                { "W_NUMERO_CPF_BASE" , ""},
                { "OD002_NOM_PESSOA" , ""},
                { "W_PF_INSC_PREFEITURA" , ""},
                { "W_PF_INSC_ESTADUAL" , ""},
                { "W_PF_NUM_INSC_SOCIAL" , ""},
                { "W_PF_NUM_DV_INSC_SOCIAL" , ""},
                { "W_NUMERO_CNPJ_BASE" , ""},
                { "OD003_NOM_RAZAO_SOCIAL" , ""},
                { "W_PJ_INSC_PREFEITURA" , ""},
                { "W_PJ_INSC_ESTADUAL" , ""},
                { "W_PJ_NUM_INSC_SOCIAL" , ""},
                { "W_PJ_NUM_DV_INSC_SOCIAL" , ""},
                { "OD007_NOM_LOGRADOURO" , ""},
                { "OD007_DES_NUM_IMOVEL" , ""},
                { "OD007_DES_COMPL_ENDERECO" , ""},
                { "OD007_NOM_BAIRRO" , ""},
                { "OD007_NOM_CIDADE" , ""},
                { "OD007_COD_CEP" , ""},
                { "OD007_COD_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1", q8);

            #endregion

            #region R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SINILT01_NUM_APOL_SINISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1", q9);

            #endregion

            #region R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "FORNECED_NOME_FORNECEDOR" , ""},
                { "FORNECED_TIPO_PESSOA" , ""},
                { "W_NOME_TIPO_PESSOA" , ""},
                { "FORNECED_CGCCPF" , ""},
                { "FORNECED_ENDERECO" , ""},
                { "FORNECED_BAIRRO" , ""},
                { "FORNECED_CIDADE" , ""},
                { "FORNECED_CEP" , ""},
                { "FORNECED_SIGLA_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1", q10);

            #endregion

            #region R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "GEOPERAC_FUNCAO_OPERACAO" , ""},
                { "GEOPERAC_DES_OPERACAO" , ""},
                { "FORNECED_TIPO_PESSOA" , ""},
                { "W_NOME_TIPO_PESSOA" , ""},
                { "FORNECED_CGCCPF" , ""},
                { "FORNECED_NOME_FORNECEDOR" , ""},
                { "FORNECED_INSC_PREFEITURA" , ""},
                { "FORNECED_INSC_ESTADUAL" , ""},
                { "FORNECED_OPT_SIMPLES_FED" , ""},
                { "FORNECED_OPT_SIMPLES_MUN" , ""},
                { "FORNECED_ENDERECO" , ""},
                { "FORNECED_BAIRRO" , ""},
                { "FORNECED_CIDADE" , ""},
                { "FORNECED_CEP" , ""},
                { "FORNECED_SIGLA_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1", q11);

            #endregion

            #region R2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "FIPADOFI_NUM_DOC_FISCAL" , ""},
                { "FIPADOFI_SERIE_DOC_FISCAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1", q12);

            #endregion

            #region R2040_PEGA_SERVICO_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "FORNECED_CEP" , ""},
                { "FORNECED_COD_SERVICO_ISS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2040_PEGA_SERVICO_DB_SELECT_1_Query1", q13);

            #endregion

            #region R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "CEPFXFIL_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1", q14);

            #endregion

            #region R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "HOST_CURRENT_TIMESTAMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1", q15);

            #endregion

            #endregion
        }

        [Fact]
        public static void SISAP15B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                GE0005S_Tests.Load_Parameters();
             

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-27"},
                { "SISTEMAS_DATULT_PROCESSAMEN" , "2025-01-24"},
                { "HOST_CURRENT_DATE" , "2025-03-24"},
                { "HOST_CURRENT_TIME" , "09:19:26"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0010_SELECT_SISTEMAS_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "HOST_SI_DATA_MOV_ABERTO" , "2025-01-01"},
                { "HOST_SI_CURRENT_DATE" , "2025-03-24"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0010_SELECT_SISTEMAS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_SELECT_SISTEMAS_DB_SELECT_2_Query1", q1);

                #endregion

                #region R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "100"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1", q2);

                #endregion

                #region SISAP15B_LE_MOVDEBCE

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "W_NOME_QUERY" , "x"},
                { "SINISHIS_TIPO_REGISTRO" , "1"},
                { "W_NOME_TIPO_SEGURO" , "x"},
                { "SINISHIS_NUM_APOLICE" , "2"},
                { "SINISHIS_NUM_APOL_SINISTRO" , "3"},
                { "SINISHIS_OCORR_HISTORICO" , "4"},
                { "SINISHIS_COD_OPERACAO" , "5"},
                { "SINISHIS_NOME_FAVORECIDO" , "x"},
                { "W_ANO_OPERACIONAL_MOVIMENTO" , "7"},
                { "W_ANO_CONTABIL_MOVIMENTO" , "8"},
                { "GEOPERAC_FUNCAO_OPERACAO" , "HPAG"},
                { "GEOPERAC_DES_OPERACAO" , "x"},
                { "SINISHIS_VAL_OPERACAO" , "10"},
                { "MOVDEBCE_VLR_CREDITO" , "11"},
                { "MOVDEBCE_VALOR_DEBITO" , "12"},
                { "SINISHIS_DATA_MOVIMENTO" , "2020-01-01"},
                { "SINISHIS_COD_PREST_SERVICO" , "13"},
                { "SINISHIS_COD_SERVICO" , "14"},
                { "SINISHIS_SIT_CONTABIL" , "15"},
                { "W_NOME_FORMA_PAGAMENTO" , "x"},
                { "SINISHIS_NOM_PROGRAMA" , "x"},
                { "SINISHIS_COD_USUARIO" , "16"},
                { "SINISMES_RAMO" , "17"},
                { "SINISMES_COD_FONTE" , "18"},
                { "W_DATA_AVISO_SIAS" , "2020-01-01"},
                { "SINISMES_DATA_COMUNICADO" , "2020-01-01"},
                { "SINISMES_COD_PRODUTO" , "19"},
                { "PRODUTO_DESCR_PRODUTO" , "x"},
                { "CHEQUEMI_NUM_CHEQUE_INTERNO" , "20"},
                { "MOVDEBCE_NUM_APOLICE" , "21"},
                { "MOVDEBCE_NUM_ENDOSSO" , "22"},
                { "MOVDEBCE_NUM_PARCELA" , "23"},
                { "MOVDEBCE_SITUACAO_COBRANCA" , "24"},
                { "W_NOME_SITUACAO_COBRANCA" , "x"},
                { "MOVDEBCE_DATA_VENCIMENTO" , "2020-01-01"},
                { "MOVDEBCE_DATA_MOVIMENTO" , "20-01-01"},
                { "MOVDEBCE_COD_AGENCIA_DEB" , "25"},
                { "MOVDEBCE_OPER_CONTA_DEB" , "26"},
                { "MOVDEBCE_NUM_CONTA_DEB" , "27"},
                { "MOVDEBCE_DIG_CONTA_DEB" , "28"},
                { "MOVDEBCE_COD_CONVENIO" , "29"},
                { "MOVDEBCE_DATA_ENVIO" , "2020-01-01"},
                { "MOVDEBCE_NSAS" , "30"},
                { "MOVDEBCE_NUM_REQUISICAO" , "31"},
                { "GE369_COD_AGENCIA" , "32"},
                { "GE369_COD_BANCO" , "33"},
                { "GE369_NUM_CONTA_CNB" , "34"},
                { "GE369_NUM_DV_CONTA_CNB" , "35"},
                { "GE369_IND_CONTA_BANCARIA" , "36"},
            });
                AppSettings.TestSet.DynamicData.Remove("SISAP15B_LE_MOVDEBCE");
                AppSettings.TestSet.DynamicData.Add("SISAP15B_LE_MOVDEBCE", q3);

                #endregion

                #region SISAP15B_IMPOSTOS

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "1"},
                { "SINISHIS_OCORR_HISTORICO" , "2"},
                { "SINISHIS_COD_OPERACAO" , "3"},
                { "SIPADOFI_NUM_DOCF_INTERNO" , "4"},
                { "FIPADOLA_COD_TP_LANCDOCF" , "5"},
                { "GETPLADO_ABREV_LANCDOCF" , "6"},
                { "FIPADOLA_VALOR_LANCAMENTO" , "7"},
                { "GETIPIMP_COD_IMP_INTERNO" , "8"},
                { "GETIPIMP_SIGLA_IMP" , "x"},
                { "FIPADOIM_ALIQ_TRIBUTACAO" , "9"},
                { "FIPADOIM_VALOR_IMPOSTO" , "10"},
                { "FIPADOFI_NUM_DOC_FISCAL" , "11"},
                { "FIPADOFI_SERIE_DOC_FISCAL" , "12"},
                { "FIPADOFI_DATA_EMISSAO_DOC" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("SISAP15B_IMPOSTOS");
                AppSettings.TestSet.DynamicData.Add("SISAP15B_IMPOSTOS", q4);

                #endregion

                #region R3010_ACESSA_SCPJUD_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "1"}
            });
                q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "2"}
            });
                AppSettings.TestSet.DynamicData.Remove("R3010_ACESSA_SCPJUD_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3010_ACESSA_SCPJUD_DB_SELECT_1_Query1", q5);

                #endregion

                #region R3010_ACESSA_SCPJUD_DB_SELECT_2_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SIPROJUD_COD_PROCESSO_JURID" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R3010_ACESSA_SCPJUD_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R3010_ACESSA_SCPJUD_DB_SELECT_2_Query1", q6);

                q6.AddDynamic(new Dictionary<string, string>{
                { "SIPROJUD_COD_PROCESSO_JURID" , "2"}
            });
                AppSettings.TestSet.DynamicData.Remove("R3010_ACESSA_SCPJUD_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R3010_ACESSA_SCPJUD_DB_SELECT_2_Query1", q6);

                #endregion

                #region R3210_LE_FORNECEDOR_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "FORNECED_INSC_PREFEITURA" , ""},
                { "FORNECED_INSC_ESTADUAL" , "123"},
                { "FORNECED_OPT_SIMPLES_FED" , "S"},
                { "FORNECED_OPT_SIMPLES_MUN" , "S"},
            });
                AppSettings.TestSet.DynamicData.Remove("R3210_LE_FORNECEDOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3210_LE_FORNECEDOR_DB_SELECT_1_Query1", q7);

                #endregion

                #region R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "1"},
                { "SINISHIS_OCORR_HISTORICO" , "2"},
                { "SINISHIS_COD_OPERACAO" , "3"},
                { "GEOPERAC_FUNCAO_OPERACAO" , "HPAG"},
                { "GEOPERAC_DES_OPERACAO" , "X"},
                { "GE368_NUM_OCORR_MOVTO" , "5"},
                { "GE368_NUM_PESSOA" , "6"},
                { "OD001_IND_PESSOA" , "F"},
                { "W_NUMERO_CPF_BASE" , "123456789"},
                { "OD002_NOM_PESSOA" , "X"},
                { "W_PF_INSC_PREFEITURA" , " "},
                { "W_PF_INSC_ESTADUAL" , "2"},
                { "W_PF_NUM_INSC_SOCIAL" , "0"},
                { "W_PF_NUM_DV_INSC_SOCIAL" , "8"},
                { "W_NUMERO_CNPJ_BASE" , "01123456000112"},
                { "OD003_NOM_RAZAO_SOCIAL" , "X"},
                { "W_PJ_INSC_PREFEITURA" , "0"},
                { "W_PJ_INSC_ESTADUAL" , "0"},
                { "W_PJ_NUM_INSC_SOCIAL" , "0"},
                { "W_PJ_NUM_DV_INSC_SOCIAL" , "0"},
                { "OD007_NOM_LOGRADOURO" , "X"},
                { "OD007_DES_NUM_IMOVEL" , "X"},
                { "OD007_DES_COMPL_ENDERECO" , "X"},
                { "OD007_NOM_BAIRRO" , "X"},
                { "OD007_NOM_CIDADE" , "X"},
                { "OD007_COD_CEP" , "123465"},
                { "OD007_COD_UF" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1", q8);

                #endregion

                #region R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "SINILT01_NUM_APOL_SINISTRO" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1", q9);

                #endregion

                #region R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "FORNECED_NOME_FORNECEDOR" , "X"},
                { "FORNECED_TIPO_PESSOA" , "F"},
                { "W_NOME_TIPO_PESSOA" , "F"},
                { "FORNECED_CGCCPF" , "123456"},
                { "FORNECED_ENDERECO" , "X"},
                { "FORNECED_BAIRRO" , "X"},
                { "FORNECED_CIDADE" , "X"},
                { "FORNECED_CEP" , "123"},
                { "FORNECED_SIGLA_UF" , "SP"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1", q10);

                #endregion

                #region R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "1"},
                { "SINISHIS_OCORR_HISTORICO" , "2"},
                { "SINISHIS_COD_OPERACAO" , "3"},
                { "GEOPERAC_FUNCAO_OPERACAO" , "HPAG"},
                { "GEOPERAC_DES_OPERACAO" , "X"},
                { "FORNECED_TIPO_PESSOA" , "F"},
                { "W_NOME_TIPO_PESSOA" , "X"},
                { "FORNECED_CGCCPF" , "123456"},
                { "FORNECED_NOME_FORNECEDOR" , "X"},
                { "FORNECED_INSC_PREFEITURA" , "0"},
                { "FORNECED_INSC_ESTADUAL" , "123456"},
                { "FORNECED_OPT_SIMPLES_FED" , "1"},
                { "FORNECED_OPT_SIMPLES_MUN" , "2"},
                { "FORNECED_ENDERECO" , "X"},
                { "FORNECED_BAIRRO" , "X"},
                { "FORNECED_CIDADE" , "X"},
                { "FORNECED_CEP" , "X"},
                { "FORNECED_SIGLA_UF" , "X"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1", q11);

                #endregion

                #region R2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "FIPADOFI_NUM_DOC_FISCAL" , "123456"},
                { "FIPADOFI_SERIE_DOC_FISCAL" , "123456"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1", q12);

                #endregion

                #region R2040_PEGA_SERVICO_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "FORNECED_CEP" , "123456"},
                { "FORNECED_COD_SERVICO_ISS" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2040_PEGA_SERVICO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2040_PEGA_SERVICO_DB_SELECT_1_Query1", q13);

                #endregion

                #region R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "CEPFXFIL_FONTE" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1", q14);

                #endregion

                #region R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "HOST_CURRENT_TIMESTAMP" , "2025-03-24 09:54:47.783"}
            });
                AppSettings.TestSet.DynamicData.Remove("R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1", q15);

                #endregion

                #region R0510_00_SELECT_CALENDAR_DB_SELECT_1_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DIA_SEMANA" , "D"},
                { "CALENDAR_FERIADO" , ""},
                 });
                AppSettings.TestSet.DynamicData.Remove("R0510_00_SELECT_CALENDAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0510_00_SELECT_CALENDAR_DB_SELECT_1_Query1", q30);

                #endregion
           
                
                #endregion
                var program = new SISAP15B();
                SISAP15B_REGISTRO_LINKAGE_SAP obj = new SISAP15B_REGISTRO_LINKAGE_SAP();
              
                obj.LK_SAP_COD_PROGRAMA.Value = "SI5002B";
                obj.LK_SAP_COD_CONVENIO.Value = 600128;

                program.Execute(obj);
                //program.Execute(new SISAP15B_REGISTRO_LINKAGE_SAP());

                var envList1 = AppSettings.TestSet.DynamicData["R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["R0010_SELECT_SISTEMAS_DB_SELECT_2_Query1"].DynamicList;
                Assert.Empty(envList2);

                var envList3 = AppSettings.TestSet.DynamicData["R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList3);

                var envList4 = AppSettings.TestSet.DynamicData["SISAP15B_LE_MOVDEBCE"].DynamicList;
                Assert.Empty(envList4);

                var envList6 = AppSettings.TestSet.DynamicData["R3010_ACESSA_SCPJUD_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList6);

                var envList7 = AppSettings.TestSet.DynamicData["R3010_ACESSA_SCPJUD_DB_SELECT_2_Query1"].DynamicList;
                Assert.Empty(envList7);

                var envList5 = AppSettings.TestSet.DynamicData["SISAP15B_IMPOSTOS"].DynamicList;
                Assert.Empty(envList5);  

                var envList16 = AppSettings.TestSet.DynamicData["R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList16);            

                var envList12 = AppSettings.TestSet.DynamicData["R2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList12);

                var envList13 = AppSettings.TestSet.DynamicData["R2040_PEGA_SERVICO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList13);

                var envList14 = AppSettings.TestSet.DynamicData["R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList14);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Fact]
        public static void SISAP15B_Tests99_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                GE0005S_Tests.Load_Parameters();


                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-27"},
                { "SISTEMAS_DATULT_PROCESSAMEN" , "2025-01-24"},
                { "HOST_CURRENT_DATE" , "2025-03-24"},
                { "HOST_CURRENT_TIME" , "09:19:26"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1");
               // AppSettings.TestSet.DynamicData.Add("R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0010_SELECT_SISTEMAS_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "HOST_SI_DATA_MOV_ABERTO" , ""},
                { "HOST_SI_CURRENT_DATE" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R0010_SELECT_SISTEMAS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_SELECT_SISTEMAS_DB_SELECT_2_Query1", q1);

                #endregion

                #region R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1", q2);

                #endregion

                #region SISAP15B_LE_MOVDEBCE

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "W_NOME_QUERY" , "x"},
                { "SINISHIS_TIPO_REGISTRO" , "1"},
                { "W_NOME_TIPO_SEGURO" , "x"},
                { "SINISHIS_NUM_APOLICE" , "2"},
                { "SINISHIS_NUM_APOL_SINISTRO" , "3"},
                { "SINISHIS_OCORR_HISTORICO" , "4"},
                { "SINISHIS_COD_OPERACAO" , "5"},
                { "SINISHIS_NOME_FAVORECIDO" , "x"},
                { "W_ANO_OPERACIONAL_MOVIMENTO" , "7"},
                { "W_ANO_CONTABIL_MOVIMENTO" , "8"},
                { "GEOPERAC_FUNCAO_OPERACAO" , "HPAG"},
                { "GEOPERAC_DES_OPERACAO" , "x"},
                { "SINISHIS_VAL_OPERACAO" , "10"},
                { "MOVDEBCE_VLR_CREDITO" , "11"},
                { "MOVDEBCE_VALOR_DEBITO" , "12"},
                { "SINISHIS_DATA_MOVIMENTO" , "2020-01-01"},
                { "SINISHIS_COD_PREST_SERVICO" , "13"},
                { "SINISHIS_COD_SERVICO" , "14"},
                { "SINISHIS_SIT_CONTABIL" , "15"},
                { "W_NOME_FORMA_PAGAMENTO" , "x"},
                { "SINISHIS_NOM_PROGRAMA" , "x"},
                { "SINISHIS_COD_USUARIO" , "16"},
                { "SINISMES_RAMO" , "17"},
                { "SINISMES_COD_FONTE" , "18"},
                { "W_DATA_AVISO_SIAS" , "2020-01-01"},
                { "SINISMES_DATA_COMUNICADO" , "2020-01-01"},
                { "SINISMES_COD_PRODUTO" , "19"},
                { "PRODUTO_DESCR_PRODUTO" , "x"},
                { "CHEQUEMI_NUM_CHEQUE_INTERNO" , "20"},
                { "MOVDEBCE_NUM_APOLICE" , "21"},
                { "MOVDEBCE_NUM_ENDOSSO" , "22"},
                { "MOVDEBCE_NUM_PARCELA" , "23"},
                { "MOVDEBCE_SITUACAO_COBRANCA" , "24"},
                { "W_NOME_SITUACAO_COBRANCA" , "x"},
                { "MOVDEBCE_DATA_VENCIMENTO" , "2020-01-01"},
                { "MOVDEBCE_DATA_MOVIMENTO" , "20-01-01"},
                { "MOVDEBCE_COD_AGENCIA_DEB" , "25"},
                { "MOVDEBCE_OPER_CONTA_DEB" , "26"},
                { "MOVDEBCE_NUM_CONTA_DEB" , "27"},
                { "MOVDEBCE_DIG_CONTA_DEB" , "28"},
                { "MOVDEBCE_COD_CONVENIO" , "29"},
                { "MOVDEBCE_DATA_ENVIO" , "2020-01-01"},
                { "MOVDEBCE_NSAS" , "30"},
                { "MOVDEBCE_NUM_REQUISICAO" , "31"},
                { "GE369_COD_AGENCIA" , "32"},
                { "GE369_COD_BANCO" , "33"},
                { "GE369_NUM_CONTA_CNB" , "34"},
                { "GE369_NUM_DV_CONTA_CNB" , "35"},
                { "GE369_IND_CONTA_BANCARIA" , "36"},
            });
                AppSettings.TestSet.DynamicData.Remove("SISAP15B_LE_MOVDEBCE");
                AppSettings.TestSet.DynamicData.Add("SISAP15B_LE_MOVDEBCE", q3);

                #endregion

                #region SISAP15B_IMPOSTOS

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "1"},
                { "SINISHIS_OCORR_HISTORICO" , "2"},
                { "SINISHIS_COD_OPERACAO" , "3"},
                { "SIPADOFI_NUM_DOCF_INTERNO" , "4"},
                { "FIPADOLA_COD_TP_LANCDOCF" , "5"},
                { "GETPLADO_ABREV_LANCDOCF" , "6"},
                { "FIPADOLA_VALOR_LANCAMENTO" , "7"},
                { "GETIPIMP_COD_IMP_INTERNO" , "8"},
                { "GETIPIMP_SIGLA_IMP" , "x"},
                { "FIPADOIM_ALIQ_TRIBUTACAO" , "9"},
                { "FIPADOIM_VALOR_IMPOSTO" , "10"},
                { "FIPADOFI_NUM_DOC_FISCAL" , "11"},
                { "FIPADOFI_SERIE_DOC_FISCAL" , "12"},
                { "FIPADOFI_DATA_EMISSAO_DOC" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("SISAP15B_IMPOSTOS");
                AppSettings.TestSet.DynamicData.Add("SISAP15B_IMPOSTOS", q4);

                #endregion

                #region R3010_ACESSA_SCPJUD_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "1"}
            });
                q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "2"}
            });
                AppSettings.TestSet.DynamicData.Remove("R3010_ACESSA_SCPJUD_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3010_ACESSA_SCPJUD_DB_SELECT_1_Query1", q5);

                #endregion

                #region R3010_ACESSA_SCPJUD_DB_SELECT_2_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SIPROJUD_COD_PROCESSO_JURID" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R3010_ACESSA_SCPJUD_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R3010_ACESSA_SCPJUD_DB_SELECT_2_Query1", q6);

              
                #endregion

                #region R3210_LE_FORNECEDOR_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "FORNECED_INSC_PREFEITURA" , ""},
                { "FORNECED_INSC_ESTADUAL" , ""},
                { "FORNECED_OPT_SIMPLES_FED" , "S"},
                { "FORNECED_OPT_SIMPLES_MUN" , "S"},
            });
                AppSettings.TestSet.DynamicData.Remove("R3210_LE_FORNECEDOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3210_LE_FORNECEDOR_DB_SELECT_1_Query1", q7);

                #endregion

                #region R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "1"},
                { "SINISHIS_OCORR_HISTORICO" , "2"},
                { "SINISHIS_COD_OPERACAO" , "3"},
                { "GEOPERAC_FUNCAO_OPERACAO" , ""},
                { "GEOPERAC_DES_OPERACAO" , "X"},
                { "GE368_NUM_OCORR_MOVTO" , "5"},
                { "GE368_NUM_PESSOA" , "6"},
                { "OD001_IND_PESSOA" , "F"},
                { "W_NUMERO_CPF_BASE" , ""},
                { "OD002_NOM_PESSOA" , "X"},
                { "W_PF_INSC_PREFEITURA" , " "},
                { "W_PF_INSC_ESTADUAL" , "2"},
                { "W_PF_NUM_INSC_SOCIAL" , "0"},
                { "W_PF_NUM_DV_INSC_SOCIAL" , "8"},
                { "W_NUMERO_CNPJ_BASE" , ""},
                { "OD003_NOM_RAZAO_SOCIAL" , "X"},
                { "W_PJ_INSC_PREFEITURA" , "0"},
                { "W_PJ_INSC_ESTADUAL" , "0"},
                { "W_PJ_NUM_INSC_SOCIAL" , "0"},
                { "W_PJ_NUM_DV_INSC_SOCIAL" , "0"},
                { "OD007_NOM_LOGRADOURO" , "X"},
                { "OD007_DES_NUM_IMOVEL" , "X"},
                { "OD007_DES_COMPL_ENDERECO" , "X"},
                { "OD007_NOM_BAIRRO" , "X"},
                { "OD007_NOM_CIDADE" , "X"},
                { "OD007_COD_CEP" , "123465"},
                { "OD007_COD_UF" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1", q8);

                #endregion

                #region R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "SINILT01_NUM_APOL_SINISTRO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1", q9);

                #endregion

                #region R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "FORNECED_NOME_FORNECEDOR" , "X"},
                { "FORNECED_TIPO_PESSOA" , "F"},
                { "W_NOME_TIPO_PESSOA" , ""},
                { "FORNECED_CGCCPF" , "123456"},
                { "FORNECED_ENDERECO" , "X"},
                { "FORNECED_BAIRRO" , "X"},
                { "FORNECED_CIDADE" , "X"},
                { "FORNECED_CEP" , "123"},
                { "FORNECED_SIGLA_UF" , "SP"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1", q10);

                #endregion

                #region R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "1"},
                { "SINISHIS_OCORR_HISTORICO" , "2"},
                { "SINISHIS_COD_OPERACAO" , "3"},
                { "GEOPERAC_FUNCAO_OPERACAO" , "HPAG"},
                { "GEOPERAC_DES_OPERACAO" , "X"},
                { "FORNECED_TIPO_PESSOA" , "F"},
                { "W_NOME_TIPO_PESSOA" , ""},
                { "FORNECED_CGCCPF" , ""},
                { "FORNECED_NOME_FORNECEDOR" , ""},
                { "FORNECED_INSC_PREFEITURA" , ""},
                { "FORNECED_INSC_ESTADUAL" , ""},
                { "FORNECED_OPT_SIMPLES_FED" , ""},
                { "FORNECED_OPT_SIMPLES_MUN" , ""},
                { "FORNECED_ENDERECO" , "X"},
                { "FORNECED_BAIRRO" , "X"},
                { "FORNECED_CIDADE" , "X"},
                { "FORNECED_CEP" , "X"},
                { "FORNECED_SIGLA_UF" , "X"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1", q11);

                #endregion

                #region R2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "FIPADOFI_NUM_DOC_FISCAL" , ""},
                { "FIPADOFI_SERIE_DOC_FISCAL" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1", q12);

                #endregion

                #region R2040_PEGA_SERVICO_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "FORNECED_CEP" , ""},
                { "FORNECED_COD_SERVICO_ISS" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R2040_PEGA_SERVICO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2040_PEGA_SERVICO_DB_SELECT_1_Query1", q13);

                #endregion

                #region R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "CEPFXFIL_FONTE" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1", q14);

                #endregion

                #region R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "HOST_CURRENT_TIMESTAMP" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1", q15);

                #endregion

                #region R0510_00_SELECT_CALENDAR_DB_SELECT_1_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DIA_SEMANA" , ""},
                { "CALENDAR_FERIADO" , ""},
                 });
                AppSettings.TestSet.DynamicData.Remove("R0510_00_SELECT_CALENDAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0510_00_SELECT_CALENDAR_DB_SELECT_1_Query1", q30);

                #endregion


                #endregion
                var program = new SISAP15B();
                SISAP15B_REGISTRO_LINKAGE_SAP obj = new SISAP15B_REGISTRO_LINKAGE_SAP();

                obj.LK_SAP_COD_PROGRAMA.Value = "SI5002B";
                obj.LK_SAP_COD_CONVENIO.Value = 600128;

                program.Execute(obj);
                //program.Execute(new SISAP15B_REGISTRO_LINKAGE_SAP());

              
                Assert.True(program.RETURN_CODE == 99);
            }
        }


    }
}