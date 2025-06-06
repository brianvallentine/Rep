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
    public class LOTBONUS_DCLLOTBONUS01 : VarBasis
    {
        /*"    10 LOTBONUS-COD-LOT-FENAL  PIC S9(9) USAGE COMP.*/
        public IntBasis LOTBONUS_COD_LOT_FENAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTBONUS-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis LOTBONUS_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 LOTBONUS-DTINIVIG    PIC X(10).*/
        public StringBasis LOTBONUS_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LOTBONUS-DTTERVIG    PIC X(10).*/
        public StringBasis LOTBONUS_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LOTBONUS-COD-REGIAO  PIC S9(4) USAGE COMP.*/
        public IntBasis LOTBONUS_COD_REGIAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTBONUS-TIPO-BONUS  PIC S9(4) USAGE COMP.*/
        public IntBasis LOTBONUS_TIPO_BONUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTBONUS-PERCENT-BONUS  PIC S9(3)V9(5) USAGE COMP-3.*/
        public DoubleBasis LOTBONUS_PERCENT_BONUS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(5)"), 5);
        /*"    10 LOTBONUS-DATA-GERA-MOV  PIC X(10).*/
        public StringBasis LOTBONUS_DATA_GERA_MOV { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LOTBONUS-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis LOTBONUS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTBONUS-TIMESTAMP   PIC X(26).*/
        public StringBasis LOTBONUS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}