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
    public class GE385 : VarBasis
    {
        /*"01  DCLGE-ROTINA-BATCH.*/
        public GE385_DCLGE_ROTINA_BATCH DCLGE_ROTINA_BATCH { get; set; } = new GE385_DCLGE_ROTINA_BATCH();

    }
}