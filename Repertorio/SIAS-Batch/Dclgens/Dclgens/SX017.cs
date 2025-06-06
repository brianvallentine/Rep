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
    public class SX017 : VarBasis
    {
        /*"01  DCLSX-PRODUTO.*/
        public SX017_DCLSX_PRODUTO DCLSX_PRODUTO { get; set; } = new SX017_DCLSX_PRODUTO();

    }
}