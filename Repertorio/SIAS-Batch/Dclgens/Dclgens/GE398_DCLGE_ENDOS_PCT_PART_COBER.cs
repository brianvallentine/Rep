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
    public class GE398_DCLGE_ENDOS_PCT_PART_COBER : VarBasis
    {
        /*"    10 GE398-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis GE398_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 GE398-NUM-ENDOSSO    PIC S9(9) USAGE COMP.*/
        public IntBasis GE398_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE398-COD-RAMO-COBER       PIC S9(4) USAGE COMP.*/
        public IntBasis GE398_COD_RAMO_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE398-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis GE398_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE398-COD-COSSEGURADORA       PIC S9(4) USAGE COMP.*/
        public IntBasis GE398_COD_COSSEGURADORA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE398-PCT-PARTIC-COBER       PIC S9(4)V9(5) USAGE COMP-3.*/
        public DoubleBasis GE398_PCT_PARTIC_COBER { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(5)"), 5);
        /*"    10 GE398-PCT-COMCOS-COBER       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE398_PCT_COMCOS_COBER { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 GE398-NOM-PROGRAMA   PIC X(8).*/
        public StringBasis GE398_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE398-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE398_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
    }
}