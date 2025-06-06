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
    public class _REDEF_LBTB3101_TAB_CLASSES_R : VarBasis
    {
        /*"  10   TB-CLASSES         OCCURS 6  TIMES  PIC  X(001)*/
        public ListBasis<StringBasis, string> TB_CLASSES { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)"), 6);
        /*"01       TABELA-DE-COBERTURAS*/

        public _REDEF_LBTB3101_TAB_CLASSES_R()
        {
            TB_CLASSES.ValueChanged += OnValueChanged;
        }

    }
}