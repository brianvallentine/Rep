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
    public class PLANOVID : VarBasis
    {
        /*"01  DCLPLANOS-VIDAZUL.*/
        public PLANOVID_DCLPLANOS_VIDAZUL DCLPLANOS_VIDAZUL { get; set; } = new PLANOVID_DCLPLANOS_VIDAZUL();

    }
}