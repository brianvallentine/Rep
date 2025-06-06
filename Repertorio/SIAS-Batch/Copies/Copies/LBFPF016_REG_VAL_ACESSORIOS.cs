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
    public class LBFPF016_REG_VAL_ACESSORIOS : VarBasis
    {
        /*"     10  R6-TIPO-REG                 PIC  X(001)*/
        public StringBasis R6_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  R6-NUM-PROPOSTA             PIC  9(014)*/
        public IntBasis R6_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"     10  R6-COD-ACESSORIO            PIC  9(003)*/
        public IntBasis R6_COD_ACESSORIO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"     10  R6-VAL-BENEFIC              PIC  9(013)V99*/
        public DoubleBasis R6_VAL_BENEFIC { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"     10  R6-VAL-CONTRIB              PIC  9(013)V99*/
        public DoubleBasis R6_VAL_CONTRIB { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"     10  FILLER                      PIC  X(001)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  R6-PRZ-PERCEPCAO            PIC  9(002)*/
        public IntBasis R6_PRZ_PERCEPCAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"     10  R6-IND-OPERACAO             PIC  X(001)*/
        public StringBasis R6_IND_OPERACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  FILLER                      PIC  X(248)*/
        public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "248", "X(248)"), @"");
        /*"*/
    }
}