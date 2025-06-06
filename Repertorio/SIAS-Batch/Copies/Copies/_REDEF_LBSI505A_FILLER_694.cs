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
    public class _REDEF_LBSI505A_FILLER_694 : VarBasis
    {
        /*"    03  W-TABELA1  OCCURS   695*/
        public ListBasis<LBSI505A_W_TABELA1> W_TABELA1 { get; set; } = new ListBasis<LBSI505A_W_TABELA1>(695);


        public _REDEF_LBSI505A_FILLER_694()
        {
            W_TABELA1.ValueChanged += OnValueChanged;
        }

    }
}