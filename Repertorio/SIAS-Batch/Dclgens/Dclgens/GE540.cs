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
    public class GE540 : VarBasis
    {
        /*"01  DCLGE-DETALHE-ARQ-H-SAP.*/
        public GE540_DCLGE_DETALHE_ARQ_H_SAP DCLGE_DETALHE_ARQ_H_SAP { get; set; } = new GE540_DCLGE_DETALHE_ARQ_H_SAP();

    }
}