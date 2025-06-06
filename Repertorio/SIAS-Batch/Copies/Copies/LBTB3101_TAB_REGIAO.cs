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
    public class LBTB3101_TAB_REGIAO : VarBasis
    {
        /*"  10   FILLER             PIC  X(013)  VALUE 'NORTE'*/
        public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"NORTE");
        /*"  10   FILLER             PIC  X(013)  VALUE 'CENTRO-OESTE'*/
        public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"CENTRO-OESTE");
        /*"  10   FILLER             PIC  X(013)  VALUE 'SUDESTE'*/
        public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"SUDESTE");
        /*"  10   FILLER             PIC  X(013)  VALUE 'SUL'*/
        public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"SUL");
        /*" 07     TAB-REGIAO-R      REDEFINES TAB-REGIAO*/
    }
}