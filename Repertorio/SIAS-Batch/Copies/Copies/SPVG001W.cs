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
    public class SPVG001W : VarBasis
    {
        /*"01  LK-VG001-TRACE                        PIC  X(001)*/
        public StringBasis LK_VG001_TRACE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  LK-VG001-TIPO-ACAO                    PIC S9(004) COMP-5*/
        public IntBasis LK_VG001_TIPO_ACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG001-NUM-CERTIFICADO              PIC S9(015) COMP-3*/
        public IntBasis LK_VG001_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  LK-VG001-SEQ-CRITICA                  PIC S9(004) COMP-5*/
        public IntBasis LK_VG001_SEQ_CRITICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG001-IND-TP-PROPOSTA              PIC  X(002)*/
        public StringBasis LK_VG001_IND_TP_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"01  LK-VG001-NUM-CPF-CNPJ                 PIC S9(018) COMP-5*/
        public IntBasis LK_VG001_NUM_CPF_CNPJ { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"01  LK-VG001-COD-MSG-CRITICA              PIC S9(003) COMP-5*/
        public IntBasis LK_VG001_COD_MSG_CRITICA { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01  LK-VG001-COD-USUARIO                  PIC  X(008)*/
        public StringBasis LK_VG001_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  LK-VG001-NOM-PROGRAMA                 PIC  X(010)*/
        public StringBasis LK_VG001_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-VG001-STA-CRITICA                  PIC  X(001)*/
        public StringBasis LK_VG001_STA_CRITICA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  LK-VG001-DES-COMPLEMENTAR*/
        public SPVG001W_LK_VG001_DES_COMPLEMENTAR LK_VG001_DES_COMPLEMENTAR { get; set; } = new SPVG001W_LK_VG001_DES_COMPLEMENTAR();

        public IntBasis LK_VG001_S_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  LK-VG001-S-SEQ-CRITICA                PIC S9(004) COMP-5*/
        public IntBasis LK_VG001_S_SEQ_CRITICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG001-S-IND-TP-PROPOSTA            PIC  X(002)*/
        public StringBasis LK_VG001_S_IND_TP_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"01  LK-VG001-S-COD-MSG-CRITICA            PIC S9(004) COMP-5*/
        public IntBasis LK_VG001_S_COD_MSG_CRITICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG001-S-DES-MSG-CRITICA            PIC  X(255)*/
        public StringBasis LK_VG001_S_DES_MSG_CRITICA { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
        /*"01  LK-VG001-S-DES-ABREV-MSG-CRIT         PIC  X(100)*/
        public StringBasis LK_VG001_S_DES_ABREV_MSG_CRIT { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
        /*"01  LK-VG001-S-NUM-CPF-CNPJ               PIC S9(018) COMP-5*/
        public IntBasis LK_VG001_S_NUM_CPF_CNPJ { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"01  LK-VG001-S-NUM-PROPOSTA               PIC S9(015) COMP-3*/
        public IntBasis LK_VG001_S_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  LK-VG001-S-VLR-IS                     PIC S9(13)V9(2) COMP-3*/
        public DoubleBasis LK_VG001_S_VLR_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"01  LK-VG001-S-VLR-PREMIO                 PIC S9(13)V9(2) COMP-3*/
        public DoubleBasis LK_VG001_S_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"01  LK-VG001-S-DTA-OCORRENCIA             PIC  X(010)*/
        public StringBasis LK_VG001_S_DTA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-VG001-S-DTA-RCAP                   PIC  X(010)*/
        public StringBasis LK_VG001_S_DTA_RCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-VG001-S-STA-CRITICA                PIC  X(001)*/
        public StringBasis LK_VG001_S_STA_CRITICA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  LK-VG001-S-DES-STA-CRITICA            PIC  X(255)*/
        public StringBasis LK_VG001_S_DES_STA_CRITICA { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
        /*"01  LK-VG001-S-DES-COMPLEMENTAR*/
        public SPVG001W_LK_VG001_S_DES_COMPLEMENTAR LK_VG001_S_DES_COMPLEMENTAR { get; set; } = new SPVG001W_LK_VG001_S_DES_COMPLEMENTAR();

        public StringBasis LK_VG001_S_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  LK-VG001-S-NOM-PROGRAMA               PIC  X(010)*/
        public StringBasis LK_VG001_S_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-VG001-S-DTH-CADASTRAMENTO          PIC  X(026)*/
        public StringBasis LK_VG001_S_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
        /*"01  LK-VG001-S-STA-PARA                   PIC  X(005)*/
        public StringBasis LK_VG001_S_STA_PARA { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
        /*"01  LK-VG001-IND-ERRO                     PIC S9(004) COMP-5*/
        public IntBasis LK_VG001_IND_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG001-MSG-ERRO                     PIC  X(255)*/
        public StringBasis LK_VG001_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
        /*"01  LK-VG001-NOM-TABELA                   PIC  X(036)*/
        public StringBasis LK_VG001_NOM_TABELA { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
        /*"01  LK-VG001-SQLCODE                      PIC S9(004) COMP-5*/
        public IntBasis LK_VG001_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG001-SQLERRMC                     PIC  X(070)*/
        public StringBasis LK_VG001_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
    }
}