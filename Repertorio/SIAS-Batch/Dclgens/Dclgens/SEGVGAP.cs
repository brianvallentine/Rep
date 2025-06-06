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
    public class SEGVGAP : VarBasis
    {
        /*"01  DCLSEGURADOS-VGAP.*/
        public SEGVGAP_DCLSEGURADOS_VGAP DCLSEGURADOS_VGAP { get; set; } = new SEGVGAP_DCLSEGURADOS_VGAP();

    }
}