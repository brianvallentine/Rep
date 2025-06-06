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
    public class SINIMPSE_DCLSINISTRO_IMP_SEG : VarBasis
    {
        /*"    10 SINIMPSE-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINIMPSE_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINIMPSE-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis SINIMPSE_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINIMPSE-SIT-REGISTRO  PIC X(1).*/
        public StringBasis SINIMPSE_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINIMPSE-COD-CAUSA   PIC S9(4) USAGE COMP.*/
        public IntBasis SINIMPSE_COD_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINIMPSE-VAL-IS-DATA-OCORR  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINIMPSE_VAL_IS_DATA_OCORR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SINIMPSE-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis SINIMPSE_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINIMPSE-DATA-OCORRENCIA  PIC X(10).*/
        public StringBasis SINIMPSE_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINIMPSE-TIMESTAMP   PIC X(26).*/
        public StringBasis SINIMPSE_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}