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
    public class GE095 : VarBasis
    {
        /*"01  DCLGE-VIDA-SAP.*/
        public GE095_DCLGE_VIDA_SAP DCLGE_VIDA_SAP { get; set; } = new GE095_DCLGE_VIDA_SAP();

    }
}