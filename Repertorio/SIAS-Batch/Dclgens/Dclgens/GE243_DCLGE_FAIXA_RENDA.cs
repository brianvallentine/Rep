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
    public class GE243_DCLGE_FAIXA_RENDA : VarBasis
    {
        /*"    10 GE243-NUM-FAIXA-RENDA       PIC S9(4) USAGE COMP.*/
        public IntBasis GE243_NUM_FAIXA_RENDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE243-VLR-MIN-FAIXA  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE243_VLR_MIN_FAIXA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE243-VLR-MAX-FAIXA  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE243_VLR_MAX_FAIXA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"*/
    }
}