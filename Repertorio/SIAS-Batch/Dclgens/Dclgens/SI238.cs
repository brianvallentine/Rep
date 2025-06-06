using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class SI238 : VarBasis
    {
        /*"01  DCLSI-MOVTO-PGTO-COB-HIST.*/
        public SI238_DCLSI_MOVTO_PGTO_COB_HIST DCLSI_MOVTO_PGTO_COB_HIST { get; set; } = new SI238_DCLSI_MOVTO_PGTO_COB_HIST();

    }
}