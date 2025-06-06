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
    public class GE091_DCLGE_PROD_PREMIO_COBER : VarBasis
    {
        /*"    10 GE091-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis GE091_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE091-SEQ-PRODUTO-VRS       PIC S9(4) USAGE COMP.*/
        public IntBasis GE091_SEQ_PRODUTO_VRS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE091-COD-OPC-COBERTURA       PIC X(1).*/
        public StringBasis GE091_COD_OPC_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE091-IND-CONJUGE    PIC X(1).*/
        public StringBasis GE091_IND_CONJUGE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE091-NUM-IDADE-INI  PIC S9(4) USAGE COMP.*/
        public IntBasis GE091_NUM_IDADE_INI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE091-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis GE091_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE091-NUM-IDADE-FIM  PIC S9(4) USAGE COMP.*/
        public IntBasis GE091_NUM_IDADE_FIM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE091-COD-OPC-PLANO  PIC S9(9) USAGE COMP.*/
        public IntBasis GE091_COD_OPC_PLANO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE091-VLR-IS         PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE091_VLR_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE091-VLR-PREMIO     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE091_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE091-PCT-PARTICIPACAO       PIC S9(3)V9(7) USAGE COMP-3.*/
        public DoubleBasis GE091_PCT_PARTICIPACAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(7)"), 7);
        /*"*/
    }
}