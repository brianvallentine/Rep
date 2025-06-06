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
    public class LBGE0530 : VarBasis
    {
        /*"01  LK-GE0530*/
        public LBGE0530_LK_GE0530 LK_GE0530 { get; set; } = new LBGE0530_LK_GE0530();

    }
}