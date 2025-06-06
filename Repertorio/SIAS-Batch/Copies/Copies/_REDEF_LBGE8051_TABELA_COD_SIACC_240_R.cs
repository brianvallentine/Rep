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
    public class _REDEF_LBGE8051_TABELA_COD_SIACC_240_R : VarBasis
    {
        /*"  10 TB-COD-SIACC-240  OCCURS 79 TIMES  INDEXED BY WS240*/
        public ListBasis<LBGE8051_TB_COD_SIACC_240> TB_COD_SIACC_240 { get; set; } = new ListBasis<LBGE8051_TB_COD_SIACC_240>(79);


        public _REDEF_LBGE8051_TABELA_COD_SIACC_240_R()
        {
            TB_COD_SIACC_240.ValueChanged += OnValueChanged;
        }

    }
}