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
    public class LBSI0202 : VarBasis
    {
        /*"01 SI0202S-PARAMETROS*/
        public LBSI0202_SI0202S_PARAMETROS SI0202S_PARAMETROS { get; set; } = new LBSI0202_SI0202S_PARAMETROS();

    }
}