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
    public class LBLT3142_LT3142_TAB_TAXAS_1PCL : VarBasis
    {
        /*"    05     LT3142-VALORES-TAXAS-1PCL     OCCURS       10 TIMES*/
        public ListBasis<LBLT3142_LT3142_VALORES_TAXAS_1PCL> LT3142_VALORES_TAXAS_1PCL { get; set; } = new ListBasis<LBLT3142_LT3142_VALORES_TAXAS_1PCL>(10);

    }
}