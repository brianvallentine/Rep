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
    public class SINNUMLO_DCLSINISTRO_NUM_LOTE : VarBasis
    {
        /*"    10 SINNUMLO-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis SINNUMLO_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINNUMLO-NUM-LOTE    PIC S9(9) USAGE COMP.*/
        public IntBasis SINNUMLO_NUM_LOTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINNUMLO-TIMESTAMP   PIC X(26).*/
        public StringBasis SINNUMLO_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}