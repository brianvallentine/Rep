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
    public class GE576_GE576_DES_RETORNO_ARQ_H : VarBasis
    {
        /*"       49 GE576-DES-RETORNO-ARQ-H-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis GE576_DES_RETORNO_ARQ_H_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 GE576-DES-RETORNO-ARQ-H-TEXT          PIC X(220).*/
        public StringBasis GE576_DES_RETORNO_ARQ_H_TEXT { get; set; } = new StringBasis(new PIC("X", "220", "X(220)."), @"");
        /*"    10 GE576-STA-COD-RETORNO-ARQ-H       PIC X(1).*/
    }
}