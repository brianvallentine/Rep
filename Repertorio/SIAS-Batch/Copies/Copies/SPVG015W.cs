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
    public class SPVG015W : VarBasis
    {
        /*"01  LK-VG015-E-TRACE                 PIC  X(001)*/
        public StringBasis LK_VG015_E_TRACE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  LK-VG015-E-IDE-SISTEMA           PIC  X(002)*/
        public StringBasis LK_VG015_E_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"01  LK-VG015-E-COD-USUARIO           PIC  X(008)*/
        public StringBasis LK_VG015_E_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  LK-VG015-E-NOM-PROGRAMA          PIC  X(010)*/
        public StringBasis LK_VG015_E_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-VG015-E-TIPO-ACAO             PIC S9(004) COMP-5*/
        public IntBasis LK_VG015_E_TIPO_ACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG015-E-NUM-CPF-CNPJ          PIC S9(018) COMP-5*/
        public IntBasis LK_VG015_E_NUM_CPF_CNPJ { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"01  LK-VG015-E-COD-PRODUTO           PIC S9(004) COMP-5*/
        public IntBasis LK_VG015_E_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG015-E-VLR-IS                PIC S9(013)V9(2) COMP-3*/
        public DoubleBasis LK_VG015_E_VLR_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01  LK-VG015-S-STA-PROPOSTA          PIC  X(001)*/
        public StringBasis LK_VG015_S_STA_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  LK-VG015-S-SEQ-PRODUTO-DPS       PIC S9(004) COMP-5*/
        public IntBasis LK_VG015_S_SEQ_PRODUTO_DPS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG015-S-VLR-ACUMULADO-IS      PIC S9(013)V9(2) COMP-3*/
        public DoubleBasis LK_VG015_S_VLR_ACUMULADO_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01  LK-VG015-IND-ERRO                PIC S9(004) COMP-5*/
        public IntBasis LK_VG015_IND_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG015-MENSAGEM                PIC  X(255)*/
        public StringBasis LK_VG015_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
        /*"01  LK-VG015-NOM-TABELA              PIC  X(036)*/
        public StringBasis LK_VG015_NOM_TABELA { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
        /*"01  LK-VG015-SQLCODE                 PIC S9(004) COMP-5*/
        public IntBasis LK_VG015_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG015-SQLERRMC                PIC  X(070)*/
        public StringBasis LK_VG015_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*"01  LK-VG015-SQLSTATE                PIC  X(005)*/
        public StringBasis LK_VG015_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
        /*"*/
    }
}