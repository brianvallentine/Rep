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
    public class LBLT3164_LT3164S_AREA_PARAMETROS : VarBasis
    {
        /*"  05       LT3164S-COD-PRODUTO           PIC  9(004)*/
        public IntBasis LT3164S_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"  05       LT3164S-NUM-APOLICE           PIC  9(013)*/
        public IntBasis LT3164S_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"  05       LT3164S-COD-CLIENTE           PIC  9(010)*/
        public IntBasis LT3164S_COD_CLIENTE { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
        /*"  05       LT3164S-COD-PROGRAMA          PIC  X(010)*/
        public StringBasis LT3164S_COD_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  05       LT3164S-TIPO-SOLICITACAO      PIC  9(001)*/
        public IntBasis LT3164S_TIPO_SOLICITACAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"  05       LT3164S-COD-USUARIO           PIC  X(010)*/
        public StringBasis LT3164S_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  05       LT3164S-SIT-SOLICITACAO       PIC  X(001)*/
        public StringBasis LT3164S_SIT_SOLICITACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"  05       LT3164S-PARAM-DATE01          PIC  X(010)*/
        public StringBasis LT3164S_PARAM_DATE01 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  05       LT3164S-PARAM-DATE02          PIC  X(010)*/
        public StringBasis LT3164S_PARAM_DATE02 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  05       LT3164S-PARAM-DATE03          PIC  X(010)*/
        public StringBasis LT3164S_PARAM_DATE03 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  05       LT3164S-PARAM-SMINT01         PIC  9(004)*/
        public IntBasis LT3164S_PARAM_SMINT01 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"  05       LT3164S-PARAM-SMINT02         PIC  9(004)*/
        public IntBasis LT3164S_PARAM_SMINT02 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"  05       LT3164S-PARAM-SMINT03         PIC  9(004)*/
        public IntBasis LT3164S_PARAM_SMINT03 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"  05       LT3164S-PARAM-INTG01          PIC  9(009)*/
        public IntBasis LT3164S_PARAM_INTG01 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"  05       LT3164S-PARAM-INTG02          PIC  9(009)*/
        public IntBasis LT3164S_PARAM_INTG02 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"  05       LT3164S-PARAM-INTG03          PIC  9(009)*/
        public IntBasis LT3164S_PARAM_INTG03 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"  05       LT3164S-PARAM-CHAR01          PIC  X(060)*/
        public StringBasis LT3164S_PARAM_CHAR01 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
        /*"  05       LT3164S-PARAM-CHAR02          PIC  X(030)*/
        public StringBasis LT3164S_PARAM_CHAR02 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"  05       LT3164S-PARAM-CHAR03          PIC  X(015)*/
        public StringBasis LT3164S_PARAM_CHAR03 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
        /*"  05       LT3164S-PARAM-CHAR04          PIC  X(015)*/
        public StringBasis LT3164S_PARAM_CHAR04 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
        /*"  05       LT3164S-PARAM-CHAR05          PIC  X(200)*/
        public StringBasis LT3164S_PARAM_CHAR05 { get; set; } = new StringBasis(new PIC("X", "200", "X(200)"), @"");
        /*"  05       LT3164S-COD-RETORNO           PIC  9(004)*/
        public IntBasis LT3164S_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"  05       LT3164S-MSG-RETORNO           PIC  X(100)*/
        public StringBasis LT3164S_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
    }
}