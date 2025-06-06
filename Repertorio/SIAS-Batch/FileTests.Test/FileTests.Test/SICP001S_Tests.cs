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
using static Code.SICP001S;

namespace FileTests.Test
{
    [Collection("SICP001S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class SICP001S_Tests
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

            #region SICP001S_LE_MOVDEBCE

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
                { "GEOPERAC_IND_TIPO_FUNCAO" , ""},
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
            AppSettings.TestSet.DynamicData.Add("SICP001S_LE_MOVDEBCE", q3);

            #endregion

            #region SICP001S_IMPOSTOS

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
            AppSettings.TestSet.DynamicData.Add("SICP001S_IMPOSTOS", q4);

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

            #region R3010_ACESSA_SCPJUD_DB_SELECT_3_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SIPROJUD_COD_PROCESSO_JURID" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3010_ACESSA_SCPJUD_DB_SELECT_3_Query1", q7);

            #endregion

            #region R3210_LE_FORNECEDOR_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "FORNECED_INSC_PREFEITURA" , ""},
                { "FORNECED_INSC_ESTADUAL" , ""},
                { "FORNECED_OPT_SIMPLES_FED" , ""},
                { "FORNECED_OPT_SIMPLES_MUN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3210_LE_FORNECEDOR_DB_SELECT_1_Query1", q8);

            #endregion

            #region R5000_SELECT_DOC_FISCAL_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "FIPADOFI_NUM_DOC_FISCAL" , ""},
                { "FIPADOFI_SERIE_DOC_FISCAL" , ""},
                { "FIPADOFI_DATA_EMISSAO_DOC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_SELECT_DOC_FISCAL_DB_SELECT_1_Query1", q9);

            #endregion

            #region R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1", q10);

            #endregion

            #region R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SINILT01_NUM_APOL_SINISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1", q11);

            #endregion

            #region R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1", q12);

            #endregion

            #region R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1", q13);

            #endregion

            #region R2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "FIPADOFI_NUM_DOC_FISCAL" , ""},
                { "FIPADOFI_SERIE_DOC_FISCAL" , ""},
                { "FIPADOFI_DATA_EMISSAO_DOC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1", q14);

            #endregion

            #region R2040_PEGA_SERVICO_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "FORNECED_CEP" , ""},
                { "FORNECED_COD_SERVICO_ISS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2040_PEGA_SERVICO_DB_SELECT_1_Query1", q15);

            #endregion

            #region R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "CEPFXFIL_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1", q16);

            #endregion

            #region P7011_SI1_INSERT_DB_INSERT_1_Insert1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_EMPRESA" , ""},
                { "SINISHIS_TIPO_REGISTRO" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_DATA_LIM_CORRECAO" , ""},
                { "SINISHIS_TIPO_FAVORECIDO" , ""},
                { "SINISHIS_DATA_NEGOCIADA" , ""},
                { "SINISHIS_FONTE_PAGAMENTO" , ""},
                { "SINISHIS_COD_PREST_SERVICO" , ""},
                { "SINISHIS_COD_SERVICO" , ""},
                { "SINISHIS_ORDEM_PAGAMENTO" , ""},
                { "SINISHIS_NUM_RECIBO" , ""},
                { "SINISHIS_NUM_MOV_SINISTRO" , ""},
                { "SINISHIS_COD_USUARIO" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_SIT_REGISTRO" , ""},
                { "SINISHIS_NUM_APOLICE" , ""},
                { "SINISHIS_COD_PRODUTO" , ""},
                { "SINISHIS_NOM_PROGRAMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P7011_SI1_INSERT_DB_INSERT_1_Insert1", q17);

            #endregion

            #region P7011_SI2_SELECT_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_EMPRESA" , ""},
                { "SINISHIS_TIPO_REGISTRO" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_HORA_OPERACAO" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_DATA_LIM_CORRECAO" , ""},
                { "SINISHIS_TIPO_FAVORECIDO" , ""},
                { "SINISHIS_DATA_NEGOCIADA" , ""},
                { "SINISHIS_FONTE_PAGAMENTO" , ""},
                { "SINISHIS_COD_PREST_SERVICO" , ""},
                { "SINISHIS_COD_SERVICO" , ""},
                { "SINISHIS_ORDEM_PAGAMENTO" , ""},
                { "SINISHIS_NUM_RECIBO" , ""},
                { "SINISHIS_NUM_MOV_SINISTRO" , ""},
                { "SINISHIS_COD_USUARIO" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_SIT_REGISTRO" , ""},
                { "SINISHIS_TIMESTAMP" , ""},
                { "SINISHIS_NUM_APOLICE" , ""},
                { "SINISHIS_COD_PRODUTO" , ""},
                { "SINISHIS_NOM_PROGRAMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P7011_SI2_SELECT_DB_SELECT_1_Query1", q18);

            #endregion

            #region P7011_SI3_UPDATE_DB_UPDATE_1_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NOM_PROGRAMA" , ""},
                { "WH_PROGRAMA_NULL" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P7011_SI3_UPDATE_DB_UPDATE_1_Update1", q19);

            #endregion

            #region P7237_SI1_INSERT_DB_INSERT_1_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "SI237_NUM_SINISTRO" , ""},
                { "SI237_OCORR_HISTORICO" , ""},
                { "SI237_IDE_SISTEMA" , ""},
                { "SI237_COD_OPERACAO" , ""},
                { "SI237_NUM_ID_ENVIO" , ""},
                { "SI237_SEQ_ID_ENVIO_HIST" , ""},
                { "SI237_STA_ENVIO_MOVIMENTO" , ""},
                { "SI237_DTA_SI_ENVIO" , ""},
                { "SI237_DTA_SI_RETORNO_H" , ""},
                { "SI237_DTA_EFETIVO_PGTO" , ""},
                { "SI237_COD_USUARIO" , ""},
                { "SI237_COD_PROGRAMA" , ""},
                { "SI237_SEQ_MOVTO_ARQH" , ""},
                { "SI237_STA_MOVTO_HISTORICO" , ""},
                { "SI237_QTD_RETORNO_ARQH" , ""},
                { "SI237_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P7237_SI1_INSERT_DB_INSERT_1_Insert1", q20);

            #endregion

            #region P7237_SI2_SELECT_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "SI237_NUM_ID_ENVIO" , ""},
                { "SI237_SEQ_ID_ENVIO_HIST" , ""},
                { "SI237_STA_ENVIO_MOVIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P7237_SI2_SELECT_DB_SELECT_1_Query1", q21);

            #endregion

            #region P7237_SI3_UPDATE_DB_UPDATE_1_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "SI237_SEQ_ID_ENVIO_HIST" , ""},
                { "WH_ID_ENVIO_HIST_NULL" , ""},
                { "SI237_DTA_SI_RETORNO_H" , ""},
                { "WH_SI_RETORNO_H_NULL" , ""},
                { "SI237_DTA_EFETIVO_PGTO" , ""},
                { "WH_EFETIVO_PGTO_NULL" , ""},
                { "SI237_NUM_ID_ENVIO" , ""},
                { "WH_ID_ENVIO_NULL" , ""},
                { "SI237_DTA_SI_ENVIO" , ""},
                { "WH_SI_ENVIO_NULL" , ""},
                { "SI237_STA_ENVIO_MOVIMENTO" , ""},
                { "SINISHIS_COD_USUARIO" , ""},
                { "GE420_NOM_PROGRAMA" , ""},
                { "SI237_OCORR_HISTORICO" , ""},
                { "SI237_NUM_SINISTRO" , ""},
                { "SI237_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P7237_SI3_UPDATE_DB_UPDATE_1_Update1", q22);

            #endregion

            #region P7239_SI2_SELECT_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "SI239_IDE_SISTEMA" , ""},
                { "SI239_COD_OPERACAO" , ""},
                { "SI239_COD_EVENTO_SAP" , ""},
                { "SI239_COD_EVENTO_SAP_SFH" , ""},
                { "SI239_COD_EVENTO_SAP_JUD" , ""},
                { "SI239_COD_EMPRESA_SAP" , ""},
                { "SI239_COD_SISTEMA_SAP" , ""},
                { "SI239_COD_ORIGEM_SAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P7239_SI2_SELECT_DB_SELECT_1_Query1", q23);

            #endregion

            #region P7419_GE1_INSERT_DB_INSERT_1_Insert1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "GE419_NUM_ID_ENVIO" , ""},
                { "GE419_SEQ_ID_ENVIO_HIST" , ""},
                { "GE419_COD_IMPOSTO_INTERNO" , ""},
                { "GE419_COD_TRIBUTO_SAP" , ""},
                { "GE419_IND_TP_TRIBUTO" , ""},
                { "GE419_PCT_ALIQUOTA" , ""},
                { "GE419_VLR_BASE_TRIB" , ""},
                { "GE419_VLR_TRIBUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P7419_GE1_INSERT_DB_INSERT_1_Insert1", q24);

            #endregion

            #region P7420_GE1_INSERT_DB_INSERT_1_Insert1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "GE420_NUM_ID_ENVIO" , ""},
                { "GE420_SEQ_ID_ENVIO_HIST" , ""},
                { "GE420_STA_ENVIO_MOVIMENTO" , ""},
                { "GE420_COD_EMPRESA_SAP" , ""},
                { "GE420_COD_SISTEMA_SAP" , ""},
                { "GE420_COD_EVENTO_SAP" , ""},
                { "GE420_COD_CHAVE_NEGOCIO" , ""},
                { "GE420_COD_USUARIO_LIB" , ""},
                { "GE420_NOM_PROGRAMA" , ""},
                { "GE420_NOM_RAZ_SOCIAL" , ""},
                { "GE420_IND_TIPO_PESSOA" , ""},
                { "GE420_IND_SEXO" , ""},
                { "GE420_NUM_CPF_CNPJ" , ""},
                { "GE420_NUM_CPF_CNPJ_BENEF" , ""},
                { "GE420_NOM_LOGRADOURO" , ""},
                { "GE420_DES_NUM_RESIDENCIA" , ""},
                { "GE420_DES_COMPL_ENDERECO" , ""},
                { "GE420_NOM_BAIRRO" , ""},
                { "GE420_NOM_CIDADE" , ""},
                { "GE420_COD_UF" , ""},
                { "GE420_COD_CEP" , ""},
                { "GE420_DES_EMAIL" , ""},
                { "GE420_NUM_TELEFONE" , ""},
                { "GE420_DES_FAX" , ""},
                { "GE420_NUM_INSC_MUNICIPAL" , ""},
                { "GE420_NUM_INSC_ESTADUAL" , ""},
                { "GE420_IND_OPT_SIMPLES_FEDERAL" , ""},
                { "GE420_COD_CONVENIO" , ""},
                { "GE420_IND_TP_CONVENIO" , ""},
                { "GE420_IND_FORMA_PAG_COB" , ""},
                { "GE420_TXT_EMPRESA" , ""},
                { "GE420_COD_DOC_SIACC" , ""},
                { "GE420_DTA_SOL_PAGTO" , ""},
                { "GE420_COD_BANCO" , ""},
                { "GE420_COD_AGENCIA" , ""},
                { "GE420_NUM_DV_AGENCIA" , ""},
                { "GE420_NUM_OPERACAO_CONTA" , ""},
                { "GE420_NUM_CC" , ""},
                { "GE420_NUM_DV_CONTA" , ""},
                { "GE420_VLR_PAGTO" , ""},
                { "GE420_VLR_ATU_MONETARIA" , ""},
                { "GE420_VLR_ATU_JUROS" , ""},
                { "GE420_COD_CONGENERE" , ""},
                { "GE420_COD_FONTE_SIAS" , ""},
                { "GE420_COD_RAMO_SUSEP" , ""},
                { "GE420_COD_PRODUTO" , ""},
                { "GE420_NUM_APOLICE" , ""},
                { "GE420_NUM_SINISTRO" , ""},
                { "GE420_COD_OPERACAO" , ""},
                { "GE420_NUM_OCORR_HISTORICO" , ""},
                { "GE420_DTA_AVISO" , ""},
                { "GE420_DTA_COMUNICACAO" , ""},
                { "GE420_DTA_SENTENCA_JUDICIAL" , ""},
                { "GE420_DTA_COMUNIC_SENTEN" , ""},
                { "GE420_COD_PROCES_JURID" , ""},
                { "GE420_COD_SERVICO_SAP" , ""},
                { "GE420_COD_FONTE_ISS" , ""},
                { "GE420_NUM_DOC_FISCAL" , ""},
                { "GE420_NUM_SERIE_DOC_FISCAL" , ""},
                { "GE420_COD_AGRUPADOR" , ""},
                { "GE420_NUM_CPF_CNPJ_TOMADOR" , ""},
                { "GE420_COD_INDICATIVO_OBRA" , ""},
                { "GE420_COD_NACIONAL_OBRA" , ""},
                { "GE420_DTA_NOTA_FISCAL" , ""},
                { "GE420_COD_CNAE_CPRB" , ""},
                { "GE420_COD_PROCESSO_JUD" , ""},
                { "GE420_COD_TP_SERVICO_INSS" , ""},
                { "GE420_VLR_DEDUCAO_MEAT" , ""},
                { "GE420_VLR_RET_NOTA_FISC" , ""},
                { "GE420_VLR_RET_PRINCIPAL" , ""},
                { "GE420_COD_IMPOSTO_LIMINAR" , ""},
                { "GE420_NUM_PROPOSTA" , ""},
                { "GE420_NUM_CERTIFICADO" , ""},
                { "GE420_NUM_ENDOSSO" , ""},
                { "GE420_NUM_PARCELA" , ""},
                { "GE420_NUM_NIT_INSS" , ""},
                { "GE420_COD_CANAL_VENDA" , ""},
                { "GE420_NUM_TITULO" , ""},
                { "GE420_COD_CEDENTE" , ""},
                { "GE420_COD_COMPROMISSO" , ""},
                { "GE420_TXT_INFO_CART_CRED" , ""},
                { "GE420_QTD_PARCELA" , ""},
                { "GE420_NUM_IDLG_MCP" , ""},
                { "GE420_NUM_IDLG_SAP" , ""},
                { "GE420_DTA_ENVIO_MCP" , ""},
                { "GE420_DTA_RETORNO_SAP_ARQG" , ""},
                { "GE420_DTA_RETORNO_SAP_ARQH" , ""},
                { "GE420_DTA_EFETIVO_PGTO_COB" , ""},
                { "GE420_COD_MODULO_SAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P7420_GE1_INSERT_DB_INSERT_1_Insert1", q25);

            #endregion

            #region P7420_GE2_SELECT_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "GE420_NUM_ID_ENVIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P7420_GE2_SELECT_DB_SELECT_1_Query1", q26);

            #endregion

            #region P7420_GE3_UPDATE_DB_UPDATE_1_Update1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "GE420_COD_TP_SERVICO_INSS" , ""},
                { "GE420_SEQ_ID_ENVIO_HIST" , ""},
                { "GE420_NUM_ID_ENVIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P7420_GE3_UPDATE_DB_UPDATE_1_Update1", q27);

            #endregion

            #region R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "HOST_CURRENT_TIMESTAMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1", q28);

            #endregion

            #region R19200_SELECT_REINF_DB_SELECT_1_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R19200_SELECT_REINF_DB_SELECT_1_Query1", q29);

            #endregion

            #region R19300_SELECT_INSS_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "GE612_COD_TP_SERVICO_INSS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R19300_SELECT_INSS_DB_SELECT_1_Query1", q30);

            #endregion

            #region R19400_VERIFICA_OPERACAO_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "GEOPERAC_COD_OPERACAO" , ""},
                { "GEOPERAC_DES_OPERACAO" , ""},
                { "GEOPERAC_FUNCAO_OPERACAO" , ""},
                { "GEOPERAC_IND_TIPO_FUNCAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R19400_VERIFICA_OPERACAO_DB_SELECT_1_Query1", q31);

            #endregion

            #endregion
        }

        [Fact]
        public static void SICP001S_Tests_Fact()
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
                #endregion
                var program = new SICP001S();
                program.Execute(new SICP001S_SICPW001());

                Assert.True(true);
            }
        }
    }
}