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
    public class LBLT3250 : VarBasis
    {
        /*"01       LT3250-AREA-PARAMETROS*/
        public LBLT3250_LT3250_AREA_PARAMETROS LT3250_AREA_PARAMETROS { get; set; } = new LBLT3250_LT3250_AREA_PARAMETROS();

    }
}