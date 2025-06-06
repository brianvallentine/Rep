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
    public class GE094 : VarBasis
    {
        /*"01  DCLGE-MOVDEBCE-SAP.*/
        public GE094_DCLGE_MOVDEBCE_SAP DCLGE_MOVDEBCE_SAP { get; set; } = new GE094_DCLGE_MOVDEBCE_SAP();

    }
}