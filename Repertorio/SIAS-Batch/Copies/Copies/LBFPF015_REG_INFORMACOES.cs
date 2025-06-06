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
    public class LBFPF015_REG_INFORMACOES : VarBasis
    {
        /*"     10  R5-TIPO-REG                 PIC  X(001)*/
        public StringBasis R5_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  R5-NUM-PROPOSTA             PIC  9(014)*/
        public IntBasis R5_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"     10  R5-INFO-COMPLEMEN           PIC  X(255)*/
        public StringBasis R5_INFO_COMPLEMEN { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
        /*"     10  FILLER                      PIC  X(030)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"*/
    }
}