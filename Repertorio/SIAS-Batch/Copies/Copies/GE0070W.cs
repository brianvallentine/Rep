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
    public class GE0070W : VarBasis
    {
        /*" 01 LK-0070-E-TRACE                  PIC  X(001)*/
        public StringBasis LK_0070_E_TRACE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*" 01 LK-0070-E-COD-USUARIO            PIC  X(008)*/
        public StringBasis LK_0070_E_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*" 01 LK-0070-E-NOM-PROGRAMA           PIC  X(010)*/
        public StringBasis LK_0070_E_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*" 01 LK-0070-E-ACAO                   PIC S9(005) COMP-5*/
        public IntBasis LK_0070_E_ACAO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*" 01 LK-0070-I-COD-PRODUTO            PIC S9(005) COMP-5*/
        public IntBasis LK_0070_I_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*" 01 LK-0070-I-SEQ-PRODUTO-VRS        PIC S9(005) COMP-5*/
        public IntBasis LK_0070_I_SEQ_PRODUTO_VRS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*" 01 LK-0070-I-DTA-PROPOSTA           PIC  X(010)*/
        public StringBasis LK_0070_I_DTA_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*" 01 LK-0070-S-DTA-INI-VIGENCIA       PIC  X(010)*/
        public StringBasis LK_0070_S_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*" 01 LK-0070-S-DTA-FIM-VIGENCIA       PIC  X(010)*/
        public StringBasis LK_0070_S_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*" 01 LK-0070-S-IND-FLUXO-PARAM        PIC  X(001)*/
        public StringBasis LK_0070_S_IND_FLUXO_PARAM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*" 01 LK-0070-S-COD-PERIOD-VIGENCIA    PIC S9(005) COMP-5*/
        public IntBasis LK_0070_S_COD_PERIOD_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*" 01 LK-0070-S-QTD-PERIOD-VIGENCIA    PIC S9(005) COMP-5*/
        public IntBasis LK_0070_S_QTD_PERIOD_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*" 01 LK-0070-S-COD-MOEDA              PIC S9(005) COMP-5*/
        public IntBasis LK_0070_S_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*" 01 LK-0070-S-IND-RENOVA             PIC  X(001)*/
        public StringBasis LK_0070_S_IND_RENOVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*" 01 LK-0070-S-IND-RENOVA-AUTOMAT     PIC  X(001)*/
        public StringBasis LK_0070_S_IND_RENOVA_AUTOMAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*" 01 LK-0070-S-QTD-RENOVA-AUTOMAT     PIC  S9(005) COMP-5*/
        public IntBasis LK_0070_S_QTD_RENOVA_AUTOMAT { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*" 01 LK-0070-S-IND-DPS                PIC  X(001)*/
        public StringBasis LK_0070_S_IND_DPS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*" 01 LK-0070-S-IND-REENQUADRA-PREM    PIC S9(005) COMP-5*/
        public IntBasis LK_0070_S_IND_REENQUADRA_PREM { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*" 01 LK-0070-S-IND-REAJUSTE-PREMIO    PIC  X(001)*/
        public StringBasis LK_0070_S_IND_REAJUSTE_PREMIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*" 01 LK-0070-S-COD-INDICE-REAJUSTE    PIC S9(005) COMP-5*/
        public IntBasis LK_0070_S_COD_INDICE_REAJUSTE { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*" 01 LK-0070-S-COD-PERIOD-REAJUSTE    PIC S9(005) COMP-5*/
        public IntBasis LK_0070_S_COD_PERIOD_REAJUSTE { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*" 01 LK-0070-S-COD-INDC-DEVOLUCAO     PIC S9(005) COMP-5*/
        public IntBasis LK_0070_S_COD_INDC_DEVOLUCAO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*" 01 LK-0070-S-PCT-JUROS-DEVOLUCAO    PIC S9(003)V9(5) COMP-3*/
        public DoubleBasis LK_0070_S_PCT_JUROS_DEVOLUCAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(5)"), 5);
        /*" 01 LK-0070-S-PCT-MULTA-DEVOLUCAO    PIC S9(003)V9(5) COMP-3*/
        public DoubleBasis LK_0070_S_PCT_MULTA_DEVOLUCAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(5)"), 5);
        /*" 01 LK-0070-S-IND-FLUXO-COMISSAO     PIC  X(001)*/
        public StringBasis LK_0070_S_IND_FLUXO_COMISSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*" 01 LK-0070-S-IND-ACOPLADO           PIC  X(001)*/
        public StringBasis LK_0070_S_IND_ACOPLADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*" 01 LK-0070-S-IND-FLUXO-SINISTRO     PIC  X(001)*/
        public StringBasis LK_0070_S_IND_FLUXO_SINISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*" 01 LK-0070-S-IND-CONJUGE            PIC  X(001)*/
        public StringBasis LK_0070_S_IND_CONJUGE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*" 01 LK-0070-S-COD-USUARIO            PIC  X(005)*/
        public StringBasis LK_0070_S_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
        /*" 01 LK-0070-S-NOM-PROGRAMA           PIC  X(010)*/
        public StringBasis LK_0070_S_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*" 01 LK-0070-S-DTH-CADASTRAMENTO      PIC  X(026)*/
        public StringBasis LK_0070_S_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
        /*" 01   LK-0070-IND-ERRO               PIC S9(004) COMP-5*/
        public IntBasis LK_0070_IND_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 01   LK-0070-MSG-ERRO                 PIC  X(255)*/
        public StringBasis LK_0070_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
        /*" 01   LK-0070-NOM-TABELA             PIC  X(036)*/
        public StringBasis LK_0070_NOM_TABELA { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
        /*" 01   LK-0070-SQLCODE                PIC S9(004) COMP-5*/
        public IntBasis LK_0070_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 01   LK-0070-SQLERRMC               PIC  X(070)*/
        public StringBasis LK_0070_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*" 01   LK-0070-SQLSTATE               PIC  X(005)*/
        public StringBasis LK_0070_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
        /*"*/
    }
}