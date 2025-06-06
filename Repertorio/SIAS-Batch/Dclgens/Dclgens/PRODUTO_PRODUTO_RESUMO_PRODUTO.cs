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
    public class PRODUTO_PRODUTO_RESUMO_PRODUTO : VarBasis
    {
        /*"       49 PRODUTO-RESUMO-PRODUTO-LEN          PIC S9(4) USAGE COMP*/
        public IntBasis PRODUTO_RESUMO_PRODUTO_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 PRODUTO-RESUMO-PRODUTO-TEXT          PIC X(1922)*/
        public StringBasis PRODUTO_RESUMO_PRODUTO_TEXT { get; set; } = new StringBasis(new PIC("X", "1922", "X(1922)"), @"");
        /*"    10 PRODUTO-NUM-PROCESSO-SUSEP       PIC X(25)*/
    }
}