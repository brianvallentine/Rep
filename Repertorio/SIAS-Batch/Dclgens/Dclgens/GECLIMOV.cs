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
    public class GECLIMOV : VarBasis
    {
        /*"01  DCLGE-CLIENTES-MOVTO.*/
        public GECLIMOV_DCLGE_CLIENTES_MOVTO DCLGE_CLIENTES_MOVTO { get; set; } = new GECLIMOV_DCLGE_CLIENTES_MOVTO();

    }
}