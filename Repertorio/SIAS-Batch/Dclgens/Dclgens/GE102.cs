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
    public class GE102 : VarBasis
    {
        /*"01  DCLGE-ARQUIVO-SAP.*/
        public GE102_DCLGE_ARQUIVO_SAP DCLGE_ARQUIVO_SAP { get; set; } = new GE102_DCLGE_ARQUIVO_SAP();

    }
}