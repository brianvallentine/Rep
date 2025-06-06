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
    public class HISTOCHE_DCLHISTORICO_CHEQUES : VarBasis
    {
        /*"    10 HISTOCHE-NUM-CHEQUE-INTERNO  PIC S9(9) USAGE COMP.*/
        public IntBasis HISTOCHE_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 HISTOCHE-DIG-CHEQUE-INTERNO  PIC S9(4) USAGE COMP.*/
        public IntBasis HISTOCHE_DIG_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISTOCHE-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis HISTOCHE_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 HISTOCHE-HORA-OPERACAO  PIC X(8).*/
        public StringBasis HISTOCHE_HORA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 HISTOCHE-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis HISTOCHE_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISTOCHE-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis HISTOCHE_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 HISTOCHE-TIMESTAMP   PIC X(26).*/
        public StringBasis HISTOCHE_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 HISTOCHE-DATA-COMPENSACAO  PIC X(10).*/
        public StringBasis HISTOCHE_DATA_COMPENSACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}