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
    public class LBWPF400_REG_CABEC_6 : VarBasis
    {
        /*"     10  RC6-TITULO-PERIODO          PIC X(011)*/
        public StringBasis RC6_TITULO_PERIODO { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
        /*"     10  RC6-DATA-INICIO             PIC X(010)*/
        public StringBasis RC6_DATA_INICIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"     10  RC6-TITULO-CONECT           PIC X(003)*/
        public StringBasis RC6_TITULO_CONECT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"     10  RC6-DATA-TERMINO            PIC X(010)*/
        public StringBasis RC6_DATA_TERMINO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"     10  RC6-SINAL-01                PIC X(001)*/
        public StringBasis RC6_SINAL_01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
    }
}