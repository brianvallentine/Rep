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
    public class SINISAUT_DCLSINISTRO_AUTO1 : VarBasis
    {
        /*"    10 SINISAUT-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINISAUT_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINISAUT-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINISAUT_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINISAUT-NUM-ITEM    PIC S9(9) USAGE COMP.*/
        public IntBasis SINISAUT_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISAUT-RAMO        PIC S9(4) USAGE COMP.*/
        public IntBasis SINISAUT_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISAUT-SIT-REGISTRO  PIC X(1).*/
        public StringBasis SINISAUT_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISAUT-TIMESTAMP   PIC X(26).*/
        public StringBasis SINISAUT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}