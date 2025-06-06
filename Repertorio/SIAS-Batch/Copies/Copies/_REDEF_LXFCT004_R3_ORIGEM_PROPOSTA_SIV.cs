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
    public class _REDEF_LXFCT004_R3_ORIGEM_PROPOSTA_SIV : VarBasis
    {
        /*"       15  FILLER                      PIC  X(002)*/
        public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"       15  R3-ORIGEM-PROPOSTA          PIC  9(002)*/
        public IntBasis R3_ORIGEM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"     10    R3-NSAS                     PIC  9(006)*/

        public _REDEF_LXFCT004_R3_ORIGEM_PROPOSTA_SIV()
        {
            FILLER_1.ValueChanged += OnValueChanged;
            R3_ORIGEM_PROPOSTA.ValueChanged += OnValueChanged;
        }

    }
}