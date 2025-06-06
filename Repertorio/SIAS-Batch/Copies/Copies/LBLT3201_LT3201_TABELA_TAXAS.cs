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
    public class LBLT3201_LT3201_TABELA_TAXAS : VarBasis
    {
        /*"    10 LT3201-TAB-TAXAS             OCCURS 20 TIMES*/
        public ListBasis<LBLT3201_LT3201_TAB_TAXAS> LT3201_TAB_TAXAS { get; set; } = new ListBasis<LBLT3201_LT3201_TAB_TAXAS>(20);

    }
}