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
    public class SINISHIS : VarBasis
    {
        /*"01  DCLSINISTRO-HISTORICO.*/
        public SINISHIS_DCLSINISTRO_HISTORICO DCLSINISTRO_HISTORICO { get; set; } = new SINISHIS_DCLSINISTRO_HISTORICO();

    }
}