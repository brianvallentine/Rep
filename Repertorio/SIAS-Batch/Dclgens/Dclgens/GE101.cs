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
    public class GE101 : VarBasis
    {
        /*"01  DCLGE-ESTRUTURA-SAP.*/
        public GE101_DCLGE_ESTRUTURA_SAP DCLGE_ESTRUTURA_SAP { get; set; } = new GE101_DCLGE_ESTRUTURA_SAP();

    }
}