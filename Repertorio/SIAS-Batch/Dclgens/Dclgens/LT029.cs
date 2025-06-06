using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class LT029 : VarBasis
    {
        /*"01  DCLLT-DESCONTO.*/
        public LT029_DCLLT_DESCONTO DCLLT_DESCONTO { get; set; } = new LT029_DCLLT_DESCONTO();

    }
}