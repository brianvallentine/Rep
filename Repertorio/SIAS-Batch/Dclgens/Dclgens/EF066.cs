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
    public class EF066 : VarBasis
    {
        /*"01  DCLEF-PREMIO-EMITIDO.*/
        public EF066_DCLEF_PREMIO_EMITIDO DCLEF_PREMIO_EMITIDO { get; set; } = new EF066_DCLEF_PREMIO_EMITIDO();

    }
}