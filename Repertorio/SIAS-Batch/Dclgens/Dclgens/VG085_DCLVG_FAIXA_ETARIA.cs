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
    public class VG085_DCLVG_FAIXA_ETARIA : VarBasis
    {
        /*"    10 VG085-SEQ-FAIXA-ETARIA       PIC S9(4) USAGE COMP.*/
        public IntBasis VG085_SEQ_FAIXA_ETARIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG085-NUM-FAIXA-INICIAL       PIC S9(4) USAGE COMP.*/
        public IntBasis VG085_NUM_FAIXA_INICIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG085-NUM-FAIXA-FINAL       PIC S9(4) USAGE COMP.*/
        public IntBasis VG085_NUM_FAIXA_FINAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG085-COD-USUARIO    PIC X(10).*/
        public StringBasis VG085_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG085-DTH-ATUALIZACAO       PIC X(26).*/
        public StringBasis VG085_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}