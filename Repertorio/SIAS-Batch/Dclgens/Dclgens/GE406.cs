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
    public class GE406 : VarBasis
    {
        /*"01  DCLGE-RETENCAO-PROPOSTA.*/
        public GE406_DCLGE_RETENCAO_PROPOSTA DCLGE_RETENCAO_PROPOSTA { get; set; } = new GE406_DCLGE_RETENCAO_PROPOSTA();

    }
}