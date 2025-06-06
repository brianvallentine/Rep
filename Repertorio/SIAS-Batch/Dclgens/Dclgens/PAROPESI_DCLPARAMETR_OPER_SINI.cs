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
    public class PAROPESI_DCLPARAMETR_OPER_SINI : VarBasis
    {
        /*"    10 PAROPESI-OPERACAO    PIC S9(4) USAGE COMP.*/
        public IntBasis PAROPESI_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PAROPESI-DESCRICAO   PIC X(40).*/
        public StringBasis PAROPESI_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 PAROPESI-ABREVIACAO  PIC X(15).*/
        public StringBasis PAROPESI_ABREVIACAO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 PAROPESI-IND-TIPO-OPERACAO  PIC X(10).*/
        public StringBasis PAROPESI_IND_TIPO_OPERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PAROPESI-RESERVA     PIC S9(4) USAGE COMP.*/
        public IntBasis PAROPESI_RESERVA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PAROPESI-PAGAMENTO   PIC S9(4) USAGE COMP.*/
        public IntBasis PAROPESI_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PAROPESI-OPER-LIB-COSSEG  PIC S9(4) USAGE COMP.*/
        public IntBasis PAROPESI_OPER_LIB_COSSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PAROPESI-OPER-EST-COSSEG  PIC S9(4) USAGE COMP.*/
        public IntBasis PAROPESI_OPER_EST_COSSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PAROPESI-FUNCAO-OPERACAO  PIC X(5).*/
        public StringBasis PAROPESI_FUNCAO_OPERACAO { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
        /*"    10 PAROPESI-OPER-PEND-COSSEG  PIC S9(4) USAGE COMP.*/
        public IntBasis PAROPESI_OPER_PEND_COSSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PAROPESI-OP-CM-PEND-COSSEG  PIC S9(4) USAGE COMP.*/
        public IntBasis PAROPESI_OP_CM_PEND_COSSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PAROPESI-OP-CM-LIB-COSSEG  PIC S9(4) USAGE COMP.*/
        public IntBasis PAROPESI_OP_CM_LIB_COSSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PAROPESI-OP-CM-EST-COSSEG  PIC S9(4) USAGE COMP.*/
        public IntBasis PAROPESI_OP_CM_EST_COSSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PAROPESI-OP-EST-RESSEGURO  PIC S9(4) USAGE COMP.*/
        public IntBasis PAROPESI_OP_EST_RESSEGURO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PAROPESI-NUM-FATOR-RES-REEM  PIC S9(4) USAGE COMP.*/
        public IntBasis PAROPESI_NUM_FATOR_RES_REEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PAROPESI-NUM-FATOR-PAG-REEM  PIC S9(4) USAGE COMP.*/
        public IntBasis PAROPESI_NUM_FATOR_PAG_REEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PAROPESI-COD-GRUPO-MOTIVO  PIC S9(4) USAGE COMP.*/
        public IntBasis PAROPESI_COD_GRUPO_MOTIVO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PAROPESI-NUM-FATOR-RES-JUR  PIC S9(4) USAGE COMP.*/
        public IntBasis PAROPESI_NUM_FATOR_RES_JUR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PAROPESI-NUM-FATOR-PAG-JUR  PIC S9(4) USAGE COMP.*/
        public IntBasis PAROPESI_NUM_FATOR_PAG_JUR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}