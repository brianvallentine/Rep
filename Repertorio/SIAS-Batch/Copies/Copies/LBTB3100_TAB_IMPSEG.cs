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
    public class LBTB3100_TAB_IMPSEG : VarBasis
    {
        /*"     10 TB-IMPSEG       PIC S9(10)V99 COMP-3 OCCURS    10 TIMES*/
        public ListBasis<DoubleBasis, double> TB_IMPSEG { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "10", "S9(10)V99"), 10);
        /*"01 TAB-TAXAS     COMP-3*/
    }
}