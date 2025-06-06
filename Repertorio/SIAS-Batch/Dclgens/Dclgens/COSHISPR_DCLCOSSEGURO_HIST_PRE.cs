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
    public class COSHISPR_DCLCOSSEGURO_HIST_PRE : VarBasis
    {
        /*"    10 COSHISPR-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis COSHISPR_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COSHISPR-COD-CONGENERE  PIC S9(4) USAGE COMP.*/
        public IntBasis COSHISPR_COD_CONGENERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COSHISPR-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis COSHISPR_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 COSHISPR-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis COSHISPR_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COSHISPR-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis COSHISPR_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COSHISPR-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis COSHISPR_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COSHISPR-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis COSHISPR_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COSHISPR-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis COSHISPR_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 COSHISPR-TIPO-SEGURO  PIC X(1).*/
        public StringBasis COSHISPR_TIPO_SEGURO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COSHISPR-PRM-TARIFARIO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis COSHISPR_PRM_TARIFARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 COSHISPR-VAL-DESCONTO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis COSHISPR_VAL_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 COSHISPR-PRM-LIQUIDO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis COSHISPR_PRM_LIQUIDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 COSHISPR-ADIC-FRACIONAMENTO  PIC S9(13)V9(2) USAGE COMP-3*/
        public DoubleBasis COSHISPR_ADIC_FRACIONAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 COSHISPR-VAL-COMISSAO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis COSHISPR_VAL_COMISSAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 COSHISPR-PRM-TOTAL   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis COSHISPR_PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 COSHISPR-TIMESTAMP   PIC X(26).*/
        public StringBasis COSHISPR_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 COSHISPR-DATA-QUITACAO  PIC X(10).*/
        public StringBasis COSHISPR_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 COSHISPR-SIT-FINANCEIRA  PIC X(1).*/
        public StringBasis COSHISPR_SIT_FINANCEIRA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COSHISPR-SIT-LIBRECUP  PIC X(1).*/
        public StringBasis COSHISPR_SIT_LIBRECUP { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COSHISPR-NUM-OCORRENCIA  PIC S9(4) USAGE COMP.*/
        public IntBasis COSHISPR_NUM_OCORRENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}