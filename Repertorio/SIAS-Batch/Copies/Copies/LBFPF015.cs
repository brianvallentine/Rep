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
    public class LBFPF015 : VarBasis
    {
        /*"01       REG-INFORMACOES*/
        public LBFPF015_REG_INFORMACOES REG_INFORMACOES { get; set; } = new LBFPF015_REG_INFORMACOES();

    }
}