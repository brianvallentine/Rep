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
    public class LBLT3151_LT3151_TABELA_PREMIOS : VarBasis
    {
        /*"    10 LT3151-TAB-PREMIOS           OCCURS 20 TIMES*/
        public ListBasis<LBLT3151_LT3151_TAB_PREMIOS> LT3151_TAB_PREMIOS { get; set; } = new ListBasis<LBLT3151_LT3151_TAB_PREMIOS>(20);

    }
}