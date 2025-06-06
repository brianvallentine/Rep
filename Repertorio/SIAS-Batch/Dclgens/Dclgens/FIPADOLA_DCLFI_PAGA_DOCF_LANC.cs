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
    public class FIPADOLA_DCLFI_PAGA_DOCF_LANC : VarBasis
    {
        /*"    10 FIPADOLA-NUM-DOCF-INTERNO  PIC S9(9) USAGE COMP.*/
        public IntBasis FIPADOLA_NUM_DOCF_INTERNO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FIPADOLA-COD-TP-LANCDOCF  PIC S9(4) USAGE COMP.*/
        public IntBasis FIPADOLA_COD_TP_LANCDOCF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FIPADOLA-DT-INIVIG-LANCDOCF  PIC X(10).*/
        public StringBasis FIPADOLA_DT_INIVIG_LANCDOCF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FIPADOLA-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis FIPADOLA_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FIPADOLA-HORA-MOVIMENTO  PIC X(8).*/
        public StringBasis FIPADOLA_HORA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 FIPADOLA-VALOR-LANCAMENTO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis FIPADOLA_VALOR_LANCAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"*/
    }
}