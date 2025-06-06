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
    public class TPENDER_DCLTIPO_ENDERECO : VarBasis
    {
        /*"    10 TIPO-ENDER           PIC S9(4) USAGE COMP.*/
        public IntBasis TIPO_ENDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 DESCR-TIPO-ENDER     PIC X(20).*/
        public StringBasis DESCR_TIPO_ENDER { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 ABREV-TIPO-ENDER     PIC X(6).*/
        public StringBasis ABREV_TIPO_ENDER { get; set; } = new StringBasis(new PIC("X", "6", "X(6)."), @"");
        /*"*/
    }
}