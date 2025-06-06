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
    public class SPVG014W_LK_VG014_NULL : VarBasis
    {
        /*" 05 NU-VG014-E-TRACE                 PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_E_TRACE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-E-IDE-SISTEMA           PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_E_IDE_SISTEMA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-E-NUM-CERTIFICADO       PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_E_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-E-COD-PRODUTO           PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_E_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-E-COD-PLANO             PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_E_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-E-NUM-SERIE             PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_E_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-E-NUM-TITULO            PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_E_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-E-COD-USUARIO           PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_E_COD_USUARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-E-NOM-PROGRAMA          PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_E_NOM_PROGRAMA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-E-TIPO-ACAO             PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_E_TIPO_ACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-I-STA-TITULO            PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_I_STA_TITULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-I-COD-SUB-TITULO        PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_I_COD_SUB_TITULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-I-DTA-INI-VIGENCIA      PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_I_DTA_INI_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-I-DTA-FIM-VIGENCIA      PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_I_DTA_FIM_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-I-DTH-CRIACAO           PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_I_DTH_CRIACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-I-DTA-INI-SORTEIO       PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_I_DTA_INI_SORTEIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-I-DTH-ATIVACAO          PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_I_DTH_ATIVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-I-DTA-SUSPENSAO         PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_I_DTA_SUSPENSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-I-DTA-CADUCACAO         PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_I_DTA_CADUCACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-I-COD-DV                PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_I_COD_DV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-I-VLR-MENSALIDADE       PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_I_VLR_MENSALIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-I-NUM-MOD-PLANO         PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_I_NUM_MOD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-I-DES-COMBINACAO        PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_I_DES_COMBINACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-I-DTH-CADASTRAMENTO     PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_I_DTH_CADASTRAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-IND-ERRO                PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_IND_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-MENSAGEM                PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_MENSAGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-NOM-TABELA              PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_NOM_TABELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-SQLCODE                 PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-SQLERRMC                PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_SQLERRMC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 05 NU-VG014-SQLSTATE                PIC S9(004) COMP-5*/
        public IntBasis NU_VG014_SQLSTATE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"*/
    }
}