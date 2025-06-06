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
    public class AU055_DCLAU_HIS_PROP_CONV : VarBasis
    {
        /*"    10 AU055-NUM-PROPOSTA-VC       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis AU055_NUM_PROPOSTA_VC { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 AU055-SEQ-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis AU055_SEQ_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AU055-NOM-PROGRAMA   PIC X(8).*/
        public StringBasis AU055_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 AU055-DTH-OPERACAO   PIC X(10).*/
        public StringBasis AU055_DTH_OPERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 AU055-IND-OPERACAO   PIC X(3).*/
        public StringBasis AU055_IND_OPERACAO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 AU055-DTH-MOVTO-ARQUIVO       PIC X(10).*/
        public StringBasis AU055_DTH_MOVTO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 AU055-NUM-ARQUIVO    PIC S9(9) USAGE COMP.*/
        public IntBasis AU055_NUM_ARQUIVO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AU055-STA-ERRO       PIC X(1).*/
        public StringBasis AU055_STA_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AU055-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis AU055_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 AU055-COD-CONGENERE  PIC S9(4) USAGE COMP.*/
        public IntBasis AU055_COD_CONGENERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}