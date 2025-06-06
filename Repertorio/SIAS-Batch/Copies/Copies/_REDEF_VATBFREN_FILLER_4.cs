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
    public class _REDEF_VATBFREN_FILLER_4 : VarBasis
    {
        /*"      05 VATBFREN-REND-IND-LIMITE  PIC S9(09)V99  OCCURS 5 TIMES*/
        public ListBasis<DoubleBasis, double> VATBFREN_REND_IND_LIMITE { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "9", "S9(09)V99"), 5);

        public _REDEF_VATBFREN_FILLER_4()
        {
            VATBFREN_REND_IND_LIMITE.ValueChanged += OnValueChanged;
        }

    }
}