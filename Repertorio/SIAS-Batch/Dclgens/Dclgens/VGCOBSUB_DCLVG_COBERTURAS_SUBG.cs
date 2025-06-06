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
    public class VGCOBSUB_DCLVG_COBERTURAS_SUBG : VarBasis
    {
        /*"    10 VGCOBSUB-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis VGCOBSUB_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 VGCOBSUB-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis VGCOBSUB_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGCOBSUB-RAMO-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis VGCOBSUB_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGCOBSUB-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis VGCOBSUB_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGCOBSUB-MODALI-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis VGCOBSUB_MODALI_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGCOBSUB-IMP-SEGURADA-IX  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGCOBSUB_IMP_SEGURADA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VGCOBSUB-PRM-TARIFARIO-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis VGCOBSUB_PRM_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 VGCOBSUB-IMP-SEGURADA-VAR  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGCOBSUB_IMP_SEGURADA_VAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VGCOBSUB-PRM-TARIFARIO-VAR  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis VGCOBSUB_PRM_TARIFARIO_VAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 VGCOBSUB-PCT-COBERTURA  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGCOBSUB_PCT_COBERTURA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 VGCOBSUB-FATOR-MULTIPLICA  PIC S9(4) USAGE COMP.*/
        public IntBasis VGCOBSUB_FATOR_MULTIPLICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGCOBSUB-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis VGCOBSUB_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VGCOBSUB-TRATAMENTO-FATURA  PIC X(1).*/
        public StringBasis VGCOBSUB_TRATAMENTO_FATURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VGCOBSUB-TRATAMENTO-PRMTOT  PIC X(1).*/
        public StringBasis VGCOBSUB_TRATAMENTO_PRMTOT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VGCOBSUB-SIT-COBERTURA  PIC X(1).*/
        public StringBasis VGCOBSUB_SIT_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VGCOBSUB-COD-USUARIO  PIC X(8).*/
        public StringBasis VGCOBSUB_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VGCOBSUB-TIMESTAMP   PIC X(26).*/
        public StringBasis VGCOBSUB_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 VGCOBSUB-VLR-LIM-MIN-COBER  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGCOBSUB_VLR_LIM_MIN_COBER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VGCOBSUB-VLR-LIM-MAX-COBER  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGCOBSUB_VLR_LIM_MAX_COBER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"*/
    }
}