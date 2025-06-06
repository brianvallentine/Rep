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
    public class MALHACEF_DCLMALHA_CEF : VarBasis
    {
        /*"    10 MALHACEF-COD-DERAR   PIC S9(4) USAGE COMP.*/
        public IntBasis MALHACEF_COD_DERAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MALHACEF-COD-SUREG   PIC S9(4) USAGE COMP.*/
        public IntBasis MALHACEF_COD_SUREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MALHACEF-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis MALHACEF_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MALHACEF-COD-SUREG-SASSE  PIC S9(4) USAGE COMP.*/
        public IntBasis MALHACEF_COD_SUREG_SASSE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}