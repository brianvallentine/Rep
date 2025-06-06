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
    public class EF063_DCLEF_APOLICE : VarBasis
    {
        /*"    10 EF063-NUM-CONTRATO   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF063_NUM_CONTRATO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF063-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis EF063_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 EF063-COD-TIPO-APOLICE       PIC X(1).*/
        public StringBasis EF063_COD_TIPO_APOLICE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF063-STA-CALC-SD    PIC X(1).*/
        public StringBasis EF063_STA_CALC_SD { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF063-STA-CALC-PREMIO       PIC X(1).*/
        public StringBasis EF063_STA_CALC_PREMIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF063-IND-EMISSAO    PIC X(1).*/
        public StringBasis EF063_IND_EMISSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF063-IND-COBR-PREMIO       PIC X(1).*/
        public StringBasis EF063_IND_COBR_PREMIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF063-IND-FORMA-FATURAM       PIC S9(4) USAGE COMP.*/
        public IntBasis EF063_IND_FORMA_FATURAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF063-STA-PERMITE-MIGRAR       PIC X(1).*/
        public StringBasis EF063_STA_PERMITE_MIGRAR { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF063-STA-PERMITE-SUBROG       PIC X(1).*/
        public StringBasis EF063_STA_PERMITE_SUBROG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF063-STA-ATLZ-MONET-MES       PIC X(1).*/
        public StringBasis EF063_STA_ATLZ_MONET_MES { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF063-STA-ATLZ-MONET-RET       PIC X(1).*/
        public StringBasis EF063_STA_ATLZ_MONET_RET { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF063-IND-TIPO-ATLZ-MONE       PIC X(1).*/
        public StringBasis EF063_IND_TIPO_ATLZ_MONE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF063-COD-MOEDA-ATLZ-MON       PIC S9(4) USAGE COMP.*/
        public IntBasis EF063_COD_MOEDA_ATLZ_MON { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF063-STA-ACEITA-IS-SUP       PIC X(1).*/
        public StringBasis EF063_STA_ACEITA_IS_SUP { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF063-NUM-RAMO-EMISSOR       PIC S9(4) USAGE COMP.*/
        public IntBasis EF063_NUM_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF063-COD-MODALIDADE       PIC S9(4) USAGE COMP.*/
        public IntBasis EF063_COD_MODALIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF063-QTD-IDADE-MIN  PIC S9(4) USAGE COMP.*/
        public IntBasis EF063_QTD_IDADE_MIN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF063-QTD-IDADE-MAX-FIN       PIC S9(4) USAGE COMP.*/
        public IntBasis EF063_QTD_IDADE_MAX_FIN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF063-PCT-MAX-COMPROM       PIC S9(4)V9(2) USAGE COMP-3.*/
        public DoubleBasis EF063_PCT_MAX_COMPROM { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(2)"), 2);
        /*"    10 EF063-PCT-JUROS-MORA       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis EF063_PCT_JUROS_MORA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 EF063-IND-RATEIO-CORR       PIC X(1).*/
        public StringBasis EF063_IND_RATEIO_CORR { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF063-QTD-DIAS-RATEIO       PIC S9(4) USAGE COMP.*/
        public IntBasis EF063_QTD_DIAS_RATEIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF063-PCT-RESSEGURO  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis EF063_PCT_RESSEGURO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 EF063-DTH-TERM-AVERBACAO       PIC X(10).*/
        public StringBasis EF063_DTH_TERM_AVERBACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF063-QTD-MESES-RETRO       PIC S9(4) USAGE COMP.*/
        public IntBasis EF063_QTD_MESES_RETRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}