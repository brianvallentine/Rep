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
    public class PF089_DCLPF_ERRO_PROC_PROPOSTA : VarBasis
    {
        /*"    10 PF089-NUM-ERRO-PROPOSTA       PIC S9(4) USAGE COMP.*/
        public IntBasis PF089_NUM_ERRO_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PF089-DES-ERRO-PROPOSTA.*/
        public PF089_PF089_DES_ERRO_PROPOSTA PF089_DES_ERRO_PROPOSTA { get; set; } = new PF089_PF089_DES_ERRO_PROPOSTA();

    }
}