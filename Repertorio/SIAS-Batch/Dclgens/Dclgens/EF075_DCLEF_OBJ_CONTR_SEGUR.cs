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
    public class EF075_DCLEF_OBJ_CONTR_SEGUR : VarBasis
    {
        /*"    10 EF075-NUM-CONTRATO-SEGUR  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF075_NUM_CONTRATO_SEGUR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF075-COD-TIPO-OBJ-SEG  PIC S9(4) USAGE COMP.*/
        public IntBasis EF075_COD_TIPO_OBJ_SEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF075-SEQ-TIPO-OBJ-SEG  PIC S9(4) USAGE COMP.*/
        public IntBasis EF075_SEQ_TIPO_OBJ_SEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF075-NUM-RAMO-EMISSOR  PIC S9(4) USAGE COMP.*/
        public IntBasis EF075_NUM_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF075-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis EF075_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF075-NUM-CONTRATO-APOL  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF075_NUM_CONTRATO_APOL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF075-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis EF075_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF075-COD-TIPO-VAR-PROD  PIC S9(4) USAGE COMP.*/
        public IntBasis EF075_COD_TIPO_VAR_PROD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF075-SEQ-CONFIG-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis EF075_SEQ_CONFIG_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF075-STA-COBERTURA  PIC X(1).*/
        public StringBasis EF075_STA_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF075-STA-OBJ-CONTR-SEG  PIC X(1).*/
        public StringBasis EF075_STA_OBJ_CONTR_SEG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF075-DTH-INI-VIGENCIA  PIC X(10).*/
        public StringBasis EF075_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF075-DTH-FIM-VIGENCIA  PIC X(10).*/
        public StringBasis EF075_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF075-DTH-INI-VIG-CONFIG  PIC X(10).*/
        public StringBasis EF075_DTH_INI_VIG_CONFIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}