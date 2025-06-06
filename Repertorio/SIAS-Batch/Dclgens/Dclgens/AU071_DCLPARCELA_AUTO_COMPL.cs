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
    public class AU071_DCLPARCELA_AUTO_COMPL : VarBasis
    {
        /*"    10 AU071-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis AU071_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 AU071-NUM-ENDOSSO    PIC S9(9) USAGE COMP.*/
        public IntBasis AU071_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AU071-NUM-PARCELA    PIC S9(4) USAGE COMP.*/
        public IntBasis AU071_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AU071-DTA-VENCTO     PIC X(10).*/
        public StringBasis AU071_DTA_VENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 AU071-NUM-VENCTO     PIC S9(4) USAGE COMP.*/
        public IntBasis AU071_NUM_VENCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AU071-VLR-PREMIO-LIQUIDO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AU071_VLR_PREMIO_LIQUIDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AU071-VLR-JUROS      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AU071_VLR_JUROS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AU071-VLR-ADIC-FRAC  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AU071_VLR_ADIC_FRAC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AU071-VLR-MULTA      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AU071_VLR_MULTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AU071-VLR-CUSTO      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AU071_VLR_CUSTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AU071-VLR-IOF        PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AU071_VLR_IOF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AU071-VLR-PREMIO-TOTAL       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AU071_VLR_PREMIO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AU071-NUM-RECIBO-CONV       PIC S9(18)V USAGE COMP-3.*/
        public DoubleBasis AU071_NUM_RECIBO_CONV { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(18)V"), 0);
        /*"    10 AU071-COD-USUARIO    PIC X(8).*/
        public StringBasis AU071_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 AU071-DTH-TIMESTAMP  PIC X(26).*/
        public StringBasis AU071_DTH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}