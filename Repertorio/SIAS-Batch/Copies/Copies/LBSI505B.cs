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
    public class LBSI505B : VarBasis
    {
        /*"01 SI0505B-PARAMETROS*/
        public LBSI505B_SI0505B_PARAMETROS SI0505B_PARAMETROS { get; set; } = new LBSI505B_SI0505B_PARAMETROS();

    }
}