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
    public class LBWPF400_REG_CABEC_3 : VarBasis
    {
        /*"     10  RC3-TITULO-DATA             PIC X(005)*/
        public StringBasis RC3_TITULO_DATA { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
        /*"     10  RC3-DATA-PROCES             PIC X(010)*/
        public StringBasis RC3_DATA_PROCES { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"     10  RC3-SINAL-01                PIC X(001)*/
        public StringBasis RC3_SINAL_01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01      REG-CABEC-4*/
    }
}