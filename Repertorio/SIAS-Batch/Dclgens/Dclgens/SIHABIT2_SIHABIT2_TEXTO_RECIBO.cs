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
    public class SIHABIT2_SIHABIT2_TEXTO_RECIBO : VarBasis
    {
        /*"       49 SIHABIT2-TEXTO-RECIBO-LEN  PIC S9(4) USAGE COMP.*/
        public IntBasis SIHABIT2_TEXTO_RECIBO_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 SIHABIT2-TEXTO-RECIBO-TEXT  PIC X(500).*/
        public StringBasis SIHABIT2_TEXTO_RECIBO_TEXT { get; set; } = new StringBasis(new PIC("X", "500", "X(500)."), @"");
        /*"*/
    }
}