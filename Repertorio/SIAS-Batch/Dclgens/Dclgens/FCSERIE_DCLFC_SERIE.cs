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
    public class FCSERIE_DCLFC_SERIE : VarBasis
    {
        /*"    10 FCSERIE-NUM-PLANO    PIC S9(4) USAGE COMP.*/
        public IntBasis FCSERIE_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCSERIE-NUM-SERIE    PIC S9(4) USAGE COMP.*/
        public IntBasis FCSERIE_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCSERIE-DTH-ASSOCIACAO  PIC X(10).*/
        public StringBasis FCSERIE_DTH_ASSOCIACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FCSERIE-IDE-SERIEPADRAO  PIC S9(4) USAGE COMP.*/
        public IntBasis FCSERIE_IDE_SERIEPADRAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCSERIE-NUM-TIT-ULT-EMIT  PIC S9(9) USAGE COMP.*/
        public IntBasis FCSERIE_NUM_TIT_ULT_EMIT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCSERIE-NUM-TIT-ULT-SOLIC  PIC S9(9) USAGE COMP.*/
        public IntBasis FCSERIE_NUM_TIT_ULT_SOLIC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}