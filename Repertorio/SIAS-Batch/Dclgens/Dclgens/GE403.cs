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
    public class GE403 : VarBasis
    {
        /*"01  DCLGE-CONTROLE-EMISSAO-SIGCB.*/
        public GE403_DCLGE_CONTROLE_EMISSAO_SIGCB DCLGE_CONTROLE_EMISSAO_SIGCB { get; set; } = new GE403_DCLGE_CONTROLE_EMISSAO_SIGCB();

    }
}