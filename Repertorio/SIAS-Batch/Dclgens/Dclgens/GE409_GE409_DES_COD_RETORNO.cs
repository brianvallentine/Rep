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
    public class GE409_GE409_DES_COD_RETORNO : VarBasis
    {
        /*"       49 GE409-DES-COD-RETORNO-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis GE409_DES_COD_RETORNO_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 GE409-DES-COD-RETORNO-TEXT          PIC X(133).*/
        public StringBasis GE409_DES_COD_RETORNO_TEXT { get; set; } = new StringBasis(new PIC("X", "133", "X(133)."), @"");
        /*"*/
    }
}