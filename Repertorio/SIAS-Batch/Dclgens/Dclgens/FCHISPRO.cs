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
    public class FCHISPRO : VarBasis
    {
        /*"01  DCLFC-HIST-PROPOSTA.*/
        public FCHISPRO_DCLFC_HIST_PROPOSTA DCLFC_HIST_PROPOSTA { get; set; } = new FCHISPRO_DCLFC_HIST_PROPOSTA();

    }
}