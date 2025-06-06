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
    public class PROPOSTA_DCLPROPOSTAS : VarBasis
    {
        /*"    10 PROPOSTA-TIPO-PROPOSTA  PIC X(1).*/
        public StringBasis PROPOSTA_TIPO_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOSTA-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-NUM-PROPOSTA  PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOSTA_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOSTA-RAMO-EMISSOR  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-COD-MODALIDADE  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_COD_MODALIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-NUM-APOL-ANTERIOR  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PROPOSTA_NUM_APOL_ANTERIOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PROPOSTA-TIPO-APOLICE  PIC X(1).*/
        public StringBasis PROPOSTA_TIPO_APOLICE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOSTA-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOSTA_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOSTA-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis PROPOSTA_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOSTA-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis PROPOSTA_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOSTA-IND-SORTEIO  PIC X(1).*/
        public StringBasis PROPOSTA_IND_SORTEIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOSTA-TIPO-CORRECAO  PIC X(1).*/
        public StringBasis PROPOSTA_TIPO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOSTA-COD-MOEDA-IMP  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_COD_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-COD-MOEDA-PRM  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_COD_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-QTD-DIAS-PRIMEIRA  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_QTD_DIAS_PRIMEIRA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-BCO-RCAP    PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_BCO_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-AGE-RCAP    PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_AGE_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-NUM-RCAP    PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOSTA_NUM_RCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOSTA-VAL-RCAP    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PROPOSTA_VAL_RCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PROPOSTA-PLANO-SEGURO  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_PLANO_SEGURO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-QTD-PARCELAS  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_QTD_PARCELAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-PCT-ENTRADA  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis PROPOSTA_PCT_ENTRADA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 PROPOSTA-PCT-ADIC-JUROS  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis PROPOSTA_PCT_ADIC_JUROS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 PROPOSTA-IND-IOCC    PIC X(1).*/
        public StringBasis PROPOSTA_IND_IOCC { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOSTA-ISENTA-CUSTO  PIC X(1).*/
        public StringBasis PROPOSTA_ISENTA_CUSTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOSTA-QTD-PRESTACOES  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_QTD_PRESTACOES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-BCO-COBRANCA  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_BCO_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-AGE-COBRANCA  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-TIPO-CORRETAGEM  PIC X(1).*/
        public StringBasis PROPOSTA_TIPO_CORRETAGEM { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOSTA-NUM-AUTOR-CORRETA  PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOSTA_NUM_AUTOR_CORRETA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOSTA-QTD-CORRETORES  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_QTD_CORRETORES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-QTD-CORRET-CALC  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_QTD_CORRET_CALC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-NUM-APOL-MANUAL  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PROPOSTA_NUM_APOL_MANUAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PROPOSTA-TIPO-COSSEGURO-CED  PIC X(1).*/
        public StringBasis PROPOSTA_TIPO_COSSEGURO_CED { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOSTA-QTD-COSSEGURA-INF  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_QTD_COSSEGURA_INF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-QTD-COSSEGURA-APU  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_QTD_COSSEGURA_APU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-QTD-ITENS-INF  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_QTD_ITENS_INF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-QTD-ITENS-APU  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_QTD_ITENS_APU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-TIPO-MOVIMENTO  PIC X(1).*/
        public StringBasis PROPOSTA_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOSTA-DATA-ENTRADA  PIC X(10).*/
        public StringBasis PROPOSTA_DATA_ENTRADA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOSTA-DATA-CADASTRAMENTO  PIC X(10).*/
        public StringBasis PROPOSTA_DATA_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOSTA-TIPO-CALCULO  PIC X(1).*/
        public StringBasis PROPOSTA_TIPO_CALCULO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOSTA-LIMITE-INDENIZA  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_LIMITE_INDENIZA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-COD-ACEITACAO  PIC X(1).*/
        public StringBasis PROPOSTA_COD_ACEITACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOSTA-NUM-AUTOR-ACEITA  PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOSTA_NUM_AUTOR_ACEITA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOSTA-PCT-DESCONTO  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis PROPOSTA_PCT_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 PROPOSTA-IND-RCAP    PIC X(1).*/
        public StringBasis PROPOSTA_IND_RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOSTA-COD-TEXTO-PADRAO  PIC X(3).*/
        public StringBasis PROPOSTA_COD_TEXTO_PADRAO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 PROPOSTA-NUM-RENOVACAO  PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOSTA_NUM_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOSTA-CONVENIO-COBRANCA  PIC X(1).*/
        public StringBasis PROPOSTA_CONVENIO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOSTA-OCORR-ENDERECO  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-SIT-REGISTRO  PIC X(1).*/
        public StringBasis PROPOSTA_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOSTA-COD-USUARIO  PIC X(8).*/
        public StringBasis PROPOSTA_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PROPOSTA-NUM-ATA     PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOSTA_NUM_ATA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOSTA-ANO-ATA     PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_ANO_ATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-DATA-SORTEIO  PIC X(10).*/
        public StringBasis PROPOSTA_DATA_SORTEIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOSTA-DATA-LIBERACAO  PIC X(10).*/
        public StringBasis PROPOSTA_DATA_LIBERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOSTA-DATA-APOL-MANUAL  PIC X(10).*/
        public StringBasis PROPOSTA_DATA_APOL_MANUAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOSTA-DATA-RCAP   PIC X(10).*/
        public StringBasis PROPOSTA_DATA_RCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOSTA-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOSTA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOSTA-TIMESTAMP   PIC X(26).*/
        public StringBasis PROPOSTA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 PROPOSTA-TIPO-ENDOSSO  PIC X(1).*/
        public StringBasis PROPOSTA_TIPO_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOSTA-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PROPOSTA_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PROPOSTA-COD-INSPETOR  PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOSTA_COD_INSPETOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOSTA-CANAL-PRODUCAO  PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOSTA_CANAL_PRODUCAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOSTA-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOSTA_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOSTA-DATA-VENCIMENTO  PIC X(10).*/
        public StringBasis PROPOSTA_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOSTA-COEF-PREFIX  PIC S9(4)V9(5) USAGE COMP-3.*/
        public DoubleBasis PROPOSTA_COEF_PREFIX { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(5)"), 5);
        /*"    10 PROPOSTA-VAL-CUSTO-EMISSAO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PROPOSTA_VAL_CUSTO_EMISSAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PROPOSTA-DESTINO-APOLICE  PIC X(1).*/
        public StringBasis PROPOSTA_DESTINO_APOLICE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPOSTA-IND-PAGTO   PIC X(1).*/
        public StringBasis PROPOSTA_IND_PAGTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}