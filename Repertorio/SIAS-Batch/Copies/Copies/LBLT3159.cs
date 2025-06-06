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
    public class LBLT3159 : VarBasis
    {
        /*"01       LT3159S-AREA-PARAMETROS*/
        public LBLT3159_LT3159S_AREA_PARAMETROS LT3159S_AREA_PARAMETROS { get; set; } = new LBLT3159_LT3159S_AREA_PARAMETROS();

    }
}