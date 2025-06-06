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
    public class CALENDAR_DCLCALENDARIO : VarBasis
    {
        /*"    10 CALENDAR-DATA-CALENDARIO  PIC X(10).*/
        public StringBasis CALENDAR_DATA_CALENDARIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CALENDAR-DIA-SEMANA  PIC X(1).*/
        public StringBasis CALENDAR_DIA_SEMANA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CALENDAR-FERIADO     PIC X(1).*/
        public StringBasis CALENDAR_FERIADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CALENDAR-TIMESTAMP   PIC X(26).*/
        public StringBasis CALENDAR_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 CALENDAR-DTH-ULT-DIA-MES  PIC X(10).*/
        public StringBasis CALENDAR_DTH_ULT_DIA_MES { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
    }
}