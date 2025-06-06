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
    public class CBO_DCLCBO : VarBasis
    {
        /*"    10 CBO-COD-CBO          PIC S9(9) USAGE COMP.*/
        public IntBasis CBO_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CBO-DESCR-CBO        PIC X(50).*/
        public StringBasis CBO_DESCR_CBO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
        /*"    10 CBO-ABREV-CBO        PIC X(15).*/
        public StringBasis CBO_ABREV_CBO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"*/
    }
}