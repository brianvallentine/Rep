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
    public class PF0005W : VarBasis
    {
        /*"01  LK-PF005-E-TRACE                 PIC  X(001)*/
        public StringBasis LK_PF005_E_TRACE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  LK-PF005-E-ACAO                  PIC  9(002)*/
        public IntBasis LK_PF005_E_ACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"01  LK-PF005-E-NUM-IDENTIFICACAO     PIC S9(018) COMP-5*/
        public IntBasis LK_PF005_E_NUM_IDENTIFICACAO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"01  LK-PF005-E-DATA-SITUACAO         PIC  X(010)*/
        public StringBasis LK_PF005_E_DATA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-PF005-E-NSAS-SIVPF            PIC S9(009) COMP-5*/
        public IntBasis LK_PF005_E_NSAS_SIVPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  LK-PF005-E-NSL                   PIC S9(009)*/
        public IntBasis LK_PF005_E_NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  LK-PF005-E-SIT-PROPOSTA          PIC  X(003)*/
        public StringBasis LK_PF005_E_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01  LK-PF005-E-SIT-COBRANCA-SIVPF    PIC  X(003)*/
        public StringBasis LK_PF005_E_SIT_COBRANCA_SIVPF { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01  LK-PF005-E-SIT-MOTIVO-SIVPF      PIC S9(009) COMP-5*/
        public IntBasis LK_PF005_E_SIT_MOTIVO_SIVPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  LK-PF005-E-COD-EMPRESA-SIVPF     PIC S9(004) COMP-5*/
        public IntBasis LK_PF005_E_COD_EMPRESA_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-PF005-E-COD-PRODUTO-SIVPF     PIC S9(004) COMP-5*/
        public IntBasis LK_PF005_E_COD_PRODUTO_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-PF005-E-IND-TP-ACAO           PIC  X(001)*/
        public StringBasis LK_PF005_E_IND_TP_ACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  LK-PF005-E-IND-TP-SENSIBILIZA    PIC  X(001)*/
        public StringBasis LK_PF005_E_IND_TP_SENSIBILIZA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  LK-PF005-E-DTA-INI-VIGENCIA      PIC  X(010)*/
        public StringBasis LK_PF005_E_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-PF005-E-DTA-FIM-VIGENCIA      PIC  X(010)*/
        public StringBasis LK_PF005_E_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-PF005-E-NUM-PARCELA           PIC S9(009) COMP-5*/
        public IntBasis LK_PF005_E_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  LK-PF005-E-COD-TP-LANCAMENTO     PIC S9(004) COMP-5*/
        public IntBasis LK_PF005_E_COD_TP_LANCAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-PF005-E-VLR-PREMIO            PIC S9(013)V9(2) COMP-3*/
        public DoubleBasis LK_PF005_E_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01  LK-PF005-E-DTA-PROCESSA-CEF      PIC  X(010)*/
        public StringBasis LK_PF005_E_DTA_PROCESSA_CEF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-PF005-E-COD-ERRO              PIC S9(004) COMP-5*/
        public IntBasis LK_PF005_E_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-PF005-E-COD-USUARIO           PIC  X(008)*/
        public StringBasis LK_PF005_E_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  LK-PF005-E-NOM-PROGRAMA          PIC  X(010)*/
        public StringBasis LK_PF005_E_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-PF005-IND-ERRO                PIC S9(004) COMP-5*/
        public IntBasis LK_PF005_IND_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-PF005-MENSAGEM                PIC  X(255)*/
        public StringBasis LK_PF005_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
        /*"01  LK-PF005-NOM-TABELA              PIC  X(036)*/
        public StringBasis LK_PF005_NOM_TABELA { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
        /*"01  LK-PF005-SQLCODE                 PIC S9(004) COMP-5*/
        public IntBasis LK_PF005_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-PF005-SQLERRMC                PIC  X(070)*/
        public StringBasis LK_PF005_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*"01  LK-PF005-SQLSTATE                PIC  X(005)*/
        public StringBasis LK_PF005_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
    }
}