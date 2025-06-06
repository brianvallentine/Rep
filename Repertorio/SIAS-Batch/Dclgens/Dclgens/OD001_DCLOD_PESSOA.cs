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
    public class OD001_DCLOD_PESSOA : VarBasis
    {
        /*"    10 OD001-NUM-PESSOA     PIC S9(9) USAGE COMP.*/
        public IntBasis OD001_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 OD001-DTH-CADASTRAMENTO  PIC X(26).*/
        public StringBasis OD001_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 OD001-NUM-DV-PESSOA  PIC S9(4) USAGE COMP.*/
        public IntBasis OD001_NUM_DV_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OD001-IND-PESSOA     PIC X(1).*/
        public StringBasis OD001_IND_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 OD001-STA-INF-INTEGRA  PIC X(1).*/
        public StringBasis OD001_STA_INF_INTEGRA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}