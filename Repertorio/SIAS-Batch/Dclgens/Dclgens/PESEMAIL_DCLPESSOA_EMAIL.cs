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
    public class PESEMAIL_DCLPESSOA_EMAIL : VarBasis
    {
        /*"    10 COD-PESSOA           PIC S9(9) USAGE COMP.*/
        public IntBasis COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SEQ-EMAIL            PIC S9(4) USAGE COMP.*/
        public IntBasis SEQ_EMAIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EMAIL                PIC X(40).*/
        public StringBasis EMAIL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SITUACAO-EMAIL       PIC X(1).*/
        public StringBasis SITUACAO_EMAIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COD-USUARIO          PIC X(8).*/
        public StringBasis COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 TIMESTAMP            PIC X(26).*/
        public StringBasis TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}