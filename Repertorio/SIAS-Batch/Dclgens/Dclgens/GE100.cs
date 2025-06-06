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
    public class GE100 : VarBasis
    {
        /*"01  DCLGE-CONTROLE-INTERF-SAP.*/
        public GE100_DCLGE_CONTROLE_INTERF_SAP DCLGE_CONTROLE_INTERF_SAP { get; set; } = new GE100_DCLGE_CONTROLE_INTERF_SAP();

    }
}