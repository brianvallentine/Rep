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
    public class OD009_DCLOD_PESS_CONTA_BANC : VarBasis
    {
        /*"    10 OD009-NUM-PESSOA     PIC S9(9) USAGE COMP.*/
        public IntBasis OD009_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 OD009-SEQ-CONTA-BANCARIA       PIC S9(4) USAGE COMP.*/
        public IntBasis OD009_SEQ_CONTA_BANCARIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OD009-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis OD009_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 OD009-STA-CONTA      PIC X(1).*/
        public StringBasis OD009_STA_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 OD009-COD-BANCO      PIC S9(4) USAGE COMP.*/
        public IntBasis OD009_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OD009-COD-AGENCIA    PIC S9(4) USAGE COMP.*/
        public IntBasis OD009_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OD009-IND-CONTA-BANCARIA       PIC S9(4) USAGE COMP.*/
        public IntBasis OD009_IND_CONTA_BANCARIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OD009-NUM-CONTA      PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis OD009_NUM_CONTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 OD009-NUM-DV-CONTA   PIC X(2).*/
        public StringBasis OD009_NUM_DV_CONTA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 OD009-NUM-OPERACAO-CONTA       PIC S9(4) USAGE COMP.*/
        public IntBasis OD009_NUM_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}