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
    public class SINISLAN : VarBasis
    {
        /*"01  DCLSINISTRO-LANCLOTE1.*/
        public SINISLAN_DCLSINISTRO_LANCLOTE1 DCLSINISTRO_LANCLOTE1 { get; set; } = new SINISLAN_DCLSINISTRO_LANCLOTE1();

    }
}