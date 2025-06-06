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
    public class LBSI1001 : VarBasis
    {
        /*"01        SI1001S-PARAMETROS*/
        public LBSI1001_SI1001S_PARAMETROS SI1001S_PARAMETROS { get; set; } = new LBSI1001_SI1001S_PARAMETROS();

    }
}