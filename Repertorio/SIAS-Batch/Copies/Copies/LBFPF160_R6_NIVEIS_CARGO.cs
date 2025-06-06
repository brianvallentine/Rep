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
    public class LBFPF160_R6_NIVEIS_CARGO : VarBasis
    {
        /*"       20 R6-NIVEL-CARGO               PIC  9(002)*/
        public IntBasis R6_NIVEL_CARGO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"       20 R6-IS-CARGO                  PIC  9(013)V99*/
        public DoubleBasis R6_IS_CARGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"       20 R6-VIDAS-CARGO               PIC  9(003)*/
        public IntBasis R6_VIDAS_CARGO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"    15 R6-FATURAMENTO-ANUAL            PIC  9(013)V99*/

        public LBFPF160_R6_NIVEIS_CARGO()
        {
            R6_NIVEL_CARGO.ValueChanged += OnValueChanged;
            R6_IS_CARGO.ValueChanged += OnValueChanged;
            R6_VIDAS_CARGO.ValueChanged += OnValueChanged;
        }

    }
}