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
    public class AUTOCOBE_DCLAUTO_COBERTURAS : VarBasis
    {
        /*"    10 AUTOCOBE-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis AUTOCOBE_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AUTOCOBE-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis AUTOCOBE_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AUTOCOBE-NUM-PROPOSTA       PIC S9(9) USAGE COMP.*/
        public IntBasis AUTOCOBE_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AUTOCOBE-NUM-ITEM    PIC S9(9) USAGE COMP.*/
        public IntBasis AUTOCOBE_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AUTOCOBE-RAMO-COBERTURA       PIC S9(4) USAGE COMP.*/
        public IntBasis AUTOCOBE_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AUTOCOBE-MODALI-COBERTURA       PIC S9(4) USAGE COMP.*/
        public IntBasis AUTOCOBE_MODALI_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AUTOCOBE-COD-COBERTURA       PIC S9(4) USAGE COMP.*/
        public IntBasis AUTOCOBE_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AUTOCOBE-DATA-INIVIGENCIA       PIC X(10).*/
        public StringBasis AUTOCOBE_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 AUTOCOBE-DATA-TERVIGENCIA       PIC X(10).*/
        public StringBasis AUTOCOBE_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 AUTOCOBE-IMP-SEGURADA-IX       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AUTOCOBE_IMP_SEGURADA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AUTOCOBE-IMP-SEGURADA-VAR       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AUTOCOBE_IMP_SEGURADA_VAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AUTOCOBE-TAXAS-IS    PIC S9(2)V9(5) USAGE COMP-3.*/
        public DoubleBasis AUTOCOBE_TAXAS_IS { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(2)V9(5)"), 5);
        /*"    10 AUTOCOBE-PRM-ANUAL-IX       PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis AUTOCOBE_PRM_ANUAL_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 AUTOCOBE-PRM-TARIFARIO-IX       PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis AUTOCOBE_PRM_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 AUTOCOBE-PRM-TARIFARIO-VAR       PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis AUTOCOBE_PRM_TARIFARIO_VAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 AUTOCOBE-SIT-REGISTRO       PIC X(1).*/
        public StringBasis AUTOCOBE_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AUTOCOBE-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis AUTOCOBE_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 AUTOCOBE-NUM-ENDOSSO       PIC S9(9) USAGE COMP.*/
        public IntBasis AUTOCOBE_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AUTOCOBE-TIMESTAMP   PIC X(26).*/
        public StringBasis AUTOCOBE_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 AUTOCOBE-VLR-FRANQUIA-IX       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AUTOCOBE_VLR_FRANQUIA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AUTOCOBE-VLR-FRANQUIA-VAR       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AUTOCOBE_VLR_FRANQUIA_VAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"*/
    }
}