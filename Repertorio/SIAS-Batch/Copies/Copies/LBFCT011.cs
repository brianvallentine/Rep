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
    public class LBFCT011 : VarBasis
    {
        /*"01      REG-HEADER-STA*/
        public LBFCT011_REG_HEADER_STA REG_HEADER_STA { get; set; } = new LBFCT011_REG_HEADER_STA();

        public LBFCT011_REG_STA_QUOTA REG_STA_QUOTA { get; set; } = new LBFCT011_REG_STA_QUOTA();

        public LBFCT011_REG_STA_PROPOSTA REG_STA_PROPOSTA { get; set; } = new LBFCT011_REG_STA_PROPOSTA();

        public LBFCT011_REG_TRAILLER_STA REG_TRAILLER_STA { get; set; } = new LBFCT011_REG_TRAILLER_STA();

    }
}