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
    public class LOTECHEQ_DCLLOTE_CHEQUES : VarBasis
    {
        /*"    10 LOTECHEQ-COD-BANCO   PIC S9(4) USAGE COMP.*/
        public IntBasis LOTECHEQ_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTECHEQ-COD-AGENCIA  PIC S9(4) USAGE COMP.*/
        public IntBasis LOTECHEQ_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTECHEQ-NUM-CHEQUE  PIC S9(9) USAGE COMP.*/
        public IntBasis LOTECHEQ_NUM_CHEQUE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTECHEQ-DIG-CHEQUE  PIC S9(4) USAGE COMP.*/
        public IntBasis LOTECHEQ_DIG_CHEQUE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTECHEQ-DATA-CADASTRAMENTO  PIC X(10).*/
        public StringBasis LOTECHEQ_DATA_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LOTECHEQ-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis LOTECHEQ_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 LOTECHEQ-NUM-CHEQUE-INTERNO  PIC S9(9) USAGE COMP.*/
        public IntBasis LOTECHEQ_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTECHEQ-DIG-CHEQUE-INTERNO  PIC S9(4) USAGE COMP.*/
        public IntBasis LOTECHEQ_DIG_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 LOTECHEQ-SIT-REGISTRO  PIC X(1).*/
        public StringBasis LOTECHEQ_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 LOTECHEQ-SIT-CHEQUE  PIC X(1).*/
        public StringBasis LOTECHEQ_SIT_CHEQUE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 LOTECHEQ-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis LOTECHEQ_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 LOTECHEQ-TIMESTAMP   PIC X(26).*/
        public StringBasis LOTECHEQ_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 LOTECHEQ-SERIE-CHEQUE  PIC X(3).*/
        public StringBasis LOTECHEQ_SERIE_CHEQUE { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
    }
}