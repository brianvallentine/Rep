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
    public class LBFPF011 : VarBasis
    {
        /*"01       REG-CLIENTES*/
        public LBFPF011_REG_CLIENTES REG_CLIENTES { get; set; } = new LBFPF011_REG_CLIENTES();

    }
}