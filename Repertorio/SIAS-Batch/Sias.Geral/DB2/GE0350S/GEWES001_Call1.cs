using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0350S
{
    public class GEWES001_Call1 : QueryBasis<GEWES001_Call1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            CALL GEWES001 ( :LK-COD-SISTEMA-WE001
            :LKN-COD-SISTEMA-WE001
            , :LK-NUM-PROPOSTA-WE001
            :LKN-NUM-PROPOSTA-WE001
            , :LK-NUM-APOLICE-WE001
            :LKN-NUM-APOLICE-WE001
            , :LK-NUM-ENDOSSO-WE001
            :LKN-NUM-ENDOSSO-WE001
            , :LK-COD-CANAL-WE001
            :LKN-COD-CANAL-WE001
            , :LK-NUM-PARCELA-WE001
            :LKN-NUM-PARCELA-WE001
            , :LK-NUM-TOTAL-PARCELAS-WE001
            :LKN-NUM-TOTAL-PARCELAS-WE001
            , :LK-COD-FONTE-WE001
            :LKN-COD-FONTE-WE001
            , :LK-COD-CENTRO-LUCRO-WE001
            :LKN-COD-CENTRO-LUCRO-WE001
            , :LK-NUM-RAMO-SUSEP-WE001
            :LKN-NUM-RAMO-SUSEP-WE001
            , :LK-COD-TIPO-CONVENIO-WE001
            :LKN-COD-TIPO-CONVENIO-WE001
            , :LK-COD-COMPROMISSO-WE001
            :LKN-COD-COMPROMISSO-WE001
            , :LK-NUM-CERTIFICADO-WE001
            :LKN-NUM-CERTIFICADO-WE001
            , :LK-NUM-TITULO-WE001
            :LKN-NUM-TITULO-WE001
            , :LK-NUM-GRUPO-WE001
            :LKN-NUM-GRUPO-WE001
            , :LK-NUM-COTA-WE001
            :LKN-NUM-COTA-WE001
            , :LK-VLR-FUNDO-COMUM-WE001
            :LKN-VLR-FUNDO-COMUM-WE001
            , :LK-VLR-FUNDO-RESERVA-WE001
            :LKN-VLR-FUNDO-RESERVA-WE001
            , :LK-VLR-MULTA-JUROS-WE001
            :LKN-VLR-MULTA-JUROS-WE001
            , :LK-VLR-SEGURO-WE001
            :LKN-VLR-SEGURO-WE001
            , :LK-VLR-TAXA-ADMINISTRAC-WE001
            :LKN-VLR-TAXA-ADMINISTRAC-WE001
            , :LK-VLR-REPASS-MUL-JUROS-WE001
            :LKN-VLR-REPASS-MUL-JUROS-WE001
            , :LK-VLR-BOLETO-WE001
            :LKN-VLR-BOLETO-WE001
            , :LK-QTD-PERMANENCIA-WE001
            :LKN-QTD-PERMANENCIA-WE001
            , :LK-VLR-IOF-WE001
            :LKN-VLR-IOF-WE001
            , :LK-IND-REGISTRA-ONLINE-WE001
            :LKN-IND-REGISTRA-ONLINE-WE001
            , :LK-PCT-MULTA-WE001
            :LKN-PCT-MULTA-WE001
            , :LK-VLR-JUROS-DIA-WE001
            :LKN-VLR-JUROS-DIA-WE001
            , :LK-NOM-PESSOA-WE001
            :LKN-NOM-PESSOA-WE001
            , :LK-NOM-ULTIMO-NOME-WE001
            :LKN-NOM-ULTIMO-NOME-WE001
            , :LK-COD-FORMA-TRATAMENTO-WE001
            :LKN-COD-FORMA-TRATAMENTO-WE001
            , :LK-COD-ENDERECO-WE001
            :LKN-COD-ENDERECO-WE001
            , :LK-NUM-ENDERECO-WE001
            :LKN-NUM-ENDERECO-WE001
            , :LK-DES-ENDERECO-WE001
            :LKN-DES-ENDERECO-WE001
            , :LK-DES-COMPLEMENTO-WE001
            :LKN-DES-COMPLEMENTO-WE001
            , :LK-NOM-BAIRRO-WE001
            :LKN-NOM-BAIRRO-WE001
            , :LK-NOM-CIDADE-WE001
            :LKN-NOM-CIDADE-WE001
            , :LK-COD-UF-WE001
            :LKN-COD-UF-WE001
            , :LK-NUM-CEP-WE001
            :LKN-NUM-CEP-WE001
            , :LK-IND-CONCILIA-SIGPF-WE001
            :LKN-IND-CONCILIA-SIGPF-WE001
            , :LK-COD-EVENTO-WE001
            :LKN-COD-EVENTO-WE001
            , :LK-COD-IDENTIFICADOR-WE001
            :LKN-COD-IDENTIFICADOR-WE001
            , :LK-DTA-DOCUMENTO-WE001
            :LKN-DTA-DOCUMENTO-WE001
            , :LK-DTA-LANCAM-DOCUMENTO-WE001
            :LKN-DTA-LANCAM-DOCUMENTO-WE001
            , :LK-DTA-VENCIMENTO-WE001
            :LKN-DTA-VENCIMENTO-WE001
            , :LK-NUM-CONTA-CONTRATO-WE001
            :LKN-NUM-CONTA-CONTRATO-WE001
            , :LK-NUM-CPF-CNPJ-WE001
            :LKN-NUM-CPF-CNPJ-WE001
            , :LK-COD-RETORNO-WE001
            :LKN-COD-RETORNO-WE001
            , :LK-DES-MENS-SISTEMA-WE001
            :LKN-DES-MENS-SISTEMA-WE001
            , :LK-DES-MENS-AMIGAVE-WE001
            :LKN-DES-MENS-AMIGAVE-WE001
            , :LK-COD-ORIGEM-WE001
            :LKN-COD-ORIGEM-WE001
            , :LK-COD-EMPRESA-WE001
            :LKN-COD-EMPRESA-WE001
            , :LK-NUM-LOTE-WE001
            :LKN-NUM-LOTE-WE001
            , :LK-NUM-DOCUMENTO-WE001
            :LKN-NUM-DOCUMENTO-WE001
            , :LK-NUM-BOLETO-WE001
            :LKN-NUM-BOLETO-WE001
            , :LK-NUM-NOSSO-NUMERO-WE001
            :LKN-NUM-NOSSO-NUMERO-WE001
            , :LK-DES-LINHA-DIGITAVEL-WE001
            :LKN-DES-LINHA-DIGITAVEL-WE001
            , :LK-NUM-AGENCIA-CEDENTE-WE001
            :LKN-NUM-AGENCIA-CEDENTE-WE001
            , :LK-NUM-PARCEIRO-NEGOC-WE001
            :LKN-NUM-PARCEIRO-NEGOC-WE001
            , :LK-VLR-TOTAL-BOLETO-WE001
            :LKN-VLR-TOTAL-BOLETO-WE001
            , :LK-LST-MENSAGENS-CONT-WE001
            :LKN-LST-MENSAGENS-CONT-WE001
            , :LK-COD-TIPO-WE001
            :LKN-COD-TIPO-WE001
            , :LK-COD-MENSAGEM-WE001
            :LKN-COD-MENSAGEM-WE001
            , :LK-NUM-MENSAGEM-WE001
            :LKN-NUM-MENSAGEM-WE001
            , :LK-DES-MENSAGEM-WE001
            :LKN-DES-MENSAGEM-WE001
            , :LK-DES-LOG-WE001
            :LKN-DES-LOG-WE001
            , :LK-SEQ-LOG-WE001
            :LKN-SEQ-LOG-WE001
            , :LK-NOM-PARAMETRO-WE001
            :LKN-NOM-PARAMETRO-WE001
            , :LK-NUM-LINHA-WE001
            :LKN-NUM-LINHA-WE001
            , :LK-NOM-CAMPO-WE001
            :LKN-NOM-CAMPO-WE001
            , :LK-NOM-SISTEMA-WE001
            :LKN-NOM-SISTEMA-WE001
            , :LK-IND-ERRO-WE001
            :LKN-IND-ERRO-WE001
            , :LK-MSG-RET-WE001
            :LKN-MSG-RET-WE001
            , :LK-NM-TAB-WE001
            :LKN-NM-TAB-WE001
            , :LK-SQLCODE-WE001
            :LKN-SQLCODE-WE001
            , :LK-SQLERRMC-WE001
            :LKN-SQLERRMC-WE001
            )
            END-EXEC.
            */
            #endregion
            IsProcedure = true;

            var query = @$"GEWES001";

            return query;
        }
        public string LK_COD_SISTEMA_WE001 { get; set; }
        public string LKN_COD_SISTEMA_WE001 { get; set; }
        public string LK_NUM_PROPOSTA_WE001 { get; set; }
        public string LKN_NUM_PROPOSTA_WE001 { get; set; }
        public string LK_NUM_APOLICE_WE001 { get; set; }
        public string LKN_NUM_APOLICE_WE001 { get; set; }
        public string LK_NUM_ENDOSSO_WE001 { get; set; }
        public string LKN_NUM_ENDOSSO_WE001 { get; set; }
        public string LK_COD_CANAL_WE001 { get; set; }
        public string LKN_COD_CANAL_WE001 { get; set; }
        public string LK_NUM_PARCELA_WE001 { get; set; }
        public string LKN_NUM_PARCELA_WE001 { get; set; }
        public string LK_NUM_TOTAL_PARCELAS_WE001 { get; set; }
        public string LKN_NUM_TOTAL_PARCELAS_WE001 { get; set; }
        public string LK_COD_FONTE_WE001 { get; set; }
        public string LKN_COD_FONTE_WE001 { get; set; }
        public string LK_COD_CENTRO_LUCRO_WE001 { get; set; }
        public string LKN_COD_CENTRO_LUCRO_WE001 { get; set; }
        public string LK_NUM_RAMO_SUSEP_WE001 { get; set; }
        public string LKN_NUM_RAMO_SUSEP_WE001 { get; set; }
        public string LK_COD_TIPO_CONVENIO_WE001 { get; set; }
        public string LKN_COD_TIPO_CONVENIO_WE001 { get; set; }
        public string LK_COD_COMPROMISSO_WE001 { get; set; }
        public string LKN_COD_COMPROMISSO_WE001 { get; set; }
        public string LK_NUM_CERTIFICADO_WE001 { get; set; }
        public string LKN_NUM_CERTIFICADO_WE001 { get; set; }
        public string LK_NUM_TITULO_WE001 { get; set; }
        public string LKN_NUM_TITULO_WE001 { get; set; }
        public string LK_NUM_GRUPO_WE001 { get; set; }
        public string LKN_NUM_GRUPO_WE001 { get; set; }
        public string LK_NUM_COTA_WE001 { get; set; }
        public string LKN_NUM_COTA_WE001 { get; set; }
        public string LK_VLR_FUNDO_COMUM_WE001 { get; set; }
        public string LKN_VLR_FUNDO_COMUM_WE001 { get; set; }
        public string LK_VLR_FUNDO_RESERVA_WE001 { get; set; }
        public string LKN_VLR_FUNDO_RESERVA_WE001 { get; set; }
        public string LK_VLR_MULTA_JUROS_WE001 { get; set; }
        public string LKN_VLR_MULTA_JUROS_WE001 { get; set; }
        public string LK_VLR_SEGURO_WE001 { get; set; }
        public string LKN_VLR_SEGURO_WE001 { get; set; }
        public string LK_VLR_TAXA_ADMINISTRAC_WE001 { get; set; }
        public string LKN_VLR_TAXA_ADMINISTRAC_WE001 { get; set; }
        public string LK_VLR_REPASS_MUL_JUROS_WE001 { get; set; }
        public string LKN_VLR_REPASS_MUL_JUROS_WE001 { get; set; }
        public string LK_VLR_BOLETO_WE001 { get; set; }
        public string LKN_VLR_BOLETO_WE001 { get; set; }
        public string LK_QTD_PERMANENCIA_WE001 { get; set; }
        public string LKN_QTD_PERMANENCIA_WE001 { get; set; }
        public string LK_VLR_IOF_WE001 { get; set; }
        public string LKN_VLR_IOF_WE001 { get; set; }
        public string LK_IND_REGISTRA_ONLINE_WE001 { get; set; }
        public string LKN_IND_REGISTRA_ONLINE_WE001 { get; set; }
        public string LK_PCT_MULTA_WE001 { get; set; }
        public string LKN_PCT_MULTA_WE001 { get; set; }
        public string LK_VLR_JUROS_DIA_WE001 { get; set; }
        public string LKN_VLR_JUROS_DIA_WE001 { get; set; }
        public string LK_NOM_PESSOA_WE001 { get; set; }
        public string LKN_NOM_PESSOA_WE001 { get; set; }
        public string LK_NOM_ULTIMO_NOME_WE001 { get; set; }
        public string LKN_NOM_ULTIMO_NOME_WE001 { get; set; }
        public string LK_COD_FORMA_TRATAMENTO_WE001 { get; set; }
        public string LKN_COD_FORMA_TRATAMENTO_WE001 { get; set; }
        public string LK_COD_ENDERECO_WE001 { get; set; }
        public string LKN_COD_ENDERECO_WE001 { get; set; }
        public string LK_NUM_ENDERECO_WE001 { get; set; }
        public string LKN_NUM_ENDERECO_WE001 { get; set; }
        public string LK_DES_ENDERECO_WE001 { get; set; }
        public string LKN_DES_ENDERECO_WE001 { get; set; }
        public string LK_DES_COMPLEMENTO_WE001 { get; set; }
        public string LKN_DES_COMPLEMENTO_WE001 { get; set; }
        public string LK_NOM_BAIRRO_WE001 { get; set; }
        public string LKN_NOM_BAIRRO_WE001 { get; set; }
        public string LK_NOM_CIDADE_WE001 { get; set; }
        public string LKN_NOM_CIDADE_WE001 { get; set; }
        public string LK_COD_UF_WE001 { get; set; }
        public string LKN_COD_UF_WE001 { get; set; }
        public string LK_NUM_CEP_WE001 { get; set; }
        public string LKN_NUM_CEP_WE001 { get; set; }
        public string LK_IND_CONCILIA_SIGPF_WE001 { get; set; }
        public string LKN_IND_CONCILIA_SIGPF_WE001 { get; set; }
        public string LK_COD_EVENTO_WE001 { get; set; }
        public string LKN_COD_EVENTO_WE001 { get; set; }
        public string LK_COD_IDENTIFICADOR_WE001 { get; set; }
        public string LKN_COD_IDENTIFICADOR_WE001 { get; set; }
        public string LK_DTA_DOCUMENTO_WE001 { get; set; }
        public string LKN_DTA_DOCUMENTO_WE001 { get; set; }
        public string LK_DTA_LANCAM_DOCUMENTO_WE001 { get; set; }
        public string LKN_DTA_LANCAM_DOCUMENTO_WE001 { get; set; }
        public string LK_DTA_VENCIMENTO_WE001 { get; set; }
        public string LKN_DTA_VENCIMENTO_WE001 { get; set; }
        public string LK_NUM_CONTA_CONTRATO_WE001 { get; set; }
        public string LKN_NUM_CONTA_CONTRATO_WE001 { get; set; }
        public string LK_NUM_CPF_CNPJ_WE001 { get; set; }
        public string LKN_NUM_CPF_CNPJ_WE001 { get; set; }
        public string LK_COD_RETORNO_WE001 { get; set; }
        public string LKN_COD_RETORNO_WE001 { get; set; }
        public string LK_DES_MENS_SISTEMA_WE001 { get; set; }
        public string LKN_DES_MENS_SISTEMA_WE001 { get; set; }
        public string LK_DES_MENS_AMIGAVE_WE001 { get; set; }
        public string LKN_DES_MENS_AMIGAVE_WE001 { get; set; }
        public string LK_COD_ORIGEM_WE001 { get; set; }
        public string LKN_COD_ORIGEM_WE001 { get; set; }
        public string LK_COD_EMPRESA_WE001 { get; set; }
        public string LKN_COD_EMPRESA_WE001 { get; set; }
        public string LK_NUM_LOTE_WE001 { get; set; }
        public string LKN_NUM_LOTE_WE001 { get; set; }
        public string LK_NUM_DOCUMENTO_WE001 { get; set; }
        public string LKN_NUM_DOCUMENTO_WE001 { get; set; }
        public string LK_NUM_BOLETO_WE001 { get; set; }
        public string LKN_NUM_BOLETO_WE001 { get; set; }
        public string LK_NUM_NOSSO_NUMERO_WE001 { get; set; }
        public string LKN_NUM_NOSSO_NUMERO_WE001 { get; set; }
        public string LK_DES_LINHA_DIGITAVEL_WE001 { get; set; }
        public string LKN_DES_LINHA_DIGITAVEL_WE001 { get; set; }
        public string LK_NUM_AGENCIA_CEDENTE_WE001 { get; set; }
        public string LKN_NUM_AGENCIA_CEDENTE_WE001 { get; set; }
        public string LK_NUM_PARCEIRO_NEGOC_WE001 { get; set; }
        public string LKN_NUM_PARCEIRO_NEGOC_WE001 { get; set; }
        public string LK_VLR_TOTAL_BOLETO_WE001 { get; set; }
        public string LKN_VLR_TOTAL_BOLETO_WE001 { get; set; }
        public string LK_LST_MENSAGENS_CONT_WE001 { get; set; }
        public string LKN_LST_MENSAGENS_CONT_WE001 { get; set; }
        public string LK_COD_TIPO_WE001 { get; set; }
        public string LKN_COD_TIPO_WE001 { get; set; }
        public string LK_COD_MENSAGEM_WE001 { get; set; }
        public string LKN_COD_MENSAGEM_WE001 { get; set; }
        public string LK_NUM_MENSAGEM_WE001 { get; set; }
        public string LKN_NUM_MENSAGEM_WE001 { get; set; }
        public string LK_DES_MENSAGEM_WE001 { get; set; }
        public string LKN_DES_MENSAGEM_WE001 { get; set; }
        public string LK_DES_LOG_WE001 { get; set; }
        public string LKN_DES_LOG_WE001 { get; set; }
        public string LK_SEQ_LOG_WE001 { get; set; }
        public string LKN_SEQ_LOG_WE001 { get; set; }
        public string LK_NOM_PARAMETRO_WE001 { get; set; }
        public string LKN_NOM_PARAMETRO_WE001 { get; set; }
        public string LK_NUM_LINHA_WE001 { get; set; }
        public string LKN_NUM_LINHA_WE001 { get; set; }
        public string LK_NOM_CAMPO_WE001 { get; set; }
        public string LKN_NOM_CAMPO_WE001 { get; set; }
        public string LK_NOM_SISTEMA_WE001 { get; set; }
        public string LKN_NOM_SISTEMA_WE001 { get; set; }
        public string LK_IND_ERRO_WE001 { get; set; }
        public string LKN_IND_ERRO_WE001 { get; set; }
        public string LK_MSG_RET_WE001 { get; set; }
        public string LKN_MSG_RET_WE001 { get; set; }
        public string LK_NM_TAB_WE001 { get; set; }
        public string LKN_NM_TAB_WE001 { get; set; }
        public string LK_SQLCODE_WE001 { get; set; }
        public string LKN_SQLCODE_WE001 { get; set; }
        public string LK_SQLERRMC_WE001 { get; set; }
        public string LKN_SQLERRMC_WE001 { get; set; }

        public static GEWES001_Call1 Execute(GEWES001_Call1 gEWES001_Call1)
        {
            var ths = gEWES001_Call1;
            ths.SetQuery(ths.GetQuery());

            ths.Params = new
            {
                ths.LK_COD_SISTEMA_WE001,
                ths.LKN_COD_SISTEMA_WE001,
                ths.LK_NUM_PROPOSTA_WE001,
                ths.LKN_NUM_PROPOSTA_WE001,
                ths.LK_NUM_APOLICE_WE001,
                ths.LKN_NUM_APOLICE_WE001,
                ths.LK_NUM_ENDOSSO_WE001,
                ths.LKN_NUM_ENDOSSO_WE001,
                ths.LK_COD_CANAL_WE001,
                ths.LKN_COD_CANAL_WE001,
                ths.LK_NUM_PARCELA_WE001,
                ths.LKN_NUM_PARCELA_WE001,
                ths.LK_NUM_TOTAL_PARCELAS_WE001,
                ths.LKN_NUM_TOTAL_PARCELAS_WE001,
                ths.LK_COD_FONTE_WE001,
                ths.LKN_COD_FONTE_WE001,
                ths.LK_COD_CENTRO_LUCRO_WE001,
                ths.LKN_COD_CENTRO_LUCRO_WE001,
                ths.LK_NUM_RAMO_SUSEP_WE001,
                ths.LKN_NUM_RAMO_SUSEP_WE001,
                ths.LK_COD_TIPO_CONVENIO_WE001,
                ths.LKN_COD_TIPO_CONVENIO_WE001,
                ths.LK_COD_COMPROMISSO_WE001,
                ths.LKN_COD_COMPROMISSO_WE001,
                ths.LK_NUM_CERTIFICADO_WE001,
                ths.LKN_NUM_CERTIFICADO_WE001,
                ths.LK_NUM_TITULO_WE001,
                ths.LKN_NUM_TITULO_WE001,
                ths.LK_NUM_GRUPO_WE001,
                ths.LKN_NUM_GRUPO_WE001,
                ths.LK_NUM_COTA_WE001,
                ths.LKN_NUM_COTA_WE001,
                ths.LK_VLR_FUNDO_COMUM_WE001,
                ths.LKN_VLR_FUNDO_COMUM_WE001,
                ths.LK_VLR_FUNDO_RESERVA_WE001,
                ths.LKN_VLR_FUNDO_RESERVA_WE001,
                ths.LK_VLR_MULTA_JUROS_WE001,
                ths.LKN_VLR_MULTA_JUROS_WE001,
                ths.LK_VLR_SEGURO_WE001,
                ths.LKN_VLR_SEGURO_WE001,
                ths.LK_VLR_TAXA_ADMINISTRAC_WE001,
                ths.LKN_VLR_TAXA_ADMINISTRAC_WE001,
                ths.LK_VLR_REPASS_MUL_JUROS_WE001,
                ths.LKN_VLR_REPASS_MUL_JUROS_WE001,
                ths.LK_VLR_BOLETO_WE001,
                ths.LKN_VLR_BOLETO_WE001,
                ths.LK_QTD_PERMANENCIA_WE001,
                ths.LKN_QTD_PERMANENCIA_WE001,
                ths.LK_VLR_IOF_WE001,
                ths.LKN_VLR_IOF_WE001,
                ths.LK_IND_REGISTRA_ONLINE_WE001,
                ths.LKN_IND_REGISTRA_ONLINE_WE001,
                ths.LK_PCT_MULTA_WE001,
                ths.LKN_PCT_MULTA_WE001,
                ths.LK_VLR_JUROS_DIA_WE001,
                ths.LKN_VLR_JUROS_DIA_WE001,
                ths.LK_NOM_PESSOA_WE001,
                ths.LKN_NOM_PESSOA_WE001,
                ths.LK_NOM_ULTIMO_NOME_WE001,
                ths.LKN_NOM_ULTIMO_NOME_WE001,
                ths.LK_COD_FORMA_TRATAMENTO_WE001,
                ths.LKN_COD_FORMA_TRATAMENTO_WE001,
                ths.LK_COD_ENDERECO_WE001,
                ths.LKN_COD_ENDERECO_WE001,
                ths.LK_NUM_ENDERECO_WE001,
                ths.LKN_NUM_ENDERECO_WE001,
                ths.LK_DES_ENDERECO_WE001,
                ths.LKN_DES_ENDERECO_WE001,
                ths.LK_DES_COMPLEMENTO_WE001,
                ths.LKN_DES_COMPLEMENTO_WE001,
                ths.LK_NOM_BAIRRO_WE001,
                ths.LKN_NOM_BAIRRO_WE001,
                ths.LK_NOM_CIDADE_WE001,
                ths.LKN_NOM_CIDADE_WE001,
                ths.LK_COD_UF_WE001,
                ths.LKN_COD_UF_WE001,
                ths.LK_NUM_CEP_WE001,
                ths.LKN_NUM_CEP_WE001,
                ths.LK_IND_CONCILIA_SIGPF_WE001,
                ths.LKN_IND_CONCILIA_SIGPF_WE001,
                ths.LK_COD_EVENTO_WE001,
                ths.LKN_COD_EVENTO_WE001,
                ths.LK_COD_IDENTIFICADOR_WE001,
                ths.LKN_COD_IDENTIFICADOR_WE001,
                ths.LK_DTA_DOCUMENTO_WE001,
                ths.LKN_DTA_DOCUMENTO_WE001,
                ths.LK_DTA_LANCAM_DOCUMENTO_WE001,
                ths.LKN_DTA_LANCAM_DOCUMENTO_WE001,
                ths.LK_DTA_VENCIMENTO_WE001,
                ths.LKN_DTA_VENCIMENTO_WE001,
                ths.LK_NUM_CONTA_CONTRATO_WE001,
                ths.LKN_NUM_CONTA_CONTRATO_WE001,
                ths.LK_NUM_CPF_CNPJ_WE001,
                ths.LKN_NUM_CPF_CNPJ_WE001,
                ths.LK_COD_RETORNO_WE001,
                ths.LKN_COD_RETORNO_WE001,
                ths.LK_DES_MENS_SISTEMA_WE001,
                ths.LKN_DES_MENS_SISTEMA_WE001,
                ths.LK_DES_MENS_AMIGAVE_WE001,
                ths.LKN_DES_MENS_AMIGAVE_WE001,
                ths.LK_COD_ORIGEM_WE001,
                ths.LKN_COD_ORIGEM_WE001,
                ths.LK_COD_EMPRESA_WE001,
                ths.LKN_COD_EMPRESA_WE001,
                ths.LK_NUM_LOTE_WE001,
                ths.LKN_NUM_LOTE_WE001,
                ths.LK_NUM_DOCUMENTO_WE001,
                ths.LKN_NUM_DOCUMENTO_WE001,
                ths.LK_NUM_BOLETO_WE001,
                ths.LKN_NUM_BOLETO_WE001,
                ths.LK_NUM_NOSSO_NUMERO_WE001,
                ths.LKN_NUM_NOSSO_NUMERO_WE001,
                ths.LK_DES_LINHA_DIGITAVEL_WE001,
                ths.LKN_DES_LINHA_DIGITAVEL_WE001,
                ths.LK_NUM_AGENCIA_CEDENTE_WE001,
                ths.LKN_NUM_AGENCIA_CEDENTE_WE001,
                ths.LK_NUM_PARCEIRO_NEGOC_WE001,
                ths.LKN_NUM_PARCEIRO_NEGOC_WE001,
                ths.LK_VLR_TOTAL_BOLETO_WE001,
                ths.LKN_VLR_TOTAL_BOLETO_WE001,
                ths.LK_LST_MENSAGENS_CONT_WE001,
                ths.LKN_LST_MENSAGENS_CONT_WE001,
                ths.LK_COD_TIPO_WE001,
                ths.LKN_COD_TIPO_WE001,
                ths.LK_COD_MENSAGEM_WE001,
                ths.LKN_COD_MENSAGEM_WE001,
                ths.LK_NUM_MENSAGEM_WE001,
                ths.LKN_NUM_MENSAGEM_WE001,
                ths.LK_DES_MENSAGEM_WE001,
                ths.LKN_DES_MENSAGEM_WE001,
                ths.LK_DES_LOG_WE001,
                ths.LKN_DES_LOG_WE001,
                ths.LK_SEQ_LOG_WE001,
                ths.LKN_SEQ_LOG_WE001,
                ths.LK_NOM_PARAMETRO_WE001,
                ths.LKN_NOM_PARAMETRO_WE001,
                ths.LK_NUM_LINHA_WE001,
                ths.LKN_NUM_LINHA_WE001,
                ths.LK_NOM_CAMPO_WE001,
                ths.LKN_NOM_CAMPO_WE001,
                ths.LK_NOM_SISTEMA_WE001,
                ths.LKN_NOM_SISTEMA_WE001,
                ths.LK_IND_ERRO_WE001,
                ths.LKN_IND_ERRO_WE001,
                ths.LK_MSG_RET_WE001,
                ths.LKN_MSG_RET_WE001,
                ths.LK_NM_TAB_WE001,
                ths.LKN_NM_TAB_WE001,
                ths.LK_SQLCODE_WE001,
                ths.LKN_SQLCODE_WE001,
                ths.LK_SQLERRMC_WE001,
                ths.LKN_SQLERRMC_WE001
            };

            ths.Open(ths.Params);
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override GEWES001_Call1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new GEWES001_Call1();
            dta.LK_COD_SISTEMA_WE001 = result[0].Value?.ToString();
            dta.LKN_COD_SISTEMA_WE001 = result[1].Value?.ToString();
            dta.LK_NUM_PROPOSTA_WE001 = result[2].Value?.ToString();
            dta.LKN_NUM_PROPOSTA_WE001 = result[3].Value?.ToString();
            dta.LK_NUM_APOLICE_WE001 = result[4].Value?.ToString();
            dta.LKN_NUM_APOLICE_WE001 = result[5].Value?.ToString();
            dta.LK_NUM_ENDOSSO_WE001 = result[6].Value?.ToString();
            dta.LKN_NUM_ENDOSSO_WE001 = result[7].Value?.ToString();
            dta.LK_COD_CANAL_WE001 = result[8].Value?.ToString();
            dta.LKN_COD_CANAL_WE001 = result[9].Value?.ToString();
            dta.LK_NUM_PARCELA_WE001 = result[10].Value?.ToString();
            dta.LKN_NUM_PARCELA_WE001 = result[11].Value?.ToString();
            dta.LK_NUM_TOTAL_PARCELAS_WE001 = result[12].Value?.ToString();
            dta.LKN_NUM_TOTAL_PARCELAS_WE001 = result[13].Value?.ToString();
            dta.LK_COD_FONTE_WE001 = result[14].Value?.ToString();
            dta.LKN_COD_FONTE_WE001 = result[15].Value?.ToString();
            dta.LK_COD_CENTRO_LUCRO_WE001 = result[16].Value?.ToString();
            dta.LKN_COD_CENTRO_LUCRO_WE001 = result[17].Value?.ToString();
            dta.LK_NUM_RAMO_SUSEP_WE001 = result[18].Value?.ToString();
            dta.LKN_NUM_RAMO_SUSEP_WE001 = result[19].Value?.ToString();
            dta.LK_COD_TIPO_CONVENIO_WE001 = result[20].Value?.ToString();
            dta.LKN_COD_TIPO_CONVENIO_WE001 = result[21].Value?.ToString();
            dta.LK_COD_COMPROMISSO_WE001 = result[22].Value?.ToString();
            dta.LKN_COD_COMPROMISSO_WE001 = result[23].Value?.ToString();
            dta.LK_NUM_CERTIFICADO_WE001 = result[24].Value?.ToString();
            dta.LKN_NUM_CERTIFICADO_WE001 = result[25].Value?.ToString();
            dta.LK_NUM_TITULO_WE001 = result[26].Value?.ToString();
            dta.LKN_NUM_TITULO_WE001 = result[27].Value?.ToString();
            dta.LK_NUM_GRUPO_WE001 = result[28].Value?.ToString();
            dta.LKN_NUM_GRUPO_WE001 = result[29].Value?.ToString();
            dta.LK_NUM_COTA_WE001 = result[30].Value?.ToString();
            dta.LKN_NUM_COTA_WE001 = result[31].Value?.ToString();
            dta.LK_VLR_FUNDO_COMUM_WE001 = result[32].Value?.ToString();
            dta.LKN_VLR_FUNDO_COMUM_WE001 = result[33].Value?.ToString();
            dta.LK_VLR_FUNDO_RESERVA_WE001 = result[34].Value?.ToString();
            dta.LKN_VLR_FUNDO_RESERVA_WE001 = result[35].Value?.ToString();
            dta.LK_VLR_MULTA_JUROS_WE001 = result[36].Value?.ToString();
            dta.LKN_VLR_MULTA_JUROS_WE001 = result[37].Value?.ToString();
            dta.LK_VLR_SEGURO_WE001 = result[38].Value?.ToString();
            dta.LKN_VLR_SEGURO_WE001 = result[39].Value?.ToString();
            dta.LK_VLR_TAXA_ADMINISTRAC_WE001 = result[40].Value?.ToString();
            dta.LKN_VLR_TAXA_ADMINISTRAC_WE001 = result[41].Value?.ToString();
            dta.LK_VLR_REPASS_MUL_JUROS_WE001 = result[42].Value?.ToString();
            dta.LKN_VLR_REPASS_MUL_JUROS_WE001 = result[43].Value?.ToString();
            dta.LK_VLR_BOLETO_WE001 = result[44].Value?.ToString();
            dta.LKN_VLR_BOLETO_WE001 = result[45].Value?.ToString();
            dta.LK_QTD_PERMANENCIA_WE001 = result[46].Value?.ToString();
            dta.LKN_QTD_PERMANENCIA_WE001 = result[47].Value?.ToString();
            dta.LK_VLR_IOF_WE001 = result[48].Value?.ToString();
            dta.LKN_VLR_IOF_WE001 = result[49].Value?.ToString();
            dta.LK_IND_REGISTRA_ONLINE_WE001 = result[50].Value?.ToString();
            dta.LKN_IND_REGISTRA_ONLINE_WE001 = result[51].Value?.ToString();
            dta.LK_PCT_MULTA_WE001 = result[52].Value?.ToString();
            dta.LKN_PCT_MULTA_WE001 = result[53].Value?.ToString();
            dta.LK_VLR_JUROS_DIA_WE001 = result[54].Value?.ToString();
            dta.LKN_VLR_JUROS_DIA_WE001 = result[55].Value?.ToString();
            dta.LK_NOM_PESSOA_WE001 = result[56].Value?.ToString();
            dta.LKN_NOM_PESSOA_WE001 = result[57].Value?.ToString();
            dta.LK_NOM_ULTIMO_NOME_WE001 = result[58].Value?.ToString();
            dta.LKN_NOM_ULTIMO_NOME_WE001 = result[59].Value?.ToString();
            dta.LK_COD_FORMA_TRATAMENTO_WE001 = result[60].Value?.ToString();
            dta.LKN_COD_FORMA_TRATAMENTO_WE001 = result[61].Value?.ToString();
            dta.LK_COD_ENDERECO_WE001 = result[62].Value?.ToString();
            dta.LKN_COD_ENDERECO_WE001 = result[63].Value?.ToString();
            dta.LK_NUM_ENDERECO_WE001 = result[64].Value?.ToString();
            dta.LKN_NUM_ENDERECO_WE001 = result[65].Value?.ToString();
            dta.LK_DES_ENDERECO_WE001 = result[66].Value?.ToString();
            dta.LKN_DES_ENDERECO_WE001 = result[67].Value?.ToString();
            dta.LK_DES_COMPLEMENTO_WE001 = result[68].Value?.ToString();
            dta.LKN_DES_COMPLEMENTO_WE001 = result[69].Value?.ToString();
            dta.LK_NOM_BAIRRO_WE001 = result[70].Value?.ToString();
            dta.LKN_NOM_BAIRRO_WE001 = result[71].Value?.ToString();
            dta.LK_NOM_CIDADE_WE001 = result[72].Value?.ToString();
            dta.LKN_NOM_CIDADE_WE001 = result[73].Value?.ToString();
            dta.LK_COD_UF_WE001 = result[74].Value?.ToString();
            dta.LKN_COD_UF_WE001 = result[75].Value?.ToString();
            dta.LK_NUM_CEP_WE001 = result[76].Value?.ToString();
            dta.LKN_NUM_CEP_WE001 = result[77].Value?.ToString();
            dta.LK_IND_CONCILIA_SIGPF_WE001 = result[78].Value?.ToString();
            dta.LKN_IND_CONCILIA_SIGPF_WE001 = result[79].Value?.ToString();
            dta.LK_COD_EVENTO_WE001 = result[80].Value?.ToString();
            dta.LKN_COD_EVENTO_WE001 = result[81].Value?.ToString();
            dta.LK_COD_IDENTIFICADOR_WE001 = result[82].Value?.ToString();
            dta.LKN_COD_IDENTIFICADOR_WE001 = result[83].Value?.ToString();
            dta.LK_DTA_DOCUMENTO_WE001 = result[84].Value?.ToString();
            dta.LKN_DTA_DOCUMENTO_WE001 = result[85].Value?.ToString();
            dta.LK_DTA_LANCAM_DOCUMENTO_WE001 = result[86].Value?.ToString();
            dta.LKN_DTA_LANCAM_DOCUMENTO_WE001 = result[87].Value?.ToString();
            dta.LK_DTA_VENCIMENTO_WE001 = result[88].Value?.ToString();
            dta.LKN_DTA_VENCIMENTO_WE001 = result[89].Value?.ToString();
            dta.LK_NUM_CONTA_CONTRATO_WE001 = result[90].Value?.ToString();
            dta.LKN_NUM_CONTA_CONTRATO_WE001 = result[91].Value?.ToString();
            dta.LK_NUM_CPF_CNPJ_WE001 = result[92].Value?.ToString();
            dta.LKN_NUM_CPF_CNPJ_WE001 = result[93].Value?.ToString();
            dta.LK_COD_RETORNO_WE001 = result[94].Value?.ToString();
            dta.LKN_COD_RETORNO_WE001 = result[95].Value?.ToString();
            dta.LK_DES_MENS_SISTEMA_WE001 = result[96].Value?.ToString();
            dta.LKN_DES_MENS_SISTEMA_WE001 = result[97].Value?.ToString();
            dta.LK_DES_MENS_AMIGAVE_WE001 = result[98].Value?.ToString();
            dta.LKN_DES_MENS_AMIGAVE_WE001 = result[99].Value?.ToString();
            dta.LK_COD_ORIGEM_WE001 = result[100].Value?.ToString();
            dta.LKN_COD_ORIGEM_WE001 = result[101].Value?.ToString();
            dta.LK_COD_EMPRESA_WE001 = result[102].Value?.ToString();
            dta.LKN_COD_EMPRESA_WE001 = result[103].Value?.ToString();
            dta.LK_NUM_LOTE_WE001 = result[104].Value?.ToString();
            dta.LKN_NUM_LOTE_WE001 = result[105].Value?.ToString();
            dta.LK_NUM_DOCUMENTO_WE001 = result[106].Value?.ToString();
            dta.LKN_NUM_DOCUMENTO_WE001 = result[107].Value?.ToString();
            dta.LK_NUM_BOLETO_WE001 = result[108].Value?.ToString();
            dta.LKN_NUM_BOLETO_WE001 = result[109].Value?.ToString();
            dta.LK_NUM_NOSSO_NUMERO_WE001 = result[110].Value?.ToString();
            dta.LKN_NUM_NOSSO_NUMERO_WE001 = result[111].Value?.ToString();
            dta.LK_DES_LINHA_DIGITAVEL_WE001 = result[112].Value?.ToString();
            dta.LKN_DES_LINHA_DIGITAVEL_WE001 = result[113].Value?.ToString();
            dta.LK_NUM_AGENCIA_CEDENTE_WE001 = result[114].Value?.ToString();
            dta.LKN_NUM_AGENCIA_CEDENTE_WE001 = result[115].Value?.ToString();
            dta.LK_NUM_PARCEIRO_NEGOC_WE001 = result[116].Value?.ToString();
            dta.LKN_NUM_PARCEIRO_NEGOC_WE001 = result[117].Value?.ToString();
            dta.LK_VLR_TOTAL_BOLETO_WE001 = result[118].Value?.ToString();
            dta.LKN_VLR_TOTAL_BOLETO_WE001 = result[119].Value?.ToString();
            dta.LK_LST_MENSAGENS_CONT_WE001 = result[120].Value?.ToString();
            dta.LKN_LST_MENSAGENS_CONT_WE001 = result[121].Value?.ToString();
            dta.LK_COD_TIPO_WE001 = result[122].Value?.ToString();
            dta.LKN_COD_TIPO_WE001 = result[123].Value?.ToString();
            dta.LK_COD_MENSAGEM_WE001 = result[124].Value?.ToString();
            dta.LKN_COD_MENSAGEM_WE001 = result[125].Value?.ToString();
            dta.LK_NUM_MENSAGEM_WE001 = result[126].Value?.ToString();
            dta.LKN_NUM_MENSAGEM_WE001 = result[127].Value?.ToString();
            dta.LK_DES_MENSAGEM_WE001 = result[128].Value?.ToString();
            dta.LKN_DES_MENSAGEM_WE001 = result[129].Value?.ToString();
            dta.LK_DES_LOG_WE001 = result[130].Value?.ToString();
            dta.LKN_DES_LOG_WE001 = result[131].Value?.ToString();
            dta.LK_SEQ_LOG_WE001 = result[132].Value?.ToString();
            dta.LKN_SEQ_LOG_WE001 = result[133].Value?.ToString();
            dta.LK_NOM_PARAMETRO_WE001 = result[134].Value?.ToString();
            dta.LKN_NOM_PARAMETRO_WE001 = result[135].Value?.ToString();
            dta.LK_NUM_LINHA_WE001 = result[136].Value?.ToString();
            dta.LKN_NUM_LINHA_WE001 = result[137].Value?.ToString();
            dta.LK_NOM_CAMPO_WE001 = result[138].Value?.ToString();
            dta.LKN_NOM_CAMPO_WE001 = result[139].Value?.ToString();
            dta.LK_NOM_SISTEMA_WE001 = result[140].Value?.ToString();
            dta.LKN_NOM_SISTEMA_WE001 = result[141].Value?.ToString();
            dta.LK_IND_ERRO_WE001 = result[142].Value?.ToString();
            dta.LKN_IND_ERRO_WE001 = result[143].Value?.ToString();
            dta.LK_MSG_RET_WE001 = result[144].Value?.ToString();
            dta.LKN_MSG_RET_WE001 = result[145].Value?.ToString();
            dta.LK_NM_TAB_WE001 = result[146].Value?.ToString();
            dta.LKN_NM_TAB_WE001 = result[147].Value?.ToString();
            dta.LK_SQLCODE_WE001 = result[148].Value?.ToString();
            dta.LKN_SQLCODE_WE001 = result[149].Value?.ToString();
            dta.LK_SQLERRMC_WE001 = result[150].Value?.ToString();
            dta.LKN_SQLERRMC_WE001 = result[151].Value?.ToString();
            return dta;
        }

    }
}