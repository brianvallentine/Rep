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
    public class AU050_DCLAU_PROP_COBRNCA_VC : VarBasis
    {
        /*"    10 AU050-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis AU050_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 AU050-NUM-ENDOSSO    PIC S9(9) USAGE COMP.*/
        public IntBasis AU050_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AU050-NUM-PARCELA    PIC S9(4) USAGE COMP.*/
        public IntBasis AU050_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AU050-SEQ-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis AU050_SEQ_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AU050-OCORR-HISTORICO       PIC S9(4) USAGE COMP.*/
        public IntBasis AU050_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AU050-COD-OPERACAO   PIC S9(4) USAGE COMP.*/
        public IntBasis AU050_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AU050-VLR-PARCELA    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AU050_VLR_PARCELA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AU050-DTH-MOVIMENTO  PIC X(10).*/
        public StringBasis AU050_DTH_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 AU050-NUM-ARQUIVO    PIC S9(9) USAGE COMP.*/
        public IntBasis AU050_NUM_ARQUIVO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AU050-DTH-VENCTO-REPROG       PIC X(10).*/
        public StringBasis AU050_DTH_VENCTO_REPROG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 AU050-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis AU050_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 AU050-COD-CONGENERE  PIC S9(4) USAGE COMP.*/
        public IntBasis AU050_COD_CONGENERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}