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
    public class _REDEF_LBTB3201_TABELA_LIMITE_MINMAX_R : VarBasis
    {
        /*"  10   TAB-LIMITE-MINMAX     OCCURS 20 TIMES*/
        public ListBasis<LBTB3201_TAB_LIMITE_MINMAX> TAB_LIMITE_MINMAX { get; set; } = new ListBasis<LBTB3201_TAB_LIMITE_MINMAX>(20);


        public _REDEF_LBTB3201_TABELA_LIMITE_MINMAX_R()
        {
            TAB_LIMITE_MINMAX.ValueChanged += OnValueChanged;
        }

    }
}