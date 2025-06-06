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
    public class EF050_DCLEF_CONTRATO : VarBasis
    {
        /*"    10 EF050-NUM-CONTRATO   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF050_NUM_CONTRATO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF050-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis EF050_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF050-COD-TIPO-CONTRATO  PIC S9(4) USAGE COMP.*/
        public IntBasis EF050_COD_TIPO_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF050-NUM-CONTRATO-ANT  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF050_NUM_CONTRATO_ANT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF050-DTH-ASSINATURA  PIC X(10).*/
        public StringBasis EF050_DTH_ASSINATURA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF050-IND-PERIODO-COBR  PIC S9(4) USAGE COMP.*/
        public IntBasis EF050_IND_PERIODO_COBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF050-DTH-INCLUSAO   PIC X(26).*/
        public StringBasis EF050_DTH_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 EF050-STA-CONTRATO   PIC X(1).*/
        public StringBasis EF050_STA_CONTRATO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF050-DTH-INI-VIGENCIA  PIC X(10).*/
        public StringBasis EF050_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF050-DTH-FIM-VIGENCIA  PIC X(10).*/
        public StringBasis EF050_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}