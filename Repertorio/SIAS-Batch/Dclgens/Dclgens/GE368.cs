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
    public class GE368 : VarBasis
    {
        /*"01  DCLGE-LEG-PESS-EVENTO.*/
        public GE368_DCLGE_LEG_PESS_EVENTO DCLGE_LEG_PESS_EVENTO { get; set; } = new GE368_DCLGE_LEG_PESS_EVENTO();

    }
}