using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBSI1000_SI1000S_SAIDA : VarBasis
    {
        /*"    10    SI1000S-VALOR-CALCULADO      PIC  S9(013)V99 COMP-3*/
        public DoubleBasis SI1000S_VALOR_CALCULADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"    10    SI1000S-ERRO-PARAGRAFO       PIC   X(003)*/
        public StringBasis SI1000S_ERRO_PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"    10    SI1000S-ERRO-SQLCODE         PIC  S9(003)    COMP-3*/
        public IntBasis SI1000S_ERRO_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"    10    SI1000S-ERRO-MENSAGEM        PIC   X(080)*/
        public StringBasis SI1000S_ERRO_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
        /*"*/
    }
}