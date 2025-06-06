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
    public class LBFCT011_REG_STA_QUOTA : VarBasis
    {
        /*"     10  R0-TIPO-REG                 PIC  X(001)*/
        public StringBasis R0_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  R0-VAL-QUOTA                PIC  9(007)V9(08)*/
        public DoubleBasis R0_VAL_QUOTA { get; set; } = new DoubleBasis(new PIC("9", "7", "9(007)V9(08)"), 8);
        /*"     10  FILLER                      PIC  X(084)*/
        public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "84", "X(084)"), @"");
        /*"01      REG-STA-PROPOSTA*/
    }
}