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
    public class _REDEF_LBTB3100_TAB_MESES_R : VarBasis
    {
        /*"     10   TAB-MES            OCCURS 12 TIMES                                PIC  X(009)*/
        public ListBasis<StringBasis, string> TAB_MES { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "9", "X(009)"), 12);
        /*"01 TABELA-UF*/

        public _REDEF_LBTB3100_TAB_MESES_R()
        {
            TAB_MES.ValueChanged += OnValueChanged;
        }

    }
}