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
    public class GE118_GE118_DES_APRESENTA_DOC : VarBasis
    {
        /*"       49 GE118-DES-APRESENTA-DOC-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis GE118_DES_APRESENTA_DOC_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 GE118-DES-APRESENTA-DOC-TEXT          PIC X(100).*/
        public StringBasis GE118_DES_APRESENTA_DOC_TEXT { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"*/
    }
}