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
    public class CB039_ICB_PESS_PENDENCIA : VarBasis
    {
        /*"    10 INDSTRUC           PIC S9(4) USAGE COMP OCCURS 6 TIMES.*/
        public ListBasis<IntBasis, Int64> INDSTRUC { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(4)"), 6);
        /*"*/
    }
}