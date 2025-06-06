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
    public class AGEAPOVG : VarBasis
    {
        /*"01  DCLAGENCTO-APOL-VGAP.*/
        public AGEAPOVG_DCLAGENCTO_APOL_VGAP DCLAGENCTO_APOL_VGAP { get; set; } = new AGEAPOVG_DCLAGENCTO_APOL_VGAP();

    }
}