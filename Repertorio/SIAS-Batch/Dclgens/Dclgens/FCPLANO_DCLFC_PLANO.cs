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
    public class FCPLANO_DCLFC_PLANO : VarBasis
    {
        /*"    10 FCPLANO-NUM-PLANO    PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPLANO-NOM-PLANO    PIC X(100).*/
        public StringBasis FCPLANO_NOM_PLANO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 FCPLANO-COD-CONVENIO       PIC X(20).*/
        public StringBasis FCPLANO_COD_CONVENIO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 FCPLANO-COD-ESPEC-TITULO       PIC X(3).*/
        public StringBasis FCPLANO_COD_ESPEC_TITULO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCPLANO-COD-FORMA-VCTO       PIC X(3).*/
        public StringBasis FCPLANO_COD_FORMA_VCTO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCPLANO-COD-INTERV-RESG       PIC X(3).*/
        public StringBasis FCPLANO_COD_INTERV_RESG { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCPLANO-COD-PERIODO-SORT       PIC X(3).*/
        public StringBasis FCPLANO_COD_PERIODO_SORT { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCPLANO-COD-TIPO-ANIVERS       PIC X(3).*/
        public StringBasis FCPLANO_COD_TIPO_ANIVERS { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCPLANO-COD-TIPO-EMIS       PIC X(3).*/
        public StringBasis FCPLANO_COD_TIPO_EMIS { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCPLANO-COD-TIPO-PGTO       PIC X(3).*/
        public StringBasis FCPLANO_COD_TIPO_PGTO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCPLANO-COD-TIPO-VIGENCIA       PIC X(3).*/
        public StringBasis FCPLANO_COD_TIPO_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCPLANO-COD-TP-VLR-TOLER       PIC X(3).*/
        public StringBasis FCPLANO_COD_TP_VLR_TOLER { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCPLANO-COD-UNID-TEMPO       PIC X(3).*/
        public StringBasis FCPLANO_COD_UNID_TEMPO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCPLANO-DTH-FINAL-VENDAS       PIC X(10).*/
        public StringBasis FCPLANO_DTH_FINAL_VENDAS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FCPLANO-DTH-INICIO-VENDAS       PIC X(10).*/
        public StringBasis FCPLANO_DTH_INICIO_VENDAS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FCPLANO-IDE-QUOTA-ATU-PARC       PIC S9(9) USAGE COMP.*/
        public IntBasis FCPLANO_IDE_QUOTA_ATU_PARC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCPLANO-IDE-QUOTA-CORR-ATR       PIC S9(9) USAGE COMP.*/
        public IntBasis FCPLANO_IDE_QUOTA_CORR_ATR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCPLANO-IDE-QUOTA-PROV-CTX       PIC S9(9) USAGE COMP.*/
        public IntBasis FCPLANO_IDE_QUOTA_PROV_CTX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCPLANO-IDE-QUOTA-PROV-STX       PIC S9(9) USAGE COMP.*/
        public IntBasis FCPLANO_IDE_QUOTA_PROV_STX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCPLANO-IND-DECURS-VALID       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_IND_DECURS_VALID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPLANO-IND-DIA-VCTO       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_IND_DIA_VCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPLANO-IND-INTERV-SUSP       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_IND_INTERV_SUSP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPLANO-IND-NUM-MAX-SUSP       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_IND_NUM_MAX_SUSP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPLANO-IND-PERIOD-CADUC       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_IND_PERIOD_CADUC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPLANO-IND-PERIOD-PGTO       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_IND_PERIOD_PGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPLANO-IND-PERIOD-REAJ       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_IND_PERIOD_REAJ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPLANO-IND-PER-MAX-SUSP       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_IND_PER_MAX_SUSP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPLANO-IND-ULT-SORTEIO       PIC S9(9) USAGE COMP.*/
        public IntBasis FCPLANO_IND_ULT_SORTEIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCPLANO-NOM-CODIGO-PLANO       PIC X(10).*/
        public StringBasis FCPLANO_NOM_CODIGO_PLANO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FCPLANO-NUM-CARENCIA-RESG       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_NUM_CARENCIA_RESG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPLANO-NUM-DIAS-SORTEIO       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_NUM_DIAS_SORTEIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPLANO-NUM-DIAS-TOLER       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_NUM_DIAS_TOLER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPLANO-NUM-DIA-ANIVERS       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_NUM_DIA_ANIVERS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPLANO-NUM-DIA-VIGENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_NUM_DIA_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPLANO-NUM-MES-VIGENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_NUM_MES_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPLANO-NUM-PRAZ-CAPITALIZ       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_NUM_PRAZ_CAPITALIZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPLANO-NUM-SER-ULT-EMIT       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_NUM_SER_ULT_EMIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPLANO-NUM-SER-ULT-SOLIC       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_NUM_SER_ULT_SOLIC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPLANO-QTD-TITULOS-LOTE       PIC S9(9) USAGE COMP.*/
        public IntBasis FCPLANO_QTD_TITULOS_LOTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCPLANO-QTD-TITULOS-SERIE       PIC S9(9) USAGE COMP.*/
        public IntBasis FCPLANO_QTD_TITULOS_SERIE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCPLANO-STA-CONTR-RISCO       PIC X(1).*/
        public StringBasis FCPLANO_STA_CONTR_RISCO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCPLANO-STA-DIAS-UTEIS       PIC X(1).*/
        public StringBasis FCPLANO_STA_DIAS_UTEIS { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCPLANO-STA-DIAS-UT-SORT       PIC X(1).*/
        public StringBasis FCPLANO_STA_DIAS_UT_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCPLANO-STA-DIR-SORT-TERC       PIC X(1).*/
        public StringBasis FCPLANO_STA_DIR_SORT_TERC { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCPLANO-STA-PRO-RATA-PROV       PIC X(1).*/
        public StringBasis FCPLANO_STA_PRO_RATA_PROV { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCPLANO-STA-REATIV-TITULO       PIC X(1).*/
        public StringBasis FCPLANO_STA_REATIV_TITULO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCPLANO-STA-TRANSF-SUBSC       PIC X(1).*/
        public StringBasis FCPLANO_STA_TRANSF_SUBSC { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCPLANO-STA-TRANSF-TITULAR       PIC X(1).*/
        public StringBasis FCPLANO_STA_TRANSF_TITULAR { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCPLANO-VLR-JUROS-ATRASO       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis FCPLANO_VLR_JUROS_ATRASO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 FCPLANO-VLR-LIM-MIN-RECEB       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis FCPLANO_VLR_LIM_MIN_RECEB { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 FCPLANO-VLR-MULTA-ATRASO       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis FCPLANO_VLR_MULTA_ATRASO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 FCPLANO-VLR-TOLER-RECEB       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis FCPLANO_VLR_TOLER_RECEB { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 FCPLANO-COD-BOL-RENOV       PIC X(1).*/
        public StringBasis FCPLANO_COD_BOL_RENOV { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCPLANO-COD-BOL-COBRANCA       PIC X(1).*/
        public StringBasis FCPLANO_COD_BOL_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCPLANO-COD-BOL-SIGPF       PIC X(1).*/
        public StringBasis FCPLANO_COD_BOL_SIGPF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCPLANO-COD-BOL-REVENDA       PIC X(1).*/
        public StringBasis FCPLANO_COD_BOL_REVENDA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCPLANO-COD-SEQ-REVENDA       PIC X(5).*/
        public StringBasis FCPLANO_COD_SEQ_REVENDA { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
        /*"    10 FCPLANO-COD-SEQ-VENDA       PIC X(5).*/
        public StringBasis FCPLANO_COD_SEQ_VENDA { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
        /*"    10 FCPLANO-NUM-MES-VIG-SORT       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_NUM_MES_VIG_SORT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPLANO-STA-VENDA-SIATC       PIC X(1).*/
        public StringBasis FCPLANO_STA_VENDA_SIATC { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCPLANO-QTD-DIG-COMBINACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_QTD_DIG_COMBINACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPLANO-NOM-LINK-PROP-DIG       PIC X(75).*/
        public StringBasis FCPLANO_NOM_LINK_PROP_DIG { get; set; } = new StringBasis(new PIC("X", "75", "X(75)."), @"");
        /*"    10 FCPLANO-COD-BOL-PENALIDADE       PIC X(1).*/
        public StringBasis FCPLANO_COD_BOL_PENALIDADE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCPLANO-COD-BOL-SER-ALT       PIC X(1).*/
        public StringBasis FCPLANO_COD_BOL_SER_ALT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCPLANO-NUM-DIAS-CANC-COM       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_NUM_DIAS_CANC_COM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPLANO-STA-EXTRATO-IR       PIC X(1).*/
        public StringBasis FCPLANO_STA_EXTRATO_IR { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCPLANO-NOM-ENDERECO-LOGO       PIC X(20).*/
        public StringBasis FCPLANO_NOM_ENDERECO_LOGO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 FCPLANO-COD-BOL-ACOPLADO       PIC X(1).*/
        public StringBasis FCPLANO_COD_BOL_ACOPLADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCPLANO-VLR-MIN-PARCELAS       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis FCPLANO_VLR_MIN_PARCELAS { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 FCPLANO-VLR-MAX-PARCELAS       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis FCPLANO_VLR_MAX_PARCELAS { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 FCPLANO-VLR-MULT-PARCELAS       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis FCPLANO_VLR_MULT_PARCELAS { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 FCPLANO-IND-RENOVACAO-AUT       PIC X(1).*/
        public StringBasis FCPLANO_IND_RENOVACAO_AUT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCPLANO-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis FCPLANO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCPLANO-QTD-MES-PRORROGA       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_QTD_MES_PRORROGA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPLANO-NUM-CIRCULAR-SUSEP       PIC S9(4) USAGE COMP.*/
        public IntBasis FCPLANO_NUM_CIRCULAR_SUSEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}