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
    public class LBLT2118 : VarBasis
    {
        /*"01       LT2118S-AREA-PARAMETROS*/
        public LBLT2118_LT2118S_AREA_PARAMETROS LT2118S_AREA_PARAMETROS { get; set; } = new LBLT2118_LT2118S_AREA_PARAMETROS();

    }
}