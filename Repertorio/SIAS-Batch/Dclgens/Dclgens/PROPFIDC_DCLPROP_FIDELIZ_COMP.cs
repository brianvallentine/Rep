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
    public class PROPFIDC_DCLPROP_FIDELIZ_COMP : VarBasis
    {
        /*"    10 NUM-IDENTIFICACAO    PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NUM_IDENTIFICACAO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 INFORMACAO-COMPL     PIC X(255).*/
        public StringBasis INFORMACAO_COMPL { get; set; } = new StringBasis(new PIC("X", "255", "X(255)."), @"");
        /*"    10 COD-USUARIO          PIC X(8).*/
        public StringBasis COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 TIMESTAMP            PIC X(26).*/
        public StringBasis TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}