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
    public class LBLT3151_LT3151_TAB_IMPSEG : VarBasis
    {
        /*"       15 LT3151-IMPSEG             PIC S9(10)V9(02) COMP-3*/
        public DoubleBasis LT3151_IMPSEG { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"  05  LT3151-TABELA-TAXAS*/
    }
}