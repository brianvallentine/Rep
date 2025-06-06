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
    public class SX104_DCLSX_IOF_RAMO_COB : VarBasis
    {
        /*"    10 SX104-NUM-RAMO       PIC S9(4) USAGE COMP.*/
        public IntBasis SX104_NUM_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SX104-NUM-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis SX104_NUM_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SX104-DTA-INI-VIGENCIA       PIC X(10).*/
        public StringBasis SX104_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SX104-DTA-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis SX104_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SX104-PCT-IOF        PIC S9(2)V9(3) USAGE COMP-3.*/
        public DoubleBasis SX104_PCT_IOF { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(2)V9(3)"), 3);
        /*"    10 SX104-PCT-IOF-REDUCAO       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis SX104_PCT_IOF_REDUCAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
    }
}