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
    public class LT028 : VarBasis
    {
        /*"01  DCLLT-PREMIO.*/
        public LT028_DCLLT_PREMIO DCLLT_PREMIO { get; set; } = new LT028_DCLLT_PREMIO();

    }
}