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
    public class LBTB3101_TAB_LIM_MINMAX : VarBasis
    {
        /*"    15   TB-LIM-MIN         PIC  X(17)*/
        public StringBasis TB_LIM_MIN { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"");
        /*"    15   TB-LIM-MAX         PIC  X(17)*/
        public StringBasis TB_LIM_MAX { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"");
        /*"01  TABELA-DE-LIMITE-MINMAX*/

        public LBTB3101_TAB_LIM_MINMAX()
        {
            TB_LIM_MIN.ValueChanged += OnValueChanged;
            TB_LIM_MAX.ValueChanged += OnValueChanged;
        }

    }
}