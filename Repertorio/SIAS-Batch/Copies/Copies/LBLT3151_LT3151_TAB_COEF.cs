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
    public class LBLT3151_LT3151_TAB_COEF : VarBasis
    {
        /*"       15 LT3151-COEF               PIC S9(03)V9(09) COMP-3*/
        public DoubleBasis LT3151_COEF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(09)"), 9);
        /*"  05  LT3151-PCT-DESC-FIDEL         PIC S9(03)V9(02) COMP-3*/
    }
}