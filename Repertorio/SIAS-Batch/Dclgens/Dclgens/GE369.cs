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
    public class GE369 : VarBasis
    {
        /*"01  DCLGE-MOVTO-CONTA.*/
        public GE369_DCLGE_MOVTO_CONTA DCLGE_MOVTO_CONTA { get; set; } = new GE369_DCLGE_MOVTO_CONTA();

    }
}