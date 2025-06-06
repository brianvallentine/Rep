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
    public class APOLICLA_DCLAPOLICE_CLAUSULAS : VarBasis
    {
        /*"    10 APOLICLA-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis APOLICLA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLICLA-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis APOLICLA_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 APOLICLA-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis APOLICLA_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLICLA-RAMO-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICLA_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICLA-MODALI-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICLA_MODALI_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICLA-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICLA_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICLA-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis APOLICLA_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 APOLICLA-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis APOLICLA_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 APOLICLA-NUM-ITEM    PIC S9(9) USAGE COMP.*/
        public IntBasis APOLICLA_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLICLA-COD-CLAUSULA  PIC X(3).*/
        public StringBasis APOLICLA_COD_CLAUSULA { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 APOLICLA-TIPO-CLAUSULA  PIC X(1).*/
        public StringBasis APOLICLA_TIPO_CLAUSULA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLICLA-LIMITE-INDENIZA-IX  PIC S9(10)V9(5) USAGE COMP-3*/
        public DoubleBasis APOLICLA_LIMITE_INDENIZA_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 APOLICLA-TIMESTAMP   PIC X(26).*/
        public StringBasis APOLICLA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}