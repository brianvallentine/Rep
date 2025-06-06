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
    public class _REDEF_LBTB3101_TABELA_UF_4_R : VarBasis
    {
        /*"  10 TAB-UF-4 OCCURS 35 TIMES INDEXED BY WS-IUF4*/
        public ListBasis<LBTB3101_TAB_UF_4> TAB_UF_4 { get; set; } = new ListBasis<LBTB3101_TAB_UF_4>(35);


        public _REDEF_LBTB3101_TABELA_UF_4_R()
        {
            TAB_UF_4.ValueChanged += OnValueChanged;
        }

    }
}