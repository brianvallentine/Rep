using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class GEWEW001_LKN_VALORES_NULOS_WE001 : VarBasis
    {
        /*"   05 LKN-COD-SISTEMA-WE001          PIC S9(004) COMP*/
        public IntBasis LKN_COD_SISTEMA_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NUM-PROPOSTA-WE001         PIC S9(004) COMP*/
        public IntBasis LKN_NUM_PROPOSTA_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NUM-APOLICE-WE001          PIC S9(004) COMP*/
        public IntBasis LKN_NUM_APOLICE_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NUM-ENDOSSO-WE001          PIC S9(004) COMP*/
        public IntBasis LKN_NUM_ENDOSSO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-COD-CANAL-WE001            PIC S9(004) COMP*/
        public IntBasis LKN_COD_CANAL_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NUM-PARCELA-WE001          PIC S9(004) COMP*/
        public IntBasis LKN_NUM_PARCELA_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NUM-TOTAL-PARCELAS-WE001   PIC S9(004) COMP*/
        public IntBasis LKN_NUM_TOTAL_PARCELAS_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-COD-FONTE-WE001            PIC S9(004) COMP*/
        public IntBasis LKN_COD_FONTE_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-COD-CENTRO-LUCRO-WE001     PIC S9(004) COMP*/
        public IntBasis LKN_COD_CENTRO_LUCRO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NUM-RAMO-SUSEP-WE001       PIC S9(004) COMP*/
        public IntBasis LKN_NUM_RAMO_SUSEP_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-COD-TIPO-CONVENIO-WE001    PIC S9(004) COMP*/
        public IntBasis LKN_COD_TIPO_CONVENIO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-COD-COMPROMISSO-WE001      PIC S9(004) COMP*/
        public IntBasis LKN_COD_COMPROMISSO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NUM-CERTIFICADO-WE001      PIC S9(004) COMP*/
        public IntBasis LKN_NUM_CERTIFICADO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NUM-TITULO-WE001           PIC S9(004) COMP*/
        public IntBasis LKN_NUM_TITULO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NUM-GRUPO-WE001            PIC S9(004) COMP*/
        public IntBasis LKN_NUM_GRUPO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NUM-COTA-WE001             PIC S9(004) COMP*/
        public IntBasis LKN_NUM_COTA_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-VLR-FUNDO-COMUM-WE001      PIC S9(004) COMP*/
        public IntBasis LKN_VLR_FUNDO_COMUM_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-VLR-FUNDO-RESERVA-WE001    PIC S9(004) COMP*/
        public IntBasis LKN_VLR_FUNDO_RESERVA_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-VLR-MULTA-JUROS-WE001      PIC S9(004) COMP*/
        public IntBasis LKN_VLR_MULTA_JUROS_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-VLR-SEGURO-WE001           PIC S9(004) COMP*/
        public IntBasis LKN_VLR_SEGURO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-VLR-TAXA-ADMINISTRAC-WE001 PIC S9(004) COMP*/
        public IntBasis LKN_VLR_TAXA_ADMINISTRAC_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-VLR-REPASS-MUL-JUROS-WE001 PIC S9(004) COMP*/
        public IntBasis LKN_VLR_REPASS_MUL_JUROS_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-VLR-BOLETO-WE001           PIC S9(004) COMP*/
        public IntBasis LKN_VLR_BOLETO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-QTD-PERMANENCIA-WE001      PIC S9(004) COMP*/
        public IntBasis LKN_QTD_PERMANENCIA_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-VLR-IOF-WE001              PIC S9(004) COMP*/
        public IntBasis LKN_VLR_IOF_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-IND-REGISTRA-ONLINE-WE001  PIC S9(004) COMP*/
        public IntBasis LKN_IND_REGISTRA_ONLINE_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-PCT-MULTA-WE001            PIC S9(004) COMP*/
        public IntBasis LKN_PCT_MULTA_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-VLR-JUROS-DIA-WE001        PIC S9(004) COMP*/
        public IntBasis LKN_VLR_JUROS_DIA_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NOM-PESSOA-WE001           PIC S9(004) COMP*/
        public IntBasis LKN_NOM_PESSOA_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NOM-ULTIMO-NOME-WE001      PIC S9(004) COMP*/
        public IntBasis LKN_NOM_ULTIMO_NOME_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-COD-FORMA-TRATAMENTO-WE001 PIC S9(004) COMP*/
        public IntBasis LKN_COD_FORMA_TRATAMENTO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-COD-ENDERECO-WE001         PIC S9(004) COMP*/
        public IntBasis LKN_COD_ENDERECO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NUM-ENDERECO-WE001         PIC S9(004) COMP*/
        public IntBasis LKN_NUM_ENDERECO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-DES-ENDERECO-WE001         PIC S9(004) COMP*/
        public IntBasis LKN_DES_ENDERECO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-DES-COMPLEMENTO-WE001      PIC S9(004) COMP*/
        public IntBasis LKN_DES_COMPLEMENTO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NOM-BAIRRO-WE001           PIC S9(004) COMP*/
        public IntBasis LKN_NOM_BAIRRO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NOM-CIDADE-WE001           PIC S9(004) COMP*/
        public IntBasis LKN_NOM_CIDADE_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-COD-UF-WE001               PIC S9(004) COMP*/
        public IntBasis LKN_COD_UF_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NUM-CEP-WE001              PIC S9(004) COMP*/
        public IntBasis LKN_NUM_CEP_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-IND-CONCILIA-SIGPF-WE001   PIC S9(004) COMP*/
        public IntBasis LKN_IND_CONCILIA_SIGPF_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-COD-EVENTO-WE001           PIC S9(004) COMP*/
        public IntBasis LKN_COD_EVENTO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-COD-IDENTIFICADOR-WE001    PIC S9(004) COMP*/
        public IntBasis LKN_COD_IDENTIFICADOR_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-DTA-DOCUMENTO-WE001        PIC S9(004) COMP*/
        public IntBasis LKN_DTA_DOCUMENTO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-DTA-LANCAM-DOCUMENTO-WE001 PIC S9(004) COMP*/
        public IntBasis LKN_DTA_LANCAM_DOCUMENTO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-DTA-VENCIMENTO-WE001       PIC S9(004) COMP*/
        public IntBasis LKN_DTA_VENCIMENTO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NUM-CONTA-CONTRATO-WE001   PIC S9(004) COMP*/
        public IntBasis LKN_NUM_CONTA_CONTRATO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NUM-CPF-CNPJ-WE001         PIC S9(004) COMP*/
        public IntBasis LKN_NUM_CPF_CNPJ_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-COD-RETORNO-WE001          PIC S9(004) COMP*/
        public IntBasis LKN_COD_RETORNO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-DES-MENS-SISTEMA-WE001     PIC S9(004) COMP*/
        public IntBasis LKN_DES_MENS_SISTEMA_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-DES-MENS-AMIGAVE-WE001     PIC S9(004) COMP*/
        public IntBasis LKN_DES_MENS_AMIGAVE_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-COD-ORIGEM-WE001           PIC S9(004) COMP*/
        public IntBasis LKN_COD_ORIGEM_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-COD-EMPRESA-WE001          PIC S9(004) COMP*/
        public IntBasis LKN_COD_EMPRESA_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NUM-LOTE-WE001             PIC S9(004) COMP*/
        public IntBasis LKN_NUM_LOTE_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NUM-DOCUMENTO-WE001        PIC S9(004) COMP*/
        public IntBasis LKN_NUM_DOCUMENTO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NUM-BOLETO-WE001           PIC S9(004) COMP*/
        public IntBasis LKN_NUM_BOLETO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NUM-NOSSO-NUMERO-WE001     PIC S9(004) COMP*/
        public IntBasis LKN_NUM_NOSSO_NUMERO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-DES-LINHA-DIGITAVEL-WE001  PIC S9(004) COMP*/
        public IntBasis LKN_DES_LINHA_DIGITAVEL_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NUM-AGENCIA-CEDENTE-WE001  PIC S9(004) COMP*/
        public IntBasis LKN_NUM_AGENCIA_CEDENTE_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NUM-PARCEIRO-NEGOC-WE001   PIC S9(004) COMP*/
        public IntBasis LKN_NUM_PARCEIRO_NEGOC_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-VLR-TOTAL-BOLETO-WE001     PIC S9(004) COMP*/
        public IntBasis LKN_VLR_TOTAL_BOLETO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-LST-MENSAGENS-CONT-WE001   PIC S9(004) COMP*/
        public IntBasis LKN_LST_MENSAGENS_CONT_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-COD-TIPO-WE001             PIC S9(004) COMP*/
        public IntBasis LKN_COD_TIPO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-COD-MENSAGEM-WE001         PIC S9(004) COMP*/
        public IntBasis LKN_COD_MENSAGEM_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NUM-MENSAGEM-WE001         PIC S9(004) COMP*/
        public IntBasis LKN_NUM_MENSAGEM_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-DES-MENSAGEM-WE001         PIC S9(004) COMP*/
        public IntBasis LKN_DES_MENSAGEM_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-DES-LOG-WE001              PIC S9(004) COMP*/
        public IntBasis LKN_DES_LOG_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-SEQ-LOG-WE001              PIC S9(004) COMP*/
        public IntBasis LKN_SEQ_LOG_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NOM-PARAMETRO-WE001        PIC S9(004) COMP*/
        public IntBasis LKN_NOM_PARAMETRO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NUM-LINHA-WE001            PIC S9(004) COMP*/
        public IntBasis LKN_NUM_LINHA_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NOM-CAMPO-WE001            PIC S9(004) COMP*/
        public IntBasis LKN_NOM_CAMPO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NOM-SISTEMA-WE001          PIC S9(004) COMP*/
        public IntBasis LKN_NOM_SISTEMA_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-IND-ERRO-WE001             PIC S9(004) COMP*/
        public IntBasis LKN_IND_ERRO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-MSG-RET-WE001              PIC S9(004) COMP*/
        public IntBasis LKN_MSG_RET_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-NM-TAB-WE001               PIC S9(004) COMP*/
        public IntBasis LKN_NM_TAB_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-SQLCODE-WE001              PIC S9(004) COMP*/
        public IntBasis LKN_SQLCODE_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   05 LKN-SQLERRMC-WE001             PIC S9(004) COMP*/
        public IntBasis LKN_SQLERRMC_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
    }
}