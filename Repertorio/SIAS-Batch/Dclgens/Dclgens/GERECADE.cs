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
    public class GERECADE : VarBasis
    {
        /*"01  DCLGE-REL-CARTA-DEST.*/
        public GERECADE_DCLGE_REL_CARTA_DEST DCLGE_REL_CARTA_DEST { get; set; } = new GERECADE_DCLGE_REL_CARTA_DEST();

    }
}