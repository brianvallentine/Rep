using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBWPF400_REG_CABEC_5 : VarBasis
    {
        /*"     10  RC5-DESCRICAO-PROGRAMA      PIC X(072)*/
        public StringBasis RC5_DESCRICAO_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"");
        /*"     10  RC5-SINAL-01                PIC X(001)*/
        public StringBasis RC5_SINAL_01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01      REG-CABEC-6*/
    }
}