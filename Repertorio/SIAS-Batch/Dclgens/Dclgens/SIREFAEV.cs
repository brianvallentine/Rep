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
    public class SIREFAEV : VarBasis
    {
        /*"01  DCLSI-REL-FASE-EVENTO.*/
        public SIREFAEV_DCLSI_REL_FASE_EVENTO DCLSI_REL_FASE_EVENTO { get; set; } = new SIREFAEV_DCLSI_REL_FASE_EVENTO();

    }
}