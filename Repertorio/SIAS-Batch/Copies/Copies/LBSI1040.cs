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
    public class LBSI1040 : VarBasis
    {
        /*"01 SI1040S-PARAMETROS*/
        public LBSI1040_SI1040S_PARAMETROS SI1040S_PARAMETROS { get; set; } = new LBSI1040_SI1040S_PARAMETROS();

    }
}