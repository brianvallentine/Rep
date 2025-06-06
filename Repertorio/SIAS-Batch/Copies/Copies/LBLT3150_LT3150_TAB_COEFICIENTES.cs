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
    public class LBLT3150_LT3150_TAB_COEFICIENTES : VarBasis
    {
        /*"    05     LT3150-PERCENT-COEFICIENTES   OCCURS       12 TIMES*/
        public ListBasis<LBLT3150_LT3150_PERCENT_COEFICIENTES> LT3150_PERCENT_COEFICIENTES { get; set; } = new ListBasis<LBLT3150_LT3150_PERCENT_COEFICIENTES>(12);

    }
}