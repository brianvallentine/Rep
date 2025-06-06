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
    public class GE284 : VarBasis
    {
        /*"01  DCLGE-SISTEMA-ORIGEM.*/
        public GE284_DCLGE_SISTEMA_ORIGEM DCLGE_SISTEMA_ORIGEM { get; set; } = new GE284_DCLGE_SISTEMA_ORIGEM();

    }
}