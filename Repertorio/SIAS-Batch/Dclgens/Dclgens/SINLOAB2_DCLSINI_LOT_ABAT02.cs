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
    public class SINLOAB2_DCLSINI_LOT_ABAT02 : VarBasis
    {
        /*"    10 SINLOAB2-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINLOAB2_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINLOAB2-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis SINLOAB2_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINLOAB2-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis SINLOAB2_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINLOAB2-IDE-SISTEMA  PIC X(2).*/
        public StringBasis SINLOAB2_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SINLOAB2-COD-RETENCAO  PIC X(1).*/
        public StringBasis SINLOAB2_COD_RETENCAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINLOAB2-DT-INIVIG-RETENCAO  PIC X(10).*/
        public StringBasis SINLOAB2_DT_INIVIG_RETENCAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINLOAB2-COD-LOT-FENAL  PIC S9(9) USAGE COMP.*/
        public IntBasis SINLOAB2_COD_LOT_FENAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINLOAB2-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis SINLOAB2_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINLOAB2-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis SINLOAB2_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINLOAB2-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINLOAB2_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINLOAB2-TIPO-PARCELA  PIC X(1).*/
        public StringBasis SINLOAB2_TIPO_PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINLOAB2-NUM-FATURA  PIC S9(9) USAGE COMP.*/
        public IntBasis SINLOAB2_NUM_FATURA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINLOAB2-PREMIO-LIQUIDO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINLOAB2_PREMIO_LIQUIDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINLOAB2-TAXA-BASICA-PREMIO  PIC S9(3)V9(9) USAGE COMP-3.*/
        public DoubleBasis SINLOAB2_TAXA_BASICA_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(9)"), 9);
        /*"    10 SINLOAB2-VALOR-IS    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINLOAB2_VALOR_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINLOAB2-QTD-SINISTRO-PAGO  PIC S9(4) USAGE COMP.*/
        public IntBasis SINLOAB2_QTD_SINISTRO_PAGO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINLOAB2-PERCENT-RETENCAO  PIC S9(3)V9(5) USAGE COMP-3.*/
        public DoubleBasis SINLOAB2_PERCENT_RETENCAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(5)"), 5);
        /*"    10 SINLOAB2-TAXA-BASICA-AGRAV  PIC S9(3)V9(9) USAGE COMP-3.*/
        public DoubleBasis SINLOAB2_TAXA_BASICA_AGRAV { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(9)"), 9);
        /*"    10 SINLOAB2-PREMIO-AGRAV  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINLOAB2_PREMIO_AGRAV { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINLOAB2-VALOR-RETENCAO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINLOAB2_VALOR_RETENCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINLOAB2-VALOR-RETENCAO-ANT  PIC S9(13)V9(2) USAGE COMP-3*/
        public DoubleBasis SINLOAB2_VALOR_RETENCAO_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINLOAB2-QTD-DIAS-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis SINLOAB2_QTD_DIAS_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINLOAB2-QTD-DIAS-PRO-RATA  PIC S9(4) USAGE COMP.*/
        public IntBasis SINLOAB2_QTD_DIAS_PRO_RATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINLOAB2-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis SINLOAB2_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINLOAB2-HORA-MOVIMENTO  PIC X(8).*/
        public StringBasis SINLOAB2_HORA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SINLOAB2-DT-INIVIG-TXBASPRE  PIC X(10).*/
        public StringBasis SINLOAB2_DT_INIVIG_TXBASPRE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINLOAB2-DT-TERVIG-TXBASPRE  PIC X(10).*/
        public StringBasis SINLOAB2_DT_TERVIG_TXBASPRE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINLOAB2-DT-INIVIG-IMPSEG  PIC X(10).*/
        public StringBasis SINLOAB2_DT_INIVIG_IMPSEG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINLOAB2-DT-TERVIG-IMPSEG  PIC X(10).*/
        public StringBasis SINLOAB2_DT_TERVIG_IMPSEG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINLOAB2-TIMESTAMP   PIC X(26).*/
        public StringBasis SINLOAB2_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SINLOAB2-VLR-RETENCAO-CALC  PIC S9(11)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINLOAB2_VLR_RETENCAO_CALC { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 SINLOAB2-IND-VLR-RETENCAO  PIC X(1).*/
        public StringBasis SINLOAB2_IND_VLR_RETENCAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
    }
}