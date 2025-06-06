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
    public class LXFPF028 : VarBasis
    {
        /*"01       REG-TIPO-D*/
        public LXFPF028_REG_TIPO_D REG_TIPO_D { get; set; } = new LXFPF028_REG_TIPO_D();

    }
}