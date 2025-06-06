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
    public class PARAGEEM_DCLPARM_AGENCI_EMP : VarBasis
    {
        /*"    10 PARAGEEM-PERI-PAGAMENTO       PIC S9(4) USAGE COMP.*/
        public IntBasis PARAGEEM_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARAGEEM-DATA-INIVIGENCIA       PIC X(10).*/
        public StringBasis PARAGEEM_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PARAGEEM-DATA-TERVIGENCIA       PIC X(10).*/
        public StringBasis PARAGEEM_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PARAGEEM-PCCOMSUR    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARAGEEM_PCCOMSUR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 PARAGEEM-PCCOMGCO    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARAGEEM_PCCOMGCO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 PARAGEEM-PCCOMGER    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARAGEEM_PCCOMGER { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 PARAGEEM-PCCOMVEN    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARAGEEM_PCCOMVEN { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 PARAGEEM-PCADIANTVEN       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARAGEEM_PCADIANTVEN { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 PARAGEEM-COD-USUARIO       PIC X(8).*/
        public StringBasis PARAGEEM_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PARAGEEM-TIMESTAMP   PIC X(26).*/
        public StringBasis PARAGEEM_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 PARAGEEM-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PARAGEEM_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"*/
    }
}