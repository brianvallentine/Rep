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
    public class _REDEF_JVBKINCL_FILLER : VarBasis
    {
        /*"  02  JVPROD                       PIC S9(004) COMP-5                                    OCCURS 9999 TIMES*/
        public ListBasis<IntBasis, Int64> JVPROD { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 9999);
        /*"01    CVP-PRODUTOS-RUNOFF*/

        public _REDEF_JVBKINCL_FILLER()
        {
            JVPROD.ValueChanged += OnValueChanged;
        }

    }
}