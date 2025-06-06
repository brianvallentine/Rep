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
    public class _REDEF_LBTB3201_TAB_REGIAO_R : VarBasis
    {
        /*"  10   TB-REGIAO          OCCURS 4  TIMES                              PIC  X(013)*/
        public ListBasis<StringBasis, string> TB_REGIAO { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "13", "X(013)"), 4);
        /*"01       TABELA-CLASSES*/

        public _REDEF_LBTB3201_TAB_REGIAO_R()
        {
            TB_REGIAO.ValueChanged += OnValueChanged;
        }

    }
}