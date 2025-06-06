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
    public class _REDEF_LBTB3101_TABELA_LIM_MINMAX_R : VarBasis
    {
        /*"  10   TAB-LIM-MINMAX     OCCURS 20 TIMES*/
        public ListBasis<LBTB3101_TAB_LIM_MINMAX> TAB_LIM_MINMAX { get; set; } = new ListBasis<LBTB3101_TAB_LIM_MINMAX>(20);


        public _REDEF_LBTB3101_TABELA_LIM_MINMAX_R()
        {
            TAB_LIM_MINMAX.ValueChanged += OnValueChanged;
        }

    }
}