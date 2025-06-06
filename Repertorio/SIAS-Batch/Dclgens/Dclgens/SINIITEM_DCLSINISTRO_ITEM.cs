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
    public class SINIITEM_DCLSINISTRO_ITEM : VarBasis
    {
        /*"    10 SINIITEM-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINIITEM_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINIITEM-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis SINIITEM_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINIITEM-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis SINIITEM_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}