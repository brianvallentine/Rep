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
    public class VG093_DCLVG_REPRES_LEGAL : VarBasis
    {
        /*"    10 VG093-COD-PESSOA     PIC S9(9) USAGE COMP.*/
        public IntBasis VG093_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG093-NUM-OCORR-HIST       PIC S9(4) USAGE COMP.*/
        public IntBasis VG093_NUM_OCORR_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG093-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis VG093_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 VG093-COD-SUBGRUPO   PIC S9(4) USAGE COMP.*/
        public IntBasis VG093_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG093-VLR-RENDA      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VG093_VLR_RENDA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VG093-COD-TP-VINCULO       PIC S9(4) USAGE COMP.*/
        public IntBasis VG093_COD_TP_VINCULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG093-STA-REPRES-LEGAL       PIC X(1).*/
        public StringBasis VG093_STA_REPRES_LEGAL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG093-PCT-PARTICIPACAO       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis VG093_PCT_PARTICIPACAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 VG093-COD-USUARIO    PIC X(8).*/
        public StringBasis VG093_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG093-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis VG093_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG093-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis VG093_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}