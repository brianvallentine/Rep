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
    public class VATBFREN : VarBasis
    {
        /*"01       VATBFREN-TABELA-FAIXA-RENDA*/
        public VATBFREN_VATBFREN_TABELA_FAIXA_RENDA VATBFREN_TABELA_FAIXA_RENDA { get; set; } = new VATBFREN_VATBFREN_TABELA_FAIXA_RENDA();

    }
}