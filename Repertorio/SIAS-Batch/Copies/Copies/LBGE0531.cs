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
    public class LBGE0531 : VarBasis
    {
        /*"01  LK-GE0531.*/
        public LBGE0531_LK_GE0531 LK_GE0531 { get; set; } = new LBGE0531_LK_GE0531();

    }
}