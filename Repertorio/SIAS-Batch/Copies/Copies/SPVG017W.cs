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
    public class SPVG017W : VarBasis
    {
        /*"01  LK-VG017-E-TRACE                 PIC  X(001)*/
        public StringBasis LK_VG017_E_TRACE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  LK-VG017-E-IDE-SISTEMA           PIC  X(002)*/
        public StringBasis LK_VG017_E_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"01  LK-VG017-E-COD-USUARIO           PIC  X(008)*/
        public StringBasis LK_VG017_E_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  LK-VG017-E-NOM-PROGRAMA          PIC  X(010)*/
        public StringBasis LK_VG017_E_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-VG017-E-TIPO-ACAO             PIC S9(004) COMP-5*/
        public IntBasis LK_VG017_E_TIPO_ACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG017-E-NUM-PROTOCOLO         PIC S9(018) COMP-5*/
        public IntBasis LK_VG017_E_NUM_PROTOCOLO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"01  LK-VG017-E-NUM-CPF-CNPJ          PIC S9(018) COMP-5*/
        public IntBasis LK_VG017_E_NUM_CPF_CNPJ { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"01  LK-VG017-E-NUM-PROPOSTA          PIC S9(018) COMP-5*/
        public IntBasis LK_VG017_E_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"01  LK-VG017-E-SEQ-PRODUTO-DPS       PIC S9(004) COMP-5*/
        public IntBasis LK_VG017_E_SEQ_PRODUTO_DPS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG017-E-DTH-CONSULTA-DPS      PIC  X(023)*/
        public StringBasis LK_VG017_E_DTH_CONSULTA_DPS { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
        /*"01  LK-VG017-E-IND-TP-PESSOA         PIC  X(001)*/
        public StringBasis LK_VG017_E_IND_TP_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  LK-VG017-E-IND-TP-SEGURADO       PIC  X(001)*/
        public StringBasis LK_VG017_E_IND_TP_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  LK-VG017-E-NUM-CERTIFICADO       PIC S9(018) COMP-5*/
        public IntBasis LK_VG017_E_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"01  LK-VG017-E-VLR-IS                PIC S9(013)V9(2) COMP-3*/
        public DoubleBasis LK_VG017_E_VLR_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01  LK-VG017-E-VLR-ACUMULADO-IS      PIC S9(013)V9(2) COMP-3*/
        public DoubleBasis LK_VG017_E_VLR_ACUMULADO_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01  LK-VG017-E-STA-PROPOSTA-SIAS     PIC S9(004) COMP-5*/
        public IntBasis LK_VG017_E_STA_PROPOSTA_SIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG017-E-STA-PROPOSTA-MOTOR    PIC  X(003)*/
        public StringBasis LK_VG017_E_STA_PROPOSTA_MOTOR { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01  LK-VG017-IND-ERRO                PIC S9(004) COMP-5*/
        public IntBasis LK_VG017_IND_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG017-MENSAGEM                PIC  X(255)*/
        public StringBasis LK_VG017_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
        /*"01  LK-VG017-NOM-TABELA              PIC  X(036)*/
        public StringBasis LK_VG017_NOM_TABELA { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
        /*"01  LK-VG017-SQLCODE                 PIC S9(004) COMP-5*/
        public IntBasis LK_VG017_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG017-SQLERRMC                PIC  X(070)*/
        public StringBasis LK_VG017_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*"01  LK-VG017-SQLSTATE                PIC  X(005)*/
        public StringBasis LK_VG017_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
    }
}