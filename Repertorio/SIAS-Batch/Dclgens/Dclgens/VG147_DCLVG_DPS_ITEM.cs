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
    public class VG147_DCLVG_DPS_ITEM : VarBasis
    {
        /*"    10 VG147-SEQ-DPS-ITEM   PIC S9(9) USAGE COMP.*/
        public IntBasis VG147_SEQ_DPS_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG147-NOM-DPS-ITEM   PIC X(80).*/
        public StringBasis VG147_NOM_DPS_ITEM { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
        /*"    10 VG147-IND-TP-ITEM    PIC X(1).*/
        public StringBasis VG147_IND_TP_ITEM { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG147-COD-USUARIO    PIC X(8).*/
        public StringBasis VG147_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG147-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis VG147_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG147-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis VG147_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}