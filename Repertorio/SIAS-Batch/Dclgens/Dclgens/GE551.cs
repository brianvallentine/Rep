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
    public class GE551 : VarBasis
    {
        /*"01  DCLGE-DETALHE-ARQ-G-SAP.*/
        public GE551_DCLGE_DETALHE_ARQ_G_SAP DCLGE_DETALHE_ARQ_G_SAP { get; set; } = new GE551_DCLGE_DETALHE_ARQ_G_SAP();

    }
}