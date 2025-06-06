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
    public class PRAZOSEG_DCLPRAZO_SEGURO : VarBasis
    {
        /*"    10 PRAZOSEG-COD-TABELA  PIC S9(4) USAGE COMP.*/
        public IntBasis PRAZOSEG_COD_TABELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRAZOSEG-INICIO-PRAZO  PIC S9(4) USAGE COMP.*/
        public IntBasis PRAZOSEG_INICIO_PRAZO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRAZOSEG-FIM-PRAZO   PIC S9(4) USAGE COMP.*/
        public IntBasis PRAZOSEG_FIM_PRAZO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRAZOSEG-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis PRAZOSEG_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PRAZOSEG-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis PRAZOSEG_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PRAZOSEG-PCT-PRM-ANUAL  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis PRAZOSEG_PCT_PRM_ANUAL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 PRAZOSEG-DATA-ULT-MANUTEN  PIC X(10).*/
        public StringBasis PRAZOSEG_DATA_ULT_MANUTEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PRAZOSEG-HORA-ULT-MANUTEN  PIC X(8).*/
        public StringBasis PRAZOSEG_HORA_ULT_MANUTEN { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PRAZOSEG-TIPO-ULT-MANUTEN  PIC X(1).*/
        public StringBasis PRAZOSEG_TIPO_ULT_MANUTEN { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRAZOSEG-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis PRAZOSEG_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PRAZOSEG-TIMESTAMP   PIC X(26).*/
        public StringBasis PRAZOSEG_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}