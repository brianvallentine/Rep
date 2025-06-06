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
    public class PMONLK01 : VarBasis
    {
        /*"01  LK-:GE3000B:-PARAMETROS*/
        public PMONLK01_LK_GE3000B_PARAMETROS LK_GE3000B_PARAMETROS { get; set; } = new PMONLK01_LK_GE3000B_PARAMETROS();

    }
}