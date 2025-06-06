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
    public class SINIPLAN_DCLSINI_PLANHABIT01 : VarBasis
    {
        /*"    10 SINIPLAN-NUM-APOL-SINISTRO       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINIPLAN_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINIPLAN-NUM-SEQ-PLAN       PIC S9(4) USAGE COMP.*/
        public IntBasis SINIPLAN_NUM_SEQ_PLAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINIPLAN-OCORHIST    PIC S9(4) USAGE COMP.*/
        public IntBasis SINIPLAN_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINIPLAN-PERC-PARTICIPACAO       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis SINIPLAN_PERC_PARTICIPACAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 SINIPLAN-DATA-INDENIZACAO       PIC X(10).*/
        public StringBasis SINIPLAN_DATA_INDENIZACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINIPLAN-DATA-SALDO-DEVEDOR       PIC X(10).*/
        public StringBasis SINIPLAN_DATA_SALDO_DEVEDOR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINIPLAN-VAL-SALDO-DEVEDOR       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINIPLAN_VAL_SALDO_DEVEDOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINIPLAN-VAL-ACORRIGIR       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINIPLAN_VAL_ACORRIGIR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINIPLAN-VAL-INDENIZACAO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINIPLAN_VAL_INDENIZACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINIPLAN-CODUNIMO    PIC S9(4) USAGE COMP.*/
        public IntBasis SINIPLAN_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINIPLAN-DATA-PRI-CODUNIMO       PIC X(10).*/
        public StringBasis SINIPLAN_DATA_PRI_CODUNIMO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINIPLAN-VAL-PRI-CODUNIMO       PIC S9(3)V9(6) USAGE COMP-3.*/
        public DoubleBasis SINIPLAN_VAL_PRI_CODUNIMO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(6)"), 6);
        /*"    10 SINIPLAN-DATA-ULT-CODUNIMO       PIC X(10).*/
        public StringBasis SINIPLAN_DATA_ULT_CODUNIMO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINIPLAN-VAL-ULT-CODUNIMO       PIC S9(3)V9(6) USAGE COMP-3.*/
        public DoubleBasis SINIPLAN_VAL_ULT_CODUNIMO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(6)"), 6);
        /*"    10 SINIPLAN-DATA-ULT-PAGTO       PIC X(10).*/
        public StringBasis SINIPLAN_DATA_ULT_PAGTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINIPLAN-VAL-PREMIO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINIPLAN_VAL_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINIPLAN-VAL-DESPESA       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINIPLAN_VAL_DESPESA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINIPLAN-QTD-PRE-ARECUPERAR       PIC S9(4) USAGE COMP.*/
        public IntBasis SINIPLAN_QTD_PRE_ARECUPERAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINIPLAN-TIMESTAMP   PIC X(26).*/
        public StringBasis SINIPLAN_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SINIPLAN-NUM-ULT-PREST-PAGA       PIC S9(4) USAGE COMP.*/
        public IntBasis SINIPLAN_NUM_ULT_PREST_PAGA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINIPLAN-DATA-CONTRATO       PIC X(10).*/
        public StringBasis SINIPLAN_DATA_CONTRATO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINIPLAN-JUROS-CONTRATO       PIC S9(3)V9(9) USAGE COMP-3.*/
        public DoubleBasis SINIPLAN_JUROS_CONTRATO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(9)"), 9);
        /*"    10 SINIPLAN-VAL-FINANCIADO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINIPLAN_VAL_FINANCIADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINIPLAN-VAL-LIBERADO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINIPLAN_VAL_LIBERADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINIPLAN-VAL-LIBERADO-ATUAL       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINIPLAN_VAL_LIBERADO_ATUAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINIPLAN-VAL-ALIBERAR       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINIPLAN_VAL_ALIBERAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINIPLAN-DT-PRI-PREST-PAGA       PIC X(10).*/
        public StringBasis SINIPLAN_DT_PRI_PREST_PAGA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINIPLAN-DT-ULT-PREST-PAGA       PIC X(10).*/
        public StringBasis SINIPLAN_DT_ULT_PREST_PAGA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINIPLAN-COD-MOEDA-DESPESA       PIC S9(4) USAGE COMP.*/
        public IntBasis SINIPLAN_COD_MOEDA_DESPESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINIPLAN-DT-PRI-MOEDA-DESP       PIC X(10).*/
        public StringBasis SINIPLAN_DT_PRI_MOEDA_DESP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINIPLAN-VAL-PRI-MOEDA-DESP       PIC S9(3)V9(6) USAGE COMP-3.*/
        public DoubleBasis SINIPLAN_VAL_PRI_MOEDA_DESP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(6)"), 6);
        /*"    10 SINIPLAN-DT-ULT-MOEDA-DESP       PIC X(10).*/
        public StringBasis SINIPLAN_DT_ULT_MOEDA_DESP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINIPLAN-VAL-ULT-MOEDA-DESP       PIC S9(3)V9(6) USAGE COMP-3.*/
        public DoubleBasis SINIPLAN_VAL_ULT_MOEDA_DESP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(6)"), 6);
        /*"    10 SINIPLAN-VAL-DESP-ACORRIGIR       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINIPLAN_VAL_DESP_ACORRIGIR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINIPLAN-VAL-DESP-CORRIGIDO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINIPLAN_VAL_DESP_CORRIGIDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINIPLAN-DT-DESPESA-CART       PIC X(10).*/
        public StringBasis SINIPLAN_DT_DESPESA_CART { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINIPLAN-DUP         PIC S9(4) USAGE COMP.*/
        public IntBasis SINIPLAN_DUP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINIPLAN-DUM         PIC S9(4) USAGE COMP.*/
        public IntBasis SINIPLAN_DUM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINIPLAN-IND-ACORDO  PIC X(1).*/
        public StringBasis SINIPLAN_IND_ACORDO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}