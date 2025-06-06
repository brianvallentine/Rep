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
    public class GE149_GE149_NOM_SOCIAL : VarBasis
    {
        /*"       49 GE149-NOM-SOCIAL-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis GE149_NOM_SOCIAL_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 GE149-NOM-SOCIAL-TEXT          PIC X(100).*/
        public StringBasis GE149_NOM_SOCIAL_TEXT { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 GE149-IND-TIPO-ACAO  PIC X(1).*/
    }
}