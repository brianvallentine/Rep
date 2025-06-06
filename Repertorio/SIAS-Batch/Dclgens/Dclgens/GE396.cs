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
    public class GE396 : VarBasis
    {
        /*"01  DCLGE-SINISTRO-ANALITICO.*/
        public GE396_DCLGE_SINISTRO_ANALITICO DCLGE_SINISTRO_ANALITICO { get; set; } = new GE396_DCLGE_SINISTRO_ANALITICO();

    }
}