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
    public class GE420 : VarBasis
    {
        /*"01  DCLGE-MOVTO-ENVIO-MCP.*/
        public GE420_DCLGE_MOVTO_ENVIO_MCP DCLGE_MOVTO_ENVIO_MCP { get; set; } = new GE420_DCLGE_MOVTO_ENVIO_MCP();

    }
}