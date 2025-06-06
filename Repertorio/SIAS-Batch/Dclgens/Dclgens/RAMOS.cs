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
    public class RAMOS : VarBasis
    {
        /*"01  DCLRAMOS.*/
        public RAMOS_DCLRAMOS DCLRAMOS { get; set; } = new RAMOS_DCLRAMOS();

    }
}