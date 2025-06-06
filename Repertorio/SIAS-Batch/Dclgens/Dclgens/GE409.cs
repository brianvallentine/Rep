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
    public class GE409 : VarBasis
    {
        /*"01  DCLGE-DES-RETORNO-CIELO.*/
        public GE409_DCLGE_DES_RETORNO_CIELO DCLGE_DES_RETORNO_CIELO { get; set; } = new GE409_DCLGE_DES_RETORNO_CIELO();

    }
}