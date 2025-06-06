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
    public class CALENDAR : VarBasis
    {
        /*"01  DCLCALENDARIO.*/
        public CALENDAR_DCLCALENDARIO DCLCALENDARIO { get; set; } = new CALENDAR_DCLCALENDARIO();

    }
}