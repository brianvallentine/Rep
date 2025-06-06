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
    public class OD009 : VarBasis
    {
        /*"01  DCLOD-PESS-CONTA-BANC.*/
        public OD009_DCLOD_PESS_CONTA_BANC DCLOD_PESS_CONTA_BANC { get; set; } = new OD009_DCLOD_PESS_CONTA_BANC();

    }
}