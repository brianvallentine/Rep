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
    public class CB040_DCLCB_PESS_REC_ANT : VarBasis
    {
        /*"    10 CB040-NUM-OCORR-MOVTO  PIC S9(9) USAGE COMP.*/
        public IntBasis CB040_NUM_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CB040-COD-FONTE      PIC S9(4) USAGE COMP.*/
        public IntBasis CB040_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CB040-NUM-RCAP       PIC S9(9) USAGE COMP.*/
        public IntBasis CB040_NUM_RCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}