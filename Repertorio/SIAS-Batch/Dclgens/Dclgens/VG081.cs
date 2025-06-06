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
    public class VG081 : VarBasis
    {
        /*"01  DCLVG-PARAM-RAMO-COMP.*/
        public VG081_DCLVG_PARAM_RAMO_COMP DCLVG_PARAM_RAMO_COMP { get; set; } = new VG081_DCLVG_PARAM_RAMO_COMP();

    }
}