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
    public class GE318 : VarBasis
    {
        /*"01  DCLGE-DNE-LOG-UF.*/
        public GE318_DCLGE_DNE_LOG_UF DCLGE_DNE_LOG_UF { get; set; } = new GE318_DCLGE_DNE_LOG_UF();

    }
}