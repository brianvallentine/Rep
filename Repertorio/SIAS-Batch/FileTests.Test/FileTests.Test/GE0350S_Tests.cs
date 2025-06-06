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
using static Code.GE0350S;

namespace FileTests.Test
{
    [Collection("GE0350S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class GE0350S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0090_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "HOST_CURRENT_DATE" , "2024-01-01"},
                { "HOST_TIMESTAMP" , ""},
                { "HOST_CURRENT_TIME" , ""},
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "HOST_CURRENT_DATE" , "2024-01-02"},
                { "HOST_TIMESTAMP" , ""},
                { "HOST_CURRENT_TIME" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0090_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0100_CRITICA_DATA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_AUX" , "2024-01-01"}
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_AUX" , "2024-01-01"}
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_AUX" , "2024-01-01"}
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_AUX" , "2024-01-01"}
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_AUX" , "2024-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_CRITICA_DATA_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0110_CRITICA_CLIENTE_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0110_CRITICA_CLIENTE_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0120_CRITICA_IDE_SISTEMA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_IDE_SISTEMA" , "AC"}
            });
            AppSettings.TestSet.DynamicData.Add("R0120_CRITICA_IDE_SISTEMA_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0500_PESQUISA_PRODUTO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_RAMO_EMISSOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0500_PESQUISA_PRODUTO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1000_CONSULTA_NN_VALIDO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "GE403_SEQ_CONTROLE_SIGCB" , ""},
                { "GE403_DTA_MOVIMENTO" , ""},
                { "GE403_NUM_OCORR_MOVTO" , ""},
                { "GE403_NUM_IDLG" , ""},
                { "GE403_COD_PRODUTO" , ""},
                { "GE403_DTA_VENCIMENTO" , "2024-11-11"},
                { "GE403_VLR_PREMIO_TOTAL" , "449.17"},
                { "GE403_VLR_IOF" , ""},
                { "GE403_QTD_PARCELA" , ""},
                { "GE403_QTD_DIAS_CUSTODIA" , ""},
                { "GE403_COD_CLIENTE" , ""},
                { "GE403_COD_CEDENTE_SAP" , ""},
                { "GE403_NUM_BOLETO_INTERNO" , ""},
                { "GE403_NUM_NOSSO_NUMERO_SAP" , "100010970324"},
                { "GE403_COD_LINHA_DIGITAVEL" , ""},
                { "GE403_NUM_TITULO" , ""},
                { "GE403_IDE_SISTEMA" , ""},
                { "GE403_COD_USUARIO" , ""},
                { "GE403_COD_SITUACAO" , "H"},
                { "WS_DTA_VENC_CUSTODIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_CONSULTA_NN_VALIDO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1100_CONS_NN_CERTIFICADO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "GE403_NUM_PROPOSTA" , ""},
                { "GE403_NUM_APOLICE" , ""},
                { "GE403_NUM_ENDOSSO" , ""},
                { "GE403_SEQ_CONTROLE_SIGCB" , ""},
                { "GE403_DTA_MOVIMENTO" , ""},
                { "GE403_NUM_OCORR_MOVTO" , ""},
                { "GE403_NUM_IDLG" , ""},
                { "GE403_COD_PRODUTO" , ""},
                { "GE403_DTA_VENCIMENTO" , ""},
                { "GE403_VLR_PREMIO_TOTAL" , ""},
                { "GE403_VLR_IOF" , ""},
                { "GE403_QTD_PARCELA" , ""},
                { "GE403_QTD_DIAS_CUSTODIA" , ""},
                { "GE403_COD_CLIENTE" , ""},
                { "GE403_COD_CEDENTE_SAP" , ""},
                { "GE403_NUM_BOLETO_INTERNO" , ""},
                { "GE403_NUM_NOSSO_NUMERO_SAP" , ""},
                { "GE403_COD_LINHA_DIGITAVEL" , ""},
                { "GE403_NUM_TITULO" , ""},
                { "GE403_IDE_SISTEMA" , ""},
                { "GE403_COD_USUARIO" , ""},
                { "GE403_COD_SITUACAO" , ""},
                { "WS_DTA_VENC_CUSTODIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_CONS_NN_CERTIFICADO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R2100_INSERE_CONTROLE_SIGCB_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "GE403_NUM_PROPOSTA" , ""},
                { "GE403_NUM_CERTIFICADO" , ""},
                { "GE403_NUM_PARCELA" , ""},
                { "GE403_NUM_APOLICE" , ""},
                { "GE403_NUM_ENDOSSO" , ""},
                { "GE403_SEQ_CONTROLE_SIGCB" , ""},
                { "GE403_NUM_OCORR_MOVTO" , ""},
                { "GE403_NUM_IDLG" , ""},
                { "GE403_COD_PRODUTO" , ""},
                { "GE403_DTA_MOVIMENTO" , ""},
                { "GE403_DTA_VENCIMENTO" , ""},
                { "GE403_VLR_PREMIO_TOTAL" , ""},
                { "GE403_VLR_IOF" , ""},
                { "GE403_QTD_PARCELA" , ""},
                { "GE403_QTD_DIAS_CUSTODIA" , ""},
                { "GE403_COD_CLIENTE" , ""},
                { "GE403_COD_CEDENTE_SAP" , ""},
                { "GE403_NUM_BOLETO_INTERNO" , ""},
                { "GE403_NUM_NOSSO_NUMERO_SAP" , ""},
                { "GE403_COD_LINHA_DIGITAVEL" , ""},
                { "GE403_NUM_TITULO" , ""},
                { "GE403_IDE_SISTEMA" , ""},
                { "GE403_COD_USUARIO" , ""},
                { "GE403_COD_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_INSERE_CONTROLE_SIGCB_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R2200_MAX_SEQ_CONTROLE_EMISSAO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "GE403_SEQ_CONTROLE_SIGCB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2200_MAX_SEQ_CONTROLE_EMISSAO_DB_SELECT_1_Query1", q8);

            #endregion

            #region R2500_INSERE_CONTROLE_HIST_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "GE403_NUM_PROPOSTA" , ""},
                { "GE403_NUM_CERTIFICADO" , ""},
                { "GE403_NUM_PARCELA" , ""},
                { "GE403_NUM_APOLICE" , ""},
                { "GE403_NUM_ENDOSSO" , ""},
                { "GE403_SEQ_CONTROLE_SIGCB" , ""},
                { "WS_SEQ_CONTROLE_HIST" , ""},
                { "GE403_COD_SITUACAO" , ""},
                { "GE404_COD_REJEICAO" , ""},
                { "GE403_IDE_SISTEMA" , ""},
                { "GE403_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2500_INSERE_CONTROLE_HIST_DB_INSERT_1_Insert1", q9);

            #endregion

            #region R2510_MAX_SEQ_CONTROLE_SIGCB_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "WS_SEQ_CONTROLE_HIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2510_MAX_SEQ_CONTROLE_SIGCB_DB_SELECT_1_Query1", q10);

            #endregion

            #region R3000_UPDATE_SIT_CNTRLE_SIGCB_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "GE403_COD_SITUACAO" , ""},
                { "GE403_COD_USUARIO" , ""},
                { "GE403_SEQ_CONTROLE_SIGCB" , ""},
                { "GE403_NUM_CERTIFICADO" , ""},
                { "GE403_NUM_PROPOSTA" , ""},
                { "GE403_NUM_PARCELA" , ""},
                { "GE403_NUM_APOLICE" , ""},
                { "GE403_NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_UPDATE_SIT_CNTRLE_SIGCB_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R3500_UPDATE_SIT_AGUARDA_SAP_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "GE403_NUM_OCORR_MOVTO" , ""},
                { "WS_IND_NUM_OCORR_MOVTO" , ""},
                { "GE403_NUM_IDLG" , ""},
                { "WS_IND_NUM_IDLG" , ""},
                { "GE403_COD_SITUACAO" , ""},
                { "GE403_COD_USUARIO" , ""},
                { "GE403_SEQ_CONTROLE_SIGCB" , ""},
                { "GE403_NUM_CERTIFICADO" , ""},
                { "GE403_NUM_PROPOSTA" , ""},
                { "GE403_NUM_PARCELA" , ""},
                { "GE403_NUM_APOLICE" , ""},
                { "GE403_NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3500_UPDATE_SIT_AGUARDA_SAP_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R4500_UPDATE_NN_REGISTRADO_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "GE403_NUM_OCORR_MOVTO" , ""},
                { "WS_IND_NUM_OCORR_MOVTO" , ""},
                { "GE403_COD_LINHA_DIGITAVEL" , ""},
                { "WS_IND_COD_LIN_DIG" , ""},
                { "GE403_COD_CEDENTE_SAP" , ""},
                { "WS_IND_COD_CEDENTE" , ""},
                { "GE403_NUM_NOSSO_NUMERO_SAP" , ""},
                { "WS_IND_NN_SAP" , ""},
                { "GE403_NUM_BOLETO_INTERNO" , ""},
                { "WS_IND_BOL_INT" , ""},
                { "GE403_NUM_TITULO" , ""},
                { "WS_IND_NUM_TITULO" , ""},
                { "GE403_NUM_IDLG" , ""},
                { "WS_IND_NUM_IDLG" , ""},
                { "GE403_COD_SITUACAO" , ""},
                { "GE403_COD_USUARIO" , ""},
                { "GE403_SEQ_CONTROLE_SIGCB" , ""},
                { "GE403_NUM_CERTIFICADO" , ""},
                { "GE403_NUM_PROPOSTA" , ""},
                { "GE403_NUM_PARCELA" , ""},
                { "GE403_NUM_APOLICE" , ""},
                { "GE403_NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4500_UPDATE_NN_REGISTRADO_DB_UPDATE_1_Update1", q13);

            #endregion

            #region R4910_UPDATE_NN_SAP_DB_UPDATE_1_Update1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "GE403_NUM_TITULO" , ""},
                { "WS_IND_NUM_TITULO" , ""},
                { "GE403_NUM_APOLICE" , ""},
                { "GE403_NUM_ENDOSSO" , ""},
                { "GE403_NUM_PARCELA" , ""},
                { "GE403_NUM_NOSSO_NUMERO_SAP" , ""},
                { "GE403_SEQ_CONTROLE_SIGCB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4910_UPDATE_NN_SAP_DB_UPDATE_1_Update1", q14);

            #endregion

            #region R4920_INSERE_NN_HIST_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "WS_SEQ_CONTROLE_HIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4920_INSERE_NN_HIST_DB_SELECT_1_Query1", q15);

            #endregion

            #region R4920_INSERE_NN_HIST_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "GE403_NUM_PROPOSTA" , ""},
                { "GE403_NUM_CERTIFICADO" , ""},
                { "GE403_NUM_PARCELA" , ""},
                { "GE403_NUM_APOLICE" , ""},
                { "GE403_NUM_ENDOSSO" , ""},
                { "GE403_SEQ_CONTROLE_SIGCB" , ""},
                { "WS_SEQ_CONTROLE_HIST" , ""},
                { "GE403_COD_SITUACAO" , ""},
                { "GE404_COD_REJEICAO" , ""},
                { "GE403_IDE_SISTEMA" , ""},
                { "GE403_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4920_INSERE_NN_HIST_DB_INSERT_1_Insert1", q16);

            #endregion

            #region R5000_CONSULTA_NN_NUM_IDLG_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "GE403_NUM_PROPOSTA" , ""},
                { "GE403_NUM_CERTIFICADO" , ""},
                { "GE403_NUM_PARCELA" , ""},
                { "GE403_NUM_APOLICE" , ""},
                { "GE403_NUM_ENDOSSO" , ""},
                { "GE403_SEQ_CONTROLE_SIGCB" , ""},
                { "GE403_DTA_MOVIMENTO" , ""},
                { "GE403_NUM_OCORR_MOVTO" , ""},
                { "GE403_NUM_IDLG" , ""},
                { "GE403_COD_PRODUTO" , ""},
                { "GE403_DTA_VENCIMENTO" , ""},
                { "GE403_VLR_PREMIO_TOTAL" , ""},
                { "GE403_VLR_IOF" , ""},
                { "GE403_QTD_PARCELA" , ""},
                { "GE403_QTD_DIAS_CUSTODIA" , ""},
                { "GE403_COD_CLIENTE" , ""},
                { "GE403_COD_CEDENTE_SAP" , ""},
                { "GE403_NUM_BOLETO_INTERNO" , ""},
                { "GE403_NUM_NOSSO_NUMERO_SAP" , ""},
                { "GE403_COD_LINHA_DIGITAVEL" , ""},
                { "GE403_NUM_TITULO" , ""},
                { "GE403_IDE_SISTEMA" , ""},
                { "GE403_COD_USUARIO" , ""},
                { "GE403_COD_SITUACAO" , ""},
                { "WS_DTA_VENC_CUSTODIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_CONSULTA_NN_NUM_IDLG_DB_SELECT_1_Query1", q17);

            #endregion

            #region R6000_CONSULTA_POR_NN_SAP_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "GE403_NUM_PROPOSTA" , ""},
                { "GE403_NUM_CERTIFICADO" , ""},
                { "GE403_NUM_PARCELA" , ""},
                { "GE403_NUM_APOLICE" , ""},
                { "GE403_NUM_ENDOSSO" , ""},
                { "GE403_SEQ_CONTROLE_SIGCB" , ""},
                { "GE403_DTA_MOVIMENTO" , ""},
                { "GE403_NUM_OCORR_MOVTO" , ""},
                { "GE403_NUM_IDLG" , ""},
                { "GE403_COD_PRODUTO" , ""},
                { "GE403_DTA_VENCIMENTO" , ""},
                { "GE403_VLR_PREMIO_TOTAL" , ""},
                { "GE403_VLR_IOF" , ""},
                { "GE403_QTD_PARCELA" , ""},
                { "GE403_QTD_DIAS_CUSTODIA" , ""},
                { "GE403_COD_CLIENTE" , ""},
                { "GE403_COD_CEDENTE_SAP" , ""},
                { "GE403_NUM_BOLETO_INTERNO" , ""},
                { "GE403_NUM_NOSSO_NUMERO_SAP" , ""},
                { "GE403_COD_LINHA_DIGITAVEL" , ""},
                { "GE403_NUM_TITULO" , ""},
                { "GE403_IDE_SISTEMA" , ""},
                { "GE403_COD_USUARIO" , ""},
                { "GE403_COD_SITUACAO" , ""},
                { "WS_DTA_VENC_CUSTODIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_CONSULTA_POR_NN_SAP_DB_SELECT_1_Query1", q18);

            #endregion

            #region GEWES001_Call1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "LK_COD_SISTEMA_WE001" , ""},
                { "LKN_COD_SISTEMA_WE001" , ""},
                { "LK_NUM_PROPOSTA_WE001" , ""},
                { "LKN_NUM_PROPOSTA_WE001" , ""},
                { "LK_NUM_APOLICE_WE001" , ""},
                { "LKN_NUM_APOLICE_WE001" , ""},
                { "LK_NUM_ENDOSSO_WE001" , ""},
                { "LKN_NUM_ENDOSSO_WE001" , ""},
                { "LK_COD_CANAL_WE001" , ""},
                { "LKN_COD_CANAL_WE001" , ""},
                { "LK_NUM_PARCELA_WE001" , ""},
                { "LKN_NUM_PARCELA_WE001" , ""},
                { "LK_NUM_TOTAL_PARCELAS_WE001" , ""},
                { "LKN_NUM_TOTAL_PARCELAS_WE001" , ""},
                { "LK_COD_FONTE_WE001" , ""},
                { "LKN_COD_FONTE_WE001" , ""},
                { "LK_COD_CENTRO_LUCRO_WE001" , ""},
                { "LKN_COD_CENTRO_LUCRO_WE001" , ""},
                { "LK_NUM_RAMO_SUSEP_WE001" , ""},
                { "LKN_NUM_RAMO_SUSEP_WE001" , ""},
                { "LK_COD_TIPO_CONVENIO_WE001" , ""},
                { "LKN_COD_TIPO_CONVENIO_WE001" , ""},
                { "LK_COD_COMPROMISSO_WE001" , ""},
                { "LKN_COD_COMPROMISSO_WE001" , ""},
                { "LK_NUM_CERTIFICADO_WE001" , ""},
                { "LKN_NUM_CERTIFICADO_WE001" , ""},
                { "LK_NUM_TITULO_WE001" , ""},
                { "LKN_NUM_TITULO_WE001" , ""},
                { "LK_NUM_GRUPO_WE001" , ""},
                { "LKN_NUM_GRUPO_WE001" , ""},
                { "LK_NUM_COTA_WE001" , ""},
                { "LKN_NUM_COTA_WE001" , ""},
                { "LK_VLR_FUNDO_COMUM_WE001" , ""},
                { "LKN_VLR_FUNDO_COMUM_WE001" , ""},
                { "LK_VLR_FUNDO_RESERVA_WE001" , ""},
                { "LKN_VLR_FUNDO_RESERVA_WE001" , ""},
                { "LK_VLR_MULTA_JUROS_WE001" , ""},
                { "LKN_VLR_MULTA_JUROS_WE001" , ""},
                { "LK_VLR_SEGURO_WE001" , ""},
                { "LKN_VLR_SEGURO_WE001" , ""},
                { "LK_VLR_TAXA_ADMINISTRAC_WE001" , ""},
                { "LKN_VLR_TAXA_ADMINISTRAC_WE001" , ""},
                { "LK_VLR_REPASS_MUL_JUROS_WE001" , ""},
                { "LKN_VLR_REPASS_MUL_JUROS_WE001" , ""},
                { "LK_VLR_BOLETO_WE001" , ""},
                { "LKN_VLR_BOLETO_WE001" , ""},
                { "LK_QTD_PERMANENCIA_WE001" , ""},
                { "LKN_QTD_PERMANENCIA_WE001" , ""},
                { "LK_VLR_IOF_WE001" , ""},
                { "LKN_VLR_IOF_WE001" , ""},
                { "LK_IND_REGISTRA_ONLINE_WE001" , ""},
                { "LKN_IND_REGISTRA_ONLINE_WE001" , ""},
                { "LK_PCT_MULTA_WE001" , ""},
                { "LKN_PCT_MULTA_WE001" , ""},
                { "LK_VLR_JUROS_DIA_WE001" , ""},
                { "LKN_VLR_JUROS_DIA_WE001" , ""},
                { "LK_NOM_PESSOA_WE001" , ""},
                { "LKN_NOM_PESSOA_WE001" , ""},
                { "LK_NOM_ULTIMO_NOME_WE001" , ""},
                { "LKN_NOM_ULTIMO_NOME_WE001" , ""},
                { "LK_COD_FORMA_TRATAMENTO_WE001" , ""},
                { "LKN_COD_FORMA_TRATAMENTO_WE001" , ""},
                { "LK_COD_ENDERECO_WE001" , ""},
                { "LKN_COD_ENDERECO_WE001" , ""},
                { "LK_NUM_ENDERECO_WE001" , ""},
                { "LKN_NUM_ENDERECO_WE001" , ""},
                { "LK_DES_ENDERECO_WE001" , ""},
                { "LKN_DES_ENDERECO_WE001" , ""},
                { "LK_DES_COMPLEMENTO_WE001" , ""},
                { "LKN_DES_COMPLEMENTO_WE001" , ""},
                { "LK_NOM_BAIRRO_WE001" , ""},
                { "LKN_NOM_BAIRRO_WE001" , ""},
                { "LK_NOM_CIDADE_WE001" , ""},
                { "LKN_NOM_CIDADE_WE001" , ""},
                { "LK_COD_UF_WE001" , ""},
                { "LKN_COD_UF_WE001" , ""},
                { "LK_NUM_CEP_WE001" , ""},
                { "LKN_NUM_CEP_WE001" , ""},
                { "LK_IND_CONCILIA_SIGPF_WE001" , ""},
                { "LKN_IND_CONCILIA_SIGPF_WE001" , ""},
                { "LK_COD_EVENTO_WE001" , ""},
                { "LKN_COD_EVENTO_WE001" , ""},
                { "LK_COD_IDENTIFICADOR_WE001" , ""},
                { "LKN_COD_IDENTIFICADOR_WE001" , ""},
                { "LK_DTA_DOCUMENTO_WE001" , ""},
                { "LKN_DTA_DOCUMENTO_WE001" , ""},
                { "LK_DTA_LANCAM_DOCUMENTO_WE001" , ""},
                { "LKN_DTA_LANCAM_DOCUMENTO_WE001" , ""},
                { "LK_DTA_VENCIMENTO_WE001" , ""},
                { "LKN_DTA_VENCIMENTO_WE001" , ""},
                { "LK_NUM_CONTA_CONTRATO_WE001" , ""},
                { "LKN_NUM_CONTA_CONTRATO_WE001" , ""},
                { "LK_NUM_CPF_CNPJ_WE001" , ""},
                { "LKN_NUM_CPF_CNPJ_WE001" , ""},
                { "LK_COD_RETORNO_WE001" , ""},
                { "LKN_COD_RETORNO_WE001" , ""},
                { "LK_DES_MENS_SISTEMA_WE001" , ""},
                { "LKN_DES_MENS_SISTEMA_WE001" , ""},
                { "LK_DES_MENS_AMIGAVE_WE001" , ""},
                { "LKN_DES_MENS_AMIGAVE_WE001" , ""},
                { "LK_COD_ORIGEM_WE001" , ""},
                { "LKN_COD_ORIGEM_WE001" , ""},
                { "LK_COD_EMPRESA_WE001" , ""},
                { "LKN_COD_EMPRESA_WE001" , ""},
                { "LK_NUM_LOTE_WE001" , ""},
                { "LKN_NUM_LOTE_WE001" , ""},
                { "LK_NUM_DOCUMENTO_WE001" , ""},
                { "LKN_NUM_DOCUMENTO_WE001" , ""},
                { "LK_NUM_BOLETO_WE001" , ""},
                { "LKN_NUM_BOLETO_WE001" , ""},
                { "LK_NUM_NOSSO_NUMERO_WE001" , ""},
                { "LKN_NUM_NOSSO_NUMERO_WE001" , ""},
                { "LK_DES_LINHA_DIGITAVEL_WE001" , ""},
                { "LKN_DES_LINHA_DIGITAVEL_WE001" , ""},
                { "LK_NUM_AGENCIA_CEDENTE_WE001" , ""},
                { "LKN_NUM_AGENCIA_CEDENTE_WE001" , ""},
                { "LK_NUM_PARCEIRO_NEGOC_WE001" , ""},
                { "LKN_NUM_PARCEIRO_NEGOC_WE001" , ""},
                { "LK_VLR_TOTAL_BOLETO_WE001" , ""},
                { "LKN_VLR_TOTAL_BOLETO_WE001" , ""},
                { "LK_LST_MENSAGENS_CONT_WE001" , ""},
                { "LKN_LST_MENSAGENS_CONT_WE001" , ""},
                { "LK_COD_TIPO_WE001" , ""},
                { "LKN_COD_TIPO_WE001" , ""},
                { "LK_COD_MENSAGEM_WE001" , ""},
                { "LKN_COD_MENSAGEM_WE001" , ""},
                { "LK_NUM_MENSAGEM_WE001" , ""},
                { "LKN_NUM_MENSAGEM_WE001" , ""},
                { "LK_DES_MENSAGEM_WE001" , ""},
                { "LKN_DES_MENSAGEM_WE001" , ""},
                { "LK_DES_LOG_WE001" , ""},
                { "LKN_DES_LOG_WE001" , ""},
                { "LK_SEQ_LOG_WE001" , ""},
                { "LKN_SEQ_LOG_WE001" , ""},
                { "LK_NOM_PARAMETRO_WE001" , ""},
                { "LKN_NOM_PARAMETRO_WE001" , ""},
                { "LK_NUM_LINHA_WE001" , ""},
                { "LKN_NUM_LINHA_WE001" , ""},
                { "LK_NOM_CAMPO_WE001" , ""},
                { "LKN_NOM_CAMPO_WE001" , ""},
                { "LK_NOM_SISTEMA_WE001" , ""},
                { "LKN_NOM_SISTEMA_WE001" , ""},
                { "LK_IND_ERRO_WE001" , ""},
                { "LKN_IND_ERRO_WE001" , ""},
                { "LK_MSG_RET_WE001" , ""},
                { "LKN_MSG_RET_WE001" , ""},
                { "LK_NM_TAB_WE001" , ""},
                { "LKN_NM_TAB_WE001" , ""},
                { "LK_SQLCODE_WE001" , ""},
                { "LKN_SQLCODE_WE001" , ""},
                { "LK_SQLERRMC_WE001" , ""},
                { "LKN_SQLERRMC_WE001" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("GEWES001_Call1", q19);

            #endregion

            #region R7010_00_SELECT_CLIENTE_RESS_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NUM_CPFCGC_ACORDO" , ""},
                { "SIARDEVC_NOM_RESP_ACORDO" , ""},
                { "SIARDEVC_DES_ENDERECO" , ""},
                { "SIARDEVC_NOM_CIDADE" , ""},
                { "SIARDEVC_COD_UF" , ""},
                { "SIARDEVC_NUM_CEP" , ""},
                { "SIARDEVC_COD_FONTE" , ""},
                { "SIARDEVC_TIPO_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7010_00_SELECT_CLIENTE_RESS_DB_SELECT_1_Query1", q20);

            #endregion

            #region R7200_00_SELECT_CLIENTE_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_TIPO_PESSOA" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_IDE_SEXO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7200_00_SELECT_CLIENTE_DB_SELECT_1_Query1", q21);

            #endregion

            #region R7300_00_SELECT_ENDERECOS_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
                { "ENDERECO_DDD" , ""},
                { "ENDERECO_TELEFONE" , ""},
                { "ENDERECO_FAX" , ""},
                { "ENDERECO_DES_COMPLEMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7300_00_SELECT_ENDERECOS_DB_SELECT_1_Query1", q22);

            #endregion

            #region R7301_00_ENDOSSO_ENDERECO_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_OCORR_ENDERECO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7301_00_ENDOSSO_ENDERECO_DB_SELECT_1_Query1", q23);

            #endregion

            #region R7301_00_ENDOSSO_ENDERECO_DB_SELECT_2_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
                { "ENDERECO_DDD" , ""},
                { "ENDERECO_TELEFONE" , ""},
                { "ENDERECO_FAX" , ""},
                { "ENDERECO_DES_COMPLEMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7301_00_ENDOSSO_ENDERECO_DB_SELECT_2_Query1", q24);

            #endregion

            #endregion
        }

        [Fact]
        public static void GE0350S_Tests_Fact_CodigoFuncao02_ReturnCode_00()
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
                var inputParam = new GE0350S_REGISTRO_LINKAGE_GE0350S()
                {
                    LK_GE350_COD_CANAL = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0000
                    },
                    LK_GE350_COD_CLIENTE = new IntBasis()
                    {
                        Pic = new PIC("S9", "9", "S9(09)"),
                        Value = 014293265
                    },
                    LK_GE350_COD_FONTE = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0000
                    },
                    LK_GE350_COD_FUNCAO = new IntBasis()
                    {
                        Pic = new PIC("9", "2", "9(02)."),
                        Value = 02
                    },
                    LK_GE350_COD_PRODUTO = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 6922
                    },
                    LK_GE350_COD_SITUACAO = new StringBasis()
                    {
                        Pic = new PIC("X", "1", "X(01)."),
                        Value = "P"
                    },
                    LK_GE350_COD_USUARIO = new StringBasis()
                    {
                        Pic = new PIC("X", "10", "X(10)."),
                        Value = "BI0230B1  "
                    },
                    LK_GE350_DTA_MOVIMENTO = new StringBasis()
                    {
                        Pic = new PIC("X", "10", "X(10)."),
                        Value = "2024-01-01"
                    },
                    LK_GE350_DTA_VENCIMENTO = new StringBasis()
                    {
                        Pic = new PIC("X", "10", "X(10)."),
                        Value = "2019-06-29"
                    },
                    LK_GE350_IDE_SISTEMA = new StringBasis()
                    {
                        Pic = new PIC("X", "2", "X(02)."),
                        Value = "BI"
                    },
                    LK_GE350_NUM_APOLICE = new DoubleBasis
                    {
                        Pic = new PIC("S9", "13", "S9(13)V"),
                        Value = 0108199999998
                    },
                    LK_GE350_NUM_BLTO_INTERNO = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "10", "S9(10)V"),
                        Value = 0000000000
                    },
                    LK_GE350_NUM_CERTIFICADO = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "15", "S9(15)V"),
                        Value = 202401010000017
                    },
                    LK_GE350_NUM_ENDOSSO = new IntBasis()
                    {
                        Pic = new PIC("S9", "9", "S9(09)"),
                        Value = 000000014
                    },
                    LK_GE350_NUM_OCORR_MOVTO = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "18", "S9(18)V"),
                        Value = 000000000000000000
                    },
                    LK_GE350_NUM_PARCELA = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0001
                    },
                    LK_GE350_NUM_PROPOSTA = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "16", "S9(16)V"),
                        Value = 0202401010000017
                    },
                    LK_GE350_NUM_TITULO = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "16", "S9(16)V"),
                        Value = 0202401010000017
                    },
                    LK_GE350_QTD_DIAS_CUSTODIA = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0029
                    },
                    LK_GE350_QTD_PARCELA = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0001
                    },
                    LK_GE350_SEQ_CNTRLE_SIGCB = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0000
                    },
                    LK_GE350_VLR_IOF = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2)
                    {
                        Value = 0000000000000.15
                    },
                    LK_GE350_VLR_PREMIO_TOTAL = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2)
                    {
                        Value = 0000000000038.50
                    }
                };
                #endregion
                var program = new GE0350S();
                program.Execute(inputParam);

                Assert.True(program.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO == 0);

                //R2100_INSERE_CONTROLE_SIGCB_DB_INSERT_1_Insert1
                var envList0 = AppSettings.TestSet.DynamicData["R2100_INSERE_CONTROLE_SIGCB_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList0.Count > 1);
                Assert.True(envList0[1].TryGetValue("GE403_NUM_PROPOSTA", out var val0r) && val0r.Contains("0202401010000017"));
                Assert.True(envList0[1].TryGetValue("GE403_NUM_APOLICE", out var val1r) && val1r.Contains("0108199999998"));

                //R2500_INSERE_CONTROLE_HIST_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R2500_INSERE_CONTROLE_HIST_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("GE403_COD_SITUACAO", out var val2r) && val2r.Contains("P"));
                Assert.True(envList1[1].TryGetValue("GE403_NUM_APOLICE", out var val3r) && val3r.Contains("0108199999998"));
            }
        }
        [Fact]
        public static void GE0350S_Tests_Fact_CodigoFuncao09_ReturnCode_00()
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
                var inputParam = new GE0350S_REGISTRO_LINKAGE_GE0350S()
                {
                    LK_GE350_COD_CANAL = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0000
                    },
                    LK_GE350_COD_CLIENTE = new IntBasis()
                    {
                        Pic = new PIC("S9", "9", "S9(09)"),
                        Value = 014293265
                    },
                    LK_GE350_COD_FONTE = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0000
                    },
                    LK_GE350_COD_FUNCAO = new IntBasis()
                    {
                        Pic = new PIC("9", "2", "9(02)."),
                        Value = 09
                    },
                    LK_GE350_COD_PRODUTO = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 6922
                    },
                    LK_GE350_COD_SITUACAO = new StringBasis()
                    {
                        Pic = new PIC("X", "1", "X(01)."),
                        Value = "P"
                    },
                    LK_GE350_COD_USUARIO = new StringBasis()
                    {
                        Pic = new PIC("X", "10", "X(10)."),
                        Value = "BI0230B1  "
                    },
                    LK_GE350_DTA_MOVIMENTO = new StringBasis()
                    {
                        Pic = new PIC("X", "10", "X(10)."),
                        Value = "2024-01-01"
                    },
                    LK_GE350_DTA_VENCIMENTO = new StringBasis()
                    {
                        Pic = new PIC("X", "10", "X(10)."),
                        Value = "2019-06-29"
                    },
                    LK_GE350_IDE_SISTEMA = new StringBasis()
                    {
                        Pic = new PIC("X", "2", "X(02)."),
                        Value = "BI"
                    },
                    LK_GE350_NUM_APOLICE = new DoubleBasis
                    {
                        Pic = new PIC("S9", "13", "S9(13)V"),
                        Value = 19790324
                    },
                    LK_GE350_NUM_BLTO_INTERNO = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "10", "S9(10)V"),
                        Value = 0000000000
                    },
                    LK_GE350_NUM_CERTIFICADO = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "15", "S9(15)V"),
                        Value = 202401010000017
                    },
                    LK_GE350_NUM_ENDOSSO = new IntBasis()
                    {
                        Pic = new PIC("S9", "9", "S9(09)"),
                        Value = 000000014
                    },
                    LK_GE350_NUM_OCORR_MOVTO = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "18", "S9(18)V"),
                        Value = 000000000000000000
                    },
                    LK_GE350_NUM_PARCELA = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0001
                    },
                    LK_GE350_NUM_PROPOSTA = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "16", "S9(16)V"),
                        Value = 0202401010000017
                    },
                    LK_GE350_NUM_TITULO = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "16", "S9(16)V"),
                        Value = 0202401010000017
                    },
                    LK_GE350_QTD_DIAS_CUSTODIA = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0029
                    },
                    LK_GE350_QTD_PARCELA = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0001
                    },
                    LK_GE350_SEQ_CNTRLE_SIGCB = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0000
                    },
                    LK_GE350_VLR_IOF = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2)
                    {
                        Value = 0000000000000.15
                    },
                    LK_GE350_VLR_PREMIO_TOTAL = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2)
                    {
                        Value = 0000000000038.50
                    }
                };
                #endregion
                var program = new GE0350S();
                program.Execute(inputParam);

                Assert.True(program.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO == 0);

                //R4910_UPDATE_NN_SAP_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["R4910_UPDATE_NN_SAP_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("GE403_NUM_APOLICE", out var val0r) && val0r.Contains("0000019790324"));
                Assert.True(envList0[1].TryGetValue("GE403_NUM_TITULO", out var val1r) && val1r.Contains("0202401010000017"));

                //R4920_INSERE_NN_HIST_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R4920_INSERE_NN_HIST_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("GE403_NUM_APOLICE", out var val2r) && val2r.Contains("0000019790324"));
                Assert.True(envList1[1].TryGetValue("GE403_COD_SITUACAO", out var val3r) && val3r.Contains("P"));
            }
        }
        [Fact]
        public static void GE0350S_Tests_Fact_CodigoFuncao03_Movimento00_ReturnCode_00()
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
                var inputParam = new GE0350S_REGISTRO_LINKAGE_GE0350S()
                {
                    LK_GE350_COD_CANAL = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0000
                    },
                    LK_GE350_COD_CLIENTE = new IntBasis()
                    {
                        Pic = new PIC("S9", "9", "S9(09)"),
                        Value = 014293265
                    },
                    LK_GE350_COD_FONTE = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0000
                    },
                    LK_GE350_COD_FUNCAO = new IntBasis()
                    {
                        Pic = new PIC("9", "2", "9(02)."),
                        Value = 03
                    },
                    LK_GE350_COD_PRODUTO = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 6922
                    },
                    LK_GE350_COD_SITUACAO = new StringBasis()
                    {
                        Pic = new PIC("X", "1", "X(01)."),
                        Value = "H"
                    },
                    LK_GE350_COD_USUARIO = new StringBasis()
                    {
                        Pic = new PIC("X", "10", "X(10)."),
                        Value = "BI0230B1  "
                    },
                    LK_GE350_DTA_MOVIMENTO = new StringBasis()
                    {
                        Pic = new PIC("X", "10", "X(10)."),
                        Value = "2024-01-01"
                    },
                    LK_GE350_DTA_VENCIMENTO = new StringBasis()
                    {
                        Pic = new PIC("X", "10", "X(10)."),
                        Value = "2019-06-29"
                    },
                    LK_GE350_IDE_SISTEMA = new StringBasis()
                    {
                        Pic = new PIC("X", "2", "X(02)."),
                        Value = "BI"
                    },
                    LK_GE350_NUM_APOLICE = new DoubleBasis
                    {
                        Pic = new PIC("S9", "13", "S9(13)V"),
                        Value = 20100826
                    },
                    LK_GE350_NUM_BLTO_INTERNO = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "10", "S9(10)V"),
                        Value = 0000000000
                    },
                    LK_GE350_NUM_CERTIFICADO = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "15", "S9(15)V"),
                        Value = 202401010000017
                    },
                    LK_GE350_NUM_ENDOSSO = new IntBasis()
                    {
                        Pic = new PIC("S9", "9", "S9(09)"),
                        Value = 000000014
                    },
                    LK_GE350_NUM_OCORR_MOVTO = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "18", "S9(18)V"),
                        Value = 000000000000000000
                    },
                    LK_GE350_NUM_PARCELA = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0001
                    },
                    LK_GE350_NUM_PROPOSTA = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "16", "S9(16)V"),
                        Value = 0202401010000017
                    },
                    LK_GE350_NUM_TITULO = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "16", "S9(16)V"),
                        Value = 0202401010000017
                    },
                    LK_GE350_QTD_DIAS_CUSTODIA = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0029
                    },
                    LK_GE350_QTD_PARCELA = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0001
                    },
                    LK_GE350_SEQ_CNTRLE_SIGCB = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0000
                    },
                    LK_GE350_VLR_IOF = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2)
                    {
                        Value = 0000000000000.15
                    },
                    LK_GE350_VLR_PREMIO_TOTAL = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2)
                    {
                        Value = 0000000000038.50
                    }
                };
                #endregion
                var program = new GE0350S();
                program.Execute(inputParam);

                Assert.True(program.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO == 0);

                //R3000_UPDATE_SIT_CNTRLE_SIGCB_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["R3000_UPDATE_SIT_CNTRLE_SIGCB_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("GE403_COD_SITUACAO", out var val0r) && val0r.Contains("H"));
                Assert.True(envList0[1].TryGetValue("GE403_NUM_APOLICE", out var val1r) && val1r.Contains("0000020100826"));

                //R2500_INSERE_CONTROLE_HIST_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R2500_INSERE_CONTROLE_HIST_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("GE403_COD_SITUACAO", out var val2r) && val2r.Contains("H"));
                Assert.True(envList1[1].TryGetValue("GE403_NUM_APOLICE", out var val3r) && val3r.Contains("0000020100826"));
            }
        }
        [Fact]
        public static void GE0350S_Tests_Fact_CodigoFuncao03_ReturnCode_00()
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
                var inputParam = new GE0350S_REGISTRO_LINKAGE_GE0350S()
                {
                    LK_GE350_COD_CANAL = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0000
                    },
                    LK_GE350_COD_CLIENTE = new IntBasis()
                    {
                        Pic = new PIC("S9", "9", "S9(09)"),
                        Value = 014293265
                    },
                    LK_GE350_COD_FONTE = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0000
                    },
                    LK_GE350_COD_FUNCAO = new IntBasis()
                    {
                        Pic = new PIC("9", "2", "9(02)."),
                        Value = 03
                    },
                    LK_GE350_COD_PRODUTO = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 6922
                    },
                    LK_GE350_COD_SITUACAO = new StringBasis()
                    {
                        Pic = new PIC("X", "1", "X(01)."),
                        Value = "H"
                    },
                    LK_GE350_COD_USUARIO = new StringBasis()
                    {
                        Pic = new PIC("X", "10", "X(10)."),
                        Value = "BI0230B1  "
                    },
                    LK_GE350_DTA_MOVIMENTO = new StringBasis()
                    {
                        Pic = new PIC("X", "10", "X(10)."),
                        Value = "2024-01-01"
                    },
                    LK_GE350_DTA_VENCIMENTO = new StringBasis()
                    {
                        Pic = new PIC("X", "10", "X(10)."),
                        Value = "2019-06-29"
                    },
                    LK_GE350_IDE_SISTEMA = new StringBasis()
                    {
                        Pic = new PIC("X", "2", "X(02)."),
                        Value = "BI"
                    },
                    LK_GE350_NUM_APOLICE = new DoubleBasis
                    {
                        Pic = new PIC("S9", "13", "S9(13)V"),
                        Value = 20100826
                    },
                    LK_GE350_NUM_BLTO_INTERNO = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "10", "S9(10)V"),
                        Value = 0000000000
                    },
                    LK_GE350_NUM_CERTIFICADO = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "15", "S9(15)V"),
                        Value = 202401010000017
                    },
                    LK_GE350_NUM_ENDOSSO = new IntBasis()
                    {
                        Pic = new PIC("S9", "9", "S9(09)"),
                        Value = 000000014
                    },
                    LK_GE350_NUM_OCORR_MOVTO = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "18", "S9(18)V"),
                        Value = 000000000000000001
                    },
                    LK_GE350_NUM_PARCELA = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0001
                    },
                    LK_GE350_NUM_PROPOSTA = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "16", "S9(16)V"),
                        Value = 0202401010000017
                    },
                    LK_GE350_NUM_TITULO = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "16", "S9(16)V"),
                        Value = 0202401010000017
                    },
                    LK_GE350_QTD_DIAS_CUSTODIA = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0029
                    },
                    LK_GE350_QTD_PARCELA = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0001
                    },
                    LK_GE350_SEQ_CNTRLE_SIGCB = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0000
                    },
                    LK_GE350_VLR_IOF = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2)
                    {
                        Value = 0000000000000.15
                    },
                    LK_GE350_VLR_PREMIO_TOTAL = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2)
                    {
                        Value = 0000000000038.50
                    }
                };
                #endregion
                var program = new GE0350S();
                program.Execute(inputParam);

                Assert.True(program.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO == 0);

                //R3500_UPDATE_SIT_AGUARDA_SAP_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["R3500_UPDATE_SIT_AGUARDA_SAP_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("GE403_COD_SITUACAO", out var val0r) && val0r.Contains("H"));
                Assert.True(envList0[1].TryGetValue("GE403_NUM_APOLICE", out var val1r) && val1r.Contains("0000020100826"));

                //R2500_INSERE_CONTROLE_HIST_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R2500_INSERE_CONTROLE_HIST_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("GE403_NUM_APOLICE", out var val2r) && val2r.Contains("0000020100826"));
                Assert.True(envList1[1].TryGetValue("GE403_COD_SITUACAO", out var val3r) && val3r.Contains("H"));
            }
        }
        [Fact]
        public static void GE0350S_Tests_Fact_CodigoFuncaoInvalida_ReturnCode_1()
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
                var inputParam = new GE0350S_REGISTRO_LINKAGE_GE0350S()
                {
                    LK_GE350_COD_CANAL = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0000
                    },
                    LK_GE350_COD_CLIENTE = new IntBasis()
                    {
                        Pic = new PIC("S9", "9", "S9(09)"),
                        Value = 014293265
                    },
                    LK_GE350_COD_FONTE = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0000
                    },
                    LK_GE350_COD_FUNCAO = new IntBasis()
                    {
                        Pic = new PIC("9", "2", "9(02)."),
                        Value = 10
                    },
                    LK_GE350_COD_PRODUTO = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 6922
                    },
                    LK_GE350_COD_SITUACAO = new StringBasis()
                    {
                        Pic = new PIC("X", "1", "X(01)."),
                        Value = "H"
                    },
                    LK_GE350_COD_USUARIO = new StringBasis()
                    {
                        Pic = new PIC("X", "10", "X(10)."),
                        Value = "BI0230B1  "
                    },
                    LK_GE350_DTA_MOVIMENTO = new StringBasis()
                    {
                        Pic = new PIC("X", "10", "X(10)."),
                        Value = "2024-01-01"
                    },
                    LK_GE350_DTA_VENCIMENTO = new StringBasis()
                    {
                        Pic = new PIC("X", "10", "X(10)."),
                        Value = "2019-06-29"
                    },
                    LK_GE350_IDE_SISTEMA = new StringBasis()
                    {
                        Pic = new PIC("X", "2", "X(02)."),
                        Value = "BI"
                    },
                    LK_GE350_NUM_APOLICE = new DoubleBasis
                    {
                        Pic = new PIC("S9", "13", "S9(13)V"),
                        Value = 20100826
                    },
                    LK_GE350_NUM_BLTO_INTERNO = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "10", "S9(10)V"),
                        Value = 0000000000
                    },
                    LK_GE350_NUM_CERTIFICADO = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "15", "S9(15)V"),
                        Value = 202401010000017
                    },
                    LK_GE350_NUM_ENDOSSO = new IntBasis()
                    {
                        Pic = new PIC("S9", "9", "S9(09)"),
                        Value = 000000014
                    },
                    LK_GE350_NUM_OCORR_MOVTO = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "18", "S9(18)V"),
                        Value = 000000000000000001
                    },
                    LK_GE350_NUM_PARCELA = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0001
                    },
                    LK_GE350_NUM_PROPOSTA = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "16", "S9(16)V"),
                        Value = 0202401010000017
                    },
                    LK_GE350_NUM_TITULO = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "16", "S9(16)V"),
                        Value = 0202401010000017
                    },
                    LK_GE350_QTD_DIAS_CUSTODIA = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0029
                    },
                    LK_GE350_QTD_PARCELA = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0001
                    },
                    LK_GE350_SEQ_CNTRLE_SIGCB = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0000
                    },
                    LK_GE350_VLR_IOF = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2)
                    {
                        Value = 0000000000000.15
                    },
                    LK_GE350_VLR_PREMIO_TOTAL = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2)
                    {
                        Value = 0000000000038.50
                    }
                };
                #endregion
                var program = new GE0350S();
                program.Execute(inputParam);

                Assert.True(program.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO == 1);

            }
        }
    }
}