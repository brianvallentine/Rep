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
    public class CB039_DCLCB_PESS_PENDENCIA : VarBasis
    {
        /*"    10 CB039-NUM-OCORR-MOVTO  PIC S9(9) USAGE COMP.*/
        public IntBasis CB039_NUM_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CB039-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis CB039_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 CB039-NUM-ENDOSSO    PIC S9(9) USAGE COMP.*/
        public IntBasis CB039_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CB039-NUM-PARCELA    PIC S9(4) USAGE COMP.*/
        public IntBasis CB039_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CB039-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis CB039_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CB039-HORA-OPERACAO  PIC X(8).*/
        public StringBasis CB039_HORA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"01  ICB-PESS-PENDENCIA.*/
    }
}