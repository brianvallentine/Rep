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
    public class JVBKINCL_JV_AGE_AVISO : VarBasis
    {
        /*"  05  CVPAG-996                    PIC S9(003) COMP-5                                               VALUE 828*/
        public IntBasis CVPAG_996 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), 828);
        /*"  05  JVPAG-996                    PIC S9(003) COMP-5                                               VALUE 556*/
        public IntBasis JVPAG_996 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), 556);
        /*"  05  CVPAG-005                    PIC S9(003) COMP-5                                               VALUE 800*/
        public IntBasis CVPAG_005 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), 800);
        /*"  05  JVPAG-005                    PIC S9(003) COMP-5                                               VALUE 557*/
        public IntBasis JVPAG_005 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), 557);
        /*"01    JV-PRODUTOS*/
    }
}