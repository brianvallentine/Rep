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
    public class _REDEF_LBTB3201_TABELA_FRANQUIAS_R : VarBasis
    {
        /*"  10   TAB-FRANQUIAS      OCCURS 20 TIMES*/
        public ListBasis<LBTB3201_TAB_FRANQUIAS> TAB_FRANQUIAS { get; set; } = new ListBasis<LBTB3201_TAB_FRANQUIAS>(20);


        public _REDEF_LBTB3201_TABELA_FRANQUIAS_R()
        {
            TAB_FRANQUIAS.ValueChanged += OnValueChanged;
        }

    }
}