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
    public class VG077_DCLVG_INDICES : VarBasis
    {
        /*"    10 VG077-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis VG077_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 VG077-COD-SUBGRUPO   PIC S9(4) USAGE COMP.*/
        public IntBasis VG077_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG077-COD-MOEDA      PIC S9(4) USAGE COMP.*/
        public IntBasis VG077_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG077-DTH-INIVIGENCIA  PIC X(10).*/
        public StringBasis VG077_DTH_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG077-DTH-TERVIGENCIA  PIC X(10).*/
        public StringBasis VG077_DTH_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG077-COD-USUARIO    PIC X(8).*/
        public StringBasis VG077_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG077-DTH-CADASTRAMENTO  PIC X(26).*/
        public StringBasis VG077_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}