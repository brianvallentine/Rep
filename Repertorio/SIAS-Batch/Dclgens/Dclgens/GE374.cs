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
    public class GE374 : VarBasis
    {
        /*"01  DCLGE-CNAE-ATIVIDADE.*/
        public GE374_DCLGE_CNAE_ATIVIDADE DCLGE_CNAE_ATIVIDADE { get; set; } = new GE374_DCLGE_CNAE_ATIVIDADE();

    }
}