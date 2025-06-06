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
    public class _REDEF_LXFCT004_R3_CARTAO : VarBasis
    {
        /*"       15  FILLER                      PIC  X(005)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
        /*"       15  R3-NUM-CARTAO               PIC  9(016)*/
        public IntBasis R3_NUM_CARTAO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
        /*"     10    R3-DPS-TITULAR              PIC  X(007)*/

        public _REDEF_LXFCT004_R3_CARTAO()
        {
            FILLER.ValueChanged += OnValueChanged;
            R3_NUM_CARTAO.ValueChanged += OnValueChanged;
        }

    }
}