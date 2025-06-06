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
    public class LBLT3250_LT3250_PERCENT_PLURI : VarBasis
    {
        /*"      10   LT3250-QTD-DIAS-PLURI        PIC  9(006)*/
        public IntBasis LT3250_QTD_DIAS_PLURI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"      10   LT3250-PCT-PLURI             PIC  9(005)V9(2)*/
        public DoubleBasis LT3250_PCT_PLURI { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V9(2)"), 2);
        /*"  03       LT3250-DISPLAY               PIC  X(001)*/
    }
}