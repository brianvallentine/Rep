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
    public class GEOBJECT_GEOBJECT_DES_OBJETO : VarBasis
    {
        /*"       49 GEOBJECT-DES-OBJETO-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis GEOBJECT_DES_OBJETO_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 GEOBJECT-DES-OBJETO-TEXT          PIC X(4500).*/
        public StringBasis GEOBJECT_DES_OBJETO_TEXT { get; set; } = new StringBasis(new PIC("X", "4500", "X(4500)."), @"");
        /*"*/
    }
}