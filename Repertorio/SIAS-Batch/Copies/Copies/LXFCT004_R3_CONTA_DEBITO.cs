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
    public class LXFCT004_R3_CONTA_DEBITO : VarBasis
    {
        /*"       15  R3-AGECTADEB                PIC  9(004)*/
        public IntBasis R3_AGECTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"       15  R3-OPRCTADEB                PIC  9(004)*/
        public IntBasis R3_OPRCTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"       15  R3-NUMCTADEB                PIC  9(012)*/
        public IntBasis R3_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)"));
        /*"       15  R3-DIGCTADEB                PIC  9(001)*/
        public IntBasis R3_DIGCTADEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"     10    R3-CARTAO   REDEFINES   R3-CONTA-DEBITO*/
    }
}