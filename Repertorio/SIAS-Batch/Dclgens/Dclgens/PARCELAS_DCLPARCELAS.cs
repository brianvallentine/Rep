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
    public class PARCELAS_DCLPARCELAS : VarBasis
    {
        /*"    10 PARCELAS-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PARCELAS_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PARCELAS-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis PARCELAS_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PARCELAS-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis PARCELAS_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARCELAS-DAC-PARCELA  PIC X(1).*/
        public StringBasis PARCELAS_DAC_PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PARCELAS-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis PARCELAS_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARCELAS-NUM-TITULO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PARCELAS_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PARCELAS-PRM-TARIFARIO-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis PARCELAS_PRM_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 PARCELAS-VAL-DESCONTO-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis PARCELAS_VAL_DESCONTO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 PARCELAS-PRM-LIQUIDO-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis PARCELAS_PRM_LIQUIDO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 PARCELAS-ADICIONAL-FRAC-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis PARCELAS_ADICIONAL_FRAC_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 PARCELAS-VAL-CUSTO-EMIS-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis PARCELAS_VAL_CUSTO_EMIS_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 PARCELAS-VAL-IOCC-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis PARCELAS_VAL_IOCC_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 PARCELAS-PRM-TOTAL-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis PARCELAS_PRM_TOTAL_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 PARCELAS-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis PARCELAS_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARCELAS-QTD-DOCUMENTOS  PIC S9(4) USAGE COMP.*/
        public IntBasis PARCELAS_QTD_DOCUMENTOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARCELAS-SIT-REGISTRO  PIC X(1).*/
        public StringBasis PARCELAS_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PARCELAS-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis PARCELAS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PARCELAS-TIMESTAMP   PIC X(26).*/
        public StringBasis PARCELAS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 PARCELAS-SITUACAO-COBRANCA  PIC X(1).*/
        public StringBasis PARCELAS_SITUACAO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}