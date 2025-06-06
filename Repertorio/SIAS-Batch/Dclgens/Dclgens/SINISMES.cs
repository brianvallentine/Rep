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
    public class SINISMES : VarBasis
    {
        /*"01  DCLSINISTRO-MESTRE.*/
        public SINISMES_DCLSINISTRO_MESTRE DCLSINISTRO_MESTRE { get; set; } = new SINISMES_DCLSINISTRO_MESTRE();

    }
}