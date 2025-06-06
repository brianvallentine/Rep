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
    public class LBFPF010 : VarBasis
    {
        /*"01  REG-VENDAS*/
        public LBFPF010_REG_VENDAS REG_VENDAS { get; set; } = new LBFPF010_REG_VENDAS();

    }
}