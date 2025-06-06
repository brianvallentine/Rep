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
    public class VG145_DCLVG_DPS_REGRA : VarBasis
    {
        /*"    10 VG145-SEQ-DPS-REGRA  PIC S9(9) USAGE COMP.*/
        public IntBasis VG145_SEQ_DPS_REGRA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG145-NOM-DPS-REGRA  PIC X(80).*/
        public StringBasis VG145_NOM_DPS_REGRA { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
        /*"    10 VG145-IND-TP-REGRA   PIC X(1).*/
        public StringBasis VG145_IND_TP_REGRA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG145-COD-USUARIO    PIC X(8).*/
        public StringBasis VG145_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG145-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis VG145_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG145-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis VG145_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}