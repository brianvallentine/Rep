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
    public class SINISACO : VarBasis
    {
        /*"01  DCLSINISTRO-ACOMPANHA.*/
        public SINISACO_DCLSINISTRO_ACOMPANHA DCLSINISTRO_ACOMPANHA { get; set; } = new SINISACO_DCLSINISTRO_ACOMPANHA();

    }
}