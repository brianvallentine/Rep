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
    public class LBSI1000 : VarBasis
    {
        /*"01        SI1000S-PARAMETROS*/
        public LBSI1000_SI1000S_PARAMETROS SI1000S_PARAMETROS { get; set; } = new LBSI1000_SI1000S_PARAMETROS();

    }
}