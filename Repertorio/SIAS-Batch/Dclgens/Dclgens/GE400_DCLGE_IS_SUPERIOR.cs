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
    public class GE400_DCLGE_IS_SUPERIOR : VarBasis
    {
        /*"    10 GE400-NUM-APOLICE    PIC S9(13)V USAGE COMP-3*/
        public DoubleBasis GE400_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 GE400-COD-PRODUTO    PIC S9(4) USAGE COMP*/
        public IntBasis GE400_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE400-SEQ-IS-SUPERIOR       PIC S9(4) USAGE COMP*/
        public IntBasis GE400_SEQ_IS_SUPERIOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE400-NUM-CPF        PIC S9(11)V USAGE COMP-3*/
        public DoubleBasis GE400_NUM_CPF { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 GE400-STA-IS-SUPERIOR       PIC X(1)*/
        public StringBasis GE400_STA_IS_SUPERIOR { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"");
        /*"    10 GE400-DTA-IS-SUPERIOR       PIC X(10)*/
        public StringBasis GE400_DTA_IS_SUPERIOR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"    10 GE400-NOM-PROGRAMA   PIC X(8)*/
        public StringBasis GE400_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)"), @"");
        /*"    10 GE400-COD-USUARIO    PIC X(8)*/
        public StringBasis GE400_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)"), @"");
        /*"    10 GE400-DTH-CADASTRAMENTO       PIC X(26)*/
        public StringBasis GE400_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"");
        /*"*/
    }
}