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
    public class LBWCT002_PROTOCOLO_ENVIO : VarBasis
    {
        /*"      10  OUT-COD-RETORNO               PIC S9(004) COMP.*/

        public SelectorBasis OUT_COD_RETORNO { get; set; } = new SelectorBasis("004")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 OUT-RET-VALIDO        VALUE 00 */
							new SelectorItemBasis("OUT_RET_VALIDO", "00"),
							/*" 88 OUT-RET-OPER-INVALIDA VALUE 01 */
							new SelectorItemBasis("OUT_RET_OPER_INVALIDA", "01")
                }
        };

        /*"      10  OUT-COD-RETORNO-SQL           PIC S9(004) COMP.*/
        public IntBasis OUT_COD_RETORNO_SQL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"      10  OUT-MENSAGEM                  PIC X(070).*/
        public StringBasis OUT_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"      10  OUT-SQLERRMC                  PIC X(070).*/
        public StringBasis OUT_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"      10  OUT-SQLSTATE                  PIC X(005).*/
        public StringBasis OUT_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
    }
}