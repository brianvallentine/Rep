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
    public class SZEMWL01_N_SZL01_SZEMNL01 : VarBasis
    {
        /*"  10   N-SZL01-COD-USUARIO            PIC S9(004) COMP*/
        public IntBasis N_SZL01_COD_USUARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  10   N-SZL01-COD-PROGRAMA           PIC S9(004) COMP*/
        public IntBasis N_SZL01_COD_PROGRAMA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  10   N-SZL01-DES-MSG-SISTEMA        PIC S9(004) COMP*/
        public IntBasis N_SZL01_DES_MSG_SISTEMA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  10   N-SZL01-IND-ERRO-LOG           PIC S9(004) COMP*/
        public IntBasis N_SZL01_IND_ERRO_LOG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  10   N-SZL01-SQLCODE-LOG            PIC S9(004) COMP*/
        public IntBasis N_SZL01_SQLCODE_LOG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  10   N-SZL01-SQLERRMC-LOG           PIC S9(004) COMP*/
        public IntBasis N_SZL01_SQLERRMC_LOG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  10   N-SZL01-DES-MSG-RETORNO        PIC S9(004) COMP*/
        public IntBasis N_SZL01_DES_MSG_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  10   N-SZL01-SEQ-LOG-SISTEMA        PIC S9(004) COMP*/
        public IntBasis N_SZL01_SEQ_LOG_SISTEMA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  10   N-SZL01-IND-ERRO               PIC S9(004) COMP*/
        public IntBasis N_SZL01_IND_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  10   N-SZL01-MSG-RET                PIC S9(004) COMP*/
        public IntBasis N_SZL01_MSG_RET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  10   N-SZL01-NM-TAB                 PIC S9(004) COMP*/
        public IntBasis N_SZL01_NM_TAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  10   N-SZL01-SQLCODE                PIC S9(004) COMP*/
        public IntBasis N_SZL01_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  10   N-SZL01-SQLERRMC               PIC S9(004) COMP*/
        public IntBasis N_SZL01_SQLERRMC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"*/
    }
}