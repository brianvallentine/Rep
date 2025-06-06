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
    public class PF087 : VarBasis
    {
        /*"01  DCLPF-PROC-PROPOSTA.*/
        public PF087_DCLPF_PROC_PROPOSTA DCLPF_PROC_PROPOSTA { get; set; } = new PF087_DCLPF_PROC_PROPOSTA();

    }
}