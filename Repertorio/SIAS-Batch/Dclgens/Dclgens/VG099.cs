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
    public class VG099 : VarBasis
    {
        /*"01  DCLVG-DM-STA-CRITICA.*/
        public VG099_DCLVG_DM_STA_CRITICA DCLVG_DM_STA_CRITICA { get; set; } = new VG099_DCLVG_DM_STA_CRITICA();

    }
}