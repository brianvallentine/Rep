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
    public class GE105 : VarBasis
    {
        /*"01  DCLGE-CONTROLE-ARQH.*/
        public GE105_DCLGE_CONTROLE_ARQH DCLGE_CONTROLE_ARQH { get; set; } = new GE105_DCLGE_CONTROLE_ARQH();

    }
}