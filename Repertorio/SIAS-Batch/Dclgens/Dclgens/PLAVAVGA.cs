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
    public class PLAVAVGA : VarBasis
    {
        /*"01  DCLPLANOS-VA-VGAP.*/
        public PLAVAVGA_DCLPLANOS_VA_VGAP DCLPLANOS_VA_VGAP { get; set; } = new PLAVAVGA_DCLPLANOS_VA_VGAP();

    }
}