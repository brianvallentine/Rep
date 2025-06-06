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
    public class FERIADOS_DCLFERIADOS : VarBasis
    {
        /*"    10 FERIADOS-DATA-FERIADO  PIC X(10).*/
        public StringBasis FERIADOS_DATA_FERIADO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FERIADOS-DESCRICAO   PIC X(40).*/
        public StringBasis FERIADOS_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 FERIADOS-TIPO-FERIADO  PIC X(1).*/
        public StringBasis FERIADOS_TIPO_FERIADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FERIADOS-SIT-REGISTRO  PIC X(1).*/
        public StringBasis FERIADOS_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FERIADOS-TIMESTAMP   PIC X(26).*/
        public StringBasis FERIADOS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}