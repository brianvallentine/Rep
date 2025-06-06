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
    public class ENDHABIT : VarBasis
    {
        /*"01  DCLENDERECO-HABIT.*/
        public ENDHABIT_DCLENDERECO_HABIT DCLENDERECO_HABIT { get; set; } = new ENDHABIT_DCLENDERECO_HABIT();

    }
}