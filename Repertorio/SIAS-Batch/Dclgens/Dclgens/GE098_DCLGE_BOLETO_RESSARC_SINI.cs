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
    public class GE098_DCLGE_BOLETO_RESSARC_SINI : VarBasis
    {
        /*"    10 GE098-NUM-OCORR-MOVTO       PIC S9(18)V USAGE COMP-3.*/
        public DoubleBasis GE098_NUM_OCORR_MOVTO { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(18)V"), 0);
        /*"    10 GE098-NUM-APOL-SINISTRO       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis GE098_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 GE098-COD-OPERACAO   PIC S9(4) USAGE COMP.*/
        public IntBasis GE098_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE098-NUM-OCORR-HISTORICO       PIC S9(4) USAGE COMP.*/
        public IntBasis GE098_NUM_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE098-NUM-RESSARC    PIC S9(9) USAGE COMP.*/
        public IntBasis GE098_NUM_RESSARC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE098-SEQ-RESSARC    PIC S9(4) USAGE COMP.*/
        public IntBasis GE098_SEQ_RESSARC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE098-NUM-PARCELA    PIC S9(9) USAGE COMP.*/
        public IntBasis GE098_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE098-NUM-NOSSO-TITULO       PIC S9(16)V USAGE COMP-3.*/
        public DoubleBasis GE098_NUM_NOSSO_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V"), 0);
        /*"    10 GE098-NSAS           PIC S9(4) USAGE COMP.*/
        public IntBasis GE098_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE098-IDE-SISTEMA    PIC X(2).*/
        public StringBasis GE098_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE098-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE098_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}