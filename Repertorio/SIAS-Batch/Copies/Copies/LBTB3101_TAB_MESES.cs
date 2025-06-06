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
    public class LBTB3101_TAB_MESES : VarBasis
    {
        /*"  10   FILLER             PIC  X(011)  VALUE '01JANEIRO  '*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"01JANEIRO  ");
        /*"  10   FILLER             PIC  X(011)  VALUE '02FEVEREIRO'*/
        public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"02FEVEREIRO");
        /*"  10   FILLER             PIC  X(011)  VALUE '03MARCO    '*/
        public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"03MARCO    ");
        /*"  10   FILLER             PIC  X(011)  VALUE '04ABRIL    '*/
        public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"04ABRIL    ");
        /*"  10   FILLER             PIC  X(011)  VALUE '05MAIO     '*/
        public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"05MAIO     ");
        /*"  10   FILLER             PIC  X(011)  VALUE '06JUNHO    '*/
        public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"06JUNHO    ");
        /*"  10   FILLER             PIC  X(011)  VALUE '07JULHO    '*/
        public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"07JULHO    ");
        /*"  10   FILLER             PIC  X(011)  VALUE '08AGOSTO   '*/
        public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"08AGOSTO   ");
        /*"  10   FILLER             PIC  X(011)  VALUE '09SETEMBRO '*/
        public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"09SETEMBRO ");
        /*"  10   FILLER             PIC  X(011)  VALUE '10OUTUBRO  '*/
        public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"10OUTUBRO  ");
        /*"  10   FILLER             PIC  X(011)  VALUE '11NOVEMBRO '*/
        public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"11NOVEMBRO ");
        /*"  10   FILLER             PIC  X(011)  VALUE '12DEZEMBRO '*/
        public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"12DEZEMBRO ");
        /*" 07 TAB-MESES-R  REDEFINES  TAB-MESES*/
    }
}