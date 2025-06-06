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
    public class LBTB3201_TAB_CLASSES : VarBasis
    {
        /*"  10   FILLER             PIC  X(001)  VALUE 'A'*/
        public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"A");
        /*"  10   FILLER             PIC  X(001)  VALUE 'B'*/
        public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"B");
        /*"  10   FILLER             PIC  X(001)  VALUE 'C'*/
        public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"C");
        /*"  10   FILLER             PIC  X(001)  VALUE 'D'*/
        public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"D");
        /*"  10   FILLER             PIC  X(001)  VALUE 'E'*/
        public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"E");
        /*"  10   FILLER             PIC  X(001)  VALUE 'F'*/
        public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"F");
        /*" 07     TAB-CLASSES-R      REDEFINES       TAB-CLASSES*/
    }
}