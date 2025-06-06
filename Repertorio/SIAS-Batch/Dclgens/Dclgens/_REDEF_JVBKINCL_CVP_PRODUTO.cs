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
    public class _REDEF_JVBKINCL_CVP_PRODUTO : VarBasis
    {
        /*"  03  CVPPROD                      PIC S9(004) COMP-5                                   OCCURS 669 TIMES                                   INDEXED BY WS-IND-PROD*/
        public ListBasis<IntBasis, Int64> CVPPROD { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 669);

        public _REDEF_JVBKINCL_CVP_PRODUTO()
        {
            CVPPROD.ValueChanged += OnValueChanged;
        }

    }
}