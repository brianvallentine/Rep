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
    public class IDENTREL_DCLIDENTIFICA_RELAC : VarBasis
    {
        /*"    10 IDENTREL-NUM-IDENTIFICACAO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis IDENTREL_NUM_IDENTIFICACAO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 IDENTREL-COD-PESSOA  PIC S9(9) USAGE COMP.*/
        public IntBasis IDENTREL_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 IDENTREL-COD-RELAC   PIC S9(4) USAGE COMP.*/
        public IntBasis IDENTREL_COD_RELAC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 IDENTREL-COD-USUARIO  PIC X(8).*/
        public StringBasis IDENTREL_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 IDENTREL-TIMESTAMP   PIC X(26).*/
        public StringBasis IDENTREL_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}