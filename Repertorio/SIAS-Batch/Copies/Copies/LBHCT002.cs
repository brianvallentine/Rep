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
    public class LBHCT002 : VarBasis
    {
        /*"01      H-OUT-COD-RETORNO              PIC S9(004) COMP.*/

        public SelectorBasis H_OUT_COD_RETORNO { get; set; } = new SelectorBasis("004")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 H-OUT-RET-VALIDO        VALUE 00 */
							new SelectorItemBasis("H_OUT_RET_VALIDO", "00"),
							/*" 88 H-OUT-RET-OPER-INVALIDA VALUE 01 */
							new SelectorItemBasis("H_OUT_RET_OPER_INVALIDA", "01")
                }
        };

        /*"01      H-OUT-COD-RETORNO-SQL           PIC S9(004) COMP.*/
        public IntBasis H_OUT_COD_RETORNO_SQL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01      H-OUT-MENSAGEM                  PIC X(070).*/
        public StringBasis H_OUT_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01      H-OUT-SQLERRMC                  PIC X(070).*/
        public StringBasis H_OUT_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01      H-OUT-SQLSTATE                  PIC X(005).*/
        public StringBasis H_OUT_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
    }
}