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
    public class GE097 : VarBasis
    {
        /*"01  DCLGE-CHEQUE-SAP.*/
        public GE097_DCLGE_CHEQUE_SAP DCLGE_CHEQUE_SAP { get; set; } = new GE097_DCLGE_CHEQUE_SAP();

    }
}