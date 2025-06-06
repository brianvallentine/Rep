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
    public class GE420_DCLGE_MOVTO_ENVIO_MCP : VarBasis
    {
        /*"    10 GE420-NUM-ID-ENVIO   PIC S9(18) USAGE COMP.*/
        public IntBasis GE420_NUM_ID_ENVIO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE420-SEQ-ID-ENVIO-HIST       PIC S9(4) USAGE COMP.*/
        public IntBasis GE420_SEQ_ID_ENVIO_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE420-STA-ENVIO-MOVIMENTO       PIC X(2).*/
        public StringBasis GE420_STA_ENVIO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE420-COD-EMPRESA-SAP       PIC X(4).*/
        public StringBasis GE420_COD_EMPRESA_SAP { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 GE420-COD-SISTEMA-SAP       PIC X(2).*/
        public StringBasis GE420_COD_SISTEMA_SAP { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE420-COD-EVENTO-SAP       PIC X(10).*/
        public StringBasis GE420_COD_EVENTO_SAP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE420-COD-CHAVE-NEGOCIO       PIC X(40).*/
        public StringBasis GE420_COD_CHAVE_NEGOCIO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE420-COD-USUARIO-LIB       PIC X(8).*/
        public StringBasis GE420_COD_USUARIO_LIB { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE420-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis GE420_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE420-NOM-RAZ-SOCIAL       PIC X(100).*/
        public StringBasis GE420_NOM_RAZ_SOCIAL { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 GE420-IND-TIPO-PESSOA       PIC X(1).*/
        public StringBasis GE420_IND_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE420-IND-SEXO       PIC X(1).*/
        public StringBasis GE420_IND_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE420-NUM-CPF-CNPJ   PIC S9(18) USAGE COMP.*/
        public IntBasis GE420_NUM_CPF_CNPJ { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE420-NUM-CPF-CNPJ-BENEF       PIC S9(18) USAGE COMP.*/
        public IntBasis GE420_NUM_CPF_CNPJ_BENEF { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE420-NOM-LOGRADOURO       PIC X(60).*/
        public StringBasis GE420_NOM_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
        /*"    10 GE420-DES-NUM-RESIDENCIA       PIC X(10).*/
        public StringBasis GE420_DES_NUM_RESIDENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE420-DES-COMPL-ENDERECO       PIC X(10).*/
        public StringBasis GE420_DES_COMPL_ENDERECO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE420-NOM-BAIRRO     PIC X(40).*/
        public StringBasis GE420_NOM_BAIRRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE420-NOM-CIDADE     PIC X(40).*/
        public StringBasis GE420_NOM_CIDADE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE420-COD-UF         PIC X(3).*/
        public StringBasis GE420_COD_UF { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 GE420-COD-CEP        PIC X(10).*/
        public StringBasis GE420_COD_CEP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE420-DES-EMAIL      PIC X(241).*/
        public StringBasis GE420_DES_EMAIL { get; set; } = new StringBasis(new PIC("X", "241", "X(241)."), @"");
        /*"    10 GE420-NUM-TELEFONE   PIC S9(9) USAGE COMP.*/
        public IntBasis GE420_NUM_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE420-DES-FAX        PIC X(30).*/
        public StringBasis GE420_DES_FAX { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 GE420-NUM-INSC-MUNICIPAL       PIC X(20).*/
        public StringBasis GE420_NUM_INSC_MUNICIPAL { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 GE420-NUM-INSC-ESTADUAL       PIC X(20).*/
        public StringBasis GE420_NUM_INSC_ESTADUAL { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 GE420-IND-OPT-SIMPLES-FEDERAL       PIC X(3).*/
        public StringBasis GE420_IND_OPT_SIMPLES_FEDERAL { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 GE420-COD-CONVENIO   PIC S9(9) USAGE COMP.*/
        public IntBasis GE420_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE420-IND-TP-CONVENIO       PIC X(1).*/
        public StringBasis GE420_IND_TP_CONVENIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE420-IND-FORMA-PAG-COB       PIC X(1).*/
        public StringBasis GE420_IND_FORMA_PAG_COB { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE420-TXT-EMPRESA.*/
        public GE420_GE420_TXT_EMPRESA GE420_TXT_EMPRESA { get; set; } = new GE420_GE420_TXT_EMPRESA();

        public StringBasis GE420_COD_DOC_SIACC { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 GE420-DTA-SOL-PAGTO  PIC X(10).*/
        public StringBasis GE420_DTA_SOL_PAGTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE420-COD-BANCO      PIC S9(4) USAGE COMP.*/
        public IntBasis GE420_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE420-COD-AGENCIA    PIC S9(4) USAGE COMP.*/
        public IntBasis GE420_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE420-NUM-DV-AGENCIA       PIC X(2).*/
        public StringBasis GE420_NUM_DV_AGENCIA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE420-NUM-OPERACAO-CONTA       PIC S9(4) USAGE COMP.*/
        public IntBasis GE420_NUM_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE420-NUM-CC         PIC S9(18) USAGE COMP.*/
        public IntBasis GE420_NUM_CC { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE420-NUM-DV-CONTA   PIC X(2).*/
        public StringBasis GE420_NUM_DV_CONTA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE420-VLR-PAGTO      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE420_VLR_PAGTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE420-VLR-ATU-MONETARIA       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE420_VLR_ATU_MONETARIA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE420-VLR-ATU-JUROS  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE420_VLR_ATU_JUROS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE420-COD-CONGENERE  PIC S9(4) USAGE COMP.*/
        public IntBasis GE420_COD_CONGENERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE420-COD-FONTE-SIAS       PIC S9(4) USAGE COMP.*/
        public IntBasis GE420_COD_FONTE_SIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE420-COD-RAMO-SUSEP       PIC S9(4) USAGE COMP.*/
        public IntBasis GE420_COD_RAMO_SUSEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE420-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis GE420_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE420-NUM-APOLICE    PIC S9(18) USAGE COMP.*/
        public IntBasis GE420_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE420-NUM-SINISTRO   PIC S9(18) USAGE COMP.*/
        public IntBasis GE420_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE420-COD-OPERACAO   PIC S9(4) USAGE COMP.*/
        public IntBasis GE420_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE420-NUM-OCORR-HISTORICO       PIC S9(4) USAGE COMP.*/
        public IntBasis GE420_NUM_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE420-DTA-AVISO      PIC X(10).*/
        public StringBasis GE420_DTA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE420-DTA-COMUNICACAO       PIC X(10).*/
        public StringBasis GE420_DTA_COMUNICACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE420-DTA-SENTENCA-JUDICIAL       PIC X(10).*/
        public StringBasis GE420_DTA_SENTENCA_JUDICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE420-DTA-COMUNIC-SENTEN       PIC X(10).*/
        public StringBasis GE420_DTA_COMUNIC_SENTEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE420-COD-PROCES-JURID       PIC X(30).*/
        public StringBasis GE420_COD_PROCES_JURID { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 GE420-COD-SERVICO-SAP       PIC S9(4) USAGE COMP.*/
        public IntBasis GE420_COD_SERVICO_SAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE420-COD-FONTE-ISS  PIC S9(4) USAGE COMP.*/
        public IntBasis GE420_COD_FONTE_ISS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE420-NUM-DOC-FISCAL       PIC X(30).*/
        public StringBasis GE420_NUM_DOC_FISCAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 GE420-NUM-SERIE-DOC-FISCAL       PIC X(30).*/
        public StringBasis GE420_NUM_SERIE_DOC_FISCAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 GE420-COD-AGRUPADOR  PIC X(30).*/
        public StringBasis GE420_COD_AGRUPADOR { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 GE420-NUM-CPF-CNPJ-TOMADOR       PIC S9(18) USAGE COMP.*/
        public IntBasis GE420_NUM_CPF_CNPJ_TOMADOR { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE420-COD-INDICATIVO-OBRA       PIC S9(4) USAGE COMP.*/
        public IntBasis GE420_COD_INDICATIVO_OBRA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE420-COD-NACIONAL-OBRA       PIC S9(18) USAGE COMP.*/
        public IntBasis GE420_COD_NACIONAL_OBRA { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE420-DTA-NOTA-FISCAL       PIC X(10).*/
        public StringBasis GE420_DTA_NOTA_FISCAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE420-COD-CNAE-CPRB  PIC X(8).*/
        public StringBasis GE420_COD_CNAE_CPRB { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE420-COD-PROCESSO-JUD       PIC X(21).*/
        public StringBasis GE420_COD_PROCESSO_JUD { get; set; } = new StringBasis(new PIC("X", "21", "X(21)."), @"");
        /*"    10 GE420-COD-TP-SERVICO-INSS       PIC X(9).*/
        public StringBasis GE420_COD_TP_SERVICO_INSS { get; set; } = new StringBasis(new PIC("X", "9", "X(9)."), @"");
        /*"    10 GE420-VLR-DEDUCAO-MEAT       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE420_VLR_DEDUCAO_MEAT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE420-VLR-RET-NOTA-FISC       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE420_VLR_RET_NOTA_FISC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE420-VLR-RET-PRINCIPAL       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE420_VLR_RET_PRINCIPAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE420-COD-IMPOSTO-LIMINAR       PIC X(2).*/
        public StringBasis GE420_COD_IMPOSTO_LIMINAR { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE420-NUM-PROPOSTA   PIC S9(18) USAGE COMP.*/
        public IntBasis GE420_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE420-NUM-CERTIFICADO       PIC S9(18) USAGE COMP.*/
        public IntBasis GE420_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE420-NUM-ENDOSSO    PIC S9(9) USAGE COMP.*/
        public IntBasis GE420_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE420-NUM-PARCELA    PIC S9(4) USAGE COMP.*/
        public IntBasis GE420_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE420-NUM-NIT-INSS   PIC X(60).*/
        public StringBasis GE420_NUM_NIT_INSS { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
        /*"    10 GE420-COD-CANAL-VENDA       PIC S9(4) USAGE COMP.*/
        public IntBasis GE420_COD_CANAL_VENDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE420-NUM-TITULO     PIC S9(18) USAGE COMP.*/
        public IntBasis GE420_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE420-COD-CEDENTE    PIC S9(18) USAGE COMP.*/
        public IntBasis GE420_COD_CEDENTE { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE420-COD-COMPROMISSO       PIC S9(4) USAGE COMP.*/
        public IntBasis GE420_COD_COMPROMISSO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE420-TXT-INFO-CART-CRED       PIC X(10).*/
        public StringBasis GE420_TXT_INFO_CART_CRED { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE420-QTD-PARCELA    PIC S9(4) USAGE COMP.*/
        public IntBasis GE420_QTD_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE420-NUM-IDLG-MCP   PIC S9(18) USAGE COMP.*/
        public IntBasis GE420_NUM_IDLG_MCP { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE420-NUM-IDLG-SAP   PIC X(40).*/
        public StringBasis GE420_NUM_IDLG_SAP { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE420-DTA-ENVIO-MCP  PIC X(10).*/
        public StringBasis GE420_DTA_ENVIO_MCP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE420-DTA-RETORNO-SAP-ARQG       PIC X(10).*/
        public StringBasis GE420_DTA_RETORNO_SAP_ARQG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE420-DTA-RETORNO-SAP-ARQH       PIC X(10).*/
        public StringBasis GE420_DTA_RETORNO_SAP_ARQH { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE420-DTA-EFETIVO-PGTO-COB       PIC X(10).*/
        public StringBasis GE420_DTA_EFETIVO_PGTO_COB { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE420-COD-MODULO-SAP       PIC X(2).*/
        public StringBasis GE420_COD_MODULO_SAP { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE420-NOM-PROG-GRAVOU       PIC X(10).*/
        public StringBasis GE420_NOM_PROG_GRAVOU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE420-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE420_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}