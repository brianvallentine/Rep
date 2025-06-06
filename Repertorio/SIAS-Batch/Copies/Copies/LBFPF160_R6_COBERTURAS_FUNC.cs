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
    public class LBFPF160_R6_COBERTURAS_FUNC : VarBasis
    {
        /*"       20 R6-NUM-FUNC-COB              PIC  9(003)*/
        public IntBasis R6_NUM_FUNC_COB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"       20 R6-COD-COBERTURA             PIC  9(002)*/
        public IntBasis R6_COD_COBERTURA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"       20 R6-VALOR-IS                  PIC  9(013)V99*/
        public DoubleBasis R6_VALOR_IS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"       20 R6-VALOR-PREMIO              PIC  9(013)V99*/
        public DoubleBasis R6_VALOR_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"       20 R6-VALOR-TAXA                PIC  9(003)V9(07)*/
        public DoubleBasis R6_VALOR_TAXA { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V9(07)"), 7);
        /*"    15 FILLER                          PIC  X(011)*/

        public LBFPF160_R6_COBERTURAS_FUNC()
        {
            R6_NUM_FUNC_COB.ValueChanged += OnValueChanged;
            R6_COD_COBERTURA.ValueChanged += OnValueChanged;
            R6_VALOR_IS.ValueChanged += OnValueChanged;
            R6_VALOR_PREMIO.ValueChanged += OnValueChanged;
            R6_VALOR_TAXA.ValueChanged += OnValueChanged;
        }

    }
}