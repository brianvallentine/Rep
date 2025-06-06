using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class GE0071W : VarBasis
    {
        /*" 01 LK-0071-E-TRACE                  PIC  X(001)*/
        public StringBasis LK_0071_E_TRACE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*" 01 LK-0071-E-COD-USUARIO            PIC  X(008)*/
        public StringBasis LK_0071_E_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*" 01 LK-0071-E-NOM-PROGRAMA           PIC  X(010)*/
        public StringBasis LK_0071_E_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*" 01 LK-0071-E-ACAO                   PIC S9(005) COMP-5*/
        public IntBasis LK_0071_E_ACAO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*" 01 LK-0071-I-COD-PRODUTO            PIC S9(005) COMP-5*/
        public IntBasis LK_0071_I_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*" 01 LK-0071-I-SEQ-PRODUTO-VRS        PIC S9(005) COMP-5*/
        public IntBasis LK_0071_I_SEQ_PRODUTO_VRS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*" 01 LK-0071-I-COD-OPC-COBERTURA      PIC  X(001)*/
        public StringBasis LK_0071_I_COD_OPC_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*" 01 LK-0071-I-COD-OPC-PLANO          PIC S9(009) COMP-5*/
        public IntBasis LK_0071_I_COD_OPC_PLANO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*" 01    LK-0071-I-COD-OPC-PLANO        PIC S9(009) COMP-5*/
        public IntBasis LK_0071_I_COD_OPC_PLANO_0 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*" 01 LK-0071-I-IND-CONJUGE            PIC  X(001)*/
        public StringBasis LK_0071_I_IND_CONJUGE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*" 01 LK-0071-I-NUM-IDADE              PIC S9(005) COMP-5*/
        public IntBasis LK_0071_I_NUM_IDADE { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*" 01    LK-0071-S-NUM-IDADE-INI        PIC S9(004) COMP-5*/
        public IntBasis LK_0071_S_NUM_IDADE_INI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 01    LK-0071-S-NUM-IDADE-FIM        PIC S9(004) COMP-5*/
        public IntBasis LK_0071_S_NUM_IDADE_FIM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 01    LK-0071-S-VLR-INI-PREMIO       PIC S9(013)V9(2) COMP-3*/
        public DoubleBasis LK_0071_S_VLR_INI_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*" 01    LK-0071-S-VLR-FIM-PREMIO       PIC S9(013)V9(2) COMP-3*/
        public DoubleBasis LK_0071_S_VLR_FIM_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*" 01    LK-0071-S-PCT-IOF              PIC S9(003)V9(7) COMP-3*/
        public DoubleBasis LK_0071_S_PCT_IOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(7)"), 7);
        /*" 01    LK-0071-S-PCT-REENQUADRAMENTO  PIC S9(003)V9(7) COMP-3*/
        public DoubleBasis LK_0071_S_PCT_REENQUADRAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(7)"), 7);
        /*" 01    LK-0071-S-IND-PERMIT-VENDA     PIC  X(001)*/
        public StringBasis LK_0071_S_IND_PERMIT_VENDA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*" 01    LK-0071-S-VLR-TOTAL-IS         PIC S9(013)V9(2) COMP-3*/
        public DoubleBasis LK_0071_S_VLR_TOTAL_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*" 01    LK-0071-S-QTD-OCC              PIC S9(004) COMP-5*/
        public IntBasis LK_0071_S_QTD_OCC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 01    LK-0071-S-ARR*/
        public GE0071W_LK_0071_S_ARR LK_0071_S_ARR { get; set; } = new GE0071W_LK_0071_S_ARR();

    }
}