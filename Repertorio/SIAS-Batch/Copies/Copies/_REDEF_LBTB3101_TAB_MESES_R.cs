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
    public class _REDEF_LBTB3101_TAB_MESES_R : VarBasis
    {
        /*"  10 TB-MESES  OCCURS 12 TIMES  INDEXED BY WS-MES*/
        public ListBasis<LBTB3101_TB_MESES> TB_MESES { get; set; } = new ListBasis<LBTB3101_TB_MESES>(12);


        public _REDEF_LBTB3101_TAB_MESES_R()
        {
            TB_MESES.ValueChanged += OnValueChanged;
        }

    }
}