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
    public class FIPADOIM_DCLFI_PAGA_DOCF_IMP : VarBasis
    {
        /*"    10 FIPADOIM-NUM-DOCF-INTERNO       PIC S9(9) USAGE COMP.*/
        public IntBasis FIPADOIM_NUM_DOCF_INTERNO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FIPADOIM-COD-TP-LANCDOCF       PIC S9(4) USAGE COMP.*/
        public IntBasis FIPADOIM_COD_TP_LANCDOCF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FIPADOIM-DT-INIVIG-LANCDOCF       PIC X(10).*/
        public StringBasis FIPADOIM_DT_INIVIG_LANCDOCF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FIPADOIM-COD-IMP-INTERNO       PIC S9(4) USAGE COMP.*/
        public IntBasis FIPADOIM_COD_IMP_INTERNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FIPADOIM-DATA-INIVIG-IMP       PIC X(10).*/
        public StringBasis FIPADOIM_DATA_INIVIG_IMP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FIPADOIM-DATA-INIVIG-IMPLAN       PIC X(10).*/
        public StringBasis FIPADOIM_DATA_INIVIG_IMPLAN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FIPADOIM-COD-FONTE-RECOLHE       PIC S9(4) USAGE COMP.*/
        public IntBasis FIPADOIM_COD_FONTE_RECOLHE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FIPADOIM-DATA-MOVIMENTO       PIC X(10).*/
        public StringBasis FIPADOIM_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FIPADOIM-HORA-MOVIMENTO       PIC X(8).*/
        public StringBasis FIPADOIM_HORA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 FIPADOIM-VALOR-IMPOSTO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis FIPADOIM_VALOR_IMPOSTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 FIPADOIM-ALIQ-TRIBUTACAO       PIC S9(3)V9(5) USAGE COMP-3.*/
        public DoubleBasis FIPADOIM_ALIQ_TRIBUTACAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(5)"), 5);
        /*"    10 FIPADOIM-COD-IMPOSTO-SAP       PIC X(2).*/
        public StringBasis FIPADOIM_COD_IMPOSTO_SAP { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"*/
    }
}