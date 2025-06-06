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
    public class RAMOCOMP_DCLRAMO_COMPLEMENTAR : VarBasis
    {
        /*"    10 RAMOCOMP-RAMO-EMISSOR  PIC S9(4) USAGE COMP.*/
        public IntBasis RAMOCOMP_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RAMOCOMP-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis RAMOCOMP_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 RAMOCOMP-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis RAMOCOMP_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 RAMOCOMP-TIPO-FRACIONAMENTO  PIC X(1).*/
        public StringBasis RAMOCOMP_TIPO_FRACIONAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 RAMOCOMP-IND-ISENCAO-CUSTO  PIC X(1).*/
        public StringBasis RAMOCOMP_IND_ISENCAO_CUSTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 RAMOCOMP-PCT-JURO-RAMO  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis RAMOCOMP_PCT_JURO_RAMO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 RAMOCOMP-PCT-IOCC-RAMO  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis RAMOCOMP_PCT_IOCC_RAMO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 RAMOCOMP-PRM-MIN-APOLICE  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis RAMOCOMP_PRM_MIN_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 RAMOCOMP-PRM-MIN-ENDOSSO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis RAMOCOMP_PRM_MIN_ENDOSSO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 RAMOCOMP-IND-RAMO-INDEX  PIC X(1).*/
        public StringBasis RAMOCOMP_IND_RAMO_INDEX { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 RAMOCOMP-TIPO-RISCO  PIC X(1).*/
        public StringBasis RAMOCOMP_TIPO_RISCO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 RAMOCOMP-GRUPO-RAMO  PIC S9(4) USAGE COMP.*/
        public IntBasis RAMOCOMP_GRUPO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RAMOCOMP-NUM-MAX-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis RAMOCOMP_NUM_MAX_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RAMOCOMP-PRM-MIN-PARCELA  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis RAMOCOMP_PRM_MIN_PARCELA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 RAMOCOMP-PRM-MAX-PARCELA  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis RAMOCOMP_PRM_MAX_PARCELA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 RAMOCOMP-PRM-MIN-CTAMENS  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis RAMOCOMP_PRM_MIN_CTAMENS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 RAMOCOMP-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis RAMOCOMP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 RAMOCOMP-TIMESTAMP   PIC X(26).*/
        public StringBasis RAMOCOMP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}