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
    public class UNIDACEF : VarBasis
    {
        /*"01  DCLUNIDADE-CEF.*/
        public UNIDACEF_DCLUNIDADE_CEF DCLUNIDADE_CEF { get; set; } = new UNIDACEF_DCLUNIDADE_CEF();

    }
}