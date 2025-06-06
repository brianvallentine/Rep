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
    public class LBLT3159_LT3159S_TABELA_SAIDA : VarBasis
    {
        /*"    10     LT3159S-TAB-SAIDA       OCCURS      99  TIMES*/
        public ListBasis<LBLT3159_LT3159S_TAB_SAIDA> LT3159S_TAB_SAIDA { get; set; } = new ListBasis<LBLT3159_LT3159S_TAB_SAIDA>(99);

    }
}