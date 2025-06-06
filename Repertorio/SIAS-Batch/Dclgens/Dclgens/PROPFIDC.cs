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
    public class PROPFIDC : VarBasis
    {
        /*"01  DCLPROP-FIDELIZ-COMP.*/
        public PROPFIDC_DCLPROP_FIDELIZ_COMP DCLPROP_FIDELIZ_COMP { get; set; } = new PROPFIDC_DCLPROP_FIDELIZ_COMP();

    }
}