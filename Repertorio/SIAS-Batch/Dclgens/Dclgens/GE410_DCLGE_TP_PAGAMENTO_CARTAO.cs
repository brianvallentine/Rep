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
    public class GE410_DCLGE_TP_PAGAMENTO_CARTAO : VarBasis
    {
        /*"    10 GE410-COD-TP-PAGAMENTO       PIC X(2).*/
        public StringBasis GE410_COD_TP_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE410-DES-TP-PAGAMENTO       PIC X(40).*/
        public StringBasis GE410_DES_TP_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"*/
    }
}