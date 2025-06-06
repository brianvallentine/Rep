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
    public class GE562_GE562_DES_MSG_ERRO : VarBasis
    {
        /*"       49 GE562-DES-MSG-ERRO-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis GE562_DES_MSG_ERRO_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 GE562-DES-MSG-ERRO-TEXT          PIC X(220).*/
        public StringBasis GE562_DES_MSG_ERRO_TEXT { get; set; } = new StringBasis(new PIC("X", "220", "X(220)."), @"");
        /*"*/
    }
}