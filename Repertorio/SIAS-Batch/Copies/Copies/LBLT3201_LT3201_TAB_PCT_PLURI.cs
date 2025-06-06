using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBLT3201_LT3201_TAB_PCT_PLURI : VarBasis
    {
        /*"       15 LT3201-QTD-DIAS-PLURI     PIC S9(06)       COMP*/
        public IntBasis LT3201_QTD_DIAS_PLURI { get; set; } = new IntBasis(new PIC("S9", "6", "S9(06)"));
        /*"       15 LT3201-PCT-PLURI          PIC S9(05)V9(02) COMP-3*/
        public DoubleBasis LT3201_PCT_PLURI { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(05)V9(02)"), 2);
        /*"       15 LT3201-QTD-PARCELAS-PLURI PIC S9(06)       COMP*/
        public IntBasis LT3201_QTD_PARCELAS_PLURI { get; set; } = new IntBasis(new PIC("S9", "6", "S9(06)"));
        /*"  05  LT3201-PCT-DESC-FIDEL         PIC S9(03)V9(02) COMP-3*/
    }
}