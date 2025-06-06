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
    public class BENPROPZ : VarBasis
    {
        /*"01  DCLBENEF-PROP-AZUL.*/
        public BENPROPZ_DCLBENEF_PROP_AZUL DCLBENEF_PROP_AZUL { get; set; } = new BENPROPZ_DCLBENEF_PROP_AZUL();

    }
}