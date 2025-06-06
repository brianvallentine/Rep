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
    public class NUMERCOS_DCLNUMERO_COSSEGURO : VarBasis
    {
        /*"    10 NUMERCOS-ORGAO-EMISSOR  PIC S9(4) USAGE COMP.*/
        public IntBasis NUMERCOS_ORGAO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NUMERCOS-COD-CONGENERE  PIC S9(4) USAGE COMP.*/
        public IntBasis NUMERCOS_COD_CONGENERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NUMERCOS-SEQ-ORD-CEDIDO  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMERCOS_SEQ_ORD_CEDIDO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMERCOS-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMERCOS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMERCOS-TIMESTAMP   PIC X(26).*/
        public StringBasis NUMERCOS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}