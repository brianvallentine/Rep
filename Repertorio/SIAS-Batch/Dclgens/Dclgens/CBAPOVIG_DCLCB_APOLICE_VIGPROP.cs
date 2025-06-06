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
    public class CBAPOVIG_DCLCB_APOLICE_VIGPROP : VarBasis
    {
        /*"    10 CBAPOVIG-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis CBAPOVIG_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 CBAPOVIG-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis CBAPOVIG_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CBAPOVIG-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis CBAPOVIG_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CBAPOVIG-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis CBAPOVIG_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CBAPOVIG-DATA-VENCIMENTO  PIC X(10).*/
        public StringBasis CBAPOVIG_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CBAPOVIG-PREMIO-TOTAL-PAGO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CBAPOVIG_PREMIO_TOTAL_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CBAPOVIG-PREMIO-TOTAL-DEV  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CBAPOVIG_PREMIO_TOTAL_DEV { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CBAPOVIG-QTD-DIAS-COBERTOS  PIC S9(4) USAGE COMP.*/
        public IntBasis CBAPOVIG_QTD_DIAS_COBERTOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CBAPOVIG-DATA-FIM-VIG-PROP  PIC X(10).*/
        public StringBasis CBAPOVIG_DATA_FIM_VIG_PROP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CBAPOVIG-DATA-CANCELAMENTO  PIC X(10).*/
        public StringBasis CBAPOVIG_DATA_CANCELAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CBAPOVIG-IDTAB-SITUACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis CBAPOVIG_IDTAB_SITUACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CBAPOVIG-SITUACAO    PIC X(1).*/
        public StringBasis CBAPOVIG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CBAPOVIG-TIMESTAMP   PIC X(26).*/
        public StringBasis CBAPOVIG_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 CBAPOVIG-DATA-MALA-VIG-PROP  PIC X(10).*/
        public StringBasis CBAPOVIG_DATA_MALA_VIG_PROP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CBAPOVIG-DATA-MALA-CANCEL  PIC X(10).*/
        public StringBasis CBAPOVIG_DATA_MALA_CANCEL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}