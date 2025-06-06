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
    public class LBFPF991 : VarBasis
    {
        /*"01       REG-TRAILLER*/
        public LBFPF991_REG_TRAILLER REG_TRAILLER { get; set; } = new LBFPF991_REG_TRAILLER();

    }
}