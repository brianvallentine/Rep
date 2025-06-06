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
    public class CODIGOPE_CODIGOPE_DES_OPE_PORTALPJ : VarBasis
    {
        /*"       49 CODIGOPE-DES-OPE-PORTALPJ-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis CODIGOPE_DES_OPE_PORTALPJ_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 CODIGOPE-DES-OPE-PORTALPJ-TEXT          PIC X(100).*/
        public StringBasis CODIGOPE_DES_OPE_PORTALPJ_TEXT { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
    }
}