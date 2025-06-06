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
    public class GECARTEX_GECARTEX_TEXTO_CARTA : VarBasis
    {
        /*"       49 GECARTEX-TEXTO-CARTA-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis GECARTEX_TEXTO_CARTA_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 GECARTEX-TEXTO-CARTA-TEXT          PIC X(19200).*/
        public StringBasis GECARTEX_TEXTO_CARTA_TEXT { get; set; } = new StringBasis(new PIC("X", "19200", "X(19200)."), @"");
        /*"    10 GECARTEX-TIMESTAMP   PIC X(26).*/
    }
}