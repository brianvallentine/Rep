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
    public class SI175_DCLSI_PESS_SINISTRO : VarBasis
    {
        /*"    10 SI175-NUM-OCORR-MOVTO  PIC S9(9) USAGE COMP.*/
        public IntBasis SI175_NUM_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SI175-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SI175_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SI175-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis SI175_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI175-COD-OPERACAO   PIC S9(4) USAGE COMP.*/
        public IntBasis SI175_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}