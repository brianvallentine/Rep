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
    public class _REDEF_LBGE8051_TABELA_COD_RETORNO_SIAS_R : VarBasis
    {
        /*"    10 TAB-COD-RETORNO-SIAS  OCCURS 18 TIMES INDEXED BY WSSIAS*/
        public ListBasis<LBGE8051_TAB_COD_RETORNO_SIAS> TAB_COD_RETORNO_SIAS { get; set; } = new ListBasis<LBGE8051_TAB_COD_RETORNO_SIAS>(18);


        public _REDEF_LBGE8051_TABELA_COD_RETORNO_SIAS_R()
        {
            TAB_COD_RETORNO_SIAS.ValueChanged += OnValueChanged;
        }

    }
}