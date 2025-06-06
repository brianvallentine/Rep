using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class EF072 : VarBasis
    {
        /*"01  DCLEF-CONTR-SEG-HABIT.*/
        public EF072_DCLEF_CONTR_SEG_HABIT DCLEF_CONTR_SEG_HABIT { get; set; } = new EF072_DCLEF_CONTR_SEG_HABIT();

    }
}