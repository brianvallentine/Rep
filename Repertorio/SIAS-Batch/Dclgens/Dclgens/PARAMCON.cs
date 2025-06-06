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
    public class PARAMCON : VarBasis
    {
        /*"01  DCLPARAM-CONTACEF.*/
        public PARAMCON_DCLPARAM_CONTACEF DCLPARAM_CONTACEF { get; set; } = new PARAMCON_DCLPARAM_CONTACEF();

    }
}