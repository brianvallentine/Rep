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
    public class LBWPF400_REG_CABEC_2 : VarBasis
    {
        /*"     10  RC2-TITULO-ORGAO            PIC X(030)*/
        public StringBasis RC2_TITULO_ORGAO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"     10  RC2-SINAL-01                PIC X(001)*/
        public StringBasis RC2_SINAL_01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01      REG-CABEC-3*/
    }
}