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
    public class UNIDAFED_DCLUNIDADE_FEDERACAO : VarBasis
    {
        /*"    10 UNIDAFED-SIGLA-UF    PIC X(2).*/
        public StringBasis UNIDAFED_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 UNIDAFED-COD-PAIS    PIC S9(4) USAGE COMP.*/
        public IntBasis UNIDAFED_COD_PAIS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 UNIDAFED-NOME-UF     PIC X(20).*/
        public StringBasis UNIDAFED_NOME_UF { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"*/
    }
}