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
    public class PARFEDCA_DCLPARCEL_FED_CAP_VA : VarBasis
    {
        /*"    10 PARFEDCA-NRTITFDCAP  PIC S9(12)V USAGE COMP-3.*/
        public DoubleBasis PARFEDCA_NRTITFDCAP { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(12)V"), 0);
        /*"    10 PARFEDCA-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis PARFEDCA_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARFEDCA-VAL-CUSTO-TITULO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARFEDCA_VAL_CUSTO_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PARFEDCA-DTFATUR     PIC X(10).*/
        public StringBasis PARFEDCA_DTFATUR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PARFEDCA-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis PARFEDCA_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PARFEDCA-SITUACAO    PIC X(1).*/
        public StringBasis PARFEDCA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PARFEDCA-NRMFDCAP    PIC S9(4) USAGE COMP.*/
        public IntBasis PARFEDCA_NRMFDCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARFEDCA-TIMESTAMP   PIC X(26).*/
        public StringBasis PARFEDCA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}