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
    public class AU055 : VarBasis
    {
        /*"01  DCLAU-HIS-PROP-CONV.*/
        public AU055_DCLAU_HIS_PROP_CONV DCLAU_HIS_PROP_CONV { get; set; } = new AU055_DCLAU_HIS_PROP_CONV();

    }
}