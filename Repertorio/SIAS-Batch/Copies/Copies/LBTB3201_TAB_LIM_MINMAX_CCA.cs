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
    public class LBTB3201_TAB_LIM_MINMAX_CCA : VarBasis
    {
        /*"    15   TB-LIM-MIN-CCA     PIC  X(17)*/
        public StringBasis TB_LIM_MIN_CCA { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"");
        /*"    15   TB-LIM-MAX-CCA     PIC  X(17)*/
        public StringBasis TB_LIM_MAX_CCA { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"");
        /*"01  TABELA-DE-LIMITE-MINMAX-CCA*/

        public LBTB3201_TAB_LIM_MINMAX_CCA()
        {
            TB_LIM_MIN_CCA.ValueChanged += OnValueChanged;
            TB_LIM_MAX_CCA.ValueChanged += OnValueChanged;
        }

    }
}