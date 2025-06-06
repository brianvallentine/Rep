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
    public class SIARDEVC_DCLSI_AR_DETALHE_VC : VarBasis
    {
        /*"    10 SIARDEVC-NOM-ARQUIVO       PIC X(8).*/
        public StringBasis SIARDEVC_NOM_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SIARDEVC-SEQ-GERACAO       PIC S9(9) USAGE COMP.*/
        public IntBasis SIARDEVC_SEQ_GERACAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIARDEVC-TIPO-REGISTRO       PIC X(1).*/
        public StringBasis SIARDEVC_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIARDEVC-SEQ-REGISTRO       PIC S9(9) USAGE COMP.*/
        public IntBasis SIARDEVC_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIARDEVC-COD-OPERACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis SIARDEVC_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIARDEVC-OCORR-HISTORICO       PIC S9(4) USAGE COMP.*/
        public IntBasis SIARDEVC_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIARDEVC-NUM-SINISTRO-VC       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_NUM_SINISTRO_VC { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SIARDEVC-NUM-EXPEDIENTE-VC       PIC S9(4) USAGE COMP.*/
        public IntBasis SIARDEVC_NUM_EXPEDIENTE_VC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIARDEVC-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SIARDEVC-NUM-ENDOSSO       PIC S9(9) USAGE COMP.*/
        public IntBasis SIARDEVC_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIARDEVC-NUM-ITEM    PIC S9(9) USAGE COMP.*/
        public IntBasis SIARDEVC_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIARDEVC-COD-RAMO    PIC S9(4) USAGE COMP.*/
        public IntBasis SIARDEVC_COD_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIARDEVC-COD-COBERTURA       PIC S9(4) USAGE COMP.*/
        public IntBasis SIARDEVC_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIARDEVC-COD-CAUSA   PIC S9(4) USAGE COMP.*/
        public IntBasis SIARDEVC_COD_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIARDEVC-DATA-COMUNICADO       PIC X(10).*/
        public StringBasis SIARDEVC_DATA_COMUNICADO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIARDEVC-DATA-OCORRENCIA       PIC X(10).*/
        public StringBasis SIARDEVC_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIARDEVC-HORA-OCORRENCIA       PIC X(8).*/
        public StringBasis SIARDEVC_HORA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SIARDEVC-DATA-MOVIMENTO       PIC X(10).*/
        public StringBasis SIARDEVC_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIARDEVC-IND-FAVORECIDO       PIC X(1).*/
        public StringBasis SIARDEVC_IND_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIARDEVC-VAL-TOT-MOVIMENTO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_VAL_TOT_MOVIMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SIARDEVC-VAL-PECAS   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_VAL_PECAS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SIARDEVC-VAL-MAO-OBRA       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_VAL_MAO_OBRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SIARDEVC-VAL-PARCELA-PEND       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_VAL_PARCELA_PEND { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SIARDEVC-QTD-PARCELA-PEND       PIC S9(4) USAGE COMP.*/
        public IntBasis SIARDEVC_QTD_PARCELA_PEND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIARDEVC-VAL-DESC-PARC-PEND       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_VAL_DESC_PARC_PEND { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SIARDEVC-DATA-NEGOCIADA       PIC X(10).*/
        public StringBasis SIARDEVC_DATA_NEGOCIADA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIARDEVC-VAL-IRF     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_VAL_IRF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SIARDEVC-VAL-ISS     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_VAL_ISS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SIARDEVC-VAL-INSS    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_VAL_INSS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SIARDEVC-VAL-LIQUIDO-PAGTO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_VAL_LIQUIDO_PAGTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SIARDEVC-CGCCPF      PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_CGCCPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SIARDEVC-NOM-FAVORECIDO       PIC X(40).*/
        public StringBasis SIARDEVC_NOM_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SIARDEVC-IND-DOC-FISCAL       PIC X(1).*/
        public StringBasis SIARDEVC_IND_DOC_FISCAL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIARDEVC-NUM-DOC-FISCAL       PIC S9(9) USAGE COMP.*/
        public IntBasis SIARDEVC_NUM_DOC_FISCAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIARDEVC-SERIE-DOC-FISCAL       PIC X(6).*/
        public StringBasis SIARDEVC_SERIE_DOC_FISCAL { get; set; } = new StringBasis(new PIC("X", "6", "X(6)."), @"");
        /*"    10 SIARDEVC-DATA-EMISSAO       PIC X(10).*/
        public StringBasis SIARDEVC_DATA_EMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIARDEVC-DES-ENDERECO       PIC X(80).*/
        public StringBasis SIARDEVC_DES_ENDERECO { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
        /*"    10 SIARDEVC-NOM-BAIRRO  PIC X(40).*/
        public StringBasis SIARDEVC_NOM_BAIRRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SIARDEVC-NOM-CIDADE  PIC X(60).*/
        public StringBasis SIARDEVC_NOM_CIDADE { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
        /*"    10 SIARDEVC-COD-UF      PIC X(2).*/
        public StringBasis SIARDEVC_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SIARDEVC-NUM-CEP     PIC S9(9) USAGE COMP.*/
        public IntBasis SIARDEVC_NUM_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIARDEVC-NUM-DDD     PIC S9(4) USAGE COMP.*/
        public IntBasis SIARDEVC_NUM_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIARDEVC-NUM-TELEFONE       PIC S9(9) USAGE COMP.*/
        public IntBasis SIARDEVC_NUM_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIARDEVC-IND-FORMA-PAGTO       PIC X(1).*/
        public StringBasis SIARDEVC_IND_FORMA_PAGTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIARDEVC-NUM-IDENTIFICADOR       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_NUM_IDENTIFICADOR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SIARDEVC-NUM-CHEQUE-INTERNO       PIC S9(9) USAGE COMP.*/
        public IntBasis SIARDEVC_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIARDEVC-ORDEM-PAGAMENTO-VC       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_ORDEM_PAGAMENTO_VC { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SIARDEVC-ORDEM-PAGAMENTO       PIC S9(9) USAGE COMP.*/
        public IntBasis SIARDEVC_ORDEM_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIARDEVC-COD-BANCO   PIC S9(4) USAGE COMP.*/
        public IntBasis SIARDEVC_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIARDEVC-COD-AGENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis SIARDEVC_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIARDEVC-OPERACAO-CONTA       PIC S9(4) USAGE COMP.*/
        public IntBasis SIARDEVC_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIARDEVC-COD-CONTA   PIC X(15).*/
        public StringBasis SIARDEVC_COD_CONTA { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 SIARDEVC-DV-CONTA    PIC X(1).*/
        public StringBasis SIARDEVC_DV_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIARDEVC-COD-FAVORECIDO       PIC S9(9) USAGE COMP.*/
        public IntBasis SIARDEVC_COD_FAVORECIDO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIARDEVC-NUM-APOL-SINISTRO       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SIARDEVC-STA-PROCESSAMENTO       PIC X(1).*/
        public StringBasis SIARDEVC_STA_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIARDEVC-COD-ERRO    PIC S9(4) USAGE COMP.*/
        public IntBasis SIARDEVC_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIARDEVC-TIPO-PESSOA       PIC X(1).*/
        public StringBasis SIARDEVC_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIARDEVC-STA-RETORNO       PIC X(1).*/
        public StringBasis SIARDEVC_STA_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIARDEVC-VAL-PISPASEP       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_VAL_PISPASEP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SIARDEVC-VAL-COFINS  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_VAL_COFINS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SIARDEVC-VAL-CSLL    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_VAL_CSLL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SIARDEVC-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis SIARDEVC_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIARDEVC-NOM-NAT-DOC       PIC X(20).*/
        public StringBasis SIARDEVC_NOM_NAT_DOC { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 SIARDEVC-COD-IDENTIDADE       PIC X(20).*/
        public StringBasis SIARDEVC_COD_IDENTIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 SIARDEVC-NOM-ORGAO-EXP       PIC X(10).*/
        public StringBasis SIARDEVC_NOM_ORGAO_EXP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIARDEVC-DTH-EXP-DOC-IDENT       PIC X(10).*/
        public StringBasis SIARDEVC_DTH_EXP_DOC_IDENT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIARDEVC-COD-UF-EXPEDIDORA       PIC X(2).*/
        public StringBasis SIARDEVC_COD_UF_EXPEDIDORA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SIARDEVC-COD-ATIV-PRINCIPAL       PIC S9(4) USAGE COMP.*/
        public IntBasis SIARDEVC_COD_ATIV_PRINCIPAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIARDEVC-DTH-ULT-DOCTO       PIC X(10).*/
        public StringBasis SIARDEVC_DTH_ULT_DOCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIARDEVC-DES-MARCA-MODELO       PIC X(90).*/
        public StringBasis SIARDEVC_DES_MARCA_MODELO { get; set; } = new StringBasis(new PIC("X", "90", "X(90)."), @"");
        /*"    10 SIARDEVC-NUM-PLACA   PIC X(7).*/
        public StringBasis SIARDEVC_NUM_PLACA { get; set; } = new StringBasis(new PIC("X", "7", "X(7)."), @"");
        /*"    10 SIARDEVC-NUM-CHASSIS       PIC X(20).*/
        public StringBasis SIARDEVC_NUM_CHASSIS { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 SIARDEVC-DTH-ANO-VEICULO       PIC S9(4) USAGE COMP.*/
        public IntBasis SIARDEVC_DTH_ANO_VEICULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIARDEVC-NUM-RESSARC       PIC S9(9) USAGE COMP.*/
        public IntBasis SIARDEVC_NUM_RESSARC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIARDEVC-IND-PESSOA-ACORDO       PIC X(1).*/
        public StringBasis SIARDEVC_IND_PESSOA_ACORDO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIARDEVC-NUM-CPFCGC-ACORDO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_NUM_CPFCGC_ACORDO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SIARDEVC-NOM-RESP-ACORDO       PIC X(40).*/
        public StringBasis SIARDEVC_NOM_RESP_ACORDO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SIARDEVC-STA-ACORDO  PIC X(1).*/
        public StringBasis SIARDEVC_STA_ACORDO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIARDEVC-DTH-INDENIZACAO       PIC X(10).*/
        public StringBasis SIARDEVC_DTH_INDENIZACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIARDEVC-VLR-INDENIZACAO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_VLR_INDENIZACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SIARDEVC-VLR-PART-TERCEIROS       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_VLR_PART_TERCEIROS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SIARDEVC-VLR-DIVIDA  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_VLR_DIVIDA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SIARDEVC-PCT-DESCONTO       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_PCT_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 SIARDEVC-VLR-TOTAL-DESCONTO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_VLR_TOTAL_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SIARDEVC-VLR-TOTAL-ACORDO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_VLR_TOTAL_ACORDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SIARDEVC-COD-MOEDA-ACORDO       PIC S9(4) USAGE COMP.*/
        public IntBasis SIARDEVC_COD_MOEDA_ACORDO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIARDEVC-DTH-ACORDO  PIC X(10).*/
        public StringBasis SIARDEVC_DTH_ACORDO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIARDEVC-QTD-PARCELAS-ACORDO       PIC S9(4) USAGE COMP.*/
        public IntBasis SIARDEVC_QTD_PARCELAS_ACORDO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIARDEVC-NUM-PARCELA-ACORDO       PIC S9(4) USAGE COMP.*/
        public IntBasis SIARDEVC_NUM_PARCELA_ACORDO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIARDEVC-COD-AGENCIA-CEDENT       PIC S9(4) USAGE COMP.*/
        public IntBasis SIARDEVC_COD_AGENCIA_CEDENT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIARDEVC-NUM-CEDENTE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_NUM_CEDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SIARDEVC-NUM-CEDENTE-DV       PIC X(1).*/
        public StringBasis SIARDEVC_NUM_CEDENTE_DV { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIARDEVC-DTH-VENCIMENTO       PIC X(10).*/
        public StringBasis SIARDEVC_DTH_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIARDEVC-NUM-NOSSO-TITULO       PIC S9(16)V USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_NUM_NOSSO_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V"), 0);
        /*"    10 SIARDEVC-VLR-TITULO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_VLR_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SIARDEVC-NUM-CPFCGC-RECLAMANTE       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_NUM_CPFCGC_RECLAMANTE { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SIARDEVC-NOM-RECLAMANTE       PIC X(40).*/
        public StringBasis SIARDEVC_NOM_RECLAMANTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SIARDEVC-VLR-RECLAMADO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_VLR_RECLAMADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SIARDEVC-VLR-PROVISIONADO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_VLR_PROVISIONADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SIARDEVC-NUM-SINISTRO-CONV       PIC X(30).*/
        public StringBasis SIARDEVC_NUM_SINISTRO_CONV { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 SIARDEVC-NUM-IDENT-CONV       PIC S9(17)V USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_NUM_IDENT_CONV { get; set; } = new DoubleBasis(new PIC("S9", "17", "S9(17)V"), 0);
        /*"    10 SIARDEVC-NUM-IDE-COBR-CONV       PIC S9(17)V USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_NUM_IDE_COBR_CONV { get; set; } = new DoubleBasis(new PIC("S9", "17", "S9(17)V"), 0);
        /*"    10 SIARDEVC-COD-IDLG    PIC X(40).*/
        public StringBasis SIARDEVC_COD_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SIARDEVC-COD-CFOP    PIC S9(9) USAGE COMP.*/
        public IntBasis SIARDEVC_COD_CFOP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIARDEVC-COD-CEST    PIC S9(18) USAGE COMP.*/
        public IntBasis SIARDEVC_COD_CEST { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 SIARDEVC-NUM-INSCR-ESTADUAL       PIC S9(18) USAGE COMP.*/
        public IntBasis SIARDEVC_NUM_INSCR_ESTADUAL { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 SIARDEVC-NUM-NCM     PIC S9(18) USAGE COMP.*/
        public IntBasis SIARDEVC_NUM_NCM { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 SIARDEVC-NUM-CPF-CNPJ-TOMADOR       PIC S9(18) USAGE COMP.*/
        public IntBasis SIARDEVC_NUM_CPF_CNPJ_TOMADOR { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 SIARDEVC-IND-ISENCAO-TRIBUTO       PIC X(1).*/
        public StringBasis SIARDEVC_IND_ISENCAO_TRIBUTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIARDEVC-COD-IMPOSTO-LIMINAR       PIC S9(4) USAGE COMP.*/
        public IntBasis SIARDEVC_COD_IMPOSTO_LIMINAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIARDEVC-COD-PROCESSO-ISENCAO       PIC X(30).*/
        public StringBasis SIARDEVC_COD_PROCESSO_ISENCAO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 SIARDEVC-VLR-RET-N-EFETUADO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIARDEVC_VLR_RET_N_EFETUADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"*/
    }
}