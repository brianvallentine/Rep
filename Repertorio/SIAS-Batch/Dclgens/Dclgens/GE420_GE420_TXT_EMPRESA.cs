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
    public class GE420_GE420_TXT_EMPRESA : VarBasis
    {
        /*"       49 GE420-TXT-EMPRESA-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis GE420_TXT_EMPRESA_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 GE420-TXT-EMPRESA-TEXT          PIC X(200).*/
        public StringBasis GE420_TXT_EMPRESA_TEXT { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
        /*"    10 GE420-COD-DOC-SIACC  PIC X(30).*/
    }
}