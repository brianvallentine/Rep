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
    public class COSSESIN_DCLCOSSEGURO_SINISTRO : VarBasis
    {
        /*"    10 COSSESIN-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis COSSESIN_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COSSESIN-TIPO-SEGURO  PIC X(1).*/
        public StringBasis COSSESIN_TIPO_SEGURO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COSSESIN-COD-CONGENERE  PIC S9(4) USAGE COMP.*/
        public IntBasis COSSESIN_COD_CONGENERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COSSESIN-NUM-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis COSSESIN_NUM_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 COSSESIN-VAL-OPERACAO-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis COSSESIN_VAL_OPERACAO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 COSSESIN-SIT-REGISTRO  PIC X(1).*/
        public StringBasis COSSESIN_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COSSESIN-SIT-CONGENERE  PIC X(1).*/
        public StringBasis COSSESIN_SIT_CONGENERE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COSSESIN-TIMESTAMP   PIC X(26).*/
        public StringBasis COSSESIN_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
    }
}