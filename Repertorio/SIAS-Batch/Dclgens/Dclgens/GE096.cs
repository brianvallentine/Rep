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
    public class GE096 : VarBasis
    {
        /*"01  DCLGE-BOLETO-EMISSAO.*/
        public GE096_DCLGE_BOLETO_EMISSAO DCLGE_BOLETO_EMISSAO { get; set; } = new GE096_DCLGE_BOLETO_EMISSAO();

    }
}