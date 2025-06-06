using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBCS0701 : VarBasis
    {
        /*"01       CS0701S-AREA-PARAMETROS*/
        public LBCS0701_CS0701S_AREA_PARAMETROS CS0701S_AREA_PARAMETROS { get; set; } = new LBCS0701_CS0701S_AREA_PARAMETROS();

    }
}