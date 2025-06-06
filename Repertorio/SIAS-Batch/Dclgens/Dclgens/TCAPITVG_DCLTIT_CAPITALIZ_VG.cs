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
    public class TCAPITVG_DCLTIT_CAPITALIZ_VG : VarBasis
    {
        /*"    10 TCAPITVG-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis TCAPITVG_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 TCAPITVG-NUM-TIT-CAPITALIZ  PIC S9(4) USAGE COMP.*/
        public IntBasis TCAPITVG_NUM_TIT_CAPITALIZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TCAPITVG-NUM-SERIE-TITULO  PIC S9(4) USAGE COMP.*/
        public IntBasis TCAPITVG_NUM_SERIE_TITULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TCAPITVG-NUM-SORTEIO  PIC S9(9) USAGE COMP.*/
        public IntBasis TCAPITVG_NUM_SORTEIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 TCAPITVG-VAL-TIT-CAPITALIZ  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis TCAPITVG_VAL_TIT_CAPITALIZ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 TCAPITVG-VAL-CUS-CAPITALIZ  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis TCAPITVG_VAL_CUS_CAPITALIZ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 TCAPITVG-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis TCAPITVG_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 TCAPITVG-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis TCAPITVG_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 TCAPITVG-SIT-REGISTRO  PIC X(1).*/
        public StringBasis TCAPITVG_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 TCAPITVG-SIT-SORTEIO  PIC X(1).*/
        public StringBasis TCAPITVG_SIT_SORTEIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 TCAPITVG-SIT-RESGATE  PIC X(1).*/
        public StringBasis TCAPITVG_SIT_RESGATE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 TCAPITVG-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis TCAPITVG_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TCAPITVG-TIMESTAMP   PIC X(26).*/
        public StringBasis TCAPITVG_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}