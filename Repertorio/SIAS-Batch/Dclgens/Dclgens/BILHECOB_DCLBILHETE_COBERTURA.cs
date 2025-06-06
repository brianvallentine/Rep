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
    public class BILHECOB_DCLBILHETE_COBERTURA : VarBasis
    {
        /*"    10 BILHECOB-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis BILHECOB_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 BILHECOB-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis BILHECOB_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILHECOB-RAMO-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis BILHECOB_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILHECOB-MODALI-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis BILHECOB_MODALI_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILHECOB-COD-OPCAO-PLANO  PIC S9(4) USAGE COMP.*/
        public IntBasis BILHECOB_COD_OPCAO_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILHECOB-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis BILHECOB_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILHECOB-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis BILHECOB_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 BILHECOB-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis BILHECOB_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 BILHECOB-IDE-COBERTURA  PIC X(1).*/
        public StringBasis BILHECOB_IDE_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 BILHECOB-IMP-SEGURADA-IX  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILHECOB_IMP_SEGURADA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 BILHECOB-PRM-TARIFARIO-IX  PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis BILHECOB_PRM_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"    10 BILHECOB-COD-MOEDA   PIC S9(4) USAGE COMP.*/
        public IntBasis BILHECOB_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILHECOB-PCT-COM-CORRETOR  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILHECOB_PCT_COM_CORRETOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 BILHECOB-COD-COBERTURA-BAS  PIC S9(4) USAGE COMP.*/
        public IntBasis BILHECOB_COD_COBERTURA_BAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILHECOB-PCT-MAX-COBER-BAS  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILHECOB_PCT_MAX_COBER_BAS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 BILHECOB-VAL-MAX-COBER-BAS  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILHECOB_VAL_MAX_COBER_BAS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 BILHECOB-TIMESTAMP   PIC X(26).*/
        public StringBasis BILHECOB_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 BILHECOB-VAL-COBERTURA-IX  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILHECOB_VAL_COBERTURA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 BILHECOB-PCT-PARTIC  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILHECOB_PCT_PARTIC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 BILHECOB-PRM-TOTAL   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILHECOB_PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 BILHECOB-PCT-IOCC    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILHECOB_PCT_IOCC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 BILHECOB-VLR-PREM-LIQ-TOT  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILHECOB_VLR_PREM_LIQ_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 BILHECOB-NUM-SEQ-EXIBE-COB  PIC X(1).*/
        public StringBasis BILHECOB_NUM_SEQ_EXIBE_COB { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 BILHECOB-PCT-IOF     PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILHECOB_PCT_IOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 BILHECOB-VLR-ADIC-FRACIONA  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILHECOB_VLR_ADIC_FRACIONA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 BILHECOB-DTH-CADASTRAMENTO  PIC X(26).*/
        public StringBasis BILHECOB_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 BILHECOB-COD-USUARIO  PIC X(8).*/
        public StringBasis BILHECOB_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"*/
    }
}