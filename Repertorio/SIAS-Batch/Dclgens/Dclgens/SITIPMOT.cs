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
    public class SITIPMOT : VarBasis
    {
        /*"01  DCLSI-TIPO-MOTIVO.*/
        public SITIPMOT_DCLSI_TIPO_MOTIVO DCLSI_TIPO_MOTIVO { get; set; } = new SITIPMOT_DCLSI_TIPO_MOTIVO();

    }
}