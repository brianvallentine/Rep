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
    public class SPGE053W : VarBasis
    {
        /*"01  LK-GE053-E-TRACE                 PIC  X(001)*/
        public StringBasis LK_GE053_E_TRACE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  LK-GE053-E-IDE-SISTEMA           PIC  X(002)*/
        public StringBasis LK_GE053_E_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"01  LK-GE053-E-IND-OPERACAO           PIC S9(004) COMP-5*/
        public IntBasis LK_GE053_E_IND_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-GE053-I-NUM-CPF               PIC S9(018) COMP-5*/
        public IntBasis LK_GE053_I_NUM_CPF { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"01  LK-GE053-I-DTH-OPERACAO          PIC  X(026)*/
        public StringBasis LK_GE053_I_DTH_OPERACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
        /*"01  LK-GE053-I-NOM-SOCIAL            PIC  X(100)*/
        public StringBasis LK_GE053_I_NOM_SOCIAL { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
        /*"01  LK-GE053-I-IND-TIPO-ACAO         PIC  X(001)*/
        public StringBasis LK_GE053_I_IND_TIPO_ACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  LK-GE053-I-IND-USA-NOME-SOCIAL   PIC  X(001)*/
        public StringBasis LK_GE053_I_IND_USA_NOME_SOCIAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  LK-GE053-I-COD-TP-PES-NEGOCIO    PIC S9(004) COMP-5*/
        public IntBasis LK_GE053_I_COD_TP_PES_NEGOCIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-GE053-I-NUM-PROPOSTA          PIC S9(018) COMP-5*/
        public IntBasis LK_GE053_I_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"01  LK-GE053-I-COD-CANAL-ORIGEM      PIC  X(010)*/
        public StringBasis LK_GE053_I_COD_CANAL_ORIGEM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-GE053-I-NUM-MATRICULA         PIC  X(020)*/
        public StringBasis LK_GE053_I_NUM_MATRICULA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
        /*"01  LK-GE053-I-NOM-PROGRAMA          PIC  X(010)*/
        public StringBasis LK_GE053_I_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-GE053-I-DTH-CADASTRAMENTO     PIC  X(026)*/
        public StringBasis LK_GE053_I_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
        /*"01  LK-GE053-IND-ERRO                PIC S9(004) COMP-5*/
        public IntBasis LK_GE053_IND_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-GE053-ID-ERRO                 PIC S9(003) COMP-5*/
        public IntBasis LK_GE053_ID_ERRO { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01  LK-GE053-MENSAGEM                PIC  X(255)*/
        public StringBasis LK_GE053_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
        /*"01  LK-GE053-NOM-TABELA              PIC  X(036)*/
        public StringBasis LK_GE053_NOM_TABELA { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
        /*"01  LK-GE053-SQLCODE                 PIC S9(004) COMP-5*/
        public IntBasis LK_GE053_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-GE053-SQLERRMC                PIC  X(070)*/
        public StringBasis LK_GE053_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*"01  LK-GE053-SQLSTATE                PIC  X(005)*/
        public StringBasis LK_GE053_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
    }
}