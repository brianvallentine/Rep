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
    public class MOEDACOT_DCLMOEDAS_COTACAO : VarBasis
    {
        /*"    10 MOEDACOT-COD-MOEDA   PIC S9(4) USAGE COMP.*/
        public IntBasis MOEDACOT_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOEDACOT-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis MOEDACOT_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOEDACOT-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis MOEDACOT_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOEDACOT-VAL-COMPRA  PIC S9(6)V9(9) USAGE COMP-3.*/
        public DoubleBasis MOEDACOT_VAL_COMPRA { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(6)V9(9)"), 9);
        /*"    10 MOEDACOT-VAL-VENDA   PIC S9(6)V9(9) USAGE COMP-3.*/
        public DoubleBasis MOEDACOT_VAL_VENDA { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(6)V9(9)"), 9);
        /*"    10 MOEDACOT-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis MOEDACOT_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}