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
    public class AVISOSAL_DCLAVISOS_SALDOS : VarBasis
    {
        /*"    10 AVISOSAL-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis AVISOSAL_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AVISOSAL-BCO-AVISO   PIC S9(4) USAGE COMP.*/
        public IntBasis AVISOSAL_BCO_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AVISOSAL-AGE-AVISO   PIC S9(4) USAGE COMP.*/
        public IntBasis AVISOSAL_AGE_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AVISOSAL-TIPO-SEGURO  PIC X(1).*/
        public StringBasis AVISOSAL_TIPO_SEGURO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AVISOSAL-NUM-AVISO-CREDITO  PIC S9(9) USAGE COMP.*/
        public IntBasis AVISOSAL_NUM_AVISO_CREDITO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AVISOSAL-DATA-AVISO  PIC X(10).*/
        public StringBasis AVISOSAL_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 AVISOSAL-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis AVISOSAL_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 AVISOSAL-SALDO-ATUAL  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis AVISOSAL_SALDO_ATUAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 AVISOSAL-SIT-REGISTRO  PIC X(1).*/
        public StringBasis AVISOSAL_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AVISOSAL-TIMESTAMP   PIC X(26).*/
        public StringBasis AVISOSAL_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 AVISOSAL-COD-CONVENIO  PIC S9(9) USAGE COMP.*/
        public IntBasis AVISOSAL_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}