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
    public class GE118 : VarBasis
    {
        /*"01  DCLGE-PRODUTO-COBERTURA.*/
        public GE118_DCLGE_PRODUTO_COBERTURA DCLGE_PRODUTO_COBERTURA { get; set; } = new GE118_DCLGE_PRODUTO_COBERTURA();

    }
}