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
    public class LBFCT016 : VarBasis
    {
        /*"01      REG-APOL-SASSE*/
        public LBFCT016_REG_APOL_SASSE REG_APOL_SASSE { get; set; } = new LBFCT016_REG_APOL_SASSE();

        public LBFCT016_REG_COBER_SASSE REG_COBER_SASSE { get; set; } = new LBFCT016_REG_COBER_SASSE();

        public LBFCT016_REG_PGTO_SASSE REG_PGTO_SASSE { get; set; } = new LBFCT016_REG_PGTO_SASSE();

    }
}