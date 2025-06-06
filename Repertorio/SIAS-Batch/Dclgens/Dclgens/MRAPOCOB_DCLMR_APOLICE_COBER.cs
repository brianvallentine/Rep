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
    public class MRAPOCOB_DCLMR_APOLICE_COBER : VarBasis
    {
        /*"    10 MRAPOCOB-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis MRAPOCOB_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 MRAPOCOB-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis MRAPOCOB_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MRAPOCOB-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis MRAPOCOB_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRAPOCOB-NUM-ITEM    PIC S9(9) USAGE COMP.*/
        public IntBasis MRAPOCOB_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MRAPOCOB-RAMO-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis MRAPOCOB_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRAPOCOB-MODALI-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis MRAPOCOB_MODALI_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRAPOCOB-DTH-INI-VIG-COBER  PIC X(10).*/
        public StringBasis MRAPOCOB_DTH_INI_VIG_COBER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MRAPOCOB-DTH-FIM-VIG-COBER  PIC X(10).*/
        public StringBasis MRAPOCOB_DTH_FIM_VIG_COBER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MRAPOCOB-IMP-SEGURADA-IX  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MRAPOCOB_IMP_SEGURADA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MRAPOCOB-IMP-SEGURADA-VAR  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MRAPOCOB_IMP_SEGURADA_VAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MRAPOCOB-TAXA-IS     PIC S9(3)V9(7) USAGE COMP-3.*/
        public DoubleBasis MRAPOCOB_TAXA_IS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(7)"), 7);
        /*"    10 MRAPOCOB-PRM-TARIFARIO-IX  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MRAPOCOB_PRM_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MRAPOCOB-PRM-TARIFARIO-VAR  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MRAPOCOB_PRM_TARIFARIO_VAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MRAPOCOB-VAL-MIN-FRANQ-IX  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MRAPOCOB_VAL_MIN_FRANQ_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MRAPOCOB-PCT-FRANQUIA  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MRAPOCOB_PCT_FRANQUIA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MRAPOCOB-SIT-REGISTRO  PIC X(1).*/
        public StringBasis MRAPOCOB_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MRAPOCOB-DTH-TIMESTAMP  PIC X(26).*/
        public StringBasis MRAPOCOB_DTH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 MRAPOCOB-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis MRAPOCOB_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}