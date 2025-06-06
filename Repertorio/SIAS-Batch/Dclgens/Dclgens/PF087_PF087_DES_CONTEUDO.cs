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
    public class PF087_PF087_DES_CONTEUDO : VarBasis
    {
        /*"       49 PF087-DES-CONTEUDO-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis PF087_DES_CONTEUDO_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 PF087-DES-CONTEUDO-TEXT          PIC X(150).*/
        public StringBasis PF087_DES_CONTEUDO_TEXT { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"    10 PF087-STA-PROCESSAMENTO       PIC X(1).*/
    }
}