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
    public class LBTB3100_TAB_MESES : VarBasis
    {
        /*"     10   FILLER             PIC  X(009)  VALUE '  JANEIRO'*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  JANEIRO");
        /*"     10   FILLER             PIC  X(009)  VALUE 'FEVEREIRO'*/
        public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FEVEREIRO");
        /*"     10   FILLER             PIC  X(009)  VALUE '    MARCO'*/
        public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    MARCO");
        /*"     10   FILLER             PIC  X(009)  VALUE '    ABRIL'*/
        public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    ABRIL");
        /*"     10   FILLER             PIC  X(009)  VALUE '     MAIO'*/
        public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"     MAIO");
        /*"     10   FILLER             PIC  X(009)  VALUE '    JUNHO'*/
        public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JUNHO");
        /*"     10   FILLER             PIC  X(009)  VALUE '    JULHO'*/
        public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JULHO");
        /*"     10   FILLER             PIC  X(009)  VALUE '   AGOSTO'*/
        public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"   AGOSTO");
        /*"     10   FILLER             PIC  X(009)  VALUE ' SETEMBRO'*/
        public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" SETEMBRO");
        /*"     10   FILLER             PIC  X(009)  VALUE '  OUTUBRO'*/
        public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  OUTUBRO");
        /*"     10   FILLER             PIC  X(009)  VALUE ' NOVEMBRO'*/
        public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" NOVEMBRO");
        /*"     10   FILLER             PIC  X(009)  VALUE ' DEZEMBRO'*/
        public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" DEZEMBRO");
        /*"   07     TAB-MESES-R        REDEFINES          TAB-MESES*/
    }
}