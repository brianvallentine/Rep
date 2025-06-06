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
    public class SX017_SX017_DES_PRODUTO : VarBasis
    {
        /*"       49 SX017-DES-PRODUTO-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis SX017_DES_PRODUTO_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 SX017-DES-PRODUTO-TEXT          PIC X(100).*/
        public StringBasis SX017_DES_PRODUTO_TEXT { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 SX017-DTA-INI-VIGENCIA       PIC X(10).*/
    }
}