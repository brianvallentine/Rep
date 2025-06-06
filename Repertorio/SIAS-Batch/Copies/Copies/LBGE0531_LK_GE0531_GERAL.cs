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
    public class LBGE0531_LK_GE0531_GERAL : VarBasis
    {
        /*"        10  LK-GE0531-COD-RETORNO       PIC  9(004) VALUE 0.*/
        public IntBasis LK_GE0531_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"        10  LK-GE0531-MSG-RETORNO       PIC  X(070) VALUE ' '.*/
        public StringBasis LK_GE0531_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @" ");
    }
}