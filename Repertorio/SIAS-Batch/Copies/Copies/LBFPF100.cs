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
    public class LBFPF100 : VarBasis
    {
        /*"01       REG-DIVERSOS-VE*/
        public LBFPF100_REG_DIVERSOS_VE REG_DIVERSOS_VE { get; set; } = new LBFPF100_REG_DIVERSOS_VE();

    }
}