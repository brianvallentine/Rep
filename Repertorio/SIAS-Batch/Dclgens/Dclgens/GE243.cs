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
    public class GE243 : VarBasis
    {
        /*"01  DCLGE-FAIXA-RENDA.*/
        public GE243_DCLGE_FAIXA_RENDA DCLGE_FAIXA_RENDA { get; set; } = new GE243_DCLGE_FAIXA_RENDA();

    }
}