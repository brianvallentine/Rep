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
    public class LBWPF400_REG_CABEC_1 : VarBasis
    {
        /*"     10  RC1-TITULO-EMPRESA          PIC X(030)*/
        public StringBasis RC1_TITULO_EMPRESA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"     10  RC1-SINAL-01                PIC X(001)*/
        public StringBasis RC1_SINAL_01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01      REG-CABEC-2*/
    }
}