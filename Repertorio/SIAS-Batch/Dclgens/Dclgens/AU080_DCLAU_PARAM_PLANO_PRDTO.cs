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
    public class AU080_DCLAU_PARAM_PLANO_PRDTO : VarBasis
    {
        /*"    10 AU080-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis AU080_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AU080-IND-FORMA-PGTO       PIC S9(4) USAGE COMP.*/
        public IntBasis AU080_IND_FORMA_PGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AU080-QTD-PARCELA    PIC S9(4) USAGE COMP.*/
        public IntBasis AU080_QTD_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AU080-DTA-INI-VIGENCIA       PIC X(10).*/
        public StringBasis AU080_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 AU080-DTA-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis AU080_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 AU080-PCT-TOTAL-ENCARGO       PIC S9(2)V9(5) USAGE COMP-3.*/
        public DoubleBasis AU080_PCT_TOTAL_ENCARGO { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(2)V9(5)"), 5);
        /*"    10 AU080-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis AU080_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 AU080-VLR-TOTAL-PARCELA       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AU080_VLR_TOTAL_PARCELA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AU080-VLR-TOTAL-PREMIO-LIQ       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AU080_VLR_TOTAL_PREMIO_LIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AU080-VLR-TOTAL-CUSTO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AU080_VLR_TOTAL_CUSTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AU080-VLR-TOTAL-IOF  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AU080_VLR_TOTAL_IOF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"*/
    }
}