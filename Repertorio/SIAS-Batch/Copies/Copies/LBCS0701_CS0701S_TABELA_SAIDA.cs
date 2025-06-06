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
    public class LBCS0701_CS0701S_TABELA_SAIDA : VarBasis
    {
        /*"    10     CS0701S-TAB-SAIDA       OCCURS      200 TIMES*/
        public ListBasis<LBCS0701_CS0701S_TAB_SAIDA> CS0701S_TAB_SAIDA { get; set; } = new ListBasis<LBCS0701_CS0701S_TAB_SAIDA>(200);

    }
}