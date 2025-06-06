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
    public class MOVFEDCA_DCLMOVIMEN_FED_CAP_VA : VarBasis
    {
        /*"    10 MOVFEDCA-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis MOVFEDCA_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 MOVFEDCA-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis MOVFEDCA_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVFEDCA-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis MOVFEDCA_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVFEDCA-NUM-PROPOSTA  PIC S9(9) USAGE COMP.*/
        public IntBasis MOVFEDCA_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVFEDCA-DTMVFDCAP   PIC X(10).*/
        public StringBasis MOVFEDCA_DTMVFDCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVFEDCA-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis MOVFEDCA_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVFEDCA-QUANT-TIT-CAPITALI  PIC S9(4) USAGE COMP.*/
        public IntBasis MOVFEDCA_QUANT_TIT_CAPITALI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVFEDCA-VAL-CUSTO-CAPITALI  PIC S9(13)V9(2) USAGE COMP-3*/
        public DoubleBasis MOVFEDCA_VAL_CUSTO_CAPITALI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVFEDCA-SITUACAO    PIC X(1).*/
        public StringBasis MOVFEDCA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVFEDCA-NRTITFDCAP  PIC S9(12)V USAGE COMP-3.*/
        public DoubleBasis MOVFEDCA_NRTITFDCAP { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(12)V"), 0);
        /*"    10 MOVFEDCA-NRMSCAP     PIC S9(4) USAGE COMP.*/
        public IntBasis MOVFEDCA_NRMSCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVFEDCA-NUM-SEQUENCIA  PIC S9(9) USAGE COMP.*/
        public IntBasis MOVFEDCA_NUM_SEQUENCIA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVFEDCA-TIMESTAMP   PIC X(26).*/
        public StringBasis MOVFEDCA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 MOVFEDCA-CODPRODU    PIC S9(9) USAGE COMP.*/
        public IntBasis MOVFEDCA_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}