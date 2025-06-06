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
    public class GE332 : VarBasis
    {
        /*"01  DCLGE-DNE-FAIXA-UF.*/
        public GE332_DCLGE_DNE_FAIXA_UF DCLGE_DNE_FAIXA_UF { get; set; } = new GE332_DCLGE_DNE_FAIXA_UF();

    }
}