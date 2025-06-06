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
    public class EF080_DCLEF_CONFIG_CNTR_SEG : VarBasis
    {
        /*"    10 EF080-NUM-CONTRATO-SEGUR  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF080_NUM_CONTRATO_SEGUR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF080-NUM-CONTRATO-APOL  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF080_NUM_CONTRATO_APOL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF080-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis EF080_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF080-NUM-RAMO-EMISSOR  PIC S9(4) USAGE COMP.*/
        public IntBasis EF080_NUM_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF080-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis EF080_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF080-COD-TIPO-VAR-PROD  PIC S9(4) USAGE COMP.*/
        public IntBasis EF080_COD_TIPO_VAR_PROD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF080-SEQ-CONFIG-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis EF080_SEQ_CONFIG_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF080-IND-IOF-INCLUSO  PIC X(1).*/
        public StringBasis EF080_IND_IOF_INCLUSO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF080-COD-IMP-SEGURADA  PIC S9(4) USAGE COMP.*/
        public IntBasis EF080_COD_IMP_SEGURADA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF080-DTH-INI-VIGENCIA  PIC X(10).*/
        public StringBasis EF080_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF080-STA-RECALC-ITEM  PIC X(1).*/
        public StringBasis EF080_STA_RECALC_ITEM { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF080-VLR-BASE-ITEM-CONF  PIC S9(10)V9(2) USAGE COMP-3.*/
        public DoubleBasis EF080_VLR_BASE_ITEM_CONF { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(2)"), 2);
        /*"    10 EF080-IND-TIPO-RECALC  PIC X(1).*/
        public StringBasis EF080_IND_TIPO_RECALC { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF080-IND-SIST-AMORTIZ  PIC S9(4) USAGE COMP.*/
        public IntBasis EF080_IND_SIST_AMORTIZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF080-VLR-IS         PIC S9(10)V9(2) USAGE COMP-3.*/
        public DoubleBasis EF080_VLR_IS { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(2)"), 2);
        /*"    10 EF080-PCT-TAXA-PREMIO  PIC S9(3)V9(9) USAGE COMP-3.*/
        public DoubleBasis EF080_PCT_TAXA_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(9)"), 9);
        /*"    10 EF080-PCT-TAXA-IOF   PIC S9(3)V9(9) USAGE COMP-3.*/
        public DoubleBasis EF080_PCT_TAXA_IOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(9)"), 9);
        /*"    10 EF080-VLR-PREMIO-SERVICO  PIC S9(10)V9(2) USAGE COMP-3.*/
        public DoubleBasis EF080_VLR_PREMIO_SERVICO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(2)"), 2);
        /*"    10 EF080-DTH-REFERENCIA-IS  PIC X(10).*/
        public StringBasis EF080_DTH_REFERENCIA_IS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF080-STA-CONFIG-CONTR  PIC X(1).*/
        public StringBasis EF080_STA_CONFIG_CONTR { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF080-DTH-ULT-REFER-IS  PIC X(10).*/
        public StringBasis EF080_DTH_ULT_REFER_IS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF080-DTH-FIM-VIGENCIA  PIC X(10).*/
        public StringBasis EF080_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF080-PCT-REDUCAO    PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis EF080_PCT_REDUCAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 EF080-SEQ-OPER-REDUCAO  PIC S9(4) USAGE COMP.*/
        public IntBasis EF080_SEQ_OPER_REDUCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}