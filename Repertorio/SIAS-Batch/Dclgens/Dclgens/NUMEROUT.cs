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
    public class NUMEROUT : VarBasis
    {
        /*"01  DCLNUMERO-OUTROS.*/
        public NUMEROUT_DCLNUMERO_OUTROS DCLNUMERO_OUTROS { get; set; } = new NUMEROUT_DCLNUMERO_OUTROS();

    }
}