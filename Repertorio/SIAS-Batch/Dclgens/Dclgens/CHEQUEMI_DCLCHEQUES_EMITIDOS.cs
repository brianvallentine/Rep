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
    public class CHEQUEMI_DCLCHEQUES_EMITIDOS : VarBasis
    {
        /*"    10 CHEQUEMI-TIPO-MOVIMENTO  PIC X(1).*/
        public StringBasis CHEQUEMI_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CHEQUEMI-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis CHEQUEMI_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CHEQUEMI-NUM-DOCUMENTO  PIC X(18).*/
        public StringBasis CHEQUEMI_NUM_DOCUMENTO { get; set; } = new StringBasis(new PIC("X", "18", "X(18)."), @"");
        /*"    10 CHEQUEMI-NOME-FAVORECIDO  PIC X(40).*/
        public StringBasis CHEQUEMI_NOME_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 CHEQUEMI-VAL-CHEQUE  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CHEQUEMI_VAL_CHEQUE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CHEQUEMI-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis CHEQUEMI_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CHEQUEMI-DATA-EMISSAO  PIC X(10).*/
        public StringBasis CHEQUEMI_DATA_EMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CHEQUEMI-NUM-CHEQUE-INTERNO  PIC S9(9) USAGE COMP.*/
        public IntBasis CHEQUEMI_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CHEQUEMI-DIG-CHEQUE-INTERNO  PIC S9(4) USAGE COMP.*/
        public IntBasis CHEQUEMI_DIG_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CHEQUEMI-SIT-REGISTRO  PIC X(1).*/
        public StringBasis CHEQUEMI_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CHEQUEMI-TIPO-PAGAMENTO  PIC X(1).*/
        public StringBasis CHEQUEMI_TIPO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CHEQUEMI-DATA-COMPETENCIA  PIC X(10).*/
        public StringBasis CHEQUEMI_DATA_COMPETENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CHEQUEMI-PRACA-PAGAMENTO  PIC X(20).*/
        public StringBasis CHEQUEMI_PRACA_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 CHEQUEMI-NUM-RECIBO  PIC S9(9) USAGE COMP.*/
        public IntBasis CHEQUEMI_NUM_RECIBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CHEQUEMI-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis CHEQUEMI_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CHEQUEMI-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis CHEQUEMI_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CHEQUEMI-COD-DESPESA  PIC S9(4) USAGE COMP.*/
        public IntBasis CHEQUEMI_COD_DESPESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CHEQUEMI-VAL-IRF     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CHEQUEMI_VAL_IRF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CHEQUEMI-VAL-ISS     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CHEQUEMI_VAL_ISS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CHEQUEMI-VAL-IAPAS   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CHEQUEMI_VAL_IAPAS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CHEQUEMI-COD-LANCAMENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis CHEQUEMI_COD_LANCAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CHEQUEMI-DATA-LANCAMENTO  PIC X(10).*/
        public StringBasis CHEQUEMI_DATA_LANCAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CHEQUEMI-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis CHEQUEMI_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CHEQUEMI-TIMESTAMP   PIC X(26).*/
        public StringBasis CHEQUEMI_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 CHEQUEMI-COD-FAVORECIDO  PIC S9(9) USAGE COMP.*/
        public IntBasis CHEQUEMI_COD_FAVORECIDO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CHEQUEMI-VAL-INSS    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CHEQUEMI_VAL_INSS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"*/
    }
}