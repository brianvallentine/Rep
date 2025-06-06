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
    public class LBWPF400_REG_CABEC_4 : VarBasis
    {
        /*"     10  RC4-TITULO-PROGRAMA         PIC X(010)*/
        public StringBasis RC4_TITULO_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"     10  RC4-COD-PROGRAMA            PIC X(010)*/
        public StringBasis RC4_COD_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"     10  RC4-PERIODICIDADE           PIC X(015)*/
        public StringBasis RC4_PERIODICIDADE { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
        /*"     10  RC4-SINAL-01                PIC X(001)*/
        public StringBasis RC4_SINAL_01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01      REG-CABEC-5*/
    }
}