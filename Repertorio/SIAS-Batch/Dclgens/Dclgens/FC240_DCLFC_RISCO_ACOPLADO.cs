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
    public class FC240_DCLFC_RISCO_ACOPLADO : VarBasis
    {
        /*"    10 FC240-NUM-PLANO      PIC S9(4) USAGE COMP.*/
        public IntBasis FC240_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FC240-NUM-TITULO     PIC S9(9) USAGE COMP.*/
        public IntBasis FC240_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FC240-IDE-SERIEPADRAO       PIC S9(4) USAGE COMP.*/
        public IntBasis FC240_IDE_SERIEPADRAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FC240-QTD-TITULOS    PIC S9(4) USAGE COMP.*/
        public IntBasis FC240_QTD_TITULOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
    }
}