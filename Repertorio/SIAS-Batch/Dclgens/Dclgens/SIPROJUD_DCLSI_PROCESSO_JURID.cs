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
    public class SIPROJUD_DCLSI_PROCESSO_JURID : VarBasis
    {
        /*"    10 SIPROJUD-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SIPROJUD_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SIPROJUD-COD-PROCESSO-JURID  PIC X(15).*/
        public StringBasis SIPROJUD_COD_PROCESSO_JURID { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 SIPROJUD-DTH-TIMESTAMP  PIC X(26).*/
        public StringBasis SIPROJUD_DTH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SIPROJUD-DTH-INI-PROCESSO  PIC X(10).*/
        public StringBasis SIPROJUD_DTH_INI_PROCESSO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIPROJUD-DTH-FIM-PROCESSO  PIC X(10).*/
        public StringBasis SIPROJUD_DTH_FIM_PROCESSO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}