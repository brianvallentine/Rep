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
    public class SUBGVGAP_DCLSUBGRUPOS_VGAP : VarBasis
    {
        /*"    10 SUBGVGAP-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SUBGVGAP_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SUBGVGAP-COD-SUBGRUPO       PIC S9(4) USAGE COMP.*/
        public IntBasis SUBGVGAP_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SUBGVGAP-COD-CLIENTE       PIC S9(9) USAGE COMP.*/
        public IntBasis SUBGVGAP_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SUBGVGAP-CLASSE-APOLICE       PIC X(1).*/
        public StringBasis SUBGVGAP_CLASSE_APOLICE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SUBGVGAP-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis SUBGVGAP_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SUBGVGAP-TIPO-FATURAMENTO       PIC X(1).*/
        public StringBasis SUBGVGAP_TIPO_FATURAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SUBGVGAP-FORMA-FATURAMENTO       PIC X(1).*/
        public StringBasis SUBGVGAP_FORMA_FATURAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SUBGVGAP-FORMA-AVERBACAO       PIC X(1).*/
        public StringBasis SUBGVGAP_FORMA_AVERBACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SUBGVGAP-TIPO-PLANO  PIC X(1).*/
        public StringBasis SUBGVGAP_TIPO_PLANO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SUBGVGAP-PERI-FATURAMENTO       PIC S9(4) USAGE COMP.*/
        public IntBasis SUBGVGAP_PERI_FATURAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SUBGVGAP-PERI-RENOVACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis SUBGVGAP_PERI_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SUBGVGAP-PERI-RETROATI-INC       PIC S9(4) USAGE COMP.*/
        public IntBasis SUBGVGAP_PERI_RETROATI_INC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SUBGVGAP-PERI-RETROATI-CAN       PIC S9(4) USAGE COMP.*/
        public IntBasis SUBGVGAP_PERI_RETROATI_CAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SUBGVGAP-OCORR-ENDERECO       PIC S9(4) USAGE COMP.*/
        public IntBasis SUBGVGAP_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SUBGVGAP-OCORR-END-COBRAN       PIC S9(4) USAGE COMP.*/
        public IntBasis SUBGVGAP_OCORR_END_COBRAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SUBGVGAP-BCO-COBRANCA       PIC S9(4) USAGE COMP.*/
        public IntBasis SUBGVGAP_BCO_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SUBGVGAP-AGE-COBRANCA       PIC S9(4) USAGE COMP.*/
        public IntBasis SUBGVGAP_AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SUBGVGAP-DAC-COBRANCA       PIC X(1).*/
        public StringBasis SUBGVGAP_DAC_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SUBGVGAP-TIPO-COBRANCA       PIC X(1).*/
        public StringBasis SUBGVGAP_TIPO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SUBGVGAP-COD-PAG-ANGARIACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis SUBGVGAP_COD_PAG_ANGARIACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SUBGVGAP-PCT-CONJUGE-VG       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis SUBGVGAP_PCT_CONJUGE_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 SUBGVGAP-PCT-CONJUGE-AP       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis SUBGVGAP_PCT_CONJUGE_AP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 SUBGVGAP-OPCAO-COBERTURA       PIC X(1).*/
        public StringBasis SUBGVGAP_OPCAO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SUBGVGAP-OPCAO-CORRETAGEM       PIC X(1).*/
        public StringBasis SUBGVGAP_OPCAO_CORRETAGEM { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SUBGVGAP-IND-CONSISTE-MATRI       PIC X(1).*/
        public StringBasis SUBGVGAP_IND_CONSISTE_MATRI { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SUBGVGAP-IND-PLANO-ASSOCIA       PIC X(1).*/
        public StringBasis SUBGVGAP_IND_PLANO_ASSOCIA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SUBGVGAP-SIT-REGISTRO       PIC X(1).*/
        public StringBasis SUBGVGAP_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SUBGVGAP-OPCAO-CONJUGE       PIC X(1).*/
        public StringBasis SUBGVGAP_OPCAO_CONJUGE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SUBGVGAP-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis SUBGVGAP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SUBGVGAP-TIPO-SUBGRUPO       PIC X(1).*/
        public StringBasis SUBGVGAP_TIPO_SUBGRUPO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SUBGVGAP-DATA-INCLUSAO       PIC X(10).*/
        public StringBasis SUBGVGAP_DATA_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SUBGVGAP-DATA-INIVIGENCIA       PIC X(10).*/
        public StringBasis SUBGVGAP_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SUBGVGAP-DATA-TERVIGENCIA       PIC X(10).*/
        public StringBasis SUBGVGAP_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SUBGVGAP-IND-IOF     PIC X(1).*/
        public StringBasis SUBGVGAP_IND_IOF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SUBGVGAP-TIPO-POSTAGEM       PIC X(1).*/
        public StringBasis SUBGVGAP_TIPO_POSTAGEM { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}