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
    public class GE408 : VarBasis
    {
        /*"01  DCLGE-RETORNO-CA-CIELO.*/
        public GE408_DCLGE_RETORNO_CA_CIELO DCLGE_RETORNO_CA_CIELO { get; set; } = new GE408_DCLGE_RETORNO_CA_CIELO();

    }
}