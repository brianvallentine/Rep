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
    public class GE367_DCLGE_LEGADO_PESSOA : VarBasis
    {
        /*"    10 GE367-NUM-PESSOA     PIC S9(9) USAGE COMP.*/
        public IntBasis GE367_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE367-NUM-OCORR-MOVTO  PIC S9(9) USAGE COMP.*/
        public IntBasis GE367_NUM_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE367-IND-RELACIONAMENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis GE367_IND_RELACIONAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE367-DTH-CADASTRAMENTO  PIC X(26).*/
        public StringBasis GE367_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}