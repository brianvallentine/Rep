using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class PROPVA_DCLPROPOSTAS_VA : VarBasis
    {
        /*"    10 NUM-CERTIFICADO      PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 COD-PRODUTO          PIC S9(4) USAGE COMP.*/
        public IntBasis COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COD-CLIENTE          PIC S9(9) USAGE COMP.*/
        public IntBasis COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 OCOREND              PIC S9(4) USAGE COMP.*/
        public IntBasis OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COD-FONTE            PIC S9(4) USAGE COMP.*/
        public IntBasis COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AGE-COBRANCA         PIC S9(4) USAGE COMP.*/
        public IntBasis AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OPCAO-COBERTURA      PIC X(1).*/
        public StringBasis OPCAO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 DATA-QUITACAO        PIC X(10).*/
        public StringBasis DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 COD-AGE-VENDEDOR     PIC S9(4) USAGE COMP.*/
        public IntBasis COD_AGE_VENDEDOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OPE-CONTA-VENDEDOR   PIC S9(4) USAGE COMP.*/
        public IntBasis OPE_CONTA_VENDEDOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NUM-CONTA-VENDEDOR   PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis NUM_CONTA_VENDEDOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 DIG-CONTA-VENDEDOR   PIC S9(4) USAGE COMP.*/
        public IntBasis DIG_CONTA_VENDEDOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NUM-MATRI-VENDEDOR   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NUM_MATRI_VENDEDOR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 COD-OPERACAO         PIC S9(4) USAGE COMP.*/
        public IntBasis COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROFISSAO            PIC X(20).*/
        public StringBasis PROFISSAO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 DTINCLUS             PIC X(10).*/
        public StringBasis DTINCLUS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 DATA-MOVIMENTO       PIC X(10).*/
        public StringBasis DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIT-REGISTRO         PIC X(1).*/
        public StringBasis SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 NUM-APOLICE          PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 COD-SUBGRUPO         PIC S9(4) USAGE COMP.*/
        public IntBasis COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OCORR-HISTORICO      PIC S9(4) USAGE COMP.*/
        public IntBasis OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NRPRIPARATZ          PIC S9(4) USAGE COMP.*/
        public IntBasis NRPRIPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 QTDPARATZ            PIC S9(4) USAGE COMP.*/
        public IntBasis QTDPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 DTPROXVEN            PIC X(10).*/
        public StringBasis DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 NUM-PARCELA          PIC S9(4) USAGE COMP.*/
        public IntBasis NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 DATA-VENCIMENTO      PIC X(10).*/
        public StringBasis DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIT-INTERFACE        PIC X(1).*/
        public StringBasis SIT_INTERFACE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 DTFENAE              PIC X(10).*/
        public StringBasis DTFENAE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 COD-USUARIO          PIC X(8).*/
        public StringBasis COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 TIMESTAMP            PIC X(26).*/
        public StringBasis TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 IDADE                PIC S9(4) USAGE COMP.*/
        public IntBasis IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 IDE-SEXO             PIC X(1).*/
        public StringBasis IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ESTADO-CIVIL         PIC X(1).*/
        public StringBasis ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 OPCAO-MARCADA        PIC X(1).*/
        public StringBasis OPCAO_MARCADA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIGLA-CRM            PIC X(2).*/
        public StringBasis SIGLA_CRM { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 COD-CRM              PIC S9(9) USAGE COMP.*/
        public IntBasis COD_CRM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOS-INVALIDEZ       PIC X(1).*/
        public StringBasis APOS_INVALIDEZ { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ASSINATURA           PIC X(1).*/
        public StringBasis ASSINATURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ACATAMENTO           PIC X(1).*/
        public StringBasis ACATAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 NOME-ESPOSA          PIC X(40).*/
        public StringBasis NOME_ESPOSA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 DTNASC-ESPOSA        PIC X(10).*/
        public StringBasis DTNASC_ESPOSA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROFIS-ESPOSA        PIC X(20).*/
        public StringBasis PROFIS_ESPOSA { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 DPS-TITULAR          PIC X(25).*/
        public StringBasis DPS_TITULAR { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"    10 DPS-ESPOSA           PIC X(25).*/
        public StringBasis DPS_ESPOSA { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"    10 NUM-MATRICULA        PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NUM_MATRICULA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 GRAU-PARENTESCO      PIC X(10).*/
        public StringBasis GRAU_PARENTESCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 DATA-ADMISSAO        PIC X(10).*/
        public StringBasis DATA_ADMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 NUM-PROPOSTA         PIC S9(9) USAGE COMP.*/
        public IntBasis NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EM-ATIVIDADE         PIC X(1).*/
        public StringBasis EM_ATIVIDADE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 LOC-ATIVIDADE        PIC X(40).*/
        public StringBasis LOC_ATIVIDADE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 INFO-COMPLEMENTAR    PIC X(50).*/
        public StringBasis INFO_COMPLEMENTAR { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
        /*"    10 NRMALADIR            PIC S9(4) USAGE COMP.*/
        public IntBasis NRMALADIR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NRCERTIFANT          PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NRCERTIFANT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 COD-CCT              PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis COD_CCT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 FAIXA-RENDA-IND      PIC X(1).*/
        public StringBasis FAIXA_RENDA_IND { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FAIXA-RENDA-FAM      PIC X(1).*/
        public StringBasis FAIXA_RENDA_FAM { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 NUM-CONTR-VINCULO    PIC S9(18)V USAGE COMP-3.*/
        public DoubleBasis NUM_CONTR_VINCULO { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(18)V"), 0);
        /*"    10 COD-CORRESP-BANC     PIC S9(9) USAGE COMP.*/
        public IntBasis COD_CORRESP_BANC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COD-ORIGEM-PROPOSTA  PIC S9(4) USAGE COMP.*/
        public IntBasis COD_ORIGEM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NUM-PRAZO-FIN        PIC S9(4) USAGE COMP.*/
        public IntBasis NUM_PRAZO_FIN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COD-OPER-CREDITO     PIC S9(4) USAGE COMP.*/
        public IntBasis COD_OPER_CREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 STA-ANTECIPACAO      PIC X(1).*/
        public StringBasis STA_ANTECIPACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 STA-MUDANCA-PLANO    PIC X(1).*/
        public StringBasis STA_MUDANCA_PLANO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 DTA-DECLINIO         PIC X(10).*/
        public StringBasis DTA_DECLINIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}