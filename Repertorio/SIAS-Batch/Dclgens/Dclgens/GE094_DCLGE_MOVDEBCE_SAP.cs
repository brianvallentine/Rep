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
    public class GE094_DCLGE_MOVDEBCE_SAP : VarBasis
    {
        /*"    10 GE094-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis GE094_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 GE094-NUM-ENDOSSO    PIC S9(9) USAGE COMP.*/
        public IntBasis GE094_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE094-NUM-PARCELA    PIC S9(4) USAGE COMP.*/
        public IntBasis GE094_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE094-COD-CONVENIO   PIC S9(9) USAGE COMP.*/
        public IntBasis GE094_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE094-NSAS           PIC S9(4) USAGE COMP.*/
        public IntBasis GE094_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE094-NUM-OCORR-MOVTO       PIC S9(18)V USAGE COMP-3.*/
        public DoubleBasis GE094_NUM_OCORR_MOVTO { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(18)V"), 0);
        /*"    10 GE094-IDE-SISTEMA    PIC X(2).*/
        public StringBasis GE094_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE094-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE094_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}