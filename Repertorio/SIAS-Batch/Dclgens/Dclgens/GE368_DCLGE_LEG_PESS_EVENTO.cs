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
    public class GE368_DCLGE_LEG_PESS_EVENTO : VarBasis
    {
        /*"    10 GE368-NUM-PESSOA     PIC S9(9) USAGE COMP.*/
        public IntBasis GE368_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE368-NUM-OCORR-MOVTO  PIC S9(9) USAGE COMP.*/
        public IntBasis GE368_NUM_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE368-SEQ-ENTIDADE   PIC S9(4) USAGE COMP.*/
        public IntBasis GE368_SEQ_ENTIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE368-IND-ENTIDADE   PIC S9(4) USAGE COMP.*/
        public IntBasis GE368_IND_ENTIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE368-DTH-CADASTRAMENTO  PIC X(26).*/
        public StringBasis GE368_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
    }
}