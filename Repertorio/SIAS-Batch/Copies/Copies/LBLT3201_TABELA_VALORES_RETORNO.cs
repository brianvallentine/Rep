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
    public class LBLT3201_TABELA_VALORES_RETORNO : VarBasis
    {
        /*"     10 TABELA-VALORES-RET OCCURS 5 TIMES*/
        public ListBasis<LBLT3201_TABELA_VALORES_RET> TABELA_VALORES_RET { get; set; } = new ListBasis<LBLT3201_TABELA_VALORES_RET>(5);

    }
}