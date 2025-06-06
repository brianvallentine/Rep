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
    public class _REDEF_LBTB3201_TAB_VIG_PLURI_R : VarBasis
    {
        /*"  10   TB-VIG-PLURI       OCCURS 10 TIMES*/
        public ListBasis<LBTB3201_TB_VIG_PLURI> TB_VIG_PLURI { get; set; } = new ListBasis<LBTB3201_TB_VIG_PLURI>(10);


        public _REDEF_LBTB3201_TAB_VIG_PLURI_R()
        {
            TB_VIG_PLURI.ValueChanged += OnValueChanged;
        }

    }
}