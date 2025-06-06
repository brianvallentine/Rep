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
    public class AVISOCRE_DCLAVISO_CREDITO : VarBasis
    {
        /*"    10 AVISOCRE-BCO-AVISO   PIC S9(4) USAGE COMP.*/
        public IntBasis AVISOCRE_BCO_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AVISOCRE-AGE-AVISO   PIC S9(4) USAGE COMP.*/
        public IntBasis AVISOCRE_AGE_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AVISOCRE-NUM-AVISO-CREDITO  PIC S9(9) USAGE COMP.*/
        public IntBasis AVISOCRE_NUM_AVISO_CREDITO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AVISOCRE-NUM-SEQUENCIA  PIC S9(9) USAGE COMP.*/
        public IntBasis AVISOCRE_NUM_SEQUENCIA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AVISOCRE-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis AVISOCRE_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 AVISOCRE-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis AVISOCRE_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AVISOCRE-TIPO-AVISO  PIC X(1).*/
        public StringBasis AVISOCRE_TIPO_AVISO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AVISOCRE-DATA-AVISO  PIC X(10).*/
        public StringBasis AVISOCRE_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 AVISOCRE-VAL-IOCC    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AVISOCRE_VAL_IOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AVISOCRE-VAL-DESPESA  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AVISOCRE_VAL_DESPESA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AVISOCRE-PRM-COSSEGURO-CED  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AVISOCRE_PRM_COSSEGURO_CED { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AVISOCRE-PRM-LIQUIDO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AVISOCRE_PRM_LIQUIDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AVISOCRE-PRM-TOTAL   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AVISOCRE_PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AVISOCRE-SIT-CONTABIL  PIC X(1).*/
        public StringBasis AVISOCRE_SIT_CONTABIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AVISOCRE-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis AVISOCRE_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AVISOCRE-TIMESTAMP   PIC X(26).*/
        public StringBasis AVISOCRE_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 AVISOCRE-ORIGEM-AVISO  PIC S9(4) USAGE COMP.*/
        public IntBasis AVISOCRE_ORIGEM_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AVISOCRE-VAL-ADIANTAMENTO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AVISOCRE_VAL_ADIANTAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AVISOCRE-STA-DEPOSITO-TER  PIC X(1).*/
        public StringBasis AVISOCRE_STA_DEPOSITO_TER { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
    }
}