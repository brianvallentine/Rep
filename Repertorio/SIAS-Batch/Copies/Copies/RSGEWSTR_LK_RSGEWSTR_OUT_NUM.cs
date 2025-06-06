using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class RSGEWSTR_LK_RSGEWSTR_OUT_NUM : VarBasis
    {
        /*"  05  LK-RSGEWSTR-OUT-NUM-LGTH       PIC S9(004)  COMP-5*/
        public IntBasis LK_RSGEWSTR_OUT_NUM_LGTH { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  05  LK-RSGEWSTR-OUT-NUM-DATA       PIC  X(030)*/
        public StringBasis LK_RSGEWSTR_OUT_NUM_DATA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"*/
    }
}