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
    public class GECARTA : VarBasis
    {
        /*"01  DCLGE-CARTA.*/
        public GECARTA_DCLGE_CARTA DCLGE_CARTA { get; set; } = new GECARTA_DCLGE_CARTA();

    }
}