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
    public class PF088_DCLPF_DET_ARQ_PROPOSTA : VarBasis
    {
        /*"    10 PF088-NUM-DET-ARQ-PROPOSTA       PIC S9(9) USAGE COMP.*/
        public IntBasis PF088_NUM_DET_ARQ_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PF088-NOM-DET-ARQ-PROPOSTA       PIC X(50).*/
        public StringBasis PF088_NOM_DET_ARQ_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
        /*"    10 PF088-DES-DET-ARQ-PROP.*/
        public PF088_PF088_DES_DET_ARQ_PROP PF088_DES_DET_ARQ_PROP { get; set; } = new PF088_PF088_DES_DET_ARQ_PROP();

    }
}