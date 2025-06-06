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
    public class PF089_PF089_DES_ERRO_PROPOSTA : VarBasis
    {
        /*"       49 PF089-DES-ERRO-PROPOSTA-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis PF089_DES_ERRO_PROPOSTA_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 PF089-DES-ERRO-PROPOSTA-TEXT          PIC X(150).*/
        public StringBasis PF089_DES_ERRO_PROPOSTA_TEXT { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"*/
    }
}