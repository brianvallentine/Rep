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
    public class CAUSACOB_DCLCAUSA_COBERTURA : VarBasis
    {
        /*"    10 CAUSACOB-RAMO        PIC S9(4) USAGE COMP.*/
        public IntBasis CAUSACOB_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CAUSACOB-COD-CAUSA   PIC S9(4) USAGE COMP.*/
        public IntBasis CAUSACOB_COD_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CAUSACOB-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis CAUSACOB_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CAUSACOB-TIMESTAMP   PIC X(26).*/
        public StringBasis CAUSACOB_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}