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
    public class GECARTEX : VarBasis
    {
        /*"01  DCLGE-CARTA-TEXTO.*/
        public GECARTEX_DCLGE_CARTA_TEXTO DCLGE_CARTA_TEXTO { get; set; } = new GECARTEX_DCLGE_CARTA_TEXTO();

    }
}