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
    public class GE552 : VarBasis
    {
        /*"01  DCLGE-CONTROL-ARQ-G-SAP.*/
        public GE552_DCLGE_CONTROL_ARQ_G_SAP DCLGE_CONTROL_ARQ_G_SAP { get; set; } = new GE552_DCLGE_CONTROL_ARQ_G_SAP();

    }
}