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
    public class LBWPF400 : VarBasis
    {
        /*"01      REG-CABEC-1*/
        public LBWPF400_REG_CABEC_1 REG_CABEC_1 { get; set; } = new LBWPF400_REG_CABEC_1();

        public LBWPF400_REG_CABEC_2 REG_CABEC_2 { get; set; } = new LBWPF400_REG_CABEC_2();

        public LBWPF400_REG_CABEC_3 REG_CABEC_3 { get; set; } = new LBWPF400_REG_CABEC_3();

        public LBWPF400_REG_CABEC_4 REG_CABEC_4 { get; set; } = new LBWPF400_REG_CABEC_4();

        public LBWPF400_REG_CABEC_5 REG_CABEC_5 { get; set; } = new LBWPF400_REG_CABEC_5();

        public LBWPF400_REG_CABEC_6 REG_CABEC_6 { get; set; } = new LBWPF400_REG_CABEC_6();

    }
}