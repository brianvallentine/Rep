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
    public class PF089 : VarBasis
    {
        /*"01  DCLPF-ERRO-PROC-PROPOSTA.*/
        public PF089_DCLPF_ERRO_PROC_PROPOSTA DCLPF_ERRO_PROC_PROPOSTA { get; set; } = new PF089_DCLPF_ERRO_PROC_PROPOSTA();

    }
}