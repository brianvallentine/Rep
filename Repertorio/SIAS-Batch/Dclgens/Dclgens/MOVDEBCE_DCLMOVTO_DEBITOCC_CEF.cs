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
    public class MOVDEBCE_DCLMOVTO_DEBITOCC_CEF : VarBasis
    {
        /*"    10 MOVDEBCE-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis MOVDEBCE_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVDEBCE-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis MOVDEBCE_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 MOVDEBCE-NUM-ENDOSSO       PIC S9(9) USAGE COMP.*/
        public IntBasis MOVDEBCE_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVDEBCE-NUM-PARCELA       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVDEBCE_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVDEBCE-SITUACAO-COBRANCA       PIC X(1).*/
        public StringBasis MOVDEBCE_SITUACAO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVDEBCE-DATA-VENCIMENTO       PIC X(10).*/
        public StringBasis MOVDEBCE_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVDEBCE-VALOR-DEBITO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVDEBCE_VALOR_DEBITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVDEBCE-DATA-MOVIMENTO       PIC X(10).*/
        public StringBasis MOVDEBCE_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVDEBCE-TIMESTAMP   PIC X(26).*/
        public StringBasis MOVDEBCE_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 MOVDEBCE-DIA-DEBITO  PIC S9(4) USAGE COMP.*/
        public IntBasis MOVDEBCE_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVDEBCE-COD-AGENCIA-DEB       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVDEBCE_COD_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVDEBCE-OPER-CONTA-DEB       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVDEBCE_OPER_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVDEBCE-NUM-CONTA-DEB       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis MOVDEBCE_NUM_CONTA_DEB { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 MOVDEBCE-DIG-CONTA-DEB       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVDEBCE_DIG_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVDEBCE-COD-CONVENIO       PIC S9(9) USAGE COMP.*/
        public IntBasis MOVDEBCE_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVDEBCE-DATA-ENVIO  PIC X(10).*/
        public StringBasis MOVDEBCE_DATA_ENVIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVDEBCE-DATA-RETORNO       PIC X(10).*/
        public StringBasis MOVDEBCE_DATA_RETORNO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVDEBCE-COD-RETORNO-CEF       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVDEBCE_COD_RETORNO_CEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVDEBCE-NSAS        PIC S9(4) USAGE COMP.*/
        public IntBasis MOVDEBCE_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVDEBCE-COD-USUARIO       PIC X(8).*/
        public StringBasis MOVDEBCE_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 MOVDEBCE-NUM-REQUISICAO       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis MOVDEBCE_NUM_REQUISICAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 MOVDEBCE-NUM-CARTAO  PIC S9(16)V USAGE COMP-3.*/
        public DoubleBasis MOVDEBCE_NUM_CARTAO { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V"), 0);
        /*"    10 MOVDEBCE-SEQUENCIA   PIC S9(4) USAGE COMP.*/
        public IntBasis MOVDEBCE_SEQUENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVDEBCE-NUM-LOTE    PIC S9(9) USAGE COMP.*/
        public IntBasis MOVDEBCE_NUM_LOTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVDEBCE-DTCREDITO   PIC X(10).*/
        public StringBasis MOVDEBCE_DTCREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVDEBCE-STATUS-CARTAO       PIC X(2).*/
        public StringBasis MOVDEBCE_STATUS_CARTAO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 MOVDEBCE-VLR-CREDITO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVDEBCE_VLR_CREDITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVDEBCE-NUM-CERTIFICADO       PIC S9(18) USAGE COMP.*/
        public IntBasis MOVDEBCE_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 MOVDEBCE-COD-MOEDA   PIC S9(4) USAGE COMP.*/
        public IntBasis MOVDEBCE_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVDEBCE-PCT-INDICE  PIC S9(4)V9(5) USAGE COMP-3.*/
        public DoubleBasis MOVDEBCE_PCT_INDICE { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(5)"), 5);
        /*"    10 MOVDEBCE-VLR-ORIGINAL       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVDEBCE_VLR_ORIGINAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVDEBCE-VLR-PRORATA       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVDEBCE_VLR_PRORATA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVDEBCE-VLR-JUROS   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVDEBCE_VLR_JUROS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVDEBCE-VLR-MULTA   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVDEBCE_VLR_MULTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVDEBCE-DTA-ORIGINAL       PIC X(10).*/
        public StringBasis MOVDEBCE_DTA_ORIGINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVDEBCE-COD-IDLG    PIC X(40).*/
        public StringBasis MOVDEBCE_COD_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"*/
    }
}