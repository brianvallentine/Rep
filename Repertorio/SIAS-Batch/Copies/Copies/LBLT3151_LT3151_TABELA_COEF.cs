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
    public class LBLT3151_LT3151_TABELA_COEF : VarBasis
    {
        /*"    10 LT3151-TAB-COEF              OCCURS 12 TIMES*/
        public ListBasis<LBLT3151_LT3151_TAB_COEF> LT3151_TAB_COEF { get; set; } = new ListBasis<LBLT3151_LT3151_TAB_COEF>(12);

    }
}