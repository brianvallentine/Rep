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
    public class CLIENEMA_DCLCLIENTE_EMAIL : VarBasis
    {
        /*"    10 CLIENEMA-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis CLIENEMA_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CLIENEMA-SEQ-EMAIL   PIC S9(4) USAGE COMP.*/
        public IntBasis CLIENEMA_SEQ_EMAIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CLIENEMA-EMAIL       PIC X(40).*/
        public StringBasis CLIENEMA_EMAIL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"*/
    }
}