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
    public class SZEMWL01_H_SZL01_SZEMNL01 : VarBasis
    {
        /*"  10   H-SZL01-COD-USUARIO            PIC X(008)*/
        public StringBasis H_SZL01_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"  10   H-SZL01-COD-PROGRAMA           PIC X(010)*/
        public StringBasis H_SZL01_COD_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  10   H-SZL01-DES-MSG-SISTEMA*/
        public SZEMWL01_H_SZL01_DES_MSG_SISTEMA H_SZL01_DES_MSG_SISTEMA { get; set; } = new SZEMWL01_H_SZL01_DES_MSG_SISTEMA();

        public IntBasis H_SZL01_IND_ERRO_LOG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  10   H-SZL01-SQLCODE-LOG            PIC S9(009) COMP*/
        public IntBasis H_SZL01_SQLCODE_LOG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"  10   H-SZL01-SQLERRMC-LOG           PIC X(070)*/
        public StringBasis H_SZL01_SQLERRMC_LOG { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*"  10   H-SZL01-DES-MSG-RETORNO        PIC X(133)*/
        public StringBasis H_SZL01_DES_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "133", "X(133)"), @"");
        /*"  10   H-SZL01-SEQ-LOG-SISTEMA        PIC S9(018) COMP*/
        public IntBasis H_SZL01_SEQ_LOG_SISTEMA { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"  10   H-SZL01-IND-ERRO               PIC S9(004) COMP*/
        public IntBasis H_SZL01_IND_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  10   H-SZL01-MSG-RET                PIC X(133)*/
        public StringBasis H_SZL01_MSG_RET { get; set; } = new StringBasis(new PIC("X", "133", "X(133)"), @"");
        /*"  10   H-SZL01-NM-TAB                 PIC X(030)*/
        public StringBasis H_SZL01_NM_TAB { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"  10   H-SZL01-SQLCODE                PIC S9(009) COMP*/
        public IntBasis H_SZL01_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"  10   H-SZL01-SQLERRMC               PIC X(070)*/
        public StringBasis H_SZL01_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*"01     N-SZL01-SZEMNL01*/
    }
}