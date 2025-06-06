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
    public class GE387 : VarBasis
    {
        /*"01  DCLGE-EXEC-ROTINA-ETAPA.*/
        public GE387_DCLGE_EXEC_ROTINA_ETAPA DCLGE_EXEC_ROTINA_ETAPA { get; set; } = new GE387_DCLGE_EXEC_ROTINA_ETAPA();

    }
}