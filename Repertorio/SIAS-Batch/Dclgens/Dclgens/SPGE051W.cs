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
    public class SPGE051W : VarBasis
    {
        /*"01 LK-GE051-TRACE                    PIC X(001)*/
        public StringBasis LK_GE051_TRACE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01 LK-GE051-NUM-CPF-CNPJ             PIC S9(18)  COMP*/
        public IntBasis LK_GE051_NUM_CPF_CNPJ { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"01 LK-GE051-S-QTD-CNTR-PREST         PIC S9(9)  COMP*/
        public IntBasis LK_GE051_S_QTD_CNTR_PREST { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01 LK-GE051-S-VLR-IS-ACUM-PREST      PIC S9(17)V9(2)  COMP-3*/
        public DoubleBasis LK_GE051_S_VLR_IS_ACUM_PREST { get; set; } = new DoubleBasis(new PIC("S9", "17", "S9(17)V9(2)"), 2);
        /*"01 LK-GE051-S-DTH-CAD-PREST          PIC X(26)*/
        public StringBasis LK_GE051_S_DTH_CAD_PREST { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"");
        /*"01 LK-GE051-S-QTD-CONTR-VIDA         PIC S9(9)  COMP*/
        public IntBasis LK_GE051_S_QTD_CONTR_VIDA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01 LK-GE051-S-VLR-IS-ACUM-VIDA       PIC S9(17)V9(2)  COMP-3*/
        public DoubleBasis LK_GE051_S_VLR_IS_ACUM_VIDA { get; set; } = new DoubleBasis(new PIC("S9", "17", "S9(17)V9(2)"), 2);
        /*"01 LK-GE051-S-DTH-CAD-VIDA           PIC X(26)*/
        public StringBasis LK_GE051_S_DTH_CAD_VIDA { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"");
        /*"01 LK-GE051-S-QTD-CNTR-PREV          PIC S9(9)  COMP*/
        public IntBasis LK_GE051_S_QTD_CNTR_PREV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01 LK-GE051-S-VLR-IS-ACUM-PREV       PIC S9(17)V9(2)  COMP-3*/
        public DoubleBasis LK_GE051_S_VLR_IS_ACUM_PREV { get; set; } = new DoubleBasis(new PIC("S9", "17", "S9(17)V9(2)"), 2);
        /*"01 LK-GE051-S-DTH-CAD-PREV           PIC X(26)*/
        public StringBasis LK_GE051_S_DTH_CAD_PREV { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"");
        /*"01 LK-GE051-S-QTD-CONTR-HABIT        PIC S9(9)  COMP*/
        public IntBasis LK_GE051_S_QTD_CONTR_HABIT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01 LK-GE051-S-VLR-IS-ACUM-HABIT      PIC S9(17)V9(2)  COMP-3*/
        public DoubleBasis LK_GE051_S_VLR_IS_ACUM_HABIT { get; set; } = new DoubleBasis(new PIC("S9", "17", "S9(17)V9(2)"), 2);
        /*"01 LK-GE051-S-DTH-CAD-HABIT          PIC X(26)*/
        public StringBasis LK_GE051_S_DTH_CAD_HABIT { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"");
        /*"01 LK-GE051-S-QTD-TOTAL-CNTR         PIC S9(9)  COMP*/
        public IntBasis LK_GE051_S_QTD_TOTAL_CNTR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01 LK-GE051-S-VLR-TOTAL-CNTR         PIC S9(17)V9(2)  COMP-3*/
        public DoubleBasis LK_GE051_S_VLR_TOTAL_CNTR { get; set; } = new DoubleBasis(new PIC("S9", "17", "S9(17)V9(2)"), 2);
        /*"01 LK-GE051-S-DTH-CADASTRAMENTO      PIC X(26)*/
        public StringBasis LK_GE051_S_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"");
        /*"01  LK-GE051-IND-ERRO                     PIC S9(004) COMP-5*/
        public IntBasis LK_GE051_IND_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-GE051-MSG-ERRO                     PIC  X(255)*/
        public StringBasis LK_GE051_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
        /*"01  LK-GE051-NOM-TABELA                   PIC  X(036)*/
        public StringBasis LK_GE051_NOM_TABELA { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
        /*"01  LK-GE051-SQLCODE                      PIC S9(004) COMP-5*/
        public IntBasis LK_GE051_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-GE051-SQLERRMC                     PIC  X(070)*/
        public StringBasis LK_GE051_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*"*/
    }
}