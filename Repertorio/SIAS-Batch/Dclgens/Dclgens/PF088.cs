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
    public class PF088 : VarBasis
    {
        /*"01  DCLPF-DET-ARQ-PROPOSTA.*/
        public PF088_DCLPF_DET_ARQ_PROPOSTA DCLPF_DET_ARQ_PROPOSTA { get; set; } = new PF088_DCLPF_DET_ARQ_PROPOSTA();

    }
}