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
    public class PROPOVA_DCLPROPOSTAS_VA : VarBasis
    {
        /*"    10 PROPOVA-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PROPOVA_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PROPOVA-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOVA_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOVA-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOVA_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOVA-OCOREND      PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOVA_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOVA-COD-FONTE    PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOVA_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOVA-AGE-COBRANCA       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOVA_AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOVA-OPCAO-COBERTURA       PIC X(1).*/
        public StringBasis PROPOVA_OPCAO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOVA-DATA-QUITACAO       PIC X(10).*/
        public StringBasis PROPOVA_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOVA-COD-AGE-VENDEDOR       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOVA_COD_AGE_VENDEDOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOVA-OPE-CONTA-VENDEDOR       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOVA_OPE_CONTA_VENDEDOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOVA-NUM-CONTA-VENDEDOR       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PROPOVA_NUM_CONTA_VENDEDOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PROPOVA-DIG-CONTA-VENDEDOR       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOVA_DIG_CONTA_VENDEDOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOVA-NUM-MATRI-VENDEDOR       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PROPOVA_NUM_MATRI_VENDEDOR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PROPOVA-COD-OPERACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOVA_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOVA-PROFISSAO    PIC X(20).*/
        public StringBasis PROPOVA_PROFISSAO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 PROPOVA-DTINCLUS     PIC X(10).*/
        public StringBasis PROPOVA_DTINCLUS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOVA-DATA-MOVIMENTO       PIC X(10).*/
        public StringBasis PROPOVA_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOVA-SIT-REGISTRO       PIC X(1).*/
        public StringBasis PROPOVA_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOVA-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PROPOVA_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PROPOVA-COD-SUBGRUPO       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOVA_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOVA-OCORR-HISTORICO       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOVA_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOVA-NRPRIPARATZ  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOVA_NRPRIPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOVA-QTDPARATZ    PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOVA_QTDPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOVA-DTPROXVEN    PIC X(10).*/
        public StringBasis PROPOVA_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOVA-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOVA_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOVA-DATA-VENCIMENTO       PIC X(10).*/
        public StringBasis PROPOVA_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOVA-SIT-INTERFACE       PIC X(1).*/
        public StringBasis PROPOVA_SIT_INTERFACE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOVA-DTFENAE      PIC X(10).*/
        public StringBasis PROPOVA_DTFENAE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOVA-COD-USUARIO  PIC X(8).*/
        public StringBasis PROPOVA_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PROPOVA-TIMESTAMP    PIC X(26).*/
        public StringBasis PROPOVA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 PROPOVA-IDADE        PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOVA_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOVA-IDE-SEXO     PIC X(1).*/
        public StringBasis PROPOVA_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOVA-ESTADO-CIVIL       PIC X(1).*/
        public StringBasis PROPOVA_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOVA-OPCAO-MARCADA       PIC X(1).*/
        public StringBasis PROPOVA_OPCAO_MARCADA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOVA-SIGLA-CRM    PIC X(2).*/
        public StringBasis PROPOVA_SIGLA_CRM { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 PROPOVA-COD-CRM      PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOVA_COD_CRM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOVA-APOS-INVALIDEZ       PIC X(1).*/
        public StringBasis PROPOVA_APOS_INVALIDEZ { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOVA-ASSINATURA   PIC X(1).*/
        public StringBasis PROPOVA_ASSINATURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOVA-ACATAMENTO   PIC X(1).*/
        public StringBasis PROPOVA_ACATAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOVA-NOME-ESPOSA  PIC X(40).*/
        public StringBasis PROPOVA_NOME_ESPOSA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 PROPOVA-DTNASC-ESPOSA       PIC X(10).*/
        public StringBasis PROPOVA_DTNASC_ESPOSA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOVA-PROFIS-ESPOSA       PIC X(20).*/
        public StringBasis PROPOVA_PROFIS_ESPOSA { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 PROPOVA-DPS-TITULAR  PIC X(25).*/
        public StringBasis PROPOVA_DPS_TITULAR { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"    10 PROPOVA-DPS-ESPOSA   PIC X(25).*/
        public StringBasis PROPOVA_DPS_ESPOSA { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"    10 PROPOVA-NUM-MATRICULA       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PROPOVA_NUM_MATRICULA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PROPOVA-GRAU-PARENTESCO       PIC X(10).*/
        public StringBasis PROPOVA_GRAU_PARENTESCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOVA-DATA-ADMISSAO       PIC X(10).*/
        public StringBasis PROPOVA_DATA_ADMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOVA-NUM-PROPOSTA       PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOVA_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOVA-EM-ATIVIDADE       PIC X(1).*/
        public StringBasis PROPOVA_EM_ATIVIDADE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOVA-LOC-ATIVIDADE       PIC X(40).*/
        public StringBasis PROPOVA_LOC_ATIVIDADE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 PROPOVA-INFO-COMPLEMENTAR       PIC X(50).*/
        public StringBasis PROPOVA_INFO_COMPLEMENTAR { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
        /*"    10 PROPOVA-NRMALADIR    PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOVA_NRMALADIR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOVA-NRCERTIFANT  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PROPOVA_NRCERTIFANT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PROPOVA-COD-CCT      PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PROPOVA_COD_CCT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PROPOVA-FAIXA-RENDA-IND       PIC X(1).*/
        public StringBasis PROPOVA_FAIXA_RENDA_IND { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOVA-FAIXA-RENDA-FAM       PIC X(1).*/
        public StringBasis PROPOVA_FAIXA_RENDA_FAM { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOVA-NUM-CONTR-VINCULO       PIC S9(18)V USAGE COMP-3.*/
        public DoubleBasis PROPOVA_NUM_CONTR_VINCULO { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(18)V"), 0);
        /*"    10 PROPOVA-COD-CORRESP-BANC       PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOVA_COD_CORRESP_BANC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOVA-COD-ORIGEM-PROPOSTA       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOVA_COD_ORIGEM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOVA-NUM-PRAZO-FIN       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOVA_NUM_PRAZO_FIN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOVA-COD-OPER-CREDITO       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOVA_COD_OPER_CREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOVA-STA-ANTECIPACAO       PIC X(1).*/
        public StringBasis PROPOVA_STA_ANTECIPACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOVA-STA-MUDANCA-PLANO       PIC X(1).*/
        public StringBasis PROPOVA_STA_MUDANCA_PLANO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOVA-DTA-DECLINIO       PIC X(10).*/
        public StringBasis PROPOVA_DTA_DECLINIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}