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
    public class GECARTEX_DCLGE_CARTA_TEXTO : VarBasis
    {
        /*"    10 GECARTEX-NUM-CARTA   PIC S9(9) USAGE COMP.*/
        public IntBasis GECARTEX_NUM_CARTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GECARTEX-TEXTO-CARTA.*/
        public GECARTEX_GECARTEX_TEXTO_CARTA GECARTEX_TEXTO_CARTA { get; set; } = new GECARTEX_GECARTEX_TEXTO_CARTA();

        public StringBasis GECARTEX_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}