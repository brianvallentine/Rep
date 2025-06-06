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
    public class PF062_DCLPF_CBO : VarBasis
    {
        /*"    10 PF062-NUM-PROPOSTA-SIVPF  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PF062_NUM_PROPOSTA_SIVPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PF062-COD-CBO        PIC S9(9) USAGE COMP.*/
        public IntBasis PF062_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PF062-DES-CBO        PIC X(50).*/
        public StringBasis PF062_DES_CBO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
        /*"*/
    }
}