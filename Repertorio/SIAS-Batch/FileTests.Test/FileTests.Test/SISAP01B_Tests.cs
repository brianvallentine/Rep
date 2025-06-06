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
using static Code.SISAP01B;

namespace FileTests.Test
{
    [Collection("SISAP01B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class SISAP01B_Tests
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

            #region SISAP01B_LE_MOVDEBCE

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
                { "PRODUTO_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SISAP01B_LE_MOVDEBCE", q3);

            #endregion

            #region SISAP01B_IMPOSTOS

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
                { "FIPADOIM_COD_IMPOSTO_SAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SISAP01B_IMPOSTOS", q4);

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

            #region R5000_SELECT_DOC_FISCAL_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "FIPADOFI_NUM_DOC_FISCAL" , ""},
                { "FIPADOFI_SERIE_DOC_FISCAL" , ""},
                { "FIPADOFI_DATA_EMISSAO_DOC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_SELECT_DOC_FISCAL_DB_SELECT_1_Query1", q8);

            #endregion

            #region R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
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
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "GEOPERAC_IND_TIPO_FUNCAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1", q9);

            #endregion

            #region R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "SINILT01_NUM_APOL_SINISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1", q10);

            #endregion

            #region R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1", q11);

            #endregion

            #region R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
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
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "GEOPERAC_IND_TIPO_FUNCAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1", q12);

            #endregion

            #region R2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "FIPADOFI_NUM_DOC_FISCAL" , ""},
                { "FIPADOFI_SERIE_DOC_FISCAL" , ""},
                { "FIPADOFI_DATA_EMISSAO_DOC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1", q13);

            #endregion

            #region R2040_PEGA_SERVICO_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "FORNECED_CEP" , ""},
                { "FORNECED_COD_SERVICO_ISS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2040_PEGA_SERVICO_DB_SELECT_1_Query1", q14);

            #endregion

            #region R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "CEPFXFIL_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1", q15);

            #endregion

            #region R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "HOST_CURRENT_TIMESTAMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1", q16);

            #endregion

            #region R19200_SELECT_REINF_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "SINISLAN_COD_FONTE" , ""},
                { "SINISLAN_NUM_LOTE" , ""},
                { "SINISLAN_NUM_APOL_SINISTRO" , ""},
                { "SINISLAN_OCORR_HISTORICO" , ""},
                { "SINISLAN_COD_OPERACAO" , ""},
                { "SINISLAN_VAL_OPERACAO" , ""},
                { "SINISLAN_COD_PROCESSO_JURID" , ""},
                { "SINISLAN_SEQ_TP_SERVICO_INSS" , ""},
                { "SINISLAN_SEQ_INDICATIVO_OBRA" , ""},
                { "SINISLAN_COD_NACIONAL_OBRA" , ""},
                { "SINISLAN_VLR_CUSTO_N_BASE_INSS" , ""},
                { "SINISLAN_VLR_BASE_CALCULO_INSS" , ""},
                { "SINISLAN_VLR_INSS_SUBCONTRATO" , ""},
                { "SINISCAP_NUM_DOCF_INTERNO" , ""},
                { "SINISCAP_NUM_CPF_CNPJ_FAVOREC" , ""},
                { "SINISCAP_NUM_CPF_CNPJ_TOMADOR" , ""},
                { "SINISCAP_SEQ_CNAE_CPRB" , ""},
                { "SINISCAP_VLR_TOTAL_DOCUMENTO" , ""},
                { "SINISCAP_IND_GRUPO_LANCAMENTO" , ""},
                { "SINISCAP_IND_ISENCAO_TRIBUTO" , ""},
                { "SINISCAP_COD_IMPOSTO_LIMINAR" , ""},
                { "SINISCAP_COD_PROCESSO_ISENCAO" , ""},
                { "SINISCAP_VLR_RET_N_EFETUADO" , ""},
                { "SINISCAP_PCT_CPRB" , ""},
                { "SINISCAP_IND_DESC_INSS" , ""},
                { "SINISCAP_COD_SERVICO_CONTABIL" , ""},
                { "SINISCAP_COD_NAT_RENDIMENTO" , ""},
                { "SINISCAP_COD_IMPOSTO_ISS" , ""},
                { "SINISCAP_PCT_ALIQ_ISS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R19200_SELECT_REINF_DB_SELECT_1_Query1", q17);

