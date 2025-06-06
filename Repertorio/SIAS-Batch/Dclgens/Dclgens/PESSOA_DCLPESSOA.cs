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
    public class PESSOA_DCLPESSOA : VarBasis
    {
        /*"    10 PESSOA-COD-PESSOA    PIC S9(9) USAGE COMP.*/
        public IntBasis PESSOA_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PESSOA-NOME-PESSOA   PIC X(40).*/
        public StringBasis PESSOA_NOME_PESSOA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 PESSOA-TIMESTAMP     PIC X(26).*/
        public StringBasis PESSOA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 PESSOA-COD-USUARIO   PIC X(8).*/
        public StringBasis PESSOA_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PESSOA-TIPO-PESSOA   PIC X(1).*/
        public StringBasis PESSOA_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PESSOA-SIGLA-PESSOA  PIC X(10).*/
        public StringBasis PESSOA_SIGLA_PESSOA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}