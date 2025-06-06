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
    public class EF066_DCLEF_PREMIO_EMITIDO : VarBasis
    {
        /*"    10 EF066-NUM-CONTRATO-SEGUR       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF066_NUM_CONTRATO_SEGUR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF066-SEQ-PREMIO     PIC S9(9) USAGE COMP.*/
        public IntBasis EF066_SEQ_PREMIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EF066-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis EF066_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF066-COD-TAXA-PREMIO       PIC X(5).*/
        public StringBasis EF066_COD_TAXA_PREMIO { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
        /*"    10 EF066-NUM-RAMO-EMISSOR       PIC S9(4) USAGE COMP.*/
        public IntBasis EF066_NUM_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF066-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis EF066_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF066-COD-TIPO-VAR-PROD       PIC S9(4) USAGE COMP.*/
        public IntBasis EF066_COD_TIPO_VAR_PROD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF066-SEQ-CONFIG-PRODUTO       PIC S9(4) USAGE COMP.*/
        public IntBasis EF066_SEQ_CONFIG_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF066-VLR-PREMIO-TARIF       PIC S9(10)V9(2) USAGE COMP-3.*/
        public DoubleBasis EF066_VLR_PREMIO_TARIF { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(2)"), 2);
        /*"    10 EF066-VLR-IOF        PIC S9(10)V9(2) USAGE COMP-3.*/
        public DoubleBasis EF066_VLR_IOF { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(2)"), 2);
        /*"    10 EF066-IND-ORIGEM-PREMIO       PIC X(1).*/
        public StringBasis EF066_IND_ORIGEM_PREMIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF066-IND-TIPO-PREMIO       PIC X(1).*/
        public StringBasis EF066_IND_TIPO_PREMIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF066-PCT-TAXA-PREM-REC       PIC S9(1)V9(9) USAGE COMP-3.*/
        public DoubleBasis EF066_PCT_TAXA_PREM_REC { get; set; } = new DoubleBasis(new PIC("S9", "1", "S9(1)V9(9)"), 9);
        /*"    10 EF066-STA-PREMIO     PIC X(1).*/
        public StringBasis EF066_STA_PREMIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF066-DTH-INI-REFERENCIA       PIC X(10).*/
        public StringBasis EF066_DTH_INI_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF066-DTH-FIM-REFERENCIA       PIC X(10).*/
        public StringBasis EF066_DTH_FIM_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF066-DTH-ULT-MOVTO  PIC X(10).*/
        public StringBasis EF066_DTH_ULT_MOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF066-NUM-CONTRATO-APOL       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF066_NUM_CONTRATO_APOL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF066-DTH-INI-VIG-CONFIG       PIC X(10).*/
        public StringBasis EF066_DTH_INI_VIG_CONFIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}