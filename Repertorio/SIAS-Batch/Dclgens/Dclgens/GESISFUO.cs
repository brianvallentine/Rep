using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class GESISFUO : VarBasis
    {
        /*"01  DCLGE-SIS-FUNCAO-OPER.*/
        public GESISFUO_DCLGE_SIS_FUNCAO_OPER DCLGE_SIS_FUNCAO_OPER { get; set; } = new GESISFUO_DCLGE_SIS_FUNCAO_OPER();

    }
}