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
    public class LOTISG01_DCLLOTIMPSEG01 : VarBasis
    {
        /*"    10 LOTISG01-COD-LOT-FENAL  PIC S9(9) USAGE COMP.*/
        public IntBasis LOTISG01_COD_LOT_FENAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTISG01-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis LOTISG01_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 LOTISG01-NUM-CONTROLE-FENAL  PIC S9(9) USAGE COMP.*/
        public IntBasis LOTISG01_NUM_CONTROLE_FENAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTISG01-RAMO-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis LOTISG01_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTISG01-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis LOTISG01_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTISG01-MODALIDA-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis LOTISG01_MODALIDA_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTISG01-DTINIVIG    PIC X(10).*/
        public StringBasis LOTISG01_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LOTISG01-DTTERVIG    PIC X(10).*/
        public StringBasis LOTISG01_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LOTISG01-COD-MOEDA   PIC S9(4) USAGE COMP.*/
        public IntBasis LOTISG01_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTISG01-IMP-SEG     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis LOTISG01_IMP_SEG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 LOTISG01-SITUACAO    PIC X(1).*/
        public StringBasis LOTISG01_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 LOTISG01-DATA-GERA-MOV  PIC X(10).*/
        public StringBasis LOTISG01_DATA_GERA_MOV { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LOTISG01-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis LOTISG01_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTISG01-TIMESTAMP   PIC X(26).*/
        public StringBasis LOTISG01_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}