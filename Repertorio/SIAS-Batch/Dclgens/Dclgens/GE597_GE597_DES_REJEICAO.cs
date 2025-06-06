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
    public class GE597_GE597_DES_REJEICAO : VarBasis
    {
        /*"       49 GE597-DES-REJEICAO-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis GE597_DES_REJEICAO_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 GE597-DES-REJEICAO-TEXT          PIC X(255).*/
        public StringBasis GE597_DES_REJEICAO_TEXT { get; set; } = new StringBasis(new PIC("X", "255", "X(255)."), @"");
        /*"    10 GE597-STA-REJEICAO   PIC X(1).*/
    }
}