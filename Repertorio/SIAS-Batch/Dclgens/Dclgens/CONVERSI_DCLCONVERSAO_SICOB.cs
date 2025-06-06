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
    public class CONVERSI_DCLCONVERSAO_SICOB : VarBasis
    {
        /*"    10 CONVERSI-NUM-PROPOSTA-SIVPF  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis CONVERSI_NUM_PROPOSTA_SIVPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 CONVERSI-NUM-SICOB   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis CONVERSI_NUM_SICOB { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 CONVERSI-COD-EMPRESA-SIVPF  PIC S9(4) USAGE COMP.*/
        public IntBasis CONVERSI_COD_EMPRESA_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONVERSI-COD-PRODUTO-SIVPF  PIC S9(4) USAGE COMP.*/
        public IntBasis CONVERSI_COD_PRODUTO_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONVERSI-AGEPGTO     PIC S9(4) USAGE COMP.*/
        public IntBasis CONVERSI_AGEPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONVERSI-DATA-OPERACAO  PIC X(10).*/
        public StringBasis CONVERSI_DATA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CONVERSI-DATA-QUITACAO  PIC X(10).*/
        public StringBasis CONVERSI_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CONVERSI-VAL-RCAP    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONVERSI_VAL_RCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONVERSI-COD-USUARIO  PIC X(8).*/
        public StringBasis CONVERSI_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 CONVERSI-TIMESTAMP   PIC X(26).*/
        public StringBasis CONVERSI_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}