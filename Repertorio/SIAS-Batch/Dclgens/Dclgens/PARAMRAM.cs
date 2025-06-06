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
    public class PARAMRAM : VarBasis
    {
        /*"01  DCLPARAMETROS-RAMOS.*/
        public PARAMRAM_DCLPARAMETROS_RAMOS DCLPARAMETROS_RAMOS { get; set; } = new PARAMRAM_DCLPARAMETROS_RAMOS();

    }
}