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
    public class GE089 : VarBasis
    {
        /*"01  DCLGE-PRODUTO-COMPLEMENTO.*/
        public GE089_DCLGE_PRODUTO_COMPLEMENTO DCLGE_PRODUTO_COMPLEMENTO { get; set; } = new GE089_DCLGE_PRODUTO_COMPLEMENTO();

    }
}