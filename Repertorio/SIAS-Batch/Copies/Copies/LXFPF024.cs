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
    public class LXFPF024 : VarBasis
    {
        /*"01        REG-TIPO-B*/
        public LXFPF024_REG_TIPO_B REG_TIPO_B { get; set; } = new LXFPF024_REG_TIPO_B();

    }
}