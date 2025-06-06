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
    public class LBLT3250_LT3250_TAB_COEF_PLURI : VarBasis
    {
        /*"    05     LT3250-PERCENT-PLURI         OCCURS      10  TIMES*/
        public ListBasis<LBLT3250_LT3250_PERCENT_PLURI> LT3250_PERCENT_PLURI { get; set; } = new ListBasis<LBLT3250_LT3250_PERCENT_PLURI>(10);

    }
}