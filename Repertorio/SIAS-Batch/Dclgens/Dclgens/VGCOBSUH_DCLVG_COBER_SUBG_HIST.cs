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
    public class VGCOBSUH_DCLVG_COBER_SUBG_HIST : VarBasis
    {
        /*"    10 VGCOBSUH-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis VGCOBSUH_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 VGCOBSUH-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis VGCOBSUH_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGCOBSUH-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis VGCOBSUH_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VGCOBSUH-RAMO-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis VGCOBSUH_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGCOBSUH-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis VGCOBSUH_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGCOBSUH-MODALI-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis VGCOBSUH_MODALI_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGCOBSUH-IMP-SEGURADA-IX  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGCOBSUH_IMP_SEGURADA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VGCOBSUH-PRM-TARIFARIO-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis VGCOBSUH_PRM_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 VGCOBSUH-IMP-SEGURADA-VAR  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGCOBSUH_IMP_SEGURADA_VAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VGCOBSUH-PRM-TARIFARIO-VAR  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis VGCOBSUH_PRM_TARIFARIO_VAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 VGCOBSUH-PCT-COBERTURA  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGCOBSUH_PCT_COBERTURA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 VGCOBSUH-FATOR-MULTIPLICA  PIC S9(4) USAGE COMP.*/
        public IntBasis VGCOBSUH_FATOR_MULTIPLICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGCOBSUH-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis VGCOBSUH_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VGCOBSUH-TRATAMENTO-FATURA  PIC X(1).*/
        public StringBasis VGCOBSUH_TRATAMENTO_FATURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VGCOBSUH-TRATAMENTO-PRMTOT  PIC X(1).*/
        public StringBasis VGCOBSUH_TRATAMENTO_PRMTOT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VGCOBSUH-COD-USUARIO  PIC X(8).*/
        public StringBasis VGCOBSUH_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VGCOBSUH-TIMESTAMP   PIC X(26).*/
        public StringBasis VGCOBSUH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 VGCOBSUH-VLR-LIM-MIN-COBER  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGCOBSUH_VLR_LIM_MIN_COBER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VGCOBSUH-VLR-LIM-MAX-COBER  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGCOBSUH_VLR_LIM_MAX_COBER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"*/
    }
}