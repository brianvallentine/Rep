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
    public class SPVG014W : VarBasis
    {
        /*"01  LK-VG014-E-TRACE                 PIC  X(001)*/
        public StringBasis LK_VG014_E_TRACE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  LK-VG014-E-IDE-SISTEMA           PIC  X(002)*/
        public StringBasis LK_VG014_E_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"01  LK-VG014-E-NUM-CERTIFICADO       PIC S9(018) COMP-5*/
        public IntBasis LK_VG014_E_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"01  LK-VG014-E-COD-PRODUTO           PIC S9(004) COMP-5*/
        public IntBasis LK_VG014_E_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG014-E-COD-PLANO             PIC S9(004) COMP-5*/
        public IntBasis LK_VG014_E_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG014-E-NUM-SERIE             PIC S9(004) COMP-5*/
        public IntBasis LK_VG014_E_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG014-E-NUM-TITULO            PIC S9(009) COMP-5*/
        public IntBasis LK_VG014_E_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  LK-VG014-E-COD-USUARIO           PIC  X(008)*/
        public StringBasis LK_VG014_E_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  LK-VG014-E-NOM-PROGRAMA          PIC  X(010)*/
        public StringBasis LK_VG014_E_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-VG014-E-TIPO-ACAO             PIC S9(004) COMP-5*/
        public IntBasis LK_VG014_E_TIPO_ACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG014-I-STA-TITULO            PIC  X(003)*/
        public StringBasis LK_VG014_I_STA_TITULO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01  LK-VG014-I-COD-SUB-TITULO        PIC  X(003)*/
        public StringBasis LK_VG014_I_COD_SUB_TITULO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01  LK-VG014-I-DTA-INI-VIGENCIA      PIC  X(010)*/
        public StringBasis LK_VG014_I_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-VG014-I-DTA-FIM-VIGENCIA      PIC  X(010)*/
        public StringBasis LK_VG014_I_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-VG014-I-DTH-CRIACAO           PIC  X(026)*/
        public StringBasis LK_VG014_I_DTH_CRIACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
        /*"01  LK-VG014-I-DTA-INI-SORTEIO       PIC  X(010)*/
        public StringBasis LK_VG014_I_DTA_INI_SORTEIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-VG014-I-DTH-ATIVACAO          PIC  X(026)*/
        public StringBasis LK_VG014_I_DTH_ATIVACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
        /*"01  LK-VG014-I-DTA-SUSPENSAO         PIC  X(010)*/
        public StringBasis LK_VG014_I_DTA_SUSPENSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-VG014-I-DTA-CADUCACAO         PIC  X(010)*/
        public StringBasis LK_VG014_I_DTA_CADUCACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-VG014-I-COD-DV                PIC S9(004) COMP-5*/
        public IntBasis LK_VG014_I_COD_DV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG014-I-VLR-MENSALIDADE       PIC S9(013)V9(2) COMP-3*/
        public DoubleBasis LK_VG014_I_VLR_MENSALIDADE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01  LK-VG014-I-NUM-MOD-PLANO         PIC S9(004) COMP-5*/
        public IntBasis LK_VG014_I_NUM_MOD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG014-I-DES-COMBINACAO        PIC  X(020)*/
        public StringBasis LK_VG014_I_DES_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
        /*"01  LK-VG014-S-DTH-CADASTRAMENTO     PIC  X(026)*/
        public StringBasis LK_VG014_S_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
        /*"01  LK-VG014-IND-ERRO                PIC S9(004) COMP-5*/
        public IntBasis LK_VG014_IND_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG014-MENSAGEM                PIC  X(255)*/
        public StringBasis LK_VG014_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
        /*"01  LK-VG014-NOM-TABELA              PIC  X(036)*/
        public StringBasis LK_VG014_NOM_TABELA { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
        /*"01  LK-VG014-SQLCODE                 PIC S9(004) COMP-5*/
        public IntBasis LK_VG014_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG014-SQLERRMC                PIC  X(070)*/
        public StringBasis LK_VG014_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*"01  LK-VG014-SQLSTATE                PIC  X(005)*/
        public StringBasis LK_VG014_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
        /*"01  LK-VG014-NULL*/
        public SPVG014W_LK_VG014_NULL LK_VG014_NULL { get; set; } = new SPVG014W_LK_VG014_NULL();

    }
}