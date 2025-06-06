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
    public class LXFCT004 : VarBasis
    {
        /*"01         REG-PROPOSTA-SASSE*/
        public LXFCT004_REG_PROPOSTA_SASSE REG_PROPOSTA_SASSE { get; set; } = new LXFCT004_REG_PROPOSTA_SASSE();

    }
}