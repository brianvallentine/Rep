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
    public class MRPROCOR_DCLMR_PROPOSTA_COBER : VarBasis
    {
        /*"    10 MRPROCOR-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROCOR_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROCOR-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROCOR_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROCOR-NUM-PROPOSTA  PIC S9(9) USAGE COMP.*/
        public IntBasis MRPROCOR_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MRPROCOR-NUM-ITEM    PIC S9(9) USAGE COMP.*/
        public IntBasis MRPROCOR_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MRPROCOR-RAMO-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROCOR_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROCOR-MODALI-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROCOR_MODALI_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROCOR-DTH-INI-VIGENCIA  PIC X(10).*/
        public StringBasis MRPROCOR_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MRPROCOR-DTH-FIM-VIGENCIA  PIC X(10).*/
        public StringBasis MRPROCOR_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MRPROCOR-IMP-SEGURADA-IX  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MRPROCOR_IMP_SEGURADA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MRPROCOR-IMP-SEGURADA-VAR  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MRPROCOR_IMP_SEGURADA_VAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MRPROCOR-TAXA-IS-COBER  PIC S9(3)V9(7) USAGE COMP-3.*/
        public DoubleBasis MRPROCOR_TAXA_IS_COBER { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(7)"), 7);
        /*"    10 MRPROCOR-PRM-TARIFARIO-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis MRPROCOR_PRM_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 MRPROCOR-PRM-TARIFARIO-VAR  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis MRPROCOR_PRM_TARIFARIO_VAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 MRPROCOR-PCT-FRANQUIA  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MRPROCOR_PCT_FRANQUIA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MRPROCOR-VAL-FRANQ-OBR-IX  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MRPROCOR_VAL_FRANQ_OBR_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MRPROCOR-SIT-REGISTRO  PIC X(1).*/
        public StringBasis MRPROCOR_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MRPROCOR-DTH-TIMESTAMP  PIC X(26).*/
        public StringBasis MRPROCOR_DTH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 MRPROCOR-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis MRPROCOR_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}