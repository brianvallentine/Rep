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
    public class MOVIMEA_DCLMOVIMENTO_EA : VarBasis
    {
        /*"    10 MOVIMEA-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis MOVIMEA_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 MOVIMEA-NSAS         PIC S9(4) USAGE COMP.*/
        public IntBasis MOVIMEA_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVIMEA-TIPO-MOVIMENTO  PIC X(1).*/
        public StringBasis MOVIMEA_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVIMEA-COD-USUARIO  PIC X(8).*/
        public StringBasis MOVIMEA_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 MOVIMEA-TIMESTAMP    PIC X(26).*/
        public StringBasis MOVIMEA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}