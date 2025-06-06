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
    public class SINISAUT : VarBasis
    {
        /*"01  DCLSINISTRO-AUTO1.*/
        public SINISAUT_DCLSINISTRO_AUTO1 DCLSINISTRO_AUTO1 { get; set; } = new SINISAUT_DCLSINISTRO_AUTO1();

    }
}