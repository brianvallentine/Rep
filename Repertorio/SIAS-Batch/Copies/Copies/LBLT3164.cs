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
    public class LBLT3164 : VarBasis
    {
        /*"01       LT3164S-AREA-PARAMETROS*/
        public LBLT3164_LT3164S_AREA_PARAMETROS LT3164S_AREA_PARAMETROS { get; set; } = new LBLT3164_LT3164S_AREA_PARAMETROS();

    }
}