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
    public class LBLT3201 : VarBasis
    {
        /*"01  LT3201-AREA-PARAMETROS*/
        public LBLT3201_LT3201_AREA_PARAMETROS LT3201_AREA_PARAMETROS { get; set; } = new LBLT3201_LT3201_AREA_PARAMETROS();

    }
}