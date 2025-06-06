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
    public class GE397_DCLGE_ENDOS_COSSEG_COBER : VarBasis
    {
        /*"    10 GE397-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis GE397_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 GE397-NUM-ENDOSSO    PIC S9(9) USAGE COMP.*/
        public IntBasis GE397_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE397-COD-RAMO-COBER       PIC S9(4) USAGE COMP.*/
        public IntBasis GE397_COD_RAMO_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE397-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis GE397_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE397-VLR-IMP-SEGUR-VAR       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE397_VLR_IMP_SEGUR_VAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE397-VLR-PREMIO-TARIF-VAR       PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis GE397_VLR_PREMIO_TARIF_VAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 GE397-NOM-PROGRAMA   PIC X(8).*/
        public StringBasis GE397_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE397-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE397_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}