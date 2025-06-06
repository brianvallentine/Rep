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
    public class GE404_DCLGE_CONTROLE_SIGCB_HIST : VarBasis
    {
        /*"    10 GE404-NUM-PROPOSTA   PIC S9(16)V USAGE COMP-3.*/
        public DoubleBasis GE404_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V"), 0);
        /*"    10 GE404-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis GE404_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 GE404-NUM-PARCELA    PIC S9(4) USAGE COMP.*/
        public IntBasis GE404_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE404-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis GE404_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 GE404-NUM-ENDOSSO    PIC S9(9) USAGE COMP.*/
        public IntBasis GE404_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE404-SEQ-CONTROLE-SIGCB       PIC S9(4) USAGE COMP.*/
        public IntBasis GE404_SEQ_CONTROLE_SIGCB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE404-SEQ-CONTROLE-SIGCB-HIST       PIC S9(4) USAGE COMP.*/
        public IntBasis GE404_SEQ_CONTROLE_SIGCB_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE404-COD-SITUACAO   PIC X(1).*/
        public StringBasis GE404_COD_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE404-COD-REJEICAO   PIC X(10).*/
        public StringBasis GE404_COD_REJEICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE404-IDE-SISTEMA    PIC X(2).*/
        public StringBasis GE404_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE404-COD-USUARIO    PIC X(8).*/
        public StringBasis GE404_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE404-DTH-PROCESSAMENTO       PIC X(26).*/
        public StringBasis GE404_DTH_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}