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
    public class VG098_DCLVG_CERTIFICADO_TITULO : VarBasis
    {
        /*"    10 VG098-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis VG098_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VG098-NUM-TITULO     PIC S9(9) USAGE COMP.*/
        public IntBasis VG098_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG098-NUM-SERIE      PIC S9(4) USAGE COMP.*/
        public IntBasis VG098_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG098-NUM-PLANO      PIC S9(4) USAGE COMP.*/
        public IntBasis VG098_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG098-COD-ACAO       PIC X(1).*/
        public StringBasis VG098_COD_ACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG098-COD-USUARIO    PIC X(8).*/
        public StringBasis VG098_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG098-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis VG098_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
    }
}