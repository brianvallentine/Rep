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
    public class NUMOUTRO_DCLNUMERO_OUTROS : VarBasis
    {
        /*"    10 COD-CORRETOR         PIC S9(9) USAGE COMP.*/
        public IntBasis COD_CORRETOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COD-ANGARIADOR       PIC S9(9) USAGE COMP.*/
        public IntBasis COD_ANGARIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COD-PREPOSTO         PIC S9(9) USAGE COMP.*/
        public IntBasis COD_PREPOSTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COD-ESTIPULANTE      PIC S9(9) USAGE COMP.*/
        public IntBasis COD_ESTIPULANTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COD-INSPETOR         PIC S9(9) USAGE COMP.*/
        public IntBasis COD_INSPETOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUM-DPVAT            PIC S9(9) USAGE COMP.*/
        public IntBasis NUM_DPVAT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUM-RCAP             PIC S9(9) USAGE COMP.*/
        public IntBasis NUM_RCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ORDEM-PAGAMENTO      PIC S9(9) USAGE COMP.*/
        public IntBasis ORDEM_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COD-PREST-SERVICO    PIC S9(9) USAGE COMP.*/
        public IntBasis COD_PREST_SERVICO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUM-RECIBO           PIC S9(9) USAGE COMP.*/
        public IntBasis NUM_RECIBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUM-RECIBO-CTPAG     PIC S9(9) USAGE COMP.*/
        public IntBasis NUM_RECIBO_CTPAG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUM-MOV-SINISTRO     PIC S9(9) USAGE COMP.*/
        public IntBasis NUM_MOV_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUM-CERT-VGAP        PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NUM_CERT_VGAP { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 NUM-CLIENTE          PIC S9(9) USAGE COMP.*/
        public IntBasis NUM_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COD-EMPRESA          PIC S9(9) USAGE COMP.*/
        public IntBasis COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 TIMESTAMP            PIC X(26).*/
        public StringBasis TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 COD-SUPERINTEND      PIC S9(9) USAGE COMP.*/
        public IntBasis COD_SUPERINTEND { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUM-REQUISI          PIC S9(9) USAGE COMP.*/
        public IntBasis NUM_REQUISI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUM-CANC-SEGU-SINI   PIC S9(9) USAGE COMP.*/
        public IntBasis NUM_CANC_SEGU_SINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUM-SIVAT            PIC S9(9) USAGE COMP.*/
        public IntBasis NUM_SIVAT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}