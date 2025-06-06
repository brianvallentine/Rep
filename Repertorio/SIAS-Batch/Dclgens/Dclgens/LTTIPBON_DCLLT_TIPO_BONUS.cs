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
    public class LTTIPBON_DCLLT_TIPO_BONUS : VarBasis
    {
        /*"    10 LTTIPBON-COD-BONUS   PIC S9(4) USAGE COMP.*/
        public IntBasis LTTIPBON_COD_BONUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LTTIPBON-DESCR-BONUS  PIC X(30).*/
        public StringBasis LTTIPBON_DESCR_BONUS { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 LTTIPBON-ABREV-BONUS  PIC X(10).*/
        public StringBasis LTTIPBON_ABREV_BONUS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
    }
}