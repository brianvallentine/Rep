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
    public class GE090_DCLGE_PRODUTO_PREMIO : VarBasis
    {
        /*"    10 GE090-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis GE090_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE090-SEQ-PRODUTO-VRS       PIC S9(4) USAGE COMP.*/
        public IntBasis GE090_SEQ_PRODUTO_VRS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE090-COD-OPC-COBERTURA       PIC X(1).*/
        public StringBasis GE090_COD_OPC_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE090-IND-CONJUGE    PIC X(1).*/
        public StringBasis GE090_IND_CONJUGE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE090-NUM-IDADE-INI  PIC S9(4) USAGE COMP.*/
        public IntBasis GE090_NUM_IDADE_INI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE090-NUM-IDADE-FIM  PIC S9(4) USAGE COMP.*/
        public IntBasis GE090_NUM_IDADE_FIM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE090-COD-OPC-PLANO  PIC S9(9) USAGE COMP.*/
        public IntBasis GE090_COD_OPC_PLANO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE090-VLR-INI-PREMIO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE090_VLR_INI_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE090-VLR-FIM-PREMIO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE090_VLR_FIM_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE090-PCT-IOF        PIC S9(3)V9(7) USAGE COMP-3.*/
        public DoubleBasis GE090_PCT_IOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(7)"), 7);
        /*"    10 GE090-PCT-REENQUADRAMENTO       PIC S9(3)V9(7) USAGE COMP-3.*/
        public DoubleBasis GE090_PCT_REENQUADRAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(7)"), 7);
        /*"    10 GE090-IND-PERMIT-VENDA       PIC X(1).*/
        public StringBasis GE090_IND_PERMIT_VENDA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}