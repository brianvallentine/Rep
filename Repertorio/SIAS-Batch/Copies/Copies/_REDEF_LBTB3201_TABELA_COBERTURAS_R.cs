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
    public class _REDEF_LBTB3201_TABELA_COBERTURAS_R : VarBasis
    {
        /*"  10   TAB-COBERTURAS     OCCURS 20 TIMES*/
        public ListBasis<LBTB3201_TAB_COBERTURAS> TAB_COBERTURAS { get; set; } = new ListBasis<LBTB3201_TAB_COBERTURAS>(20);


        public _REDEF_LBTB3201_TABELA_COBERTURAS_R()
        {
            TAB_COBERTURAS.ValueChanged += OnValueChanged;
        }

    }
}