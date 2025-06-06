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
    public class LBLT3151 : VarBasis
    {
        /*"01  LT3151-AREA-PARAMETROS*/
        public LBLT3151_LT3151_AREA_PARAMETROS LT3151_AREA_PARAMETROS { get; set; } = new LBLT3151_LT3151_AREA_PARAMETROS();

    }
}