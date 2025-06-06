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
    public class PROPOCOB_DCLPROPOSTA_COBERTURA : VarBasis
    {
        /*"    10 PROPOCOB-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOCOB_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOCOB-NUM-PROPOSTA  PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOCOB_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOCOB-NUM-ITEM    PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOCOB_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOCOB-RAMO-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOCOB_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOCOB-MODALI-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOCOB_MODALI_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOCOB-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOCOB_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOCOB-IMP-SEGURADA-IX  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PROPOCOB_IMP_SEGURADA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PROPOCOB-PRM-TARIFARIO-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis PROPOCOB_PRM_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 PROPOCOB-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis PROPOCOB_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOCOB-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis PROPOCOB_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOCOB-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOCOB_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOCOB-TIMESTAMP   PIC X(26).*/
        public StringBasis PROPOCOB_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}