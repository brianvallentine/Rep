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
    public class _REDEF_LBTB3101_FILLER_28 : VarBasis
    {
        /*"  10   TAB-LIM-MINMAX-CCA  OCCURS 20 TIMES*/
        public ListBasis<LBTB3101_TAB_LIM_MINMAX_CCA> TAB_LIM_MINMAX_CCA { get; set; } = new ListBasis<LBTB3101_TAB_LIM_MINMAX_CCA>(20);


        public _REDEF_LBTB3101_FILLER_28()
        {
            TAB_LIM_MINMAX_CCA.ValueChanged += OnValueChanged;
        }

    }
}