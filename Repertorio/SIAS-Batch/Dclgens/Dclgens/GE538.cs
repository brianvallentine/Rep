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
    public class GE538 : VarBasis
    {
        /*"01  DCLGE-EVENTO-AP-CA-SAP.*/
        public GE538_DCLGE_EVENTO_AP_CA_SAP DCLGE_EVENTO_AP_CA_SAP { get; set; } = new GE538_DCLGE_EVENTO_AP_CA_SAP();

    }
}