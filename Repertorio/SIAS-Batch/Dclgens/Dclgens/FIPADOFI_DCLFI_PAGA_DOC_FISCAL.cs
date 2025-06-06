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
    public class FIPADOFI_DCLFI_PAGA_DOC_FISCAL : VarBasis
    {
        /*"    10 FIPADOFI-NUM-DOCF-INTERNO  PIC S9(9) USAGE COMP.*/
        public IntBasis FIPADOFI_NUM_DOCF_INTERNO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FIPADOFI-IDTAB-FORNECEDOR  PIC S9(4) USAGE COMP.*/
        public IntBasis FIPADOFI_IDTAB_FORNECEDOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FIPADOFI-COD-CH1-FORNECEDOR  PIC X(1).*/
        public StringBasis FIPADOFI_COD_CH1_FORNECEDOR { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FIPADOFI-COD-FORNECEDOR  PIC S9(9) USAGE COMP.*/
        public IntBasis FIPADOFI_COD_FORNECEDOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FIPADOFI-IDTAB-DOC-FISCAL  PIC S9(4) USAGE COMP.*/
        public IntBasis FIPADOFI_IDTAB_DOC_FISCAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FIPADOFI-COD-CH1-DOC-FISCAL  PIC X(1).*/
        public StringBasis FIPADOFI_COD_CH1_DOC_FISCAL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FIPADOFI-COD-FONTE-LANC  PIC S9(4) USAGE COMP.*/
        public IntBasis FIPADOFI_COD_FONTE_LANC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FIPADOFI-TIPO-MOVIMENTO  PIC X(1).*/
        public StringBasis FIPADOFI_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FIPADOFI-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis FIPADOFI_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FIPADOFI-NUM-CHEQUE-INTERNO  PIC S9(9) USAGE COMP.*/
        public IntBasis FIPADOFI_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FIPADOFI-NUM-DOC-FISCAL  PIC S9(9) USAGE COMP.*/
        public IntBasis FIPADOFI_NUM_DOC_FISCAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FIPADOFI-SERIE-DOC-FISCAL  PIC X(10).*/
        public StringBasis FIPADOFI_SERIE_DOC_FISCAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FIPADOFI-DATA-EMISSAO-DOC  PIC X(10).*/
        public StringBasis FIPADOFI_DATA_EMISSAO_DOC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FIPADOFI-CGCCPF      PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis FIPADOFI_CGCCPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 FIPADOFI-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis FIPADOFI_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FIPADOFI-TIMESTAMP   PIC X(26).*/
        public StringBasis FIPADOFI_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}