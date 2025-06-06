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
    public class CBCONDEV_DCLCB_CONTR_DEVPREMIO : VarBasis
    {
        /*"    10 CBCONDEV-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis CBCONDEV_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CBCONDEV-TIPO-MOVIMENTO       PIC X(1).*/
        public StringBasis CBCONDEV_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CBCONDEV-NUM-CHEQUE-INTERNO       PIC S9(9) USAGE COMP.*/
        public IntBasis CBCONDEV_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CBCONDEV-DIG-CHEQUE-INTERNO       PIC S9(4) USAGE COMP.*/
        public IntBasis CBCONDEV_DIG_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CBCONDEV-DATA-MOVIMENTO       PIC X(10).*/
        public StringBasis CBCONDEV_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CBCONDEV-NUM-SEQUENCIA       PIC S9(9) USAGE COMP.*/
        public IntBasis CBCONDEV_NUM_SEQUENCIA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CBCONDEV-NUM-TITULO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis CBCONDEV_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 CBCONDEV-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis CBCONDEV_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CBCONDEV-NUM-RCAP    PIC S9(9) USAGE COMP.*/
        public IntBasis CBCONDEV_NUM_RCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CBCONDEV-NUM-RCAP-COMPLEMEN       PIC S9(9) USAGE COMP.*/
        public IntBasis CBCONDEV_NUM_RCAP_COMPLEMEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CBCONDEV-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis CBCONDEV_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 CBCONDEV-NUM-ENDOSSO       PIC S9(9) USAGE COMP.*/
        public IntBasis CBCONDEV_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CBCONDEV-NUM-PARCELA       PIC S9(4) USAGE COMP.*/
        public IntBasis CBCONDEV_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CBCONDEV-COD-SUBGRUPO       PIC S9(4) USAGE COMP.*/
        public IntBasis CBCONDEV_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CBCONDEV-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis CBCONDEV_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 CBCONDEV-DATA-OCORRENCIA       PIC X(10).*/
        public StringBasis CBCONDEV_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CBCONDEV-HORA-OPERACAO       PIC X(8).*/
        public StringBasis CBCONDEV_HORA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 CBCONDEV-NUM-MATRICULA       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis CBCONDEV_NUM_MATRICULA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 CBCONDEV-RAMO-EMISSOR       PIC S9(4) USAGE COMP.*/
        public IntBasis CBCONDEV_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CBCONDEV-COD-PRODUTO       PIC S9(4) USAGE COMP.*/
        public IntBasis CBCONDEV_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CBCONDEV-COD-FILIAL  PIC S9(4) USAGE COMP.*/
        public IntBasis CBCONDEV_COD_FILIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CBCONDEV-COD-ESCNEG  PIC S9(4) USAGE COMP.*/
        public IntBasis CBCONDEV_COD_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CBCONDEV-AGE-COBRANCA       PIC S9(4) USAGE COMP.*/
        public IntBasis CBCONDEV_AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CBCONDEV-TIPO-FAVORECIDO       PIC X(1).*/
        public StringBasis CBCONDEV_TIPO_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CBCONDEV-COD-FAVORECIDO       PIC S9(9) USAGE COMP.*/
        public IntBasis CBCONDEV_COD_FAVORECIDO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CBCONDEV-COD-ENDERECO       PIC S9(4) USAGE COMP.*/
        public IntBasis CBCONDEV_COD_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CBCONDEV-OCORR-ENDERECO       PIC S9(4) USAGE COMP.*/
        public IntBasis CBCONDEV_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CBCONDEV-COD-AGENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis CBCONDEV_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CBCONDEV-OPERACAO-CONTA       PIC S9(4) USAGE COMP.*/
        public IntBasis CBCONDEV_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CBCONDEV-NUM-CONTA   PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis CBCONDEV_NUM_CONTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 CBCONDEV-DIG-CONTA   PIC S9(4) USAGE COMP.*/
        public IntBasis CBCONDEV_DIG_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CBCONDEV-SIT-REGISTRO       PIC X(1).*/
        public StringBasis CBCONDEV_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CBCONDEV-DATA-QUITACAO       PIC X(10).*/
        public StringBasis CBCONDEV_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CBCONDEV-VAL-TITULO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CBCONDEV_VAL_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CBCONDEV-VAL-DESCONTO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CBCONDEV_VAL_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CBCONDEV-VAL-OPERACAO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CBCONDEV_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CBCONDEV-COD-DESPESA       PIC S9(4) USAGE COMP.*/
        public IntBasis CBCONDEV_COD_DESPESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CBCONDEV-COD-DEVOLUCAO       PIC S9(4) USAGE COMP.*/
        public IntBasis CBCONDEV_COD_DEVOLUCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CBCONDEV-COD-SISTEMA       PIC S9(4) USAGE COMP.*/
        public IntBasis CBCONDEV_COD_SISTEMA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CBCONDEV-COD-USU-SOLICITA       PIC X(8).*/
        public StringBasis CBCONDEV_COD_USU_SOLICITA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 CBCONDEV-TIMESTAMP   PIC X(26).*/
        public StringBasis CBCONDEV_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 CBCONDEV-DATA-CANCELAMENTO       PIC X(10).*/
        public StringBasis CBCONDEV_DATA_CANCELAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CBCONDEV-COD-USU-CANCELA       PIC X(8).*/
        public StringBasis CBCONDEV_COD_USU_CANCELA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"*/
    }
}