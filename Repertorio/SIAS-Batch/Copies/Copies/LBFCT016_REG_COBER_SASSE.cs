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
    public class LBFCT016_REG_COBER_SASSE : VarBasis
    {
        /*"     10 R3-TIPO-REG                 PIC  X(001)*/
        public StringBasis R3_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10 R3-NUM-PROPOSTA             PIC  9(014)*/
        public IntBasis R3_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"     10 R3-COD-COBERTURA            PIC  9(004)*/
        public IntBasis R3_COD_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"     10 R3-VAL-COBERTURA            PIC  9(013)V99*/
        public DoubleBasis R3_VAL_COBERTURA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"     10 FILLER                      PIC  X(066)*/
        public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "66", "X(066)"), @"");
        /*"01      REG-PGTO-SASSE*/
    }
}