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
    public class LBFCT018_REG_PARAMETROS : VarBasis
    {
        /*"     10  R1-TIPO-REG                 PIC  9(002)*/
        public IntBasis R1_TIPO_REG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"     10  R1-AGENCIA                  PIC  9(004)*/
        public IntBasis R1_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"     10  FILLER                      PIC  X(194)*/
        public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "194", "X(194)"), @"");
        /*"01      REG-TRAILLER-PARAM*/
    }
}