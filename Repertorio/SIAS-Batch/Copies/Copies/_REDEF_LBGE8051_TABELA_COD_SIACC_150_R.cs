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
    public class _REDEF_LBGE8051_TABELA_COD_SIACC_150_R : VarBasis
    {
        /*"   10 TB-COD-SIACC-150  OCCURS 118 TIMES  INDEXED BY WS150*/
        public ListBasis<LBGE8051_TB_COD_SIACC_150> TB_COD_SIACC_150 { get; set; } = new ListBasis<LBGE8051_TB_COD_SIACC_150>(118);


        public _REDEF_LBGE8051_TABELA_COD_SIACC_150_R()
        {
            TB_COD_SIACC_150.ValueChanged += OnValueChanged;
        }

    }
}