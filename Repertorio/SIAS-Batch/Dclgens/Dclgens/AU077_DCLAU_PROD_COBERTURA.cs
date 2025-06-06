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
    public class AU077_DCLAU_PROD_COBERTURA : VarBasis
    {
        /*"    10 AU077-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis AU077_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AU077-COD-EMPRESA    PIC S9(9) USAGE COMP.*/
        public IntBasis AU077_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AU077-RAMO-COBERTURA       PIC S9(4) USAGE COMP.*/
        public IntBasis AU077_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AU077-MODALI-COBERTURA       PIC S9(4) USAGE COMP.*/
        public IntBasis AU077_MODALI_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AU077-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis AU077_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AU077-DTA-INI-VIGENCIA       PIC X(10).*/
        public StringBasis AU077_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 AU077-DTA-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis AU077_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 AU077-VLR-IS         PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AU077_VLR_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AU077-VLR-PREMIO-LIQUIDO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AU077_VLR_PREMIO_LIQUIDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AU077-VLR-CUSTO      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AU077_VLR_CUSTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AU077-VLR-IOF        PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AU077_VLR_IOF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AU077-VLR-PREMIO-TOTAL       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AU077_VLR_PREMIO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AU077-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis AU077_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}