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
    public class RSGEWSTR_LK_RSGEWSTR_INP_STR : VarBasis
    {
        /*"  05  LK-RSGEWSTR-INP-STR-LGTH       PIC S9(004)  COMP-5*/
        public IntBasis LK_RSGEWSTR_INP_STR_LGTH { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  05  LK-RSGEWSTR-INP-STR-DATA       PIC  X(2000)*/
        public StringBasis LK_RSGEWSTR_INP_STR_DATA { get; set; } = new StringBasis(new PIC("X", "2000", "X(2000)"), @"");
        /*"01 LK-RSGEWSTR-INP-NUM*/
    }
}