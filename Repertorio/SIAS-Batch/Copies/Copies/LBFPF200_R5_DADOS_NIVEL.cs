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
    public class LBFPF200_R5_DADOS_NIVEL : VarBasis
    {
        /*"           15 R5-NUM-NIVEL-CARGO          PIC  9(002)*/
        public IntBasis R5_NUM_NIVEL_CARGO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"           15 R5-IMP-SEGURADA             PIC  9(013)V99*/
        public DoubleBasis R5_IMP_SEGURADA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"           15 R5-QUANTIDADE-VIDAS         PIC  9(003)*/
        public IntBasis R5_QUANTIDADE_VIDAS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"        10       FILLER                   PIC  X(005)*/

        public LBFPF200_R5_DADOS_NIVEL()
        {
            R5_NUM_NIVEL_CARGO.ValueChanged += OnValueChanged;
            R5_IMP_SEGURADA.ValueChanged += OnValueChanged;
            R5_QUANTIDADE_VIDAS.ValueChanged += OnValueChanged;
        }

    }
}