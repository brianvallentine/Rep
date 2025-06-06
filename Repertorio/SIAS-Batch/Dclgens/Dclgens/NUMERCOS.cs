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
    public class NUMERCOS : VarBasis
    {
        /*"01  DCLNUMERO-COSSEGURO.*/
        public NUMERCOS_DCLNUMERO_COSSEGURO DCLNUMERO_COSSEGURO { get; set; } = new NUMERCOS_DCLNUMERO_COSSEGURO();

    }
}