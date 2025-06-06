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
    public class MR026_DCLMR_PROP_SUB_COBER : VarBasis
    {
        /*"    10 MR026-COD-FONTE      PIC S9(4) USAGE COMP.*/
        public IntBasis MR026_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MR026-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis MR026_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MR026-NUM-PROPOSTA   PIC S9(9) USAGE COMP.*/
        public IntBasis MR026_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MR026-NUM-ITEM       PIC S9(9) USAGE COMP.*/
        public IntBasis MR026_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MR026-NUM-SUB-ITEM   PIC S9(4) USAGE COMP.*/
        public IntBasis MR026_NUM_SUB_ITEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MR026-COD-RUBRICA    PIC S9(9) USAGE COMP.*/
        public IntBasis MR026_COD_RUBRICA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MR026-COD-SUB-RUBRICA  PIC S9(9) USAGE COMP.*/
        public IntBasis MR026_COD_SUB_RUBRICA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MR026-DTH-INI-VIGENCIA  PIC X(10).*/
        public StringBasis MR026_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MR026-DTH-FIM-VIGENCIA  PIC X(10).*/
        public StringBasis MR026_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MR026-VLR-IMP-SEGUR-IX  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MR026_VLR_IMP_SEGUR_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MR026-VLR-IMP-SEGUR-VAR  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MR026_VLR_IMP_SEGUR_VAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MR026-NUM-TAXA-IS-COBER  PIC S9(3)V9(7) USAGE COMP-3.*/
        public DoubleBasis MR026_NUM_TAXA_IS_COBER { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(7)"), 7);
        /*"    10 MR026-VLR-TARIFARIO-IX  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MR026_VLR_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MR026-VLR-TARIFARIO-VAR  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MR026_VLR_TARIFARIO_VAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MR026-PCT-FRANQUIA   PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MR026_PCT_FRANQUIA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MR026-VLR-MIN-INDENIZ  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MR026_VLR_MIN_INDENIZ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MR026-VLR-MAX-INDENIZ  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MR026_VLR_MAX_INDENIZ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MR026-VLR-FRANQ-OBR-IX  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MR026_VLR_FRANQ_OBR_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MR026-STA-REGISTRO   PIC X(1).*/
        public StringBasis MR026_STA_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MR026-DTH-CADASTRAMENTO  PIC X(26).*/
        public StringBasis MR026_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}