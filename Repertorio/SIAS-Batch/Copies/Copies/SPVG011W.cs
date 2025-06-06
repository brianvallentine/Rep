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
    public class SPVG011W : VarBasis
    {
        /*"01  LK-VG011-E-TRACE                  PIC  X(001)*/
        public StringBasis LK_VG011_E_TRACE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  LK-VG011-E-COD-USUARIO            PIC  X(008)*/
        public StringBasis LK_VG011_E_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  LK-VG011-E-NOM-PROGRAMA           PIC  X(010)*/
        public StringBasis LK_VG011_E_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-VG011-E-TIPO-ACAO              PIC S9(004) COMP-5*/
        public IntBasis LK_VG011_E_TIPO_ACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG011-E-COD-PRODUTO            PIC S9(004) COMP-5*/
        public IntBasis LK_VG011_E_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG011-E-DTA-INI-CALCULO        PIC X(010)*/
        public StringBasis LK_VG011_E_DTA_INI_CALCULO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-VG011-E-DTA-FIM-CALCULO        PIC X(010)*/
        public StringBasis LK_VG011_E_DTA_FIM_CALCULO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-VG011-E-DTA-DECLINIO           PIC X(010)*/
        public StringBasis LK_VG011_E_DTA_DECLINIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-VG011-E-VL-ORIGINAL            PIC S9(15)V9(2) COMP-3*/
        public DoubleBasis LK_VG011_E_VL_ORIGINAL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(2)"), 2);
        /*"01  LK-VG011-E-NUM-APOLICE            PIC S9(18) COMP-5*/
        public IntBasis LK_VG011_E_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"01  LK-VG011-E-COD-SUBGRUPO           PIC S9(004) COMP-5*/
        public IntBasis LK_VG011_E_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG011-E-QTD-DIA-PGMNTO         PIC S9(004) COMP-5*/
        public IntBasis LK_VG011_E_QTD_DIA_PGMNTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG011-S-COD-MOEDA             PIC S9(004) COMP-5*/
        public IntBasis LK_VG011_S_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG011-S-PC-INDICE             PIC S9(03)V9(5) COMP-3*/
        public DoubleBasis LK_VG011_S_PC_INDICE { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(5)"), 5);
        /*"01  LK-VG011-S-VL-JUROS              PIC S9(15)V9(2) COMP-3*/
        public DoubleBasis LK_VG011_S_VL_JUROS { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(2)"), 2);
        /*"01  LK-VG011-S-VL-MULTA              PIC S9(15)V9(2) COMP-3*/
        public DoubleBasis LK_VG011_S_VL_MULTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(2)"), 2);
        /*"01  LK-VG011-S-VL-CORRIGIDO          PIC S9(15)V9(2) COMP-3*/
        public DoubleBasis LK_VG011_S_VL_CORRIGIDO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(2)"), 2);
        /*"01  LK-VG011-S-DTA-FIM-PGMNTO        PIC X(010)*/
        public StringBasis LK_VG011_S_DTA_FIM_PGMNTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-VG011-IND-ERRO                PIC S9(004) COMP-5*/
        public IntBasis LK_VG011_IND_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG011-MSG-ERRO                PIC  X(255)*/
        public StringBasis LK_VG011_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
        /*"01  LK-VG011-NOM-TABELA              PIC  X(036)*/
        public StringBasis LK_VG011_NOM_TABELA { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
        /*"01  LK-VG011-SQLCODE                 PIC S9(004) COMP-5*/
        public IntBasis LK_VG011_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG011-SQLERRMC                PIC  X(070)*/
        public StringBasis LK_VG011_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
    }
}