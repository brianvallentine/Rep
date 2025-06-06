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
    public class LBFPF026 : VarBasis
    {
        /*"01  REG-TIPO-C*/
        public LBFPF026_REG_TIPO_C REG_TIPO_C { get; set; } = new LBFPF026_REG_TIPO_C();

    }
}