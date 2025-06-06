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
    public class APOLICOB_DCLAPOLICE_COBERTURAS : VarBasis
    {
        /*"    10 APOLICOB-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis APOLICOB_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 APOLICOB-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis APOLICOB_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLICOB-NUM-ITEM    PIC S9(9) USAGE COMP.*/
        public IntBasis APOLICOB_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLICOB-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICOB_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICOB-RAMO-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICOB_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICOB-MODALI-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICOB_MODALI_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICOB-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICOB_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICOB-IMP-SEGURADA-IX  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 APOLICOB-PRM-TARIFARIO-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis APOLICOB_PRM_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 APOLICOB-IMP-SEGURADA-VAR  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_VAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 APOLICOB-PRM-TARIFARIO-VAR  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis APOLICOB_PRM_TARIFARIO_VAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 APOLICOB-PCT-COBERTURA  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis APOLICOB_PCT_COBERTURA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 APOLICOB-FATOR-MULTIPLICA  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICOB_FATOR_MULTIPLICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICOB-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis APOLICOB_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 APOLICOB-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis APOLICOB_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 APOLICOB-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis APOLICOB_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLICOB-TIMESTAMP   PIC X(26).*/
        public StringBasis APOLICOB_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 APOLICOB-SIT-REGISTRO  PIC X(1).*/
        public StringBasis APOLICOB_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}