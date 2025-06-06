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
    public class GE252 : VarBasis
    {
        /*"01  DCLGE-PRODUTO-MOEDA.*/
        public GE252_DCLGE_PRODUTO_MOEDA DCLGE_PRODUTO_MOEDA { get; set; } = new GE252_DCLGE_PRODUTO_MOEDA();

    }
}