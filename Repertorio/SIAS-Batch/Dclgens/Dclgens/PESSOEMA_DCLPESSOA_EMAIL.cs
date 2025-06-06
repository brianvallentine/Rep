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
    public class PESSOEMA_DCLPESSOA_EMAIL : VarBasis
    {
        /*"    10 PESSOEMA-COD-PESSOA  PIC S9(9) USAGE COMP.*/
        public IntBasis PESSOEMA_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PESSOEMA-SEQ-EMAIL   PIC S9(4) USAGE COMP.*/
        public IntBasis PESSOEMA_SEQ_EMAIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PESSOEMA-EMAIL       PIC X(40).*/
        public StringBasis PESSOEMA_EMAIL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 PESSOEMA-SITUACAO-EMAIL       PIC X(1).*/
        public StringBasis PESSOEMA_SITUACAO_EMAIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PESSOEMA-COD-USUARIO       PIC X(8).*/
        public StringBasis PESSOEMA_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PESSOEMA-TIMESTAMP   PIC X(26).*/
        public StringBasis PESSOEMA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}