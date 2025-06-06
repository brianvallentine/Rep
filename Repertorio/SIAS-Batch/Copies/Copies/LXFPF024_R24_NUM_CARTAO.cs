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
    public class LXFPF024_R24_NUM_CARTAO : VarBasis
    {
        /*"          20 R24-FAIXA-CARTAO          PIC  9(006)*/
        public IntBasis R24_FAIXA_CARTAO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"          20 R24-PIN-CARTAO            PIC  9(010)*/
        public IntBasis R24_PIN_CARTAO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
        /*"       15 R24-NUM-CARTAO-R          REDEFINES          R24-NUM-CARTAO               PIC  9(016)*/

        public LXFPF024_R24_NUM_CARTAO()
        {
            R24_FAIXA_CARTAO.ValueChanged += OnValueChanged;
            R24_PIN_CARTAO.ValueChanged += OnValueChanged;
        }

    }
}