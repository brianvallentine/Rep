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
    public class TPRELAC_DCLTIPO_RELACIONAMENT : VarBasis
    {
        /*"    10 COD-RELAC            PIC S9(4) USAGE COMP.*/
        public IntBasis COD_RELAC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 DESCR-RELAC          PIC X(40).*/
        public StringBasis DESCR_RELAC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 ABREV-RELAC          PIC X(10).*/
        public StringBasis ABREV_RELAC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}