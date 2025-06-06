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
    public class ENDOSSOS_DCLENDOSSOS : VarBasis
    {
        /*"    10 ENDOSSOS-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis ENDOSSOS_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 ENDOSSOS-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis ENDOSSOS_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ENDOSSOS-RAMO-EMISSOR  PIC S9(4) USAGE COMP.*/
        public IntBasis ENDOSSOS_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDOSSOS-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis ENDOSSOS_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDOSSOS-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis ENDOSSOS_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDOSSOS-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis ENDOSSOS_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDOSSOS-NUM-PROPOSTA  PIC S9(9) USAGE COMP.*/
        public IntBasis ENDOSSOS_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ENDOSSOS-DATA-PROPOSTA  PIC X(10).*/
        public StringBasis ENDOSSOS_DATA_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 ENDOSSOS-DATA-LIBERACAO  PIC X(10).*/
        public StringBasis ENDOSSOS_DATA_LIBERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 ENDOSSOS-DATA-EMISSAO  PIC X(10).*/
        public StringBasis ENDOSSOS_DATA_EMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 ENDOSSOS-NUM-RCAP    PIC S9(9) USAGE COMP.*/
        public IntBasis ENDOSSOS_NUM_RCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ENDOSSOS-VAL-RCAP    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis ENDOSSOS_VAL_RCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 ENDOSSOS-BCO-RCAP    PIC S9(4) USAGE COMP.*/
        public IntBasis ENDOSSOS_BCO_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDOSSOS-AGE-RCAP    PIC S9(4) USAGE COMP.*/
        public IntBasis ENDOSSOS_AGE_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDOSSOS-DAC-RCAP    PIC X(1).*/
        public StringBasis ENDOSSOS_DAC_RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ENDOSSOS-TIPO-RCAP   PIC X(1).*/
        public StringBasis ENDOSSOS_TIPO_RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ENDOSSOS-BCO-COBRANCA  PIC S9(4) USAGE COMP.*/
        public IntBasis ENDOSSOS_BCO_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDOSSOS-AGE-COBRANCA  PIC S9(4) USAGE COMP.*/
        public IntBasis ENDOSSOS_AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDOSSOS-DAC-COBRANCA  PIC X(1).*/
        public StringBasis ENDOSSOS_DAC_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ENDOSSOS-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis ENDOSSOS_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 ENDOSSOS-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis ENDOSSOS_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 ENDOSSOS-PLANO-SEGURO  PIC S9(4) USAGE COMP.*/
        public IntBasis ENDOSSOS_PLANO_SEGURO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDOSSOS-PCT-ENTRADA  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis ENDOSSOS_PCT_ENTRADA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 ENDOSSOS-PCT-ADIC-FRACIO  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis ENDOSSOS_PCT_ADIC_FRACIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 ENDOSSOS-QTD-DIAS-PRIMEIRA  PIC S9(4) USAGE COMP.*/
        public IntBasis ENDOSSOS_QTD_DIAS_PRIMEIRA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDOSSOS-QTD-PARCELAS  PIC S9(4) USAGE COMP.*/
        public IntBasis ENDOSSOS_QTD_PARCELAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDOSSOS-QTD-PRESTACOES  PIC S9(4) USAGE COMP.*/
        public IntBasis ENDOSSOS_QTD_PRESTACOES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDOSSOS-QTD-ITENS   PIC S9(4) USAGE COMP.*/
        public IntBasis ENDOSSOS_QTD_ITENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDOSSOS-COD-TEXTO-PADRAO  PIC X(3).*/
        public StringBasis ENDOSSOS_COD_TEXTO_PADRAO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 ENDOSSOS-COD-ACEITACAO  PIC X(1).*/
        public StringBasis ENDOSSOS_COD_ACEITACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ENDOSSOS-COD-MOEDA-IMP  PIC S9(4) USAGE COMP.*/
        public IntBasis ENDOSSOS_COD_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDOSSOS-COD-MOEDA-PRM  PIC S9(4) USAGE COMP.*/
        public IntBasis ENDOSSOS_COD_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDOSSOS-TIPO-ENDOSSO  PIC X(1).*/
        public StringBasis ENDOSSOS_TIPO_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ENDOSSOS-COD-USUARIO  PIC X(8).*/
        public StringBasis ENDOSSOS_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 ENDOSSOS-OCORR-ENDERECO  PIC S9(4) USAGE COMP.*/
        public IntBasis ENDOSSOS_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDOSSOS-SIT-REGISTRO  PIC X(1).*/
        public StringBasis ENDOSSOS_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ENDOSSOS-DATA-RCAP   PIC X(10).*/
        public StringBasis ENDOSSOS_DATA_RCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 ENDOSSOS-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis ENDOSSOS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ENDOSSOS-TIPO-CORRECAO  PIC X(1).*/
        public StringBasis ENDOSSOS_TIPO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ENDOSSOS-ISENTA-CUSTO  PIC X(1).*/
        public StringBasis ENDOSSOS_ISENTA_CUSTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ENDOSSOS-TIMESTAMP   PIC X(26).*/
        public StringBasis ENDOSSOS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 ENDOSSOS-DATA-VENCIMENTO  PIC X(10).*/
        public StringBasis ENDOSSOS_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 ENDOSSOS-COEF-PREFIX  PIC S9(4)V9(5) USAGE COMP-3.*/
        public DoubleBasis ENDOSSOS_COEF_PREFIX { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(5)"), 5);
        /*"    10 ENDOSSOS-VAL-CUSTO-EMISSAO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis ENDOSSOS_VAL_CUSTO_EMISSAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"*/
    }
}