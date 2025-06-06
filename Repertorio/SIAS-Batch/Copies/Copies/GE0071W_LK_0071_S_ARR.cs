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
    public class GE0071W_LK_0071_S_ARR : VarBasis
    {
        /*"  05  LK-0071-S-ARR-OCC              OCCURS 030 TIMES*/
        public ListBasis<GE0071W_LK_0071_S_ARR_OCC> LK_0071_S_ARR_OCC { get; set; } = new ListBasis<GE0071W_LK_0071_S_ARR_OCC>(030);

        public IntBasis LK_0071_IND_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  01   LK-0071-MSG-ERRO               PIC  X(255)*/
        public StringBasis LK_0071_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
        /*"  01   LK-0071-NOM-TABELA             PIC  X(036)*/
        public StringBasis LK_0071_NOM_TABELA { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
        /*"  01   LK-0071-SQLCODE                PIC S9(004) COMP-5*/
        public IntBasis LK_0071_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  01   LK-0071-SQLERRMC               PIC  X(070)*/
        public StringBasis LK_0071_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*"  01   LK-0071-SQLSTATE               PIC  X(005)*/
        public StringBasis LK_0071_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
        /*"*/
    }
}