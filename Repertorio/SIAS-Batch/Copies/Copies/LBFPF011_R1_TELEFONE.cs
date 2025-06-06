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
    public class LBFPF011_R1_TELEFONE : VarBasis
    {
        /*"      15 R1-DDD                      PIC  9(003)*/
        public IntBasis R1_DDD { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"      15 R1-NUM-FONE                 PIC  9(009)*/
        public IntBasis R1_NUM_FONE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"     10  R1-DATA-EXPEDICAO-RG        PIC  9(008)*/
    }
}