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
    public class SIMOVSIN : VarBasis
    {
        /*"01  DCLSI-MOVIMENTO-SINI.*/
        public SIMOVSIN_DCLSI_MOVIMENTO_SINI DCLSI_MOVIMENTO_SINI { get; set; } = new SIMOVSIN_DCLSI_MOVIMENTO_SINI();

    }
}