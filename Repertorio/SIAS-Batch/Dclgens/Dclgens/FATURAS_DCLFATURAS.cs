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
    public class FATURAS_DCLFATURAS : VarBasis
    {
        /*"    10 FATURAS-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis FATURAS_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 FATURAS-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis FATURAS_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FATURAS-NUM-FATURA   PIC S9(9) USAGE COMP.*/
        public IntBasis FATURAS_NUM_FATURA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FATURAS-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis FATURAS_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FATURAS-TIPO-ENDOSSO  PIC X(1).*/
        public StringBasis FATURAS_TIPO_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FATURAS-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis FATURAS_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FATURAS-VAL-FATURA   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis FATURAS_VAL_FATURA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 FATURAS-COD-FONTE    PIC S9(4) USAGE COMP.*/
        public IntBasis FATURAS_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FATURAS-NUM-RCAP     PIC S9(9) USAGE COMP.*/
        public IntBasis FATURAS_NUM_RCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FATURAS-VAL-RCAP     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis FATURAS_VAL_RCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 FATURAS-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis FATURAS_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FATURAS-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis FATURAS_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FATURAS-SIT-REGISTRO  PIC X(1).*/
        public StringBasis FATURAS_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FATURAS-DATA-FATURA  PIC X(10).*/
        public StringBasis FATURAS_DATA_FATURA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FATURAS-DATA-RCAP    PIC X(10).*/
        public StringBasis FATURAS_DATA_RCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FATURAS-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis FATURAS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FATURAS-DATA-VENCIMENTO  PIC X(10).*/
        public StringBasis FATURAS_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FATURAS-VAL-IOCC     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis FATURAS_VAL_IOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"*/
    }
}