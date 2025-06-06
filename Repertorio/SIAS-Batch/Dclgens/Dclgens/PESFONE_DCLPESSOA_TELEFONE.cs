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
    public class PESFONE_DCLPESSOA_TELEFONE : VarBasis
    {
        /*"    10 COD-PESSOA           PIC S9(9) USAGE COMP.*/
        public IntBasis COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 TIPO-FONE            PIC S9(4) USAGE COMP.*/
        public IntBasis TIPO_FONE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEQ-FONE             PIC S9(4) USAGE COMP.*/
        public IntBasis SEQ_FONE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 DDI                  PIC S9(4) USAGE COMP.*/
        public IntBasis DDI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 DDD                  PIC S9(4) USAGE COMP.*/
        public IntBasis DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NUM-FONE             PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis NUM_FONE { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 SITUACAO-FONE        PIC X(1).*/
        public StringBasis SITUACAO_FONE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COD-USUARIO          PIC X(8).*/
        public StringBasis COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 TIMESTAMP            PIC X(26).*/
        public StringBasis TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}