            #endregion

            #region R19300_SELECT_INSS_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "GE612_COD_TP_SERVICO_INSS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R19300_SELECT_INSS_DB_SELECT_1_Query1", q18);

            #endregion

            #region R19400_VERIFICA_OPERACAO_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "GEOPERAC_COD_OPERACAO" , ""},
                { "GEOPERAC_DES_OPERACAO" , ""},
                { "GEOPERAC_FUNCAO_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R19400_VERIFICA_OPERACAO_DB_SELECT_1_Query1", q19);

            #endregion

            #endregion
        }

        [Fact]
        public static void SISAP01B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                GE0005S_Tests.Load_Parameters();

                #region R0510_00_SELECT_CALENDAR_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DIA_SEMANA" , "D"},
                { "CALENDAR_FERIADO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R0510_00_SELECT_CALENDAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0510_00_SELECT_CALENDAR_DB_SELECT_1_Query1", q0);

                #endregion

                #region R1100_00_SELECT_GE292_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "GE292_COD_GRUPO_SUSEP" , "1"},
                { "GE292_COD_RAMO_SUSEP" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_GE292_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_GE292_DB_SELECT_1_Query1", q1);

                #endregion

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-27"},
                { "SISTEMAS_DATULT_PROCESSAMEN" , "2025-03-25"},
                { "HOST_CURRENT_DATE" , "2025-03-25"},
                { "HOST_CURRENT_TIME" , "09:52:47"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1", q30);

                #endregion

                #region R0010_SELECT_SISTEMAS_DB_SELECT_2_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "HOST_SI_DATA_MOV_ABERTO" , "2025-01-27"},
                { "HOST_SI_CURRENT_DATE" , "2025-03-25"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0010_SELECT_SISTEMAS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_SELECT_SISTEMAS_DB_SELECT_2_Query1", q31);

                #endregion

                #region R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "10"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1", q2);

                #endregion

                #region SISAP01B_LE_MOVDEBCE

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "W_NOME_QUERY" , "X"},
                { "SINISHIS_TIPO_REGISTRO" , "X"},
                { "W_NOME_TIPO_SEGURO" , "X"},
                { "SINISHIS_NUM_APOLICE" , "1"},
                { "SINISHIS_NUM_APOL_SINISTRO" , "2"},
                { "SINISHIS_OCORR_HISTORICO" , "X"},
                { "SINISHIS_COD_OPERACAO" , "1070"},
                { "SINISHIS_NOME_FAVORECIDO" , "X"},
                { "W_ANO_OPERACIONAL_MOVIMENTO" , "2000"},
                { "W_ANO_CONTABIL_MOVIMENTO" , "2000"},
                { "GEOPERAC_FUNCAO_OPERACAO" , "EIND"},
                { "GEOPERAC_DES_OPERACAO" , "X"},
                { "SINISHIS_VAL_OPERACAO" , "100"},
                { "MOVDEBCE_VLR_CREDITO" , "100"},
                { "MOVDEBCE_VALOR_DEBITO" , "100"},
                { "SINISHIS_DATA_MOVIMENTO" , "2021-01-01"},
                { "SINISHIS_COD_PREST_SERVICO" , "5"},
                { "SINISHIS_COD_SERVICO" , "6"},
                { "SINISHIS_SIT_CONTABIL" , "7"},
                { "W_NOME_FORMA_PAGAMENTO" , "X"},
                { "SINISHIS_NOM_PROGRAMA" , "FI0096B"},
                { "SINISHIS_COD_USUARIO" , "8"},
                { "SINISMES_RAMO" , "66"},
                { "SINISMES_COD_FONTE" , "9"},
                { "W_DATA_AVISO_SIAS" , "2020-01-01"},
                { "SINISMES_DATA_COMUNICADO" , "2020-01-01"},
                { "SINISMES_COD_PRODUTO" , "11"},
                { "PRODUTO_DESCR_PRODUTO" , "X"},
                { "CHEQUEMI_NUM_CHEQUE_INTERNO" , "13"},
                { "MOVDEBCE_NUM_APOLICE" , "14"},
                { "MOVDEBCE_NUM_ENDOSSO" , "15"},
                { "MOVDEBCE_NUM_PARCELA" , "16"},
                { "MOVDEBCE_SITUACAO_COBRANCA" , "X"},
                { "W_NOME_SITUACAO_COBRANCA" , "X"},
                { "MOVDEBCE_DATA_VENCIMENTO" , "2020-01-01"},
                { "MOVDEBCE_DATA_MOVIMENTO" , "2020-01-01"},
                { "MOVDEBCE_COD_AGENCIA_DEB" , "17"},
                { "MOVDEBCE_OPER_CONTA_DEB" , "18"},
                { "MOVDEBCE_NUM_CONTA_DEB" , "19"},
                { "MOVDEBCE_DIG_CONTA_DEB" , "20"},
                { "MOVDEBCE_COD_CONVENIO" , "21"},
                { "MOVDEBCE_DATA_ENVIO" , "2020-01-01"},
                { "MOVDEBCE_NSAS" , "22"},
                { "MOVDEBCE_NUM_REQUISICAO" , "23"},
                { "GE369_COD_AGENCIA" , "24"},
                { "GE369_COD_BANCO" , "25"},
                { "GE369_NUM_CONTA_CNB" , "26"},
                { "GE369_NUM_DV_CONTA_CNB" , "27"},
                { "GE369_IND_CONTA_BANCARIA" , "28"},
                { "PRODUTO_COD_EMPRESA" , "29"},
                });
                AppSettings.TestSet.DynamicData.Remove("SISAP01B_LE_MOVDEBCE");
                AppSettings.TestSet.DynamicData.Add("SISAP01B_LE_MOVDEBCE", q3);

                #endregion

                #region SISAP01B_IMPOSTOS

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "1"},
                { "SINISHIS_OCORR_HISTORICO" , "2"},
                { "SINISHIS_COD_OPERACAO" , "1070"},
                { "SIPADOFI_NUM_DOCF_INTERNO" , "4"},
                { "FIPADOLA_COD_TP_LANCDOCF" , "5"},
                { "GETPLADO_ABREV_LANCDOCF" , "6"},
                { "FIPADOLA_VALOR_LANCAMENTO" , "100"},
                { "GETIPIMP_COD_IMP_INTERNO" , "7"},
                { "GETIPIMP_SIGLA_IMP" , "X"},
                { "FIPADOIM_ALIQ_TRIBUTACAO" , "100"},
                { "FIPADOIM_VALOR_IMPOSTO" , "100"},
                { "FIPADOIM_COD_IMPOSTO_SAP" , "11"},
                });
                AppSettings.TestSet.DynamicData.Remove("SISAP01B_IMPOSTOS");
                AppSettings.TestSet.DynamicData.Add("SISAP01B_IMPOSTOS", q4);

                #endregion

                #region R3010_ACESSA_SCPJUD_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "1"}
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

                #endregion

                #region R3210_LE_FORNECEDOR_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "FORNECED_INSC_PREFEITURA" , "1"},
                { "FORNECED_INSC_ESTADUAL" , "2"},
                { "FORNECED_OPT_SIMPLES_FED" , "3"},
                { "FORNECED_OPT_SIMPLES_MUN" , "4"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3210_LE_FORNECEDOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3210_LE_FORNECEDOR_DB_SELECT_1_Query1", q7);

                #endregion

                #region R5000_SELECT_DOC_FISCAL_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "FIPADOFI_NUM_DOC_FISCAL" , "1"},
                { "FIPADOFI_SERIE_DOC_FISCAL" , "2"},
                { "FIPADOFI_DATA_EMISSAO_DOC" , "2020-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R5000_SELECT_DOC_FISCAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R5000_SELECT_DOC_FISCAL_DB_SELECT_1_Query1", q8);

                #endregion

                #region R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "1"},
                { "SINISHIS_OCORR_HISTORICO" , "2"},
                { "SINISHIS_COD_OPERACAO" , "1070"},
                { "GEOPERAC_FUNCAO_OPERACAO" , "EIND"},
                { "GEOPERAC_DES_OPERACAO" , "X"},
                { "GE368_NUM_OCORR_MOVTO" , "5"},
                { "GE368_NUM_PESSOA" , "X"},
                { "OD001_IND_PESSOA" , "1"},
                { "W_NUMERO_CPF_BASE" , "123456"},
                { "OD002_NOM_PESSOA" , "X"},
                { "W_PF_INSC_PREFEITURA" , "123456"},
                { "W_PF_INSC_ESTADUAL" , "123456"},
                { "W_PF_NUM_INSC_SOCIAL" , "123456"},
                { "W_PF_NUM_DV_INSC_SOCIAL" , "123456"},
                { "W_NUMERO_CNPJ_BASE" , "123456"},
                { "OD003_NOM_RAZAO_SOCIAL" , "X"},
                { "W_PJ_INSC_PREFEITURA" , "123456"},
                { "W_PJ_INSC_ESTADUAL" , "123456"},
                { "W_PJ_NUM_INSC_SOCIAL" , "123456"},
                { "W_PJ_NUM_DV_INSC_SOCIAL" , "123456"},
                { "OD007_NOM_LOGRADOURO" , "X"},
                { "OD007_DES_NUM_IMOVEL" , "X"},
                { "OD007_DES_COMPL_ENDERECO" , "X"},
                { "OD007_NOM_BAIRRO" , "X"},
                { "OD007_NOM_CIDADE" , "X"},
                { "OD007_COD_CEP" , "123456"},
                { "OD007_COD_UF" , "SP"},
                { "SINISHIS_NOME_FAVORECIDO" , "X"},
                { "GEOPERAC_IND_TIPO_FUNCAO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1", q9);

                #endregion

                #region R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "SINILT01_NUM_APOL_SINISTRO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1", q10);

                #endregion

                #region R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "FORNECED_NOME_FORNECEDOR" , "X"},
                { "FORNECED_TIPO_PESSOA" , "1"},
                { "W_NOME_TIPO_PESSOA" , "X"},
                { "FORNECED_CGCCPF" , "123456"},
                { "FORNECED_ENDERECO" , "X"},
                { "FORNECED_BAIRRO" , "X"},
                { "FORNECED_CIDADE" , "X"},
                { "FORNECED_CEP" , "123456"},
                { "FORNECED_SIGLA_UF" , "SP"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1", q11);

                #endregion

                #region R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "1"},
                { "SINISHIS_OCORR_HISTORICO" , "2"},
                { "SINISHIS_COD_OPERACAO" , "1070"},
                { "GEOPERAC_FUNCAO_OPERACAO" , "EIND"},
                { "GEOPERAC_DES_OPERACAO" , "X"},
                { "FORNECED_TIPO_PESSOA" , "F"},
                { "W_NOME_TIPO_PESSOA" , "X"},
                { "FORNECED_CGCCPF" , "123456"},
                { "FORNECED_NOME_FORNECEDOR" , "X"},
                { "FORNECED_INSC_PREFEITURA" , "123456"},
                { "FORNECED_INSC_ESTADUAL" , "123456"},
                { "FORNECED_OPT_SIMPLES_FED" , "5"},
                { "FORNECED_OPT_SIMPLES_MUN" , "6"},
                { "FORNECED_ENDERECO" , "X"},
                { "FORNECED_BAIRRO" , "X"},
                { "FORNECED_CIDADE" , "X"},
                { "FORNECED_CEP" , "12365"},
                { "FORNECED_SIGLA_UF" , "SP"},
                { "SINISHIS_NOME_FAVORECIDO" , "X"},
                { "GEOPERAC_IND_TIPO_FUNCAO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1", q12);


                #endregion

                #region R2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "FIPADOFI_NUM_DOC_FISCAL" , "1"},
                { "FIPADOFI_SERIE_DOC_FISCAL" , "2"},
                { "FIPADOFI_DATA_EMISSAO_DOC" , "2020-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1", q13);

                #endregion

                #region R2040_PEGA_SERVICO_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "FORNECED_CEP" , "123456"},
                { "FORNECED_COD_SERVICO_ISS" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2040_PEGA_SERVICO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2040_PEGA_SERVICO_DB_SELECT_1_Query1", q14);

                #endregion

                #region R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "CEPFXFIL_FONTE" , "123456"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1", q15);

                #endregion

                #region R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "HOST_CURRENT_TIMESTAMP" , "2001-09-12 11:38:49.190"}
                });
                AppSettings.TestSet.DynamicData.Remove("R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1", q16);

                #endregion

                #region R19200_SELECT_REINF_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "SINISLAN_COD_FONTE" , "1"},
                { "SINISLAN_NUM_LOTE" , "2"},
                { "SINISLAN_NUM_APOL_SINISTRO" , "3"},
                { "SINISLAN_OCORR_HISTORICO" , "4"},
                { "SINISLAN_COD_OPERACAO" , "5"},
                { "SINISLAN_VAL_OPERACAO" , "100"},
                { "SINISLAN_COD_PROCESSO_JURID" , "6"},
                { "SINISLAN_SEQ_TP_SERVICO_INSS" , "7"},
                { "SINISLAN_SEQ_INDICATIVO_OBRA" , "8"},
                { "SINISLAN_COD_NACIONAL_OBRA" , "9"},
                { "SINISLAN_VLR_CUSTO_N_BASE_INSS" , "100"},
                { "SINISLAN_VLR_BASE_CALCULO_INSS" , "100"},
                { "SINISLAN_VLR_INSS_SUBCONTRATO" , "100"},
                { "SINISCAP_NUM_DOCF_INTERNO" , "123465"},
                { "SINISCAP_NUM_CPF_CNPJ_FAVOREC" , "123456"},
                { "SINISCAP_NUM_CPF_CNPJ_TOMADOR" , "123456"},
                { "SINISCAP_SEQ_CNAE_CPRB" , "2"},
                { "SINISCAP_VLR_TOTAL_DOCUMENTO" , "100"},
                { "SINISCAP_IND_GRUPO_LANCAMENTO" , "1"},
                { "SINISCAP_IND_ISENCAO_TRIBUTO" , "2"},
                { "SINISCAP_COD_IMPOSTO_LIMINAR" , "3"},
                { "SINISCAP_COD_PROCESSO_ISENCAO" , "4"},
                { "SINISCAP_VLR_RET_N_EFETUADO" , "5"},
                { "SINISCAP_PCT_CPRB" , "6"},
                { "SINISCAP_IND_DESC_INSS" , "123456"},
                { "SINISCAP_COD_SERVICO_CONTABIL" , "7"},
                { "SINISCAP_COD_NAT_RENDIMENTO" , "8"},
                { "SINISCAP_COD_IMPOSTO_ISS" , "9"},
                { "SINISCAP_PCT_ALIQ_ISS" , "10"},
                });
                AppSettings.TestSet.DynamicData.Remove("R19200_SELECT_REINF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R19200_SELECT_REINF_DB_SELECT_1_Query1", q17);

                #endregion

                #region R19300_SELECT_INSS_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "GE612_COD_TP_SERVICO_INSS" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R19300_SELECT_INSS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R19300_SELECT_INSS_DB_SELECT_1_Query1", q18);

                #endregion

                #region R19400_VERIFICA_OPERACAO_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "GEOPERAC_COD_OPERACAO" , "1"},
                { "GEOPERAC_DES_OPERACAO" , "X"},
                { "GEOPERAC_FUNCAO_OPERACAO" , "EIND"},
                });
                AppSettings.TestSet.DynamicData.Remove("R19400_VERIFICA_OPERACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R19400_VERIFICA_OPERACAO_DB_SELECT_1_Query1", q19);

                #endregion


                #endregion
                var program = new SISAP01B();

                SISAP01B_REGISTRO_LINKAGE_SAP obj = new SISAP01B_REGISTRO_LINKAGE_SAP();
                obj.LK_SAP_COD_CONVENIO.Value = 600128;


                program.LK_SAP_COD_PROGRAMA.Value = "FI0096B";
                program.Execute(obj);
                //program.Execute(new SISAP01B_REGISTRO_LINKAGE_SAP());


                var envList1 = AppSettings.TestSet.DynamicData["R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["R0010_SELECT_SISTEMAS_DB_SELECT_2_Query1"].DynamicList;
                Assert.Empty(envList2);

                var envList3 = AppSettings.TestSet.DynamicData["R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList3);

                var envList4 = AppSettings.TestSet.DynamicData["SISAP01B_LE_MOVDEBCE"].DynamicList;
                Assert.Empty(envList4);

                
                //var envList6 = AppSettings.TestSet.DynamicData["R3010_ACESSA_SCPJUD_DB_SELECT_1_Query1"].DynamicList;
               // Assert.Empty(envList6);

                var envList14 = AppSettings.TestSet.DynamicData["R19200_SELECT_REINF_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList14);

                var envList15 = AppSettings.TestSet.DynamicData["R19300_SELECT_INSS_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList15);

                 // var envList5 = AppSettings.TestSet.DynamicData["SISAP01B_IMPOSTOS"].DynamicList;
                 // Assert.Empty(envList5);

              //  var envList7 = AppSettings.TestSet.DynamicData["R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1"].DynamicList;
                //Assert.Empty(envList7);
                
                //var envList8 = AppSettings.TestSet.DynamicData["R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1"].DynamicList;
                //Assert.Empty(envList8);

                 //var envList9 = AppSettings.TestSet.DynamicData["R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1"].DynamicList;
                // Assert.Empty(envList9);

                 //var envList10 = AppSettings.TestSet.DynamicData["R2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1"].DynamicList;
                 // Assert.Empty(envList10);

                    //var envList11 = AppSettings.TestSet.DynamicData["R2040_PEGA_SERVICO_DB_SELECT_1_Query1"].DynamicList;
                     //Assert.Empty(envList11);

                 // var envList12 = AppSettings.TestSet.DynamicData["R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1"].DynamicList;
                 // Assert.Empty(envList12);

                 //var envList13 = AppSettings.TestSet.DynamicData["R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1"].DynamicList;
               // Assert.Empty(envList13);

              //  var envList16 = AppSettings.TestSet.DynamicData["R19400_VERIFICA_OPERACAO_DB_SELECT_1_Query1"].DynamicList;
              // Assert.Empty(envList16);


                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void SISAP01B_Tests99_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                GE0005S_Tests.Load_Parameters();

                #region R0510_00_SELECT_CALENDAR_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DIA_SEMANA" , "D"},
                { "CALENDAR_FERIADO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R0510_00_SELECT_CALENDAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0510_00_SELECT_CALENDAR_DB_SELECT_1_Query1", q0);

                #endregion

                #region R1100_00_SELECT_GE292_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "GE292_COD_GRUPO_SUSEP" , "1"},
                { "GE292_COD_RAMO_SUSEP" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_GE292_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_GE292_DB_SELECT_1_Query1", q1);

                #endregion

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q30 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1", q30);

                #endregion

                #region R0010_SELECT_SISTEMAS_DB_SELECT_2_Query1

                var q31 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0010_SELECT_SISTEMAS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_SELECT_SISTEMAS_DB_SELECT_2_Query1", q31);

                #endregion

                #region R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "10"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1", q2);

                #endregion

                #region SISAP01B_LE_MOVDEBCE

                var q3 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("SISAP01B_LE_MOVDEBCE");
                AppSettings.TestSet.DynamicData.Add("SISAP01B_LE_MOVDEBCE", q3);

                #endregion

                #region SISAP01B_IMPOSTOS

                var q4 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("SISAP01B_IMPOSTOS");
                AppSettings.TestSet.DynamicData.Add("SISAP01B_IMPOSTOS", q4);

                #endregion

                #region R3010_ACESSA_SCPJUD_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R3010_ACESSA_SCPJUD_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3010_ACESSA_SCPJUD_DB_SELECT_1_Query1", q5);

                #endregion

                #region R3010_ACESSA_SCPJUD_DB_SELECT_2_Query1

                var q6 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R3010_ACESSA_SCPJUD_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R3010_ACESSA_SCPJUD_DB_SELECT_2_Query1", q6);

                #endregion

                #region R3210_LE_FORNECEDOR_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R3210_LE_FORNECEDOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3210_LE_FORNECEDOR_DB_SELECT_1_Query1", q7);

                #endregion

                #region R5000_SELECT_DOC_FISCAL_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                
                AppSettings.TestSet.DynamicData.Remove("R5000_SELECT_DOC_FISCAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R5000_SELECT_DOC_FISCAL_DB_SELECT_1_Query1", q8);

                #endregion

                #region R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1

                var q9 = new DynamicData();
               
                AppSettings.TestSet.DynamicData.Remove("R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1", q9);

                #endregion

                #region R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1", q10);

                #endregion

                #region R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1

                var q11 = new DynamicData();
                              AppSettings.TestSet.DynamicData.Remove("R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1", q11);

                #endregion

                #region R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1

                var q12 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1", q12);


                #endregion

                #region R2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1

                var q13 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("R2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1", q13);

                #endregion

                #region R2040_PEGA_SERVICO_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                
                AppSettings.TestSet.DynamicData.Remove("R2040_PEGA_SERVICO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2040_PEGA_SERVICO_DB_SELECT_1_Query1", q14);

                #endregion

                #region R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                
                AppSettings.TestSet.DynamicData.Remove("R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1", q15);

                #endregion

                #region R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                
                AppSettings.TestSet.DynamicData.Remove("R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1", q16);

                #endregion

                #region R19200_SELECT_REINF_DB_SELECT_1_Query1

                var q17 = new DynamicData();
              
                AppSettings.TestSet.DynamicData.Remove("R19200_SELECT_REINF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R19200_SELECT_REINF_DB_SELECT_1_Query1", q17);

                #endregion

                #region R19300_SELECT_INSS_DB_SELECT_1_Query1

                var q18 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("R19300_SELECT_INSS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R19300_SELECT_INSS_DB_SELECT_1_Query1", q18);

                #endregion

                #region R19400_VERIFICA_OPERACAO_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "GEOPERAC_COD_OPERACAO" , "1"},
                { "GEOPERAC_DES_OPERACAO" , "X"},
                { "GEOPERAC_FUNCAO_OPERACAO" , "EIND"},
                });
                AppSettings.TestSet.DynamicData.Remove("R19400_VERIFICA_OPERACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R19400_VERIFICA_OPERACAO_DB_SELECT_1_Query1", q19);

                #endregion


                #endregion
                var program = new SISAP01B();

                SISAP01B_REGISTRO_LINKAGE_SAP obj = new SISAP01B_REGISTRO_LINKAGE_SAP();
                obj.LK_SAP_COD_CONVENIO.Value = 600128;


                program.LK_SAP_COD_PROGRAMA.Value = "FI0096B";
                program.Execute(obj);
                //program.Execute(new SISAP01B_REGISTRO_LINKAGE_SAP());


                Assert.True(program.RETURN_CODE == 99);
            }
        }

    }
}