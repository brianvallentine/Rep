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
    public class GE407 : VarBasis
    {
        /*"01  DCLGE-CONTROLE-CARTAO-CIELO.*/
        public GE407_DCLGE_CONTROLE_CARTAO_CIELO DCLGE_CONTROLE_CARTAO_CIELO { get; set; } = new GE407_DCLGE_CONTROLE_CARTAO_CIELO();

    }
}