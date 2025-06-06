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
    public class MOEDACOT : VarBasis
    {
        /*"01  DCLMOEDAS-COTACAO.*/
        public MOEDACOT_DCLMOEDAS_COTACAO DCLMOEDAS_COTACAO { get; set; } = new MOEDACOT_DCLMOEDAS_COTACAO();

    }
}