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
    public class GE541 : VarBasis
    {
        /*"01  DCLGE-CONTROL-ARQ-H-SAP.*/
        public GE541_DCLGE_CONTROL_ARQ_H_SAP DCLGE_CONTROL_ARQ_H_SAP { get; set; } = new GE541_DCLGE_CONTROL_ARQ_H_SAP();

    }
}