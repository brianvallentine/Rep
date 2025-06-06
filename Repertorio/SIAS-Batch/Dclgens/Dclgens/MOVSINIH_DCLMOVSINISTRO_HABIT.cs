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
    public class MOVSINIH_DCLMOVSINISTRO_HABIT : VarBasis
    {
        /*"    10 MOVSINIH-ORIGEM      PIC S9(4) USAGE COMP.*/
        public IntBasis MOVSINIH_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVSINIH-DATA-PAGAMENTO       PIC X(10).*/
        public StringBasis MOVSINIH_DATA_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVSINIH-COD-PRODUTO       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVSINIH_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVSINIH-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 MOVSINIH-MATR-AGENTE       PIC S9(9) USAGE COMP.*/
        public IntBasis MOVSINIH_MATR_AGENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVSINIH-AGE-INDENIZACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVSINIH_AGE_INDENIZACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVSINIH-NUM-CONTRATO-CEF       PIC S9(12)V USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_NUM_CONTRATO_CEF { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(12)V"), 0);
        /*"    10 MOVSINIH-DATA-OCORRENCIA       PIC X(10).*/
        public StringBasis MOVSINIH_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVSINIH-DATA-COMUNICADO       PIC X(10).*/
        public StringBasis MOVSINIH_DATA_COMUNICADO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVSINIH-COD-COBERTURA       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVSINIH_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVSINIH-COD-CAUSA   PIC S9(4) USAGE COMP.*/
        public IntBasis MOVSINIH_COD_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVSINIH-NUM-APOL-SINISTRO       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 MOVSINIH-DATA-AVISO  PIC X(10).*/
        public StringBasis MOVSINIH_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVSINIH-DATA-CONTRATO       PIC X(10).*/
        public StringBasis MOVSINIH_DATA_CONTRATO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVSINIH-NOME-SEGURADO       PIC X(40).*/
        public StringBasis MOVSINIH_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 MOVSINIH-CGCCPF      PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_CGCCPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 MOVSINIH-VAL-PAGAMENTO       PIC S9(11)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_VAL_PAGAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 MOVSINIH-VAL-MAO-OBRA       PIC S9(11)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_VAL_MAO_OBRA { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 MOVSINIH-TIPO-PAGAMENTO       PIC X(1).*/
        public StringBasis MOVSINIH_TIPO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVSINIH-TIPO-FAVORECIDO       PIC X(1).*/
        public StringBasis MOVSINIH_TIPO_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVSINIH-NATUREZA-PAGTO       PIC X(1).*/
        public StringBasis MOVSINIH_NATUREZA_PAGTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVSINIH-COD-DESEMBOLSO       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVSINIH_COD_DESEMBOLSO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVSINIH-COD-FAVORECIDO       PIC S9(9) USAGE COMP.*/
        public IntBasis MOVSINIH_COD_FAVORECIDO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVSINIH-CGCCPF-FAV  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_CGCCPF_FAV { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 MOVSINIH-NUM-PARCELA       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVSINIH_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVSINIH-VAL-TOT-OBRA       PIC S9(11)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_VAL_TOT_OBRA { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 MOVSINIH-SITUACAO    PIC X(1).*/
        public StringBasis MOVSINIH_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVSINIH-TIMESTAMP   PIC X(26).*/
        public StringBasis MOVSINIH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 MOVSINIH-OCORR-HISTORICO       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVSINIH_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVSINIH-CODUSU-LIBERACAO       PIC X(8).*/
        public StringBasis MOVSINIH_CODUSU_LIBERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 MOVSINIH-CODUSU-PAGTO       PIC X(8).*/
        public StringBasis MOVSINIH_CODUSU_PAGTO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 MOVSINIH-NUM-ORDEM   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_NUM_ORDEM { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 MOVSINIH-NUM-NF      PIC X(10).*/
        public StringBasis MOVSINIH_NUM_NF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVSINIH-NUM-CONTR-OBRA       PIC X(12).*/
        public StringBasis MOVSINIH_NUM_CONTR_OBRA { get; set; } = new StringBasis(new PIC("X", "12", "X(12)."), @"");
        /*"    10 MOVSINIH-DATA-REFERENCIA       PIC X(10).*/
        public StringBasis MOVSINIH_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVSINIH-TSTP-SITUACAO       PIC X(26).*/
        public StringBasis MOVSINIH_TSTP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 MOVSINIH-TSTP-RETORNO       PIC X(26).*/
        public StringBasis MOVSINIH_TSTP_RETORNO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 MOVSINIH-DATA-NOTA-FISCAL       PIC X(10).*/
        public StringBasis MOVSINIH_DATA_NOTA_FISCAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVSINIH-RENDA-PACTUADA       PIC S9(5)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_RENDA_PACTUADA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(5)V9(2)"), 2);
        /*"    10 MOVSINIH-COD-OPERACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVSINIH_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVSINIH-VLR-ATUALIZACAO       PIC S9(11)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_VLR_ATUALIZACAO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 MOVSINIH-NUM-CONTR-LASTREAD       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_NUM_CONTR_LASTREAD { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 MOVSINIH-VLR-LASTREADO       PIC S9(11)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_VLR_LASTREADO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 MOVSINIH-VLR-NAO-LASTREADO       PIC S9(11)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_VLR_NAO_LASTREADO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 MOVSINIH-NUM-AVISO-SIACT       PIC S9(14)V USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_NUM_AVISO_SIACT { get; set; } = new DoubleBasis(new PIC("S9", "14", "S9(14)V"), 0);
        /*"    10 MOVSINIH-DTH-NASCIMENTO       PIC X(10).*/
        public StringBasis MOVSINIH_DTH_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVSINIH-STA-SEXO    PIC X(1).*/
        public StringBasis MOVSINIH_STA_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVSINIH-DTH-SINISTRO-ASC       PIC X(10).*/
        public StringBasis MOVSINIH_DTH_SINISTRO_ASC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVSINIH-NUM-CARTA-PREST       PIC X(20).*/
        public StringBasis MOVSINIH_NUM_CARTA_PREST { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 MOVSINIH-DTH-ENVIO-CARTA       PIC X(10).*/
        public StringBasis MOVSINIH_DTH_ENVIO_CARTA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVSINIH-COD-EVENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis MOVSINIH_COD_EVENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVSINIH-DTH-EVENTO  PIC X(10).*/
        public StringBasis MOVSINIH_DTH_EVENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVSINIH-NUM-SINISTRO-PREST       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_NUM_SINISTRO_PREST { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 MOVSINIH-NUM-SINISTRO-OFIC       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_NUM_SINISTRO_OFIC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 MOVSINIH-NUM-DV-CONTRATO-CEF       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVSINIH_NUM_DV_CONTRATO_CEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVSINIH-COD-PROCESSO-JURID       PIC X(15).*/
        public StringBasis MOVSINIH_COD_PROCESSO_JURID { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 MOVSINIH-FORMA-PAGTO       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVSINIH_FORMA_PAGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVSINIH-COD-OPER-PGTO       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVSINIH_COD_OPER_PGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVSINIH-COD-CEF     PIC S9(4) USAGE COMP.*/
        public IntBasis MOVSINIH_COD_CEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVSINIH-NUM-MES-ANO-COMP       PIC S9(9) USAGE COMP.*/
        public IntBasis MOVSINIH_NUM_MES_ANO_COMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVSINIH-DES-EMAIL   PIC X(100).*/
        public StringBasis MOVSINIH_DES_EMAIL { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 MOVSINIH-NUM-CPF-CNPJ-FAVOREC       PIC S9(18) USAGE COMP.*/
        public IntBasis MOVSINIH_NUM_CPF_CNPJ_FAVOREC { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 MOVSINIH-NUM-CPF-CNPJ-TOMADOR       PIC S9(18) USAGE COMP.*/
        public IntBasis MOVSINIH_NUM_CPF_CNPJ_TOMADOR { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 MOVSINIH-SEQ-CNAE-CPRB       PIC S9(18) USAGE COMP.*/
        public IntBasis MOVSINIH_SEQ_CNAE_CPRB { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 MOVSINIH-VLR-TOTAL-DOCUMENTO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_VLR_TOTAL_DOCUMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVSINIH-COD-BANCO   PIC S9(4) USAGE COMP.*/
        public IntBasis MOVSINIH_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVSINIH-COD-AGENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVSINIH_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVSINIH-COD-DV-AGENCIA       PIC X(2).*/
        public StringBasis MOVSINIH_COD_DV_AGENCIA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 MOVSINIH-COD-OPERACAO-CONTA       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVSINIH_COD_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVSINIH-NUM-CONTA-CORRENTE       PIC S9(18) USAGE COMP.*/
        public IntBasis MOVSINIH_NUM_CONTA_CORRENTE { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 MOVSINIH-COD-DV-CONTA-CORRENTE       PIC X(2).*/
        public StringBasis MOVSINIH_COD_DV_CONTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 MOVSINIH-IND-CONTA-BANCARIA       PIC X(2).*/
        public StringBasis MOVSINIH_IND_CONTA_BANCARIA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 MOVSINIH-IND-TP-PESS-FAVOREC       PIC X(1).*/
        public StringBasis MOVSINIH_IND_TP_PESS_FAVOREC { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVSINIH-COD-GRUPO-LANC       PIC X(3).*/
        public StringBasis MOVSINIH_COD_GRUPO_LANC { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 MOVSINIH-IND-ISENCAO-TRIBUTO       PIC X(1).*/
        public StringBasis MOVSINIH_IND_ISENCAO_TRIBUTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVSINIH-COD-IMPOSTO-LIMINAR       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVSINIH_COD_IMPOSTO_LIMINAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVSINIH-COD-PROCESSO-ISENCAO       PIC X(30).*/
        public StringBasis MOVSINIH_COD_PROCESSO_ISENCAO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 MOVSINIH-VLR-RET-N-EFETUADO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_VLR_RET_N_EFETUADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVSINIH-PCT-CPRB    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_PCT_CPRB { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 MOVSINIH-IDE-SISTEMA       PIC X(2).*/
        public StringBasis MOVSINIH_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 MOVSINIH-COD-OPER-PRINCIPAL       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVSINIH_COD_OPER_PRINCIPAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVSINIH-IND-DESC-INSS       PIC X(1).*/
        public StringBasis MOVSINIH_IND_DESC_INSS { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVSINIH-NOM-PROGRAMA       PIC X(10).*/
        public StringBasis MOVSINIH_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVSINIH-SEQ-TP-SERVICO-INSS       PIC S9(9) USAGE COMP.*/
        public IntBasis MOVSINIH_SEQ_TP_SERVICO_INSS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVSINIH-SEQ-INDICATIVO-OBRA       PIC S9(9) USAGE COMP.*/
        public IntBasis MOVSINIH_SEQ_INDICATIVO_OBRA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVSINIH-COD-NACIONAL-OBRA       PIC S9(18) USAGE COMP.*/
        public IntBasis MOVSINIH_COD_NACIONAL_OBRA { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 MOVSINIH-VLR-CUSTO-N-BASE-INSS       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_VLR_CUSTO_N_BASE_INSS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVSINIH-VLR-BASE-CALCULO-INSS       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_VLR_BASE_CALCULO_INSS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVSINIH-VLR-INSS-SUBCONTRATO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_VLR_INSS_SUBCONTRATO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVSINIH-COD-SERIE-DOC-FISCAL       PIC X(5).*/
        public StringBasis MOVSINIH_COD_SERIE_DOC_FISCAL { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
        /*"    10 MOVSINIH-COD-SERVICO-CONTABIL       PIC X(10).*/
        public StringBasis MOVSINIH_COD_SERVICO_CONTABIL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVSINIH-COD-NAT-RENDIMENTO       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVSINIH_COD_NAT_RENDIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVSINIH-COD-IMPOSTO-ISS       PIC X(2).*/
        public StringBasis MOVSINIH_COD_IMPOSTO_ISS { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 MOVSINIH-PCT-ALIQ-ISS       PIC S9(3)V9(5) USAGE COMP-3.*/
        public DoubleBasis MOVSINIH_PCT_ALIQ_ISS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(5)"), 5);
        /*"    10 MOVSINIH-COD-IMPOSTO-INSS       PIC X(2).*/
        public StringBasis MOVSINIH_COD_IMPOSTO_INSS { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"*/
    }
}