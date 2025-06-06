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
    public class GE366_DCLGE_MOVIMENTO : VarBasis
    {
        /*"    10 GE366-NUM-OCORR-MOVTO  PIC S9(9) USAGE COMP.*/
        public IntBasis GE366_NUM_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE366-COD-EVENTO     PIC S9(4) USAGE COMP.*/
        public IntBasis GE366_COD_EVENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE366-IDE-SISTEMA    PIC X(2).*/
        public StringBasis GE366_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE366-DTH-MOVIMENTO  PIC X(10).*/
        public StringBasis GE366_DTH_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE366-IND-ESTRUTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis GE366_IND_ESTRUTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE366-IND-ORIGEM-FUNC  PIC S9(4) USAGE COMP.*/
        public IntBasis GE366_IND_ORIGEM_FUNC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE366-DTH-CADASTRAMENTO  PIC X(26).*/
        public StringBasis GE366_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GE366-IND-EVENTO     PIC S9(4) USAGE COMP.*/
        public IntBasis GE366_IND_EVENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE366-NOM-PROGRAMA   PIC X(8).*/
        public StringBasis GE366_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE366-COD-USUARIO    PIC X(8).*/
        public StringBasis GE366_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"01  IGE-MOVIMENTO.*/
    }
}