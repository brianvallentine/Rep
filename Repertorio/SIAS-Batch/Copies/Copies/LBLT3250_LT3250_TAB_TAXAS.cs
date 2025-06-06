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
    public class LBLT3250_LT3250_TAB_TAXAS : VarBasis
    {
        /*"    05     LT3250-VALORES-TAXAS         OCCURS       20 TIMES*/
        public ListBasis<LBLT3250_LT3250_VALORES_TAXAS> LT3250_VALORES_TAXAS { get; set; } = new ListBasis<LBLT3250_LT3250_VALORES_TAXAS>(20);

    }
}