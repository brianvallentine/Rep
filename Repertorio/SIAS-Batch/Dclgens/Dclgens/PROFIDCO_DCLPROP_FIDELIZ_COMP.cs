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
    public class PROFIDCO_DCLPROP_FIDELIZ_COMP : VarBasis
    {
        /*"    10 PROFIDCO-NUM-IDENTIFICACAO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PROFIDCO_NUM_IDENTIFICACAO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PROFIDCO-INFORMACAO-COMPL  PIC X(255).*/
        public StringBasis PROFIDCO_INFORMACAO_COMPL { get; set; } = new StringBasis(new PIC("X", "255", "X(255)."), @"");
        /*"    10 PROFIDCO-COD-USUARIO  PIC X(8).*/
        public StringBasis PROFIDCO_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PROFIDCO-TIMESTAMP   PIC X(26).*/
        public StringBasis PROFIDCO_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 PROFIDCO-IND-TP-INFORMACAO  PIC X(1).*/
        public StringBasis PROFIDCO_IND_TP_INFORMACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}