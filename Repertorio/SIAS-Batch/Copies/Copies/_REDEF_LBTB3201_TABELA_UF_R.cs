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
    public class _REDEF_LBTB3201_TABELA_UF_R : VarBasis
    {
        /*"     10 TAB-UF OCCURS 35 TIMES INDEXED BY WS-MEN*/
        public ListBasis<LBTB3201_TAB_UF> TAB_UF { get; set; } = new ListBasis<LBTB3201_TAB_UF>(35);


        public _REDEF_LBTB3201_TABELA_UF_R()
        {
            TAB_UF.ValueChanged += OnValueChanged;
        }

    }
}