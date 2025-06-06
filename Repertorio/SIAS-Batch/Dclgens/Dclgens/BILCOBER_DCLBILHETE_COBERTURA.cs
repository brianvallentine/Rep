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
    public class BILCOBER_DCLBILHETE_COBERTURA : VarBasis
    {
        /*"    10 BILCOBER-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis BILCOBER_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 BILCOBER-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis BILCOBER_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILCOBER-RAMO-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis BILCOBER_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILCOBER-MODALI-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis BILCOBER_MODALI_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILCOBER-COD-OPCAO-PLANO  PIC S9(4) USAGE COMP.*/
        public IntBasis BILCOBER_COD_OPCAO_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILCOBER-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis BILCOBER_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILCOBER-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis BILCOBER_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 BILCOBER-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis BILCOBER_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 BILCOBER-IDE-COBERTURA  PIC X(1).*/
        public StringBasis BILCOBER_IDE_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 BILCOBER-IMP-SEGURADA-IX  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILCOBER_IMP_SEGURADA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 BILCOBER-PRM-TARIFARIO-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis BILCOBER_PRM_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 BILCOBER-COD-MOEDA   PIC S9(4) USAGE COMP.*/
        public IntBasis BILCOBER_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILCOBER-PCT-COM-CORRETOR  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILCOBER_PCT_COM_CORRETOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 BILCOBER-COD-COBERTURA-BAS  PIC S9(4) USAGE COMP.*/
        public IntBasis BILCOBER_COD_COBERTURA_BAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILCOBER-PCT-MAX-COBER-BAS  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILCOBER_PCT_MAX_COBER_BAS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 BILCOBER-VAL-MAX-COBER-BAS  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILCOBER_VAL_MAX_COBER_BAS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 BILCOBER-TIMESTAMP   PIC X(26).*/
        public StringBasis BILCOBER_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 BILCOBER-VAL-COBERTURA-IX  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILCOBER_VAL_COBERTURA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 BILCOBER-PCT-PARTIC  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILCOBER_PCT_PARTIC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 BILCOBER-PRM-TOTAL   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILCOBER_PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 BILCOBER-PCT-IOCC    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILCOBER_PCT_IOCC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"*/
    }
}