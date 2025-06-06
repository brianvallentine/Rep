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
    public class _REDEF_LBTB3201_FILLER_49 : VarBasis
    {
        /*"  10   TAB-LIMITE-MINMAX-CCAT OCCURS 20 TIMES*/
        public ListBasis<LBTB3201_TAB_LIMITE_MINMAX_CCAT> TAB_LIMITE_MINMAX_CCAT { get; set; } = new ListBasis<LBTB3201_TAB_LIMITE_MINMAX_CCAT>(20);


        public _REDEF_LBTB3201_FILLER_49()
        {
            TAB_LIMITE_MINMAX_CCAT.ValueChanged += OnValueChanged;
        }

    }
}