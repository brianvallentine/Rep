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
    public class OUTROCOB_DCLOUTROS_COBERTURAS : VarBasis
    {
        /*"    10 OUTROCOB-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis OUTROCOB_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 OUTROCOB-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis OUTROCOB_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OUTROCOB-NUM-PROPOSTA  PIC S9(9) USAGE COMP.*/
        public IntBasis OUTROCOB_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 OUTROCOB-NUM-RISCO   PIC S9(9) USAGE COMP.*/
        public IntBasis OUTROCOB_NUM_RISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 OUTROCOB-RAMO-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis OUTROCOB_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OUTROCOB-MODALI-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis OUTROCOB_MODALI_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OUTROCOB-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis OUTROCOB_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OUTROCOB-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis OUTROCOB_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 OUTROCOB-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis OUTROCOB_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 OUTROCOB-IMP-SEGURADA-IX  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis OUTROCOB_IMP_SEGURADA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 OUTROCOB-IMP-SEGURADA-VAR  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis OUTROCOB_IMP_SEGURADA_VAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 OUTROCOB-TAXA-IS     PIC S9(3)V9(9) USAGE COMP-3.*/
        public DoubleBasis OUTROCOB_TAXA_IS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(9)"), 9);
        /*"    10 OUTROCOB-PRM-ANUAL-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis OUTROCOB_PRM_ANUAL_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 OUTROCOB-PRM-TARIFARIO-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis OUTROCOB_PRM_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 OUTROCOB-PRM-TARIFARIO-VAR  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis OUTROCOB_PRM_TARIFARIO_VAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 OUTROCOB-VAL-FRANQ-OBR-IX  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis OUTROCOB_VAL_FRANQ_OBR_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 OUTROCOB-LIMITE-INDENIZA-IX  PIC S9(10)V9(5) USAGE COMP-3*/
        public DoubleBasis OUTROCOB_LIMITE_INDENIZA_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 OUTROCOB-SIT-REGISTRO  PIC X(1).*/
        public StringBasis OUTROCOB_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 OUTROCOB-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis OUTROCOB_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 OUTROCOB-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis OUTROCOB_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 OUTROCOB-TIMESTAMP   PIC X(26).*/
        public StringBasis OUTROCOB_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}