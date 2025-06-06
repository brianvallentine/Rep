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
    public class SPVG009W : VarBasis
    {
        /*"01  LK-VG009-E-TRACE                  PIC  X(001)*/
        public StringBasis LK_VG009_E_TRACE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  LK-VG009-E-COD-USUARIO            PIC  X(008)*/
        public StringBasis LK_VG009_E_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  LK-VG009-E-NOM-PROGRAMA           PIC  X(010)*/
        public StringBasis LK_VG009_E_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-VG009-E-TIPO-ACAO              PIC S9(004) COMP-5*/
        public IntBasis LK_VG009_E_TIPO_ACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG009-E-NUM-PROPOSTA           PIC S9(018) COMP-5*/
        public IntBasis LK_VG009_E_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"01  LK-VG009-S-COD-PESSOA            PIC S9(009) COMP-5*/
        public IntBasis LK_VG009_S_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  LK-VG009-S-SEQ-PESSOA-HIST       PIC S9(009) COMP-5*/
        public IntBasis LK_VG009_S_SEQ_PESSOA_HIST { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  LK-VG009-S-COD-CLASSIF-RISCO     PIC S9(004) COMP-5*/
        public IntBasis LK_VG009_S_COD_CLASSIF_RISCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG009-S-NUM-SCORE-RISCO       PIC S9(004) COMP-5*/
        public IntBasis LK_VG009_S_NUM_SCORE_RISCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG009-S-DTA-CLASSIF-RISCO     PIC  X(010)*/
        public StringBasis LK_VG009_S_DTA_CLASSIF_RISCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-VG009-S-IND-PEND-APROVACAO    PIC  X(001)*/
        public StringBasis LK_VG009_S_IND_PEND_APROVACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  LK-VG009-S-IND-DECL-AUTOMATICO   PIC  X(001)*/
        public StringBasis LK_VG009_S_IND_DECL_AUTOMATICO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  LK-VG009-S-IND-ATLZ-FXA-RISCO    PIC  X(001)*/
        public StringBasis LK_VG009_S_IND_ATLZ_FXA_RISCO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  LK-VG009-IND-ERRO                PIC S9(004) COMP-5*/
        public IntBasis LK_VG009_IND_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG009-MSG-ERRO                PIC  X(255)*/
        public StringBasis LK_VG009_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
        /*"01  LK-VG009-NOM-TABELA              PIC  X(036)*/
        public StringBasis LK_VG009_NOM_TABELA { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
        /*"01  LK-VG009-SQLCODE                 PIC S9(004) COMP-5*/
        public IntBasis LK_VG009_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG009-SQLERRMC                PIC  X(070)*/
        public StringBasis LK_VG009_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*"*/
    }
}