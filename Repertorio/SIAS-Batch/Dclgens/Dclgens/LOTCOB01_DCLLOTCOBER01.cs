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
    public class LOTCOB01_DCLLOTCOBER01 : VarBasis
    {
        /*"    10 LOTCOB01-COD-LOT-FENAL  PIC S9(9) USAGE COMP.*/
        public IntBasis LOTCOB01_COD_LOT_FENAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTCOB01-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis LOTCOB01_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 LOTCOB01-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis LOTCOB01_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTCOB01-RAMO-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis LOTCOB01_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTCOB01-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis LOTCOB01_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTCOB01-MODALIDA-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis LOTCOB01_MODALIDA_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTCOB01-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis LOTCOB01_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTCOB01-DTINIVIG    PIC X(10).*/
        public StringBasis LOTCOB01_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LOTCOB01-DTTERVIG    PIC X(10).*/
        public StringBasis LOTCOB01_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LOTCOB01-COD-MOEDA   PIC S9(4) USAGE COMP.*/
        public IntBasis LOTCOB01_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTCOB01-PREMIO-BRUTO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis LOTCOB01_PREMIO_BRUTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 LOTCOB01-IOF         PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis LOTCOB01_IOF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 LOTCOB01-PREMIO-LIQUIDO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis LOTCOB01_PREMIO_LIQUIDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 LOTCOB01-NUM-FATURA  PIC S9(9) USAGE COMP.*/
        public IntBasis LOTCOB01_NUM_FATURA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTCOB01-SITUACAO-FATURA  PIC X(1).*/
        public StringBasis LOTCOB01_SITUACAO_FATURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 LOTCOB01-DATA-DEBITO  PIC X(10).*/
        public StringBasis LOTCOB01_DATA_DEBITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LOTCOB01-DATA-GERA-MOV  PIC X(10).*/
        public StringBasis LOTCOB01_DATA_GERA_MOV { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LOTCOB01-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis LOTCOB01_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTCOB01-TIMESTAMP   PIC X(26).*/
        public StringBasis LOTCOB01_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 LOTCOB01-TIPO-PARCELA  PIC X(1).*/
        public StringBasis LOTCOB01_TIPO_PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 LOTCOB01-SITUACAO    PIC X(1).*/
        public StringBasis LOTCOB01_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 LOTCOB01-NUM-LANC-LOTERICO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis LOTCOB01_NUM_LANC_LOTERICO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 LOTCOB01-PCT-TAXA-PREMIO  PIC S9(3)V9(9) USAGE COMP-3.*/
        public DoubleBasis LOTCOB01_PCT_TAXA_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(9)"), 9);
        /*"    10 LOTCOB01-QTD-COBRANCA-PREM  PIC S9(4) USAGE COMP.*/
        public IntBasis LOTCOB01_QTD_COBRANCA_PREM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTCOB01-IMP-SEG     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis LOTCOB01_IMP_SEG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 LOTCOB01-VLR-CUSTO-APOLICE  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis LOTCOB01_VLR_CUSTO_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 LOTCOB01-VLR-ADICIONAL-FRAC  PIC S9(13)V9(2) USAGE COMP-3*/
        public DoubleBasis LOTCOB01_VLR_ADICIONAL_FRAC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 LOTCOB01-VLR-JUROS-MENSAL  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis LOTCOB01_VLR_JUROS_MENSAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"*/
    }
}