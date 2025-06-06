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
    public class AU057 : VarBasis
    {
        /*"01  DCLAU-PROP-CONV-VC.*/
        public AU057_DCLAU_PROP_CONV_VC DCLAU_PROP_CONV_VC { get; set; } = new AU057_DCLAU_PROP_CONV_VC();

    }
}