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
    public class LBFPF012 : VarBasis
    {
        /*"01       REG-ENDERECO*/
        public LBFPF012_REG_ENDERECO REG_ENDERECO { get; set; } = new LBFPF012_REG_ENDERECO();

    }
}