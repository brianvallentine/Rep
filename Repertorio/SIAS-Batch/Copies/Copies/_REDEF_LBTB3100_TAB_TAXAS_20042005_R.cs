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
    public class _REDEF_LBTB3100_TAB_TAXAS_20042005_R : VarBasis
    {
        /*"     10 TB-TAXAS-20042005   PIC 9(03)V9(9) OCCURS 228 TIMES*/
        public ListBasis<DoubleBasis, double> TB_TAXAS_20042005 { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "3", "9(03)V9(9)"), 228);
        /*"01 TAB-TAXAS-2006*/

        public _REDEF_LBTB3100_TAB_TAXAS_20042005_R()
        {
            TB_TAXAS_20042005.ValueChanged += OnValueChanged;
        }

    }
}