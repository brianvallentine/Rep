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
    public class LBTB3201_TAB_LIM_MINMAX_CCAT : VarBasis
    {
        /*"    15   TB-LIM-MIN-CCAT     PIC  X(17)*/
        public StringBasis TB_LIM_MIN_CCAT { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"");
        /*"    15   TB-LIM-MAX-CCAT     PIC  X(17)*/
        public StringBasis TB_LIM_MAX_CCAT { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"");
        /*"01  TABELA-DE-LIMITE-MINMAX-CCAT*/

        public LBTB3201_TAB_LIM_MINMAX_CCAT()
        {
            TB_LIM_MIN_CCAT.ValueChanged += OnValueChanged;
            TB_LIM_MAX_CCAT.ValueChanged += OnValueChanged;
        }

    }
}