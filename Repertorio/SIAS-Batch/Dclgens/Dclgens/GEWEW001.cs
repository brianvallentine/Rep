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
    public class GEWEW001 : VarBasis
    {
        /*"01 LK-COD-SISTEMA-WE001              PIC X(010)*/
        public StringBasis LK_COD_SISTEMA_WE001 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01 LK-NUM-PROPOSTA-WE001             PIC S9(018) COMP*/
        public IntBasis LK_NUM_PROPOSTA_WE001 { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"01 LK-NUM-APOLICE-WE001              PIC S9(018) COMP*/
        public IntBasis LK_NUM_APOLICE_WE001 { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"01 LK-NUM-ENDOSSO-WE001              PIC S9(018) COMP*/
        public IntBasis LK_NUM_ENDOSSO_WE001 { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"01 LK-COD-CANAL-WE001                PIC S9(009) COMP*/
        public IntBasis LK_COD_CANAL_WE001 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01 LK-NUM-PARCELA-WE001              PIC S9(009) COMP*/
        public IntBasis LK_NUM_PARCELA_WE001 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01 LK-NUM-TOTAL-PARCELAS-WE001       PIC S9(009) COMP*/
        public IntBasis LK_NUM_TOTAL_PARCELAS_WE001 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01 LK-COD-FONTE-WE001                PIC S9(009) COMP*/
        public IntBasis LK_COD_FONTE_WE001 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01 LK-COD-CENTRO-LUCRO-WE001         PIC X(008)*/
        public StringBasis LK_COD_CENTRO_LUCRO_WE001 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01 LK-NUM-RAMO-SUSEP-WE001           PIC S9(009) COMP*/
        public IntBasis LK_NUM_RAMO_SUSEP_WE001 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01 LK-COD-TIPO-CONVENIO-WE001        PIC X(001)*/
        public StringBasis LK_COD_TIPO_CONVENIO_WE001 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01 LK-COD-COMPROMISSO-WE001          PIC S9(009) COMP*/
        public IntBasis LK_COD_COMPROMISSO_WE001 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01 LK-NUM-CERTIFICADO-WE001          PIC S9(018) COMP*/
        public IntBasis LK_NUM_CERTIFICADO_WE001 { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"01 LK-NUM-TITULO-WE001               PIC S9(018) COMP*/
        public IntBasis LK_NUM_TITULO_WE001 { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"01 LK-NUM-GRUPO-WE001                PIC S9(018) COMP*/
        public IntBasis LK_NUM_GRUPO_WE001 { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"01 LK-NUM-COTA-WE001                 PIC S9(018) COMP*/
        public IntBasis LK_NUM_COTA_WE001 { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"01 LK-VLR-FUNDO-COMUM-WE001          PIC S9(15)V9(3) COMP-3*/
        public DoubleBasis LK_VLR_FUNDO_COMUM_WE001 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(3)"), 3);
        /*"01 LK-VLR-FUNDO-RESERVA-WE001        PIC S9(15)V9(3) COMP-3*/
        public DoubleBasis LK_VLR_FUNDO_RESERVA_WE001 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(3)"), 3);
        /*"01 LK-VLR-MULTA-JUROS-WE001          PIC S9(15)V9(3) COMP-3*/
        public DoubleBasis LK_VLR_MULTA_JUROS_WE001 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(3)"), 3);
        /*"01 LK-VLR-SEGURO-WE001               PIC S9(15)V9(3) COMP-3*/
        public DoubleBasis LK_VLR_SEGURO_WE001 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(3)"), 3);
        /*"01 LK-VLR-TAXA-ADMINISTRAC-WE001     PIC S9(15)V9(3) COMP-3*/
        public DoubleBasis LK_VLR_TAXA_ADMINISTRAC_WE001 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(3)"), 3);
        /*"01 LK-VLR-REPASS-MUL-JUROS-WE001     PIC S9(15)V9(3) COMP-3*/
        public DoubleBasis LK_VLR_REPASS_MUL_JUROS_WE001 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(3)"), 3);
        /*"01 LK-VLR-BOLETO-WE001               PIC S9(15)V9(3) COMP-3*/
        public DoubleBasis LK_VLR_BOLETO_WE001 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(3)"), 3);
        /*"01 LK-QTD-PERMANENCIA-WE001          PIC S9(018) COMP*/
        public IntBasis LK_QTD_PERMANENCIA_WE001 { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"01 LK-VLR-IOF-WE001                  PIC S9(15)V9(3) COMP-3*/
        public DoubleBasis LK_VLR_IOF_WE001 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(3)"), 3);
        /*"01 LK-IND-REGISTRA-ONLINE-WE001      PIC X(001)*/
        public StringBasis LK_IND_REGISTRA_ONLINE_WE001 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01 LK-PCT-MULTA-WE001                PIC S9(15)V9(3) COMP-3*/
        public DoubleBasis LK_PCT_MULTA_WE001 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(3)"), 3);
        /*"01 LK-VLR-JUROS-DIA-WE001            PIC S9(15)V9(3) COMP-3*/
        public DoubleBasis LK_VLR_JUROS_DIA_WE001 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(3)"), 3);
        /*"01 LK-NOM-PESSOA-WE001               PIC X(040)*/
        public StringBasis LK_NOM_PESSOA_WE001 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"01 LK-NOM-ULTIMO-NOME-WE001          PIC X(040)*/
        public StringBasis LK_NOM_ULTIMO_NOME_WE001 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"01 LK-COD-FORMA-TRATAMENTO-WE001     PIC X(004)*/
        public StringBasis LK_COD_FORMA_TRATAMENTO_WE001 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
        /*"01 LK-COD-ENDERECO-WE001             PIC X(040)*/
        public StringBasis LK_COD_ENDERECO_WE001 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"01 LK-NUM-ENDERECO-WE001             PIC S9(018) COMP*/
        public IntBasis LK_NUM_ENDERECO_WE001 { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"01 LK-DES-ENDERECO-WE001             PIC X(060)*/
        public StringBasis LK_DES_ENDERECO_WE001 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
        /*"01 LK-DES-COMPLEMENTO-WE001          PIC X(010)*/
        public StringBasis LK_DES_COMPLEMENTO_WE001 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01 LK-NOM-BAIRRO-WE001               PIC X(040)*/
        public StringBasis LK_NOM_BAIRRO_WE001 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"01 LK-NOM-CIDADE-WE001               PIC X(040)*/
        public StringBasis LK_NOM_CIDADE_WE001 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"01 LK-COD-UF-WE001                   PIC X(002)*/
        public StringBasis LK_COD_UF_WE001 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"01 LK-NUM-CEP-WE001                  PIC X(010)*/
        public StringBasis LK_NUM_CEP_WE001 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01 LK-IND-CONCILIA-SIGPF-WE001       PIC X(001)*/
        public StringBasis LK_IND_CONCILIA_SIGPF_WE001 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01 LK-COD-EVENTO-WE001               PIC X(010)*/
        public StringBasis LK_COD_EVENTO_WE001 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01 LK-COD-IDENTIFICADOR-WE001        PIC X(040)*/
        public StringBasis LK_COD_IDENTIFICADOR_WE001 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"01 LK-DTA-DOCUMENTO-WE001            PIC X(010)*/
        public StringBasis LK_DTA_DOCUMENTO_WE001 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01 LK-DTA-LANCAM-DOCUMENTO-WE001     PIC X(010)*/
        public StringBasis LK_DTA_LANCAM_DOCUMENTO_WE001 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01 LK-DTA-VENCIMENTO-WE001           PIC X(010)*/
        public StringBasis LK_DTA_VENCIMENTO_WE001 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01 LK-NUM-CONTA-CONTRATO-WE001       PIC X(025)*/
        public StringBasis LK_NUM_CONTA_CONTRATO_WE001 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
        /*"01 LK-NUM-CPF-CNPJ-WE001             PIC X(014)*/
        public StringBasis LK_NUM_CPF_CNPJ_WE001 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
        /*"01 LK-COD-RETORNO-WE001              PIC X(002)*/
        public StringBasis LK_COD_RETORNO_WE001 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"01 LK-DES-MENS-SISTEMA-WE001*/
        public GEWEW001_LK_DES_MENS_SISTEMA_WE001 LK_DES_MENS_SISTEMA_WE001 { get; set; } = new GEWEW001_LK_DES_MENS_SISTEMA_WE001();

        public GEWEW001_LK_DES_MENS_AMIGAVE_WE001 LK_DES_MENS_AMIGAVE_WE001 { get; set; } = new GEWEW001_LK_DES_MENS_AMIGAVE_WE001();

        public StringBasis LK_COD_ORIGEM_WE001 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
        /*"01 LK-COD-EMPRESA-WE001              PIC X(004)*/
        public StringBasis LK_COD_EMPRESA_WE001 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
        /*"01 LK-NUM-LOTE-WE001                 PIC X(024)*/
        public StringBasis LK_NUM_LOTE_WE001 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
        /*"01 LK-NUM-DOCUMENTO-WE001            PIC X(012)*/
        public StringBasis LK_NUM_DOCUMENTO_WE001 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
        /*"01 LK-NUM-BOLETO-WE001               PIC X(010)*/
        public StringBasis LK_NUM_BOLETO_WE001 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01 LK-NUM-NOSSO-NUMERO-WE001         PIC X(020)*/
        public StringBasis LK_NUM_NOSSO_NUMERO_WE001 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
        /*"01 LK-DES-LINHA-DIGITAVEL-WE001      PIC X(060)*/
        public StringBasis LK_DES_LINHA_DIGITAVEL_WE001 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
        /*"01 LK-NUM-AGENCIA-CEDENTE-WE001      PIC X(020)*/
        public StringBasis LK_NUM_AGENCIA_CEDENTE_WE001 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
        /*"01 LK-NUM-PARCEIRO-NEGOC-WE001       PIC X(010)*/
        public StringBasis LK_NUM_PARCEIRO_NEGOC_WE001 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01 LK-VLR-TOTAL-BOLETO-WE001         PIC S9(15)V9(3) COMP-3*/
        public DoubleBasis LK_VLR_TOTAL_BOLETO_WE001 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(3)"), 3);
        /*"01 LK-LST-MENSAGENS-CONT-WE001       PIC X(016)*/
        public StringBasis LK_LST_MENSAGENS_CONT_WE001 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"");
        /*"01 LK-COD-TIPO-WE001*/
        public GEWEW001_LK_COD_TIPO_WE001 LK_COD_TIPO_WE001 { get; set; } = new GEWEW001_LK_COD_TIPO_WE001();

        public GEWEW001_LK_COD_MENSAGEM_WE001 LK_COD_MENSAGEM_WE001 { get; set; } = new GEWEW001_LK_COD_MENSAGEM_WE001();

        public IntBasis LK_NUM_MENSAGEM_WE001 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01 LK-DES-MENSAGEM-WE001*/
        public GEWEW001_LK_DES_MENSAGEM_WE001 LK_DES_MENSAGEM_WE001 { get; set; } = new GEWEW001_LK_DES_MENSAGEM_WE001();

        public GEWEW001_LK_DES_LOG_WE001 LK_DES_LOG_WE001 { get; set; } = new GEWEW001_LK_DES_LOG_WE001();

        public IntBasis LK_SEQ_LOG_WE001 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01 LK-NOM-PARAMETRO-WE001*/
        public GEWEW001_LK_NOM_PARAMETRO_WE001 LK_NOM_PARAMETRO_WE001 { get; set; } = new GEWEW001_LK_NOM_PARAMETRO_WE001();

        public IntBasis LK_NUM_LINHA_WE001 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01 LK-NOM-CAMPO-WE001*/
        public GEWEW001_LK_NOM_CAMPO_WE001 LK_NOM_CAMPO_WE001 { get; set; } = new GEWEW001_LK_NOM_CAMPO_WE001();

        public GEWEW001_LK_NOM_SISTEMA_WE001 LK_NOM_SISTEMA_WE001 { get; set; } = new GEWEW001_LK_NOM_SISTEMA_WE001();

        public IntBasis LK_IND_ERRO_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01 LK-MSG-RET-WE001                  PIC X(133)*/
        public StringBasis LK_MSG_RET_WE001 { get; set; } = new StringBasis(new PIC("X", "133", "X(133)"), @"");
        /*"01 LK-NM-TAB-WE001                   PIC X(030)*/
        public StringBasis LK_NM_TAB_WE001 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"01 LK-SQLCODE-WE001                  PIC S9(009) COMP*/
        public IntBasis LK_SQLCODE_WE001 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01 LK-SQLERRMC-WE001                 PIC X(070)*/
        public StringBasis LK_SQLERRMC_WE001 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*"01 LKN-VALORES-NULOS-WE001*/
        public GEWEW001_LKN_VALORES_NULOS_WE001 LKN_VALORES_NULOS_WE001 { get; set; } = new GEWEW001_LKN_VALORES_NULOS_WE001();

    }
}