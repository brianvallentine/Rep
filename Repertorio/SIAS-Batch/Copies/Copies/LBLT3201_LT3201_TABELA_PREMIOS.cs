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
    public class LBLT3201_LT3201_TABELA_PREMIOS : VarBasis
    {
        /*"    10 LT3201-TAB-PREMIOS           OCCURS 20 TIMES*/
        public ListBasis<LBLT3201_LT3201_TAB_PREMIOS> LT3201_TAB_PREMIOS { get; set; } = new ListBasis<LBLT3201_LT3201_TAB_PREMIOS>(20);

    }
}