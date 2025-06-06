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
    public class GE369_DCLGE_MOVTO_CONTA : VarBasis
    {
        /*"    10 GE369-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis GE369_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 GE369-NUM-ENDOSSO    PIC S9(9) USAGE COMP.*/
        public IntBasis GE369_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE369-NUM-PARCELA    PIC S9(4) USAGE COMP.*/
        public IntBasis GE369_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE369-COD-CONVENIO   PIC S9(9) USAGE COMP.*/
        public IntBasis GE369_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE369-NSAS           PIC S9(4) USAGE COMP.*/
        public IntBasis GE369_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE369-COD-AGENCIA    PIC S9(4) USAGE COMP.*/
        public IntBasis GE369_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE369-COD-BANCO      PIC S9(4) USAGE COMP.*/
        public IntBasis GE369_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE369-NUM-CONTA-CNB  PIC X(20).*/
        public StringBasis GE369_NUM_CONTA_CNB { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 GE369-NUM-DV-CONTA-CNB  PIC X(3).*/
        public StringBasis GE369_NUM_DV_CONTA_CNB { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 GE369-IND-CONTA-BANCARIA  PIC S9(4) USAGE COMP.*/
        public IntBasis GE369_IND_CONTA_BANCARIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}