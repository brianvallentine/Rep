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
using Dclgens;
using Code;
using static Code.SI9211B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI9211B_Tests")]
    public class SI9211B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "HOST_ANO_MOV_ABERTO" , ""},
                { "HOST_MES_MOV_ABERTO" , ""},
                { "HOST_DATA_30" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_SEQ_GERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , ""},
                { "GEARDETA_SEQ_GERACAO" , ""},
                { "HOST_ANO_MOV_ABERTO" , ""},
                { "HOST_MES_MOV_ABERTO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "GEARDETA_QTD_REG_PROCESSADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1", q2);

            #endregion

            #region R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , ""},
                { "GEARDETA_SEQ_GERACAO" , ""},
                { "SIARVRCZ_TIPO_REGISTRO" , ""},
                { "SIARVRCZ_SEQ_REGISTRO" , ""},
                { "SIARVRCZ_STA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1", q3);

            #endregion

            #region R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_QTD_REG_PROCESSADO" , ""},
                { "GEARDETA_NOM_ARQUIVO" , ""},
                { "GEARDETA_SEQ_GERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1", q4);

            #endregion

            #region SI9211B_C01_SIARDEVC

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NOM_ARQUIVO" , ""},
                { "SIARDEVC_SEQ_GERACAO" , ""},
                { "SIARDEVC_TIPO_REGISTRO" , ""},
                { "SIARDEVC_SEQ_REGISTRO" , ""},
                { "SIARDEVC_COD_OPERACAO" , ""},
                { "SIARDEVC_OCORR_HISTORICO" , ""},
                { "SIARDEVC_NUM_SINISTRO_VC" , ""},
                { "SIARDEVC_NUM_EXPEDIENTE_VC" , ""},
                { "SIARDEVC_NUM_APOLICE" , ""},
                { "SIARDEVC_NUM_ENDOSSO" , ""},
                { "SIARDEVC_NUM_ITEM" , ""},
                { "SIARDEVC_COD_RAMO" , ""},
                { "SIARDEVC_COD_COBERTURA" , ""},
                { "SIARDEVC_COD_CAUSA" , ""},
                { "SIARDEVC_DATA_COMUNICADO" , ""},
                { "SIARDEVC_DATA_OCORRENCIA" , ""},
                { "SIARDEVC_HORA_OCORRENCIA" , ""},
                { "SIARDEVC_DATA_MOVIMENTO" , ""},
                { "SIARDEVC_IND_FAVORECIDO" , ""},
                { "SIARDEVC_VAL_TOT_MOVIMENTO" , ""},
                { "SIARDEVC_VAL_PECAS" , ""},
                { "SIARDEVC_VAL_MAO_OBRA" , ""},
                { "SIARDEVC_VAL_PARCELA_PEND" , ""},
                { "SIARDEVC_QTD_PARCELA_PEND" , ""},
                { "SIARDEVC_VAL_DESC_PARC_PEND" , ""},
                { "SIARDEVC_DATA_NEGOCIADA" , ""},
                { "SIARDEVC_VAL_IRF" , ""},
                { "SIARDEVC_VAL_ISS" , ""},
                { "SIARDEVC_VAL_INSS" , ""},
                { "SIARDEVC_VAL_LIQUIDO_PAGTO" , ""},
                { "SIARDEVC_CGCCPF" , ""},
                { "SIARDEVC_TIPO_PESSOA" , ""},
                { "SIARDEVC_NOM_FAVORECIDO" , ""},
                { "SIARDEVC_IND_DOC_FISCAL" , ""},
                { "SIARDEVC_NUM_DOC_FISCAL" , ""},
                { "SIARDEVC_SERIE_DOC_FISCAL" , ""},
                { "SIARDEVC_DATA_EMISSAO" , ""},
                { "SIARDEVC_DES_ENDERECO" , ""},
                { "SIARDEVC_NOM_BAIRRO" , ""},
                { "SIARDEVC_NOM_CIDADE" , ""},
                { "SIARDEVC_COD_UF" , ""},
                { "SIARDEVC_NUM_CEP" , ""},
                { "SIARDEVC_NUM_DDD" , ""},
                { "SIARDEVC_NUM_TELEFONE" , ""},
                { "SIARDEVC_IND_FORMA_PAGTO" , ""},
                { "SIARDEVC_NUM_IDENTIFICADOR" , ""},
                { "SIARDEVC_NUM_CHEQUE_INTERNO" , ""},
                { "SIARDEVC_ORDEM_PAGAMENTO_VC" , ""},
                { "SIARDEVC_ORDEM_PAGAMENTO" , ""},
                { "SIARDEVC_COD_BANCO" , ""},
                { "SIARDEVC_COD_AGENCIA" , ""},
                { "SIARDEVC_OPERACAO_CONTA" , ""},
                { "SIARDEVC_COD_CONTA" , ""},
                { "SIARDEVC_DV_CONTA" , ""},
                { "SIARDEVC_COD_FAVORECIDO" , ""},
                { "SIARDEVC_NUM_APOL_SINISTRO" , ""},
                { "SIARDEVC_STA_PROCESSAMENTO" , ""},
                { "SIARDEVC_COD_ERRO" , ""},
                { "SIARDEVC_VAL_PISPASEP" , ""},
                { "SIARDEVC_VAL_COFINS" , ""},
                { "SIARDEVC_VAL_CSLL" , ""},
                { "SIARDEVC_COD_FONTE" , ""},
                { "SIARDEVC_NUM_RESSARC" , ""},
                { "SIARDEVC_IND_PESSOA_ACORDO" , ""},
                { "SIARDEVC_NUM_CPFCGC_ACORDO" , ""},
                { "SIARDEVC_NOM_RESP_ACORDO" , ""},
                { "SIARDEVC_STA_ACORDO" , ""},
                { "SIARDEVC_DTH_INDENIZACAO" , ""},
                { "SIARDEVC_VLR_INDENIZACAO" , ""},
                { "SIARDEVC_VLR_PART_TERCEIROS" , ""},
                { "SIARDEVC_VLR_DIVIDA" , ""},
                { "SIARDEVC_PCT_DESCONTO" , ""},
                { "SIARDEVC_VLR_TOTAL_DESCONTO" , ""},
                { "SIARDEVC_VLR_TOTAL_ACORDO" , ""},
                { "SIARDEVC_COD_MOEDA_ACORDO" , ""},
                { "SIARDEVC_DTH_ACORDO" , ""},
                { "SIARDEVC_QTD_PARCELAS_ACORDO" , ""},
                { "SIARDEVC_NUM_PARCELA_ACORDO" , ""},
                { "SIARDEVC_COD_AGENCIA_CEDENT" , ""},
                { "SIARDEVC_NUM_CEDENTE" , ""},
                { "SIARDEVC_NUM_CEDENTE_DV" , ""},
                { "SIARDEVC_DTH_VENCIMENTO" , ""},
                { "SIARDEVC_NUM_NOSSO_TITULO" , ""},
                { "SIARDEVC_VLR_TITULO" , ""},
                { "SIARDEVC_NUM_CPFCGC_RECLAMANTE" , ""},
                { "SIARDEVC_NOM_RECLAMANTE" , ""},
                { "SIARDEVC_VLR_RECLAMADO" , ""},
                { "SIARDEVC_VLR_PROVISIONADO" , ""},
                { "SIARDEVC_NUM_SINISTRO_CONV" , ""},
                { "SIARDEVC_NUM_IDENT_CONV" , ""},
                { "SIARDEVC_NUM_IDE_COBR_CONV" , ""},
                { "SIARDEVC_COD_CFOP" , ""},
                { "SIARDEVC_COD_CEST" , ""},
                { "SIARDEVC_NUM_INSCR_ESTADUAL" , ""},
                { "SIARDEVC_NUM_NCM" , ""},
                { "SIARDEVC_NUM_CPF_CNPJ_TOMADOR" , ""},
                { "SIARDEVC_IND_ISENCAO_TRIBUTO" , ""},
                { "SIARDEVC_COD_IMPOSTO_LIMINAR" , ""},
                { "SIARDEVC_COD_PROCESSO_ISENCAO" , ""},
                { "SIARDEVC_VLR_RET_N_EFETUADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI9211B_C01_SIARDEVC", q5);

            #endregion

            #region R1010_00_CHECA_ESTORNO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_DATA_MOVIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1010_00_CHECA_ESTORNO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1010_00_CHECA_ESTORNO_DB_SELECT_2_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NOM_PROGRAMA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1010_00_CHECA_ESTORNO_DB_SELECT_2_Query1", q7);

            #endregion

            #region R1060_00_LE_CAUSA_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_GRUPO_CAUSAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1060_00_LE_CAUSA_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1070_00_LE_MESTSINI_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_PRODUTO" , ""},
                { "SINISMES_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1070_00_LE_MESTSINI_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1100_00_LE_SIERRO_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "SIERRO_DES_ERRO" , ""}
            });
                        
            AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SIERRO_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1210_00_LE_MOVDEBCE_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_RETORNO_CEF" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_LE_MOVDEBCE_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1250_00_LE_SINISMES_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_FONTE" , ""},
                { "SINISMES_NUM_PROTOCOLO_SINI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1250_00_LE_SINISMES_DB_SELECT_1_Query1", q12);

            #endregion

            #region R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , ""},
                { "GEARDETA_SEQ_GERACAO" , ""},
                { "SIARREVC_TIPO_REGISTRO_VC" , ""},
                { "SIARREVC_SEQ_REGISTRO_VC" , ""},
                { "SIARDEVC_NOM_ARQUIVO" , ""},
                { "SIARDEVC_SEQ_GERACAO" , ""},
                { "SIARDEVC_TIPO_REGISTRO" , ""},
                { "SIARDEVC_SEQ_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1", q13);

            #endregion

            #region R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NUM_CHEQUE_INTERNO" , ""},
                { "SIARDEVC_NUM_IDENTIFICADOR" , ""},
                { "SIARDEVC_VAL_LIQUIDO_PAGTO" , ""},
                { "SIARDEVC_STA_PROCESSAMENTO" , ""},
                { "SIARDEVC_TIPO_REGISTRO" , ""},
                { "SIARDEVC_SEQ_REGISTRO" , ""},
                { "SIARDEVC_NOM_ARQUIVO" , ""},
                { "SIARDEVC_SEQ_GERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q14);

            #endregion

            #region R1450_CHECA_OP_BAIXA_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_ENDOSSO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1450_CHECA_OP_BAIXA_DB_SELECT_1_Query1", q15);

            #endregion

            #region R1510_00_CONSULTA_SINI_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_TIPO_FAVORECIDO" , ""},
                { "SINISHIS_DATA_NEGOCIADA" , ""},
                { "SINISHIS_FONTE_PAGAMENTO" , ""},
                { "SINISHIS_COD_PREST_SERVICO" , ""},
                { "SINISHIS_COD_SERVICO" , ""},
                { "SINISHIS_ORDEM_PAGAMENTO" , ""},
                { "SINISHIS_NUM_RECIBO" , ""},
                { "SINISHIS_NUM_MOV_SINISTRO" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_SIT_REGISTRO" , ""},
                { "SINISHIS_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1510_00_CONSULTA_SINI_DB_SELECT_1_Query1", q16);

            #endregion

            #region R1520_00_INCLUI_SINIS_DB_INSERT_1_Insert1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_DATA_NEGOCIADA" , ""},
                { "SINISHIS_TIPO_FAVORECIDO" , ""},
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
            AppSettings.TestSet.DynamicData.Add("R1520_00_INCLUI_SINIS_DB_INSERT_1_Insert1", q17);

            #endregion

            #region R1610_00_ATUAL_SI_PESS_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1610_00_ATUAL_SI_PESS_DB_SELECT_1_Query1", q18);

            #endregion

            #region R1610_00_ATUAL_SI_PESS_DB_UPDATE_1_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SIARDEVC_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1610_00_ATUAL_SI_PESS_DB_UPDATE_1_Update1", q19);

            #endregion

            #region R1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1_Query1", q20);

            #endregion

            #region R1620_00_ATUAL_SINI_CHEQ_DB_UPDATE_1_Update1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SIARDEVC_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1620_00_ATUAL_SINI_CHEQ_DB_UPDATE_1_Update1", q21);

            #endregion

            #region R1630_00_ATUAL_PAGA_DOCFIS_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1630_00_ATUAL_PAGA_DOCFIS_DB_SELECT_1_Query1", q22);

            #endregion

            #region R1630_00_ATUAL_PAGA_DOCFIS_DB_UPDATE_1_Update1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SIARDEVC_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1630_00_ATUAL_PAGA_DOCFIS_DB_UPDATE_1_Update1", q23);

            #endregion

            #region R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "GE369_NUM_APOLICE" , ""},
                { "GE369_NUM_ENDOSSO" , ""},
                { "GE369_NUM_PARCELA" , ""},
                { "GE369_COD_CONVENIO" , ""},
                { "GE369_NSAS" , ""},
                { "GE369_COD_AGENCIA" , ""},
                { "GE369_COD_BANCO" , ""},
                { "GE369_NUM_CONTA_CNB" , ""},
                { "GE369_NUM_DV_CONTA_CNB" , ""},
                { "GE369_IND_CONTA_BANCARIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1_Query1", q24);

            #endregion

            #region R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2_Query1", q25);

            #endregion

            #region R1641_00_DELET_GE_MOVTO_CONT_DB_DELETE_1_Delete1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1641_00_DELET_GE_MOVTO_CONT_DB_DELETE_1_Delete1", q26);

            #endregion

            #region R1642_00_ATUAL_MOVTO_DEBT_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1642_00_ATUAL_MOVTO_DEBT_DB_SELECT_1_Query1", q27);

            #endregion

            #region R1642_00_ATUAL_MOVTO_DEBT_DB_UPDATE_1_Update1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "AUX_COD_OPERACAO" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1642_00_ATUAL_MOVTO_DEBT_DB_UPDATE_1_Update1", q28);

            #endregion

            #region R1643_00_INSERT_GE_MOVTO_CONT_DB_INSERT_1_Insert1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "GE369_NUM_APOLICE" , ""},
                { "GE369_NUM_ENDOSSO" , ""},
                { "GE369_NUM_PARCELA" , ""},
                { "GE369_COD_CONVENIO" , ""},
                { "GE369_NSAS" , ""},
                { "GE369_COD_AGENCIA" , ""},
                { "GE369_COD_BANCO" , ""},
                { "GE369_NUM_CONTA_CNB" , ""},
                { "GE369_NUM_DV_CONTA_CNB" , ""},
                { "GE369_IND_CONTA_BANCARIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1643_00_INSERT_GE_MOVTO_CONT_DB_INSERT_1_Insert1", q29);

            #endregion

            #region R1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1_Query1", q30);

            #endregion

            #region R1660_00_ATUAL_MOVDEB_SAP_DB_UPDATE_1_Update1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_OPERACAO" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1660_00_ATUAL_MOVDEB_SAP_DB_UPDATE_1_Update1", q31);

            #endregion

            #region R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "SISINCHE_NUM_CHEQUE_INTERNO" , ""},
                { "CHEQUEMI_TIPO_PAGAMENTO" , ""},
                { "CHEQUEMI_DATA_EMISSAO" , ""},
                { "CHEQUEMI_DATA_MOVIMENTO" , ""},
                { "CHEQUEMI_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1", q32);

            #endregion

            #region R11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "LOTECHEQ_NUM_CHEQUE" , ""},
                { "LOTECHEQ_SERIE_CHEQUE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1_Query1", q33);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI9211B_t1")]
        public static void SI9211B_Tests_Theory(string CSPAGSIN_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CSPAGSIN_FILE_NAME_P = $"{CSPAGSIN_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                SI1001S_Tests.Load_Parameters();
                SI1000S_Tests.Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "HOST_ANO_MOV_ABERTO" , "2023" },
                { "HOST_MES_MOV_ABERTO" , "12" },
                { "HOST_DATA_30" , "2023-12-30" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_SEQ_GERACAO" , "1001" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , "detalhe_20231201.csv" },
                { "GEARDETA_SEQ_GERACAO" , "1001" },
                { "HOST_ANO_MOV_ABERTO" , "2023" },
                { "HOST_MES_MOV_ABERTO" , "12" },
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "GEARDETA_QTD_REG_PROCESSADO" , "150" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1", q2);

                #endregion

                #region R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , "detalhe_20231201.csv" },
                { "GEARDETA_SEQ_GERACAO" , "1001" },
                { "SIARVRCZ_TIPO_REGISTRO" , "01" },
                { "SIARVRCZ_SEQ_REGISTRO" , "001" },
                { "SIARVRCZ_STA_PROCESSAMENTO" , "P" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1", q3);

                #endregion

                #region R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_QTD_REG_PROCESSADO" , "150" },
                { "GEARDETA_NOM_ARQUIVO" , "detalhe_20231201.csv" },
                { "GEARDETA_SEQ_GERACAO" , "1001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1", q4);

                #endregion

                #region SI9211B_C01_SIARDEVC

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NOM_ARQUIVO" , "devolucao_20231201.csv" },
                { "SIARDEVC_SEQ_GERACAO" , "1002" },
                { "SIARDEVC_TIPO_REGISTRO" , "02" },
                { "SIARDEVC_SEQ_REGISTRO" , "002" },
                { "SIARDEVC_COD_OPERACAO" , "1081" },
                { "SIARDEVC_OCORR_HISTORICO" , "Processamento concluído" },
                { "SIARDEVC_NUM_SINISTRO_VC" , "123456" },
                { "SIARDEVC_NUM_EXPEDIENTE_VC" , "123456" },
                { "SIARDEVC_NUM_APOLICE" , "103100014418" },
                { "SIARDEVC_NUM_ENDOSSO" , "801225" },
                { "SIARDEVC_NUM_ITEM" , "01" },
                { "SIARDEVC_COD_RAMO" , "31" },
                { "SIARDEVC_COD_COBERTURA" , "4" },
                { "SIARDEVC_COD_CAUSA" , "11" },
                { "SIARDEVC_DATA_COMUNICADO" , "2023-12-01" },
                { "SIARDEVC_DATA_OCORRENCIA" , "2023-11-30" },
                { "SIARDEVC_HORA_OCORRENCIA" , "14:00" },
                { "SIARDEVC_DATA_MOVIMENTO" , "2023-12-01" },
                { "SIARDEVC_IND_FAVORECIDO" , "1" },
                { "SIARDEVC_VAL_TOT_MOVIMENTO" , "5000.00" },
                { "SIARDEVC_VAL_PECAS" , "3000.00" },
                { "SIARDEVC_VAL_MAO_OBRA" , "2000.00" },
                { "SIARDEVC_VAL_PARCELA_PEND" , "0.00" },
                { "SIARDEVC_QTD_PARCELA_PEND" , "0" },
                { "SIARDEVC_VAL_DESC_PARC_PEND" , "0.00" },
                { "SIARDEVC_DATA_NEGOCIADA" , "2023-12-15" },
                { "SIARDEVC_VAL_IRF" , "150.00" },
                { "SIARDEVC_VAL_ISS" , "100.00" },
                { "SIARDEVC_VAL_INSS" , "75.00" },
                { "SIARDEVC_VAL_LIQUIDO_PAGTO" , "4675.00" },
                { "SIARDEVC_CGCCPF" , "12345678901" },
                { "SIARDEVC_TIPO_PESSOA" , "Física" },
                { "SIARDEVC_NOM_FAVORECIDO" , "João Silva" },
                { "SIARDEVC_IND_DOC_FISCAL" , "1" },
                { "SIARDEVC_NUM_DOC_FISCAL" , "100000123" },
                { "SIARDEVC_SERIE_DOC_FISCAL" , "1" },
                { "SIARDEVC_DATA_EMISSAO" , "2023-12-01" },
                { "SIARDEVC_DES_ENDERECO" , "Rua das Flores, 123" },
                { "SIARDEVC_NOM_BAIRRO" , "Jardim das Árvores" },
                { "SIARDEVC_NOM_CIDADE" , "São Paulo" },
                { "SIARDEVC_COD_UF" , "SP" },
                { "SIARDEVC_NUM_CEP" , "01000-000" },
                { "SIARDEVC_NUM_DDD" , "11" },
                { "SIARDEVC_NUM_TELEFONE" , "40028922" },
                { "SIARDEVC_IND_FORMA_PAGTO" , "3" },
                { "SIARDEVC_NUM_IDENTIFICADOR" , "ID123456789" },
                { "SIARDEVC_NUM_CHEQUE_INTERNO" , "CHK123456" },
                { "SIARDEVC_ORDEM_PAGAMENTO_VC" , "OP123456" },
                { "SIARDEVC_ORDEM_PAGAMENTO" , "OP654321" },
                { "SIARDEVC_COD_BANCO" , "001" },
                { "SIARDEVC_COD_AGENCIA" , "0001" },
                { "SIARDEVC_OPERACAO_CONTA" , "013" },
                { "SIARDEVC_COD_CONTA" , "1234567" },
                { "SIARDEVC_DV_CONTA" , "0" },
                { "SIARDEVC_COD_FAVORECIDO" , "FV123456" },
                { "SIARDEVC_NUM_APOL_SINISTRO" , "335216" },
                { "SIARDEVC_STA_PROCESSAMENTO" , "P" },
                { "SIARDEVC_COD_ERRO" , "01" },
                { "SIARDEVC_VAL_PISPASEP" , "0.00" },
                { "SIARDEVC_VAL_COFINS" , "50.00" },
                { "SIARDEVC_VAL_CSLL" , "25.00" },
                { "SIARDEVC_COD_FONTE" , "123" },
                { "SIARDEVC_NUM_RESSARC" , "RS123456" },
                { "SIARDEVC_IND_PESSOA_ACORDO" , "1" },
                { "SIARDEVC_NUM_CPFCGC_ACORDO" , "98765432109" },
                { "SIARDEVC_NOM_RESP_ACORDO" , "Maria Oliveira" },
                { "SIARDEVC_STA_ACORDO" , "Ativo" },
                { "SIARDEVC_DTH_INDENIZACAO" , "2023-12-01T15:00:00" },
                { "SIARDEVC_VLR_INDENIZACAO" , "4500.00" },
                { "SIARDEVC_VLR_PART_TERCEIROS" , "500.00" },
                { "SIARDEVC_VLR_DIVIDA" , "0.00" },
                { "SIARDEVC_PCT_DESCONTO" , "0.00" },
                { "SIARDEVC_VLR_TOTAL_DESCONTO" , "0.00" },
                { "SIARDEVC_VLR_TOTAL_ACORDO" , "5000.00" },
                { "SIARDEVC_COD_MOEDA_ACORDO" , "BRL" },
                { "SIARDEVC_DTH_ACORDO" , "2023-12-01T15:00:00" },
                { "SIARDEVC_QTD_PARCELAS_ACORDO" , "1" },
                { "SIARDEVC_NUM_PARCELA_ACORDO" , "1" },
                { "SIARDEVC_COD_AGENCIA_CEDENT" , "0001" },
                { "SIARDEVC_NUM_CEDENTE" , "123456" },
                { "SIARDEVC_NUM_CEDENTE_DV" , "0" },
                { "SIARDEVC_DTH_VENCIMENTO" , "2023-12-30" },
                { "SIARDEVC_NUM_NOSSO_TITULO" , "NT123456" },
                { "SIARDEVC_VLR_TITULO" , "5000.00" },
                { "SIARDEVC_NUM_CPFCGC_RECLAMANTE" , "12345678901" },
                { "SIARDEVC_NOM_RECLAMANTE" , "Carlos Pereira" },
                { "SIARDEVC_VLR_RECLAMADO" , "5000.00" },
                { "SIARDEVC_VLR_PROVISIONADO" , "5000.00" },
                { "SIARDEVC_NUM_SINISTRO_CONV" , "SIN123456" },
                { "SIARDEVC_NUM_IDENT_CONV" , "IDC123456" },
                { "SIARDEVC_NUM_IDE_COBR_CONV" , "COB123456" },
                { "SIARDEVC_COD_CFOP" , "5102" },
                { "SIARDEVC_COD_CEST" , "1234567" },
                { "SIARDEVC_NUM_INSCR_ESTADUAL" , "IE123456" },
                { "SIARDEVC_NUM_NCM" , "12345678" },
                { "SIARDEVC_NUM_CPF_CNPJ_TOMADOR" , "12345678901" },
                { "SIARDEVC_IND_ISENCAO_TRIBUTO" , "Não" },
                { "SIARDEVC_COD_IMPOSTO_LIMINAR" , "IL123" },
                { "SIARDEVC_COD_PROCESSO_ISENCAO" , "PI123456" },
                { "SIARDEVC_VLR_RET_N_EFETUADO" , "0.00" },
            });
                AppSettings.TestSet.DynamicData.Remove("SI9211B_C01_SIARDEVC");
                AppSettings.TestSet.DynamicData.Add("SI9211B_C01_SIARDEVC", q5);

                #endregion

                #region R1010_00_CHECA_ESTORNO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_DATA_MOVIMENTO" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1010_00_CHECA_ESTORNO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1010_00_CHECA_ESTORNO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1010_00_CHECA_ESTORNO_DB_SELECT_2_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NOM_PROGRAMA" , "SI9211B" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1010_00_CHECA_ESTORNO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1010_00_CHECA_ESTORNO_DB_SELECT_2_Query1", q7);

                #endregion

                #region R1060_00_LE_CAUSA_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_GRUPO_CAUSAS" , "PT" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1060_00_LE_CAUSA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1060_00_LE_CAUSA_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1070_00_LE_MESTSINI_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_PRODUTO" , "3173" },
                { "SINISMES_OCORR_HISTORICO" , "Processamento de sinistro" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1070_00_LE_MESTSINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1070_00_LE_MESTSINI_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1100_00_LE_SIERRO_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "SIERRO_DES_ERRO" , "Nenhum erro encontrado" }
            });

                q10.AddDynamic(new Dictionary<string, string>{
                { "SIERRO_DES_ERRO" , "Nenhum erro encontrado"}
            });

                q10.AddDynamic(new Dictionary<string, string>{
                { "SIERRO_DES_ERRO" , "Nenhum erro encontrado"}
            });

                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_SIERRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SIERRO_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1210_00_LE_MOVDEBCE_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_RETORNO_CEF" , "00" },
                { "MOVDEBCE_DATA_VENCIMENTO" , "2023-12-30" },
            });

                q11.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_RETORNO_CEF" , "00" },
                { "MOVDEBCE_DATA_VENCIMENTO" , "2024-12-30" },
            });

                AppSettings.TestSet.DynamicData.Remove("R1210_00_LE_MOVDEBCE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1210_00_LE_MOVDEBCE_DB_SELECT_1_Query1", q11);

                #endregion

                #region R1250_00_LE_SINISMES_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_FONTE" , "123" },
                { "SINISMES_NUM_PROTOCOLO_SINI" , "123456" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1250_00_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1250_00_LE_SINISMES_DB_SELECT_1_Query1", q12);

                #endregion

                #region R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , "detalhe_20231201.csv" },
                { "GEARDETA_SEQ_GERACAO" , "1001" },
                { "SIARREVC_TIPO_REGISTRO_VC" , "03" },
                { "SIARREVC_SEQ_REGISTRO_VC" , "003" },
                { "SIARDEVC_NOM_ARQUIVO" , "devolucao_20231201.csv" },
                { "SIARDEVC_SEQ_GERACAO" , "1002" },
                { "SIARDEVC_TIPO_REGISTRO" , "02" },
                { "SIARDEVC_SEQ_REGISTRO" , "002" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1", q13);

                #endregion

                #region R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NUM_CHEQUE_INTERNO" , "CHK123456" },
                { "SIARDEVC_NUM_IDENTIFICADOR" , "ID123456789" },
                { "SIARDEVC_VAL_LIQUIDO_PAGTO" , "4675.00" },
                { "SIARDEVC_STA_PROCESSAMENTO" , "P" },
                { "SIARDEVC_TIPO_REGISTRO" , "02" },
                { "SIARDEVC_SEQ_REGISTRO" , "002" },
                { "SIARDEVC_NOM_ARQUIVO" , "devolucao_20231201.csv" },
                { "SIARDEVC_SEQ_GERACAO" , "1002" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q14);

                #endregion

                #region R1450_CHECA_OP_BAIXA_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_ENDOSSO" , "801647" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1450_CHECA_OP_BAIXA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1450_CHECA_OP_BAIXA_DB_SELECT_1_Query1", q15);

                #endregion

                #region R1510_00_CONSULTA_SINI_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NOME_FAVORECIDO" , "João Silva" },
                { "SINISHIS_VAL_OPERACAO" , "5000.00" },
                { "SINISHIS_TIPO_FAVORECIDO" , "Física" },
                { "SINISHIS_DATA_NEGOCIADA" , "2023-12-15" },
                { "SINISHIS_FONTE_PAGAMENTO" , "Banco do Brasil" },
                { "SINISHIS_COD_PREST_SERVICO" , "SERV123" },
                { "SINISHIS_COD_SERVICO" , "SERV123" },
                { "SINISHIS_ORDEM_PAGAMENTO" , "OP123456" },
                { "SINISHIS_NUM_RECIBO" , "REC123456" },
                { "SINISHIS_NUM_MOV_SINISTRO" , "MOV123456" },
                { "SINISHIS_SIT_CONTABIL" , "Ativo" },
                { "SINISHIS_SIT_REGISTRO" , "Registrado" },
                { "SINISHIS_COD_PRODUTO" , "PROD123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1510_00_CONSULTA_SINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1510_00_CONSULTA_SINI_DB_SELECT_1_Query1", q16);

                #endregion

                #region R1520_00_INCLUI_SINIS_DB_INSERT_1_Insert1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "335216" },
                { "SINISHIS_OCORR_HISTORICO" , "Processamento de sinistro" },
                { "SINISHIS_COD_OPERACAO" , "1081" },
                { "SINISHIS_DATA_MOVIMENTO" , "2023-12-01" },
                { "SINISHIS_NOME_FAVORECIDO" , "João Silva" },
                { "SINISHIS_VAL_OPERACAO" , "5000.00" },
                { "SINISHIS_DATA_NEGOCIADA" , "2023-12-15" },
                { "SINISHIS_TIPO_FAVORECIDO" , "Física" },
                { "SINISHIS_FONTE_PAGAMENTO" , "Banco do Brasil" },
                { "SINISHIS_COD_PREST_SERVICO" , "SERV123" },
                { "SINISHIS_COD_SERVICO" , "SERV123" },
                { "SINISHIS_ORDEM_PAGAMENTO" , "OP123456" },
                { "SINISHIS_NUM_RECIBO" , "REC123456" },
                { "SINISHIS_NUM_MOV_SINISTRO" , "MOV123456" },
                { "SINISHIS_COD_USUARIO" , "USR123" },
                { "SINISHIS_SIT_CONTABIL" , "Ativo" },
                { "SINISHIS_SIT_REGISTRO" , "Registrado" },
                { "SINISHIS_NUM_APOLICE" , "103100014418" },
                { "SINISHIS_COD_PRODUTO" , "PROD123" },
                { "SINISHIS_NOM_PROGRAMA" , "SI9211B" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1520_00_INCLUI_SINIS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1520_00_INCLUI_SINIS_DB_INSERT_1_Insert1", q17);

                #endregion

                #region R1610_00_ATUAL_SI_PESS_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1610_00_ATUAL_SI_PESS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1610_00_ATUAL_SI_PESS_DB_SELECT_1_Query1", q18);

                #endregion

                #region R1610_00_ATUAL_SI_PESS_DB_UPDATE_1_Update1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_OPERACAO" , "1081" },
                { "SINISHIS_NUM_APOL_SINISTRO" , "335216" },
                { "SINISHIS_OCORR_HISTORICO" , "Processamento de sinistro" },
                { "SIARDEVC_COD_OPERACAO" , "1081" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1610_00_ATUAL_SI_PESS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1610_00_ATUAL_SI_PESS_DB_UPDATE_1_Update1", q19);

                #endregion

                #region R1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1_Query1", q20);

                #endregion

                #region R1620_00_ATUAL_SINI_CHEQ_DB_UPDATE_1_Update1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_OPERACAO" , "1081" },
                { "SINISHIS_NUM_APOL_SINISTRO" , "335216" },
                { "SINISHIS_OCORR_HISTORICO" , "Processamento de sinistro" },
                { "SIARDEVC_COD_OPERACAO" , "1081" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1620_00_ATUAL_SINI_CHEQ_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1620_00_ATUAL_SINI_CHEQ_DB_UPDATE_1_Update1", q21);

                #endregion

                #region R1630_00_ATUAL_PAGA_DOCFIS_DB_SELECT_1_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1630_00_ATUAL_PAGA_DOCFIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1630_00_ATUAL_PAGA_DOCFIS_DB_SELECT_1_Query1", q22);

                #endregion

                #region R1630_00_ATUAL_PAGA_DOCFIS_DB_UPDATE_1_Update1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_OPERACAO" , "1081" },
                { "SINISHIS_NUM_APOL_SINISTRO" , "335216" },
                { "SINISHIS_OCORR_HISTORICO" , "Processamento de sinistro" },
                { "SIARDEVC_COD_OPERACAO" , "1081" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1630_00_ATUAL_PAGA_DOCFIS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1630_00_ATUAL_PAGA_DOCFIS_DB_UPDATE_1_Update1", q23);

                #endregion

                #region R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "GE369_NUM_APOLICE" , "103100014418" },
                { "GE369_NUM_ENDOSSO" , "801647" },
                { "GE369_NUM_PARCELA" , "02" },
                { "GE369_COD_CONVENIO" , "CONV123" },
                { "GE369_NSAS" , "NS123456" },
                { "GE369_COD_AGENCIA" , "0001" },
                { "GE369_COD_BANCO" , "001" },
                { "GE369_NUM_CONTA_CNB" , "1234567" },
                { "GE369_NUM_DV_CONTA_CNB" , "0" },
                { "GE369_IND_CONTA_BANCARIA" , "Sim" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1_Query1", q24);

                #endregion

                #region R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2_Query1", q25);

                #endregion

                #region R1641_00_DELET_GE_MOVTO_CONT_DB_DELETE_1_Delete1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , "103100014418" },
                { "MOVDEBCE_NUM_ENDOSSO" , "801647" },
                { "MOVDEBCE_NUM_PARCELA" , "02" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1641_00_DELET_GE_MOVTO_CONT_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R1641_00_DELET_GE_MOVTO_CONT_DB_DELETE_1_Delete1", q26);

                #endregion

                #region R1642_00_ATUAL_MOVTO_DEBT_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1642_00_ATUAL_MOVTO_DEBT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1642_00_ATUAL_MOVTO_DEBT_DB_SELECT_1_Query1", q27);

                #endregion

                #region R1642_00_ATUAL_MOVTO_DEBT_DB_UPDATE_1_Update1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "AUX_COD_OPERACAO" , "1081" },
                { "MOVDEBCE_NUM_APOLICE" , "103100014418" },
                { "MOVDEBCE_NUM_ENDOSSO" , "801647" },
                { "MOVDEBCE_NUM_PARCELA" , "02" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1642_00_ATUAL_MOVTO_DEBT_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1642_00_ATUAL_MOVTO_DEBT_DB_UPDATE_1_Update1", q28);

                #endregion

                #region R1643_00_INSERT_GE_MOVTO_CONT_DB_INSERT_1_Insert1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "GE369_NUM_APOLICE" , "103100014418" },
                { "GE369_NUM_ENDOSSO" , "801647" },
                { "GE369_NUM_PARCELA" , "02" },
                { "GE369_COD_CONVENIO" , "CONV123" },
                { "GE369_NSAS" , "NS123456" },
                { "GE369_COD_AGENCIA" , "0001" },
                { "GE369_COD_BANCO" , "001" },
                { "GE369_NUM_CONTA_CNB" , "1234567" },
                { "GE369_NUM_DV_CONTA_CNB" , "0" },
                { "GE369_IND_CONTA_BANCARIA" , "Sim" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1643_00_INSERT_GE_MOVTO_CONT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1643_00_INSERT_GE_MOVTO_CONT_DB_INSERT_1_Insert1", q29);

                #endregion

                #region R1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1_Query1", q30);

                #endregion

                #region R1660_00_ATUAL_MOVDEB_SAP_DB_UPDATE_1_Update1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_OPERACAO" , "1081" },
                { "MOVDEBCE_NUM_APOLICE" , "103100004293" },
                { "MOVDEBCE_NUM_ENDOSSO" , "801647" },
                { "MOVDEBCE_NUM_PARCELA" , "02" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1660_00_ATUAL_MOVDEB_SAP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1660_00_ATUAL_MOVDEB_SAP_DB_UPDATE_1_Update1", q31);

                #endregion

                #region R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                { "SISINCHE_NUM_CHEQUE_INTERNO" , "CHK123456" },
                { "CHEQUEMI_TIPO_PAGAMENTO" , "1" },
                { "CHEQUEMI_DATA_EMISSAO" , "2023-12-01" },
                { "CHEQUEMI_DATA_MOVIMENTO" , "2024-12-01" },
                { "CHEQUEMI_SIT_REGISTRO" , "2" },
            });

                q32.AddDynamic(new Dictionary<string, string>{
                { "SISINCHE_NUM_CHEQUE_INTERNO" , "CHK123456" },
                { "CHEQUEMI_TIPO_PAGAMENTO" , "1" },
                { "CHEQUEMI_DATA_EMISSAO" , "2024-12-01" },
                { "CHEQUEMI_DATA_MOVIMENTO" , "2024-12-01" },
                { "CHEQUEMI_SIT_REGISTRO" , "2" },
            });
                AppSettings.TestSet.DynamicData.Remove("R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1", q32);

                #endregion

                #region R11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1_Query1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "LOTECHEQ_NUM_CHEQUE" , "CHK123456" },
                { "LOTECHEQ_SERIE_CHEQUE" , "Serie1" },
            });

                q33.AddDynamic(new Dictionary<string, string>{
                { "LOTECHEQ_NUM_CHEQUE" , "6419993" },
                { "LOTECHEQ_SERIE_CHEQUE" , "Serie3" },
            });

                q33.AddDynamic(new Dictionary<string, string>{
                { "LOTECHEQ_NUM_CHEQUE" , "6419990" },
                { "LOTECHEQ_SERIE_CHEQUE" , "Serie4" },
            });

                q33.AddDynamic(new Dictionary<string, string>{
                { "LOTECHEQ_NUM_CHEQUE" , "6420002" },
                { "LOTECHEQ_SERIE_CHEQUE" , "Serie3" },
            });
                AppSettings.TestSet.DynamicData.Remove("R11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1_Query1", q33);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new SI9211B();

                program.Execute(CSPAGSIN_FILE_NAME_P);

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();

                //o Cobol, ele esta chamando de forma estruturada ao inves de explicitar o perform. Por esse motivo reduzi os 6 updates que estão no mesmo bloco.
                Assert.True(updates.Count >= (allUpdates.Count - 6) / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                //o Cobol, ele esta chamando de forma estruturada ao inves de explicitar o perform. Por esse motivo reduzi os 6 selects que estão no mesmo bloco.
                Assert.True(selects.Count >= (allSelects.Count - 6) / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }


        [Theory]
        [InlineData("SI9211B_t2")]
        public static void SI9211B_Tests_TheoryReturn99(string CSPAGSIN_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CSPAGSIN_FILE_NAME_P = $"{CSPAGSIN_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                SI1001S_Tests.Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "HOST_ANO_MOV_ABERTO" , "2023" },
                { "HOST_MES_MOV_ABERTO" , "12" },
                { "HOST_DATA_30" , "2023-12-30" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_SEQ_GERACAO" , "1001" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , "detalhe_20231201.csv" },
                { "GEARDETA_SEQ_GERACAO" , "1001" },
                { "HOST_ANO_MOV_ABERTO" , "2023" },
                { "HOST_MES_MOV_ABERTO" , "12" },
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "GEARDETA_QTD_REG_PROCESSADO" , "150" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1", q2);

                #endregion

                #region R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , "detalhe_20231201.csv" },
                { "GEARDETA_SEQ_GERACAO" , "1001" },
                { "SIARVRCZ_TIPO_REGISTRO" , "01" },
                { "SIARVRCZ_SEQ_REGISTRO" , "001" },
                { "SIARVRCZ_STA_PROCESSAMENTO" , "P" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1", q3);

                #endregion

                #region R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_QTD_REG_PROCESSADO" , "150" },
                { "GEARDETA_NOM_ARQUIVO" , "detalhe_20231201.csv" },
                { "GEARDETA_SEQ_GERACAO" , "1001" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1", q4);

                #endregion

                #region SI9211B_C01_SIARDEVC

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NOM_ARQUIVO" , "devolucao_20231201.csv" },
                { "SIARDEVC_SEQ_GERACAO" , "1002" },
                { "SIARDEVC_TIPO_REGISTRO" , "02" },
                { "SIARDEVC_SEQ_REGISTRO" , "002" },
                { "SIARDEVC_COD_OPERACAO" , "1081" },
                { "SIARDEVC_OCORR_HISTORICO" , "Processamento concluído" },
                { "SIARDEVC_NUM_SINISTRO_VC" , "SIN123456" },
                { "SIARDEVC_NUM_EXPEDIENTE_VC" , "EXP123456" },
                { "SIARDEVC_NUM_APOLICE" , "66001000001" },
                { "SIARDEVC_NUM_ENDOSSO" , "END123456" },
                { "SIARDEVC_NUM_ITEM" , "01" },
                { "SIARDEVC_COD_RAMO" , "31" },
                { "SIARDEVC_COD_COBERTURA" , "4" },
                { "SIARDEVC_COD_CAUSA" , "11" },
                { "SIARDEVC_DATA_COMUNICADO" , "2023-12-01" },
                { "SIARDEVC_DATA_OCORRENCIA" , "2023-11-30" },
                { "SIARDEVC_HORA_OCORRENCIA" , "14:00" },
                { "SIARDEVC_DATA_MOVIMENTO" , "2023-12-01" },
                { "SIARDEVC_IND_FAVORECIDO" , "1" },
                { "SIARDEVC_VAL_TOT_MOVIMENTO" , "5000.00" },
                { "SIARDEVC_VAL_PECAS" , "3000.00" },
                { "SIARDEVC_VAL_MAO_OBRA" , "2000.00" },
                { "SIARDEVC_VAL_PARCELA_PEND" , "0.00" },
                { "SIARDEVC_QTD_PARCELA_PEND" , "0" },
                { "SIARDEVC_VAL_DESC_PARC_PEND" , "0.00" },
                { "SIARDEVC_DATA_NEGOCIADA" , "2023-12-15" },
                { "SIARDEVC_VAL_IRF" , "150.00" },
                { "SIARDEVC_VAL_ISS" , "100.00" },
                { "SIARDEVC_VAL_INSS" , "75.00" },
                { "SIARDEVC_VAL_LIQUIDO_PAGTO" , "4675.00" },
                { "SIARDEVC_CGCCPF" , "12345678901" },
                { "SIARDEVC_TIPO_PESSOA" , "Física" },
                { "SIARDEVC_NOM_FAVORECIDO" , "João Silva" },
                { "SIARDEVC_IND_DOC_FISCAL" , "1" },
                { "SIARDEVC_NUM_DOC_FISCAL" , "100000123" },
                { "SIARDEVC_SERIE_DOC_FISCAL" , "1" },
                { "SIARDEVC_DATA_EMISSAO" , "2023-12-01" },
                { "SIARDEVC_DES_ENDERECO" , "Rua das Flores, 123" },
                { "SIARDEVC_NOM_BAIRRO" , "Jardim das Árvores" },
                { "SIARDEVC_NOM_CIDADE" , "São Paulo" },
                { "SIARDEVC_COD_UF" , "SP" },
                { "SIARDEVC_NUM_CEP" , "01000-000" },
                { "SIARDEVC_NUM_DDD" , "11" },
                { "SIARDEVC_NUM_TELEFONE" , "40028922" },
                { "SIARDEVC_IND_FORMA_PAGTO" , "3" },
                { "SIARDEVC_NUM_IDENTIFICADOR" , "ID123456789" },
                { "SIARDEVC_NUM_CHEQUE_INTERNO" , "CHK123456" },
                { "SIARDEVC_ORDEM_PAGAMENTO_VC" , "OP123456" },
                { "SIARDEVC_ORDEM_PAGAMENTO" , "OP654321" },
                { "SIARDEVC_COD_BANCO" , "001" },
                { "SIARDEVC_COD_AGENCIA" , "0001" },
                { "SIARDEVC_OPERACAO_CONTA" , "013" },
                { "SIARDEVC_COD_CONTA" , "1234567" },
                { "SIARDEVC_DV_CONTA" , "0" },
                { "SIARDEVC_COD_FAVORECIDO" , "FV123456" },
                { "SIARDEVC_NUM_APOL_SINISTRO" , "335216" },
                { "SIARDEVC_STA_PROCESSAMENTO" , "P" },
                { "SIARDEVC_COD_ERRO" , "01" },
                { "SIARDEVC_VAL_PISPASEP" , "0.00" },
                { "SIARDEVC_VAL_COFINS" , "50.00" },
                { "SIARDEVC_VAL_CSLL" , "25.00" },
                { "SIARDEVC_COD_FONTE" , "123" },
                { "SIARDEVC_NUM_RESSARC" , "RS123456" },
                { "SIARDEVC_IND_PESSOA_ACORDO" , "1" },
                { "SIARDEVC_NUM_CPFCGC_ACORDO" , "98765432109" },
                { "SIARDEVC_NOM_RESP_ACORDO" , "Maria Oliveira" },
                { "SIARDEVC_STA_ACORDO" , "Ativo" },
                { "SIARDEVC_DTH_INDENIZACAO" , "2023-12-01T15:00:00" },
                { "SIARDEVC_VLR_INDENIZACAO" , "4500.00" },
                { "SIARDEVC_VLR_PART_TERCEIROS" , "500.00" },
                { "SIARDEVC_VLR_DIVIDA" , "0.00" },
                { "SIARDEVC_PCT_DESCONTO" , "0.00" },
                { "SIARDEVC_VLR_TOTAL_DESCONTO" , "0.00" },
                { "SIARDEVC_VLR_TOTAL_ACORDO" , "5000.00" },
                { "SIARDEVC_COD_MOEDA_ACORDO" , "BRL" },
                { "SIARDEVC_DTH_ACORDO" , "2023-12-01T15:00:00" },
                { "SIARDEVC_QTD_PARCELAS_ACORDO" , "1" },
                { "SIARDEVC_NUM_PARCELA_ACORDO" , "1" },
                { "SIARDEVC_COD_AGENCIA_CEDENT" , "0001" },
                { "SIARDEVC_NUM_CEDENTE" , "123456" },
                { "SIARDEVC_NUM_CEDENTE_DV" , "0" },
                { "SIARDEVC_DTH_VENCIMENTO" , "2023-12-30" },
                { "SIARDEVC_NUM_NOSSO_TITULO" , "NT123456" },
                { "SIARDEVC_VLR_TITULO" , "5000.00" },
                { "SIARDEVC_NUM_CPFCGC_RECLAMANTE" , "12345678901" },
                { "SIARDEVC_NOM_RECLAMANTE" , "Carlos Pereira" },
                { "SIARDEVC_VLR_RECLAMADO" , "5000.00" },
                { "SIARDEVC_VLR_PROVISIONADO" , "5000.00" },
                { "SIARDEVC_NUM_SINISTRO_CONV" , "SIN123456" },
                { "SIARDEVC_NUM_IDENT_CONV" , "IDC123456" },
                { "SIARDEVC_NUM_IDE_COBR_CONV" , "COB123456" },
                { "SIARDEVC_COD_CFOP" , "5102" },
                { "SIARDEVC_COD_CEST" , "1234567" },
                { "SIARDEVC_NUM_INSCR_ESTADUAL" , "IE123456" },
                { "SIARDEVC_NUM_NCM" , "12345678" },
                { "SIARDEVC_NUM_CPF_CNPJ_TOMADOR" , "12345678901" },
                { "SIARDEVC_IND_ISENCAO_TRIBUTO" , "Não" },
                { "SIARDEVC_COD_IMPOSTO_LIMINAR" , "IL123" },
                { "SIARDEVC_COD_PROCESSO_ISENCAO" , "PI123456" },
                { "SIARDEVC_VLR_RET_N_EFETUADO" , "0.00" },
            });
                AppSettings.TestSet.DynamicData.Remove("SI9211B_C01_SIARDEVC");
                AppSettings.TestSet.DynamicData.Add("SI9211B_C01_SIARDEVC", q5);

                #endregion

                #region R1010_00_CHECA_ESTORNO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_DATA_MOVIMENTO" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1010_00_CHECA_ESTORNO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1010_00_CHECA_ESTORNO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1010_00_CHECA_ESTORNO_DB_SELECT_2_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NOM_PROGRAMA" , "SiasSinistro" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1010_00_CHECA_ESTORNO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1010_00_CHECA_ESTORNO_DB_SELECT_2_Query1", q7);

                #endregion

                #region R1060_00_LE_CAUSA_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_GRUPO_CAUSAS" , "PT" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1060_00_LE_CAUSA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1060_00_LE_CAUSA_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1070_00_LE_MESTSINI_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_PRODUTO" , "3173" },
                { "SINISMES_OCORR_HISTORICO" , "Processamento de sinistro" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1070_00_LE_MESTSINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1070_00_LE_MESTSINI_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1100_00_LE_SIERRO_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "SIERRO_DES_ERRO" , "Nenhum erro encontrado" }
            });

                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_SIERRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SIERRO_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1210_00_LE_MOVDEBCE_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_RETORNO_CEF" , "00" },
                { "MOVDEBCE_DATA_VENCIMENTO" , "2023-12-30" },
            });

                AppSettings.TestSet.DynamicData.Remove("R1210_00_LE_MOVDEBCE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1210_00_LE_MOVDEBCE_DB_SELECT_1_Query1", q11);

                #endregion

                #region R1250_00_LE_SINISMES_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_FONTE" , "335216" },
                { "SINISMES_NUM_PROTOCOLO_SINI" , "PROTO123456" },
            });

                AppSettings.TestSet.DynamicData.Remove("R1250_00_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1250_00_LE_SINISMES_DB_SELECT_1_Query1", q12);

                #endregion

                #region R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , "detalhe_20231201.csv" },
                { "GEARDETA_SEQ_GERACAO" , "1001" },
                { "SIARREVC_TIPO_REGISTRO_VC" , "03" },
                { "SIARREVC_SEQ_REGISTRO_VC" , "003" },
                { "SIARDEVC_NOM_ARQUIVO" , "devolucao_20231201.csv" },
                { "SIARDEVC_SEQ_GERACAO" , "1002" },
                { "SIARDEVC_TIPO_REGISTRO" , "02" },
                { "SIARDEVC_SEQ_REGISTRO" , "002" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1", q13);

                #endregion

                #region R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NUM_CHEQUE_INTERNO" , "CHK123456" },
                { "SIARDEVC_NUM_IDENTIFICADOR" , "ID123456789" },
                { "SIARDEVC_VAL_LIQUIDO_PAGTO" , "4675.00" },
                { "SIARDEVC_STA_PROCESSAMENTO" , "P" },
                { "SIARDEVC_TIPO_REGISTRO" , "02" },
                { "SIARDEVC_SEQ_REGISTRO" , "002" },
                { "SIARDEVC_NOM_ARQUIVO" , "devolucao_20231201.csv" },
                { "SIARDEVC_SEQ_GERACAO" , "1002" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q14);

                #endregion

                #region R1450_CHECA_OP_BAIXA_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_ENDOSSO" , "END123456" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1450_CHECA_OP_BAIXA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1450_CHECA_OP_BAIXA_DB_SELECT_1_Query1", q15);

                #endregion

                #region R1510_00_CONSULTA_SINI_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NOME_FAVORECIDO" , "João Silva" },
                { "SINISHIS_VAL_OPERACAO" , "5000.00" },
                { "SINISHIS_TIPO_FAVORECIDO" , "Física" },
                { "SINISHIS_DATA_NEGOCIADA" , "2023-12-15" },
                { "SINISHIS_FONTE_PAGAMENTO" , "Banco do Brasil" },
                { "SINISHIS_COD_PREST_SERVICO" , "SERV123" },
                { "SINISHIS_COD_SERVICO" , "SERV123" },
                { "SINISHIS_ORDEM_PAGAMENTO" , "OP123456" },
                { "SINISHIS_NUM_RECIBO" , "REC123456" },
                { "SINISHIS_NUM_MOV_SINISTRO" , "MOV123456" },
                { "SINISHIS_SIT_CONTABIL" , "Ativo" },
                { "SINISHIS_SIT_REGISTRO" , "Registrado" },
                { "SINISHIS_COD_PRODUTO" , "PROD123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1510_00_CONSULTA_SINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1510_00_CONSULTA_SINI_DB_SELECT_1_Query1", q16);

                #endregion

                #region R1520_00_INCLUI_SINIS_DB_INSERT_1_Insert1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "335216" },
                { "SINISHIS_OCORR_HISTORICO" , "Processamento de sinistro" },
                { "SINISHIS_COD_OPERACAO" , "1081" },
                { "SINISHIS_DATA_MOVIMENTO" , "2023-12-01" },
                { "SINISHIS_NOME_FAVORECIDO" , "João Silva" },
                { "SINISHIS_VAL_OPERACAO" , "5000.00" },
                { "SINISHIS_DATA_NEGOCIADA" , "2023-12-15" },
                { "SINISHIS_TIPO_FAVORECIDO" , "Física" },
                { "SINISHIS_FONTE_PAGAMENTO" , "Banco do Brasil" },
                { "SINISHIS_COD_PREST_SERVICO" , "SERV123" },
                { "SINISHIS_COD_SERVICO" , "SERV123" },
                { "SINISHIS_ORDEM_PAGAMENTO" , "OP123456" },
                { "SINISHIS_NUM_RECIBO" , "REC123456" },
                { "SINISHIS_NUM_MOV_SINISTRO" , "MOV123456" },
                { "SINISHIS_COD_USUARIO" , "USR123" },
                { "SINISHIS_SIT_CONTABIL" , "Ativo" },
                { "SINISHIS_SIT_REGISTRO" , "Registrado" },
                { "SINISHIS_NUM_APOLICE" , "66001000001" },
                { "SINISHIS_COD_PRODUTO" , "PROD123" },
                { "SINISHIS_NOM_PROGRAMA" , "SI66SIV9" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1520_00_INCLUI_SINIS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1520_00_INCLUI_SINIS_DB_INSERT_1_Insert1", q17);

                #endregion

                #region R1610_00_ATUAL_SI_PESS_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1610_00_ATUAL_SI_PESS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1610_00_ATUAL_SI_PESS_DB_SELECT_1_Query1", q18);

                #endregion

                #region R1610_00_ATUAL_SI_PESS_DB_UPDATE_1_Update1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_OPERACAO" , "1081" },
                { "SINISHIS_NUM_APOL_SINISTRO" , "335216" },
                { "SINISHIS_OCORR_HISTORICO" , "Processamento de sinistro" },
                { "SIARDEVC_COD_OPERACAO" , "1081" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1610_00_ATUAL_SI_PESS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1610_00_ATUAL_SI_PESS_DB_UPDATE_1_Update1", q19);

                #endregion

                #region R1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1_Query1", q20);

                #endregion

                #region R1620_00_ATUAL_SINI_CHEQ_DB_UPDATE_1_Update1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_OPERACAO" , "1081" },
                { "SINISHIS_NUM_APOL_SINISTRO" , "335216" },
                { "SINISHIS_OCORR_HISTORICO" , "Processamento de sinistro" },
                { "SIARDEVC_COD_OPERACAO" , "1081" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1620_00_ATUAL_SINI_CHEQ_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1620_00_ATUAL_SINI_CHEQ_DB_UPDATE_1_Update1", q21);

                #endregion

                #region R1630_00_ATUAL_PAGA_DOCFIS_DB_SELECT_1_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1630_00_ATUAL_PAGA_DOCFIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1630_00_ATUAL_PAGA_DOCFIS_DB_SELECT_1_Query1", q22);

                #endregion

                #region R1630_00_ATUAL_PAGA_DOCFIS_DB_UPDATE_1_Update1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_OPERACAO" , "1081" },
                { "SINISHIS_NUM_APOL_SINISTRO" , "335216" },
                { "SINISHIS_OCORR_HISTORICO" , "Processamento de sinistro" },
                { "SIARDEVC_COD_OPERACAO" , "1081" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1630_00_ATUAL_PAGA_DOCFIS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1630_00_ATUAL_PAGA_DOCFIS_DB_UPDATE_1_Update1", q23);

                #endregion

                #region R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "GE369_NUM_APOLICE" , "66001000001" },
                { "GE369_NUM_ENDOSSO" , "END123456" },
                { "GE369_NUM_PARCELA" , "01" },
                { "GE369_COD_CONVENIO" , "CONV123" },
                { "GE369_NSAS" , "NS123456" },
                { "GE369_COD_AGENCIA" , "0001" },
                { "GE369_COD_BANCO" , "001" },
                { "GE369_NUM_CONTA_CNB" , "1234567" },
                { "GE369_NUM_DV_CONTA_CNB" , "0" },
                { "GE369_IND_CONTA_BANCARIA" , "Sim" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1_Query1", q24);

                #endregion

                #region R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2_Query1", q25);

                #endregion

                #region R1641_00_DELET_GE_MOVTO_CONT_DB_DELETE_1_Delete1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , "66001000001" },
                { "MOVDEBCE_NUM_ENDOSSO" , "END123456" },
                { "MOVDEBCE_NUM_PARCELA" , "01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1641_00_DELET_GE_MOVTO_CONT_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R1641_00_DELET_GE_MOVTO_CONT_DB_DELETE_1_Delete1", q26);

                #endregion

                #region R1642_00_ATUAL_MOVTO_DEBT_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1642_00_ATUAL_MOVTO_DEBT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1642_00_ATUAL_MOVTO_DEBT_DB_SELECT_1_Query1", q27);

                #endregion

                #region R1642_00_ATUAL_MOVTO_DEBT_DB_UPDATE_1_Update1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "AUX_COD_OPERACAO" , "1081" },
                { "MOVDEBCE_NUM_APOLICE" , "66001000001" },
                { "MOVDEBCE_NUM_ENDOSSO" , "END123456" },
                { "MOVDEBCE_NUM_PARCELA" , "01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1642_00_ATUAL_MOVTO_DEBT_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1642_00_ATUAL_MOVTO_DEBT_DB_UPDATE_1_Update1", q28);

                #endregion

                #region R1643_00_INSERT_GE_MOVTO_CONT_DB_INSERT_1_Insert1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "GE369_NUM_APOLICE" , "66001000001" },
                { "GE369_NUM_ENDOSSO" , "END123456" },
                { "GE369_NUM_PARCELA" , "01" },
                { "GE369_COD_CONVENIO" , "CONV123" },
                { "GE369_NSAS" , "NS123456" },
                { "GE369_COD_AGENCIA" , "0001" },
                { "GE369_COD_BANCO" , "001" },
                { "GE369_NUM_CONTA_CNB" , "1234567" },
                { "GE369_NUM_DV_CONTA_CNB" , "0" },
                { "GE369_IND_CONTA_BANCARIA" , "Sim" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1643_00_INSERT_GE_MOVTO_CONT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1643_00_INSERT_GE_MOVTO_CONT_DB_INSERT_1_Insert1", q29);

                #endregion

                #region R1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1_Query1", q30);

                #endregion

                #region R1660_00_ATUAL_MOVDEB_SAP_DB_UPDATE_1_Update1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_OPERACAO" , "1081" },
                { "MOVDEBCE_NUM_APOLICE" , "66001000001" },
                { "MOVDEBCE_NUM_ENDOSSO" , "END123456" },
                { "MOVDEBCE_NUM_PARCELA" , "01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1660_00_ATUAL_MOVDEB_SAP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1660_00_ATUAL_MOVDEB_SAP_DB_UPDATE_1_Update1", q31);

                #endregion

                #region R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                { "SISINCHE_NUM_CHEQUE_INTERNO" , "CHK123456" },
                { "CHEQUEMI_TIPO_PAGAMENTO" , "1" },
                { "CHEQUEMI_DATA_EMISSAO" , "2023-12-01" },
                { "CHEQUEMI_DATA_MOVIMENTO" , "2024-12-01" },
                { "CHEQUEMI_SIT_REGISTRO" , "2" },
            });

                AppSettings.TestSet.DynamicData.Remove("R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1", q32);

                #endregion

                #region R11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1_Query1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "LOTECHEQ_NUM_CHEQUE" , "6419989" },
                { "LOTECHEQ_SERIE_CHEQUE" , "Serie1" },
            });


                AppSettings.TestSet.DynamicData.Remove("R11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1_Query1", q33);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new SI9211B();

                program.Execute(CSPAGSIN_FILE_NAME_P);

                Assert.True(program.RETURN_CODE != 0);
            }
        }
    }
}