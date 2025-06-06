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
    public class MALHACEF : VarBasis
    {
        /*"01  DCLMALHA-CEF.*/
        public MALHACEF_DCLMALHA_CEF DCLMALHA_CEF { get; set; } = new MALHACEF_DCLMALHA_CEF();

    }
}