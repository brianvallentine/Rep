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
    public class NUMEROUT_DCLNUMERO_OUTROS : VarBasis
    {
        /*"    10 NUMEROUT-COD-CORRETOR  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMEROUT_COD_CORRETOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMEROUT-COD-ANGARIADOR  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMEROUT_COD_ANGARIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMEROUT-COD-PREPOSTO  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMEROUT_COD_PREPOSTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMEROUT-COD-ESTIPULANTE  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMEROUT_COD_ESTIPULANTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMEROUT-COD-INSPETOR  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMEROUT_COD_INSPETOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMEROUT-NUM-DPVAT   PIC S9(9) USAGE COMP.*/
        public IntBasis NUMEROUT_NUM_DPVAT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMEROUT-NUM-RCAP    PIC S9(9) USAGE COMP.*/
        public IntBasis NUMEROUT_NUM_RCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMEROUT-ORDEM-PAGAMENTO  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMEROUT_ORDEM_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMEROUT-COD-PREST-SERVICO  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMEROUT_COD_PREST_SERVICO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMEROUT-NUM-RECIBO  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMEROUT_NUM_RECIBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMEROUT-NUM-RECIBO-CTPAG  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMEROUT_NUM_RECIBO_CTPAG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMEROUT-NUM-MOV-SINISTRO  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMEROUT_NUM_MOV_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMEROUT-NUM-CERT-VGAP  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NUMEROUT_NUM_CERT_VGAP { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 NUMEROUT-NUM-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMEROUT_NUM_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMEROUT-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMEROUT_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMEROUT-TIMESTAMP   PIC X(26).*/
        public StringBasis NUMEROUT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 NUMEROUT-COD-SUPERINTEND  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMEROUT_COD_SUPERINTEND { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMEROUT-NUM-REQUISI  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMEROUT_NUM_REQUISI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMEROUT-NUM-CANC-SEGU-SINI  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMEROUT_NUM_CANC_SEGU_SINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMEROUT-NUM-LOTE-PAR  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMEROUT_NUM_LOTE_PAR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMEROUT-NUM-SIVAT   PIC S9(9) USAGE COMP.*/
        public IntBasis NUMEROUT_NUM_SIVAT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMEROUT-CLIFOR      PIC S9(9) USAGE COMP.*/
        public IntBasis NUMEROUT_CLIFOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMEROUT-NUM-SIVAT-CAP  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMEROUT_NUM_SIVAT_CAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMEROUT-NUM-CERT-SAUDE  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NUMEROUT_NUM_CERT_SAUDE { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"*/
    }
}