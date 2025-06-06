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
    public class PF090 : VarBasis
    {
        /*"01  DCLPF-PROC-PROPOSTA-HIST.*/
        public PF090_DCLPF_PROC_PROPOSTA_HIST DCLPF_PROC_PROPOSTA_HIST { get; set; } = new PF090_DCLPF_PROC_PROPOSTA_HIST();

    }
}