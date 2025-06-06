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
    public class LT029_DCLLT_DESCONTO : VarBasis
    {
        /*"    10 LT029-NUM-PROPOSTA-SIM       PIC S9(18) USAGE COMP.*/
        public IntBasis LT029_NUM_PROPOSTA_SIM { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 LT029-IND-TIPO-VIGENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis LT029_IND_TIPO_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LT029-COD-DESCONTO   PIC S9(4) USAGE COMP.*/
        public IntBasis LT029_COD_DESCONTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LT029-SEQ-DESCONTO   PIC S9(4) USAGE COMP.*/
        public IntBasis LT029_SEQ_DESCONTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LT029-IND-TIPO-DESCONTO       PIC S9(4) USAGE COMP.*/
        public IntBasis LT029_IND_TIPO_DESCONTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LT029-STA-DESCONTO   PIC S9(4) USAGE COMP.*/
        public IntBasis LT029_STA_DESCONTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LT029-PCT-DESCONTO   PIC S9(4)V9(3) USAGE COMP-3.*/
        public DoubleBasis LT029_PCT_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(3)"), 3);
        /*"    10 LT029-VLR-BASE-CALCULO       PIC S9(11)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT029_VLR_BASE_CALCULO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 LT029-VLR-DESCONTO   PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LT029_VLR_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 LT029-COD-USUARIO    PIC X(8).*/
        public StringBasis LT029_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 LT029-COD-PROGRAMA   PIC X(10).*/
        public StringBasis LT029_COD_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LT029-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis LT029_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
    }
}