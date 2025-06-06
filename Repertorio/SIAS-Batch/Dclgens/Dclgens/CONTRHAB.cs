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
    public class CONTRHAB : VarBasis
    {
        /*"01  DCLCONTRATO-HABIT.*/
        public CONTRHAB_DCLCONTRATO_HABIT DCLCONTRATO_HABIT { get; set; } = new CONTRHAB_DCLCONTRATO_HABIT();

    }
}