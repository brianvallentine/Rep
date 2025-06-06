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
    public class VG141_DCLVG_DPS_REGRA_ITEM : VarBasis
    {
        /*"    10 VG141-SEQ-DPS-REGRA  PIC S9(9) USAGE COMP.*/
        public IntBasis VG141_SEQ_DPS_REGRA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG141-SEQ-DPS-ITEM   PIC S9(9) USAGE COMP.*/
        public IntBasis VG141_SEQ_DPS_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG141-VLR-NUMR-INICIAL       PIC S9(12)V9(5) USAGE COMP-3.*/
        public DoubleBasis VG141_VLR_NUMR_INICIAL { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(12)V9(5)"), 5);
        /*"    10 VG141-VLR-NUMR-FINAL       PIC S9(12)V9(5) USAGE COMP-3.*/
        public DoubleBasis VG141_VLR_NUMR_FINAL { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(12)V9(5)"), 5);
        /*"    10 VG141-VLR-ALFA-INICIAL       PIC X(50).*/
        public StringBasis VG141_VLR_ALFA_INICIAL { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
        /*"    10 VG141-VLR-ALFA-FINAL       PIC X(50).*/
        public StringBasis VG141_VLR_ALFA_FINAL { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
        /*"    10 VG141-COD-TP-COMPARACAO       PIC X(2).*/
        public StringBasis VG141_COD_TP_COMPARACAO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 VG141-COD-USUARIO    PIC X(8).*/
        public StringBasis VG141_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG141-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis VG141_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG141-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis VG141_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}