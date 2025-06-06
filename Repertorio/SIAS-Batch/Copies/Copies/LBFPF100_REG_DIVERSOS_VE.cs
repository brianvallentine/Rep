using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBFPF100_REG_DIVERSOS_VE : VarBasis
    {
        /*"     10  R6-TIPO-REG                 PIC  X(001)*/
        public StringBasis R6_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  R6-NUM-PROPOSTA             PIC  9(014)*/
        public IntBasis R6_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"     10  R6-PERI-PAGAMENTO           PIC  9(001)*/
        public IntBasis R6_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"     10  R6-TIPO-CAPITAL             PIC  9(001)*/
        public IntBasis R6_TIPO_CAPITAL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"     10  R6-COBERTURA-MQC            PIC  X(001)*/
        public StringBasis R6_COBERTURA_MQC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  R6-COBERTURA-IPA            PIC  X(001)*/
        public StringBasis R6_COBERTURA_IPA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  R6-COBERTURA-MORTE-CONJ     PIC  X(001)*/
        public StringBasis R6_COBERTURA_MORTE_CONJ { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  R6-COBERTURA-DMH            PIC  X(001)*/
        public StringBasis R6_COBERTURA_DMH { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  R6-COBERTURA-AUX-ALIM       PIC  X(001)*/
        public StringBasis R6_COBERTURA_AUX_ALIM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  R6-COBERTURA-AUX-FUN        PIC  X(001)*/
        public StringBasis R6_COBERTURA_AUX_FUN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  R6-TIPO-CORRECAO            PIC  9(002)*/
        public IntBasis R6_TIPO_CORRECAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"     10  R6-PERIODO-CORRECAO         PIC  9(001)*/
        public IntBasis R6_PERIODO_CORRECAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"     10  R6-COD-MOEDA-IMP            PIC  9(002)*/
        public IntBasis R6_COD_MOEDA_IMP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"     10  R6-COD-MOEDA-PRM            PIC  9(002)*/
        public IntBasis R6_COD_MOEDA_PRM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"     10  R6-IND-PLANO-ASSOCIADO      PIC  X(001)*/
        public StringBasis R6_IND_PLANO_ASSOCIADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  R6-VALOR-PREMIO             PIC  9(015)V99*/
        public DoubleBasis R6_VALOR_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99"), 2);
        /*"     10  R6-QTDE-VIDA-MODULO-1       PIC  9(004)*/
        public IntBasis R6_QTDE_VIDA_MODULO_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"     10  R6-CAPITAL-MODULO-1         PIC  9(015)V99*/
        public DoubleBasis R6_CAPITAL_MODULO_1 { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99"), 2);
        /*"     10  R6-QTDE-VIDA-MODULO-2       PIC  9(004)*/
        public IntBasis R6_QTDE_VIDA_MODULO_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"     10  R6-CAPITAL-MODULO-2         PIC  9(015)V99*/
        public DoubleBasis R6_CAPITAL_MODULO_2 { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99"), 2);
        /*"     10  R6-QTDE-VIDA-MODULO-3       PIC  9(004)*/
        public IntBasis R6_QTDE_VIDA_MODULO_3 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"     10  R6-CAPITAL-MODULO-3         PIC  9(015)V99*/
        public DoubleBasis R6_CAPITAL_MODULO_3 { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99"), 2);
        /*"     10  R6-NUMERO-DO-ORCAMENTO      PIC  9(018)*/
        public IntBasis R6_NUMERO_DO_ORCAMENTO { get; set; } = new IntBasis(new PIC("9", "18", "9(018)"));
        /*"     10  R6-COBERTURA-MA             PIC  X(001)*/
        public StringBasis R6_COBERTURA_MA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  R6-CNAE                     PIC  9(007)*/
        public IntBasis R6_CNAE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"     10  R6-PORTE-EMPRESA            PIC  9(001)*/
        public IntBasis R6_PORTE_EMPRESA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"     10  FILLER                      PIC  X(162)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "162", "X(162)"), @"");
        /*"*/
    }
}