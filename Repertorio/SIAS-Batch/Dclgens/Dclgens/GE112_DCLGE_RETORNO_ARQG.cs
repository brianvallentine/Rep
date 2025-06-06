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
    public class GE112_DCLGE_RETORNO_ARQG : VarBasis
    {
        /*"    10 GE112-NUM-OCORR-MOVTO       PIC S9(18)V USAGE COMP-3.*/
        public DoubleBasis GE112_NUM_OCORR_MOVTO { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(18)V"), 0);
        /*"    10 GE112-SEQ-RETORNO-MOVIMENTO       PIC S9(4) USAGE COMP.*/
        public IntBasis GE112_SEQ_RETORNO_MOVIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE112-COD-ERRO       PIC S9(9) USAGE COMP.*/
        public IntBasis GE112_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE112-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE112_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}