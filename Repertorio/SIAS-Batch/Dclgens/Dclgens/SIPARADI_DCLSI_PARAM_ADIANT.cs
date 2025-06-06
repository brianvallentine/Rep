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
    public class SIPARADI_DCLSI_PARAM_ADIANT : VarBasis
    {
        /*"    10 SIPARADI-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIPARADI_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIPARADI-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis SIPARADI_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIPARADI-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis SIPARADI_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIPARADI-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis SIPARADI_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIPARADI-PERC-ADIANTAMENTO  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIPARADI_PERC_ADIANTAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 SIPARADI-IND-SINISTROS  PIC X(1).*/
        public StringBasis SIPARADI_IND_SINISTROS { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIPARADI-TIMESTAMP   PIC X(26).*/
        public StringBasis SIPARADI_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}