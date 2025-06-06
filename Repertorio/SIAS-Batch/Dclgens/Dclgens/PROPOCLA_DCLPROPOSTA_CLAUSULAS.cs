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
    public class PROPOCLA_DCLPROPOSTA_CLAUSULAS : VarBasis
    {
        /*"    10 PROPOCLA-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOCLA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOCLA-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOCLA_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOCLA-NUM-PROPOSTA  PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOCLA_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOCLA-RAMO-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOCLA_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOCLA-MODALI-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOCLA_MODALI_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOCLA-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOCLA_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPOCLA-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis PROPOCLA_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOCLA-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis PROPOCLA_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPOCLA-NUM-ITEM    PIC S9(9) USAGE COMP.*/
        public IntBasis PROPOCLA_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPOCLA-COD-CLAUSULA  PIC X(8).*/
        public StringBasis PROPOCLA_COD_CLAUSULA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PROPOCLA-LIMITE-INDENIZA-IX  PIC S9(10)V9(5) USAGE COMP-3*/
        public DoubleBasis PROPOCLA_LIMITE_INDENIZA_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 PROPOCLA-TIMESTAMP   PIC X(26).*/
        public StringBasis PROPOCLA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 PROPOCLA-TIPO-CLAUSULA  PIC X(1).*/
        public StringBasis PROPOCLA_TIPO_CLAUSULA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}