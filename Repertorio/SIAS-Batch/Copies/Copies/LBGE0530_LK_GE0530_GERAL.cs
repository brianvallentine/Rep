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
    public class LBGE0530_LK_GE0530_GERAL : VarBasis
    {
        /*"        10  LK-GE0530-COD-RETORNO       PIC  9(004) VALUE   0*/
        public IntBasis LK_GE0530_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"        10  LK-GE0530-MSG-RETORNO       PIC  X(070) VALUE ' '*/
        public StringBasis LK_GE0530_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @" ");
        /*"        10  LK-GE0530-IND-RESTRICAO     PIC  X(001) VALUE ' '*/
        public StringBasis LK_GE0530_IND_RESTRICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
        /*"    05  LK-GE0530-RELATORIOS*/
    }
}