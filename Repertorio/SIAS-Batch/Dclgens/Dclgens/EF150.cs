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
    public class EF150 : VarBasis
    {
        /*"01  DCLEF-ENVIO-MOVTO-SAP.*/
        public EF150_DCLEF_ENVIO_MOVTO_SAP DCLEF_ENVIO_MOVTO_SAP { get; set; } = new EF150_DCLEF_ENVIO_MOVTO_SAP();

    }
}