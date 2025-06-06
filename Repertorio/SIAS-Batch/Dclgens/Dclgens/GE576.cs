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
    public class GE576 : VarBasis
    {
        /*"01  DCLGE-RETORNO-ARQ-H-SAP.*/
        public GE576_DCLGE_RETORNO_ARQ_H_SAP DCLGE_RETORNO_ARQ_H_SAP { get; set; } = new GE576_DCLGE_RETORNO_ARQ_H_SAP();

    }
}