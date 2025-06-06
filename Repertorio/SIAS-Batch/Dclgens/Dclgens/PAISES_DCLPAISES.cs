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
    public class PAISES_DCLPAISES : VarBasis
    {
        /*"    10 PAISES-COD-PAIS      PIC S9(4) USAGE COMP.*/
        public IntBasis PAISES_COD_PAIS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PAISES-NOME-PAIS     PIC X(20).*/
        public StringBasis PAISES_NOME_PAIS { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 PAISES-SIGLA-PAIS    PIC X(3).*/
        public StringBasis PAISES_SIGLA_PAIS { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 PAISES-DDI           PIC S9(4) USAGE COMP.*/
        public IntBasis PAISES_DDI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
    }
}