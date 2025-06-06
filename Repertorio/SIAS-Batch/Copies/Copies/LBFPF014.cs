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
    public class LBFPF014 : VarBasis
    {
        /*"01       REG-BENEFIC*/
        public LBFPF014_REG_BENEFIC REG_BENEFIC { get; set; } = new LBFPF014_REG_BENEFIC();

    }
}