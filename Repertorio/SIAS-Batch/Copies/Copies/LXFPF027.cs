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
    public class LXFPF027 : VarBasis
    {
        /*"01    REG-TIPO-W*/
        public LXFPF027_REG_TIPO_W REG_TIPO_W { get; set; } = new LXFPF027_REG_TIPO_W();

    }
}