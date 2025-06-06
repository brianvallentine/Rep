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
    public class RTPRELAC : VarBasis
    {
        /*"01  DCLR-PESSOA-TIPORELAC.*/
        public RTPRELAC_DCLR_PESSOA_TIPORELAC DCLR_PESSOA_TIPORELAC { get; set; } = new RTPRELAC_DCLR_PESSOA_TIPORELAC();

    }
}