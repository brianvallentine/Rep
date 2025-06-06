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
    public class AU080 : VarBasis
    {
        /*"01  DCLAU-PARAM-PLANO-PRDTO.*/
        public AU080_DCLAU_PARAM_PLANO_PRDTO DCLAU_PARAM_PLANO_PRDTO { get; set; } = new AU080_DCLAU_PARAM_PLANO_PRDTO();

    }
}