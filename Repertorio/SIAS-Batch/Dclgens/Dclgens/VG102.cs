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
    public class VG102 : VarBasis
    {
        /*"01  DCLVG-DM-MSG-CRITICA.*/
        public VG102_DCLVG_DM_MSG_CRITICA DCLVG_DM_MSG_CRITICA { get; set; } = new VG102_DCLVG_DM_MSG_CRITICA();

    }
}