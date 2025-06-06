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
    public class SI155 : VarBasis
    {
        /*"01  DCLSI-MOV-HABIT-PAR.*/
        public SI155_DCLSI_MOV_HABIT_PAR DCLSI_MOV_HABIT_PAR { get; set; } = new SI155_DCLSI_MOV_HABIT_PAR();

    }
}