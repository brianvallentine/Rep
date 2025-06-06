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
    public class SINISHIS_DCLSINISTRO_HISTORICO : VarBasis
    {
        /*"    10 SINISHIS-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis SINISHIS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISHIS-TIPO-REGISTRO  PIC X(1).*/
        public StringBasis SINISHIS_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISHIS-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINISHIS_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINISHIS-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis SINISHIS_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISHIS-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis SINISHIS_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISHIS-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis SINISHIS_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINISHIS-HORA-OPERACAO  PIC X(8).*/
        public StringBasis SINISHIS_HORA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SINISHIS-NOME-FAVORECIDO  PIC X(40).*/
        public StringBasis SINISHIS_NOME_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SINISHIS-VAL-OPERACAO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINISHIS_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINISHIS-DATA-LIM-CORRECAO  PIC X(10).*/
        public StringBasis SINISHIS_DATA_LIM_CORRECAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINISHIS-TIPO-FAVORECIDO  PIC X(1).*/
        public StringBasis SINISHIS_TIPO_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISHIS-DATA-NEGOCIADA  PIC X(10).*/
        public StringBasis SINISHIS_DATA_NEGOCIADA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINISHIS-FONTE-PAGAMENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SINISHIS_FONTE_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISHIS-COD-PREST-SERVICO  PIC S9(9) USAGE COMP.*/
        public IntBasis SINISHIS_COD_PREST_SERVICO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISHIS-COD-SERVICO  PIC S9(4) USAGE COMP.*/
        public IntBasis SINISHIS_COD_SERVICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISHIS-ORDEM-PAGAMENTO  PIC S9(9) USAGE COMP.*/
        public IntBasis SINISHIS_ORDEM_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISHIS-NUM-RECIBO  PIC S9(9) USAGE COMP.*/
        public IntBasis SINISHIS_NUM_RECIBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISHIS-NUM-MOV-SINISTRO  PIC S9(9) USAGE COMP.*/
        public IntBasis SINISHIS_NUM_MOV_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISHIS-COD-USUARIO  PIC X(8).*/
        public StringBasis SINISHIS_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SINISHIS-SIT-CONTABIL  PIC X(1).*/
        public StringBasis SINISHIS_SIT_CONTABIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISHIS-SIT-REGISTRO  PIC X(1).*/
        public StringBasis SINISHIS_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISHIS-TIMESTAMP   PIC X(26).*/
        public StringBasis SINISHIS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SINISHIS-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINISHIS_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINISHIS-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SINISHIS_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISHIS-NOM-PROGRAMA  PIC X(8).*/
        public StringBasis SINISHIS_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"*/
    }
}