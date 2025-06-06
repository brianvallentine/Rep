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
    public class SIPADOFI_DCLSI_PAGA_DOC_FISCAL : VarBasis
    {
        /*"    10 SIPADOFI-NUM-DOCF-INTERNO   PIC S9(9) USAGE COMP.*/
        public IntBasis SIPADOFI_NUM_DOCF_INTERNO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIPADOFI-NUM-PARCELA        PIC S9(4) USAGE COMP.*/
        public IntBasis SIPADOFI_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIPADOFI-NUM-MES-ANO-COMPET    PIC S9(9) USAGE COMP.*/
        public IntBasis SIPADOFI_NUM_MES_ANO_COMPET { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIPADOFI-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SIPADOFI_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SIPADOFI-COD-OPERACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis SIPADOFI_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIPADOFI-OCORR-HISTORICO    PIC S9(4) USAGE COMP.*/
        public IntBasis SIPADOFI_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIPADOFI-UNIVERSAL-ID       PIC X(32).*/
        public StringBasis SIPADOFI_UNIVERSAL_ID { get; set; } = new StringBasis(new PIC("X", "32", "X(32)."), @"");
        /*"    10 SIPADOFI-TIMESTAMP          PIC X(26).*/
        public StringBasis SIPADOFI_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}