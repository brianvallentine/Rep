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
    public class VG110_DCLVG_C612_RELAC_PROPOSTA : VarBasis
    {
        /*"    10 VG110-COD-PESSOA     PIC S9(9) USAGE COMP.*/
        public IntBasis VG110_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG110-SEQ-PESSOA-HIST       PIC S9(9) USAGE COMP.*/
        public IntBasis VG110_SEQ_PESSOA_HIST { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG110-SEQ-REMESSA    PIC S9(9) USAGE COMP.*/
        public IntBasis VG110_SEQ_REMESSA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG110-NUM-PROPOSTA   PIC S9(18) USAGE COMP.*/
        public IntBasis VG110_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 VG110-IND-TP-PROPOSTA       PIC X(1).*/
        public StringBasis VG110_IND_TP_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}