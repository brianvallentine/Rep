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
    public class AGTABCH1_DCLAGRUPA_TABELAS_CH1 : VarBasis
    {
        /*"    10 AGTABCH1-IDTAB       PIC S9(4) USAGE COMP.*/
        public IntBasis AGTABCH1_IDTAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AGTABCH1-CODIGO-CH1  PIC X(1).*/
        public StringBasis AGTABCH1_CODIGO_CH1 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AGTABCH1-DESCRICAO   PIC X(40).*/
        public StringBasis AGTABCH1_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 AGTABCH1-SITUACAO    PIC X(1).*/
        public StringBasis AGTABCH1_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AGTABCH1-TIMESTAMP   PIC X(26).*/
        public StringBasis AGTABCH1_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}