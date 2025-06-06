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
    public class TITFEDCA_DCLTITULOS_FED_CAP_VA : VarBasis
    {
        /*"    10 TITFEDCA-NRTITFDCAP  PIC S9(12)V USAGE COMP-3.*/
        public DoubleBasis TITFEDCA_NRTITFDCAP { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(12)V"), 0);
        /*"    10 TITFEDCA-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis TITFEDCA_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 TITFEDCA-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis TITFEDCA_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 TITFEDCA-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis TITFEDCA_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 TITFEDCA-NRSORTEIO   PIC S9(9) USAGE COMP.*/
        public IntBasis TITFEDCA_NRSORTEIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 TITFEDCA-VAL-CUSTO-TITULO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis TITFEDCA_VAL_CUSTO_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 TITFEDCA-NRPARCEL    PIC S9(4) USAGE COMP.*/
        public IntBasis TITFEDCA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TITFEDCA-NRMFDCAPF   PIC S9(4) USAGE COMP.*/
        public IntBasis TITFEDCA_NRMFDCAPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TITFEDCA-SITUACAO    PIC X(1).*/
        public StringBasis TITFEDCA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 TITFEDCA-SIT-RELAT   PIC X(1).*/
        public StringBasis TITFEDCA_SIT_RELAT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 TITFEDCA-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis TITFEDCA_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 TITFEDCA-TIMESTAMP   PIC X(26).*/
        public StringBasis TITFEDCA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 TITFEDCA-NRMFDCAPR   PIC S9(4) USAGE COMP.*/
        public IntBasis TITFEDCA_NRMFDCAPR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TITFEDCA-NRTITREN    PIC S9(12)V USAGE COMP-3.*/
        public DoubleBasis TITFEDCA_NRTITREN { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(12)V"), 0);
        /*"*/
    }
}