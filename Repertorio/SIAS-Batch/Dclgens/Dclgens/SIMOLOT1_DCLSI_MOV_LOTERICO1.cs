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
    public class SIMOLOT1_DCLSI_MOV_LOTERICO1 : VarBasis
    {
        /*"    10 SIMOLOT1-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SIMOLOT1_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SIMOLOT1-COD-LOT-CEF  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SIMOLOT1_COD_LOT_CEF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SIMOLOT1-NOME-LOTERICO  PIC X(40).*/
        public StringBasis SIMOLOT1_NOME_LOTERICO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SIMOLOT1-DATA-OCORRENCIA  PIC X(10).*/
        public StringBasis SIMOLOT1_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIMOLOT1-HORA-OCORRENCIA  PIC X(8).*/
        public StringBasis SIMOLOT1_HORA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SIMOLOT1-DATA-GERACAO-MOV  PIC X(10).*/
        public StringBasis SIMOLOT1_DATA_GERACAO_MOV { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIMOLOT1-DATA-AVISO  PIC X(10).*/
        public StringBasis SIMOLOT1_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIMOLOT1-HORA-AVISO  PIC X(8).*/
        public StringBasis SIMOLOT1_HORA_AVISO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SIMOLOT1-VALOR-INFORMADO  PIC S9(11)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIMOLOT1_VALOR_INFORMADO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 SIMOLOT1-NATUREZA    PIC S9(4) USAGE COMP.*/
        public IntBasis SIMOLOT1_NATUREZA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIMOLOT1-COD-CAUSA   PIC S9(4) USAGE COMP.*/
        public IntBasis SIMOLOT1_COD_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIMOLOT1-IND-CRITICA  PIC X(1).*/
        public StringBasis SIMOLOT1_IND_CRITICA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIMOLOT1-MENSAGEM    PIC X(40).*/
        public StringBasis SIMOLOT1_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SIMOLOT1-VALOR-REGISTRADO  PIC S9(11)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIMOLOT1_VALOR_REGISTRADO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 SIMOLOT1-VAL-IS      PIC S9(11)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIMOLOT1_VAL_IS { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 SIMOLOT1-VAL-ADIANTAMENTO  PIC S9(11)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIMOLOT1_VAL_ADIANTAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 SIMOLOT1-PERC-ADIANTAMENTO  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIMOLOT1_PERC_ADIANTAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 SIMOLOT1-COD-LOT-SASSE  PIC S9(9) USAGE COMP.*/
        public IntBasis SIMOLOT1_COD_LOT_SASSE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIMOLOT1-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis SIMOLOT1_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIMOLOT1-QTD-SINI-AVISADO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIMOLOT1_QTD_SINI_AVISADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIMOLOT1-QTD-SINI-PAGOS  PIC S9(4) USAGE COMP.*/
        public IntBasis SIMOLOT1_QTD_SINI_PAGOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIMOLOT1-QTD-MESES   PIC S9(4) USAGE COMP.*/
        public IntBasis SIMOLOT1_QTD_MESES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIMOLOT1-TIMESTAMP   PIC X(26).*/
        public StringBasis SIMOLOT1_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SIMOLOT1-DATA-ULT-DOC  PIC X(10).*/
        public StringBasis SIMOLOT1_DATA_ULT_DOC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIMOLOT1-NUM-SINI-PREST  PIC S9(12)V USAGE COMP-3.*/
        public DoubleBasis SIMOLOT1_NUM_SINI_PREST { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(12)V"), 0);
        /*"    10 SIMOLOT1-QTD-PORTADORES  PIC S9(4) USAGE COMP.*/
        public IntBasis SIMOLOT1_QTD_PORTADORES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIMOLOT1-IND-ADIANTAMENTO  PIC X(1).*/
        public StringBasis SIMOLOT1_IND_ADIANTAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}