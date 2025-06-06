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
    public class COVSICOB_DCLCONVERSAO_SICOB : VarBasis
    {
        /*"    10 NUM-PROPOSTA-SIVPF   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NUM_PROPOSTA_SIVPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 NUM-SICOB            PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NUM_SICOB { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 COD-EMPRESA-SIVPF    PIC S9(4) USAGE COMP.*/
        public IntBasis COD_EMPRESA_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUTO-SIVPF        PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUTO_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AGEPGTO              PIC S9(4) USAGE COMP.*/
        public IntBasis AGEPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 DATA-OPERACAO        PIC X(10).*/
        public StringBasis DATA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 DATA-QUITACAO        PIC X(10).*/
        public StringBasis DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VAL-RCAP             PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VAL_RCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 COD-USUARIO          PIC X(8).*/
        public StringBasis COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 TIMESTAMP            PIC X(26).*/
        public StringBasis TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}