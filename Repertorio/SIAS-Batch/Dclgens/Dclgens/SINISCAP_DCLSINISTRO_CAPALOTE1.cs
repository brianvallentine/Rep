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
    public class SINISCAP_DCLSINISTRO_CAPALOTE1 : VarBasis
    {
        /*"    10 SINISCAP-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCAP_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCAP-NUM-LOTE    PIC S9(9) USAGE COMP.*/
        public IntBasis SINISCAP_NUM_LOTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISCAP-COD-PREST-SERVICO       PIC S9(9) USAGE COMP.*/
        public IntBasis SINISCAP_COD_PREST_SERVICO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISCAP-NUM-CHEQUE-INTERNO       PIC S9(9) USAGE COMP.*/
        public IntBasis SINISCAP_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISCAP-DIG-CHEQUE-INTERNO       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCAP_DIG_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCAP-QTD-LANCAMENTO       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCAP_QTD_LANCAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCAP-VAL-TOT-LANCA       PIC S9(11)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINISCAP_VAL_TOT_LANCA { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 SINISCAP-DT-ABERTURA       PIC X(10).*/
        public StringBasis SINISCAP_DT_ABERTURA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINISCAP-DT-FECHAMENTO       PIC X(10).*/
        public StringBasis SINISCAP_DT_FECHAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINISCAP-DT-LIBERA-PAGTO       PIC X(10).*/
        public StringBasis SINISCAP_DT_LIBERA_PAGTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINISCAP-DT-PAGAMENTO       PIC X(10).*/
        public StringBasis SINISCAP_DT_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINISCAP-DT-CANCELA-LOTE       PIC X(10).*/
        public StringBasis SINISCAP_DT_CANCELA_LOTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINISCAP-SITUACAO-LOTE       PIC X(1).*/
        public StringBasis SINISCAP_SITUACAO_LOTE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISCAP-COD-MOEDA   PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCAP_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCAP-COD-USUARIO       PIC X(8).*/
        public StringBasis SINISCAP_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SINISCAP-TIMESTAMP   PIC X(26).*/
        public StringBasis SINISCAP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SINISCAP-NOME-DEPTO  PIC X(20).*/
        public StringBasis SINISCAP_NOME_DEPTO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 SINISCAP-COD-FONTE-DEST       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCAP_COD_FONTE_DEST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCAP-IDTAB       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCAP_IDTAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCAP-CODIGO-CH1  PIC X(1).*/
        public StringBasis SINISCAP_CODIGO_CH1 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISCAP-NUM-DOCF-INTERNO       PIC S9(9) USAGE COMP.*/
        public IntBasis SINISCAP_NUM_DOCF_INTERNO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISCAP-COD-PRODUTO       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCAP_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCAP-COD-SISTEMA-ORIGEM       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCAP_COD_SISTEMA_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCAP-DES-EMAIL   PIC X(100).*/
        public StringBasis SINISCAP_DES_EMAIL { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 SINISCAP-NUM-CPF-CNPJ-FAVOREC       PIC S9(18) USAGE COMP.*/
        public IntBasis SINISCAP_NUM_CPF_CNPJ_FAVOREC { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 SINISCAP-NUM-CPF-CNPJ-TOMADOR       PIC S9(18) USAGE COMP.*/
        public IntBasis SINISCAP_NUM_CPF_CNPJ_TOMADOR { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 SINISCAP-SEQ-CNAE-CPRB       PIC S9(18) USAGE COMP.*/
        public IntBasis SINISCAP_SEQ_CNAE_CPRB { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 SINISCAP-VLR-TOTAL-DOCUMENTO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINISCAP_VLR_TOTAL_DOCUMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINISCAP-COD-BANCO   PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCAP_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCAP-COD-AGENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCAP_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCAP-COD-DV-AGENCIA       PIC X(2).*/
        public StringBasis SINISCAP_COD_DV_AGENCIA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SINISCAP-COD-OPERACAO-CONTA       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCAP_COD_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCAP-NUM-CONTA-CORRENTE       PIC S9(18) USAGE COMP.*/
        public IntBasis SINISCAP_NUM_CONTA_CORRENTE { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 SINISCAP-COD-DV-CONTA-CORRENTE       PIC X(2).*/
        public StringBasis SINISCAP_COD_DV_CONTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SINISCAP-IND-CONTA-BANCARIA       PIC X(2).*/
        public StringBasis SINISCAP_IND_CONTA_BANCARIA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SINISCAP-IND-TP-PESS-FAVOREC       PIC X(1).*/
        public StringBasis SINISCAP_IND_TP_PESS_FAVOREC { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISCAP-IND-GRUPO-LANCAMENTO       PIC X(3).*/
        public StringBasis SINISCAP_IND_GRUPO_LANCAMENTO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 SINISCAP-IND-ISENCAO-TRIBUTO       PIC X(1).*/
        public StringBasis SINISCAP_IND_ISENCAO_TRIBUTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISCAP-COD-IMPOSTO-LIMINAR       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCAP_COD_IMPOSTO_LIMINAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCAP-COD-PROCESSO-ISENCAO       PIC X(30).*/
        public StringBasis SINISCAP_COD_PROCESSO_ISENCAO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 SINISCAP-VLR-RET-N-EFETUADO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINISCAP_VLR_RET_N_EFETUADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINISCAP-PCT-CPRB    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINISCAP_PCT_CPRB { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 SINISCAP-IDE-SISTEMA       PIC X(2).*/
        public StringBasis SINISCAP_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SINISCAP-COD-OPER-PRINCIPAL       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCAP_COD_OPER_PRINCIPAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCAP-IND-DESC-INSS       PIC X(1).*/
        public StringBasis SINISCAP_IND_DESC_INSS { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISCAP-NOM-PROGRAMA       PIC X(10).*/
        public StringBasis SINISCAP_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINISCAP-NUM-LOTE-SCPJUD       PIC S9(18) USAGE COMP.*/
        public IntBasis SINISCAP_NUM_LOTE_SCPJUD { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 SINISCAP-COD-SERVICO-CONTABIL       PIC X(10).*/
        public StringBasis SINISCAP_COD_SERVICO_CONTABIL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINISCAP-COD-NAT-RENDIMENTO       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCAP_COD_NAT_RENDIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCAP-COD-IMPOSTO-ISS       PIC X(2).*/
        public StringBasis SINISCAP_COD_IMPOSTO_ISS { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SINISCAP-COD-IMPOSTO-INSS       PIC X(2).*/
        public StringBasis SINISCAP_COD_IMPOSTO_INSS { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SINISCAP-PCT-ALIQ-ISS       PIC S9(3)V9(5) USAGE COMP-3.*/
        public DoubleBasis SINISCAP_PCT_ALIQ_ISS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(5)"), 5);
        /*"*/
    }
}