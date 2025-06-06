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
    public class GE190 : VarBasis
    {
        /*"01  DCLGE-PARAM-APLICACAO.*/
        public GE190_DCLGE_PARAM_APLICACAO DCLGE_PARAM_APLICACAO { get; set; } = new GE190_DCLGE_PARAM_APLICACAO();

    }
}