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
    public class SINISMES_DCLSINISTRO_MESTRE : VarBasis
    {
        /*"    10 SINISMES-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis SINISMES_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISMES-TIPO-REGISTRO       PIC X(1).*/
        public StringBasis SINISMES_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISMES-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis SINISMES_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISMES-NUM-PROTOCOLO-SINI       PIC S9(9) USAGE COMP.*/
        public IntBasis SINISMES_NUM_PROTOCOLO_SINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISMES-DAC-PROTOCOLO-SINI       PIC X(1).*/
        public StringBasis SINISMES_DAC_PROTOCOLO_SINI { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISMES-NUM-APOL-SINISTRO       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINISMES_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINISMES-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINISMES_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINISMES-NUM-ENDOSSO       PIC S9(9) USAGE COMP.*/
        public IntBasis SINISMES_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISMES-COD-SUBGRUPO       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISMES_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISMES-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SINISMES_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SINISMES-DAC-CERTIFICADO       PIC X(1).*/
        public StringBasis SINISMES_DAC_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISMES-TIPO-SEGURADO       PIC X(1).*/
        public StringBasis SINISMES_TIPO_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISMES-NUM-EMBARQUE       PIC S9(9) USAGE COMP.*/
        public IntBasis SINISMES_NUM_EMBARQUE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISMES-REF-EMBARQUE       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISMES_REF_EMBARQUE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISMES-OCORR-HISTORICO       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISMES_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISMES-COD-LIDER   PIC S9(4) USAGE COMP.*/
        public IntBasis SINISMES_COD_LIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISMES-NUM-SINI-LIDER       PIC X(15).*/
        public StringBasis SINISMES_NUM_SINI_LIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 SINISMES-DATA-COMUNICADO       PIC X(10).*/
        public StringBasis SINISMES_DATA_COMUNICADO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINISMES-DATA-OCORRENCIA       PIC X(10).*/
        public StringBasis SINISMES_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINISMES-DATA-TECNICA       PIC X(10).*/
        public StringBasis SINISMES_DATA_TECNICA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINISMES-COD-CAUSA   PIC S9(4) USAGE COMP.*/
        public IntBasis SINISMES_COD_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISMES-NUM-IRB     PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis SINISMES_NUM_IRB { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 SINISMES-NUM-AVISO-IRB       PIC X(10).*/
        public StringBasis SINISMES_NUM_AVISO_IRB { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINISMES-COD-MOEDA-SINI       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISMES_COD_MOEDA_SINI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISMES-SALDO-PAGAR-IX       PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis SINISMES_SALDO_PAGAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 SINISMES-TOT-PAGAMENTO-IX       PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis SINISMES_TOT_PAGAMENTO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 SINISMES-SALDO-RECUPERAR-IX       PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis SINISMES_SALDO_RECUPERAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 SINISMES-TOT-RECUPERADO-IX       PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis SINISMES_TOT_RECUPERADO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 SINISMES-SALDO-RESSARCIR-IX       PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis SINISMES_SALDO_RESSARCIR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 SINISMES-TOT-RESSARCIDO-IX       PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis SINISMES_TOT_RESSARCIDO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 SINISMES-TOT-DESPESAS-IX       PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis SINISMES_TOT_DESPESAS_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 SINISMES-TOT-HONORARIOS-IX       PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis SINISMES_TOT_HONORARIOS_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 SINISMES-ADIA-RECUPERAR-IX       PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis SINISMES_ADIA_RECUPERAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 SINISMES-ADIA-RECUPERADO-IX       PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis SINISMES_ADIA_RECUPERADO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 SINISMES-IMP-SEGURADA-IX       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINISMES_IMP_SEGURADA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINISMES-PCT-PART-COSSEGURO       PIC S9(4)V9(5) USAGE COMP-3.*/
        public DoubleBasis SINISMES_PCT_PART_COSSEGURO { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(5)"), 5);
        /*"    10 SINISMES-PCT-PART-RESSEGURO       PIC S9(4)V9(5) USAGE COMP-3.*/
        public DoubleBasis SINISMES_PCT_PART_RESSEGURO { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(5)"), 5);
        /*"    10 SINISMES-APROVACAO-ALCADA       PIC S9(9) USAGE COMP.*/
        public IntBasis SINISMES_APROVACAO_ALCADA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISMES-IND-SALVADO       PIC X(1).*/
        public StringBasis SINISMES_IND_SALVADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISMES-INTEGRAL-ESPECIAL       PIC X(1).*/
        public StringBasis SINISMES_INTEGRAL_ESPECIAL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISMES-NUM-MOV-SINI-ATU       PIC S9(9) USAGE COMP.*/
        public IntBasis SINISMES_NUM_MOV_SINI_ATU { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISMES-NUM-MOV-SINI-ANT       PIC S9(9) USAGE COMP.*/
        public IntBasis SINISMES_NUM_MOV_SINI_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISMES-DATA-ULT-MOVIMENTO       PIC X(10).*/
        public StringBasis SINISMES_DATA_ULT_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINISMES-SIT-REGISTRO       PIC X(1).*/
        public StringBasis SINISMES_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISMES-TIMESTAMP   PIC X(26).*/
        public StringBasis SINISMES_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SINISMES-BANCO-ORDEM-PAG       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISMES_BANCO_ORDEM_PAG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISMES-AGENCIA-ORDEM-PAG       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISMES_AGENCIA_ORDEM_PAG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISMES-TIPO-PAGAMENTO       PIC X(1).*/
        public StringBasis SINISMES_TIPO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISMES-RAMO        PIC S9(4) USAGE COMP.*/
        public IntBasis SINISMES_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISMES-NUMERO-ORDEM       PIC S9(9) USAGE COMP.*/
        public IntBasis SINISMES_NUMERO_ORDEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISMES-COD-PRODUTO       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISMES_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISMES-SEQ-CID     PIC S9(9) USAGE COMP.*/
        public IntBasis SINISMES_SEQ_CID { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISMES-DTA-ALTA-INSS       PIC X(10).*/
        public StringBasis SINISMES_DTA_ALTA_INSS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINISMES-QTD-DIA-AFASTAMENTO       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISMES_QTD_DIA_AFASTAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}