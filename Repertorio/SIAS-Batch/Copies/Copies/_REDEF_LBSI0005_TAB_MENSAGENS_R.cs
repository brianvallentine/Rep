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
    public class _REDEF_LBSI0005_TAB_MENSAGENS_R : VarBasis
    {
        /*"    10       TB-OCORREMSG       OCCURS 34 TIMES                       INDEXED BY WS-IND-TB*/
        public ListBasis<LBSI0005_TB_OCORREMSG> TB_OCORREMSG { get; set; } = new ListBasis<LBSI0005_TB_OCORREMSG>(34);


        public _REDEF_LBSI0005_TAB_MENSAGENS_R()
        {
            TB_OCORREMSG.ValueChanged += OnValueChanged;
        }

    }
}