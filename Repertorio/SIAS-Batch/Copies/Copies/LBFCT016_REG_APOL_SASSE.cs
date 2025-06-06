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
    public class LBFCT016_REG_APOL_SASSE : VarBasis
    {
        /*"     10 R2-TIPO-REG                 PIC  X(001)*/
        public StringBasis R2_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10 R2-NUM-PROPOSTA             PIC  9(014)*/
        public IntBasis R2_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"     10 R2-NRCERTIF                 PIC  9(015)*/
        public IntBasis R2_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
        /*"     10 R2-DTINIVIG                 PIC  9(008)*/
        public IntBasis R2_DTINIVIG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10 R2-DTTERVIG                 PIC  9(008)*/
        public IntBasis R2_DTTERVIG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10 R2-VAL-PREMIO               PIC  9(013)V99*/
        public DoubleBasis R2_VAL_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"     10 R2-VAL-IOF                  PIC  9(013)V99*/
        public DoubleBasis R2_VAL_IOF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"     10 FILLER                      PIC  X(024)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
        /*"01      REG-COBER-SASSE*/
    }
}