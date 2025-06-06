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
    public class LOTTAX01_DCLLOTTAXA01 : VarBasis
    {
        /*"    10 LOTTAX01-COD-LOT-FENAL  PIC S9(9) USAGE COMP.*/
        public IntBasis LOTTAX01_COD_LOT_FENAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTTAX01-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis LOTTAX01_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 LOTTAX01-RAMO-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis LOTTAX01_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTTAX01-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis LOTTAX01_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTTAX01-MODALIDA-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis LOTTAX01_MODALIDA_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTTAX01-DTINIVIG    PIC X(10).*/
        public StringBasis LOTTAX01_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LOTTAX01-DTTERVIG    PIC X(10).*/
        public StringBasis LOTTAX01_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LOTTAX01-TAXA-IS-FENAL  PIC S9(3)V9(9) USAGE COMP-3.*/
        public DoubleBasis LOTTAX01_TAXA_IS_FENAL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(9)"), 9);
        /*"    10 LOTTAX01-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis LOTTAX01_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 LOTTAX01-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis LOTTAX01_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTTAX01-TIMESTAMP   PIC X(26).*/
        public StringBasis LOTTAX01_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 LOTTAX01-IND-TIPO-TAXA  PIC X(1).*/
        public StringBasis LOTTAX01_IND_TIPO_TAXA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 LOTTAX01-PERC-SINISTRO  PIC S9(3)V9(3) USAGE COMP-3.*/
        public DoubleBasis LOTTAX01_PERC_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(3)"), 3);
    }
}